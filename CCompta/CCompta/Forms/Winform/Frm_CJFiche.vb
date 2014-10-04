Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Frm_CJFiche
    Public gmode As String = Nothing
    'Public gCG_Num As String
    Public gJO_Num As String

    Public Sub New(ByVal lmode As String, ByVal liCG_Num As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gmode = lmode
        gJO_Num = liCG_Num

    End Sub

    Private Sub Frm_CJFiche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If gmode = "Edit" Then
            updatecompte()
        End If
        If gmode = "Add" Then
            If Trim(TbCodej.Text) <> "" And Trim(Tb_IntituleJ.Text) <> "" And Trim(Cb_TypeJ.Text) <> "" Then
                Addcompte()
            End If
        End If

    End Sub
    Private Sub Frm_CJFiche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ldt As DataTable = New DataTable
        Dim lCommandText As String = ""
        '
        If gmode = "Edit" Then
            If Not loadfiche() Then
                MessageBox.Show("Le compte est introuvable")
            End If
        End If
        If gmode = "Add" Then
            TbCodej.Enabled = True
            Cb_TypeJ.Enabled = True
            Cb_CpteTreso.Enabled = True
        End If
    End Sub

    Private Function loadfiche() As Boolean
        Dim lcmd As MySqlCommand
        Dim lreader As MySqlDataReader = Nothing
        Dim lCommandText As String = "SELECT * FROM f_journaux WHERE JO_Num = '" & gJO_Num & "'"

        Try
            lcmd = New MySqlCommand(lCommandText, MyConn.conn)
            lreader = lcmd.ExecuteReader()

            If lreader.Read() Then
                TbCodej.Text = lreader.GetString(1)
                Tb_IntituleJ.Text = lreader.GetString(2)
                Cb_CpteTreso.Text = lreader.GetString(3)
                Cb_TypeJ.SelectedIndex = Val(Trim(lreader.GetString(4)))
                '
                Me.Text &= " " & Trim(TbCodej.Text) & " " & Trim(Tb_IntituleJ.Text)

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
            cmd.Parameters.AddWithValue("@JO_Intitule", Trim(Tb_IntituleJ.Text))

            cmd.CommandText = "UPDATE f_journaux SET JO_Intitule= @JO_Intitule WHERE JO_Num = '" & Trim(gJO_Num) & "'"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function
    Private Function Addcompte() As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            cmd.Parameters.AddWithValue("@JO_Num", Trim(TbCodej.Text))
            cmd.Parameters.AddWithValue("@JO_Intitule", Trim(Tb_IntituleJ.Text))
            cmd.Parameters.AddWithValue("@JO_Type", Cb_TypeJ.SelectedIndex)
            cmd.Parameters.AddWithValue("@CG_Num", Trim(Cb_CpteTreso.Text))

            cmd.CommandText = "INSERT INTO f_journaux (JO_Num, JO_Intitule, CG_Num, JO_Type) VALUES (@JO_Num, @JO_Intitule, @CG_Num, @JO_Type)"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function

End Class