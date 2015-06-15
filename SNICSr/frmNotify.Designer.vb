<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNotify2ndAuth
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
        Me.lblNotify = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.lbx2ndAuth = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblNotify
        '
        Me.lblNotify.AutoSize = True
        Me.lblNotify.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotify.Location = New System.Drawing.Point(22, 20)
        Me.lblNotify.Name = "lblNotify"
        Me.lblNotify.Size = New System.Drawing.Size(432, 24)
        Me.lblNotify.TabIndex = 1
        Me.lblNotify.Text = "Do you wish to (email) notify the 2nd Analyst?"
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(67, 59)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 2
        Me.btnYes.Text = "YES"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(314, 59)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 23)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "NO"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "If so, who?"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(154, 131)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(329, 102)
        Me.txtMessage.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Any Message:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(26, 200)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 7
        Me.btnSend.Text = "SEND"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'lbx2ndAuth
        '
        Me.lbx2ndAuth.FormattingEnabled = True
        Me.lbx2ndAuth.Location = New System.Drawing.Point(154, 103)
        Me.lbx2ndAuth.Name = "lbx2ndAuth"
        Me.lbx2ndAuth.Size = New System.Drawing.Size(187, 24)
        Me.lbx2ndAuth.TabIndex = 8
        '
        'FrmNotify2ndAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 260)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbx2ndAuth)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblNotify)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmNotify2ndAuth"
        Me.Text = "Notify Second Authorizer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNotify As System.Windows.Forms.Label
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents lbx2ndAuth As System.Windows.Forms.ComboBox
End Class
