Public Class ucAproposSte
    Public Event infoSociete()

    Private Sub Btn_Infos_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Btn_Infos.Click
        lwd_Societe = New Wd_Societe
        lwd_Societe.ShowDialog()
        RaiseEvent infoSociete()

    End Sub
End Class
