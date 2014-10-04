<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PCFiche
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
        Me.Cb_typeCpte = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TbIntituleCpte = New System.Windows.Forms.TextBox()
        Me.Cb_NatCptes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DGCpteTiers = New System.Windows.Forms.DataGridView()
        Me.Cb_CpteTiers = New UTCombo.MultiColCombo(Me.components)
        Me.TbNumCompte = New System.Windows.Forms.TextBox()
        CType(Me.DGCpteTiers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° Compte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Type"
        '
        'Cb_typeCpte
        '
        Me.Cb_typeCpte.Enabled = False
        Me.Cb_typeCpte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_typeCpte.FormattingEnabled = True
        Me.Cb_typeCpte.Items.AddRange(New Object() {"Detail", "Total"})
        Me.Cb_typeCpte.Location = New System.Drawing.Point(321, 22)
        Me.Cb_typeCpte.Name = "Cb_typeCpte"
        Me.Cb_typeCpte.Size = New System.Drawing.Size(120, 24)
        Me.Cb_typeCpte.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Intitulé "
        '
        'TbIntituleCpte
        '
        Me.TbIntituleCpte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TbIntituleCpte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbIntituleCpte.Location = New System.Drawing.Point(117, 59)
        Me.TbIntituleCpte.Name = "TbIntituleCpte"
        Me.TbIntituleCpte.Size = New System.Drawing.Size(324, 22)
        Me.TbIntituleCpte.TabIndex = 6
        '
        'Cb_NatCptes
        '
        Me.Cb_NatCptes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_NatCptes.FormattingEnabled = True
        Me.Cb_NatCptes.Items.AddRange(New Object() {"Aucune", "Client", "Fournisseur", "Salarié", "Banque", "Caisse", "Amortissement/Provision", "Résultat bilan", "Charge", "Produit"})
        Me.Cb_NatCptes.Location = New System.Drawing.Point(117, 88)
        Me.Cb_NatCptes.Name = "Cb_NatCptes"
        Me.Cb_NatCptes.Size = New System.Drawing.Size(167, 24)
        Me.Cb_NatCptes.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nature de Compte"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Comptes tiers rattachés :"
        '
        'DGCpteTiers
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGCpteTiers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGCpteTiers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGCpteTiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCpteTiers.Location = New System.Drawing.Point(15, 132)
        Me.DGCpteTiers.MultiSelect = False
        Me.DGCpteTiers.Name = "DGCpteTiers"
        Me.DGCpteTiers.ReadOnly = True
        Me.DGCpteTiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCpteTiers.Size = New System.Drawing.Size(339, 98)
        Me.DGCpteTiers.TabIndex = 10
        '
        'Cb_CpteTiers
        '
        Me.Cb_CpteTiers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cb_CpteTiers.FormattingEnabled = True
        Me.Cb_CpteTiers.Location = New System.Drawing.Point(15, 236)
        Me.Cb_CpteTiers.Name = "Cb_CpteTiers"
        Me.Cb_CpteTiers.Size = New System.Drawing.Size(137, 24)
        Me.Cb_CpteTiers.TabIndex = 12
        '
        'TbNumCompte
        '
        Me.TbNumCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TbNumCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumCompte.Location = New System.Drawing.Point(117, 24)
        Me.TbNumCompte.Name = "TbNumCompte"
        Me.TbNumCompte.Size = New System.Drawing.Size(151, 22)
        Me.TbNumCompte.TabIndex = 13
        '
        'Frm_PCFiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 275)
        Me.Controls.Add(Me.TbNumCompte)
        Me.Controls.Add(Me.Cb_CpteTiers)
        Me.Controls.Add(Me.DGCpteTiers)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cb_NatCptes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TbIntituleCpte)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cb_typeCpte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PCFiche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compte "
        CType(Me.DGCpteTiers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb_typeCpte As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TbIntituleCpte As System.Windows.Forms.TextBox
    Friend WithEvents Cb_NatCptes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGCpteTiers As System.Windows.Forms.DataGridView
    Friend WithEvents Cb_CpteTiers As UTCombo.MultiColCombo
    Friend WithEvents TbNumCompte As System.Windows.Forms.TextBox
End Class
