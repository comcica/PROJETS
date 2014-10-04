Imports MySql.Data.MySqlClient
Imports System.Data

Public Class CMySQL_Bd_Connection
    Public conn As MySqlConnection

    Public Function Connect_BD() As Boolean
        Dim strconnect As String
        If Not conn Is Nothing Then conn.Close()

        strconnect = "Server=" & setup.gDBServerIP & ";" & "User Id=" & PunchClock_Connect.gUser & ";" & "Password=" & PunchClock_Connect.gPassword & ";" & "Database=" & DatabaseName
        Try
            conn = New MySqlConnection(strconnect)
            conn.Open()
            Return True
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
            Return False
        End Try

    End Function
    Public Function ConnectInit() As Boolean
        Dim strconnect As String
        If Not conn Is Nothing Then conn.Close()

        strconnect = "Server=" & setup.gDBServerIP & ";" & "User Id=" & PunchClock_Connect.gUser & ";" & "Password=" & PunchClock_Connect.gPassword & ";" & "Database=" & ""
        Try
            conn = New MySqlConnection(strconnect)
            conn.Open()
            Return True
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
            Return False
        End Try

    End Function

    Public Function createDB(ByVal lDBName As String) As Boolean
        Dim lCommandText As String = "CREATE DATABASE " & lDBName
        Dim myCommand As MySqlCommand = New MySqlCommand(lCommandText, conn)
        Try
            myCommand.ExecuteNonQuery()
            myCommand.Cancel()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function createTables() As Boolean
        Dim lCommandText As String
        Dim myCommand As MySqlCommand = conn.CreateCommand()

        Try
            't_lastin
            lCommandText = ""
            lCommandText = "CREATE TABLE t_lastin (idt_lastin int(11) NOT NULL AUTO_INCREMENT, Touch_Number varchar(45) DEFAULT NULL, WorkerInTime varchar(8) DEFAULT NULL, " & _
                "PRIMARY KEY (idt_lastin), UNIQUE KEY (Touch_Number))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            't_punchclock
            lCommandText = ""
            lCommandText = "CREATE TABLE t_punchclock (idT_PUNCHCLOCK bigint(20) NOT NULL AUTO_INCREMENT, Id_Worker int(11) DEFAULT NULL, Touch_Number varchar(12) DEFAULT NULL, Date varchar(10) DEFAULT NULL, " & _
                "Time_Start varchar(8) DEFAULT ' ', Time_Stop varchar(8) DEFAULT ' ', PRIMARY KEY (idT_PUNCHCLOCK))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            't_touch
            lCommandText = ""
            lCommandText = "CREATE TABLE t_touch (idT_CLE int(11) NOT NULL AUTO_INCREMENT, Touch_Number varchar(12) NOT NULL, Touch_Valide char(1) DEFAULT NULL, Touch_Use char(1) DEFAULT NULL, " & _
                "PRIMARY KEY (idT_CLE), UNIQUE KEY (Touch_Number))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            'T_Dossiers
            lCommandText = ""
            lCommandText = "CREATE TABLE t_worker (idT_PERSONNE int(11) NOT NULL AUTO_INCREMENT, Id_Worker int(11) NOT NULL, Worker_Name varchar(32) DEFAULT NULL, Worker_Email varchar(98) DEFAULT NULL, " & _
                "Worker_State char(1) DEFAULT NULL, Worker_Led int(11) DEFAULT NULL, worker_valid char(1) DEFAULT NULL, PRIMARY KEY (idT_PERSONNE), UNIQUE KEY (Id_Worker))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()
            't_workertouch
            lCommandText = "CREATE TABLE t_workertouch (idt_workertouch int(11) NOT NULL AUTO_INCREMENT, Id_Worker int(11) DEFAULT NULL, Touch_Number varchar(12) DEFAULT NULL, " & _
                "PRIMARY KEY (idt_workertouch), UNIQUE KEY (Touch_Number))"
            myCommand.CommandText = lCommandText
            myCommand.ExecuteNonQuery()


            myCommand.Cancel()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function AddPunch(ByVal IdWorker As String, ByVal tDate As String, ByVal tTime As String, ByVal tHDorHS As String) As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = conn.CreateCommand()
        ' table
        Try
            cmd.Parameters.AddWithValue("@Idtworker", IdWorker)
            cmd.Parameters.AddWithValue("@tDate", tDate)
            cmd.Parameters.AddWithValue("@tTime", tTime)

            cmd.CommandText = "INSERT INTO t_punchclock (Id_Worker, Date, " & tHDorHS & ") VALUES (@Idtworker, @tDate, @tTime)"
            'cmd.Parameters("@Idtworker").Value = IdWorker
            'cmd.Parameters("@tDate").Value = tDate
            'cmd.Parameters("@tTime").Value = tTime

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function
    Public Function FinAWorker(ByVal ltxtSQL As String) As Boolean
        Dim lcmd As MySqlCommand
        Dim lreader As MySqlDataReader = Nothing

        Try
            lcmd = New MySqlCommand(ltxtSQL, conn)
            lreader = lcmd.ExecuteReader()

            If lreader.Read() Then

                lworker.Id_Worker = lreader.GetString(1)
                lworker.Worker_Name = lreader.GetString(2)
                lworker.Worker_Email = lreader.GetString(3)
                lworker.Worker_State = lreader.GetString(4)
                'led = 5eme
                lworker.worker_valid = lreader.GetString(6)

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        Finally
            If Not lreader Is Nothing Then lreader.Close()

        End Try
    End Function


    Public Function Maj(ByVal ltxtSQL As String) As Boolean
        Dim lcmd As MySqlCommand

        Try
            lcmd = New MySqlCommand(ltxtSQL, conn)
            lcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Sub disconnect()
        If Not conn Is Nothing Then
            conn.Dispose()
            conn.Close()
        End If
    End Sub

End Class
