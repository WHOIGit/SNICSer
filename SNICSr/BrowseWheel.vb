Public Class BrowseWheel    ' the wheel browser

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Me.Visible = False
    End Sub

    Private Sub trvWheel_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvWheel.AfterSelect
        If e.Node.Text.Length = 11 Then
            lblChoice.Text = e.Node.Text
            lbl1st.Visible = True
            lbl2nd.Visible = True
            txtWheel.Visible = True
            Dim theWheel As WheelID = SNICSrFrm.GetWheelID(lblChoice.Text)
            Select Case theWheel.Analyzed
                Case 0
                    txtWheel.Text = "Not Analyzed Yet"
                Case 1
                    txtWheel.Text = theWheel.FirstAuthName & " at " & theWheel.FirstAuthDate.ToString("HH:mm MM/dd/yyyy")
                Case 2
                    txtWheel.Text = theWheel.FirstAuthName & " at " & theWheel.FirstAuthDate.ToString("HH:mm MM/dd/yyyy")
                    txtWheel.Text &= vbCrLf & theWheel.SecondAuthName & " at " & theWheel.SecondAuthDate.ToString("HH:mm MM/dd/yyyy")
            End Select
        Else
            If Not SNICSrFrm.IamBuildingTrees Then
                With trvWheel.SelectedNode
                    If .IsExpanded Then
                        .Collapse()
                    Else
                        .Expand()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        lblChoice.Text = ""
        Me.Visible = False
    End Sub

    Private Sub trvWheel_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles trvWheel.MouseDoubleClick
        Dim theWheel As String = trvWheel.SelectedNode.Name
        If theWheel.Length = 11 Then lblChoice.Text = theWheel
        If Trim(lblChoice.Text) <> "" Then
            Me.Visible = False
        End If
    End Sub
End Class