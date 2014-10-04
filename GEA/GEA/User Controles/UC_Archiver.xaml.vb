Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class UC_Archiver
    Private ldt As DataTable = New DataTable
    Public lwd_MajCategorie As Wd_MajCategorie
    Public Const gModeAjout As String = "Ajouter"
    Public Const gtitreArmoire As String = "Armoires"
    Public Const gModeModifier As String = "Modifier"
    Public Const gtitreRayon As String = "Rayons"
    Public Const gtitreClasseur As String = "Classeurs"
    Public Const gtitreDossier As String = "Dossiers"
    Public Const gtitreArchive As String = "Archives"
    Public lIDArmoire As String
    Public lIDRayon, lIDClasseur, lIDDossier, lIDArchive As String
    Public libarmoire, librayon, libclasseur, libdossier, libarchive As String
    Public llibarmoire, llibrayon, llibclasseur, llibdossier, llibarchive As String

    Private myCmd As SqlCommand = Nothing

    Public Sub New(ByVal lCommandText As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ldt = lcsqlserver.displaydocs(lCommandText)

        GrdArmoires.ItemsSource = ldt.DefaultView

    End Sub
    Private Sub UserControl_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If GrdArmoires.Items.Count > 0 Then
            GrdArmoires.SelectedIndex = 0
        End If
    End Sub

    Private Sub GrdArmoires_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles GrdArmoires.SelectionChanged

        Dim drv As System.Data.DataRowView = CType(GrdArmoires.SelectedItem, System.Data.DataRowView)
        If Not drv Is Nothing Then
            lIDArmoire = drv.Item(0).ToString()
            llibarmoire = drv.Item(1).ToString()
            libarmoire = "..\ " & drv.Item(1).ToString() & " \ "
            LbRep.Content = libarmoire
        Else
            lIDArmoire = "0"
            LbRep.Content = ""
        End If
        Dim lCmdRayonsText As String = "SELECT * FROM T_Rayons WHERE ArmoireID = '" & lIDArmoire & "'"
        'GrdRayons.Items.Clear()
        ldt = lcsqlserver.displaydocs(lCmdRayonsText)
        GrdRayons.ItemsSource = ldt.DefaultView
        If GrdRayons.Items.Count > 0 Then
            GrdRayons.SelectedIndex = 0
        End If
    End Sub

    Private Sub GrdRayons_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles GrdRayons.SelectionChanged
        Dim drv As System.Data.DataRowView = CType(GrdRayons.SelectedItem, System.Data.DataRowView)
        If Not drv Is Nothing Then
            lIDRayon = drv.Item(0).ToString()
            llibrayon = drv.Item(2).ToString()
            librayon = drv.Item(2).ToString() & " \ "
            LbRep.Content = libarmoire & librayon
        Else
            lIDRayon = "0"
            'LbRep.Content = 
        End If
        Dim lCmdRayonsText As String = "SELECT * FROM T_Classeurs WHERE RayonID = '" & lIDRayon & "'"

        ldt = lcsqlserver.displaydocs(lCmdRayonsText)
        GrdClasseurs.ItemsSource = ldt.DefaultView
        If GrdClasseurs.Items.Count > 0 Then
            GrdClasseurs.SelectedIndex = 0
        End If

    End Sub

    Private Sub GrdClasseurs_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles GrdClasseurs.SelectionChanged
        Dim drv As System.Data.DataRowView = CType(GrdClasseurs.SelectedItem, System.Data.DataRowView)
        If Not drv Is Nothing Then
            lIDClasseur = drv.Item(0).ToString()
            libclasseur = drv.Item(2).ToString() & " \ "
            llibclasseur = drv.Item(2).ToString()
            LbRep.Content = libarmoire & librayon & libclasseur
        Else
            lIDClasseur = "0"
        End If
        Dim lCmdRayonsText As String = "SELECT * FROM T_Dossiers WHERE ClasseurID = '" & lIDClasseur & "'"

        ldt = lcsqlserver.displaydocs(lCmdRayonsText)
        GrdDossiers.ItemsSource = ldt.DefaultView
        If GrdDossiers.Items.Count > 0 Then
            GrdDossiers.SelectedIndex = 0
        End If
    End Sub

    Private Sub GrdDossiers_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles GrdDossiers.SelectionChanged
        Dim drv As System.Data.DataRowView = CType(GrdDossiers.SelectedItem, System.Data.DataRowView)
        If Not drv Is Nothing Then
            lIDDossier = drv.Item(0).ToString()
            llibdossier = drv.Item(2).ToString()
            libdossier = drv.Item(2).ToString() & " \ "
            LbRep.Content = libarmoire & librayon & libclasseur & libdossier

        Else
            lIDDossier = "0"
        End If
        Dim lCmdRayonsText As String = "SELECT * FROM T_Archives WHERE DossierID = '" & lIDDossier & "'"

        ldt = lcsqlserver.displaydocs(lCmdRayonsText)
        grdDocs.ItemsSource = ldt.DefaultView
        If grdDocs.Items.Count > 0 Then
            grdDocs.SelectedIndex = 0
        End If

    End Sub
    Private Sub grdDocs_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles grdDocs.SelectionChanged
        Dim drv As System.Data.DataRowView = CType(grdDocs.SelectedItem, System.Data.DataRowView)
        If Not drv Is Nothing Then
            lIDArchive = drv.Item(0).ToString()
            libarchive = drv.Item(5).ToString()
            llibarchive = drv.Item(6).ToString()
        Else
            lIDArchive = "0"
        End If

    End Sub

    Private Sub MenuItemArmoire_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim litem As MenuItem = DirectCast(sender, MenuItem)
        Dim lCommandText As String
        Select Case litem.Header
            Case "Ajouter Armoire"
                lwd_MajCategorie = New Wd_MajCategorie(gModeAjout, gtitreArmoire, lIDArmoire, llibarmoire)
                lwd_MajCategorie.ShowDialog()

            Case "Modifier Armoire"
                lwd_MajCategorie = New Wd_MajCategorie(gModeModifier, gtitreArmoire, lIDArmoire, llibarmoire)
                lwd_MajCategorie.ShowDialog()

            Case "Supprimer Armoire"

                lCommandText = String.Format("SELECT * FROM T_Rayons WHERE ArmoireID = '{0}'", Trim(lIDArmoire))
                If lcsqlserver.Trouver(lCommandText) = True Then
                    MessageBox.Show("L'Armoire contient au moins un Rayon. Supprimer en premier les Rayons")
                Else
                    Dim result = MessageBox.Show("Voulez vouez Supprimer l'armoire : " & llibarmoire & " ?", "Suppression Armoire", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
                    If result = MessageBoxResult.OK Then
                        lCommandText = String.Format("DELETE FROM T_Armoires WHERE ArmoireID = '{0}'", Trim(lIDArmoire))
                        lcsqlserver.Maj(lCommandText)
                    End If

                End If
        End Select
        lCommandText = "SELECT * FROM T_Armoires"
        ldt = lcsqlserver.displaydocs(lCommandText)
        GrdArmoires.ItemsSource = ldt.DefaultView
        If GrdArmoires.Items.Count > 0 Then
            GrdArmoires.SelectedIndex = 0
        End If

    End Sub

    Private Sub MenuItemRayon_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim litem As MenuItem = DirectCast(sender, MenuItem)
        Dim lCommandText As String
        Dim locidArmoire As Integer = lIDArmoire
        Select Case litem.Header
            Case "Ajouter Rayon"
                lwd_MajCategorie = New Wd_MajCategorie(gModeAjout, gtitreRayon, locidArmoire, llibrayon)
                lwd_MajCategorie.ShowDialog()

            Case "Modifier Rayon"
                lwd_MajCategorie = New Wd_MajCategorie(gModeModifier, gtitreRayon, lIDRayon, llibrayon)
                lwd_MajCategorie.ShowDialog()

            Case "Supprimer Rayon"

                lCommandText = String.Format("SELECT * FROM T_Classeurs WHERE RayonID = '{0}'", Trim(lIDRayon))
                If lcsqlserver.Trouver(lCommandText) = True Then
                    MessageBox.Show("Le Rayon contient au moins un classeur. Supprimer en premier les classeurs")
                Else
                    Dim result = MessageBox.Show("Voulez vouez Supprimer le Rayon : " & llibrayon & " ?", "Suppression Rayon", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
                    If result = MessageBoxResult.OK Then
                        lCommandText = String.Format("DELETE FROM T_Rayons WHERE RayonID = '{0}'", Trim(lIDRayon))
                        lcsqlserver.Maj(lCommandText)
                    End If

                End If

        End Select
        lCommandText = "SELECT * FROM T_Rayons WHERE ArmoireID = '" & lIDArmoire & "'"
        ldt = lcsqlserver.displaydocs(lCommandText)
        GrdRayons.ItemsSource = ldt.DefaultView
        If GrdRayons.Items.Count > 0 Then
            GrdRayons.SelectedIndex = 0
        End If

    End Sub

    Private Sub MenuItemClasseur_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim litem As MenuItem = DirectCast(sender, MenuItem)
        Dim lCommandText As String
        Dim locidrayon As Integer = lIDRayon
        Select Case litem.Header
            Case "Ajouter Classeur"
                lwd_MajCategorie = New Wd_MajCategorie(gModeAjout, gtitreClasseur, locidrayon, llibclasseur)
                lwd_MajCategorie.ShowDialog()

            Case "Modifier Classeur"
                lwd_MajCategorie = New Wd_MajCategorie(gModeModifier, gtitreClasseur, lIDClasseur, llibclasseur)
                lwd_MajCategorie.ShowDialog()

            Case "Supprimer Classeur"

                lCommandText = String.Format("SELECT * FROM T_Dossiers WHERE ClasseurID = '{0}'", Trim(lIDClasseur))
                If lcsqlserver.Trouver(lCommandText) = True Then
                    MessageBox.Show("Le classeur contient au moins un dossier. Supprimer en premier les dossiers")
                Else
                    Dim result = MessageBox.Show("Voulez vouez Supprimer le classeur : " & llibclasseur & " ?", "Suppression classeur", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
                    If result = MessageBoxResult.OK Then
                        lCommandText = String.Format("DELETE FROM T_Classeurs WHERE ClasseurID = '{0}'", Trim(lIDClasseur))
                        lcsqlserver.Maj(lCommandText)
                    End If

                End If

        End Select
        lCommandText = "SELECT * FROM T_Classeurs WHERE RayonID = '" & lIDRayon & "'"
        ldt = lcsqlserver.displaydocs(lCommandText)
        GrdClasseurs.ItemsSource = ldt.DefaultView
        If GrdClasseurs.Items.Count > 0 Then
            GrdClasseurs.SelectedIndex = 0
        End If

    End Sub

    Private Sub MenuItemDossier_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim litem As MenuItem = DirectCast(sender, MenuItem)
        Dim lCommandText As String
        Dim locidClasseur As Integer = lIDClasseur
        Select Case litem.Header
            Case "Ajouter Dossier"
                lwd_MajCategorie = New Wd_MajCategorie(gModeAjout, gtitreDossier, locidClasseur, llibdossier)
                lwd_MajCategorie.ShowDialog()

            Case "Modifier Dossier"
                lwd_MajCategorie = New Wd_MajCategorie(gModeModifier, gtitreDossier, lIDDossier, llibdossier)
                lwd_MajCategorie.ShowDialog()

            Case "Supprimer Dossier"

                lCommandText = String.Format("SELECT * FROM T_Archives WHERE DossierID = '{0}'", Trim(lIDDossier))
                If lcsqlserver.Trouver(lCommandText) = True Then
                    MessageBox.Show("Le dossier contient au moins un archive. Supprimer en premier les archives")
                Else
                    Dim result = MessageBox.Show("Voulez vouez Supprimer le Dossier : " & llibdossier & " ?", "Suppression Dossier", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
                    If result = MessageBoxResult.OK Then
                        lCommandText = String.Format("DELETE FROM T_Dossiers WHERE DossierID = '{0}'", Trim(lIDDossier))
                        lcsqlserver.Maj(lCommandText)
                    End If

                End If

        End Select
        lCommandText = "SELECT * FROM T_Dossiers WHERE ClasseurID = '" & lIDClasseur & "'"
        ldt = lcsqlserver.displaydocs(lCommandText)
        GrdDossiers.ItemsSource = ldt.DefaultView
        If GrdDossiers.Items.Count > 0 Then
            GrdDossiers.SelectedIndex = 0
        End If

    End Sub
    Private Sub AddFiles(ByVal lidArmoire As Integer, ByVal lidRayon As Integer, ByVal lidClasseur As Integer, ByVal lidDossier As Integer)
        Dim dlg As New Microsoft.Win32.OpenFileDialog()
        Dim lCommandText As String
        Dim lfiledate, lfileLastAcces, lfileLastWrite As String
        If lcsqlserver.connectDB(GEA_Connect.gInstance, gDBName, GEA_Connect.gUser, GEA_Connect.gPassword) = True Then
            ' Set filter for file extension and default file extension 
            dlg.DefaultExt = ".doc"
            dlg.Multiselect = True
            dlg.Filter = "Pdf files (*.pdf)|*.pdf|Excel files (*.xlsx)|*.xlsx|Excel 97 - 2003 (*.xls)|*.xls|Word files (*.docx)|*.docx|Word 97 - 2003 (*.doc)|*.doc"
            ' Display OpenFileDialog by calling ShowDialog method 
            Dim result As Nullable(Of Boolean) = dlg.ShowDialog()
            ' Get the selected file name and display in a TextBox 
            If result = True Then
                'Dim str As String() = dlg.FileNames ' Multi-selection avec for
                Dim filebyte As Byte() = Nothing
                Dim imagebyte As Byte() = Nothing
                Dim filename As String = dlg.FileName
                Dim fi As FileInfo = New FileInfo(filename)

                lfiledate = fi.CreationTime
                lfileLastAcces = fi.LastAccessTime
                lfileLastWrite = fi.LastWriteTime

                Dim setc As String = fi.CreationTime
                lCommandText = "SELECT * FROM T_Archives WHERE fileName = '" & fi.Name & "'"
                If lcsqlserver.Trouver(lCommandText) = True Then
                    MessageBox.Show("Ce document est dejà archivé ")
                Else

                    filebyte = System.IO.File.ReadAllBytes(dlg.FileName)
                    Select Case fi.Extension
                        Case ".pdf", ".PDF"
                            imagebyte = System.IO.File.ReadAllBytes(RepTravail & "\pdf14x14.jpg")
                        Case ".doc", ".DOC", "docx", "DOCX"
                            imagebyte = System.IO.File.ReadAllBytes(RepTravail & "\word16x20.jpg")
                        Case ".xls", ".XLS", ".xlsx", "XLSX"
                            imagebyte = System.IO.File.ReadAllBytes(RepTravail & "\excel20x20.jpg")
                        Case Else
                            imagebyte = System.IO.File.ReadAllBytes(RepTravail & "\Unknow48x48.jpg")
                    End Select

                    lCommandText = "Insert into T_Archives ( ArmoireID, RayonID, ClasseurID, DossierID, fileType, fileName, fileDate, fileLastAcces, fileLastWrite, fileLength, fileData, fileImage)" & _
                                                 " Values(@ArmoireID, @RayonID, @ClasseurID, @Dossier, @filetype, @fileName, @filedate, @fileLastAcces, @fileLastWrite, @filelength, @fileData, @imageData)"


                    myCmd = New SqlCommand(lCommandText, lcsqlserver.myConn)

                    myCmd.Parameters.Add("@ArmoireID", SqlDbType.Int).Value = lidArmoire
                    myCmd.Parameters.Add("@RayonID", SqlDbType.Int).Value = lidRayon
                    myCmd.Parameters.Add("@ClasseurID", SqlDbType.Int).Value = lidClasseur
                    myCmd.Parameters.Add("@Dossier", SqlDbType.Int).Value = lidDossier
                    '
                    myCmd.Parameters.Add("@filetype", SqlDbType.NVarChar).Value = fi.Extension
                    myCmd.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = fi.Name
                    myCmd.Parameters.Add("@filedate", SqlDbType.NVarChar).Value = FormDate(lfiledate)
                    myCmd.Parameters.Add("@fileLastAcces", SqlDbType.NVarChar).Value = FormDate(lfileLastAcces)
                    myCmd.Parameters.Add("@fileLastWrite", SqlDbType.NVarChar).Value = FormDate(lfileLastWrite)
                    myCmd.Parameters.Add("@filelength", SqlDbType.Float).Value = (fi.Length \ 1024)
                    myCmd.Parameters.Add("@fileData", SqlDbType.Binary).Value = filebyte
                    myCmd.Parameters.Add("@imageData", SqlDbType.Image).Value = imagebyte

                    myCmd.ExecuteNonQuery()

                    myCmd.Cancel()
                    Interaction.MsgBox("File saved into database", MsgBoxStyle.Information)
                End If
            End If
        End If

    End Sub
    Private Sub MenuItemArchive_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim litem As MenuItem = DirectCast(sender, MenuItem)
        Dim lCommandText As String
        ' Dim locidDossier As Integer = lIDDossier
        Select Case litem.Header
            Case "Archiver document"
                If Trim(lIDDossier) = "" Or Trim(lIDDossier) = "0" Then
                    MessageBox.Show("Selectionner en premier le dossier devant contenir l'archive")
                Else
                    If Trim(lIDClasseur) = "" Or Trim(lIDClasseur) = "0" Or Trim(lIDRayon) = "" Or Trim(lIDRayon) = "0" Or Trim(lIDArmoire) = "" Or Trim(lIDArmoire) = "0" Then
                        MessageBox.Show("Selectionner l'armoire, le rayon, le classeur et le dossier devant contenir l'archive")
                    Else
                        Dim locidArmoire, locidRayon, locidClasseur, locidDossier As Integer
                        locidArmoire = lIDArmoire
                        locidRayon = lIDRayon
                        locidClasseur = lIDClasseur
                        locidDossier = lIDDossier

                        AddFiles(locidArmoire, locidRayon, locidClasseur, locidDossier)
                    End If
                End If
            Case "Consulter Archive"

            Case "Supprimer Archive"
                Dim result = MessageBox.Show("Voulez vouez Supprimer l'archive : " & llibarchive & " ?", "Suppression archive", MessageBoxButton.OKCancel, MessageBoxImage.Stop, MessageBoxResult.Cancel)
                If result = MessageBoxResult.OK Then
                    lCommandText = String.Format("DELETE FROM T_Archives WHERE ArchiveID = '{0}'", Trim(lIDArchive))
                    lcsqlserver.Maj(lCommandText)
                End If
            Case "Enregistrer une copie sous"

        End Select
        lCommandText = "SELECT * FROM T_Archives WHERE DossierID = '" & lIDDossier & "'"
        ldt = lcsqlserver.displaydocs(lCommandText)
        grdDocs.ItemsSource = ldt.DefaultView
        If grdDocs.Items.Count > 0 Then
            grdDocs.SelectedIndex = 0
        End If

    End Sub

End Class
