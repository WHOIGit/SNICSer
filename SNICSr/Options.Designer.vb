<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gpbAnalyst = New System.Windows.Forms.GroupBox()
        Me.chkRememberMe = New System.Windows.Forms.CheckBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnalyst = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAllowSelfNorm = New System.Windows.Forms.CheckBox()
        Me.nudNumStds = New System.Windows.Forms.NumericUpDown()
        Me.chkGroup = New System.Windows.Forms.CheckBox()
        Me.lblstds = New System.Windows.Forms.Label()
        Me.lblFit = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFitType = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkShowStdsBlanks = New System.Windows.Forms.CheckBox()
        Me.chkClassic = New System.Windows.Forms.CheckBox()
        Me.chkTopPlot = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkWide = New System.Windows.Forms.CheckBox()
        Me.chkTall = New System.Windows.Forms.CheckBox()
        Me.chk2StdDev = New System.Windows.Forms.CheckBox()
        Me.nudSymbSize = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbNumMult = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbNumVar = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudNumFnt = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudFontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudResSigFig = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudRunSigFig = New System.Windows.Forms.NumericUpDown()
        Me.bntQuit = New System.Windows.Forms.Button()
        Me.tbcOpt = New System.Windows.Forms.TabControl()
        Me.tpCalc = New System.Windows.Forms.TabPage()
        Me.tbAppear = New System.Windows.Forms.TabPage()
        Me.tbcColor = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnUnk = New System.Windows.Forms.Button()
        Me.btnSec = New System.Windows.Forms.Button()
        Me.btnStd = New System.Windows.Forms.Button()
        Me.btnBlk = New System.Windows.Forms.Button()
        Me.btnFactReset = New System.Windows.Forms.Button()
        Me.bntResetOptions = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnScheme2 = New System.Windows.Forms.Button()
        Me.btnScheme1 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gpbAnalyst.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudNumStds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudSymbSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumFnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudResSigFig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRunSigFig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcOpt.SuspendLayout()
        Me.tpCalc.SuspendLayout()
        Me.tbAppear.SuspendLayout()
        Me.tbcColor.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(10, 323)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(181, 37)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save and Continue"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'gpbAnalyst
        '
        Me.gpbAnalyst.Controls.Add(Me.chkRememberMe)
        Me.gpbAnalyst.Controls.Add(Me.txtPwd)
        Me.gpbAnalyst.Controls.Add(Me.Label2)
        Me.gpbAnalyst.Controls.Add(Me.Label1)
        Me.gpbAnalyst.Controls.Add(Me.txtAnalyst)
        Me.gpbAnalyst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbAnalyst.Location = New System.Drawing.Point(79, 106)
        Me.gpbAnalyst.Name = "gpbAnalyst"
        Me.gpbAnalyst.Size = New System.Drawing.Size(222, 92)
        Me.gpbAnalyst.TabIndex = 24
        Me.gpbAnalyst.TabStop = False
        Me.gpbAnalyst.Text = "Analyst"
        '
        'chkRememberMe
        '
        Me.chkRememberMe.AutoSize = True
        Me.chkRememberMe.Location = New System.Drawing.Point(41, 68)
        Me.chkRememberMe.Name = "chkRememberMe"
        Me.chkRememberMe.Size = New System.Drawing.Size(128, 20)
        Me.chkRememberMe.TabIndex = 28
        Me.chkRememberMe.Text = "Remember Me"
        Me.chkRememberMe.UseVisualStyleBackColor = True
        '
        'txtPwd
        '
        Me.txtPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Location = New System.Drawing.Point(81, 40)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Size = New System.Drawing.Size(130, 22)
        Me.txtPwd.TabIndex = 27
        Me.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPwd.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(98, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Password"
        '
        'txtAnalyst
        '
        Me.txtAnalyst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnalyst.Location = New System.Drawing.Point(8, 40)
        Me.txtAnalyst.Name = "txtAnalyst"
        Me.txtAnalyst.Size = New System.Drawing.Size(59, 22)
        Me.txtAnalyst.TabIndex = 24
        Me.txtAnalyst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAllowSelfNorm)
        Me.GroupBox1.Controls.Add(Me.nudNumStds)
        Me.GroupBox1.Controls.Add(Me.chkGroup)
        Me.GroupBox1.Controls.Add(Me.lblstds)
        Me.GroupBox1.Controls.Add(Me.lblFit)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbFitType)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(409, 96)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Calculations"
        '
        'chkAllowSelfNorm
        '
        Me.chkAllowSelfNorm.AutoSize = True
        Me.chkAllowSelfNorm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllowSelfNorm.Location = New System.Drawing.Point(224, 67)
        Me.chkAllowSelfNorm.Name = "chkAllowSelfNorm"
        Me.chkAllowSelfNorm.Size = New System.Drawing.Size(162, 17)
        Me.chkAllowSelfNorm.TabIndex = 27
        Me.chkAllowSelfNorm.Text = "Allow Self Normalization"
        Me.chkAllowSelfNorm.UseVisualStyleBackColor = True
        '
        'nudNumStds
        '
        Me.nudNumStds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudNumStds.Location = New System.Drawing.Point(285, 27)
        Me.nudNumStds.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumStds.Name = "nudNumStds"
        Me.nudNumStds.Size = New System.Drawing.Size(48, 22)
        Me.nudNumStds.TabIndex = 21
        Me.nudNumStds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudNumStds.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'chkGroup
        '
        Me.chkGroup.AutoSize = True
        Me.chkGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGroup.Location = New System.Drawing.Point(18, 67)
        Me.chkGroup.Name = "chkGroup"
        Me.chkGroup.Size = New System.Drawing.Size(173, 17)
        Me.chkGroup.TabIndex = 26
        Me.chkGroup.Text = "Enforce Group Separation"
        Me.chkGroup.UseVisualStyleBackColor = True
        '
        'lblstds
        '
        Me.lblstds.AutoSize = True
        Me.lblstds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstds.Location = New System.Drawing.Point(329, 30)
        Me.lblstds.Name = "lblstds"
        Me.lblstds.Size = New System.Drawing.Size(79, 16)
        Me.lblstds.TabIndex = 25
        Me.lblstds.Text = "Standards"
        '
        'lblFit
        '
        Me.lblFit.AutoSize = True
        Me.lblFit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFit.Location = New System.Drawing.Point(207, 30)
        Me.lblFit.Name = "lblFit"
        Me.lblFit.Size = New System.Drawing.Size(80, 16)
        Me.lblFit.TabIndex = 24
        Me.lblFit.Text = "of Nearest"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Perform"
        '
        'cmbFitType
        '
        Me.cmbFitType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFitType.FormattingEnabled = True
        Me.cmbFitType.Items.AddRange(New Object() {"Average in Time", "Bracket Average", "Linear"})
        Me.cmbFitType.Location = New System.Drawing.Point(66, 26)
        Me.cmbFitType.Name = "cmbFitType"
        Me.cmbFitType.Size = New System.Drawing.Size(137, 24)
        Me.cmbFitType.TabIndex = 22
        Me.cmbFitType.Text = "Average in Time"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkShowStdsBlanks)
        Me.GroupBox2.Controls.Add(Me.chkClassic)
        Me.GroupBox2.Controls.Add(Me.chkTopPlot)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.chkWide)
        Me.GroupBox2.Controls.Add(Me.chkTall)
        Me.GroupBox2.Controls.Add(Me.chk2StdDev)
        Me.GroupBox2.Controls.Add(Me.nudSymbSize)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmbNumMult)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cmbNumVar)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.nudNumFnt)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.nudFontSize)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.nudResSigFig)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.nudRunSigFig)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(409, 279)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Display"
        '
        'chkShowStdsBlanks
        '
        Me.chkShowStdsBlanks.AutoSize = True
        Me.chkShowStdsBlanks.Checked = True
        Me.chkShowStdsBlanks.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowStdsBlanks.Enabled = False
        Me.chkShowStdsBlanks.Location = New System.Drawing.Point(7, 210)
        Me.chkShowStdsBlanks.Name = "chkShowStdsBlanks"
        Me.chkShowStdsBlanks.Size = New System.Drawing.Size(208, 20)
        Me.chkShowStdsBlanks.TabIndex = 45
        Me.chkShowStdsBlanks.Text = "Show Stds Blanks Window"
        Me.chkShowStdsBlanks.UseVisualStyleBackColor = True
        Me.chkShowStdsBlanks.Visible = False
        '
        'chkClassic
        '
        Me.chkClassic.AutoSize = True
        Me.chkClassic.Location = New System.Drawing.Point(260, 174)
        Me.chkClassic.Name = "chkClassic"
        Me.chkClassic.Size = New System.Drawing.Size(145, 20)
        Me.chkClassic.TabIndex = 43
        Me.chkClassic.Text = "Classic File View"
        Me.chkClassic.UseVisualStyleBackColor = True
        '
        'chkTopPlot
        '
        Me.chkTopPlot.AutoSize = True
        Me.chkTopPlot.Location = New System.Drawing.Point(298, 146)
        Me.chkTopPlot.Name = "chkTopPlot"
        Me.chkTopPlot.Size = New System.Drawing.Size(107, 20)
        Me.chkTopPlot.TabIndex = 42
        Me.chkTopPlot.Text = "Plot on Top"
        Me.chkTopPlot.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(240, 121)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 16)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Plot bands"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 166)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(175, 16)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Raw Data Display Mode"
        '
        'chkWide
        '
        Me.chkWide.AutoSize = True
        Me.chkWide.Location = New System.Drawing.Point(184, 156)
        Me.chkWide.Name = "chkWide"
        Me.chkWide.Size = New System.Drawing.Size(63, 20)
        Me.chkWide.TabIndex = 39
        Me.chkWide.Text = "Wide"
        Me.chkWide.UseVisualStyleBackColor = True
        '
        'chkTall
        '
        Me.chkTall.AutoSize = True
        Me.chkTall.Location = New System.Drawing.Point(184, 178)
        Me.chkTall.Name = "chkTall"
        Me.chkTall.Size = New System.Drawing.Size(54, 20)
        Me.chkTall.TabIndex = 38
        Me.chkTall.Text = "Tall"
        Me.chkTall.UseVisualStyleBackColor = True
        '
        'chk2StdDev
        '
        Me.chk2StdDev.AutoSize = True
        Me.chk2StdDev.Checked = True
        Me.chk2StdDev.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk2StdDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk2StdDev.Location = New System.Drawing.Point(324, 120)
        Me.chk2StdDev.Name = "chk2StdDev"
        Me.chk2StdDev.Size = New System.Drawing.Size(82, 20)
        Me.chk2StdDev.TabIndex = 36
        Me.chk2StdDev.Text = "2 StdDev"
        Me.chk2StdDev.UseVisualStyleBackColor = True
        '
        'nudSymbSize
        '
        Me.nudSymbSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSymbSize.Location = New System.Drawing.Point(175, 119)
        Me.nudSymbSize.Maximum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.nudSymbSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSymbSize.Name = "nudSymbSize"
        Me.nudSymbSize.Size = New System.Drawing.Size(48, 22)
        Me.nudSymbSize.TabIndex = 37
        Me.nudSymbSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudSymbSize.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(80, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 16)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Symbol Size"
        '
        'cmbNumMult
        '
        Me.cmbNumMult.FormattingEnabled = True
        Me.cmbNumMult.Items.AddRange(New Object() {"1.0e5", "1.0e6", "1.0e7", "1.0e8", "1.0e9"})
        Me.cmbNumMult.Location = New System.Drawing.Point(334, 38)
        Me.cmbNumMult.Name = "cmbNumMult"
        Me.cmbNumMult.Size = New System.Drawing.Size(71, 24)
        Me.cmbNumMult.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(193, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 16)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Numeric Multiplier"
        '
        'cmbNumVar
        '
        Me.cmbNumVar.FormattingEnabled = True
        Me.cmbNumVar.Location = New System.Drawing.Point(334, 11)
        Me.cmbNumVar.Name = "cmbNumVar"
        Me.cmbNumVar.Size = New System.Drawing.Size(71, 24)
        Me.cmbNumVar.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(201, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Numeric Variable"
        '
        'nudNumFnt
        '
        Me.nudNumFnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudNumFnt.Location = New System.Drawing.Point(353, 67)
        Me.nudNumFnt.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudNumFnt.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudNumFnt.Name = "nudNumFnt"
        Me.nudNumFnt.Size = New System.Drawing.Size(48, 22)
        Me.nudNumFnt.TabIndex = 31
        Me.nudNumFnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudNumFnt.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(214, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 16)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Numeric Font Size"
        '
        'nudFontSize
        '
        Me.nudFontSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudFontSize.Location = New System.Drawing.Point(126, 72)
        Me.nudFontSize.Maximum = New Decimal(New Integer() {14, 0, 0, 0})
        Me.nudFontSize.Minimum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nudFontSize.Name = "nudFontSize"
        Me.nudFontSize.Size = New System.Drawing.Size(48, 22)
        Me.nudFontSize.TabIndex = 29
        Me.nudFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudFontSize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(133, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 16)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "S.F."
        '
        'nudResSigFig
        '
        Me.nudResSigFig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudResSigFig.Location = New System.Drawing.Point(82, 44)
        Me.nudResSigFig.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.nudResSigFig.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudResSigFig.Name = "nudResSigFig"
        Me.nudResSigFig.Size = New System.Drawing.Size(48, 22)
        Me.nudResSigFig.TabIndex = 27
        Me.nudResSigFig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudResSigFig.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Results:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(133, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "S.F."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Table Font Size"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Run Data:"
        '
        'nudRunSigFig
        '
        Me.nudRunSigFig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudRunSigFig.Location = New System.Drawing.Point(82, 18)
        Me.nudRunSigFig.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.nudRunSigFig.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudRunSigFig.Name = "nudRunSigFig"
        Me.nudRunSigFig.Size = New System.Drawing.Size(48, 22)
        Me.nudRunSigFig.TabIndex = 21
        Me.nudRunSigFig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudRunSigFig.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'bntQuit
        '
        Me.bntQuit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntQuit.Location = New System.Drawing.Point(135, 366)
        Me.bntQuit.Name = "bntQuit"
        Me.bntQuit.Size = New System.Drawing.Size(181, 37)
        Me.bntQuit.TabIndex = 30
        Me.bntQuit.Text = "FahGeddAbowdIt!"
        Me.bntQuit.UseVisualStyleBackColor = False
        '
        'tbcOpt
        '
        Me.tbcOpt.Controls.Add(Me.tpCalc)
        Me.tbcOpt.Controls.Add(Me.tbAppear)
        Me.tbcOpt.Controls.Add(Me.tbcColor)
        Me.tbcOpt.Location = New System.Drawing.Point(-3, 0)
        Me.tbcOpt.Name = "tbcOpt"
        Me.tbcOpt.SelectedIndex = 0
        Me.tbcOpt.Size = New System.Drawing.Size(426, 317)
        Me.tbcOpt.TabIndex = 31
        '
        'tpCalc
        '
        Me.tpCalc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tpCalc.Controls.Add(Me.GroupBox1)
        Me.tpCalc.Controls.Add(Me.gpbAnalyst)
        Me.tpCalc.Location = New System.Drawing.Point(4, 22)
        Me.tpCalc.Name = "tpCalc"
        Me.tpCalc.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCalc.Size = New System.Drawing.Size(418, 291)
        Me.tpCalc.TabIndex = 0
        Me.tpCalc.Text = "Calculations"
        '
        'tbAppear
        '
        Me.tbAppear.BackColor = System.Drawing.Color.White
        Me.tbAppear.Controls.Add(Me.GroupBox2)
        Me.tbAppear.Location = New System.Drawing.Point(4, 22)
        Me.tbAppear.Name = "tbAppear"
        Me.tbAppear.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAppear.Size = New System.Drawing.Size(418, 291)
        Me.tbAppear.TabIndex = 1
        Me.tbAppear.Text = "Appearance"
        '
        'tbcColor
        '
        Me.tbcColor.Controls.Add(Me.GroupBox3)
        Me.tbcColor.Controls.Add(Me.btnFactReset)
        Me.tbcColor.Controls.Add(Me.bntResetOptions)
        Me.tbcColor.Controls.Add(Me.GroupBox4)
        Me.tbcColor.Location = New System.Drawing.Point(4, 22)
        Me.tbcColor.Name = "tbcColor"
        Me.tbcColor.Size = New System.Drawing.Size(418, 291)
        Me.tbcColor.TabIndex = 2
        Me.tbcColor.Text = "Colors"
        Me.tbcColor.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnUnk)
        Me.GroupBox3.Controls.Add(Me.btnSec)
        Me.GroupBox3.Controls.Add(Me.btnStd)
        Me.GroupBox3.Controls.Add(Me.btnBlk)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(96, 140)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Type Colors"
        '
        'btnUnk
        '
        Me.btnUnk.Location = New System.Drawing.Point(6, 110)
        Me.btnUnk.Name = "btnUnk"
        Me.btnUnk.Size = New System.Drawing.Size(77, 24)
        Me.btnUnk.TabIndex = 33
        Me.btnUnk.Text = "Unknowns"
        Me.btnUnk.UseVisualStyleBackColor = True
        '
        'btnSec
        '
        Me.btnSec.Location = New System.Drawing.Point(6, 79)
        Me.btnSec.Name = "btnSec"
        Me.btnSec.Size = New System.Drawing.Size(77, 24)
        Me.btnSec.TabIndex = 32
        Me.btnSec.Text = "Secondaries"
        Me.btnSec.UseVisualStyleBackColor = True
        '
        'btnStd
        '
        Me.btnStd.Location = New System.Drawing.Point(6, 19)
        Me.btnStd.Name = "btnStd"
        Me.btnStd.Size = New System.Drawing.Size(77, 24)
        Me.btnStd.TabIndex = 30
        Me.btnStd.Text = "Standards"
        Me.btnStd.UseVisualStyleBackColor = True
        '
        'btnBlk
        '
        Me.btnBlk.Location = New System.Drawing.Point(6, 49)
        Me.btnBlk.Name = "btnBlk"
        Me.btnBlk.Size = New System.Drawing.Size(77, 24)
        Me.btnBlk.TabIndex = 31
        Me.btnBlk.Text = "Blanks"
        Me.btnBlk.UseVisualStyleBackColor = True
        '
        'btnFactReset
        '
        Me.btnFactReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnFactReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFactReset.Location = New System.Drawing.Point(308, 102)
        Me.btnFactReset.Name = "btnFactReset"
        Me.btnFactReset.Size = New System.Drawing.Size(75, 43)
        Me.btnFactReset.TabIndex = 35
        Me.btnFactReset.Text = "Factory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reset"
        Me.btnFactReset.UseVisualStyleBackColor = False
        '
        'bntResetOptions
        '
        Me.bntResetOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntResetOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntResetOptions.Location = New System.Drawing.Point(308, 55)
        Me.bntResetOptions.Name = "bntResetOptions"
        Me.bntResetOptions.Size = New System.Drawing.Size(75, 43)
        Me.bntResetOptions.TabIndex = 34
        Me.bntResetOptions.Text = "Reset to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previous"
        Me.bntResetOptions.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnScheme2)
        Me.GroupBox4.Controls.Add(Me.btnScheme1)
        Me.GroupBox4.Controls.Add(Me.btn9)
        Me.GroupBox4.Controls.Add(Me.btn8)
        Me.GroupBox4.Controls.Add(Me.btn7)
        Me.GroupBox4.Controls.Add(Me.btn6)
        Me.GroupBox4.Controls.Add(Me.btn5)
        Me.GroupBox4.Controls.Add(Me.btn4)
        Me.GroupBox4.Controls.Add(Me.btn3)
        Me.GroupBox4.Controls.Add(Me.btn2)
        Me.GroupBox4.Controls.Add(Me.btn1)
        Me.GroupBox4.Controls.Add(Me.btn0)
        Me.GroupBox4.Location = New System.Drawing.Point(105, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 148)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Plot Colors"
        '
        'btnScheme2
        '
        Me.btnScheme2.BackColor = System.Drawing.Color.Silver
        Me.btnScheme2.ForeColor = System.Drawing.Color.Black
        Me.btnScheme2.Location = New System.Drawing.Point(116, 116)
        Me.btnScheme2.Name = "btnScheme2"
        Me.btnScheme2.Size = New System.Drawing.Size(64, 24)
        Me.btnScheme2.TabIndex = 43
        Me.btnScheme2.Text = "Scheme 2"
        Me.btnScheme2.UseVisualStyleBackColor = False
        '
        'btnScheme1
        '
        Me.btnScheme1.BackColor = System.Drawing.Color.Silver
        Me.btnScheme1.ForeColor = System.Drawing.Color.Black
        Me.btnScheme1.Location = New System.Drawing.Point(116, 87)
        Me.btnScheme1.Name = "btnScheme1"
        Me.btnScheme1.Size = New System.Drawing.Size(64, 24)
        Me.btnScheme1.TabIndex = 42
        Me.btnScheme1.Text = "Scheme 1"
        Me.btnScheme1.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.ForeColor = System.Drawing.Color.White
        Me.btn9.Location = New System.Drawing.Point(116, 57)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(38, 24)
        Me.btn9.TabIndex = 41
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = True
        '
        'btn8
        '
        Me.btn8.ForeColor = System.Drawing.Color.White
        Me.btn8.Location = New System.Drawing.Point(116, 27)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(38, 24)
        Me.btn8.TabIndex = 40
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.ForeColor = System.Drawing.Color.White
        Me.btn7.Location = New System.Drawing.Point(61, 117)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(38, 24)
        Me.btn7.TabIndex = 39
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.ForeColor = System.Drawing.Color.White
        Me.btn6.Location = New System.Drawing.Point(61, 87)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(38, 24)
        Me.btn6.TabIndex = 38
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.ForeColor = System.Drawing.Color.White
        Me.btn5.Location = New System.Drawing.Point(61, 57)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(38, 24)
        Me.btn5.TabIndex = 37
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.ForeColor = System.Drawing.Color.White
        Me.btn4.Location = New System.Drawing.Point(61, 27)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(38, 24)
        Me.btn4.TabIndex = 36
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.ForeColor = System.Drawing.Color.White
        Me.btn3.Location = New System.Drawing.Point(6, 117)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(38, 24)
        Me.btn3.TabIndex = 35
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.Location = New System.Drawing.Point(6, 87)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(38, 24)
        Me.btn2.TabIndex = 34
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.ForeColor = System.Drawing.Color.White
        Me.btn1.Location = New System.Drawing.Point(6, 57)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(38, 24)
        Me.btn1.TabIndex = 33
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn0
        '
        Me.btn0.ForeColor = System.Drawing.Color.White
        Me.btn0.Location = New System.Drawing.Point(6, 27)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(38, 24)
        Me.btn0.TabIndex = 32
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnHelp.Location = New System.Drawing.Point(12, 373)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(50, 24)
        Me.btnHelp.TabIndex = 32
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(228, 323)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(181, 37)
        Me.btnCancel.TabIndex = 33
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(434, 412)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.tbcOpt)
        Me.Controls.Add(Me.bntQuit)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Options"
        Me.Text = "SNICSer Options"
        Me.TopMost = True
        Me.gpbAnalyst.ResumeLayout(False)
        Me.gpbAnalyst.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudNumStds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudSymbSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumFnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudResSigFig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRunSigFig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcOpt.ResumeLayout(False)
        Me.tpCalc.ResumeLayout(False)
        Me.tbAppear.ResumeLayout(False)
        Me.tbcColor.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gpbAnalyst As System.Windows.Forms.GroupBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAnalyst As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblstds As System.Windows.Forms.Label
    Friend WithEvents lblFit As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFitType As System.Windows.Forms.ComboBox
    Friend WithEvents nudNumStds As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudRunSigFig As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudResSigFig As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkGroup As System.Windows.Forms.CheckBox
    Friend WithEvents bntQuit As System.Windows.Forms.Button
    Friend WithEvents tbcOpt As System.Windows.Forms.TabControl
    Friend WithEvents tpCalc As System.Windows.Forms.TabPage
    Friend WithEvents tbAppear As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUnk As System.Windows.Forms.Button
    Friend WithEvents btnSec As System.Windows.Forms.Button
    Friend WithEvents btnStd As System.Windows.Forms.Button
    Friend WithEvents btnBlk As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnScheme2 As System.Windows.Forms.Button
    Friend WithEvents btnScheme1 As System.Windows.Forms.Button
    Friend WithEvents chkRememberMe As System.Windows.Forms.CheckBox
    Friend WithEvents bntResetOptions As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbNumVar As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents nudNumFnt As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbNumMult As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnFactReset As System.Windows.Forms.Button
    Friend WithEvents chk2StdDev As System.Windows.Forms.CheckBox
    Friend WithEvents nudSymbSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents tbcColor As System.Windows.Forms.TabPage
    Friend WithEvents chkWide As System.Windows.Forms.CheckBox
    Friend WithEvents chkTall As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkTopPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkClassic As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowSelfNorm As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkShowStdsBlanks As System.Windows.Forms.CheckBox
End Class
