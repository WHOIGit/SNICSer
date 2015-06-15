<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.lblTP_Comment = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblRecNum = New System.Windows.Forms.Label()
        Me.lblTP_Num = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblRec_Date = New System.Windows.Forms.Label()
        Me.lblSampleID = New System.Windows.Forms.Label()
        Me.lblProcType = New System.Windows.Forms.Label()
        Me.lblSampleSize = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(73, 25)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(120, 20)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Sample Name"
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientName.Location = New System.Drawing.Point(24, 110)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(91, 16)
        Me.lblClientName.TabIndex = 1
        Me.lblClientName.Text = "Client Name ="
        '
        'lblTP_Comment
        '
        Me.lblTP_Comment.AutoSize = True
        Me.lblTP_Comment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTP_Comment.Location = New System.Drawing.Point(141, 82)
        Me.lblTP_Comment.Name = "lblTP_Comment"
        Me.lblTP_Comment.Size = New System.Drawing.Size(146, 16)
        Me.lblTP_Comment.TabIndex = 2
        Me.lblTP_Comment.Text = "Target Press Comment"
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.Location = New System.Drawing.Point(79, 9)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(116, 16)
        Me.lblPosition.TabIndex = 3
        Me.lblPosition.Text = "Position on Wheel"
        '
        'lblRecNum
        '
        Me.lblRecNum.AutoSize = True
        Me.lblRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecNum.Location = New System.Drawing.Point(76, 54)
        Me.lblRecNum.Name = "lblRecNum"
        Me.lblRecNum.Size = New System.Drawing.Size(78, 16)
        Me.lblRecNum.TabIndex = 4
        Me.lblRecNum.Text = "Rec_Num ="
        '
        'lblTP_Num
        '
        Me.lblTP_Num.AutoSize = True
        Me.lblTP_Num.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTP_Num.Location = New System.Drawing.Point(24, 82)
        Me.lblTP_Num.Name = "lblTP_Num"
        Me.lblTP_Num.Size = New System.Drawing.Size(71, 16)
        Me.lblTP_Num.TabIndex = 5
        Me.lblTP_Num.Text = "TP_Num ="
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(24, 311)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 24)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblRec_Date
        '
        Me.lblRec_Date.AutoSize = True
        Me.lblRec_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRec_Date.Location = New System.Drawing.Point(24, 166)
        Me.lblRec_Date.Name = "lblRec_Date"
        Me.lblRec_Date.Size = New System.Drawing.Size(79, 16)
        Me.lblRec_Date.TabIndex = 8
        Me.lblRec_Date.Text = "Rec_Date ="
        '
        'lblSampleID
        '
        Me.lblSampleID.AutoSize = True
        Me.lblSampleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampleID.Location = New System.Drawing.Point(24, 138)
        Me.lblSampleID.Name = "lblSampleID"
        Me.lblSampleID.Size = New System.Drawing.Size(75, 16)
        Me.lblSampleID.TabIndex = 9
        Me.lblSampleID.Text = "Sample_ID"
        '
        'lblProcType
        '
        Me.lblProcType.AutoSize = True
        Me.lblProcType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcType.Location = New System.Drawing.Point(24, 194)
        Me.lblProcType.Name = "lblProcType"
        Me.lblProcType.Size = New System.Drawing.Size(78, 16)
        Me.lblProcType.TabIndex = 10
        Me.lblProcType.Text = "ProcType ="
        '
        'lblSampleSize
        '
        Me.lblSampleSize.AutoSize = True
        Me.lblSampleSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampleSize.Location = New System.Drawing.Point(24, 222)
        Me.lblSampleSize.Name = "lblSampleSize"
        Me.lblSampleSize.Size = New System.Drawing.Size(84, 16)
        Me.lblSampleSize.TabIndex = 11
        Me.lblSampleSize.Text = "Sample Size"
        '
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 347)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSampleSize)
        Me.Controls.Add(Me.lblProcType)
        Me.Controls.Add(Me.lblSampleID)
        Me.Controls.Add(Me.lblRec_Date)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTP_Num)
        Me.Controls.Add(Me.lblRecNum)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.lblTP_Comment)
        Me.Controls.Add(Me.lblClientName)
        Me.Controls.Add(Me.lblName)
        Me.Name = "frmInfo"
        Me.Text = "Sample Information"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents lblTP_Comment As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblRecNum As System.Windows.Forms.Label
    Friend WithEvents lblTP_Num As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblRec_Date As System.Windows.Forms.Label
    Friend WithEvents lblSampleID As System.Windows.Forms.Label
    Friend WithEvents lblProcType As System.Windows.Forms.Label
    Friend WithEvents lblSampleSize As System.Windows.Forms.Label
End Class
