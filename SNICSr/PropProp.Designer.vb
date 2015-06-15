<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropPropPlot
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
        Me.cmbXvar = New System.Windows.Forms.ComboBox()
        Me.cmbYvar = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkUnks = New System.Windows.Forms.CheckBox()
        Me.chkSecs = New System.Windows.Forms.CheckBox()
        Me.chkBlanks = New System.Windows.Forms.CheckBox()
        Me.chkStds = New System.Windows.Forms.CheckBox()
        Me.zc1 = New ZedGraph.ZedGraphControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.chkExclude = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbXvar
        '
        Me.cmbXvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbXvar.FormattingEnabled = True
        Me.cmbXvar.Location = New System.Drawing.Point(46, 11)
        Me.cmbXvar.Name = "cmbXvar"
        Me.cmbXvar.Size = New System.Drawing.Size(97, 24)
        Me.cmbXvar.TabIndex = 0
        '
        'cmbYvar
        '
        Me.cmbYvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYvar.FormattingEnabled = True
        Me.cmbYvar.Location = New System.Drawing.Point(187, 12)
        Me.cmbYvar.Name = "cmbYvar"
        Me.cmbYvar.Size = New System.Drawing.Size(97, 24)
        Me.cmbYvar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "X-Axis"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(142, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Y-Axis"
        '
        'chkUnks
        '
        Me.chkUnks.AutoSize = True
        Me.chkUnks.Location = New System.Drawing.Point(608, 14)
        Me.chkUnks.Name = "chkUnks"
        Me.chkUnks.Size = New System.Drawing.Size(77, 17)
        Me.chkUnks.TabIndex = 14
        Me.chkUnks.Text = "Unknowns"
        Me.chkUnks.UseVisualStyleBackColor = True
        '
        'chkSecs
        '
        Me.chkSecs.AutoSize = True
        Me.chkSecs.Location = New System.Drawing.Point(517, 14)
        Me.chkSecs.Name = "chkSecs"
        Me.chkSecs.Size = New System.Drawing.Size(85, 17)
        Me.chkSecs.TabIndex = 13
        Me.chkSecs.Text = "Secondaries"
        Me.chkSecs.UseVisualStyleBackColor = True
        '
        'chkBlanks
        '
        Me.chkBlanks.AutoSize = True
        Me.chkBlanks.Location = New System.Drawing.Point(453, 14)
        Me.chkBlanks.Name = "chkBlanks"
        Me.chkBlanks.Size = New System.Drawing.Size(58, 17)
        Me.chkBlanks.TabIndex = 12
        Me.chkBlanks.Text = "Blanks"
        Me.chkBlanks.UseVisualStyleBackColor = True
        '
        'chkStds
        '
        Me.chkStds.AutoSize = True
        Me.chkStds.Checked = True
        Me.chkStds.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStds.Location = New System.Drawing.Point(373, 14)
        Me.chkStds.Name = "chkStds"
        Me.chkStds.Size = New System.Drawing.Size(74, 17)
        Me.chkStds.TabIndex = 11
        Me.chkStds.Text = "Standards"
        Me.chkStds.UseVisualStyleBackColor = True
        '
        'zc1
        '
        Me.zc1.Location = New System.Drawing.Point(3, 42)
        Me.zc1.Name = "zc1"
        Me.zc1.ScrollGrace = 0.0R
        Me.zc1.ScrollMaxX = 0.0R
        Me.zc1.ScrollMaxY = 0.0R
        Me.zc1.ScrollMaxY2 = 0.0R
        Me.zc1.ScrollMinX = 0.0R
        Me.zc1.ScrollMinY = 0.0R
        Me.zc1.ScrollMinY2 = 0.0R
        Me.zc1.Size = New System.Drawing.Size(858, 697)
        Me.zc1.TabIndex = 15
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(762, 8)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(70, 26)
        Me.btnPrint.TabIndex = 17
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(683, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 24)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chkExclude
        '
        Me.chkExclude.AutoSize = True
        Me.chkExclude.Location = New System.Drawing.Point(293, 7)
        Me.chkExclude.Name = "chkExclude"
        Me.chkExclude.Size = New System.Drawing.Size(64, 30)
        Me.chkExclude.TabIndex = 19
        Me.chkExclude.Text = "Exclude" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rejects"
        Me.chkExclude.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(841, -2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 24)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PropPropPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 738)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkExclude)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.zc1)
        Me.Controls.Add(Me.chkUnks)
        Me.Controls.Add(Me.chkSecs)
        Me.Controls.Add(Me.chkBlanks)
        Me.Controls.Add(Me.chkStds)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbYvar)
        Me.Controls.Add(Me.cmbXvar)
        Me.Name = "PropPropPlot"
        Me.Text = "Property Property Plots"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbXvar As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYvar As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkUnks As System.Windows.Forms.CheckBox
    Friend WithEvents chkSecs As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlanks As System.Windows.Forms.CheckBox
    Friend WithEvents chkStds As System.Windows.Forms.CheckBox
    Friend WithEvents zc1 As ZedGraph.ZedGraphControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkExclude As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
