
Public Class Frm_MenuP

    Private Sub Frm_MenuP_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result = MessageBox.Show("Voulez vouez quitter l'application ?", "Fermeture de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
        If result = MsgBoxResult.Ok Then
            'If Not lcsqlserver Is Nothing Then
            '    lcsqlserver.disconnect()
            'End If
            End
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub Frm_MenuP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " ( Version : " & Application.ProductVersion & " )"
        'Me.Btn_Personnel.BackColor = 
        MyConn.Connect_BD()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Personnel.Click
        Call Frm_Worker.Show()
    End Sub

    Private Sub Btn_Clef_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Clef.Click
        Call Frm_Touch.Show()
    End Sub


    Private Sub EditerRapportDesPunchsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditerRapportDesPunchsToolStripMenuItem.Click
        Call Frm_Rapports.Show()
    End Sub


    Private Sub VisualiserPunchsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VisualiserPunchsToolStripMenuItem.Click
        Call Frm_DisplayPunch.Show()
    End Sub

    Private Sub Btn_exit_Click(sender As System.Object, e As System.EventArgs) Handles Btn_exit.Click
        Me.Close()
    End Sub

    Private Sub Btn_Rapport_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Rapport.Click
        Btn_Rapport.ContextMenuStrip.Show(Me.Location.X + 416, Me.Location.Y + 400)
    End Sub
End Class
