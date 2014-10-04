Public Class uHome

    Public Event Aproposde_Click()
    Public Event Structure_Click()
    Public Event Tratements_Click()
    Public Event Etats_Click()
    Public Event Interro_Click()
    Public Event enableControlsMain()
    Public Event desableControlsMain()

    Private Sub btnAproposde_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAproposde.Click
        RaiseEvent Aproposde_Click()
    End Sub

    Private Sub btnStructure_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnStructure.Click
        RaiseEvent Structure_Click()
    End Sub

    Private Sub btnTratements_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnTratements.Click
        RaiseEvent Tratements_Click()
    End Sub

    Private Sub btnEtats_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnEtats.Click
        RaiseEvent Etats_Click()
    End Sub

    Private Sub btnInterro_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnInterro.Click
        RaiseEvent Interro_Click()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnConnect.Click
        If Trim(btnConnect.Tag.ToString) = "Connect DB" Then
            Dim gWd_Login As Wd_Login = New Wd_Login
            CCompta_Connect.gStateConnectDB = False
            gWd_Login.ShowDialog()
            If CCompta_Connect.gStateConnectDB = True Then
                btnConnect.Tag = "DeConnect DB"
                Tb_closeopendb.Text = "Fermer"
                RaiseEvent enableControlsMain()
            Else
                MessageBox.Show("error connection Base de données, contactez le support technique. ")
            End If
        ElseIf Trim(btnConnect.Tag.ToString) = "DeConnect DB" Then
            Dim result = MessageBox.Show("Voulez vouez Déconnectez de la base de données ?", "Deconnection de le Base de données ", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel)
            If result = MessageBoxResult.OK Then
                MyConn.disconnect()
                btnConnect.Tag = "Connect DB"
                Tb_closeopendb.Text = "Ouvrir"
                RaiseEvent desableControlsMain()
            End If
            '
        End If

    End Sub
End Class
