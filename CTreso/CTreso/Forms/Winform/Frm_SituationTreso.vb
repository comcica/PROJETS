Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization.CultureInfo
Imports System
Imports System.IO

Public Class Frm_SituationTreso
    Public gSoldeDebut As String = ""
    Public gSoldePeriode As String = ""
    Public gSoldeFin As String = ""
    Public gNatSoldeD As String = ""
    Public gNatSoldeP As String = ""
    Public gNatSoldeF As String = ""
    Public gtypeTreso As String = ""
    Public gIntitule As String = ""
    Public gCodeJ As String = ""
    Public gDebut As String = ""
    Public gFin As String = ""
    Public lCG_Num As String = ""

    Public ldt As DataTable = New DataTable

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub
    Private Function SoldeJournal(ByRef ldt As DataTable) As String
        Dim TotDebit, TotCredit, solde As Double
        Dim NatSolde As Integer = 2
        TotDebit = 0
        TotCredit = 0
        solde = 0

        If ldt.Rows.Count > 0 Then
            For Each lrow As DataRow In ldt.Rows
                If Trim(lrow(0)) = "0" Then 'debit
                    TotDebit += Val(Trim(lrow(1)))
                End If
                If Trim(lrow(0)) = "1" Then 'credit
                    TotCredit += Val(Trim(lrow(1)))
                End If
            Next

            If TotDebit > TotCredit Then 'solde débiteur
                solde = TotDebit - TotCredit
                NatSolde = 0
                'Lb_SoldeDebit.Text = solde.ToString("### ### ###.##")
            End If
            If TotCredit > TotDebit Then 'solde créditeur
                solde = TotCredit - TotDebit
                NatSolde = 1
                'Lb_SoldeCredit.Text = solde.ToString("### ### ###.##")
            End If
            If TotCredit = TotDebit Then 'solde null
                solde = 0
                NatSolde = 2
            End If
            'Lb_TotDebit.Text = TotDebit.ToString("### ### ###.##")
            'Lb_TotCredit.Text = TotCredit.ToString("### ### ###.##")

            'return solde  0 = solde debit  1 = solde credit   2 = solde null
            If NatSolde = 0 Then
                Return "0#" & solde.ToString("### ### ###.##")
            ElseIf NatSolde = 1 Then
                Return "1#" & solde.ToString("### ### ###.##")
            Else
                Return "2#" & solde.ToString("### ### ###.##")
            End If
        Else
            Return "2#" & solde.ToString("### ### ###.##")
        End If
    End Function

    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click
        'cpte du journal
        Dim lCommandText As String = "SELECT CG_Num FROM f_journaux WHERE JO_Num = '" & Trim(Cb_CodeJ.Text) & "'"
        lCG_Num = MyConn.getElmt(lCommandText)

        'calcul solde debut periode
        lCommandText = ""
        lCommandText = String.Format("SELECT EC_Sens, EC_Montant FROM f_ecriturec WHERE JO_Num = '{0}' AND CG_Num = '{1}' AND EC_Date < '{2}'", _
            Trim(Cb_CodeJ.Text), Trim(lCG_Num), FormDate(DTDateD.Value))

        ldt = New DataTable
        ldt = MyConn.displayGrid(lCommandText)
        If ldt.Rows.Count > 0 Then
            gSoldeDebut = SoldeJournal(ldt)
            gNatSoldeD = Mid(gSoldeDebut, 1, 1)
            gSoldeDebut = Mid(gSoldeDebut, 3)
        Else
            gNatSoldeD = "2"
            gSoldeDebut = "0"
        End If
        'calcul solde  periode
        lCommandText = ""
        lCommandText = String.Format("SELECT EC_Sens, EC_Montant FROM f_ecriturec WHERE JO_Num = '{0}' AND CG_Num = '{1}' AND EC_Date BETWEEN '{2}' AND '{3}'", _
            Trim(Cb_CodeJ.Text), Trim(lCG_Num), FormDate(DTDateD.Value), FormDate(DTDateF.Value))

        ldt = New DataTable
        ldt = MyConn.displayGrid(lCommandText)
        If ldt.Rows.Count > 0 Then
            gSoldePeriode = SoldeJournal(ldt)
            gNatSoldeP = Mid(gSoldePeriode, 1, 1)
            gSoldePeriode = Mid(gSoldePeriode, 3)
        Else
            gNatSoldeP = "2"
            gSoldePeriode = "0"
        End If
        'calcul solde fin periode
        If Trim(gNatSoldeD) = Trim(gNatSoldeP) Then
            gSoldeFin = Trim(Val(Trim(gSoldeDebut)) + Val(Trim(gSoldePeriode)))
            gNatSoldeF = gNatSoldeD
        Else
            If Val(Trim(gSoldeDebut)) > Val(Trim(gSoldePeriode)) Then
                gSoldeFin = Trim(Val(Trim(gSoldeDebut)) - Val(Trim(gSoldePeriode)))
                gNatSoldeF = gNatSoldeD
            ElseIf Val(Trim(gSoldeDebut)) < Val(Trim(gSoldePeriode)) Then
                gSoldeFin = Trim(Val(Trim(gSoldePeriode)) - Val(Trim(gSoldeDebut)))
                gNatSoldeF = gNatSoldeP
            ElseIf Val(Trim(gSoldeDebut)) = Val(Trim(gSoldePeriode)) Then
                gSoldeFin = "0"
                gNatSoldeF = "0"
            End If
        End If
        'Mouvement de la periode
        lCommandText = ""
        lCommandText = String.Format("SELECT EC_Date, EC_Piece, EC_Intitule, CG_Num, EC_Sens, EC_Beneficiaire, EC_Montant FROM f_ecriturec WHERE JO_Num = '{0}' AND EC_Date BETWEEN '{1}' AND '{2}'", _
            Trim(Cb_CodeJ.Text), FormDate(DTDateD.Value), FormDate(DTDateF.Value))

        ldt = New DataTable
        ldt = MyConn.displayGrid(lCommandText)
        If ldt.Rows.Count > 0 Then
            imprimerecu()
        Else
            System.Windows.MessageBox.Show("Il n'y a pas de données à Exporter ")
        End If

    End Sub
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim x, y As Integer
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing
        Dim printFont As Font = New Font("Arial", 12)

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ''1er
        'ev.Graphics.DrawRectangle(Pens.Black, leftMargin, topMargin, 770, 600)
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
        y = 220

        count = 220
        ev.Graphics.DrawString("Situation de Trésorerie ", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 57, y, New StringFormat())
        ev.Graphics.DrawString("Date Edition :" & Now(), New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 500, y, New StringFormat())
        y += 60
        count += 60
        If Trim(gtypeTreso) = "0" Then 'Caisse
            ev.Graphics.DrawString("Caisse : ", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 57, y, New StringFormat())
        Else 'Banque
            ev.Graphics.DrawString("Banque : ", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 57, y, New StringFormat())
        End If
        '
        ev.Graphics.DrawString(gCodeJ & "-" & gIntitule, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 150, y, New StringFormat())
        ev.Graphics.DrawString("Compte Général :  " & lCG_Num, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 500, y, New StringFormat())

        y += 40
        count += 40
        ev.Graphics.DrawString("Situation du  :  " & gDebut & "  au  " & gFin, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, 57, y, New StringFormat())
        'y += 20
        'count += 20
        'ev.Graphics.DrawString("Mouvement", New Font("Arial", 12), Brushes.Black, 575, y, New StringFormat())
        'ev.Graphics.DrawString("Solde", New Font("Arial", 12), Brushes.Black, 735, y, New StringFormat())
        y += 35
        count += 35
        ev.Graphics.DrawString("Date", New Font("Arial", 12), Brushes.Black, 20, y, New StringFormat())
        ev.Graphics.DrawString("N° Piècce", New Font("Arial", 12), Brushes.Black, 100, y, New StringFormat())
        ev.Graphics.DrawString("Libellé écriture", New Font("Arial", 12), Brushes.Black, 185, y, New StringFormat())
        ev.Graphics.DrawString("Compte", New Font("Arial", 12), Brushes.Black, 425, y, New StringFormat())
        ev.Graphics.DrawString("Bénéficiaire", New Font("Arial", 12), Brushes.Black, 500, y, New StringFormat())
        'ev.Graphics.DrawString("Crédit", New Font("Arial", 12), Brushes.Black, 625, y, New StringFormat())
        ev.Graphics.DrawString("Débit", New Font("Arial", 12), Brushes.Black, 650, y, New StringFormat())
        ev.Graphics.DrawString("Crédit", New Font("Arial", 12), Brushes.Black, 750, y, New StringFormat())
        '
        y += 20
        count += 20
        printFont = New Font("Arial", 15, FontStyle.Bold)
        ev.Graphics.DrawLine(Pens.Black, 20, y, 840, y)
        ' solde debut
        y += 15
        count += 15
        ev.Graphics.DrawString("Solde antérieur au  " & gDebut, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 185, y, New StringFormat())
        If Trim(gNatSoldeD) = "0" Then 'solde debit
            ev.Graphics.DrawString(gSoldeDebut, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 650, y, New StringFormat())
        End If
        If Trim(gNatSoldeD) = "1" Then 'solde credit
            ev.Graphics.DrawString(gSoldeDebut, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 750, y, New StringFormat())
        End If

        Dim mySolde As String = Trim(gSoldeDebut)
        y += 5
        count += 5

        printFont = New Font("Arial", 10)
        For Each lrow As DataRow In ldt.Rows
            y += 15
            count += 15

            ev.Graphics.DrawString(lrow(0), printFont, Brushes.Black, 20, y, New StringFormat())
            ev.Graphics.DrawString(lrow(1), printFont, Brushes.Black, 110, y, New StringFormat())
            ev.Graphics.DrawString(lrow(2), printFont, Brushes.Black, 185, y, New StringFormat())
            ev.Graphics.DrawString(lrow(3), printFont, Brushes.Black, 425, y, New StringFormat())
            ev.Graphics.DrawString(lrow(5), printFont, Brushes.Black, 500, y, New StringFormat())
            'mvt
            If Val(Trim(lrow(4))) = 0 Then 'mvt debit
                ev.Graphics.DrawString(Val(Trim(lrow(6))).ToString("### ### ###.##"), printFont, Brushes.Black, 650, y, New StringFormat())
            End If
            If Val(Trim(lrow(4))) = 1 Then 'mvt credit
                ev.Graphics.DrawString(Val(Trim(lrow(6))).ToString("### ### ###.##"), printFont, Brushes.Black, 750, y, New StringFormat())
            End If
            'solde
            'If Trim(gNatSolde) = Val(Trim(lrow(4))) Then 'sens solde  = sens mvt 
            '    If Trim(gNatSolde) = "0" Then 'solde debit et mvt debit
            '        mySolde = Trim(Val(Trim(mySolde)) + Val(Trim(lrow(5))))
            '        ev.Graphics.DrawString(mySolde, printFont, Brushes.Black, 700, y, New StringFormat())
            '    End If
            '    If Trim(gNatSolde) = "1" Then 'solde credit et mvt credit
            '        mySolde = Trim(Val(Trim(mySolde)) + Val(Trim(lrow(5))))
            '        ev.Graphics.DrawString(mySolde, printFont, Brushes.Black, 775, y, New StringFormat())
            '    End If
            'Else
            '    If Val(Trim(mySolde)) > Val(Trim(lrow(5))) Then
            '        mySolde = Trim(Val(Trim(mySolde)) - Val(Trim(lrow(5))))
            '        If Trim(gNatSolde) = "0" Then 'solde debit
            '            ev.Graphics.DrawString(mySolde, printFont, Brushes.Black, 700, y, New StringFormat())
            '        End If
            '        If Trim(gNatSolde) = "1" Then 'solde credit
            '            ev.Graphics.DrawString(mySolde, printFont, Brushes.Black, 775, y, New StringFormat())
            '        End If
            '    ElseIf Val(Trim(mySolde)) < Val(Trim(lrow(5))) Then
            '        mySolde = Trim(Val(Trim(lrow(5))) - Trim(Val(Trim(mySolde))))
            '        If Val(Trim(lrow(4))) = 0 Then 'mvt debit
            '            gNatSolde = "0"
            '            ev.Graphics.DrawString(mySolde, printFont, Brushes.Black, 700, y, New StringFormat())
            '        End If
            '        If Val(Trim(lrow(4))) = 1 Then 'mvt credit
            '            gNatSolde = "1"
            '            ev.Graphics.DrawString(mySolde, printFont, Brushes.Black, 775, y, New StringFormat())
            '        End If
            '    ElseIf Val(Trim(mySolde)) = Val(Trim(lrow(5))) Then
            '        mySolde = "0"
            '        gNatSolde = "0"
            '    End If
            'End If
            'lrow.Delete()
        Next
        'solde final 

        y += 25
        count += 25
        ev.Graphics.DrawString("Solde au  " & gFin, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 185, y, New StringFormat())
        If Trim(gNatSoldeF) = "0" Then 'solde debit
            ev.Graphics.DrawString(Val(Trim(gSoldeFin)).ToString("### ### ###.##"), New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 650, y, New StringFormat())
        End If
        If Trim(gNatSoldeF) = "1" Then 'solde credit
            ev.Graphics.DrawString(Val(Trim(gSoldeFin)).ToString("### ### ###.##"), New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 750, y, New StringFormat())
        End If
        '
        y += 20
        count += 20
        printFont = New Font("Arial", 15, FontStyle.Bold)
        ev.Graphics.DrawLine(Pens.Black, 20, y, 840, y)

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

    Private Sub Frm_SituationTreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Cb_CodeJ.SelectedIndex = -1
    End Sub

    Private Sub Cb_CodeJ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_CodeJ.SelectedIndexChanged
        'type treso journal
        Dim lCommandText As String = "SELECT TypeTreso FROM f_journaux WHERE JO_Num = '" & Trim(Cb_CodeJ.Text) & "'"
        gtypeTreso = MyConn.getElmt(lCommandText)
        'intitule journal
        lCommandText = "SELECT JO_Intitule FROM f_journaux WHERE JO_Num = '" & Trim(Cb_CodeJ.Text) & "'"
        gIntitule = MyConn.getElmt(lCommandText)
        'code journal
        gCodeJ = Trim(Cb_CodeJ.Text)
    End Sub

    Private Sub DTDateD_ValueChanged(sender As Object, e As EventArgs) Handles DTDateD.ValueChanged
        'Date debut
        gDebut = FormDate(DTDateD.Value)

    End Sub

    Private Sub DTDateF_ValueChanged(sender As Object, e As EventArgs) Handles DTDateF.ValueChanged
        'Date fin
        gFin = FormDate(DTDateF.Value)

    End Sub
End Class