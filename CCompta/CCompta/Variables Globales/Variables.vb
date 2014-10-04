Module Variables
    Public RepTravail As String = My.Application.Info.DirectoryPath
    Public Const SetupName As String = "setup.ini"
    Public DatabaseName As String = "D_CCompta"
    '
    Public MyConn As CMySQL_Bd_Connection = New CMySQL_Bd_Connection
    Public CCompta_Connect As Cconnect = New Cconnect
    Public setup As CSetup = New CSetup

    Public d_socete As CSociete = New CSociete()
    Public lwd_Societe As Wd_Societe

End Module
