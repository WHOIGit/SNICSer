Public Class GroupMerge

    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click
        Dim GrpToMrg As Integer = nudGroup.Value
        Disappear()
        With SNICSrFrm
            If .GROUPBOUNDS Then
                .dgvInputData.CausesValidation = False
                For i = .GroupEnd(GrpToMrg - 1) + 1 To .InputData.Rows.Count - 1         ' first update raw data table
                    .GroupNums(i) -= 1          ' decrement group numbers
                    .InputData.Rows(i).Item("Grp") = .GroupNums(i).ToString
                Next
                .dgvInputData.CausesValidation = True
                For i = GrpToMrg To .NumGroups
                    .GroupEnd(i - 1) = .GroupEnd(i)
                    .GroupTimes(i - 1) = .GroupTimes(i)
                Next
                .NumGroups -= 1
                .UpdateDataListLabel()
            Else
                MsgBox("Group Bounds are Not Enforced:" & vbCrLf & "No Point in Merging Groups" & vbCrLf & "So Not Done")
            End If
        End With
        Me.Enabled = True
        Me.Visible = False
    End Sub

    Private Sub Disappear()
        lblPatience.Text = "This may take some time..." & vbCrLf & "Please be patient"
        lblPatience.Visible = True
        btnCancel.Visible = False
        btnMergeAll.Visible = False
        btnMerge.Visible = False
        Me.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub

    Private Sub btnMergeAll_Click(sender As System.Object, e As System.EventArgs) Handles btnMergeAll.Click
        Disappear()
        With SNICSrFrm
            If .GROUPBOUNDS And (.NumGroups > 1) Then
                Me.Enabled = False
                For i = .GroupEnd(1) + 1 To .InputData.Rows.Count - 1         ' first update raw data table starting at beginning of group 2
                    .GroupNums(i) = 1          ' decrement group numbers
                    .InputData.Rows(i).Item("Grp") = 1
                Next
                .GroupEnd(0) = 0
                .GroupEnd(1) = .InputData.Rows.Count - 1
                .GroupTimes(1) = .GroupTimes(.NumGroups)
                .NumGroups = 1
                .UpdateDataListLabel()
            Else
                MsgBox("Group Bounds are Not Enforced:" & vbCrLf & "No Point in Merging Groups" & vbCrLf & "So Not Done")
            End If
        End With
        Me.Enabled = True
        Me.Visible = False
    End Sub

    Private Sub lbxGroups_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbxGroups.SelectedIndexChanged
        If lbxGroups.SelectedIndex > 0 Then nudGroup.Value = lbxGroups.SelectedIndex + 1
    End Sub
End Class