<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyProductions
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDailyProductions))
		Me.dgvDailyProductions = New System.Windows.Forms.DataGridView
		CType(Me.dgvDailyProductions, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'dgvDailyProductions
		'
		Me.dgvDailyProductions.AllowUserToAddRows = False
		Me.dgvDailyProductions.AllowUserToDeleteRows = False
		Me.dgvDailyProductions.AllowUserToResizeRows = False
		Me.dgvDailyProductions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvDailyProductions.BackgroundColor = System.Drawing.Color.White
		Me.dgvDailyProductions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvDailyProductions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvDailyProductions.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvDailyProductions.EnableHeadersVisualStyles = False
		Me.dgvDailyProductions.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvDailyProductions.Location = New System.Drawing.Point(0, 0)
		Me.dgvDailyProductions.Name = "dgvDailyProductions"
		Me.dgvDailyProductions.ReadOnly = True
		Me.dgvDailyProductions.RowHeadersVisible = False
		Me.dgvDailyProductions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvDailyProductions.Size = New System.Drawing.Size(1016, 596)
		Me.dgvDailyProductions.TabIndex = 0
		'
		'frmDailyProductions
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1016, 596)
		Me.Controls.Add(Me.dgvDailyProductions)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmDailyProductions"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Daily Productions"
		CType(Me.dgvDailyProductions, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents dgvDailyProductions As System.Windows.Forms.DataGridView
End Class
