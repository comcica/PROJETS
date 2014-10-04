Public Class CSetup

    Public gModeConnection As String = "" '(  Mono ,  Multi-Utilisateur)
    Public gModeUse As String = "" '( 0 = Initialisation  1 = Utilisation 

    Private lcrwinitfile As CRWinitfile = New CRWinitfile

    Public Sub New()
        gModeConnection = "Multi-Utilisateur"
        gModeUse = "0"
    End Sub
    Public Function loadsetup() As Boolean
        Try
            gModeConnection = lcrwinitfile.ReadINI("connectBD", "Mode", RepTravail & "\" & "setup.ini")
            gModeUse = lcrwinitfile.ReadINI("APPStartup", "Mode", RepTravail & "\" & "setup.ini")

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function savesetup() As Boolean
        Try
            lcrwinitfile.WriteINI("connectBD", "Mode", gModeConnection, RepTravail & "\" & "setup.ini")
            lcrwinitfile.WriteINI("APPStartup", "Mode", gModeUse, RepTravail & "\" & "setup.ini")

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
