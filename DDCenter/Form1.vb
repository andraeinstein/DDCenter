Imports MySql.Data.MySqlClient
Imports System.Threading
Public Class Form1
    Dim onoff As String
    Dim statusserver As String
    Dim cthread As Thread

    Private Sub btnsetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetting.Click
        frmsetting.ShowDialog()
    End Sub
    Sub proses()
        Dim nama, tgl_input As String
        Try
            SQLCari("select o.tgl_input,o.pesan,c.nama from outbox o,cabang c where o.id_cabang=c.id order by o.id limit 1")
            If objDataTable.Rows.Count > 0 Then
                nama = objDataTable.Rows(0).Item("nama").ToString
                tgl_input = objDataTable.Rows(0).Item("tgl_input").ToString
                txtlog.AppendText(tgl_input & " >>> Dari " & nama & " | " & objDataTable.Rows(0).Item("pesan").ToString & " " + Environment.NewLine)
                'data dilempar ke server VRE
                SQLQuery("insert into federated_sms_inbox(sourceno,nama,tgl,text,port,ip,iscentre,istrx,idmember) " _
                    & "select o.hp,m.nama,now(),o.pesan,'10','192.168.2.7',1,1,m.id_member from federated_member m,federated_member_hp h, " _
                    & "outbox o where h.id_member=m.id_member and h.hp=o.hp order by o.id limit 1;")
                SQLQuery("delete from outbox order by id limit 1")
            End If
        Catch ex As Exception
            txtlog.AppendText("Proses Gagal " + Environment.NewLine)
        End Try

        Try
            Dim i, reply As String
            Dim j As Integer
            SQLCari("select idmember,jumlah,pesan from deposit where pesan is null order by id limit 1")
            If objDataTable.Rows.Count > 0 Then
                i = objDataTable.Rows(0).Item("idmember").ToString
                j = objDataTable.Rows(0).Item("jumlah").ToString
                txtlog.AppendText(tgl_input & " >>> Dari " & nama & " | " & objDataTable.Rows(0).Item("pesan").ToString & " " + Environment.NewLine)
                'data dilempar ke server VRE
                SQLCari("select reply from federated_sms_komplain where pesan regexp '[[:<:]]" & i & "." & j & "[[:>:]]' AND TGL_SMS>(curdate())")
                If objDataTable.Rows.Count > 0 Then
                    reply = objDataTable.Rows(0).Item("reply").ToString
                    SQLQuery("update deposit set pesan='" & reply & "' where idmember='" & i & "' and jumlah=" & j & "")
                End If
            End If
        Catch ex As Exception
            txtlog.AppendText("Ambil data deposit gagal " + Environment.NewLine)
            txtlog.AppendText(ex.ToString + Environment.NewLine)
        End Try
    End Sub

    Sub terima()
        Try
            SQLCari("select so.tgl_input,so.pesan,so.id,c.nama from federated_sms_outbox so,cabang c " _
                                      & "where so.com='20' and (so.no_hp=c.no_hp or so.no_hp=c.no_hp2) order by so.id limit 1")
            If objDataTable.Rows.Count > 0 Then
                txtlog.AppendText(objDataTable.Rows(0).Item("tgl_input").ToString & " <<< Untuk " & objDataTable.Rows(0).Item("nama").ToString & " | " & objDataTable.Rows(0).Item("pesan").ToString & " " + Environment.NewLine)
                'data dilempar ke server VRE
                SQLQuery("insert into inbox(tgl_input,pesan,id_cabang,hp) " _
                    & "select now(),so.pesan,c.id,so.no_hp from federated_sms_outbox so, cabang c " _
                    & "where so.com='20' and (so.no_hp=c.no_hp or so.no_hp=c.no_hp2) order by so.id limit 1;")
                SQLQuery("insert into federated_sms_history(tgl_input,no_hp,nama,pesan,tipe,tgl_sms,com) " _
                    & "select tgl_input,no_hp,nama,pesan,1,now(),com from federated_sms_outbox so " _
                    & "where so.com='20' order by so.id limit 1;")
                SQLQuery("delete from federated_sms_outbox where com='20' order by id limit 1")
            End If
        Catch ex As Exception
            txtlog.AppendText(ex.ToString)
        End Try
    End Sub

    Sub setstatusserver()
        Try
            SQLQuery("update status_server set status=" & statusserver & "")
        Catch ex As Exception
            txtlog.AppendText(ex.ToString)
        End Try
    End Sub

    Private Sub btnonoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnonoff.Click
        If onoff = "on" Then
            btnonoff.BackgroundImage = My.Resources.Off_Button
            timerproses.Start()
            onoff = "off"
            btnsetting.Enabled = False
            statusserver = 1
            cthread = New Thread(AddressOf setstatusserver)
            cthread.Start()
            txtlog.AppendText("~ Processor center diaktifkan" + Environment.NewLine)
        Else
            btnonoff.BackgroundImage = My.Resources.On_Button
            timerproses.Stop()
            onoff = "on"
            btnsetting.Enabled = True
            statusserver = 0
            cthread = New Thread(AddressOf setstatusserver)
            cthread.Start()
            txtlog.AppendText("~ Processor center dinonaktifkan" + Environment.NewLine)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        onoff = "on"
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub timerproses_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerproses.Tick
        Call proses()
        Call terima()
        If txtlog.Lines.Count = 100 Then
            txtlog.Clear()
        End If
    End Sub
End Class