Imports System.Data

Public Class UC_DisplayDocs
    'Private lcsqlserver As CSQLSERVER = New CSQLSERVER
    Private ldt As DataTable = New DataTable

    Public Sub New(ByVal lCommandText As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'lcsqlserver.connect("JESUS-HP\SQLEXPRESS", "Bd_test", "sa", "sa")
        'Dim lCommandText As String = "SELECT * FROM T_Files"
        ldt = lcsqlserver.displaydocs(lCommandText)

        grdDocs.ItemsSource = ldt.DefaultView
    End Sub

    Private Sub grdDocs_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles grdDocs.SelectionChanged

    End Sub

    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

    End Sub
End Class
