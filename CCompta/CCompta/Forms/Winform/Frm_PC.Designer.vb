<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PC
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
        Me.DGPlanComptable = New System.Windows.Forms.DataGridView()
        Me.CtxtMenuStripPC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AjouterUnCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCpteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelCpteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DGPlanComptable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CtxtMenuStripPC.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGPlanComptable
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGPlanComptable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGPlanComptable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGPlanComptable.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGPlanComptable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPlanComptable.ContextMenuStrip = Me.CtxtMenuStripPC
        Me.DGPlanComptable.Location = New System.Drawing.Point(12, 23)
        Me.DGPlanComptable.MultiSelect = False
        Me.DGPlanComptable.Name = "DGPlanComptable"
        Me.DGPlanComptable.ReadOnly = True
        Me.DGPlanComptable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPlanComptable.Size = New System.Drawing.Size(931, 287)
        Me.DGPlanComptable.TabIndex = 0
        '
        'CtxtMenuStripPC
        '
        Me.CtxtMenuStripPC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjouterUnCompteToolStripMenuItem, Me.UpdateCpteToolStripMenuItem, Me.DelCpteToolStripMenuItem})
        Me.CtxtMenuStripPC.Name = "CtxtMenuStripPC"
        Me.CtxtMenuStripPC.Size = New System.Drawing.Size(300, 70)
        '
        'AjouterUnCompteToolStripMenuItem
        '
        Me.AjouterUnCompteToolStripMenuItem.Image = Global.CCompta.My.Resources.Resources.add32
        Me.AjouterUnCompteToolStripMenuItem.Name = "AjouterUnCompteToolStripMenuItem"
        Me.AjouterUnCompteToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.AjouterUnCompteToolStripMenuItem.Text = "Ajouter Un Compte"
        '
        'UpdateCpteToolStripMenuItem
        '
        Me.UpdateCpteToolStripMenuItem.Image = Global.CCompta.My.Resources.Resources.edit32
        Me.UpdateCpteToolStripMenuItem.Name = "UpdateCpteToolStripMenuItem"
        Me.UpdateCpteToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.UpdateCpteToolStripMenuItem.Text = "Modifier / Voir le compte sélectionné"
        '
        'DelCpteToolStripMenuItem
        '
        Me.DelCpteToolStripMenuItem.Image = Global.CCompta.My.Resources.Resources.delele32
        Me.DelCpteToolStripMenuItem.Name = "DelCpteToolStripMenuItem"
        Me.DelCpteToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.DelCpteToolStripMenuItem.Text = "Supprimer le compte sélectionné"
        '
        'Frm_PC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 322)
        Me.Controls.Add(Me.DGPlanComptable)
        Me.Name = "Frm_PC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan Comptable"
        CType(Me.DGPlanComptable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CtxtMenuStripPC.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGPlanComptable As System.Windows.Forms.DataGridView
    Friend WithEvents CtxtMenuStripPC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AjouterUnCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateCpteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelCpteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
