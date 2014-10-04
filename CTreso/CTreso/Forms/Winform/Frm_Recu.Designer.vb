<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Recu
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
        Me.DTDateD = New System.Windows.Forms.DateTimePicker()
        Me.Tb_NumPiece = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTDateF = New System.Windows.Forms.DateTimePicker()
        Me.Cb_CodeJ = New UTCombo.MultiColCombo(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_Print = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DTDateD
        '
        Me.DTDateD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDateD.Location = New System.Drawing.Point(101, 103)
        Me.DTDateD.Name = "DTDateD"
        Me.DTDateD.Size = New System.Drawing.Size(146, 22)
        Me.DTDateD.TabIndex = 13
        Me.DTDateD.Visible = False
        '
        'Tb_NumPiece
        '
        Me.Tb_NumPiece.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tb_NumPiece.Location = New System.Drawing.Point(381, 36)
        Me.Tb_NumPiece.Name = "Tb_NumPiece"
        Me.Tb_NumPiece.Size = New System.Drawing.Size(139, 22)
        Me.Tb_NumPiece.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Date   du"
        Me.Label7.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(280, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "N°  de Pièce"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Code Journal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTDateF)
        Me.GroupBox1.Controls.Add(Me.Cb_CodeJ)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Tb_NumPiece)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTDateD)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 187)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Critères de sélection"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(292, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Au"
        Me.Label2.Visible = False
        '
        'DTDateF
        '
        Me.DTDateF.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDateF.Location = New System.Drawing.Point(381, 103)
        Me.DTDateF.Name = "DTDateF"
        Me.DTDateF.Size = New System.Drawing.Size(139, 22)
        Me.DTDateF.TabIndex = 19
        Me.DTDateF.Visible = False
        '
        'Cb_CodeJ
        '
        Me.Cb_CodeJ.FormattingEnabled = True
        Me.Cb_CodeJ.Location = New System.Drawing.Point(101, 34)
        Me.Cb_CodeJ.Name = "Cb_CodeJ"
        Me.Cb_CodeJ.Size = New System.Drawing.Size(173, 24)
        Me.Cb_CodeJ.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = Global.CTreso.My.Resources.Resources._exit
        Me.Button1.Location = New System.Drawing.Point(441, 234)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 46)
        Me.Button1.TabIndex = 11
        Me.Button1.UseCompatibleTextRendering = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Btn_Print
        '
        Me.Btn_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Print.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Btn_Print.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Print.Image = Global.CTreso.My.Resources.Resources.Print
        Me.Btn_Print.Location = New System.Drawing.Point(233, 234)
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(119, 46)
        Me.Btn_Print.TabIndex = 10
        Me.Btn_Print.UseCompatibleTextRendering = True
        Me.Btn_Print.UseVisualStyleBackColor = False
        '
        'Frm_Recu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 292)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btn_Print)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Recu"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "IMPRIMER"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Print As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DTDateD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tb_NumPiece As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cb_CodeJ As UTCombo.MultiColCombo
    Friend WithEvents DTDateF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
