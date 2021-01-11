<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Compare
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvCompare = New System.Windows.Forms.DataGridView()
        Me.lblComparison = New System.Windows.Forms.Label()
        Me.btnSaveToFile = New System.Windows.Forms.Button()
        Me.btnSaveToClipboard = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lblFirstAnalyst = New System.Windows.Forms.Label()
        Me.lblSecondAnalyst = New System.Windows.Forms.Label()
        Me.cmbCompare = New System.Windows.Forms.ComboBox()
        CType(Me.dgvCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCompare
        '
        Me.dgvCompare.AllowUserToAddRows = False
        Me.dgvCompare.AllowUserToDeleteRows = False
        Me.dgvCompare.AllowUserToOrderColumns = True
        Me.dgvCompare.AllowUserToResizeColumns = False
        Me.dgvCompare.AllowUserToResizeRows = False
        Me.dgvCompare.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompare.Location = New System.Drawing.Point(0, 78)
        Me.dgvCompare.Name = "dgvCompare"
        Me.dgvCompare.ReadOnly = True
        Me.dgvCompare.RowHeadersVisible = False
        Me.dgvCompare.Size = New System.Drawing.Size(1130, 685)
        Me.dgvCompare.TabIndex = 0
        '
        'lblComparison
        '
        Me.lblComparison.AutoSize = True
        Me.lblComparison.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComparison.Location = New System.Drawing.Point(0, 0)
        Me.lblComparison.Name = "lblComparison"
        Me.lblComparison.Size = New System.Drawing.Size(112, 24)
        Me.lblComparison.TabIndex = 1
        Me.lblComparison.Text = "Comparison"
        '
        'btnSaveToFile
        '
        Me.btnSaveToFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveToFile.Location = New System.Drawing.Point(1006, 49)
        Me.btnSaveToFile.Name = "btnSaveToFile"
        Me.btnSaveToFile.Size = New System.Drawing.Size(124, 23)
        Me.btnSaveToFile.TabIndex = 2
        Me.btnSaveToFile.Text = "Save to File"
        Me.btnSaveToFile.UseVisualStyleBackColor = True
        '
        'btnSaveToClipboard
        '
        Me.btnSaveToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveToClipboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveToClipboard.Location = New System.Drawing.Point(968, 6)
        Me.btnSaveToClipboard.Name = "btnSaveToClipboard"
        Me.btnSaveToClipboard.Size = New System.Drawing.Size(162, 23)
        Me.btnSaveToClipboard.TabIndex = 3
        Me.btnSaveToClipboard.Text = "Save to ClipBoard"
        Me.btnSaveToClipboard.UseVisualStyleBackColor = True
        '
        'lblFirstAnalyst
        '
        Me.lblFirstAnalyst.AutoSize = True
        Me.lblFirstAnalyst.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstAnalyst.Location = New System.Drawing.Point(350, 22)
        Me.lblFirstAnalyst.Name = "lblFirstAnalyst"
        Me.lblFirstAnalyst.Size = New System.Drawing.Size(98, 24)
        Me.lblFirstAnalyst.TabIndex = 4
        Me.lblFirstAnalyst.Text = "1st Analyst"
        '
        'lblSecondAnalyst
        '
        Me.lblSecondAnalyst.AutoSize = True
        Me.lblSecondAnalyst.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondAnalyst.Location = New System.Drawing.Point(350, 46)
        Me.lblSecondAnalyst.Name = "lblSecondAnalyst"
        Me.lblSecondAnalyst.Size = New System.Drawing.Size(107, 24)
        Me.lblSecondAnalyst.TabIndex = 5
        Me.lblSecondAnalyst.Text = "2nd Analyst"
        '
        'cmbCompare
        '
        Me.cmbCompare.FormattingEnabled = True
        Me.cmbCompare.Items.AddRange(New Object() {"Current vs. 1st Analyst", "Current vs. 2nd Analyst", "1st Analyst vs. 2nd Analyst"})
        Me.cmbCompare.Location = New System.Drawing.Point(4, 27)
        Me.cmbCompare.Name = "cmbCompare"
        Me.cmbCompare.Size = New System.Drawing.Size(283, 21)
        Me.cmbCompare.TabIndex = 6
        '
        'Compare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 763)
        Me.Controls.Add(Me.cmbCompare)
        Me.Controls.Add(Me.lblSecondAnalyst)
        Me.Controls.Add(Me.lblFirstAnalyst)
        Me.Controls.Add(Me.btnSaveToClipboard)
        Me.Controls.Add(Me.btnSaveToFile)
        Me.Controls.Add(Me.lblComparison)
        Me.Controls.Add(Me.dgvCompare)
        Me.Name = "Compare"
        Me.Text = "SNICSer Compare"
        CType(Me.dgvCompare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCompare As System.Windows.Forms.DataGridView
    Friend WithEvents lblComparison As System.Windows.Forms.Label
    Friend WithEvents btnSaveToFile As System.Windows.Forms.Button
    Friend WithEvents btnSaveToClipboard As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblFirstAnalyst As System.Windows.Forms.Label
    Friend WithEvents lblSecondAnalyst As System.Windows.Forms.Label
    Friend WithEvents cmbCompare As ComboBox
End Class
