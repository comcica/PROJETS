Imports MySql.Data.MySqlClient

Public Class Frm_Touch
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Dim idKey As String


    Private Sub Frm_Touch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MyConn.Connect_BD()
        loaddataGrid()
        datagvSelChg()
        Chb_Use.Enabled = False
        Tbx_WorkerTouchNumber.Enabled = False
    End Sub

    Private Function UpdateRecord() As Boolean
        Dim MyStringInsert As String
        Dim cmd As MySqlCommand
        Dim reader As MySqlDataReader
        Dim Mycheck As String = ""
        Dim MycheckUse As String = ""
        reader = Nothing

        MyStringInsert = String.Format("SELECT * FROM t_touch WHERE touch_number = '{0}'", idKey)
        cmd = New MySqlCommand(MyStringInsert, MyConn.conn)

        Try
            reader = cmd.ExecuteReader()
            If Not reader.Read() Then
                Return False
            Else
                If Chb_TouchValid.Checked = False Then
                    Mycheck = "0"
                End If
                If Chb_TouchValid.Checked = True Then
                    Mycheck = "1"
                End If
                'If Chb_Use.Checked = False Then
                '    MycheckUse = "0"
                'End If
                'If Chb_Use.Checked = True Then
                '    MycheckUse = "1"
                'End If

                If Not reader Is Nothing Then reader.Close()
                MyStringInsert = ""
                MyStringInsert = String.Format("UPDATE t_touch SET Touch_Valide = '{0}' WHERE touch_number = '{1}'", _
                     Trim(Mycheck), idKey)

                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                cmd.ExecuteReader()
                Return True
            End If
        Catch ex As MySqlException
            Return False
        End Try

    End Function
    Private Function AddRecord() As Boolean
        Dim MyStringInsert As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        reader = Nothing

        MyStringInsert = String.Format("SELECT * FROM t_touch WHERE touch_number = '{0}'", Tbx_WorkerTouchNumber.Text)
        cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
        Try
            reader = cmd.ExecuteReader()
            If reader.Read() Then
                Return False
            Else
                If Not reader Is Nothing Then reader.Close()
                MyStringInsert = String.Format("INSERT INTO t_touch (Touch_Number, Touch_Valide, Touch_Use) VALUES ('{0}', '{1}', '{2}')", _
                 Trim(Tbx_WorkerTouchNumber.Text), 1, 0)

                cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
                cmd.ExecuteReader()
                If Not reader Is Nothing Then reader.Close()
                Return True
            End If
            'While (reader.Read())
            'databaseList.Items.Add(reader.GetString(0))
            'End While
        Catch ex As MySqlException
            Return False
            'MessageBox.Show("Failed to populate database list: " + ex.Message)
        End Try

    End Function
    Private Sub loaddataGrid()

        Try
            data = New DataTable

            da = New MySqlDataAdapter("SELECT * FROM t_touch", MyConn.conn)
            cb = New MySqlCommandBuilder(da)

            da.Fill(data)
            DataGV_Touch.DataSource = data

            DataGV_Touch.Columns(0).Visible = False
            DataGV_Touch.Columns(1).HeaderText = "Touch Number"
            DataGV_Touch.Columns(2).HeaderText = "Valid"
            DataGV_Touch.Columns(3).HeaderText = "Use"

        Catch ex As Exception
            'MsgBox("Worker list not available")
        End Try

    End Sub

    Private Sub datagvSelChg()
        Try
            Tbx_WorkerTouchNumber.Text = ""
            Chb_TouchValid.Checked = False
            Chb_Use.Checked = False

            Tbx_WorkerTouchNumber.Text = DataGV_Touch.SelectedRows(0).Cells(1).Value.ToString
            idKey = DataGV_Touch.SelectedRows(0).Cells(1).Value.ToString

            If DataGV_Touch.SelectedRows(0).Cells(2).Value.ToString = "0" Then
                Chb_TouchValid.Checked = False
            End If
            If DataGV_Touch.SelectedRows(0).Cells(2).Value.ToString = "1" Then
                Chb_TouchValid.Checked = True
            End If

            If DataGV_Touch.SelectedRows(0).Cells(3).Value.ToString = "0" Then
                Chb_Use.Checked = False
            End If
            If DataGV_Touch.SelectedRows(0).Cells(3).Value.ToString = "1" Then
                Chb_Use.Checked = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Quitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitter.Click
        Me.Close()
    End Sub
    Private Sub refrshValid()
        Btn_modifier.Visible = True
        Btn_supp.Visible = True
        Btn_Ajouter.Visible = True
        Chb_TouchValid.Visible = True
        Lb_TouchValid.Visible = True
        Chb_Use.Visible = True
        Lb_Use.Visible = True
        Chb_Use.Enabled = False
        Tbx_WorkerTouchNumber.Enabled = False

        Btn_Valider.Visible = False
        Btn_Annuler.Visible = False

        'Connect_WorkerTable()
        MyConn.Connect_BD()
        loaddataGrid()
        datagvSelChg()

    End Sub
    Private Sub Btn_Annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Annuler.Click
        refrshValid()
    End Sub

    Private Sub Btn_Valider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Valider.Click
        If Trim(Tbx_WorkerTouchNumber.Text) = "" Then
            MsgBox("Touch Number empty")
        Else
            If AddRecord() Then
                MessageBox.Show("Add done")
            Else
                MessageBox.Show("Add failed")
            End If
            refrshValid()
        End If
    End Sub
    Private Function delRecord() As Boolean
        Dim MyStringInsert As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        reader = Nothing

        Try
            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_lastin WHERE touch_number = '{0}'", Tbx_WorkerTouchNumber.Text)
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()
            If Not reader Is Nothing Then reader.Close()

            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_punchclock WHERE touch_number = '{0}'", Tbx_WorkerTouchNumber.Text)
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()
            If Not reader Is Nothing Then reader.Close()

            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_workertouch WHERE touch_number = '{0}'", Tbx_WorkerTouchNumber.Text)
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()
            If Not reader Is Nothing Then reader.Close()

            MyStringInsert = ""
            MyStringInsert = String.Format("DELETE FROM t_touch WHERE touch_number = '{0}'", Tbx_WorkerTouchNumber.Text)
            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            reader = cmd.ExecuteReader()

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


    Private Sub DataGV_Touch_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGV_Touch.SelectionChanged
        datagvSelChg()
    End Sub

    Private Sub Btn_Ajouter_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ajouter.Click

        Tbx_WorkerTouchNumber.Text = ""
        Chb_TouchValid.Checked = False

        Btn_modifier.Visible = False
        Btn_supp.Visible = False
        Btn_Ajouter.Visible = False
        Chb_TouchValid.Visible = False
        Lb_TouchValid.Visible = False
        Chb_Use.Visible = False
        Lb_Use.Visible = False

        Tbx_WorkerTouchNumber.Enabled = True
        Btn_Valider.Visible = True
        Btn_Annuler.Visible = True

    End Sub

End Class