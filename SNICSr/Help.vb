Public Class Help

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Visible = False
    End Sub

    Private Sub btnHelpBack_Click(sender As Object, e As EventArgs) Handles btnHelpBack.Click
        HelpBrowser.GoBack()
    End Sub

    Private Sub btnHelpForward_Click(sender As Object, e As EventArgs) Handles btnHelpForward.Click
        HelpBrowser.GoForward()
    End Sub

    Private Sub tmrHelp_Tick(sender As Object, e As EventArgs) Handles tmrHelp.Tick
        btnHelpBack.Visible = helpbrowser.CanGoBack
        btnHelpForward.Visible = helpbrowser.CanGoForward
    End Sub

End Class