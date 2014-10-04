Public Class Cconnect
    Public gInstance As String = ""
    Public gUser As String = ""
    Public gPassword As String = ""
    Public gStateConnectDB As Boolean = False

    Public Sub InitConnect(ByVal lInstance As String, ByVal lUser As String, ByVal lpassword As String)
        gInstance = lInstance
        gUser = lUser
        gPassword = lpassword
    End Sub
End Class
