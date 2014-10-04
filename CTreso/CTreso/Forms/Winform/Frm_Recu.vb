Imports System.Data
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Globalization.CultureInfo

Public Class Frm_Recu
    Public ldt As DataTable = New DataTable
    Public lpiece As CPiece
    '
    Dim Monnaie As Byte
    Dim Py As Byte
    Dim DCI As Byte

    '
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Frm_Recu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ldt As DataTable = New DataTable
        Dim lCommandText As String = ""
        lCommandText = "SELECT JO_Num, JO_Intitule FROM f_journaux"
        ldt = MyConn.displayGrid(lCommandText)
        With Cb_CodeJ
            .Table = ldt
            .DisplayMember = "JO_Num"
            .ValueMember = "JO_Num"
            .ColumnsToDisplay = New String() {"Code Journaux", "Intitulé"}
        End With
        Sep = CurrentCulture.NumberFormat.NumberDecimalSeparator ' Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Py = 0 : Monnaie = 3 : DCI = 1

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
        ev.Graphics.DrawString("MOTIF DU PAIEMENT ", New Font("Arial", 13, FontStyle.Bold), Brushes.CadetBlue, 200, 265, New StringFormat())
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
        MyPrintDialog.ShowNetwork = False

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
    Private Sub Btn_Print_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Print.Click

        Dim lCommandText As String = "SELECT CG_Num FROM f_journaux WHERE JO_Num = '" & Trim(Cb_CodeJ.Text) & "'"
        Dim lCG_Num As String = MyConn.getElmt(lCommandText)
        If Trim(lCG_Num) <> "" Then
            lCommandText = ""
            lCommandText = String.Format("SELECT * FROM f_ecriturec WHERE JO_Num = '{0}' AND CG_Num <> '{1}' AND EC_Piece = '{2}'", _
                                Trim(Cb_CodeJ.Text), lCG_Num, Trim(Tb_NumPiece.Text))

            ldt = MyConn.displayGrid(lCommandText)
            If ldt.Rows.Count > 0 Then
                For Each r As DataRow In ldt.Rows
                    lpiece = New CPiece(Trim(r(2)), Trim(r(3)), Trim(r(4)), Trim(r(5)), Trim(r(6)), Trim(r(7)), Trim(r(11)), Trim(r(8)), r(9), Trim(r(10)), r(12))
                Next
                imprimerecu()
            Else
                    MessageBox.Show("Il n'y a pas de données à imprimer ")
            End If
        Else
            MessageBox.Show("Il n'y a pas de numéro de compte associé au journal sélectionné")
        End If

    End Sub
End Class