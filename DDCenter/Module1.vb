Imports MySql.Data.MySqlClient
Module Module1
    Dim inifile As IniFile
    Public ip, user, pwd, ipvre, uservre, pwdvre As String

    Public Sub atur()
        inifile = New IniFile
        inifile.Load(Application.StartupPath + "/setting.ini")
        ip = inifile.GetKeyValue("host", "ip")
        user = inifile.GetKeyValue("host", "user")
        pwd = inifile.GetKeyValue("host", "pwd")
    End Sub

    Public objCommand As MySqlCommand
    Public objDataSet As New DataSet
    Public objDataTable As New DataTable
    Public objDataReader As MySqlDataReader
    Public objDataAdapter As New MySqlDataAdapter
    Public StrSQL As String
    Public myConnectionString As String
    Public cek As MySqlDataReader
    Public ds As New DataSet

    Public Sub SQLQuery(ByVal SQCommand As String)
        Call atur()
        Dim koneksi As New MySqlConnection("Server='" & ip & "';port=3306;user id='" & user & "';password='" & pwd & "';database='ddsender'")
        Dim SQLCMD As New MySqlCommand(SQCommand, koneksi)
        koneksi.Open()
        SQLCMD.ExecuteNonQuery()
        koneksi.Close()
    End Sub

    Public Sub SQLCari(ByVal SQCommand As String)
        Call atur()
        objDataTable = New DataTable
        Dim koneksi As New MySqlConnection("Server='" & ip & "';port=3306;user id='" & user & "';password='" & pwd & "';database='ddsender'")
        Dim da As New MySqlDataAdapter(SQCommand, koneksi)
        koneksi.Open()
        da.Fill(objDataTable)
        koneksi.Close()
    End Sub

End Module
