<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GroupMerge
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
        Me.lbxGroups = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudGroup = New System.Windows.Forms.NumericUpDown()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.lblPatience = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnMergeAll = New System.Windows.Forms.Button()
        CType(Me.nudGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbxGroups
        '
        Me.lbxGroups.BackColor = System.Drawing.Color.White
        Me.lbxGroups.FormattingEnabled = True
        Me.lbxGroups.Location = New System.Drawing.Point(121, 1)
        Me.lbxGroups.Name = "lbxGroups"
        Me.lbxGroups.Size = New System.Drawing.Size(236, 121)
        Me.lbxGroups.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 48)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Group " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to Merge with " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previous Group"
        '
        'nudGroup
        '
        Me.nudGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudGroup.Location = New System.Drawing.Point(29, 72)
        Me.nudGroup.Name = "nudGroup"
        Me.nudGroup.Size = New System.Drawing.Size(46, 26)
        Me.nudGroup.TabIndex = 2
        Me.nudGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMerge
        '
        Me.btnMerge.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMerge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMerge.Location = New System.Drawing.Point(8, 119)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(89, 36)
        Me.btnMerge.TabIndex = 3
        Me.btnMerge.Text = "Merge"
        Me.btnMerge.UseVisualStyleBackColor = False
        '
        'lblPatience
        '
        Me.lblPatience.AutoSize = True
        Me.lblPatience.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatience.Location = New System.Drawing.Point(123, 125)
        Me.lblPatience.Name = "lblPatience"
        Me.lblPatience.Size = New System.Drawing.Size(55, 16)
        Me.lblPatience.TabIndex = 4
        Me.lblPatience.Text = "Label2"
        Me.lblPatience.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(268, 129)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnMergeAll
        '
        Me.btnMergeAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMergeAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMergeAll.Location = New System.Drawing.Point(103, 127)
        Me.btnMergeAll.Name = "btnMergeAll"
        Me.btnMergeAll.Size = New System.Drawing.Size(159, 28)
        Me.btnMergeAll.TabIndex = 6
        Me.btnMergeAll.Text = "Merge all Groups"
        Me.btnMergeAll.UseVisualStyleBackColor = False
        '
        'GroupMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(358, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnMergeAll)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblPatience)
        Me.Controls.Add(Me.btnMerge)
        Me.Controls.Add(Me.nudGroup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbxGroups)
        Me.Name = "GroupMerge"
        Me.Text = "SNICSer Group Merge"
        Me.TopMost = True
        CType(Me.nudGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbxGroups As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudGroup As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents lblPatience As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnMergeAll As System.Windows.Forms.Button
End Class
