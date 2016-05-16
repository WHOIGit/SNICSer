Public Class frmTargetInfo

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            For i = 0 To dgvTargetInfo.Rows.Count - 1
                If IsDBNull(dgvTargetInfo("Comment", i).Value) Then
                    SNICSrFrm.TargetComments(SNICSrFrm.TargetData(i).Item("Pos")) = ""
                Else
                    SNICSrFrm.TargetComments(SNICSrFrm.TargetData(i).Item("Pos")) = Trim(dgvTargetInfo("Comment", i).Value)
                End If
            Next
        Catch ex As Exception
            MsgBox("Target Info Error" & vbCrLf & ex.Message)
        End Try

        Me.Visible = False
    End Sub

    Private Sub dgvTargetInfo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTargetInfo.CellEndEdit
        Dim theWidth As Integer = 0
        With dgvTargetInfo
            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            For i = 0 To .Columns.Count - 1
                theWidth += .Columns(i).Width
            Next
            .Width = theWidth + 20
        End With
        Me.Width = dgvTargetInfo.Width + 20
    End Sub

End Class