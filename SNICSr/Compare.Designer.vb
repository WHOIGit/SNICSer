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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSecond = New System.Windows.Forms.Label()
        Me.lblFirst = New System.Windows.Forms.Label()
        Me.dgvFlags = New System.Windows.Forms.DataGridView()
        Me.cbUseBCFm = New System.Windows.Forms.CheckBox()
        CType(Me.dgvCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFlags, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvCompare.Location = New System.Drawing.Point(4, 73)
        Me.dgvCompare.Name = "dgvCompare"
        Me.dgvCompare.ReadOnly = True
        Me.dgvCompare.RowHeadersVisible = False
        Me.dgvCompare.Size = New System.Drawing.Size(843, 685)
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
        Me.btnSaveToFile.Location = New System.Drawing.Point(1318, 35)
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
        Me.btnSaveToClipboard.Location = New System.Drawing.Point(1280, 6)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SeaShell
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(1217, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Both Accepted"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(935, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Both Rejected"
        '
        'lblSecond
        '
        Me.lblSecond.AutoSize = True
        Me.lblSecond.BackColor = System.Drawing.Color.Blue
        Me.lblSecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecond.ForeColor = System.Drawing.Color.White
        Me.lblSecond.Location = New System.Drawing.Point(1121, 52)
        Me.lblSecond.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSecond.Name = "lblSecond"
        Me.lblSecond.Size = New System.Drawing.Size(92, 17)
        Me.lblSecond.TabIndex = 9
        Me.lblSecond.Text = "2nd Rejected"
        '
        'lblFirst
        '
        Me.lblFirst.AutoSize = True
        Me.lblFirst.BackColor = System.Drawing.Color.Red
        Me.lblFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirst.ForeColor = System.Drawing.Color.White
        Me.lblFirst.Location = New System.Drawing.Point(1032, 52)
        Me.lblFirst.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(87, 17)
        Me.lblFirst.TabIndex = 8
        Me.lblFirst.Text = "1st Rejected"
        '
        'dgvFlags
        '
        Me.dgvFlags.AllowUserToAddRows = False
        Me.dgvFlags.AllowUserToDeleteRows = False
        Me.dgvFlags.AllowUserToResizeColumns = False
        Me.dgvFlags.AllowUserToResizeRows = False
        Me.dgvFlags.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFlags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvFlags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFlags.Location = New System.Drawing.Point(936, 73)
        Me.dgvFlags.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvFlags.Name = "dgvFlags"
        Me.dgvFlags.RowHeadersVisible = False
        Me.dgvFlags.RowTemplate.Height = 28
        Me.dgvFlags.Size = New System.Drawing.Size(309, 685)
        Me.dgvFlags.TabIndex = 7
        '
        'cbUseBCFm
        '
        Me.cbUseBCFm.AutoSize = True
        Me.cbUseBCFm.Checked = True
        Me.cbUseBCFm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbUseBCFm.Location = New System.Drawing.Point(4, 53)
        Me.cbUseBCFm.Name = "cbUseBCFm"
        Me.cbUseBCFm.Size = New System.Drawing.Size(156, 17)
        Me.cbUseBCFm.TabIndex = 12
        Me.cbUseBCFm.Text = "Use blank corrected values"
        Me.cbUseBCFm.UseVisualStyleBackColor = True
        '
        'Compare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1445, 763)
        Me.Controls.Add(Me.cbUseBCFm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSecond)
        Me.Controls.Add(Me.lblFirst)
        Me.Controls.Add(Me.dgvFlags)
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
        CType(Me.dgvFlags, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSecond As Label
    Friend WithEvents lblFirst As Label
    Friend WithEvents dgvFlags As DataGridView
    Friend WithEvents cbUseBCFm As CheckBox
End Class
