Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.IO
Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Frm_DisplayPunch
    Dim MyIdWorker As Integer
    Dim MyNameWorker As String
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Public lidAuto_Punch As String
    Public lpunchclock As CPunchClock = New CPunchClock()

    Private Sub Btn_Search_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Search.Click
        Dim dataToDisplay As DataTable
        Dim data As DataTable
        '
        Dim date_debut As String = ""
        Dim date_fin As String = ""
        Dim MyStringInsert As String

        date_debut = FormDate(DTDebut.Value)
        date_fin = FormDate(DTFin.Value)

        Data = New DataTable()
        dataToDisplay = New DataTable()

        dataToDisplay.Columns.Add("idauto")
        dataToDisplay.Columns.Add("idwork")
        dataToDisplay.Columns.Add("tnumber")
        dataToDisplay.Columns.Add("date")
        dataToDisplay.Columns.Add("He")
        dataToDisplay.Columns.Add("Hs")
        'dataToDisplay.Columns.Add("He_Pm")
        'dataToDisplay.Columns.Add("Hs_Pm")
        '
        MyStringInsert = ""
        MyStringInsert = String.Format("SELECT * FROM t_punchclock WHERE Id_Worker = '{0}' AND Date BETWEEN '{1}' AND '{2}' ORDER BY idT_PUNCHCLOCK ASC", MyIdWorker, date_debut, date_fin)


        da = New MySqlDataAdapter(MyStringInsert, MyConn.conn) ' conn)
        cb = New MySqlCommandBuilder(da)

        da.Fill(data)
        '
        Dim k As Integer = 0
        Dim Mon_HeurePmAm As String

        While k <= data.Rows.Count - 1

            Dim rowtowrite As DataRow = dataToDisplay.NewRow
            rowtowrite(0) = data.Rows(k)(0).ToString()
            rowtowrite(1) = data.Rows(k)(1).ToString()
            rowtowrite(2) = data.Rows(k)(2).ToString()
            rowtowrite(3) = data.Rows(k)(3).ToString()

            rowtowrite(4) = data.Rows(k)(4).ToString()
            rowtowrite(5) = data.Rows(k)(5).ToString()

            dataToDisplay.Rows.Add(rowtowrite)
            k = k + 1
        End While
        '
        DataGridV_Punch.DataSource = dataToDisplay

        DataGridV_Punch.Columns(0).Visible = False
        DataGridV_Punch.Columns(1).HeaderText = "Id_Worker"
        DataGridV_Punch.Columns(2).HeaderText = "Touch_Number"
        DataGridV_Punch.Columns(3).HeaderText = "Date"
        DataGridV_Punch.Columns(4).HeaderText = "Time Start"
        DataGridV_Punch.Columns(5).HeaderText = "Time Stop"

    End Sub

    Private Sub Frm_DisplayPunch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MyConn.Connect_BD()
        loadWorker()

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


    Private Sub Cb_worker_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles Cb_worker.SelectedValueChanged
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

    Private Sub Btn_Quitter_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Quitter.Click
        Me.Close()
    End Sub

    Private Sub DataGridV_Punch_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridV_Punch.CellContentClick

    End Sub

    Private Sub DataGridV_Punch_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridV_Punch.CellMouseDoubleClick
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

    Private Sub DataGridV_Punch_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridV_Punch.SelectionChanged
        If DataGridV_Punch.SelectedRows.Count <> 0 Then
            lidAuto_Punch = DataGridV_Punch.SelectedRows(0).Cells(0).Value.ToString
        End If

    End Sub
End Class