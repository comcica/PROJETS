Public Class ucTraitement

    Private Sub Btn_SaisieP_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Btn_SaisieP.Click
        Dim lJS As Frm_JournauxSaisi = New Frm_JournauxSaisi
        lJS.ShowDialog()
    End Sub

    Private Sub Btn_Recu_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Btn_Recu.Click
        Dim lrecu As Frm_Recu = New Frm_Recu
        lrecu.ShowDialog()

    End Sub

    Private Sub Btn_SitTreso_Click(sender As Object, e As RoutedEventArgs) Handles Btn_SitTreso.Click
        Dim lSitTreso As Frm_SituationTreso = New Frm_SituationTreso
        lSitTreso.ShowDialog()

    End Sub

    Private Sub Btn_MajCpta_Click(sender As Object, e As RoutedEventArgs) Handles Btn_MajCpta.Click
        Dim lMajCpta As Frm_MajCpta = New Frm_MajCpta
        lMajCpta.ShowDialog()

    End Sub
End Class
