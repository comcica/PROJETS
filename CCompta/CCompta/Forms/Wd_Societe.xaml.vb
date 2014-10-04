Public Class Wd_Societe

    Private Sub Wd_Societe_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If CCompta_Connect.gStateSociete = True Then
            If MyConn.AddSociete(Trim(TbRaisonSoc.Text), Trim(TbProfession.Text), Trim(TbAdresse.Text), Trim(TbComplement.Text), Trim(TbCP.Text), Trim(TbVille.Text), Trim(TbPays.Text), Trim(TbCommentaire.Text), _
                                 Trim(TbIdentifiant.Text), FormDate(Trim(DP_DebutExo.Text)), "", "", "", "", FormDate(Trim(DP_finExo.Text)), "", "", "", "", Trim(TbTelephone.Text), Trim(TbTeleponie.Text), Trim(TbEmail.Text), Trim(TbSite.Text), Trim(TbExercice.Text)) Then
                Dim lCommandText As String = "SELECT * FROM p_dossier"
                If MyConn.FindSociete(lCommandText) = False Then
                    MessageBox.Show("Les infos de votre Société ne sont pas disponibles ")
                End If

            End If
        Else
            If MyConn.UpdateSociete(Trim(TbRaisonSoc.Text), Trim(TbProfession.Text), Trim(TbAdresse.Text), Trim(TbComplement.Text), Trim(TbCP.Text), Trim(TbVille.Text), Trim(TbPays.Text), Trim(TbCommentaire.Text), _
                                 Trim(TbIdentifiant.Text), FormDate(Trim(DP_DebutExo.Text)), "", "", "", "", FormDate(Trim(DP_finExo.Text)), "", "", "", "", Trim(TbTelephone.Text), Trim(TbTeleponie.Text), Trim(TbEmail.Text), Trim(TbSite.Text), Trim(TbExercice.Text)) Then
                Dim lCommandText As String = "SELECT * FROM p_dossier"
                If MyConn.FindSociete(lCommandText) = False Then
                    MessageBox.Show("Les infos de votre Société ne sont pas disponibles ")
                End If

            End If

        End If
    End Sub
    Private Sub loadSociete()
        TbRaisonSoc.Text = d_socete.D_RaisonSoc
        TbAdresse.Text = d_socete.D_Adresse
        TbCommentaire.Text = d_socete.D_Commentaire
        TbComplement.Text = d_socete.D_Complement
        TbCP.Text = d_socete.D_CodePostal
        TbEmail.Text = d_socete.D_EMailSoc
        TbExercice.Text = d_socete.D_Anneefiscale
        TbIdentifiant.Text = d_socete.D_Identifiant
        TbPays.Text = d_socete.D_Pays
        TbProfession.Text = d_socete.D_Profession
        TbSite.Text = d_socete.D_Site
        TbTelephone.Text = d_socete.D_Telephone
        TbTeleponie.Text = d_socete.D_Telecopie
        TbVille.Text = d_socete.D_Ville
        DP_DebutExo.Text = d_socete.D_DebutExo01
        DP_finExo.Text = d_socete.D_FinExo01

    End Sub
    Private Sub Window_Loaded(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim lCommandText As String = "SELECT * FROM p_dossier"
        If MyConn.FindSociete(lCommandText) Then
            Me.Title &= " " & d_socete.D_RaisonSoc
            loadSociete()
        Else
            'procedure mettre null
        End If
    End Sub

    Private Sub DP_finExo_SelectedDateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles DP_finExo.SelectedDateChanged
        TbExercice.Text = Mid(FormDate(Trim(DP_finExo.Text)), 1, 4)
    End Sub
End Class
