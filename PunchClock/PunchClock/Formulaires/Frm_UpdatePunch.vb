Imports MySql.Data.MySqlClient

Public Class Frm_UpdatePunch

    Private Sub Frm_UpdatePunch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text &= "  ---> " & Trim(Frm_Rapports.Cb_worker.Text) & " Touch : " & Frm_Rapports.lpunchclock.Touch_Number
    End Sub

    Private Sub Btn_Quitter_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Quitter.Click
        Me.Close()
    End Sub

    Private Sub Tb_DatePunch_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_DatePunch.TextChanged
        Frm_Rapports.lpunchclock.PDate = Trim(Tb_DatePunch.Text)
    End Sub

    Private Sub Tb_TimeStartPunch_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_TimeStartPunch.TextChanged
        Frm_Rapports.lpunchclock.Time_Start = Trim(Tb_TimeStartPunch.Text)
    End Sub

    Private Sub Tb_TimeStopPunch_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_TimeStopPunch.TextChanged
        Frm_Rapports.lpunchclock.Time_Stop = Trim(Tb_TimeStopPunch.Text)
    End Sub
    Private Function UpdateRecord() As Boolean
        Dim MyStringInsert As String = ""
        Dim cmd As MySqlCommand

        Try
            MyStringInsert = String.Format("UPDATE t_punchclock SET Date = '{0}', Time_Start = '{1}', Time_Stop = '{2}' WHERE idT_PUNCHCLOCK = '{3}'", _
                    Trim(Tb_DatePunch.Text), Trim(Tb_TimeStartPunch.Text), Trim(Tb_TimeStopPunch.Text), Trim(Frm_DisplayPunch.lpunchclock.idT_PUNCHCLOCK))

            cmd = New MySqlCommand(MyStringInsert, MyConn.conn)
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As MySqlException
            Return False
        End Try

    End Function

    Private Sub Btn_Valider_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Valider.Click
        If MsgBox("Do you want to update this record ?", vbYesNo) = Windows.Forms.DialogResult.Yes Then
            If UpdateRecord() Then
                MessageBox.Show("Update done")
            Else
                MessageBox.Show("Update failed")
            End If
            Me.Close()
            Frm_DisplayPunch.searchPunch()

        End If

    End Sub
End Class