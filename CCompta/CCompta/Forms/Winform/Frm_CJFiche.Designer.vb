﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CJFiche
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
        Me.Cb_TypeJ = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TbCodej = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tb_IntituleJ = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cb_CpteTreso = New UTCombo.MultiColCombo(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Cb_TypeJ
        '
        Me.Cb_TypeJ.Enabled = False
        Me.Cb_TypeJ.FormattingEnabled = True
        Me.Cb_TypeJ.Items.AddRange(New Object() {"Achats", "Ventes", "Trésoreries", "Général", "Situation"})
        Me.Cb_TypeJ.Location = New System.Drawing.Point(339, 29)
        Me.Cb_TypeJ.Name = "Cb_TypeJ"
        Me.Cb_TypeJ.Size = New System.Drawing.Size(138, 21)
        Me.Cb_TypeJ.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(298, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Type"
        '
        'TbCodej
        '
        Me.TbCodej.Enabled = False
        Me.TbCodej.Location = New System.Drawing.Point(121, 29)
        Me.TbCodej.Name = "TbCodej"
        Me.TbCodej.Size = New System.Drawing.Size(169, 20)
        Me.TbCodej.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Code"
        '
        'Tb_IntituleJ
        '
        Me.Tb_IntituleJ.Location = New System.Drawing.Point(121, 56)
        Me.Tb_IntituleJ.Name = "Tb_IntituleJ"
        Me.Tb_IntituleJ.Size = New System.Drawing.Size(356, 20)
        Me.Tb_IntituleJ.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Intitulé"
        '
        'Cb_CpteTreso
        '
        Me.Cb_CpteTreso.Enabled = False
        Me.Cb_CpteTreso.FormattingEnabled = True
        Me.Cb_CpteTreso.Location = New System.Drawing.Point(121, 82)
        Me.Cb_CpteTreso.Name = "Cb_CpteTreso"
        Me.Cb_CpteTreso.Size = New System.Drawing.Size(146, 21)
        Me.Cb_CpteTreso.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Compte de trésorerie"
        '
        'Frm_CJFiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 134)
        Me.Controls.Add(Me.Cb_CpteTreso)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tb_IntituleJ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cb_TypeJ)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TbCodej)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CJFiche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code Journal :"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cb_TypeJ As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TbCodej As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tb_IntituleJ As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb_CpteTreso As UTCombo.MultiColCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
