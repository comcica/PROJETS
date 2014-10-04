<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PTFiche
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Identification = New System.Windows.Forms.TabPage()
        Me.Cb_CpteCollectif = New UTCombo.MultiColCombo(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Tb_CTSite = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Tb_CTEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tb_CTTeleponie = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tb_CTTelephone = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Tb_CTIdentifiant = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Tb_CTPays = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tb_CTVille = New System.Windows.Forms.TextBox()
        Me.Tb_CTCP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tb_CTComplement = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tb_CTAdresse = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tb_CTContact = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TbCTIntitule = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_typeCpte = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TbCpeTiers = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.Identification.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.Identification)
        Me.TabControl1.Location = New System.Drawing.Point(22, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(597, 427)
        Me.TabControl1.TabIndex = 0
        '
        'Identification
        '
        Me.Identification.Controls.Add(Me.Cb_CpteCollectif)
        Me.Identification.Controls.Add(Me.GroupBox1)
        Me.Identification.Controls.Add(Me.Tb_CTIdentifiant)
        Me.Identification.Controls.Add(Me.Label10)
        Me.Identification.Controls.Add(Me.Tb_CTPays)
        Me.Identification.Controls.Add(Me.Label9)
        Me.Identification.Controls.Add(Me.Tb_CTVille)
        Me.Identification.Controls.Add(Me.Tb_CTCP)
        Me.Identification.Controls.Add(Me.Label8)
        Me.Identification.Controls.Add(Me.Tb_CTComplement)
        Me.Identification.Controls.Add(Me.Label7)
        Me.Identification.Controls.Add(Me.Tb_CTAdresse)
        Me.Identification.Controls.Add(Me.Label6)
        Me.Identification.Controls.Add(Me.Tb_CTContact)
        Me.Identification.Controls.Add(Me.Label5)
        Me.Identification.Controls.Add(Me.Label4)
        Me.Identification.Controls.Add(Me.TbCTIntitule)
        Me.Identification.Controls.Add(Me.Label3)
        Me.Identification.Controls.Add(Me.Cb_typeCpte)
        Me.Identification.Controls.Add(Me.Label2)
        Me.Identification.Controls.Add(Me.TbCpeTiers)
        Me.Identification.Controls.Add(Me.Label1)
        Me.Identification.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Identification.Location = New System.Drawing.Point(4, 22)
        Me.Identification.Name = "Identification"
        Me.Identification.Padding = New System.Windows.Forms.Padding(3)
        Me.Identification.Size = New System.Drawing.Size(589, 401)
        Me.Identification.TabIndex = 0
        Me.Identification.Text = "Identification"
        Me.Identification.UseVisualStyleBackColor = True
        '
        'Cb_CpteCollectif
        '
        Me.Cb_CpteCollectif.FormattingEnabled = True
        Me.Cb_CpteCollectif.Location = New System.Drawing.Point(141, 84)
        Me.Cb_CpteCollectif.Name = "Cb_CpteCollectif"
        Me.Cb_CpteCollectif.Size = New System.Drawing.Size(138, 24)
        Me.Cb_CpteCollectif.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tb_CTSite)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Tb_CTEmail)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Tb_CTTeleponie)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Tb_CTTelephone)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(26, 258)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 127)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Télécommunication"
        '
        'Tb_CTSite
        '
        Me.Tb_CTSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_CTSite.Location = New System.Drawing.Point(101, 76)
        Me.Tb_CTSite.Name = "Tb_CTSite"
        Me.Tb_CTSite.Size = New System.Drawing.Size(422, 22)
        Me.Tb_CTSite.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 16)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Site"
        '
        'Tb_CTEmail
        '
        Me.Tb_CTEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_CTEmail.Location = New System.Drawing.Point(101, 48)
        Me.Tb_CTEmail.Name = "Tb_CTEmail"
        Me.Tb_CTEmail.Size = New System.Drawing.Size(422, 22)
        Me.Tb_CTEmail.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 16)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "E-mail"
        '
        'Tb_CTTeleponie
        '
        Me.Tb_CTTeleponie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_CTTeleponie.Location = New System.Drawing.Point(366, 20)
        Me.Tb_CTTeleponie.Name = "Tb_CTTeleponie"
        Me.Tb_CTTeleponie.Size = New System.Drawing.Size(157, 22)
        Me.Tb_CTTeleponie.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(259, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Télécopie"
        '
        'Tb_CTTelephone
        '
        Me.Tb_CTTelephone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_CTTelephone.Location = New System.Drawing.Point(101, 20)
        Me.Tb_CTTelephone.Name = "Tb_CTTelephone"
        Me.Tb_CTTelephone.Size = New System.Drawing.Size(152, 22)
        Me.Tb_CTTelephone.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Téléphone"
        '
        'Tb_CTIdentifiant
        '
        Me.Tb_CTIdentifiant.Location = New System.Drawing.Point(141, 218)
        Me.Tb_CTIdentifiant.Name = "Tb_CTIdentifiant"
        Me.Tb_CTIdentifiant.Size = New System.Drawing.Size(422, 22)
        Me.Tb_CTIdentifiant.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "N°  Identifiant"
        '
        'Tb_CTPays
        '
        Me.Tb_CTPays.Location = New System.Drawing.Point(141, 192)
        Me.Tb_CTPays.Name = "Tb_CTPays"
        Me.Tb_CTPays.Size = New System.Drawing.Size(422, 22)
        Me.Tb_CTPays.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Pays"
        '
        'Tb_CTVille
        '
        Me.Tb_CTVille.Location = New System.Drawing.Point(288, 166)
        Me.Tb_CTVille.Name = "Tb_CTVille"
        Me.Tb_CTVille.Size = New System.Drawing.Size(275, 22)
        Me.Tb_CTVille.TabIndex = 16
        '
        'Tb_CTCP
        '
        Me.Tb_CTCP.Location = New System.Drawing.Point(141, 166)
        Me.Tb_CTCP.Name = "Tb_CTCP"
        Me.Tb_CTCP.Size = New System.Drawing.Size(138, 22)
        Me.Tb_CTCP.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "CP / Ville"
        '
        'Tb_CTComplement
        '
        Me.Tb_CTComplement.Location = New System.Drawing.Point(141, 140)
        Me.Tb_CTComplement.Name = "Tb_CTComplement"
        Me.Tb_CTComplement.Size = New System.Drawing.Size(422, 22)
        Me.Tb_CTComplement.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Complement"
        '
        'Tb_CTAdresse
        '
        Me.Tb_CTAdresse.Location = New System.Drawing.Point(141, 112)
        Me.Tb_CTAdresse.Name = "Tb_CTAdresse"
        Me.Tb_CTAdresse.Size = New System.Drawing.Size(422, 22)
        Me.Tb_CTAdresse.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Adresse"
        '
        'Tb_CTContact
        '
        Me.Tb_CTContact.Location = New System.Drawing.Point(336, 83)
        Me.Tb_CTContact.Name = "Tb_CTContact"
        Me.Tb_CTContact.Size = New System.Drawing.Size(227, 22)
        Me.Tb_CTContact.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Contact"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Compte Collectif"
        '
        'TbCTIntitule
        '
        Me.TbCTIntitule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TbCTIntitule.Location = New System.Drawing.Point(141, 56)
        Me.TbCTIntitule.Name = "TbCTIntitule"
        Me.TbCTIntitule.Size = New System.Drawing.Size(422, 22)
        Me.TbCTIntitule.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Intitulé"
        '
        'Cb_typeCpte
        '
        Me.Cb_typeCpte.Enabled = False
        Me.Cb_typeCpte.FormattingEnabled = True
        Me.Cb_typeCpte.Items.AddRange(New Object() {"Client", "Fournisseur", "Salarié", "Autre"})
        Me.Cb_typeCpte.Location = New System.Drawing.Point(425, 27)
        Me.Cb_typeCpte.Name = "Cb_typeCpte"
        Me.Cb_typeCpte.Size = New System.Drawing.Size(138, 24)
        Me.Cb_typeCpte.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type"
        '
        'TbCpeTiers
        '
        Me.TbCpeTiers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TbCpeTiers.Enabled = False
        Me.TbCpeTiers.Location = New System.Drawing.Point(141, 30)
        Me.TbCpeTiers.Name = "TbCpeTiers"
        Me.TbCpeTiers.Size = New System.Drawing.Size(169, 22)
        Me.TbCpeTiers.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° de compte"
        '
        'Frm_PTFiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 478)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PTFiche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiers : "
        Me.TabControl1.ResumeLayout(False)
        Me.Identification.ResumeLayout(False)
        Me.Identification.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Identification As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbCpeTiers As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_typeCpte As System.Windows.Forms.ComboBox
    Friend WithEvents TbCTIntitule As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTContact As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTAdresse As System.Windows.Forms.TextBox
    Friend WithEvents Tb_CTComplement As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTVille As System.Windows.Forms.TextBox
    Friend WithEvents Tb_CTCP As System.Windows.Forms.TextBox
    Friend WithEvents Tb_CTPays As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTIdentifiant As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tb_CTTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTTeleponie As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTSite As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Tb_CTEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Cb_CpteCollectif As UTCombo.MultiColCombo
End Class
