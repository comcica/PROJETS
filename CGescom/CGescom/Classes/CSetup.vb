Public Class CSetup

    Public gDBServerIP As String = ""
    Public gDBConnect As String = "" '( 0 = pas connecter  1 = connecter )
    Public gDBModeUse As String = "" '( 1 = Initialisation  0 = Utilisation )


    Private lcrwinitfile As CRWinitfile = New CRWinitfile

    Public Sub New()
        gDBServerIP = "127.0.0.1"
        gDBConnect = "0"
        gDBModeUse = "1"
        '
        'lcrwinitfile.WriteINI("Database", "DBServerIP", gDBServerIP, RepTravail & "\" & SetupName)
        'lcrwinitfile.WriteINI("Database", "DBModeUse", gDBModeUse, RepTravail & "\" & SetupName)
        'lcrwinitfile.WriteINI("Database", "DBConnect", gDBConnect, RepTravail & "\" & SetupName)

    End Sub
    Public Function loadsetup() As Boolean
        Try
            gDBServerIP = lcrwinitfile.ReadINI("Database", "DBServerIP", RepTravail & "\" & SetupName)
            gDBConnect = lcrwinitfile.ReadINI("Database", "DBConnect", RepTravail & "\" & SetupName)
            gDBModeUse = lcrwinitfile.ReadINI("Database", "DBModeUse", RepTravail & "\" & SetupName)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function savesetup() As Boolean
        Try
            'ByVal lDBServerip As String, ByVal lmodeuse As String, ByVal lDBmodeuse As String
            'gDBServerIP = lDBServerip
            'gModeUse = lmodeuse
            'gDBModeUse = lDBmodeuse
            '
            lcrwinitfile.WriteINI("Database", "DBServerIP", gDBServerIP, RepTravail & "\" & SetupName)
            lcrwinitfile.WriteINI("Database", "DBModeUse", gDBModeUse, RepTravail & "\" & SetupName)
            lcrwinitfile.WriteINI("Database", "DBConnect", gDBConnect, RepTravail & "\" & SetupName)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
