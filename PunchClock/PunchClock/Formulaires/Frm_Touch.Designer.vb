<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Touch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Touch))
        Me.Btn_Annuler = New System.Windows.Forms.Button()
        Me.Btn_Valider = New System.Windows.Forms.Button()
        Me.Btn_Quitter = New System.Windows.Forms.Button()
        Me.Btn_supp = New System.Windows.Forms.Button()
        Me.Btn_modifier = New System.Windows.Forms.Button()
        Me.Btn_Ajouter = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGV_Touch = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lb_Use = New System.Windows.Forms.Label()
        Me.Chb_Use = New System.Windows.Forms.CheckBox()
        Me.Chb_TouchValid = New System.Windows.Forms.CheckBox()
        Me.Lb_TouchValid = New System.Windows.Forms.Label()
        Me.Lb_TouchNumber = New System.Windows.Forms.Label()
        Me.Tbx_WorkerTouchNumber = New System.Windows.Forms.TextBox()
        Me.Lb_ = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGV_Touch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Annuler
        '
        Me.Btn_Annuler.Location = New System.Drawing.Point(104, 326)
        Me.Btn_Annuler.Name = "Btn_Annuler"
        Me.Btn_Annuler.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Annuler.TabIndex = 47
        Me.Btn_Annuler.Text = "Annuler"
        Me.Btn_Annuler.UseVisualStyleBackColor = True
        Me.Btn_Annuler.Visible = False
        '
        'Btn_Valider
        '
        Me.Btn_Valider.Location = New System.Drawing.Point(13, 326)
        Me.Btn_Valider.Name = "Btn_Valider"
        Me.Btn_Valider.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Valider.TabIndex = 46
        Me.Btn_Valider.Text = "Ok"
        Me.Btn_Valider.UseVisualStyleBackColor = True
        Me.Btn_Valider.Visible = False
        '
        'Btn_Quitter
        '
        Me.Btn_Quitter.Location = New System.Drawing.Point(516, 340)
        Me.Btn_Quitter.Name = "Btn_Quitter"
        Me.Btn_Quitter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Quitter.TabIndex = 45
        Me.Btn_Quitter.Text = "Quitter"
        Me.Btn_Quitter.UseVisualStyleBackColor = True
        '
        'Btn_supp
        '
        Me.Btn_supp.Location = New System.Drawing.Point(195, 326)
        Me.Btn_supp.Name = "Btn_supp"
        Me.Btn_supp.Size = New System.Drawing.Size(85, 32)
        Me.Btn_supp.TabIndex = 44
        Me.Btn_supp.Text = "Supprimer"
        Me.Btn_supp.UseVisualStyleBackColor = True
        '
        'Btn_modifier
        '
        Me.Btn_modifier.Location = New System.Drawing.Point(104, 326)
        Me.Btn_modifier.Name = "Btn_modifier"
        Me.Btn_modifier.Size = New System.Drawing.Size(85, 32)
        Me.Btn_modifier.TabIndex = 43
        Me.Btn_modifier.Text = "Modifier"
        Me.Btn_modifier.UseVisualStyleBackColor = True
        '
        'Btn_Ajouter
        '
        Me.Btn_Ajouter.Location = New System.Drawing.Point(13, 326)
        Me.Btn_Ajouter.Name = "Btn_Ajouter"
        Me.Btn_Ajouter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Ajouter.TabIndex = 42
        Me.Btn_Ajouter.Text = "Ajouter"
        Me.Btn_Ajouter.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGV_Touch)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(580, 207)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Touch Number List"
        '
        'DataGV_Touch
        '
        Me.DataGV_Touch.AllowUserToOrderColumns = True
        Me.DataGV_Touch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGV_Touch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_Touch.Location = New System.Drawing.Point(6, 27)
        Me.DataGV_Touch.MultiSelect = False
        Me.DataGV_Touch.Name = "DataGV_Touch"
        Me.DataGV_Touch.ReadOnly = True
        Me.DataGV_Touch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGV_Touch.Size = New System.Drawing.Size(547, 164)
        Me.DataGV_Touch.TabIndex = 42
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lb_Use)
        Me.GroupBox1.Controls.Add(Me.Chb_Use)
        Me.GroupBox1.Controls.Add(Me.Chb_TouchValid)
        Me.GroupBox1.Controls.Add(Me.Lb_TouchValid)
        Me.GroupBox1.Controls.Add(Me.Lb_TouchNumber)
        Me.GroupBox1.Controls.Add(Me.Tbx_WorkerTouchNumber)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 225)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 75)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Touch Number  Record"
        '
        'Lb_Use
        '
        Me.Lb_Use.AutoSize = True
        Me.Lb_Use.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Use.Location = New System.Drawing.Point(441, 31)
        Me.Lb_Use.Name = "Lb_Use"
        Me.Lb_Use.Size = New System.Drawing.Size(44, 16)
        Me.Lb_Use.TabIndex = 41
        Me.Lb_Use.Text = "Use :"
        '
        'Chb_Use
        '
        Me.Chb_Use.AutoSize = True
        Me.Chb_Use.Location = New System.Drawing.Point(504, 33)
        Me.Chb_Use.Name = "Chb_Use"
        Me.Chb_Use.Size = New System.Drawing.Size(15, 14)
        Me.Chb_Use.TabIndex = 40
        Me.Chb_Use.UseVisualStyleBackColor = True
        '
        'Chb_TouchValid
        '
        Me.Chb_TouchValid.AutoSize = True
        Me.Chb_TouchValid.Location = New System.Drawing.Point(395, 30)
        Me.Chb_TouchValid.Name = "Chb_TouchValid"
        Me.Chb_TouchValid.Size = New System.Drawing.Size(15, 14)
        Me.Chb_TouchValid.TabIndex = 39
        Me.Chb_TouchValid.UseVisualStyleBackColor = True
        '
        'Lb_TouchValid
        '
        Me.Lb_TouchValid.AutoSize = True
        Me.Lb_TouchValid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TouchValid.Location = New System.Drawing.Point(337, 31)
        Me.Lb_TouchValid.Name = "Lb_TouchValid"
        Me.Lb_TouchValid.Size = New System.Drawing.Size(52, 16)
        Me.Lb_TouchValid.TabIndex = 38
        Me.Lb_TouchValid.Text = "Valid :"
        '
        'Lb_TouchNumber
        '
        Me.Lb_TouchNumber.AutoSize = True
        Me.Lb_TouchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TouchNumber.Location = New System.Drawing.Point(4, 24)
        Me.Lb_TouchNumber.Name = "Lb_TouchNumber"
        Me.Lb_TouchNumber.Size = New System.Drawing.Size(121, 16)
        Me.Lb_TouchNumber.TabIndex = 31
        Me.Lb_TouchNumber.Text = "Touch Number  :"
        '
        'Tbx_WorkerTouchNumber
        '
        Me.Tbx_WorkerTouchNumber.Location = New System.Drawing.Point(131, 21)
        Me.Tbx_WorkerTouchNumber.Name = "Tbx_WorkerTouchNumber"
        Me.Tbx_WorkerTouchNumber.Size = New System.Drawing.Size(195, 22)
        Me.Tbx_WorkerTouchNumber.TabIndex = 30
        '
        'Lb_
        '
        Me.Lb_.AutoSize = True
        Me.Lb_.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_.Location = New System.Drawing.Point(4, 24)
        Me.Lb_.Name = "Lb_"
        Me.Lb_.Size = New System.Drawing.Size(121, 16)
        Me.Lb_.TabIndex = 31
        Me.Lb_.Text = "Touch Number  :"
        '
        'Frm_Touch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 384)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Btn_Annuler)
        Me.Controls.Add(Me.Btn_Valider)
        Me.Controls.Add(Me.Btn_Quitter)
        Me.Controls.Add(Me.Btn_supp)
        Me.Controls.Add(Me.Btn_modifier)
        Me.Controls.Add(Me.Btn_Ajouter)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Touch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Touch Number"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGV_Touch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Annuler As System.Windows.Forms.Button
    Friend WithEvents Btn_Valider As System.Windows.Forms.Button
    Friend WithEvents Btn_Quitter As System.Windows.Forms.Button
    Friend WithEvents Btn_supp As System.Windows.Forms.Button
    Friend WithEvents Btn_modifier As System.Windows.Forms.Button
    Friend WithEvents Btn_Ajouter As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGV_Touch As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lb_TouchNumber As System.Windows.Forms.Label
    Friend WithEvents Tbx_WorkerTouchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TouchValid As System.Windows.Forms.Label
    Friend WithEvents Lb_ As System.Windows.Forms.Label
    Friend WithEvents Chb_TouchValid As System.Windows.Forms.CheckBox
    Friend WithEvents Lb_Use As System.Windows.Forms.Label
    Friend WithEvents Chb_Use As System.Windows.Forms.CheckBox
End Class
