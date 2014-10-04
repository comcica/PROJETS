<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rapports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rapports))
        Me.Lb_Worker = New System.Windows.Forms.Label()
        Me.Lb_PeriodeD = New System.Windows.Forms.Label()
        Me.Btn_Quitter = New System.Windows.Forms.Button()
        Me.Lb_Au = New System.Windows.Forms.Label()
        Me.DTDebut = New System.Windows.Forms.DateTimePicker()
        Me.DTFin = New System.Windows.Forms.DateTimePicker()
        Me.Cb_worker = New System.Windows.Forms.ComboBox()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridV_PunchErreur = New System.Windows.Forms.DataGridView()
        Me.Lb_TotalGlobal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ChB_Tous = New System.Windows.Forms.CheckBox()
        Me.Btn_ExWs = New System.Windows.Forms.Button()
        CType(Me.DataGridV_PunchErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lb_Worker
        '
        Me.Lb_Worker.AutoSize = True
        Me.Lb_Worker.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Worker.Location = New System.Drawing.Point(31, 48)
        Me.Lb_Worker.Name = "Lb_Worker"
        Me.Lb_Worker.Size = New System.Drawing.Size(66, 16)
        Me.Lb_Worker.TabIndex = 1
        Me.Lb_Worker.Text = "Worker :"
        '
        'Lb_PeriodeD
        '
        Me.Lb_PeriodeD.AutoSize = True
        Me.Lb_PeriodeD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_PeriodeD.Location = New System.Drawing.Point(380, 50)
        Me.Lb_PeriodeD.Name = "Lb_PeriodeD"
        Me.Lb_PeriodeD.Size = New System.Drawing.Size(96, 16)
        Me.Lb_PeriodeD.TabIndex = 2
        Me.Lb_PeriodeD.Text = "Période du : "
        '
        'Btn_Quitter
        '
        Me.Btn_Quitter.Location = New System.Drawing.Point(1063, 444)
        Me.Btn_Quitter.Name = "Btn_Quitter"
        Me.Btn_Quitter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Quitter.TabIndex = 46
        Me.Btn_Quitter.Text = "Quitter"
        Me.Btn_Quitter.UseVisualStyleBackColor = True
        '
        'Lb_Au
        '
        Me.Lb_Au.AutoSize = True
        Me.Lb_Au.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Au.Location = New System.Drawing.Point(618, 50)
        Me.Lb_Au.Name = "Lb_Au"
        Me.Lb_Au.Size = New System.Drawing.Size(26, 16)
        Me.Lb_Au.TabIndex = 47
        Me.Lb_Au.Text = "Au"
        '
        'DTDebut
        '
        Me.DTDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDebut.Location = New System.Drawing.Point(482, 45)
        Me.DTDebut.Name = "DTDebut"
        Me.DTDebut.Size = New System.Drawing.Size(130, 20)
        Me.DTDebut.TabIndex = 6
        '
        'DTFin
        '
        Me.DTFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFin.Location = New System.Drawing.Point(650, 46)
        Me.DTFin.Name = "DTFin"
        Me.DTFin.Size = New System.Drawing.Size(130, 20)
        Me.DTFin.TabIndex = 48
        '
        'Cb_worker
        '
        Me.Cb_worker.FormattingEnabled = True
        Me.Cb_worker.Location = New System.Drawing.Point(103, 48)
        Me.Cb_worker.Name = "Cb_worker"
        Me.Cb_worker.Size = New System.Drawing.Size(249, 21)
        Me.Cb_worker.TabIndex = 49
        '
        'Btn_Search
        '
        Me.Btn_Search.Location = New System.Drawing.Point(895, 37)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(161, 34)
        Me.Btn_Search.TabIndex = 51
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(22, 452)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 16)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Total Période (HH:MM:SS) :"
        '
        'DataGridV_PunchErreur
        '
        Me.DataGridV_PunchErreur.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridV_PunchErreur.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridV_PunchErreur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridV_PunchErreur.Location = New System.Drawing.Point(621, 110)
        Me.DataGridV_PunchErreur.Name = "DataGridV_PunchErreur"
        Me.DataGridV_PunchErreur.ReadOnly = True
        Me.DataGridV_PunchErreur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridV_PunchErreur.Size = New System.Drawing.Size(527, 317)
        Me.DataGridV_PunchErreur.TabIndex = 53
        '
        'Lb_TotalGlobal
        '
        Me.Lb_TotalGlobal.AutoSize = True
        Me.Lb_TotalGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TotalGlobal.ForeColor = System.Drawing.Color.Red
        Me.Lb_TotalGlobal.Location = New System.Drawing.Point(227, 452)
        Me.Lb_TotalGlobal.Name = "Lb_TotalGlobal"
        Me.Lb_TotalGlobal.Size = New System.Drawing.Size(12, 16)
        Me.Lb_TotalGlobal.TabIndex = 54
        Me.Lb_TotalGlobal.Text = " "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(22, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Punchs Corrects de la période"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(618, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(227, 16)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Punchs Incorrects de la période"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 110)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(586, 317)
        Me.RichTextBox1.TabIndex = 57
        Me.RichTextBox1.Text = ""
        '
        'ChB_Tous
        '
        Me.ChB_Tous.AutoSize = True
        Me.ChB_Tous.Location = New System.Drawing.Point(801, 47)
        Me.ChB_Tous.Name = "ChB_Tous"
        Me.ChB_Tous.Size = New System.Drawing.Size(50, 17)
        Me.ChB_Tous.TabIndex = 58
        Me.ChB_Tous.Text = "Tous"
        Me.ChB_Tous.UseVisualStyleBackColor = True
        '
        'Btn_ExWs
        '
        Me.Btn_ExWs.Location = New System.Drawing.Point(495, 444)
        Me.Btn_ExWs.Name = "Btn_ExWs"
        Me.Btn_ExWs.Size = New System.Drawing.Size(103, 32)
        Me.Btn_ExWs.TabIndex = 60
        Me.Btn_ExWs.Text = "export worksheet"
        Me.Btn_ExWs.UseVisualStyleBackColor = True
        '
        'Frm_Rapports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 510)
        Me.Controls.Add(Me.Btn_ExWs)
        Me.Controls.Add(Me.ChB_Tous)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Lb_TotalGlobal)
        Me.Controls.Add(Me.DataGridV_PunchErreur)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.Cb_worker)
        Me.Controls.Add(Me.DTFin)
        Me.Controls.Add(Me.Lb_Au)
        Me.Controls.Add(Me.Btn_Quitter)
        Me.Controls.Add(Me.DTDebut)
        Me.Controls.Add(Me.Lb_PeriodeD)
        Me.Controls.Add(Me.Lb_Worker)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rapports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rapports WorkSheet"
        CType(Me.DataGridV_PunchErreur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_Worker As System.Windows.Forms.Label
    Friend WithEvents Lb_PeriodeD As System.Windows.Forms.Label
    Friend WithEvents Btn_Quitter As System.Windows.Forms.Button
    Friend WithEvents Lb_Au As System.Windows.Forms.Label
    Friend WithEvents DTDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cb_worker As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Search As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridV_PunchErreur As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_TotalGlobal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ChB_Tous As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_ExWs As System.Windows.Forms.Button
End Class
