Public Class frmGroupCommit

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        For i = 0 To clbGroups.Items.Count - 1
            If clbGroups.GetItemChecked(i) Then
                'MsgBox(clbGroups.Items(i).ToString)
                SNICSrFrm.CommitToDatabase(i + 1)
            End If
        Next
        Me.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub
End Class