Imports ZedGraph

Public Class PropPropPlot

    Private Sub PropPropPlot_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        zc1.Width = Me.Width - zc1.Left / 2
        zc1.Height = Me.Height - zc1.Top - 30
        btnPrint.Left = zc1.Right - btnPrint.Width - 20
        btnClose.Left = btnPrint.Left - btnClose.Width - 10
        chkUnks.Left = btnClose.Left - chkUnks.Width - 5
        chkSecs.Left = chkUnks.Left - chkSecs.Width - 2
        chkBlanks.Left = chkSecs.Left - chkBlanks.Width - 2
        chkStds.Left = chkBlanks.Left - chkStds.Width - 2
    End Sub


    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim bm As Bitmap = GetFormImage()
        SNICSrFrm.thePlot = bm
        SNICSrFrm.PlotPtr.Print()
    End Sub

    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal _
    hdcDest As IntPtr, ByVal nXDest As Integer, ByVal _
    nYDest As Integer, ByVal nWidth As Integer, ByVal _
    nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc _
    As Integer, ByVal nYSrc As Integer, ByVal dwRop As  _
    System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020


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
                    With SNICSrFrm
                        If (.InputData(i).Item(cmbXvar.Text) = crv.Points(inrst).X) And _
                                    (.InputData(i).Item(cmbYvar.Text) = crv.Points(inrst).Y) Then
                            themsg = "Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName") & " (Run " & i.ToString & ")"
                            ToolTip1.Show(themsg, Me, mousePt.X, mousePt.Y)
                            Exit For
                        End If
                    End With
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
        Dim list As New PointPairList
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            SNICSrFrm.RawNum += 1
            Dim rawcolor = SNICSrFrm.RawNum - 10 * (SNICSrFrm.RawNum \ 10)
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                For i = 0 To SNICSrFrm.InputData.Rows.Count - 1
                    With SNICSrFrm
                        If (.InputData(i).Item(cmbXvar.Text) = crv.Points(inrst).X) And _
                                    (.InputData(i).Item(cmbYvar.Text) = crv.Points(inrst).Y) Then
                            Dim posn As Integer = .InputData(i).Item("Pos")
                            For j = 1 To .RunKeys(posn, 0)
                                Dim k As Integer = .RunKeys(posn, j)
                                list.Add(.InputData(k).Item(cmbXvar.Text), .InputData(k).Item(cmbYvar.Text))
                            Next
                            Dim thecrv As LineItem = pane.AddCurve("Tgt " & SNICSrFrm.InputData(i).Item("Pos") & " " & SNICSrFrm.InputData(i).Item("SampleName"), _
                                                                    list, SNICSrFrm.PlotCols(rawcolor), SymbolType.None)
                            thecrv.Line.Width = 2
                            zc1.AxisChange()
                            zc1.Refresh()
                            Exit For
                        End If
                    End With
                Next
            End If
        End If
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

    Private Sub cmbYvar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbYvar.SelectedIndexChanged
        If Not SNICSrFrm.FIRSTPROPPROP And (cmbXvar.Text <> "") And (cmbYvar.Text <> "") Then SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub cmbXvar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbXvar.SelectedIndexChanged
        If Not SNICSrFrm.FIRSTPROPPROP And (cmbXvar.Text <> "") And (cmbYvar.Text <> "") Then SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Visible = False
    End Sub

    Private Sub chkBlanks_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBlanks.CheckedChanged
        If Not SNICSrFrm.FIRSTPROPPROP And Not SNICSrFrm.IamLoading Then SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub chkStds_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStds.CheckedChanged
        If Not SNICSrFrm.FIRSTPROPPROP And Not SNICSrFrm.IamLoading Then SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub chkSecs_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSecs.CheckedChanged
        If Not SNICSrFrm.FIRSTPROPPROP And Not SNICSrFrm.IamLoading Then SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub chkUnks_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUnks.CheckedChanged
        If Not SNICSrFrm.FIRSTPROPPROP And Not SNICSrFrm.IamLoading Then SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub chkExclude_CheckedChanged(sender As Object, e As EventArgs) Handles chkExclude.CheckedChanged
        SNICSrFrm.PlotPropProp()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
    End Sub
End Class