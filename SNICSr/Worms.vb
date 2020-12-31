Imports ZedGraph

Public Class Worms

#Region "Storage"
    Public Legend As New DataTable
    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal _
    hdcDest As IntPtr, ByVal nXDest As Integer, ByVal _
    nYDest As Integer, ByVal nWidth As Integer, ByVal _
    nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc _
    As Integer, ByVal nYSrc As Integer, ByVal dwRop As  _
    System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020
    Private ptOriginal As New Point
    Private ptLast As New Point
    Private xStart As Double = -1.0
    Private yStart As Double = -1.0
    Private yGmax As Double = -1.0
    Private yGmin As Double = -1.0
    Public cmbGoTo As CmbColor = New CmbColor()

#End Region

#Region "Button Clicks"

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs)
        chkOverlay.Checked = False
        Me.Visible = False
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim bm As Bitmap = GetFormImage()
        SNICSrFrm.thePlot = bm
        SNICSrFrm.PlotPtr.Print()
    End Sub

    Private Sub btnCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculate.Click
        With SNICSrFrm
            .Calculate()
            If .NumPlots > 1 Then
                .DoWormPlots()
            Else
                .PopRuns(.SelectedTarget)
                '.PlotRuns()
            End If
        End With
    End Sub

#End Region

#Region "Hover Messages"

    Private Function zc1_MouseMoveEvent(sender As ZedGraph.ZedGraphControl, e As System.Windows.Forms.MouseEventArgs) As System.Boolean Handles zc1.MouseMoveEvent
        Dim mousePt As New PointF(e.X, e.Y)
        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim themsg As String = "None"
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                If rdbByTime.Checked Then
                    For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                        If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                            themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                            ToolTip1.Show(themsg, Me, mousePt.X, mousePt.Y)
                            Exit For
                        End If
                    Next
                Else
                    For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                        If (SNICSrFrm.InputData(i).Item("Mst") = crv.Points(inrst).X) And (SNICSrFrm.NormRat(i) = crv.Points(inrst).Y) Then
                            themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                            ToolTip1.Show(themsg, Me, mousePt.X, mousePt.Y)
                            Exit For
                        End If
                    Next
                End If
            Else
                ToolTip1.Hide(Me)
            End If
        End If
        Return False
    End Function

    Private Function zc2_MouseMoveEvent(sender As ZedGraph.ZedGraphControl, e As System.Windows.Forms.MouseEventArgs) As System.Boolean Handles zc2.MouseMoveEvent
        Dim mousePt As New PointF(e.X, e.Y)
        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim themsg As String = "None"
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                If rdbByTime.Checked Then
                    For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                        If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                            themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                            ToolTip2.Show(themsg, Me, e.X, e.Y)
                            Exit For
                        End If
                    Next
                Else
                    For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                        If (SNICSrFrm.InputData(i).Item("Mst") = crv.Points(inrst).X) And (SNICSrFrm.InputData(i).Item(cmbOther.Text) = crv.Points(inrst).Y) Then
                            themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                            ToolTip2.Show(themsg, Me, e.X, e.Y)
                            Exit For
                        End If
                    Next
                End If
            Else
                ToolTip2.Hide(Me)
            End If
        End If
        Return False
    End Function

#End Region

#Region "Sundry"

    Private Function GetFormImage() As Bitmap
        ' Get this form's Graphics object.
        Dim me_gr As Graphics = Me.CreateGraphics

        ' Make a Bitmap to hold the image.
        Dim bm As New Bitmap(Me.ClientSize.Width, _
            Me.ClientSize.Height, me_gr)
        Dim bm_gr As Graphics = me_gr.FromImage(bm)
        Dim bm_hdc As IntPtr = bm_gr.GetHdc

        ' Get the form's hDC. We must do this after 
        ' creating the new Bitmap, which uses me_gr.
        Dim me_hdc As IntPtr = me_gr.GetHdc

        ' BitBlt the form's image onto the Bitmap.
        BitBlt(bm_hdc, 0, 0, Me.ClientSize.Width, _
            Me.ClientSize.Height, _
            me_hdc, 0, 0, SRCCOPY)
        me_gr.ReleaseHdc(me_hdc)
        bm_gr.ReleaseHdc(bm_hdc)

        ' Return the result.
        Return bm
    End Function

    Private Sub Worms_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        dgvLgndWorms.Left = Me.Width - dgvLgndWorms.Width + 10
        zc1.Width = Me.Width - zc1.Left / 2 - dgvLgndWorms.Width
        If (cmbOther.Text <> "None") And (Trim(cmbOther.Text) <> "") Then
            zc1.Height = Me.Height / 1.8 - zc1.Top
            zc2.Top = zc1.Bottom
            zc2.Width = zc1.Width
            zc2.Left = zc1.Left
            zc2.Height = Me.Height - zc1.Bottom - 20
            zc2.Visible = True
        Else
            zc1.Height = Me.Height - zc1.Top - 30
            zc2.Visible = False
        End If
    End Sub

#End Region

#Region "Option Changes"

    Private Sub rdbStd_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbStd.CheckedChanged
        SNICSrFrm.WormType = "S"
        SNICSrFrm.WormName = "Standards"
        If Me.Visible Then SNICSrFrm.DoWormPlots()
    End Sub

    Private Sub rdbBlk_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbBlk.CheckedChanged
        SNICSrFrm.WormType = "B"
        SNICSrFrm.WormName = "Blanks"
        If Me.Visible Then SNICSrFrm.DoWormPlots()
    End Sub

    Private Sub rdbSec_CheckedChanged(sender As System.Object, e As System.EventArgs)
        SNICSrFrm.WormType = "SS"
        SNICSrFrm.WormName = "Secondaries"
        If Me.Visible Then SNICSrFrm.PlotWorms()
    End Sub

    Private Sub rdbUnk_CheckedChanged(sender As System.Object, e As System.EventArgs)
        SNICSrFrm.WormType = "U"
        SNICSrFrm.WormName = "Unknowns"
        If Me.Visible Then SNICSrFrm.PlotWorms()
    End Sub

    Private Sub cmbOther_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbOther.SelectedIndexChanged
        For i = 0 To cmbOther.Items.Count - 1
            If cmbOther.Text = cmbOther.Items(i) Then
                If cmbOther.Text = "None" Then
                    Me.Height = zc1.Bottom + 10
                Else
                    Me.Height = zc2.Bottom + 10
                    SNICSrFrm.PlotWorms()
                End If
            End If
        Next
    End Sub

    Private Sub rdbByTime_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbByTime.CheckedChanged
        If Not SNICSrFrm.FirstTimeThrough Then SNICSrFrm.PlotWorms()
    End Sub

    Private Sub chkExclude_CheckedChanged(sender As Object, e As EventArgs) Handles chkExclude.CheckedChanged
        With SNICSrFrm
            If Me.Visible Then
                If .SelectedTarget < 0 Then
                    .DoWormPlots()
                Else
                    .PopRuns(.SelectedTarget)
                End If
            End If
        End With
    End Sub


#End Region

#Region "Keyboard Responses (for Prev/Next)"

    Private Sub Worms_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, zc1.KeyDown, zc2.KeyDown
        Select Case e.KeyCode
            Case Keys.Right, Keys.Down, Keys.Enter          ' right, down arrows and enter key advance
                doNext()
                e.Handled = True
            Case Keys.Left, Keys.Up, Keys.Back              ' left, up, backspace go back
                doPrev()
                e.Handled = True
        End Select
    End Sub

    Private Sub cmbOther_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbOther.KeyDown
        Select Case e.KeyCode
            Case Keys.Right, Keys.Down, Keys.Enter          ' right, down arrows and enter key advance
                doNext()
                e.Handled = True
            Case Keys.Left, Keys.Up, Keys.Back              ' left, up, backspace go back
                doPrev()
                e.Handled = True
        End Select
    End Sub

    Private Sub btnPrev_Click(sender As System.Object, e As System.EventArgs) Handles btnPrev.Click, btnPrev2.Click
        doPrev()
    End Sub

    Private Sub doPrev()
        With SNICSrFrm
            For i = 1 To .TargetData.Rows.Count - 1
                If .TargetSelected = .TargetData(i).Item("Pos") Then
                    .PopRuns(.TargetData(i - 1).Item("Pos"))
                    Exit For
                End If
            Next
        End With
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click, btnNext2.Click
        doNext()
    End Sub

    Private Sub doNext()
        With SNICSrFrm
            For i = 0 To .TargetData.Rows.Count - 2
                If .TargetSelected = .TargetData(i).Item("Pos") Then
                    .PopRuns(.TargetData(i + 1).Item("Pos"))
                    Exit For
                End If
            Next
        End With
    End Sub


#End Region

#Region "Toggle Points"

    Private Sub zc1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles zc1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim mousePt As New PointF(e.X, e.Y)
            Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
            Dim list As New PointPairList
            If Not pane Is Nothing Then
                Dim x As Double, y As Double
                Dim crv As CurveItem = Nothing, inrst As Integer = -1
                pane.ReverseTransform(mousePt, x, y)
                If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                    If rdbByTime.Checked Then
                        For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                            If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                                SNICSrFrm.ToggleRun(i)
                                Exit For
                            End If
                        Next
                    Else
                        For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                            If (SNICSrFrm.InputData(i).Item("Mst") = crv.Points(inrst).X) And (SNICSrFrm.NormRat(i) = crv.Points(inrst).Y) Then
                                SNICSrFrm.ToggleRun(i)
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub zc2_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles zc2.MouseClick
        Dim mousePt As New PointF(e.X, e.Y)
        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim list As New PointPairList
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                If rdbByTime.Checked Then
                    For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                        If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                            SNICSrFrm.ToggleRun(i)
                            Exit For
                        End If
                    Next
                Else
                    For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                        If (SNICSrFrm.InputData(i).Item("Mst") = crv.Points(inrst).X) And (SNICSrFrm.InputData(i).Item(cmbOther.Text) = crv.Points(inrst).Y) Then
                            SNICSrFrm.ToggleRun(i)
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
    End Sub

#End Region

#Region "Box Toggling"
    ' the code below serves to allow the user to use the right mouse button drag to
    ' create an interval in the plot and then toggle the state of all the points
    ' inside the defined time span to all true or false

    Private Function zc1_MouseDownEvent(sender As ZedGraphControl, e As MouseEventArgs) As System.Boolean Handles zc1.MouseDownEvent, zc2.MouseDownEvent
        If e.Button = Windows.Forms.MouseButtons.Right Then     ' this initiates the process
            Dim pane As GraphPane = sender.MasterPane.FindChartRect(e.Location)
            yGmax = pane.YAxis.Scale.Max
            yGmin = pane.YAxis.Scale.Min
            Try
                pane.ReverseTransform(e.Location, xStart, yStart)
                ptOriginal = e.Location
                ptLast = ptOriginal
            Catch ex As Exception
                ' ignore errors
            End Try
        End If
        Return False
    End Function

    Private Sub zc1_MouseMove(sender As ZedGraphControl, e As MouseEventArgs) Handles zc1.MouseMove, zc2.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If ptLast <> e.Location Then        ' have we genuinely moved?
                sender.IsShowContextMenu = False       ' We are right mouse dragging, so suspend the popup menu
                Dim pane As GraphPane = sender.MasterPane.FindChartRect(e.Location)
                Dim x As Double, y As Double
                Try
                    pane.CurveList.Remove(pane.CurveList("Box"))
                    sender.Invalidate()
                    sender.Refresh()
                Catch ex As Exception

                End Try
                Try
                    pane.ReverseTransform(e.Location, x, y)
                    Dim theBox As New PointPairList
                    theBox.Add(xStart, yGmin)
                    theBox.Add(xStart, yGmax)
                    theBox.Add(x, yGmax)
                    theBox.Add(x, yGmin)
                    theBox.Add(xStart, yGmin)
                    Dim theCrv As LineItem = pane.AddCurve("Box", theBox, Color.Red, SymbolType.None)
                    theCrv.Line.Width = 1
                    sender.Invalidate()
                    sender.Refresh()
                Catch ex As Exception

                End Try
            End If
            ' create a graphics object on the plot that defines the time span
        End If
    End Sub

    Private Function zc1_MouseUpEvent(sender As ZedGraphControl, e As MouseEventArgs) As System.Boolean Handles zc1.MouseUpEvent, zc2.MouseUpEvent
        If e.Button = Windows.Forms.MouseButtons.Right Then     ' this terminates the process
            If ptOriginal <> e.Location Then
                Dim pane As GraphPane = sender.MasterPane.FindChartRect(e.Location)
                Dim x As Double, y As Double
                Try
                    pane.ReverseTransform(e.Location, x, y)
                    If x < xStart Then          ' we have a reverse box!
                        Dim xtemp As Double = xStart
                        xStart = x
                        x = xtemp
                    End If
                    Dim theBox As New PointPairList
                    theBox.Add(xStart, yGmin)
                    theBox.Add(xStart, yGmax)
                    theBox.Add(x, yGmax)
                    theBox.Add(x, yGmin)
                    theBox.Add(xStart, yGmin)
                    Dim theCrv As LineItem = pane.AddCurve("Box", theBox, Color.Red, SymbolType.None)
                    theCrv.Line.Width = 5
                    sender.Invalidate()
                    sender.Refresh()
                    Dim theMsg As String = "You have selected a span from " & DateTime.FromOADate(xStart).ToShortTimeString & " on " & DateTime.FromOADate(xStart).ToLongDateString & vbCrLf
                    theMsg &= "                                  to " & DateTime.FromOADate(x).ToShortTimeString & " on " & DateTime.FromOADate(x).ToLongDateString & vbCrLf
                    theMsg &= "Do you wish to reject ALL sample runs between these times?" & vbCrLf _
                                            & "YES = Reject All,   NO = Accept All,   CANCEL = Leave as is"
                    Dim msgRes As MsgBoxResult = MsgBox(theMsg, vbYesNoCancel)
                    pane.CurveList("Box").Clear()
                    sender.Invalidate()
                    sender.Refresh()
                    If msgRes = MsgBoxResult.Yes Then                        ' reject all in range
                        With SNICSrFrm
                            .RejectRange(xStart, x)
                            .PlotWorms()
                        End With
                    ElseIf msgRes = MsgBoxResult.No Then          ' accept all in range
                        With SNICSrFrm
                            .AcceptRange(xStart, x)
                            .PlotWorms()
                        End With
                    Else
                        SNICSrFrm.PlotWorms()
                    End If
                Catch ex As Exception
                    ' ignore error
                End Try
            End If
            sender.IsShowContextMenu = True            ' allow the popup menu again
        End If
        Return False
    End Function


#End Region

    Private Sub btnReplot_Click(sender As Object, e As EventArgs) Handles btnReplot.Click
        With SNICSrFrm
            If .NumPlots > 1 Then
                .SelectedTarget = -1     ' deselect any target number for point toggling
                With Me
                    .btnPrev.Visible = False
                    .btnNext.Visible = False
                    .btnPrev2.Visible = False
                    .btnNext2.Visible = False
                    .chkOverlay.Visible = False
                    .btnPlotBlks.Visible = False
                    .btnPlotStds.Visible = False
                    .rdbBlk.Visible = True
                    .rdbStd.Visible = True
                End With
                .NumPlots = 0
                For i = 0 To 133
                    If .TargetTypes(i) = .WormType Then
                        .PlotList(.NumPlots) = i
                        .NumPlots += 1
                    End If
                Next
                .PlotWorms()
            Else
                .PopRuns(.SelectedTarget)
            End If
        End With

    End Sub
    'can't use system close box because of the way worms is instantiated. Maybe move subs that use worms to worms.vb?
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        chkOverlay.Checked = False
        Me.Visible = False
    End Sub

    Private Sub cmbGoTo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        SNICSrFrm.PopRuns(CInt(cmb.Text.Substring(0, cmb.Text.IndexOf(":"))))
    End Sub

    Private Sub Worms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Add(cmbGoTo)
        With cmbGoTo
            .Visible = True
            .Top = 2
            .Left = 2
            .Width = 160
            .Height = 35
            .Font = New Font("Arial", 10)
            AddHandler cmbGoTo.SelectedIndexChanged, AddressOf cmbGoTo_SelectedIndexChanged
        End With
    End Sub

    Private Sub btnPlotStds_Click(sender As Object, e As EventArgs) Handles btnPlotStds.Click
        Me.rdbStd.Checked = True
        SNICSrFrm.TargetSelected = -1
        SNICSrFrm.DoWormPlots()
    End Sub

    Private Sub btnPlotBlks_Click(sender As Object, e As EventArgs) Handles btnPlotBlks.Click
        Me.rdbBlk.Checked = True
        SNICSrFrm.TargetSelected = -1
        SNICSrFrm.DoWormPlots()
    End Sub

End Class