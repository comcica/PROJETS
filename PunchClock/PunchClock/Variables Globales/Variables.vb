Module Variables
    Public MyConn As CMySQL_Bd_Connection = New CMySQL_Bd_Connection
    Public PunchClock_Connect As Cconnect = New Cconnect
    Public setup As CSetup = New CSetup
    Public lworker As CWorker = New CWorker

    Public Structure Worker
        Dim Id_Worker As Integer
        Dim Worker_Name As String
        Dim Worker_Email As String
        Dim Worker_State As String
        Dim Worker_Led As String
        Dim Worker_Valid As String

    End Structure
    Public Tworker() As Worker
    Public RepTravail As String = Application.StartupPath '.StartupPath
    Public Const SetupName As String = "setup.ini"
    Public Worksheet_String As String = "Worksheet.txt"
    Public DatabaseName As String = "D_PunchClock"

End Module
