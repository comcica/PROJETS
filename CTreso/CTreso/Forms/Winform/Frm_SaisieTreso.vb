Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Globalization.CultureInfo

Public Class Frm_SaisieTreso
    Public Totdebit, Totcredit As Double
    Public lArraypiece(1) As Double
    Public gJO_Num As String
    Public gCG_Num As String
    Public gtypetreso As Integer

    Dim Monnaie As Byte
    Dim Py As Byte
    Dim DCI As Byte


    Public lpiece As CPiece
    'Public Pieceequilibre As Boolean = True
    'Public gNumpiece As String = ""
    Dim ldt_print As DataTable = New DataTable
    Public Tp_NumPiece, TpDate, Tp_Ref, Tp_NumFac, Tp_CpteTiers, Tp_CpteGeneral, Tp_Sens, Tp_Montant, Tp_libelle, Tp_Benef As String


    Public Sub New(ByVal libjour As String, ByVal liJO_Num As String, ByVal lCG_Num As String, ByVal ltypetreso As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        gJO_Num = liJO_Num
        gCG_Num = lCG_Num
        gtypetreso = ltypetreso
        Lb_Journal.Text = libjour

    End Sub
    Private Sub refreshData()
        Dim ldt As DataTable = New DataTable
        Dim lCommandText As String = ""
        lCommandText = "SELECT EC_No, JO_Num, EC_Piece, EC_Intitule, EC_Date, EC_RefPiece, EC_NumFac, CT_Num, CG_Num, EC_Sens, EC_Montant, EC_Beneficiaire FROM f_ecriturec WHERE JO_Num = '" & gJO_Num & "' AND CG_Num = '" & gCG_Num & "'"
        ldt = MyConn.displayGrid(lCommandText)
        Calcul(ldt)
        '
        lCommandText = ""
        lCommandText = "SELECT EC_No, JO_Num, EC_Piece, EC_Intitule, EC_Date, EC_RefPiece, EC_NumFac, CT_Num, CG_Num, EC_Sens, EC_Montant, EC_Beneficiaire FROM f_ecriturec WHERE JO_Num = '" & gJO_Num & "'"
        ldt = MyConn.displayGrid(lCommandText)
        ldt.Columns.Add("Debit") ' 12
        ldt.Columns.Add("Credit") ' 13
        traiter(ldt)
        ldt.Columns.Remove("EC_Sens")
        ldt.Columns.Remove("EC_Montant")
        DGSaisieTreso.DataSource = ldt.DefaultView
        DGSaisieTreso.Columns(0).Visible = False
        DGSaisieTreso.Columns(1).HeaderText = "Code Journal"
        DGSaisieTreso.Columns(2).HeaderText = "N° Piêce"
        DGSaisieTreso.Columns(3).HeaderText = "Libellé écriture"
        DGSaisieTreso.Columns(4).HeaderText = "Date"
        DGSaisieTreso.Columns(5).HeaderText = "Référence"
        DGSaisieTreso.Columns(6).HeaderText = "N° Facture"
        DGSaisieTreso.Columns(7).HeaderText = "Compte Tiers"
        DGSaisieTreso.Columns(8).HeaderText = "Compte Général"
        DGSaisieTreso.Columns(9).HeaderText = "Bénéficiaire"
        DGSaisieTreso.Columns(10).HeaderText = "Débit" ' sens
        DGSaisieTreso.Columns(11).HeaderText = "Crédit" ' montant
        '
        Dim direction As ListSortDirection
        direction = ListSortDirection.Ascending

        DGSaisieTreso.Sort(DGSaisieTreso.Columns(2), direction)
    End Sub
    Private Sub InitCombo()

        Dim ldtt As DataTable = New DataTable
        Dim lCommandText As String = ""
        Cb_CpteGeneral.Items.Clear()
        lCommandText = "SELECT CG_Num, CG_Intitule FROM f_compteg"
        ldtt = MyConn.displayGrid(lCommandText)
        With Cb_CpteGeneral
            .Table = ldtt
            .DisplayMember = "CG_Num"
            .ValueMember = "CG_Num"
            .ColumnsToDisplay = New String() {"Compte", "Intitulé"}
        End With
        Cb_CpteGeneral.SelectedIndex = -1

        '
        lCommandText = ""
        lCommandText = "SELECT CT_Num, CT_Intitule FROM f_comptet"
        ldtt = MyConn.displayGrid(lCommandText)
        With Cb_CpteTiers
            .Table = ldtt
            .DisplayMember = "CT_Num"
            .ValueMember = "CT_Num"
            .ColumnsToDisplay = New String() {"Compte Tiers", "Intitulé"}
        End With

    End Sub

    Private Sub Frm_SaisieTreso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim lCommandText As String = ""
        Dim ldtable As DataTable = New DataTable
        lCommandText = "SELECT PNE_Num FROM f_Piecene"
        ldtable = MyConn.displayGrid(lCommandText)

        If ldtable.Rows.Count > 0 Then
            Dim lesNumPieces As String = ""
            For Each r As DataRow In ldtable.Rows
                lesNumPieces &= r(0) & ", "
            Next
            lesNumPieces = Trim(lesNumPieces)
            lesNumPieces = Mid(lesNumPieces, 1, lesNumPieces.Length - 1)
            MessageBox.Show("La(Les) Pièce(s) suivante(s) :  " & lesNumPieces & " sont non équilibrée(s) dans ce Journal")
            e.Cancel = True
        End If
    End Sub
    Private Sub Frm_SaisieTreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sep = CurrentCulture.NumberFormat.NumberDecimalSeparator ' Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Py = 0 : Monnaie = 3 : DCI = 1

        Me.Text &= gJO_Num & " " & Lb_Journal.Text

        InitCombo()
        RefreshChamp()
        refreshData()
        DGSaisieTreso.Columns(10).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub traiter(ByRef ldt As DataTable)
        'Dim TotDebit, TotCredit, solde As Double
        'TotDebit = 0
        'TotCredit = 0
        'solde = 0
        'Lb_TotDebit.Text = ""
        'Lb_TotCredit.Text = ""
        'Lb_SoldeCredit.Text = ""
        'Lb_SoldeDebit.Text = ""

        If ldt.Rows.Count > 0 Then
            For Each lrow As DataRow In ldt.Rows
                If Trim(lrow(9)) = "0" Then 'debit
                    'TotDebit += Val(Trim(lrow(10)))
                    lrow(12) = lrow(10)
                End If
                If Trim(lrow(9)) = "1" Then 'credit
                    'TotCredit += Val(Trim(lrow(10)))
                    lrow(13) = lrow(10)
                End If
                Dim lCommandText = String.Format("SELECT CT_Intitule FROM f_comptet WHERE CT_Num = '{0}'", lrow(7))
                lrow(7) = MyConn.getElmt(lCommandText)

            Next

            '    If TotDebit > TotCredit Then
            '        solde = TotDebit - TotCredit
            '        Lb_SoldeDebit.Text = solde.ToString("### ### ###.##")
            '    End If
            '    If TotCredit > TotDebit Then
            '        solde = TotCredit - TotDebit
            '        Lb_SoldeCredit.Text = solde.ToString("### ### ###.##")
            '    End If
            '    If TotCredit = TotDebit Then
            '        solde = 0
            '    End If
            '    Lb_TotDebit.Text = TotDebit.ToString("### ### ###.##")
            '    Lb_TotCredit.Text = TotCredit.ToString("### ### ###.##")
            '    If TotDebit = 0 Then
            '        Lb_TotDebit.Text = ""
            '    End If
            '    If TotCredit = 0 Then
            '        Lb_TotCredit.Text = ""
            '    End If
        End If

    End Sub
    Private Sub Calcul(ByRef ldt As DataTable)
        Dim TotDebit, TotCredit, solde As Double
        TotDebit = 0
        TotCredit = 0
        solde = 0
        Lb_TotDebit.Text = ""
        Lb_TotCredit.Text = ""
        Lb_SoldeCredit.Text = ""
        Lb_SoldeDebit.Text = ""

        If ldt.Rows.Count > 0 Then
            For Each lrow As DataRow In ldt.Rows
                If Trim(lrow(9)) = "0" Then 'debit
                    TotDebit += Val(Trim(lrow(10)))
                End If
                If Trim(lrow(9)) = "1" Then 'credit
                    TotCredit += Val(Trim(lrow(10)))
                End If
            Next

            If TotDebit > TotCredit Then
                solde = TotDebit - TotCredit
                Lb_SoldeDebit.Text = solde.ToString("### ### ###.##")
            End If
            If TotCredit > TotDebit Then
                solde = TotCredit - TotDebit
                Lb_SoldeCredit.Text = solde.ToString("### ### ###.##")
            End If
            If TotCredit = TotDebit Then
                solde = 0
            End If
            Lb_TotDebit.Text = TotDebit.ToString("### ### ###.##")
            Lb_TotCredit.Text = TotCredit.ToString("### ### ###.##")
            If TotDebit = 0 Then
                Lb_TotDebit.Text = ""
            End If
            If TotCredit = 0 Then
                Lb_TotCredit.Text = ""
            End If
        End If

    End Sub

    Private Sub RefreshChamp()
        Tb_NumPiece.Enabled = True
        Tb_NumPiece.Text = ""
        DTDate.Value = Now
        Tb_Libelle.Text = ""
        Tb_Ref.Text = ""
        Tb_NumFac.Text = ""
        Cb_CpteTiers.SelectedIndex = -1
        Cb_CpteGeneral.SelectedIndex = -1
        Cb_Sens.SelectedIndex = -1
        Tb_Montant.Text = ""
        Tb_EC_No.Text = ""
        'Tb_CT_Num.Text = ""
        Tb_Benef.Text = ""
    End Sub
    Private Sub memochamps()
        Tp_Benef = Tb_Benef.Text
        Tp_CpteGeneral = Cb_CpteGeneral.Text
        Tp_CpteTiers = Cb_CpteTiers.Text
        Tp_Montant = Tb_Montant.Text
        Tp_NumFac = Tb_NumFac.Text
        Tp_NumPiece = Tb_NumPiece.Text
        Tp_Ref = Tb_Ref.Text
        Tp_Sens = Cb_Sens.Text
        TpDate = DTDate.Value
        Tp_libelle = Tb_Libelle.Text
    End Sub
    Private Sub restaurememochamps()
        Tb_Benef.Text = Tp_Benef
        Cb_CpteGeneral.Text = Tp_CpteGeneral
        Cb_CpteTiers.Text = Tp_CpteTiers
        Tb_Montant.Text = Tp_Montant
        Tb_NumFac.Text = Tp_NumFac
        Tb_NumPiece.Text = Tp_NumPiece
        Tb_Ref.Text = Tp_Ref
        Cb_Sens.Text = Tp_Sens
        DTDate.Value = TpDate
        Tb_Libelle.Text = Tp_libelle

    End Sub
    Private Function addPieceNonEqui(ByVal lpieceNE As String) As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            cmd.Parameters.AddWithValue("@lpieceNE", Trim(lpieceNE))

            cmd.CommandText = "INSERT INTO f_Piecene (PNE_Num,) VALUES (@lpieceNE,)"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function
    Private Sub Btn_Valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Valider.Click
        Totcredit = 0
        Totdebit = 0
        'Pieceequilibre = True
        '
        If Trim(Tb_EC_No.Text) = "" Then
            If Trim(Tb_NumPiece.Text) <> "" Or Trim(Tb_Libelle.Text) <> "" Or FormDate(Trim(DTDate.Value)) <> "" Or Trim(Cb_Sens.Text) <> "" Or Trim(Tb_Montant.Text) <> "" Then
                If AddEcriture() Then
                    memochamps()
                    Dim lCommandText As String = String.Format("SELECT * FROM f_ecriturec WHERE EC_Piece = '{0}'", Trim(Tb_NumPiece.Text))
                    Dim locdt As DataTable = MyConn.displayGrid(lCommandText)
                    If locdt.Rows.Count > 0 Then
                        For Each lrow As DataRow In locdt.Rows
                            If Trim(lrow(9)) = "0" Then 'debit
                                Totdebit += Val(Trim(lrow(10)))
                            Else
                                Totcredit += Val(Trim(lrow(10)))
                            End If
                        Next
                        Dim lsoldepiece As Double
                        If Totdebit = Totcredit Then
                            Totdebit = 0
                            Totcredit = 0
                            lsoldepiece = 0
                            'Pieceequilibre = True
                            refreshData()
                            RefreshChamp()
                            'DGSaisieTreso.Enabled = True
                        Else
                            If Totdebit > Totcredit Then
                                lsoldepiece = Totdebit - Totcredit
                                Cb_Sens.SelectedIndex = 1
                                Tb_Montant.Text = lsoldepiece
                            End If
                            If Totcredit > Totdebit Then
                                lsoldepiece = Totcredit - Totdebit
                                Cb_Sens.SelectedIndex = 0
                                Tb_Montant.Text = lsoldepiece
                            End If

                            refreshData()
                            Cb_CpteGeneral.Focus()

                            addPieceNonEqui(Trim(Tb_NumPiece.Text))
                            'DGSaisieTreso.Enabled = False
                            RefreshChamp()
                            restaurememochamps()
                        End If
                        'refreshData()
                        DGSaisieTreso.Columns(10).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill

                    End If
                Else
                    MessageBox.Show("Saisie non enregistrée")
                End If

            Else
                MessageBox.Show("Champ de saisie vide")
            End If
        Else ' update
            If UpdateEcriture() Then
                Dim lCommandText As String = String.Format("SELECT * FROM f_ecriturec WHERE EC_Piece = '{0}'", Trim(Tb_NumPiece.Text))
                Dim locdt As DataTable = MyConn.displayGrid(lCommandText)
                If locdt.Rows.Count > 0 Then
                    For Each lrow As DataRow In locdt.Rows
                        If Trim(lrow(9)) = "0" Then 'debit
                            Totdebit += Val(Trim(lrow(10)))
                        Else
                            Totcredit += Val(Trim(lrow(10)))
                        End If
                    Next
                    Dim lsoldepiece As Double
                    If Totdebit = Totcredit Then
                        Totdebit = 0
                        Totcredit = 0
                        lsoldepiece = 0
                        'Pieceequilibre = True
                        RefreshChamp()
                    Else
                        'If Totdebit > Totcredit Then
                        '    lsoldepiece = Totdebit - Totcredit
                        '    Cb_Sens.SelectedIndex = 1
                        '    Tb_Montant.Text = lsoldepiece
                        'End If
                        'If Totcredit > Totdebit Then
                        '    lsoldepiece = Totcredit - Totdebit
                        '    Cb_Sens.SelectedIndex = 0
                        '    Tb_Montant.Text = lsoldepiece
                        'End If

                        'Cb_CpteGeneral.Focus()
                        'Pieceequilibre = False
                    End If
                    refreshData()
                    DGSaisieTreso.Columns(10).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill

                End If
                'RefreshChamp()
                'refreshData()
                'DGSaisieTreso.Columns(10).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill
            Else
                MessageBox.Show("Mise à jour non enregistrée")
            End If

        End If

    End Sub

    Private Function AddEcriture() As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            cmd.Parameters.AddWithValue("@JO_Num", Trim(gJO_Num))
            cmd.Parameters.AddWithValue("@EC_Piece", Trim(Tb_NumPiece.Text))
            cmd.Parameters.AddWithValue("@EC_Intitule", Trim(Tb_Libelle.Text))
            cmd.Parameters.AddWithValue("@EC_Date", FormDate(Trim(DTDate.Value)))
            cmd.Parameters.AddWithValue("@EC_RefPiece", Trim(Tb_Ref.Text))
            cmd.Parameters.AddWithValue("@EC_NumFac", Trim(Tb_NumFac.Text))
            cmd.Parameters.AddWithValue("@CT_Num", Trim(Cb_CpteTiers.Text))
            cmd.Parameters.AddWithValue("@CG_Num", Trim(Cb_CpteGeneral.Text))
            cmd.Parameters.AddWithValue("@EC_Sens", Cb_Sens.SelectedIndex)
            cmd.Parameters.AddWithValue("@EC_Montant", Trim(Tb_Montant.Text))
            cmd.Parameters.AddWithValue("@EC_Beneficiaire", Trim(Tb_Benef.Text))
            cmd.Parameters.AddWithValue("@EC_TypeTreso", Trim(gtypetreso))

            cmd.CommandText = "INSERT INTO f_ecriturec (JO_Num, EC_Piece, EC_Intitule, EC_Date, EC_RefPiece, EC_NumFac, CT_Num, CG_Num, " & _
            "EC_Sens, EC_Montant, EC_Beneficiaire, TypeTreso) VALUES (@JO_Num, @EC_Piece, @EC_Intitule, @EC_Date, @EC_RefPiece, @EC_NumFac, " & _
            "@CT_Num, @CG_Num, @EC_Sens, @EC_Montant, @EC_Beneficiaire, @EC_TypeTreso)"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function
    Private Function UpdateEcriture() As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd = MyConn.conn.CreateCommand()

        Try
            cmd.Parameters.AddWithValue("@EC_Intitule", Trim(Tb_Libelle.Text))
            cmd.Parameters.AddWithValue("@EC_Date", FormDate(Trim(DTDate.Value)))
            cmd.Parameters.AddWithValue("@EC_RefPiece", Trim(Tb_Ref.Text))
            cmd.Parameters.AddWithValue("@EC_NumFac", Trim(Tb_NumFac.Text))
            cmd.Parameters.AddWithValue("@CT_Num", Trim(Cb_CpteTiers.Text)) ' Trim(Cb_CpteTiers.SelectedValue.ToString))
            cmd.Parameters.AddWithValue("@CG_Num", Trim(Cb_CpteGeneral.Text))
            cmd.Parameters.AddWithValue("@EC_Sens", Cb_Sens.SelectedIndex)
            cmd.Parameters.AddWithValue("@EC_Montant", Trim(Tb_Montant.Text))
            cmd.Parameters.AddWithValue("@EC_Beneficiaire", Trim(Tb_Benef.Text))

            cmd.CommandText = "UPDATE f_ecriturec SET EC_Intitule= @EC_Intitule, EC_Date=@EC_Date, EC_RefPiece=@EC_RefPiece, EC_NumFac=@EC_NumFac, CT_Num=@CT_Num, " & _
                              "CG_Num=@CG_Num, EC_Sens=@EC_Sens, EC_Montant=@EC_Montant, EC_Beneficiaire=@EC_Beneficiaire WHERE EC_No = '" & Trim(Tb_EC_No.Text) & "'"

            cmd.ExecuteNonQuery()

            Return True
        Catch
            Return False
        End Try

    End Function


    Private Sub Cb_CpteTiers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim lCommandText = String.Format("SELECT CT_Num FROM f_comptet WHERE CT_Intitule = '{0}'", Trim(Cb_CpteTiers.Text))
        'Tb_CT_Num.Text = MyConn.getCTIntitule(lCommandText)

    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        RefreshChamp()
    End Sub
    Private Sub datagvSelChg()
        Try
            If DGSaisieTreso.Rows.Count - 1 > 0 Then
                If DGSaisieTreso.SelectedRows.Count > 0 Then
                    Tb_NumPiece.Enabled = False
                    Tb_EC_No.Text = DGSaisieTreso.SelectedRows(0).Cells(0).Value.ToString
                    Tb_NumPiece.Text = DGSaisieTreso.SelectedRows(0).Cells(2).Value.ToString
                    Tb_Libelle.Text = DGSaisieTreso.SelectedRows(0).Cells(3).Value.ToString
                    DTDate.Value = DGSaisieTreso.SelectedRows(0).Cells(4).Value.ToString
                    Tb_Ref.Text = DGSaisieTreso.SelectedRows(0).Cells(5).Value.ToString
                    Tb_NumFac.Text = DGSaisieTreso.SelectedRows(0).Cells(6).Value.ToString
                    'Dim lCommandText = String.Format("SELECT CT_Num FROM f_comptet WHERE CT_Intitule = '{0}'", Trim(DGSaisieTreso.SelectedRows(0).Cells(7).Value.ToString))
                    'Tb_CT_Num.Text = MyConn.getCTIntitule(lCommandText)
                    Cb_CpteTiers.Text = DGSaisieTreso.SelectedRows(0).Cells(7).Value.ToString
                    Cb_CpteGeneral.Text = DGSaisieTreso.SelectedRows(0).Cells(8).Value.ToString
                    Tb_Benef.Text = DGSaisieTreso.SelectedRows(0).Cells(9).Value.ToString
                    Dim lmontant As String = ""
                    lmontant = DGSaisieTreso.SelectedRows(0).Cells(10).Value.ToString ' debit
                    If Trim(lmontant) <> "" Then
                        Cb_Sens.SelectedIndex = 0
                        Tb_Montant.Text = Trim(lmontant)
                    Else
                        Cb_Sens.SelectedIndex = 1
                        Tb_Montant.Text = Trim(DGSaisieTreso.SelectedRows(0).Cells(11).Value.ToString)
                    End If

                End If
            End If
        Catch
            MessageBox.Show("erreur lors de l'assignation des champs")
        End Try

    End Sub
    Private Sub DGSaisieTreso_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGSaisieTreso.SelectionChanged
        datagvSelChg()
    End Sub

    Private Sub SpprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpprimerToolStripMenuItem.Click
        Dim lCommandText = "DELETE FROM f_ecriturec WHERE EC_No = '" & Trim(Tb_EC_No.Text) & "'"
        If Not MyConn.Maj(lCommandText) Then
            MessageBox.Show("Erreur lors de la suppression")
        Else
            refreshData()
            DGSaisieTreso.Columns(10).AutoSizeMode = Forms.DataGridViewAutoSizeColumnMode.Fill
        End If

    End Sub

    Private Sub Tb_Montant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_Montant.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) <> 46 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim x, y As Single
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing
        Dim printFont As Font = New Font("Arial", 12)

        ' Calculate the number of lines per page.
        'linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        '1er
        ev.Graphics.DrawRectangle(Pens.Black, leftMargin, topMargin, 770, 600)
        x = 57
        y = 41
        Dim monImage As Image = Nothing
        Dim pictureData As Byte() = d_socete.D_Imagebyte
        Dim lstream As MemoryStream
        If Not pictureData Is Nothing Then
            lstream = New IO.MemoryStream(pictureData)
            monImage = Image.FromStream(lstream)
            ev.Graphics.DrawImage(monImage, x, y)
        End If
        x += 1
        y += 1
        '2eme
        ev.Graphics.DrawRectangle(Pens.Black, 50, 215, 750, 420)

        ev.Graphics.DrawRectangle(Pens.Black, 50, 215, 450, 40)
        ev.Graphics.DrawRectangle(Pens.Black, 500, 215, 300, 40)
        ev.Graphics.FillRectangle(Brushes.LightGray, 501, 216, 298, 38)

        '
        Dim strtoprint As String = ""
        ' caisse
        If lpiece.typetreso = 0 Then
            If lpiece.sens = 1 Then
                strtoprint = "BON DE CAISSE "
            End If
            If lpiece.sens = 0 Then
                strtoprint = "RECU DE CAISSE "
            End If
        End If
        ' banque
        If lpiece.typetreso = 1 Then
            If lpiece.sens = 1 Then
                strtoprint = "RETRAIT "
            End If
            If lpiece.sens = 0 Then
                strtoprint = "VERSEMENT "
            End If
        End If

        ev.Graphics.DrawString(strtoprint, New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 53, 225, New StringFormat())
        ev.Graphics.DrawString(lpiece.numPiece, New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 600, 225, New StringFormat())
        '
        ev.Graphics.DrawRectangle(Pens.Black, 50, 255, 450, 40)
        ev.Graphics.DrawRectangle(Pens.Black, 500, 255, 300, 40)
        ev.Graphics.DrawString("MOTIF DE LA PIECE ", New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 200, 265, New StringFormat())
        ev.Graphics.DrawString("BENEFICIAIRE", New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 600, 265, New StringFormat())
        '3eme
        ev.Graphics.DrawRectangle(Pens.Black, 50, 295, 450, 265)
        ev.Graphics.DrawRectangle(Pens.Black, 500, 295, 300, 265)
        Dim ldesign As String = ""
        Dim i As Integer
        If lpiece.designation.Length >= 45 Then
            For i = 0 To lpiece.designation.Length - 1
                ldesign &= lpiece.designation(i)
                If i = 45 Then
                    ldesign &= vbCrLf
                End If
            Next
            lpiece.designation = ldesign
        End If
        ev.Graphics.DrawString(lpiece.designation, New Font("Arial", 12), Brushes.CadetBlue, 53, 315, New StringFormat())
        ev.Graphics.DrawString("Nom : ", New Font("Arial", 13, FontStyle.Underline), Brushes.CadetBlue, 505, 300, New StringFormat())
        ev.Graphics.DrawString(lpiece.benef, New Font("Arial", 12), Brushes.CadetBlue, 560, 300, New StringFormat())
        ev.Graphics.DrawString("Piece d'Identité N° :", New Font("Arial", 12, FontStyle.Underline), Brushes.CadetBlue, 505, 335, New StringFormat())
        ev.Graphics.DrawString("Signature :", New Font("Arial", 12, FontStyle.Underline), Brushes.CadetBlue, 505, 370, New StringFormat())

        ev.Graphics.DrawRectangle(Pens.Black, 500, 405, 300, 30)
        ev.Graphics.DrawString("N° DE COMPTE : ", New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 505, 414, New StringFormat())
        ev.Graphics.DrawString(lpiece.cpteg, New Font("Arial", 12), Brushes.CadetBlue, 660, 414, New StringFormat())
        ev.Graphics.DrawRectangle(Pens.Black, 500, 435, 300, 30)
        strtoprint = ""
        ' caisse
        If lpiece.typetreso = 0 Then
            strtoprint = "CAISSE :  "
        End If
        ' banque
        If lpiece.typetreso = 1 Then
            strtoprint = "BANQUE :  "
        End If

        ev.Graphics.DrawString(strtoprint, New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 600, 444, New StringFormat())

        ev.Graphics.DrawRectangle(Pens.Black, 50, 560, 750, 40)
        ev.Graphics.DrawString("Montant :", New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 53, 570, New StringFormat())
        Dim mydouble As Double = Val(Trim(lpiece.mt))
        ev.Graphics.DrawString(mydouble.ToString("### ### ###.##") & "  F CFA  ( " & EnTexte(mydouble, Py, Monnaie, DCI) & " )", New Font("Arial", 10, FontStyle.Bold), Brushes.Red, 150, 570, New StringFormat())

        ev.Graphics.FillRectangle(Brushes.LightGray, 51, 601, 748, 33)
        ev.Graphics.DrawString("Date :", New Font("Arial", 12, FontStyle.Underline), Brushes.CadetBlue, 53, 610, New StringFormat())
        ev.Graphics.DrawString(lpiece.ldate, New Font("Arial", 12), Brushes.CadetBlue, 110, 610, New StringFormat())


        'monImage = Image.FromStream(lstream) 'Image.FromFile("C:\Donnees 2013\COMCI_CANADA\programming project\Developpement\CTreso\CTreso\Images\logoste.png")
        'ev.Graphics.DrawImage(monImage, x, y)


        'ev.Graphics.DrawString("GAMMA International ", New Font("Arial", 16), Brushes.Black, x, y, New StringFormat())
        'ev.Graphics.DrawString("Bon de CAISSE ", printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
        'count += 2
        'yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
        'printFont = New Font("Arial", 10)
        'ev.Graphics.DrawRectangle(Pens.Black, leftMargin, yPos, 1083, 240)
        'ev.Graphics.DrawString("____________________________________ ", printFont, Brushes.Black, leftMargin, yPos, New StringFormat())

        'count += 1
        'yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
        ' Print each line of the file.
        'While count < linesPerPage
        '    If ldt_print.Rows.Count > 0 Then
        '        For Each lrow As DataRow In ldt_print.Rows

        '            count += 1
        '        Next
        '    Else
        '        Exit While
        '    End If

        'line = streamToPrint.ReadLine()
        'If line Is Nothing Then
        '    Exit While
        'End If
        'printFont = New Font("Arial", 14)
        'yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
        'printFont = New Font("Arial", 10)
        'ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
        'count += 1
        'End While

        ' If more lines exist, print another page.
        'If Not (line Is Nothing) Then
        '    ev.HasMorePages = True
        'Else
        '    ev.HasMorePages = False
        'End If

    End Sub
    Private Sub imprimerecu()
        Dim MyPrintDialog As PrintDialog = New PrintDialog()
        MyPrintDialog.AllowCurrentPage = False
        MyPrintDialog.AllowPrintToFile = False
        MyPrintDialog.AllowSelection = False
        MyPrintDialog.AllowSomePages = False
        MyPrintDialog.PrintToFile = False
        MyPrintDialog.ShowHelp = False
        MyPrintDialog.ShowNetwork = True


        If (MyPrintDialog.ShowDialog() = DialogResult.OK) Then
            Dim MyPrintDocument As New PrintDocument()
            MyPrintDocument.DocumentName = "Réçu "
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings
            MyPrintDocument.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)
            '

            AddHandler MyPrintDocument.PrintPage, AddressOf Me.pd_PrintPage
            '
            Dim MyPrintPreviewDialog As PrintPreviewDialog = New PrintPreviewDialog()
            MyPrintPreviewDialog.Document = MyPrintDocument
            MyPrintPreviewDialog.ShowDialog()

        End If

    End Sub

    Private Sub ImprimerBonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerBonToolStripMenuItem.Click
        Dim ldtable As DataTable = New DataTable
        Dim lCommandText As String = ""
        lCommandText = String.Format("SELECT * FROM f_ecriturec WHERE JO_Num = '{0}' AND CG_Num = '{1}' AND EC_Piece = '{2}'", _
                            Trim(gJO_Num), Trim(Cb_CpteGeneral.Text), Trim(Tb_NumPiece.Text))

        ldtable = MyConn.displayGrid(lCommandText)
        If ldtable.Rows.Count > 0 Then
            For Each r As DataRow In ldtable.Rows
                lpiece = New CPiece(Trim(r(2)), Trim(r(3)), Trim(r(4)), Trim(r(5)), Trim(r(6)), Trim(r(7)), Trim(r(11)), Trim(r(8)), r(9), Trim(r(10)), r(12))
            Next
            imprimerecu()
        Else
            MessageBox.Show("Il n'y a pas de données à imprimer ")
        End If
    End Sub

    Private Sub DGSaisieTreso_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSaisieTreso.CellContentClick

    End Sub

    'Private Sub Tb_Libelle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_Libelle.KeyPress
    '    If Trim(Tb_Libelle.Text).Length = 34 Then
    '        e.KeyChar = vbCrLf
    '        'Tb_Libelle.Text = Tb_Libelle.Text & vbCrLf
    '    End If
    'End Sub

    Private Sub Tb_Libelle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_Libelle.TextChanged

    End Sub
End Class