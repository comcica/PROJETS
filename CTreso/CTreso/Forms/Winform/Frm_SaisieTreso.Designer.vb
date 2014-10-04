<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SaisieTreso
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGSaisieTreso = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimerBonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tb_NumPiece = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tb_Ref = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tb_NumFac = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tb_Libelle = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cb_CpteTiers = New UTCombo.MultiColCombo(Me.components)
        Me.Cb_CpteGeneral = New UTCombo.MultiColCombo(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tb_Benef = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Tb_Montant = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Cb_Sens = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tb_EC_No = New System.Windows.Forms.TextBox()
        Me.Btn_Refresh = New System.Windows.Forms.Button()
        Me.Btn_Valider = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_Journal = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Lb_SoldeDebit = New System.Windows.Forms.TextBox()
        Me.Lb_TotDebit = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Lb_TotCredit = New System.Windows.Forms.TextBox()
        Me.Lb_SoldeCredit = New System.Windows.Forms.TextBox()
        CType(Me.DGSaisieTreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(481, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Totaux  : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(481, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Solde : "
        '
        'DGSaisieTreso
        '
        Me.DGSaisieTreso.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGSaisieTreso.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGSaisieTreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGSaisieTreso.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGSaisieTreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSaisieTreso.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGSaisieTreso.Location = New System.Drawing.Point(12, 367)
        Me.DGSaisieTreso.Name = "DGSaisieTreso"
        Me.DGSaisieTreso.ReadOnly = True
        Me.DGSaisieTreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSaisieTreso.Size = New System.Drawing.Size(1083, 240)
        Me.DGSaisieTreso.TabIndex = 8
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimerBonToolStripMenuItem, Me.SpprimerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(166, 48)
        '
        'ImprimerBonToolStripMenuItem
        '
        Me.ImprimerBonToolStripMenuItem.Image = Global.CTreso.My.Resources.Resources.Print
        Me.ImprimerBonToolStripMenuItem.Name = "ImprimerBonToolStripMenuItem"
        Me.ImprimerBonToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ImprimerBonToolStripMenuItem.Text = "Imprimer la ligne"
        '
        'SpprimerToolStripMenuItem
        '
        Me.SpprimerToolStripMenuItem.Image = Global.CTreso.My.Resources.Resources.delele32
        Me.SpprimerToolStripMenuItem.Name = "SpprimerToolStripMenuItem"
        Me.SpprimerToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SpprimerToolStripMenuItem.Text = "Spprimer la Pièce"
        '
        'Tb_NumPiece
        '
        Me.Tb_NumPiece.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tb_NumPiece.Location = New System.Drawing.Point(135, 42)
        Me.Tb_NumPiece.Name = "Tb_NumPiece"
        Me.Tb_NumPiece.Size = New System.Drawing.Size(139, 22)
        Me.Tb_NumPiece.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "N°  de Pièce"
        '
        'Tb_Ref
        '
        Me.Tb_Ref.Location = New System.Drawing.Point(367, 85)
        Me.Tb_Ref.MaxLength = 17
        Me.Tb_Ref.Name = "Tb_Ref"
        Me.Tb_Ref.Size = New System.Drawing.Size(227, 22)
        Me.Tb_Ref.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(281, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Référence"
        '
        'Tb_NumFac
        '
        Me.Tb_NumFac.Location = New System.Drawing.Point(721, 85)
        Me.Tb_NumFac.MaxLength = 17
        Me.Tb_NumFac.Name = "Tb_NumFac"
        Me.Tb_NumFac.Size = New System.Drawing.Size(169, 22)
        Me.Tb_NumFac.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(604, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "N°  de  Facture"
        '
        'Tb_Libelle
        '
        Me.Tb_Libelle.Location = New System.Drawing.Point(342, 31)
        Me.Tb_Libelle.MaxLength = 68
        Me.Tb_Libelle.Multiline = True
        Me.Tb_Libelle.Name = "Tb_Libelle"
        Me.Tb_Libelle.Size = New System.Drawing.Size(548, 43)
        Me.Tb_Libelle.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(281, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Libellé"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Cb_CpteTiers)
        Me.GroupBox1.Controls.Add(Me.Cb_CpteGeneral)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Tb_Benef)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Tb_Montant)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Cb_Sens)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DTDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Tb_Libelle)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Tb_NumFac)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Tb_Ref)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Tb_NumPiece)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(958, 191)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Saisie Journal"
        '
        'Cb_CpteTiers
        '
        Me.Cb_CpteTiers.FormattingEnabled = True
        Me.Cb_CpteTiers.Location = New System.Drawing.Point(135, 118)
        Me.Cb_CpteTiers.Name = "Cb_CpteTiers"
        Me.Cb_CpteTiers.Size = New System.Drawing.Size(237, 24)
        Me.Cb_CpteTiers.TabIndex = 34
        '
        'Cb_CpteGeneral
        '
        Me.Cb_CpteGeneral.FormattingEnabled = True
        Me.Cb_CpteGeneral.Location = New System.Drawing.Point(135, 158)
        Me.Cb_CpteGeneral.Name = "Cb_CpteGeneral"
        Me.Cb_CpteGeneral.Size = New System.Drawing.Size(171, 24)
        Me.Cb_CpteGeneral.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(390, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 16)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Bénéficiaire"
        '
        'Tb_Benef
        '
        Me.Tb_Benef.Location = New System.Drawing.Point(523, 121)
        Me.Tb_Benef.MaxLength = 35
        Me.Tb_Benef.Name = "Tb_Benef"
        Me.Tb_Benef.Size = New System.Drawing.Size(367, 22)
        Me.Tb_Benef.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(592, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 16)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Montant"
        '
        'Tb_Montant
        '
        Me.Tb_Montant.Location = New System.Drawing.Point(690, 158)
        Me.Tb_Montant.MaxLength = 12
        Me.Tb_Montant.Name = "Tb_Montant"
        Me.Tb_Montant.Size = New System.Drawing.Size(200, 22)
        Me.Tb_Montant.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(329, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 16)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Sens"
        '
        'Cb_Sens
        '
        Me.Cb_Sens.FormattingEnabled = True
        Me.Cb_Sens.Items.AddRange(New Object() {"Débit", "Crédit"})
        Me.Cb_Sens.Location = New System.Drawing.Point(417, 158)
        Me.Cb_Sens.Name = "Cb_Sens"
        Me.Cb_Sens.Size = New System.Drawing.Size(134, 24)
        Me.Cb_Sens.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Compte Général"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Compte Tiers"
        '
        'DTDate
        '
        Me.DTDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTDate.Location = New System.Drawing.Point(135, 88)
        Me.DTDate.Name = "DTDate"
        Me.DTDate.Size = New System.Drawing.Size(130, 22)
        Me.DTDate.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Date"
        '
        'Tb_EC_No
        '
        Me.Tb_EC_No.Location = New System.Drawing.Point(195, 137)
        Me.Tb_EC_No.Name = "Tb_EC_No"
        Me.Tb_EC_No.Size = New System.Drawing.Size(139, 20)
        Me.Tb_EC_No.TabIndex = 11
        Me.Tb_EC_No.Visible = False
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Refresh.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Btn_Refresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Refresh.Image = Global.CTreso.My.Resources.Resources.refresh
        Me.Btn_Refresh.Location = New System.Drawing.Point(976, 240)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(119, 38)
        Me.Btn_Refresh.TabIndex = 13
        Me.Btn_Refresh.UseCompatibleTextRendering = True
        Me.Btn_Refresh.UseVisualStyleBackColor = False
        '
        'Btn_Valider
        '
        Me.Btn_Valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Valider.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Btn_Valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Valider.Image = Global.CTreso.My.Resources.Resources.valider
        Me.Btn_Valider.Location = New System.Drawing.Point(976, 311)
        Me.Btn_Valider.Name = "Btn_Valider"
        Me.Btn_Valider.Size = New System.Drawing.Size(119, 38)
        Me.Btn_Valider.TabIndex = 9
        Me.Btn_Valider.UseCompatibleTextRendering = True
        Me.Btn_Valider.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_Journal)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 105)
        Me.Panel1.TabIndex = 14
        '
        'Lb_Journal
        '
        Me.Lb_Journal.AutoSize = True
        Me.Lb_Journal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Journal.ForeColor = System.Drawing.Color.Fuchsia
        Me.Lb_Journal.Location = New System.Drawing.Point(13, 36)
        Me.Lb_Journal.Name = "Lb_Journal"
        Me.Lb_Journal.Size = New System.Drawing.Size(0, 24)
        Me.Lb_Journal.TabIndex = 0
        Me.Lb_Journal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Lb_SoldeDebit)
        Me.Panel2.Controls.Add(Me.Lb_TotDebit)
        Me.Panel2.Location = New System.Drawing.Point(630, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(224, 104)
        Me.Panel2.TabIndex = 15
        '
        'Lb_SoldeDebit
        '
        Me.Lb_SoldeDebit.BackColor = System.Drawing.SystemColors.Control
        Me.Lb_SoldeDebit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lb_SoldeDebit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lb_SoldeDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_SoldeDebit.ForeColor = System.Drawing.Color.Red
        Me.Lb_SoldeDebit.Location = New System.Drawing.Point(3, 69)
        Me.Lb_SoldeDebit.Name = "Lb_SoldeDebit"
        Me.Lb_SoldeDebit.Size = New System.Drawing.Size(214, 22)
        Me.Lb_SoldeDebit.TabIndex = 4
        Me.Lb_SoldeDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lb_TotDebit
        '
        Me.Lb_TotDebit.BackColor = System.Drawing.SystemColors.Control
        Me.Lb_TotDebit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lb_TotDebit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lb_TotDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TotDebit.ForeColor = System.Drawing.Color.Black
        Me.Lb_TotDebit.Location = New System.Drawing.Point(-2, 20)
        Me.Lb_TotDebit.Name = "Lb_TotDebit"
        Me.Lb_TotDebit.Size = New System.Drawing.Size(219, 19)
        Me.Lb_TotDebit.TabIndex = 3
        Me.Lb_TotDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Lb_TotCredit)
        Me.Panel3.Controls.Add(Me.Lb_SoldeCredit)
        Me.Panel3.Location = New System.Drawing.Point(860, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(235, 105)
        Me.Panel3.TabIndex = 16
        '
        'Lb_TotCredit
        '
        Me.Lb_TotCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_TotCredit.BackColor = System.Drawing.SystemColors.Control
        Me.Lb_TotCredit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lb_TotCredit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lb_TotCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TotCredit.ForeColor = System.Drawing.Color.Black
        Me.Lb_TotCredit.Location = New System.Drawing.Point(3, 20)
        Me.Lb_TotCredit.Name = "Lb_TotCredit"
        Me.Lb_TotCredit.Size = New System.Drawing.Size(219, 19)
        Me.Lb_TotCredit.TabIndex = 2
        Me.Lb_TotCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lb_SoldeCredit
        '
        Me.Lb_SoldeCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_SoldeCredit.BackColor = System.Drawing.SystemColors.Control
        Me.Lb_SoldeCredit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lb_SoldeCredit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Lb_SoldeCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_SoldeCredit.ForeColor = System.Drawing.Color.Red
        Me.Lb_SoldeCredit.Location = New System.Drawing.Point(3, 69)
        Me.Lb_SoldeCredit.Name = "Lb_SoldeCredit"
        Me.Lb_SoldeCredit.Size = New System.Drawing.Size(219, 22)
        Me.Lb_SoldeCredit.TabIndex = 1
        Me.Lb_SoldeCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_SaisieTreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 619)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Btn_Refresh)
        Me.Controls.Add(Me.Tb_EC_No)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Btn_Valider)
        Me.Controls.Add(Me.DGSaisieTreso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(1124, 657)
        Me.Name = "Frm_SaisieTreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saisie "
        CType(Me.DGSaisieTreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGSaisieTreso As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Valider As System.Windows.Forms.Button
    Friend WithEvents Tb_NumPiece As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb_Ref As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb_NumFac As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tb_Libelle As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tb_Montant As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Cb_Sens As System.Windows.Forms.ComboBox
    Friend WithEvents Tb_EC_No As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Refresh As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimerBonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_Journal As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Lb_SoldeCredit As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TotCredit As System.Windows.Forms.TextBox
    Friend WithEvents Lb_SoldeDebit As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TotDebit As System.Windows.Forms.TextBox
    Friend WithEvents Tb_Benef As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cb_CpteGeneral As UTCombo.MultiColCombo
    Friend WithEvents Cb_CpteTiers As UTCombo.MultiColCombo
End Class
