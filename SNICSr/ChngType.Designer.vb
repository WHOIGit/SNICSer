<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChngType
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
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblSampleID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSmpName = New System.Windows.Forms.TextBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBatch = New System.Windows.Forms.Button()
        Me.lbxFrom = New System.Windows.Forms.ListBox()
        Me.lbxTo = New System.Windows.Forms.ListBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnChange
        '
        Me.btnChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChange.Location = New System.Drawing.Point(14, 187)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(91, 36)
        Me.btnChange.TabIndex = 0
        Me.btnChange.Text = "Change"
        Me.btnChange.UseVisualStyleBackColor = False
        Me.btnChange.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(129, 187)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblSampleID
        '
        Me.lblSampleID.AutoSize = True
        Me.lblSampleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampleID.Location = New System.Drawing.Point(32, 41)
        Me.lblSampleID.Name = "lblSampleID"
        Me.lblSampleID.Size = New System.Drawing.Size(166, 20)
        Me.lblSampleID.TabIndex = 2
        Me.lblSampleID.Text = "Sample Information"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "So You Wish to Change Sample Information for"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(154, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(295, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Type"
        '
        'txtSmpName
        '
        Me.txtSmpName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSmpName.Location = New System.Drawing.Point(75, 107)
        Me.txtSmpName.Name = "txtSmpName"
        Me.txtSmpName.Size = New System.Drawing.Size(173, 22)
        Me.txtSmpName.TabIndex = 7
        '
        'cmbType
        '
        Me.cmbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"S", "B", "SS", "U"})
        Me.cmbType.Location = New System.Drawing.Point(348, 105)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(51, 24)
        Me.cmbType.TabIndex = 8
        '
        'txtComment
        '
        Me.txtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Location = New System.Drawing.Point(8, 159)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(419, 22)
        Me.txtComment.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(12, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(356, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "... or add/change a comment for this target "
        '
        'btnBatch
        '
        Me.btnBatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatch.Location = New System.Drawing.Point(246, 187)
        Me.btnBatch.Name = "btnBatch"
        Me.btnBatch.Size = New System.Drawing.Size(176, 36)
        Me.btnBatch.TabIndex = 11
        Me.btnBatch.Text = "Batch Change ==>"
        Me.btnBatch.UseVisualStyleBackColor = False
        '
        'lbxFrom
        '
        Me.lbxFrom.FormattingEnabled = True
        Me.lbxFrom.Location = New System.Drawing.Point(468, 23)
        Me.lbxFrom.Name = "lbxFrom"
        Me.lbxFrom.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbxFrom.Size = New System.Drawing.Size(150, 199)
        Me.lbxFrom.Sorted = True
        Me.lbxFrom.TabIndex = 12
        Me.lbxFrom.TabStop = False
        '
        'lbxTo
        '
        Me.lbxTo.FormattingEnabled = True
        Me.lbxTo.Location = New System.Drawing.Point(627, 24)
        Me.lbxTo.Name = "lbxTo"
        Me.lbxTo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbxTo.Size = New System.Drawing.Size(150, 160)
        Me.lbxTo.Sorted = True
        Me.lbxTo.TabIndex = 13
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.ForeColor = System.Drawing.Color.DarkRed
        Me.lblFrom.Location = New System.Drawing.Point(470, 0)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(70, 20)
        Me.lblFrom.TabIndex = 14
        Me.lblFrom.Text = "Choose"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTo.Location = New System.Drawing.Point(630, 1)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(71, 20)
        Me.lblTo.TabIndex = 15
        Me.lblTo.Text = "Change"
        '
        'btnExecute
        '
        Me.btnExecute.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExecute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(653, 190)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(99, 29)
        Me.btnExecute.TabIndex = 18
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.UseVisualStyleBackColor = False
        Me.btnExecute.Visible = False
        '
        'ChngType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 229)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lbxTo)
        Me.Controls.Add(Me.lbxFrom)
        Me.Controls.Add(Me.btnBatch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.txtSmpName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSampleID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnChange)
        Me.Name = "ChngType"
        Me.Text = "Change Sample I.D."
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblSampleID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSmpName As System.Windows.Forms.TextBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBatch As System.Windows.Forms.Button
    Friend WithEvents lbxFrom As System.Windows.Forms.ListBox
    Friend WithEvents lbxTo As System.Windows.Forms.ListBox
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
End Class
