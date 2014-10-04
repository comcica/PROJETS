Imports System.Data

Public Class Frm_JournauxSaisi

    Private ldt As DataTable = New DataTable
    Public lJO_Num As String = ""
    Public lJO_Lib As String = ""
    Public lTypeTreso As Integer


    Private Sub RefreshDGCJ()
        Dim lCommandText As String = "SELECT JO_Num, JO_Intitule, TypeTreso FROM f_journaux"
        ldt = MyConn.displayGrid(lCommandText)
        DGCJ.DataSource = ldt.DefaultView
        DGCJ.Columns(0).HeaderText = "Code"
        DGCJ.Columns(1).HeaderText = "Intitulé du Journal"
        DGCJ.Columns(2).HeaderText = "Type Treso"
        DGCJ.Columns(2).Visible = False

    End Sub

    Private Sub DGPT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCJ.CellDoubleClick
        If Trim(lJO_Num) <> "" Then
            Dim lCommandText As String = "SELECT CG_Num FROM f_journaux WHERE JO_Num = '" & lJO_Num & "'"
            Dim lCG_Num As String = MyConn.getElmt(lCommandText)
            Dim lSaisieTreso As Frm_SaisieTreso = New Frm_SaisieTreso(lJO_Lib, lJO_Num, lCG_Num, lTypeTreso)
            lSaisieTreso.ShowDialog()
            '
            'RefreshDGCJ()
        End If
    End Sub

    Private Sub DGPT_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCJ.RowEnter
        If DGCJ.SelectedRows.Count <> 0 Then
            If Trim(DGCJ.SelectedRows(0).Cells(1).Value) <> "" Then
                lJO_Num = DGCJ.SelectedRows(0).Cells(0).Value.ToString()
                lJO_Lib = DGCJ.SelectedRows(0).Cells(1).Value.ToString()
                lTypeTreso = DGCJ.SelectedRows(0).Cells(2).Value
            Else
                lJO_Num = ""
                lJO_Lib = ""
                lTypeTreso = 0
            End If
        End If

    End Sub

    Private Sub Frm_JournauxSaisi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshDGCJ()
        '
        DGCJ.Columns(1).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub DGCJ_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCJ.CellContentClick

    End Sub
End Class