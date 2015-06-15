Public Class StdsAndBlks

    Public IamFilling As Boolean = False
    Public Assumed_Rat As Double = 0.0
    Public Assumed_C13 As Double = 0.0

    Private Sub dgvStandards_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStandards.ColumnHeaderMouseClick
        IamFilling = True
        If e.ColumnIndex = 4 Then
            With SNICSrFrm
                For i = 1 To .StandardsValues.Rows.Count - 1
                    If .StandardsValues(i).Item("Asm_Rat") = 42 Then
                        .StandardsValues(i).Item("Asm_Rat") = .StandardsValues(i - 1).Item("Asm_Rat")
                    End If
                Next
                .CheckStdsAndBlks()
            End With
        ElseIf e.ColumnIndex = 9 Then
            With SNICSrFrm
                For i = 1 To .StandardsValues.Rows.Count - 1
                    If .StandardsValues(i).Item("Asm13/12") = 42 Then
                        .StandardsValues(i).Item("Asm13/12") = .StandardsValues(i - 1).Item("Asm13/12")
                    End If
                Next
                .CheckStdsAndBlks()
            End With
        End If
        IamFilling = False
    End Sub

    Private Sub dgvBlanks_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBlanks.ColumnHeaderMouseClick
        IamFilling = True
        If e.ColumnIndex = 4 Then
            With SNICSrFrm
                For i = 1 To .BlanksValues.Rows.Count - 1
                    If .BlanksValues(i).Item("Asm_Rat") = 42 Then
                        .BlanksValues(i).Item("Asm_Rat") = .BlanksValues(i - 1).Item("Asm_Rat")
                    End If
                Next
                .CheckStdsAndBlks()
            End With
        ElseIf e.ColumnIndex = 9 Then
            With SNICSrFrm
                For i = 1 To .BlanksValues.Rows.Count - 1
                    If .BlanksValues(i).Item("Asm13/12") = 42 Then
                        .BlanksValues(i).Item("Asm13/12") = .BlanksValues(i - 1).Item("Asm13/12")
                    End If
                Next
                .CheckStdsAndBlks()
            End With
        End If
        IamFilling = False
    End Sub

    Private Sub dgvStandards_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStandards.CellValueChanged
        If Not IamFilling Then SNICSrFrm.CheckStdsAndBlks()
    End Sub

    Private Sub dgvBlanks_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBlanks.CellValueChanged
        If Not IamFilling Then SNICSrFrm.CheckStdsAndBlks()
    End Sub

    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        With SNICSrFrm
            For i = 0 To .StandardsValues.Rows.Count - 1
                Dim k As Integer = .StandardsValues(i).Item("Pos")
                For j = 1 To .RunKeys(k, 0)
                    .StdC13C12(.RunKeys(k, j)) = .StandardsValues(i).Item("Asm13/12")
                    .StdC14C12(.RunKeys(k, j)) = .StandardsValues(i).Item("Asm_Rat")
                Next
            Next
            If .FirstTimeThrough Then
                .Calculate()
                .chkDoCalc.Checked = False
            End If
            .FirstTimeThrough = False
            .Visible = True
            .ColorizeTargets()
            For i = 0 To .StandardsValues.Rows.Count - 1
                Dim FoundIt As Boolean = False
                For j = 0 To .NumStds - 1
                    If .Std_Rec_Num(j) = .StandardsValues.Rows(i).Item("Rec_Num") Then
                        FoundIt = True            ' found it in the table, no need to add it
                    End If
                Next
                If Not FoundIt Then
                    .Std_Rec_Num(.NumStds) = .StandardsValues.Rows(i).Item("Rec_Num")
                    .Std_Name(.NumStds) = .StandardsValues.Rows(i).Item("SampleName")
                    .Std_Fm(.NumStds) = .StandardsValues.Rows(i).Item("Asm_Rat")
                    .AsmRat(.StandardsValues.Rows(i).Item("Pos")) = .StandardsValues.Rows(i).Item("Asm_Rat")
                    .Std_delC13(.NumStds) = .StandardsValues.Rows(i).Item("Asm13/12")
                    .NumStds += 1
                End If
            Next
            For i = 0 To .BlanksValues.Rows.Count - 1
                .AsmRat(.BlanksValues.Rows(i).Item("Pos")) = .BlanksValues.Rows(i).Item("Asm_Rat")
            Next
        End With
        Me.Visible = False
    End Sub

    Private Sub dgvBlanks_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBlanks.RowHeaderMouseClick
        If Not SNICSrFrm.FirstTimeThrough Then SNICSrFrm.PopRuns(SNICSrFrm.BlanksValues(e.RowIndex).Item("Pos")) ' get the selected target position
    End Sub

    Private Sub dgvStandards_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStandards.RowHeaderMouseClick
        If Not SNICSrFrm.FirstTimeThrough Then
            SNICSrFrm.PopRuns(SNICSrFrm.StandardsValues(e.RowIndex).Item("Pos")) ' get the selected target position
        End If
    End Sub

    Private Sub cmbExternal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExternal.SelectedIndexChanged
        Select Case cmbExternal.Text
            Case "OX-II"
                Assumed_Rat = 1.3407
                Assumed_C13 = 0.9822
            Case "OX-I"
                Assumed_Rat = 1.0398
                Assumed_C13 = 0.981
            Case "Other"
                ExtStd.ShowDialog()
        End Select
     End Sub

    Private Sub btnFill_Click(sender As Object, e As EventArgs) Handles btnFill.Click
        With SNICSrFrm
            For i = 0 To .StandardsValues.Rows.Count - 1
                If .StandardsValues.Rows(i).Item("Asm_Rat") = 42 Then .StandardsValues.Rows(i).Item("Asm_Rat") = Assumed_Rat
                If .StandardsValues.Rows(i).Item("Asm13/12") = 42 Then .StandardsValues.Rows(i).Item("Asm13/12") = Assumed_C13
                dgvStandards.Rows(i).DefaultCellStyle.BackColor = Color.White
            Next
        End With
    End Sub

End Class