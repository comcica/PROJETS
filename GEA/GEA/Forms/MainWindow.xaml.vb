Imports System.Windows.Threading
Imports System.IO
Imports System.Globalization
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading

Class MainWindow
    Public lversion As String = " ( Logiciel de Gestio n Electronique d'Archives, Version: " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString & " )" '  My.Application.Info.Version  'System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
    Public lucsetup As UC_Setup = New UC_Setup
    'Private myConn As SqlConnection = Nothing
    Private myCmd As SqlCommand = Nothing


    Public Sub New()
        Dim ssstartup As New SplashScreenStartup()
        Dim DispatcherTimer = New System.Windows.Threading.DispatcherTimer()
        If setup.loadsetup() = False Then
            MessageBox.Show("error in loading the setup file, contact technical support. ")
            End
        Else
            ssstartup.Show()
            Thread.Sleep(1500)

            ' This call is required by the designer.
            InitializeComponent()
            ssstartup.Close()
            AddHandler DispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
            DispatcherTimer.Interval = New TimeSpan(0, 0, 1)
            DispatcherTimer.Start()
            ' Add any initialization after the InitializeComponent() call.
        End If

    End Sub
    Private Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        DisplayTimer.Text = Now.ToLongTimeString()
        DisplayDate.Text = Now.ToLongDateString()
        ' Forcing the CommandManager to raise the RequerySuggested event
        CommandManager.InvalidateRequerySuggested()
    End Sub
    Public Sub loadMain()

    End Sub

    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Dim result = MessageBox.Show("Voulez vouez quitter l'application ?", "Fermeture de l'application", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
        If result = MessageBoxResult.OK Then
            If Not lcsqlserver Is Nothing Then
                lcsqlserver.disconnect()
            End If
            End
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub MainWindow_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Me.Title &= lversion '" (Gestion BD TOOLS, Version: " & lversion.Major & "." & lversion.Minor & "." & " build " & lversion.Build & ")"
        If Not setup.loadsetup() Then
            MessageBox.Show("error in loading the setup file, contact technical support. ")
            End
        End If

        btn_Upload.IsEnabled = False
        btn_find.IsEnabled = False
        btn3.IsEnabled = False
        'btn4.IsEnabled = False

        loadMain()
        'Settings.IsSelected = True
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_exit.Click
        If Not lcsqlserver.myConn Is Nothing Then
            lcsqlserver.disconnect()
        End If


        Me.Close()
    End Sub


    Private Sub btn_setting_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_setting.Click
        MainWindow.DisplayWindow.Children.Clear()
        lucsetup.Height = DisplayWindow.Height
        lucsetup.Width = DisplayWindow.Width

        MainWindow.DisplayWindow.Children.Add(lucsetup)

    End Sub
    Private Sub showDocs(ByVal lCommandText As String)
        Dim lucdisplaydocs As UC_DisplayDocs = New UC_DisplayDocs(lCommandText)
        MainWindow.DisplayWindow.Children.Clear()
        MainWindow.DisplayWindow.Children.Add(lucdisplaydocs)

    End Sub

    Private Sub btn_Connect_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_Connect.Click
        If Trim(btn_Connect.Content.ToString) = "Connect DB" Then
            'Dim lwdwait As Wd_Wait = New Wd_Wait
            'lwdwait.Show()

            Dim gWd_Login As Wd_Login = New Wd_Login
            'Dim lCommandText As String = "SELECT * FROM T_Archives"

            GEA_Connect.gStateConnectDB = False
            'lwdwait.Close()
            gWd_Login.ShowDialog()
            If GEA_Connect.gStateConnectDB = True Then
                'showDocs(lCommandText)
                btn_Connect.Content = "DeConnect DB"
                '
                btn_Upload.IsEnabled = True
                btn_find.IsEnabled = True
                btn3.IsEnabled = True
                'btn4.IsEnabled = True
            Else
                MessageBox.Show("error connection Base de données, contactez le support technique. ")
            End If
            'btn0.IsEnabled = False
        ElseIf Trim(btn_Connect.Content.ToString) = "DeConnect DB" Then
            Dim result = MessageBox.Show("Voulez vouez Déconnectez de la base de données ?", "Deconnection de le Base de données ", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel)
            If result = MessageBoxResult.OK Then

                lcsqlserver.disconnect()
                btn_Connect.Content = "Connect DB"
                MainWindow.DisplayWindow.Children.Clear()
                '
                btn_Upload.IsEnabled = False
                btn_find.IsEnabled = False
                btn3.IsEnabled = False
                'btn4.IsEnabled = False

            End If
            '
        End If

    End Sub

    Private Sub btn_Upload_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_Upload.Click
        Dim lucArchiver As UC_Archiver = New UC_Archiver("SELECT * FROM T_Armoires")
        MainWindow.DisplayWindow.Children.Clear()
        MainWindow.DisplayWindow.Children.Add(lucArchiver)

    End Sub

    Private Sub btn_find_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_find.Click
        Dim lucFind As UC_Find = New UC_Find
        MainWindow.DisplayWindow.Children.Clear()
        MainWindow.DisplayWindow.Children.Add(lucFind)

    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub
End Class
