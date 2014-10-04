Imports System.Data

Public Class Frm_CodeJournaux

    Private ldt As DataTable = New DataTable
    Public lJO_Num As String = ""

    Private Sub RefreshDGCJ()
        Dim lCommandText As String = "SELECT JO_Type, JO_Num, JO_Intitule FROM f_journaux"
        ldt = MyConn.displayGrid(lCommandText)
        DGCJ.DataSource = ldt.DefaultView
        DGCJ.Columns(0).HeaderText = "Type"
        DGCJ.Columns(1).HeaderText = "Code"
        DGCJ.Columns(2).HeaderText = "Intitulé du Journal"

    End Sub

    Private Sub AjouterUnCompteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterUnCompteToolStripMenuItem.Click

        Dim lwdPCFiche As New Frm_CJFiche("Add", lJO_Num)
        lwdPCFiche.ShowDialog()
        '
        RefreshDGCJ()

    End Sub

    Private Sub DelCpteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelCpteToolStripMenuItem.Click
        Dim lCommandText As String = "SELECT * FROM f_ecriturec WHERE JO_Num = '" & lJO_Num & "'"
        If MyConn.Trouver(lCommandText) Then
            MessageBox.Show("Le Journal ne peut être supprimer car il contient des écritures")
        Else
            lCommandText = "DELETE FROM f_journaux WHERE JO_Num = '" & lJO_Num & "'"
            If Not MyConn.Maj(lCommandText) Then
                MessageBox.Show("Erreur lors de la suppression")
            End If
            '
            RefreshDGCJ()
        End If

    End Sub

    Private Sub UpdateCpteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCpteToolStripMenuItem.Click
        If Trim(lJO_Num) <> "" Then
            Dim lwdPCFiche As New Frm_CJFiche("Edit", lJO_Num)
            lwdPCFiche.ShowDialog()
            '
            RefreshDGCJ()
        End If
    End Sub
    Private Sub DGPT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCJ.CellDoubleClick
        If Trim(lJO_Num) <> "" Then
            Dim lwdPCFiche As New Frm_CJFiche("Edit", lJO_Num)
            lwdPCFiche.ShowDialog()
            '
            RefreshDGCJ()
        End If
    End Sub

    Private Sub DGPT_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCJ.RowEnter
        If DGCJ.SelectedRows.Count <> 0 Then
            If Trim(DGCJ.SelectedRows(0).Cells(1).Value) <> "" Then
                lJO_Num = DGCJ.SelectedRows(0).Cells(1).Value.ToString()
            Else
                lJO_Num = ""
            End If
        End If

    End Sub

    Private Sub Frm_CodeJournaux_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshDGCJ()
        '
        DGCJ.Columns(2).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class