Public Class frmBlankCorr

    Public tblStandards As New DataTable
    Public tblGroup(10) As DataTable
    Public tblInorganic As New DataTable
    Public tblOrganic As New DataTable
    Public tblWatson As New DataTable
    Public tblBlanks As New DataTable
    Public dgvGroup(10) As DataGridView
    Public chkSmall(10) As CheckBox
    Public chkLock(10) As CheckBox
    Public lblGroup(10) As Label
    Public GroupSel As Integer = -1

    Private Sub frmBlankCorr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvOrganic.DataSource = tblOrganic
        dgvInorganic.DataSource = tblInorganic
        dgvBlanks.DataSource = tblBlanks
        dgvWatson.DataSource = tblWatson
    End Sub

    Private Sub tbcGroups_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcGroups.SelectedIndexChanged
        Dim theTPC As TabControl = CType(sender, TabControl)
        Dim iSel As Integer = theTPC.SelectedIndex
        If iSel >= 0 Then
            For iRow = 0 To dgvGroup(iSel).Rows.Count - 1
                dgvGroup(iSel).Rows(iRow).DefaultCellStyle.BackColor = SNICSrFrm.TargetColor(dgvGroup(iSel).Item("Typ", iRow).Value)
            Next
        End If
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        With SNICSrFrm
            If Not .IAMINSPECTING And (.FIRSTAUTH Or .SECONDAUTH) Then
                .tsmCommit.Visible = True
                If .ISPARTIALWHEEL Then SNICSrFrm.tsmCommit.Text = "Commit Rest to Database"
                If .GROUPBOUNDS And .FIRSTAUTH And Not .REAUTH Then
                    .CommitGroupToDatabaseToolStripMenuItem.Visible = True
                    .CommitGroupToDatabaseToolStripMenuItem.Enabled = True
                End If
            End If
            SNICSrFrm.BlankCorrectedResultsToolStripMenuItem.Visible = True
        End With
        Me.Visible = False
    End Sub

    Private Sub dgvBlanks_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvBlanks.CurrentCellDirtyStateChanged
        If dgvBlanks.IsCurrentCellDirty Then
            dgvBlanks.CommitEdit(DataGridViewDataErrorContexts.Commit)
            SNICSrFrm.ComputeBlanks()
            UpDateBlankTables()
        End If
    End Sub

    Private Sub dgvInorganic_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInorganic.CellEndEdit
        UpDateBlankTables()
    End Sub

    Private Sub dgvOrganic_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrganic.CellEndEdit
        UpDateBlankTables()
    End Sub

    Private Sub dgvWatson_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWatson.CellEndEdit
        UpDateBlankTables()
    End Sub

    Private Sub UpDateBlankTables()
        With SNICSrFrm
            .SetUpStandardsBlankTables()
            '.SetUpBlankBlankTable() 'Causes watson table to revert to old value when manually entering
            For iGrp = 0 To .NumGroups - 1
                For iRow = 0 To tblGroup(iGrp).Rows.Count - 1
                    .SetLgBlkCorr(iGrp, iRow)
                    .DoLgBlkCorr(iGrp, iRow)
                    If tblGroup(iGrp).Rows(iRow).Item(0) Then
                        .DoMBCorr(iGrp, iRow)
                    Else
                        .RemoveMassBalanceBlankCorr(iGrp, iRow)  ' remove mass balance correction
                    End If
                Next
            Next
            If GroupSel >= 0 Then tbcGroups.SelectTab(GroupSel) ' return to previously selected tab page
        End With
    End Sub

    Private Sub tbcGroups_MouseClick(sender As Object, e As MouseEventArgs) Handles tbcGroups.MouseClick
        GroupSel = tbcGroups.SelectedIndex      ' save selected tab page number
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        sfdSaveBCResults.FileName = SNICSrFrm.WheelName & "MBC.xls"
        sfdSaveBCResults.InitialDirectory = SNICSrFrm.MySNICSerDir
        If sfdSaveBCResults.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fname As String = sfdSaveBCResults.FileName
            FileOpen(10, fname, OpenMode.Output)
            PrintLine(10, SNICSrFrm.WheelName)
            PrintLine(10)
            PrintLine(10)
            FileClose(10)
            AppendDGV(dgvInorganic, fname)
            WriteLabel("", fname)
            AppendDGV(dgvOrganic, fname)
            WriteLabel("Standards", fname)
            AppendDGV(dgvStandards, fname)
            WriteLabel("Blanks", fname)
            AppendDGV(dgvBlanks, fname)
            For i = 0 To tbcGroups.TabCount - 1
                If dgvGroup(i).Rows.Count > 0 Then
                    WriteLabel("Group " & (i + 1).ToString, fname)
                    AppendDGV(dgvGroup(i), fname)
                End If
            Next
        End If
    End Sub

    Private Sub AppendDGV(dgv As DataGridView, fname As String)
        dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        dgv.SelectAll()
        IO.File.AppendAllText(fname, dgv.GetClipboardContent().GetText.TrimEnd)
        dgv.ClearSelection()
    End Sub

    Private Sub WriteLabel(theText As String, fname As String)
        FileOpen(10, fname, OpenMode.Append)
        PrintLine(10)
        PrintLine(10)
        PrintLine(10, theText)
        FileClose(10)
    End Sub

    Public Sub dgvGroups_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)        'Handles dgvBlanks.CurrentCellDirtyStateChanged
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If dgv.IsCurrentCellDirty Then
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Public Sub dgvGroups_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim iGrp As Integer = dgv.Tag
        Dim iRow As Integer = e.RowIndex
        If e.ColumnIndex = 0 And iRow > -1 Then
            If Not chkLock(iGrp).Checked Then
                tblGroup(iGrp).Rows(iRow).Item(0) = Not tblGroup(iGrp).Rows(iRow).Item(0)
                UpDateBlkCorr(iGrp, iRow)
            End If
        End If
    End Sub

    Private Sub UpDateBlkCorr(iGrp As Integer, iRow As Integer)
        Dim iPos As Integer = tblGroup(iGrp).Rows(iRow).Item("Pos")
        With SNICSrFrm
            .SetLgBlkCorr(iGrp, iRow)           ' first update the large blank correction accordingly
            .DoLgBlkCorr(iGrp, iRow)
            If tblGroup(iGrp).Rows(iRow).Item(0) Then            ' code to add or remove mass balance correction 
                '.TargetIsSmall(iPos) = True
                .DoMBCorr(iGrp, iRow)
            Else
                '.TargetIsSmall(iPos) = False
                .RemoveMassBalanceBlankCorr(iGrp, iRow)  ' remove mass balance correction
            End If
        End With
    End Sub

    Public Sub SmallChkBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim iGrp As Integer = chk.Tag
        If Not chkLock(iGrp).Checked Then
            For iRow = 0 To tblGroup(iGrp).Rows.Count - 1
                tblGroup(iGrp).Rows(iRow).Item(0) = chk.Checked
                UpDateBlkCorr(iGrp, iRow)
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class