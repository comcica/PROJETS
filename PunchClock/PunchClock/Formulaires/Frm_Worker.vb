Imports MySql.Data.MySqlClient

Public Class Frm_Worker

    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Dim idKey As String


    Private Function UpdateRecord() As Boolean
        Dim MyStringInsert As String
        Dim cmd As MySqlCommand
        Dim reader As MySqlDataReader
        reader = Nothing

        MyStringInsert = String.Format("SELECT * FROM t_worker WHERE Id_Worker = '{0}'", Trim(Tbx_idworker.Text))
        cmd = New MySqlCommand(MyStringInsert, MyConn.conn)

        Try
            reader = cmd.ExecuteReader()
            If Not reader.Read() Then
                If Not reader Is Nothing Then reader.Close()
                Return False
            Else
                If Not reader Is Nothing Then reader.Close()
                MyStringInsert = String.Format("UPDATE t_worker SET worker_name = '{0}', worker_email = '{1}', worker_state = '{2}', worker_led = '{3}', worker_valid = '{4}' WHERE Id_Worker = '{5}'", _
                    Trim(Tbx_WorkerName.Text), Trim(Tbx_WorkerEmail.Text), Trim(Cb_WorkerState.Text), Trim(Tbx_WorkerLed.Text), Trim(Cb_WorkerValid.Text), Trim(Tbx_idworker.Text))

                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                reader = cmd.ExecuteReader()

                If Not reader Is Nothing Then reader.Close()
                Return True
            End If
        Catch ex As MySqlException
            If Not reader Is Nothing Then reader.Close()
            Return False
        End Try

    End Function
    Private Function AddRecord() As Boolean
        Dim MyStringInsert As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        reader = Nothing

        MyStringInsert = String.Format("SELECT * FROM t_worker WHERE id_worker = '{0}'", Trim(Tbx_idworker.Text))
        cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
        Try
            reader = cmd.ExecuteReader()
            If Not reader.Read() Then
                If Not reader Is Nothing Then reader.Close()

                If Trim(Tbx_WorkerEmail.Text) <> "" And Trim(Tbx_WorkerLed.Text) <> "" Then
                    MyStringInsert = String.Format("INSERT INTO t_worker (id_worker, worker_name, worker_email, worker_state, worker_led, worker_valid) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", _
                    Tbx_idworker.Text, Tbx_WorkerName.Text, Tbx_WorkerEmail.Text, 0, Tbx_WorkerLed.Text, 1)
                Else
                    If Trim(Tbx_WorkerEmail.Text) = "" And Trim(Tbx_WorkerLed.Text) = "" Then
                        MyStringInsert = String.Format("INSERT INTO t_worker (id_worker, worker_name, worker_state, worker_valid) VALUES ('{0}', '{1}', '{2}', '{3}'", _
                        Tbx_idworker.Text, Tbx_WorkerName.Text, 0, 1)
                    Else
                        If Trim(Tbx_WorkerEmail.Text) = "" Then
                            MyStringInsert = String.Format("INSERT INTO t_worker (id_worker, worker_name, worker_state, worker_led, worker_valid) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", _
                            Tbx_idworker.Text, Tbx_WorkerName.Text, 0, Tbx_WorkerLed.Text, 1)
                        End If
                        If Trim(Tbx_WorkerLed.Text) = "" Then
                            MyStringInsert = String.Format("INSERT INTO t_worker (id_worker, worker_name, worker_state, worker_email, worker_valid) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", _
                            Tbx_idworker.Text, Tbx_WorkerName.Text, 0, Tbx_WorkerEmail.Text, 1)
                        End If

                    End If

                End If

                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                reader = cmd.ExecuteReader()

                If Not reader Is Nothing Then reader.Close()
                Return True
            Else
                If Not reader Is Nothing Then reader.Close()
                Return False
            End If
            'While (reader.Read())
            'databaseList.Items.Add(reader.GetString(0))
            'End While
        Catch ex As MySqlException
            Return False
            'MessageBox.Show("Failed to populate database list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Function
    Private Sub loadCbTouchNotUse()

        Dim reader As MySqlDataReader
        reader = Nothing

        Dim cmd As New MySqlCommand("SELECT * FROM t_touch WHERE Touch_Use = '0'", MyConn.conn)
        Try
            reader = cmd.ExecuteReader()
            cb_WorkerTouchNumberNotUse.Items.Clear()

            While (reader.Read())
                cb_WorkerTouchNumberNotUse.Items.Add(reader.GetString(1))
            End While
        Catch ex As MySqlException
            MessageBox.Show("Failed to populate Touch Number Not use list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Sub
    Private Sub loaddataGrid()

        Try
            data = New DataTable

            da = New MySqlDataAdapter("SELECT * FROM t_worker", MyConn.conn)
            cb = New MySqlCommandBuilder(da)

            da.Fill(data)
            DataGV_peronne.DataSource = data

            DataGV_peronne.Columns(0).Visible = False
            DataGV_peronne.Columns(1).HeaderText = "Id"
            DataGV_peronne.Columns(2).HeaderText = "Name"
            DataGV_peronne.Columns(3).HeaderText = "Email"
            DataGV_peronne.Columns(4).HeaderText = "State"
            DataGV_peronne.Columns(5).HeaderText = "Led"
            'DataGV_peronne.Columns(4).Visible = False
            DataGV_peronne.Columns(6).HeaderText = "Valid"
            DataGV_peronne.Columns(7).HeaderText = "Worker In Time"


        Catch ex As Exception
            'MsgBox("Worker list not available")
        End Try

    End Sub
    Private Sub loaddatagridvWTNA(ByVal MyIdworker As Integer)
        Dim MyStringInsert As String
        Try
            data = New DataTable

            MyStringInsert = String.Format("SELECT * FROM t_workertouch WHERE Id_Worker = '{0}'", Trim(MyIdworker))
            da = New MySqlDataAdapter(MyStringInsert, MyConn.conn)
            cb = New MySqlCommandBuilder(da)

            da.Fill(data)
            DataGridV_AssociateTouchNumber.DataSource = data

            DataGridV_AssociateTouchNumber.Columns(0).Visible = False
            DataGridV_AssociateTouchNumber.Columns(1).Visible = False
            DataGridV_AssociateTouchNumber.Columns(2).HeaderText = "Touch Number"

        Catch ex As Exception

        End Try

    End Sub
    Private Sub datagvSelChg()
        Try
            Tbx_idworker.Text = ""
            Tbx_WorkerName.Text = ""
            Tbx_WorkerEmail.Text = ""
            Cb_WorkerState.Text = ""
            Tbx_WorkerLed.Text = ""
            cb_WorkerTouchNumberNotUse.Text = ""
            Cb_WorkerValid.Text = ""
            DataGridV_AssociateTouchNumber.DataSource = Nothing
            'DataGridV_AssociateTouchNumber.Rows.Clear()
            'MsgBox("ok 2")

            Try
                loaddatagridvWTNA(Trim(DataGV_peronne.SelectedRows(0).Cells(1).Value.ToString))
            Catch ex As Exception

            End Try

            Tbx_idworker.Text = DataGV_peronne.SelectedRows(0).Cells(1).Value.ToString
            Tbx_WorkerName.Text = DataGV_peronne.SelectedRows(0).Cells(2).Value.ToString
            Tbx_WorkerEmail.Text = DataGV_peronne.SelectedRows(0).Cells(3).Value.ToString
            Cb_WorkerState.Text = DataGV_peronne.SelectedRows(0).Cells(4).Value.ToString
            Tbx_WorkerLed.Text = DataGV_peronne.SelectedRows(0).Cells(5).Value.ToString
            Cb_WorkerValid.Text = DataGV_peronne.SelectedRows(0).Cells(6).Value.ToString
            'Cb_WorkerValid.Text = DataGV_peronne.SelectedRows(0).Cells(7).Value.ToString
            'cb_WorkerTouchNumberNotUse.Text = DataGV_peronne.SelectedRows(0).Cells(6).Value.ToString
            'idKey = DataGV_peronne.SelectedRows(0).Cells(6).Value.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Quitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitter.Click
        Me.Close()
    End Sub

    Private Sub Btn_Ajouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ajouter.Click

        Tbx_idworker.Text = ""
        Tbx_WorkerLed.Text = ""
        Tbx_WorkerName.Text = ""
        cb_WorkerTouchNumberNotUse.Text = ""
        Tbx_WorkerEmail.Text = ""
        Cb_WorkerState.Text = ""
        Cb_WorkerValid.Text = ""
        'DataGridV_AssociateTouchNumber.DataSource = Nothing

        DataGV_peronne.Enabled = False

        Btn_modifier.Visible = False
        Btn_supp.Visible = False
        Btn_Ajouter.Visible = False
        Cb_WorkerState.Visible = False
        Cb_WorkerValid.Visible = False
        Lb_WorkerState.Visible = False
        Lb_WorkerValid.Visible = False
        cb_WorkerTouchNumberNotUse.Visible = False
        Lb_ClePersonne.Visible = False
        Btn_moins.Visible = False
        Btn_Plus.Visible = False
        DataGridV_AssociateTouchNumber.Visible = False
        Gb_AssociateTouchNumber.Visible = False

        Btn_Valider.Visible = True
        Btn_Annuler.Visible = True
        Tbx_idworker.Enabled = True

        loadCbTouchNotUse()
    End Sub
    Private Sub refrshValid()
        Btn_modifier.Visible = True
        Btn_supp.Visible = True
        Btn_Ajouter.Visible = True
        Cb_WorkerState.Visible = True
        Cb_WorkerValid.Visible = True
        Lb_WorkerState.Visible = True
        Lb_WorkerValid.Visible = True
        DataGV_peronne.Enabled = True
        Btn_moins.Visible = True
        Btn_Plus.Visible = True
        DataGridV_AssociateTouchNumber.Visible = True
        cb_WorkerTouchNumberNotUse.Visible = True
        Lb_ClePersonne.Visible = True
        Gb_AssociateTouchNumber.Visible = True

        Btn_Valider.Visible = False
        Btn_Annuler.Visible = False
        Tbx_idworker.Enabled = False

        'Connect_WorkerTable()
        MyConn.Connect_BD()
        loadCbTouchNotUse()
        loaddataGrid()

        datagvSelChg()
        'cb_WorkerTouchNumberNotUse.Items.Clear()
    End Sub
    Private Sub Btn_Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Annuler.Click
        refrshValid()
    End Sub

    Private Sub DataGV_peronne_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGV_peronne.SelectionChanged
        datagvSelChg()
    End Sub

    Private Sub Btn_Valider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Valider.Click
        If AddRecord() Then
            MessageBox.Show("Add done")
        Else
            MessageBox.Show("Add failed")
        End If
        refrshValid()
    End Sub

    Private Sub Frm_Worker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Connect_WorkerTable()
        MyConn.Connect_BD()
        loadCbTouchNotUse()
        loaddataGrid()

        datagvSelChg()
        Tbx_idworker.Enabled = False
    End Sub
    Private Function delRecord() As Boolean
        Dim MyStringInsert As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        reader = Nothing

        Try
            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_punchclock WHERE Id_Worker = '{0}'", Trim(Tbx_idworker.Text))
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()
            If Not reader Is Nothing Then reader.Close()

            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_workertouch WHERE Id_Worker = '{0}'", Trim(Tbx_idworker.Text))
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()
            If Not reader Is Nothing Then reader.Close()

            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_worker WHERE Id_Worker = '{0}'", Trim(Tbx_idworker.Text))
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()
            If Not reader Is Nothing Then reader.Close()

            Return True
        Catch ex As MySqlException
            If Not reader Is Nothing Then reader.Close()
            Return False
            'MessageBox.Show("Failed to populate database list: " + ex.Message)
        End Try
    End Function

    Private Sub Btn_supp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_supp.Click
        If MsgBox("Do you want to delete this record ?", vbYesNo) = Windows.Forms.DialogResult.Yes Then
            If delRecord() Then
                MessageBox.Show("Delete done")
            Else
                MessageBox.Show("Delete failed")
            End If
            refrshValid()
        End If
    End Sub

    Private Sub Btn_modifier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_modifier.Click
        If MsgBox("Do you want to update this record ?", vbYesNo) = Windows.Forms.DialogResult.Yes Then
            If UpdateRecord() Then
                MessageBox.Show("Update done")
            Else
                MessageBox.Show("Update failed")
            End If
            refrshValid()
        End If
    End Sub

    Private Function AddRecordAssociateTouchNumber() As Boolean
        Dim MyStringInsert As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        reader = Nothing

        MyStringInsert = String.Format("SELECT * FROM t_workertouch WHERE id_worker = '{0}' AND Touch_Number = '{1}'", Trim(Tbx_idworker.Text), Trim(cb_WorkerTouchNumberNotUse.Text))
        cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
        Try
            reader = cmd.ExecuteReader()
            If Not reader.Read() Then
                If Not reader Is Nothing Then reader.Close()

                MyStringInsert = String.Format("INSERT INTO t_workertouch (id_worker, Touch_Number) VALUES ('{0}', '{1}')", _
                Trim(Tbx_idworker.Text), Trim(cb_WorkerTouchNumberNotUse.Text))

                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                reader = cmd.ExecuteReader()

                If Not reader Is Nothing Then reader.Close()

                MyStringInsert = String.Format("SELECT * FROM t_touch WHERE Touch_Number = '{0}'", Trim(cb_WorkerTouchNumberNotUse.Text))
                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                reader = cmd.ExecuteReader()
                If Not reader.Read() Then
                    If Not reader Is Nothing Then reader.Close()
                    Return False
                Else
                    If Not reader Is Nothing Then reader.Close()
                    MyStringInsert = String.Format("UPDATE t_touch SET Touch_Use = '1' WHERE Touch_Number = '{0}'", _
                        Trim(cb_WorkerTouchNumberNotUse.Text))

                    cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                    reader = cmd.ExecuteReader()
                    If Not reader Is Nothing Then reader.Close()

                    Return True

                End If
            Else
                If Not reader Is Nothing Then reader.Close()
                Return False
            End If
        Catch ex As MySqlException
            Return False
            'MessageBox.Show("Failed to populate database list: " + ex.Message)
        End Try

    End Function

    Private Sub Btn_Plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Plus.Click
        If Trim(cb_WorkerTouchNumberNotUse.Text) = "" Then
            MsgBox("Touch Number empty")
        Else
            If MsgBox("Do you want to Add this record ?", vbYesNo) = Windows.Forms.DialogResult.Yes Then
                If AddRecordAssociateTouchNumber() Then
                    loaddatagridvWTNA(Trim(Tbx_idworker.Text))
                    loadCbTouchNotUse()
                    MessageBox.Show("Add done")
                Else
                    MessageBox.Show("Add failed")
                End If


            End If
        End If
    End Sub

    Private Sub Btn_moins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_moins.Click
        If DataGridV_AssociateTouchNumber.RowCount > 1 Then
            If MsgBox("Do you want to delete this record ?", vbYesNo) = Windows.Forms.DialogResult.Yes Then

                Dim MyStringInsert As String
                Dim reader As MySqlDataReader
                Dim cmd As MySqlCommand
                reader = Nothing

                MyStringInsert = String.Format("DELETE FROM t_workertouch WHERE idt_workertouch = '{0}'", Trim(DataGridV_AssociateTouchNumber.SelectedRows(0).Cells(0).Value.ToString))
                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                Try
                    reader = cmd.ExecuteReader()
                    If Not reader Is Nothing Then reader.Close()

                    MyStringInsert = String.Format("SELECT * FROM t_touch WHERE Touch_Number = '{0}'", Trim(DataGridV_AssociateTouchNumber.SelectedRows(0).Cells(2).Value.ToString))
                    cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                    reader = cmd.ExecuteReader()
                    If Not reader.Read() Then
                        If Not reader Is Nothing Then reader.Close()
                        MessageBox.Show("Delete failed")
                    Else
                        If Not reader Is Nothing Then reader.Close()
                        MyStringInsert = String.Format("UPDATE t_touch SET Touch_Use = '0' WHERE Touch_Number = '{0}'", _
                            Trim(DataGridV_AssociateTouchNumber.SelectedRows(0).Cells(2).Value.ToString))

                        cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                        reader = cmd.ExecuteReader()
                        If Not reader Is Nothing Then reader.Close()

                        loaddatagridvWTNA(Trim(Tbx_idworker.Text))
                        loadCbTouchNotUse()
                        MessageBox.Show("Delete done")
                    End If

                Catch ex As MySqlException
                    If Not reader Is Nothing Then reader.Close()
                    MessageBox.Show("Delete failed")
                    'MessageBox.Show("Failed to populate database list: " + ex.Message)
                End Try

            End If
        End If
    End Sub

End Class