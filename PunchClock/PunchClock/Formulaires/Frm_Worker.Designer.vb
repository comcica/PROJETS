<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Worker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Worker))
        Me.Tbx_idworker = New System.Windows.Forms.TextBox()
        Me.Tbx_WorkerName = New System.Windows.Forms.TextBox()
        Me.Tbx_WorkerEmail = New System.Windows.Forms.TextBox()
        Me.Tbx_WorkerLed = New System.Windows.Forms.TextBox()
        Me.Lb_IdPersonne = New System.Windows.Forms.Label()
        Me.Lb_Nompersonne = New System.Windows.Forms.Label()
        Me.Lb_EmailPersonne = New System.Windows.Forms.Label()
        Me.Lb_ClePersonne = New System.Windows.Forms.Label()
        Me.Lb_Led = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cb_WorkerValid = New System.Windows.Forms.ComboBox()
        Me.Cb_WorkerState = New System.Windows.Forms.ComboBox()
        Me.Lb_WorkerValid = New System.Windows.Forms.Label()
        Me.Lb_WorkerState = New System.Windows.Forms.Label()
        Me.cb_WorkerTouchNumberNotUse = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGV_peronne = New System.Windows.Forms.DataGridView()
        Me.Btn_Ajouter = New System.Windows.Forms.Button()
        Me.Btn_modifier = New System.Windows.Forms.Button()
        Me.IdPersonne1 = New System.Windows.Forms.TextBox()
        Me.Btn_supp = New System.Windows.Forms.Button()
        Me.Btn_Quitter = New System.Windows.Forms.Button()
        Me.Btn_Valider = New System.Windows.Forms.Button()
        Me.Btn_Annuler = New System.Windows.Forms.Button()
        Me.DataGridV_AssociateTouchNumber = New System.Windows.Forms.DataGridView()
        Me.Gb_AssociateTouchNumber = New System.Windows.Forms.GroupBox()
        Me.Btn_moins = New System.Windows.Forms.Button()
        Me.Btn_Plus = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGV_peronne, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridV_AssociateTouchNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb_AssociateTouchNumber.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tbx_idworker
        '
        Me.Tbx_idworker.Location = New System.Drawing.Point(113, 20)
        Me.Tbx_idworker.Name = "Tbx_idworker"
        Me.Tbx_idworker.Size = New System.Drawing.Size(264, 22)
        Me.Tbx_idworker.TabIndex = 24
        '
        'Tbx_WorkerName
        '
        Me.Tbx_WorkerName.Location = New System.Drawing.Point(113, 47)
        Me.Tbx_WorkerName.Name = "Tbx_WorkerName"
        Me.Tbx_WorkerName.Size = New System.Drawing.Size(264, 22)
        Me.Tbx_WorkerName.TabIndex = 25
        '
        'Tbx_WorkerEmail
        '
        Me.Tbx_WorkerEmail.Location = New System.Drawing.Point(113, 75)
        Me.Tbx_WorkerEmail.Name = "Tbx_WorkerEmail"
        Me.Tbx_WorkerEmail.Size = New System.Drawing.Size(264, 22)
        Me.Tbx_WorkerEmail.TabIndex = 26
        '
        'Tbx_WorkerLed
        '
        Me.Tbx_WorkerLed.Location = New System.Drawing.Point(126, 405)
        Me.Tbx_WorkerLed.Name = "Tbx_WorkerLed"
        Me.Tbx_WorkerLed.Size = New System.Drawing.Size(264, 20)
        Me.Tbx_WorkerLed.TabIndex = 29
        '
        'Lb_IdPersonne
        '
        Me.Lb_IdPersonne.AutoSize = True
        Me.Lb_IdPersonne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_IdPersonne.Location = New System.Drawing.Point(3, 23)
        Me.Lb_IdPersonne.Name = "Lb_IdPersonne"
        Me.Lb_IdPersonne.Size = New System.Drawing.Size(83, 16)
        Me.Lb_IdPersonne.TabIndex = 28
        Me.Lb_IdPersonne.Text = "Id Worker :"
        '
        'Lb_Nompersonne
        '
        Me.Lb_Nompersonne.AutoSize = True
        Me.Lb_Nompersonne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Nompersonne.Location = New System.Drawing.Point(3, 47)
        Me.Lb_Nompersonne.Name = "Lb_Nompersonne"
        Me.Lb_Nompersonne.Size = New System.Drawing.Size(57, 16)
        Me.Lb_Nompersonne.TabIndex = 29
        Me.Lb_Nompersonne.Text = "Name :"
        '
        'Lb_EmailPersonne
        '
        Me.Lb_EmailPersonne.AutoSize = True
        Me.Lb_EmailPersonne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_EmailPersonne.Location = New System.Drawing.Point(3, 81)
        Me.Lb_EmailPersonne.Name = "Lb_EmailPersonne"
        Me.Lb_EmailPersonne.Size = New System.Drawing.Size(54, 16)
        Me.Lb_EmailPersonne.TabIndex = 30
        Me.Lb_EmailPersonne.Text = "email :"
        '
        'Lb_ClePersonne
        '
        Me.Lb_ClePersonne.AutoSize = True
        Me.Lb_ClePersonne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_ClePersonne.Location = New System.Drawing.Point(16, 20)
        Me.Lb_ClePersonne.Name = "Lb_ClePersonne"
        Me.Lb_ClePersonne.Size = New System.Drawing.Size(121, 16)
        Me.Lb_ClePersonne.TabIndex = 31
        Me.Lb_ClePersonne.Text = "Touch Number  :"
        '
        'Lb_Led
        '
        Me.Lb_Led.AutoSize = True
        Me.Lb_Led.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Led.Location = New System.Drawing.Point(16, 407)
        Me.Lb_Led.Name = "Lb_Led"
        Me.Lb_Led.Size = New System.Drawing.Size(42, 16)
        Me.Lb_Led.TabIndex = 32
        Me.Lb_Led.Text = "Led :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tbx_idworker)
        Me.GroupBox1.Controls.Add(Me.Cb_WorkerValid)
        Me.GroupBox1.Controls.Add(Me.Tbx_WorkerName)
        Me.GroupBox1.Controls.Add(Me.Cb_WorkerState)
        Me.GroupBox1.Controls.Add(Me.Lb_EmailPersonne)
        Me.GroupBox1.Controls.Add(Me.Lb_Nompersonne)
        Me.GroupBox1.Controls.Add(Me.Lb_WorkerValid)
        Me.GroupBox1.Controls.Add(Me.Tbx_WorkerEmail)
        Me.GroupBox1.Controls.Add(Me.Lb_IdPersonne)
        Me.GroupBox1.Controls.Add(Me.Lb_WorkerState)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 302)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 170)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Worker Record"
        '
        'Cb_WorkerValid
        '
        Me.Cb_WorkerValid.FormattingEnabled = True
        Me.Cb_WorkerValid.Items.AddRange(New Object() {"0", "1"})
        Me.Cb_WorkerValid.Location = New System.Drawing.Point(302, 129)
        Me.Cb_WorkerValid.Name = "Cb_WorkerValid"
        Me.Cb_WorkerValid.Size = New System.Drawing.Size(75, 24)
        Me.Cb_WorkerValid.TabIndex = 28
        Me.Cb_WorkerValid.Text = " "
        '
        'Cb_WorkerState
        '
        Me.Cb_WorkerState.FormattingEnabled = True
        Me.Cb_WorkerState.Items.AddRange(New Object() {"0", "1"})
        Me.Cb_WorkerState.Location = New System.Drawing.Point(113, 129)
        Me.Cb_WorkerState.Name = "Cb_WorkerState"
        Me.Cb_WorkerState.Size = New System.Drawing.Size(55, 24)
        Me.Cb_WorkerState.TabIndex = 27
        '
        'Lb_WorkerValid
        '
        Me.Lb_WorkerValid.AutoSize = True
        Me.Lb_WorkerValid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_WorkerValid.Location = New System.Drawing.Point(207, 132)
        Me.Lb_WorkerValid.Name = "Lb_WorkerValid"
        Me.Lb_WorkerValid.Size = New System.Drawing.Size(52, 16)
        Me.Lb_WorkerValid.TabIndex = 36
        Me.Lb_WorkerValid.Text = "Valid :"
        '
        'Lb_WorkerState
        '
        Me.Lb_WorkerState.AutoSize = True
        Me.Lb_WorkerState.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_WorkerState.Location = New System.Drawing.Point(3, 132)
        Me.Lb_WorkerState.Name = "Lb_WorkerState"
        Me.Lb_WorkerState.Size = New System.Drawing.Size(52, 16)
        Me.Lb_WorkerState.TabIndex = 34
        Me.Lb_WorkerState.Text = "State :"
        '
        'cb_WorkerTouchNumberNotUse
        '
        Me.cb_WorkerTouchNumberNotUse.FormattingEnabled = True
        Me.cb_WorkerTouchNumberNotUse.Location = New System.Drawing.Point(146, 15)
        Me.cb_WorkerTouchNumberNotUse.Name = "cb_WorkerTouchNumberNotUse"
        Me.cb_WorkerTouchNumberNotUse.Size = New System.Drawing.Size(217, 21)
        Me.cb_WorkerTouchNumberNotUse.TabIndex = 37
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGV_peronne)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 273)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Worker List"
        '
        'DataGV_peronne
        '
        Me.DataGV_peronne.AllowUserToOrderColumns = True
        Me.DataGV_peronne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGV_peronne.Location = New System.Drawing.Point(14, 17)
        Me.DataGV_peronne.MultiSelect = False
        Me.DataGV_peronne.Name = "DataGV_peronne"
        Me.DataGV_peronne.ReadOnly = True
        Me.DataGV_peronne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGV_peronne.Size = New System.Drawing.Size(795, 240)
        Me.DataGV_peronne.TabIndex = 42
        '
        'Btn_Ajouter
        '
        Me.Btn_Ajouter.Location = New System.Drawing.Point(5, 542)
        Me.Btn_Ajouter.Name = "Btn_Ajouter"
        Me.Btn_Ajouter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Ajouter.TabIndex = 35
        Me.Btn_Ajouter.Text = "Ajouter"
        Me.Btn_Ajouter.UseVisualStyleBackColor = True
        '
        'Btn_modifier
        '
        Me.Btn_modifier.Location = New System.Drawing.Point(96, 542)
        Me.Btn_modifier.Name = "Btn_modifier"
        Me.Btn_modifier.Size = New System.Drawing.Size(85, 32)
        Me.Btn_modifier.TabIndex = 36
        Me.Btn_modifier.Text = "Modifier"
        Me.Btn_modifier.UseVisualStyleBackColor = True
        '
        'IdPersonne1
        '
        Me.IdPersonne1.Enabled = False
        Me.IdPersonne1.Location = New System.Drawing.Point(977, 12)
        Me.IdPersonne1.Name = "IdPersonne1"
        Me.IdPersonne1.Size = New System.Drawing.Size(185, 20)
        Me.IdPersonne1.TabIndex = 23
        '
        'Btn_supp
        '
        Me.Btn_supp.Location = New System.Drawing.Point(187, 542)
        Me.Btn_supp.Name = "Btn_supp"
        Me.Btn_supp.Size = New System.Drawing.Size(85, 32)
        Me.Btn_supp.TabIndex = 38
        Me.Btn_supp.Text = "Supprimer"
        Me.Btn_supp.UseVisualStyleBackColor = True
        '
        'Btn_Quitter
        '
        Me.Btn_Quitter.Location = New System.Drawing.Point(777, 541)
        Me.Btn_Quitter.Name = "Btn_Quitter"
        Me.Btn_Quitter.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Quitter.TabIndex = 39
        Me.Btn_Quitter.Text = "Quitter"
        Me.Btn_Quitter.UseVisualStyleBackColor = True
        '
        'Btn_Valider
        '
        Me.Btn_Valider.Location = New System.Drawing.Point(5, 541)
        Me.Btn_Valider.Name = "Btn_Valider"
        Me.Btn_Valider.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Valider.TabIndex = 40
        Me.Btn_Valider.Text = "Ok"
        Me.Btn_Valider.UseVisualStyleBackColor = True
        Me.Btn_Valider.Visible = False
        '
        'Btn_Annuler
        '
        Me.Btn_Annuler.Location = New System.Drawing.Point(96, 542)
        Me.Btn_Annuler.Name = "Btn_Annuler"
        Me.Btn_Annuler.Size = New System.Drawing.Size(85, 32)
        Me.Btn_Annuler.TabIndex = 41
        Me.Btn_Annuler.Text = "Annuler"
        Me.Btn_Annuler.UseVisualStyleBackColor = True
        Me.Btn_Annuler.Visible = False
        '
        'DataGridV_AssociateTouchNumber
        '
        Me.DataGridV_AssociateTouchNumber.AllowUserToOrderColumns = True
        Me.DataGridV_AssociateTouchNumber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridV_AssociateTouchNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridV_AssociateTouchNumber.Location = New System.Drawing.Point(19, 49)
        Me.DataGridV_AssociateTouchNumber.MultiSelect = False
        Me.DataGridV_AssociateTouchNumber.Name = "DataGridV_AssociateTouchNumber"
        Me.DataGridV_AssociateTouchNumber.ReadOnly = True
        Me.DataGridV_AssociateTouchNumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridV_AssociateTouchNumber.Size = New System.Drawing.Size(344, 101)
        Me.DataGridV_AssociateTouchNumber.TabIndex = 42
        '
        'Gb_AssociateTouchNumber
        '
        Me.Gb_AssociateTouchNumber.Controls.Add(Me.Btn_moins)
        Me.Gb_AssociateTouchNumber.Controls.Add(Me.Btn_Plus)
        Me.Gb_AssociateTouchNumber.Controls.Add(Me.DataGridV_AssociateTouchNumber)
        Me.Gb_AssociateTouchNumber.Controls.Add(Me.cb_WorkerTouchNumberNotUse)
        Me.Gb_AssociateTouchNumber.Controls.Add(Me.Lb_ClePersonne)
        Me.Gb_AssociateTouchNumber.Location = New System.Drawing.Point(458, 305)
        Me.Gb_AssociateTouchNumber.Name = "Gb_AssociateTouchNumber"
        Me.Gb_AssociateTouchNumber.Size = New System.Drawing.Size(403, 167)
        Me.Gb_AssociateTouchNumber.TabIndex = 44
        Me.Gb_AssociateTouchNumber.TabStop = False
        Me.Gb_AssociateTouchNumber.Text = "Associated Touch Number :"
        '
        'Btn_moins
        '
        Me.Btn_moins.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_moins.Image = Global.PunchClock.My.Resources.Resources.moins
        Me.Btn_moins.Location = New System.Drawing.Point(365, 115)
        Me.Btn_moins.Name = "Btn_moins"
        Me.Btn_moins.Size = New System.Drawing.Size(34, 35)
        Me.Btn_moins.TabIndex = 44
        Me.Btn_moins.Text = "..."
        Me.Btn_moins.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_moins.UseVisualStyleBackColor = True
        '
        'Btn_Plus
        '
        Me.Btn_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Plus.Image = Global.PunchClock.My.Resources.Resources.Plus
        Me.Btn_Plus.Location = New System.Drawing.Point(365, 12)
        Me.Btn_Plus.Name = "Btn_Plus"
        Me.Btn_Plus.Size = New System.Drawing.Size(34, 35)
        Me.Btn_Plus.TabIndex = 43
        Me.Btn_Plus.Text = "..."
        Me.Btn_Plus.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_Plus.UseVisualStyleBackColor = True
        '
        'Frm_Worker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 586)
        Me.Controls.Add(Me.Gb_AssociateTouchNumber)
        Me.Controls.Add(Me.Btn_Annuler)
        Me.Controls.Add(Me.IdPersonne1)
        Me.Controls.Add(Me.Btn_Valider)
        Me.Controls.Add(Me.Btn_Quitter)
        Me.Controls.Add(Me.Tbx_WorkerLed)
        Me.Controls.Add(Me.Btn_supp)
        Me.Controls.Add(Me.Lb_Led)
        Me.Controls.Add(Me.Btn_modifier)
        Me.Controls.Add(Me.Btn_Ajouter)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Worker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Workers"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGV_peronne, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridV_AssociateTouchNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb_AssociateTouchNumber.ResumeLayout(False)
        Me.Gb_AssociateTouchNumber.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tbx_idworker As System.Windows.Forms.TextBox
    Friend WithEvents Tbx_WorkerName As System.Windows.Forms.TextBox
    Friend WithEvents Tbx_WorkerEmail As System.Windows.Forms.TextBox
    Friend WithEvents Tbx_WorkerLed As System.Windows.Forms.TextBox
    Friend WithEvents Lb_IdPersonne As System.Windows.Forms.Label
    Friend WithEvents Lb_Nompersonne As System.Windows.Forms.Label
    Friend WithEvents Lb_EmailPersonne As System.Windows.Forms.Label
    Friend WithEvents Lb_ClePersonne As System.Windows.Forms.Label
    Friend WithEvents Lb_Led As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Ajouter As System.Windows.Forms.Button
    Friend WithEvents Btn_modifier As System.Windows.Forms.Button
    Friend WithEvents IdPersonne1 As System.Windows.Forms.TextBox
    Friend WithEvents Btn_supp As System.Windows.Forms.Button
    Friend WithEvents Btn_Quitter As System.Windows.Forms.Button
    Friend WithEvents Btn_Valider As System.Windows.Forms.Button
    Friend WithEvents Btn_Annuler As System.Windows.Forms.Button
    Friend WithEvents DataGV_peronne As System.Windows.Forms.DataGridView
    Friend WithEvents Lb_WorkerState As System.Windows.Forms.Label
    Friend WithEvents Lb_WorkerValid As System.Windows.Forms.Label
    Friend WithEvents Cb_WorkerState As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_WorkerValid As System.Windows.Forms.ComboBox
    Friend WithEvents cb_WorkerTouchNumberNotUse As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridV_AssociateTouchNumber As System.Windows.Forms.DataGridView
    Friend WithEvents Gb_AssociateTouchNumber As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Plus As System.Windows.Forms.Button
    Friend WithEvents Btn_moins As System.Windows.Forms.Button
End Class
