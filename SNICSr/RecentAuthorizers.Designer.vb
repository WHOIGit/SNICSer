<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RecentAuthorizers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvRecentAuthorizers = New System.Windows.Forms.DataGridView()
        CType(Me.dgvRecentAuthorizers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(11, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(82, 27)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvRecentAuthorizers
        '
        Me.dgvRecentAuthorizers.AllowUserToAddRows = False
        Me.dgvRecentAuthorizers.AllowUserToDeleteRows = False
        Me.dgvRecentAuthorizers.AllowUserToResizeRows = False
        Me.dgvRecentAuthorizers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRecentAuthorizers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecentAuthorizers.Location = New System.Drawing.Point(6, 35)
        Me.dgvRecentAuthorizers.Name = "dgvRecentAuthorizers"
        Me.dgvRecentAuthorizers.RowHeadersVisible = False
        Me.dgvRecentAuthorizers.RowHeadersWidth = 47
        Me.dgvRecentAuthorizers.Size = New System.Drawing.Size(642, 529)
        Me.dgvRecentAuthorizers.TabIndex = 1
        '
        'RecentAuthorizers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 567)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvRecentAuthorizers)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "RecentAuthorizers"
        Me.Text = "Recent Authorizers"
        CType(Me.dgvRecentAuthorizers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgvRecentAuthorizers As System.Windows.Forms.DataGridView
End Class
