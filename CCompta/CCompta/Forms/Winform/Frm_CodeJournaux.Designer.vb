<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CodeJournaux
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGCJ = New System.Windows.Forms.DataGridView()
        Me.CtxtMenuStripCJ = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AjouterUnCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCpteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelCpteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGPlanComptable = New System.Windows.Forms.DataGridView()
        CType(Me.DGCJ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CtxtMenuStripCJ.SuspendLayout()
        CType(Me.DGPlanComptable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGCJ
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGCJ.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGCJ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGCJ.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGCJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCJ.ContextMenuStrip = Me.CtxtMenuStripCJ
        Me.DGCJ.Location = New System.Drawing.Point(12, 12)
        Me.DGCJ.MultiSelect = False
        Me.DGCJ.Name = "DGCJ"
        Me.DGCJ.ReadOnly = True
        Me.DGCJ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCJ.Size = New System.Drawing.Size(628, 211)
        Me.DGCJ.TabIndex = 1
        '
        'CtxtMenuStripCJ
        '
        Me.CtxtMenuStripCJ.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjouterUnCompteToolStripMenuItem, Me.UpdateCpteToolStripMenuItem, Me.DelCpteToolStripMenuItem})
        Me.CtxtMenuStripCJ.Name = "CtxtMenuStripPC"
        Me.CtxtMenuStripCJ.Size = New System.Drawing.Size(312, 70)
        '
        'AjouterUnCompteToolStripMenuItem
        '
        Me.AjouterUnCompteToolStripMenuItem.Image = Global.CCompta.My.Resources.Resources.add32
        Me.AjouterUnCompteToolStripMenuItem.Name = "AjouterUnCompteToolStripMenuItem"
        Me.AjouterUnCompteToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.AjouterUnCompteToolStripMenuItem.Text = "Ajouter Un Compte de tiers"
        '
        'UpdateCpteToolStripMenuItem
        '
        Me.UpdateCpteToolStripMenuItem.Image = Global.CCompta.My.Resources.Resources.edit32
        Me.UpdateCpteToolStripMenuItem.Name = "UpdateCpteToolStripMenuItem"
        Me.UpdateCpteToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.UpdateCpteToolStripMenuItem.Text = "Modifier / Voir le compte de tiers sélectionné"
        '
        'DelCpteToolStripMenuItem
        '
        Me.DelCpteToolStripMenuItem.Image = Global.CCompta.My.Resources.Resources.delele32
        Me.DelCpteToolStripMenuItem.Name = "DelCpteToolStripMenuItem"
        Me.DelCpteToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.DelCpteToolStripMenuItem.Text = "Supprimer le compte de tiers sélectionné"
        '
        'DGPlanComptable
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGPlanComptable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGPlanComptable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGPlanComptable.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGPlanComptable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPlanComptable.Location = New System.Drawing.Point(12, 12)
        Me.DGPlanComptable.MultiSelect = False
        Me.DGPlanComptable.Name = "DGPlanComptable"
        Me.DGPlanComptable.ReadOnly = True
        Me.DGPlanComptable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPlanComptable.Size = New System.Drawing.Size(896, 354)
        Me.DGPlanComptable.TabIndex = 1
        '
        'Frm_CodeJournaux
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 235)
        Me.Controls.Add(Me.DGCJ)
        Me.Name = "Frm_CodeJournaux"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Codes Journaux"
        CType(Me.DGCJ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CtxtMenuStripCJ.ResumeLayout(False)
        CType(Me.DGPlanComptable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGCJ As System.Windows.Forms.DataGridView
    Friend WithEvents DGPlanComptable As System.Windows.Forms.DataGridView
    Friend WithEvents CtxtMenuStripCJ As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AjouterUnCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateCpteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelCpteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
