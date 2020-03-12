Imports System.Net.Mail
Imports System.Net
Imports System.Text
Imports System.IO


Public Class FrmNotify2ndAuth

    Dim MyHeight As Integer = 0

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.Visible = False
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        MyHeight = Me.Height
        Me.Height = txtMessage.Bottom + 50
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If lbx2ndAuth.Text.Trim = "" Then
            MsgBox("You must select a 2nd Authorizer")
        Else
            Dim Client As New SmtpClient("outbox.whoi.edu", 25)
            Client.Credentials = New NetworkCredential("snicser@whoi.edu", "alert-@-NOSAMS")
            Using msg As New MailMessage
                msg.From = New MailAddress("snicser@whoi.edu")
                If SNICSrFrm.FIRSTAUTH Then
                    msg.Subject = "Wheel " & SNICSrFrm.WheelName & " has been 1st Analyzed"
                    msg.Body = SNICSrFrm.UserName & " has 1st analyzed wheel " & SNICSrFrm.WheelName
                    msg.Body &= " and suggests " & lbx2ndAuth.Text.Trim & " as the 2nd authorizer" & vbCrLf
                Else
                    msg.Subject = "Wheel " & SNICSrFrm.WheelName & " has been 2nd Analyzed"
                    msg.Body = SNICSrFrm.UserName & " has 2nd analyzed wheel " & SNICSrFrm.WheelName & vbCrLf
                End If
                With SNICSrFrm
                    msg.Body &= vbCrLf & "Using V" & .VERSION.ToString("0.000") & " and  " & .CalcMode & " of " & .CalcNum
                    If .GROUPBOUNDS Then msg.Body &= "  Group Bounds Enforced"
                    msg.Body &= vbCrLf & vbCrLf
                End With
                If txtMessage.Text.Trim <> "" Then msg.Body &= vbCrLf & vbCrLf & txtMessage.Text.Trim
                msg.Body &= vbCrLf & vbCrLf & vbCrLf & "Thank you for using SNICSer" & vbCrLf & vbCrLf
                msg.To.Add(New MailAddress(lbx2ndAuth.Text.Trim & "@whoi.edu"))
                For i = 0 To lbx2ndAuth.Items.Count - 1
                    msg.CC.Add(New MailAddress(lbx2ndAuth.Items(i).trim & "@whoi.edu"))
                Next
                Try
                    Client.Send(msg)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Dim post As String = ""
                If SNICSrFrm.FIRSTAUTH Then
                    post = SNICSrFrm.UserName & " has 1st analyzed wheel " & SNICSrFrm.WheelName & " and suggests " & lbx2ndAuth.Text.Trim & " as the 2nd authorizer."
                Else
                    post = SNICSrFrm.UserName & " has 2nd analyzed wheel " & SNICSrFrm.WheelName
                End If
                post &= "\n Using V" & SNICSrFrm.VERSION.ToString("0.000") & " and  " & SNICSrFrm.CalcMode & " of " & SNICSrFrm.CalcNum
                If SNICSrFrm.GROUPBOUNDS Then post &= "  Group Bounds Enforced"
                If txtMessage.Text.Trim <> "" Then post &= "\n" & txtMessage.Text.Trim
                ' slackPost(post) disabled until TLS1.2 is implemented
            End Using
            Me.Height = MyHeight
            Me.Visible = False
        End If
    End Sub

    Public Sub slackPost(post As String)
        'Post to #wheelanalysis on Slack
        Dim request As WebRequest = WebRequest.Create("https://hooks.slack.com/services/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")
        request.Method = "POST"
        Dim postData As String = "payload={""text"": """ & post & """}"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        Try
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.
            dataStream.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class