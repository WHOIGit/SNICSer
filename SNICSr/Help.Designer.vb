<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Help
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.HelpBrowser = New System.Windows.Forms.WebBrowser()
        Me.btnHelpForward = New System.Windows.Forms.Button()
        Me.btnHelpBack = New System.Windows.Forms.Button()
        Me.tmrHelp = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(330, 1)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(105, 30)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'HelpBrowser
        '
        Me.HelpBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HelpBrowser.Location = New System.Drawing.Point(0, 37)
        Me.HelpBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.HelpBrowser.Name = "HelpBrowser"
        Me.HelpBrowser.Size = New System.Drawing.Size(811, 808)
        Me.HelpBrowser.TabIndex = 2
        '
        'btnHelpForward
        '
        Me.btnHelpForward.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelpForward.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelpForward.Location = New System.Drawing.Point(768, 3)
        Me.btnHelpForward.Name = "btnHelpForward"
        Me.btnHelpForward.Size = New System.Drawing.Size(43, 28)
        Me.btnHelpForward.TabIndex = 7
        Me.btnHelpForward.Text = "==>"
        Me.btnHelpForward.UseVisualStyleBackColor = True
        Me.btnHelpForward.Visible = False
        '
        'btnHelpBack
        '
        Me.btnHelpBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelpBack.Location = New System.Drawing.Point(1, 2)
        Me.btnHelpBack.Name = "btnHelpBack"
        Me.btnHelpBack.Size = New System.Drawing.Size(39, 28)
        Me.btnHelpBack.TabIndex = 6
        Me.btnHelpBack.Text = "<=="
        Me.btnHelpBack.UseVisualStyleBackColor = True
        Me.btnHelpBack.Visible = False
        '
        'tmrHelp
        '
        Me.tmrHelp.Enabled = True
        Me.tmrHelp.Interval = 1000
        '
        'Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 842)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHelpForward)
        Me.Controls.Add(Me.btnHelpBack)
        Me.Controls.Add(Me.HelpBrowser)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Help"
        Me.Text = "SNICSer Help"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents HelpBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents btnHelpForward As System.Windows.Forms.Button
    Friend WithEvents btnHelpBack As System.Windows.Forms.Button
    Friend WithEvents tmrHelp As System.Windows.Forms.Timer
End Class
