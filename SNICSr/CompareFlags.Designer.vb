<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompareFlags
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
        Me.dgvFlags = New System.Windows.Forms.DataGridView()
        Me.lblFirst = New System.Windows.Forms.Label()
        Me.lblSecond = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFlags
        '
        Me.dgvFlags.AllowUserToAddRows = False
        Me.dgvFlags.AllowUserToDeleteRows = False
        Me.dgvFlags.AllowUserToResizeColumns = False
        Me.dgvFlags.AllowUserToResizeRows = False
        Me.dgvFlags.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFlags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvFlags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFlags.Location = New System.Drawing.Point(1, 33)
        Me.dgvFlags.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvFlags.Name = "dgvFlags"
        Me.dgvFlags.RowHeadersVisible = False
        Me.dgvFlags.RowTemplate.Height = 28
        Me.dgvFlags.Size = New System.Drawing.Size(445, 630)
        Me.dgvFlags.TabIndex = 0
        '
        'lblFirst
        '
        Me.lblFirst.AutoSize = True
        Me.lblFirst.BackColor = System.Drawing.Color.Red
        Me.lblFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirst.ForeColor = System.Drawing.Color.White
        Me.lblFirst.Location = New System.Drawing.Point(102, 6)
        Me.lblFirst.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(87, 17)
        Me.lblFirst.TabIndex = 1
        Me.lblFirst.Text = "1st Rejected"
        '
        'lblSecond
        '
        Me.lblSecond.AutoSize = True
        Me.lblSecond.BackColor = System.Drawing.Color.Blue
        Me.lblSecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecond.ForeColor = System.Drawing.Color.White
        Me.lblSecond.Location = New System.Drawing.Point(191, 6)
        Me.lblSecond.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSecond.Name = "lblSecond"
        Me.lblSecond.Size = New System.Drawing.Size(92, 17)
        Me.lblSecond.TabIndex = 2
        Me.lblSecond.Text = "2nd Rejected"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Both Rejected"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SeaShell
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(287, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Both Accepted"
        '
        'CompareFlags
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 656)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSecond)
        Me.Controls.Add(Me.lblFirst)
        Me.Controls.Add(Me.dgvFlags)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "CompareFlags"
        Me.Text = "Flag Comparison"
        CType(Me.dgvFlags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFlags As System.Windows.Forms.DataGridView
    Friend WithEvents lblFirst As System.Windows.Forms.Label
    Friend WithEvents lblSecond As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
