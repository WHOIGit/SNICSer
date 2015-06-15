<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartial
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
        Me.nudFrom = New System.Windows.Forms.NumericUpDown()
        Me.nudTo = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.rdb1 = New System.Windows.Forms.RadioButton()
        Me.rdb2 = New System.Windows.Forms.RadioButton()
        CType(Me.nudFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudFrom
        '
        Me.nudFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudFrom.Location = New System.Drawing.Point(60, 81)
        Me.nudFrom.Maximum = New Decimal(New Integer() {133, 0, 0, 0})
        Me.nudFrom.Name = "nudFrom"
        Me.nudFrom.Size = New System.Drawing.Size(67, 22)
        Me.nudFrom.TabIndex = 0
        Me.nudFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudTo
        '
        Me.nudTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTo.Location = New System.Drawing.Point(164, 81)
        Me.nudTo.Maximum = New Decimal(New Integer() {133, 0, 0, 0})
        Me.nudTo.Name = "nudTo"
        Me.nudTo.Size = New System.Drawing.Size(67, 22)
        Me.nudTo.TabIndex = 1
        Me.nudTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudTo.Value = New Decimal(New Integer() {133, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Partial Wheel Range"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(133, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(104, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "(inclusive)"
        '
        'btnExecute
        '
        Me.btnExecute.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExecute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(17, 131)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(81, 25)
        Me.btnExecute.TabIndex = 6
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(141, 131)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'rdb1
        '
        Me.rdb1.AutoSize = True
        Me.rdb1.Checked = True
        Me.rdb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb1.Location = New System.Drawing.Point(30, 42)
        Me.rdb1.Name = "rdb1"
        Me.rdb1.Size = New System.Drawing.Size(94, 20)
        Me.rdb1.TabIndex = 8
        Me.rdb1.TabStop = True
        Me.rdb1.Text = "By Target"
        Me.rdb1.UseVisualStyleBackColor = True
        '
        'rdb2
        '
        Me.rdb2.AutoSize = True
        Me.rdb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb2.Location = New System.Drawing.Point(147, 42)
        Me.rdb2.Name = "rdb2"
        Me.rdb2.Size = New System.Drawing.Size(75, 20)
        Me.rdb2.TabIndex = 9
        Me.rdb2.Text = "By Run"
        Me.rdb2.UseVisualStyleBackColor = True
        '
        'frmPartial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 168)
        Me.ControlBox = False
        Me.Controls.Add(Me.rdb2)
        Me.Controls.Add(Me.rdb1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudTo)
        Me.Controls.Add(Me.nudFrom)
        Me.Name = "frmPartial"
        Me.Text = "Partial Wheel Selection"
        CType(Me.nudFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudFrom As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudTo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb2 As System.Windows.Forms.RadioButton
End Class
