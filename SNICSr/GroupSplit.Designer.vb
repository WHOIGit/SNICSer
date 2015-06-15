<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GroupSplit
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
        Me.lblPrompt = New System.Windows.Forms.Label()
        Me.nudSplit = New System.Windows.Forms.NumericUpDown()
        Me.btnSplit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dgvSplit = New System.Windows.Forms.DataGridView()
        CType(Me.nudSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPrompt
        '
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.Location = New System.Drawing.Point(12, 9)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(465, 20)
        Me.lblPrompt.TabIndex = 0
        Me.lblPrompt.Text = "Select Run Number Where New Group Starts,  Then Press Enter"
        '
        'nudSplit
        '
        Me.nudSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSplit.Location = New System.Drawing.Point(506, 4)
        Me.nudSplit.Name = "nudSplit"
        Me.nudSplit.Size = New System.Drawing.Size(120, 29)
        Me.nudSplit.TabIndex = 1
        Me.nudSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSplit
        '
        Me.btnSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSplit.Location = New System.Drawing.Point(732, 4)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.Size = New System.Drawing.Size(100, 32)
        Me.btnSplit.TabIndex = 2
        Me.btnSplit.Text = "Split"
        Me.btnSplit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(872, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'dgvSplit
        '
        Me.dgvSplit.AllowUserToAddRows = False
        Me.dgvSplit.AllowUserToDeleteRows = False
        Me.dgvSplit.AllowUserToResizeColumns = False
        Me.dgvSplit.AllowUserToResizeRows = False
        Me.dgvSplit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSplit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSplit.Location = New System.Drawing.Point(-1, 40)
        Me.dgvSplit.Name = "dgvSplit"
        Me.dgvSplit.Size = New System.Drawing.Size(984, 219)
        Me.dgvSplit.TabIndex = 4
        '
        'GroupSplit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 259)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvSplit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSplit)
        Me.Controls.Add(Me.nudSplit)
        Me.Controls.Add(Me.lblPrompt)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "GroupSplit"
        Me.Text = "Group Split"
        Me.TopMost = True
        CType(Me.nudSplit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents nudSplit As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSplit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dgvSplit As System.Windows.Forms.DataGridView
End Class
