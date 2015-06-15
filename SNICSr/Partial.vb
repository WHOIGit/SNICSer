Public Class frmPartial

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub

    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        If nudFrom.Value >= nudTo.Value Then
            MsgBox("Invalid Range")
            Exit Sub
        Else
            For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                Dim pos As Integer = SNICSrFrm.InputData(i).Item("Pos")
                If (pos < nudFrom.Value) Or (pos > nudTo.Value) Then SNICSrFrm.InputData(i).Delete()
            Next
        End If
        Me.Visible = False
    End Sub

End Class