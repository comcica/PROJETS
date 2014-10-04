Imports System.Threading
Imports System.Windows.Threading
Imports System.IO
Imports System.Reflection


Module Variables
    Public setup As CSetup = New CSetup
    Public GEA_Connect As Cconnect = New Cconnect
    Public lcsqlserver As CSQLSERVER = New CSQLSERVER
    'Public gStateConnectDB As Boolean = False
    Public Const gDBName As String = "D_Archives"
    'Public SOH As String = Chr(1)
    'Public EOT As String = Chr(4)
    'Public ACK As String = Chr(6)
    'Public NAK As String = Chr(15)
    'Public MNH As String = Chr(135)
    'Public MNB As String = Chr(255)


    'Public Const gAID_G3CS = "001"
    'Public Const gAID_TControler = "T"
    'Public Const gAID_Display = "a"

    'Public masterkeylvl(27) As String
    'Public dealerkeylvl(27) As String
    'Public supervisorkeylvl(27) As String

    'Public RepTravail As String = Application.StartupPath
    Public RepTravail As String = My.Application.Info.DirectoryPath  ' Assembly.GetExecutingAssembly.Location()    'Application.Startup
    'Public DatabaseName As String = "SimTable_bd_sqlite.s3db"

    ''Public PlayerOnTable As String = "PlayerTable.dat"
    'Public uc1 As Uc_Main = New Uc_Main()

    'Public x As Integer = 0
    'Public gIndexList As Integer = 0
    'Public gCountTableList As Integer = 0

    'Public lListTable As New List(Of CGestionTable)
    'Public lListGroupe As New List(Of CGroupTable)
    'Public lListAllTable As New List(Of CAllTable)
    'Public lListGrTable As New List(Of CGrsTable)
    ''
    'Public lListTableScriptStop As New List(Of CGestionTable)
    'Public lListTableScriptVente As New List(Of CGestionTable)
    'Public lListTableScriptWin As New List(Of CGestionTable)
    'Public lScriptOrigin As Integer = 0
    ''
    'Public IndiceArray As Integer
    'Public rand As New Random()
    'Public dataListTable As DataTable
    ''
    'Public Gfois As Integer = 0
    'Public gTpsEnSecMil As Integer = 60000 '60 s
    'Public gTpsEnSec As Integer = 60
    'Public gNbTable As Integer = 0
    'Public G3CS_Mode As Boolean = False
    ''hand
    'Public gHotSpots As Integer = 0
    '' Public myThreadWait As Thread = New Thread(New ThreadStart(AddressOf StartAndStop))
    'Public sw As StreamWriter
End Module
