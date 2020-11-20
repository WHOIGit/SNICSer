Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient


Public Class Options


    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveOptions()
        SNICSrFrm.GetPeirceValues()
        Me.Visible = False
    End Sub

    Public Sub SaveOptions()
        If (Trim(txtPwd.Text) = "") Or (Trim(txtAnalyst.Text) = "") Then
            MsgBox("Sorry, you MUST enter your database password and username" & vbCrLf & "before leaving this window")
            Exit Sub
        End If
        If Not CheckDBCon() Then
            MsgBox("Unable to connect to database." & vbCrLf & "Please check your user name and password are correct." & vbCrLf & "And try again")
            Exit Sub
        End If
        With SNICSrFrm
            .ShareDrivePath = Trim(txtShareDrivePath.Text)
            .NumRawFigs = nudRunSigFig.Value
            .NumResFigs = nudResSigFig.Value
            .TableFontSize = nudFontSize.Value
            .CalcNum = nudNumStds.Value
            .UserName = Trim(txtAnalyst.Text)
            .Password = Trim(txtPwd.Text)
            .CalcMode = Trim(cmbFitType.Text)
            .NumVarPlt = Trim(cmbNumVar.Text)
            .NumVarFnt = nudNumFnt.Value
            .NumVarMult = Val(cmbNumMult.Text)
            .SymbSize = nudSymbSize.Value
            .Enabled = True
            .Visible = True
            If chk2StdDev.Checked Then
                .NumStdDev = 2
            Else
                .NumStdDev = 1
            End If
            FileOpen(1, .HomeDirectory & "/SNICSer.opt", OpenMode.Output)
            Print(1, .NumRawFigs.ToString & vbTab)
            Print(1, .NumResFigs.ToString & vbTab)
            Print(1, .TableFontSize.ToString & vbTab)
            Print(1, .CalcNum.ToString & vbCrLf)
            PrintLine(1, .CalcMode)
            If chkRememberMe.Checked Then
                PrintLine(1, .UserName)
            Else
                PrintLine(1, "")
            End If
            PrintColor(.StdCol)
            PrintColor(.BlkCol)
            PrintColor(.SecCol)
            PrintColor(.UnkCol)
            For i = 0 To .PlotCols.Length - 1
                PrintColor(.PlotCols(i))
            Next
            If chkRememberMe.Checked Then
                PrintLine(1, txtPwd.Text)
            Else
                PrintLine(1, "")
            End If
            PrintLine(1, chkRememberMe.Checked)
            Print(1, nudNumFnt.Value.ToString & vbTab & cmbNumMult.Text & vbTab)
            PrintLine(1, .NumVarPlt)
            PrintLine(1, .NumStdDev.ToString)
            PrintLine(1, .SymbSize.ToString)
            PrintLine(1, chkTall.Checked.ToString)
            PrintLine(1, chkWide.Checked.ToString)
            PrintLine(1, chkTopPlot.Checked.ToString)
            PrintLine(1, chkClassic.Checked.ToString)
            PrintLine(1, chkGroup.Checked.ToString)
            PrintLine(1, .ShareDrivePath)
            FileClose(1)
            .Enabled = True
            .Visible = True
            .InitStdList()
            .ofdLoadFile.Filter &= ";*." & .UserName
            .chkBlanks.BackColor = .BlkCol
            .chkStandards.BackColor = .StdCol
            .chkSecondaries.BackColor = .SecCol
            .chkUnknowns.BackColor = .UnkCol
            .GROUPBOUNDS = chkGroup.Checked
            .TALL = chkTall.Checked
            .WIDE = chkWide.Checked
            .TopPlot = chkTopPlot.Checked
            .ClassicView = chkClassic.Checked
            If .GROUPBOUNDS Then
                .Text = "SNICSer v" & .VERSION.ToString("0.00")
                .tspGroup.Enabled = True
            Else
                .Text = "SNICSer v" & .VERSION.ToString("0.00") & "  GROUP BOUNDARIES IGNORED"
                .tspGroup.Enabled = False
            End If
        End With
        With SNICSrFrm
            If .WIDE Then
                .WIDEToolStripMenuItem.Text = "NARROW"
            Else
                .WIDEToolStripMenuItem.Text = "WIDE"
            End If
            If .TALL Then
                .TALLToolStripMenuItem1.Text = "SHORT"
            Else
                .TALLToolStripMenuItem1.Text = "TALL"
            End If
        End With
    End Sub

    Private Sub PrintColor(thecolor As Color)
        Print(1, thecolor.A & vbTab & thecolor.R & vbTab & thecolor.G & vbTab & thecolor.B & vbCrLf)
    End Sub

    Private Function CheckDBCon() As Boolean
        CheckDBCon = False
        SNICSrFrm.ConString = _
                    "Data Source=nosams-prod.whoi.edu;Database=amsprod;User ID=" _
                    & Trim(txtAnalyst.Text) & ";Password=" & txtPwd.Text & ";"
        Using con As New SqlConnection
            Try
                con.ConnectionString = SNICSrFrm.ConString
                con.Open()
                con.Close()
                CheckDBCon = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs)
        If (Trim(txtPwd.Text) = "") Or (Trim(txtAnalyst.Text) = "") Then
            MsgBox("Sorry, you MUST enter your database password and username" & vbCrLf & "before leaving this window")
            Exit Sub
        End If
        Me.Visible = False
    End Sub

    Private Sub cmbFitType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Select Case cmbFitType.Text
            Case "Average"
                lblFit.Text = "of Nearest"
            Case "Linear"
                lblFit.Text = "Fit to Nearest"
        End Select
        nudNumStds.Left = lblFit.Right + 3
        lblstds.Left = nudNumStds.Right + 3
    End Sub

    Private Sub txtPwd_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPwd.KeyPress
        If e.KeyChar = vbCr Then SaveOptions()
    End Sub

    Private Sub bntQuit_Click(sender As System.Object, e As System.EventArgs) Handles bntQuit.Click
        End
    End Sub

    Private Sub btnStd_Click(sender As System.Object, e As System.EventArgs) Handles btnStd.Click
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = SNICSrFrm.StdCol
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            btnStd.BackColor = ColorDialog1.Color
            SNICSrFrm.StdCol = ColorDialog1.Color
        End If
    End Sub

    Private Sub btnBlk_Click(sender As System.Object, e As System.EventArgs) Handles btnBlk.Click
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = SNICSrFrm.BlkCol
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            btnBlk.BackColor = ColorDialog1.Color
            SNICSrFrm.BlkCol = ColorDialog1.Color
        End If
    End Sub

    Private Sub btnSec_Click(sender As System.Object, e As System.EventArgs) Handles btnSec.Click
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = SNICSrFrm.SecCol
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            btnSec.BackColor = ColorDialog1.Color
            SNICSrFrm.SecCol = ColorDialog1.Color
        End If
    End Sub

    Private Sub btnUnk_Click(sender As System.Object, e As System.EventArgs) Handles btnUnk.Click
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = SNICSrFrm.UnkCol
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            btnUnk.BackColor = ColorDialog1.Color
            SNICSrFrm.UnkCol = ColorDialog1.Color
        End If
    End Sub

    Private Sub btn_Click(sender As System.Object, e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, _
                                 btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim i As Integer = Val(Mid(sender.name, 4))
        ColorDialog1.FullOpen = True
        ColorDialog1.Color = SNICSrFrm.PlotCols(i)
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            sender.backcolor = ColorDialog1.Color
            SNICSrFrm.PlotCols(i) = ColorDialog1.Color
        End If
    End Sub

    Private Sub btnScheme1_Click(sender As System.Object, e As System.EventArgs) Handles btnScheme1.Click
        With SNICSrFrm
            For i = 0 To 9
                .PlotCols(i) = .PlotColsOrig(i)
            Next
            .AssignOptionButtons()
        End With
    End Sub

    Private Sub btnScheme2_Click(sender As System.Object, e As System.EventArgs) Handles btnScheme2.Click
        With SNICSrFrm
            For i = 0 To 9
                .PlotCols(i) = .PlotColsCB(i)
            Next
            .AssignOptionButtons()
        End With
    End Sub

    Private Sub bntResetOptions_Click(sender As Object, e As EventArgs) Handles bntResetOptions.Click
        SNICSrFrm.GetOptions()
    End Sub

    Private Sub btnFactReset_Click(sender As System.Object, e As System.EventArgs) Handles btnFactReset.Click
        Try
            Kill(SNICSrFrm.HomeDirectory & "/SNICSer.opt")
            MsgBox("Options reset to defaults" & vbCrLf & "Restart SNICSer")
            End
        Catch ex As Exception
            MsgBox("Could not reset: please see manual")
        End Try
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.Visible = True
    End Sub

    Private Sub chkTopPlot_CheckedChanged(sender As Object, e As EventArgs) Handles chkTopPlot.CheckedChanged
        Worms.TopMost = chkTopPlot.Checked
        PlotRaw.TopMost = chkTopPlot.Checked
    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = 10
        Me.Top = 10
    End Sub

    Private Sub chkAllowSelfNorm_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllowSelfNorm.CheckedChanged
        SNICSrFrm.AllowSelfNorm = chkAllowSelfNorm.Checked
    End Sub

    Private Sub nudNumStds_ValueChanged(sender As Object, e As EventArgs) Handles nudNumStds.ValueChanged
        If nudNumStds.Value < 3 And cmbFitType.Text = "Linear" Then
            MsgBox("   YOU SILLY GOOSE!!!" & vbCrLf & "To get a slope and scatter estimate, you " & vbCrLf & "should not do a linear fit to less than 3 points")
            nudNumStds.Value = 3
        End If
    End Sub

    Private Sub cmbFitType_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbFitType.SelectedIndexChanged
        If nudNumStds.Value < 3 And cmbFitType.Text = "Linear" Then
            MsgBox("   YOU SILLY GOOSE!!!" & vbCrLf & "To get a slope and scatter estimate, you " & vbCrLf & "should not do a linear fit to less than 3 points")
            nudNumStds.Value = 3
        End If
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub



    Private Sub chkShowStdsBlanks_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowStdsBlanks.CheckedChanged
        SNICSrFrm.ShowStdsBlanks = chkShowStdsBlanks.Checked
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbNumStds.CheckedChanged

    End Sub

    Private Sub nudStdsMult_ValueChanged(sender As Object, e As EventArgs) Handles nudStdsMult.ValueChanged

    End Sub
End Class