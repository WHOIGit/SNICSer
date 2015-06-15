
Imports System.Windows.Forms
Imports System.Drawing


Public Class CmbColor
    Inherits ComboBox

    Public Sub New()
        Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        MyBase.OnDrawItem(e)
        e.DrawBackground()
        Dim item As CmbColorItem = DirectCast(Me.Items(e.Index), CmbColorItem)
        Dim brush As Brush = New SolidBrush(item.ForeColor)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            brush = Brushes.Red
        End If
        Dim bgnd As SolidBrush = New SolidBrush(item.BackColor)
        e.Graphics.FillRectangle(bgnd, e.Bounds)
        e.Graphics.DrawString(item.Text, Me.Font, brush, e.Bounds.X, e.Bounds.Y)
    End Sub

End Class

Public Class CmbColorItem


    Public Property Text() As String

    Public Property Value() As Object

    Public Property ForeColor() As Color

    Public Property BackColor() As Color

    Public Sub New()
        Text = ""
        Value = Nothing
        ForeColor = Color.Black
        BackColor = Color.White
    End Sub

    Public Sub New(pText As String, pValue As Object)
        Text = pText
        Value = pValue
    End Sub

    Public Sub New(pText As String, pValue As Object, fColor As Color, bColor As Color)
        Text = pText
        Value = pValue
        ForeColor = fColor
        BackColor = bColor
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function

End Class
