Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class UC_Find
    Private lIDArchive, libarchive, lIDArmoire, lIDRayon, lIDClasseur, lIDDossier As String
    Private ldt As DataTable = New DataTable

    Private Sub grdDocs_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles grdDocs.SelectionChanged
        Dim drv As System.Data.DataRowView = CType(grdDocs.SelectedItem, System.Data.DataRowView)
        If Not drv Is Nothing Then
            lIDArchive = drv.Item(0).ToString()
            libarchive = drv.Item(5).ToString()
        Else
            lIDArchive = "0"
        End If

    End Sub

    Private Sub MenuItemArchive_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim litem As MenuItem = DirectCast(sender, MenuItem)
        Select Case litem.Header
            Case "Archiver document"
            Case "Consulter Archive"

            Case "Supprimer Archive"
            Case "Enregistrer une copie sous"

        End Select

    End Sub

    Private Sub Btn_find_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Btn_find.Click
        Dim locArchive As String = ""
        Dim archtrouve As String = ""
        'locArchive and IdentArchive
        If Chb_locArchive.IsChecked And Chb_IdentArchive.IsChecked Then
            Dim lCommandText As String = String.Format("SELECT * FROM T_Archives WHERE ArmoireID = '{0}' AND RayonID = '{1}' AND ClasseurID = '{2}' AND DossierID = '{3}'AND fileName LIKE '%{0}%' AND fileDate BETWEEN '{1}' AND '{2}'" _
            , lIDArmoire, lIDRayon, lIDClasseur, lIDDossier, Trim(Tb_fileName.Text), FormDate(DP_Debut.Text), FormDate(DP_fin.Text))

            '
            ldt.Columns.Add("fileArmoire") '13
            ldt.Columns.Add("fileRayon") '14
            ldt.Columns.Add("fileClasseur") '15
            ldt.Columns.Add("filedossier") '16
            '
            If ldt.Rows.Count > 0 Then
                For Each lrow As DataRow In ldt.Rows
                    'Armoire
                    lCommandText = String.Format("SELECT Designation FROM T_Armoires WHERE ArmoireID = '{0}'", lrow(1))
                    lrow(13) = lcsqlserver.getDesgnation(lCommandText)
                    'Rayon
                    lCommandText = String.Format("SELECT Designation FROM T_Rayons WHERE RayonID = '{0}'", lrow(2))
                    lrow(14) = lcsqlserver.getDesgnation(lCommandText)
                    'Classeur
                    lCommandText = String.Format("SELECT Designation FROM T_Classeurs WHERE ClasseurID = '{0}'", lrow(3))
                    lrow(15) = lcsqlserver.getDesgnation(lCommandText)
                    'Dossier
                    lCommandText = String.Format("SELECT Designation FROM T_Dossiers WHERE DossierID = '{0}'", lrow(4))
                    lrow(16) = lcsqlserver.getDesgnation(lCommandText)
                Next
            End If
            '
            ldt = lcsqlserver.displaydocs(lCommandText)
            grdDocs.ItemsSource = ldt.DefaultView
            If grdDocs.Items.Count > 0 Then
                grdDocs.SelectedIndex = 0
                If grdDocs.Items.Count > 1 Then
                    locArchive = "Archives"
                    archtrouve = "trouvés"
                Else
                    locArchive = "Archive"
                    archtrouve = "trouvé"
                End If
            Else
                locArchive = "Archive"
                archtrouve = "trouvé"
            End If
            Dim txtResult As String = grdDocs.Items.Count
            Tbl_Result.Text = txtResult & " " & locArchive & " " & archtrouve

            'locArchive
        ElseIf Chb_locArchive.IsChecked Then
            Dim lCommandText As String = String.Format("SELECT * FROM T_Archives WHERE ArmoireID = '{0}' AND RayonID = '{1}' AND ClasseurID = '{2}' AND DossierID = '{3}'", lIDArmoire, lIDRayon, lIDClasseur, lIDDossier)
            ldt = lcsqlserver.displaydocs(lCommandText)
            '
            ldt.Columns.Add("fileArmoire") '13
            ldt.Columns.Add("fileRayon") '14
            ldt.Columns.Add("fileClasseur") '15
            ldt.Columns.Add("filedossier") '16
            '
            If ldt.Rows.Count > 0 Then
                For Each lrow As DataRow In ldt.Rows
                    'Armoire
                    lCommandText = String.Format("SELECT Designation FROM T_Armoires WHERE ArmoireID = '{0}'", lrow(1))
                    lrow(13) = lcsqlserver.getDesgnation(lCommandText)
                    'Rayon
                    lCommandText = String.Format("SELECT Designation FROM T_Rayons WHERE RayonID = '{0}'", lrow(2))
                    lrow(14) = lcsqlserver.getDesgnation(lCommandText)
                    'Classeur
                    lCommandText = String.Format("SELECT Designation FROM T_Classeurs WHERE ClasseurID = '{0}'", lrow(3))
                    lrow(15) = lcsqlserver.getDesgnation(lCommandText)
                    'Dossier
                    lCommandText = String.Format("SELECT Designation FROM T_Dossiers WHERE DossierID = '{0}'", lrow(4))
                    lrow(16) = lcsqlserver.getDesgnation(lCommandText)
                Next
            End If
            grdDocs.ItemsSource = ldt.DefaultView
            If grdDocs.Items.Count > 0 Then
                grdDocs.SelectedIndex = 0
                If grdDocs.Items.Count > 1 Then
                    locArchive = "Archives"
                    archtrouve = "trouvés"
                Else
                    locArchive = "Archive"
                    archtrouve = "trouvé"
                End If
            Else
                locArchive = "Archive"
                archtrouve = "trouvé"
            End If
            Dim txtResult As String = grdDocs.Items.Count
            Tbl_Result.Text = txtResult & " " & locArchive & " " & archtrouve
            'IdentArchive
        ElseIf Chb_IdentArchive.IsChecked Then

            'SELECT * FROM Customers WHERE Country LIKE '%land%'; fileName, fileDate,
            Dim lCommandText As String = String.Format("SELECT * FROM T_Archives WHERE fileName LIKE '%{0}%' AND fileDate BETWEEN '{1}' AND '{2}'", Trim(Tb_fileName.Text), FormDate(DP_Debut.Text), FormDate(DP_fin.Text))
            ldt = lcsqlserver.displaydocs(lCommandText)
            '
            ldt.Columns.Add("fileArmoire") '13
            ldt.Columns.Add("fileRayon") '14
            ldt.Columns.Add("fileClasseur") '15
            ldt.Columns.Add("filedossier") '16
            '
            If ldt.Rows.Count > 0 Then
                For Each lrow As DataRow In ldt.Rows
                    'Armoire
                    lCommandText = String.Format("SELECT Designation FROM T_Armoires WHERE ArmoireID = '{0}'", lrow(1))
                    lrow(13) = lcsqlserver.getDesgnation(lCommandText)
                    'Rayon
                    lCommandText = String.Format("SELECT Designation FROM T_Rayons WHERE RayonID = '{0}'", lrow(2))
                    lrow(14) = lcsqlserver.getDesgnation(lCommandText)
                    'Classeur
                    lCommandText = String.Format("SELECT Designation FROM T_Classeurs WHERE ClasseurID = '{0}'", lrow(3))
                    lrow(15) = lcsqlserver.getDesgnation(lCommandText)
                    'Dossier
                    lCommandText = String.Format("SELECT Designation FROM T_Dossiers WHERE DossierID = '{0}'", lrow(4))
                    lrow(16) = lcsqlserver.getDesgnation(lCommandText)
                Next
            End If
            '
            grdDocs.ItemsSource = ldt.DefaultView
            If grdDocs.Items.Count > 0 Then
                grdDocs.SelectedIndex = 0
                If grdDocs.Items.Count > 1 Then
                    locArchive = "Archives"
                    archtrouve = "trouvés"
                Else
                    locArchive = "Archive"
                    archtrouve = "trouvé"
                End If
            Else
                locArchive = "Archive"
                archtrouve = "trouvé"
            End If
            Dim txtResult As String = grdDocs.Items.Count
            Tbl_Result.Text = txtResult & " " & locArchive & " " & archtrouve
            Else
                MessageBox.Show("Critères Incorrectes")
            End If
    End Sub
    Private Sub locArchiveVisibility()
        If Chb_locArchive.IsChecked Then
            'label
            Lb_Armoire.Visibility = Windows.Visibility.Visible
            Lb_Rayon.Visibility = Windows.Visibility.Visible
            Lb_Classeur.Visibility = Windows.Visibility.Visible
            Lb_Dossier.Visibility = Windows.Visibility.Visible
            'combo
            Cb_Armoire.Visibility = Windows.Visibility.Visible
            Cb_Rayon.Visibility = Windows.Visibility.Visible
            Cb_Classeur.Visibility = Windows.Visibility.Visible
            Cb_Dossier.Visibility = Windows.Visibility.Visible
        Else
            'label
            Lb_Armoire.Visibility = Windows.Visibility.Hidden
            Lb_Rayon.Visibility = Windows.Visibility.Hidden
            Lb_Classeur.Visibility = Windows.Visibility.Hidden
            Lb_Dossier.Visibility = Windows.Visibility.Hidden
            'combo
            Cb_Armoire.Visibility = Windows.Visibility.Hidden
            Cb_Rayon.Visibility = Windows.Visibility.Hidden
            Cb_Classeur.Visibility = Windows.Visibility.Hidden
            Cb_Dossier.Visibility = Windows.Visibility.Hidden

            If Chb_IdentArchive.IsChecked = False Then
                Chb_IdentArchive.IsChecked = True
                IdentArchiveVisibility()
            End If
        End If

    End Sub
    Private Sub IdentArchiveVisibility()
        If Chb_IdentArchive.IsChecked Then
            'label
            Lb_fileName.Visibility = Windows.Visibility.Visible
            Lb_Au.Visibility = Windows.Visibility.Visible
            Lb_fileDate.Visibility = Windows.Visibility.Visible
            'texbox, datepicker
            Tb_fileName.Visibility = Windows.Visibility.Visible
            DP_Debut.Visibility = Windows.Visibility.Visible
            DP_fin.Visibility = Windows.Visibility.Visible
        Else
            'label
            Lb_fileName.Visibility = Windows.Visibility.Hidden
            Lb_Au.Visibility = Windows.Visibility.Hidden
            Lb_fileDate.Visibility = Windows.Visibility.Hidden
            'texbox, datepicker
            Tb_fileName.Visibility = Windows.Visibility.Hidden
            DP_Debut.Visibility = Windows.Visibility.Hidden
            DP_fin.Visibility = Windows.Visibility.Hidden

            If Chb_locArchive.IsChecked = False Then
                Chb_locArchive.IsChecked = True
                locArchiveVisibility()
            End If
        End If

    End Sub
    Private Sub Chb_locArchive_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles Chb_locArchive.Click
        locArchiveVisibility()
    End Sub

    Private Sub Chb_IdentArchive_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles Chb_IdentArchive.Click
        IdentArchiveVisibility()
    End Sub
    Private Sub loadArmoire()
        Dim reader As SqlDataReader
        reader = Nothing

        Dim cmd As New SqlCommand("SELECT * FROM T_Armoires", lcsqlserver.myConn)
        Try
            reader = cmd.ExecuteReader()
            Cb_Armoire.Items.Clear()
            Dim i As Integer = 0
            While (reader.Read())
                Cb_Armoire.Items.Add(reader.GetString(1))
            End While
        Catch ex As SqlException
            MessageBox.Show("Failed to populate Cb_Armoire list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub
    Private Sub loadRayon(ByVal lIDArmoire As String)
        Dim reader As SqlDataReader
        reader = Nothing

        Dim cmd As New SqlCommand("SELECT * FROM T_Rayons WHERE ArmoireID = '" & Trim(lIDArmoire) & "'", lcsqlserver.myConn)
        Try
            reader = cmd.ExecuteReader()
            'Cb_Rayon.Items.Clear()
            Dim i As Integer = 0
            While (reader.Read())
                Cb_Rayon.Items.Add(reader.GetString(2))
            End While
        Catch ex As SqlException
            MessageBox.Show("Failed to populate Cb_Rayon list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub
    Private Sub loadClasseur(ByVal lIDRayon As String)
        Dim reader As SqlDataReader
        reader = Nothing

        Dim cmd As New SqlCommand("SELECT * FROM T_Classeurs WHERE RayonID = '" & Trim(lIDRayon) & "'", lcsqlserver.myConn)
        Try
            reader = cmd.ExecuteReader()
            'Cb_Classeur.Items.Clear()
            Dim i As Integer = 0
            While (reader.Read())
                Cb_Classeur.Items.Add(reader.GetString(2))
            End While
        Catch ex As SqlException
            MessageBox.Show("Failed to populate Cb_Classeur list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub
    Private Sub loadDossier(ByVal lIDClasseur As String)
        Dim reader As SqlDataReader
        reader = Nothing

        Dim cmd As New SqlCommand("SELECT * FROM T_Dossiers WHERE ClasseurID = '" & Trim(lIDClasseur) & "'", lcsqlserver.myConn)
        Try
            reader = cmd.ExecuteReader()
            'Cb_Dossier.Items.Clear()
            Dim i As Integer = 0
            While (reader.Read())
                Cb_Dossier.Items.Add(reader.GetString(2))
            End While
        Catch ex As SqlException
            MessageBox.Show("Failed to populate Cb_Dossier list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub
    Private Sub loadAllCombo()
        Cb_Armoire.Items.Clear()
        'load Armoires
        loadArmoire()

    End Sub
    Private Sub oucfind_Loaded(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        loadAllCombo()
        Chb_IdentArchive.IsChecked = True
        Chb_locArchive.IsChecked = True
    End Sub

    Private Sub Cb_Armoire_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles Cb_Armoire.SelectionChanged
        Dim lCommandText As String = "SELECT * FROM T_Armoires WHERE Designation = '" & Trim(Cb_Armoire.SelectedItem.ToString) & "'"
        lIDArmoire = lcsqlserver.getID(lCommandText)
        Cb_Rayon.Items.Clear()
        Cb_Classeur.Items.Clear()
        Cb_Dossier.Items.Clear()
        loadRayon(lIDArmoire)
    End Sub

    Private Sub Cb_Rayon_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles Cb_Rayon.SelectionChanged

        Dim lCommandText As String = "SELECT * FROM T_Rayons WHERE Designation = '" & Trim(Cb_Rayon.SelectedItem.ToString) & "'"
        lIDRayon = lcsqlserver.getID(lCommandText)
        Cb_Classeur.Items.Clear()
        Cb_Dossier.Items.Clear()
        loadClasseur(lIDRayon)

    End Sub

    Private Sub Cb_Classeur_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles Cb_Classeur.SelectionChanged

        Dim lCommandText As String = "SELECT * FROM T_Classeurs WHERE Designation = '" & Trim(Cb_Classeur.SelectedItem.ToString) & "'"
        lIDClasseur = lcsqlserver.getID(lCommandText)
        Cb_Dossier.Items.Clear()
        loadDossier(lIDClasseur)

    End Sub

    Private Sub Cb_Dossier_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles Cb_Dossier.SelectionChanged

        Dim lCommandText As String = "SELECT * FROM T_Dossiers WHERE Designation = '" & Trim(Cb_Dossier.SelectedItem.ToString) & "'"
        lIDDossier = lcsqlserver.getID(lCommandText)

    End Sub

End Class
