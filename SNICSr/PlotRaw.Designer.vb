<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlotRaw
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
        Me.zc1 = New ZedGraph.ZedGraphControl()
        Me.chkStds = New System.Windows.Forms.CheckBox()
        Me.chkBlanks = New System.Windows.Forms.CheckBox()
        Me.chkSecs = New System.Windows.Forms.CheckBox()
        Me.chkUnks = New System.Windows.Forms.CheckBox()
        Me.cmbOther = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.zc2 = New ZedGraph.ZedGraphControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnWorms = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.dgvLgndWorms = New System.Windows.Forms.DataGridView()
        Me.chkExclude = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvLgndWorms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'zc1
        '
        Me.zc1.Location = New System.Drawing.Point(8, 32)
        Me.zc1.Name = "zc1"
        Me.zc1.ScrollGrace = 0.0R
        Me.zc1.ScrollMaxX = 0.0R
        Me.zc1.ScrollMaxY = 0.0R
        Me.zc1.ScrollMaxY2 = 0.0R
        Me.zc1.ScrollMinX = 0.0R
        Me.zc1.ScrollMinY = 0.0R
        Me.zc1.ScrollMinY2 = 0.0R
        Me.zc1.Size = New System.Drawing.Size(872, 381)
        Me.zc1.TabIndex = 1
        '
        'chkStds
        '
        Me.chkStds.AutoSize = True
        Me.chkStds.Checked = True
        Me.chkStds.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStds.Location = New System.Drawing.Point(265, 5)
        Me.chkStds.Name = "chkStds"
        Me.chkStds.Size = New System.Drawing.Size(89, 20)
        Me.chkStds.TabIndex = 2
        Me.chkStds.Text = "Standards"
        Me.chkStds.UseVisualStyleBackColor = True
        '
        'chkBlanks
        '
        Me.chkBlanks.AutoSize = True
        Me.chkBlanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBlanks.Location = New System.Drawing.Point(360, 5)
        Me.chkBlanks.Name = "chkBlanks"
        Me.chkBlanks.Size = New System.Drawing.Size(68, 20)
        Me.chkBlanks.TabIndex = 3
        Me.chkBlanks.Text = "Blanks"
        Me.chkBlanks.UseVisualStyleBackColor = True
        '
        'chkSecs
        '
        Me.chkSecs.AutoSize = True
        Me.chkSecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSecs.Location = New System.Drawing.Point(434, 5)
        Me.chkSecs.Name = "chkSecs"
        Me.chkSecs.Size = New System.Drawing.Size(104, 20)
        Me.chkSecs.TabIndex = 4
        Me.chkSecs.Text = "Secondaries"
        Me.chkSecs.UseVisualStyleBackColor = True
        '
        'chkUnks
        '
        Me.chkUnks.AutoSize = True
        Me.chkUnks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUnks.Location = New System.Drawing.Point(544, 5)
        Me.chkUnks.Name = "chkUnks"
        Me.chkUnks.Size = New System.Drawing.Size(89, 20)
        Me.chkUnks.TabIndex = 5
        Me.chkUnks.Text = "Unknowns"
        Me.chkUnks.UseVisualStyleBackColor = True
        '
        'cmbOther
        '
        Me.cmbOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOther.FormattingEnabled = True
        Me.cmbOther.Location = New System.Drawing.Point(776, 5)
        Me.cmbOther.Name = "cmbOther"
        Me.cmbOther.Size = New System.Drawing.Size(95, 24)
        Me.cmbOther.TabIndex = 6
        Me.cmbOther.Text = "None"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(730, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Other"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(10, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(77, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'zc2
        '
        Me.zc2.Location = New System.Drawing.Point(8, 410)
        Me.zc2.Name = "zc2"
        Me.zc2.ScrollGrace = 0.0R
        Me.zc2.ScrollMaxX = 0.0R
        Me.zc2.ScrollMaxY = 0.0R
        Me.zc2.ScrollMaxY2 = 0.0R
        Me.zc2.ScrollMinX = 0.0R
        Me.zc2.ScrollMinY = 0.0R
        Me.zc2.ScrollMinY2 = 0.0R
        Me.zc2.Size = New System.Drawing.Size(872, 366)
        Me.zc2.TabIndex = 9
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        '
        'btnWorms
        '
        Me.btnWorms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorms.Location = New System.Drawing.Point(93, 4)
        Me.btnWorms.Name = "btnWorms"
        Me.btnWorms.Size = New System.Drawing.Size(77, 23)
        Me.btnWorms.TabIndex = 10
        Me.btnWorms.Text = "Worms"
        Me.btnWorms.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(638, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(77, 23)
        Me.btnPrint.TabIndex = 11
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'dgvLgndWorms
        '
        Me.dgvLgndWorms.AllowUserToAddRows = False
        Me.dgvLgndWorms.AllowUserToDeleteRows = False
        Me.dgvLgndWorms.AllowUserToResizeColumns = False
        Me.dgvLgndWorms.AllowUserToResizeRows = False
        Me.dgvLgndWorms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLgndWorms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLgndWorms.Location = New System.Drawing.Point(886, 32)
        Me.dgvLgndWorms.Name = "dgvLgndWorms"
        Me.dgvLgndWorms.RowHeadersVisible = False
        Me.dgvLgndWorms.Size = New System.Drawing.Size(142, 392)
        Me.dgvLgndWorms.TabIndex = 20
        '
        'chkExclude
        '
        Me.chkExclude.AutoSize = True
        Me.chkExclude.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExclude.Location = New System.Drawing.Point(180, -2)
        Me.chkExclude.Name = "chkExclude"
        Me.chkExclude.Size = New System.Drawing.Size(70, 34)
        Me.chkExclude.TabIndex = 21
        Me.chkExclude.Text = "Exclude" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rejects" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkExclude.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1013, -2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 54
        Me.Button1.TabStop = False
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PlotRaw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 503)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkExclude)
        Me.Controls.Add(Me.dgvLgndWorms)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnWorms)
        Me.Controls.Add(Me.zc2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOther)
        Me.Controls.Add(Me.chkUnks)
        Me.Controls.Add(Me.chkSecs)
        Me.Controls.Add(Me.chkBlanks)
        Me.Controls.Add(Me.chkStds)
        Me.Controls.Add(Me.zc1)
        Me.Name = "PlotRaw"
        Me.Text = "Raw Plot"
        Me.TopMost = True
        CType(Me.dgvLgndWorms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents zc1 As ZedGraph.ZedGraphControl
    Friend WithEvents chkStds As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlanks As System.Windows.Forms.CheckBox
    Friend WithEvents chkSecs As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnks As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOther As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents zc2 As ZedGraph.ZedGraphControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnWorms As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dgvLgndWorms As System.Windows.Forms.DataGridView
    Friend WithEvents chkExclude As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
