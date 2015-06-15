Imports ZedGraph

Public Class frmC13compare

    Private Function zc1_MouseMoveEvent(sender As ZedGraph.ZedGraphControl, e As System.Windows.Forms.MouseEventArgs) As System.Boolean Handles zc1.MouseMoveEvent
        Dim mousePt As New PointF(e.X, e.Y)
        Dim pane As GraphPane = sender.MasterPane.FindChartRect(mousePt)
        Dim themsg As String = "None"
        If Not pane Is Nothing Then
            Dim x As Double, y As Double
            Dim crv As CurveItem = Nothing, inrst As Integer = -1
            pane.ReverseTransform(mousePt, x, y)
            If pane.FindNearestPoint(mousePt, pane.CurveList, crv, inrst) Then
                themsg = "Target " & SNICSrFrm.IRMSdC13Pos(inrst).ToString & " (" & SNICSrFrm.TargetData(SNICSrFrm.IRMSdC13Pos(inrst)).Item("SampleName") & ")"
                ToolTip1.Show(themsg, Me, mousePt.X, mousePt.Y)
            End If
        Else
            ToolTip1.Hide(Me)
        End If
        Return False
    End Function

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
                    With SNICSrFrm
                        .TargetSelected = inrst
                        .PopRuns(.TargetSelected)
                    End With
                End If
            End If
        End If
    End Sub


End Class