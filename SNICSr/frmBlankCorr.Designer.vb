<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBlankCorr
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBlankCorr))
        Me.dgvStandards = New System.Windows.Forms.DataGridView()
        Me.lblStandards = New System.Windows.Forms.Label()
        Me.tbcGroups = New System.Windows.Forms.TabControl()
        Me.tbpGroup1 = New System.Windows.Forms.TabPage()
        Me.dgvInorganic = New System.Windows.Forms.DataGridView()
        Me.dgvOrganic = New System.Windows.Forms.DataGridView()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.dgvBlanks = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.sfdSaveBCResults = New System.Windows.Forms.SaveFileDialog()
        Me.dgvWatson = New System.Windows.Forms.DataGridView()
        Me.chkLockAll = New System.Windows.Forms.CheckBox()
        Me.tbResErr = New System.Windows.Forms.TextBox()
        Me.lblResErr = New System.Windows.Forms.Label()
        Me.dgvWS = New System.Windows.Forms.DataGridView()
        CType(Me.dgvStandards, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcGroups.SuspendLayout()
        CType(Me.dgvInorganic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrganic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBlanks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWatson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvStandards
        '
        Me.dgvStandards.AllowUserToAddRows = False
        Me.dgvStandards.AllowUserToDeleteRows = False
        Me.dgvStandards.AllowUserToResizeColumns = False
        Me.dgvStandards.AllowUserToResizeRows = False
        Me.dgvStandards.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStandards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvStandards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStandards.Location = New System.Drawing.Point(1, 125)
        Me.dgvStandards.Name = "dgvStandards"
        Me.dgvStandards.RowHeadersVisible = False
        Me.dgvStandards.RowHeadersWidth = 51
        Me.dgvStandards.Size = New System.Drawing.Size(1446, 193)
        Me.dgvStandards.TabIndex = 0
        '
        'lblStandards
        '
        Me.lblStandards.AutoSize = True
        Me.lblStandards.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStandards.Location = New System.Drawing.Point(3, 104)
        Me.lblStandards.Name = "lblStandards"
        Me.lblStandards.Size = New System.Drawing.Size(78, 16)
        Me.lblStandards.TabIndex = 2
        Me.lblStandards.Text = "Standards"
        '
        'tbcGroups
        '
        Me.tbcGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcGroups.Controls.Add(Me.tbpGroup1)
        Me.tbcGroups.Location = New System.Drawing.Point(1, 465)
        Me.tbcGroups.Name = "tbcGroups"
        Me.tbcGroups.SelectedIndex = 0
        Me.tbcGroups.Size = New System.Drawing.Size(1446, 423)
        Me.tbcGroups.TabIndex = 5
        '
        'tbpGroup1
        '
        Me.tbpGroup1.Location = New System.Drawing.Point(4, 22)
        Me.tbpGroup1.Name = "tbpGroup1"
        Me.tbpGroup1.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpGroup1.Size = New System.Drawing.Size(1438, 397)
        Me.tbpGroup1.TabIndex = 0
        Me.tbpGroup1.Text = "Group 1"
        Me.tbpGroup1.UseVisualStyleBackColor = True
        '
        'dgvInorganic
        '
        Me.dgvInorganic.AllowUserToAddRows = False
        Me.dgvInorganic.AllowUserToDeleteRows = False
        Me.dgvInorganic.AllowUserToResizeColumns = False
        Me.dgvInorganic.AllowUserToResizeRows = False
        Me.dgvInorganic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInorganic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInorganic.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInorganic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInorganic.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInorganic.Location = New System.Drawing.Point(159, 65)
        Me.dgvInorganic.Name = "dgvInorganic"
        Me.dgvInorganic.RowHeadersVisible = False
        Me.dgvInorganic.RowHeadersWidth = 51
        Me.dgvInorganic.Size = New System.Drawing.Size(315, 54)
        Me.dgvInorganic.TabIndex = 6
        '
        'dgvOrganic
        '
        Me.dgvOrganic.AllowUserToAddRows = False
        Me.dgvOrganic.AllowUserToDeleteRows = False
        Me.dgvOrganic.AllowUserToResizeColumns = False
        Me.dgvOrganic.AllowUserToResizeRows = False
        Me.dgvOrganic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOrganic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOrganic.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOrganic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrganic.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOrganic.Location = New System.Drawing.Point(159, 5)
        Me.dgvOrganic.Name = "dgvOrganic"
        Me.dgvOrganic.RowHeadersVisible = False
        Me.dgvOrganic.RowHeadersWidth = 51
        Me.dgvOrganic.Size = New System.Drawing.Size(314, 54)
        Me.dgvOrganic.TabIndex = 7
        '
        'btnDone
        '
        Me.btnDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDone.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(1258, 10)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(180, 34)
        Me.btnDone.TabIndex = 8
        Me.btnDone.Text = "Save and Continue"
        Me.btnDone.UseVisualStyleBackColor = False
        '
        'dgvBlanks
        '
        Me.dgvBlanks.AllowUserToAddRows = False
        Me.dgvBlanks.AllowUserToDeleteRows = False
        Me.dgvBlanks.AllowUserToResizeColumns = False
        Me.dgvBlanks.AllowUserToResizeRows = False
        Me.dgvBlanks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBlanks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvBlanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlanks.Location = New System.Drawing.Point(1, 324)
        Me.dgvBlanks.Name = "dgvBlanks"
        Me.dgvBlanks.RowHeadersVisible = False
        Me.dgvBlanks.RowHeadersWidth = 51
        Me.dgvBlanks.Size = New System.Drawing.Size(1446, 135)
        Me.dgvBlanks.TabIndex = 9
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(1283, 56)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(155, 34)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save To File"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvWatson
        '
        Me.dgvWatson.AllowUserToAddRows = False
        Me.dgvWatson.AllowUserToDeleteRows = False
        Me.dgvWatson.AllowUserToResizeColumns = False
        Me.dgvWatson.AllowUserToResizeRows = False
        Me.dgvWatson.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWatson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWatson.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvWatson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Format = "N4"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWatson.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvWatson.Location = New System.Drawing.Point(480, 65)
        Me.dgvWatson.Name = "dgvWatson"
        Me.dgvWatson.RowHeadersVisible = False
        Me.dgvWatson.RowHeadersWidth = 51
        Me.dgvWatson.Size = New System.Drawing.Size(314, 54)
        Me.dgvWatson.TabIndex = 11
        '
        'chkLockAll
        '
        Me.chkLockAll.AutoSize = True
        Me.chkLockAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLockAll.Location = New System.Drawing.Point(12, 5)
        Me.chkLockAll.Name = "chkLockAll"
        Me.chkLockAll.Size = New System.Drawing.Size(103, 28)
        Me.chkLockAll.TabIndex = 12
        Me.chkLockAll.Text = "Lock All"
        Me.chkLockAll.UseVisualStyleBackColor = True
        '
        'tbResErr
        '
        Me.tbResErr.Location = New System.Drawing.Point(12, 56)
        Me.tbResErr.Name = "tbResErr"
        Me.tbResErr.Size = New System.Drawing.Size(90, 20)
        Me.tbResErr.TabIndex = 13
        Me.tbResErr.Text = "0.0026"
        '
        'lblResErr
        '
        Me.lblResErr.AutoSize = True
        Me.lblResErr.Location = New System.Drawing.Point(12, 40)
        Me.lblResErr.Name = "lblResErr"
        Me.lblResErr.Size = New System.Drawing.Size(73, 13)
        Me.lblResErr.TabIndex = 15
        Me.lblResErr.Text = "Residual Error"
        '
        'dgvWS
        '
        Me.dgvWS.AllowUserToAddRows = False
        Me.dgvWS.AllowUserToDeleteRows = False
        Me.dgvWS.AllowUserToResizeColumns = False
        Me.dgvWS.AllowUserToResizeRows = False
        Me.dgvWS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.Format = "N4"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWS.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvWS.Location = New System.Drawing.Point(479, 5)
        Me.dgvWS.Name = "dgvWS"
        Me.dgvWS.RowHeadersVisible = False
        Me.dgvWS.RowHeadersWidth = 51
        Me.dgvWS.Size = New System.Drawing.Size(314, 54)
        Me.dgvWS.TabIndex = 16
        '
        'frmBlankCorr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1450, 890)
        Me.Controls.Add(Me.dgvWS)
        Me.Controls.Add(Me.lblResErr)
        Me.Controls.Add(Me.tbResErr)
        Me.Controls.Add(Me.chkLockAll)
        Me.Controls.Add(Me.dgvWatson)
        Me.Controls.Add(Me.dgvBlanks)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.dgvOrganic)
        Me.Controls.Add(Me.dgvInorganic)
        Me.Controls.Add(Me.tbcGroups)
        Me.Controls.Add(Me.lblStandards)
        Me.Controls.Add(Me.dgvStandards)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBlankCorr"
        Me.Text = "SNICSer Blank Corrections"
        CType(Me.dgvStandards, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcGroups.ResumeLayout(False)
        CType(Me.dgvInorganic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrganic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBlanks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWatson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvStandards As System.Windows.Forms.DataGridView
    Friend WithEvents lblStandards As System.Windows.Forms.Label
    Friend WithEvents tbcGroups As System.Windows.Forms.TabControl
    Friend WithEvents tbpGroup1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvInorganic As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOrganic As System.Windows.Forms.DataGridView
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents dgvBlanks As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents sfdSaveBCResults As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dgvWatson As System.Windows.Forms.DataGridView
    Friend WithEvents chkLockAll As System.Windows.Forms.CheckBox
    Friend WithEvents tbResErr As System.Windows.Forms.TextBox
    Friend WithEvents lblResErr As System.Windows.Forms.Label
    Friend WithEvents dgvWS As DataGridView
End Class
