<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNorm
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
        Me.dgvNorm = New System.Windows.Forms.DataGridView()
        Me.lblMethod = New System.Windows.Forms.Label()
        CType(Me.dgvNorm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNorm
        '
        Me.dgvNorm.AllowUserToAddRows = False
        Me.dgvNorm.AllowUserToDeleteRows = False
        Me.dgvNorm.AllowUserToResizeColumns = False
        Me.dgvNorm.AllowUserToResizeRows = False
        Me.dgvNorm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvNorm.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvNorm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNorm.Location = New System.Drawing.Point(2, 23)
        Me.dgvNorm.Name = "dgvNorm"
        Me.dgvNorm.ReadOnly = True
        Me.dgvNorm.RowHeadersVisible = False
        Me.dgvNorm.Size = New System.Drawing.Size(307, 380)
        Me.dgvNorm.TabIndex = 0
        '
        'lblMethod
        '
        Me.lblMethod.AutoSize = True
        Me.lblMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.Location = New System.Drawing.Point(4, 3)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(39, 13)
        Me.lblMethod.TabIndex = 1
        Me.lblMethod.Text = "Label1"
        '
        'frmNorm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 403)
        Me.Controls.Add(Me.lblMethod)
        Me.Controls.Add(Me.dgvNorm)
        Me.Name = "frmNorm"
        Me.Text = "Form1"
        CType(Me.dgvNorm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvNorm As System.Windows.Forms.DataGridView
    Friend WithEvents lblMethod As System.Windows.Forms.Label
End Class
