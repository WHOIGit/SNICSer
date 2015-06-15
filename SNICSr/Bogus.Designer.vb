<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bogus
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
        Me.lbxBogus = New System.Windows.Forms.ListBox()
        Me.lblBogus = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbxBogus
        '
        Me.lbxBogus.FormattingEnabled = True
        Me.lbxBogus.ItemHeight = 20
        Me.lbxBogus.Location = New System.Drawing.Point(51, 86)
        Me.lbxBogus.Name = "lbxBogus"
        Me.lbxBogus.Size = New System.Drawing.Size(128, 224)
        Me.lbxBogus.TabIndex = 0
        '
        'lblBogus
        '
        Me.lblBogus.AutoSize = True
        Me.lblBogus.Location = New System.Drawing.Point(14, 3)
        Me.lblBogus.Name = "lblBogus"
        Me.lblBogus.Size = New System.Drawing.Size(57, 20)
        Me.lblBogus.TabIndex = 1
        Me.lblBogus.Text = "Label1"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(51, 317)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(128, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Bogus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(230, 355)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblBogus)
        Me.Controls.Add(Me.lbxBogus)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Bogus"
        Me.Text = "Bogus Lines"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbxBogus As System.Windows.Forms.ListBox
    Friend WithEvents lblBogus As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
