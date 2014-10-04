Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Frm_PTFiche
    Public gmode As String = Nothing
    Public gCG_Num As String
    Public gCT_Num As String

    Public Sub New(ByVal lmode As String, ByVal liCG_Num As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gmode = lmode
        gCT_Num = liCG_Num

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


    Private Sub Frm_PTFiche_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If gmode = "Edit" Then
            updatecompte()
        End If
        If gmode = "Add" Then
            If Trim(TbCpeTiers.Text) <> "" And Trim(TbCTIntitule.Text) <> "" And Trim(Cb_typeCpte.Text) <> "" Then
                'Addcompte()
                If Trim(Cb_CpteCollectif.Text) = "" Then
                    MessageBox.Show("Le compte Collectif n'est pas renseigné")
                Else
                    Addcompte()
                    addcompteTG(Trim(TbCpeTiers.Text), Trim(Cb_CpteCollectif.Text))
                End If
            End If
        End If

    End Sub
    Private Sub Frm_PTFiche_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ldt As DataTable = New DataTable
        Dim lCommandText As String = ""
        Cb_CpteCollectif.Items.Clear()
        lCommandText = "SELECT CG_Num, CG_Intitule FROM f_compteg"
        ldt = MyConn.displayGrid(lCommandText)
        With Cb_CpteCollectif
            .Table = ldt
            .DisplayMember = "CG_Num"
            .ValueMember = "CG_Num"
            .ColumnsToDisplay = New String() {"Compte", "Intitulé"}
        End With
        Cb_CpteCollectif.SelectedIndex = -1
        '
        If gmode = "Edit" Then
            If Not loadfiche() Then
                MessageBox.Show("Le compte est introuvable")
            End If
        End If
        If gmode = "Add" Then
            TbCpeTiers.Enabled = True
            Cb_typeCpte.Enabled = True
        End If
    End Sub
    Private Function loadfiche() As Boolean
        Dim lcmd As MySqlCommand
        Dim lreader As MySqlDataReader = Nothing
        Dim lCommandText As String = "SELECT * FROM f_comptet WHERE CT_Num = '" & gCT_Num & "'"

        Try
            lcmd = New MySqlCommand(lCommandText, MyConn.conn)
            lreader = lcmd.ExecuteReader()

            If lreader.Read() Then
                TbCpeTiers.Text = lreader.GetString(1)
                TbCTIntitule.Text = lreader.GetString(2)
                Cb_typeCpte.SelectedIndex = Val(Trim(lreader.GetString(3)))
                Cb_CpteCollectif.Text = lreader.GetString(4)
                Tb_CTContact.Text = lreader.GetString(5)
                Tb_CTAdresse.Text = lreader.GetString(6)
                Tb_CTComplement.Text = lreader.GetString(7)
                Tb_CTCP.Text = lreader.GetString(8)
                Tb_CTVille.Text = lreader.GetString(9)
                Tb_CTPays.Text = lreader.GetString(11)
                Tb_CTIdentifiant.Text = lreader.GetString(12)
                Tb_CTTelephone.Text = lreader.GetString(14)
                Tb_CTTeleponie.Text = lreader.GetString(15)
                Tb_CTEmail.Text = lreader.GetString(16)
                Tb_CTSite.Text = lreader.GetString(17)
                '
                Me.Text &= " " & Trim(TbCpeTiers.Text) & " " & Trim(TbCTIntitule.Text)

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
            'cmd.Parameters.AddWithValue("@CT_Num", Trim(TbCpeTiers.Text))
            cmd.Parameters.AddWithValue("@CT_Intitule", Trim(TbCTIntitule.Text))
            'cmd.Parameters.AddWithValue("@CT_Type", Cb_typeCpte.SelectedIndex)
            cmd.Parameters.AddWithValue("@CG_NumPrinc", Trim(Cb_CpteCollectif.Text))
            cmd.Parameters.AddWithValue("@CT_Contact", Trim(Tb_CTContact.Text))
            cmd.Parameters.AddWithValue("@CT_Adresse", Trim(Tb_CTAdresse.Text))
            cmd.Parameters.AddWithValue("@CT_Complement", Trim(Tb_CTComplement.Text))
            cmd.Parameters.AddWithValue("@CT_CodePostal", Trim(Tb_CTCP.Text))
            cmd.Parameters.AddWithValue("@CT_Ville", Trim(Tb_CTVille.Text))
            cmd.Parameters.AddWithValue("@CT_Pays", Trim(Tb_CTPays.Text))
            cmd.Parameters.AddWithValue("@CT_Identifiant", Trim(Tb_CTIdentifiant.Text))
            cmd.Parameters.AddWithValue("@CT_Telephone", Trim(Tb_CTTelephone.Text))
            cmd.Parameters.AddWithValue("@CT_Telecopie", Trim(Tb_CTTeleponie.Text))
            cmd.Parameters.AddWithValue("@CT_EMail", Trim(Tb_CTEmail.Text))
            cmd.Parameters.AddWithValue("@CT_Site", Trim(Tb_CTSite.Text))

            cmd.CommandText = "UPDATE f_comptet SET CT_Intitule= @CT_Intitule, CG_NumPrinc=@CG_NumPrinc, CT_Contact=@CT_Contact, CT_Adresse=@CT_Adresse, " & _
            "CT_Complement=@CT_Complement, CT_CodePostal=@CT_CodePostal, CT_Ville=@CT_Ville, CT_Pays=@CT_Pays, CT_Identifiant=@CT_Identifiant, CT_Telephone=@CT_Telephone, " & _
            "CT_Telecopie=@CT_Telecopie, CT_EMail=@CT_EMail, CT_Site=@CT_Site WHERE CT_Num = '" & Trim(gCT_Num) & "'"

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
            cmd.Parameters.AddWithValue("@CT_Num", Trim(TbCpeTiers.Text))
            cmd.Parameters.AddWithValue("@CT_Intitule", Trim(TbCTIntitule.Text))
            cmd.Parameters.AddWithValue("@CT_Type", Cb_typeCpte.SelectedIndex)
            cmd.Parameters.AddWithValue("@CG_NumPrinc", Trim(Cb_CpteCollectif.Text))
            cmd.Parameters.AddWithValue("@CT_Contact", Trim(Tb_CTContact.Text))
            cmd.Parameters.AddWithValue("@CT_Adresse", Trim(Tb_CTAdresse.Text))
            cmd.Parameters.AddWithValue("@CT_Complement", Trim(Tb_CTComplement.Text))
            cmd.Parameters.AddWithValue("@CT_CodePostal", Trim(Tb_CTCP.Text))
            cmd.Parameters.AddWithValue("@CT_Ville", Trim(Tb_CTVille.Text))
            cmd.Parameters.AddWithValue("@CT_Pays", Trim(Tb_CTPays.Text))
            cmd.Parameters.AddWithValue("@CT_Identifiant", Trim(Tb_CTIdentifiant.Text))
            cmd.Parameters.AddWithValue("@CT_Telephone", Trim(Tb_CTTelephone.Text))
            cmd.Parameters.AddWithValue("@CT_Telecopie", Trim(Tb_CTTeleponie.Text))
            cmd.Parameters.AddWithValue("@CT_EMail", Trim(Tb_CTEmail.Text))
            cmd.Parameters.AddWithValue("@CT_Site", Trim(Tb_CTSite.Text))

            cmd.CommandText = "INSERT INTO f_comptet (CT_Num, CT_Intitule, CT_Type, CG_NumPrinc, CT_Contact, CT_Adresse, CT_Complement, CT_CodePostal, " & _
            "CT_Ville, CT_Pays, CT_Identifiant, CT_Telephone, CT_Telecopie, CT_EMail, CT_Site) VALUES (@CT_Num, @CT_Intitule, @CT_Type, @CG_NumPrinc, @CT_Contact, @CT_Adresse, " & _
            "@CT_Complement, @CT_CodePostal, @CT_Ville, @CT_Pays, @CT_Identifiant, @CT_Telephone, @CT_Telecopie, @CT_EMail, @CT_Site )"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function

End Class