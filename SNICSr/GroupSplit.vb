Public Class GroupSplit

    Public theRun As Integer = 0                                ' where the split occurs
    Public theGroup As Integer = 0                              ' the new group number
    Public nRange As Integer = 3

    Private Sub nudSplit_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudSplit.ValueChanged
        With SNICSrFrm
            If IsNumeric(nudSplit.Value) Then
                .SplitList.Rows.Clear()
                theRun = nudSplit.Value                                 ' where the split occurs
                If (theRun = 0) Or (theRun = .InputData.Rows.Count - 1) Then
                    MsgBox("It makes no sense to put a split here")
                    Exit Sub
                End If
                theGroup = .InputData.Rows(theRun).Item("Grp") + 1      ' now promoting to new group
                For j = theRun - nRange To theRun + nRange
                    If (j >= 0) And (j < .InputData.Rows.Count) Then
                        Dim newrow As DataRow = .SplitList.NewRow
                        For i = 0 To dgvSplit.Columns.Count - 1
                            newrow(i) = .InputData.Rows(j).Item(i)
                        Next
                        .SplitList.Rows.Add(newrow)
                    End If
                Next
            End If
        End With
        dgvSplit.Visible = True
        dgvSplit.Rows(nRange).Selected = True
        btnSplit.Visible = True
        ReSizeMe()
    End Sub

    Private Sub ReSizeMe()
        Dim dgvWidth As Integer = 0
        For i = 0 To dgvSplit.Columns.Count - 1
            dgvWidth += dgvSplit.Columns(i).Width
        Next
        dgvSplit.Width = dgvWidth + 10
        Dim dgvheight As Integer = dgvSplit.ColumnHeadersHeight
        For i = 0 To dgvSplit.Rows.Count - 1
            dgvheight += dgvSplit.Rows(i).Height
        Next
        dgvSplit.Height = dgvheight + 10
        Me.Width = dgvSplit.Width + 20
        Me.Height = dgvSplit.Height + lblPrompt.Bottom + 40
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub

    Private Sub btnSplit_Click(sender As System.Object, e As System.EventArgs) Handles btnSplit.Click
        lblPrompt.Text = "This will take some time... Please be Patient"
        btnSplit.Visible = False
        Me.Enabled = False
        With SNICSrFrm
            For i = theRun To .InputData.Rows.Count - 1
                .GroupNums(i) += 1
                .InputData.Rows(i).Item("Grp") += 1
            Next
            .NumGroups += 1
            For i = .NumGroups To theGroup Step -1      ' extend list and make room for new group
                .GroupEnd(i) = .GroupEnd(i - 1)
                .GroupTimes(i) = .GroupTimes(i - 1)
            Next
            .GroupEnd(theGroup - 1) = theRun - 1
            .GroupTimes(theGroup - 1) = (.RunTimes(theRun) + .RunTimes(theRun - 1)) / 2
            .UpdateDataListLabel()
        End With
        Me.Enabled = True
        Me.Visible = False
    End Sub

End Class