Imports DDCenter.IniFile
Public Class frmsetting
    Dim inifile As IniFile
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        inifile = New IniFile
        With inifile
            .AddSection("host").AddKey("ip").Value = txtiphost.Text
            .AddSection("host").AddKey("user").Value = txtuserhost.Text
            .AddSection("host").AddKey("pwd").Value = txtpasshost.Text
            .Save(Application.StartupPath + "/setting.ini")
        End With
        MsgBox("Data telah tersimpan")
        Me.Close()
        Application.Restart()
    End Sub

    Private Sub frmsetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inifile = New IniFile
        inifile.Load(Application.StartupPath + "/setting.ini")
        txtiphost.Text = inifile.GetKeyValue("host", "ip")
        txtuserhost.Text = inifile.GetKeyValue("host", "user")
        txtpasshost.Text = inifile.GetKeyValue("host", "pwd")
    End Sub
End Class