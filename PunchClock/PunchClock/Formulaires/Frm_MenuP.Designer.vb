<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuP))
        Me.Btn_Personnel = New System.Windows.Forms.Button()
        Me.Btn_Clef = New System.Windows.Forms.Button()
        Me.Btn_exit = New System.Windows.Forms.Button()
        Me.Btn_Rapport = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VisualiserPunchsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditerRapportDesPunchsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Personnel
        '
        Me.Btn_Personnel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Personnel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Personnel.Image = Global.PunchClock.My.Resources.Resources.pers
        Me.Btn_Personnel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_Personnel.Location = New System.Drawing.Point(282, 52)
        Me.Btn_Personnel.Name = "Btn_Personnel"
        Me.Btn_Personnel.Size = New System.Drawing.Size(315, 104)
        Me.Btn_Personnel.TabIndex = 0
        Me.Btn_Personnel.Text = "Personnel"
        Me.Btn_Personnel.UseVisualStyleBackColor = True
        '
        'Btn_Clef
        '
        Me.Btn_Clef.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Clef.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Clef.Image = Global.PunchClock.My.Resources.Resources.clef1
        Me.Btn_Clef.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_Clef.Location = New System.Drawing.Point(282, 182)
        Me.Btn_Clef.Name = "Btn_Clef"
        Me.Btn_Clef.Size = New System.Drawing.Size(315, 104)
        Me.Btn_Clef.TabIndex = 1
        Me.Btn_Clef.Text = "Clés  D'accès"
        Me.Btn_Clef.UseVisualStyleBackColor = True
        '
        'Btn_exit
        '
        Me.Btn_exit.AutoEllipsis = True
        Me.Btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_exit.Image = Global.PunchClock.My.Resources.Resources.exit11
        Me.Btn_exit.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_exit.Location = New System.Drawing.Point(737, 400)
        Me.Btn_exit.Name = "Btn_exit"
        Me.Btn_exit.Size = New System.Drawing.Size(129, 52)
        Me.Btn_exit.TabIndex = 2
        Me.Btn_exit.UseVisualStyleBackColor = True
        '
        'Btn_Rapport
        '
        Me.Btn_Rapport.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Btn_Rapport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Rapport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Rapport.Image = Global.PunchClock.My.Resources.Resources.Rapport
        Me.Btn_Rapport.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_Rapport.Location = New System.Drawing.Point(282, 316)
        Me.Btn_Rapport.Name = "Btn_Rapport"
        Me.Btn_Rapport.Size = New System.Drawing.Size(315, 104)
        Me.Btn_Rapport.TabIndex = 3
        Me.Btn_Rapport.Text = "Rapports"
        Me.Btn_Rapport.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisualiserPunchsToolStripMenuItem, Me.EditerRapportDesPunchsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(213, 48)
        '
        'VisualiserPunchsToolStripMenuItem
        '
        Me.VisualiserPunchsToolStripMenuItem.Name = "VisualiserPunchsToolStripMenuItem"
        Me.VisualiserPunchsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.VisualiserPunchsToolStripMenuItem.Text = "Visualiser Punchs"
        '
        'EditerRapportDesPunchsToolStripMenuItem
        '
        Me.EditerRapportDesPunchsToolStripMenuItem.Name = "EditerRapportDesPunchsToolStripMenuItem"
        Me.EditerRapportDesPunchsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EditerRapportDesPunchsToolStripMenuItem.Text = "Editer Rapport des Punchs"
        '
        'Frm_MenuP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.PunchClock.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(909, 476)
        Me.Controls.Add(Me.Btn_exit)
        Me.Controls.Add(Me.Btn_Clef)
        Me.Controls.Add(Me.Btn_Personnel)
        Me.Controls.Add(Me.Btn_Rapport)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MenuP"
        Me.Text = "Administration Punch Clock"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Personnel As System.Windows.Forms.Button
    Friend WithEvents Btn_Clef As System.Windows.Forms.Button
    Friend WithEvents Btn_exit As System.Windows.Forms.Button
    Friend WithEvents Btn_Rapport As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VisualiserPunchsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditerRapportDesPunchsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
