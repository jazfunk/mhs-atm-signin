<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDGV_SignCheck
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
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.dgvGenericList = New System.Windows.Forms.DataGridView
		Me.pnlList = New System.Windows.Forms.Panel
		Me.dtpBuildDate = New System.Windows.Forms.DateTimePicker
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.lblDisplay = New System.Windows.Forms.Label
		CType(Me.dgvGenericList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlList.SuspendLayout()
		Me.SuspendLayout()
		'
		'dgvGenericList
		'
		Me.dgvGenericList.AllowUserToAddRows = False
		Me.dgvGenericList.AllowUserToDeleteRows = False
		Me.dgvGenericList.AllowUserToOrderColumns = True
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
		Me.dgvGenericList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvGenericList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvGenericList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.dgvGenericList.BackgroundColor = System.Drawing.Color.White
		Me.dgvGenericList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvGenericList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvGenericList.DefaultCellStyle = DataGridViewCellStyle3
		Me.dgvGenericList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvGenericList.EnableHeadersVisualStyles = False
		Me.dgvGenericList.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvGenericList.Location = New System.Drawing.Point(0, 0)
		Me.dgvGenericList.Name = "dgvGenericList"
		Me.dgvGenericList.ReadOnly = True
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvGenericList.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
		Me.dgvGenericList.RowHeadersVisible = False
		Me.dgvGenericList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvGenericList.Size = New System.Drawing.Size(796, 454)
		Me.dgvGenericList.TabIndex = 4
		Me.dgvGenericList.TabStop = False
		'
		'pnlList
		'
		Me.pnlList.Controls.Add(Me.dgvGenericList)
		Me.pnlList.Dock = System.Windows.Forms.DockStyle.Top
		Me.pnlList.Location = New System.Drawing.Point(0, 0)
		Me.pnlList.Name = "pnlList"
		Me.pnlList.Size = New System.Drawing.Size(796, 454)
		Me.pnlList.TabIndex = 5
		'
		'dtpBuildDate
		'
		Me.dtpBuildDate.CustomFormat = "MM/dd/yyyy"
		Me.dtpBuildDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dtpBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dtpBuildDate.Location = New System.Drawing.Point(12, 460)
		Me.dtpBuildDate.Name = "dtpBuildDate"
		Me.dtpBuildDate.Size = New System.Drawing.Size(199, 31)
		Me.dtpBuildDate.TabIndex = 9
		Me.dtpBuildDate.Value = New Date(2016, 7, 5, 14, 22, 0, 0)
		Me.dtpBuildDate.Visible = False
		'
		'btnOK
		'
		Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnOK.Location = New System.Drawing.Point(575, 460)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(209, 50)
		Me.btnOK.TabIndex = 6
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(387, 460)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(182, 50)
		Me.btnCancel.TabIndex = 7
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'lblDisplay
		'
		Me.lblDisplay.AutoSize = True
		Me.lblDisplay.Location = New System.Drawing.Point(12, 494)
		Me.lblDisplay.Name = "lblDisplay"
		Me.lblDisplay.Size = New System.Drawing.Size(39, 13)
		Me.lblDisplay.TabIndex = 8
		Me.lblDisplay.Text = "Label1"
		'
		'frmDGV_SignCheck
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(796, 512)
		Me.Controls.Add(Me.dtpBuildDate)
		Me.Controls.Add(Me.lblDisplay)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.pnlList)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "frmDGV_SignCheck"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "DGV List"
		CType(Me.dgvGenericList, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlList.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents dgvGenericList As System.Windows.Forms.DataGridView
	Friend WithEvents pnlList As System.Windows.Forms.Panel
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents lblDisplay As System.Windows.Forms.Label
	Friend WithEvents dtpBuildDate As System.Windows.Forms.DateTimePicker
End Class
