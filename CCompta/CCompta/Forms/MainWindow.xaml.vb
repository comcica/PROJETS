Imports System.Windows.Threading
Imports System.IO
Imports System.Globalization
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading

Class MainWindow
    Public lversion As String = " ( Logiciel de Gestion Comptable , Version: " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString & " )" '  My.Application.Info.Version  'System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
    'Public lucsetup As UC_Setup = New UC_Setup
    'Private myConn As SqlConnection = Nothing
    Private myCmd As SqlCommand = Nothing

    Public Sub New()
        Dim ssstartup As New SplashScreenStartup()
        Dim DispatcherTimer = New System.Windows.Threading.DispatcherTimer()
        'If setup.loadsetup() = False Then
        '    MessageBox.Show("error in loading the setup file, contact technical support. ")
        '    End
        'Else
        ssstartup.Show()
        Thread.Sleep(1500)

        ' This call is required by the designer.
        InitializeComponent()

        ssstartup.Close()
        AddHandler DispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        DispatcherTimer.Interval = New TimeSpan(0, 0, 1)
        DispatcherTimer.Start()
        ' Add any initialization after the InitializeComponent() call.
        'End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        DisplayTimer.Text = Now.ToLongTimeString()
        DisplayDate.Text = Now.ToLongDateString()
        ' Forcing the CommandManager to raise the RequerySuggested event
        CommandManager.InvalidateRequerySuggested()
    End Sub
    Public Sub desableControls()
        tiAproposde.IsEnabled = False
        tiEtats.IsEnabled = False
        tiTraitement.IsEnabled = False
        tiStructures.IsEnabled = False
        '
        uHome.btnEtats.IsEnabled = False
        uHome.btnStructure.IsEnabled = False
        uHome.btnTratements.IsEnabled = False
        uHome.btnAproposde.IsEnabled = False
    End Sub
    Public Sub enableControls()
        tiAproposde.IsEnabled = True
        tiEtats.IsEnabled = True
        tiTraitement.IsEnabled = True
        tiStructures.IsEnabled = True
        '
        uHome.btnEtats.IsEnabled = True
        uHome.btnStructure.IsEnabled = True
        uHome.btnTratements.IsEnabled = True
        uHome.btnAproposde.IsEnabled = True
    End Sub
    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Dim result = MessageBox.Show("Voulez vouez quitter l'application ?", "Fermeture de l'application", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
        If result = MessageBoxResult.OK Then
            If Not MyConn Is Nothing Then
                MyConn.disconnect()
            End If
            End
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub MainWindow_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Me.Title &= lversion
        If Not File.Exists(RepTravail & "\" & SetupName) Then
            setup.savesetup() 'save setup  default
        Else
            If Not setup.loadsetup() Then
                MessageBox.Show("error in loading the setup file, contact technical support. ")
                End
            End If
        End If
        desableControls()
    End Sub
    'Private Sub TabItem_PreviewMouseMove(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
    '    Dim item As TabItem = TryCast(e.Source, TabItem)
    '    'Determine if mouse left button is pressed.
    '    If ((Not (item) Is Nothing) _
    '       AndAlso (Mouse.PrimaryDevice.LeftButton = MouseButtonState.Pressed)) Then
    '        'We can make the whole TabItem as data of the drag drop operation.
    '        DragDrop.DoDragDrop(item, item, DragDropEffects.All)

    '    End If
    'End Sub

    'Private Sub TabItem_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
    '    'Sort, repositionne un tab item soit pour le réordonner dans le tab control ou le sortir et le mettre dans une nouvelle fenêtre 
    '    Dim target As TabItem = TryCast(e.Source, TabItem)
    '    Dim source As TabItem = TryCast(e.Data.GetData(GetType(TabItem)), TabItem)
    '    If source IsNot Nothing AndAlso Not source.Name = "tiHome" Then
    '        'Only perform drop if target is not source.
    '        If ((Not (target) Is Nothing) _
    '           AndAlso ((Not (source) Is Nothing) _
    '           AndAlso (Not source.Equals(target)))) Then
    '            Dim tabSource As TabControl = TryCast(source.Parent, TabControl)
    '            Dim tabTarget As TabControl = TryCast(target.Parent, TabControl)
    '            Dim sourceIndex As Integer = tabSource.Items.IndexOf(source)
    '            Dim targetIndex As Integer = tabTarget.Items.IndexOf(target)
    '            'Must remove an element from the element tree before insert it into another place.
    '            tabSource.Items.Remove(source)
    '            tabTarget.Items.Insert(targetIndex, source)
    '        ElseIf (((target) Is Nothing) _
    '           AndAlso ((Not (source) Is Nothing) _
    '           AndAlso (Not source.Equals(target)))) Then

    '            Dim tab As TabControl = TryCast(source.Parent, TabControl)
    '            tab.Items.Remove(source)
    '            'Dim dlg As New dlgTabItem(source)
    '            'dlg.Show()
    '            'AddHandler dlg.OnClosingDlg, AddressOf OnClosingDlgTabItem
    '            'AddHandler dlg.OnF1ToF8KeyDown, AddressOf OnDlgKeyDownReceive
    '            'mListDlgWindowTabItem.Add(dlg)

    '        End If
    '    End If
    'End Sub
    Private Sub uHome_Aproposde_Click() Handles uHome.Aproposde_Click
        tiAproposde.IsSelected = True
    End Sub
    Private Sub uHome_Structure_Click() Handles uHome.Structure_Click
        tiStructures.IsSelected = True
    End Sub
    Private Sub uHome_Tratements_Click() Handles uHome.Tratements_Click
        tiTraitement.IsSelected = True
    End Sub
    Private Sub uHome_Etats_Click() Handles uHome.Etats_Click
        tiEtats.IsSelected = True
    End Sub
    Private Sub uHome_Interro_Click() Handles uHome.Interro_Click
        tiInterro.IsSelected = True
    End Sub
    Private Sub uHome_enableControlsMain() Handles uHome.enableControlsMain
        Me.Title &= " - Compta " & d_socete.D_RaisonSoc
        Me.TblAffCompta.Text = "COMPTA " & d_socete.D_RaisonSoc
        Me.DisplayDESc.Text = "EXERCICE : " & d_socete.D_Anneefiscale
        enableControls()
    End Sub
    Private Sub uHome_desableControlsMain() Handles uHome.desableControlsMain
        Me.Title = "COMCI COMPTABILITE" & lversion
        Me.TblAffCompta.Text = "COMCI COMPTABILITE"
        Me.DisplayDESc.Text = "Logiciel de Gestion Comptable "
        desableControls()
    End Sub
    Private Sub ucAproposSte_infoSociete() Handles ucAproposSte.infoSociete
        Me.Title &= " - Compta " & d_socete.D_RaisonSoc
        Me.TblAffCompta.Text = "COMPTA " & d_socete.D_RaisonSoc
        Me.DisplayDESc.Text = "EXERCICE : " & d_socete.D_Anneefiscale
    End Sub

    Private Sub Btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub

End Class
