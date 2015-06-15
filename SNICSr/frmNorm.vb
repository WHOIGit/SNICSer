Public Class frmNorm

    Private Sub dgvNorm_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNorm.CellContentClick
        If e.RowIndex >= 0 Then
            SNICSrFrm.PopRuns(dgvNorm.Item(1, e.RowIndex).Value)
        End If
    End Sub
End Class