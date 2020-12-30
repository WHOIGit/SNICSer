<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SNICSrFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SNICSrFrm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.InpsectRawDataFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadRestOfRawDataFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tspPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TargetTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FudgerStyleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseImportFIleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmFillInC13Table = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmPrintTargetTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspCompare = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalizedResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlankCorrectedResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlagsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmBlankCorrect = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspNukeDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCommit = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommitGroupToDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspWriteDatabaseImportFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetAllFlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InheritFirstsFlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InheritSecondsFlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompareFlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountFlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspGroupMerge = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspGroupSplit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspGroupRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspListGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlotGroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertyPropertyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspPlotAllStds = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspPlotStds = New System.Windows.Forms.ToolStripMenuItem()
        Me.AMSVsIRMSDC13ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandardsAndBlanksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TargetInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tspShowSecondaries = New System.Windows.Forms.ToolStripMenuItem()
        Me.TALLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TALLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WIDEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.ofdLoadFile = New System.Windows.Forms.OpenFileDialog()
        Me.dgvInputData = New System.Windows.Forms.DataGridView()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.dgvTargets = New System.Windows.Forms.DataGridView()
        Me.dgvRuns = New System.Windows.Forms.DataGridView()
        Me.lblRuns = New System.Windows.Forms.Label()
        Me.chkStandards = New System.Windows.Forms.CheckBox()
        Me.chkBlanks = New System.Windows.Forms.CheckBox()
        Me.chkSecondaries = New System.Windows.Forms.CheckBox()
        Me.chkUnknowns = New System.Windows.Forms.CheckBox()
        Me.lblDGVTarg = New System.Windows.Forms.Label()
        Me.lblInputDataList = New System.Windows.Forms.Label()
        Me.lblStats = New System.Windows.Forms.Label()
        Me.dgvSecs = New System.Windows.Forms.DataGridView()
        Me.lblSecStds = New System.Windows.Forms.Label()
        Me.chkDoCalc = New System.Windows.Forms.CheckBox()
        Me.btnPlotAllStds = New System.Windows.Forms.Button()
        Me.btnPlotStandards = New System.Windows.Forms.Button()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdPrintFile = New System.Windows.Forms.SaveFileDialog()
        Me.ofdLoadFudgerFile = New System.Windows.Forms.OpenFileDialog()
        Me.ofdReLoadFile = New System.Windows.Forms.OpenFileDialog()
        Me.sdfSaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.cmbPlot = New System.Windows.Forms.ComboBox()
        Me.flpPlotCalc = New System.Windows.Forms.FlowLayoutPanel()
        Me.flpSampleTypeChkBoxes = New System.Windows.Forms.FlowLayoutPanel()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInputData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTargets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRuns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSecs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpPlotCalc.SuspendLayout()
        Me.flpSampleTypeChkBoxes.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.FlagsToolStripMenuItem, Me.tspGroup, Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.CommentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1389, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmLoad, Me.InpsectRawDataFile, Me.mnuReload, Me.LoadRestOfRawDataFromFileToolStripMenuItem, Me.ToolStripSeparator3, Me.tspPrint, Me.ToolStripSeparator2, Me.tsmFillInC13Table, Me.ToolStripSeparator4, Me.tsmPrintTargetTable, Me.tsmSave, Me.tspCompare, Me.tsmBlankCorrect, Me.tspNukeDatabase, Me.tsmCommit, Me.CommitGroupToDatabaseToolStripMenuItem, Me.tspWriteDatabaseImportFile, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem, Me.tspQuit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'tsmLoad
        '
        Me.tsmLoad.Name = "tsmLoad"
        Me.tsmLoad.Size = New System.Drawing.Size(245, 22)
        Me.tsmLoad.Text = "Load"
        '
        'InpsectRawDataFile
        '
        Me.InpsectRawDataFile.Name = "InpsectRawDataFile"
        Me.InpsectRawDataFile.Size = New System.Drawing.Size(245, 22)
        Me.InpsectRawDataFile.Text = "Inspect a Raw Data File"
        '
        'mnuReload
        '
        Me.mnuReload.Name = "mnuReload"
        Me.mnuReload.Size = New System.Drawing.Size(245, 22)
        Me.mnuReload.Text = "ReLoad Saved Analysis From File"
        '
        'LoadRestOfRawDataFromFileToolStripMenuItem
        '
        Me.LoadRestOfRawDataFromFileToolStripMenuItem.Name = "LoadRestOfRawDataFromFileToolStripMenuItem"
        Me.LoadRestOfRawDataFromFileToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.LoadRestOfRawDataFromFileToolStripMenuItem.Text = "Load Rest of Raw Data From File"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(242, 6)
        '
        'tspPrint
        '
        Me.tspPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TargetTableToolStripMenuItem, Me.ReportToolStripMenuItem, Me.FudgerStyleReportToolStripMenuItem, Me.DatabaseImportFIleToolStripMenuItem})
        Me.tspPrint.Name = "tspPrint"
        Me.tspPrint.Size = New System.Drawing.Size(245, 22)
        Me.tspPrint.Text = "Print"
        Me.tspPrint.Visible = False
        '
        'TargetTableToolStripMenuItem
        '
        Me.TargetTableToolStripMenuItem.Name = "TargetTableToolStripMenuItem"
        Me.TargetTableToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.TargetTableToolStripMenuItem.Text = "Target Table"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
        Me.ReportToolStripMenuItem.Visible = False
        '
        'FudgerStyleReportToolStripMenuItem
        '
        Me.FudgerStyleReportToolStripMenuItem.Name = "FudgerStyleReportToolStripMenuItem"
        Me.FudgerStyleReportToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.FudgerStyleReportToolStripMenuItem.Text = "Fudger Style Report"
        '
        'DatabaseImportFIleToolStripMenuItem
        '
        Me.DatabaseImportFIleToolStripMenuItem.Name = "DatabaseImportFIleToolStripMenuItem"
        Me.DatabaseImportFIleToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.DatabaseImportFIleToolStripMenuItem.Text = "Database Import FIle"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(242, 6)
        '
        'tsmFillInC13Table
        '
        Me.tsmFillInC13Table.Name = "tsmFillInC13Table"
        Me.tsmFillInC13Table.Size = New System.Drawing.Size(245, 22)
        Me.tsmFillInC13Table.Text = "Fill in C13 Table"
        Me.tsmFillInC13Table.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(242, 6)
        '
        'tsmPrintTargetTable
        '
        Me.tsmPrintTargetTable.Name = "tsmPrintTargetTable"
        Me.tsmPrintTargetTable.Size = New System.Drawing.Size(245, 22)
        Me.tsmPrintTargetTable.Text = "Print Target Table"
        '
        'tsmSave
        '
        Me.tsmSave.Enabled = False
        Me.tsmSave.Name = "tsmSave"
        Me.tsmSave.Size = New System.Drawing.Size(245, 22)
        Me.tsmSave.Text = "Save Analysis to File"
        '
        'tspCompare
        '
        Me.tspCompare.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormalizedResultsToolStripMenuItem, Me.BlankCorrectedResultsToolStripMenuItem, Me.FlagsToolStripMenuItem1})
        Me.tspCompare.Name = "tspCompare"
        Me.tspCompare.Size = New System.Drawing.Size(245, 22)
        Me.tspCompare.Text = "Compare"
        Me.tspCompare.Visible = False
        '
        'NormalizedResultsToolStripMenuItem
        '
        Me.NormalizedResultsToolStripMenuItem.Name = "NormalizedResultsToolStripMenuItem"
        Me.NormalizedResultsToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.NormalizedResultsToolStripMenuItem.Text = "Normalized Results"
        '
        'BlankCorrectedResultsToolStripMenuItem
        '
        Me.BlankCorrectedResultsToolStripMenuItem.Name = "BlankCorrectedResultsToolStripMenuItem"
        Me.BlankCorrectedResultsToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.BlankCorrectedResultsToolStripMenuItem.Text = "Blank Corrected Results"
        Me.BlankCorrectedResultsToolStripMenuItem.Visible = False
        '
        'FlagsToolStripMenuItem1
        '
        Me.FlagsToolStripMenuItem1.Name = "FlagsToolStripMenuItem1"
        Me.FlagsToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
        Me.FlagsToolStripMenuItem1.Text = "Flags"
        Me.FlagsToolStripMenuItem1.Visible = False
        '
        'tsmBlankCorrect
        '
        Me.tsmBlankCorrect.Name = "tsmBlankCorrect"
        Me.tsmBlankCorrect.Size = New System.Drawing.Size(245, 22)
        Me.tsmBlankCorrect.Text = "Blank Correct"
        Me.tsmBlankCorrect.Visible = False
        '
        'tspNukeDatabase
        '
        Me.tspNukeDatabase.Name = "tspNukeDatabase"
        Me.tspNukeDatabase.Size = New System.Drawing.Size(245, 22)
        Me.tspNukeDatabase.Text = "Clean From Database"
        Me.tspNukeDatabase.Visible = False
        '
        'tsmCommit
        '
        Me.tsmCommit.Name = "tsmCommit"
        Me.tsmCommit.Size = New System.Drawing.Size(245, 22)
        Me.tsmCommit.Text = "Commit to Database"
        Me.tsmCommit.Visible = False
        '
        'CommitGroupToDatabaseToolStripMenuItem
        '
        Me.CommitGroupToDatabaseToolStripMenuItem.Enabled = False
        Me.CommitGroupToDatabaseToolStripMenuItem.Name = "CommitGroupToDatabaseToolStripMenuItem"
        Me.CommitGroupToDatabaseToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.CommitGroupToDatabaseToolStripMenuItem.Text = "Commit Group to Database"
        '
        'tspWriteDatabaseImportFile
        '
        Me.tspWriteDatabaseImportFile.Name = "tspWriteDatabaseImportFile"
        Me.tspWriteDatabaseImportFile.Size = New System.Drawing.Size(245, 22)
        Me.tspWriteDatabaseImportFile.Text = "Write Database Import File"
        Me.tspWriteDatabaseImportFile.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ExitToolStripMenuItem.Text = "Exit and Maybe Save to File"
        '
        'tspQuit
        '
        Me.tspQuit.Name = "tspQuit"
        Me.tspQuit.Size = New System.Drawing.Size(245, 22)
        Me.tspQuit.Text = "Quit, Bail Out, and Give Up!"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspHelp, Me.tspAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'tspHelp
        '
        Me.tspHelp.Name = "tspHelp"
        Me.tspHelp.Size = New System.Drawing.Size(107, 22)
        Me.tspHelp.Text = "Help"
        '
        'tspAbout
        '
        Me.tspAbout.Name = "tspAbout"
        Me.tspAbout.Size = New System.Drawing.Size(107, 22)
        Me.tspAbout.Text = "About"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'FlagsToolStripMenuItem
        '
        Me.FlagsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetAllFlagsToolStripMenuItem, Me.InheritFirstsFlagsToolStripMenuItem, Me.InheritSecondsFlagsToolStripMenuItem, Me.CompareFlagsToolStripMenuItem, Me.CountFlagsToolStripMenuItem})
        Me.FlagsToolStripMenuItem.Name = "FlagsToolStripMenuItem"
        Me.FlagsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.FlagsToolStripMenuItem.Text = "Flags"
        '
        'ResetAllFlagsToolStripMenuItem
        '
        Me.ResetAllFlagsToolStripMenuItem.Name = "ResetAllFlagsToolStripMenuItem"
        Me.ResetAllFlagsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ResetAllFlagsToolStripMenuItem.Text = "Reset All Flags"
        '
        'InheritFirstsFlagsToolStripMenuItem
        '
        Me.InheritFirstsFlagsToolStripMenuItem.Name = "InheritFirstsFlagsToolStripMenuItem"
        Me.InheritFirstsFlagsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.InheritFirstsFlagsToolStripMenuItem.Text = "Inherit First's Flags"
        Me.InheritFirstsFlagsToolStripMenuItem.Visible = False
        '
        'InheritSecondsFlagsToolStripMenuItem
        '
        Me.InheritSecondsFlagsToolStripMenuItem.Name = "InheritSecondsFlagsToolStripMenuItem"
        Me.InheritSecondsFlagsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.InheritSecondsFlagsToolStripMenuItem.Text = "Inherit Second's Flags"
        Me.InheritSecondsFlagsToolStripMenuItem.Visible = False
        '
        'CompareFlagsToolStripMenuItem
        '
        Me.CompareFlagsToolStripMenuItem.Name = "CompareFlagsToolStripMenuItem"
        Me.CompareFlagsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CompareFlagsToolStripMenuItem.Text = "Compare Flags"
        Me.CompareFlagsToolStripMenuItem.Visible = False
        '
        'CountFlagsToolStripMenuItem
        '
        Me.CountFlagsToolStripMenuItem.Name = "CountFlagsToolStripMenuItem"
        Me.CountFlagsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CountFlagsToolStripMenuItem.Text = "Count Flags"
        '
        'tspGroup
        '
        Me.tspGroup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspGroupMerge, Me.tspGroupSplit, Me.tspGroupRestore, Me.tspListGroups, Me.PlotGroupsToolStripMenuItem})
        Me.tspGroup.Name = "tspGroup"
        Me.tspGroup.Size = New System.Drawing.Size(52, 20)
        Me.tspGroup.Text = "Group"
        '
        'tspGroupMerge
        '
        Me.tspGroupMerge.Name = "tspGroupMerge"
        Me.tspGroupMerge.Size = New System.Drawing.Size(154, 22)
        Me.tspGroupMerge.Text = "Merge Groups"
        '
        'tspGroupSplit
        '
        Me.tspGroupSplit.Name = "tspGroupSplit"
        Me.tspGroupSplit.Size = New System.Drawing.Size(154, 22)
        Me.tspGroupSplit.Text = "Split Group"
        '
        'tspGroupRestore
        '
        Me.tspGroupRestore.Name = "tspGroupRestore"
        Me.tspGroupRestore.Size = New System.Drawing.Size(154, 22)
        Me.tspGroupRestore.Text = "Restore Groups"
        '
        'tspListGroups
        '
        Me.tspListGroups.Name = "tspListGroups"
        Me.tspListGroups.Size = New System.Drawing.Size(154, 22)
        Me.tspListGroups.Text = "List Groups"
        '
        'PlotGroupsToolStripMenuItem
        '
        Me.PlotGroupsToolStripMenuItem.Name = "PlotGroupsToolStripMenuItem"
        Me.PlotGroupsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PlotGroupsToolStripMenuItem.Text = "Plot Groups"
        Me.PlotGroupsToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertyPropertyToolStripMenuItem, Me.tspPlotAllStds, Me.tspPlotStds, Me.AMSVsIRMSDC13ToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.ToolStripMenuItem1.Text = "Plot"
        '
        'PropertyPropertyToolStripMenuItem
        '
        Me.PropertyPropertyToolStripMenuItem.Enabled = False
        Me.PropertyPropertyToolStripMenuItem.Name = "PropertyPropertyToolStripMenuItem"
        Me.PropertyPropertyToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PropertyPropertyToolStripMenuItem.Text = "Property-Property"
        '
        'tspPlotAllStds
        '
        Me.tspPlotAllStds.Name = "tspPlotAllStds"
        Me.tspPlotAllStds.Size = New System.Drawing.Size(173, 22)
        Me.tspPlotAllStds.Text = "Plot All Standards"
        '
        'tspPlotStds
        '
        Me.tspPlotStds.Name = "tspPlotStds"
        Me.tspPlotStds.Size = New System.Drawing.Size(173, 22)
        Me.tspPlotStds.Text = "Plot Standards"
        '
        'AMSVsIRMSDC13ToolStripMenuItem
        '
        Me.AMSVsIRMSDC13ToolStripMenuItem.Name = "AMSVsIRMSDC13ToolStripMenuItem"
        Me.AMSVsIRMSDC13ToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AMSVsIRMSDC13ToolStripMenuItem.Text = "AMS vs IRMS dC13"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StandardsAndBlanksToolStripMenuItem, Me.TargetInfoToolStripMenuItem, Me.tspShowSecondaries, Me.TALLToolStripMenuItem})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(44, 20)
        Me.ToolStripMenuItem3.Text = "View"
        '
        'StandardsAndBlanksToolStripMenuItem
        '
        Me.StandardsAndBlanksToolStripMenuItem.Enabled = False
        Me.StandardsAndBlanksToolStripMenuItem.Name = "StandardsAndBlanksToolStripMenuItem"
        Me.StandardsAndBlanksToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.StandardsAndBlanksToolStripMenuItem.Text = "Standards and Blanks"
        '
        'TargetInfoToolStripMenuItem
        '
        Me.TargetInfoToolStripMenuItem.Name = "TargetInfoToolStripMenuItem"
        Me.TargetInfoToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.TargetInfoToolStripMenuItem.Text = "Target Info"
        '
        'tspShowSecondaries
        '
        Me.tspShowSecondaries.Enabled = False
        Me.tspShowSecondaries.Name = "tspShowSecondaries"
        Me.tspShowSecondaries.Size = New System.Drawing.Size(199, 22)
        Me.tspShowSecondaries.Text = "Show Secondaries Table"
        '
        'TALLToolStripMenuItem
        '
        Me.TALLToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TALLToolStripMenuItem1, Me.WIDEToolStripMenuItem})
        Me.TALLToolStripMenuItem.Name = "TALLToolStripMenuItem"
        Me.TALLToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.TALLToolStripMenuItem.Text = "Screen Size"
        '
        'TALLToolStripMenuItem1
        '
        Me.TALLToolStripMenuItem1.Name = "TALLToolStripMenuItem1"
        Me.TALLToolStripMenuItem1.Size = New System.Drawing.Size(102, 22)
        Me.TALLToolStripMenuItem1.Text = "TALL"
        '
        'WIDEToolStripMenuItem
        '
        Me.WIDEToolStripMenuItem.Name = "WIDEToolStripMenuItem"
        Me.WIDEToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.WIDEToolStripMenuItem.Text = "WIDE"
        '
        'CommentToolStripMenuItem
        '
        Me.CommentToolStripMenuItem.Name = "CommentToolStripMenuItem"
        Me.CommentToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.CommentToolStripMenuItem.Text = "Comment"
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.Tan
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(2, 27)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(108, 27)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'ofdLoadFile
        '
        Me.ofdLoadFile.DefaultExt = "XLS"
        Me.ofdLoadFile.FileName = "ofdLoadFile"
        Me.ofdLoadFile.Filter = "SNICS Files|*.XLS;*.TXT"
        Me.ofdLoadFile.InitialDirectory = "C:\Users\wjj\Desktop\CFAMS-Tandetron CLIVAR Comparison"
        Me.ofdLoadFile.Title = "Load SNICS File"
        '
        'dgvInputData
        '
        Me.dgvInputData.AllowUserToAddRows = False
        Me.dgvInputData.AllowUserToDeleteRows = False
        Me.dgvInputData.AllowUserToResizeColumns = False
        Me.dgvInputData.AllowUserToResizeRows = False
        Me.dgvInputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInputData.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInputData.Location = New System.Drawing.Point(783, 58)
        Me.dgvInputData.MultiSelect = False
        Me.dgvInputData.Name = "dgvInputData"
        Me.dgvInputData.RowHeadersWidth = 51
        Me.dgvInputData.Size = New System.Drawing.Size(594, 531)
        Me.dgvInputData.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(7, 34)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(76, 16)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Loading..."
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'dgvTargets
        '
        Me.dgvTargets.AllowUserToAddRows = False
        Me.dgvTargets.AllowUserToDeleteRows = False
        Me.dgvTargets.AllowUserToResizeColumns = False
        Me.dgvTargets.AllowUserToResizeRows = False
        Me.dgvTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTargets.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTargets.Location = New System.Drawing.Point(3, 58)
        Me.dgvTargets.MultiSelect = False
        Me.dgvTargets.Name = "dgvTargets"
        Me.dgvTargets.ReadOnly = True
        Me.dgvTargets.RowHeadersVisible = False
        Me.dgvTargets.RowHeadersWidth = 20
        Me.dgvTargets.Size = New System.Drawing.Size(774, 576)
        Me.dgvTargets.TabIndex = 4
        '
        'dgvRuns
        '
        Me.dgvRuns.AllowUserToAddRows = False
        Me.dgvRuns.AllowUserToDeleteRows = False
        Me.dgvRuns.AllowUserToResizeColumns = False
        Me.dgvRuns.AllowUserToResizeRows = False
        Me.dgvRuns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRuns.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRuns.Location = New System.Drawing.Point(3, 678)
        Me.dgvRuns.MultiSelect = False
        Me.dgvRuns.Name = "dgvRuns"
        Me.dgvRuns.RowHeadersWidth = 25
        Me.dgvRuns.Size = New System.Drawing.Size(793, 143)
        Me.dgvRuns.TabIndex = 5
        '
        'lblRuns
        '
        Me.lblRuns.AutoSize = True
        Me.lblRuns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuns.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblRuns.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuns.Location = New System.Drawing.Point(10, 656)
        Me.lblRuns.Name = "lblRuns"
        Me.lblRuns.Size = New System.Drawing.Size(124, 18)
        Me.lblRuns.TabIndex = 6
        Me.lblRuns.Text = "Runs for Sample"
        Me.lblRuns.Visible = False
        '
        'chkStandards
        '
        Me.chkStandards.AutoSize = True
        Me.chkStandards.Checked = True
        Me.chkStandards.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStandards.Location = New System.Drawing.Point(247, 3)
        Me.chkStandards.Name = "chkStandards"
        Me.chkStandards.Size = New System.Drawing.Size(74, 17)
        Me.chkStandards.TabIndex = 7
        Me.chkStandards.Text = "Standards"
        Me.chkStandards.UseVisualStyleBackColor = True
        '
        'chkBlanks
        '
        Me.chkBlanks.AutoSize = True
        Me.chkBlanks.Checked = True
        Me.chkBlanks.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBlanks.Location = New System.Drawing.Point(9, 3)
        Me.chkBlanks.Name = "chkBlanks"
        Me.chkBlanks.Size = New System.Drawing.Size(58, 17)
        Me.chkBlanks.TabIndex = 8
        Me.chkBlanks.Text = "Blanks"
        Me.chkBlanks.UseVisualStyleBackColor = True
        '
        'chkSecondaries
        '
        Me.chkSecondaries.AutoSize = True
        Me.chkSecondaries.Checked = True
        Me.chkSecondaries.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSecondaries.Location = New System.Drawing.Point(73, 3)
        Me.chkSecondaries.Name = "chkSecondaries"
        Me.chkSecondaries.Size = New System.Drawing.Size(85, 17)
        Me.chkSecondaries.TabIndex = 9
        Me.chkSecondaries.Text = "Secondaries"
        Me.chkSecondaries.UseVisualStyleBackColor = True
        '
        'chkUnknowns
        '
        Me.chkUnknowns.AutoSize = True
        Me.chkUnknowns.Checked = True
        Me.chkUnknowns.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnknowns.Location = New System.Drawing.Point(164, 3)
        Me.chkUnknowns.Name = "chkUnknowns"
        Me.chkUnknowns.Size = New System.Drawing.Size(77, 17)
        Me.chkUnknowns.TabIndex = 10
        Me.chkUnknowns.Text = "Unknowns"
        Me.chkUnknowns.UseVisualStyleBackColor = True
        '
        'lblDGVTarg
        '
        Me.lblDGVTarg.AutoSize = True
        Me.lblDGVTarg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDGVTarg.Location = New System.Drawing.Point(140, 31)
        Me.lblDGVTarg.Name = "lblDGVTarg"
        Me.lblDGVTarg.Size = New System.Drawing.Size(95, 20)
        Me.lblDGVTarg.TabIndex = 11
        Me.lblDGVTarg.Text = "Target List"
        '
        'lblInputDataList
        '
        Me.lblInputDataList.AutoSize = True
        Me.lblInputDataList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputDataList.Location = New System.Drawing.Point(798, 35)
        Me.lblInputDataList.Name = "lblInputDataList"
        Me.lblInputDataList.Size = New System.Drawing.Size(19, 20)
        Me.lblInputDataList.TabIndex = 16
        Me.lblInputDataList.Text = "+"
        '
        'lblStats
        '
        Me.lblStats.AutoSize = True
        Me.lblStats.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStats.Location = New System.Drawing.Point(799, 604)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(138, 16)
        Me.lblStats.TabIndex = 21
        Me.lblStats.Text = "Standard Statistics"
        Me.lblStats.Visible = False
        '
        'dgvSecs
        '
        Me.dgvSecs.AllowUserToAddRows = False
        Me.dgvSecs.AllowUserToDeleteRows = False
        Me.dgvSecs.AllowUserToResizeColumns = False
        Me.dgvSecs.AllowUserToResizeRows = False
        Me.dgvSecs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvSecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSecs.Location = New System.Drawing.Point(802, 678)
        Me.dgvSecs.MultiSelect = False
        Me.dgvSecs.Name = "dgvSecs"
        Me.dgvSecs.ReadOnly = True
        Me.dgvSecs.RowHeadersVisible = False
        Me.dgvSecs.RowHeadersWidth = 20
        Me.dgvSecs.Size = New System.Drawing.Size(575, 143)
        Me.dgvSecs.TabIndex = 25
        Me.dgvSecs.Visible = False
        '
        'lblSecStds
        '
        Me.lblSecStds.AutoSize = True
        Me.lblSecStds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecStds.Location = New System.Drawing.Point(799, 659)
        Me.lblSecStds.Name = "lblSecStds"
        Me.lblSecStds.Size = New System.Drawing.Size(158, 16)
        Me.lblSecStds.TabIndex = 26
        Me.lblSecStds.Text = "Secondary Standards"
        Me.lblSecStds.Visible = False
        '
        'chkDoCalc
        '
        Me.chkDoCalc.AutoSize = True
        Me.chkDoCalc.Checked = True
        Me.chkDoCalc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDoCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDoCalc.Location = New System.Drawing.Point(297, 3)
        Me.chkDoCalc.Name = "chkDoCalc"
        Me.chkDoCalc.Size = New System.Drawing.Size(66, 24)
        Me.chkDoCalc.TabIndex = 27
        Me.chkDoCalc.Text = "Auto"
        Me.chkDoCalc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDoCalc.UseVisualStyleBackColor = True
        '
        'btnPlotAllStds
        '
        Me.btnPlotAllStds.BackColor = System.Drawing.Color.PeachPuff
        Me.btnPlotAllStds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlotAllStds.Location = New System.Drawing.Point(7, 3)
        Me.btnPlotAllStds.Name = "btnPlotAllStds"
        Me.btnPlotAllStds.Size = New System.Drawing.Size(102, 27)
        Me.btnPlotAllStds.TabIndex = 28
        Me.btnPlotAllStds.Text = "Plot All Stds"
        Me.btnPlotAllStds.UseVisualStyleBackColor = False
        '
        'btnPlotStandards
        '
        Me.btnPlotStandards.BackColor = System.Drawing.Color.PeachPuff
        Me.btnPlotStandards.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlotStandards.Location = New System.Drawing.Point(115, 3)
        Me.btnPlotStandards.Name = "btnPlotStandards"
        Me.btnPlotStandards.Size = New System.Drawing.Size(50, 27)
        Me.btnPlotStandards.TabIndex = 29
        Me.btnPlotStandards.Text = "Plot"
        Me.btnPlotStandards.UseVisualStyleBackColor = False
        '
        'btnCalculate
        '
        Me.btnCalculate.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btnCalculate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculate.Location = New System.Drawing.Point(369, 3)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(100, 27)
        Me.btnCalculate.TabIndex = 30
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = False
        '
        'ofdLoadFudgerFile
        '
        Me.ofdLoadFudgerFile.DefaultExt = "XLS"
        Me.ofdLoadFudgerFile.FileName = "ofdLoadFudgerFile"
        Me.ofdLoadFudgerFile.Filter = "SNICS Files|*.XLS"
        Me.ofdLoadFudgerFile.InitialDirectory = "C:\Users\wjj\Desktop\CFAMS-Tandetron CLIVAR Comparison"
        Me.ofdLoadFudgerFile.Title = "Load Fudger Results File"
        '
        'ofdReLoadFile
        '
        Me.ofdReLoadFile.DefaultExt = "XLS"
        Me.ofdReLoadFile.FileName = "ofdLoadFile"
        Me.ofdReLoadFile.Title = "Load SNICS File"
        '
        'sdfSaveFile
        '
        Me.sdfSaveFile.FileName = "sd"
        '
        'cmbPlot
        '
        Me.cmbPlot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlot.FormattingEnabled = True
        Me.cmbPlot.Items.AddRange(New Object() {"Standards", "Blanks", "Secondaries", "Unknowns", "All Samples"})
        Me.cmbPlot.Location = New System.Drawing.Point(171, 3)
        Me.cmbPlot.Name = "cmbPlot"
        Me.cmbPlot.Size = New System.Drawing.Size(120, 24)
        Me.cmbPlot.TabIndex = 31
        Me.cmbPlot.Text = "Standards"
        '
        'flpPlotCalc
        '
        Me.flpPlotCalc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpPlotCalc.Controls.Add(Me.btnCalculate)
        Me.flpPlotCalc.Controls.Add(Me.chkDoCalc)
        Me.flpPlotCalc.Controls.Add(Me.cmbPlot)
        Me.flpPlotCalc.Controls.Add(Me.btnPlotStandards)
        Me.flpPlotCalc.Controls.Add(Me.btnPlotAllStds)
        Me.flpPlotCalc.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpPlotCalc.Location = New System.Drawing.Point(917, 24)
        Me.flpPlotCalc.Name = "flpPlotCalc"
        Me.flpPlotCalc.Size = New System.Drawing.Size(472, 30)
        Me.flpPlotCalc.TabIndex = 32
        '
        'flpSampleTypeChkBoxes
        '
        Me.flpSampleTypeChkBoxes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpSampleTypeChkBoxes.Controls.Add(Me.chkStandards)
        Me.flpSampleTypeChkBoxes.Controls.Add(Me.chkUnknowns)
        Me.flpSampleTypeChkBoxes.Controls.Add(Me.chkSecondaries)
        Me.flpSampleTypeChkBoxes.Controls.Add(Me.chkBlanks)
        Me.flpSampleTypeChkBoxes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpSampleTypeChkBoxes.Location = New System.Drawing.Point(438, 34)
        Me.flpSampleTypeChkBoxes.Name = "flpSampleTypeChkBoxes"
        Me.flpSampleTypeChkBoxes.Size = New System.Drawing.Size(324, 24)
        Me.flpSampleTypeChkBoxes.TabIndex = 33
        '
        'SNICSrFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1389, 825)
        Me.Controls.Add(Me.flpSampleTypeChkBoxes)
        Me.Controls.Add(Me.flpPlotCalc)
        Me.Controls.Add(Me.dgvInputData)
        Me.Controls.Add(Me.lblSecStds)
        Me.Controls.Add(Me.dgvSecs)
        Me.Controls.Add(Me.lblStats)
        Me.Controls.Add(Me.lblInputDataList)
        Me.Controls.Add(Me.lblDGVTarg)
        Me.Controls.Add(Me.lblRuns)
        Me.Controls.Add(Me.dgvRuns)
        Me.Controls.Add(Me.dgvTargets)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Enabled = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SNICSrFrm"
        Me.Text = "SNICSer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInputData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTargets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRuns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSecs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpPlotCalc.ResumeLayout(False)
        Me.flpPlotCalc.PerformLayout()
        Me.flpSampleTypeChkBoxes.ResumeLayout(False)
        Me.flpSampleTypeChkBoxes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents ofdLoadFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgvInputData As System.Windows.Forms.DataGridView
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents dgvTargets As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRuns As System.Windows.Forms.DataGridView
    Friend WithEvents lblRuns As System.Windows.Forms.Label
    Friend WithEvents lblDGVTarg As System.Windows.Forms.Label
    Friend WithEvents chkUnknowns As System.Windows.Forms.CheckBox
    Friend WithEvents chkSecondaries As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlanks As System.Windows.Forms.CheckBox
    Friend WithEvents chkStandards As System.Windows.Forms.CheckBox
    Friend WithEvents lblInputDataList As System.Windows.Forms.Label
    Friend WithEvents lblStats As System.Windows.Forms.Label
    Friend WithEvents tsmSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertyPropertyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCommit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tspPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvSecs As System.Windows.Forms.DataGridView
    Friend WithEvents lblSecStds As System.Windows.Forms.Label
    Friend WithEvents chkDoCalc As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StandardsAndBlanksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPlotAllStds As System.Windows.Forms.Button
    Friend WithEvents btnPlotStandards As System.Windows.Forms.Button
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TargetInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspGroupMerge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspGroupSplit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspGroupRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspPlotAllStds As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspPlotStds As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspListGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspShowSecondaries As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TargetTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdPrintFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tspQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FudgerStyleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspCompare As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdLoadFudgerFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdReLoadFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sdfSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tsmBlankCorrect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbPlot As System.Windows.Forms.ComboBox
    Friend WithEvents NormalizedResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlankCorrectedResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TALLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TALLToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WIDEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetAllFlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InheritFirstsFlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InheritSecondsFlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspNukeDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AMSVsIRMSDC13ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InpsectRawDataFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspWriteDatabaseImportFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompareFlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlagsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CountFlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseImportFIleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFillInC13Table As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmPrintTargetTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlotGroupsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommitGroupToDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadRestOfRawDataFromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents flpPlotCalc As FlowLayoutPanel
    Friend WithEvents flpSampleTypeChkBoxes As FlowLayoutPanel
End Class
