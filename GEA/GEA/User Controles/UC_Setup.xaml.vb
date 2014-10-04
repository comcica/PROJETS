Public Class UC_Setup

    Public Sub Enabled()
        Btn_Valider.IsEnabled = True
    End Sub
    Public Sub ReloadSetupCell()
        ' mode de connection 
        For Each litem As ComboBoxItem In Cb_ModeConnect.Items
            If litem.Content = setup.gModeConnection Then
                If setup.gModeConnection = "Mono-utilisateur" Then '0
                    Cb_ModeConnect.SelectedIndex = 0
                ElseIf setup.gModeConnection = "Multi-utilisateurs" Then '1
                    Cb_ModeConnect.SelectedIndex = 1
                End If
            End If
        Next
        ' Init db
        If setup.gModeUse = "1" Then
            Chb_IitDB.IsChecked = True
        Else
            Chb_IitDB.IsChecked = False
        End If
    End Sub
    Public Sub disEnabled()
        Btn_Valider.IsEnabled = False
    End Sub
    Private Sub Btn_Annuler_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Btn_Annuler.Click
        If setup.loadsetup() Then
            ReloadSetupCell()
        Else
            MessageBox.Show("Setup can not be load ")
        End If
        disEnabled()
    End Sub

    Private Sub UserControl_Loaded(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If setup.loadsetup() Then
            ReloadSetupCell()
            Btn_Valider.IsEnabled = False
        Else
            MessageBox.Show("Setup can not be load ")
        End If
    End Sub


    Private Sub Btn_Valider_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Btn_Valider.Click
        setup.savesetup()
        disEnabled()
    End Sub


    Private Sub Chb_IitDB_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Chb_IitDB.Click
        If Chb_IitDB.IsChecked Then
            setup.gModeUse = "1"
        Else
            setup.gModeUse = "0"
        End If
        Enabled()

    End Sub

    Private Sub Cb_ModeConnect_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles Cb_ModeConnect.SelectionChanged
        Dim objSelectedvalue As ComboBoxItem = New ComboBoxItem
        objSelectedvalue = Cb_ModeConnect.SelectedValue
        If Not objSelectedvalue Is Nothing Then
            setup.gModeConnection = objSelectedvalue.Content.ToString()
            Enabled()
        End If
    End Sub
End Class
