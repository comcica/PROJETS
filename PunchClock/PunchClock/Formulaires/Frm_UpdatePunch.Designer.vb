<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UpdatePunch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_UpdatePunch))
        Me.Tb_DatePunch = New System.Windows.Forms.TextBox()
        Me.Tb_TimeStartPunch = New System.Windows.Forms.TextBox()
        Me.Tb_TimeStopPunch = New System.Windows.Forms.TextBox()
        Me.Lb_date = New System.Windows.Forms.Label()
        Me.Lb_formatDate = New System.Windows.Forms.Label()
        Me.Lb_TimeStart = New System.Windows.Forms.Label()
        Me.Lb_TimeStatFormat = New System.Windows.Forms.Label()
        Me.Lb_TimeStop = New System.Windows.Forms.Label()
        Me.Lb_TimeStopformat = New System.Windows.Forms.Label()
        Me.GB_Punch = New System.Windows.Forms.GroupBox()
        Me.Btn_Quitter = New System.Windows.Forms.Button()
        Me.Btn_Valider = New System.Windows.Forms.Button()
        Me.GB_Punch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tb_DatePunch
        '
        Me.Tb_DatePunch.Location = New System.Drawing.Point(178, 61)
        Me.Tb_DatePunch.Name = "Tb_DatePunch"
        Me.Tb_DatePunch.Size = New System.Drawing.Size(146, 20)
        Me.Tb_DatePunch.TabIndex = 0
        '
        'Tb_TimeStartPunch
        '
        Me.Tb_TimeStartPunch.Location = New System.Drawing.Point(178, 102)
        Me.Tb_TimeStartPunch.Name = "Tb_TimeStartPunch"
        Me.Tb_TimeStartPunch.Size = New System.Drawing.Size(148, 20)
        Me.Tb_TimeStartPunch.TabIndex = 1
        '
        'Tb_TimeStopPunch
        '
        Me.Tb_TimeStopPunch.Location = New System.Drawing.Point(181, 150)
        Me.Tb_TimeStopPunch.Name = "Tb_TimeStopPunch"
        Me.Tb_TimeStopPunch.Size = New System.Drawing.Size(143, 20)
        Me.Tb_TimeStopPunch.TabIndex = 2
        '
        'Lb_date
        '
        Me.Lb_date.AutoSize = True
        Me.Lb_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_date.Location = New System.Drawing.Point(72, 61)
        Me.Lb_date.Name = "Lb_date"
        Me.Lb_date.Size = New System.Drawing.Size(49, 16)
        Me.Lb_date.TabIndex = 3
        Me.Lb_date.Text = "Date :"
        '
        'Lb_formatDate
        '
        Me.Lb_formatDate.AutoSize = True
        Me.Lb_formatDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_formatDate.Location = New System.Drawing.Point(343, 61)
        Me.Lb_formatDate.Name = "Lb_formatDate"
        Me.Lb_formatDate.Size = New System.Drawing.Size(77, 16)
        Me.Lb_formatDate.TabIndex = 4
        Me.Lb_formatDate.Text = "aaa/mm/jj"
        '
        'Lb_TimeStart
        '
        Me.Lb_TimeStart.AutoSize = True
        Me.Lb_TimeStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TimeStart.Location = New System.Drawing.Point(72, 106)
        Me.Lb_TimeStart.Name = "Lb_TimeStart"
        Me.Lb_TimeStart.Size = New System.Drawing.Size(87, 16)
        Me.Lb_TimeStart.TabIndex = 5
        Me.Lb_TimeStart.Text = "Time Start :"
        '
        'Lb_TimeStatFormat
        '
        Me.Lb_TimeStatFormat.AutoSize = True
        Me.Lb_TimeStatFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TimeStatFormat.Location = New System.Drawing.Point(343, 103)
        Me.Lb_TimeStatFormat.Name = "Lb_TimeStatFormat"
        Me.Lb_TimeStatFormat.Size = New System.Drawing.Size(72, 16)
        Me.Lb_TimeStatFormat.TabIndex = 6
        Me.Lb_TimeStatFormat.Text = "hh:mm:ss"
        '
        'Lb_TimeStop
        '
        Me.Lb_TimeStop.AutoSize = True
        Me.Lb_TimeStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TimeStop.Location = New System.Drawing.Point(72, 151)
        Me.Lb_TimeStop.Name = "Lb_TimeStop"
        Me.Lb_TimeStop.Size = New System.Drawing.Size(91, 16)
        Me.Lb_TimeStop.TabIndex = 7
        Me.Lb_TimeStop.Text = "Time Stop  :"
        '
        'Lb_TimeStopformat
        '
        Me.Lb_TimeStopformat.AutoSize = True
        Me.Lb_TimeStopformat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TimeStopformat.Location = New System.Drawing.Point(343, 151)
        Me.Lb_TimeStopformat.Name = "Lb_TimeStopformat"
        Me.Lb_TimeStopformat.Size = New System.Drawing.Size(72, 16)
        Me.Lb_TimeStopformat.TabIndex = 8
        Me.Lb_TimeStopformat.Text = "hh:mm:ss"
        '
        'GB_Punch
        '
        Me.GB_Punch.Controls.Add(Me.Lb_TimeStopformat)
        Me.GB_Punch.Controls.Add(Me.Lb_TimeStop)
        Me.GB_Punch.Controls.Add(Me.Lb_TimeStatFormat)
        Me.GB_Punch.Controls.Add(Me.Lb_TimeStart)
        Me.GB_Punch.Controls.Add(Me.Lb_formatDate)
        Me.GB_Punch.Controls.Add(Me.Lb_date)
        Me.GB_Punch.Controls.Add(Me.Tb_TimeStopPunch)
        Me.GB_Punch.Controls.Add(Me.Tb_TimeStartPunch)
        Me.GB_Punch.Controls.Add(Me.Tb_DatePunch)
        Me.GB_Punch.Location = New System.Drawing.Point(22, 27)
        Me.GB_Punch.Name = "GB_Punch"
        Me.GB_Punch.Size = New System.Drawing.Size(635, 271)
        Me.GB_Punch.TabIndex = 9
        Me.GB_Punch.TabStop = False
        Me.GB_Punch.Text = "Infos PunchClock to Update"
        '
        'Btn_Quitter
        '
        Me.Btn_Quitter.Location = New System.Drawing.Point(608, 321)
        Me.Btn_Quitter.Name = "Btn_Quitter"
        Me.Btn_Quitter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Quitter.TabIndex = 46
        Me.Btn_Quitter.Text = "Quitter"
        Me.Btn_Quitter.UseVisualStyleBackColor = True
        '
        'Btn_Valider
        '
        Me.Btn_Valider.Location = New System.Drawing.Point(42, 317)
        Me.Btn_Valider.Name = "Btn_Valider"
        Me.Btn_Valider.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Valider.TabIndex = 47
        Me.Btn_Valider.Text = "Mettre à Jour"
        Me.Btn_Valider.UseVisualStyleBackColor = True
        '
        'Frm_UpdatePunch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 361)
        Me.Controls.Add(Me.Btn_Valider)
        Me.Controls.Add(Me.Btn_Quitter)
        Me.Controls.Add(Me.GB_Punch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UpdatePunch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PunchClock Update"
        Me.GB_Punch.ResumeLayout(False)
        Me.GB_Punch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tb_DatePunch As System.Windows.Forms.TextBox
    Friend WithEvents Tb_TimeStartPunch As System.Windows.Forms.TextBox
    Friend WithEvents Tb_TimeStopPunch As System.Windows.Forms.TextBox
    Friend WithEvents Lb_date As System.Windows.Forms.Label
    Friend WithEvents Lb_formatDate As System.Windows.Forms.Label
    Friend WithEvents Lb_TimeStart As System.Windows.Forms.Label
    Friend WithEvents Lb_TimeStatFormat As System.Windows.Forms.Label
    Friend WithEvents Lb_TimeStop As System.Windows.Forms.Label
    Friend WithEvents Lb_TimeStopformat As System.Windows.Forms.Label
    Friend WithEvents GB_Punch As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Quitter As System.Windows.Forms.Button
    Friend WithEvents Btn_Valider As System.Windows.Forms.Button
End Class
