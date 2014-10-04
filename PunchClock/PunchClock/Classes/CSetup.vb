Public Class CSetup

    Public gDBServerIP As String = ""
    Public gModeUse As String = "" '( 0 = Frm_MenuP  1 = Frm_Punch )
    Public gDBModeUse As String = "" '( 1 = Initialisation  0 = Utilisation )


    Private lcrwinitfile As CRWinitfile = New CRWinitfile

    Public Sub New()
        gDBServerIP = "127.0.0.1"
        gModeUse = "0"
        gDBModeUse = "1"
        '
        lcrwinitfile.WriteINI("Database", "DBServerIP", gDBServerIP, RepTravail & "\" & "setup.ini")
        lcrwinitfile.WriteINI("Database", "DBModeUse", gDBModeUse, RepTravail & "\" & "setup.ini")
        lcrwinitfile.WriteINI("FrmStartup", "Mode", gModeUse, RepTravail & "\" & "setup.ini")

    End Sub
    Public Function loadsetup() As Boolean
        Try
            gDBServerIP = lcrwinitfile.ReadINI("Database", "DBServerIP", RepTravail & "\" & "setup.ini")
            gModeUse = lcrwinitfile.ReadINI("FrmStartup", "Mode", RepTravail & "\" & "setup.ini")
            gDBModeUse = lcrwinitfile.ReadINI("Database", "DBModeUse", RepTravail & "\" & "setup.ini")

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
            lcrwinitfile.WriteINI("Database", "DBServerIP", gDBServerIP, RepTravail & "\" & "setup.ini")
            lcrwinitfile.WriteINI("Database", "DBModeUse", gDBModeUse, RepTravail & "\" & "setup.ini")
            lcrwinitfile.WriteINI("FrmStartup", "Mode", gModeUse, RepTravail & "\" & "setup.ini")

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
