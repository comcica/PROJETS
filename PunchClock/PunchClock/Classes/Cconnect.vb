Public Class Cconnect
    Public gUser As String = ""
    Public gPassword As String = ""
    Public gStateConnectDB As Boolean = False

    Public Sub InitConnect(ByVal lUser As String, ByVal lpassword As String)
        gUser = lUser
        gPassword = lpassword
    End Sub
End Class
