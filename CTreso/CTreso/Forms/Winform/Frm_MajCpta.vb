Imports System.Data
Imports System.IO

Public Class Frm_MajCpta

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim lFormatExport As Frm_ForatEXPORT = New Frm_ForatEXPORT
        lFormatExport.ShowDialog()

    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub Frm_MajCpta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Cb_CodeJ.SelectedIndex = 0
    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles Btn_Export.Click
        Dim sw As StreamWriter
        Dim lCommandText As String = ""
        If Trim(Tb_NumPieceDeb.Text) <> "" And Trim(Tb_NumPieceFin.Text) <> "" Then
            lCommandText = String.Format("SELECT JO_Num, EC_Date, CG_Num, EC_Piece, EC_NumFac, EC_RefPiece, CT_Num, EC_Intitule, EC_Sens, EC_Montant FROM f_ecriturec WHERE JO_Num = '{0}' AND EC_Date BETWEEN '{1}' AND '{2}' AND EC_Piece BETWEEN '{3}' AND '{4}'", _
            Trim(Cb_CodeJ.Text), FormDate(DTDateD.Value), FormDate(DTDateF.Value), Trim(Tb_NumPieceDeb.Text), Trim(Tb_NumPieceFin.Text))
        Else
            lCommandText = String.Format("SELECT JO_Num, EC_Date, CG_Num, EC_Piece, EC_NumFac, EC_RefPiece, CT_Num, EC_Intitule, EC_Sens, EC_Montant FROM f_ecriturec WHERE JO_Num = '{0}' AND EC_Date BETWEEN '{1}' AND '{2}'", _
                        Trim(Cb_CodeJ.Text), FormDate(DTDateD.Value), FormDate(DTDateF.Value))
        End If
        Dim ldt As DataTable = New DataTable
        ldt = MyConn.displayGrid(lCommandText)
        If ldt.Rows.Count > 0 Then
            ' Configure save file dialog box 
            Dim dlg As New Microsoft.Win32.SaveFileDialog()
            dlg.FileName = "TresoCpta" ' Default file name
            dlg.DefaultExt = ".text" ' Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt" ' Filter files by extension

            ' Show save file dialog box 
            Dim result? As Boolean = dlg.ShowDialog()

            ' Process save file dialog box results 
            If result = True Then
                ' Save document 
                sw = New StreamWriter(dlg.FileName)
                Dim strToWrite As String = ""
                Dim lcodej As String = ""
                Dim ldatep As String = ""
                Dim lcpteg As String = ""
                Dim lnpiece As String = ""
                Dim lnfac As String = ""
                Dim lref As String = ""
                Dim ltiers As String = ""
                Dim llib As String = ""
                Dim lsens As String = ""
                Dim lmontant As String = ""
                Dim lmontantd As String = ""
                Dim lmontantc As String = ""

                For Each r As DataRow In ldt.Rows
                    strToWrite = ""

                    lcodej = Trim(r(0))
                    ldatep = Trim(r(1))
                    lcpteg = Trim(r(2))
                    lnpiece = Trim(r(3))
                    lnfac = Trim(r(4))
                    lref = Trim(r(5))
                    ltiers = Trim(r(6))
                    llib = Trim(r(7))
                    lsens = Trim(r(8))
                    lmontant = Trim(r(9))
                    lmontant = Trim(lmontant)
                    Dim lpos As Integer = lmontant.IndexOf(".")
                    If lpos = -1 Then
                        lmontant = lmontant & ",00"
                    Else
                        lmontant = Mid(lmontant, 1, lpos) & "," & Mid(lmontant, lpos + 2, 2)
                    End If
                    '
                    Dim x As Integer = 0
                    Dim ch As String = ""
                    x = Trim(lcodej).Length
                    If x < 6 Then
                        ch = New String(" ", 6 - x)
                        lcodej &= ch
                    ElseIf x > 6 Then
                        lcodej = Mid(lcodej, 1, 6)
                    End If
                    '
                    ldatep = Mid(Trim(ldatep), 9, 2) & Mid(Trim(ldatep), 6, 2) & Mid(Trim(ldatep), 3, 2)
                    'x = Trim(ldatep).Length
                    'If x < 6 Then
                    ' ch = New String(" ", 6 - x)
                    ' ldatep &= ch
                    ' ElseIf x > 6 Then
                    ' ldatep = Mid(ldatep, 1, 6)
                    ' End If
                    '
                    x = Trim(lcpteg).Length
                    If x < 13 Then
                        ch = New String(" ", 13 - x)
                        lcpteg &= ch
                    ElseIf x > 13 Then
                        lcpteg = Mid(lcpteg, 1, 13)
                    End If
                    '
                    x = Trim(lnpiece).Length
                    If x < 13 Then
                        ch = New String(" ", 13 - x)
                        lnpiece &= ch
                    ElseIf x > 13 Then
                        lnpiece = Mid(lnpiece, 1, 13)
                    End If
                    '
                    x = Trim(lnfac).Length
                    If x < 17 Then
                        ch = New String(" ", 17 - x)
                        lnfac &= ch
                    ElseIf x > 17 Then
                        lnfac = Mid(lnfac, 1, 17)
                    End If
                    '
                    x = Trim(lref).Length
                    If x < 17 Then
                        ch = New String(" ", 17 - x)
                        lref &= ch
                    ElseIf x > 17 Then
                        lref = Mid(lref, 1, 17)
                    End If
                    '
                    x = Trim(ltiers).Length
                    If x < 17 Then
                        ch = New String(" ", 17 - x)
                        ltiers &= ch
                    ElseIf x > 17 Then
                        ltiers = Mid(ltiers, 1, 17)
                    End If
                    '
                    x = Trim(llib).Length
                    If x < 35 Then
                        ch = New String(" ", 35 - x)
                        llib &= ch
                    ElseIf x > 35 Then
                        llib = Mid(llib, 1, 35)
                    End If
                    '
                    If Trim(lsens) = "0" Then
                        x = Trim(lmontant).Length
                        If x < 14 Then
                            ch = New String(" ", 14 - x)
                            lmontantd = lmontant & ch
                        ElseIf x > 35 Then
                            lmontantd = Mid(lmontant, 1, 14)
                        End If
                        lmontantc = New String(" ", 14)
                    Else
                        x = Trim(lmontant).Length
                        If x < 14 Then
                            ch = New String(" ", 14 - x)
                            lmontantc = lmontant & ch
                        ElseIf x > 35 Then
                            lmontantc = Mid(lmontant, 1, 14)
                        End If
                        lmontantd = New String(" ", 14)

                    End If
                    strToWrite &= lcodej & ldatep & lcpteg & lnpiece & lnfac & lref & ltiers & llib & lmontantd & lmontantc
                    sw.WriteLine(strToWrite)
                Next

                sw.Close()
            End If

        Else
            MessageBox.Show("Il n'y a pas de données à Exporter ")
        End If

    End Sub
End Class