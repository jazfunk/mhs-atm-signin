<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTOFtoStatus
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
		Me.cmbMhsJob = New System.Windows.Forms.ComboBox
		Me.Button1 = New System.Windows.Forms.Button
		Me.Button2 = New System.Windows.Forms.Button
		Me.DataGridView1 = New System.Windows.Forms.DataGridView
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
		Me.btnAll = New System.Windows.Forms.Button
		Me.btnFilterFS = New System.Windows.Forms.Button
		Me.btnFilterPLY = New System.Windows.Forms.Button
		Me.btnFilterEXT = New System.Windows.Forms.Button
		Me.btnFilterTypeV = New System.Windows.Forms.Button
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'cmbMhsJob
		'
		Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbMhsJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbMhsJob.FormattingEnabled = True
		Me.cmbMhsJob.Location = New System.Drawing.Point(71, 26)
		Me.cmbMhsJob.Name = "cmbMhsJob"
		Me.cmbMhsJob.Size = New System.Drawing.Size(128, 21)
		Me.cmbMhsJob.TabIndex = 2
		Me.cmbMhsJob.Text = "Select Job"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(12, 81)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(442, 23)
		Me.Button1.TabIndex = 3
		Me.Button1.Text = "Start Record Migration"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(205, 26)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(181, 23)
		Me.Button2.TabIndex = 4
		Me.Button2.Text = "Load Combined TakeOff"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.AllowUserToAddRows = False
		Me.DataGridView1.AllowUserToDeleteRows = False
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Location = New System.Drawing.Point(12, 110)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.ReadOnly = True
		Me.DataGridView1.Size = New System.Drawing.Size(442, 178)
		Me.DataGridView1.TabIndex = 5
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(12, 323)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(442, 20)
		Me.TextBox1.TabIndex = 6
		Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Location = New System.Drawing.Point(12, 294)
		Me.ProgressBar1.Name = "ProgressBar1"
		Me.ProgressBar1.Size = New System.Drawing.Size(442, 23)
		Me.ProgressBar1.TabIndex = 7
		'
		'btnAll
		'
		Me.btnAll.Location = New System.Drawing.Point(116, 349)
		Me.btnAll.Name = "btnAll"
		Me.btnAll.Size = New System.Drawing.Size(63, 23)
		Me.btnAll.TabIndex = 172
		Me.btnAll.Text = "All Signs"
		Me.btnAll.UseVisualStyleBackColor = True
		'
		'btnFilterFS
		'
		Me.btnFilterFS.Location = New System.Drawing.Point(323, 349)
		Me.btnFilterFS.Name = "btnFilterFS"
		Me.btnFilterFS.Size = New System.Drawing.Size(63, 23)
		Me.btnFilterFS.TabIndex = 171
		Me.btnFilterFS.Text = "FlatSheet"
		Me.btnFilterFS.UseVisualStyleBackColor = True
		'
		'btnFilterPLY
		'
		Me.btnFilterPLY.Location = New System.Drawing.Point(254, 349)
		Me.btnFilterPLY.Name = "btnFilterPLY"
		Me.btnFilterPLY.Size = New System.Drawing.Size(63, 23)
		Me.btnFilterPLY.TabIndex = 170
		Me.btnFilterPLY.Text = "Plywood"
		Me.btnFilterPLY.UseVisualStyleBackColor = True
		'
		'btnFilterEXT
		'
		Me.btnFilterEXT.Location = New System.Drawing.Point(185, 349)
		Me.btnFilterEXT.Name = "btnFilterEXT"
		Me.btnFilterEXT.Size = New System.Drawing.Size(63, 23)
		Me.btnFilterEXT.TabIndex = 169
		Me.btnFilterEXT.Text = "Extruded"
		Me.btnFilterEXT.UseVisualStyleBackColor = True
		'
		'btnFilterTypeV
		'
		Me.btnFilterTypeV.Location = New System.Drawing.Point(392, 349)
		Me.btnFilterTypeV.Name = "btnFilterTypeV"
		Me.btnFilterTypeV.Size = New System.Drawing.Size(63, 23)
		Me.btnFilterTypeV.TabIndex = 173
		Me.btnFilterTypeV.Text = "Type V"
		Me.btnFilterTypeV.UseVisualStyleBackColor = True
		'
		'frmTOFtoStatus
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(463, 377)
		Me.Controls.Add(Me.btnFilterTypeV)
		Me.Controls.Add(Me.btnAll)
		Me.Controls.Add(Me.btnFilterFS)
		Me.Controls.Add(Me.btnFilterPLY)
		Me.Controls.Add(Me.btnFilterEXT)
		Me.Controls.Add(Me.ProgressBar1)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.cmbMhsJob)
		Me.Name = "frmTOFtoStatus"
		Me.Text = "Migrate TOF to Status Table"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
	Friend WithEvents btnAll As System.Windows.Forms.Button
	Friend WithEvents btnFilterFS As System.Windows.Forms.Button
	Friend WithEvents btnFilterPLY As System.Windows.Forms.Button
	Friend WithEvents btnFilterEXT As System.Windows.Forms.Button
	Friend WithEvents btnFilterTypeV As System.Windows.Forms.Button
End Class
