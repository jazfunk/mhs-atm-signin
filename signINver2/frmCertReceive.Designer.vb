<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCertReceive
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCertReceive))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.txtRathcoSalesOrder = New System.Windows.Forms.TextBox
        Me.txtShipDate = New System.Windows.Forms.TextBox
        Me.lblShipDate = New System.Windows.Forms.Label
        Me.txtJob = New System.Windows.Forms.TextBox
        Me.lblJob = New System.Windows.Forms.Label
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.cmbMhsJob = New System.Windows.Forms.ComboBox
        Me.lblRequest = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReceiveDate = New System.Windows.Forms.TextBox
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.txtRequestDate = New System.Windows.Forms.TextBox
        Me.lblPO = New System.Windows.Forms.Label
        Me.btnNew = New System.Windows.Forms.Button
        Me.lblRathcoSalesOrder = New System.Windows.Forms.Label
        Me.txtRathcoInvoice = New System.Windows.Forms.TextBox
        Me.lblRathcoInvoice = New System.Windows.Forms.Label
        Me.dgvRequests = New System.Windows.Forms.DataGridView
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.btnDeleteCertRcvd = New System.Windows.Forms.Button
        Me.lblEditSelected = New System.Windows.Forms.Label
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.bntUpdateRcvd = New System.Windows.Forms.Button
        Me.txtItemQty = New System.Windows.Forms.TextBox
        Me.txtItemDetails = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnSum = New System.Windows.Forms.Button
        Me.lblItemDetails = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblItemQty = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.dgvJoinedCerts = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJoinedCerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1MinSize = 180
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.SplitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1054, 590)
        Me.SplitContainer1.SplitterDistance = 247
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtRathcoSalesOrder)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtShipDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblShipDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtJob)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblJob)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblJobDesc)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnEdit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnRefresh)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbMhsJob)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblRequest)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtReceiveDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtPO)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtRequestDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblPO)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnNew)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblRathcoSalesOrder)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtRathcoInvoice)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblRathcoInvoice)
        Me.SplitContainer2.Panel1MinSize = 408
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvRequests)
        Me.SplitContainer2.Size = New System.Drawing.Size(1054, 247)
        Me.SplitContainer2.SplitterDistance = 456
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 22
        '
        'txtRathcoSalesOrder
        '
        Me.txtRathcoSalesOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRathcoSalesOrder.Location = New System.Drawing.Point(32, 162)
        Me.txtRathcoSalesOrder.Name = "txtRathcoSalesOrder"
        Me.txtRathcoSalesOrder.Size = New System.Drawing.Size(100, 20)
        Me.txtRathcoSalesOrder.TabIndex = 4
        Me.txtRathcoSalesOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShipDate
        '
        Me.txtShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipDate.Location = New System.Drawing.Point(244, 103)
        Me.txtShipDate.Name = "txtShipDate"
        Me.txtShipDate.Size = New System.Drawing.Size(100, 20)
        Me.txtShipDate.TabIndex = 3
        Me.txtShipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblShipDate
        '
        Me.lblShipDate.AutoSize = True
        Me.lblShipDate.Location = New System.Drawing.Point(244, 87)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(57, 13)
        Me.lblShipDate.TabIndex = 26
        Me.lblShipDate.Text = "Ship Date:"
        '
        'txtJob
        '
        Me.txtJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJob.Location = New System.Drawing.Point(351, 37)
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Size = New System.Drawing.Size(100, 20)
        Me.txtJob.TabIndex = 1
        Me.txtJob.TabStop = False
        Me.txtJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblJob
        '
        Me.lblJob.AutoSize = True
        Me.lblJob.Location = New System.Drawing.Point(318, 40)
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Size = New System.Drawing.Size(27, 13)
        Me.lblJob.TabIndex = 24
        Me.lblJob.Text = "Job:"
        '
        'lblJobDesc
        '
        Me.lblJobDesc.AutoEllipsis = True
        Me.lblJobDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblJobDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobDesc.Location = New System.Drawing.Point(171, 8)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblJobDesc.Size = New System.Drawing.Size(280, 26)
        Me.lblJobDesc.TabIndex = 15
        Me.lblJobDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(380, 160)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(67, 23)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(380, 100)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(67, 23)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(380, 130)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(67, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbMhsJob
        '
        Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMhsJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMhsJob.FormattingEnabled = True
        Me.cmbMhsJob.Location = New System.Drawing.Point(11, 10)
        Me.cmbMhsJob.Name = "cmbMhsJob"
        Me.cmbMhsJob.Size = New System.Drawing.Size(153, 24)
        Me.cmbMhsJob.TabIndex = 0
        '
        'lblRequest
        '
        Me.lblRequest.AutoSize = True
        Me.lblRequest.Location = New System.Drawing.Point(138, 148)
        Me.lblRequest.Name = "lblRequest"
        Me.lblRequest.Size = New System.Drawing.Size(76, 13)
        Me.lblRequest.TabIndex = 4
        Me.lblRequest.Text = "Request Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(244, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Receive Date:"
        '
        'txtReceiveDate
        '
        Me.txtReceiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiveDate.Location = New System.Drawing.Point(244, 162)
        Me.txtReceiveDate.Name = "txtReceiveDate"
        Me.txtReceiveDate.Size = New System.Drawing.Size(100, 20)
        Me.txtReceiveDate.TabIndex = 6
        Me.txtReceiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPO
        '
        Me.txtPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPO.Location = New System.Drawing.Point(32, 103)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(100, 20)
        Me.txtPO.TabIndex = 1
        Me.txtPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRequestDate
        '
        Me.txtRequestDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestDate.Location = New System.Drawing.Point(138, 162)
        Me.txtRequestDate.Name = "txtRequestDate"
        Me.txtRequestDate.Size = New System.Drawing.Size(100, 20)
        Me.txtRequestDate.TabIndex = 5
        Me.txtRequestDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.Location = New System.Drawing.Point(32, 89)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(25, 13)
        Me.lblPO.TabIndex = 7
        Me.lblPO.Text = "PO:"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(272, 201)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(175, 30)
        Me.btnNew.TabIndex = 10
        Me.btnNew.Text = "Enter New Cert Request"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'lblRathcoSalesOrder
        '
        Me.lblRathcoSalesOrder.AutoSize = True
        Me.lblRathcoSalesOrder.Location = New System.Drawing.Point(32, 148)
        Me.lblRathcoSalesOrder.Name = "lblRathcoSalesOrder"
        Me.lblRathcoSalesOrder.Size = New System.Drawing.Size(65, 13)
        Me.lblRathcoSalesOrder.TabIndex = 9
        Me.lblRathcoSalesOrder.Text = "Sales Order:"
        '
        'txtRathcoInvoice
        '
        Me.txtRathcoInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRathcoInvoice.Location = New System.Drawing.Point(138, 103)
        Me.txtRathcoInvoice.Name = "txtRathcoInvoice"
        Me.txtRathcoInvoice.Size = New System.Drawing.Size(100, 20)
        Me.txtRathcoInvoice.TabIndex = 2
        Me.txtRathcoInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRathcoInvoice
        '
        Me.lblRathcoInvoice.AutoSize = True
        Me.lblRathcoInvoice.Location = New System.Drawing.Point(138, 89)
        Me.lblRathcoInvoice.Name = "lblRathcoInvoice"
        Me.lblRathcoInvoice.Size = New System.Drawing.Size(45, 13)
        Me.lblRathcoInvoice.TabIndex = 11
        Me.lblRathcoInvoice.Text = "Invoice:"
        '
        'dgvRequests
        '
        Me.dgvRequests.AllowUserToAddRows = False
        Me.dgvRequests.AllowUserToDeleteRows = False
        Me.dgvRequests.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvRequests.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRequests.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRequests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRequests.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRequests.EnableHeadersVisualStyles = False
        Me.dgvRequests.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvRequests.Location = New System.Drawing.Point(0, 0)
        Me.dgvRequests.Name = "dgvRequests"
        Me.dgvRequests.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRequests.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRequests.RowHeadersVisible = False
        Me.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequests.Size = New System.Drawing.Size(595, 245)
        Me.dgvRequests.TabIndex = 21
        Me.dgvRequests.TabStop = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnDeleteCertRcvd)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblEditSelected)
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvItemList)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bntUpdateRcvd)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtItemQty)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtItemDetails)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ListBox1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnSum)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblItemDetails)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnAdd)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblItemQty)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnReset)
        Me.SplitContainer3.Panel1MinSize = 408
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgvJoinedCerts)
        Me.SplitContainer3.Size = New System.Drawing.Size(1054, 342)
        Me.SplitContainer3.SplitterDistance = 457
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 25
        '
        'btnDeleteCertRcvd
        '
        Me.btnDeleteCertRcvd.Location = New System.Drawing.Point(299, 128)
        Me.btnDeleteCertRcvd.Name = "btnDeleteCertRcvd"
        Me.btnDeleteCertRcvd.Size = New System.Drawing.Size(46, 23)
        Me.btnDeleteCertRcvd.TabIndex = 24
        Me.btnDeleteCertRcvd.Text = "Delete"
        Me.btnDeleteCertRcvd.UseVisualStyleBackColor = True
        '
        'lblEditSelected
        '
        Me.lblEditSelected.Location = New System.Drawing.Point(296, 112)
        Me.lblEditSelected.Name = "lblEditSelected"
        Me.lblEditSelected.Size = New System.Drawing.Size(152, 13)
        Me.lblEditSelected.TabIndex = 23
        Me.lblEditSelected.Text = "Edit/Delete Selected"
        Me.lblEditSelected.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToResizeRows = False
        Me.dgvItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvItemList.BackgroundColor = System.Drawing.Color.White
        Me.dgvItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvItemList.ColumnHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItemList.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvItemList.EnableHeadersVisualStyles = False
        Me.dgvItemList.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvItemList.Location = New System.Drawing.Point(15, 21)
        Me.dgvItemList.MultiSelect = False
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemList.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvItemList.RowHeadersVisible = False
        Me.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItemList.Size = New System.Drawing.Size(275, 303)
        Me.dgvItemList.TabIndex = 0
        Me.dgvItemList.TabStop = False
        '
        'bntUpdateRcvd
        '
        Me.bntUpdateRcvd.Location = New System.Drawing.Point(351, 128)
        Me.bntUpdateRcvd.Name = "bntUpdateRcvd"
        Me.bntUpdateRcvd.Size = New System.Drawing.Size(97, 23)
        Me.bntUpdateRcvd.TabIndex = 1
        Me.bntUpdateRcvd.Text = "Update"
        Me.bntUpdateRcvd.UseVisualStyleBackColor = True
        '
        'txtItemQty
        '
        Me.txtItemQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemQty.Location = New System.Drawing.Point(299, 42)
        Me.txtItemQty.Name = "txtItemQty"
        Me.txtItemQty.Size = New System.Drawing.Size(70, 20)
        Me.txtItemQty.TabIndex = 0
        Me.txtItemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemDetails
        '
        Me.txtItemDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDetails.Location = New System.Drawing.Point(378, 42)
        Me.txtItemDetails.Name = "txtItemDetails"
        Me.txtItemDetails.Size = New System.Drawing.Size(70, 20)
        Me.txtItemDetails.TabIndex = 1
        Me.txtItemDetails.Text = "3990"
        Me.txtItemDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(299, 171)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(149, 95)
        Me.ListBox1.TabIndex = 22
        Me.ListBox1.TabStop = False
        '
        'btnSum
        '
        Me.btnSum.Location = New System.Drawing.Point(299, 301)
        Me.btnSum.Name = "btnSum"
        Me.btnSum.Size = New System.Drawing.Size(149, 23)
        Me.btnSum.TabIndex = 6
        Me.btnSum.Text = "Sum Current List"
        Me.btnSum.UseVisualStyleBackColor = True
        '
        'lblItemDetails
        '
        Me.lblItemDetails.AutoSize = True
        Me.lblItemDetails.Location = New System.Drawing.Point(375, 26)
        Me.lblItemDetails.Name = "lblItemDetails"
        Me.lblItemDetails.Size = New System.Drawing.Size(39, 13)
        Me.lblItemDetails.TabIndex = 15
        Me.lblItemDetails.Text = "Details"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(299, 68)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(149, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add New"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblItemQty
        '
        Me.lblItemQty.AutoSize = True
        Me.lblItemQty.Location = New System.Drawing.Point(296, 26)
        Me.lblItemQty.Name = "lblItemQty"
        Me.lblItemQty.Size = New System.Drawing.Size(49, 13)
        Me.lblItemQty.TabIndex = 16
        Me.lblItemQty.Text = "Quantity:"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(299, 272)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(150, 23)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset/View All"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'dgvJoinedCerts
        '
        Me.dgvJoinedCerts.AllowUserToAddRows = False
        Me.dgvJoinedCerts.AllowUserToDeleteRows = False
        Me.dgvJoinedCerts.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvJoinedCerts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvJoinedCerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvJoinedCerts.BackgroundColor = System.Drawing.Color.White
        Me.dgvJoinedCerts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJoinedCerts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJoinedCerts.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvJoinedCerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJoinedCerts.EnableHeadersVisualStyles = False
        Me.dgvJoinedCerts.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvJoinedCerts.Location = New System.Drawing.Point(0, 0)
        Me.dgvJoinedCerts.Name = "dgvJoinedCerts"
        Me.dgvJoinedCerts.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJoinedCerts.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvJoinedCerts.RowHeadersVisible = False
        Me.dgvJoinedCerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJoinedCerts.Size = New System.Drawing.Size(596, 342)
        Me.dgvJoinedCerts.TabIndex = 18
        Me.dgvJoinedCerts.TabStop = False
        '
        'frmCertReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1054, 590)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCertReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sign Certifications"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJoinedCerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents txtReceiveDate As System.Windows.Forms.TextBox
	Friend WithEvents txtRequestDate As System.Windows.Forms.TextBox
	Friend WithEvents btnNew As System.Windows.Forms.Button
	Friend WithEvents lblJobDesc As System.Windows.Forms.Label
	Friend WithEvents lblRathcoInvoice As System.Windows.Forms.Label
	Friend WithEvents txtRathcoInvoice As System.Windows.Forms.TextBox
	Friend WithEvents lblRathcoSalesOrder As System.Windows.Forms.Label
	Friend WithEvents txtRathcoSalesOrder As System.Windows.Forms.TextBox
	Friend WithEvents lblPO As System.Windows.Forms.Label
	Friend WithEvents txtPO As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents lblRequest As System.Windows.Forms.Label
	Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
	Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
	Friend WithEvents dgvRequests As System.Windows.Forms.DataGridView
	Friend WithEvents btnRefresh As System.Windows.Forms.Button
	Friend WithEvents btnEdit As System.Windows.Forms.Button
	Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
	Friend WithEvents txtItemDetails As System.Windows.Forms.TextBox
	Friend WithEvents lblItemDetails As System.Windows.Forms.Label
	Friend WithEvents txtItemQty As System.Windows.Forms.TextBox
	Friend WithEvents lblItemQty As System.Windows.Forms.Label
	Friend WithEvents dgvJoinedCerts As System.Windows.Forms.DataGridView
	Friend WithEvents txtJob As System.Windows.Forms.TextBox
	Friend WithEvents lblJob As System.Windows.Forms.Label
	Friend WithEvents btnSum As System.Windows.Forms.Button
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents btnReset As System.Windows.Forms.Button
	Friend WithEvents bntUpdateRcvd As System.Windows.Forms.Button
	Friend WithEvents lblShipDate As System.Windows.Forms.Label
	Friend WithEvents txtShipDate As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnDeleteCertRcvd As System.Windows.Forms.Button
    Friend WithEvents lblEditSelected As System.Windows.Forms.Label
End Class
