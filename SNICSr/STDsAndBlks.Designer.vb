<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StdsAndBlks
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
        Me.dgvBlanks = New System.Windows.Forms.DataGridView()
        Me.dgvStandards = New System.Windows.Forms.DataGridView()
        Me.lblBlks = New System.Windows.Forms.Label()
        Me.lblStds = New System.Windows.Forms.Label()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.cmbExternal = New System.Windows.Forms.ComboBox()
        Me.lblExternal = New System.Windows.Forms.Label()
        Me.btnFill = New System.Windows.Forms.Button()
        CType(Me.dgvBlanks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStandards, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBlanks
        '
        Me.dgvBlanks.AllowUserToAddRows = False
        Me.dgvBlanks.AllowUserToDeleteRows = False
        Me.dgvBlanks.AllowUserToResizeColumns = False
        Me.dgvBlanks.AllowUserToResizeRows = False
        Me.dgvBlanks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBlanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlanks.Location = New System.Drawing.Point(3, 255)
        Me.dgvBlanks.Name = "dgvBlanks"
        Me.dgvBlanks.RowHeadersWidth = 20
        Me.dgvBlanks.Size = New System.Drawing.Size(565, 288)
        Me.dgvBlanks.TabIndex = 22
        '
        'dgvStandards
        '
        Me.dgvStandards.AllowUserToAddRows = False
        Me.dgvStandards.AllowUserToDeleteRows = False
        Me.dgvStandards.AllowUserToResizeColumns = False
        Me.dgvStandards.AllowUserToResizeRows = False
        Me.dgvStandards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvStandards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStandards.Location = New System.Drawing.Point(3, 28)
        Me.dgvStandards.Name = "dgvStandards"
        Me.dgvStandards.ReadOnly = True
        Me.dgvStandards.RowHeadersWidth = 20
        Me.dgvStandards.Size = New System.Drawing.Size(565, 202)
        Me.dgvStandards.TabIndex = 21
        '
        'lblBlks
        '
        Me.lblBlks.AutoSize = True
        Me.lblBlks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlks.Location = New System.Drawing.Point(7, 236)
        Me.lblBlks.Name = "lblBlks"
        Me.lblBlks.Size = New System.Drawing.Size(55, 16)
        Me.lblBlks.TabIndex = 25
        Me.lblBlks.Text = "Blanks"
        '
        'lblStds
        '
        Me.lblStds.AutoSize = True
        Me.lblStds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStds.Location = New System.Drawing.Point(12, 9)
        Me.lblStds.Name = "lblStds"
        Me.lblStds.Size = New System.Drawing.Size(79, 16)
        Me.lblStds.TabIndex = 24
        Me.lblStds.Text = "Standards"
        '
        'btnDone
        '
        Me.btnDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDone.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(503, 0)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(77, 25)
        Me.btnDone.TabIndex = 26
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = False
        '
        'cmbExternal
        '
        Me.cmbExternal.FormattingEnabled = True
        Me.cmbExternal.Location = New System.Drawing.Point(268, 3)
        Me.cmbExternal.Name = "cmbExternal"
        Me.cmbExternal.Size = New System.Drawing.Size(79, 21)
        Me.cmbExternal.TabIndex = 27
        Me.cmbExternal.Visible = False
        '
        'lblExternal
        '
        Me.lblExternal.AutoSize = True
        Me.lblExternal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExternal.Location = New System.Drawing.Point(165, 5)
        Me.lblExternal.Name = "lblExternal"
        Me.lblExternal.Size = New System.Drawing.Size(99, 16)
        Me.lblExternal.TabIndex = 28
        Me.lblExternal.Text = "Externals are"
        Me.lblExternal.Visible = False
        '
        'btnFill
        '
        Me.btnFill.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnFill.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFill.Location = New System.Drawing.Point(349, 2)
        Me.btnFill.Name = "btnFill"
        Me.btnFill.Size = New System.Drawing.Size(75, 23)
        Me.btnFill.TabIndex = 29
        Me.btnFill.Text = "Fill In"
        Me.btnFill.UseVisualStyleBackColor = False
        Me.btnFill.Visible = False
        '
        'StdsAndBlks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnFill)
        Me.Controls.Add(Me.lblExternal)
        Me.Controls.Add(Me.cmbExternal)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.lblBlks)
        Me.Controls.Add(Me.lblStds)
        Me.Controls.Add(Me.dgvBlanks)
        Me.Controls.Add(Me.dgvStandards)
        Me.Name = "StdsAndBlks"
        Me.Text = "Standards and Blanks"
        CType(Me.dgvBlanks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStandards, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBlanks As System.Windows.Forms.DataGridView
    Friend WithEvents dgvStandards As System.Windows.Forms.DataGridView
    Friend WithEvents lblBlks As System.Windows.Forms.Label
    Friend WithEvents lblStds As System.Windows.Forms.Label
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents cmbExternal As System.Windows.Forms.ComboBox
    Friend WithEvents lblExternal As System.Windows.Forms.Label
    Friend WithEvents btnFill As System.Windows.Forms.Button
End Class
