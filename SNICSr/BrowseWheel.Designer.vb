<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseWheel
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
        Me.trvWheel = New System.Windows.Forms.TreeView()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.iList = New System.Windows.Forms.ImageList(Me.components)
        Me.lblChoice = New System.Windows.Forms.Label()
        Me.txtWheel = New System.Windows.Forms.TextBox()
        Me.lbl1st = New System.Windows.Forms.Label()
        Me.lbl2nd = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'trvWheel
        '
        Me.trvWheel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvWheel.Location = New System.Drawing.Point(0, 50)
        Me.trvWheel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.trvWheel.Name = "trvWheel"
        Me.trvWheel.Size = New System.Drawing.Size(367, 729)
        Me.trvWheel.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(0, 789)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(108, 29)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(259, 789)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 29)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'iList
        '
        Me.iList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.iList.ImageSize = New System.Drawing.Size(32, 32)
        Me.iList.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblChoice
        '
        Me.lblChoice.AutoSize = True
        Me.lblChoice.Location = New System.Drawing.Point(2, 25)
        Me.lblChoice.Name = "lblChoice"
        Me.lblChoice.Size = New System.Drawing.Size(126, 20)
        Me.lblChoice.TabIndex = 3
        Me.lblChoice.Text = "Choose a Wheel"
        '
        'txtWheel
        '
        Me.txtWheel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWheel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWheel.Location = New System.Drawing.Point(190, 2)
        Me.txtWheel.Multiline = True
        Me.txtWheel.Name = "txtWheel"
        Me.txtWheel.Size = New System.Drawing.Size(177, 40)
        Me.txtWheel.TabIndex = 4
        Me.txtWheel.Visible = False
        '
        'lbl1st
        '
        Me.lbl1st.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1st.AutoSize = True
        Me.lbl1st.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1st.Location = New System.Drawing.Point(149, 4)
        Me.lbl1st.Name = "lbl1st"
        Me.lbl1st.Size = New System.Drawing.Size(43, 16)
        Me.lbl1st.TabIndex = 5
        Me.lbl1st.Text = "1st by"
        Me.lbl1st.Visible = False
        '
        'lbl2nd
        '
        Me.lbl2nd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2nd.AutoSize = True
        Me.lbl2nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2nd.Location = New System.Drawing.Point(145, 22)
        Me.lbl2nd.Name = "lbl2nd"
        Me.lbl2nd.Size = New System.Drawing.Size(48, 16)
        Me.lbl2nd.TabIndex = 6
        Me.lbl2nd.Text = "2nd by"
        Me.lbl2nd.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Choose a Wheel"
        '
        'BrowseWheel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 821)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtWheel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl2nd)
        Me.Controls.Add(Me.lbl1st)
        Me.Controls.Add(Me.lblChoice)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.trvWheel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "BrowseWheel"
        Me.Text = "BrowseWheel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trvWheel As System.Windows.Forms.TreeView
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents iList As System.Windows.Forms.ImageList
    Friend WithEvents lblChoice As System.Windows.Forms.Label
    Friend WithEvents txtWheel As System.Windows.Forms.TextBox
    Friend WithEvents lbl1st As System.Windows.Forms.Label
    Friend WithEvents lbl2nd As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
