<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DisplayPunch
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
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Cb_worker = New System.Windows.Forms.ComboBox()
        Me.DTFin = New System.Windows.Forms.DateTimePicker()
        Me.Lb_Au = New System.Windows.Forms.Label()
        Me.DTDebut = New System.Windows.Forms.DateTimePicker()
        Me.Lb_PeriodeD = New System.Windows.Forms.Label()
        Me.Lb_Worker = New System.Windows.Forms.Label()
        Me.DataGridV_Punch = New System.Windows.Forms.DataGridView()
        Me.Btn_Quitter = New System.Windows.Forms.Button()
        CType(Me.DataGridV_Punch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Search
        '
        Me.Btn_Search.Location = New System.Drawing.Point(709, 33)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(90, 34)
        Me.Btn_Search.TabIndex = 65
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Cb_worker
        '
        Me.Cb_worker.FormattingEnabled = True
        Me.Cb_worker.Location = New System.Drawing.Point(15, 40)
        Me.Cb_worker.Name = "Cb_worker"
        Me.Cb_worker.Size = New System.Drawing.Size(249, 21)
        Me.Cb_worker.TabIndex = 64
        '
        'DTFin
        '
        Me.DTFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFin.Location = New System.Drawing.Point(562, 38)
        Me.DTFin.Name = "DTFin"
        Me.DTFin.Size = New System.Drawing.Size(130, 20)
        Me.DTFin.TabIndex = 63
        '
        'Lb_Au
        '
        Me.Lb_Au.AutoSize = True
        Me.Lb_Au.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Au.Location = New System.Drawing.Point(530, 42)
        Me.Lb_Au.Name = "Lb_Au"
        Me.Lb_Au.Size = New System.Drawing.Size(26, 16)
        Me.Lb_Au.TabIndex = 62
        Me.Lb_Au.Text = "Au"
        '
        'DTDebut
        '
        Me.DTDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDebut.Location = New System.Drawing.Point(394, 37)
        Me.DTDebut.Name = "DTDebut"
        Me.DTDebut.Size = New System.Drawing.Size(130, 20)
        Me.DTDebut.TabIndex = 61
        '
        'Lb_PeriodeD
        '
        Me.Lb_PeriodeD.AutoSize = True
        Me.Lb_PeriodeD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_PeriodeD.Location = New System.Drawing.Point(292, 42)
        Me.Lb_PeriodeD.Name = "Lb_PeriodeD"
        Me.Lb_PeriodeD.Size = New System.Drawing.Size(96, 16)
        Me.Lb_PeriodeD.TabIndex = 60
        Me.Lb_PeriodeD.Text = "Période du : "
        '
        'Lb_Worker
        '
        Me.Lb_Worker.AutoSize = True
        Me.Lb_Worker.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Worker.Location = New System.Drawing.Point(-246, 39)
        Me.Lb_Worker.Name = "Lb_Worker"
        Me.Lb_Worker.Size = New System.Drawing.Size(66, 16)
        Me.Lb_Worker.TabIndex = 59
        Me.Lb_Worker.Text = "Worker :"
        '
        'DataGridV_Punch
        '
        Me.DataGridV_Punch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridV_Punch.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridV_Punch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridV_Punch.Location = New System.Drawing.Point(15, 73)
        Me.DataGridV_Punch.Name = "DataGridV_Punch"
        Me.DataGridV_Punch.ReadOnly = True
        Me.DataGridV_Punch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridV_Punch.Size = New System.Drawing.Size(784, 317)
        Me.DataGridV_Punch.TabIndex = 66
        '
        'Btn_Quitter
        '
        Me.Btn_Quitter.Location = New System.Drawing.Point(714, 409)
        Me.Btn_Quitter.Name = "Btn_Quitter"
        Me.Btn_Quitter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Quitter.TabIndex = 67
        Me.Btn_Quitter.Text = "Quitter"
        Me.Btn_Quitter.UseVisualStyleBackColor = True
        '
        'Frm_DisplayPunch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 453)
        Me.Controls.Add(Me.Btn_Quitter)
        Me.Controls.Add(Me.DataGridV_Punch)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.Cb_worker)
        Me.Controls.Add(Me.DTFin)
        Me.Controls.Add(Me.Lb_Au)
        Me.Controls.Add(Me.DTDebut)
        Me.Controls.Add(Me.Lb_PeriodeD)
        Me.Controls.Add(Me.Lb_Worker)
        Me.Name = "Frm_DisplayPunch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frm_DisplayPunch"
        CType(Me.DataGridV_Punch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Search As System.Windows.Forms.Button
    Friend WithEvents Cb_worker As System.Windows.Forms.ComboBox
    Friend WithEvents DTFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_Au As System.Windows.Forms.Label
    Friend WithEvents DTDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb_PeriodeD As System.Windows.Forms.Label
    Friend WithEvents Lb_Worker As System.Windows.Forms.Label
    Friend WithEvents DataGridV_Punch As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Quitter As System.Windows.Forms.Button
End Class
