Imports System.Data

Public Class Frm_PlanTiers

    Private ldt As DataTable = New DataTable
    Public lCT_Num As String = ""

    Private Sub RefreshDGPT()
        Dim lCommandText As String = "SELECT CT_Type, CT_Num, CT_Intitule FROM f_comptet"
        ldt = MyConn.displayGrid(lCommandText)
        DGPT.DataSource = ldt.DefaultView
        DGPT.Columns(0).HeaderText = "Type"
        DGPT.Columns(1).HeaderText = "Numéro"
        DGPT.Columns(2).HeaderText = "Intitulé du Tiers"

    End Sub

    Private Sub AjouterUnCompteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AjouterUnCompteToolStripMenuItem.Click

        Dim lwdPCFiche As New Frm_PTFiche("Add", lCT_Num)
        lwdPCFiche.ShowDialog()
        '
        RefreshDGPT()
    End Sub

    Private Sub DelCpteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DelCpteToolStripMenuItem.Click
        Dim lCommandText As String = "SELECT * FROM f_ecriturec WHERE CT_Num = '" & lCT_Num & "'"
        If MyConn.Trouver(lCommandText) Then
            MessageBox.Show("Le compte ne peut être supprimer car il contient des écritures")
        Else
            lCommandText = "DELETE FROM f_comptet WHERE CT_Num = '" & lCT_Num & "'"
            If Not MyConn.Maj(lCommandText) Then
                MessageBox.Show("Erreur lors de la suppression")
            End If
            '
            RefreshDGPT()
        End If

    End Sub

    Private Sub UpdateCpteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCpteToolStripMenuItem.Click
        If Trim(lCT_Num) <> "" Then
            Dim lwdPCFiche As New Frm_PTFiche("Edit", lCT_Num)
            lwdPCFiche.ShowDialog()
            '
            RefreshDGPT()
        End If
    End Sub

    Private Sub Frm_PlanTiers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RefreshDGPT()
        '
        DGPT.Columns(2).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub DGPT_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPT.CellDoubleClick
        If Trim(lCT_Num) <> "" Then
            Dim lwdPCFiche As New Frm_PTFiche("Edit", lCT_Num)
            lwdPCFiche.ShowDialog()
            '
            RefreshDGPT()
        End If
    End Sub

    Private Sub DGPT_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPT.RowEnter
        If DGPT.SelectedRows.Count <> 0 Then
            If Trim(DGPT.SelectedRows(0).Cells(1).Value) <> "" Then
                lCT_Num = DGPT.SelectedRows(0).Cells(1).Value.ToString()
            Else
                lCT_Num = ""
            End If
        End If

    End Sub
End Class