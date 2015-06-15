Imports ZedGraph


Public Class PlotRaw

#Region "Variables and Constants"
    Public VarNum As Integer = 0
    Public dx As Double, dy As Double
    Public Nrun As Integer, Npos As Integer
    Public Legend As New DataTable
    Public HaveLegend As Boolean = False
    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal _
    hdcDest As IntPtr, ByVal nXDest As Integer, ByVal _
    nYDest As Integer, ByVal nWidth As Integer, ByVal _
    nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc _
    As Integer, ByVal nYSrc As Integer, ByVal dwRop As  _
    System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020
    Public IAMUPDATING As Boolean = False
    Private ptOriginal As New Point
    Private ptLast As New Point
    Private xStart As Double = -1.0
    Private yStart As Double = -1.0
    Private yGmax As Double = -1.0
    Private yGmin As Double = -1.0
    Public SelVar As Integer = -1

#End Region

    Private Sub PlotRaw_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        dgvLgndWorms.Visible = HaveLegend       ' legend is only visible when you want it
        If Not SNICSrFrm.FirstTimeThrough Then
            SNICSrFrm.FullReSizeDGV(dgvLgndWorms, 5)
            If dgvLgndWorms.Height > Me.Height Then
                dgvLgndWorms.Height = Me.Height - dgvLgndWorms.Top - 50
                dgvLgndWorms.Width = dgvLgndWorms.Width + 20
            End If
        End If
        If HaveLegend Then
            dgvLgndWorms.Left = Me.Width - dgvLgndWorms.Width - 10
            zc1.Width = dgvLgndWorms.Left - zc1.Left
        Else
            zc1.Width = Me.Width - zc1.Left / 2
        End If
        If cmbOther.Text = "None" Then
            zc1.Height = Me.Height - zc1.Top - 30
            zc2.Width = zc1.Width
            zc2.Top = zc1.Bottom
        Else
            zc1.Height = 0.55 * Me.Height - zc1.Top - 30
            zc2.Width = zc1.Width
            zc2.Top = zc1.Bottom
            zc2.Height = Me.Height - zc2.Top - 30
        End If
    End Sub

    Private Sub UpDatePlot(sender As System.Object, e As System.EventArgs)
        If Me.Visible Then
            SNICSrFrm.DoRawPlot(SNICSrFrm.RawCol)
        End If
    End Sub

    Private Sub PlotRaw_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler chkBlanks.CheckedChanged, AddressOf UpDatePlot
        AddHandler chkStds.CheckedChanged, AddressOf UpDatePlot
        AddHandler chkSecs.CheckedChanged, AddressOf UpDatePlot
        AddHandler chkUnks.CheckedChanged, AddressOf UpDatePlot
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        HaveLegend = False
        dgvLgndWorms.Visible = False
        btnWorms.Visible = True
        cmbOther.Text = "None"
        Me.Visible = False
    End Sub

    Private Sub cmbOther_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbOther.SelectedIndexChanged
        If Not IAMUPDATING Then
            If cmbOther.Text = "None" Then
                Me.Height = zc1.Bottom + 10
            Else
                Me.Height = zc2.Bottom + 10
                SNICSrFrm.DoRawPlot(VarNum)
            End If
        End If
    End Sub

    Private Function zc1_MouseMoveEvent(sender As ZedGraph.ZedGraphControl, e As System.Windows.Forms.MouseEventArgs) As System.Boolean Handles zc1.MouseMoveEvent
        Dim mousePt As New PointF(e.X, e.Y)
        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim themsg As String = "None"
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                    If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                        themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                        ToolTip1.Show(themsg, Me, mousePt.X, mousePt.Y)
                        Exit For
                    End If
                Next
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
                For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                    If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                        themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                        ToolTip1.Show(themsg, Me, mousePt.X, mousePt.Y)
                        Exit For
                    End If
                Next
            Else
                ToolTip1.Hide(Me)
            End If
        End If
        Return False
    End Function

    Private Sub zc1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles zc1.MouseClick
        Dim mousePt As New PointF(e.X, e.Y)
        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim opane As GraphPane = zc2.GraphPane
        Dim list As New PointPairList
        Dim olist As New PointPairList
        Dim posn As Integer
        btnWorms.Visible = False
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            SNICSrFrm.RawNum += 1
            Dim rawcolor = SNICSrFrm.RawNum - 10 * (SNICSrFrm.RawNum \ 10)
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                    If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                        posn = SNICSrFrm.InputData(i).Item("Pos")
                        For j = 0 To SNICSrFrm.InputData.Rows.Count - 1
                            If SNICSrFrm.InputData(j).Item("Pos") = posn Then
                                list.Add(SNICSrFrm.RunTimes(j), SNICSrFrm.InputData(j).Item(SNICSrFrm.RawCol))
                                If cmbOther.Text <> "None" Then
                                    olist.Add(SNICSrFrm.RunTimes(j), SNICSrFrm.InputData(j).Item(SNICSrFrm.oVarSel))
                                End If
                            End If
                        Next
                        Dim thecrv As LineItem = pane.AddCurve("Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName"), _
                                                               list, SNICSrFrm.PlotCols(rawcolor), SymbolType.None)
                        thecrv.Line.Width = 2
                        zc1.AxisChange()
                        zc1.Refresh()
                        If cmbOther.Text <> "None" Then
                            Dim ocrv As LineItem = opane.AddCurve("Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName"), _
                                                               olist, SNICSrFrm.PlotCols(rawcolor), SymbolType.None)
                            ocrv.Line.Width = 2
                            zc2.AxisChange()
                            zc2.Refresh()
                        End If
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub zc2_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles zc2.MouseClick
        Dim mousePt As New PointF(e.X, e.Y)
        Dim opane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim pane As GraphPane = zc1.GraphPane
        Dim list As New PointPairList
        Dim olist As New PointPairList
        Dim posn As Integer
        btnWorms.Visible = False
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            SNICSrFrm.RawNum += 1
            Dim rawcolor = SNICSrFrm.RawNum - 10 * (SNICSrFrm.RawNum \ 10)
            opane.ReverseTransform(mousePt, x, y)
            If opane.FindNearestPoint(mousePt, opane.CurveList, crv, inrst) Then
                For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                    If SNICSrFrm.RunTimes(i) >= crv.Points(inrst).X Then
                        posn = SNICSrFrm.InputData(i).Item("Pos")
                        For j = 0 To SNICSrFrm.InputData.Rows.Count - 1
                            If SNICSrFrm.InputData(j).Item("Pos") = posn Then
                                list.Add(SNICSrFrm.RunTimes(j), SNICSrFrm.InputData(j).Item(SNICSrFrm.RawCol))
                                If cmbOther.Text <> "None" Then
                                    olist.Add(SNICSrFrm.RunTimes(j), SNICSrFrm.InputData(j).Item(SNICSrFrm.oVarSel))
                                End If
                            End If
                        Next
                        Dim thecrv As LineItem = pane.AddCurve("Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName"), _
                                                               list, SNICSrFrm.PlotCols(rawcolor), SymbolType.None)
                        thecrv.Line.Width = 2
                        zc1.AxisChange()
                        zc1.Refresh()
                        If cmbOther.Text <> "None" Then
                            Dim ocrv As LineItem = opane.AddCurve("Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName"), _
                                                               olist, SNICSrFrm.PlotCols(rawcolor), SymbolType.None)
                            ocrv.Line.Width = 2
                            zc2.AxisChange()
                            zc2.Refresh()
                        End If
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnWorms_Click(sender As System.Object, e As System.EventArgs) Handles btnWorms.Click
         btnWorms.Visible = False
        dgvLgndWorms.Visible = True
        Legend.Rows.Clear()
        HaveLegend = True
        Dim nRuns As Integer = 0
        Dim theName As String = ""
        With SNICSrFrm
            For i = 0 To 133
                Dim theType As String = .TargetTypes(i)
                If (chkStds.Checked And theType = "S") Or (chkBlanks.Checked And theType = "B") Or _
                    (chkSecs.Checked And theType = "SS") Or (chkUnks.Checked And theType = "U") Then
                    Dim pane As GraphPane = zc1.GraphPane
                    pane.Legend.IsVisible = False
                    Dim list As New PointPairList
                    Dim opane As GraphPane = zc2.GraphPane
                    Dim olist As New PointPairList
                    theName = .TargetNames(i)
                    For j = 1 To .RunKeys(i, 0)
                        Dim k As Integer = .RunKeys(i, j)
                        list.Add(.RunTimes(k), .InputData(k).Item(.RawCol))
                        If cmbOther.Text <> "None" Then
                            olist.Add(SNICSrFrm.RunTimes(k), SNICSrFrm.InputData(k).Item(SNICSrFrm.oVarSel))
                        End If
                    Next
                    .RawNum += 1
                    Dim rawcolor = .RawNum - 10 * (.RawNum \ 10)
                    Dim newrow As DataRow = Legend.NewRow
                    newrow("Pos") = i
                    newrow("SampleName") = SNICSrFrm.TargetNames(i)
                    Legend.Rows.Add(newrow)
                    dgvLgndWorms.Rows(.RawNum).DefaultCellStyle.ForeColor = .PlotCols(rawcolor)
                    Dim thecrv As LineItem = pane.AddCurve("Tgt " & i.ToString & " " & theName, _
                                                            list, .PlotCols(rawcolor), SymbolType.None)
                    thecrv.Line.Width = 2
                    zc1.AxisChange()
                    zc1.Refresh()
                    If cmbOther.Text <> "None" Then
                        Dim ocrv As LineItem = opane.AddCurve("Tgt " & i.ToString & " " & theName, _
                                                           olist, .PlotCols(rawcolor), SymbolType.None)
                        ocrv.Line.Width = 2
                        zc2.AxisChange()
                        zc2.Refresh()
                    End If
                End If
            Next
        End With
        Me.Width = Me.Width + dgvLgndWorms.Width
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim bm As Bitmap = GetFormImage()
        SNICSrFrm.thePlot = bm
        SNICSrFrm.PlotPtr.Print()
    End Sub

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

    Private Sub chkExclude_CheckedChanged(sender As Object, e As EventArgs) Handles chkExclude.CheckedChanged
        If Me.Visible Then SNICSrFrm.DoRawPlot(VarNum)
    End Sub


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
                            .DoRawPlot(SelVar)
                        End With
                    ElseIf msgRes = MsgBoxResult.No Then          ' accept all in range
                        With SNICSrFrm
                            .AcceptRange(xStart, x)
                            .DoRawPlot(SelVar)
                        End With
                    Else
                        SNICSrFrm.DoRawPlot(SelVar)
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
    End Sub
End Class