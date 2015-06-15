Public Class WheelID
    Public Month As Integer = 0
    Public Year As Integer = 0
    Public Name As String = ""
    Public Analyzed As Integer = 0
    Public FirstAuthName As String = ""
    Public SecondAuthName As String = ""
    Public FirstAuthDate As Date = New Date(1900, 1, 1)
    Public SecondAuthDate As Date = New Date(1900, 1, 1)
    Public Method1 As String = ""
    Public Method2 As String = ""
    Public IsReadOnly As Boolean = False

    Public Sub New(theName As String)
        Name = theName
        If theName.Length >= 11 Then
            Try
                Month = CInt(theName.Substring(5, 2))
                Year = CInt(theName.Substring(9, 2))
                Analyzed = 0
            Catch ex As Exception
                MsgBox("In Class: " & ex.Message & Name)
            End Try
        End If
    End Sub

End Class
