Public Class ChngType
    Public theRow As Integer = 0
    Public thePos As Integer = 0
    Public theName As String = ""
    Public theType As String = ""


    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        btnExecute.Visible = True
        btnChange.Visible = False
        Me.Visible = False
    End Sub

    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        If Trim(txtSmpName.Text) = "" Then
            MsgBox("You must specify a name")
            Exit Sub
        End If
        Me.Enabled = False
        With SNICSrFrm
            Dim theCol As Color
                Select Case cmbType.Text        ' select/assign the bacground color
                    Case "S"
                        theCol = .StdCol
                    Case "SS"
                        theCol = .SecCol
                    Case "B"
                        theCol = .BlkCol
                    Case "U"
                        theCol = .UnkCol
                End Select
            .TargetComments(thePos) = txtComment.Text
            For i = 1 To .RunKeys(thePos, 0)
                .InputData(.RunKeys(thePos, i)).Item("Typ") = cmbType.Text
                .dgvInputData.Rows(.RunKeys(thePos, i)).DefaultCellStyle.BackColor = theCol
            Next
            ResetTargetTable()
            .PopulateTargets()
            .SetUpStds()
            .UpdateStandardsTables()
        End With
        Me.Enabled = True
        Me.Visible = False
        btnChange.Visible = False
        SNICSrFrm.Calculate()
        'MsgBox("Don't forget to click CALCULATE on main form")
    End Sub

    Private Sub ChangeType(ByVal nPos As Integer)
        Dim theCol As Color
        With SNICSrFrm
            Select Case cmbType.Text        ' select/assign the bacground color
                Case "S"
                    theCol = .StdCol
                Case "SS"
                    theCol = .SecCol
                Case "B"
                    theCol = .BlkCol
                Case "U"
                    theCol = .UnkCol
            End Select
            .TargetComments(nPos) = txtComment.Text
            For i = 1 To .RunKeys(nPos, 0)
                .InputData(.RunKeys(nPos, i)).Item("Typ") = cmbType.Text
                .dgvInputData.Rows(.RunKeys(nPos, i)).DefaultCellStyle.BackColor = theCol
            Next
            'For i = 0 To .InputData.Rows.Count - 1
            'If .InputData(i).Item("Pos") = nPos Then
            '.InputData(i).Item("Typ") = cmbType.Text
            '.dgvInputData.Rows(i).DefaultCellStyle.BackColor = theCol
            'End If
            'Next
        End With
    End Sub

    Private Sub btnBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnBatch.Click
        Me.Width = 800
        btnChange.Visible = False
    End Sub

    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        If lbxTo.Items.Count < 1 Then
            MsgBox("Must have at least one target in the TO list")
            Exit Sub
        End If
        Dim ians As Integer = MsgBox("Are you sure you want to do this?", MsgBoxStyle.YesNo)
        If ians = MsgBoxResult.No Then Exit Sub
        Me.Enabled = False
        For i = 0 To lbxTo.Items.Count - 1
            Dim thestr As String = Mid(lbxTo.Items(i), 1, InStr(lbxTo.Items(i), ":") - 1)
            Dim nPos As Integer = Val(thestr)
            ChangeType(nPos)
        Next
        ResetTargetTable()
        With SNICSrFrm
            .PopulateTargets()
            .SetUpStds()
            .UpdateStandardsTables()
        End With
        btnChange.Visible = True
        Me.Enabled = True
        Me.Visible = False
        SNICSrFrm.Calculate()
        'MsgBox("Don't forget to click CALCULATE on main form" & vbCrLf & "when finished changing types")
    End Sub

    Public Sub ResetTargetTable()
        With SNICSrFrm
            .IamBatching = True
            .chkBlanks.Checked = True
            .chkStandards.Checked = True
            .chkSecondaries.Checked = True
            .chkUnknowns.Checked = True
            .IamBatching = False
        End With
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs)
        If lbxFrom.SelectedItems.Count > 0 Then
            For i = 0 To lbxFrom.SelectedItems.Count - 1
                lbxTo.Items.Add(lbxFrom.SelectedItems(i).ToString)
            Next
            For i = lbxFrom.SelectedItems.Count - 1 To 0 Step -1
                lbxFrom.Items.RemoveAt(lbxFrom.SelectedIndices(i))
            Next
            btnExecute.Visible = True
        Else
            MsgBox("Must select at least one to add to list")
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs)
        If lbxTo.SelectedItems.Count > 0 Then
            For i = 0 To lbxTo.SelectedItems.Count - 1
                lbxFrom.Items.Add(lbxTo.SelectedItems(i).ToString)
            Next
            For i = lbxTo.SelectedItems.Count - 1 To 0 Step -1
                lbxTo.Items.RemoveAt(lbxTo.SelectedIndices(i))
            Next
        Else
            MsgBox("Must select at least one to remove from list")
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        lblTo.Text = "To Type " & cmbType.Text
        btnChange.Visible = True
    End Sub

    Private Sub lbxFrom_Click(sender As Object, e As EventArgs) Handles lbxFrom.Click
        lbxTo.Items.Add(lbxFrom.Items(lbxFrom.SelectedIndex))
        lbxFrom.Items.RemoveAt(lbxFrom.SelectedIndex)
        btnExecute.Visible = True
    End Sub

    Private Sub lbxTo_MouseClick(sender As Object, e As MouseEventArgs) Handles lbxTo.MouseClick
        lbxFrom.Items.Add(lbxTo.Items(lbxTo.SelectedIndex))
        lbxTo.Items.RemoveAt(lbxTo.SelectedIndex)
        btnExecute.Visible = True
    End Sub

End Class