Option Compare Text   ' ignore case on lexical comparisons

#Region "Imports"
Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports ZedGraph
Imports System.Diagnostics
Imports System.Net.Mail
Imports System.Runtime.InteropServices
#End Region  'namespace declarations

Public Class SNICSrFrm

    Public VERSION As Double = 2.91     ' this is the version number. Increment in units of 0.01 when updating 
    Public Const TEST As Boolean = True ' TRUE triggers test environment behavior, FALSE for production
    Public TTE As String = ""                   ' modifier for Database Test Table Extension

#Region "Constants, variables, etc"
    Dim CFAMS As New List(Of WheelID)     ' list of CFAMS wheel objects (see WheelID.vb)
    Dim USAMS As New List(Of WheelID)     ' list of USAMS wheel objects (see WheelID.vb)
    Public GroupAvgStdFm(MAXGROUPS) As Double       ' average Fm of standards in this group
    Public Peirce(60, 10) As Double                 ' storage for Peirce criteria lookup table
    Public SNICSerControlDir As String = ""         ' directory for email list
    Public MaxSmallSampleMass As Double = 100.0     ' maximum small sample mass (in micrograms) for automatic assignment
    ' (set to zero to suppress automatic assignment)

#Region "Array Sizes"
    Public Const MAXRUNS As Integer = 4000          ' maximum number of runs on a wheel
    Public Const MAXGROUPS As Integer = 100         ' maximum number of groups on a wheel
    Public Const MAXBURNS As Integer = 200          ' maximum number of times a target is burnt
    Public Const MAXTARGETS As Integer = 133        ' maximum number of targets on a wheel
#End Region

#Region "Flags"
    Public ShowStdsBlanks As Boolean = True     ' show standards and blanks window
    Public AllowSelfNorm As Boolean = False     ' default to no self-normalization
    Public ISPARTIALWHEEL As Boolean = False        ' whether part of a wheel analyzed
    Public ISREADONLY As Boolean = False        ' is set if the wheel is reported, hence read-only
    Public ISACQUIFILE As Boolean = False       ' true if reading the acquisition file
    Public WTDBLANK As Boolean = False          ' true if blanks are weighted mean values
    Public TALL As Boolean = False              ' display mode tall/short
    Public WIDE As Boolean = False              ' display mode wide/narrow
    Public FIRSTAUTH As Boolean = True          ' assume you're the first authorizer until shown otherwise
    Public SECONDAUTH As Boolean = False        ' and not second authorizer
    Public REAUTH As Boolean = False            ' true if you're doing it a second time
    Public SAVEDTODATABASE As Boolean = False   ' true if saved to database
    Public IamLoading As Boolean = False        ' true if loading a file
    Public TypeSubstFlag As Boolean = False     ' true if a standard flag is not recognized
    Public CLEANDB As Boolean = True            ' assume not data in the database
    Public GROUPBOUNDS As Boolean = True        ' whether group boundaries are respected
    Public CheckStates(4) As Boolean            ' status of target table check boxes
    Public IamBuildingTrees As Boolean = False  ' true if building trees
    Public BLANKCORRECTED As Boolean = False    ' set when blank correction applied
    Public FIRSTPROPPROP As Boolean = True      ' true on first property-property plot
    Public IAMINSPECTING As Boolean = False     ' true if only inpsecting file (no write)
    Public LOADEDWHEEL As Boolean = False       ' set to true once wheel is loaded
    Public FirstTimeThrough As Boolean = True   ' cleared once you've loaded and gone through the data first time
    Public RememberMe As Boolean = False        ' temporary storage for whether "Remember Me" is Checked
#End Region

#Region "General Variables"

#Region "About the current wheel"
    Public WheelName As String = ""
    Public TheWheel As WheelID = Nothing
    Public FirstAuthName As String = ""
    Public FirstAuthDate As DateTime
    Public SecondAuthName As String = ""
    Public SecondAuthDate As DateTime
#End Region

#Region "Directories and Filenames"
    Public MySNICSerDir As String = ""
    Public HomeDirectory As String = ""
    Public FileName As String = ""              ' the input file name
    Public OutFileName As String = ""           ' the output file name
#End Region

    Public NumRuns As Integer = 0           ' number of runs counter
    Public RawCol As Integer = 0            ' pointer to column having raw data to be plotted
    Public oVarSel As Integer = 0           ' pointer to column of alternate raw data to be plotted
    Public RawNum As Integer = 0            ' number of raw data points being plotted
    Public ConString As String = ""         ' Connection string: "Data Source=nosams-prod.whoi.edu;Database=amsprod;User ID=YourUserName;Password=YourPassword;"
    Public PlotPtr As New PrintDocument         ' used to print plots
    Public thePlot As Bitmap                    ' bitmap storage for plots
    Public WormType As String = "S"             ' type of sample being wormed
    Public WormName As String = "Standards"     ' name of sample being wormed
    Public thePWD As String = ""            ' database password
    Public FileHeader(6) As String          ' file header info passed on with file
    Public PlotList(300) As Integer         ' list of cumulative plot target numbers
    Public NumPlots As Integer = 0          ' number of targets in list
    Public GroupTimes(200) As Double           ' a listing of group time boundaries
    Public GroupEnd(200) As Integer             ' the run number at end of group
    Public NumGroups As Integer             ' the number of groups
    Public nBogus As Integer = 0            ' number of bogus lines read in the input file
    Public BogusLines(200) As Integer       ' listing of run numbers of bogus lines
#End Region         ' general variables

#Region "Data Tables"
    Public InputData As New DataTable("InputData")
    Public RunsData As New DataTable("Runs")
    Public StandardsValues As New DataTable("StandardsValues")
    Public BlanksValues As New DataTable("BlanksValues")
    Public SecsValues As New DataTable("Secondaries")
    Public TargetInfo As New DataTable("TargetInfo")
    Public SplitList As New DataTable("SplitList")
    Public Comparison As New DataTable("Comparison")
    Public BCComparison As New DataTable("BCComparison")
    Public TargetData As New DataTable("Targets")
    Public CommentTable As New DataTable("Comments")
    Public FlagTable As New DataTable("Flags")
    Public NormTable As New DataTable("NormTable")
#End Region

#Region "Input Table Storage"
    Public SmpTimes(MAXRUNS) As Integer        ' time since start in seconds 
    Public RunTimes(MAXRUNS) As Double         ' run times in full date-time format
    Public iRunTimes(MAXRUNS) As Integer       ' run times in seconds since start of run
    Public RunPos(MAXRUNS) As Integer          ' target number (position) of run
    Public IsStd(MAXRUNS) As Boolean         ' sample type = true if standard and O
    Public GroupNums(MAXRUNS) As Integer       ' group numbers for a given run
    Public TP_Nums(MAXRUNS) As Integer         ' target press number for each run
    Public Rat(MAXRUNS) As Double
    Public ErrRat(MAXRUNS) As Double
    Public NormRat(MAXRUNS) As Double
    Public NormRatErr(MAXRUNS) As Double
    Public C13C12(MAXRUNS) As Double
    Public SigC13C12(MAXRUNS) As Double
    Public StdC13C12(MAXRUNS) As Double        ' the standard's C13C12 absolute ratio
    Public StdC14C12(MAXRUNS) As Double        ' the standard's C14C12 absolute ratio
    Public Samp_Typ(MAXRUNS) As String         ' the original sample type is stored here
    Public pRunNums(MAXRUNS) As Integer          ' the original run numbers
    Public pRunFlags(MAXRUNS) As Boolean        ' the original run flags
    Public pRunTypes(MAXRUNS) As String         ' the original run types
    Public pRuns As Integer = 0                 ' the number of partial runs
#End Region

#Region "Target Table Storage"
    Public TargetIsPresent(MAXTARGETS) As Boolean       ' whether a target is present/run
    Public TargetIsReadOnly(MAXTARGETS) As Boolean        ' target is a read only (has been promoted to OS table)
    Public TargetNonPerf(MAXTARGETS) As Boolean        ' target non-performer flag
    Public TargetIsSmall(MAXTARGETS) As Boolean        ' if considered a small sample
    Public TargetNames(MAXTARGETS) As String           ' target names
    Public TargetTypes(MAXTARGETS) As String           ' target types
    Public TargetRunTimes(MAXTARGETS) As Double        ' time of first run   
    Public OrigTypes(MAXTARGETS) As String             ' originally assigned target types
    Public TargetRuns(MAXTARGETS) As Integer           ' number of unflagged target runs
    Public TargetGroups(MAXTARGETS) As Integer         ' nominal group name for targets
    Public TargetProcs(MAXTARGETS) As String           ' process type for target sample
    Public TargetProcNums(MAXTARGETS) As Integer       ' target process numbers
    Public TotalRuns(MAXTARGETS) As Integer            ' total number of target runs (initially)
    Public TargetMass(MAXTARGETS) As Double            ' target mass
    Public TotalMass(MAXTARGETS) As Double             ' total mass of CO2
    Public TargetRat(MAXTARGETS) As Double             ' target normalized ratio
    Public AsmRat(MAXTARGETS) As Double                ' assumed ratio (where relevant)
    Public IntErr(MAXTARGETS) As Double                ' computed target internal error
    Public ExtErr(MAXTARGETS) As Double                ' computed target external errror
    Public Tp_Num(MAXTARGETS) As Integer               ' target press numbers for each target
    Public C13Rat(MAXTARGETS) As Double                ' AMS avg normalized C13/12 ratio
    Public SigC13(MAXTARGETS) As Double                ' Ext Error for C13
    Public SigC13IntErr(MAXTARGETS) As Double          ' Int Error for C13
    Public Rec_Num(MAXTARGETS) As Integer              ' receipt numbers for each target
    Public RunKeys(MAXTARGETS, MAXBURNS) As Integer          ' pointers to where the runs are for each target
    Public TargetComments(MAXTARGETS) As String        ' individual target comments
    Public NumTargets As Integer = 0
    Public TargetSelected As Integer = -1
    Public IamBatching As Boolean = False
    Public SelectedTarget As Integer = -1
    Public MBCLgFm(MAXTARGETS) As Double                ' mass balance large blank correction values
    Public MBCLgFmSig(MAXTARGETS) As Double             ' uncertainty
    Public MBCFm(MAXTARGETS) As Double                  ' mass balance Fm
    Public MBCFmSig(MAXTARGETS) As Double               ' uncertainty
    Public MBCMass(MAXTARGETS) As Double                ' mass balance mass
    Public MBCMassSig(MAXTARGETS) As Double             ' uncertainty
    Public IRMSdC13(MAXTARGETS) As Double              ' the IRMS delC13 measurement
    Public IRMSdC13Pos(MAXTARGETS) As Integer          ' a list of the positions in the plot 
    Public pTargetPos(MAXTARGETS) As Integer        ' a list of target positions that have been run in a partial run
    Public pTargetNums As Integer               ' how many
    Public NumdC13Pos As Integer = 0            ' how many in plot
    Public GroupIsReadOnly(MAXGROUPS) As Boolean        ' whether a group is considered read only
#End Region    '       Target Table Storage

#Region "Standards and Blanks Storage"
    Public NumStds As Integer = 0
    Public Std_Rec_Num(500) As Integer
    Public Std_Name(500) As String
    Public Std_Fm(500) As Double
    Public Std_delC13(500) As Double
    Public Std_Flag(500) As Boolean
    Public FitMode As String = "Average"
    Public FitNum As Integer = 6
    Public StdNames(6) As String
    Public StdNormRat(6) As Double
    Public StdC13(6) As Double
    Public BlkNames(6) As String
    Public BlkNormRat(6) As Double
    Public BlkC13(6) As Double
    Public NumStdAssumed As Integer = 0        ' number of assumed standards values
    Public AssumedStdValues(200, 2) As Double   ' saving assumed standards values
    Public NumBlkAssumed As Integer = 0        ' number of assumed blanks values
    Public AssumedBlkValues(200, 2) As Double    ' saving assumed blanks values
#End Region    '       Standards Storage

#Region "Options"
    Public TableFontSize As Integer = 10
    Public UserName As String = ""
    Public Password As String = ""
    Public NumRawFigs As Integer = 4
    Public NumResFigs As Integer = 5
    Public CalcMode As String = "Average"
    Public CalcNum As Integer = 6
    Public eFnt() As String = {"0.00e+0", "0.000e+0", "0.0000e+0", "0.00000e+0", "0.000000e+0", "0.0000000e+0"}
    Public dFnt() As String = {"0.00", "0.000", "0.0000", "0.00000", "0.000000", "0.0000000"}
    Public NumVarPlt As String = "LE12C"
    Public NumVarFnt As Integer = 6
    Public NumVarMult As Double = 1000000.0
    Public NumStdDev As Integer = 2
    Public SymbSize As Integer = 6
    Public TopPlot As Boolean = False
    Public ClassicView As Boolean = False
    Public ShareDrivePath As String = "\\sharenosams.whoi.edu\shared"

#Region "Colors"
    Public PlotColsOrig() As Color = {Color.Purple, Color.Magenta, Color.Red, Color.DarkOrange, Color.Orange,
                                  Color.DarkOliveGreen, Color.Green, Color.DarkCyan, Color.Blue, Color.Black}
    Public PlotColsCB() As Color = {Color.Cyan, Color.Blue, Color.OliveDrab, Color.Green, Color.Pink,
                                  Color.Red, Color.Yellow, Color.Orange, Color.MediumPurple, Color.Purple}
    Public PlotCols() As Color = {Color.Purple, Color.Magenta, Color.Red, Color.DarkOrange, Color.Orange,
                                  Color.DarkOliveGreen, Color.Green, Color.DarkCyan, Color.Blue, Color.Black}
    Public StdCol As Color = Color.LightSteelBlue
    Public SecCol As Color = Color.Wheat
    Public BlkCol As Color = Color.LightCyan
    Public UnkCol As Color = Color.White
#End Region

#End Region

#Region "Blank Corrections"
    Public FmCorr(MAXTARGETS) As Double                ' fraction modern large blank corrected
    Public SigFmCorr(MAXTARGETS) As Double             ' uncertainty in above
    Public LgBlkFm(MAXTARGETS) As Double               ' large blank Fm applied
    Public SigLgBlkFm(MAXTARGETS) As Double            ' uncertainty in above
    Public FmMBCorr(MAXTARGETS) As Double              ' fraction modern corrected for mass balance blank
    Public SigFmMBCorr(MAXTARGETS) As Double           ' uncertainty in above
    Public MBBlkFm(MAXTARGETS) As Double               ' mass balance blank Fm applied
    Public SigMBBlkFm(MAXTARGETS) As Double            ' uncertainty in above
    Public MBBlkMass(MAXTARGETS) As Double             ' mass balance blank mass applied
    Public SigMBBlkMass(MAXTARGETS) As Double          ' uncertainty in above
    Public SigTargetMass(MAXTARGETS) As Double         ' uncertainty in target mass
    Public SigTotalMass(MAXTARGETS) As Double         ' uncertainty in total mass
#End Region

#End Region ' variable and storage declarations

    Private Sub SNICSrFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 10                 ' locate the main form in the upper left corner of the screen
        Me.Left = 10
        MySNICSerDir = My.Application.Info.DirectoryPath        ' save the location of the /App directory
        If TEST Then TTE = "_test" ' test environment Database Test Table name extension
        Try
            MySNICSerDir = MySNICSerDir.Substring(0, MySNICSerDir.Length - 3) & "SNICSER Results"
            Dim dirinfo As DirectoryInfo = New DirectoryInfo(MySNICSerDir)      ' locate the default Results directory
            If dirinfo.Exists Then dirinfo.CreateSubdirectory(UserName) ' and create personal directory (if it doesn't exist)
        Catch ex As Exception
            ' do nothing on error
        End Try
        SNICSerControlDir = My.Application.Info.DirectoryPath.Substring(0, My.Application.Info.DirectoryPath.Length - 3) & "Control\"      ' points to control directory for SNICSer
        MySNICSerDir = MySNICSerDir & "\" & UserName        ' points to personal directory
        MakeMeSmall()                                       ' shrink window to minimum size
        StdsAndBlks.Visible = False                         ' make sure standards and blanks window is invisible
        Me.Visible = False                                  ' I don't think this works
        Options.Focus()                                     ' set default focus to the Options window
        Options.Text = "SNICSer v" & VERSION.ToString("0.000") & " Options"     ' and give it a version specific title bar
        GetOptions()                ' get the options and update the window settings
        InitDataSets()              ' initialize the data arrays, data tables, and data grid views
        InitPrinter()             ' prepare for printing plots
        TurnOnNumLock()           ' turn num lock on if off (mainly for Macs)
        SetupTreeImages()             ' for the wheel browser window
        GetNotifyRecipients()         ' for email notification
        SetUpBailButton()
    End Sub             ' this executes on startup

#Region "Initialization"

    Public Sub InitDataSets()
        For i = 0 To TargetRuns.Length - 1
            TargetRuns(i) = 0.0
            RunKeys(i, 0) = 0
        Next
        SetupInputData()
        SetupTargetData()
        SetupRunsData()
        SetupSecsData()
        SetupWormLegend()
        SetupSplitList()
        SetupCompareList()
        SetupBCCompareList()
        SetupStandardsTables()          ' set up the data set structures for display and manipulation
        With Options
            .cmbNumVar.Items.Clear()
            .cmbNumVar.Items.Add("None")
            For i = 9 To 13
                .cmbNumVar.Items.Add(InputData.Columns(i).ColumnName)
            Next
        End With
    End Sub      ' Initialize the data tables

#Region "Set Up Data Tables"

    Public Sub SetupInputData()
        InputData.Columns.Clear()
        InputData.Columns.Add("OK", GetType(Boolean))               ' add all the columns in correct order
        InputData.Columns.Add("Run", GetType(Integer))
        InputData.Columns.Add("RunTime", GetType(Date))
        InputData.Columns.Add("Pos", GetType(Integer))
        InputData.Columns.Add("Grp", GetType(Integer))
        InputData.Columns.Add("Mst", GetType(Integer))
        InputData.Columns.Add("SampleName", GetType(String))
        InputData.Columns.Add("Typ", GetType(String))
        InputData.Columns.Add("Cycles", GetType(Double))
        InputData.Columns.Add("LE12C", GetType(Double))
        InputData.Columns.Add("LE13C", GetType(Double))
        InputData.Columns.Add("HE12C", GetType(Double))
        InputData.Columns.Add("HE13C", GetType(Double))
        InputData.Columns.Add("CntTotH", GetType(Integer))
        InputData.Columns.Add("CntTotS", GetType(Integer))
        InputData.Columns.Add("CntTotGT", GetType(Integer))
        InputData.Columns.Add("HE13/12", GetType(Double))
        InputData.Columns.Add("HE14/12", GetType(Double))
        InputData.Columns.Add("LTCorr", GetType(Double))
        InputData.Columns.Add("Corr14/12", GetType(Double))
        InputData.Columns.Add("Sig14/12", GetType(Double))
        InputData.Columns.Add("DelC13", GetType(Double))               ' add all the columns in correct order
        dgvInputData.DataSource = InputData                     ' link the datagrid view to the dataset
        dgvInputData.RowHeadersVisible = False                  ' show the row selector button
        dgvInputData.Columns("RunTime").DefaultCellStyle.Format = ("MMM dd HH:mm:ss")   ' format for date/time display
        For i = 9 To 20
            If (i < 13) Or (i > 15) Then
                dgvInputData.Columns(i).DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))     ' standardize the numeric display
            End If
        Next
        dgvInputData.Columns("DelC13").DefaultCellStyle.Format = (dFnt(NumRawFigs - 3))
        dgvInputData.Columns("HE13/12").DefaultCellStyle.Format = (dFnt(NumRawFigs - 3))
        dgvInputData.Columns("LTCorr").DefaultCellStyle.Format = (dFnt(NumRawFigs - 3))
        For i = 0 To InputData.Columns.Count - 1
            dgvInputData.Columns(i).SortMode = False                ' don't allow sorting of the data
            If (i > 0) Then dgvInputData.Columns(i).ReadOnly = True ' cannot change the data except the OK flag
        Next
        dgvInputData.Columns("SampleName").Frozen = True
        dgvInputData.Font = New Font("Arial Narrow", TableFontSize)
    End Sub

    Public Sub SetupSplitList()
        SplitList.Columns.Clear()
        SplitList.Columns.Add("OK", GetType(Boolean))               ' add all the columns in correct order
        SplitList.Columns.Add("Run", GetType(Integer))
        SplitList.Columns.Add("RunTime", GetType(Date))
        SplitList.Columns.Add("Pos", GetType(Integer))
        SplitList.Columns.Add("Grp", GetType(Integer))
        SplitList.Columns.Add("Mst", GetType(Integer))
        SplitList.Columns.Add("SampleName", GetType(String))
        SplitList.Columns.Add("Typ", GetType(String))
        SplitList.Columns.Add("Cycles", GetType(Double))
        SplitList.Columns.Add("LE12C", GetType(Double))
        SplitList.Columns.Add("LE13C", GetType(Double))
        SplitList.Columns.Add("HE12C", GetType(Double))
        SplitList.Columns.Add("HE13C", GetType(Double))
        SplitList.Columns.Add("CntTotH", GetType(Integer))
        SplitList.Columns.Add("CntTotS", GetType(Integer))
        SplitList.Columns.Add("CntTotGT", GetType(Integer))
        SplitList.Columns.Add("HE13/12", GetType(Double))
        SplitList.Columns.Add("HE14/12", GetType(Double))
        SplitList.Columns.Add("LTCorr", GetType(Double))
        SplitList.Columns.Add("Corr14/12", GetType(Double))
        SplitList.Columns.Add("Sig14/12", GetType(Double))
        SplitList.Columns.Add("DelC13", GetType(Double))
        With GroupSplit
            .dgvSplit.DataSource = SplitList
            .dgvSplit.RowHeadersVisible = False                  ' show the row selector button
            .dgvSplit.Font = New Font("Arial Narrow", TableFontSize)
            For i = 0 To .dgvSplit.Columns.Count - 1
                .dgvSplit.Columns(i).SortMode = False                ' don't allow sorting of the data
                .dgvSplit.Columns(i).ReadOnly = True ' cannot change the data except the OK flag
                .dgvSplit.Columns(i).DefaultCellStyle.Format = dgvInputData.Columns(i).DefaultCellStyle.Format
            Next
        End With
    End Sub

    Public Sub SetupTargetData()
        TargetData.Columns.Clear()
        TargetData.Columns.Add("NP", GetType(Boolean))
        TargetData.Columns.Add("Pos", GetType(Integer))               ' add all the columns in correct order
        TargetData.Columns.Add("SampleName", GetType(String))
        TargetData.Columns.Add("Rec_Num", GetType(Integer))
        TargetData.Columns.Add("Typ", GetType(String))
        TargetData.Columns.Add("Proc", GetType(String))
        TargetData.Columns.Add("Mass", GetType(Double))
        TargetData.Columns.Add("N", GetType(Integer))
        TargetData.Columns.Add("NormRat", GetType(Double))
        TargetData.Columns.Add("IntErr", GetType(Double))
        TargetData.Columns.Add("ExtErr", GetType(Double))
        TargetData.Columns.Add("DelC13", GetType(Double))
        TargetData.Columns.Add("SigC13", GetType(Double))
        TargetData.Columns.Add("MSdC13", GetType(Double))
        dgvTargets.DataSource = TargetData
        For i = 1 To TargetData.Columns.Count - 1
            If i > 0 Then dgvTargets.Columns(i).ReadOnly = True
            dgvTargets.Columns(i).SortMode = False
        Next
        dgvTargets.Columns("NP").ReadOnly = False
        dgvTargets.Columns("Mass").DefaultCellStyle.Format = "0.00"
        dgvTargets.Columns("NormRat").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvTargets.Columns("IntErr").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvTargets.Columns("ExtErr").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvTargets.Columns("DelC13").DefaultCellStyle.Format = ("0.00")
        dgvTargets.Columns("SigC13").DefaultCellStyle.Format = ("0.00")
        dgvTargets.Columns("Mass").DefaultCellStyle.Format = "0"
        dgvTargets.Columns("MSdC13").DefaultCellStyle.Format = "0.00"
        dgvTargets.Font = New Font("Arial Narrow", TableFontSize)
        TargetInfo.Columns.Clear()
        TargetInfo.Columns.Add("Pos", GetType(Integer))               ' add all the columns in correct order
        TargetInfo.Columns.Add("SampleName", GetType(String))
        TargetInfo.Columns.Add("TP_Num", GetType(Integer))
        TargetInfo.Columns.Add("Rec_Num", GetType(Integer))
        TargetInfo.Columns.Add("Typ", GetType(String))
        TargetInfo.Columns.Add("N", GetType(Integer))
        TargetInfo.Columns.Add("Mass", GetType(Double))
        TargetInfo.Columns.Add("Proc", GetType(String))
        TargetInfo.Columns.Add("Comment", GetType(String))
        With frmTargetInfo.dgvTargetInfo
            .DataSource = TargetInfo
            .Font = New Font("Arial Narrow", TableFontSize)
        End With
    End Sub

    Public Sub SetupRunsData()
        RunsData.Columns.Clear()
        RunsData.Columns.Add("OK", GetType(Boolean))               ' add all the columns in correct order
        RunsData.Columns.Add("RunTime", GetType(Date))               ' add all the columns in correct order
        RunsData.Columns.Add("Run", GetType(Integer))               ' add all the columns in correct order
        RunsData.Columns.Add("Mst", GetType(Integer))               ' add all the columns in correct order
        RunsData.Columns.Add("NormRat", GetType(Double))
        RunsData.Columns.Add("IntErr", GetType(Double))
        RunsData.Columns.Add("DelC13", GetType(Double))               ' add all the columns in correct order
        RunsData.Columns.Add("NormD13", GetType(Double))               ' add all the columns in correct order
        RunsData.Columns.Add("SigD13", GetType(Double))               ' add all the columns in correct order
        RunsData.Columns.Add("LE12C", GetType(Double))
        RunsData.Columns.Add("LE13C", GetType(Double))
        RunsData.Columns.Add("HE12C", GetType(Double))
        RunsData.Columns.Add("HE13C", GetType(Double))
        RunsData.Columns.Add("CntTotH", GetType(Integer))
        RunsData.Columns.Add("CntTotS", GetType(Integer))
        RunsData.Columns.Add("CntTotGT", GetType(Integer))
        RunsData.Columns.Add("HE13/12", GetType(Double))
        RunsData.Columns.Add("HE14/12", GetType(Double))
        RunsData.Columns.Add("LTCorr", GetType(Double))
        RunsData.Columns.Add("Corr14/12", GetType(Double))
        RunsData.Columns.Add("Sig14/12", GetType(Double))
        dgvRuns.DataSource = RunsData
        dgvRuns.Columns("LE12C").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("LE12C").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("HE12C").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("HE13C").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("HE13/12").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("HE14/12").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("LTCorr").DefaultCellStyle.Format = (dFnt(NumRawFigs - 3))
        dgvRuns.Columns("Corr14/12").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("Sig14/12").DefaultCellStyle.Format = (eFnt(NumRawFigs - 3))
        dgvRuns.Columns("DelC13").DefaultCellStyle.Format = ("0.00")
        dgvRuns.Columns("NormD13").DefaultCellStyle.Format = ("0.00")
        dgvRuns.Columns("SigD13").DefaultCellStyle.Format = ("0.00")
        dgvRuns.Columns("NormRat").DefaultCellStyle.Format = (dFnt(NumRawFigs - 3))
        dgvRuns.Columns("IntErr").DefaultCellStyle.Format = (dFnt(NumRawFigs - 3))
        dgvRuns.Columns("DelC13").Frozen = True
        dgvRuns.Columns("RunTime").DefaultCellStyle.Format = ("MMM dd HH:mm:ss")   ' format for date/time display
        dgvRuns.Font = New Font("Arial Narrow", TableFontSize)
        For i = 1 To RunsData.Columns.Count - 1
            dgvRuns.Columns(i).ReadOnly = True
            dgvRuns.Columns(i).SortMode = False
        Next
        Worms.cmbOther.Items.Clear()
        Worms.cmbOther.Items.Add("None")
        Worms.cmbOther.Text = "None"
        For i = 4 To RunsData.Columns.Count - 1
            Worms.cmbOther.Items.Add(RunsData.Columns(i).ColumnName)
        Next
        PlotRaw.cmbOther.Items.Add("None")
        PlotRaw.cmbOther.Text = "None"
        For i = 7 To InputData.Columns.Count - 1
            PlotRaw.cmbOther.Items.Add(i.ToString)                  'RunsData.Columns(i).ColumnName)
        Next
    End Sub

    Public Sub SetupSecsData()
        SecsValues.Columns.Clear()
        SecsValues.Columns.Add("Pos", GetType(Integer))
        SecsValues.Columns.Add("SampleName", GetType(String))
        SecsValues.Columns.Add("Rec_Num", GetType(Integer))
        SecsValues.Columns.Add("N", GetType(Integer))
        SecsValues.Columns.Add("NormRat", GetType(Double))
        SecsValues.Columns.Add("IntErr", GetType(Double))
        SecsValues.Columns.Add("ExtErr", GetType(Double))
        SecsValues.Columns.Add("Asm_Rat", GetType(Double))
        SecsValues.Columns.Add("Sigma", GetType(Double))
        dgvSecs.DataSource = SecsValues
        dgvSecs.Columns("NormRat").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvSecs.Columns("IntErr").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvSecs.Columns("ExtErr").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvSecs.Columns("Asm_Rat").DefaultCellStyle.Format = (dFnt(NumResFigs - 3))
        dgvSecs.Columns("Sigma").DefaultCellStyle.Format = ("0.00")
        dgvSecs.Font = New Font("Arial Narrow", TableFontSize)
    End Sub

    Public Sub SetupStandardsTables()
        StandardsValues.Columns.Clear()
        StandardsValues.Columns.Add("Pos", GetType(Integer))
        StandardsValues.Columns.Add("SampleName", GetType(String))
        StandardsValues.Columns.Add("Tp_Num", GetType(Integer))
        StandardsValues.Columns.Add("Rec_Num", GetType(Integer))
        StandardsValues.Columns.Add("Asm_Rat", GetType(Double))
        StandardsValues.Columns.Add("NormRat", GetType(Double))
        StandardsValues.Columns.Add("IntErr", GetType(Double))
        StandardsValues.Columns.Add("ExtErr", GetType(Double))
        StandardsValues.Columns.Add("Sigma", GetType(Double))
        StandardsValues.Columns.Add("Asm13/12", GetType(Double))
        StandardsValues.Columns.Add("C13/12", GetType(Double))
        BlanksValues.Columns.Clear()
        BlanksValues.Columns.Add("Pos", GetType(Integer))
        BlanksValues.Columns.Add("SampleName", GetType(String))
        BlanksValues.Columns.Add("Tp_Num", GetType(Integer))
        BlanksValues.Columns.Add("Rec_Num", GetType(Integer))
        BlanksValues.Columns.Add("Asm_Rat", GetType(Double))
        BlanksValues.Columns.Add("NormRat", GetType(Double))
        BlanksValues.Columns.Add("IntErr", GetType(Double))
        BlanksValues.Columns.Add("ExtErr", GetType(Double))
        BlanksValues.Columns.Add("Sigma", GetType(Double))
        BlanksValues.Columns.Add("Asm13/12", GetType(Double))
        BlanksValues.Columns.Add("C13/12", GetType(Double))
        With StdsAndBlks
            .dgvStandards.DataSource = StandardsValues
            .dgvStandards.Columns("Asm_Rat").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvStandards.Columns("NormRat").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvStandards.Columns("IntErr").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvStandards.Columns("ExtErr").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvStandards.Columns("Sigma").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvStandards.Columns("Asm13/12").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvStandards.Columns("C13/12").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            For i = 0 To StandardsValues.Columns.Count - 1
                .dgvStandards.Columns(i).SortMode = False
            Next
            .dgvStandards.Font = New Font("Arial Narrow", TableFontSize)
            .dgvBlanks.DataSource = BlanksValues
            .dgvBlanks.Columns("Asm_Rat").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvBlanks.Columns("NormRat").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvBlanks.Columns("IntErr").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvBlanks.Columns("ExtErr").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvBlanks.Columns("Sigma").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvBlanks.Columns("Asm13/12").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            .dgvBlanks.Columns("C13/12").DefaultCellStyle.Format = dFnt(NumResFigs - 3)
            For i = 0 To BlanksValues.Columns.Count - 1
                .dgvBlanks.Columns(i).SortMode = False
            Next
            .dgvBlanks.Font = New Font("Arial Narrow", TableFontSize)
            .cmbExternal.Visible = False
            .lblExternal.Visible = False
            .btnFill.Visible = False
            .cmbExternal.Items.Clear()
            .cmbExternal.Items.Add("OX-I")
            .cmbExternal.Items.Add("OX-II")
            .cmbExternal.Items.Add("Other")
            .cmbExternal.Text = "OX-II"
        End With
    End Sub

    Public Sub SetupCompareList()
        Comparison.Columns.Clear()
        Comparison.Columns.Add("NP", GetType(Boolean))
        Comparison.Columns.Add("Pos", GetType(Integer))               ' add all the columns in correct order
        Comparison.Columns.Add("SampleName", GetType(String))
        Comparison.Columns.Add("Rec_Num", GetType(Integer))
        Comparison.Columns.Add("1stTyp", GetType(String))
        Comparison.Columns.Add("2ndTyp", GetType(String))
        Comparison.Columns.Add("1stN", GetType(Integer))
        Comparison.Columns.Add("2ndN", GetType(Integer))
        Comparison.Columns.Add("1stNormRat", GetType(Double))
        Comparison.Columns.Add("2ndNormRat", GetType(Double))
        Comparison.Columns.Add("DelNormRat", GetType(Double))
        Comparison.Columns.Add("SigmaC14", GetType(Double))
        Comparison.Columns.Add("1stIntErr", GetType(Double))
        Comparison.Columns.Add("2ndIntErr", GetType(Double))
        Comparison.Columns.Add("1stExtErr", GetType(Double))
        Comparison.Columns.Add("2ndExtErr", GetType(Double))
        Comparison.Columns.Add("Comment", GetType(String))
        Compare.dgvCompare.Font = New Font("Arial Narrow", TableFontSize)
        'Comparison.Columns.Add("1stDelC13", GetType(Double))
        'Comparison.Columns.Add("2ndDelC13", GetType(Double))
        'Comparison.Columns.Add("DelDelC13", GetType(Double))
        'Comparison.Columns.Add("SigmaC13", GetType(Double))
        'Comparison.Columns.Add("1stSigC13", GetType(Double))
        'Comparison.Columns.Add("2ndSigC13", GetType(Double))
    End Sub

    Public Sub SetupBCCompareList()
        BCComparison.Columns.Clear()
        BCComparison.Columns.Add("Pos", GetType(Integer))               ' add all the columns in correct order
        BCComparison.Columns.Add("SampleName", GetType(String))
        BCComparison.Columns.Add("Rec_Num", GetType(Integer))
        BCComparison.Columns.Add("1stFmCorr", GetType(Double))
        BCComparison.Columns.Add("2ndFmCorr", GetType(Double))
        BCComparison.Columns.Add("DelFmCorr", GetType(Double))
        BCComparison.Columns.Add("SigmaFmCorr", GetType(Double))
        BCComparison.Columns.Add("1stSigFmCorr", GetType(Double))
        BCComparison.Columns.Add("2ndSigFmCorr", GetType(Double))
        BCComparison.Columns.Add("DelSigFmCorr", GetType(Double))
        BCComparison.Columns.Add("Comment", GetType(String))
    End Sub

#End Region 'Set up various data tables and their corresponding gridviews

    Public Sub InitParams()
        FirstTimeThrough = True
        FIRSTAUTH = False
        SECONDAUTH = False
        BLANKCORRECTED = False
        LOADEDWHEEL = False
        REAUTH = False
        SAVEDTODATABASE = False
        tsmCommit.Visible = False
        NumStdAssumed = 0                  ' start with no assumptions
        NumBlkAssumed = 0
        chkDoCalc.Checked = True
        chkStandards.Checked = True
        chkBlanks.Checked = True
        chkSecondaries.Checked = True
        chkUnknowns.Checked = True
        IamLoading = True
        btnLoad.Visible = False
        tspPrint.Visible = False
    End Sub         ' initializes basic parameters on load/reload

    Public Sub SetupWormLegend()
        With Worms
            .Legend.Columns.Clear()
            .Legend.Columns.Add("Pos")
            .Legend.Columns.Add("SampleName")
            .dgvLgndWorms.DataSource = .Legend
            .dgvLgndWorms.Font = New Font("Arial Narrow", TableFontSize, FontStyle.Bold)
        End With
        With PlotRaw
            .Legend.Columns.Clear()
            .Legend.Columns.Add("Pos")
            .Legend.Columns.Add("SampleName")
            .dgvLgndWorms.DataSource = .Legend
            .dgvLgndWorms.Font = New Font("Arial Narrow", TableFontSize, FontStyle.Bold)
        End With
    End Sub

    Private Sub MakeMeSmall()
        Me.Width = btnLoad.Right + 50
        Me.Height = btnLoad.Bottom + MenuStrip1.Height + 15
    End Sub

    Public Sub GetOptions()
        Me.Visible = False
        'HomeDirectory = My.Application.Info.DirectoryPath      ' OLD CONFIGURATION
        HomeDirectory = "C:\SNICSer\" & Environment.UserName
        If Not Directory.Exists(HomeDirectory) Then
            Try
                Directory.CreateDirectory(HomeDirectory)
            Catch ex As Exception
                MsgBox(HomeDirectory & " doesn't exist, and I can't create it" & vbCrLf & "Please create it manually and try again" & vbCrLf & ex.Message)
                End
            End Try
        End If
        Try
            FileOpen(1, HomeDirectory & "\SNICSer.opt", OpenMode.Input)
            Input(1, NumRawFigs)
            Input(1, NumResFigs)
            Input(1, TableFontSize)
            Input(1, CalcNum)
            CalcMode = LineInput(1)
            UserName = LineInput(1)
            StdCol = ReadColor()
            BlkCol = ReadColor()
            SecCol = ReadColor()
            UnkCol = ReadColor()
            For i = 0 To PlotCols.Length - 1
                PlotCols(i) = ReadColor()
            Next
            thePWD = LineInput(1)
            RememberMe = LineInput(1)
            Input(1, NumVarFnt)               'NumVarFnt = CInt(LineInput(1))
            Input(1, NumVarMult)
            NumVarPlt = LineInput(1)
            Input(1, NumStdDev)
            Input(1, SymbSize)
            Input(1, TALL)
            Input(1, WIDE)
            Input(1, TopPlot)
            Input(1, ClassicView)
            Input(1, GROUPBOUNDS)
            ShareDrivePath = LineInput(1)
            FileClose(1)
        Catch ex As Exception       ' cannot find options file so force them to fill it in 
            Try
                FileClose(1)
            Catch ex1 As Exception
                ' do nothing here
            End Try
        End Try
        AssignOptionButtons()
        Options.Left = Me.Right
        Options.Top = Me.Bottom
        Options.Visible = True
    End Sub

    Public Sub AssignOptionButtons()
        With Options
            .btn0.BackColor = PlotCols(0)
            .btn1.BackColor = PlotCols(1)
            .btn2.BackColor = PlotCols(2)
            .btn3.BackColor = PlotCols(3)
            .btn4.BackColor = PlotCols(4)
            .btn5.BackColor = PlotCols(5)
            .btn6.BackColor = PlotCols(6)
            .btn7.BackColor = PlotCols(7)
            .btn8.BackColor = PlotCols(8)
            .btn9.BackColor = PlotCols(9)
            .btnStd.BackColor = StdCol
            .btnBlk.BackColor = BlkCol
            .btnSec.BackColor = SecCol
            .btnUnk.BackColor = UnkCol
            .nudFontSize.Value = TableFontSize
            .nudNumStds.Value = CalcNum
            .nudResSigFig.Value = NumResFigs
            .nudRunSigFig.Value = NumRawFigs
            .txtAnalyst.Text = Trim(UserName)
            .txtPwd.Text = thePWD
            .txtShareDrivePath.Text = ShareDrivePath
            .cmbFitType.Text = Trim(CalcMode)
            '.txtPwd.Text = ""
            .txtPwd.Focus()
            .chkRememberMe.Checked = RememberMe
            .cmbNumVar.Text = NumVarPlt
            .nudNumFnt.Value = NumVarFnt
            .cmbNumMult.Text = NumVarMult.ToString("0.0e0")
            .chkTall.Checked = TALL
            .chkWide.Checked = WIDE
            .chkTopPlot.Checked = TopPlot
            .chkClassic.Checked = ClassicView
            .chkGroup.Checked = GROUPBOUNDS
            Worms.TopMost = TopPlot
            If NumStdDev = 2 Then
                .chk2StdDev.Checked = True
            Else
                .chk2StdDev.Checked = False
            End If
            .nudSymbSize.Value = SymbSize
            .Visible = True
        End With

    End Sub

    Public Function ReadColor() As Color
        Dim col(3) As Byte
        For i = 0 To 3
            Input(1, col(i))
        Next
        ReadColor = Color.FromArgb(col(0), col(1), col(2), col(3))
    End Function

    Public Sub SetUpStds()
        Dim NewRow As DataRow
        StandardsValues.Clear()
        BlanksValues.Clear()
        For i = 0 To TargetData.Rows.Count - 1          ' first load the receipt numbers into the target table
            TargetData(i).Item("Rec_Num") = Rec_Num(TargetData(i).Item("Pos"))
        Next
        Dim theName As String = ""
        Dim theRecNum As Integer = 0
        Dim theFm As Double = 42
        Dim theDel As Double = 42
        StandardsValues.Clear()         ' clear the standards table
        Dim nSrow As Integer = 0
        Dim nBrow As Integer = 0
        For i = 0 To MAXTARGETS
            AsmRat(i) = 42
        Next
        For i = 0 To MAXTARGETS
            If TargetTypes(i) = "S" Then        ' if a standard then
                theName = TargetNames(i)
                theRecNum = Rec_Num(i)              'TargetData(i).Item("Rec_Num")
                theFm = 42
                theDel = 42
                For j = 0 To NumStds - 1
                    If Std_Rec_Num(j) = Rec_Num(i) Then
                        theName = Std_Name(j)
                        theRecNum = Std_Rec_Num(j)
                        theFm = Std_Fm(j)
                        theDel = Std_delC13(j)
                        Exit For
                    End If
                Next
                If theName <> "" Then
                    NewRow = StandardsValues.NewRow
                    NewRow("Pos") = i
                    NewRow("SampleName") = theName
                    NewRow("TP_Num") = Tp_Num(i)
                    NewRow("Rec_Num") = theRecNum
                    NewRow("Asm_Rat") = theFm
                    AsmRat(i) = theFm
                    NewRow("Asm13/12") = theDel
                    StandardsValues.Rows.Add(NewRow)
                End If
                If (theFm = 42) Or (theDel = 42) Then
                    With StdsAndBlks
                        .dgvStandards.Rows(nSrow).DefaultCellStyle.BackColor = Color.LightPink
                        .lblExternal.Visible = True
                        .cmbExternal.Visible = True
                        .btnFill.Visible = True
                    End With
                End If
                nSrow += 1
            ElseIf TargetTypes(i) = "B" Then
                theName = TargetNames(i)
                theRecNum = Rec_Num(i)          'TargetData(i).Item("Rec_Num")
                theFm = 42
                theDel = 42
                For j = 0 To NumStds - 1
                    If Std_Rec_Num(j) = Rec_Num(i) Then
                        theName = Std_Name(j)
                        theRecNum = Std_Rec_Num(j)
                        theFm = Std_Fm(j)
                        theDel = Std_delC13(j)
                        Exit For
                    End If
                Next
                If theName <> "" Then
                    NewRow = BlanksValues.NewRow
                    NewRow("Pos") = i
                    NewRow("TP_Num") = Tp_Num(i)
                    NewRow("SampleName") = theName
                    NewRow("Rec_Num") = theRecNum
                    NewRow("Asm_Rat") = theFm
                    NewRow("Asm13/12") = theDel
                    BlanksValues.Rows.Add(NewRow)
                End If
                If (theFm = 42) Or (theDel = 42) Then
                    StdsAndBlks.dgvBlanks.Rows(nBrow).DefaultCellStyle.BackColor = Color.LightPink
                End If
                nBrow += 1
            End If
        Next
        If ShowStdsBlanks = True Then
            StdsAndBlks.Visible = True
            ReSizeStdsAndBlks()
            Me.Visible = False
            CheckStdsAndBlks()
        End If

    End Sub

    Public Sub ReSizeStdsAndBlks()
        FullReSizeDGV(StdsAndBlks.dgvStandards, 25)
        FullReSizeDGV(StdsAndBlks.dgvBlanks, 25)
        With StdsAndBlks
            .lblBlks.Top = .dgvStandards.Bottom + 5
            .lblBlks.Left = .dgvStandards.Left
            .dgvBlanks.Top = .lblBlks.Bottom + 5
            .btnDone.Visible = True
            .Width = .dgvBlanks.Right + 20
            .Left = Me.Left
            .Top = Me.Top
            .Height = .dgvBlanks.Bottom + 50
        End With
    End Sub

    Public Sub CheckStdsAndBlks()
        With StdsAndBlks
            .btnDone.Visible = True
            For i = 0 To StandardsValues.Rows.Count - 1
                If (StandardsValues(i).Item("Asm_Rat") = 42) Or (StandardsValues(i).Item("Asm13/12") = 42) Then
                    .cmbExternal.Visible = True
                    .lblExternal.Visible = True
                    StdsAndBlks.dgvStandards.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                Else
                    StdsAndBlks.dgvStandards.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            Next
            For i = 0 To BlanksValues.Rows.Count - 1
                If (BlanksValues(i).Item("Asm_Rat") = 42) Or (BlanksValues(i).Item("Asm13/12") = 42) Then
                    '.btnDone.Visible = False
                    StdsAndBlks.dgvBlanks.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                Else
                    StdsAndBlks.dgvBlanks.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            Next
        End With
    End Sub

    Public Sub InitPrinter()
        Dim ptrname As String = ""
        For Each ptr As String In PrinterSettings.InstalledPrinters
            If InStr(ptr, "PDF") Then
                ptrname = ptr
            End If
        Next
        If ptrname <> "" Then           ' preferentially print to a pdf file, else to default printer
            PlotPtr.PrinterSettings.PrinterName = ptrname
            'MsgBox("You cannot print to PDFs")
        End If
        AddHandler PlotPtr.PrintPage, AddressOf Plot_PrintPage
    End Sub

    Public Sub ClearBlankCorr()
        For i = 0 To FmCorr.Length - 1
            FmCorr(i) = 0
            SigFmCorr(i) = 0
            LgBlkFm(i) = 0
            SigLgBlkFm(i) = 0
            FmMBCorr(i) = -99
            SigFmMBCorr(i) = -99
            MBBlkFm(i) = 0
            SigFmMBCorr(i) = 0
            MBBlkMass(i) = 0
            SigMBBlkMass(i) = 0
            SigTargetMass(i) = 0
            SigTotalMass(i) = 0
        Next
    End Sub      ' Clear blank correction arrays

    Private Sub GetNotifyRecipients()
        'this is just a filler until there is a list in the database
        Dim theName As String = ""
        Try
            FileOpen(22, SNICSerControlDir & "email.lst", OpenMode.Input)
            While Not EOF(22)
                theName = LineInput(22)
                If theName <> "" Then FrmNotify2ndAuth.lbx2ndAuth.Items.Add(theName)
            End While
            FileClose(22)
        Catch ex As Exception
            MsgBox("Problem accessing or reading " & SNICSerControlDir & "email.lst" & vbCrLf _
                   & "If you are in the development environment, this is OK" & vbCrLf _
                   & "Otherwise, please contact system adminstrator")
            FileClose(22)
            With FrmNotify2ndAuth
                .lbx2ndAuth.Items.Add("rhansman")
                .lbx2ndAuth.Items.Add("jhlavenka")
                .lbx2ndAuth.Items.Add("mkurz")
                .lbx2ndAuth.Items.Add("blongworth")
                .lbx2ndAuth.Items.Add("kelder")
                .lbx2ndAuth.Items.Add("mroberts")
                .lbx2ndAuth.Items.Add("agagnon")
                .lbx2ndAuth.Items.Add("shandwork")
            End With
        End Try
    End Sub   ' set up email list for notifications

    Private Sub SetUpBailButton()
        Dim i As Integer = Now.Second / 10        ' random number 0-5
        Dim theText() As String = {"The Hell With It", "Punt That Puppy", "Bail Out", "FahGeddAbowDit", "Gone Baby Gone", "I Give Up", "Quit, why don't you?"}
        Try
            Options.bntQuit.Text = theText(i)
        Catch ex As Exception
            Options.bntQuit.Text = "I Give Up!"
        End Try
    End Sub

    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte,
            ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)         ' this is needed for the next subroutine

    Private Sub TurnOnNumLock()
        Dim VK_NUMLOCK As Byte = &H90
        Dim BSCAN As Byte = &H45
        Dim dwFlag1 As Long = 1
        Dim dwFlag2 As Long = 3
        Dim dwExt As Long = 0
        ' turn on numlock
        Dim numlok As String = Chr(144)
        If Not My.Computer.Keyboard.NumLock Then
            keybd_event(VK_NUMLOCK, BSCAN, dwFlag1, dwExt)
            keybd_event(VK_NUMLOCK, BSCAN, dwFlag2, dwExt)
        End If
    End Sub         ' turn on Mark's numlock key

#Region "Wheel Browser"

    Private Sub SetupTreeImages()
        With BrowseWheel
            Try
                .iList.Images.Clear()
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Wheel0.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Wheel1.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Wheel2.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Month.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Year.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\SNICS.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Wheel1RO.jpg"))
                .iList.Images.Add(Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Wheel2RO.jpg"))
                .trvWheel.ImageList = .iList
            Catch ex As Exception
                MsgBox("Problem accessing or reading " & My.Application.Info.DirectoryPath & "\Images" & vbCrLf _
                    & "If you are in the development environment, this is OK" & vbCrLf _
                    & "Otherwise, please contact system adminstrator")
            End Try

        End With
    End Sub

    Private Sub SetupWheelBrowser()
        IamBuildingTrees = True
        With BrowseWheel
            .txtWheel.Text = ""
            .lblChoice.Text = ""
            .trvWheel.Nodes.Clear()
            .trvWheel.Nodes.Add("CFAMS", "CFAMS", 5, 5)
            .trvWheel.Nodes.Add("USAMS", "USAMS", 5, 5)
            DoTree(CFAMS, 0)
            DoTree(USAMS, 1)
        End With
        IamBuildingTrees = False
    End Sub

    Private Sub DoTree(AMS As List(Of WheelID), node As Integer)
        Dim Months As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                  "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
        With BrowseWheel
            Dim thisYear As Integer = CInt(Now.ToString("yy"))
            Dim thisMonth As Integer = CInt(Now.ToString("MM"))
            Dim yrno As Integer = -1
            For iy = thisYear To 9 Step -1
                Dim iyr As Integer = iy
                Dim tst As IEnumerable(Of String) = From g In AMS Where g.Year = iyr Select g.Name
                If tst.Count > 0 Then
                    .trvWheel.Nodes(node).Nodes.Add("20" & iy.ToString("00"), "20" & iy.ToString("00"), 4, 4)
                    yrno += 1
                End If
                Dim mno As Integer = -1
                For im = 1 To 12
                    Dim imonth As Integer = im
                    Dim subset As IEnumerable(Of WheelID) = From g In AMS Where g.Year = iyr And g.Month = imonth Order By g.Name Select g
                    If subset.Count > 0 Then
                        .trvWheel.Nodes(node).Nodes(yrno).Nodes.Add(Months(im - 1), Months(im - 1), 3, 3)
                        If (AMS Is CFAMS) And (UserName = "mr") And (iy = thisYear) And (im = thisMonth) Then .trvWheel.Nodes(node).Nodes(yrno).Expand()
                        If (AMS Is USAMS) And ((UserName = "kvr") Or (UserName = "brettl")) And (iy = thisYear) And (im = thisMonth) Then .trvWheel.Nodes(node).Nodes(yrno).Expand()
                        mno += 1
                        For Each s As WheelID In subset
                            Dim theImage As Integer = s.Analyzed
                            If s.IsReadOnly Then
                                theImage += 5
                            End If
                            .trvWheel.Nodes(node).Nodes(yrno).Nodes(mno).Nodes.Add(s.Name, s.Name, theImage, theImage)
                        Next
                        If imonth = thisMonth And iyr = thisYear Then .trvWheel.Nodes(node).Nodes(yrno).Nodes(mno).ExpandAll()
                    End If
                Next
            Next
        End With
    End Sub


#End Region

#End Region  ' Initialize variables, data tables, and forms

#Region "Procedures"

#Region "Data Loading"

    Private Function WheelFileName(ByRef Wheel As WheelID) As String
        Dim iyr As Integer = CInt(Now.ToString("yy"))
        Dim subDir As String = ""
        Dim FileName As String = ""
        If TheWheel.Year <> iyr Then subDir = "20" & TheWheel.Year.ToString & " Results\"
        If TEST Then
            If TheWheel.Name.Substring(0, 5) = "CFAMS" Then
                FileName = ShareDrivePath & "\SNICSer\ResultsTest\CFAMSResults\" & subDir & TheWheel.Name & "R.xls"
            Else
                FileName = ShareDrivePath & "\SNICSer\ResultsTest\USAMSResults\" & subDir & TheWheel.Name & "R.txt"
            End If
        Else
            If TheWheel.Name.Substring(0, 5) = "CFAMS" Then
                FileName = ShareDrivePath & "\CFAMS\CFAMS Results\" & subDir & TheWheel.Name & "R.xls"
            Else
                FileName = ShareDrivePath & "\USAMS\Results\" & subDir & TheWheel.Name & "R.txt"
            End If
        End If
        If TheWheel.Year <> iyr Then subDir = "20" & TheWheel.Year.ToString & " Results\"
        If TheWheel.Analyzed = 0 Then
            Dim fn As New FileInfo(FileName)
            If Not fn.Exists Then
                MsgBox(FileName & "Not found. Trying V: drive")
                If TheWheel.Name.Substring(0, 5) = "CFAMS" Then
                    FileName = "V:\CFAMS\CFAMS Results\" & subDir & TheWheel.Name & "R.xls"
                Else
                    FileName = "V:\USAMS\Results\" & subDir & TheWheel.Name & "R.txt"
                End If
                Dim fn1 As New FileInfo(FileName)
                If Not fn1.Exists Then
                    MsgBox("This wheel file  named " & FileName & " is not accessible" & vbCrLf & "The wheel may not have been run or someone has changed the file name from the original")
                    FileName = ""           ' bail only if you need the file
                End If
            End If
        End If
        '        MsgBox(FileName)
        Return FileName
    End Function

    Private Sub doLoad()
        InitParams()                ' initialize basic parameters on reload/load
        InitDataSets()
        MakeMeSmall()
        lblStatus.Text = "Select File..."
        ofdLoadFile.FileName = GetDirectoryName()
        FindAllWheels()
        If ClassicView Then
            ofdLoadFile.ShowDialog()
            FileName = ofdLoadFile.FileName
        Else
            BrowseWheel.ShowDialog()
            If Trim(BrowseWheel.lblChoice.Text) = "" Then
                btnLoad.Visible = True
                IamLoading = False
                Exit Sub
            End If
            TheWheel = GetWheelID(BrowseWheel.lblChoice.Text)       ' assign the current wheel to global wheelid struct
            FileName = WheelFileName(TheWheel)
        End If
        lblStatus.Text = "Loading File..."
        If Trim(FileName) = "" Then
            btnLoad.Visible = True
            IamLoading = False
            Exit Sub
        End If
        SaveDirectoryName(FileName)
        WheelName = ParseWheelName(FileName)
        If GetWheelID(WheelName).IsReadOnly Then MsgBox("SOME OR ALL OF THE SAMPLES ON THIS WHEEL" & vbCrLf _
                                            & "    HAVE BEEN PROMOTED TO THE OS TABLE AND POSSIBLY REPORTED" _
                                            & vbCrLf & "YOU MAY NOT BE ABLE TO SAVE PART OR ALL " & vbCrLf _
                                            & "     OF YOUR ANALYSIS TO THE DATABASE" & vbCrLf & "   OR CLEAN THE WHEEL FROM THE DATABASE")
        tspGroup.Visible = False
        Select Case GetWheelID(WheelName).Analyzed
            Case 0
                LoadRawDataFromFile(FileName)
                FIRSTAUTH = True
                REAUTH = False
                If GROUPBOUNDS Then tspGroup.Visible = True
            Case 1
                If TheWheel.FirstAuthName = UserName Then
                    REAUTH = True
                    FIRSTAUTH = True
                Else
                    SECONDAUTH = True
                End If
                GetRawDataFromDatabase(WheelName)
                AssignTargets()                ' designate small targets with mass > 0 and < 100 ug
                FindSmallSamples()
            Case 2
                If GetWheelID(WheelName).SecondAuthName = UserName Then
                    REAUTH = True
                    SECONDAUTH = True
                End If
                GetRawDataFromDatabase(WheelName)
                AssignTargets()                ' designate small targets with mass > 0 and < 100 ug
                FindSmallSamples()
        End Select
        btnLoad.Visible = True
        tsmBlankCorrect.Visible = True
        tsmCommit.Visible = False
        Me.Width = dgvTargets.Right + 20
        Me.Height = dgvRuns.Bottom + 50
        IamLoading = False
        If Not REAUTH Then ClearBlankCorr()
        Me.Text = "SNICSer V" & VERSION.ToString("0.00") & " " & WheelName
        If GROUPBOUNDS Then
            Me.Text &= " GROUP BOUNDS ENFORCED"
        Else
            Me.Text &= " GROUP BOUNDS IGNORED"
        End If
    End Sub

    Private Function ParseWheelName(FileName As String) As String
        ParseWheelName = ""
        If FileName.LastIndexOf("AMS") <> 0 Then
            If FileName.Length > FileName.LastIndexOf("AMS") + 9 Then
                ParseWheelName = FileName.Substring(FileName.LastIndexOf("AMS") - 2, 11)
            End If
        End If
        If FileName.LastIndexOf("USAMS") <> 0 Then
        ElseIf FileName.LastIndexOf("CFAMS") Then
        End If
    End Function

    Private Sub SaveDirectoryName(FileName As String)
        FileOpen(1, HomeDirectory & "/SNICSer.dir", OpenMode.Output)
        Print(1, My.Computer.FileSystem.GetFileInfo(FileName).DirectoryName & vbCrLf)
        FileClose(1)
    End Sub

    Private Function GetDirectoryName() As String
        GetDirectoryName = ""
        Try
            FileOpen(1, HomeDirectory & "/SNICSer.dir", OpenMode.Input)
            GetDirectoryName = LineInput(1)
            FileClose(1)
        Catch ex As Exception
            ' do nothing
        End Try
    End Function

    Public Function GetWheelID(theName As String) As WheelID
        GetWheelID = Nothing
        For i = 0 To CFAMS.Count - 1
            If CFAMS(i).Name = theName Then Return CFAMS(i)
        Next
        For i = 0 To USAMS.Count - 1
            If USAMS(i).Name = theName Then Return USAMS(i)
        Next
    End Function

    Private Sub doReLoad()
        InitParams()
        InitDataSets()
        NumStdAssumed = 0                  ' start with no assumptions
        NumBlkAssumed = 0
        chkDoCalc.Checked = True
        chkStandards.Checked = True
        chkBlanks.Checked = True
        chkSecondaries.Checked = True
        chkUnknowns.Checked = True
        MakeMeSmall()
        lblStatus.Text = "Select File..."
        IamLoading = True
        btnLoad.Visible = False
        ofdReLoadFile.FileName = ""
        'ofdReLoadFile.InitialDirectory = MySNICSerDir
        ofdReLoadFile.DefaultExt = UserName
        ofdReLoadFile.Filter = "SNICSer|*." & UserName & "|All Files|*.*"
        If ofdReLoadFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileName = ofdReLoadFile.FileName
            lblStatus.Text = "Loading File..."
            LoadRawDataFromFile(FileName)
            btnLoad.Visible = True
            Me.Width = dgvTargets.Right + 20
            Me.Height = dgvRuns.Bottom + 50
            IamLoading = False
            tsmBlankCorrect.Visible = True
        Else
            btnLoad.Visible = True
            IamLoading = False
        End If
        If Not REAUTH Then ClearBlankCorr()
    End Sub

    Private Sub LoadRawDataFromFile(fName As String)
        ' need to check with database to see if this wheel has been first/second authorized by the user
        ' if so, skip the file reading part and load directly from the database
        '
        For i = 0 To OrigTypes.Length - 1       ' clear array of original types (for safety)
            OrigTypes(i) = ""
        Next
        Dim whlName As String = ""
        Dim WasSaved As Boolean = True
        nBogus = 0              ' restart the bogus line count
        If (fName.ToUpper).Substring(fName.Length - 3).Contains("XLS") Or (fName.ToUpper).Substring(fName.Length - 3).Contains("TXT") Then WasSaved = False
        If (fName.ToUpper).Contains("ACQUISITION") Then ISACQUIFILE = True
        StdsAndBlks.Text = "Standards and Blanks for " & fName
        PropPropPlot.Text = "Property-Property Plot for " & fName
        PlotRaw.Text = "Raw Data Plot for " & fName
        Dim Group As Integer = 1, LastMst As Integer = Group
        GroupEnd(0) = -1           ' signifies that the last run of "group 0" is -1 (0 based list!)
        Dim inpLine As String = ""
        Dim inpFields As String()
        Dim StartDate As Date
        Dim theLTCorr As Double
        TypeSubstFlag = False          ' start with no substitutes
        FirstTimeThrough = True
        NumGroups = 0
        For i = 0 To MAXTARGETS
            RunKeys(i, 0) = 0
        Next
        InputData.Clear()
        NumRuns = 0
        Try
            FileOpen(1, fName, OpenMode.Input)
        Catch ex As Exception
            ofdLoadFile.ShowDialog()
            FileName = ofdLoadFile.FileName
            Try
                FileOpen(1, fName, OpenMode.Input)
            Catch ex2 As Exception
                MsgBox("File Dialog Error" & vbCrLf & ex2.Message)
            End Try
            Exit Sub
        End Try
        If GROUPBOUNDS Then
            Me.Text = "SNICSer v " & VERSION.ToString("0.000") & " File = " & fName & "  GROUP BOUNDS ENFORCED"
        Else
            Me.Text = "SNICSer v " & VERSION.ToString("0.000") & " File = " & fName
        End If
        btnLoad.Text = "Load"
        Dim NewRow As DataRow
        Try
            If ISACQUIFILE Then       ' there are no headers in an acquifile
                For i = 1 To 2
                    FileHeader(i) = LineInput(1)
                Next
            Else
                For i = 1 To 6
                    FileHeader(i) = LineInput(1)
                Next
            End If
            For i = 0 To MAXTARGETS            ' must instantiate comments or errors will ensue...
                TargetComments(i) = ""
            Next
            If WasSaved Then        ' if a saved (not raw/new) data file
                Dim ncomms As Integer = 0
                Input(1, ncomms)
                If ncomms > 0 Then
                    Dim ipos As Integer = 0
                    For i = 0 To ncomms - 1
                        Input(1, ipos)
                        TargetComments(ipos) = LineInput(1)
                    Next
                End If
                NumRuns = 0
                While Not EOF(1)
                    NewRow = InputData.NewRow()
                    inpLine = LineInput(1)
                    If Trim(inpLine) <> "" Then
                        Dim i As Integer = 0
                        inpFields = inpLine.Split(vbTab)
                        For i = 0 To InputData.Columns.Count - 1
                            NewRow(i) = inpFields(i)
                        Next
                        If inpFields.Length > InputData.Columns.Count Then
                            Samp_Typ(NumRuns) = inpFields(inpFields.Length - 1)
                        End If
                        'For Each s In inpFields
                        'Try
                        'NewRow(i) = s         ' force the conversion
                        'i += 1
                        'Catch ex As Exception
                        'MsgBox(ex.Message & vbCrLf & "Variable " & i.ToString & " in Line " & inpLine & vbCrLf & NewRow(i).ToString)
                        'Exit Sub
                        'End Try
                        'Next
                    End If
                    NumRuns = NewRow("Run")     ' this is already recorded, override the counter in case some runs are deleted
                    RunPos(NumRuns) = NewRow("Pos")
                    GroupNums(NumRuns) = NewRow("Grp")
                    RunTimes(NumRuns) = CDate(NewRow("RunTime")).ToOADate
                    iRunTimes(NumRuns) = 24 * 3600 * (RunTimes(NumRuns) - RunTimes(0)) + NewRow("Cycles") / 20  ' seconds from start of wheel to mid-analysis
                    If (NumRuns > 0) Then
                        If GroupNums(NumRuns) <> GroupNums(NumRuns - 1) Then      ' must be in a new group
                            GroupEnd(GroupNums(NumRuns - 1)) = NumRuns - 1           ' point to end of the last group
                            GroupTimes(GroupNums(NumRuns - 1)) = (RunTimes(NumRuns) + RunTimes(NumRuns - 1)) / 2     ' time marker between two runs
                            'MsgBox(NumGroups.ToString & ": " & GroupEnd(NumGroups).ToString)
                            NumGroups += 1
                        End If
                    End If
                    RunKeys(NewRow("Pos"), 0) += 1               ' increment number of runs for this position
                    RunKeys(NewRow("Pos"), RunKeys(NewRow("Pos"), 0)) = NumRuns         ' save the run key info
                    InputData.Rows.Add(NewRow)
                    If NewRow("Typ") = "S" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = StdCol
                    If NewRow("Typ") = "SS" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = SecCol
                    If NewRow("Typ") = "B" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = BlkCol
                    If NewRow("Typ") = "U" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = UnkCol
                    NumRuns += 1
                End While
                FileClose(1)
                NumGroups += 1
                GroupEnd(NumGroups) = NumRuns - 1             ' point to end of last group
                GroupTimes(NumGroups) = RunTimes(NumRuns)
                whlName = FileHeader(1)
            Else
                Dim npos As Integer = InStr(fName, ".xls")
                If npos <= 0 Then npos = InStr(fName, ".txt")
                If npos <= 0 Then
                    MsgBox("Cannot find legitimate wheel name from file name specified " & vbCrLf & fName)
                    End
                End If
                If ISACQUIFILE Then
                    If fName.Contains("CFAMS") Then
                        whlName = LatestWheelName("CFAMS")
                    Else
                        whlName = LatestWheelName("USAMS")
                    End If
                Else
                    whlName = fName.Substring(fName.LastIndexOf("AMS") - 2, 11)
                End If
                While Not EOF(1)
                    NewRow = InputData.NewRow
                    inpLine = LineInput(1)
                    If Trim(inpLine) <> "" Then
                        inpFields = inpLine.Split(vbTab)
                        Dim i As Integer = 1
                        If WasSaved Then
                            i = -1
                        Else
                            NewRow("OK") = True
                        End If
                        For Each s As String In inpFields
                            If i = 1 Then
                                Dim theDate As Date
                                If WasSaved Then
                                    theDate = CDate(s)
                                Else
                                    theDate = CDate(Mid(s, 5, 7) & Mid(s, 21) & Mid(s, 11, 9))      ' if a new XLS, parse arcane CFAMS format
                                End If
                                NewRow("RunTime") = theDate
                                If NumRuns = 0 Then
                                    StartDate = theDate
                                    SmpTimes(0) = 0
                                    RunTimes(0) = theDate.ToOADate
                                Else
                                    SmpTimes(NumRuns) = DateDiff(DateInterval.Second, StartDate, theDate)
                                    RunTimes(NumRuns) = theDate.ToOADate
                                End If
                            ElseIf i = 2 Then
                                NewRow(i + 1) = s
                            Else
                                Try
                                    NewRow(i + 2) = s         ' force the conversion
                                Catch ex As Exception
                                    MsgBox(ex.Message & vbCrLf & "Variable " & i.ToString & " in Line " & inpLine & vbCrLf & NewRow(i).ToString)
                                    Exit Sub
                                End Try
                            End If
                            i += 1
                        Next
                        NewRow("Run") = NumRuns
                        RunPos(NumRuns) = NewRow("Pos")
                        If ((whlName.Substring(0, 5)).ToUpper = "USAMS") And (NewRow("HE13/12") < 0.3) Then NewRow("HE13/12") = 100 * NewRow("HE13/12") ' convert to CFAMS convention for 13/12 X 100
                        C13C12(NumRuns) = NewRow("HE13/12")
                        theLTCorr = (NewRow("CntTotS") / NewRow("CntTotH"))
                        If (theLTCorr = 0) Or (NewRow("CntTotS") = 0) Or (NewRow("CntTotH") = 0) Then
                            theLTCorr = 1 ' cannot divide by zero!
                            NewRow("OK") = False          ' bad line is automatically disabled
                            nBogus += 1                 ' increment bogus count
                            BogusLines(nBogus) = NumRuns            ' save the run number
                        End If
                        NewRow("LTCorr") = theLTCorr
                        NewRow("Corr14/12") = NewRow("He14/12") / NewRow("LTCorr") / C13C12(NumRuns) ^ 2    '### SQ FRAC CORR ###
                        If NewRow("CntTotS") <> 0 And NewRow("CntTotGT") <> 0 Then
                            Dim RelErrSq As Double = (NewRow("CntTotH") - NewRow("CntTotS")) * NewRow("CntTotH") ^ 2 / NewRow("CntTotS") ^ 4 _
                                                     + NewRow("CntTotH") ^ 2 / NewRow("CntTotGT") / NewRow("CntTotS") ^ 2
                            NewRow("Sig14/12") = NewRow("Corr14/12") * RelErrSq ^ 0.5
                        Else
                            NewRow("Sig14/12") = 0.000000000000001
                        End If
                        NewRow("DelC13") = 1000 * (C13C12(NumRuns) / 1.12372 - 1)         ' referenced to VPDB
                        If (NewRow("Mst") < LastMst) And (NewRow("Mst") = 1) Then
                            GroupEnd(Group) = NumRuns - 1           ' point to end of the last group
                            GroupTimes(Group) = (RunTimes(NumRuns) + RunTimes(NumRuns - 1)) / 2     ' time marker between two runs
                            'MsgBox(Group.ToString & ":: " & GroupEnd(Group).ToString)
                            Group += 1                          ' must be onto a new group
                        End If
                        LastMst = NewRow("Mst")
                        NewRow("Grp") = Group
                        GroupNums(NumRuns) = Group
                        RunKeys(NewRow("Pos"), 0) += 1               ' increment number of runs for this position
                        RunKeys(NewRow("Pos"), RunKeys(NewRow("Pos"), 0)) = NumRuns         ' save the run key info
                        Samp_Typ(NumRuns) = NewRow("Typ")              ' save the original assignment
                        If (NewRow("Typ") <> "S") And (NewRow("Typ") <> "SS") And (NewRow("Typ") <> "B") And (NewRow("Typ") <> "U") Then
                            If Not TypeSubstFlag Then
                                TypeSubstFlag = True        ' so only do this once
                                Dim theMsg As String = "Error in TYPE field of input file:" & vbCrLf & NewRow("SampleName") _
                                                       & "(Pos " & NewRow("Pos") & ") classed as '" & NewRow("Typ") & "'" _
                                                       & vbCrLf & "Reclassified as 'U'" & vbCrLf & "You may need to correct this" _
                                                       & vbCrLf & "... and there may be more!"
                                MsgBox(theMsg)
                            End If
                            NewRow("Typ") = "U"
                        End If
                        iRunTimes(NumRuns) = 24 * 3600 * (RunTimes(NumRuns) - RunTimes(0)) + NewRow("Cycles") / 20  ' seconds from start of wheel to mid-analysis
                        InputData.Rows.Add(NewRow)
                        If NewRow("Typ") = "S" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = StdCol
                        If NewRow("Typ") = "SS" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = SecCol
                        If NewRow("Typ") = "B" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = BlkCol
                        If NewRow("Typ") = "U" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = UnkCol
                        NumRuns += 1
                    End If
                End While
                NumGroups = Group
                GroupEnd(NumGroups) = NumRuns - 1             ' point to end of last group
                GroupTimes(NumGroups) = RunTimes(NumRuns - 1)
                GroupTimes(0) = RunTimes(0) - 0.01
                If nBogus > 0 Then
                    With Bogus
                        .Text = fName
                        .lblBogus.Text = nBogus.ToString & " bad lines" & vbCrLf & "were encountered" & vbCrLf & "and disabled"
                        .lbxBogus.Items.Clear()
                        For i = 1 To nBogus
                            .lbxBogus.Items.Add(BogusLines(i).ToString)
                        Next
                        .ShowDialog(Me)
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & " at around line " & NumRuns.ToString)
        End Try
        FileClose(1)
        For i = 0 To NumRuns - 1
            OrigTypes(RunPos(i)) = InputData(i).Item("Typ")
        Next
        'Dim thegMsg As String = "Group Table: entries " & NumGroups.ToString
        'For i = 0 To NumGroups - 1
        'thegMsg &= vbCrLf & GroupNums(i).ToString & " : " & GroupTimes(i).ToString
        'Next
        'MsgBox(thegMsg)
        If (whlName.Substring(0, 5)).ToUpper = "USAMS" Then
            dgvInputData.Columns(8).DefaultCellStyle.Format = "0.00"
        Else
            dgvInputData.Columns(8).DefaultCellStyle.Format = "0"
        End If
        dgvInputData.AutoResizeColumns()
        dgvInputData.AutoResizeRows()
        UpdateDataListLabel()
        CollectRats()
        AssignTargets()          ' find out if target exists
        PopulateTargets()
        WheelName = whlName
        DoFillInC13Table()
        GetWheelInfo(whlName)
        If Not ISPARTIALWHEEL Then SetUpStds()
        'Calculate()
        RepositionDGVs()
        tsmSave.Enabled = True
        If Not ISACQUIFILE Then
            tsmCommit.Enabled = True
            tsmCommit.Visible = True
        End If
        PropertyPropertyToolStripMenuItem.Enabled = True
        StandardsAndBlanksToolStripMenuItem.Enabled = True
        LOADEDWHEEL = True
        FindSmallSamples()          ' find out if target is small
        'If GROUPBOUNDS Then CommitGroupToDatabaseToolStripMenuItem.Enabled = True
    End Sub

    Public Sub AssignTargets()      ' find out if target exists and/or if small
        For iPos = 0 To MAXTARGETS
            If RunKeys(iPos, 0) = 0 Then
                TargetIsPresent(iPos) = False
            Else
                TargetIsPresent(iPos) = True
            End If
        Next
    End Sub

    Public Sub FindSmallSamples()      ' find out if target exists and/or if small
        For iPos = 0 To MAXTARGETS
            TargetIsSmall(iPos) = (TargetMass(iPos) > 0) And (TargetMass(iPos) < MaxSmallSampleMass)
        Next
        'ListSmallTargets()     ' optional listing for debugging purposes
    End Sub

    Public Sub ListSmallTargets()
        Dim msg As String = "List of Smallness " & TargetData.Rows.Count.ToString
        For i = 0 To TargetData.Rows.Count - 1
            msg &= TargetData.Rows(i).Item("Pos") & ": " & TargetIsSmall(TargetData.Rows(i).Item("Pos")).ToString
        Next
        MsgBox(msg)
    End Sub

#End Region

#Region "Manage Tables"

    Public Sub UpdateDataListLabel()
        lblInputDataList.Text = "Input " & NumRuns.ToString & " Runs (" & (NumGroups).ToString & " Groups)"
    End Sub

    Public Sub RepositionDGVs()     ' rearranges data grid views to fit
        ReSizeDGV(dgvInputData, 20)
        If Not WIDE Then dgvInputData.Width = 0.6 * dgvInputData.Width
        dgvInputData.Height = 660
        If Not TALL Then dgvInputData.Height = 0.6 * dgvInputData.Height
        dgvTargets.Left = dgvInputData.Right + 10
        lblDGVTarg.Left = dgvTargets.Left
        ReSizeDGV(dgvTargets, 40)
        dgvTargets.Height = 0.9 * dgvInputData.Height
        lblStats.Left = dgvTargets.Left
        lblStats.Top = dgvTargets.Bottom + 10
        Me.Width = dgvTargets.Right + 20
        lblRuns.Top = dgvInputData.Bottom + 10
        dgvRuns.Top = lblRuns.Bottom + 10
        dgvRuns.Width = dgvInputData.Width - 20
        Me.Height = dgvRuns.Bottom + 50
        If WIDE Then
            ReSizeDGV(dgvRuns, 40)
        Else
            dgvRuns.Width = dgvInputData.Width - 10
        End If
        dgvSecs.Left = dgvInputData.Right
        dgvSecs.Top = lblStats.Bottom + 10
        'ReSizeDGV(dgvSecs, 40)
        lblSecStds.Left = dgvSecs.Left
        '.Left = dgvTargets.Right - chkUnknowns.Width - 30
        'chkSecondaries.Left = chkUnknowns.Left - chkSecondaries.Width - 2
        'chkBlanks.Left = chkSecondaries.Left - chkBlanks.Width - 2
        'chkStandards.Left = chkBlanks.Left - chkSecondaries.Width - 2
        'lblDGVTarg.Left = chkStandards.Left - lblDGVTarg.Width - 2
        If lblDGVTarg.Left > dgvTargets.Left Then lblDGVTarg.Left = dgvTargets.Left
    End Sub

    Public Sub ReSizeDGV(dgv As DataGridView, pad As Integer)
        Dim dgvWidth As Integer = 0
        For i = 0 To dgv.Columns.Count - 1
            dgvWidth += dgv.Columns(i).Width
        Next
        dgv.Width = dgvWidth + pad
    End Sub

    Public Sub FullReSizeDGV(dgv As DataGridView, pad As Integer)
        Dim dgvWidth As Integer = 0
        For i = 0 To dgv.Columns.Count - 1
            dgvWidth += dgv.Columns(i).Width
        Next
        dgv.Width = dgvWidth + pad
        Dim dgvHeight As Integer = 0
        For i = 0 To dgv.Rows.Count - 1
            dgvHeight += dgv.Rows(i).Height
        Next
        dgv.Height = dgvHeight + 35
    End Sub

    Public Sub RefreshTargetTable()
        CheckStates(1) = chkStandards.Checked
        CheckStates(2) = chkBlanks.Checked
        CheckStates(3) = chkSecondaries.Checked
        CheckStates(4) = chkUnknowns.Checked
        If Not (CheckStates(1) And CheckStates(2) And CheckStates(3) And CheckStates(4)) Then          ' only do this if you have to
            IamBatching = True
            chkSecondaries.Checked = True
            chkStandards.Checked = True
            chkUnknowns.Checked = True
            chkBlanks.Checked = True
            IamBatching = False
        End If
        RePopulateTargets()
    End Sub

    Public Sub RestoreTargetTableChecks()
        If Not (CheckStates(1) And CheckStates(2) And CheckStates(3) And CheckStates(4)) Then           ' only do this if you have to
            IamBatching = True
            chkStandards.Checked = CheckStates(1)
            chkBlanks.Checked = CheckStates(2)
            chkSecondaries.Checked = CheckStates(3)
            chkUnknowns.Checked = CheckStates(4)
            IamBatching = False
        End If
        RePopulateTargets()
    End Sub

    Private Sub UpdateTargetTable()
        'is this ever called?
        TargetData.Rows.Clear()
        NumTargets = 0
        For i = 0 To TargetTypes.Length - 1
            If TargetIsPresent(i) Then      ' do only if Target is present
                If Trim(TargetNames(i)) <> "" Then
                    If (chkBlanks.Checked And (TargetTypes(i) = "B")) Or (chkSecondaries.Checked And (TargetTypes(i) = "SS")) _
                        Or (chkStandards.Checked And (TargetTypes(i) = "S")) Or (chkUnknowns.Checked And (TargetTypes(i) = "U")) Then
                        NumTargets += 1
                        Dim NewRow As DataRow = TargetData.NewRow
                        NewRow("Pos") = i
                        NewRow("SampleName") = TargetNames(i)
                        NewRow("Typ") = TargetTypes(i)
                        NewRow("N") = TargetRuns(i)
                        NewRow("NormRat") = TargetRat(i)
                        NewRow("IntErr") = IntErr(i)
                        NewRow("ExtErr") = ExtErr(i)
                        NewRow("DelC13") = 1000.0 * (C13Rat(i) - 1)
                        NewRow("SigC13") = 1000.0 * Math.Max(SigC13(i), SigC13IntErr(i))
                        NewRow("MSdC13") = IRMSdC13(i)
                        NewRow("Rec_Num") = Rec_Num(i)
                        TargetData.Rows.Add(NewRow)
                    End If
                End If
            End If      ' do only if Target is present
        Next
        'MsgBox(NumTargets, , "UpdateTargetTable")
        ColorizeTargets()
        dgvTargets.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub CalculateStandardStats()
        Dim theAvgStd As Double = 0
        Dim theExtErr As Double = 0
        Dim theWts As Double = 0
        Dim theNumStd As Integer = 0
        For i = 0 To MAXTARGETS
            If TargetTypes(i) = "S" Then
                Dim theStdRat As Double = StdAbsRat(i)
                theNumStd += 1
                theWts += (IntErr(i) / StdAbsRat(i)) ^ -2
                theAvgStd += TargetRat(i) / theStdRat / (IntErr(i) / theStdRat) ^ 2
            End If
        Next
        theAvgStd /= theWts
        For i = 0 To MAXTARGETS
            Dim theStdRat As Double = StdAbsRat(i)
            If TargetTypes(i) = "S" Then
                theExtErr += ((TargetRat(i) / theStdRat - theAvgStd) / (IntErr(i) / theStdRat)) ^ 2
            End If
        Next
        theExtErr = ((theNumStd * theExtErr / theWts / (theNumStd - 1)) ^ 0.5)
        lblStats.Text = "Average Standard Normalized to Assumed Ratio = " & theAvgStd.ToString(dFnt(NumResFigs - 2)) & " +- " _
            & (theExtErr / theNumStd ^ 0.5).ToString(dFnt(NumResFigs - 2)) & vbCrLf _
            & "                 (N = " & theNumStd.ToString & "   StdDev = " & theExtErr.ToString(dFnt(NumResFigs - 3)) & ")"
        lblStats.Visible = True
    End Sub

    Private Function StdAbsRat(iPos As Integer) As Double
        StdAbsRat = 1
        For j = 0 To StandardsValues.Rows.Count - 1     ' find entry
            If StandardsValues(j).Item("Pos") = iPos Then
                StdAbsRat = StandardsValues(j).Item("Asm_Rat")
                Exit For
            End If
        Next
    End Function

    Public Sub UpdateStandardsTables()
        SecsValues.Clear()
        For i = 0 To MAXTARGETS
            If TargetTypes(i) = "SS" Then        ' need to update secondaries table
                Dim newrow As DataRow = SecsValues.NewRow
                newrow("Pos") = i
                newrow("SampleName") = TargetNames(i)
                newrow("N") = TargetRuns(i)
                newrow("NormRat") = TargetRat(i)
                newrow("IntErr") = IntErr(i)
                newrow("ExtErr") = ExtErr(i)
                Dim rnum = Rec_Num(i)
                newrow("Rec_Num") = rnum
                For j = 0 To NumStds - 1
                    If Std_Rec_Num(j) = rnum Then
                        newrow("Asm_Rat") = Std_Fm(j)
                        AsmRat(i) = Std_Fm(j)
                        If IntErr(i) > ExtErr(i) Then
                            newrow("Sigma") = (newrow("NormRat") - newrow("Asm_Rat")) / newrow("IntErr")
                        Else
                            newrow("Sigma") = (newrow("NormRat") - newrow("Asm_Rat")) / newrow("ExtErr")
                        End If
                        If newrow("Asm_Rat") = 42 Then newrow("Sigma") = 42
                        Exit For
                    End If
                Next
                SecsValues.Rows.Add(newrow)
            ElseIf TargetTypes(i) = "S" Then
                For j = 0 To StandardsValues.Rows.Count - 1     ' find entry
                    If StandardsValues(j).Item("Pos") = i Then
                        StandardsValues(j).Item("NormRat") = TargetRat(i)
                        StandardsValues(j).Item("IntErr") = IntErr(i)
                        StandardsValues(j).Item("ExtErr") = ExtErr(i)
                        StandardsValues(j).Item("Sigma") = (TargetRat(i) - StandardsValues(j).Item("Asm_Rat")) / ExtErr(i)
                        StandardsValues(j).Item("C13/12") = C13C12(i)
                    End If
                Next
            ElseIf TargetTypes(i) = "B" Then
                For j = 0 To BlanksValues.Rows.Count - 1     ' find entry
                    If BlanksValues(j).Item("Pos") = i Then
                        BlanksValues(j).Item("NormRat") = TargetRat(i)
                        BlanksValues(j).Item("IntErr") = IntErr(i)
                        BlanksValues(j).Item("ExtErr") = ExtErr(i)
                        BlanksValues(j).Item("Sigma") = (TargetRat(i) - BlanksValues(j).Item("Asm_Rat")) / ExtErr(i)
                        BlanksValues(j).Item("C13/12") = C13C12(i)
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub PopulateTargets()
        Worms.cmbGoTo.Items.Clear()
        For i = 0 To TargetTypes.Length - 1
            'TargetNonPerf(i) = False
            'TargetIsSmall(i) = False
            TargetNames(i) = ""
            TargetTypes(i) = ""
            TargetRuns(i) = 0
            TotalRuns(i) = 0
            NormRat(i) = 0
            'NormRatErr(i) = 0
        Next
        For i = 0 To InputData.Rows.Count - 1
            Dim ipos As Integer = InputData(i).Item("Pos")
            TargetNames(ipos) = InputData(i).Item("SampleName")
            TargetTypes(ipos) = InputData(i).Item("Typ")
            TotalRuns(ipos) += 1
            If TotalRuns(ipos) = 1 Then TargetRunTimes(ipos) = RunTimes(i) ' adopt first run time as the target run time
            If InputData(i).Item("OK") Then
                TargetRuns(ipos) += 1
            End If
        Next
        TargetData.Rows.Clear()
        NumTargets = 0
        For i = 0 To MAXTARGETS
            If TargetIsPresent(i) Then      ' do only if Target is present
                If Trim(TargetNames(i)) <> "" Then
                    If (chkBlanks.Checked And (TargetTypes(i) = "B")) Or (chkSecondaries.Checked And (TargetTypes(i) = "SS")) _
                        Or (chkStandards.Checked And (TargetTypes(i) = "S")) Or (chkUnknowns.Checked And (TargetTypes(i) = "U")) Then
                        NumTargets += 1
                        Dim NewRow As DataRow = TargetData.NewRow
                        NewRow("NP") = TargetNonPerf(i)
                        NewRow("Pos") = i
                        NewRow("SampleName") = TargetNames(i)
                        NewRow("Typ") = TargetTypes(i)
                        NewRow("N") = TargetRuns(i)
                        NewRow("NormRat") = TargetRat(i)
                        NewRow("IntErr") = IntErr(i)
                        NewRow("ExtErr") = ExtErr(i)
                        NewRow("DelC13") = 1000 * (C13C12(i) - 1)
                        NewRow("Rec_Num") = Rec_Num(i)
                        NewRow("MSdC13") = IRMSdC13(i)
                        TargetData.Rows.Add(NewRow)
                    End If
                End If
            End If      ' do only if Target is present
        Next
        For i = 0 To dgvTargets.Columns.Count - 1
            dgvTargets.Columns(i).ReadOnly = True
        Next
        ColorizeTargets()
        lblRuns.Visible = False
        dgvRuns.Visible = False
        For i = 0 To NumTargets - 1
            If TargetNames(i) <> "" Then
                Worms.cmbGoTo.Items.Add(New CmbColorItem(i.ToString & ": " & TargetNames(i).Trim, i.ToString, Color.Black, TargetColor(TargetTypes(i))))
            End If
        Next

        'MsgBox(NumTargets, , "PopulateTargets")
        RePopulateTargets()
        'For i = 0 To TargetData.Rows.Count - 1          ' first load the receipt numbers into the target table
        'TargetData(i).Item("Rec_Num") = Rec_Num(TargetData(i).Item("Pos"))
        'Next
        lblDGVTarg.Text = NumTargets.ToString & " Targets"
    End Sub

    Public Sub RePopulateTargets()
        TargetData.Rows.Clear()
        For i = 0 To MAXTARGETS
            If TargetIsPresent(i) Then      ' do only if Target is present
                If Trim(TargetNames(i)) <> "" Then
                    If (chkBlanks.Checked And (TargetTypes(i) = "B")) Or (chkSecondaries.Checked And (TargetTypes(i) = "SS")) _
                        Or (chkStandards.Checked And (TargetTypes(i) = "S")) Or (chkUnknowns.Checked And (TargetTypes(i) = "U")) Then
                        Dim NewRow As DataRow = TargetData.NewRow
                        NewRow("NP") = TargetNonPerf(i)
                        NewRow("Pos") = i
                        NewRow("SampleName") = TargetNames(i)
                        NewRow("Typ") = TargetTypes(i)
                        NewRow("Proc") = TargetProcs(i)
                        NewRow("Mass") = TargetMass(i)
                        NewRow("N") = TargetRuns(i)
                        NewRow("NormRat") = TargetRat(i)
                        NewRow("IntErr") = IntErr(i)
                        NewRow("ExtErr") = ExtErr(i)
                        NewRow("DelC13") = 1000.0 * (C13Rat(i) - 1)
                        NewRow("SigC13") = 1000.0 * Math.Max(SigC13(i), SigC13IntErr(i))
                        NewRow("MSdC13") = IRMSdC13(i)
                        TargetData.Rows.Add(NewRow)
                    End If
                End If
            End If      ' do only if Target is present
        Next
        For i = 0 To dgvTargets.Columns.Count - 1
            dgvTargets.Columns(i).ReadOnly = True
        Next
        ColorizeTargets()
        lblRuns.Visible = False
        dgvRuns.Visible = False
        For i = 0 To TargetData.Rows.Count - 1          ' first load the receipt numbers into the target table
            TargetData(i).Item("Rec_Num") = Rec_Num(TargetData(i).Item("Pos"))
        Next
        dgvTargets.AutoResizeColumns()
        dgvTargets.AutoResizeRows()
    End Sub

    Public Sub ColorizeTargets()
        For i = 0 To TargetData.Rows.Count - 1
            dgvTargets.Rows(i).DefaultCellStyle.BackColor = TargetColor(dgvTargets.Item("Typ", i).Value)
            dgvTargets.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            If TargetIsReadOnly(i) Then
                dgvTargets.Rows(i).DefaultCellStyle.ForeColor = Color.Gray
            Else
                dgvTargets.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
            If dgvTargets.Item("NP", i).Value Then            'If TargetNonPerf(i) Then
                dgvTargets.Rows(i).DefaultCellStyle.BackColor = Color.Black
                dgvTargets.Rows(i).DefaultCellStyle.ForeColor = Color.White
                If TargetIsReadOnly(i) Then dgvTargets.Rows(i).DefaultCellStyle.ForeColor = Color.Gray
            End If
        Next
    End Sub

    Public Function TargetColor(ByRef theType As String) As Color
        Select Case theType
            Case "S"
                TargetColor = StdCol
            Case "B"
                TargetColor = BlkCol
            Case "SS"
                TargetColor = SecCol
            Case Else
                TargetColor = UnkCol
        End Select
        Return TargetColor
    End Function

    Public Sub PopRuns(Posn As Integer)
        SelectedTarget = Posn
        tspShowSecondaries.Enabled = True
        DeselectDGV(dgvTargets)         ' first deselect all rows for all categories
        DeselectDGV(dgvSecs)
        DeselectDGV(StdsAndBlks.dgvBlanks)
        DeselectDGV(StdsAndBlks.dgvStandards)
        For iRow = 0 To TargetData.Rows.Count - 1      ' see if it's listed in target table
            If TargetData(iRow).Item("Pos") = Posn Then
                dgvTargets.Rows(iRow).Selected = True   ' then select the correct target row
                Exit For
            End If
        Next
        If TargetTypes(Posn) = "SS" Then     ' and corrsponding SS if one
            For i = 0 To SecsValues.Rows.Count - 1
                If SecsValues(i).Item("Pos") = Posn Then
                    dgvSecs.Rows(i).Selected = True
                    Exit For
                End If
            Next
        ElseIf TargetTypes(Posn) = "S" Then      ' or corresponding standard if one
            For i = 0 To StandardsValues.Rows.Count - 1
                If StandardsValues(i).Item("Pos") = Posn Then
                    StdsAndBlks.dgvStandards.Rows(i).Selected = True
                    Exit For
                End If
            Next
        ElseIf TargetTypes(Posn) = "B" Then      ' or corresponding blank if one
            For i = 0 To BlanksValues.Rows.Count - 1
                If BlanksValues(i).Item("Pos") = Posn Then
                    StdsAndBlks.dgvBlanks.Rows(i).Selected = True
                    Exit For
                End If
            Next
        End If
        TargetSelected = Posn
        Dim sName As String = TargetNames(Posn)
        Dim sType As String = TargetTypes(Posn)
        Dim theNormRat As Double = NormRat(Posn)
        Dim theIntErr As Double = 0
        Dim theExtErr As Double = ExtErr(Posn)
        Dim theRecNum As Integer = Rec_Num(Posn)
        RunsData.Clear()
        For j = 1 To RunKeys(Posn, 0)
            Dim i As Integer = RunKeys(Posn, j)
            Dim newrow As DataRow = RunsData.NewRow
            newrow("OK") = InputData.Rows(i).Item("OK")
            newrow("RunTime") = InputData.Rows(i).Item("RunTime")
            newrow("Run") = i
            newrow("Mst") = InputData.Rows(i).Item("Mst")
            newrow("NormRat") = NormRat(i)
            newrow("IntErr") = NormRatErr(i)
            newrow("DelC13") = InputData.Rows(i).Item("DelC13")
            newrow("NormD13") = 1000 * (C13C12(i) - 1)
            newrow("SigD13") = 1000 * SigC13C12(i)
            newrow("LE12C") = InputData.Rows(i).Item("LE12C")
            newrow("LE13C") = InputData.Rows(i).Item("LE13C")
            newrow("HE12C") = InputData.Rows(i).Item("HE12C")
            newrow("HE13C") = InputData.Rows(i).Item("HE13C")
            newrow("CntTotH") = InputData.Rows(i).Item("CntTotH")
            newrow("CntTotS") = InputData.Rows(i).Item("CntTotS")
            newrow("CntTotGT") = InputData.Rows(i).Item("CntTotGT")
            newrow("HE13/12") = InputData.Rows(i).Item("HE13/12")
            newrow("HE14/12") = InputData.Rows(i).Item("HE14/12")
            newrow("LTCorr") = InputData.Rows(i).Item("LTCorr")
            newrow("Corr14/12") = InputData.Rows(i).Item("Corr14/12")
            newrow("Sig14/12") = InputData.Rows(i).Item("Sig14/12")
            RunsData.Rows.Add(newrow)
            theIntErr += 1.0 / NormRatErr(i) ^ 2
        Next
        theIntErr = theIntErr ^ -0.5
        lblRuns.Visible = True
        lblRuns.Text = "Pos " & Posn.ToString & "  " & sName & "  " & TargetRuns(Posn).ToString & " Runs,  NormRat = " & TargetRat(Posn).ToString("0.0000") _
            & " + - " & ExtErr(Posn).ToString("0.0000") & " (IntErr = " & IntErr(Posn).ToString("0.0000") & " ) "
        dgvRuns.Visible = True
        Me.Height = dgvRuns.Bottom + 50
        If Me.Width < dgvSecs.Right + 20 Then Me.Width = dgvSecs.Right + 20
        If Not Worms.chkOverlay.Checked Then NumPlots = 0
        dgvRuns.AutoResizeColumns()
        dgvRuns.AutoResizeRows()
        PlotList(NumPlots) = Posn
        NumPlots += 1
        PlotRuns()
        RepositionDGVs()
    End Sub

    Public Sub DeselectDGV(dgv As DataGridView)
        For i = 0 To dgv.Rows.Count - 1
            dgv.Rows(i).Selected = False
        Next
    End Sub

    Public Sub ToggleOK(iRow As Integer)
        DeBlankCorr()             ' make sure you have to blank correct again
        Dim iRun As Integer = RunsData(iRow).Item("Run")
        RunsData(iRow).Item("OK") = Not RunsData(iRow).Item("OK")        ' toggle it
        InputData(iRun).Item("OK") = RunsData(iRow).Item("OK")
        ReCountRuns(TargetSelected)
        If chkDoCalc.Checked Then Calculate()
        If TargetSelected >= 0 Then PopRuns(TargetSelected)
        PlotRuns()
    End Sub

    Public Sub ToggleRun(iRun As Integer)
        DeBlankCorr()             ' make sure you have to blank correct again
        InputData(iRun).Item("OK") = Not InputData(iRun).Item("OK")
        If chkDoCalc.Checked Then Calculate()
        If SelectedTarget >= 0 Then
            PopRuns(SelectedTarget)
        Else
            PlotWorms()
        End If
    End Sub

    Public Sub ColorizeCompare()
        With Compare
            .Visible = True
            For i = 0 To .dgvCompare.Rows.Count - 1
                .dgvCompare.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                .dgvCompare("1stTyp", i).Style.BackColor = TargetColor(.dgvCompare("1stTyp", i).Value)
                .dgvCompare("2ndTyp", i).Style.BackColor = TargetColor(.dgvCompare("2ndTyp", i).Value)
                If Math.Abs(.dgvCompare("SigmaC14", i).Value) > 2.5 Then
                    .dgvCompare("SigmaC14", i).Style.BackColor = Color.LightSalmon
                    .dgvCompare("DelNormRat", i).Style.BackColor = Color.LightSalmon
                ElseIf Math.Abs(.dgvCompare("SigmaC14", i).Value) > 2.0 Then
                    .dgvCompare("SigmaC14", i).Style.BackColor = Color.LightCoral
                    .dgvCompare("DelNormRat", i).Style.BackColor = Color.LightCoral
                ElseIf Math.Abs(.dgvCompare("SigmaC14", i).Value) > 1.5 Then
                    .dgvCompare("SigmaC14", i).Style.BackColor = Color.LightPink
                    .dgvCompare("DelNormRat", i).Style.BackColor = Color.LightPink
                End If
                If .dgvCompare("NP", i).Value Then
                    .dgvCompare.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    .dgvCompare.Rows(i).DefaultCellStyle.BackColor = Color.Black
                End If
            Next
        End With
    End Sub

    Public Sub PresentTargetInfo()
        TargetInfo.Rows.Clear()
        For i = 0 To TargetData.Rows.Count - 1
            'If TargetIsPresent(i) Then
            Dim ipos As Integer = TargetData(i).Item("Pos")
            Dim newrow = TargetInfo.NewRow
            newrow("Pos") = ipos
            newrow("TP_Num") = Tp_Num(ipos)
            newrow("Rec_Num") = Rec_Num(ipos)
            newrow("N") = RunKeys(ipos, 0)
            newrow("Typ") = TargetTypes(ipos)
            newrow("SampleName") = TargetNames(ipos)
            newrow("Mass") = TargetMass(ipos)
            newrow("Proc") = TargetProcs(ipos)
            newrow("Comment") = Trim(TargetComments(ipos))
            TargetInfo.Rows.Add(newrow)
            'End If

        Next
        With frmTargetInfo
            .Visible = True
            .dgvTargetInfo.Columns("Mass").DefaultCellStyle.Format = "0.0"
            .dgvTargetInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            ReSizeDGV(.dgvTargetInfo, 25)
            .Width = .dgvTargetInfo.Right + 30
            For i = 0 To .dgvTargetInfo.Rows.Count - 1
                .dgvTargetInfo.Rows(i).DefaultCellStyle.BackColor = TargetColor(TargetInfo(i).Item("Typ"))
            Next
        End With
    End Sub


#End Region

    Public Sub CountFlags()     ' counts, categorizes flags and presents information
        Dim NumFlags(4) As Integer  ' categorized (0-4) as All, B, S, SS, U number valid flags
        Dim AllRuns(4) As Double   ' all runs of each type (as above)   double to force division 
        Dim TypNames() As String = {"All", "Blank runs", "Standard runs", "Secondary runs", "Unknown runs"}
        For i = 0 To 4
            NumFlags(i) = 0
            AllRuns(i) = 0
        Next
        For i = 0 To InputData.Rows.Count - 1
            AllRuns(0) += 1
            If InputData.Rows(i).Item("OK") Then NumFlags(0) += 1 ' a valid run
            Select Case InputData.Rows(i).Item("Typ")
                Case "B"
                    If InputData.Rows(i).Item("OK") Then NumFlags(1) += 1
                    AllRuns(1) += 1
                Case "S"
                    If InputData.Rows(i).Item("OK") Then NumFlags(2) += 1
                    AllRuns(2) += 1
                Case "SS"
                    If InputData.Rows(i).Item("OK") Then NumFlags(3) += 1
                    AllRuns(3) += 1
                Case "U"
                    If InputData.Rows(i).Item("OK") Then NumFlags(4) += 1
                    AllRuns(4) += 1
            End Select
        Next
        Dim msg As String = (AllRuns(0) - NumFlags(0)).ToString & " of all runs were rejected (" _
                            & (100.0 * (AllRuns(0) - NumFlags(0)) / AllRuns(0)).ToString("0.0") & "%)"
        msg &= vbCrLf & (AllRuns(0) - NumFlags(0) - AllRuns(1) + NumFlags(1)).ToString & " of non-blanks were rejected (" _
                            & (100.0 * (AllRuns(0) - NumFlags(0) - AllRuns(1) + NumFlags(1)) / AllRuns(0)).ToString("0.0") & "%)"
        msg &= vbCrLf
        For i = 1 To 4
            msg &= vbCrLf & (AllRuns(i) - NumFlags(i)).ToString & " " & TypNames(i) & " were rejected (" _
                    & (100.0 * (AllRuns(i) - NumFlags(i)) / AllRuns(i)).ToString("0.0") & "%)"
        Next
        MsgBox(msg, vbOK)
    End Sub

#End Region ' data loading, populate tables

#Region "Normalization"

    Public Sub CollectRats()
        For i = 0 To NumRuns - 1
            Rat(i) = InputData(i).Item("Corr14/12")
            ErrRat(i) = InputData(i).Item("Sig14/12")
        Next
    End Sub

    Public Sub MakePatience()
        frmPatience.Visible = True
        frmPatience.Top = Me.Top
        frmPatience.Left = Me.Left
        Me.Enabled = False
    End Sub

    Public Sub Calculate()
        Dim RunNums(100) As Integer
        RefreshTargetTable()
        MakePatience()
        IdentifyStandards()         ' need an updated view on who's a valid standard run
        For iRun = 0 To NumRuns - 1            ' for each run:
            FindNearestStandards(iRun, CalcNum, RunNums)   ' returns run numbers of proximal standards
            ComputeRun(iRun, Options.cmbFitType.Text, CalcNum, RunNums)  ' compute the normalized values
        Next
        For i = 0 To MAXTARGETS
            AccumulateResults(i)            ' compute averages/errors, etc on a per-target basis
        Next
        RePopulateTargets()     ' rebuild the target table
        Me.Enabled = True
        If dgvRuns.Visible Then
            If TargetSelected >= 0 Then PopRuns(TargetSelected)
        End If
        CalculateStandardStats()            ' compute and accumulate standards statistics
        UpdateStandardsTables()             ' update the tables
        ReSizeStdsAndBlks()               ' accommodate any table size change
        frmPatience.Visible = False         ' disappear the Snickers
        RestoreTargetTableChecks()  ' revert the target table selection choices to original configuration
    End Sub

    Private Sub IdentifyStandards()
        ' sets up a more easily used array of booleans identifying if a run is a standard and if it's OK
        For i = 0 To NumRuns - 1                                 ' first update status, must be OK, a standard, and not a non-performer
            IsStd(i) = InputData(i).Item("OK") And (InputData(i).Item("Typ") = "S") And Not TargetNonPerf(InputData(i).Item("Pos"))
        Next
    End Sub

    Public Sub FindNearestStandards(ByVal iRun As Integer, ByVal NumStds As Integer, ByRef RunNums() As Integer)
        ' looks for the nearest NumStds standards to run iRun and returns their run numbers in RunNums
        Dim nRuns As Integer = 0
        Dim iFirst As Integer = 1       ' number of first run in group
        Dim iLast As Integer = NumRuns  ' number of last run in group
        Dim nGroup As Integer = GroupNums(iRun)
        Dim TimeDiff(100) As Integer
        Dim PosDiff(100) As Integer
        If GROUPBOUNDS Then
            iFirst = GroupEnd(nGroup - 1) + 1
            iLast = GroupEnd(nGroup)
        Else
            iFirst = 0
            iLast = NumRuns
        End If
        If iRun <= iFirst + (iLast - iFirst) / 2 Then       ' for first half, look before the sample  first
            For j = iRun - 1 To iFirst Step -1      ' working backwards before the sample...
                If IsStd(j) And ((RunPos(iRun) <> RunPos(j)) Or AllowSelfNorm) Then            ' is a standard and is not itself
                    RunNums(nRuns) = j
                    TimeDiff(nRuns) = Math.Abs(iRunTimes(j) - iRunTimes(iRun))      ' save run time difference
                    PosDiff(nRuns) = Math.Abs(j - iRun)
                    nRuns += 1
                    If nRuns >= 1 + NumStds / 2 Then Exit For
                End If
            Next
            For j = iRun + 1 To iLast     ' working forwards after the sample...
                If IsStd(j) And ((RunPos(iRun) <> RunPos(j)) Or AllowSelfNorm) Then
                    RunNums(nRuns) = j
                    TimeDiff(nRuns) = Math.Abs(iRunTimes(j) - iRunTimes(iRun))      ' save run time difference
                    PosDiff(nRuns) = Math.Abs(j - iRun)
                    nRuns += 1
                    If nRuns >= 2 + NumStds Then Exit For
                End If
            Next
        Else                        ' for second half, look after the sample first
            For j = iRun + 1 To iLast         ' working forwards after the sample...
                If IsStd(j) And ((RunPos(iRun) <> RunPos(j)) Or AllowSelfNorm) Then
                    RunNums(nRuns) = j
                    TimeDiff(nRuns) = Math.Abs(iRunTimes(j) - iRunTimes(iRun))      ' save run time difference
                    PosDiff(nRuns) = Math.Abs(j - iRun)
                    nRuns += 1
                    If nRuns >= 1 + NumStds / 2 Then Exit For
                End If
            Next
            For j = iRun - 1 To iFirst Step -1      ' working backwards before the sample...
                If IsStd(j) And ((RunPos(iRun) <> RunPos(j)) Or AllowSelfNorm) Then
                    RunNums(nRuns) = j
                    TimeDiff(nRuns) = Math.Abs(iRunTimes(j) - iRunTimes(iRun))      ' save run time difference
                    PosDiff(nRuns) = Math.Abs(j - iRun)
                    nRuns += 1
                    If nRuns >= 2 + NumStds Then Exit For
                End If
            Next
        End If
        ' OK we now have two more standards than we need, so we will now sort down to the required number by time
        '  then do a bubble sort by TimeDiff if by time, by position if bracketing 
        Dim TempRun As Integer = 0
        Dim TempDiff As Integer = 0
        If CalcMode = "Bracket Average" Then
            For i = 0 To nRuns - 2
                For j = i To nRuns - 1
                    If PosDiff(j) < PosDiff(i) Then
                        TempRun = RunNums(j)
                        TempDiff = PosDiff(j)
                        RunNums(j) = RunNums(i)
                        PosDiff(j) = PosDiff(i)
                        RunNums(i) = TempRun
                        PosDiff(i) = TempDiff
                    End If
                Next
            Next
        Else    ' must be timed
            For i = 0 To nRuns - 2
                For j = i To nRuns - 1
                    If TimeDiff(j) < TimeDiff(i) Then
                        TempRun = RunNums(j)
                        TempDiff = TimeDiff(j)
                        RunNums(j) = RunNums(i)
                        TimeDiff(j) = TimeDiff(i)
                        RunNums(i) = TempRun
                        TimeDiff(i) = TempDiff
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub ComputeRun(ByVal iRun As Integer, ByRef AnalType As String, ByVal nRuns As Integer, ByRef RunNums() As Integer)
        ' iRun = run to be computed, AnalType = type of analysis (linear, average), nRuns = number standards used, 
        ' RunNums = array of pointers, pos 0 = 3 pointers, pos 1 - nRuns = pointers to standard runs
        Dim sumY As Double = 0                      ' accumulator for average 14/12
        Dim sumSq As Double = 0                     ' accumulator for standard deviation
        Dim sumSig As Double = 0                    ' accumulator for the standards errors
        Dim sumD As Double = 0                      ' accumulator for average 13/12
        Dim sumsqD As Double = 0                    ' accumulator for standard deviation
        If (AnalType = "Average in Time") Or (AnalType = "Bracket Average") Then
            For i = 0 To nRuns - 1          ' NB: these are unweighted averages of standard values used in normalization
                ' RunNums is  a pointer array to the appropriate normalizing standard runs
                sumY += InputData(RunNums(i)).Item("Corr14/12") / StdC14C12(RunNums(i))     ' sum normalized 14/12 values for pertinent standards
                sumSig += (InputData(RunNums(i)).Item("Sig14/12") / StdC14C12(RunNums(i))) ^ 2    ' sum normalized uncertainties in standards
                sumD += InputData(RunNums(i)).Item("HE13/12") / StdC13C12(RunNums(i))       ' sum normalized 13/12 values for pertinent standards
            Next
            NormRat(iRun) = -99         ' default null value
            C13C12(iRun) = -99          ' default null value
            NormRatErr(iRun) = -99      ' default null value
            SigC13C12(iRun) = -99       ' default null value
            If nRuns > 0 Then       ' only do this if you have at least one  point!
                Dim avgY As Double = sumY / nRuns
                NormRat(iRun) = InputData(iRun).Item("Corr14/12") / avgY
                Dim avgC13 As Double = sumD / nRuns
                C13C12(iRun) = InputData(iRun).Item("HE13/12") / avgC13
                For i = 0 To nRuns - 1          ' now accumulate standard deviations (for external error calc)
                    sumSq += (InputData(RunNums(i)).Item("Corr14/12") / StdC14C12(RunNums(i)) - avgY) ^ 2
                    sumsqD += (InputData(RunNums(i)).Item("HE13/12") / StdC13C12(RunNums(i)) - avgC13) ^ 2
                Next
                If nRuns > 1 Then       ' only meaningful if you have 2 or more points
                    Dim stdErrSq As Double = sumSq / nRuns / (nRuns - 1)    ' ext Fm err squared
                    Dim stdErrSqC13 As Double = sumsqD / nRuns / (nRuns - 1)    ' ext dC13 err squared
                    Dim TheStdErr As Double = Math.Max(NormRat(iRun) * (sumSig) ^ 0.5 / avgY / nRuns, NormRat(iRun) * stdErrSq ^ 0.5 / avgY)     ' maximum of int/ext errors
                    NormRatErr(iRun) = (TheStdErr ^ 2 + NormRat(iRun) ^ 2 * InputData(iRun).Item("Sig14/12") ^ 2 / InputData(iRun).Item("Corr14/12") ^ 2) ^ 0.5    ' propagated errors
                    SigC13C12(iRun) = (C13C12(iRun) * stdErrSqC13 ^ 0.5) / avgC13                                 'uncertainty in delC13 normalized to VPDB
                End If
            End If
        ElseIf (AnalType = "Linear") And (nRuns > 1) Then
            ' the variables below are for linear regression,d only used with more than one point
            Dim xVal(100) As Double                        ' storage if using the time base rather than just averaging
            Dim yVal(100) As Double                        ' storage for interpolating the C14/C12
            Dim dVal(100) As Double                        ' storage for interpolating the delC13
            Dim m As Double = 0             ' slope for linear fit
            Dim b As Double = 0     ' intercept for linear fit
            Dim Sigm As Double = 0  ' uncertainty in slope
            Dim Sigb As Double = 0  ' uncertainty in intercept
            Dim Sigma As Double = 0 ' RMS scatter
            Dim MeanVal As Double = 0
            For i = 0 To nRuns - 1
                sumY += InputData(RunNums(i)).Item("Corr14/12") / StdC14C12(RunNums(i))
                xVal(i + 1) = RunTimes(RunNums(i))      ' note that LinFit starts arrays at position 1
                yVal(i + 1) = InputData(RunNums(i)).Item("Corr14/12") / StdC14C12(RunNums(i))
                dVal(i + 1) = InputData(RunNums(i)).Item("HE13/12") / StdC13C12(RunNums(i))
            Next
            LinFit(xVal, yVal, nRuns, m, b, Sigb, Sigm, Sigma, MeanVal)
            NormRat(iRun) = Rat(iRun) / (m * RunTimes(iRun) + b)
            NormRatErr(iRun) = nRuns * ErrRat(iRun) / sumY
            LinFit(xVal, dVal, nRuns, m, b, Sigb, Sigm, Sigma, MeanVal)
            C13C12(iRun) = InputData(iRun).Item("HE13/12") / (m * RunTimes(iRun) + b)
            If nRuns > 2 Then
                SigC13C12(iRun) = C13C12(iRun) * Sigma / MeanVal / (nRuns - 2) ^ 0.5
            Else
                SigC13C12(iRun) = 42
            End If
        End If
    End Sub

    Public Sub LinFit(ByVal x() As Double, ByVal y() As Double, ByVal n As Integer, ByRef m As Double,
                           ByRef b As Double, ByRef sigb As Double, ByRef sigm As Double,
                           ByRef sigma As Double, ByRef MeanVal As Double)
        ' given an input matrix of length n, returns the intercept b, the slope m, and the uncertainties in both
        Dim SumX As Double = 0.0, SumX2 As Double = 0.0, SumY As Double = 0.0, SumXY As Double = 0.0, SumY2 As Double = 0.0
        Dim SigSq As Double = 0.0
        If n > 2 Then
            Dim iStart As Integer = 1, iFinish As Integer = n
            For I% = iStart To iFinish
                SumX = SumX + x(I)
                SumX2 = SumX2 + x(I) ^ 2
                SumY = SumY + y(I)
                SumXY = SumXY + x(I) * y(I)
                SumY2 = SumY2 + y(I) ^ 2
            Next I
            MeanVal = SumY / n
            Dim Del As Double = n * SumX2 - SumX ^ 2
            b = (SumY * SumX2 - SumXY * SumX) / Del
            m = (n * SumXY - SumX * SumY) / Del
            If n > 2 Then
                SigSq = (SumY2 + n * b ^ 2 + SumX2 * m ^ 2 - 2 * b * SumY - 2 * m * SumXY + 2 * b * m * SumX) / (n - 2)
            Else
                SigSq = 1
            End If
            sigb = (SigSq * SumX2 / Del)
            sigm = (SigSq * n / Del)
            sigma = SigSq
            If SigSq > 0 Then
                sigb = sigb ^ 0.5
                sigm = sigm ^ 0.5
                sigma = sigma ^ 0.5
            End If
        End If      ' n > 2?
    End Sub

    Private Sub AccumulateResults(iPos As Integer)
        ' accumulate and calculate results for a given target from the valid runs
        TargetRat(iPos) = 0
        IntErr(iPos) = 0
        TargetRuns(iPos) = 0
        ExtErr(iPos) = 0
        C13Rat(iPos) = 0
        SigC13(iPos) = 0
        For i = 1 To RunKeys(iPos, 0)
            Dim iRun As Integer = RunKeys(iPos, i)
            If InputData(iRun).Item("OK") Then
                TargetRat(iPos) += NormRat(iRun) / NormRatErr(iRun) ^ 2            ' weighted mean
                IntErr(iPos) += 1 / NormRatErr(iRun) ^ 2
                C13Rat(iPos) += C13C12(iRun) / SigC13C12(iRun) ^ 2            ' weighted mean
                SigC13(iPos) += 1 / SigC13C12(iRun) ^ 2
                TargetRuns(iPos) += 1
            End If
        Next
        SigC13IntErr(iPos) = 0
        If SigC13(iPos) > 0 Then SigC13IntErr(iPos) = SigC13(iPos) ^ -0.5
        If TargetRuns(iPos) > 0 Then
            TargetRat(iPos) /= IntErr(iPos)        ' weighted mean C14 ratio
            C13Rat(iPos) /= SigC13(iPos)            ' weighted mean C13 ratio
            IntErr(iPos) = IntErr(iPos) ^ (-0.5)                    ' aggregate internal error
            SigC13(iPos) = 0                ' re-zero the sum in case N <2
            If TargetRuns(iPos) > 1 Then                        ' Exterr only means something if N > 1
                For i = 1 To RunKeys(iPos, 0)
                    Dim iRun As Integer = RunKeys(iPos, i)
                    If InputData(iRun).Item("OK") Then
                        ExtErr(iPos) += (NormRat(iRun) - TargetRat(iPos)) ^ 2
                        SigC13(iPos) += (C13C12(RunKeys(iPos, i)) - C13Rat(iPos)) ^ 2
                    End If
                Next
                ExtErr(iPos) = (ExtErr(iPos) / (TargetRuns(iPos) - 1) / TargetRuns(iPos)) ^ 0.5
                SigC13(iPos) = (SigC13(iPos) / (TargetRuns(iPos) - 1) / TargetRuns(iPos)) ^ 0.5
            End If
        Else        ' insert flagged values if no runs left
            IntErr(iPos) = -99
            ExtErr(iPos) = -99
            TargetRat(iPos) = -99
            SigC13(iPos) = -99
            C13Rat(iPos) = -99
            SigC13IntErr(iPos) = -99
        End If
    End Sub

    Public Sub ReCountRuns(iPos As Integer)
        Dim nRuns As Integer = 0
        For i = 0 To NumRuns - 1
            If InputData(i).Item("OK") And (InputData(i).Item("Pos") = iPos) Then
                nRuns += 1
            End If
        Next
        For i = 0 To TargetData.Rows.Count - 1
            If TargetData(i).Item("Pos") = iPos Then TargetData(i).Item("N") = nRuns
        Next
    End Sub


#End Region         ' normalize results

#Region "Blank Correction Routines"

    Public Sub SetUpBlankTables()
        With frmBlankCorr
            With .tblInorganic
                .Columns.Clear()
                .Columns.Add("Inorganic_Blank", GetType(String))
                .Columns.Add("Value_Used", GetType(Double))
                .Columns.Add("Uncertainty", GetType(Double))
                .Rows.Clear()
                If (TheWheel.Name.Substring(0, 5) = "CFAMS") Then
                    .Rows.Add("Large_Blank", 0.002, 0.0015)
                    .Rows.Add("Cont_Mass (ug)", 0.3, 0.1)
                    .Rows.Add("Cont Fm", 0.75, 0.25)
                Else
                    .Rows.Add("Large_Blank", 0.0008, 0.0004)
                    .Rows.Add("Cont_Mass (ug)", 0.3, 0.1)
                    .Rows.Add("Cont Fm", 0.75, 0.25)
                End If
            End With
            .dgvInorganic.Width = .dgvInorganic.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3
            .dgvInorganic.Height = .dgvInorganic.Rows.GetRowsHeight(DataGridViewElementStates.None) + .dgvInorganic.ColumnHeadersHeight + 3
            With .tblOrganic
                .Columns.Clear()
                .Columns.Add("Organic_Blank", GetType(String))
                .Columns.Add("Value_Used", GetType(Double))
                .Columns.Add("Uncertainty", GetType(Double))
                .Rows.Clear()
                If (TheWheel.Name.Substring(0, 5) = "CFAMS") Then
                    .Rows.Add("Large_Blank", 0.0045, 0.0022)
                    .Rows.Add("Cont Mass (ug)", 1.2, 0.5)
                    .Rows.Add("Cont Fm", 0.5, 0.25)
                Else
                    .Rows.Add("Large_Blank", 0.002, 0.001)
                    .Rows.Add("Cont Mass (ug)", 1.2, 0.5)
                    .Rows.Add("Cont Fm", 0.5, 0.25)
                End If
            End With
            With .tblWatson
                .Columns.Clear()
                .Columns.Add("Watson_Blank")
                .Columns.Add("Value_Used", GetType(Double))
                .Columns.Add("Uncertainty", GetType(Double))
                .Rows.Clear()
                .Rows.Add("Large_Blank", 0.0045, 0.0022)
            End With
            .dgvOrganic.Width = .dgvOrganic.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 3
            .dgvOrganic.Height = .dgvOrganic.Rows.GetRowsHeight(DataGridViewElementStates.None) + .dgvOrganic.ColumnHeadersHeight + 3
            .GroupSel = -1      ' default to no group selected the first time through
        End With
    End Sub

    Public Sub SetUpStandardsBlankTables()
        With frmBlankCorr
            .tblStandards.Rows.Clear()
            For ipos = 0 To dgvTargets.Rows.Count - 1
                Dim npos As Integer = dgvTargets("Pos", ipos).Value
                Try
                    If dgvTargets("Typ", ipos).Value = "S" Then
                        Dim MaxErr As Double = Math.Max(dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value)
                        .tblStandards.Rows.Add(npos, TargetNames(npos), dgvTargets("Typ", ipos).Value, TargetRuns(npos), dgvTargets("NormRat", ipos).Value,
                                               dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value, MaxErr,
                                               dgvTargets("DelC13", ipos).Value, dgvTargets("SigC13", ipos).Value,
                                               TotalMass(npos), SigTotalMass(npos), TargetProcs(npos))
                    End If
                Catch ex As Exception
                    ' do nothing if error
                End Try
            Next
            For i = 0 To .tblStandards.Rows.Count - 1
                .dgvStandards.Rows(i).DefaultCellStyle.BackColor = StdCol
                If Not IsDBNull(.tblStandards(i).Item("Proc")) AndAlso Trim(.tblStandards(i).Item("Proc")) <> "" Then
                    Select Case .tblStandards(i).Item("Proc")
                        Case "GS", "HY"
                            .tblStandards(i).Item("Fm_Bgnd") = .tblInorganic(0).Item("Value_Used")
                            .tblStandards(i).Item("SigFmBgnd") = .tblInorganic(0).Item("Uncertainty")
                        Case "OC"
                            .tblStandards(i).Item("Fm_Bgnd") = .tblOrganic(0).Item("Value_Used")
                            .tblStandards(i).Item("SigFmBgnd") = .tblOrganic(0).Item("Uncertainty")
                        Case "WC", "WG"
                            .tblStandards(i).Item("Fm_Bgnd") = .tblWatson(0).Item("Value_Used")
                            .tblStandards(i).Item("SigFmBgnd") = .tblWatson(0).Item("Uncertainty")
                        Case Else
                            .tblStandards(i).Item("Fm_Bgnd") = 0.0
                            .tblStandards(i).Item("SigFmBgnd") = 0.0
                    End Select
                Else
                    .tblStandards(i).Item("Fm_Bgnd") = 0.0
                    .tblStandards(i).Item("SigFmBgnd") = 0.0
                End If
                .tblStandards(i).Item("Fm_Expected") = AsmRat(.tblStandards(i).Item("Pos"))
            Next
            For i = 0 To .tblStandards.Rows.Count - 1
                Dim nPos As Integer = .tblStandards(i).Item("Pos")
                If Not .chkLockAll.Checked Then
                    .tblStandards(i).Item("Fm_Corr") = LargeBlankCorrected(.tblStandards(i).Item("Fm_Meas"), .tblStandards(i).Item("Fm_Bgnd"),
                                                                           AsmRat(.tblStandards(i).Item("Pos")))
                    .tblStandards(i).Item("Sig_Fm_Corr") = SigLargeBlankCorrected(.tblStandards(i).Item("Fm_Meas"), .tblStandards(i).Item("Fm_Bgnd"),
                                             AsmRat(.tblStandards(i).Item("Pos")), .tblStandards(i).Item("Max_Err"), .tblStandards(i).Item("SigFmBgnd"))
                    FmCorr(nPos) = .tblStandards(i).Item("Fm_Corr")
                    SigFmCorr(nPos) = .tblStandards(i).Item("Sig_Fm_Corr")
                Else
                    .tblStandards(i).Item("Fm_Corr") = FmCorr(nPos)
                    .tblStandards(i).Item("Sig_Fm_Corr") = SigFmCorr(nPos)
                End If
                .tblStandards(i).Item("Libby_Age") = LibbyAge(FmCorr(nPos), SigFmCorr(nPos))
                .tblStandards(i).Item("Sig_Libby_Age") = SigLibbyAge(FmCorr(nPos), SigFmCorr(nPos))
                .tblStandards(i).Item("Delta_Fm") = .tblStandards(i).Item("Fm_Corr") - .tblStandards(i).Item("Fm_Expected")
                .tblStandards(i).Item("Sigma_Val") = (.tblStandards(i).Item("Fm_Corr") - .tblStandards(i).Item("Fm_Expected")) / .tblStandards(i).Item("Sig_Fm_Corr")
                If Math.Abs(.tblStandards(i).Item("Sigma_Val")) > 2 Then
                    .dgvStandards("Sigma_Val", i).Style.BackColor = Color.Pink
                End If
                LgBlkFm(nPos) = .tblStandards(i).Item("Fm_Bgnd")
                SigLgBlkFm(nPos) = .tblStandards(i).Item("SigFmBgnd")
            Next
        End With
    End Sub

    Public Function LibbyAge(ByVal Fm As Double, ByVal SigFm As Double) As String      ' returns a string for Libby Age
        If Fm - SigFm > 0 Then
            Return (-8033 * Math.Log(Fm)).ToString("0")
        ElseIf Fm > 0 Then
            Return ">" & (-8033 * Math.Log(Fm + SigFm)).ToString("0")
        Else
            Return ">" & (-8033 * Math.Log(SigFm)).ToString("0")
        End If
    End Function

    Public Function SigLibbyAge(ByVal Fm As Double, ByVal SigFm As Double) As Double     ' returns a value for Libby Age Unertainty
        If Fm - SigFm > 0 Then
            Return (8033 * (SigFm / Fm))
        Else
            Return 0
        End If
    End Function

    Public Sub SetUpBlankBlankTable()
        With frmBlankCorr
            .tblBlanks.Rows.Clear()
            For ipos = 0 To dgvTargets.Rows.Count - 1              ' first find the non-typical blanks (e.g., alfa asar)
                Try
                    Dim npos As Integer = dgvTargets("Pos", ipos).Value
                    If (dgvTargets("Typ", ipos).Value = "B") And ((TargetProcs(npos) = "")) Then
                        Dim MaxErr As Double = Math.Max(dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value)
                        .tblBlanks.Rows.Add(False, npos, TargetNames(npos), dgvTargets("Typ", ipos).Value, TargetRuns(npos), dgvTargets("NormRat", ipos).Value,
                                               dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value, MaxErr,
                                               dgvTargets("DelC13", ipos).Value, dgvTargets("SigC13", ipos).Value,
                                               TotalMass(npos), SigTotalMass(npos), TargetProcs(npos))
                    End If
                Catch ex As Exception
                    ' ignore exception
                End Try
            Next
            For ipos = 0 To dgvTargets.Rows.Count - 1
                Try
                    Dim npos As Integer = dgvTargets("Pos", ipos).Value
                    If (dgvTargets("Typ", ipos).Value = "B") And ((TargetProcs(npos) = "HY") Or (TargetProcs(npos) = "GS") _
                                            Or (TargetProcs(npos) = "WS")) And (TargetMass(npos) > 150) Then
                        Dim MaxErr As Double = Math.Max(dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value)
                        .tblBlanks.Rows.Add(True, npos, TargetNames(npos), dgvTargets("Typ", ipos).Value, TargetRuns(npos), dgvTargets("NormRat", ipos).Value,
                                               dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value, MaxErr,
                                               dgvTargets("DelC13", ipos).Value, dgvTargets("SigC13", ipos).Value,
                                               TotalMass(npos), SigTotalMass(npos), TargetProcs(npos))
                    End If
                Catch ex As Exception
                    ' ignore exception
                End Try
            Next
            For ipos = 0 To dgvTargets.Rows.Count - 1
                Try
                    Dim npos As Integer = dgvTargets("Pos", ipos).Value
                    If (dgvTargets("Typ", ipos).Value = "B") And ((TargetProcs(npos) = "OC")) And (TargetMass(npos) > 150) Then
                        Dim MaxErr As Double = Math.Max(dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value)
                        .tblBlanks.Rows.Add(True, npos, TargetNames(npos), dgvTargets("Typ", ipos).Value, TargetRuns(npos), dgvTargets("NormRat", ipos).Value,
                                               dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value, MaxErr,
                                               dgvTargets("DelC13", ipos).Value, dgvTargets("SigC13", ipos).Value,
                                               TotalMass(npos), SigTotalMass(npos), TargetProcs(npos))
                    End If
                Catch ex As Exception
                    ' ignore exception
                End Try
            Next
            For ipos = 0 To dgvTargets.Rows.Count - 1
                Try
                    Dim npos As Integer = dgvTargets("Pos", ipos).Value
                    If (dgvTargets("Typ", ipos).Value = "B") And ((TargetProcs(npos) = "WC") Or (TargetProcs(npos) = "WG")) Then
                        Dim MaxErr As Double = Math.Max(dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value)
                        .tblBlanks.Rows.Add(True, npos, TargetNames(npos), dgvTargets("Typ", ipos).Value, TargetRuns(npos), dgvTargets("NormRat", ipos).Value,
                                               dgvTargets("IntErr", ipos).Value, dgvTargets("ExtErr", ipos).Value, MaxErr,
                                               dgvTargets("DelC13", ipos).Value, dgvTargets("SigC13", ipos).Value,
                                               TotalMass(npos), SigTotalMass(npos), TargetProcs(npos))
                    End If
                Catch ex As Exception
                    ' ignore exception
                End Try
            Next
            For i = 0 To .tblBlanks.Rows.Count - 1
                .dgvBlanks.Rows(i).DefaultCellStyle.BackColor = BlkCol
                .tblBlanks(i).Item("Fm_Expected") = AsmRat(.tblBlanks(i).Item("Pos"))
                If IsDBNull(.tblBlanks(i).Item("Proc")) Then
                    .tblBlanks(i).Item("OK") = False
                Else
                    If .tblBlanks(i).Item("Fm_Expected") > 0.002 Then .tblBlanks(i).Item("OK") = False
                    If (.tblBlanks(i).Item("Mass(ug)") < 150) And (.tblBlanks(i).Item("Proc") <> "WG") Then .tblBlanks(i).Item("OK") = False
                End If
            Next
            ComputeBlanks()
        End With
    End Sub

    Public Sub ComputeBlanks()
        Dim SumErrInorg As Double = 0.0
        Dim SumInorg As Double = 0.0
        Dim SumSqInorg As Double = 0.0
        Dim NumInorg As Integer = 0
        Dim SumErrOrg As Double = 0.0
        Dim SumOrg As Double = 0.0
        Dim SumSqOrg As Double = 0.0
        Dim NumOrg As Integer = 0
        Dim SumWat As Double = 0.0
        Dim SumErrWat As Double = 0.0
        Dim SumSqWat As Double = 0.0
        Dim NumWat As Integer = 0
        With frmBlankCorr
            For i = 0 To .tblBlanks.Rows.Count - 1
                .dgvBlanks.Rows(i).DefaultCellStyle.BackColor = BlkCol
                .tblBlanks(i).Item("Fm_Expected") = AsmRat(.tblBlanks(i).Item("Pos"))
                If Not IsDBNull(.tblBlanks(i).Item("Proc")) AndAlso .tblBlanks(i).Item("OK") Then
                    Select Case .tblBlanks(i).Item("Proc")
                        Case "HY", "GS", "WS"
                            If WTDBLANK Then
                                SumInorg += .tblBlanks(i).Item("Fm_Meas") / (.tblBlanks(i).Item("Max_Err") ^ 2)
                                SumErrInorg += 1 / (.tblBlanks(i).Item("Max_Err") ^ 2)
                            Else
                                SumInorg += .tblBlanks(i).Item("Fm_Meas")
                                SumErrInorg += 1
                            End If
                            SumSqInorg += .tblBlanks(i).Item("Fm_Meas") ^ 2
                        Case "OC"
                            If WTDBLANK Then
                                SumOrg += .tblBlanks(i).Item("Fm_Meas") / (.tblBlanks(i).Item("Max_Err") ^ 2)
                                SumErrOrg += 1 / (.tblBlanks(i).Item("Max_Err") ^ 2)
                            Else
                                SumOrg += .tblBlanks(i).Item("Fm_Meas")
                                SumErrOrg += 1
                            End If
                            SumSqOrg += .tblBlanks(i).Item("Fm_Meas") ^ 2
                        Case "WC", "WG"
                            If WTDBLANK Then
                                SumWat += .tblBlanks(i).Item("Fm_Meas") / (.tblBlanks(i).Item("Max_Err") ^ 2)
                                SumErrWat += 1 / (.tblBlanks(i).Item("Max_Err") ^ 2)
                            Else
                                SumWat += .tblBlanks(i).Item("Fm_Meas")
                                SumErrWat += 1
                            End If
                            SumSqWat += .tblBlanks(i).Item("Fm_Meas") ^ 2
                    End Select
                End If
            Next
            If SumErrInorg > 0 Then
                SumInorg /= SumErrInorg
                .tblInorganic(0).Item(1) = SumInorg
                If WTDBLANK Then
                    .tblInorganic(0).Item(2) = (1 / SumErrInorg) ^ 0.5
                Else
                    .tblInorganic(0).Item(2) = (SumSqInorg - SumErrInorg * SumInorg ^ 2) ^ 0.5
                    If SumErrInorg > 1 Then
                        .tblInorganic(0).Item(2) /= (SumErrInorg - 1) ^ 0.5        ' to convert to stdev
                    End If
                End If
                If .tblInorganic(0).Item(2) < SumInorg / 2.0 Then .tblInorganic(0).Item(2) = SumInorg / 2.0 ' an error floor
            End If
            If SumErrOrg > 0 Then
                SumOrg /= SumErrOrg
                .tblOrganic(0).Item(1) = SumOrg
                If WTDBLANK Then
                    .tblOrganic(0).Item(2) = (1 / SumErrOrg) ^ 0.5
                Else
                    .tblOrganic(0).Item(2) = (SumSqOrg - SumErrOrg * SumOrg ^ 2) ^ 0.5
                    If SumErrOrg > 1 Then
                        .tblOrganic(0).Item(2) /= (SumErrOrg - 1) ^ 0.5         ' to convert to stdev
                    End If
                End If
                If .tblOrganic(0).Item(2) < SumOrg / 2.0 Then .tblOrganic(0).Item(2) = SumOrg / 2.0 ' an error floor
            End If
            If SumErrWat > 0 Then
                SumWat /= SumErrWat
                .tblWatson(0).Item(1) = SumWat
                If WTDBLANK Then
                    .tblWatson(0).Item(2) = (1 / SumErrWat) ^ 0.5
                Else
                    .tblWatson(0).Item(2) = (SumSqWat - SumErrWat * SumWat ^ 2) ^ 0.5
                    If SumErrWat > 1 Then
                        .tblWatson(0).Item(2) /= (SumErrWat - 1) ^ 0.5
                    End If
                End If
                If .tblWatson(0).Item(2) < SumWat / 2.0 Then .tblWatson(0).Item(2) = SumWat / 2.0 'an error floor
            End If
            For i = 0 To .tblBlanks.Rows.Count - 1
                Dim iPos As Integer = .tblBlanks(i).Item("Pos")
                If Not IsDBNull(.tblBlanks(i).Item("Proc")) Then
                    Select Case .tblBlanks(i).Item("Proc")
                        Case "HY", "GS"
                            .tblBlanks(i).Item("Fm_Bgnd") = .tblInorganic(0).Item(1)
                            .tblBlanks(i).Item("SigFmBgnd") = .tblInorganic(0).Item(2)
                        Case "OC"
                            .tblBlanks(i).Item("Fm_Bgnd") = .tblOrganic(0).Item(1)
                            .tblBlanks(i).Item("SigFmBgnd") = .tblOrganic(0).Item(2)
                        Case "WC", "WG"
                            .tblBlanks(i).Item("Fm_Bgnd") = .tblWatson(0).Item(1)
                            .tblBlanks(i).Item("SigFmBgnd") = .tblWatson(0).Item(2)
                        Case Else
                            .tblBlanks(i).Item("Fm_Bgnd") = 0.0
                            .tblBlanks(i).Item("SigFmBgnd") = 0.0
                    End Select
                    If Not .chkLockAll.Checked Then
                        If .tblBlanks(i).Item("Proc") = "HY" Or .tblBlanks(i).Item("Proc") = "GS" Or .tblBlanks(i).Item("Proc") = "OC" _
                                        Or .tblBlanks(i).Item("Proc") = "WS" Or .tblBlanks(i).Item("Proc") = "WC" Or .tblBlanks(i).Item("Proc") = "WG" Then
                            .tblBlanks(i).Item("Fm_Corr") = LargeBlankCorrected(.tblBlanks(i).Item("Fm_Meas"), .tblBlanks(i).Item("Fm_Bgnd"), 1.0398)
                            .tblBlanks(i).Item("Sig_Fm_Corr") = SigLargeBlankCorrected(.tblBlanks(i).Item("Fm_Meas"), .tblBlanks(i).Item("Fm_Bgnd"),
                                                                               1.0398, .tblBlanks(i).Item("Max_Err"), .tblBlanks(i).Item("SigFmBgnd"))
                            FmCorr(iPos) = .tblBlanks(i).Item("Fm_Corr")
                            SigFmCorr(iPos) = .tblBlanks(i).Item("Sig_Fm_Corr")
                            LgBlkFm(iPos) = .tblBlanks(i).Item("Fm_Bgnd")
                            SigLgBlkFm(iPos) = .tblBlanks(i).Item("SigFmBgnd")
                        End If
                    Else
                        .tblBlanks(i).Item("Fm_Corr") = FmCorr(iPos)
                        .tblBlanks(i).Item("Sig_Fm_Corr") = SigFmCorr(iPos)
                    End If
                Else
                    FmCorr(iPos) = .tblBlanks(i).Item("Fm_Meas")
                    SigFmCorr(iPos) = .tblBlanks(i).Item("Max_Err")
                    .tblBlanks(i).Item("Fm_Corr") = FmCorr(iPos)
                    .tblBlanks(i).Item("Sig_Fm_Corr") = SigFmCorr(iPos)
                End If
            Next
            For i = 0 To .tblBlanks.Rows.Count - 1
                Dim iPos As Integer = .tblBlanks(i).Item("Pos")
                .tblBlanks(i).Item("Libby_Age") = LibbyAge(.tblBlanks(i).Item("Fm_Meas"), .tblBlanks(i).Item("Max_Err"))
                .tblBlanks(i).Item("Sig_Libby_Age") = SigLibbyAge(.tblBlanks(i).Item("Fm_Meas"), .tblBlanks(i).Item("Max_Err"))
            Next
        End With
    End Sub

    Public Sub DoGroupBlankTables()
        With frmBlankCorr
            .tbcGroups.TabPages.Clear()
            For iGrp = 0 To NumGroups - 1
                Dim GroupIsReadOnly As Boolean = False
                GroupAvgStdFm(iGrp) = 0
                Dim nStdsInGrp = 0
                .tblGroup(iGrp) = New DataTable
                .dgvGroup(iGrp) = New DataGridView
                .chkSmall(iGrp) = New CheckBox
                .chkLock(iGrp) = New CheckBox
                .lblGroup(iGrp) = New System.Windows.Forms.Label
                AddHandler .dgvGroup(iGrp).CurrentCellDirtyStateChanged, AddressOf .dgvGroups_CurrentCellDirtyStateChanged
                AddHandler .dgvGroup(iGrp).CellContentClick, AddressOf .dgvGroups_CellContentClick
                AddHandler .chkSmall(iGrp).CheckedChanged, AddressOf .SmallChkBox_CheckedChanged
                .tbcGroups.TabPages.Add("Group " & (iGrp + 1).ToString)
                .tbcGroups.TabPages(iGrp).Controls.Add(.dgvGroup(iGrp))
                .tbcGroups.TabPages(iGrp).Controls.Add(.chkSmall(iGrp))
                .tbcGroups.TabPages(iGrp).Controls.Add(.chkLock(iGrp))
                .tbcGroups.TabPages(iGrp).Controls.Add(.lblGroup(iGrp))
                .chkSmall(iGrp).Text = "MBC"
                .chkSmall(iGrp).Checked = True
                .chkSmall(iGrp).Tag = iGrp
                .chkLock(iGrp).Left = .chkSmall(iGrp).Right + 30
                .chkLock(iGrp).Top = .chkSmall(iGrp).Top
                .chkLock(iGrp).Text = "Locked"
                .chkLock(iGrp).Checked = False
                .lblGroup(iGrp).Text = "THIS GROUP Is READ ONLY!"
                .lblGroup(iGrp).Left = .chkLock(iGrp).Right + 30
                .lblGroup(iGrp).Top = .chkLock(iGrp).Top
                .lblGroup(iGrp).Font = New Font("Arial Bold", 14)
                .lblGroup(iGrp).Width = 400
                .lblGroup(iGrp).ForeColor = Color.Red
                AddBlkCorrColumns(.tblGroup(iGrp), .dgvGroup(iGrp))
                ArrangeDGV(.dgvGroup(iGrp))
                .dgvGroup(iGrp).Tag = iGrp
                For iPos = 0 To dgvTargets.Rows.Count - 1
                    Dim npos As Integer = dgvTargets("Pos", iPos).Value
                    If TargetGroups(npos) = iGrp + 1 And dgvTargets("Typ", iPos).Value <> "S" Then          ' And dgvTargets("Typ", iPos).Value <> "B" Then
                        Dim MaxErr As Double = Math.Max(dgvTargets("IntErr", iPos).Value, dgvTargets("ExtErr", iPos).Value)

                        .tblGroup(iGrp).Rows.Add(TargetIsSmall(npos), True, npos, TargetNames(npos),
                            dgvTargets("Typ", iPos).Value, TargetRuns(npos), dgvTargets("NormRat", iPos).Value,
                            dgvTargets("IntErr", iPos).Value, dgvTargets("ExtErr", iPos).Value, MaxErr,
                            dgvTargets("DelC13", iPos).Value, dgvTargets("SigC13", iPos).Value,
                            TotalMass(npos), SigTotalMass(npos), TargetProcs(npos))            ' Use TotalMass and mass error from dc13

                        If TargetIsReadOnly(iPos) Then
                            GroupIsReadOnly = True
                            .dgvGroup(iGrp).Rows(.dgvGroup(iGrp).Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Gray
                        Else
                            .dgvGroup(iGrp).Rows(.dgvGroup(iGrp).Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
                        End If
                    End If
                    If TargetGroups(npos) = iGrp + 1 And dgvTargets("Typ", iPos).Value = "S" Then
                        GroupAvgStdFm(iGrp) += AsmRat(npos)
                        nStdsInGrp += 1
                    End If
                Next
                .lblGroup(iGrp).Visible = GroupIsReadOnly
                If nStdsInGrp <> 0 Then GroupAvgStdFm(iGrp) /= nStdsInGrp
                For j = 0 To .tblGroup(iGrp).Rows.Count - 1
                    If AsmRat(.tblGroup(iGrp).Rows(j).Item("Pos")) <> 42 Then
                        .tblGroup(iGrp).Rows(j).Item("Fm_Expected") = AsmRat(.tblGroup(iGrp).Rows(j).Item("Pos"))
                    End If
                    .dgvGroup(iGrp).Rows(j).DefaultCellStyle.BackColor = TargetColor(.dgvGroup(iGrp).Item("Typ", j).Value)
                Next
            Next            ' for each group
            For iGrp = 0 To NumGroups - 1
                For i = 0 To .tblGroup(iGrp).Rows.Count - 1
                    SetLgBlkCorr(iGrp, i)
                Next
                If .tblGroup(iGrp).Rows.Count = 0 Then .tbcGroups.TabPages(iGrp).Text = "None"
                For iRow = 0 To .tblGroup(iGrp).Rows.Count - 1
                    DoLgBlkCorr(iGrp, iRow)
                    If .tblGroup(iGrp).Rows(iRow).Item(1) Then DoMBCorr(iGrp, iRow)
                Next
            Next        ' for each group
        End With
    End Sub

    Public Sub SetLgBlkCorr(iGrp As Integer, iRow As Integer)
        With frmBlankCorr.tblGroup(iGrp).Rows(iRow)
            If (Not frmBlankCorr.chkLock(iGrp).Checked) And (Not frmBlankCorr.chkLockAll.Checked) Then
                If Not IsDBNull(.Item("Proc")) AndAlso Trim(.Item("Proc")) <> "" Then
                    Select Case .Item("Proc")
                        Case "GS", "HY", "WS"
                            .Item("Fm_Bgnd") = frmBlankCorr.tblInorganic(0).Item("Value_Used")
                            .Item("SigFmBgnd") = frmBlankCorr.tblInorganic(0).Item("Uncertainty")
                        Case "OC", "DOC"
                            .Item("Fm_Bgnd") = frmBlankCorr.tblOrganic(0).Item("Value_Used")
                            .Item("SigFmBgnd") = frmBlankCorr.tblOrganic(0).Item("Uncertainty")
                        Case "WC", "WG", "SW"
                            .Item("Fm_Bgnd") = frmBlankCorr.tblWatson(0).Item("Value_Used")
                            .Item("SigFmBgnd") = frmBlankCorr.tblWatson(0).Item("Uncertainty")
                        Case Else
                            .Item("Fm_Bgnd") = 0.0
                            .Item("SigFmBgnd") = 0.0
                    End Select
                Else
                    .Item("Fm_Bgnd") = 0.0
                    .Item("SigFmBgnd") = 0.0

                End If
            End If
        End With
    End Sub

    Public Sub DoLgBlkCorr(iGrp As Integer, iRow As Integer)
        With frmBlankCorr
            If (Not .chkLock(iGrp).Checked) And (Not .chkLockAll.Checked) Then
                Dim iPos As Integer = .tblGroup(iGrp)(iRow).Item("Pos")
                If GroupAvgStdFm(iGrp) <> 0 Then
                    .tblGroup(iGrp)(iRow).Item("Fm_Corr") = LargeBlankCorrected(.tblGroup(iGrp)(iRow).Item("Fm_Meas"), .tblGroup(iGrp)(iRow).Item("Fm_Bgnd"),
                                                                            GroupAvgStdFm(iGrp))
                    .tblGroup(iGrp)(iRow).Item("Sig_Fm_Corr") = SigLargeBlankCorrected(.tblGroup(iGrp)(iRow).Item("Fm_Meas"), .tblGroup(iGrp)(iRow).Item("Fm_Bgnd"),
                                                                            GroupAvgStdFm(iGrp), .tblGroup(iGrp)(iRow).Item("Max_Err"), .tblGroup(iGrp)(iRow).Item("SigFmBgnd"))
                    FmCorr(iPos) = .tblGroup(iGrp)(iRow).Item("Fm_Corr")
                    SigFmCorr(iPos) = .tblGroup(iGrp)(iRow).Item("Sig_Fm_Corr")
                    .tblGroup(iGrp)(iRow).Item("Libby_Age") = LibbyAge(FmCorr(iPos), SigFmCorr(iPos))
                    .tblGroup(iGrp)(iRow).Item("Sig_Libby_Age") = SigLibbyAge(FmCorr(iPos), SigFmCorr(iPos))
                    LgBlkFm(iPos) = .tblGroup(iGrp)(iRow).Item("Fm_Bgnd")
                    SigLgBlkFm(iPos) = .tblGroup(iGrp)(iRow).Item("SigFmBgnd")
                End If
                If Not IsDBNull(.tblGroup(iGrp)(iRow).Item("Fm_Expected")) Then
                    .tblGroup(iGrp)(iRow).Item("Delta_Fm") = (.tblGroup(iGrp)(iRow).Item("Fm_Corr") - .tblGroup(iGrp)(iRow).Item("Fm_Expected"))
                    .tblGroup(iGrp)(iRow).Item("Sigma_Val") = (.tblGroup(iGrp)(iRow).Item("Fm_Corr") - .tblGroup(iGrp)(iRow).Item("Fm_Expected")) / .tblGroup(iGrp)(iRow).Item("Sig_Fm_Corr")
                    If Math.Abs(.tblGroup(iGrp)(iRow).Item("Sigma_Val")) > 2 Then
                        .dgvGroup(iGrp).Rows(iRow).Cells("Sigma_Val").Style.BackColor = Color.Pink
                    End If
                End If
            End If          ' not locked
            If .chkLockAll.Checked Then
                Dim iPos As Integer = .tblGroup(iGrp)(iRow).Item("Pos")
                .tblGroup(iGrp)(iRow).Item("Libby_Age") = LibbyAge(FmCorr(iPos), SigFmCorr(iPos))
                .tblGroup(iGrp)(iRow).Item("Sig_Libby_Age") = SigLibbyAge(FmCorr(iPos), SigFmCorr(iPos))
            End If
        End With
    End Sub

    Public Sub DoMBCorr(iGrp As Integer, iRow As Integer)
        With frmBlankCorr
            If (Not .chkLock(iGrp).Checked) And (Not .chkLockAll.Checked) Then
                Dim iPos As Integer = .tblGroup(iGrp)(iRow).Item("Pos")
                If TargetProcs(iPos) <> "" And TotalMass(iPos) > 0 And MBCFm(iPos) > 0 And MBCMass(iPos) > 0 And MBCFmSig(iPos) > 0 And MBCMassSig(iPos) > 0 Then
                    .tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr") = FmMassBal(.tblGroup(iGrp)(iRow).Item("Fm_Corr"), MBCFm(iPos), .tblGroup(iGrp)(iRow).Item("Mass(ug)"), MBCMass(iPos))
                    .tblGroup(iGrp)(iRow).Item("Sig_Fm_Blk_Corr") = SigFmMassBal(.tblGroup(iGrp)(iRow).Item("Fm_Corr"), MBCFm(iPos), .tblGroup(iGrp)(iRow).Item("Mass(ug)"), MBCMass(iPos),
                                                                                .tblGroup(iGrp)(iRow).Item("Sig_Fm_Corr"), MBCFmSig(iPos), .tblGroup(iGrp)(iRow).Item("SigMass"), MBCMassSig(iPos))
                    If TargetProcs(iPos) = "DOC" Then
                        .tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr") = FmMassBalmc(.tblGroup(iGrp)(iRow).Item("Fm_Corr"), MBCFm(iPos), .tblGroup(iGrp)(iRow).Item("Mass(ug)"), MBCMass(iPos))
                        .tblGroup(iGrp)(iRow).Item("Sig_Fm_Blk_Corr") = SigFmMassBalmc(.tblGroup(iGrp)(iRow).Item("Fm_Corr"), MBCFm(iPos), .tblGroup(iGrp)(iRow).Item("Mass(ug)"), MBCMass(iPos),
                                                                                    .tblGroup(iGrp)(iRow).Item("Sig_Fm_Corr"), MBCFmSig(iPos), .tblGroup(iGrp)(iRow).Item("SigMass"), MBCMassSig(iPos))
                    End If
                    FmMBCorr(iPos) = .tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr")
                    SigFmMBCorr(iPos) = .tblGroup(iGrp)(iRow).Item("Sig_Fm_Blk_Corr")
                    MBBlkFm(iPos) = MBCFm(iPos)
                    SigMBBlkFm(iPos) = MBCFmSig(iPos)
                    MBBlkMass(iPos) = MBCMass(iPos)
                    SigMBBlkMass(iPos) = MBCMassSig(iPos)
                    .tblGroup(iGrp)(iRow).Item("Fm_MBC") = MBCFm(iPos)
                    .tblGroup(iGrp)(iRow).Item("Mass_MBC") = MBCMass(iPos)
                    .tblGroup(iGrp)(iRow).Item("Sig_Fm_MBC") = MBCFmSig(iPos)
                    .tblGroup(iGrp)(iRow).Item("Sig_Mass_MBC") = MBCMassSig(iPos)
                    FmMBCorr(iPos) = .tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr")
                    SigFmMBCorr(iPos) = .tblGroup(iGrp)(iRow).Item("Sig_Fm_Blk_Corr")
                    SigTargetMass(iPos) = .tblGroup(iGrp)(iRow).Item("SigMass")
                    .tblGroup(iGrp)(iRow).Item("Libby_Age") = LibbyAge(FmMBCorr(iPos), SigFmMBCorr(iPos))
                    .tblGroup(iGrp)(iRow).Item("Sig_Libby_Age") = SigLibbyAge(FmMBCorr(iPos), SigFmMBCorr(iPos))
                    If Not IsDBNull(.tblGroup(iGrp)(iRow).Item("Fm_Expected")) Then
                        .tblGroup(iGrp)(iRow).Item("Delta_Fm") = (.tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr") - .tblGroup(iGrp)(iRow).Item("Fm_Expected"))
                        .tblGroup(iGrp)(iRow).Item("Sigma_Val") = (.tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr") - .tblGroup(iGrp)(iRow).Item("Fm_Expected")) / .tblGroup(iGrp)(iRow).Item("Sig_Fm_Blk_Corr")
                        If Math.Abs(.tblGroup(iGrp)(iRow).Item("Sigma_Val")) > 2 Then
                            .dgvGroup(iGrp).Rows(iRow).Cells("Sigma_Val").Style.BackColor = Color.Pink
                        End If
                    End If
                End If
            End If   ' if not locked
            If .chkLockAll.Checked Then
                Dim iPos As Integer = .tblGroup(iGrp)(iRow).Item("Pos")
                .tblGroup(iGrp)(iRow).Item("Libby_Age") = LibbyAge(FmMBCorr(iPos), SigFmMBCorr(iPos))
                .tblGroup(iGrp)(iRow).Item("Sig_Libby_Age") = SigLibbyAge(FmMBCorr(iPos), SigFmMBCorr(iPos))
            End If
        End With
    End Sub

    Public Sub RemoveMassBalanceBlankCorr(iGrp As Integer, iRow As Integer)
        With frmBlankCorr
            If (Not .chkLock(iGrp).Checked) And (Not .chkLockAll.Checked) Then
                Dim iPos As Integer = .tblGroup(iGrp)(iRow).Item("Pos")
                TargetIsSmall(iPos) = False
                FmMBCorr(iPos) = -99
                SigFmMBCorr(iPos) = -99
                .tblGroup(iGrp)(iRow).Item("Fm_Blk_Corr") = DBNull.Value
                .tblGroup(iGrp)(iRow).Item("Sig_Fm_Blk_Corr") = DBNull.Value
                .tblGroup(iGrp)(iRow).Item("Libby_Age") = LibbyAge(FmCorr(iPos), SigFmCorr(iPos))
                .tblGroup(iGrp)(iRow).Item("Sig_Libby_Age") = SigLibbyAge(FmCorr(iPos), SigFmCorr(iPos))
                .tblGroup(iGrp)(iRow).Item("Fm_MBC") = DBNull.Value
                .tblGroup(iGrp)(iRow).Item("Mass_MBC") = DBNull.Value
                .tblGroup(iGrp)(iRow).Item("Sig_Fm_MBC") = DBNull.Value
                .tblGroup(iGrp)(iRow).Item("Sig_Mass_MBC") = DBNull.Value
                If Not IsDBNull(.tblGroup(iGrp)(iRow).Item("Fm_Expected")) Then
                    .tblGroup(iGrp)(iRow).Item("Delta_Fm") = (.tblGroup(iGrp)(iRow).Item("Fm_Corr") - .tblGroup(iGrp)(iRow).Item("Fm_Expected"))
                    .tblGroup(iGrp)(iRow).Item("Sigma_Val") = (.tblGroup(iGrp)(iRow).Item("Fm_Corr") - .tblGroup(iGrp)(iRow).Item("Fm_Expected")) / .tblGroup(iGrp)(iRow).Item("Sig_Fm_Corr")
                End If
            End If   ' not locked
        End With
    End Sub

    Private Sub ArrangeDGV(theDGV As DataGridView)
        With theDGV
            .Top = 20
            .Left = 0
            .Width = frmBlankCorr.tbcGroups.TabPages(0).Width - 10
            .Height = frmBlankCorr.tbcGroups.TabPages(0).Height - 30
        End With
    End Sub

    Private Sub AddBlkCorrColumns(ByRef theTbl As DataTable, ByRef theDGV As DataGridView)
        Dim isGrpTbl As Boolean = Not ((theTbl Is frmBlankCorr.tblStandards) Or (theTbl Is frmBlankCorr.tblBlanks))
        With theTbl
            .Columns.Clear()
            If theTbl Is frmBlankCorr.tblBlanks Then .Columns.Add("OK", GetType(Boolean))
            If isGrpTbl Then
                .Columns.Add("Sm", GetType(Boolean))
                .Columns.Add("MBC", GetType(Boolean))
            End If
            .Columns.Add("Pos", GetType(Integer))
            .Columns.Add("SampleName____________", GetType(String))
            .Columns.Add("Typ", GetType(String))
            .Columns.Add("Rpts", GetType(Integer))
            .Columns.Add("Fm_Meas", GetType(Double))
            .Columns.Add("Int_Err", GetType(Double))
            .Columns.Add("Ext_Err", GetType(Double))
            .Columns.Add("Max_Err", GetType(Double))
            .Columns.Add("DelC13", GetType(Double))
            .Columns.Add("SigC13", GetType(Double))
            .Columns.Add("Mass(ug)", GetType(Double))
            .Columns.Add("SigMass", GetType(Double))
            .Columns.Add("Proc", GetType(String))
            .Columns.Add("Fm_Bgnd", GetType(Double))
            .Columns.Add("SigFmBgnd", GetType(Double))
            .Columns.Add("Fm_Corr", GetType(Double))
            .Columns.Add("Sig_Fm_Corr", GetType(Double))
            If isGrpTbl Then
                .Columns.Add("Fm_MBC", GetType(Double))
                .Columns.Add("Sig_Fm_MBC", GetType(Double))
                .Columns.Add("Mass_MBC", GetType(Double))
                .Columns.Add("Sig_Mass_MBC", GetType(Double))
            End If
            .Columns.Add("Fm_Blk_Corr", GetType(Double))
            .Columns.Add("Sig_Fm_Blk_Corr", GetType(Double))
            .Columns.Add("Libby_Age", GetType(String))
            .Columns.Add("Sig_Libby_Age", GetType(Double))
            .Columns.Add("Fm_Expected", GetType(Double))
            .Columns.Add("Delta_Fm", GetType(Double))
            .Columns.Add("Sigma_Val", GetType(Double))
            .Columns("Fm_Blk_Corr").AllowDBNull = True
            .Columns("Sig_Fm_Blk_Corr").AllowDBNull = True
            If isGrpTbl Then
                .Columns("Fm_MBC").AllowDBNull = True
                .Columns("Mass_MBC").AllowDBNull = True
                .Columns("Sig_Fm_MBC").AllowDBNull = True
                .Columns("Sig_Mass_MBC").AllowDBNull = True
            End If
        End With

        With theDGV
            .DataSource = theTbl
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            .RowHeadersVisible = False
            .Anchor = AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Left
            .Columns(3).DefaultCellStyle.Format = "0"
            For iCol = 4 To 7
                .Columns(iCol).DefaultCellStyle.Format = "0.0000"
            Next
            For iCol = 8 To 9
                .Columns(iCol).DefaultCellStyle.Format = "0.00"
            Next
            For iCol = 10 To 11 'mass, mass err
                .Columns(iCol).DefaultCellStyle.Format = "0"
            Next
            For iCol = 13 To 18
                .Columns(iCol).DefaultCellStyle.Format = "0.00000"
            Next
            .Columns(19).DefaultCellStyle.Format = "0"
            .Columns(20).DefaultCellStyle.Format = "0"
            .Columns(21).DefaultCellStyle.Format = "0.00000"
            .Columns(22).DefaultCellStyle.Format = "0.00000"
            .Columns(23).DefaultCellStyle.Format = "0.000"
            If isGrpTbl Then
                .Columns(5).DefaultCellStyle.Format = "0"
                For iCol = 6 To 9
                    .Columns(iCol).DefaultCellStyle.Format = "0.0000"
                Next
                For iCol = 10 To 11
                    .Columns(iCol).DefaultCellStyle.Format = "0.00"
                Next
                For iCol = 12 To 13 'mass, mass err
                    .Columns(iCol).DefaultCellStyle.Format = "0"
                Next
                For iCol = 15 To 18
                    .Columns(iCol).DefaultCellStyle.Format = "0.00000"
                Next
                For iCol = 19 To 22
                    .Columns(iCol).DefaultCellStyle.Format = "0.0000"
                Next
                For iCol = 23 To 24
                    .Columns(iCol).DefaultCellStyle.Format = "0.00000"
                Next
                .Columns(25).DefaultCellStyle.Format = "0"
                .Columns(26).DefaultCellStyle.Format = "0"
                .Columns(27).DefaultCellStyle.Format = "0.00000"
                .Columns(28).DefaultCellStyle.Format = "0.00000"
                .Columns(29).DefaultCellStyle.Format = "0.00"
            End If
            If theTbl Is frmBlankCorr.tblBlanks Then
                .Columns(4).DefaultCellStyle.Format = "0"
                For iCol = 5 To 8
                    .Columns(iCol).DefaultCellStyle.Format = "0.0000"
                Next
                For iCol = 9 To 10
                    .Columns(iCol).DefaultCellStyle.Format = "0.00"
                Next
                For iCol = 11 To 12
                    .Columns(iCol).DefaultCellStyle.Format = "0" 'mass, mass err
                Next
                For iCol = 14 To 17
                    .Columns(iCol).DefaultCellStyle.Format = "0.00000"
                Next
                .Columns(20).DefaultCellStyle.Format = "0"
                .Columns(21).DefaultCellStyle.Format = "0"
                .Columns(22).DefaultCellStyle.Format = "0.00000"
                .Columns(23).DefaultCellStyle.Format = "0.00000"
                .Columns(24).DefaultCellStyle.Format = "0.000"

            End If
            For i = 0 To theDGV.Columns.Count - 1
                theDGV.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                theDGV.Columns(i).ReadOnly = True
            Next
            If theDGV Is frmBlankCorr.dgvBlanks Then theDGV.Columns(0).ReadOnly = False
        End With
    End Sub

    Public Function LargeBlankCorrected(Fm As Double, FmB As Double, FmS As Double) As Double
        LargeBlankCorrected = Fm
        If FmS <> 0 Then
            LargeBlankCorrected = Fm - FmB * (FmS - Fm) / FmS
        End If
    End Function

    Public Function SigLargeBlankCorrected(Fm As Double, FmB As Double, FmS As Double, SigFm As Double, SigFmB As Double) As Double
        SigLargeBlankCorrected = SigFm ^ 2 * (1 + FmB / FmS) ^ 2 + SigFmB ^ 2 * ((Fm - FmS) / FmS) ^ 2
        If SigLargeBlankCorrected > 0 Then SigLargeBlankCorrected = SigLargeBlankCorrected ^ 0.5
    End Function

    Public Function FmMassBal(FmC As Double, FmB As Double, Mass As Double, MassB As Double) As Double
        If Mass <= MassB Then Return 42 ' flag anomalous situation
        '   FmC is the large blank corrected Fm, FmB is the blank Fm, Mass is sample mass, MassB is the blank mass
        FmMassBal = FmC + (FmC - FmB) * MassB / Mass
    End Function

    Public Function SigFmMassBal(FmC As Double, FmB As Double, M As Double, Mb As Double,
                                 SigFmC As Double, SigFmB As Double, SigMass As Double, SigMassB As Double) As Double
        If M <= Mb Then Return 42 ' flag anomalous situation
        SigFmMassBal = SigFmC ^ 2 * (1 + Mb / M) ^ 2 +
                       SigMass ^ 2 * ((FmC - FmB) * Mb / M ^ 2) ^ 2 +
                       SigFmB ^ 2 * (Mb / M) ^ 2 +
                       SigMassB ^ 2 * ((FmC - FmB) / M) ^ 2
        If SigFmMassBal > 0 Then SigFmMassBal = SigFmMassBal ^ 0.5
    End Function

    Public Function FmMassBalmc(FmC As Double, FmB As Double, Mass As Double, MassB As Double) As Double
        '   FmC is the large blank corrected Fm, FmB is the blank Fm, Mass is sample mass, MassB is the blank mass
        '   This version subtracts the contaminant mass to use the mass of the unknown instead of total mass
        If Mass <= MassB Then Return 42 ' flag anomalous situation
        FmMassBalmc = FmC + (FmC - FmB) * MassB / (Mass - MassB)
    End Function

    Public Function SigFmMassBalmc(FmC As Double, FmB As Double, M As Double, Mb As Double,
                                 SigFmC As Double, SigFmB As Double, SigMass As Double, SigMassB As Double) As Double
        '   This version is the propogation when using M - Mb as sample mass
        If M <= Mb Then Return 42 ' flag anomalous situation
        SigFmMassBalmc = SigFmC ^ 2 * (M / (M - Mb)) ^ 2 +
                       SigMass ^ 2 * ((FmB - FmC) * Mb / (M - Mb) ^ 2) ^ 2 +
                       SigFmB ^ 2 * (Mb / (M - Mb)) ^ 2 +
                       SigMassB ^ 2 * ((FmC - FmB) / (M - Mb)) ^ 2
        If SigFmMassBalmc > 0 Then SigFmMassBalmc = SigFmMassBalmc ^ 0.5
    End Function
    Public Function TotErr(Fm As Double, RepErr As Double, ResErr As Double) As Double
        ' calculate total error for a target, given reported and residual error
        TotErr = Math.Sqrt(RepErr ^ 2 + (ResErr * Fm) ^ 2)
    End Function

    Private Sub AssignGroupsToTargets()
        For i = NumRuns - 1 To 0 Step -1
            TargetGroups(RunPos(i)) = GroupNums(i)
        Next
    End Sub

    Public Sub CommitBlankCorr()
        If FIRSTAUTH Then
            CommitToDatabase()
            MsgBox("Blank Corrected Data Committed To Database")
        Else
            CommitToDatabase()
            MsgBox("You are Not first authorizer" & vbCrLf * "Only uncorrected data committed To database")
        End If
    End Sub

    Public Sub ColorizeBCCompare()
        With Compare
            .Visible = True
            For i = 0 To .dgvCompare.Rows.Count - 1
                Dim npos As Integer = .dgvCompare("Pos", i).Value
                Dim thestr As String = TargetTypes(npos)
                .dgvCompare.Rows(i).DefaultCellStyle.BackColor = TargetColor(TargetTypes(npos))
                If Math.Abs(.dgvCompare("SigmaFmCorr", i).Value) > 2.5 Then
                    .dgvCompare("DelFmCorr", i).Style.BackColor = Color.LightSalmon
                    .dgvCompare("SigmaFmCorr", i).Style.BackColor = Color.LightSalmon
                ElseIf Math.Abs(.dgvCompare("SigmaFmCorr", i).Value) > 2.0 Then
                    .dgvCompare("DelFmCorr", i).Style.BackColor = Color.LightCoral
                    .dgvCompare("SigmaFmCorr", i).Style.BackColor = Color.LightCoral
                ElseIf Math.Abs(.dgvCompare("SigmaFmCorr", i).Value) > 1.5 Then
                    .dgvCompare("DelFmCorr", i).Style.BackColor = Color.LightPink
                    .dgvCompare("SigmaFmCorr", i).Style.BackColor = Color.LightPink
                End If
            Next
        End With

    End Sub

    Public Sub DeBlankCorr()
        BLANKCORRECTED = False
        tsmCommit.Visible = False
    End Sub

#End Region ' compute and display blanks and corrected results

#Region "Graphics"

    Public Sub DoRawPlot(varSel As Integer)
        PlotRaw.SelVar = varSel
        Dim OtherName As String = ""
        PlotRaw.Width = PlotRaw.zc1.Width
        Dim grplist(20) As PointPairList
        Dim ogrplist(20) As PointPairList
        'PlotRaw.cmbOther.Text = "None"
        If Not IamLoading Then                  ' don't do this on loading
            PlotRaw.HaveLegend = False          ' start out without worms
            PlotRaw.btnWorms.Visible = True
            PlotRaw.VarNum = varSel
            RawNum = -1
            OtherName = PlotRaw.cmbOther.Text
            PlotRaw.IAMUPDATING = True
            PlotRaw.cmbOther.Items.Clear()
            PlotRaw.cmbOther.Items.Add("None")
            For i = 7 To InputData.Columns.Count - 1
                PlotRaw.cmbOther.Items.Add(InputData.Columns(i).ColumnName)
            Next
            PlotRaw.cmbOther.Text = OtherName
            PlotRaw.IAMUPDATING = False
            Dim myPane As GraphPane = PlotRaw.zc1.GraphPane
            myPane.CurveList.Clear()                                 ' in case there's already a plot
            myPane.Title.Text = FileName
            myPane.YAxis.Title.Text = dgvInputData.Columns(varSel).Name
            myPane.XAxis.Title.Text = "Date/Time"
            myPane.XAxis.Type = AxisType.Date
            myPane.XAxis.Scale.Format = "MMM dd HH:mm"
            Dim stdList As New PointPairList
            Dim blkList As New PointPairList
            Dim unkList As New PointPairList
            Dim secList As New PointPairList
            Dim rstdList As New PointPairList
            Dim rblkList As New PointPairList
            Dim runkList As New PointPairList
            Dim rsecList As New PointPairList
            For i = 0 To NumRuns - 1
                If Not PlotRaw.chkExclude.Checked Or InputData(i).Item("OK") Then
                    Select Case InputData(i).Item("Typ")
                        Case "S"
                            If InputData(i).Item("OK") Then
                                stdList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            Else
                                rstdList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            End If
                        Case "B"
                            If InputData(i).Item("OK") Then
                                blkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            Else
                                rblkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            End If
                        Case "SS"
                            If InputData(i).Item("OK") Then
                                secList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            Else
                                rsecList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            End If
                        Case "U"
                            If InputData(i).Item("OK") Then
                                unkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            Else
                                runkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(varSel))
                            End If
                    End Select
                End If
            Next
            If PlotRaw.chkStds.Checked Then
                Dim stdCurve As LineItem = myPane.AddCurve("Standards", stdList, Color.Blue, SymbolType.Circle)
                stdCurve.Symbol.Fill = New Fill(Color.Blue)
                stdCurve.Symbol.Size = CSng(SymbSize)
                stdCurve.Line.IsVisible = False
                Dim rstdCurve As LineItem = myPane.AddCurve("RejStds", rstdList, Color.Blue, SymbolType.Circle)
                rstdCurve.Symbol.Size = CSng(SymbSize)
                rstdCurve.Line.IsVisible = False
                rstdCurve.Label.IsVisible = False
            End If
            If PlotRaw.chkBlanks.Checked Then
                Dim blkCurve As LineItem = myPane.AddCurve("Blanks", blkList, Color.Magenta, SymbolType.Square)
                blkCurve.Symbol.Fill = New Fill(Color.Magenta)
                blkCurve.Symbol.Size = CSng(SymbSize)
                blkCurve.Line.IsVisible = False
                Dim rblkCurve As LineItem = myPane.AddCurve("rBlanks", rblkList, Color.Magenta, SymbolType.Square)
                rblkCurve.Symbol.Size = CSng(SymbSize)
                rblkCurve.Line.IsVisible = False
                rblkCurve.Label.IsVisible = False
            End If
            If PlotRaw.chkSecs.Checked Then
                Dim secCurve As LineItem = myPane.AddCurve("Secondaries", secList, Color.Brown, SymbolType.Diamond)
                secCurve.Symbol.Fill = New Fill(Color.Brown)
                secCurve.Symbol.Size = CSng(SymbSize)
                secCurve.Line.IsVisible = False
                Dim rsecCurve As LineItem = myPane.AddCurve("rSecondaries", rsecList, Color.Brown, SymbolType.Diamond)
                rsecCurve.Symbol.Size = CSng(SymbSize)
                rsecCurve.Line.IsVisible = False
                rsecCurve.Label.IsVisible = False
            End If
            If PlotRaw.chkUnks.Checked Then
                Dim unkCurve As LineItem = myPane.AddCurve("Unknowns", unkList, Color.Black, SymbolType.Triangle)
                unkCurve.Symbol.Fill = New Fill(Color.Black)
                unkCurve.Symbol.Size = CSng(SymbSize)
                unkCurve.Line.IsVisible = False
                Dim runkCurve As LineItem = myPane.AddCurve("Unknowns", runkList, Color.Black, SymbolType.Triangle)
                runkCurve.Symbol.Size = CSng(SymbSize)
                runkCurve.Line.IsVisible = False
                runkCurve.Label.IsVisible = False
            End If
            PlotRaw.zc1.AxisChange()
            For i = 1 To NumGroups - 1
                grplist(i) = New PointPairList
                grplist(i).Clear()
                grplist(i).Add(GroupTimes(i), myPane.YAxis.Scale.Min)
                grplist(i).Add(GroupTimes(i), myPane.YAxis.Scale.Max)
                Dim grpcurve As LineItem = myPane.AddCurve("Grp" & i.ToString & "to" & (i + 1).ToString, grplist(i), Color.Black, SymbolType.None)
                If GROUPBOUNDS Then
                    grpcurve.Line.Width = 3
                Else
                    grpcurve.Line.Width = 1
                    grpcurve.Line.StepType = StepType.ForwardStep
                    grpcurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash
                    grpcurve.Line.DashOn = 4.0F
                End If
                grpcurve.Label.IsVisible = False        ' don't show in legend
            Next
            PlotRaw.zc1.Refresh()
            PlotRaw.Visible = True
        End If
        If (PlotRaw.cmbOther.Text <> "None") And (PlotRaw.cmbOther.Text <> "") Then                  ' don't do this unless a variable is selected
            Dim myPane As GraphPane = PlotRaw.zc2.GraphPane
            myPane.Legend.IsVisible = False
            myPane.CurveList.Clear()                                 ' in case there's already a plot
            myPane.Title.Text = FileName
            oVarSel = 0
            For i = 7 To InputData.Columns.Count - 1
                If PlotRaw.cmbOther.Text = InputData.Columns(i).ColumnName Then
                    oVarSel = i
                    Exit For
                End If
            Next
            myPane.YAxis.Title.Text = dgvInputData.Columns(oVarSel).Name
            myPane.XAxis.Title.Text = "Date/Time"
            myPane.XAxis.Type = AxisType.Date
            myPane.XAxis.Scale.Format = "MMM dd HH:mm"
            Dim stdList As New PointPairList
            Dim blkList As New PointPairList
            Dim unkList As New PointPairList
            Dim secList As New PointPairList
            Dim rstdList As New PointPairList
            Dim rblkList As New PointPairList
            Dim runkList As New PointPairList
            Dim rsecList As New PointPairList
            For i = 0 To NumRuns - 1
                Select Case InputData(i).Item("Typ")
                    Case "S"
                        If InputData(i).Item("OK") Then
                            stdList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        Else
                            rstdList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        End If
                    Case "B"
                        If InputData(i).Item("OK") Then
                            blkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        Else
                            rblkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        End If
                    Case "SS"
                        If InputData(i).Item("OK") Then
                            secList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        Else
                            rsecList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        End If
                    Case "U"
                        If InputData(i).Item("OK") Then
                            unkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        Else
                            runkList.Add(CDate(InputData(i).Item("RunTime")).ToOADate, InputData(i).Item(oVarSel))
                        End If
                End Select
            Next
            If PlotRaw.chkStds.Checked Then
                Dim stdCurve As LineItem = myPane.AddCurve("Standards", stdList, Color.Blue, SymbolType.Circle)
                stdCurve.Symbol.Fill = New Fill(Color.Blue)
                stdCurve.Symbol.Size = CSng(SymbSize)
                stdCurve.Line.IsVisible = False
                Dim rstdCurve As LineItem = myPane.AddCurve("RejStds", rstdList, Color.Blue, SymbolType.Circle)
                rstdCurve.Symbol.Size = CSng(SymbSize)
                rstdCurve.Line.IsVisible = False
                rstdCurve.Label.IsVisible = False
            End If
            If PlotRaw.chkBlanks.Checked Then
                Dim blkCurve As LineItem = myPane.AddCurve("Blanks", blkList, Color.Magenta, SymbolType.Square)
                blkCurve.Symbol.Fill = New Fill(Color.Magenta)
                blkCurve.Symbol.Size = CSng(SymbSize)
                blkCurve.Line.IsVisible = False
                Dim rblkCurve As LineItem = myPane.AddCurve("rBlanks", rblkList, Color.Magenta, SymbolType.Square)
                rblkCurve.Symbol.Size = CSng(SymbSize)
                rblkCurve.Line.IsVisible = False
                rblkCurve.Label.IsVisible = False
            End If
            If PlotRaw.chkSecs.Checked Then
                Dim secCurve As LineItem = myPane.AddCurve("Secondaries", secList, Color.Brown, SymbolType.Diamond)
                secCurve.Symbol.Fill = New Fill(Color.Brown)
                secCurve.Symbol.Size = CSng(SymbSize)
                secCurve.Line.IsVisible = False
                Dim rsecCurve As LineItem = myPane.AddCurve("rSecondaries", rsecList, Color.Brown, SymbolType.Diamond)
                rsecCurve.Symbol.Size = CSng(SymbSize)
                rsecCurve.Line.IsVisible = False
                rsecCurve.Label.IsVisible = False
            End If
            If PlotRaw.chkUnks.Checked Then
                Dim unkCurve As LineItem = myPane.AddCurve("Unknowns", unkList, Color.Black, SymbolType.Triangle)
                unkCurve.Symbol.Fill = New Fill(Color.Black)
                unkCurve.Symbol.Size = CSng(SymbSize)
                unkCurve.Line.IsVisible = False
                Dim runkCurve As LineItem = myPane.AddCurve("Unknowns", runkList, Color.Black, SymbolType.Triangle)
                runkCurve.Symbol.Size = CSng(SymbSize)
                runkCurve.Line.IsVisible = False
                runkCurve.Label.IsVisible = False
            End If
            PlotRaw.zc2.AxisChange()
            For i = 1 To NumGroups - 1
                ogrplist(i) = New PointPairList
                ogrplist(i).Clear()
                ogrplist(i).Add(GroupTimes(i), myPane.YAxis.Scale.Min)
                ogrplist(i).Add(GroupTimes(i), myPane.YAxis.Scale.Max)
                Dim grpcurve As LineItem = myPane.AddCurve("Grp" & i.ToString & "to" & (i + 1).ToString, ogrplist(i), Color.Black, SymbolType.None)
                If GROUPBOUNDS Then
                    grpcurve.Line.Width = 3
                Else
                    grpcurve.Line.Width = 1
                    grpcurve.Line.StepType = StepType.ForwardStep
                    grpcurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash
                    grpcurve.Line.DashOn = 4.0F
                End If
                grpcurve.Label.IsVisible = False            ' don't show in legend
            Next
            PlotRaw.zc2.Refresh()
            PlotRaw.Visible = True
        End If
    End Sub

    Public Sub PlotGroups()
        Dim stdList As New PointPairList
        Dim blkList As New PointPairList
        Dim unkList As New PointPairList
        Dim secList As New PointPairList
        Dim xMin As Double
        Dim xMax As Double
        For i = 0 To InputData.Rows.Count - 1
            Dim x As Double = CDate(InputData(i).Item("RunTime")).ToOADate
            If i = 0 Then xMin = x
            If i = InputData.Rows.Count - 1 Then xMax = x
            Dim y As Double = InputData(i).Item("Pos")
            Select Case InputData.Rows(i).Item("Typ")
                Case "S"
                    stdList.Add(x, y)
                Case "B"
                    blkList.Add(x, y)
                Case "U"
                    unkList.Add(x, y)
                Case "SS"
                    secList.Add(x, y)
            End Select
        Next
        With GroupPlot
            Dim mypane As GraphPane = .zc1.GraphPane
            Dim stdCurve As LineItem = mypane.AddCurve("Standards", stdList, Color.Red, SymbolType.Diamond)
            stdCurve.Symbol.Size = 3
            stdCurve.Line.IsVisible = False
            Dim blkCurve As LineItem = mypane.AddCurve("Blanks", blkList, Color.Blue, SymbolType.Diamond)
            blkCurve.Symbol.Size = 3
            blkCurve.Line.IsVisible = False
            Dim unkCurve As LineItem = mypane.AddCurve("Unknowns", unkList, Color.Black, SymbolType.Diamond)
            unkCurve.Symbol.Size = 3
            unkCurve.Line.IsVisible = False
            Dim secCurve As LineItem = mypane.AddCurve("Secondaries", secList, Color.Orange, SymbolType.Diamond)
            secCurve.Symbol.Size = 3
            secCurve.Line.IsVisible = False
            mypane.Title.IsVisible = False
            mypane.XAxis.Type = AxisType.Date
            mypane.XAxis.Scale.Max = xMax
            mypane.XAxis.Scale.Min = xMin
            .zc1.Refresh()
            .zc1.AxisChange()
            .Visible = True
        End With
    End Sub

    Public Sub PlotPropProp()
        If Trim(PropPropPlot.cmbXvar.Text) <> "" And Trim(PropPropPlot.cmbYvar.Text) <> "" Then
            Dim varSel As String = PropPropPlot.cmbYvar.Text
            Dim xvar As String = PropPropPlot.cmbXvar.Text
            Dim myPane As GraphPane = PropPropPlot.zc1.GraphPane
            myPane.CurveList.Clear()                                 ' in case there's already a plot
            myPane.Title.Text = FileName
            myPane.YAxis.Title.Text = varSel
            myPane.XAxis.Title.Text = xvar
            Dim stdList As New PointPairList
            Dim blkList As New PointPairList
            Dim unkList As New PointPairList
            Dim secList As New PointPairList
            Dim rstdList As New PointPairList
            Dim rblkList As New PointPairList
            Dim runkList As New PointPairList
            Dim rsecList As New PointPairList
            For i = 0 To NumRuns - 1
                If Not PropPropPlot.chkExclude.Checked Or InputData(i).Item("OK") Then
                    Select Case InputData(i).Item("Typ")
                        Case "S"
                            If InputData(i).Item("OK") Then
                                stdList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            Else
                                rstdList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            End If
                        Case "B"
                            If InputData(i).Item("OK") Then
                                blkList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            Else
                                rblkList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            End If
                        Case "SS"
                            If InputData(i).Item("OK") Then
                                secList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            Else
                                rsecList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            End If
                        Case "U"
                            If InputData(i).Item("OK") Then
                                unkList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            Else
                                runkList.Add(InputData(i).Item(xvar), InputData(i).Item(varSel))
                            End If
                    End Select
                End If
            Next
            If PropPropPlot.chkStds.Checked Then
                Dim stdCurve As LineItem = myPane.AddCurve("Standards", stdList, Color.Blue, SymbolType.Circle)
                stdCurve.Symbol.Fill = New Fill(Color.Blue)
                stdCurve.Symbol.Size = CSng(SymbSize)
                stdCurve.Line.IsVisible = False
                Dim rstdCurve As LineItem = myPane.AddCurve("rStandards", rstdList, Color.Blue, SymbolType.Circle)
                rstdCurve.Symbol.Size = CSng(SymbSize)
                rstdCurve.Line.IsVisible = False
                rstdCurve.Label.IsVisible = False
            End If
            If PropPropPlot.chkBlanks.Checked Then
                Dim blkCurve As LineItem = myPane.AddCurve("Blanks", blkList, Color.Cyan, SymbolType.Square)
                blkCurve.Symbol.Fill = New Fill(Color.Cyan)
                blkCurve.Symbol.Size = CSng(SymbSize)
                blkCurve.Line.IsVisible = False
                Dim rblkCurve As LineItem = myPane.AddCurve("rBlanks", rblkList, Color.Cyan, SymbolType.Square)
                rblkCurve.Symbol.Size = CSng(SymbSize)
                rblkCurve.Line.IsVisible = False
                rblkCurve.Label.IsVisible = False
            End If
            If PropPropPlot.chkSecs.Checked Then
                Dim secCurve As LineItem = myPane.AddCurve("Secondaries", secList, Color.Brown, SymbolType.Diamond)
                secCurve.Symbol.Fill = New Fill(Color.Brown)
                secCurve.Symbol.Size = CSng(SymbSize)
                secCurve.Line.IsVisible = False
                Dim rsecCurve As LineItem = myPane.AddCurve("rSecondaries", rsecList, Color.Brown, SymbolType.Diamond)
                rsecCurve.Symbol.Size = CSng(SymbSize)
                rsecCurve.Line.IsVisible = False
                rsecCurve.Label.IsVisible = False
            End If
            If PropPropPlot.chkUnks.Checked Then
                Dim unkCurve As LineItem = myPane.AddCurve("Unknowns", unkList, Color.Black, SymbolType.Triangle)
                unkCurve.Symbol.Fill = New Fill(Color.Black)
                unkCurve.Symbol.Size = CSng(SymbSize)
                unkCurve.Line.IsVisible = False
                Dim runkCurve As LineItem = myPane.AddCurve("rUnknowns", runkList, Color.Black, SymbolType.Triangle)
                runkCurve.Symbol.Size = CSng(SymbSize)
                runkCurve.Line.IsVisible = False
                runkCurve.Label.IsVisible = False
            End If
            PropPropPlot.zc1.AxisChange()
            PropPropPlot.zc1.Refresh()
            PropPropPlot.Visible = True
        End If

    End Sub

    Public Sub PlotRuns()
        With Worms
            .btnPrev.Visible = True
            .btnNext.Visible = True
            .btnPrev2.Visible = True
            .btnNext2.Visible = True
            .chkOverlay.Visible = True
            .rdbBlk.Visible = False
            .rdbStd.Visible = False
            .cmbGoTo.Visible = True
            .btnPlotBlks.Visible = True
            .btnPlotStds.Visible = True
            .Visible = True
            .BringToFront()
        End With
        PlotWorms()
    End Sub

    Public Sub PlotWorms()
        Dim WormNum As Integer = 0
        Dim ybar As Double = 0.0
        Dim ysig As Double = 0.0
        Dim numy As Integer = 0
        Dim sumerr As Double = 0.0
        Dim grplist(MAXGROUPS) As PointPairList            ' group boundary marker
        Dim ogrplist(MAXGROUPS) As PointPairList           ' group boundary marker on other plot
        Dim myPane As GraphPane = Worms.zc1.GraphPane
        AddHandler myPane.XAxis.ScaleFormatEvent, AddressOf XScaleDateFormatEvent
        myPane.GraphObjList.Clear()
        Dim oPane As GraphPane = Worms.zc2.GraphPane
        AddHandler oPane.XAxis.ScaleFormatEvent, AddressOf XScaleDateFormatEvent
        Worms.Legend.Rows.Clear()
        myPane.CurveList.Clear()                                 ' in case there's already a plot
        myPane.YAxis.Title.Text = "Norm Ratio"
        myPane.YAxis.Title.FontSpec.Size = 36
        myPane.IsFontsScaled = False
        If Worms.rdbByTime.Checked Then
            myPane.XAxis.Title.Text = "Date/Time"
            myPane.XAxis.Type = AxisType.Date
            myPane.XAxis.Scale.Format = "d/HH:mm"
            myPane.XAxis.Scale.MinorUnit = DateUnit.Hour
            myPane.XAxis.Scale.MinorStep = 1
            myPane.XAxis.Scale.MajorUnit = DateUnit.Hour
            myPane.XAxis.Scale.MajorStep = 1
            myPane.XAxis.Scale.FontSpec.Angle = 90
        Else
            myPane.XAxis.Title.Text = "Measurement Number"
            myPane.XAxis.Type = AxisType.Linear
            myPane.XAxis.Scale.Format = "0"
            myPane.XAxis.Scale.MajorStep = 1
        End If
        myPane.Legend.IsVisible = False
        oPane.Legend.IsVisible = False
        If (Worms.cmbOther.Text <> "None") And (Trim(Worms.cmbOther.Text) <> "") Then
            oPane.CurveList.Clear()                                 ' in case there's already a plot
            oPane.Title.IsVisible = False
            oPane.YAxis.Title.Text = Worms.cmbOther.Text
            If Worms.rdbByTime.Checked Then
                oPane.XAxis.Title.Text = "Date/Time"
                oPane.XAxis.Type = AxisType.Date
                oPane.XAxis.Scale.Format = "d/HH:mm"
                oPane.XAxis.Scale.MinorUnit = DateUnit.Hour
                oPane.XAxis.Scale.MinorStep = 1
                oPane.XAxis.Scale.MajorUnit = DateUnit.Hour
                oPane.XAxis.Scale.MajorStep = 1
                oPane.XAxis.Scale.FontSpec.Angle = 90
            Else
                oPane.XAxis.Type = AxisType.Linear
                oPane.XAxis.Title.Text = "Measurement Number"
                oPane.XAxis.Scale.Format = "0"
                oPane.XAxis.Scale.MajorStep = 1
            End If
        End If
        Dim xmin As Double = 1.0E+18
        Dim xmax As Double = -1
        Dim ymin As Double = 100
        Dim ymax As Double = -1
        Dim oymin As Double = ymin
        Dim oymax As Double = ymax
        For iplot = 0 To NumPlots - 1
            Dim i As Integer = PlotList(iplot)
            Dim bars As New PointPairList           ' the error bars
            Dim List As New PointPairList           ' all runs
            Dim gList As New PointPairList          ' just the good ones
            Dim olist As New PointPairList
            Dim oglist As New PointPairList
            If NumPlots = 1 Then AccumulateResults(PlotList(iplot))
            For j = 1 To RunKeys(i, 0)
                Dim k As Integer = RunKeys(i, j)
                If Not Worms.chkExclude.Checked Or InputData(k).Item("OK") Then
                    Dim x As Double = 0
                    If Worms.rdbByTime.Checked Then
                        x = CDate(InputData(k).Item("RunTime")).ToOADate
                    Else
                        x = InputData(k).Item("Mst")
                    End If
                    If x < xmin Then xmin = x
                    If x > xmax Then xmax = x
                    Dim y As Double = NormRat(k)
                    Dim ypm As Double = NormRatErr(k)
                    If y - ypm < ymin Then ymin = y - ypm
                    If y + ypm > ymax Then ymax = y + ypm
                    List.Add(x, y)
                    If InputData(k).Item("OK") Then
                        gList.Add(x, y)
                        ybar += y
                        ysig += y ^ 2
                        numy += 1
                        sumerr = ypm
                    End If
                    bars.Add(x, y - ypm, y + ypm)
                    If NumVarPlt <> "None" Then
                        Dim zz As Double = InputData(k).Item(NumVarPlt) * NumVarMult
                        Dim lbl As New TextObj(zz.ToString("0.0"), x, y + 0.5 * ypm)
                        lbl.FontSpec.Size = CSng(NumVarFnt)
                        lbl.FontSpec.Border.IsVisible = False
                        myPane.GraphObjList.Add(lbl)
                    End If
                    If (Worms.cmbOther.Text <> "None") And (Trim(Worms.cmbOther.Text) <> "") Then
                        Dim theName As String = Trim(Worms.cmbOther.Text)
                        Dim theData As Double = 0.0
                        Select Case theName
                            Case "NormRat"
                                theData = NormRat(k)
                            Case "IntErr"
                                theData = NormRatErr(k)
                            Case "NormD13"
                                theData = 1000 * (C13C12(k) - 1)
                            Case "SigD13"
                                theData = 1000 * SigC13C12(k)
                            Case Else
                                theData = InputData(k).Item(theName)
                        End Select
                        Dim oy As Double = theData
                        If oy < oymin Then oymin = oy
                        If oy > oymax Then oymax = oy
                        olist.Add(x, oy)
                        If InputData(k).Item("OK") Then
                            oglist.Add(x, oy)
                        End If
                    End If

                End If
            Next
            Dim ColNum As Integer = WormNum - 10 * (WormNum \ 10)
            With Worms
                Dim newrow As DataRow = .Legend.NewRow
                newrow("Pos") = i
                newrow("SampleName") = TargetNames(i)
                .Legend.Rows.Add(newrow)
                .dgvLgndWorms.Rows(WormNum).DefaultCellStyle.ForeColor = PlotCols(ColNum)
            End With
            Dim dcurve As LineItem = myPane.AddCurve("All" & i.ToString, List, PlotCols(ColNum), SymbolType.Circle)
            dcurve.Symbol.Size = CSng(SymbSize)
            Dim gcurve As LineItem = myPane.AddCurve("Good" & i.ToString, gList, PlotCols(ColNum), SymbolType.Circle)
            gcurve.Symbol.Size = CSng(SymbSize)
            Dim ecurve As ErrorBarItem = myPane.AddErrorBar("PM" & i.ToString, bars, PlotCols(ColNum))
            gcurve.Symbol.Fill = New Fill(PlotCols(ColNum))
            gcurve.Line.IsVisible = False
            If (Worms.cmbOther.Text <> "None") And (Trim(Worms.cmbOther.Text) <> "") Then
                Dim ocurve As LineItem = oPane.AddCurve("OAll" & i.ToString, olist, PlotCols(ColNum), SymbolType.Square)
                ocurve.Symbol.Size = CSng(SymbSize)
                Dim ogcurve As LineItem = oPane.AddCurve("OGood" & i.ToString, oglist, PlotCols(ColNum), SymbolType.Square)
                ogcurve.Symbol.Size = CSng(SymbSize)
                ogcurve.Symbol.Fill = New Fill(PlotCols(ColNum))
                ogcurve.Line.IsVisible = False
            End If
            WormNum += 1
        Next
        Dim dely As Double = 0.1 * (ymax - ymin)
        ymin = ymin - dely
        ymax = ymax + dely
        myPane.YAxis.Scale.Min = ymin
        myPane.YAxis.Scale.Max = ymax
        Dim delx As Double = 0.1 * (xmax - xmin)
        xmin = xmin - delx
        xmax = xmax + delx
        myPane.XAxis.Scale.Min = xmin
        myPane.XAxis.Scale.Max = xmax
        If numy > 0 Then
            ybar = ybar / numy
            If numy > 1 Then
                ysig = ((ysig - numy * ybar ^ 2) / (numy - 1)) ^ 0.5
            Else
                ysig = sumerr
            End If
            Dim mp As New PointPairList
            Dim mm As New PointPairList
            Dim mean As New PointPairList
            mp.Add(xmin, ybar + ysig)
            mp.Add(xmax, ybar + ysig)
            Dim mpcrv As LineItem = myPane.AddCurve("mp", mp, Color.Gray, SymbolType.None)
            mpcrv.Line.Width = 2
            mm.Add(xmin, ybar - ysig)
            mm.Add(xmax, ybar - ysig)
            Dim mmcrv As LineItem = myPane.AddCurve("mm", mm, Color.Gray, SymbolType.None)
            mmcrv.Line.Width = 2
            mean.Add(xmin, ybar)
            mean.Add(xmax, ybar)
            Dim meancrv As LineItem = myPane.AddCurve("mean", mean, Color.Black, SymbolType.None)
            meancrv.Line.Width = 3
            If NumStdDev = 2 Then
                Dim mp2 As New PointPairList
                Dim mm2 As New PointPairList
                mp2.Add(xmin, ybar + 2 * ysig)
                mp2.Add(xmax, ybar + 2 * ysig)
                Dim mp2crv As LineItem = myPane.AddCurve("mp2", mp2, Color.Gray, SymbolType.None)
                mm2.Add(xmin, ybar - 2 * ysig)
                mm2.Add(xmax, ybar - 2 * ysig)
                Dim mm2crv As LineItem = myPane.AddCurve("mm2", mm2, Color.Gray, SymbolType.None)
            End If
            Dim SumCnts As Integer = 0
            If NumPlots = 1 Then        ' only do the following if there's only one target plotted
                If numy > 2 And numy < 61 Then
                    Dim pp As New PointPairList
                    Dim ypp As Double = ybar + Peirce(numy - 2, 1) * ysig
                    Dim ypm As Double = ybar - Peirce(numy - 2, 1) * ysig
                    Dim xleft As Double = xmin + 0.03 * (xmax - xmin)
                    pp.Add(xleft, ypp)
                    pp.Add(xmax, ypp)
                    Dim ppcrv As LineItem = myPane.AddCurve("pp", pp, Color.Red, SymbolType.None)
                    ppcrv.Line.Style = Drawing2D.DashStyle.Dash
                    Dim pplbl As New TextObj("Peirce=+" & Peirce(numy - 2, 1).ToString("0.00"), xleft, ypp)
                    pplbl.FontSpec.Size = 12
                    pplbl.FontSpec.FontColor = Color.Red
                    pplbl.FontSpec.Border.IsVisible = False
                    myPane.GraphObjList.Add(pplbl)
                    Dim pm As New PointPairList
                    pm.Add(xleft, ypm)
                    pm.Add(xmax, ypm)
                    Dim pmcrv As LineItem = myPane.AddCurve("pm", pm, Color.Red, SymbolType.None)
                    pmcrv.Line.Style = Drawing2D.DashStyle.Dash
                    Dim pmlbl As New TextObj("Peirce=-" & Peirce(numy - 2, 1).ToString("0.00"), xleft, ypm)
                    pmlbl.FontSpec.Size = 12
                    pmlbl.FontSpec.FontColor = Color.Red
                    pmlbl.FontSpec.Border.IsVisible = False
                    myPane.GraphObjList.Add(pmlbl)
                End If
                myPane.Title.Text = "Pos " & PlotList(0).ToString & ": " & TargetNames(PlotList(0)) & "       "
                Dim i As Integer = PlotList(0)
                For j = 1 To RunKeys(i, 0)          ' now find and flag any errant points as well as compute internal error
                    Dim k As Integer = RunKeys(i, j)        ' point to specific run number
                    If InputData(k).Item("OK") Then SumCnts += InputData(k).Item("CntTotGT") ' for internal error
                    Dim Del As Double = Math.Abs(NormRat(k) - ybar) / NormRatErr(k)     ' relative deviation from mean value
                    If ((j = 1) And (Del > 2.0)) Or ((j > 1) And (Del > 3.0)) Then      ' this is awkward but allows a different criterion for the first point
                        Dim iflg As New PointPairList
                        iflg.Clear()
                        Dim x As Double = CDate(InputData(k).Item("RunTime")).ToOADate
                        If Not Worms.rdbByTime.Checked Then x = CDbl(InputData(k).Item("Mst"))
                        iflg.Add(x, ybar)
                        iflg.Add(x, NormRat(k))
                        Dim iflagcrv As LineItem = myPane.AddCurve("iflg", iflg, Color.Red, SymbolType.None)
                        iflagcrv.Line.Style = Drawing2D.DashStyle.Dash
                        iflagcrv.Line.Width = 2
                        Dim lbl As New TextObj(Del.ToString("0.0"), x, ybar)
                        lbl.FontSpec.Size = 12
                        lbl.FontSpec.FontColor = Color.Red
                        lbl.FontSpec.Border.IsVisible = False
                        myPane.GraphObjList.Add(lbl)
                    End If
                Next
            Else
                myPane.Title.Text = ""
            End If
            myPane.Title.Text &= "Mean = " & ybar.ToString(dFnt(NumResFigs - 2)) & " +- " _
                    & (ysig / numy ^ 0.5).ToString(dFnt(NumResFigs - 2)) & "  (StdDev = " &
                    ysig.ToString(dFnt(NumResFigs - 3)) & "  N = " & numy.ToString & " )"
            If SumCnts > 0 Then
                myPane.Title.Text &= " (IntErr = " & IntErr(PlotList(0)).ToString(dFnt(NumResFigs - 2)) & ")"
            End If
            myPane.Title.FontSpec.Size = 16
        Else
            myPane.Title.Text = "No meaningful mean, no points selected"
        End If
        Worms.zc1.AxisChange()
        If Worms.rdbByTime.Checked Then
            For i = 1 To NumGroups - 1
                If (GroupTimes(i) <= myPane.XAxis.Scale.Max) And (GroupTimes(i) >= myPane.XAxis.Scale.Min) Then
                    grplist(i) = New PointPairList
                    grplist(i).Clear()
                    grplist(i).Add(GroupTimes(i), myPane.YAxis.Scale.Min)
                    grplist(i).Add(GroupTimes(i), myPane.YAxis.Scale.Max)
                    Dim grpcurve As LineItem = myPane.AddCurve("Grp" & i.ToString & "to" & (i + 1).ToString, grplist(i), Color.Black, SymbolType.None)
                    If GROUPBOUNDS Then
                        grpcurve.Line.Width = 3
                    Else
                        grpcurve.Line.Width = 1
                        grpcurve.Line.StepType = StepType.ForwardStep
                        grpcurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash
                        grpcurve.Line.DashOn = 4.0F
                    End If
                End If
            Next
        End If
        Worms.zc1.Refresh()
        If (Worms.cmbOther.Text <> "None") And (Trim(Worms.cmbOther.Text) <> "") Then
            Dim odely As Double = 0.1 * (oymax - oymin)
            oymin -= odely
            oymax += odely
            With oPane
                .YAxis.Scale.Min = oymin
                .YAxis.Scale.Max = oymax
                .XAxis.Scale.Min = xmin
                .XAxis.Scale.Max = xmax
            End With
            Worms.zc2.AxisChange()
            If Worms.rdbByTime.Checked Then
                For i = 1 To NumGroups - 1
                    If (GroupTimes(i) <= myPane.XAxis.Scale.Max) And (GroupTimes(i) >= myPane.XAxis.Scale.Min) Then
                        ogrplist(i) = New PointPairList
                        ogrplist(i).Clear()
                        ogrplist(i).Add(GroupTimes(i), oPane.YAxis.Scale.Min)
                        ogrplist(i).Add(GroupTimes(i), oPane.YAxis.Scale.Max)
                        Dim grpcurve As LineItem = oPane.AddCurve("Grp" & i.ToString & "to" & (i + 1).ToString, ogrplist(i), Color.Black, SymbolType.None)
                        If GROUPBOUNDS Then
                            grpcurve.Line.Width = 3
                        Else
                            grpcurve.Line.Width = 1
                            grpcurve.Line.StepType = StepType.ForwardStep
                            grpcurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash
                            grpcurve.Line.DashOn = 4.0F
                        End If
                    End If
                Next
            End If
            Worms.zc2.Refresh()
        End If
        Worms.dgvLgndWorms.ClearSelection()
        FullReSizeDGV(Worms.dgvLgndWorms, 5)
        Worms.Visible = True
        'Worms.BringToFront()
        'Worms.Focus()
    End Sub

    Public Sub RejectRange(xStart As Double, Xfinish As Double)
        For i = 0 To InputData.Rows.Count - 1           ' rejects runs between two times
            If RunTimes(i) > xStart And RunTimes(i) < Xfinish Then InputData(i).Item("OK") = False
        Next
    End Sub

    Public Sub AcceptRange(xStart As Double, Xfinish As Double)
        For i = 0 To InputData.Rows.Count - 1           ' accepts runs between two times
            If RunTimes(i) > xStart And RunTimes(i) < Xfinish Then InputData(i).Item("OK") = True
        Next
    End Sub

    Public Sub PlotDelC13s()        ' compares the del13C between AMS and IRMS
        With frmC13compare
            NumdC13Pos = 0
            .Text = "SNICSer V" & VERSION.ToString("0.00")
            Dim myPane As GraphPane = .zc1.GraphPane
            myPane.Title.Text = "AMS vs IRMS dC13 Comparison for " & WheelName
            myPane.Legend.IsVisible = False
            myPane.GraphObjList.Clear()
            myPane.CurveList.Clear()
            myPane.YAxis.Title.Text = "AMS Del13C"
            myPane.XAxis.Title.Text = "IRMS Del13C"
            Dim List As New PointPairList
            Dim Bars As New PointPairList
            Dim theMin As Double = 1000     ' default plot minimum
            Dim theMax As Double = -1000    ' default plot maximum
            For i = 0 To TargetData.Rows.Count - 1
                If Not TargetData(i).Item("NP") Then        ' don't plot non-performers!
                    If (Math.Abs(TargetData(i).Item("DelC13")) < 500) And (Math.Abs(TargetData(i).Item("SigC13")) < 100) And (TargetData(i).Item("N") > 0) Then
                        If TargetData(i).Item("MSdC13") > -1000 Then        ' and don't plot non-existent data
                            IRMSdC13Pos(NumdC13Pos) = TargetData(i).Item("Pos")
                            NumdC13Pos += 1
                            List.Add(TargetData(i).Item("MSdC13"), TargetData(i).Item("DelC13"))
                            Bars.Add(TargetData(i).Item("MSdC13"), TargetData(i).Item("DelC13") - TargetData(i).Item("SigC13"), TargetData(i).Item("DelC13") + TargetData(i).Item("SigC13"))
                            If TargetData(i).Item("MSdC13") < theMin Then theMin = TargetData(i).Item("MSdC13")
                            If TargetData(i).Item("MSdC13") > theMax Then theMax = TargetData(i).Item("MSdC13")
                            If TargetData(i).Item("DelC13") < theMin Then theMin = TargetData(i).Item("DelC13")
                            If TargetData(i).Item("DelC13") > theMax Then theMax = TargetData(i).Item("DelC13")
                        End If
                    End If
                End If
            Next
            Dim RefLIst As New PointPairList
            RefLIst.Add(theMin, theMin)
            RefLIst.Add(theMax, theMax)
            Dim Curve As LineItem = myPane.AddCurve("Pts", List, Color.Black)
            Dim RefCurve As LineItem = myPane.AddCurve("Ref", RefLIst, Color.Blue)
            Dim eCurve As ErrorBarItem = myPane.AddErrorBar("Sig", Bars, Color.Black)
            Curve.Line.IsVisible = False
            Curve.Symbol.Type = SymbolType.Circle
            Curve.Symbol.Size = CInt(SymbSize * 0.75)
            Curve.Symbol.Fill.Color = Color.Cyan
            Curve.Symbol.Fill.IsVisible = True
            RefCurve.Line.Width = 2
            RefCurve.Symbol.Type = SymbolType.None
            .zc1.AxisChange()
            .zc1.Refresh()
            .Visible = True
        End With
    End Sub        ' compares the del13C between AMS and IRMS

    Private Sub AMSVsIRMSDC13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AMSVsIRMSDC13ToolStripMenuItem.Click
        IamBatching = True
        chkStandards.Checked = True     ' just showing standards
        chkBlanks.Checked = True       ' not blanks
        chkSecondaries.Checked = True      ' and not secondaries
        IamBatching = False
        chkUnknowns.Checked = True     '  and not unknowns
        PlotDelC13s()
    End Sub

    Public Function XScaleDateFormatEvent(ByVal pane As GraphPane, ByVal xaxis As Axis, ByVal val As Double, ByVal index As Int32) As String
        If xaxis.Scale.Type = AxisType.Date Then
            Dim theDate As DateTime = DateTime.FromOADate(val)
            If (Math.Abs(CInt(val) - val) < 0.01) Then       ' even day number, must be midnight
                Return theDate.ToString("MMM dd")
            Else
                Return theDate.ToString("HH") & "h"
            End If
        Else
            Return val.ToString("0")
        End If
    End Function

    Private Sub PlotGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlotGroupsToolStripMenuItem.Click
        PlotGroups()
    End Sub


#End Region ' display and manage plots

#Region "Database Access"

    Public Sub FindAllWheels()
        CFAMS.Clear()
        USAMS.Clear()
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT DISTINCT wheel_id FROM dbo.wheel_pos WHERE wheel_id LIKE 'USAMS%' OR wheel_id like 'CFAMS%' ORDER BY wheel_id"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        Dim whlnm As String = rdr.GetString(0)
                        If whlnm.Substring(0, 5) = "CFAMS" Then
                            CFAMS.Add(New WheelID(whlnm))
                        ElseIf whlnm.Substring(0, 5) = "USAMS" Then
                            USAMS.Add(New WheelID(whlnm))
                        End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error reading wheel information when building wheel browser" & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        Using con As New SqlConnection
            Dim theName As String = ""
            Try
                Dim theCmd As String = "SELECT DISTINCT wheel, analyst1, analyst2, date_1, date_2, norm_method, norm_method_2, ro FROM dbo.snics_results" & TTE & " ORDER BY wheel"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        theName = rdr.GetString(0)
                        If theName.Substring(0, 5) = "CFAMS" Then
                            For i = 0 To CFAMS.Count - 1
                                If CFAMS(i).Name = theName Then
                                    If Not rdr.IsDBNull(1) AndAlso rdr.GetString(1) <> "" Then
                                        CFAMS(i).Analyzed = 1
                                        CFAMS(i).FirstAuthName = rdr.GetString(1)
                                        If Not rdr.IsDBNull(3) Then CFAMS(i).FirstAuthDate = rdr.GetDateTime(3)
                                        If Not rdr.IsDBNull(5) Then CFAMS(i).Method1 = rdr.GetString(5)
                                    End If
                                    If Not rdr.IsDBNull(2) AndAlso rdr.GetString(2) <> "" Then
                                        CFAMS(i).Analyzed = 2
                                        CFAMS(i).SecondAuthName = rdr.GetString(2)
                                        If Not rdr.IsDBNull(4) Then CFAMS(i).SecondAuthDate = rdr.GetDateTime(4)
                                        If Not rdr.IsDBNull(6) Then CFAMS(i).Method2 = rdr.GetString(6)
                                    End If
                                    If Not rdr.IsDBNull(7) AndAlso rdr.GetByte(7) = 1 Then
                                        CFAMS(i).IsReadOnly = True
                                    End If
                                    Exit For
                                End If
                            Next
                        Else
                            For i = 0 To USAMS.Count - 1
                                If USAMS(i).Name = theName Then
                                    If Not rdr.IsDBNull(1) AndAlso rdr.GetString(1) <> "" Then
                                        USAMS(i).Analyzed = 1
                                        USAMS(i).FirstAuthName = rdr.GetString(1)
                                        If Not rdr.IsDBNull(3) Then USAMS(i).FirstAuthDate = rdr.GetDateTime(3)
                                        If Not rdr.IsDBNull(5) Then USAMS(i).Method1 = rdr.GetString(5)
                                    End If
                                    If Not rdr.IsDBNull(2) AndAlso rdr.GetString(2) <> "" Then
                                        USAMS(i).Analyzed = 2
                                        USAMS(i).SecondAuthName = rdr.GetString(2)
                                        If Not rdr.IsDBNull(4) Then USAMS(i).SecondAuthDate = rdr.GetDateTime(4)
                                        If Not rdr.IsDBNull(6) Then USAMS(i).Method2 = rdr.GetString(6)
                                    End If
                                    If Not rdr.IsDBNull(7) AndAlso rdr.GetByte(7) = 1 Then USAMS(i).IsReadOnly = True
                                    Exit For
                                End If
                            Next
                        End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error reading wheel analyst information when building wheel browser" & vbCrLf & theName & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        SetupWheelBrowser()
    End Sub

    Public Sub DoFillInC13Table()       ' this is done automatically when first loading a wheel from file
        If WheelName <> "" Then
            Using con As New SqlConnection
                Try
                    Dim theCmd As String = "EXEC dbo.sp_fill_in_dc13_table '" & WheelName & "';"
                    con.ConnectionString = ConString
                    con.Open()
                    Dim com As IDbCommand = con.CreateCommand
                    com.CommandType = CommandType.Text
                    com.CommandText = theCmd
                    com.ExecuteNonQuery()
                Catch ex As Exception
                    'MsgBox("Error populating dc13 table" & vbCrLf & WheelName & vbCrLf & ex.Message)
                End Try
                con.Close()
            End Using
        End If
    End Sub

    Public Sub FillInC13Table()
        If WheelName <> "" Then
            Using con As New SqlConnection
                Try
                    Dim theCmd As String = "EXEC dbo.sp_fill_in_dc13_table '" & WheelName & "';"
                    con.ConnectionString = ConString
                    con.Open()
                    Dim com As IDbCommand = con.CreateCommand
                    com.CommandType = CommandType.Text
                    com.CommandText = theCmd
                    com.ExecuteNonQuery()
                    MsgBox("You will have to reload the wheel for this to take effect")
                Catch ex As Exception
                    MsgBox("C13 table not updated" & vbCrLf & ex.Message)
                End Try
                con.Close()
            End Using
        End If
        tsmFillInC13Table.Visible = False
    End Sub

    Public Sub GetPeirceValues()
        For i = 0 To 59
            For j = 0 To 9
                Peirce(i, j) = 0
            Next
        Next
        Dim Num As Integer = 0
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT n, r1, r2, r3, r4, r5, r6, r7, r8, r9 FROM dbo.Peirce ORDER BY n;"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        Num += 1
                        For i = 1 To 9
                            Peirce(Num, i) = rdr.GetDecimal(i)
                        Next
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error getting Peirce Lookup table" & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
    End Sub

    Public Sub GetWheelInfo(whlName As String)
        tspNukeDatabase.Visible = False
        Dim wpos As Integer = -1
        For i = 0 To Tp_Num.Length - 1
            Tp_Num(i) = -1
            Rec_Num(i) = -1
        Next
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT wheel_position, dbo.wheel_pos.tp_num, rec_num " _
                    & "FROM dbo.wheel_pos INNER JOIN dbo.target ON dbo.wheel_pos.tp_num = dbo.target.tp_num " _
                    & "WHERE wheel_id = '" & whlName & "' ORDER BY wheel_position;"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                NumTargets = 0
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        wpos = rdr.GetByte(0)
                        If TargetIsPresent(wpos) Then      ' do only if Target is present
                            Tp_Num(wpos) = rdr.GetInt32(1)
                            If Not rdr.IsDBNull(2) Then
                                Rec_Num(wpos) = rdr.GetInt32(2)
                            Else
                                Rec_Num(wpos) = 0
                            End If
                            NumTargets += 1
                        End If
                    End While
                    If NumTargets = 0 Then MsgBox("Cannot find " & whlName & " in database")
                End Using
            Catch ex As Exception
                MsgBox("Pos 1" & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        'MsgBox(NumTargets, , "GetWheelInfo") 'works OK here
        For i = 0 To NumRuns - 1
            TP_Nums(i) = Tp_Num(InputData.Rows(i).Item("Pos"))
        Next
        Dim nEnt As Integer = 0
        Dim NumC13Ents As Integer = 0
        Using con As New SqlConnection
            Try
                'MsgBox(theCmd)
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                Dim MissMass As String = ""
                For ipos = 0 To MAXTARGETS
                    If TargetIsPresent(ipos) Then      ' do only if Target is present

                        Dim theCmd As String = "SELECT total_umols_co2, graphite_umols_co2, fm_blank, " _
                                         & "fm_blank_err, fm_cont, fm_cont_err, mass_cont, " _
                                     & "mass_cont_err, dc13, added_var, sig_tot_umols " _
                                     & "FROM dbo.dc13" & TTE & " WHERE tp_num = " & Tp_Num(ipos).ToString & ";"
                        com.CommandText = theCmd
                        Using rdr As IDataReader = com.ExecuteReader

                            While rdr.Read
                                NumC13Ents += 1         ' increment count of entries in dC13 table
                                If Not rdr.IsDBNull(0) Then
                                    TotalMass(ipos) = 12.015 * rdr.GetDouble(0)
                                Else
                                    TotalMass(ipos) = 0
                                    If (Rec_Num(ipos) <> 32491) And (Rec_Num(ipos) <> 148820) Then
                                        MissMass = MissMass & ipos.ToString & " "
                                    End If
                                End If
                                If Not rdr.IsDBNull(1) Then
                                    TargetMass(ipos) = 12.015 * rdr.GetDouble(1)
                                Else
                                    TargetMass(ipos) = TotalMass(ipos)
                                End If
                                If Not rdr.IsDBNull(2) Then
                                    MBCLgFm(ipos) = rdr.GetDouble(2)
                                Else
                                    MBCLgFm(ipos) = 0.0
                                End If
                                If Not rdr.IsDBNull(3) Then
                                    MBCLgFmSig(ipos) = rdr.GetDouble(3)
                                Else
                                    MBCLgFmSig(ipos) = 0.0
                                End If
                                If Not rdr.IsDBNull(4) Then
                                    MBCFm(ipos) = rdr.GetDouble(4)
                                Else
                                    MBCFm(ipos) = 0.0
                                End If
                                If Not rdr.IsDBNull(5) Then
                                    MBCFmSig(ipos) = rdr.GetDouble(5)
                                Else
                                    MBCFmSig(ipos) = 0.0
                                End If
                                If Not rdr.IsDBNull(6) Then
                                    MBCMass(ipos) = rdr.GetDouble(6)
                                Else
                                    MBCMass(ipos) = 0.0
                                End If
                                If Not rdr.IsDBNull(7) Then
                                    MBCMassSig(ipos) = rdr.GetDouble(7)
                                Else
                                    MBCMassSig(ipos) = 0.0
                                End If
                                If Not rdr.IsDBNull(8) Then
                                    IRMSdC13(ipos) = rdr.GetDouble(8)
                                Else
                                    IRMSdC13(ipos) = -1000.0
                                End If
                                If Not rdr.IsDBNull(10) Then
                                    SigTotalMass(ipos) = 12.015 * rdr.GetDouble(10)
                                Else
                                    SigTotalMass(ipos) = 0.1 * TotalMass(ipos)
                                End If
                            End While

                        End Using

                    End If
                Next
                For Each row As DataRow In TargetData.Rows
                    row.Item("Mass") = TargetMass(row.Item("Pos"))
                    row.Item("MSdC13") = IRMSdC13(row.Item("Pos"))
                Next row
                If String.IsNullOrEmpty(MissMass) = False Then
                    MsgBox("Cannot find total mass for these targets in DC13 Table: " & MissMass)
                End If
            Catch ex As Exception
                MsgBox("Pos 2" & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        If NumC13Ents < TargetData.Rows.Count - 1 Then 'change to -2?
            MsgBox("There were " & (TargetData.Rows.Count - 1 - NumC13Ents).ToString & " missing entries in the dC13 table for this wheel" _
                    & vbCrLf & "So there will be no target weights or del13C values for those targets" & vbCrLf & "The dC13 table should be filled in ")
        End If
        For i = 0 To MAXTARGETS
            If TargetIsPresent(i) Then
                GetProcType(i)
            End If

        Next
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT analyst1, analyst2, date_1, date_2, ro FROM dbo.snics_results" & TTE & " WHERE wheel = '" & whlName & "';"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                ISREADONLY = False  ' assume not readonly at first
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        FirstAuthName = rdr.GetString(0)
                        If Not rdr.IsDBNull(1) Then SecondAuthName = rdr.GetString(1)
                        If Not rdr.IsDBNull(2) Then FirstAuthDate = rdr.GetDateTime(2)
                        If Not rdr.IsDBNull(3) Then SecondAuthDate = rdr.GetDateTime(3)
                        If Not rdr.IsDBNull(4) Then
                            If rdr.GetByte(4) = 1 Then
                                ISREADONLY = True
                            End If
                        End If
                        nEnt = 1
                        Exit While
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Pos 3" & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        If ISREADONLY Then
            'MsgBox("THIS WHEEL IS NOW CLASSED AS READ-ONLY (IT HAS BEEN REPORTED)" & vbCrLf & " YOU WILL NOT BE ABLE TO SAVE AN EDITED VERSION TO THE DATABASE")
        End If
        If FirstAuthName.Trim <> "" And IAMINSPECTING = False Then
            ' this means someone has done this before
            If FirstAuthName = UserName Then
                MsgBox("The wheel has already been first authorized by you" & vbCrLf _
                       & "At " & FirstAuthDate.ToShortTimeString & " on " & FirstAuthDate.ToLongDateString & vbCrLf _
                       & "Proceeding allows you to over-write your previous results")
                If Not ISACQUIFILE Then tsmCommit.Text = "Overwrite Database"
                FIRSTAUTH = True
                SECONDAUTH = False
                REAUTH = True         ' this signals an update to your cause
                UpdateChoices(whlName, UserName)
                UpdateNonPerfs(whlName, UserName, True)
                tspCompare.Visible = True       ' ######### test only
                If SecondAuthName.Trim <> "" Then
                    InheritSecondsFlagsToolStripMenuItem.Text = "Inherit " & SecondAuthName & "'s Flags"
                    InheritSecondsFlagsToolStripMenuItem.Visible = True
                Else
                    InheritSecondsFlagsToolStripMenuItem.Visible = False
                End If
            ElseIf SecondAuthName.Trim = UserName Then
                MsgBox(
                    "The wheel has been first authorized by " & FirstAuthName & vbCrLf _
                    & "on " & FirstAuthDate.ToLongDateString & vbCrLf _
                     & "and second authorized by you " & vbCrLf _
                    & "At " & SecondAuthDate.ToShortTimeString & "on " & SecondAuthDate.ToLongDateString & vbCrLf _
                       & "You may over-write your previous 2nd authorizing results")
                tsmCommit.Visible = False
                FIRSTAUTH = False       ' you are second authorizing
                SECONDAUTH = True
                REAUTH = True         ' this signals an update to your cause
                UpdateChoices(whlName, UserName)
                UpdateNonPerfs(whlName, UserName, False)
                tspCompare.Visible = True       ' ######### test only
                InheritFirstsFlagsToolStripMenuItem.Text = "Inherit " & FirstAuthName & "'s Flags"
                InheritFirstsFlagsToolStripMenuItem.Visible = True
                InheritSecondsFlagsToolStripMenuItem.Visible = False
            ElseIf SecondAuthName.Trim <> "" Then
                MsgBox(
                    "The wheel has been first authorized by " & FirstAuthName & vbCrLf _
                    & "At " & FirstAuthDate.ToShortTimeString & " on " & FirstAuthDate.ToLongDateString & vbCrLf _
                     & "and second authorized by " & SecondAuthName & vbCrLf _
                    & "At " & SecondAuthDate.ToShortTimeString & "on " & SecondAuthDate.ToLongDateString & vbCrLf _
                       & "You cannot over-write previous results")
                FIRSTAUTH = False       ' you are second authorizing
                SECONDAUTH = False
                REAUTH = True         ' this signals an update to your cause
                tspCompare.Visible = True       ' ######### test only
                InheritFirstsFlagsToolStripMenuItem.Text = "Inherit " & FirstAuthName & "'s Flags"
                InheritFirstsFlagsToolStripMenuItem.Visible = True
                InheritSecondsFlagsToolStripMenuItem.Text = "Inherit " & SecondAuthName & "'s Flags"
                InheritSecondsFlagsToolStripMenuItem.Visible = True
            Else
                MsgBox(
                    "The wheel has been first authorized by " & FirstAuthName & vbCrLf _
                    & "At " & FirstAuthDate.ToShortTimeString & " on " & FirstAuthDate.ToLongDateString & vbCrLf _
                       & "by proceeding you may be the Second Authorizer")
                FIRSTAUTH = False
                SECONDAUTH = True
                REAUTH = False
                tsmCommit.Text = "Commit to Database"
                tspCompare.Visible = True
                InheritFirstsFlagsToolStripMenuItem.Text = "Inherit " & FirstAuthName & "'s Flags"
                InheritFirstsFlagsToolStripMenuItem.Visible = True
                InheritSecondsFlagsToolStripMenuItem.Visible = False
            End If
        Else
            FIRSTAUTH = True
            REAUTH = False
            SECONDAUTH = False
            If (Not ISACQUIFILE) And (Not ISREADONLY) Then tsmCommit.Text = "First Authorize"
            tspCompare.Visible = False
        End If
        If FIRSTAUTH And REAUTH And (Not ISREADONLY) Then        ' only visible for the first authorizer on second go round
            tspNukeDatabase.Visible = True
            tspNukeDatabase.Text = "Clean " & WheelName & " From Database"
        End If
    End Sub

    Private Sub NukeWheel()
        Dim msg As String = "This will remove all results for " & WheelName & "from the database" & vbCrLf
        If TheWheel.SecondAuthName <> "" Then msg &= " and force " & TheWheel.SecondAuthName & " to second analyze the wheel again"
        msg &= vbCrLf & "OK to continue?"
        Dim ires As MsgBoxResult = MsgBox(msg, vbYesNoCancel)
        If ires <> MsgBoxResult.Yes Then Exit Sub
        ClearRawData()
        ClearResults()
        tspNukeDatabase.Visible = False
        MsgBox("The dirty deed has been done " & vbCrLf & WheelName & " has been removed from the database")
    End Sub

    Private Sub ClearRawData()
        Dim aCmd As String = ""
        Using con As New SqlConnection
            Try
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                aCmd = "DELETE from dbo.snics_raw" & TTE & " WHERE wheel = '" & WheelName & "';"
                com.CommandText = aCmd
                Dim ptr As Integer = com.ExecuteNonQuery()
                If ptr = 0 Then MsgBox("Error cleaning Raw Table in Database: no rows deleted" & vbCrLf & aCmd)
            Catch ex As Exception
                MsgBox("Error cleaning Raw Table in Database" & vbCrLf & aCmd & vbCrLf & ex.Message)
                Exit Sub
            End Try
            con.Close()
        End Using
    End Sub

    Private Sub ClearResults()
        Dim aCmd As String = ""
        Using con1 As New SqlConnection
            Try
                con1.ConnectionString = ConString
                con1.Open()
                Dim com As IDbCommand = con1.CreateCommand
                com.CommandType = CommandType.Text
                aCmd = "DELETE from dbo.snics_results" & TTE & " WHERE wheel = '" & WheelName & "';"
                com.CommandText = aCmd
                Dim ptr As Integer = com.ExecuteNonQuery()
                If ptr = 0 Then MsgBox("Error cleaning Results Table in Database: no rows deleted" & vbCrLf & aCmd)
            Catch ex As Exception
                MsgBox("Error cleaning Results Table in Database" & vbCrLf & ex.Message & vbCrLf & aCmd)
            End Try
            con1.Close()
        End Using

    End Sub

    Private Function LatestWheelName(CoreName As String) As String
        LatestWheelName = ""
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT wheel_id FROM dbo.wheel_pos WHERE wheel_id LIKE '" & CoreName & "%' " _
                    & "ORDER BY wheel_position DESC;"           '                     & "WHERE wheel_id LIKE 'CFAMS*' " _
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    If rdr.Read Then
                        LatestWheelName = rdr.GetString(0)
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End Using
    End Function

    Private Sub UpdateChoices(whlname As String, analyst As String)
        Dim iRun As Integer = 0
        Dim HaveRecords As Boolean = False
        For i = 0 To TargetTypes.Length - 1
            TargetTypes(i) = ""
        Next
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT run_num, ok_calc, sample_type, sample_type_1, sample_type_2 " _
                    & "FROM dbo.snics_raw" & TTE & " WHERE wheel = '" & whlname & "' AND analyst = '" & analyst & "' ORDER BY run_num;"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        HaveRecords = True
                        iRun = rdr.GetInt32(0) - InputData(0).Item("Run")
                        InputData(iRun).Item("OK") = Not (rdr.GetByte(1) = 0)
                        InputData(iRun).Item("Typ") = rdr.GetString(2)
                        If (analyst = FirstAuthName) And Not rdr.IsDBNull(3) Then InputData(iRun).Item("Typ") = rdr.GetString(3)
                        If (analyst = SecondAuthName) And Not rdr.IsDBNull(4) Then InputData(iRun).Item("Typ") = rdr.GetString(4)
                        'Dim npos As Integer = -1
                        'For i = 0 To TargetData.Rows.Count - 1
                        '    If TargetData.Rows(i).Item("Pos") = InputData(iRun).Item("Pos") Then npos = i
                        'Next
                        'TargetData(npos).Item("Typ") = InputData(iRun).Item("Typ")
                        TargetTypes(InputData(iRun).Item("Pos")) = InputData(iRun).Item("Typ")
                        Select Case InputData(iRun).Item("Typ")
                            Case "S"
                                dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = StdCol
                            Case "SS"
                                dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = SecCol
                            Case "B"
                                dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = BlkCol
                            Case "U"
                                dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = UnkCol
                        End Select
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Pos1 " & iRun.ToString & " " & InputData(iRun).Item("Pos").ToString & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            con.Close()
        End Using

        If Not HaveRecords Then ' this must be second authorizer and new generation raw data storage
            Using con As New SqlConnection
                Try
                    Dim theCmd As String = "SELECT  run_num, ok_calc_2, sample_type, sample_type_1, sample_type_2 " _
                        & "FROM dbo.snics_raw" & TTE & " WHERE wheel = '" & whlname & "' ORDER BY run_num;"
                    con.ConnectionString = ConString
                    con.Open()
                    Dim com As IDbCommand = con.CreateCommand
                    com.CommandType = CommandType.Text
                    com.CommandText = theCmd
                    Using rdr As IDataReader = com.ExecuteReader
                        While rdr.Read
                            HaveRecords = True
                            iRun = rdr.GetInt32(0) - InputData.Rows(0).Item("Run")
                            InputData(iRun).Item("OK") = Not (rdr.GetByte(1) = 0)
                            InputData(iRun).Item("Typ") = rdr.GetString(2)
                            If (analyst = FirstAuthName) And Not rdr.IsDBNull(3) Then InputData(iRun).Item("Typ") = rdr.GetString(3)
                            If (analyst = SecondAuthName) And Not rdr.IsDBNull(4) Then InputData(iRun).Item("Typ") = rdr.GetString(4)
                            'TargetData(InputData(iRun).Item("Pos")).Item("Typ") = InputData(iRun).Item("Typ")
                            TargetTypes(InputData(iRun).Item("Pos")) = InputData(iRun).Item("Typ")
                            Select Case InputData(iRun).Item("Typ")
                                Case "S"
                                    dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = StdCol
                                Case "SS"
                                    dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = SecCol
                                Case "B"
                                    dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = BlkCol
                                Case "U"
                                    dgvInputData.Rows(iRun).DefaultCellStyle.BackColor = UnkCol
                            End Select
                        End While
                    End Using
                Catch ex As Exception
                    MsgBox("Pos2 " & iRun.ToString & " " & InputData(iRun).Item("Pos").ToString & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                End Try
                con.Close()
            End Using
        End If
        For Each row As DataRow In TargetData.Rows
            row.Item("Typ") = TargetTypes(row.Item("Pos"))
        Next row
        ColorizeTargets()
    End Sub

    Private Sub UpdateNonPerfs(whlname As String, analyst As String, IsFirstAuth As Boolean)
        Dim iPos As Integer = 0
        Using con As New SqlConnection
            Try
                Dim theCmd As String = ""
                If IsFirstAuth Then
                    theCmd = "SELECT wheel_pos, np, ss " _
                        & "FROM dbo.snics_results" & TTE & " WHERE wheel = '" & whlname & "' AND analyst1 = '" & analyst & "' ORDER BY wheel_pos;"
                Else
                    theCmd = "SELECT wheel_pos, np_2, ss_2 " _
                        & "FROM dbo.snics_results" & TTE & " WHERE wheel = '" & whlname & "' AND analyst2 = '" & analyst & "' ORDER BY wheel_pos;"
                End If
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        iPos = rdr.GetByte(0)
                        TargetNonPerf(iPos) = False
                        If Not rdr.IsDBNull(1) AndAlso rdr.GetByte(1) = 1 Then
                            TargetNonPerf(iPos) = True
                        End If
                        TargetIsSmall(iPos) = False
                        If Not rdr.IsDBNull(2) AndAlso rdr.GetByte(2) = 1 Then
                            TargetIsSmall(iPos) = True
                        End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End Using
        ColorizeTargets()
    End Sub

    Public Sub InitStdList()
        Using con As New SqlConnection
            Try
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = "Select type, rec_num, sample_id, Fm_cons, d13_cons, Fm_NOSAM_avg," _
                                            & " d13C_NOSAMS_avg from dbo.standards"
                Using rdr As IDataReader = com.ExecuteReader
                    NumStds = 0
                    While rdr.Read
                        Std_Rec_Num(NumStds) = rdr.GetInt32(1)
                        Std_Name(NumStds) = rdr.GetString(2)
                        Std_Fm(NumStds) = 42.0
                        If Not rdr.IsDBNull(3) Then
                            Std_Fm(NumStds) = rdr.GetDouble(3)
                            Std_Flag(NumStds) = True
                        ElseIf Not rdr.IsDBNull(5) Then
                            Std_Fm(NumStds) = rdr.GetDouble(5)
                            Std_Flag(NumStds) = False
                        End If
                        Std_delC13(NumStds) = 42.0
                        If Not rdr.IsDBNull(4) Then
                            Std_delC13(NumStds) = (1 + 0.001 * rdr.GetDouble(4))
                        ElseIf Not rdr.IsDBNull(6) Then
                            Std_delC13(NumStds) = (1 + 0.001 * rdr.GetDouble(6))
                            Std_Flag(NumStds) = False
                        End If
                        If Std_Fm(NumStds) = 1.0398 Then
                            Std_delC13(NumStds) = 0.981
                            Std_Flag(NumStds) = True
                        End If
                        NumStds += 1
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End Using
    End Sub

    Public Sub GetTargetInfo()
        With frmInfo
            frmInfo.lblName.Text = TargetNames(TargetSelected)
            frmInfo.lblPosition.Text = "Wheel Posn = " & TargetSelected.ToString
            frmInfo.lblRecNum.Text = "Receipt # = " & Rec_Num(TargetSelected).ToString
            frmInfo.lblTP_Num.Text = "TP # = " & Tp_Num(TargetSelected).ToString
            frmInfo.lblClientName.Text = "Client = "
            frmInfo.lblSampleID.Text = "No Sample_ID Info"
            frmInfo.lblTP_Comment.Text = "No TP Comment"
            frmInfo.lblProcType.Text = "Process Type = " & TargetProcs(TargetSelected) & " (" & TargetProcNums(TargetSelected).ToString & ")"
            frmInfo.lblSampleSize.Text = "Total Sample Size = " _
                                & TotalMass(TargetSelected).ToString("0.00") & " ug" & vbCrLf & "         (Graphite Size = " _
                                & TargetMass(TargetSelected).ToString("0.00") & " ug)"
            Using con As New SqlConnection
                Try
                    con.ConnectionString = ConString
                    con.Open()
                    Dim com As IDbCommand = con.CreateCommand
                    com.CommandType = CommandType.Text
                    Dim aCmd As String = "SELECT dbo.client.client_fname, dbo.client.client_lname, dbo.logged_sample.date_rec, " _
                                & "dbo.alxrefnd.key_long_desc, dbo.graphite.gf_co2_qty, dbo.logged_sample.collection_year, " _
                                & "dbo.graphite.osg_num, dbo.graphite.gf_dc13, dbo.logged_sample.dc13_submit_value, " _
                                & "dbo.logged_sample.cl_id, dbo.logged_sample.cl_type, dbo.target.tp_comments " _
                                & "FROM (((dbo.target INNER JOIN dbo.graphite ON dbo.target.osg_num = dbo.graphite.osg_num) " _
                                & "INNER JOIN dbo.logged_sample ON dbo.target.rec_num = dbo.logged_sample.rec_num) " _
                                & "INNER JOIN dbo.client ON dbo.logged_sample.client_id = dbo.client.client_id) " _
                                & "INNER JOIN dbo.alxrefnd ON dbo.logged_sample.process_code = dbo.alxrefnd.key_cd " _
                                & "WHERE (((dbo.target.tp_num)= " & Tp_Num(TargetSelected).ToString & ") AND " _
                                & "((dbo.alxrefnd.key_name)='PROCESS_TYPE'));"
                    com.CommandText = aCmd
                    Using rdr As IDataReader = com.ExecuteReader
                        While rdr.Read
                            If Not rdr.IsDBNull(0) Then frmInfo.lblClientName.Text = "Client = " & rdr.GetString(0)
                            If Not rdr.IsDBNull(1) Then frmInfo.lblClientName.Text &= rdr.GetString(1)
                            If Not rdr.IsDBNull(2) Then frmInfo.lblRec_Date.Text = "Received " & rdr.GetDateTime(2).ToShortDateString
                            If Not rdr.IsDBNull(5) Then frmInfo.lblRec_Date.Text &= "  (Collected " & rdr.GetInt16(5).ToString("0") & ")"
                            If Not rdr.IsDBNull(9) Then frmInfo.lblSampleID.Text = "Sample = " & rdr.GetString(9)
                            If Not rdr.IsDBNull(10) Then frmInfo.lblSampleID.Text &= "  " & rdr.GetString(10)
                            If Not rdr.IsDBNull(11) Then frmInfo.lblTP_Comment.Text = rdr.GetString(11)
                        End While
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                con.Close()
            End Using
            .Visible = True
            .TopMost = True
        End With

    End Sub

    Private Sub GetProcType(ByVal iTarg As Integer)
        TargetProcNums(iTarg) = 0
        Using con As New SqlConnection
            Try
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                Dim aCmd As String = "SELECT [amsprod].[dbo].[fn_get_process_code] (" & Tp_Num(iTarg).ToString & ");"
                com.CommandText = aCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        TargetProcNums(iTarg) = rdr.GetInt16(0)
                    End While
                End Using
                aCmd = "SELECT key_short_desc FROM dbo.alxrefnd WHERE (key_name = 'PROCESS_TYPE') AND (key_cd = " & TargetProcNums(iTarg).ToString & ");"
                'MsgBox(aCmd)
                com.CommandText = aCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                         If Not rdr.IsDBNull(0) Then
                             TargetProcs(iTarg) = rdr.GetString(0)
                         Else
                             TargetProcs(iTarg) =  ""
                         End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error getting proc for pos " & iTarg.ToString & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
    End Sub

    Private Sub GetRawDataFromDatabase(wheelname As String)
        Dim acmd As String = ""
        Dim LastGrp As Integer = 0
        Dim LastMst As Integer = 0
        Using con As New SqlConnection
            Try
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                acmd = "SELECT run_num,  runtime, wheel_pos, group_num, mst_num, sample_name, sample_type, cycles, "
                acmd &= "le12c, le13c, he12c, he13c, cnt_in, cnt_meas, cnt_14c, he13_12, he14_12, ltcorr, "
                acmd &= "corr_14_12, sig_14_12, d13c, ok_calc, ok_calc_2, sample_type_1, sample_type_2 FROM dbo.snics_raw" & TTE & " WHERE wheel = '" & wheelname
                acmd &= "' AND analyst = '" & GetWheelID(wheelname).FirstAuthName & "' ORDER BY run_num;"
                com.CommandText = acmd
                'MsgBox(acmd)
                'InputData.Clear()
                'SetupInputData()
                InputData.Rows.Clear()
                NumRuns = 0
                GroupEnd(0) = -1
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        Dim newrow = InputData.NewRow
                        newrow(0) = True            'default to OK
                        If rdr.GetByte(21) = 0 Then newrow(0) = False ' OK flag
                        newrow(1) = rdr.GetInt32(0)         ' run number
                        newrow(2) = rdr.GetDateTime(1)      ' run time
                        newrow(3) = rdr.GetByte(2)          ' wheel position
                        newrow(4) = rdr.GetInt32(3)         ' group number
                        newrow(5) = rdr.GetInt32(4)         ' measurement number
                        newrow(6) = rdr.GetString(5)        ' sample name
                        newrow(7) = rdr.GetString(6)        ' original sample type
                        Samp_Typ(NumRuns) = newrow(7)          ' save as original type
                        newrow(8) = rdr.GetFloat(7)         ' number of cycles
                        For i = 8 To 11
                            newrow(i + 1) = rdr.GetDouble(i)    'le12, le13 he12 he13
                        Next
                        For i = 12 To 14
                            newrow(i + 1) = rdr.GetInt32(i)     ' cnt_in, cnt_meas, cnt_14c
                        Next
                        For i = 15 To 20
                            newrow(i + 1) = rdr.GetDouble(i)    ' he13_12, he14_12, ltcorr, corr_14_12, sig_14_12, d13c
                        Next
                        If FIRSTAUTH And REAUTH Then
                            If Not rdr.IsDBNull(23) Then        ' if the analyst had recorded his/her choice
                                newrow(7) = rdr.GetString(23) ' sample_type_1
                                'If newrow(1) = 39 Then MsgBox(newrow(7))
                            End If
                        End If
                        If SECONDAUTH And Not REAUTH Then
                            newrow(0) = True                    ' first time clear the flags
                            newrow(7) = rdr.GetString(23) ' sample_type_1 the first time
                        End If
                        If SECONDAUTH And REAUTH Then  ' get 2nd's flags and sample type
                            If Not rdr.IsDBNull(22) Then
                                newrow(0) = True
                                If rdr.GetByte(22) = 0 Then newrow(0) = False
                            End If
                            If Not rdr.IsDBNull(24) Then newrow(7) = rdr.GetString(24) ' sample_type_2
                        End If
                        RunPos(NumRuns) = newrow("Pos")
                        RunTimes(NumRuns) = CDate(newrow("RunTime")).ToOADate
                        GroupNums(NumRuns) = newrow("Grp")
                        iRunTimes(NumRuns) = 24 * 3600 * (RunTimes(NumRuns) - RunTimes(0)) + newrow("Cycles") / 20  ' seconds from start of wheel to mid-analysis
                        RunKeys(newrow("Pos"), 0) += 1               ' increment number of runs for this position
                        RunKeys(newrow("Pos"), RunKeys(newrow("Pos"), 0)) = NumRuns         ' save the run key info
                        If NumRuns > 0 Then
                            If newrow("Grp") <> LastGrp Then
                                GroupEnd(LastGrp) = NumRuns - 1
                                GroupTimes(LastGrp) = (RunTimes(NumRuns) + RunTimes(NumRuns - 1)) / 2
                                'MsgBox(NumRuns.ToString & ":=" & GroupEnd(LastGrp).ToString & "=: " & GroupTimes(LastGrp))
                            End If
                        End If
                        LastMst = newrow("Mst")
                        LastGrp = newrow("Grp")
                        InputData.Rows.Add(newrow)
                        If newrow("Typ") = "S" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = StdCol
                        If newrow("Typ") = "SS" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = SecCol
                        If newrow("Typ") = "B" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = BlkCol
                        If newrow("Typ") = "U" Then dgvInputData.Rows(NumRuns).DefaultCellStyle.BackColor = UnkCol
                        NumRuns += 1
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error Reading Raw Table in Database" & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        NumGroups = GroupNums(NumRuns - 1)
        GroupEnd(NumGroups) = NumRuns - 1             ' point to end of last group
        GroupTimes(NumGroups) = RunTimes(NumRuns - 1)
        GroupTimes(0) = RunTimes(0) - 0.001
        Using con As New SqlConnection
            Try
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                If REAUTH And FIRSTAUTH Then
                    acmd = "SELECT wheel_pos, np, ss, comment, fm_corr, sig_fm_corr, lg_blk_fm, sig_lg_blk_fm, fm_mb_corr, sig_fm_mb_corr, norm_method, ro " _
                        & " FROM dbo.snics_results" & TTE & " WHERE wheel = '" & wheelname & "' ORDER BY wheel_pos;"
                    frmBlankCorr.chkLockAll.Checked = True
                ElseIf REAUTH And SECONDAUTH Then
                    acmd = "SELECT wheel_pos, np_2, ss_2, comment_2, fm_corr_2, sig_fm_corr_2, lg_blk_fm_2, sig_lg_blk_fm_2, fm_mb_corr_2, sig_fm_mb_corr_2, norm_method_2, ro " _
                        & " FROM dbo.snics_results" & TTE & " WHERE wheel = '" & wheelname & "' ORDER BY wheel_pos;"
                    frmBlankCorr.chkLockAll.Checked = True
                Else
                    acmd = "SELECT wheel_pos, np, ss, comment, fm_corr, sig_fm_corr, lg_blk_fm, sig_lg_blk_fm, fm_mb_corr, sig_fm_mb_corr, norm_method, ro " _
                                        & " FROM dbo.snics_results" & TTE & " WHERE wheel = '" & wheelname & "' ORDER BY wheel_pos;"
                    frmBlankCorr.chkLockAll.Checked = False
                    'Exit Try
                End If
                For i = 0 To TargetIsSmall.Length - 1
                    TargetIsSmall(i) = False
                Next
                For i = 0 To TargetNonPerf.Length - 1
                    TargetNonPerf(i) = False
                Next
                Dim nPos As Integer = 0
                com.CommandText = acmd
                Using rdr As IDataReader = com.ExecuteReader
                    Dim GotMethod As Boolean = False
                    While rdr.Read
                        If Not rdr.IsDBNull(0) Then
                            nPos = rdr.GetByte(0)
                            If Not rdr.IsDBNull(1) Then
                                If rdr.GetByte(1) <> 0 Then TargetNonPerf(nPos) = True
                            End If
                            If Not rdr.IsDBNull(2) Then
                                If rdr.GetByte(2) <> 0 Then TargetIsSmall(nPos) = True
                            End If
                            TargetComments(nPos) = ""
                            If Not rdr.IsDBNull(3) Then TargetComments(nPos) = rdr.GetString(3)
                        End If
                        If Not rdr.IsDBNull(4) Then FmCorr(nPos) = rdr.GetDouble(4)
                        If Not rdr.IsDBNull(5) Then SigFmCorr(nPos) = rdr.GetDouble(5)
                        If Not rdr.IsDBNull(6) Then LgBlkFm(nPos) = rdr.GetDouble(6)
                        If Not rdr.IsDBNull(7) Then SigLgBlkFm(nPos) = rdr.GetDouble(7)
                        If Not rdr.IsDBNull(8) Then FmMBCorr(nPos) = rdr.GetDouble(8)
                        If Not rdr.IsDBNull(9) Then SigFmMBCorr(nPos) = rdr.GetDouble(9)
                        TargetIsReadOnly(nPos) = False
                        If Not rdr.IsDBNull(11) Then
                            If rdr.GetByte(11) = 1 Then TargetIsReadOnly(nPos) = True
                        End If
                        If Not rdr.IsDBNull(10) Then
                            If Not GotMethod Then
                                Dim theMethod As String = rdr.GetString(10)
                                If theMethod.Contains(" (GBE)") Then
                                    'MsgBox(theMethod)
                                    theMethod = theMethod.Remove(theMethod.LastIndexOf(" (GBE)"), 6)
                                    'MsgBox(theMethod)
                                    GROUPBOUNDS = True
                                Else
                                    GROUPBOUNDS = False
                                End If
                                CalcMode = (theMethod.Substring(0, theMethod.Length - 2)).Trim
                                If Val(theMethod.Substring(theMethod.Length - 2, 2)) > 0 Then CalcNum = CInt(theMethod.Substring(theMethod.Length - 2, 2))
                                Try
                                    Options.nudNumStds.Value = CalcNum
                                    Options.cmbFitType.Text = CalcMode
                                    Options.chkGroup.Checked = GROUPBOUNDS
                                Catch ex As Exception

                                End Try
                                'MsgBox("Got " & CalcMode & ":" & CalcNum.ToString)
                                GotMethod = True        ' do this only once
                            End If
                        End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox("Error Reading Flags from Results Table in Database" & vbCrLf & acmd & vbCrLf & ex.Message)
            End Try
            con.Close()
        End Using
        If (wheelname.Substring(0, 5)).ToUpper = "USAMS" Then
            dgvInputData.Columns(8).DefaultCellStyle.Format = "0.00"
        Else
            dgvInputData.Columns(8).DefaultCellStyle.Format = "0"
        End If
        dgvInputData.AutoResizeColumns()
        dgvInputData.AutoResizeRows()
        UpdateDataListLabel()
        CollectRats()
        AssignTargets()       ' find out if target exists
        PopulateTargets()
        GetWheelInfo(wheelname)
        SetUpStds()
        RepositionDGVs()
        tsmSave.Enabled = True
        If Not ISACQUIFILE Then tsmCommit.Enabled = True
        PropertyPropertyToolStripMenuItem.Enabled = True
        StandardsAndBlanksToolStripMenuItem.Enabled = True
        LOADEDWHEEL = True
        TheWheel = GetWheelID(wheelname)
        If TheWheel.FirstAuthName <> "" And TheWheel.SecondAuthName <> "" Then
            CompareFlagsToolStripMenuItem.Visible = True
            FlagsToolStripMenuItem1.Visible = True
        Else
            CompareFlagsToolStripMenuItem.Visible = False
            FlagsToolStripMenuItem1.Visible = False
        End If
        FindSmallSamples()       ' find out if target is small
        CommitGroupToDatabaseToolStripMenuItem.Enabled = False
        If Not FIRSTAUTH Then
            tspGroup.Visible = False
        Else
            tspGroup.Visible = True
        End If
    End Sub

    Public Sub CommitToDatabase(Optional ByVal GroupNum = 0)
        Dim NumNotSaved As Integer = 0         ' number of target records saved
        Dim aCmd As String = ""
        Dim ires As MsgBoxResult = MsgBox("This will write your results to the database, OK to continue?", vbYesNoCancel)
        If ires <> MsgBoxResult.Yes Then Exit Sub
        If Not REAUTH Then
            If FIRSTAUTH Then
                Using con As New SqlConnection
                    Try
                        con.ConnectionString = ConString
                        con.Open()
                        Dim com As IDbCommand = con.CreateCommand
                        com.CommandType = CommandType.Text
                        aCmd = "SELECT analyst1 FROM dbo.snics_results" & TTE & " WHERE wheel = '" & WheelName & "';"
                        Using rdr As IDataReader = com.ExecuteReader
                            If rdr.GetString(0) <> "" Then
                                MsgBox(rdr.GetString(0) & " Has already first analyzed this wheel")
                                con.Close()
                                Exit Sub
                            End If
                        End Using
                    Catch ex As Exception

                    End Try
                    con.Close()
                End Using
            ElseIf SECONDAUTH Then
                Using con As New SqlConnection
                    Try
                        con.ConnectionString = ConString
                        con.Open()
                        Dim com As IDbCommand = con.CreateCommand
                        com.CommandType = CommandType.Text
                        aCmd = "SELECT analyst2 FROM dbo.snics_results" & TTE & " WHERE wheel = '" & WheelName & "';"
                        Using rdr As IDataReader = com.ExecuteReader
                            If Not rdr.IsDBNull(0) <> "" Then
                                MsgBox(rdr.GetString(0) & " Has already second analyzed this wheel")
                                con.Close()
                                Exit Sub
                            End If
                        End Using
                    Catch ex As Exception

                    End Try
                    con.Close()
                End Using
            End If
        End If
        If ISPARTIALWHEEL Then REAUTH = False ' this means we've loaded the rest of the story
        MakePatience()
        Using con As New SqlConnection          ' first write to the raw data table (including flags)
            Try
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                For i = 0 To InputData.Rows.Count - 1
                    If (GroupNum = 0) Or (GroupNum = InputData.Rows(i).Item("Grp")) Then
                        Dim theSampleName As String = InputData.Rows(i).Item("SampleName")
                        theSampleName = theSampleName.Replace("'", "''")            ' for SQL syntax
                        Dim ok_calc As String = "0"
                        If InputData.Rows(i).Item("OK") Then ok_calc = "1"
                        If FIRSTAUTH And (Not REAUTH) And RunNotAlreadyDone(i) Then
                            aCmd = "INSERT INTO dbo.snics_raw" & TTE & " (wheel, tp_num, ok_calc, run_num, runtime, wheel_pos, group_num, mst_num, " _
                                        & "sample_name, sample_type_1, cycles, le12c, le13c, he12c, he13c, cnt_meas, cnt_in, cnt_14c, he13_12, he14_12, " _
                                        & "ltcorr, corr_14_12, sig_14_12, d13c, analyst, sample_type) " _
                                        & "values ( '" & WheelName & "', " & TP_Nums(i).ToString & ", " _
                                        & ok_calc & ", " & InputData.Rows(i).Item("Run").ToString & ", '" _
                                        & CDate(InputData.Rows(i).Item("RunTime")).ToString("yyyy-MM-dd HH:mm:ss") & "', "
                            For j = 3 To 5
                                aCmd &= InputData.Rows(i).Item(j).ToString & ", "
                            Next
                            aCmd &= "'" & theSampleName & "', '" & InputData.Rows(i).Item("Typ") & "'"
                            For j = 8 To InputData.Columns.Count - 1
                                aCmd &= ", " & dgvInputData.Item(j, i).Value
                            Next
                            aCmd &= ", '" & UserName & "', '" & Samp_Typ(i).ToString & "');"
                        ElseIf FIRSTAUTH And REAUTH Then
                            aCmd = "UPDATE dbo.snics_raw" & TTE & " SET  ok_calc = " & ok_calc & ", sample_type_1 = '" & InputData(i).Item("Typ").ToString
                            aCmd &= "' WHERE wheel = '" & WheelName & "' AND run_num = " & InputData(i).Item("Run").ToString & " AND analyst = '" & UserName & "';"
                        ElseIf SECONDAUTH Then
                            aCmd = "UPDATE dbo.snics_raw" & TTE & " SET  ok_calc_2 = " & ok_calc & ", sample_type_2 = '" & InputData(i).Item("Typ").ToString
                            aCmd &= "' WHERE wheel = '" & WheelName & "' AND run_num = " & InputData(i).Item("Run").ToString & " AND analyst = '" & FirstAuthName & "';"
                        End If
                        'MsgBox(aCmd)
                        If RunNotAlreadyDone(i) Then    ' only do this if valid 
                            com.CommandText = aCmd
                            Dim ptr As Integer = com.ExecuteNonQuery()
                            If ptr = 0 Then MsgBox("Error writing to Raw Table in Database: no rows saved" & vbCrLf & aCmd)
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error writing to Raw Table in Database" & vbCrLf & aCmd & vbCrLf & ex.Message & vbCrLf & "Cleaning any raw data from database" & vbCrLf & "Please save your work and restart SNICSer before continuing")
                If FIRSTAUTH And Not REAUTH Then ClearRawData()
                con.Close()
            End Try
            con.Close()
        End Using
        Using con1 As New SqlConnection     ' next write to the results table
            Try
                aCmd = "Connection details not entered"
                Dim theNormMethod As String = Trim(CalcMode)
                If GROUPBOUNDS Then theNormMethod &= " (GBE)"
                con1.ConnectionString = ConString
                con1.Open()
                Dim com As IDbCommand = con1.CreateCommand
                com.CommandType = CommandType.Text
                Dim CalcDate As String = Format(Now, "yyyy-MM-ddTHH:mm:ss")
                aCmd = "Entering results loop"
                For i = 0 To TargetData.Rows.Count - 1
                    If (GroupNum = 0) Or (GroupNum = TargetGroups(i)) Then      ' only if doing all groups or a specified group
                        aCmd = "Error accessing NonPerformance flags"
                        Dim NonPerf As String = "0"
                        If TargetNonPerf(i) Then NonPerf = "1"
                        aCmd = "Error accessing IsSmall flags"
                        Dim IsSmall As String = "0"
                        If TargetIsSmall(i) Then IsSmall = "1"
                        aCmd = "Error accessing TargetData SampleName"
                        Dim theSampleName As String = TargetData.Rows(i).Item("SampleName")
                        theSampleName = theSampleName.Replace("'", "''")        ' for SQL syntax
                        FmCorr(i) = ReplNaN(FmCorr(i))      ' if it is a NaN, replace with 42
                        SigFmCorr(i) = ReplNaN(SigFmCorr(i))
                        LgBlkFm(i) = ReplNaN(LgBlkFm(i))
                        SigLgBlkFm(i) = ReplNaN(SigLgBlkFm(i))
                        FmMBCorr(i) = ReplNaN(FmMBCorr(i))
                        SigFmMBCorr(i) = ReplNaN(SigFmMBCorr(i))
                        MBBlkFm(i) = ReplNaN(MBBlkFm(i))
                        SigMBBlkFm(i) = ReplNaN(SigMBBlkFm(i))
                        MBBlkMass(i) = ReplNaN(MBBlkMass(i))
                        SigMBBlkMass(i) = ReplNaN(SigMBBlkMass(i))
                        NormRat(i) = ReplNaN(NormRat(i))
                        IntErr(i) = ReplNaN(IntErr(i))
                        ExtErr(i) = ReplNaN(ExtErr(i))
                        If TargetComments(i) Is Nothing Then TargetComments(i) = ""
                        Dim iPos As Integer = TargetData.Rows(i).Item("Pos")
                        Dim RunDateTime As String = Date.FromOADate(TargetRunTimes(iPos)).ToString("yyyy-MM-ddTHH:mm:ss")
                        If TargetIsReadOnly(iPos) Then
                            NumNotSaved += 1
                        Else
                            If FIRSTAUTH Then
                                If Not REAUTH And TargetNotAlreadyRun(iPos) Then
                                    If FmMBCorr(iPos) <> -99 Then
                                        aCmd = "INSERT INTO dbo.snics_results" & TTE & " (wheel, wheel_pos, tp_num, num_runs, tot_runs, np, ss, " _
                                                             & "sample_name, sample_type_1, norm_ratio, int_err, ext_err, norm_method, analyst1, date_1, " _
                                                             & "del_13c, sig_13c, fm_corr, sig_fm_corr, lg_blk_fm, sig_lg_blk_fm, fm_mb_corr, sig_fm_mb_corr, " _
                                                             & "blank_fm, sig_blank_fm, blank_mass, sig_blank_mass, comment, sample_type, runtime" _
                                                             & ") values ('" & WheelName & "', " & iPos.ToString & ", " & Tp_Num(iPos).ToString _
                                                             & ", " & TargetData.Rows(i).Item("N") & ", " & TotalRuns(iPos).ToString & ", " & NonPerf & ", " & IsSmall & ", '" _
                                                             & theSampleName & "', '" & TargetData.Rows(i).Item("Typ") _
                                                             & "', " & TargetRat(iPos).ToString & ", " & IntErr(iPos).ToString _
                                                             & ", " & ExtErr(iPos).ToString & ", '" & theNormMethod & " " & CalcNum.ToString _
                                                             & "', '" & UserName & "', '" & CalcDate & "', " & TargetData.Rows(i).Item("DelC13") & ", " _
                                                             & TargetData.Rows(i).Item("SigC13") & ", " & FmCorr(iPos).ToString & ", " & SigFmCorr(iPos).ToString & ", " _
                                                             & LgBlkFm(iPos).ToString & ", " & SigLgBlkFm(iPos).ToString & ", " & FmMBCorr(iPos).ToString & ", " _
                                                             & SigFmMBCorr(iPos).ToString & ", " & MBBlkFm(iPos).ToString & ", " & SigMBBlkFm(iPos).ToString & ", " _
                                                             & MBBlkMass(iPos).ToString & ", " & SigMBBlkMass(iPos).ToString & ", '" & TargetComments(iPos).Trim _
                                                             & "', '" & OrigTypes(iPos) & "','" & RunDateTime & "');"
                                    Else    ' need to put NULLs in the mass balance results
                                        aCmd = "INSERT INTO dbo.snics_results" & TTE & " (wheel, wheel_pos, tp_num, num_runs, tot_runs, np, ss, " _
                                                            & "sample_name, sample_type_1, norm_ratio, int_err, ext_err, norm_method, analyst1, date_1, " _
                                                            & "del_13c, sig_13c, fm_corr, sig_fm_corr, lg_blk_fm, sig_lg_blk_fm, comment, sample_type, runtime" _
                                                            & ") values ('" & WheelName & "', " & iPos.ToString & ", " & Tp_Num(iPos).ToString _
                                                            & ", " & TargetData.Rows(i).Item("N") & ", " & TotalRuns(iPos).ToString & ", " & NonPerf & ", " & IsSmall & ", '" _
                                                            & theSampleName & "', '" & TargetData.Rows(i).Item("Typ") _
                                                            & "', " & TargetRat(iPos).ToString & ", " & IntErr(iPos).ToString _
                                                            & ", " & ExtErr(iPos).ToString & ", '" & theNormMethod & " " & CalcNum.ToString _
                                                            & "', '" & UserName & "', '" & CalcDate & "', " & TargetData.Rows(i).Item("DelC13") & ", " _
                                                            & TargetData.Rows(i).Item("SigC13") & ", " & FmCorr(iPos).ToString & ", " & SigFmCorr(iPos).ToString & ", " _
                                                            & LgBlkFm(iPos).ToString & ", " & SigLgBlkFm(iPos).ToString & ", '" & TargetComments(iPos).Trim _
                                                            & "', '" & OrigTypes(iPos) & "','" & RunDateTime & "');"
                                    End If
                                Else
                                    If FmMBCorr(iPos) <> -99 Then
                                        aCmd = "UPDATE dbo.snics_results" & TTE & " SET num_runs = " & TargetData.Rows(i).Item("N") & ", sample_type_1 = '" _
                                                             & TargetData.Rows(i).Item("Typ") & "', norm_ratio = " & TargetRat(iPos).ToString _
                                                             & ", int_err = " & IntErr(iPos).ToString & " , ext_err = " _
                                                             & ExtErr(i).ToString & ", date_1 = '" & CalcDate _
                                                             & "', del_13c = " & TargetData.Rows(i).Item("DelC13") & ", sig_13c = " & TargetData(i).Item("SigC13") _
                                                             & ", fm_corr = " & FmCorr(iPos).ToString _
                                                             & ", sig_fm_corr = " & SigFmCorr(iPos).ToString _
                                                             & ", lg_blk_fm = " & LgBlkFm(iPos).ToString & ", sig_lg_blk_fm = " & SigLgBlkFm(iPos).ToString _
                                                             & ", fm_mb_corr = " & FmMBCorr(iPos).ToString & ", sig_fm_mb_corr = " & SigFmMBCorr(iPos).ToString _
                                                             & ", blank_fm = " & MBBlkFm(iPos).ToString _
                                                             & ", sig_blank_fm = " & SigMBBlkFm(iPos).ToString & ", blank_mass = " _
                                                             & MBBlkMass(iPos).ToString & ", sig_blank_mass = " & SigMBBlkMass(iPos).ToString _
                                                             & ", comment = '" & TargetComments(iPos).Trim & "', np = " & NonPerf & ", ss = " & IsSmall _
                                                             & ", norm_method = '" & theNormMethod & " " & CalcNum.ToString & "'" _
                                                             & " WHERE (wheel = '" & WheelName & "') AND (wheel_pos = " & iPos.ToString & ");"
                                    Else
                                        aCmd = "UPDATE dbo.snics_results" & TTE & " SET num_runs = " & TargetData.Rows(i).Item("N") & ", sample_type_1 = '" _
                                                              & TargetData.Rows(i).Item("Typ") & "', norm_ratio = " & TargetRat(iPos).ToString _
                                                              & ", int_err = " & IntErr(iPos).ToString & " , ext_err = " _
                                                              & ExtErr(i).ToString & ", date_1 = '" & CalcDate _
                                                              & "', del_13c = " & TargetData.Rows(i).Item("DelC13") & ", sig_13c = " & TargetData(i).Item("SigC13") _
                                                              & ", fm_corr = " & FmCorr(iPos).ToString _
                                                              & ", sig_fm_corr = " & SigFmCorr(iPos).ToString _
                                                              & ", lg_blk_fm = " & LgBlkFm(iPos).ToString & ", sig_lg_blk_fm = " & SigLgBlkFm(iPos).ToString _
                                                              & ", fm_mb_corr = NULL, sig_fm_mb_corr = NULL, blank_fm = NULL" _
                                                              & ", sig_blank_fm = NULL, blank_mass = NULL, sig_blank_mass = NULL" _
                                                              & ", comment = '" & TargetComments(iPos).Trim & "', np = " & NonPerf & ", ss = " & IsSmall _
                                                              & ", norm_method = '" & theNormMethod & " " & CalcNum.ToString & "'" _
                                                              & " WHERE (wheel = '" & WheelName & "') AND (wheel_pos = " & iPos.ToString & ");"
                                    End If
                                End If
                                'MsgBox(aCmd)
                            ElseIf SECONDAUTH Then
                                If FmMBCorr(iPos) <> -99 Then
                                    aCmd = "UPDATE dbo.snics_results" & TTE & " SET num_runs_2 = " & TargetData.Rows(i).Item("N") & ", sample_type_2 = '" _
                                                        & TargetData.Rows(i).Item("Typ") & "', norm_ratio_2 = " & TargetRat(iPos).ToString _
                                                        & ", int_err_2 = " & IntErr(iPos).ToString & " , ext_err_2 = " _
                                                        & ExtErr(iPos).ToString & ", date_2 = '" & CalcDate _
                                                        & "', del_13c_2 = " & TargetData.Rows(i).Item("DelC13") & ", sig_13c_2 = " & TargetData(i).Item("SigC13") _
                                                        & ", fm_corr_2 = " & FmCorr(iPos).ToString & ", sig_fm_corr_2 = " & SigFmCorr(iPos).ToString _
                                                        & ", lg_blk_fm_2 = " & LgBlkFm(iPos).ToString & ", sig_lg_blk_fm_2 = " & SigLgBlkFm(i).ToString _
                                                        & ", fm_mb_corr_2 = " & FmMBCorr(iPos).ToString & ", sig_fm_mb_corr_2 = " & SigFmMBCorr(iPos).ToString _
                                                        & ", blank_fm_2 = " _
                                                        & MBBlkFm(iPos).ToString & ", sig_blank_fm_2 = " & SigMBBlkFm(iPos).ToString & ", blank_mass_2 = " _
                                                        & MBBlkMass(iPos).ToString & ", sig_blank_mass_2 = " & SigMBBlkMass(iPos).ToString _
                                                        & ", comment_2 = '" & TargetComments(i).Trim & "', analyst2 = '" & UserName & "', " _
                                                        & "np_2 = " & NonPerf & ", ss_2 = " & IsSmall & ", norm_method_2 = '" & theNormMethod & " " & CalcNum.ToString & "'" _
                                                        & " WHERE (wheel = '" & WheelName & "') AND (wheel_pos = " & iPos.ToString & ");"
                                Else
                                    aCmd = "UPDATE dbo.snics_results" & TTE & " SET num_runs_2 = " & TargetData.Rows(i).Item("N") & ", sample_type_2 = '" _
                                                        & TargetData.Rows(i).Item("Typ") & "', norm_ratio_2 = " & TargetRat(iPos).ToString _
                                                        & ", int_err_2 = " & IntErr(iPos).ToString & " , ext_err_2 = " _
                                                        & ExtErr(iPos).ToString & ", date_2 = '" & CalcDate _
                                                        & "', del_13c_2 = " & TargetData.Rows(i).Item("DelC13") & ", sig_13c_2 = " & TargetData(i).Item("SigC13") _
                                                        & ", fm_corr_2 = " & FmCorr(iPos).ToString & ", sig_fm_corr_2 = " & SigFmCorr(iPos).ToString _
                                                        & ", lg_blk_fm_2 = NULL, sig_lg_blk_fm_2 = NULL, fm_mb_corr_2 = NULL, sig_fm_mb_corr_2 = NULL, blank_fm_2 = NULL," _
                                                        & " sig_blank_fm_2 = NULL, blank_mass_2 = NULL, comment_2 = '" & TargetComments(i).Trim & "', analyst2 = '" & UserName & "', " _
                                                        & "np_2 = " & NonPerf & ", ss_2 = " & IsSmall & ", norm_method_2 = '" & theNormMethod & " " & CalcNum.ToString & "'" _
                                                        & " WHERE (wheel = '" & WheelName & "') AND (wheel_pos = " & iPos.ToString & ");"
                                End If
                            End If
                            If TargetNotAlreadyRun(i) Then
                                com.CommandText = aCmd
                                Dim ptr As Integer = com.ExecuteNonQuery()
                                If ptr = 0 Then MsgBox("Did not update any rows")
                            End If
                        End If
                    End If
                Next
                If NumNotSaved <> 0 Then
                    MsgBox("WARNING: " & NumNotSaved.ToString & " RESULTS WERE NOT SAVED TO DATABASE (ReadOnly)")
                Else
                    MsgBox("Your results have been saved to the database" & vbCrLf & "Thank you for using SNICSer!")
                End If
            Catch ex As Exception
                MsgBox("Error writing to Results Table in Database" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf & aCmd & vbCrLf & "Cleaning all data from database")
                If FIRSTAUTH And Not REAUTH Then
                    ClearRawData()
                    ClearResults()
                End If
            End Try
            con1.Close()
        End Using
        SAVEDTODATABASE = True
        'PrintDatabaseImportFile(GroupNum) 'Don't need db files anymore
        frmPatience.Visible = False         ' disappear the Snickers
        Me.Enabled = True
        tspPrint.Visible = True
        If FIRSTAUTH Then
            With FrmNotify2ndAuth
                .lblNotify.Text = "Do you wish to (email) notify the 2nd Analyst?"
                .lbx2ndAuth.Text = ""
                .ShowDialog() ' present them with the option to send an automatic email
            End With
        End If
        If SECONDAUTH Then
            With FrmNotify2ndAuth
                .lblNotify.Text = "Do you wish to (email) notify the 1st Analyst?"
                .lbx2ndAuth.Text = TheWheel.FirstAuthName
                .ShowDialog()
            End With
        End If
        ISPARTIALWHEEL = False
        ' clear this in case you've just updated a partial wheel
        REAUTH = True
        ' Set reauth to prevent first write issue if wheel is not reloaded
    End Sub    ' Save data to database

    Private Function RunNotAlreadyDone(iRun As Integer) As Boolean
        RunNotAlreadyDone = True
        If ISPARTIALWHEEL Then
            For i = 0 To pRuns - 1
                If pRunNums(i) = iRun Then
                    RunNotAlreadyDone = False
                    Exit For
                End If
            Next
        End If
        ''''' if had group saved, for i = 0 to numrunssaved if irun = that run then false
    End Function

    Private Function TargetNotAlreadyRun(iTarg As Integer) As Boolean
        TargetNotAlreadyRun = True
        If ISPARTIALWHEEL Then
            For i = 0 To pTargetNums - 1
                If pTargetPos(i) = iTarg Then
                    TargetNotAlreadyRun = False
                    Exit For
                End If
            Next
        End If
    End Function

    Private Function ReplNaN(Value As Double) As Double
        If Double.IsNaN(Value) Then
            Return (-99)
        Else
            Return Value
        End If
    End Function

    Public Sub DoComparison()
        Dim TheNormMethod As String = "Unknown"
        Dim TheSecondNormMethod As String = ""
        Compare.dgvCompare.DataSource = Comparison
        For i = 8 To Comparison.Columns.Count - 1
            Compare.dgvCompare.Columns(i).DefaultCellStyle.Format = dFnt(NumResFigs - 3)
        Next
        Dim NewRow As DataRow
        Calculate()                       ' force a recalculation to make sure results are current
        Dim MeanSigma As Double = 0
        Dim MeanAbsSigma As Double = 0
        Comparison.Rows.Clear()
        Dim nRow As Integer = 0
        Using con As New SqlConnection
            Try
                Dim theCmd As String = "SELECT dbo.snics_results" & TTE & ".wheel_pos,  dbo.snics_results" & TTE & ".sample_type, " _
                    & "dbo.snics_results" & TTE & ".num_runs, " _
                    & "dbo.snics_results" & TTE & ".norm_ratio, dbo.snics_results" & TTE & ".int_err, dbo.snics_results" & TTE & ".ext_err, " _
                    & "dbo.snics_results" & TTE & ".del_13C, dbo.snics_results" & TTE & ".sig_13c, dbo.snics_results" & TTE & ".comment, dbo.snics_results" & TTE & ".np, " _
                    & "dbo.snics_results" & TTE & ".sample_type_1, dbo.snics_results" & TTE & ".norm_method, dbo.snics_results" & TTE & ".norm_method_2" _
                    & " FROM dbo.snics_results" & TTE & "  WHERE dbo.snics_results" & TTE & ".wheel = '" & WheelName _
                    & "' ORDER BY dbo.snics_results" & TTE & ".wheel_pos;"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        NewRow = Comparison.NewRow
                        Dim nPos As Integer = rdr.GetByte(0)
                        NewRow("NP") = False        ' start by assuming it is NOT an non-performer
                        NewRow("Pos") = nPos
                        NewRow("SampleName") = TargetNames(nPos)
                        NewRow("Rec_Num") = Rec_Num(nPos)
                        NewRow("1stTyp") = rdr.GetString(1)
                        If Not rdr.IsDBNull(10) Then NewRow("1stTyp") = rdr.GetString(10)
                        NewRow("2ndTyp") = TargetTypes(nPos)
                        NewRow("1stN") = rdr.GetInt32(2)
                        NewRow("2ndN") = TargetRuns(nPos)
                        NewRow("1stNormRat") = rdr.GetDouble(3)
                        NewRow("2ndNormRat") = TargetRat(nPos)
                        NewRow("DelNormRat") = NewRow("2ndNormRat") - NewRow("1stNormRat")
                        NewRow("1stIntErr") = rdr.GetDouble(4)
                        NewRow("2ndIntErr") = IntErr(nPos)
                        NewRow("1stExtErr") = rdr.GetDouble(5)
                        NewRow("2ndExtErr") = ExtErr(nPos)
                        NewRow("SigmaC14") = NewRow("DelNormRat") / Math.Max(Math.Max(NewRow("1stIntErr"), NewRow("1stExtErr")) _
                                                , Math.Max(NewRow("2ndIntErr"), NewRow("2ndExtErr")))
                        MeanSigma += NewRow("SigmaC14")
                        If rdr.IsDBNull(8) Then
                            NewRow("Comment") = ""
                        Else
                            NewRow("Comment") = rdr.GetString(8)
                            TargetComments(nPos) = NewRow("Comment")
                        End If
                        If Not rdr.IsDBNull(9) Then
                            If rdr.GetByte(9) = 1 Then NewRow("NP") = True
                        End If
                        If rdr.GetByte(9) = 1 Then
                        End If
                        MeanAbsSigma += NewRow("SigmaC14") ^ 2
                        If Not rdr.IsDBNull(11) Then
                            TheNormMethod = rdr.GetString(11)
                        End If
                        If Not rdr.IsDBNull(12) Then
                            TheSecondNormMethod = rdr.GetString(12)
                        End If
                        'NewRow("1stDelC13") = rdr.GetDouble(5)
                        'NewRow("2ndDelC13") = TargetData.Rows(nRow).Item("DelC13")
                        'NewRow("DelDelC13") = NewRow("2ndDelC13") - NewRow("1stDelC13")
                        'NewRow("1stSigC13") = rdr.GetDouble(6)
                        'NewRow("2ndSigC13") = TargetData.Rows(nRow).Item("SigC13")
                        'NewRow("SigmaC13") = NewRow("DelDelC13") / Math.Max(NewRow("1stSigC13"), NewRow("2ndSigC13"))
                        Comparison.Rows.Add(NewRow)
                        nRow += 1
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End Using
        ColorizeCompare()
        MeanSigma /= Compare.dgvCompare.Rows.Count - 1
        MeanAbsSigma = (MeanAbsSigma / (Compare.dgvCompare.Rows.Count - 1)) ^ 0.5
        With Compare
            .Text = "SNICSer v" & VERSION.ToString("0.000") & " NORMALIZED SAMPLE COMPARISON for " & FileName
            .lblComparison.Text = "Mean SigmaC14 = " & MeanSigma.ToString("0.00") & "  (RMS = " _
                    & MeanAbsSigma.ToString("0.00") & " )"
            .lblFirstAnalyst.Text = "1st Analyst (" & TheWheel.FirstAuthName & " on " & TheWheel.FirstAuthDate.ToShortDateString & ") used " & TheNormMethod
            If TheSecondNormMethod <> "" Then
                .lblSecondAnalyst.Text = "2nd Analyst (" & TheWheel.SecondAuthName & ") " & TheWheel.SecondAuthDate.ToShortDateString & ") used " & TheSecondNormMethod
            Else
                .lblSecondAnalyst.Text = "2nd Analyst (" & UserName & ") " & Now.ToShortDateString & ") used "
                If GROUPBOUNDS Then .lblSecondAnalyst.Text &= " (Group Bounds Enforced)"
            End If
            Dim theWidth As Integer = 50 + .dgvCompare.Columns.GetColumnsWidth(DataGridViewElementStates.None)
            .Width = theWidth
            .Visible = True
        End With
    End Sub

    Private Sub DoBCComparison()
        Compare.dgvCompare.DataSource = BCComparison
        For i = 3 To BCComparison.Columns.Count - 1
            Compare.dgvCompare.Columns(i).DefaultCellStyle.Format = dFnt(NumResFigs - 3)
        Next
        Dim NewRow As DataRow
        Calculate()                       ' force a recalculation to make sure results are current
        Dim MeanSigma As Double = 0
        Dim MeanAbsSigma As Double = 0
        BCComparison.Rows.Clear()
        Dim nRow As Integer = 0
        Dim Small1 As Boolean = False
        Dim Small2 As Boolean = False
        Using con As New SqlConnection
            Try
                If (SECONDAUTH And Not REAUTH) Or (Not FIRSTAUTH And Not SECONDAUTH) Then       ' need to compare current results with first analyst
                    Dim theCmd As String = "SELECT dbo.snics_results" & TTE & ".wheel_pos,  fm_corr, sig_fm_corr, fm_mb_corr, sig_fm_mb_corr, comment, ss " _
                        & "FROM dbo.snics_results" & TTE & "  WHERE dbo.snics_results" & TTE & ".wheel = '" & WheelName _
                        & "' ORDER BY dbo.snics_results" & TTE & ".wheel_pos;"
                    con.ConnectionString = ConString
                    con.Open()
                    Dim com As IDbCommand = con.CreateCommand
                    com.CommandType = CommandType.Text
                    com.CommandText = theCmd
                    Using rdr As IDataReader = com.ExecuteReader
                        While rdr.Read
                            If Not IsDBNull(rdr.GetDouble(1)) And Not IsDBNull(rdr.GetDouble(2)) Then
                                If rdr.GetDouble(2) <> 0 Then                ' 
                                    NewRow = BCComparison.NewRow
                                    Dim nPos As Integer = rdr.GetByte(0)
                                    NewRow("Pos") = nPos
                                    NewRow("SampleName") = TargetNames(nPos)
                                    NewRow("Rec_Num") = Rec_Num(nPos)
                                    NewRow("1stFmCorr") = rdr.GetDouble(1)
                                    NewRow("1stSigFmCorr") = rdr.GetDouble(2)
                                    If TargetIsSmall(nPos) Then
                                        If rdr.GetByte(6) = 1 Then
                                            NewRow("1stFmCorr") = rdr.GetDouble(3)
                                            NewRow("1stSigFmCorr") = rdr.GetDouble(4)
                                        End If
                                        NewRow("2ndFmCorr") = FmMBCorr(nPos)
                                        NewRow("2ndSigFmCorr") = SigFmMBCorr(nPos)
                                    Else
                                        NewRow("2ndFmCorr") = FmCorr(nPos)
                                        NewRow("2ndSigFmCorr") = SigFmCorr(nPos)
                                    End If
                                    NewRow("DelFmCorr") = NewRow("2ndFmCorr") - NewRow("1stFmCorr")
                                    NewRow("SigmaFmCorr") = NewRow("DelFmCorr") / Math.Max(NewRow("1stSigFmCorr"), NewRow("2ndSigFmCorr"))
                                    NewRow("DelSigFmCorr") = NewRow("2ndSigFmCorr") - NewRow("1stSigFmCorr")
                                    If Not rdr.IsDBNull(5) Then
                                        TargetComments(nPos) = rdr.GetString(5)
                                    End If
                                    NewRow("Comment") = TargetComments(nPos)
                                    MeanSigma += NewRow("SigmaFmCorr")
                                    MeanAbsSigma += NewRow("SigmaFmCorr") ^ 2
                                    BCComparison.Rows.Add(NewRow)
                                    nRow += 1
                                End If
                            End If
                        End While
                    End Using
                ElseIf (FIRSTAUTH And REAUTH) Or (SECONDAUTH And REAUTH) Then     ' need to work from database only
                    Dim theCmd As String = "SELECT dbo.snics_results" & TTE & ".wheel_pos,  fm_corr, sig_fm_corr, fm_mb_corr, sig_fm_mb_corr," _
                                            & "fm_corr_2, sig_fm_corr_2, fm_mb_corr_2, sig_fm_mb_corr_2, comment, ss, ss_2 " _
                                            & "FROM dbo.snics_results" & TTE & "  WHERE dbo.snics_results" & TTE & ".wheel = '" & WheelName _
                                            & "' ORDER BY dbo.snics_results" & TTE & ".wheel_pos;"
                    con.ConnectionString = ConString
                    con.Open()
                    Dim com As IDbCommand = con.CreateCommand
                    com.CommandType = CommandType.Text
                    com.CommandText = theCmd
                    Using rdr As IDataReader = com.ExecuteReader
                        While rdr.Read
                            If Not IsDBNull(rdr.GetDouble(1)) And Not IsDBNull(rdr.GetDouble(2)) Then
                                If rdr.GetDouble(2) <> 0 Then   ' never get zero uncertainty on a blank corrected result
                                    If Not rdr.IsDBNull(10) Then Small1 = (rdr.GetByte(10) = 1)
                                    If Not rdr.IsDBNull(11) Then Small2 = (rdr.GetByte(11) = 1)
                                    NewRow = BCComparison.NewRow
                                    Dim nPos As Integer = rdr.GetByte(0)
                                    NewRow("Pos") = nPos
                                    NewRow("SampleName") = TargetNames(nPos)
                                    NewRow("Rec_Num") = Rec_Num(nPos)
                                    NewRow("1stFmCorr") = rdr.GetDouble(1)
                                    NewRow("1stSigFmCorr") = rdr.GetDouble(2)
                                    If Small1 Then     ' if there, then it must be small!
                                        NewRow("1stFmCorr") = rdr.GetDouble(3)
                                        NewRow("1stSigFmCorr") = rdr.GetDouble(4)
                                    End If
                                    NewRow("2ndFmCorr") = rdr.GetDouble(5)
                                    NewRow("2ndSigFmCorr") = rdr.GetDouble(6)
                                    If Small2 Then     ' if there, then it must be small!
                                        NewRow("2ndFmCorr") = rdr.GetDouble(7)
                                        NewRow("2ndSigFmCorr") = rdr.GetDouble(8)
                                    End If
                                    NewRow("DelFmCorr") = NewRow("2ndFmCorr") - NewRow("1stFmCorr")
                                    NewRow("SigmaFmCorr") = NewRow("DelFmCorr") / Math.Max(NewRow("1stSigFmCorr"), NewRow("2ndSigFmCorr"))
                                    NewRow("DelSigFmCorr") = NewRow("2ndSigFmCorr") - NewRow("1stSigFmCorr")
                                    If Not rdr.IsDBNull(9) Then
                                        TargetComments(nPos) = rdr.GetString(9)
                                    End If
                                    NewRow("Comment") = TargetComments(nPos)
                                    MeanSigma += NewRow("SigmaFmCorr")
                                    MeanAbsSigma += NewRow("SigmaFmCorr") ^ 2
                                    BCComparison.Rows.Add(NewRow)
                                    nRow += 1
                                End If
                            End If
                        End While
                    End Using
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End Using
        ColorizeBCCompare()
        MeanSigma /= Compare.dgvCompare.Rows.Count - 1
        MeanAbsSigma = (MeanAbsSigma / (Compare.dgvCompare.Rows.Count - 1)) ^ 0.5
        With Compare
            Dim theWidth As Integer = 50 + .dgvCompare.Columns.GetColumnsWidth(DataGridViewElementStates.None)
            .Text = "SNICSer v" & VERSION.ToString("0.000") & " MASS BALANCE BLANK CORRECTED COMPARISON for " & FileName
            .lblComparison.Text = "Mean SigmaC14 = " & MeanSigma.ToString("0.00") & "  (RMS = " _
                    & MeanAbsSigma.ToString("0.00") & " )"
            .Width = theWidth
            .Visible = True
        End With

    End Sub

    Public Sub CompareTheFlags()
        CompareFlags.dgvFlags.DataSource = FlagTable
        CompareFlags.Visible = True
        CompareFlags.Text = "Flag comparison for " & WheelName & " ( " & TheWheel.FirstAuthName & " vs " & TheWheel.SecondAuthName & " )"
        Dim RunNums(MAXTARGETS) As Integer
        Dim theCmd As String = ""
        For i = 0 To RunNums.Length - 1
            RunNums(i) = 0
        Next
        Dim iPos As Integer = -1
        Dim iFirst As Integer = 0, iSecond As Integer = 0
        FlagTable.Rows.Clear()
        FlagTable.Columns.Clear()
        FlagTable.Columns.Add("Pos", GetType(Integer))
        FlagTable.Columns.Add("SampleName", GetType(String))
        For i = 1 To TotalRuns.Max
            FlagTable.Columns.Add(i.ToString, GetType(String))
        Next
        With CompareFlags
            For i = 0 To .dgvFlags.Columns.Count - 1
                .dgvFlags.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            .dgvFlags.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            For i = 0 To MAXTARGETS
                'If TargetIsPresent(i) Then
                'Dim ipos As Integer = TargetData(i).Item("Pos")
                FlagTable.Rows.Add(i, TargetNames(i))
                '.dgvFlags.Rows(i).DefaultCellStyle.BackColor = dgvTargets.Rows(i).DefaultCellStyle.BackColor
                'End If

            Next
        End With
        Using con As New SqlConnection
            Try
                theCmd = "SELECT DISTINCT run_num, ok_calc, ok_calc_2, wheel_pos" _
                    & " FROM dbo.snics_raw" & TTE & " WHERE wheel = '" & WheelName & "' ORDER BY run_num;"
                con.ConnectionString = ConString
                con.Open()
                Dim com As IDbCommand = con.CreateCommand
                com.CommandType = CommandType.Text
                com.CommandText = theCmd
                Using rdr As IDataReader = com.ExecuteReader
                    While rdr.Read
                        If Not rdr.IsDBNull(1) And Not rdr.IsDBNull(2) Then
                            iPos = rdr.GetByte(3)
                            RunNums(iPos) += 1              ' increment the run count

                            FlagTable(iPos).Item(RunNums(iPos).ToString) = "X"
                            iFirst = rdr.GetByte(1)
                            iSecond = rdr.GetByte(2)
                            Select Case iFirst + iSecond
                                Case 0
                                    CompareFlags.dgvFlags.Rows(iPos).Cells(RunNums(iPos).ToString).Style.BackColor = Color.DarkGray
                                Case 2
                                    CompareFlags.dgvFlags.Rows(iPos).Cells(RunNums(iPos).ToString).Style.BackColor = Color.SeaShell
                                Case 1
                                    If iFirst = 1 Then
                                        CompareFlags.dgvFlags.Rows(iPos).Cells(RunNums(iPos).ToString).Style.BackColor = Color.Blue
                                    Else
                                        CompareFlags.dgvFlags.Rows(iPos).Cells(RunNums(iPos).ToString).Style.BackColor = Color.Red
                                    End If
                            End Select
                        End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & theCmd)
            End Try
            con.Close()
        End Using
        For i = 0 To CompareFlags.dgvFlags.Rows.Count - 1
            If RunNums(i) <= 0 Then
                CompareFlags.dgvFlags.Rows.Item(i).Visible = False
            End If
        Next

    End Sub


#End Region  'retrieve data from and deposit data to database

#Region "Report Printing"

    Private Sub PrintFudgerStyleReport()
        chkSecondaries.Checked = True
        chkStandards.Checked = True
        chkBlanks.Checked = True
        chkUnknowns.Checked = True
        Calculate()                       ' force a recalculation to ensure that the results are current
        sfdPrintFile.DefaultExt = "xls"
        sfdPrintFile.CheckFileExists = False
        Try
            FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Input)
            sfdPrintFile.InitialDirectory = LineInput(1)
            FileClose(1)
        Catch ex As Exception
            ' do nothing
        End Try
        sfdPrintFile.FileName = WheelName & "_Fudger"
        sfdPrintFile.ShowDialog()
        OutFileName = sfdPrintFile.FileName
        Try
            FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Output)
            PrintLine(1, My.Computer.FileSystem.GetFileInfo(OutFileName).DirectoryName)
            FileClose(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            FileOpen(2, OutFileName, OpenMode.Output)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim outStr As String = "SNICSr V" & VERSION.ToString("0.000") & vbTab & vbTab & WheelName & vbTab & vbCrLf _
                                   & "Data Analyzed by " & UserName & vbTab & vbTab & Now.ToString("HH:mm ddd, MMM dd, yyyy")
            PrintLine(2, outStr)            ' print header line
            outStr = "Normalized to " & Options.cmbFitType.Text & " of " & Options.nudNumStds.Value.ToString & " nearest accepted standards"
            PrintLine(2, outStr)                   ' then a formatting space
            outStr = "Pos." & vbTab & "Sample" & vbTab & "Rpts" & vbTab & "Ratio to STD" & vbTab & "Int Err" _
                & vbTab & "Ext Err" & vbTab & "del13C to STD" & vbTab & "del 13C Int. error" & vbTab & "del13C Ext. error"
            PrintLine(2, outStr)
            ChngType.ResetTargetTable()         ' make sure we have the fully monty
            'MsgBox(TargetData.Rows.Count.ToString & " Saved to Fudger-type File")
            For i = 0 To TargetData.Rows.Count - 1
                If Trim(TargetData.Rows(i).Item("Typ")) = "S" Then
                    PrintLine(2, FudgerLine(i))
                End If
            Next
            For i = 0 To TargetData.Rows.Count - 1
                If Trim(TargetData.Rows(i).Item("Typ")) <> "S" Then
                    PrintLine(2, FudgerLine(i))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileClose(2)

    End Sub

    Private Sub PrintDatabaseImportFile(ByVal GroupNum As Integer)
        Try
            chkSecondaries.Checked = True
            chkStandards.Checked = True
            chkBlanks.Checked = True
            chkUnknowns.Checked = True
            Calculate()                       ' force a recalculation to ensure that the results are current
            sfdPrintFile.DefaultExt = "xls"
            sfdPrintFile.CheckFileExists = False
            Try
                FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Input)
                sfdPrintFile.InitialDirectory = LineInput(1)
                FileClose(1)
            Catch ex As Exception
                ' do nothing
            End Try
            sfdPrintFile.FileName = WheelName & "_Database"
            If GroupNum <> 0 Then sfdPrintFile.FileName &= "_Group" & GroupNum.ToString
            sfdPrintFile.ShowDialog()
            OutFileName = sfdPrintFile.FileName
            Try
                FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Output)
                PrintLine(1, My.Computer.FileSystem.GetFileInfo(OutFileName).DirectoryName)
                FileClose(1)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                FileOpen(2, OutFileName, OpenMode.Output)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                Dim outStr As String = "SNICSr V" & VERSION.ToString("0.000") & vbTab & vbTab & WheelName & vbTab & vbCrLf _
                                       & "Data Analyzed by " & UserName & vbTab & vbTab & Now.ToString("HH:mm ddd, MMM dd, yyyy")
                PrintLine(2, outStr)            ' print header line
                outStr = "Normalized to " & Options.cmbFitType.Text & " of " & Options.nudNumStds.Value.ToString & " nearest accepted standards"
                PrintLine(2, outStr)                   ' then a formatting space
                outStr = "Pos." & vbTab & "Sample" & vbTab & "Rpts" & vbTab & "Ratio to STD" & vbTab & "Int Err" _
                    & vbTab & "Ext Err" & vbTab & "del13C to STD" & vbTab & "del 13C Int. error" & vbTab & "del13C Ext. error" _
                    & vbTab & "DelC13" & vbTab & "SigC13"
                PrintLine(2, outStr)
                ChngType.ResetTargetTable()         ' make sure we have the fully monty
                'MsgBox(TargetData.Rows.Count.ToString & " Saved to Fudger-type File")
                For i = 0 To TargetData.Rows.Count - 1
                    If Trim(TargetData.Rows(i).Item("Typ")) = "S" Then
                        PrintLine(2, DatabaseFileLine(i))
                    End If
                Next
                For i = 0 To TargetData.Rows.Count - 1
                    If Trim(TargetData.Rows(i).Item("Typ")) <> "S" Then
                        PrintLine(2, DatabaseFileLine(i))
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            FileClose(2)
            tspWriteDatabaseImportFile.Visible = False
        Catch ex As Exception
            MsgBox("There may have been a problem writing the database file" _
                   & vbCrLf & "Please check to make sure you don't have it open in another application" _
                   & vbCrLf & "And try again using the File -> Write Database File option")
            tspWriteDatabaseImportFile.Visible = True
        End Try
    End Sub

    Private Function FudgerLine(iPos As Integer) As String
        With TargetData.Rows(iPos)
            Dim nPos As Integer = .Item("Pos")
            FudgerLine = .Item("Pos") & vbTab & .Item("SampleName") & vbTab & .Item("N") & vbTab & .Item("NormRat") & vbTab _
                & .Item("IntErr") & vbTab & .Item("ExtErr") & vbTab & .Item("DelC13") & vbTab & (1000.0 * SigC13IntErr(nPos)).ToString("0.000") _
                & vbTab & (1000.0 * SigC13(nPos)).ToString("0.000")
        End With
    End Function

    Private Function DatabaseFileLine(ipos As Integer) As String
        With TargetData.Rows(ipos)
            Dim nPos As Integer = .Item("Pos")
            DatabaseFileLine = .Item("Pos") & vbTab & .Item("SampleName") & vbTab & .Item("N") & vbTab _
                    & FmCorr(nPos).ToString("0.000000") & vbTab & .Item("IntErr") & vbTab & SigFmCorr(nPos).ToString("0.000000") _
                    & vbTab & .Item("DelC13") & vbTab & (1000.0 * SigC13IntErr(nPos)).ToString("0.000") _
                    & vbTab & (1000.0 * SigC13(nPos)).ToString("0.000") & vbTab & FmMBCorr(nPos).ToString("0.000000") & vbTab & SigFmMBCorr(nPos).ToString("0.000000")
        End With
    End Function

    Private Sub MakeSimpleReport()
        sfdPrintFile.DefaultExt = "xls"
        sfdPrintFile.CheckFileExists = False
        Try
            FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Input)
            sfdPrintFile.InitialDirectory = LineInput(1)
            FileClose(1)
        Catch ex As Exception
            ' do nothing
        End Try
        sfdPrintFile.FileName = WheelName & "_Results"
        sfdPrintFile.ShowDialog()
        OutFileName = sfdPrintFile.FileName
        Try
            FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Output)
            PrintLine(1, My.Computer.FileSystem.GetFileInfo(OutFileName).DirectoryName)
            FileClose(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            FileOpen(2, OutFileName, OpenMode.Output)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim outStr As String = "SNICSr V" & VERSION.ToString("0.000") & vbTab & vbTab & WheelName & vbTab & vbTab & UserName _
                      & vbTab & vbTab & Now.ToString("HH:mm ddd, MMM dd, yyyy")
            PrintLine(2, outStr)            ' print header line
            PrintLine(2)                    ' then a formatting space
            outStr = vbTab & vbTab & vbTab & vbTab & "Receipt" & vbTab & "Measured" & vbTab & vbTab & vbTab _
                & vbTab & "Norm" & vbTab & "StdDev" & vbTab & vbTab & vbTab & "Bkgnd" & vbTab & vbTab & "Std Blk Corr" _
                & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "Expected"
            PrintLine(2, outStr)
            FileClose(2)
            dgvTargets.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dgvTargets.SelectAll()
            IO.File.AppendAllText(OutFileName, dgvTargets.GetClipboardContent().GetText.TrimEnd)
            dgvTargets.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileClose(2)
    End Sub

    Private Function TargetTableLine(ipos As Integer) As String
        Dim theLine As String = TargetData.Rows(ipos).Item(0).ToString
        For i = 1 To TargetData.Columns.Count - 1
            theLine &= vbTab & TargetData.Rows(ipos).Item(i).ToString
        Next
        Return theLine
    End Function

    Private Sub tsmPrintTargetTable_Click(sender As Object, e As EventArgs) Handles tsmPrintTargetTable.Click
        Try
            chkSecondaries.Checked = True
            chkStandards.Checked = True
            chkBlanks.Checked = True
            chkUnknowns.Checked = True
            Calculate()                       ' force a recalculation to ensure that the results are current
            sfdPrintFile.DefaultExt = "xls"
            sfdPrintFile.CheckFileExists = False
            Try
                FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Input)
                sfdPrintFile.InitialDirectory = LineInput(1)
                FileClose(1)
            Catch ex As Exception
                ' do nothing
            End Try
            sfdPrintFile.FileName = WheelName & "_TargetTable"
            sfdPrintFile.ShowDialog()
            OutFileName = sfdPrintFile.FileName
            Try
                FileOpen(1, MySNICSerDir & "/SNICSer.outdir", OpenMode.Output)
                PrintLine(1, My.Computer.FileSystem.GetFileInfo(OutFileName).DirectoryName)
                FileClose(1)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                FileOpen(2, OutFileName, OpenMode.Output)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                Dim theLine = "NonPerf"
                For icol = 1 To TargetData.Columns.Count - 1
                    theLine &= vbTab & TargetData.Columns(icol).Caption
                Next
                PrintLine(2, theLine)
                For ipos = 0 To TargetData.Rows.Count - 1
                    PrintLine(2, TargetTableLine(ipos))
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            FileClose(2)
        Catch ex As Exception
            MsgBox("There may have been a problem writing the target table file" _
                   & vbCrLf & "Please check to make sure you don't have it open in another application" _
                   & vbCrLf & "And try again using the File -> Print Target Table option")
        End Try

    End Sub


#End Region ' report generation (file based)

#Region "Event Handlers"

#Region "DataGridView Clicks"

    Private Sub dgvInputData_CurrentCellDirtyStateChanged(sender As System.Object, e As EventArgs) Handles dgvInputData.CurrentCellDirtyStateChanged
        If dgvInputData.IsCurrentCellDirty Then
            dgvInputData.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvInputData_CellValueChanged_(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInputData.CellValueChanged
        DeBlankCorr()             ' make sure you have to blank correct again
        For i = 0 To RunsData.Rows.Count - 1
            If RunsData.Rows(i).Item("Run") = e.RowIndex Then
                RunsData.Rows(i).Item("OK") = InputData.Rows(e.RowIndex).Item("OK")
            End If
        Next
        ReCountRuns(InputData.Rows(e.RowIndex).Item("Pos"))
        If chkDoCalc.Checked Then Calculate()
        If dgvRuns.Visible Then PlotRuns()
    End Sub

    Private Sub dgvInputData_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInputData.ColumnHeaderMouseClick
        Dim varSelected As Integer = 0
        varSelected = e.ColumnIndex
        If varSelected > 7 Then
            DoRawPlot(varSelected)
            RawCol = varSelected
        End If
    End Sub

    Private Sub dgvTargets_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTargets.CellContentDoubleClick
        GetTargetInfo()
    End Sub

    Private Sub dgvTargets_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTargets.RowHeaderMouseDoubleClick
        GetTargetInfo()
    End Sub

    Private Sub dgvTargets_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvTargets.CurrentCellDirtyStateChanged
        If dgvTargets.IsCurrentCellDirty Then
            dgvTargets.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvTargets_Sorted(sender As System.Object, e As System.EventArgs) Handles dgvTargets.Sorted
        ColorizeTargets()
    End Sub

    Private Sub dgvTargets_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTargets.CellClick   ' dgvTargets.CellContentClick, 
        If e.RowIndex >= 0 Then
            If e.ColumnIndex > 0 Then
                If e.ColumnIndex = 4 Then
                    With ChngType
                        .theRow = e.RowIndex
                        .thePos = TargetData(.theRow).Item("Pos")
                        .theName = TargetData(.theRow).Item("SampleName")
                        .theType = TargetData(.theRow).Item("Typ")
                        .lblFrom.Text = "From Type " & .theType
                        .lblSampleID.Text = "Pos " & .thePos.ToString & ": " & .theName & "   (Type " & .theType & ")"
                        .cmbType.Text = .theType
                        .txtSmpName.Text = .theName
                        .txtComment.Text = TargetComments(.thePos)
                        .lbxFrom.Items.Clear()
                        .lbxTo.Items.Clear()
                        .btnExecute.Visible = False
                        For i = 0 To dgvTargets.Rows.Count - 1
                            If TargetData(i).Item("Typ") = .theType Then
                                Dim thePos As Integer = TargetData(i).Item("Pos")
                                .lbxFrom.Items.Add(thePos.ToString("000") & ": " & TargetData(i).Item("SampleName"))
                            End If
                        Next
                        .Visible = True
                        .Width = 450
                        .BringToFront()
                        DeBlankCorr()             ' make sure you have to blank correct again
                    End With
                Else
                    PopRuns(TargetData(e.RowIndex).Item("Pos"))
                End If
            Else        ' must be designating/clearing a non performer!
                TargetNonPerf(TargetData(e.RowIndex).Item("Pos")) = Not TargetNonPerf(TargetData(e.RowIndex).Item("Pos"))
                TargetData(e.RowIndex).Item("NP") = TargetNonPerf(TargetData(e.RowIndex).Item("Pos"))
                ColorizeTargets()
                DeBlankCorr()             ' make sure you have to blank correct again
            End If
        End If
    End Sub

    Private Sub dgvTargets_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTargets.RowHeaderMouseClick
        PopRuns(TargetData(e.RowIndex).Item("Pos"))
        'Worms.Visible = False          ' don't show plot when just row header clicked
    End Sub

    Private Sub dgvTargets_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTargets.ColumnHeaderMouseClick
        If TargetData.Columns.Count - e.ColumnIndex < 4 Then PlotDelC13s()
    End Sub

    Private Sub chkTargets_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStandards.CheckedChanged, _
                    chkBlanks.CheckedChanged, chkSecondaries.CheckedChanged, chkUnknowns.CheckedChanged
        DeBlankCorr()             ' make sure you have to blank correct again
        If Not FirstTimeThrough And Not IamBatching Then RePopulateTargets()
    End Sub

    Private Sub dgvRuns_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgvRuns.CurrentCellDirtyStateChanged
        If dgvRuns.IsCurrentCellDirty Then
            dgvRuns.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvRuns_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRuns.CellValueChanged
        DeBlankCorr()             ' make sure you have to blank correct again
        Dim theState As Boolean = RunsData.Rows(e.RowIndex).Item(0)
        Dim theRun As Integer = RunsData.Rows(e.RowIndex).Item(2)
        InputData.Rows(theRun).Item(0) = theState
        ReCountRuns(InputData.Rows(theRun).Item("Pos"))
        If chkDoCalc.Checked Then Calculate()
        PlotRuns()
    End Sub

    Private Sub dgvRuns_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvRuns.RowHeaderMouseClick
        '   If you click the row header here, you get a list of the standard runs used in normalizing that run
        Dim theList(24) As Integer        ' contains the list of urns
        Dim iRun As Integer = RunsData.Rows(e.RowIndex).Item("Run")
        FindNearestStandards(iRun, CalcNum, theList)
        With NormTable
            .Clear()
            .Columns.Clear()
            .Columns.Add("Run", GetType(Integer))
            .Columns.Add("Pos", GetType(Integer))
            .Columns.Add("SampleName", GetType(String))
            .Columns.Add("Corr14/12", GetType(Double))
            .Columns.Add("DelRun", GetType(Integer))
            .Columns.Add("DelTime", GetType(String))
            For i = 0 To CalcNum + 1
                .Rows.Add(theList(i), InputData.Rows(theList(i)).Item("Pos"), InputData.Rows(theList(i)).Item("SampleName"), _
                          InputData.Rows(theList(i)).Item("Corr14/12"), theList(i) - iRun, (CDbl((iRunTimes(theList(i)) - iRunTimes(iRun))) / 60).ToString("0.00"))
            Next
        End With
        With frmNorm
            .Visible = True
            .TopMost = True
            .dgvNorm.DataSource = NormTable
            For i = 0 To .dgvNorm.Columns.Count - 1
                .dgvNorm.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            .dgvNorm.Columns("Corr14/12").DefaultCellStyle.Format = "0.000e+0"
            For i = .dgvNorm.Rows.Count - 2 To .dgvNorm.Rows.Count - 1
                .dgvNorm.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            Next
            For i = 0 To .dgvNorm.Rows.Count - 1
                .dgvNorm.Rows(i).Cells("DelRun").Style.Font = New Font(.dgvNorm.Font, FontStyle.Bold)
                .dgvNorm.Rows(i).Cells("DelTime").Style.Font = New Font(.dgvNorm.Font, FontStyle.Bold)
                If NormTable.Rows(i).Item("DelRun") < 0 Then
                    .dgvNorm.Rows(i).Cells("DelRun").Style.ForeColor = Color.DarkBlue
                    .dgvNorm.Rows(i).Cells("DelTime").Style.ForeColor = Color.DarkBlue
                Else
                    .dgvNorm.Rows(i).Cells("DelRun").Style.ForeColor = Color.DarkRed
                    .dgvNorm.Rows(i).Cells("DelTime").Style.ForeColor = Color.DarkRed
                End If
            Next
            .dgvNorm.AutoSize = True
            .Text = CalcMode & " of " & CalcNum.ToString & " for run " & iRun.ToString
            .lblMethod.Text = lblRuns.Text
            Dim dgvWidth As Integer = 0
            For i = 0 To .dgvNorm.Columns.Count - 1
                dgvWidth += .dgvNorm.Columns(i).Width
            Next
            .dgvNorm.Width = dgvWidth + 5
            .Width = .dgvNorm.Width + 10
            Dim dgvHeight As Integer = 0
            For i = 0 To .dgvNorm.Rows.Count - 1
                dgvHeight += .dgvNorm.Rows(i).Height
            Next
            .dgvNorm.Height = dgvHeight + 20
            .Height = .dgvNorm.Height + 30
        End With
    End Sub

    Private Sub dgvSecs_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSecs.RowHeaderMouseClick
        Dim posn As Integer = SecsValues(e.RowIndex).Item("Pos")
        PopRuns(posn)
    End Sub



#End Region

#Region "Button Clicks"

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        IAMINSPECTING = False
        Dim ans As MsgBoxResult = vbNo
        If btnLoad.Text <> "Load" Then
            ans = MsgBox("Do you want to save your data before re-loading?", MsgBoxStyle.YesNoCancel)
            If ans = vbCancel Then Exit Sub
            If ans = vbYes Then DoSave()
        End If
        doLoad()
        If WheelName <> "" Then tsmFillInC13Table.Visible = True
        PropertyPropertyToolStripMenuItem.Enabled = True
    End Sub

    Private Sub btnPlotStandards_Click(sender As System.Object, e As System.EventArgs) Handles btnPlotStandards.Click, cmbPlot.SelectedIndexChanged
        IamBatching = True          ' set this flag to make sure that it doesn't update every checkbox change
        Select Case cmbPlot.Text
            Case "Standards"
                chkStandards.Checked = True     ' just showing standards
                chkBlanks.Checked = False       ' not blanks
                chkSecondaries.Checked = False      ' and not secondaries
                chkUnknowns.Checked = False     '  and not unknowns
            Case "Blanks"
                chkStandards.Checked = False    ' just showing standards
                chkBlanks.Checked = True       ' not blanks
                chkSecondaries.Checked = False      ' and not secondaries
                chkUnknowns.Checked = False     '  and not unknowns
            Case "Secondaries"
                chkStandards.Checked = False     ' just showing standards
                chkBlanks.Checked = False       ' not blanks
                chkSecondaries.Checked = True      ' and not secondaries
                chkUnknowns.Checked = False     '  and not unknowns
            Case "Unknowns"
                chkStandards.Checked = False     ' just showing standards
                chkBlanks.Checked = False       ' not blanks
                chkSecondaries.Checked = False      ' and not secondaries
                chkUnknowns.Checked = True     '  and not unknowns
            Case Else
                chkStandards.Checked = True     ' just showing standards
                chkBlanks.Checked = True       ' not blanks
                chkSecondaries.Checked = True      ' and not secondaries
                chkUnknowns.Checked = True     '  and not unknowns
        End Select
        IamBatching = False             ' now OK to update on click
        RePopulateTargets()               ' now update the table!
        If TargetData.Rows.Count > 0 Then
            PopRuns(TargetData(0).Item("Pos"))
            Worms.Focus()
        End If
    End Sub

    Public Sub CheckAllTargets()
        IamBatching = True          ' set this flag to make sure that it doesn't update every checkbox change
        chkStandards.Checked = True     ' just showing standards
        chkBlanks.Checked = True       ' not blanks
        chkSecondaries.Checked = True     ' and not secondaries
        chkUnknowns.Checked = True     '  and not unknowns
        IamBatching = False             ' now OK to update on click
        RePopulateTargets()               ' now update the table!
    End Sub

    Private Sub btnCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculate.Click
        Calculate()
    End Sub

    Private Sub btnPlotAllStds_Click(sender As System.Object, e As System.EventArgs) Handles btnPlotAllStds.Click
        DoWormPlots()     ' wrap it up with dowormplots so can be called programmatically
    End Sub

    Public Sub DoWormPlots()
        SelectedTarget = -1     ' deselect any target number for point toggling
        With Worms
            .btnPrev.Visible = False
            .btnNext.Visible = False
            .btnPrev2.Visible = False
            .btnNext2.Visible = False
            .btnPlotBlks.Visible = False
            .btnPlotStds.Visible = False
            .chkOverlay.Visible = False
            .cmbGoTo.Visible = False
            .rdbBlk.Visible = True
            .rdbStd.Visible = True
        End With
        NumPlots = 0
        For i = 0 To MAXTARGETS
            If TargetTypes(i) = WormType Then
                PlotList(NumPlots) = i
                NumPlots += 1
            End If
        Next
        PlotWorms()
    End Sub

    Private Sub DoSave()
        Dim OutFileName As String = WheelName & "R." & UserName
        FileHeader(1) = WheelName
        sdfSaveFile.FileName = WheelName & "R." & UserName
        'sdfSaveFile.InitialDirectory = MySNICSerDir
        If sdfSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                FileOpen(1, sdfSaveFile.FileName, OpenMode.Output)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            FileHeader(4) = "Analyzed using SNICSer v" & VERSION.ToString("0.00") & " by " & UserName & " " & Now.ToShortTimeString & " " & Now.ToLongDateString
            FileHeader(5) = InputData.Columns(0).ColumnName
            For i = 1 To InputData.Columns.Count - 1
                FileHeader(5) &= vbTab & InputData.Columns(i).ColumnName
            Next
            For i = 1 To 6
                PrintLine(1, FileHeader(i))
            Next
            Dim ncomms As Integer = 0
            For i = 0 To NumTargets - 1
                If Trim(TargetComments(i)) <> "" Then ncomms += 1
            Next
            PrintLine(1, ncomms.ToString)
            If ncomms > 0 Then
                For i = 0 To NumTargets - 1
                    If Trim(TargetComments(i)) <> "" Then
                        Print(1, i.ToString & vbTab)
                        PrintLine(1, Trim(TargetComments(i)))
                    End If
                Next
            End If
            For i = 0 To InputData.Rows.Count - 1
                For j = 0 To InputData.Columns.Count - 1
                    Print(1, InputData(i).Item(j).ToString & vbTab)
                Next
                Print(1, Samp_Typ(i).ToString & vbCrLf)
            Next
            FileClose(1)
            MsgBox("Your work was saved to " & vbCrLf & sdfSaveFile.FileName)
        End If
    End Sub

#End Region

    Private Sub lblRuns_Click(sender As System.Object, e As System.EventArgs) Handles lblRuns.Click
        GetTargetInfo()
    End Sub

    Public Sub Plot_PrintPage(ByVal sender As Object, e As PrintPageEventArgs)
        Dim Heading1 As String = "Plotted by " & UserName
        Dim Heading2 As String = "at " & Now.ToShortTimeString & " on " & Now.ToLongDateString
        Using fnt As New Font("Arial", 14)
            e.Graphics.DrawString(Heading1, fnt, Brushes.Black, 100, 20)
            e.Graphics.DrawString(Heading2, fnt, Brushes.Black, 400, 20)
        End Using
        Dim pltWid As Integer = thePlot.Width
        Dim pltHgt As Integer = thePlot.Height
        Dim sFact As Double = 1.0
        If pltWid > 750 Then            ' preserve aspect ratio and ensure that plot fits on page
            sFact = 750 / pltWid
            pltWid = sFact * pltWid
            pltHgt = pltHgt * sFact
            If pltHgt > 900 Then
                sFact = 900 / pltHgt
                pltHgt = sFact * pltHgt
                pltWid = pltWid * sFact
            End If
        End If
        e.Graphics.DrawImage(thePlot, 50, 70, pltWid, pltHgt)

    End Sub

    Private Sub AggregateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        PlotWorms()
    End Sub

    Private Sub chkDoCalc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDoCalc.CheckedChanged
        If chkDoCalc.Checked And Not FirstTimeThrough Then
            Calculate()
        End If
    End Sub

    Private Sub StandardsAndBlanksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StandardsAndBlanksToolStripMenuItem.Click
        StdsAndBlks.Visible = True
    End Sub

    Private Sub tsmSave_Click(sender As System.Object, e As System.EventArgs) Handles tsmSave.Click
        Calculate()                       ' force a recalculation to make sure results are current
        DoSave()
    End Sub

    Private Sub TargetInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TargetInfoToolStripMenuItem.Click
        PresentTargetInfo()
    End Sub

    Private Sub TargetTableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TargetTableToolStripMenuItem.Click
        Calculate()         ' force a recalculation to ensure that the results are current
        sfdPrintFile.DefaultExt = "xls"
        sfdPrintFile.CheckFileExists = False
        Try
            FileOpen(1, HomeDirectory & "/SNICSer.outdir", OpenMode.Input)
            sfdPrintFile.InitialDirectory = LineInput(1)
            FileClose(1)
        Catch ex As Exception
            ' do nothing
        End Try
        sfdPrintFile.FileName = WheelName & "_Targets"
        sfdPrintFile.ShowDialog()
        OutFileName = sfdPrintFile.FileName
        Try
            FileOpen(1, HomeDirectory & "/SNICSer.outdir", OpenMode.Output)
            PrintLine(1, My.Computer.FileSystem.GetFileInfo(OutFileName).DirectoryName)
            FileClose(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            FileOpen(2, OutFileName, OpenMode.Output)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim outStr As String = "SNICSr V" & VERSION.ToString("0.000") & vbTab & vbTab & WheelName & vbTab & vbTab & UserName _
                      & vbTab & vbTab & Now.ToString("HH:mm ddd, MMM dd, yyyy")
            If Not GROUPBOUNDS Then outStr &= vbTab & vbTab & "Group Bounds Disabled"
            PrintLine(2, outStr)            ' print header line
            PrintLine(2)                    ' then a formatting space
            ChngType.ResetTargetTable()         ' make sure we have the fully monty
            outStr = TargetData.Columns(0).ColumnName
            For i = 1 To TargetData.Columns.Count - 1
                outStr &= vbTab & TargetData.Columns(i).ColumnName
            Next
            PrintLine(2, outStr)
            For i = 0 To TargetData.Rows.Count - 1
                outStr = TargetData.Rows(i).Item(0).ToString
                For j = 1 To TargetData.Columns.Count - 1
                    outStr &= vbTab & TargetData.Rows(i).Item(j).ToString
                Next
                PrintLine(2, outStr)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileClose(2)
    End Sub

    Private Sub FudgerStyleReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FudgerStyleReportToolStripMenuItem.Click
        PrintFudgerStyleReport()
    End Sub

    Private Sub CommentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommentToolStripMenuItem.Click
        PresentTargetInfo()
    End Sub

#Region "Menu Hits"

    Private Sub tsmCommit_Click(sender As System.Object, e As System.EventArgs) Handles tsmCommit.Click
        Calculate()                       ' force a recalculation to make sure results are current
        If Not ISACQUIFILE Then CommitToDatabase()
    End Sub

    Private Sub tsmBlankCorrect_Click(sender As Object, e As EventArgs) Handles tsmBlankCorrect.Click
        If frmBlankCorr.chkLockAll.Checked Then
            Dim iret As MsgBoxResult = MsgBox("Do you wish to recalculate the blank corrections" _
                                              & vbCrLf & "Or leave them the same?" & vbCrLf _
                                              & "(Clicking YES will recalculate)", MsgBoxStyle.YesNo)
            If iret = MsgBoxResult.Yes Then frmBlankCorr.chkLockAll.Checked = False
        End If
        CountFlags()
        CheckAllTargets()
        With frmBlankCorr
            .Visible = True
            If Not False Then           'BLANKCORRECTED Then
                .tbcGroups.TabPages.Clear()
                AddBlkCorrColumns(.tblStandards, .dgvStandards)
                AddBlkCorrColumns(.tblBlanks, .dgvBlanks)
                SetUpBlankTables()
                .dgvStandards.Top = .dgvInorganic.Bottom + 10
                .lblStandards.Top = .dgvStandards.Top - .lblStandards.Height - 3
                .dgvBlanks.Top = .dgvStandards.Bottom + 5
                .tbcGroups.Top = .dgvBlanks.Bottom + 5
                .tbcGroups.Width = .Width - 10
                SetUpBlankBlankTable()
                SetUpStandardsBlankTables()
                AssignGroupsToTargets()         ' figure out what targets are in what groups
                .tbcGroups.Width = .dgvStandards.Width + 10
                DoGroupBlankTables()
                .Width = .dgvBlanks.Columns.GetColumnsWidth(DataGridViewElementStates.None) + 45
                If REAUTH Then
                    For iPos = 0 To NumTargets - 1
                        With .tblStandards
                            For i = 0 To .Rows.Count - 1
                                With .Rows(i)
                                    If .Item("Pos") = iPos Then
                                        .Item("Fm_Corr") = FmCorr(iPos)
                                        .Item("Sig_Fm_Corr") = SigFmCorr(iPos)
                                        .Item("Fm_Bgnd") = LgBlkFm(iPos)
                                        .Item("SigFmBgnd") = SigLgBlkFm(iPos)
                                    End If
                                End With
                            Next
                        End With
                        With .tblBlanks
                            For i = 0 To .Rows.Count - 1
                                With .Rows(i)
                                    If .Item("Pos") = iPos Then
                                        .Item("Fm_Corr") = FmCorr(iPos)
                                        .Item("Sig_Fm_Corr") = SigFmCorr(iPos)
                                        .Item("Fm_Bgnd") = LgBlkFm(iPos)
                                        .Item("SigFmBgnd") = SigLgBlkFm(iPos)
                                    End If
                                End With
                            Next
                        End With
                        For iGrp = 0 To NumGroups - 1
                            With .tblGroup(iGrp)
                                For i = 0 To .Rows.Count - 1
                                    With .Rows(i)
                                        If .Item("Pos") = iPos Then
                                            .Item("Fm_Corr") = FmCorr(iPos)
                                            .Item("Sig_Fm_Corr") = SigFmCorr(iPos)
                                            .Item("Fm_Bgnd") = LgBlkFm(iPos)
                                            .Item("SigFmBgnd") = SigLgBlkFm(iPos)
                                            If TargetIsSmall(iPos) Then
                                                .Item("Sm") = True
                                                .Item("Fm_Blk_Corr") = FmMBCorr(iPos)
                                                .Item("Sig_Fm_Blk_Corr") = SigFmMBCorr(iPos)
                                            End If
                                        End If
                                    End With
                                Next
                            End With
                        Next
                    Next
                End If
                BLANKCORRECTED = True
            End If
        End With
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        Calculate()                       ' force a recalculation to make sure results are current
        MakeSimpleReport()
    End Sub

    Private Sub mnuReload_Click(sender As Object, e As EventArgs) Handles mnuReload.Click
        doReLoad()
    End Sub

    Private Sub tsmLoad_Click(sender As System.Object, e As System.EventArgs) Handles tsmLoad.Click
        IAMINSPECTING = False
        doLoad()
    End Sub

    Private Sub tsmPartialLoad_Click(sender As System.Object, e As System.EventArgs)
        frmPartial.Visible = True
    End Sub

    Private Sub PropertyPropertyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PropertyPropertyToolStripMenuItem.Click
        FIRSTPROPPROP = True
        PropPropPlot.cmbXvar.Items.Clear()
        PropPropPlot.cmbYvar.Items.Clear()
        For i = 8 To InputData.Columns.Count - 1
            PropPropPlot.cmbXvar.Items.Add(InputData.Columns(i).ColumnName)
            PropPropPlot.cmbYvar.Items.Add(InputData.Columns(i).ColumnName)
        Next
        PropPropPlot.Visible = True
        PropPropPlot.BringToFront()
        FIRSTPROPPROP = False
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Options.Visible = True
        Options.BringToFront()
    End Sub

    Private Sub tsmOptions_Click(sender As System.Object, e As System.EventArgs)
        Options.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If NumRuns = 0 Then End
        If IAMINSPECTING Then End
        Dim ans As MsgBoxResult = vbNo
        If LOADEDWHEEL And Not SAVEDTODATABASE Then
            ans = MsgBox("You have not saved your work to the database" & vbCrLf _
                       & "If you'd like to do so, click NO and do so from the FILE Menu" _
                       & vbCrLf & "Otherwise to continue to exit, click YES", vbYesNo)
            If ans = MsgBoxResult.No Then Exit Sub
        End If
        ans = MsgBox("Do you want to save your work to a file on exit?", MsgBoxStyle.YesNoCancel)
        If ans = vbYes Then
            DoSave()
            End
        ElseIf ans = vbNo Then
            End
        End If
    End Sub

    Private Sub tspQuit_Click(sender As Object, e As EventArgs) Handles tspQuit.Click
        If IAMINSPECTING Then End
        Dim ans As MsgBoxResult = vbNo
        If LOADEDWHEEL And Not SAVEDTODATABASE Then
            ans = MsgBox("You have not saved your work to the database" & vbCrLf _
                       & "If you'd like to do so, click NO and do so from the FILE Menu" _
                       & vbCrLf & "Otherwise to continue to exit, click YES", vbYesNo)
            If ans = MsgBoxResult.No Then Exit Sub
        End If
        End
    End Sub

    Private Sub tspPlotAllStds_Click(sender As Object, e As EventArgs) Handles tspPlotAllStds.Click
        DoWormPlots()
    End Sub

    Private Sub tspPlotStds_Click(sender As Object, e As EventArgs) Handles tspPlotStds.Click
        IamBatching = True          ' set this flag to make sure that it doesn't update every checkbox change
        chkStandards.Checked = True     ' just showing standards
        chkBlanks.Checked = False       ' not blanks
        chkSecondaries.Checked = False      ' and not secondaries
        chkUnknowns.Checked = False     '  and not unknowns
        IamBatching = False             ' now OK to update on click
        RePopulateTargets()               ' now update the table!
        PopRuns(TargetData(0).Item("Pos"))
    End Sub

    Private Sub tspGroupMerge_Click(sender As System.Object, e As System.EventArgs) Handles tspGroupMerge.Click
        With GroupMerge
            .lblPatience.Visible = False
            .btnCancel.Visible = True
            .btnMerge.Visible = True
            .btnMergeAll.Visible = True
            .lbxGroups.Items.Clear()
            For i = 1 To NumGroups
                .lbxGroups.Items.Add("Group " & i.ToString & " from " & (GroupEnd(i - 1) + 1).ToString & " to " _
                                     & GroupEnd(i).ToString & " (Ends " & Date.FromOADate(GroupTimes(i)).ToString("HH:mm MMM dd") & " )")
            Next
            .nudGroup.Minimum = 2
            .nudGroup.Maximum = NumGroups
            .Visible = True
        End With
    End Sub

    Private Sub tspGroupRestore_Click(sender As System.Object, e As System.EventArgs) Handles tspGroupRestore.Click
        Dim LastMst As Integer = 1000
        Dim GroupNum As Integer = 1
        GroupEnd(0) = -1
        GroupTimes(0) = RunTimes(0) - 0.001
        For i = 0 To NumRuns - 1
            If InputData.Rows(i).Item("Mst") < LastMst Then
                If i > 0 Then
                    GroupNum += 1
                    GroupEnd(GroupNum) = i - 1           ' point to end of the last group
                    GroupTimes(GroupNum) = (RunTimes(i) + RunTimes(i - 1)) / 2     ' time marker between two runs
                End If
            End If
            LastMst = InputData.Rows(i).Item("Mst")
            GroupNums(i) = GroupNum
            InputData.Rows(i).Item("Grp") = GroupNum
        Next
        GroupEnd(GroupNum) = NumRuns - 1
        GroupTimes(GroupNum) = RunTimes(NumRuns - 1) + 0.001
        UpdateDataListLabel()
    End Sub

    Private Sub tspListGroups_Click(sender As Object, e As EventArgs) Handles tspListGroups.Click
        GroupList.lbxGroups.Items.Clear()
        For i = 1 To NumGroups
            GroupList.lbxGroups.Items.Add("Group " & i.ToString & " from " & (GroupEnd(i - 1) + 1).ToString & " to " _
                                 & GroupEnd(i).ToString & " (Ends " & Date.FromOADate(GroupTimes(i)).ToString("HH:mm MMM dd") & " )")
        Next
        GroupList.Visible = True
    End Sub

    Private Sub tspGroupSplit_Click(sender As System.Object, e As System.EventArgs) Handles tspGroupSplit.Click
        With GroupSplit
            .dgvSplit.Visible = False
            .btnSplit.Visible = False
            .nudSplit.Maximum = NumRuns - 1
            .lblPrompt.Text = "Select Run Number Where New Group Starts,  Then Press Enter"
            .Visible = True
        End With
    End Sub

    Private Sub tspHelp_Click(sender As System.Object, e As System.EventArgs) Handles tspHelp.Click
        Help.HelpBrowser.Navigate(My.Application.Info.DirectoryPath & "\Help\SNICSer Manual.htm")
        Help.Visible = True
        Help.BringToFront()
    End Sub

    Private Sub tspAbout_Click(sender As System.Object, e As System.EventArgs) Handles tspAbout.Click
        With About
            .LabelProductName.Text = "SNICSer"
            .LabelCompanyName.Text = "NOSAMS"
            .LabelCopyright.Text = "W.J.Jenkins, 2013, 2014"
            .LabelVersion.Text = "V" & VERSION.ToString("0.000")
            .ShowDialog()
        End With
    End Sub

    Private Sub tspShowSecondaries_Click(sender As System.Object, e As System.EventArgs) Handles tspShowSecondaries.Click
        If tspShowSecondaries.Text = "Show Secondaries Table" Then
            dgvSecs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
            dgvSecs.Visible = True
            lblSecStds.Visible = True
            tspShowSecondaries.Text = "Hide Secondaries Table"
            ReSizeDGV(dgvSecs, 20)
            dgvSecs.Height = dgvRuns.Bottom - dgvInputData.Bottom + 10
            dgvSecs.Left = dgvInputData.Right
        Else
            dgvSecs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvSecs.Visible = False
            lblSecStds.Visible = False
            tspShowSecondaries.Text = "Show Secondaries Table"
        End If
    End Sub

    Private Sub NormalizedResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalizedResultsToolStripMenuItem.Click
        DoComparison()
    End Sub

    Private Sub BlankCorrectedResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlankCorrectedResultsToolStripMenuItem.Click
        DoBCComparison()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        With Options
            '.tbcOpt.TabPages.Remove(.tbAppear)
            .Visible = True
        End With
    End Sub

    Private Sub TALLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TALLToolStripMenuItem1.Click
        TALL = (TALLToolStripMenuItem1.Text = "TALL")
        With Options
            .chkTall.Checked = TALL
            .SaveOptions()
        End With
        MsgBox("You must reload the wheel to see the change")
    End Sub

    Private Sub WIDEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WIDEToolStripMenuItem.Click
        WIDE = (WIDEToolStripMenuItem.Text = "WIDE")
        With Options
            .chkWide.Checked = WIDE
            .SaveOptions()
        End With
        MsgBox("You must reload the wheel to see the change")
    End Sub

    Private Sub InheritFirstsFlagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InheritFirstsFlagsToolStripMenuItem.Click
        Dim iRes As MsgBoxResult = MsgBox("This will replace your current flagging with " _
                                   & FirstAuthName & "'s" & vbCrLf & "You can save your flags first using Save" _
                                   & vbCrLf & "and retrieve them using RELOAD" & vbCrLf & "Are you sure?", MsgBoxStyle.OkCancel)
        If iRes = MsgBoxResult.Ok Then
            UpdateChoices(WheelName, FirstAuthName)
            UpdateNonPerfs(WheelName, FirstAuthName, True)
        End If
    End Sub

    Private Sub InheritSecondsFlagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InheritSecondsFlagsToolStripMenuItem.Click
        Dim iRes As MsgBoxResult = MsgBox("This will replace your current flagging with " _
                                   & SecondAuthName & "'s" & vbCrLf & "You can save your flags first using Save" _
                                   & vbCrLf & "and retrieve them using RELOAD" & vbCrLf & "Are you sure?", MsgBoxStyle.OkCancel)
        If iRes = MsgBoxResult.Ok Then
            UpdateChoices(WheelName, SecondAuthName)
            UpdateNonPerfs(WheelName, SecondAuthName, False)
        End If

    End Sub

    Private Sub ResetAllFlagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetAllFlagsToolStripMenuItem.Click
        For i = 0 To InputData.Rows.Count - 1
            InputData.Rows(i).Item("OK") = True

        Next
    End Sub

    Private Sub tspNukeDatabase_Click(sender As Object, e As EventArgs) Handles tspNukeDatabase.Click
        NukeWheel()
        MsgBox("SNICSer must exit before you re-load the wheel" & vbCrLf & "Sorry for the inconvenience")
        End
        doLoad()
    End Sub

    Private Sub InpsectRawDataFile_Click(sender As Object, e As EventArgs) Handles InpsectRawDataFile.Click
        IAMINSPECTING = True
        FirstTimeThrough = True
        BLANKCORRECTED = False
        InitDataSets()
        NumStdAssumed = 0                  ' start with no assumptions
        NumBlkAssumed = 0
        chkDoCalc.Checked = True
        chkStandards.Checked = True
        chkBlanks.Checked = True
        chkSecondaries.Checked = True
        chkUnknowns.Checked = True
        MakeMeSmall()
        ofdLoadFile.CheckFileExists = True
        ofdLoadFile.CheckPathExists = True
        ofdLoadFile.ShowDialog()
        FileName = ofdLoadFile.FileName
        CommitGroupToDatabaseToolStripMenuItem.Enabled = False
        tsmCommit.Enabled = False
        tspNukeDatabase.Enabled = False
        If FileName <> "" Then LoadRawDataFromFile(FileName)
    End Sub

    Private Sub tspWriteDatabaseImportFile_Click(sender As Object, e As EventArgs) Handles tspWriteDatabaseImportFile.Click
        PrintDatabaseImportFile(0)
    End Sub

    Private Sub CompareFlagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompareFlagsToolStripMenuItem.Click
        If TheWheel.FirstAuthName <> "" And TheWheel.SecondAuthName <> "" Then
            CompareTheFlags()       ' cannot get here unless you have both first and second analysts
        Else
            MsgBox("You can only compare flags when wheel has been first and second authorized")
        End If
    End Sub

    Private Sub FlagsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FlagsToolStripMenuItem1.Click
        If TheWheel.FirstAuthName <> "" And TheWheel.SecondAuthName <> "" Then
            CompareTheFlags()       ' cannot get here unless you have both first and second analysts
        Else
            MsgBox("You can only compare flags when wheel has been first and second authorized")
        End If
    End Sub

    Private Sub CountFlagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountFlagsToolStripMenuItem.Click
        CountFlags()
    End Sub

    Private Sub DatabaseImportFIleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseImportFIleToolStripMenuItem.Click
        PrintDatabaseImportFile(0)
    End Sub

    Private Sub tsmFillInC13Table_Click(sender As Object, e As EventArgs) Handles tsmFillInC13Table.Click
        FillInC13Table()
    End Sub

    Private Sub CommitGroupToDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommitGroupToDatabaseToolStripMenuItem.Click
        If FIRSTAUTH And Not REAUTH Then
            With frmGroupCommit
                .clbGroups.Items.Clear()
                For i = 0 To NumGroups - 1
                    .clbGroups.Items.Add("Group " & (i + 1).ToString, False)
                Next
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub LoadRestOfRawDataFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadRestOfRawDataFromFileToolStripMenuItem.Click
        Dim ires As MsgBoxResult = MsgBox("This will load the rest of the raw data from file but keep already promoted data/runs", MsgBoxStyle.OkCancel)
        If ires = MsgBoxResult.Ok Then
            ISPARTIALWHEEL = True       ' flags that we're remembering what we already have data to preserve
            pRuns = InputData.Rows.Count    ' how manu data points to preserve
            For i = 0 To pRuns - 1              ' so save the run numbers, flags, and types
                pRunFlags(i) = InputData.Rows(i).Item(0)
                pRunNums(i) = InputData.Rows(i).Item(1)
                pRunTypes(i) = InputData.Rows(i).Item("Typ")
            Next
            pTargetNums = TargetData.Rows.Count
            For i = 0 To pTargetNums - 1
                pTargetPos(i) = TargetData.Rows(i).Item("Pos")
            Next
            MakeMeSmall()
            LoadRawDataFromFile(WheelFileName(TheWheel))
            tsmBlankCorrect.Visible = True
            tsmCommit.Visible = False
            For i = 0 To pRuns - 1                  ' now re-instate flags and types
                InputData.Rows(pRunNums(i)).Item(0) = pRunFlags(i)
                InputData.Rows(pRunNums(i)).Item("Typ") = pRunTypes(i)
            Next
            CollectRats()
            PopulateTargets()
            SetUpStds()
        End If
    End Sub

#End Region  ' respond to menu selections

#End Region ' respond to use clicks and selections

End Class
