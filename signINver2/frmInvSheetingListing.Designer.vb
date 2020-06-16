<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvSheetingListing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvSheetingListing))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblSheetingID = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lbl3M = New System.Windows.Forms.Label()
        Me.pic3M = New System.Windows.Forms.PictureBox()
        Me.cmbSheetingCode = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ckbDepleted = New System.Windows.Forms.CheckBox()
        Me.cmbEXTTOFFields = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.txtCarrier = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblSqrFt = New System.Windows.Forms.Label()
        Me.lblSheeting = New System.Windows.Forms.Label()
        Me.picSheetingDesc = New System.Windows.Forms.PictureBox()
        Me.grpDimensions = New System.Windows.Forms.GroupBox()
        Me.lblRowWidth = New System.Windows.Forms.Label()
        Me.lblInches = New System.Windows.Forms.Label()
        Me.txtRollWidth = New System.Windows.Forms.TextBox()
        Me.lblYards = New System.Windows.Forms.Label()
        Me.txtRollLength = New System.Windows.Forms.TextBox()
        Me.lblRollLength = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.eDtpRecvDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker()
        Me.lblRcvDate = New System.Windows.Forms.Label()
        Me.eDtpShipDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker()
        Me.lblShipDate = New System.Windows.Forms.Label()
        Me.txtDrum = New System.Windows.Forms.TextBox()
        Me.lblDrum = New System.Windows.Forms.Label()
        Me.txtLot = New System.Windows.Forms.TextBox()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.txtRollQty = New System.Windows.Forms.TextBox()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.txtInvoice = New System.Windows.Forms.TextBox()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.lblRollQty = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvSheetingListing = New System.Windows.Forms.DataGridView()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.pic3M, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSheetingDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDimensions.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvSheetingListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(1)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSheetingID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnOK)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl3M)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pic3M)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSheetingCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ckbDepleted)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbEXTTOFFields)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCriteria)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSaveChanges)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCarrier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSqrFt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSheeting)
        Me.SplitContainer1.Panel1.Controls.Add(Me.picSheetingDesc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpDimensions)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCarrier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.eDtpRecvDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRcvDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.eDtpShipDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblShipDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDrum)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDrum)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLot)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblLot)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtRollQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblInvoice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtInvoice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblPO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRollQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNew)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEdit)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvSheetingListing)
        Me.SplitContainer1.Size = New System.Drawing.Size(806, 571)
        Me.SplitContainer1.SplitterDistance = 245
        Me.SplitContainer1.TabIndex = 1
        '
        'lblSheetingID
        '
        Me.lblSheetingID.AutoSize = True
        Me.lblSheetingID.BackColor = System.Drawing.Color.Transparent
        Me.lblSheetingID.Location = New System.Drawing.Point(12, 198)
        Me.lblSheetingID.Name = "lblSheetingID"
        Me.lblSheetingID.Size = New System.Drawing.Size(18, 13)
        Me.lblSheetingID.TabIndex = 129
        Me.lblSheetingID.Text = "ID"
        Me.lblSheetingID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(12, 214)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(47, 23)
        Me.btnOK.TabIndex = 128
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbl3M
        '
        Me.lbl3M.AutoSize = True
        Me.lbl3M.BackColor = System.Drawing.Color.Transparent
        Me.lbl3M.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3M.Location = New System.Drawing.Point(673, 62)
        Me.lbl3M.Name = "lbl3M"
        Me.lbl3M.Size = New System.Drawing.Size(110, 14)
        Me.lbl3M.TabIndex = 127
        Me.lbl3M.Text = "Authorized Fabricator"
        '
        'pic3M
        '
        Me.pic3M.Image = Global.signINver2.My.Resources.Resources.MMMLogo
        Me.pic3M.Location = New System.Drawing.Point(678, 12)
        Me.pic3M.Name = "pic3M"
        Me.pic3M.Size = New System.Drawing.Size(100, 50)
        Me.pic3M.TabIndex = 126
        Me.pic3M.TabStop = False
        '
        'cmbSheetingCode
        '
        Me.cmbSheetingCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSheetingCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSheetingCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbSheetingCode.DropDownHeight = 124
        Me.cmbSheetingCode.FormattingEnabled = True
        Me.cmbSheetingCode.IntegralHeight = False
        Me.cmbSheetingCode.Location = New System.Drawing.Point(38, 13)
        Me.cmbSheetingCode.Name = "cmbSheetingCode"
        Me.cmbSheetingCode.Size = New System.Drawing.Size(112, 21)
        Me.cmbSheetingCode.TabIndex = 0
        Me.cmbSheetingCode.Text = "Sheeting"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(678, 141)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(101, 23)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'ckbDepleted
        '
        Me.ckbDepleted.AutoSize = True
        Me.ckbDepleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbDepleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbDepleted.ForeColor = System.Drawing.Color.DarkGreen
        Me.ckbDepleted.Location = New System.Drawing.Point(508, 35)
        Me.ckbDepleted.Name = "ckbDepleted"
        Me.ckbDepleted.Size = New System.Drawing.Size(101, 24)
        Me.ckbDepleted.TabIndex = 11
        Me.ckbDepleted.Text = "Depleted"
        Me.ckbDepleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbDepleted.UseVisualStyleBackColor = True
        '
        'cmbEXTTOFFields
        '
        Me.cmbEXTTOFFields.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbEXTTOFFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbEXTTOFFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEXTTOFFields.DropDownHeight = 300
        Me.cmbEXTTOFFields.FormattingEnabled = True
        Me.cmbEXTTOFFields.IntegralHeight = False
        Me.cmbEXTTOFFields.Items.AddRange(New Object() {"Roll Width", "Roll Length", "Code", "Roll Qty", "PO", "Lot", "Drum", "Invoice", "Carrier"})
        Me.cmbEXTTOFFields.Location = New System.Drawing.Point(100, 216)
        Me.cmbEXTTOFFields.Name = "cmbEXTTOFFields"
        Me.cmbEXTTOFFields.Size = New System.Drawing.Size(226, 21)
        Me.cmbEXTTOFFields.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(332, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "By"
        '
        'txtCriteria
        '
        Me.txtCriteria.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCriteria.Location = New System.Drawing.Point(357, 216)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(338, 20)
        Me.txtCriteria.TabIndex = 17
        Me.txtCriteria.Text = "Type search text here"
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSaveChanges.Location = New System.Drawing.Point(701, 214)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(78, 23)
        Me.btnSaveChanges.TabIndex = 18
        Me.btnSaveChanges.Text = "Save Changes"
        Me.btnSaveChanges.UseVisualStyleBackColor = True
        '
        'lblFilter
        '
        Me.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFilter.AutoSize = True
        Me.lblFilter.BackColor = System.Drawing.Color.Transparent
        Me.lblFilter.Location = New System.Drawing.Point(65, 219)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(29, 13)
        Me.lblFilter.TabIndex = 124
        Me.lblFilter.Text = "Filter"
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCarrier.Location = New System.Drawing.Point(357, 174)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.Size = New System.Drawing.Size(137, 20)
        Me.txtCarrier.TabIndex = 8
        Me.txtCarrier.Text = "UPS"
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCode.Location = New System.Drawing.Point(38, 38)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(112, 20)
        Me.txtCode.TabIndex = 1
        Me.txtCode.Text = "3937"
        '
        'lblSqrFt
        '
        Me.lblSqrFt.AutoSize = True
        Me.lblSqrFt.BackColor = System.Drawing.Color.Transparent
        Me.lblSqrFt.Location = New System.Drawing.Point(35, 158)
        Me.lblSqrFt.Name = "lblSqrFt"
        Me.lblSqrFt.Size = New System.Drawing.Size(51, 13)
        Me.lblSqrFt.TabIndex = 119
        Me.lblSqrFt.Text = "6,000 sFt"
        Me.lblSqrFt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSheeting
        '
        Me.lblSheeting.BackColor = System.Drawing.Color.Transparent
        Me.lblSheeting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSheeting.Location = New System.Drawing.Point(158, 39)
        Me.lblSheeting.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSheeting.Name = "lblSheeting"
        Me.lblSheeting.Size = New System.Drawing.Size(157, 16)
        Me.lblSheeting.TabIndex = 118
        Me.lblSheeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picSheetingDesc
        '
        Me.picSheetingDesc.BackColor = System.Drawing.Color.Transparent
        Me.picSheetingDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSheetingDesc.Location = New System.Drawing.Point(156, 37)
        Me.picSheetingDesc.Name = "picSheetingDesc"
        Me.picSheetingDesc.Size = New System.Drawing.Size(161, 21)
        Me.picSheetingDesc.TabIndex = 117
        Me.picSheetingDesc.TabStop = False
        '
        'grpDimensions
        '
        Me.grpDimensions.BackColor = System.Drawing.Color.Transparent
        Me.grpDimensions.Controls.Add(Me.lblRowWidth)
        Me.grpDimensions.Controls.Add(Me.lblInches)
        Me.grpDimensions.Controls.Add(Me.txtRollWidth)
        Me.grpDimensions.Controls.Add(Me.lblYards)
        Me.grpDimensions.Controls.Add(Me.txtRollLength)
        Me.grpDimensions.Controls.Add(Me.lblRollLength)
        Me.grpDimensions.Location = New System.Drawing.Point(154, 80)
        Me.grpDimensions.Name = "grpDimensions"
        Me.grpDimensions.Size = New System.Drawing.Size(161, 100)
        Me.grpDimensions.TabIndex = 3
        Me.grpDimensions.TabStop = False
        Me.grpDimensions.Text = "Sheeting Dimensions"
        '
        'lblRowWidth
        '
        Me.lblRowWidth.AutoSize = True
        Me.lblRowWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblRowWidth.Location = New System.Drawing.Point(7, 25)
        Me.lblRowWidth.Name = "lblRowWidth"
        Me.lblRowWidth.Size = New System.Drawing.Size(56, 13)
        Me.lblRowWidth.TabIndex = 34
        Me.lblRowWidth.Text = "Roll Width"
        Me.lblRowWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInches
        '
        Me.lblInches.AutoSize = True
        Me.lblInches.BackColor = System.Drawing.Color.Transparent
        Me.lblInches.Location = New System.Drawing.Point(49, 73)
        Me.lblInches.Name = "lblInches"
        Me.lblInches.Size = New System.Drawing.Size(39, 13)
        Me.lblInches.TabIndex = 69
        Me.lblInches.Text = "Inches"
        Me.lblInches.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtRollWidth
        '
        Me.txtRollWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRollWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollWidth.ForeColor = System.Drawing.Color.Black
        Me.txtRollWidth.Location = New System.Drawing.Point(10, 41)
        Me.txtRollWidth.Name = "txtRollWidth"
        Me.txtRollWidth.Size = New System.Drawing.Size(78, 29)
        Me.txtRollWidth.TabIndex = 1
        Me.txtRollWidth.Text = "48"
        Me.txtRollWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblYards
        '
        Me.lblYards.AutoSize = True
        Me.lblYards.BackColor = System.Drawing.Color.Transparent
        Me.lblYards.Location = New System.Drawing.Point(118, 73)
        Me.lblYards.Name = "lblYards"
        Me.lblYards.Size = New System.Drawing.Size(34, 13)
        Me.lblYards.TabIndex = 68
        Me.lblYards.Text = "Yards"
        Me.lblYards.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtRollLength
        '
        Me.txtRollLength.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRollLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollLength.ForeColor = System.Drawing.Color.Black
        Me.txtRollLength.Location = New System.Drawing.Point(94, 41)
        Me.txtRollLength.Name = "txtRollLength"
        Me.txtRollLength.Size = New System.Drawing.Size(58, 29)
        Me.txtRollLength.TabIndex = 2
        Me.txtRollLength.Text = "50"
        Me.txtRollLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRollLength
        '
        Me.lblRollLength.AutoSize = True
        Me.lblRollLength.BackColor = System.Drawing.Color.Transparent
        Me.lblRollLength.Location = New System.Drawing.Point(91, 25)
        Me.lblRollLength.Name = "lblRollLength"
        Me.lblRollLength.Size = New System.Drawing.Size(61, 13)
        Me.lblRollLength.TabIndex = 38
        Me.lblRollLength.Text = "Roll Length"
        Me.lblRollLength.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCarrier
        '
        Me.lblCarrier.AutoSize = True
        Me.lblCarrier.BackColor = System.Drawing.Color.Transparent
        Me.lblCarrier.Location = New System.Drawing.Point(354, 157)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(37, 13)
        Me.lblCarrier.TabIndex = 116
        Me.lblCarrier.Text = "Carrier"
        '
        'eDtpRecvDate
        '
        Me.eDtpRecvDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpRecvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpRecvDate.Location = New System.Drawing.Point(517, 173)
        Me.eDtpRecvDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpRecvDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpRecvDate.Name = "eDtpRecvDate"
        Me.eDtpRecvDate.Size = New System.Drawing.Size(92, 20)
        Me.eDtpRecvDate.TabIndex = 10
        Me.eDtpRecvDate.Value = New Date(2010, 2, 27, 0, 0, 0, 0)
        '
        'lblRcvDate
        '
        Me.lblRcvDate.AutoSize = True
        Me.lblRcvDate.BackColor = System.Drawing.Color.Transparent
        Me.lblRcvDate.Location = New System.Drawing.Point(514, 157)
        Me.lblRcvDate.Name = "lblRcvDate"
        Me.lblRcvDate.Size = New System.Drawing.Size(79, 13)
        Me.lblRcvDate.TabIndex = 115
        Me.lblRcvDate.Text = "Received Date"
        '
        'eDtpShipDate
        '
        Me.eDtpShipDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpShipDate.Location = New System.Drawing.Point(517, 126)
        Me.eDtpShipDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpShipDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpShipDate.Name = "eDtpShipDate"
        Me.eDtpShipDate.Size = New System.Drawing.Size(92, 20)
        Me.eDtpShipDate.TabIndex = 9
        Me.eDtpShipDate.Value = New Date(2010, 2, 27, 0, 0, 0, 0)
        '
        'lblShipDate
        '
        Me.lblShipDate.AutoSize = True
        Me.lblShipDate.BackColor = System.Drawing.Color.Transparent
        Me.lblShipDate.Location = New System.Drawing.Point(514, 110)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(54, 13)
        Me.lblShipDate.TabIndex = 114
        Me.lblShipDate.Text = "Ship Date"
        '
        'txtDrum
        '
        Me.txtDrum.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDrum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDrum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrum.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.txtDrum.Location = New System.Drawing.Point(407, 95)
        Me.txtDrum.Name = "txtDrum"
        Me.txtDrum.Size = New System.Drawing.Size(67, 26)
        Me.txtDrum.TabIndex = 6
        Me.txtDrum.Text = "1"
        Me.txtDrum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDrum
        '
        Me.lblDrum.AutoSize = True
        Me.lblDrum.BackColor = System.Drawing.Color.Transparent
        Me.lblDrum.Location = New System.Drawing.Point(359, 103)
        Me.lblDrum.Name = "lblDrum"
        Me.lblDrum.Size = New System.Drawing.Size(42, 13)
        Me.lblDrum.TabIndex = 113
        Me.lblDrum.Text = "Drum #"
        '
        'txtLot
        '
        Me.txtLot.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLot.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtLot.Location = New System.Drawing.Point(407, 63)
        Me.txtLot.Name = "txtLot"
        Me.txtLot.Size = New System.Drawing.Size(202, 26)
        Me.txtLot.TabIndex = 5
        Me.txtLot.Text = "2BTI4"
        Me.txtLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLot
        '
        Me.lblLot.AutoSize = True
        Me.lblLot.BackColor = System.Drawing.Color.Transparent
        Me.lblLot.Location = New System.Drawing.Point(369, 71)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(32, 13)
        Me.lblLot.TabIndex = 112
        Me.lblLot.Text = "Lot #"
        '
        'txtRollQty
        '
        Me.txtRollQty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRollQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRollQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollQty.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.txtRollQty.Location = New System.Drawing.Point(38, 111)
        Me.txtRollQty.Name = "txtRollQty"
        Me.txtRollQty.Size = New System.Drawing.Size(110, 44)
        Me.txtRollQty.TabIndex = 2
        Me.txtRollQty.Text = "32"
        Me.txtRollQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblInvoice
        '
        Me.lblInvoice.AutoSize = True
        Me.lblInvoice.BackColor = System.Drawing.Color.Transparent
        Me.lblInvoice.Location = New System.Drawing.Point(359, 130)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Size = New System.Drawing.Size(42, 13)
        Me.lblInvoice.TabIndex = 111
        Me.lblInvoice.Text = "Invoice"
        '
        'txtInvoice
        '
        Me.txtInvoice.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoice.ForeColor = System.Drawing.Color.DimGray
        Me.txtInvoice.Location = New System.Drawing.Point(407, 127)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(87, 20)
        Me.txtInvoice.TabIndex = 7
        Me.txtInvoice.Text = "TP210221"
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.BackColor = System.Drawing.Color.Transparent
        Me.lblPO.Location = New System.Drawing.Point(379, 40)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(22, 13)
        Me.lblPO.TabIndex = 110
        Me.lblPO.Text = "PO"
        '
        'txtPO
        '
        Me.txtPO.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPO.Location = New System.Drawing.Point(407, 37)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(67, 20)
        Me.txtPO.TabIndex = 4
        Me.txtPO.Text = "3989"
        '
        'lblRollQty
        '
        Me.lblRollQty.AutoSize = True
        Me.lblRollQty.BackColor = System.Drawing.Color.Transparent
        Me.lblRollQty.Location = New System.Drawing.Point(37, 95)
        Me.lblRollQty.Name = "lblRollQty"
        Me.lblRollQty.Size = New System.Drawing.Size(52, 13)
        Me.lblRollQty.TabIndex = 109
        Me.lblRollQty.Text = "# of Rolls"
        Me.lblRollQty.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Location = New System.Drawing.Point(37, 61)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(50, 13)
        Me.lblCode.TabIndex = 108
        Me.lblCode.Text = "3M Code"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(678, 112)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(101, 23)
        Me.btnNew.TabIndex = 15
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(678, 170)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(101, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 300)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(806, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel2.Text = "Ready"
        '
        'dgvSheetingListing
        '
        Me.dgvSheetingListing.AllowUserToAddRows = False
        Me.dgvSheetingListing.AllowUserToDeleteRows = False
        Me.dgvSheetingListing.AllowUserToResizeRows = False
        Me.dgvSheetingListing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSheetingListing.BackgroundColor = System.Drawing.Color.White
        Me.dgvSheetingListing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSheetingListing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSheetingListing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSheetingListing.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSheetingListing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSheetingListing.EnableHeadersVisualStyles = False
        Me.dgvSheetingListing.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSheetingListing.Location = New System.Drawing.Point(0, 0)
        Me.dgvSheetingListing.Name = "dgvSheetingListing"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSheetingListing.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSheetingListing.RowHeadersVisible = False
        Me.dgvSheetingListing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSheetingListing.Size = New System.Drawing.Size(806, 322)
        Me.dgvSheetingListing.TabIndex = 1
        Me.dgvSheetingListing.TabStop = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'frmInvSheetingListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(806, 571)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvSheetingListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sheeting Inventory Listing"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.pic3M, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSheetingDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDimensions.ResumeLayout(False)
        Me.grpDimensions.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvSheetingListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvSheetingListing As System.Windows.Forms.DataGridView
    Friend WithEvents lblSqrFt As System.Windows.Forms.Label
    Friend WithEvents lblSheeting As System.Windows.Forms.Label
    Friend WithEvents picSheetingDesc As System.Windows.Forms.PictureBox
    Friend WithEvents grpDimensions As System.Windows.Forms.GroupBox
    Friend WithEvents lblRowWidth As System.Windows.Forms.Label
    Friend WithEvents lblInches As System.Windows.Forms.Label
    Friend WithEvents txtRollWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblYards As System.Windows.Forms.Label
    Friend WithEvents txtRollLength As System.Windows.Forms.TextBox
    Friend WithEvents lblRollLength As System.Windows.Forms.Label
    Friend WithEvents lblCarrier As System.Windows.Forms.Label
    Friend WithEvents eDtpRecvDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents lblRcvDate As System.Windows.Forms.Label
    Friend WithEvents eDtpShipDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents txtDrum As System.Windows.Forms.TextBox
    Friend WithEvents lblDrum As System.Windows.Forms.Label
    Friend WithEvents txtLot As System.Windows.Forms.TextBox
    Friend WithEvents lblLot As System.Windows.Forms.Label
    Friend WithEvents txtRollQty As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoice As System.Windows.Forms.Label
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents lblRollQty As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCarrier As System.Windows.Forms.TextBox
    Friend WithEvents cmbEXTTOFFields As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents ckbDepleted As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cmbSheetingCode As System.Windows.Forms.ComboBox
    Friend WithEvents pic3M As System.Windows.Forms.PictureBox
    Friend WithEvents lbl3M As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents lblSheetingID As System.Windows.Forms.Label
End Class
