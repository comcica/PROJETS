Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Frm_PCFiche
    Public gmode As String = Nothing
    Public gCG_Num As String
    Public gCT_Num As String

    Public Sub New(ByVal lmode As String, ByVal liCG_Num As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gmode = lmode
        gCG_Num = liCG_Num
    End Sub
    Private Sub tiersRatt()

        Dim ldt As DataTable = New DataTable
        Dim lCommandText As String = ""
        lCommandText = "SELECT * FROM f_comptetg WHERE CG_Num = '" & Trim(gCG_Num) & "'"
        ldt = MyConn.displayGrid(lCommandText)
        ldt.Columns.Add("CT_Intitule") '3
        'Cb_CpteTiers.Items.Clear()
        For Each lrow As DataRow In ldt.Rows
            'Intitulé tiers
            lCommandText = String.Format("SELECT CT_Intitule FROM f_comptet WHERE CT_Num = '{0}'", lrow(1))
            lrow(3) = MyConn.getCTIntitule(lCommandText)
        Next
        ldt.Columns.Remove("CG_Num")
        ldt.Columns.Remove("Numordre")
        DGCpteTiers.DataSource = ldt.DefaultView
        DGCpteTiers.Columns("CT_Intitule").AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill

    End Sub

    Private Function loadfiche() As Boolean
        Dim lcmd As MySqlCommand
        Dim lreader As MySqlDataReader = Nothing
        Dim lCommandText As String = "SELECT * FROM f_compteg WHERE CG_Num = '" & gCG_Num & "'"
        Try
            lcmd = New MySqlCommand(lCommandText, MyConn.conn)
            lreader = lcmd.ExecuteReader()

            If lreader.Read() Then
                TbNumCompte.Text = lreader.GetString(1)
                TbIntituleCpte.Text = lreader.GetString(2)
                Cb_typeCpte.SelectedIndex = Val(lreader.GetString(3))
                Cb_NatCptes.SelectedIndex = Val(lreader.GetString(4))

                Me.Text &= " " & Trim(TbNumCompte.Text) & " " & Trim(TbIntituleCpte.Text)
                ' cpte tiers rattaches
                If Not lreader Is Nothing Then lreader.Close()
                tiersRatt()
                '
                Dim ldt As DataTable = New DataTable
                lCommandText = ""
                lCommandText = "SELECT CT_Num, CT_Intitule FROM f_comptet"
                ldt = MyConn.displayGrid(lCommandText)
                With Cb_CpteTiers
                    .Table = ldt
                    .DisplayMember = "CT_Num"
                    .ValueMember = "CT_Num"
                    .ColumnsToDisplay = New String() {"Compte Tiers", "Intitulé"}
                End With

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            If Not lreader Is Nothing Then lreader.Close()
        End Try

    End Function
    Private Function updatecompte() As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            'cmd.Parameters.AddWithValue("@CG_Num", Trim(TbNumCompte.Text))
            'cmd.Parameters.AddWithValue("@CG_Type", Cb_typeCpte.SelectedIndex)
            cmd.Parameters.AddWithValue("@CG_Intitule", Trim(TbIntituleCpte.Text))
            cmd.Parameters.AddWithValue("@N_Nature", Cb_NatCptes.SelectedIndex)

            cmd.CommandText = "UPDATE f_compteg SET CG_Intitule= @CG_Intitule, N_Nature=@N_Nature WHERE CG_Num = '" & Trim(gCG_Num) & "'"
            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function

    Private Sub Frm_PCFiche_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If gmode = "Edit" Then
            updatecompte()
        End If

    End Sub

    Private Sub Frm_PCFiche_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'loadfiche()
        If gmode = "Edit" Then
            If Not loadfiche() Then
                Me.Close()
                MessageBox.Show("Le compte est introuvable")
            End If
        End If

    End Sub

    Private Function addcompteTG(ByVal lCGnum As String, ByVal lCTNum As String) As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            cmd.Parameters.AddWithValue("@CG_Num", lCGnum)
            cmd.Parameters.AddWithValue("@CT_Num", lCTNum)

            cmd.CommandText = "INSERT INTO f_comptetg (CT_Num, CG_Num) VALUES (@CT_Num, @CG_Num)"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function

    Private Sub Cb_CpteTiers_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Cb_CpteTiers.KeyDown
        If e.KeyCode.ToString() = "Return" Then
            Dim lCommandText As String = "SELECT * FROM f_comptetg WHERE CT_Num = '" & Trim(gCT_Num) & "'"
            If Not MyConn.Trouver(lCommandText) Then
                addcompteTG(Trim(gCG_Num), Trim(gCT_Num))
                tiersRatt()
            End If
            'MessageBox.Show("key Return")
        End If

    End Sub

    Private Sub Cb_CpteTiers_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_CpteTiers.SelectedIndexChanged
        gCT_Num = Cb_CpteTiers.Text

    End Sub
End Class