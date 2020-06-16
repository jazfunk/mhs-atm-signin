<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCertRequest
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
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.btnAdd = New System.Windows.Forms.Button
		Me.txtReceiveDate = New System.Windows.Forms.TextBox
		Me.txtRequestDate = New System.Windows.Forms.TextBox
		Me.btnNew = New System.Windows.Forms.Button
		Me.btnClear = New System.Windows.Forms.Button
		Me.lbl_JobNumber = New System.Windows.Forms.Label
		Me.lblJobDesc = New System.Windows.Forms.Label
		Me.btnNext = New System.Windows.Forms.Button
		Me.btnPrevious = New System.Windows.Forms.Button
		Me.lblJob = New System.Windows.Forms.Label
		Me.lblRathcoInvoice = New System.Windows.Forms.Label
		Me.txtRathcoInvoice = New System.Windows.Forms.TextBox
		Me.lblRathcoSalesOrder = New System.Windows.Forms.Label
		Me.txtRathcoSalesOrder = New System.Windows.Forms.TextBox
		Me.lblPO = New System.Windows.Forms.Label
		Me.txtPO = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblRequest = New System.Windows.Forms.Label
		Me.dtpReceived = New System.Windows.Forms.DateTimePicker
		Me.dtpRequest = New System.Windows.Forms.DateTimePicker
		Me.cmbMhsJob = New System.Windows.Forms.ComboBox
		Me.dgvCertsRequested = New System.Windows.Forms.DataGridView
		Me.btnSave = New System.Windows.Forms.Button
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.dgvCertsRequested, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnSave)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtSearch)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnAdd)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtReceiveDate)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtRequestDate)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnNew)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnClear)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_JobNumber)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblJobDesc)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnNext)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnPrevious)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblJob)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblRathcoInvoice)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtRathcoInvoice)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblRathcoSalesOrder)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtRathcoSalesOrder)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblPO)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtPO)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblRequest)
		Me.SplitContainer1.Panel1.Controls.Add(Me.dtpReceived)
		Me.SplitContainer1.Panel1.Controls.Add(Me.dtpRequest)
		Me.SplitContainer1.Panel1.Controls.Add(Me.cmbMhsJob)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCertsRequested)
		Me.SplitContainer1.Size = New System.Drawing.Size(719, 424)
		Me.SplitContainer1.SplitterDistance = 212
		Me.SplitContainer1.TabIndex = 0
		'
		'txtSearch
		'
		Me.txtSearch.Location = New System.Drawing.Point(18, 158)
		Me.txtSearch.Name = "txtSearch"
		Me.txtSearch.Size = New System.Drawing.Size(100, 20)
		Me.txtSearch.TabIndex = 19
		'
		'btnAdd
		'
		Me.btnAdd.Location = New System.Drawing.Point(638, 155)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnAdd.TabIndex = 6
		Me.btnAdd.Text = "Add"
		Me.btnAdd.UseVisualStyleBackColor = True
		'
		'txtReceiveDate
		'
		Me.txtReceiveDate.Location = New System.Drawing.Point(458, 117)
		Me.txtReceiveDate.Name = "txtReceiveDate"
		Me.txtReceiveDate.Size = New System.Drawing.Size(100, 20)
		Me.txtReceiveDate.TabIndex = 5
		'
		'txtRequestDate
		'
		Me.txtRequestDate.Location = New System.Drawing.Point(327, 117)
		Me.txtRequestDate.Name = "txtRequestDate"
		Me.txtRequestDate.Size = New System.Drawing.Size(100, 20)
		Me.txtRequestDate.TabIndex = 3
		'
		'btnNew
		'
		Me.btnNew.Location = New System.Drawing.Point(557, 155)
		Me.btnNew.Name = "btnNew"
		Me.btnNew.Size = New System.Drawing.Size(75, 23)
		Me.btnNew.TabIndex = 18
		Me.btnNew.Text = "New"
		Me.btnNew.UseVisualStyleBackColor = True
		'
		'btnClear
		'
		Me.btnClear.Location = New System.Drawing.Point(184, 29)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(75, 23)
		Me.btnClear.TabIndex = 17
		Me.btnClear.Text = "Clear"
		Me.btnClear.UseVisualStyleBackColor = True
		'
		'lbl_JobNumber
		'
		Me.lbl_JobNumber.AutoSize = True
		Me.lbl_JobNumber.Location = New System.Drawing.Point(51, 101)
		Me.lbl_JobNumber.Name = "lbl_JobNumber"
		Me.lbl_JobNumber.Size = New System.Drawing.Size(58, 13)
		Me.lbl_JobNumber.TabIndex = 16
		Me.lbl_JobNumber.Text = "MHS Job#"
		'
		'lblJobDesc
		'
		Me.lblJobDesc.AutoSize = True
		Me.lblJobDesc.Location = New System.Drawing.Point(51, 55)
		Me.lblJobDesc.Name = "lblJobDesc"
		Me.lblJobDesc.Size = New System.Drawing.Size(80, 13)
		Me.lblJobDesc.TabIndex = 15
		Me.lblJobDesc.Text = "Job Description"
		'
		'btnNext
		'
		Me.btnNext.Location = New System.Drawing.Point(205, 156)
		Me.btnNext.Name = "btnNext"
		Me.btnNext.Size = New System.Drawing.Size(75, 23)
		Me.btnNext.TabIndex = 14
		Me.btnNext.Text = "Next"
		Me.btnNext.UseVisualStyleBackColor = True
		'
		'btnPrevious
		'
		Me.btnPrevious.Location = New System.Drawing.Point(124, 155)
		Me.btnPrevious.Name = "btnPrevious"
		Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
		Me.btnPrevious.TabIndex = 13
		Me.btnPrevious.Text = "Previous"
		Me.btnPrevious.UseVisualStyleBackColor = True
		'
		'lblJob
		'
		Me.lblJob.AutoSize = True
		Me.lblJob.Location = New System.Drawing.Point(51, 15)
		Me.lblJob.Name = "lblJob"
		Me.lblJob.Size = New System.Drawing.Size(58, 13)
		Me.lblJob.TabIndex = 12
		Me.lblJob.Text = "MHS Job#"
		'
		'lblRathcoInvoice
		'
		Me.lblRathcoInvoice.AutoSize = True
		Me.lblRathcoInvoice.Location = New System.Drawing.Point(455, 56)
		Me.lblRathcoInvoice.Name = "lblRathcoInvoice"
		Me.lblRathcoInvoice.Size = New System.Drawing.Size(87, 13)
		Me.lblRathcoInvoice.TabIndex = 11
		Me.lblRathcoInvoice.Text = "Rathco Invoice#"
		'
		'txtRathcoInvoice
		'
		Me.txtRathcoInvoice.Location = New System.Drawing.Point(458, 72)
		Me.txtRathcoInvoice.Name = "txtRathcoInvoice"
		Me.txtRathcoInvoice.Size = New System.Drawing.Size(100, 20)
		Me.txtRathcoInvoice.TabIndex = 4
		'
		'lblRathcoSalesOrder
		'
		Me.lblRathcoSalesOrder.AutoSize = True
		Me.lblRathcoSalesOrder.Location = New System.Drawing.Point(324, 13)
		Me.lblRathcoSalesOrder.Name = "lblRathcoSalesOrder"
		Me.lblRathcoSalesOrder.Size = New System.Drawing.Size(107, 13)
		Me.lblRathcoSalesOrder.TabIndex = 9
		Me.lblRathcoSalesOrder.Text = "Rathco Sales Order#"
		'
		'txtRathcoSalesOrder
		'
		Me.txtRathcoSalesOrder.Location = New System.Drawing.Point(327, 29)
		Me.txtRathcoSalesOrder.Name = "txtRathcoSalesOrder"
		Me.txtRathcoSalesOrder.Size = New System.Drawing.Size(100, 20)
		Me.txtRathcoSalesOrder.TabIndex = 2
		'
		'lblPO
		'
		Me.lblPO.AutoSize = True
		Me.lblPO.Location = New System.Drawing.Point(324, 56)
		Me.lblPO.Name = "lblPO"
		Me.lblPO.Size = New System.Drawing.Size(115, 13)
		Me.lblPO.TabIndex = 7
		Me.lblPO.Text = "MHS Purchase Order#"
		'
		'txtPO
		'
		Me.txtPO.Location = New System.Drawing.Point(327, 72)
		Me.txtPO.Name = "txtPO"
		Me.txtPO.Size = New System.Drawing.Size(100, 20)
		Me.txtPO.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(455, 101)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(73, 13)
		Me.Label1.TabIndex = 5
		Me.Label1.Text = "Receive Date"
		'
		'lblRequest
		'
		Me.lblRequest.AutoSize = True
		Me.lblRequest.Location = New System.Drawing.Point(324, 101)
		Me.lblRequest.Name = "lblRequest"
		Me.lblRequest.Size = New System.Drawing.Size(73, 13)
		Me.lblRequest.TabIndex = 4
		Me.lblRequest.Text = "Request Date"
		'
		'dtpReceived
		'
		Me.dtpReceived.CustomFormat = ""
		Me.dtpReceived.Enabled = False
		Me.dtpReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpReceived.Location = New System.Drawing.Point(604, 38)
		Me.dtpReceived.Name = "dtpReceived"
		Me.dtpReceived.Size = New System.Drawing.Size(103, 20)
		Me.dtpReceived.TabIndex = 3
		Me.dtpReceived.Visible = False
		'
		'dtpRequest
		'
		Me.dtpRequest.CustomFormat = ""
		Me.dtpRequest.Enabled = False
		Me.dtpRequest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpRequest.Location = New System.Drawing.Point(604, 12)
		Me.dtpRequest.Name = "dtpRequest"
		Me.dtpRequest.Size = New System.Drawing.Size(103, 20)
		Me.dtpRequest.TabIndex = 2
		Me.dtpRequest.Visible = False
		'
		'cmbMhsJob
		'
		Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbMhsJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbMhsJob.FormattingEnabled = True
		Me.cmbMhsJob.Location = New System.Drawing.Point(50, 31)
		Me.cmbMhsJob.Name = "cmbMhsJob"
		Me.cmbMhsJob.Size = New System.Drawing.Size(128, 21)
		Me.cmbMhsJob.TabIndex = 0
		'
		'dgvCertsRequested
		'
		Me.dgvCertsRequested.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvCertsRequested.BackgroundColor = System.Drawing.Color.White
		Me.dgvCertsRequested.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvCertsRequested.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvCertsRequested.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvCertsRequested.DefaultCellStyle = DataGridViewCellStyle5
		Me.dgvCertsRequested.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvCertsRequested.EnableHeadersVisualStyles = False
		Me.dgvCertsRequested.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvCertsRequested.Location = New System.Drawing.Point(0, 0)
		Me.dgvCertsRequested.Name = "dgvCertsRequested"
		DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Yellow
		DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvCertsRequested.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
		Me.dgvCertsRequested.RowHeadersVisible = False
		Me.dgvCertsRequested.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvCertsRequested.Size = New System.Drawing.Size(719, 208)
		Me.dgvCertsRequested.TabIndex = 1
		Me.dgvCertsRequested.TabStop = False
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(286, 156)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(100, 23)
		Me.btnSave.TabIndex = 20
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'frmCertRequest
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm1
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(719, 424)
		Me.Controls.Add(Me.SplitContainer1)
		Me.DoubleBuffered = True
		Me.Name = "frmCertRequest"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Certification Requests"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		CType(Me.dgvCertsRequested, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents dgvCertsRequested As System.Windows.Forms.DataGridView
	Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents lblRequest As System.Windows.Forms.Label
	Friend WithEvents dtpReceived As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpRequest As System.Windows.Forms.DateTimePicker
	Friend WithEvents lblRathcoInvoice As System.Windows.Forms.Label
	Friend WithEvents txtRathcoInvoice As System.Windows.Forms.TextBox
	Friend WithEvents lblRathcoSalesOrder As System.Windows.Forms.Label
	Friend WithEvents txtRathcoSalesOrder As System.Windows.Forms.TextBox
	Friend WithEvents lblPO As System.Windows.Forms.Label
	Friend WithEvents txtPO As System.Windows.Forms.TextBox
	Friend WithEvents lblJob As System.Windows.Forms.Label
	Friend WithEvents btnNext As System.Windows.Forms.Button
	Friend WithEvents btnPrevious As System.Windows.Forms.Button
	Friend WithEvents lbl_JobNumber As System.Windows.Forms.Label
	Friend WithEvents lblJobDesc As System.Windows.Forms.Label
	Friend WithEvents btnClear As System.Windows.Forms.Button
	Friend WithEvents btnNew As System.Windows.Forms.Button
	Friend WithEvents txtReceiveDate As System.Windows.Forms.TextBox
	Friend WithEvents txtRequestDate As System.Windows.Forms.TextBox
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents txtSearch As System.Windows.Forms.TextBox
	Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
