Public Class ExtStd

    Private Sub btnAdopt_Click(sender As Object, e As EventArgs) Handles btnAdopt.Click
        If Trim(txt13.Text) = "" Or Trim(txt14.Text) = "" Then
            MsgBox("You must specify both values to proceed")
            Exit Sub
        End If
        If Not IsNumeric(txt13.Text) Then
            MsgBox("C13/12 Factor is not numeric")
            Exit Sub
        End If
        If Not IsNumeric(txt14.Text) Then
            MsgBox("C14/12 Factor is not numeric")
            Exit Sub
        End If
        StdsAndBlks.Assumed_C13 = Val(txt13.Text)
        StdsAndBlks.Assumed_Rat = Val(txt14.Text)
        Me.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub
End Class