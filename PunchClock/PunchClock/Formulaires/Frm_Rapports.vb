Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.IO
Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Frm_Rapports
    Dim ttt As PrintDialog

    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Dim idKey As String
    Dim MyIdWorker As Integer
    Dim MyNameWorker As String
    Dim tMyCollectionStringG(0) As String
    Dim sw As StreamWriter
    Public lidAuto_Punch As String
    'Dim Doc As Document = New Document
    Public lpunchclock As CPunchClock = New CPunchClock()



    Private Sub Btn_Quitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitter.Click
        Me.Close()
    End Sub

    Private Sub Frm_Rapports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyConn.Connect_BD()
        loadWorker()
        'Btn_ExE.Enabled = False
        Btn_ExWs.Enabled = False
    End Sub
    Private Sub loadWorker()
        Dim reader As MySqlDataReader
        reader = Nothing

        Dim cmd As New MySqlCommand("SELECT * FROM t_worker", MyConn.conn) 'conn)
        Try
            reader = cmd.ExecuteReader()
            Cb_worker.Items.Clear()
            Dim i As Integer = 0
            While (reader.Read())
                Cb_worker.Items.Add(reader.GetString(2))
                ReDim Preserve Tworker(i)
                Tworker(i).Id_Worker = reader.GetString(1)
                Tworker(i).Worker_Name = reader.GetString(2)
                Tworker(i).Worker_Email = reader.GetString(3)
                Tworker(i).Worker_State = reader.GetString(4)
                Tworker(i).Worker_Led = reader.GetString(5)
                Tworker(i).Worker_Valid = reader.GetString(6)
                i += 1
            End While
        Catch ex As MySqlException
            MessageBox.Show("Failed to populate Worker list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub
    Public Sub Search_WorkSheet()
        'PdfWriter.GetInstance(Doc, New FileStream(RepTravail & Worksheet_String, FileMode.Create))
        sw = New StreamWriter(RepTravail & "\" & Worksheet_String)
        'Doc.Open()

        ReDim tMyCollectionStringG(0)
        Lb_TotalGlobal.Text = ""
        DataGridV_PunchErreur.DataSource = Nothing
        RichTextBox1.Clear()

        Dim dataerreur As DataTable
        dataerreur = New DataTable()

        dataerreur.Columns.Add("idauto")
        dataerreur.Columns.Add("idwork")
        dataerreur.Columns.Add("tnumber")
        dataerreur.Columns.Add("date")
        dataerreur.Columns.Add("He_Am")
        dataerreur.Columns.Add("Hs_Am")
        dataerreur.Columns.Add("He_Pm")
        dataerreur.Columns.Add("Hs_Pm")
        '
        If ChB_Tous.Checked Then
            For i = 0 To Tworker.Length - 1
                MyIdWorker = Tworker(i).Id_Worker
                MyNameWorker = Tworker(i).Worker_Name
                Tsearch(dataerreur)
            Next
            If RichTextBox1.Lines.Count > 0 Then
                Btn_ExWs.Enabled = True
            End If
            'Next
        Else
            If Trim(Cb_worker.Text) <> "" Then
                Tsearch(dataerreur)

                If RichTextBox1.Lines.Count > 0 Then
                    Btn_ExWs.Enabled = True
                End If
                'Btn_ExE.Enabled = True

            Else
                MessageBox.Show("You must enter a worker: ")
            End If
        End If
        '
        DataGridV_PunchErreur.DataSource = dataerreur

        DataGridV_PunchErreur.Columns(0).Visible = False
        DataGridV_PunchErreur.Columns(1).HeaderText = "Id_Worker"
        DataGridV_PunchErreur.Columns(2).HeaderText = "Touch_Number"
        DataGridV_PunchErreur.Columns(3).HeaderText = "Date"
        DataGridV_PunchErreur.Columns(4).HeaderText = "T_Start_Am"
        DataGridV_PunchErreur.Columns(5).HeaderText = "T_Stop_Am"
        DataGridV_PunchErreur.Columns(6).HeaderText = "T_Start_Pm"
        DataGridV_PunchErreur.Columns(7).HeaderText = "T_Stop_Pm"

        If DataGridV_PunchErreur.RowCount > 0 Then
            sw.WriteLine("")
            sw.WriteLine("Punchs Incorrects de la période")
            sw.WriteLine("")
            sw.WriteLine("Matr." & " " & "Touch       " & " " & " Date      " & "  " & " IN am   " & "  " & " Out am  " & "  " & " IN pm   " & "  " & " Out pm  ")
            Dim chsepare As String = New String(" ", 8)
            For Each r As DataGridViewRow In DataGridV_PunchErreur.Rows
                If Trim(r.Cells(1).Value) <> "" Then
                    If Trim(r.Cells(4).Value) = "" Then
                        r.Cells(4).Value = chsepare
                    End If
                    If Trim(r.Cells(5).Value) = "" Then
                        r.Cells(5).Value = chsepare
                    End If
                    If Trim(r.Cells(6).Value) = "" Then
                        r.Cells(6).Value = chsepare
                    End If
                    If Trim(r.Cells(7).Value) = "" Then
                        r.Cells(7).Value = chsepare
                    End If

                    sw.WriteLine(r.Cells(1).Value & " " & "|" & " " & r.Cells(2).Value & " " & "|" & " " & r.Cells(3).Value & " " & "|" & " " & _
                                 r.Cells(4).Value & " " & "|" & " " & r.Cells(5).Value & " " & "|" & " " & r.Cells(6).Value & " " & "|" & " " & r.Cells(7).Value)
                End If
            Next r
        End If
        sw.Close()
        'Doc.Close()
    End Sub
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Search_WorkSheet()
    End Sub

    Private Sub Cb_worker_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cb_worker.SelectedValueChanged
        Dim MyStringInsert As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        reader = Nothing

        Try
            MyStringInsert = ""
            MyStringInsert = String.Format("SELECT * FROM t_worker WHERE Worker_Name = '{0}'", Trim(Cb_worker.Text))
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn) 'conn)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                MyIdWorker = reader.GetString(1)
                MyNameWorker = reader.GetString(2)
            End If
        Catch ex As Exception

        Finally
            If Not reader Is Nothing Then reader.Close()
            Me.Text &= "  : " & MyNameWorker
        End Try


    End Sub
    Private Sub PunchJour(ByVal Tdatatemp As DataTable, ByVal ddebut As String, ByVal dfin As String)
        Dim datePunch, touchNumberPunch, He_Am, He_Pm, Hs_Am, Hs_Pm, TotLigne As String
        Dim datePunch_Suivant, touchNumberPunch_Suivant, He_Am_Suivant, He_Pm_Suivant, Hs_Am_Suivant, Hs_Pm_Suivant, TotLigne_Suivant As String

        Dim t_IdAuto, t_idworker, t_IdAuto_s, t_idworker_s As Integer
        '
        Dim TotalHeure As New TimeSpan
        Dim TotalHeureGlobal As New TimeSpan
        'Dim hour, mins, secs As Integer
        Dim chsepare As String
        Dim tMyCollectionString(0) As String

        Try
            Dim TotPosition As Integer
            Dim k As Integer = 0
            Dim p As Integer = 0

            'TotalHeureGlobal = Nothing

            While k <= Tdatatemp.Rows.Count - 1

                t_IdAuto = Tdatatemp.Rows(k)(0).ToString()
                t_idworker = Tdatatemp.Rows(k)(1).ToString()
                touchNumberPunch = Tdatatemp.Rows(k)(2).ToString()
                datePunch = Tdatatemp.Rows(k)(3).ToString()
                He_Am = Tdatatemp.Rows(k)(4).ToString()
                Hs_Am = Tdatatemp.Rows(k)(5).ToString()
                He_Pm = Tdatatemp.Rows(k)(6).ToString()
                Hs_Pm = Tdatatemp.Rows(k)(7).ToString()
                TotLigne = Tdatatemp.Rows(k)(8).ToString()

                chsepare = New String(" ", 8)
                If Trim(He_Am) = "" Then
                    He_Am = chsepare
                End If
                If Trim(Hs_Am) = "" Then
                    Hs_Am = chsepare
                End If
                If Trim(He_Pm) = "" Then
                    He_Pm = chsepare
                End If
                If Trim(Hs_Pm) = "" Then
                    Hs_Pm = chsepare
                End If

                k = k + 1
                If k <= Tdatatemp.Rows.Count - 1 Then
                    t_IdAuto_s = Tdatatemp.Rows(k)(0).ToString()
                    t_idworker_s = Tdatatemp.Rows(k)(1).ToString()
                    touchNumberPunch_Suivant = Tdatatemp.Rows(k)(2).ToString()
                    datePunch_Suivant = Tdatatemp.Rows(k)(3).ToString()
                    He_Am_Suivant = Tdatatemp.Rows(k)(4).ToString()
                    Hs_Am_Suivant = Tdatatemp.Rows(k)(5).ToString()
                    He_Pm_Suivant = Tdatatemp.Rows(k)(6).ToString()
                    Hs_Pm_Suivant = Tdatatemp.Rows(k)(7).ToString()
                    TotLigne_Suivant = Tdatatemp.Rows(k)(8).ToString()

                    If datePunch_Suivant = datePunch Then
                        Dim ts As TimeSpan
                        Dim MyString As String = ""
                        Dim MyStringCsv As String = ""
                        TimeSpan.TryParse(TotLigne, ts)
                        TotalHeure = TotalHeure + ts
                        TotalHeureGlobal = TotalHeureGlobal + ts

                        MyString = "    " & touchNumberPunch & " " & "|" & " " & He_Am & " " & "|" & " " & Hs_Am & " "
                        MyString &= "|" & " " & He_Pm & " " & "|" & " " & Hs_Pm & " " & "|" & " " & TotLigne '

                        'MyString = datePunch & "|" & vbTab & touchNumberPunch & "     " & He_Am & "     " & Hs_Am
                        'MyString &= "     " & He_Pm & "     " & Hs_Pm & "     " & TotLigne '
                        '
                        k = k - 1
                        If p = 0 Then
                            tMyCollectionString(p) = " "
                            p += 1
                            ReDim Preserve tMyCollectionString(p)

                            tMyCollectionString(p) = "Worksheet : " & "      " & MyNameWorker & vbTab & "Du " & ddebut & " au " & dfin & vbCrLf
                            p += 1
                            ReDim Preserve tMyCollectionString(p)

                            TotPosition = p
                            tMyCollectionString(p) = " "
                            p += 1
                        End If
                        ReDim Preserve tMyCollectionString(p)
                        tMyCollectionString(p) = MyString

                        p += 1
                    Else
                        Dim ts As TimeSpan
                        TimeSpan.TryParse(TotLigne, ts)
                        Dim MyString As String = ""
                        TotalHeure = TotalHeure + ts
                        TotalHeureGlobal = TotalHeureGlobal + ts

                        MyString = "    " & touchNumberPunch & " " & "|" & " " & He_Am & " " & "|" & " " & Hs_Am & " "
                        MyString &= "|" & " " & He_Pm & " " & "|" & " " & Hs_Pm & " " & "|" & " " & TotLigne '

                        'MyString = datePunch & " " & "|" & " " & touchNumberPunch & " " & "|" & " " & He_Am & " " & "|" & " " & Hs_Am & " "
                        'MyString &= "|" & " " & He_Pm & " " & "|" & " " & Hs_Pm & " " & "|" & " " & TotLigne '

                        'MyString = datePunch & vbTab & touchNumberPunch & "     " & He_Am & "     " & Hs_Am
                        'MyString &= "     " & He_Pm & "     " & Hs_Pm & "     " & TotLigne  '& vbCrLf

                        k = k - 1
                        If p = 0 Then
                            tMyCollectionString(p) = " "
                            p += 1
                            ReDim Preserve tMyCollectionString(p)

                            tMyCollectionString(p) = "Worksheet : " & "      " & MyNameWorker & "      " & "Du " & ddebut & " au " & dfin & vbCrLf
                            p += 1
                            ReDim Preserve tMyCollectionString(p)

                            TotPosition = p
                            tMyCollectionString(p) = " "
                            p += 1
                        End If

                        ReDim Preserve tMyCollectionString(p)
                        tMyCollectionString(p) = MyString

                        'tMyCollectionString(TotPosition) = "Jour:  " & vbTab & datePunch & vbTab & "Total :" & vbTab & Int(TotalHeure.TotalHours).ToString("00") & ":" & TotalHeure.Minutes.ToString("00") & ":" & TotalHeure.Seconds.ToString("00")
                        tMyCollectionString(TotPosition) = "Jour: " & datePunch & "   " & "Entree am" & "  " & "Sortie am" & "  " & "Entree pm" & "  " & "Sortie pm" & "  " & "Total"
                        p += 1
                        ReDim Preserve tMyCollectionString(p)
                        chsepare = New String(" ", 63)
                        tMyCollectionString(p) = chsepare & "--------"

                        p += 1
                        ReDim Preserve tMyCollectionString(p)
                        chsepare = New String(" ", 46)
                        tMyCollectionString(p) = "Total :" & datePunch & chsepare & Int(TotalHeure.TotalHours).ToString("00") & ":" & TotalHeure.Minutes.ToString("00") & ":" & TotalHeure.Seconds.ToString("00")
                        'TotalHeure = TimeSpan.Zero
                        TotalHeure = New TimeSpan

                        p += 1
                        ReDim Preserve tMyCollectionString(p)
                        tMyCollectionString(p) = " "
                        p += 1
                        ReDim Preserve tMyCollectionString(p)
                        tMyCollectionString(p) = " " '& vbCrLf
                        TotPosition = p
                        p += 1


                    End If
                Else
                    Dim ts As TimeSpan
                    Dim MyString As String = ""
                    TimeSpan.TryParse(TotLigne, ts)
                    TotalHeure = TotalHeure + ts
                    TotalHeureGlobal = TotalHeureGlobal + ts

                    MyString = "    " & touchNumberPunch & " " & "|" & " " & He_Am & " " & "|" & " " & Hs_Am & " "
                    MyString &= "|" & " " & He_Pm & " " & "|" & " " & Hs_Pm & " " & "|" & " " & TotLigne '

                    'MyString = datePunch & vbTab & touchNumberPunch & "     " & He_Am & "     " & Hs_Am
                    'MyString &= "     " & He_Pm & "     " & Hs_Pm & "     " & TotLigne & vbCrLf

                    k = k - 1
                    If p = 0 Then
                        tMyCollectionString(p) = " "
                        p += 1
                        ReDim Preserve tMyCollectionString(p)

                        tMyCollectionString(p) = "Worksheet : " & "      " & MyNameWorker & vbTab & "Du " & ddebut & " au " & dfin & vbCrLf
                        p += 1
                        ReDim Preserve tMyCollectionString(p)

                        TotPosition = p
                        tMyCollectionString(p) = " "
                        p += 1
                    End If

                    ReDim Preserve tMyCollectionString(p)
                    tMyCollectionString(p) = MyString

                    'tMyCollectionString(TotPosition) = "Jour:  " & datePunch & vbTab & "Total :" & vbTab & Int(TotalHeure.TotalHours).ToString("00") & ":" & TotalHeure.Minutes.ToString("00") & ":" & TotalHeure.Seconds.ToString("00")
                    tMyCollectionString(TotPosition) = "Jour: " & datePunch & "   " & "Entree am" & "  " & "Sortie am" & "  " & "Entree pm" & "  " & "Sortie pm" & "  " & "Total"
                    p += 1
                    ReDim Preserve tMyCollectionString(p)
                    chsepare = New String(" ", 63)
                    tMyCollectionString(p) = chsepare & "--------"

                    p += 1
                    ReDim Preserve tMyCollectionString(p)
                    chsepare = New String(" ", 46)
                    tMyCollectionString(p) = "Total :" & datePunch & chsepare & Int(TotalHeure.TotalHours).ToString("00") & ":" & TotalHeure.Minutes.ToString("00") & ":" & TotalHeure.Seconds.ToString("00")

                    'TotalHeure = TimeSpan.Zero
                    TotalHeure = New TimeSpan

                    p += 1
                    ReDim Preserve tMyCollectionString(p)
                    tMyCollectionString(p) = " "
                    p += 1
                    ReDim Preserve tMyCollectionString(p)
                    tMyCollectionString(p) = " "
                    TotPosition = p
                    p += 1

                End If

                k = k + 1
            End While
            p -= 1
            ReDim Preserve tMyCollectionString(p)

            Dim x As Integer = Len(Trim(MyNameWorker))
            If x <= 10 Then
                chsepare = New String(" ", 10 - x)
                MyNameWorker = Trim(MyNameWorker) & chsepare
            Else
                MyNameWorker = Mid(Trim(MyNameWorker), 1, 10)
            End If

            tMyCollectionString(p) = "Total Worksheet : " & " " & MyNameWorker & "  " & "Du " & ddebut & " au " & dfin & "  :  " & Int(TotalHeureGlobal.TotalHours).ToString("00") & ":" & TotalHeureGlobal.Minutes.ToString("00") & ":" & TotalHeureGlobal.Seconds.ToString("00")
            p += 1
            ReDim Preserve tMyCollectionString(p)
            chsepare = New String("-", 72)
            tMyCollectionString(p) = chsepare
            'tMyCollectionString(p) = "Total Worksheet : " & vbTab & MyNameWorker & vbTab & "Du " & ddebut & " au " & dfin & "  :" & vbTab & TotalHeureGlobal.ToString("hh\:mm\:ss")
            p += 1
            ReDim Preserve tMyCollectionString(p)
            'Dim MonPDF As New PdfPTable(1)

            For i = 0 To tMyCollectionString.Length - 1
                Dim Tailleg As Integer = tMyCollectionStringG.Length - 1
                'Dim MonPDF As PdfPTable

                tMyCollectionStringG(Tailleg) = tMyCollectionString(i)
                Tailleg += 1
                ReDim Preserve tMyCollectionStringG(Tailleg)


                'MonPDF.AddCell(tMyCollectionString(i))
                sw.WriteLine(tMyCollectionString(i))
                'Doc.Add(MonPDF)
            Next
            'Doc.Add(MonPDF)


            RichTextBox1.Lines = tMyCollectionStringG
            If Not ChB_Tous.Checked Then
                Lb_TotalGlobal.Text = Int(TotalHeureGlobal.TotalHours).ToString("00") & ":" & TotalHeureGlobal.Minutes.ToString("00") & ":" & TotalHeureGlobal.Seconds.ToString("00")
            End If
        Catch

        End Try

    End Sub
    Private Sub Tsearch(ByRef dataerreur As DataTable)
        Dim MyStringInsert, datePunch, touchNumberPunch, He_Am, Hs_Am, datePunch_Suivant, touchNumberPunch_suivant, He_Am_suivant, Hs_Am_suivant As String
        Dim He_Pm, Hs_Pm, He_Pm_suivant, Hs_Pm_suivant As String
        Dim Mon_HeurePmAm As String

        'Dim dataerreur As DataTable
        'Dim datanormale As DataTable
        Dim datatemp As DataTable

        Dim t_IdAuto, t_idworker As Integer
        Dim t_IdAuto_s, t_idworker_s As Integer
        Dim date_debut As String = ""
        Dim date_fin As String = ""

        'Try
        date_debut = FormDate(DTDebut.Value)
        date_fin = FormDate(DTFin.Value)

        data = New DataTable()
        'dataerreur = New DataTable()
        datatemp = New DataTable()

        'dataerreur.Columns.Add("idauto")
        'dataerreur.Columns.Add("idwork")
        'dataerreur.Columns.Add("tnumber")
        'dataerreur.Columns.Add("date")
        'dataerreur.Columns.Add("He_Am")
        'dataerreur.Columns.Add("Hs_Am")
        'dataerreur.Columns.Add("He_Pm")
        'dataerreur.Columns.Add("Hs_Pm")


        datatemp.Columns.Add("idauto") '0
        datatemp.Columns.Add("idwork") '1
        datatemp.Columns.Add("tnumber") '2
        datatemp.Columns.Add("date") '3
        datatemp.Columns.Add("He_Am") '4
        datatemp.Columns.Add("Hs_Am") '5
        datatemp.Columns.Add("He_Pm") '6
        datatemp.Columns.Add("Hs_Pm") '7

        datatemp.Columns.Add("Total") '8

        MyStringInsert = ""
        MyStringInsert = String.Format("SELECT * FROM t_punchclock WHERE Id_Worker = '{0}' AND Date BETWEEN '{1}' AND '{2}' ORDER BY idT_PUNCHCLOCK ASC", MyIdWorker, date_debut, date_fin)


        da = New MySqlDataAdapter(MyStringInsert, MyConn.conn) ' conn)
        cb = New MySqlCommandBuilder(da)

        da.Fill(data)

        Dim k As Integer = 0
        Dim MaPositionVerif As Integer = 0
        'For k = 0 To data.Rows.Count - 1
        While k <= data.Rows.Count - 1

            If Trim(data.Rows(k)(4).ToString()) = "" Then
                Dim rowtowrite As DataRow = dataerreur.NewRow
                rowtowrite(0) = data.Rows(k)(0).ToString()
                rowtowrite(1) = data.Rows(k)(1).ToString()
                rowtowrite(2) = data.Rows(k)(2).ToString()
                rowtowrite(3) = data.Rows(k)(3).ToString()

                Mon_HeurePmAm = data.Rows(k)(5).ToString()
                If Val(Mid(Trim(Mon_HeurePmAm), 1, 2)) <= 12 Then
                    rowtowrite(4) = ""
                    rowtowrite(5) = Mon_HeurePmAm
                    rowtowrite(6) = ""
                    rowtowrite(7) = ""

                Else
                    rowtowrite(4) = ""
                    rowtowrite(5) = ""
                    rowtowrite(6) = ""
                    rowtowrite(7) = Mon_HeurePmAm

                End If
                dataerreur.Rows.Add(rowtowrite)

            Else
                t_IdAuto = data.Rows(k)(0).ToString()
                t_idworker = data.Rows(k)(1).ToString()
                touchNumberPunch = data.Rows(k)(2).ToString()
                datePunch = data.Rows(k)(3).ToString()

                Mon_HeurePmAm = data.Rows(k)(4).ToString()
                If Val(Mid(Trim(Mon_HeurePmAm), 1, 2)) <= 12 Then
                    He_Am = Mon_HeurePmAm
                    Hs_Am = ""
                    He_Pm = ""
                    Hs_Pm = ""
                Else
                    He_Pm = Mon_HeurePmAm
                    Hs_Am = ""
                    He_Am = ""
                    Hs_Pm = ""
                End If
                MaPositionVerif = k
                'je commence ici
                k = k + 1
                If k <= data.Rows.Count - 1 Then
                    Dim MaSortie As Boolean = False
                    While Trim(data.Rows(k)(4).ToString()) = ""
                        k = k + 1
                        If k > data.Rows.Count - 1 Then
                            MaSortie = True
                            Exit While
                        End If
                    End While
                    'If MaSortie = False Then
                    k = k - 1
                    'End If
                End If
                'termine ici

                'k = k + 1
                If k <= data.Rows.Count - 1 Then

                    t_IdAuto_s = data.Rows(k)(0).ToString()
                    t_idworker_s = data.Rows(k)(1).ToString()
                    touchNumberPunch_suivant = data.Rows(k)(2).ToString()
                    datePunch_Suivant = data.Rows(k)(3).ToString()

                    'Heure entre suivante
                    Mon_HeurePmAm = data.Rows(k)(4).ToString()
                    If Trim(Mon_HeurePmAm) = "" Then
                        He_Pm_suivant = ""
                        He_Am_suivant = ""
                    Else
                        If Val(Mid(Trim(Mon_HeurePmAm), 1, 2)) <= 12 Then
                            He_Am_suivant = Mon_HeurePmAm
                            He_Pm_suivant = ""
                        Else
                            He_Pm_suivant = Mon_HeurePmAm
                            He_Am_suivant = ""
                        End If
                    End If

                    'Heure sortie suivante
                    Mon_HeurePmAm = data.Rows(k)(5).ToString()
                    If Trim(Mon_HeurePmAm) = "" Then
                        Hs_Pm_suivant = ""
                        Hs_Am_suivant = ""
                    Else
                        If Val(Mid(Trim(Mon_HeurePmAm), 1, 2)) <= 12 Then
                            Hs_Am_suivant = Mon_HeurePmAm
                            Hs_Pm_suivant = ""
                        Else
                            Hs_Pm_suivant = Mon_HeurePmAm
                            Hs_Am_suivant = ""
                        End If
                    End If

                    If t_IdAuto_s > t_IdAuto And datePunch_Suivant = datePunch And t_idworker_s = t_idworker And Trim(He_Am_suivant) = "" And Trim(He_Pm_suivant) = "" Then
                        If Trim(Hs_Am_suivant) <> "" Or Trim(Hs_Pm_suivant) <> "" Then
                            Dim Th_debut, Th_fin As String
                            Dim rowtowrite As DataRow = datatemp.NewRow
                            rowtowrite(0) = t_IdAuto
                            rowtowrite(1) = t_idworker
                            rowtowrite(2) = touchNumberPunch
                            rowtowrite(3) = datePunch
                            ' heure debut
                            If Trim(He_Am) <> "" Then
                                rowtowrite(4) = He_Am 't_he
                                Th_debut = He_Am
                                rowtowrite(6) = ""
                            Else
                                rowtowrite(4) = ""
                                rowtowrite(6) = He_Pm
                                Th_debut = He_Pm
                            End If
                            'heure fin
                            If Trim(Hs_Am_suivant) <> "" Then
                                rowtowrite(5) = Hs_Am_suivant
                                Th_fin = Hs_Am_suivant
                                rowtowrite(7) = ""
                            Else
                                rowtowrite(5) = ""
                                rowtowrite(7) = Hs_Pm_suivant
                                Th_fin = Hs_Pm_suivant
                            End If

                            ' Total
                            rowtowrite(8) = CalculDifferenceHeure(Th_debut, Th_fin)
                            datatemp.Rows.Add(rowtowrite)
                        Else
                            Dim rowtowrite As DataRow = dataerreur.NewRow
                            rowtowrite(0) = t_IdAuto
                            rowtowrite(1) = t_idworker
                            rowtowrite(2) = touchNumberPunch
                            rowtowrite(3) = datePunch

                            If Trim(He_Am) <> "" Then
                                rowtowrite(4) = He_Am
                                rowtowrite(5) = ""
                                rowtowrite(6) = ""
                                rowtowrite(7) = ""
                                rowtowrite(8) = ""
                            Else
                                rowtowrite(4) = He_Pm
                                rowtowrite(5) = ""
                                rowtowrite(6) = ""
                                rowtowrite(7) = ""
                                rowtowrite(8) = ""
                            End If
                            dataerreur.Rows.Add(rowtowrite)
                            'k = k - 1
                            k = MaPositionVerif

                        End If
                    Else
                        Dim rowtowrite As DataRow = dataerreur.NewRow
                        rowtowrite(0) = t_IdAuto
                        rowtowrite(1) = t_idworker
                        rowtowrite(2) = touchNumberPunch
                        rowtowrite(3) = datePunch

                        If Trim(He_Am) <> "" Then
                            rowtowrite(4) = He_Am
                            rowtowrite(5) = ""
                            rowtowrite(6) = ""
                            rowtowrite(7) = ""
                            'rowtowrite(8) = ""
                        Else
                            rowtowrite(4) = He_Pm
                            rowtowrite(5) = ""
                            rowtowrite(6) = ""
                            rowtowrite(7) = ""
                            'rowtowrite(8) = ""
                        End If
                        dataerreur.Rows.Add(rowtowrite)
                        k = MaPositionVerif
                        'k = k - 1

                    End If
                Else
                    Dim rowtowrite As DataRow = dataerreur.NewRow
                    rowtowrite(0) = t_IdAuto
                    rowtowrite(1) = t_idworker
                    rowtowrite(2) = touchNumberPunch
                    rowtowrite(3) = datePunch

                    If Trim(He_Am) <> "" Then
                        rowtowrite(4) = He_Am
                        rowtowrite(5) = ""
                        rowtowrite(6) = ""
                        rowtowrite(7) = ""
                        'rowtowrite(8) = ""
                    Else
                        rowtowrite(4) = He_Pm
                        rowtowrite(5) = ""
                        rowtowrite(6) = ""
                        rowtowrite(7) = ""
                        'rowtowrite(8) = ""
                    End If
                    dataerreur.Rows.Add(rowtowrite)

                    'k = k - 1

                End If

            End If
            k = k + 1
        End While
        'Next k

        PunchJour(datatemp, date_debut, date_fin)

    End Sub

    Private Sub ChB_Tous_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChB_Tous.CheckedChanged
        If ChB_Tous.Checked Then
            Cb_worker.Enabled = False
            Lb_TotalGlobal.Visible = False
            Label1.Visible = False
            'Btn_ExE.Visible = False
            Btn_ExWs.Enabled = False
            'Btn_ExE.Enabled = False
            Me.Text = "Rapports WorkSheet"
        Else
            Cb_worker.Enabled = True
            Lb_TotalGlobal.Visible = True
            Label1.Visible = True
            'Btn_ExE.Visible = True
            Btn_ExWs.Enabled = False
            'Btn_ExE.Enabled = False

        End If

    End Sub

    Private Sub Btn_ExWs_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ExWs.Click
        Dim ReturnValue
        ReturnValue = Shell("c:\windows\notepad.exe " & RepTravail & "\" & Worksheet_String, 1)
        'impression des punchs incorrects
        'ReturnValue = Shell("c:\windows\notepad.exe " & RepTravail & "\" & , 1)

    End Sub

    Private Sub DataGridV_PunchErreur_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridV_PunchErreur.CellMouseDoubleClick
        If Trim(lidAuto_Punch) <> "" Then
            Dim MyStringInsert As String = ""
            Dim reader As MySqlDataReader
            Dim cmd As MySqlCommand

            reader = Nothing

            Try
                MyStringInsert = String.Format("SELECT * FROM t_punchclock WHERE idT_PUNCHCLOCK = '{0}'", Trim(lidAuto_Punch))
                cmd = New MySqlCommand(MyStringInsert, MyConn.conn) 'conn)
                reader = cmd.ExecuteReader()

                If reader.Read() Then
                    lpunchclock.idT_PUNCHCLOCK = reader.GetString(0)
                    lpunchclock.Id_Worker = reader.GetString(1)
                    lpunchclock.Touch_Number = reader.GetString(2)
                    lpunchclock.PDate = reader.GetString(3)
                    lpunchclock.Time_Start = reader.GetString(4)
                    lpunchclock.Time_Stop = reader.GetString(5)
                    '
                    Frm_UpdatePunch.Tb_DatePunch.Text = lpunchclock.PDate
                    Frm_UpdatePunch.Tb_TimeStartPunch.Text = lpunchclock.Time_Start
                    Frm_UpdatePunch.Tb_TimeStopPunch.Text = lpunchclock.Time_Stop
                    ' 
                    Frm_UpdatePunch.Show()
                End If
            Catch ex As MySqlException
                MessageBox.Show("Failed to populate PunchClock : " + ex.Message)
            Finally
                If Not reader Is Nothing Then reader.Close()
            End Try

        End If
    End Sub

    Private Sub DataGridV_PunchErreur_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridV_PunchErreur.SelectionChanged
        If DataGridV_PunchErreur.SelectedRows.Count <> 0 Then
            lidAuto_Punch = DataGridV_PunchErreur.SelectedRows(0).Cells(0).Value.ToString
        End If
    End Sub

    Private Sub Cb_worker_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_worker.SelectedIndexChanged

    End Sub
End Class