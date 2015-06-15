<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GroupPlot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.zc1 = New ZedGraph.ZedGraphControl()
        Me.SuspendLayout()
        '
        'zc1
        '
        Me.zc1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zc1.Location = New System.Drawing.Point(1, 56)
        Me.zc1.Name = "zc1"
        Me.zc1.ScrollGrace = 0.0R
        Me.zc1.ScrollMaxX = 0.0R
        Me.zc1.ScrollMaxY = 0.0R
        Me.zc1.ScrollMaxY2 = 0.0R
        Me.zc1.ScrollMinX = 0.0R
        Me.zc1.ScrollMinY = 0.0R
        Me.zc1.ScrollMinY2 = 0.0R
        Me.zc1.Size = New System.Drawing.Size(968, 286)
        Me.zc1.TabIndex = 2
        '
        'GroupPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 343)
        Me.Controls.Add(Me.zc1)
        Me.Name = "GroupPlot"
        Me.Text = "GroupPlot"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents zc1 As ZedGraph.ZedGraphControl
End Class
