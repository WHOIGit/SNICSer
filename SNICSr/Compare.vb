Public Class Compare

    Private Sub dgvCompare_Sorted(sender As System.Object, e As System.EventArgs) Handles dgvCompare.Sorted
        If Me.Text.Contains("BLANK") Then
            SNICSrFrm.ColorizeBCCompare()
        Else
            SNICSrFrm.ColorizeCompare()
        End If
    End Sub

    Private Sub btnSaveToFile_Click(sender As Object, e As EventArgs) Handles btnSaveToFile.Click
        Dim OutLine As String = ""
        SaveFileDialog1.FileName = SNICSrFrm.WheelName & "_Comparison.xls"
        SaveFileDialog1.InitialDirectory = SNICSrFrm.MySNICSerDir
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then
            Try
                FileOpen(33, SaveFileDialog1.FileName, OpenMode.Output)
                OutLine = dgvCompare.Columns(0).HeaderText
                For j = 1 To dgvCompare.Columns.Count - 1
                    OutLine &= vbTab & dgvCompare.Columns(j).HeaderText
                Next
                PrintLine(33, OutLine)
                For i = 0 To dgvCompare.Rows.Count - 1
                    OutLine = dgvCompare.Item(0, i).Value
                    For j = 1 To dgvCompare.Columns.Count - 1
                        OutLine &= vbTab & dgvCompare.Item(j, i).Value
                    Next
                    PrintLine(33, OutLine)
                Next
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & SaveFileDialog1.FileName)
            Finally
                FileClose(33)
            End Try
        End If
    End Sub

    Private Sub btnSaveToClipboard_Click(sender As Object, e As EventArgs) Handles btnSaveToClipboard.Click
        Dim bm As Bitmap = New Bitmap(dgvCompare.Width, dgvCompare.Height)
        dgvCompare.DrawToBitmap(bm, New Rectangle(0, 0, dgvCompare.Width, dgvCompare.Height))
        My.Computer.Clipboard.SetImage(bm)
        MsgBox("Visible portion saved to clipboard")
    End Sub

    Private Sub cmbCompare1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompare.SelectedIndexChanged

    End Sub
End Class