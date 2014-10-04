Public Class Wd_AjoutCompte

    Private Sub Btn_Annuler_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Btn_Annuler.Click
        Me.Close()
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

    End Sub
    Private Function addcompte(ByVal lCGnum As String, ByVal lintitule As String, ByVal lCG_Type As Integer) As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            cmd.Parameters.AddWithValue("@CG_Num", lCGnum)
            cmd.Parameters.AddWithValue("@CG_Intitule", lintitule)
            cmd.Parameters.AddWithValue("@CG_Type", lCG_Type)

            cmd.CommandText = "INSERT INTO f_compteg (CG_Num, CG_Intitule, CG_Type) VALUES (@CG_Num, @CG_Intitule, @CG_Type)"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function

    Private Sub Btn_Valider_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Btn_Valider.Click
        If Not addcompte(Trim(TbNumCompte.Text), Trim(TbIntituleCpte.Text), 0) Then
            MessageBox.Show("Ajout non effectué")
        End If
        Me.Close()
    End Sub
End Class
