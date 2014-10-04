Public Class Cconnect
    Public gUser As String = ""
    Public gServer As String = ""
    Public gPassword As String = ""
    Public gStateConnectDB As Boolean = False
    Public gStateSociete As Boolean = False

    Public Sub InitConnect(ByVal lServer As String, ByVal lUser As String, ByVal lpassword As String)
        gServer = lServer
        gUser = lUser
        gPassword = lpassword
    End Sub
End Class
