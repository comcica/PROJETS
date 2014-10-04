<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MajCpta
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Tb_NumPieceFin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tb_NumPieceDeb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTDateF = New System.Windows.Forms.DateTimePicker()
        Me.Cb_CodeJ = New UTCombo.MultiColCombo(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTDateD = New System.Windows.Forms.DateTimePicker()
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_NumPieceFin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Tb_NumPieceDeb)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTDateF)
        Me.GroupBox1.Controls.Add(Me.Cb_CodeJ)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTDateD)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 187)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Critères de sélection"
        '
        'Tb_NumPieceFin
        '
        Me.Tb_NumPieceFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tb_NumPieceFin.Location = New System.Drawing.Point(381, 85)
        Me.Tb_NumPieceFin.Name = "Tb_NumPieceFin"
        Me.Tb_NumPieceFin.Size = New System.Drawing.Size(139, 22)
        Me.Tb_NumPieceFin.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(318, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Au"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "N°  de Pièce  du "
        '
        'Tb_NumPieceDeb
        '
        Me.Tb_NumPieceDeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tb_NumPieceDeb.Location = New System.Drawing.Point(146, 85)
        Me.Tb_NumPieceDeb.Name = "Tb_NumPieceDeb"
        Me.Tb_NumPieceDeb.Size = New System.Drawing.Size(146, 22)
        Me.Tb_NumPieceDeb.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(318, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Au"
        '
        'DTDateF
        '
        Me.DTDateF.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDateF.Location = New System.Drawing.Point(381, 137)
        Me.DTDateF.Name = "DTDateF"
        Me.DTDateF.Size = New System.Drawing.Size(139, 22)
        Me.DTDateF.TabIndex = 19
        '
        'Cb_CodeJ
        '
        Me.Cb_CodeJ.FormattingEnabled = True
        Me.Cb_CodeJ.Location = New System.Drawing.Point(119, 36)
        Me.Cb_CodeJ.Name = "Cb_CodeJ"
        Me.Cb_CodeJ.Size = New System.Drawing.Size(173, 24)
        Me.Cb_CodeJ.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(11, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Date Écritures   du"
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
        'DTDateD
        '
        Me.DTDateD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDateD.Location = New System.Drawing.Point(146, 137)
        Me.DTDateD.Name = "DTDateD"
        Me.DTDateD.Size = New System.Drawing.Size(146, 22)
        Me.DTDateD.TabIndex = 13
        '
        'Btn_Export
        '
        Me.Btn_Export.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Export.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Btn_Export.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Export.Location = New System.Drawing.Point(224, 218)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(119, 46)
        Me.Btn_Export.TabIndex = 22
        Me.Btn_Export.Text = " Export"
        Me.Btn_Export.UseCompatibleTextRendering = True
        Me.Btn_Export.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(17, 218)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 46)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Voir Format"
        Me.Button2.UseCompatibleTextRendering = True
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Exit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Exit.Image = Global.CTreso.My.Resources.Resources._exit
        Me.Btn_Exit.Location = New System.Drawing.Point(432, 218)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(119, 46)
        Me.Btn_Exit.TabIndex = 23
        Me.Btn_Exit.UseCompatibleTextRendering = True
        Me.Btn_Exit.UseVisualStyleBackColor = False
        '
        'Frm_MajCpta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 285)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Btn_Exit)
        Me.Controls.Add(Me.Btn_Export)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MajCpta"
        Me.Text = "Mise à Jour Comptable"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTDateF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cb_CodeJ As UTCombo.MultiColCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTDateD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_Exit As System.Windows.Forms.Button
    Friend WithEvents Btn_Export As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb_NumPieceDeb As System.Windows.Forms.TextBox
    Friend WithEvents Tb_NumPieceFin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
