Imports System.Data

Public Class Frm_PC
    Private ldt As DataTable = New DataTable
    Public lCG_Num As String

    Private Sub Frm_PC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RefreshDGPC()
        '
        DGPlanComptable.Columns(2).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub DGPlanComptable_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPlanComptable.CellDoubleClick
        If Trim(lCG_Num) <> "" Then
            Dim lwdPCFiche As New Frm_PCFiche("Edit", lCG_Num)
            lwdPCFiche.ShowDialog()
            '
            RefreshDGPC()
        End If
    End Sub

    Private Sub DGPlanComptable_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPlanComptable.RowEnter
        If DGPlanComptable.SelectedRows.Count <> 0 Then
            If Trim(DGPlanComptable.SelectedRows(0).Cells(1).Value) <> "" Then
                lCG_Num = DGPlanComptable.SelectedRows(0).Cells(1).Value.ToString()
            Else
                lCG_Num = ""
            End If
        End If

    End Sub
    Private Sub RefreshDGPC()
        Dim lCommandText As String = "SELECT CG_Type, CG_Num, CG_Intitule FROM f_compteg"
        ldt = MyConn.displayGrid(lCommandText)
        DGPlanComptable.DataSource = ldt.DefaultView
        DGPlanComptable.Columns(0).HeaderText = "Type"
        DGPlanComptable.Columns(1).HeaderText = "Numéro"
        DGPlanComptable.Columns(2).HeaderText = "Intitulé du compte"

    End Sub

    Private Sub AjouterUnCompteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AjouterUnCompteToolStripMenuItem.Click
        Dim lwdPCAjoutFiche As New Wd_AjoutCompte
        lwdPCAjoutFiche.ShowDialog()
        '
        RefreshDGPC()
    End Sub

    Private Sub DelCpteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DelCpteToolStripMenuItem.Click
        Dim lCommandText As String = "SELECT * FROM f_ecriturec WHERE CG_Num = '" & lCG_Num & "'"
        If MyConn.Trouver(lCommandText) Then
            MessageBox.Show("Le compte ne peut être supprimer car il contient des écritures")
        Else
            lCommandText = "DELETE FROM f_compteg WHERE CG_Num = '" & lCG_Num & "'"
            If Not MyConn.Maj(lCommandText) Then
                MessageBox.Show("Erreur lors de la suppression")
            End If
            '
            RefreshDGPC()
        End If

    End Sub

    Private Sub UpdateCpteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateCpteToolStripMenuItem.Click
        Dim lwdPCFiche As New Frm_PCFiche("Edit", lCG_Num)
        lwdPCFiche.ShowDialog()
        '
        RefreshDGPC()
    End Sub
End Class