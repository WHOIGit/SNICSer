Public Class CompareFlags

    Private Sub CompareFlags_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub dgvFlags_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFlags.CellContentClick
        SNICSrFrm.PopRuns(dgvFlags(0, e.RowIndex).Value)
    End Sub

 
End Class