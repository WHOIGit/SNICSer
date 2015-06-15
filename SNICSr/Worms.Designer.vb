<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Worms
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.zc1 = New ZedGraph.ZedGraphControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbOther = New System.Windows.Forms.ComboBox()
        Me.lblOther = New System.Windows.Forms.Label()
        Me.zc2 = New ZedGraph.ZedGraphControl()
        Me.rdbByMeast = New System.Windows.Forms.RadioButton()
        Me.rdbByTime = New System.Windows.Forms.RadioButton()
        Me.gpbXaxis = New System.Windows.Forms.GroupBox()
        Me.rdbStd = New System.Windows.Forms.RadioButton()
        Me.rdbBlk = New System.Windows.Forms.RadioButton()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvLgndWorms = New System.Windows.Forms.DataGridView()
        Me.lblInstr = New System.Windows.Forms.Label()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.chkOverlay = New System.Windows.Forms.CheckBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.chkExclude = New System.Windows.Forms.CheckBox()
        Me.btnNext2 = New System.Windows.Forms.Button()
        Me.btnPrev2 = New System.Windows.Forms.Button()
        Me.btnReplot = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPlotStds = New System.Windows.Forms.Button()
        Me.btnPlotBlks = New System.Windows.Forms.Button()
        Me.gpbXaxis.SuspendLayout()
        CType(Me.dgvLgndWorms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1285, 8)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(74, 24)
        Me.btnPrint.TabIndex = 46
        Me.btnPrint.TabStop = False
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'zc1
        '
        Me.zc1.Location = New System.Drawing.Point(8, 58)
        Me.zc1.Name = "zc1"
        Me.zc1.ScrollGrace = 0.0R
        Me.zc1.ScrollMaxX = 0.0R
        Me.zc1.ScrollMaxY = 0.0R
        Me.zc1.ScrollMaxY2 = 0.0R
        Me.zc1.ScrollMinX = 0.0R
        Me.zc1.ScrollMinY = 0.0R
        Me.zc1.ScrollMinY2 = 0.0R
        Me.zc1.Size = New System.Drawing.Size(1225, 453)
        Me.zc1.TabIndex = 0
        '
        'cmbOther
        '
        Me.cmbOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOther.FormattingEnabled = True
        Me.cmbOther.Location = New System.Drawing.Point(1156, 8)
        Me.cmbOther.Name = "cmbOther"
        Me.cmbOther.Size = New System.Drawing.Size(123, 24)
        Me.cmbOther.TabIndex = 45
        Me.cmbOther.TabStop = False
        '
        'lblOther
        '
        Me.lblOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOther.AutoSize = True
        Me.lblOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOther.Location = New System.Drawing.Point(1107, 12)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(45, 16)
        Me.lblOther.TabIndex = 8
        Me.lblOther.Text = "Other"
        '
        'zc2
        '
        Me.zc2.Location = New System.Drawing.Point(8, 510)
        Me.zc2.Name = "zc2"
        Me.zc2.ScrollGrace = 0.0R
        Me.zc2.ScrollMaxX = 0.0R
        Me.zc2.ScrollMaxY = 0.0R
        Me.zc2.ScrollMaxY2 = 0.0R
        Me.zc2.ScrollMinX = 0.0R
        Me.zc2.ScrollMinY = 0.0R
        Me.zc2.ScrollMinY2 = 0.0R
        Me.zc2.Size = New System.Drawing.Size(1225, 479)
        Me.zc2.TabIndex = 9
        '
        'rdbByMeast
        '
        Me.rdbByMeast.AutoSize = True
        Me.rdbByMeast.Location = New System.Drawing.Point(84, 20)
        Me.rdbByMeast.Name = "rdbByMeast"
        Me.rdbByMeast.Size = New System.Drawing.Size(68, 20)
        Me.rdbByMeast.TabIndex = 16
        Me.rdbByMeast.Text = "Meast"
        Me.rdbByMeast.UseVisualStyleBackColor = True
        '
        'rdbByTime
        '
        Me.rdbByTime.AutoSize = True
        Me.rdbByTime.Checked = True
        Me.rdbByTime.Location = New System.Drawing.Point(17, 20)
        Me.rdbByTime.Name = "rdbByTime"
        Me.rdbByTime.Size = New System.Drawing.Size(61, 20)
        Me.rdbByTime.TabIndex = 15
        Me.rdbByTime.TabStop = True
        Me.rdbByTime.Text = "Time"
        Me.rdbByTime.UseVisualStyleBackColor = True
        '
        'gpbXaxis
        '
        Me.gpbXaxis.Controls.Add(Me.rdbByTime)
        Me.gpbXaxis.Controls.Add(Me.rdbByMeast)
        Me.gpbXaxis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbXaxis.Location = New System.Drawing.Point(542, 1)
        Me.gpbXaxis.Name = "gpbXaxis"
        Me.gpbXaxis.Size = New System.Drawing.Size(158, 51)
        Me.gpbXaxis.TabIndex = 18
        Me.gpbXaxis.TabStop = False
        Me.gpbXaxis.Text = "X Axis"
        '
        'rdbStd
        '
        Me.rdbStd.AutoSize = True
        Me.rdbStd.Checked = True
        Me.rdbStd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbStd.Location = New System.Drawing.Point(269, 19)
        Me.rdbStd.Name = "rdbStd"
        Me.rdbStd.Size = New System.Drawing.Size(97, 20)
        Me.rdbStd.TabIndex = 7
        Me.rdbStd.TabStop = True
        Me.rdbStd.Text = "Standards"
        Me.rdbStd.UseVisualStyleBackColor = True
        '
        'rdbBlk
        '
        Me.rdbBlk.AutoSize = True
        Me.rdbBlk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbBlk.Location = New System.Drawing.Point(372, 19)
        Me.rdbBlk.Name = "rdbBlk"
        Me.rdbBlk.Size = New System.Drawing.Size(73, 20)
        Me.rdbBlk.TabIndex = 10
        Me.rdbBlk.Text = "Blanks"
        Me.rdbBlk.UseVisualStyleBackColor = True
        '
        'dgvLgndWorms
        '
        Me.dgvLgndWorms.AllowUserToAddRows = False
        Me.dgvLgndWorms.AllowUserToDeleteRows = False
        Me.dgvLgndWorms.AllowUserToResizeColumns = False
        Me.dgvLgndWorms.AllowUserToResizeRows = False
        Me.dgvLgndWorms.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLgndWorms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLgndWorms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLgndWorms.Location = New System.Drawing.Point(1238, 41)
        Me.dgvLgndWorms.Name = "dgvLgndWorms"
        Me.dgvLgndWorms.RowHeadersVisible = False
        Me.dgvLgndWorms.Size = New System.Drawing.Size(142, 388)
        Me.dgvLgndWorms.TabIndex = 19
        '
        'lblInstr
        '
        Me.lblInstr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInstr.AutoSize = True
        Me.lblInstr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstr.ForeColor = System.Drawing.Color.Maroon
        Me.lblInstr.Location = New System.Drawing.Point(806, 10)
        Me.lblInstr.Name = "lblInstr"
        Me.lblInstr.Size = New System.Drawing.Size(196, 20)
        Me.lblInstr.TabIndex = 20
        Me.lblInstr.Text = "Click to Toggle OK Flag"
        '
        'btnCalculate
        '
        Me.btnCalculate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculate.Location = New System.Drawing.Point(1008, 8)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(100, 26)
        Me.btnCalculate.TabIndex = 21
        Me.btnCalculate.TabStop = False
        Me.btnCalculate.Text = "Recalculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'chkOverlay
        '
        Me.chkOverlay.AutoSize = True
        Me.chkOverlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOverlay.Location = New System.Drawing.Point(457, 21)
        Me.chkOverlay.Name = "chkOverlay"
        Me.chkOverlay.Size = New System.Drawing.Size(81, 20)
        Me.chkOverlay.TabIndex = 26
        Me.chkOverlay.TabStop = False
        Me.chkOverlay.Text = "Overlay"
        Me.chkOverlay.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(1285, 483)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(93, 24)
        Me.btnNext.TabIndex = 23
        Me.btnNext.TabStop = False
        Me.btnNext.Text = "v Next v"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Location = New System.Drawing.Point(1285, 459)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(93, 24)
        Me.btnPrev.TabIndex = 22
        Me.btnPrev.TabStop = False
        Me.btnPrev.Text = "^ Prev ^"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'chkExclude
        '
        Me.chkExclude.AutoSize = True
        Me.chkExclude.Location = New System.Drawing.Point(709, 14)
        Me.chkExclude.Name = "chkExclude"
        Me.chkExclude.Size = New System.Drawing.Size(67, 30)
        Me.chkExclude.TabIndex = 27
        Me.chkExclude.TabStop = False
        Me.chkExclude.Text = "Exclude " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rejects"
        Me.chkExclude.UseVisualStyleBackColor = True
        '
        'btnNext2
        '
        Me.btnNext2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext2.Location = New System.Drawing.Point(166, 29)
        Me.btnNext2.Name = "btnNext2"
        Me.btnNext2.Size = New System.Drawing.Size(83, 24)
        Me.btnNext2.TabIndex = 49
        Me.btnNext2.TabStop = False
        Me.btnNext2.Text = "v Next v"
        Me.btnNext2.UseVisualStyleBackColor = True
        Me.btnNext2.Visible = False
        '
        'btnPrev2
        '
        Me.btnPrev2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev2.Location = New System.Drawing.Point(166, 1)
        Me.btnPrev2.Name = "btnPrev2"
        Me.btnPrev2.Size = New System.Drawing.Size(83, 24)
        Me.btnPrev2.TabIndex = 48
        Me.btnPrev2.TabStop = False
        Me.btnPrev2.Text = "^ Prev ^"
        Me.btnPrev2.UseVisualStyleBackColor = True
        Me.btnPrev2.Visible = False
        '
        'btnReplot
        '
        Me.btnReplot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReplot.Location = New System.Drawing.Point(8, 58)
        Me.btnReplot.Name = "btnReplot"
        Me.btnReplot.Size = New System.Drawing.Size(24, 24)
        Me.btnReplot.TabIndex = 52
        Me.btnReplot.TabStop = False
        Me.btnReplot.Text = "R"
        Me.btnReplot.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1365, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 53
        Me.Button1.TabStop = False
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnPlotStds
        '
        Me.btnPlotStds.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlotStds.Location = New System.Drawing.Point(9, 29)
        Me.btnPlotStds.Name = "btnPlotStds"
        Me.btnPlotStds.Size = New System.Drawing.Size(72, 24)
        Me.btnPlotStds.TabIndex = 54
        Me.btnPlotStds.TabStop = False
        Me.btnPlotStds.Text = "Plt Stds"
        Me.btnPlotStds.UseVisualStyleBackColor = True
        Me.btnPlotStds.Visible = False
        '
        'btnPlotBlks
        '
        Me.btnPlotBlks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlotBlks.Location = New System.Drawing.Point(88, 29)
        Me.btnPlotBlks.Name = "btnPlotBlks"
        Me.btnPlotBlks.Size = New System.Drawing.Size(72, 24)
        Me.btnPlotBlks.TabIndex = 55
        Me.btnPlotBlks.TabStop = False
        Me.btnPlotBlks.Text = "Plt Blks"
        Me.btnPlotBlks.UseVisualStyleBackColor = True
        Me.btnPlotBlks.Visible = False
        '
        'Worms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1390, 511)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPlotBlks)
        Me.Controls.Add(Me.btnPlotStds)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnReplot)
        Me.Controls.Add(Me.btnNext2)
        Me.Controls.Add(Me.btnPrev2)
        Me.Controls.Add(Me.chkExclude)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.chkOverlay)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.lblInstr)
        Me.Controls.Add(Me.dgvLgndWorms)
        Me.Controls.Add(Me.rdbBlk)
        Me.Controls.Add(Me.gpbXaxis)
        Me.Controls.Add(Me.zc2)
        Me.Controls.Add(Me.rdbStd)
        Me.Controls.Add(Me.lblOther)
        Me.Controls.Add(Me.cmbOther)
        Me.Controls.Add(Me.zc1)
        Me.Controls.Add(Me.btnPrint)
        Me.KeyPreview = True
        Me.Name = "Worms"
        Me.Text = "All Standards"
        Me.gpbXaxis.ResumeLayout(False)
        Me.gpbXaxis.PerformLayout()
        CType(Me.dgvLgndWorms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents zc1 As ZedGraph.ZedGraphControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbOther As System.Windows.Forms.ComboBox
    Friend WithEvents lblOther As System.Windows.Forms.Label
    Friend WithEvents zc2 As ZedGraph.ZedGraphControl
    Friend WithEvents rdbByMeast As System.Windows.Forms.RadioButton
    Friend WithEvents rdbByTime As System.Windows.Forms.RadioButton
    Friend WithEvents gpbXaxis As System.Windows.Forms.GroupBox
    Friend WithEvents rdbStd As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBlk As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents dgvLgndWorms As System.Windows.Forms.DataGridView
    Friend WithEvents lblInstr As System.Windows.Forms.Label
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents chkOverlay As System.Windows.Forms.CheckBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents chkExclude As System.Windows.Forms.CheckBox
    Friend WithEvents btnNext2 As System.Windows.Forms.Button
    Friend WithEvents btnPrev2 As System.Windows.Forms.Button
    Friend WithEvents btnReplot As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPlotStds As System.Windows.Forms.Button
    Friend WithEvents btnPlotBlks As System.Windows.Forms.Button
End Class
