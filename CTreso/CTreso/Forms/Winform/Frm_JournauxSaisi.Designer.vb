<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_JournauxSaisi
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGCJ = New System.Windows.Forms.DataGridView()
        Me.DGPlanComptable = New System.Windows.Forms.DataGridView()
        CType(Me.DGCJ, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DGCJ.Location = New System.Drawing.Point(12, 12)
        Me.DGCJ.MultiSelect = False
        Me.DGCJ.Name = "DGCJ"
        Me.DGCJ.ReadOnly = True
        Me.DGCJ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCJ.Size = New System.Drawing.Size(628, 211)
        Me.DGCJ.TabIndex = 1
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
        'Frm_JournauxSaisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 235)
        Me.Controls.Add(Me.DGCJ)
        Me.Name = "Frm_JournauxSaisi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journaux de Saisie"
        CType(Me.DGCJ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGPlanComptable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGCJ As System.Windows.Forms.DataGridView
    Friend WithEvents DGPlanComptable As System.Windows.Forms.DataGridView
End Class
