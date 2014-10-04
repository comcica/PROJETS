Imports System.Windows.Threading
Imports System.IO
Imports System.Globalization
Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading
Imports System.Windows.Input
Imports System.Windows
Imports System.Windows.Media

Class Frm_Punch
    Public lversion As String = " ( Logiciel de Gestion de Temps, Version: " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString & " )" '  My.Application.Info.Version  'System.Reflection.Assembly.GetExecutingAssembly().GetName().Version


    Public Sub New()
        'Dim ssstartup As New SplashScreenStartup()
        Dim DispatcherTimer = New System.Windows.Threading.DispatcherTimer()
        If setup.loadsetup() = False Then
            System.Windows.Forms.MessageBox.Show("error in loading the setup file, contact technical support. ")
            End
        Else
            ''ssstartup.Show()
            'Thread.Sleep(1500)

            ' This call is required by the designer.
            InitializeComponent()
            ''ssstartup.Close()
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

    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Dim result = MessageBox.Show("Voulez vouez quitter l'application ?", "Fermeture de l'application", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
        If result = MessageBoxResult.OK Then
            End
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub MainWindow_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Me.Title &= lversion '" (Gestion BD TOOLS, Version: " & lversion.Major & "." & lversion.Minor & "." & " build " & lversion.Build & ")"

    End Sub

    Private Sub Tbmatricule_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles Tbmatricule.KeyDown
        Try
            If e.Key.ToString() = "Return" Then
                Dim lMatricule As String = Trim(Tbmatricule.Text)
                'Dim lDate As String = FormDate(Now)
                Dim lDate As String = FormDate(FormatDateTime(Now, DateFormat.ShortDate))
                Dim ltime As String = TimeString 'TimeOfDay
                Dim MyStringInsert As String = String.Format("SELECT * FROM t_worker WHERE Id_Worker = '{0}' AND worker_valid = '{1}'", lMatricule, 1)
                Dim lstrbonjour As String = ""
                Dim Wstate, HDorHS As String

                Wstate = ""
                HDorHS = ""
                Tbmatricule.Text = ""
                If MyConn.FinAWorker(MyStringInsert) = True Then

                    If TimeOfDay > "12:01:00" Then
                        lstrbonjour = "Bonsoir "
                    Else
                        lstrbonjour = "Bonjour  "
                    End If
                    If lworker.Worker_State = "0" Then '0 = sorti
                        Result_Tb.Foreground = Brushes.Green
                        Result_Tb.Text = lstrbonjour & lworker.Worker_Name & " ." & vbCrLf
                        Result_Tb.Text &= "Vous entrez à : " & ltime & " du " & lDate & vbCrLf
                        Result_Tb.Text &= "     BIENVENUE"
                        Wstate = "1"
                        HDorHS = "Time_Start"
                    Else '1 entré
                        Result_Tb.Foreground = Brushes.Red
                        Result_Tb.Text = lstrbonjour & lworker.Worker_Name & " ." & vbCrLf
                        Result_Tb.Text &= "Vous sortez à : " & ltime & " du " & lDate & vbCrLf
                        Result_Tb.Text &= "     AUREVOIR"
                        Wstate = "0"
                        HDorHS = "Time_Stop"
                    End If
                    'ajout dans db
                    Tbmatricule.Text = ""
                    MyStringInsert = "UPDATE t_worker SET Worker_State = '" & Wstate & "' WHERE Id_Worker = '" & lMatricule & "'"
                    If MyConn.Maj(MyStringInsert) = True Then
                        If MyConn.AddPunch(lMatricule, lDate, ltime, HDorHS) = False Then
                            Result_Tb.Text = ""
                            MessageBox.Show("L'enregistrement a échoué, contactez le support")
                        End If
                    Else
                        Result_Tb.Text = ""
                        MessageBox.Show("L'enregistrement a échoué, contactez le support")
                    End If
                Else
                    Result_Tb.Foreground = Brushes.Red
                    Result_Tb.Text = "Désolé !!! Je n'ai pas pu vous Identifier; Re-essayez ou contactez le support" & vbCrLf & " technique"
                End If
                '
            End If

        Catch ex As MySqlException
            MessageBox.Show("processing Failed : " + ex.Message)
        End Try


    End Sub
End Class
