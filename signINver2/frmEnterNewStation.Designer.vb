<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterNewStation
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
		Me.components = New System.ComponentModel.Container
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnterNewStation))
		Me.lblATMJob = New System.Windows.Forms.Label
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.PanelATMDailyProductions = New System.Windows.Forms.Panel
		Me.dgvSessionAdded = New System.Windows.Forms.DataGridView
		Me.lblGuardRailStations = New System.Windows.Forms.Label
		Me.btnGR = New System.Windows.Forms.Button
		Me.nudAutoRemQty = New System.Windows.Forms.NumericUpDown
		Me.lblType = New System.Windows.Forms.Label
		Me.lblSignCodeDesc = New System.Windows.Forms.Label
		Me.lblPdfTitle = New System.Windows.Forms.Label
		Me.lblRemovalQty = New System.Windows.Forms.Label
		Me.btnAddRemoval = New System.Windows.Forms.Button
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
		Me.tsbDailyProductions = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.tsbHidePayItems = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.tsbNextRecord = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
		Me.tsbNextPayItem = New System.Windows.Forms.ToolStripButton
		Me.lblPID = New System.Windows.Forms.Label
		Me.lblContractorID = New System.Windows.Forms.Label
		Me.picSignImage = New System.Windows.Forms.PictureBox
		Me.cmbSignCodes = New System.Windows.Forms.ComboBox
		Me.lblPlanIssueNotes = New System.Windows.Forms.Label
		Me.txtPlanIssueNotes = New System.Windows.Forms.TextBox
		Me.btnNextRecord = New System.Windows.Forms.Button
		Me.lblStationWithSupport = New System.Windows.Forms.Label
		Me.txtStationWithSupport = New System.Windows.Forms.TextBox
		Me.ckbSupportAtThisStation = New System.Windows.Forms.CheckBox
		Me.txtContractQty = New System.Windows.Forms.TextBox
		Me.txtSignCode = New System.Windows.Forms.TextBox
		Me.txtSignWidth = New System.Windows.Forms.TextBox
		Me.txtSignHeight = New System.Windows.Forms.TextBox
		Me.lblContractQty = New System.Windows.Forms.Label
		Me.lblSignHeight = New System.Windows.Forms.Label
		Me.lblSignWidth = New System.Windows.Forms.Label
		Me.lblJobLocation = New System.Windows.Forms.Label
		Me.btnNextPayItem = New System.Windows.Forms.Button
		Me.cmbContractor = New System.Windows.Forms.ComboBox
		Me.lblContractor = New System.Windows.Forms.Label
		Me.lblSite = New System.Windows.Forms.Label
		Me.txtSite = New System.Windows.Forms.TextBox
		Me.lblUnit = New System.Windows.Forms.Label
		Me.lblNumberOfSupports = New System.Windows.Forms.Label
		Me.txtNumberOfSupports = New System.Windows.Forms.TextBox
		Me.lblPayItemDesc = New System.Windows.Forms.Label
		Me.lblSignCode = New System.Windows.Forms.Label
		Me.cmbPayItem = New System.Windows.Forms.ComboBox
		Me.lblPayItemID = New System.Windows.Forms.Label
		Me.cmbATMJob = New System.Windows.Forms.ComboBox
		Me.dgvJobPayItems = New System.Windows.Forms.DataGridView
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.ckbRepeat = New System.Windows.Forms.CheckBox
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.PanelATMDailyProductions.SuspendLayout()
		CType(Me.dgvSessionAdded, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nudAutoRemQty, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ToolStrip1.SuspendLayout()
		CType(Me.picSignImage, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvJobPayItems, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'lblATMJob
		'
		Me.lblATMJob.AutoSize = True
		Me.lblATMJob.Location = New System.Drawing.Point(86, 41)
		Me.lblATMJob.Name = "lblATMJob"
		Me.lblATMJob.Size = New System.Drawing.Size(31, 13)
		Me.lblATMJob.TabIndex = 22
		Me.lblATMJob.Text = "Job#"
		Me.lblATMJob.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'SplitContainer1
		'
		Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(1)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.PanelATMDailyProductions)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.dgvJobPayItems)
		Me.SplitContainer1.Size = New System.Drawing.Size(832, 636)
		Me.SplitContainer1.SplitterDistance = 495
		Me.SplitContainer1.SplitterWidth = 1
		Me.SplitContainer1.TabIndex = 1
		'
		'PanelATMDailyProductions
		'
		Me.PanelATMDailyProductions.BackColor = System.Drawing.Color.Transparent
		Me.PanelATMDailyProductions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.PanelATMDailyProductions.Controls.Add(Me.ckbRepeat)
		Me.PanelATMDailyProductions.Controls.Add(Me.dgvSessionAdded)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblGuardRailStations)
		Me.PanelATMDailyProductions.Controls.Add(Me.btnGR)
		Me.PanelATMDailyProductions.Controls.Add(Me.nudAutoRemQty)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblType)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblSignCodeDesc)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblPdfTitle)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblRemovalQty)
		Me.PanelATMDailyProductions.Controls.Add(Me.btnAddRemoval)
		Me.PanelATMDailyProductions.Controls.Add(Me.ToolStrip1)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblPID)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblContractorID)
		Me.PanelATMDailyProductions.Controls.Add(Me.picSignImage)
		Me.PanelATMDailyProductions.Controls.Add(Me.cmbSignCodes)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblPlanIssueNotes)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtPlanIssueNotes)
		Me.PanelATMDailyProductions.Controls.Add(Me.btnNextRecord)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblStationWithSupport)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtStationWithSupport)
		Me.PanelATMDailyProductions.Controls.Add(Me.ckbSupportAtThisStation)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtContractQty)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtSignCode)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtSignWidth)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtSignHeight)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblContractQty)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblSignHeight)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblSignWidth)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblJobLocation)
		Me.PanelATMDailyProductions.Controls.Add(Me.btnNextPayItem)
		Me.PanelATMDailyProductions.Controls.Add(Me.cmbContractor)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblContractor)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblSite)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtSite)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblUnit)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblNumberOfSupports)
		Me.PanelATMDailyProductions.Controls.Add(Me.txtNumberOfSupports)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblPayItemDesc)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblSignCode)
		Me.PanelATMDailyProductions.Controls.Add(Me.cmbPayItem)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblPayItemID)
		Me.PanelATMDailyProductions.Controls.Add(Me.cmbATMJob)
		Me.PanelATMDailyProductions.Controls.Add(Me.lblATMJob)
		Me.PanelATMDailyProductions.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PanelATMDailyProductions.Location = New System.Drawing.Point(0, 0)
		Me.PanelATMDailyProductions.Margin = New System.Windows.Forms.Padding(0)
		Me.PanelATMDailyProductions.Name = "PanelATMDailyProductions"
		Me.PanelATMDailyProductions.Size = New System.Drawing.Size(495, 636)
		Me.PanelATMDailyProductions.TabIndex = 0
		'
		'dgvSessionAdded
		'
		Me.dgvSessionAdded.AllowUserToAddRows = False
		Me.dgvSessionAdded.AllowUserToDeleteRows = False
		Me.dgvSessionAdded.AllowUserToResizeRows = False
		Me.dgvSessionAdded.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvSessionAdded.BackgroundColor = System.Drawing.Color.White
		Me.dgvSessionAdded.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvSessionAdded.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvSessionAdded.ColumnHeadersHeight = 18
		Me.dgvSessionAdded.EnableHeadersVisualStyles = False
		Me.dgvSessionAdded.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvSessionAdded.Location = New System.Drawing.Point(8, 454)
		Me.dgvSessionAdded.Name = "dgvSessionAdded"
		Me.dgvSessionAdded.ReadOnly = True
		Me.dgvSessionAdded.RowHeadersVisible = False
		Me.dgvSessionAdded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvSessionAdded.Size = New System.Drawing.Size(464, 150)
		Me.dgvSessionAdded.TabIndex = 41
		Me.dgvSessionAdded.TabStop = False
		'
		'lblGuardRailStations
		'
		Me.lblGuardRailStations.AutoSize = True
		Me.lblGuardRailStations.Location = New System.Drawing.Point(247, 111)
		Me.lblGuardRailStations.Name = "lblGuardRailStations"
		Me.lblGuardRailStations.Size = New System.Drawing.Size(0, 13)
		Me.lblGuardRailStations.TabIndex = 40
		Me.lblGuardRailStations.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnGR
		'
		Me.btnGR.Location = New System.Drawing.Point(247, 80)
		Me.btnGR.Name = "btnGR"
		Me.btnGR.Size = New System.Drawing.Size(53, 23)
		Me.btnGR.TabIndex = 39
		Me.btnGR.Text = "GR"
		Me.ToolTip1.SetToolTip(Me.btnGR, "Enter Guard Rail Stations")
		Me.btnGR.UseVisualStyleBackColor = True
		'
		'nudAutoRemQty
		'
		Me.nudAutoRemQty.Location = New System.Drawing.Point(123, 428)
		Me.nudAutoRemQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.nudAutoRemQty.Name = "nudAutoRemQty"
		Me.nudAutoRemQty.Size = New System.Drawing.Size(50, 20)
		Me.nudAutoRemQty.TabIndex = 13
		Me.nudAutoRemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.nudAutoRemQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'lblType
		'
		Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblType.Location = New System.Drawing.Point(452, 186)
		Me.lblType.Name = "lblType"
		Me.lblType.Size = New System.Drawing.Size(20, 13)
		Me.lblType.TabIndex = 35
		Me.lblType.Text = "Type"
		'
		'lblSignCodeDesc
		'
		Me.lblSignCodeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSignCodeDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSignCodeDesc.Location = New System.Drawing.Point(224, 186)
		Me.lblSignCodeDesc.Name = "lblSignCodeDesc"
		Me.lblSignCodeDesc.Size = New System.Drawing.Size(222, 13)
		Me.lblSignCodeDesc.TabIndex = 33
		Me.lblSignCodeDesc.Text = "Description"
		'
		'lblPdfTitle
		'
		Me.lblPdfTitle.AutoSize = True
		Me.lblPdfTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPdfTitle.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPdfTitle.Location = New System.Drawing.Point(120, 186)
		Me.lblPdfTitle.Name = "lblPdfTitle"
		Me.lblPdfTitle.Size = New System.Drawing.Size(58, 13)
		Me.lblPdfTitle.TabIndex = 32
		Me.lblPdfTitle.Text = ".pdf Title"
		Me.lblPdfTitle.Visible = False
		'
		'lblRemovalQty
		'
		Me.lblRemovalQty.AutoSize = True
		Me.lblRemovalQty.Location = New System.Drawing.Point(49, 430)
		Me.lblRemovalQty.Name = "lblRemovalQty"
		Me.lblRemovalQty.Size = New System.Drawing.Size(68, 13)
		Me.lblRemovalQty.TabIndex = 31
		Me.lblRemovalQty.Text = "Removal Qty"
		Me.lblRemovalQty.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnAddRemoval
		'
		Me.btnAddRemoval.Location = New System.Drawing.Point(182, 425)
		Me.btnAddRemoval.Name = "btnAddRemoval"
		Me.btnAddRemoval.Size = New System.Drawing.Size(118, 23)
		Me.btnAddRemoval.TabIndex = 14
		Me.btnAddRemoval.Text = "Auto-Removal"
		Me.btnAddRemoval.UseVisualStyleBackColor = True
		'
		'ToolStrip1
		'
		Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
		Me.ToolStrip1.BackgroundImage = Global.signINver2.My.Resources.Resources.atmToolStripBG_2
		Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDailyProductions, Me.ToolStripSeparator1, Me.tsbHidePayItems, Me.ToolStripSeparator2, Me.tsbNextRecord, Me.ToolStripSeparator3, Me.tsbNextPayItem})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(495, 25)
		Me.ToolStrip1.Stretch = True
		Me.ToolStrip1.TabIndex = 36
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'tsbDailyProductions
		'
		Me.tsbDailyProductions.Image = Global.signINver2.My.Resources.Resources.dataTable16x16
		Me.tsbDailyProductions.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbDailyProductions.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
		Me.tsbDailyProductions.Name = "tsbDailyProductions"
		Me.tsbDailyProductions.Size = New System.Drawing.Size(120, 22)
		Me.tsbDailyProductions.Text = "Daily Productions"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'tsbHidePayItems
		'
		Me.tsbHidePayItems.Image = Global.signINver2.My.Resources.Resources.pushPin24x24
		Me.tsbHidePayItems.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbHidePayItems.Name = "tsbHidePayItems"
		Me.tsbHidePayItems.Size = New System.Drawing.Size(78, 22)
		Me.tsbHidePayItems.Text = "Pay Items"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
		'
		'tsbNextRecord
		'
		Me.tsbNextRecord.ForeColor = System.Drawing.Color.Black
		Me.tsbNextRecord.Image = Global.signINver2.My.Resources.Resources.lightningBolt16x16
		Me.tsbNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbNextRecord.Name = "tsbNextRecord"
		Me.tsbNextRecord.Size = New System.Drawing.Size(89, 22)
		Me.tsbNextRecord.Text = "Add Record"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
		'
		'tsbNextPayItem
		'
		Me.tsbNextPayItem.Image = Global.signINver2.My.Resources.Resources.nextPayItem16x16
		Me.tsbNextPayItem.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.tsbNextPayItem.Name = "tsbNextPayItem"
		Me.tsbNextPayItem.Size = New System.Drawing.Size(179, 22)
		Me.tsbNextPayItem.Text = "Next Pay Item @ This Station"
		'
		'lblPID
		'
		Me.lblPID.AutoSize = True
		Me.lblPID.Location = New System.Drawing.Point(16, 89)
		Me.lblPID.Name = "lblPID"
		Me.lblPID.Size = New System.Drawing.Size(0, 13)
		Me.lblPID.TabIndex = 23
		Me.lblPID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblContractorID
		'
		Me.lblContractorID.AutoSize = True
		Me.lblContractorID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblContractorID.Location = New System.Drawing.Point(247, 155)
		Me.lblContractorID.Name = "lblContractorID"
		Me.lblContractorID.Size = New System.Drawing.Size(0, 13)
		Me.lblContractorID.TabIndex = 34
		Me.lblContractorID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'picSignImage
		'
		Me.picSignImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picSignImage.Location = New System.Drawing.Point(362, 202)
		Me.picSignImage.Name = "picSignImage"
		Me.picSignImage.Size = New System.Drawing.Size(110, 110)
		Me.picSignImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picSignImage.TabIndex = 38
		Me.picSignImage.TabStop = False
		Me.ToolTip1.SetToolTip(Me.picSignImage, "Double-Click to view Spec sheet for this sign")
		'
		'cmbSignCodes
		'
		Me.cmbSignCodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbSignCodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSignCodes.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbSignCodes.DropDownHeight = 350
		Me.cmbSignCodes.FormattingEnabled = True
		Me.cmbSignCodes.IntegralHeight = False
		Me.cmbSignCodes.Location = New System.Drawing.Point(123, 202)
		Me.cmbSignCodes.Name = "cmbSignCodes"
		Me.cmbSignCodes.Size = New System.Drawing.Size(95, 21)
		Me.cmbSignCodes.TabIndex = 3
		'
		'lblPlanIssueNotes
		'
		Me.lblPlanIssueNotes.AutoSize = True
		Me.lblPlanIssueNotes.Location = New System.Drawing.Point(30, 368)
		Me.lblPlanIssueNotes.Name = "lblPlanIssueNotes"
		Me.lblPlanIssueNotes.Size = New System.Drawing.Size(87, 13)
		Me.lblPlanIssueNotes.TabIndex = 30
		Me.lblPlanIssueNotes.Text = "Plan Issue Notes"
		Me.lblPlanIssueNotes.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtPlanIssueNotes
		'
		Me.txtPlanIssueNotes.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtPlanIssueNotes.Location = New System.Drawing.Point(123, 368)
		Me.txtPlanIssueNotes.Multiline = True
		Me.txtPlanIssueNotes.Name = "txtPlanIssueNotes"
		Me.txtPlanIssueNotes.Size = New System.Drawing.Size(349, 38)
		Me.txtPlanIssueNotes.TabIndex = 12
		Me.txtPlanIssueNotes.TabStop = False
		'
		'btnNextRecord
		'
		Me.btnNextRecord.Location = New System.Drawing.Point(306, 425)
		Me.btnNextRecord.Name = "btnNextRecord"
		Me.btnNextRecord.Size = New System.Drawing.Size(94, 23)
		Me.btnNextRecord.TabIndex = 15
		Me.btnNextRecord.Text = "Add Record"
		Me.btnNextRecord.UseVisualStyleBackColor = True
		'
		'lblStationWithSupport
		'
		Me.lblStationWithSupport.AutoSize = True
		Me.lblStationWithSupport.Location = New System.Drawing.Point(12, 335)
		Me.lblStationWithSupport.Name = "lblStationWithSupport"
		Me.lblStationWithSupport.Size = New System.Drawing.Size(105, 13)
		Me.lblStationWithSupport.TabIndex = 29
		Me.lblStationWithSupport.Text = "Station With Support"
		Me.lblStationWithSupport.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtStationWithSupport
		'
		Me.txtStationWithSupport.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtStationWithSupport.Location = New System.Drawing.Point(123, 332)
		Me.txtStationWithSupport.Name = "txtStationWithSupport"
		Me.txtStationWithSupport.Size = New System.Drawing.Size(118, 20)
		Me.txtStationWithSupport.TabIndex = 10
		'
		'ckbSupportAtThisStation
		'
		Me.ckbSupportAtThisStation.AutoSize = True
		Me.ckbSupportAtThisStation.Location = New System.Drawing.Point(182, 308)
		Me.ckbSupportAtThisStation.Name = "ckbSupportAtThisStation"
		Me.ckbSupportAtThisStation.Size = New System.Drawing.Size(135, 17)
		Me.ckbSupportAtThisStation.TabIndex = 9
		Me.ckbSupportAtThisStation.Text = "Support At This Station"
		Me.ckbSupportAtThisStation.UseVisualStyleBackColor = True
		'
		'txtContractQty
		'
		Me.txtContractQty.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtContractQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtContractQty.Location = New System.Drawing.Point(123, 255)
		Me.txtContractQty.Name = "txtContractQty"
		Me.txtContractQty.Size = New System.Drawing.Size(50, 20)
		Me.txtContractQty.TabIndex = 7
		Me.txtContractQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtSignCode
		'
		Me.txtSignCode.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSignCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtSignCode.Location = New System.Drawing.Point(224, 202)
		Me.txtSignCode.Name = "txtSignCode"
		Me.txtSignCode.Size = New System.Drawing.Size(123, 20)
		Me.txtSignCode.TabIndex = 4
		Me.txtSignCode.TabStop = False
		Me.txtSignCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'txtSignWidth
		'
		Me.txtSignWidth.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSignWidth.Location = New System.Drawing.Point(123, 229)
		Me.txtSignWidth.Name = "txtSignWidth"
		Me.txtSignWidth.Size = New System.Drawing.Size(50, 20)
		Me.txtSignWidth.TabIndex = 5
		Me.txtSignWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtSignHeight
		'
		Me.txtSignHeight.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSignHeight.Location = New System.Drawing.Point(247, 229)
		Me.txtSignHeight.Name = "txtSignHeight"
		Me.txtSignHeight.Size = New System.Drawing.Size(50, 20)
		Me.txtSignHeight.TabIndex = 6
		Me.txtSignHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblContractQty
		'
		Me.lblContractQty.AutoSize = True
		Me.lblContractQty.Location = New System.Drawing.Point(51, 258)
		Me.lblContractQty.Name = "lblContractQty"
		Me.lblContractQty.Size = New System.Drawing.Size(66, 13)
		Me.lblContractQty.TabIndex = 27
		Me.lblContractQty.Text = "Contract Qty"
		Me.lblContractQty.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSignHeight
		'
		Me.lblSignHeight.AutoSize = True
		Me.lblSignHeight.Location = New System.Drawing.Point(179, 232)
		Me.lblSignHeight.Name = "lblSignHeight"
		Me.lblSignHeight.Size = New System.Drawing.Size(62, 13)
		Me.lblSignHeight.TabIndex = 0
		Me.lblSignHeight.Text = "Sign Height"
		Me.lblSignHeight.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSignWidth
		'
		Me.lblSignWidth.AutoSize = True
		Me.lblSignWidth.Location = New System.Drawing.Point(58, 232)
		Me.lblSignWidth.Name = "lblSignWidth"
		Me.lblSignWidth.Size = New System.Drawing.Size(59, 13)
		Me.lblSignWidth.TabIndex = 26
		Me.lblSignWidth.Text = "Sign Width"
		Me.lblSignWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblJobLocation
		'
		Me.lblJobLocation.AutoSize = True
		Me.lblJobLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblJobLocation.Location = New System.Drawing.Point(123, 62)
		Me.lblJobLocation.Name = "lblJobLocation"
		Me.lblJobLocation.Size = New System.Drawing.Size(0, 13)
		Me.lblJobLocation.TabIndex = 19
		'
		'btnNextPayItem
		'
		Me.btnNextPayItem.Location = New System.Drawing.Point(247, 330)
		Me.btnNextPayItem.Name = "btnNextPayItem"
		Me.btnNextPayItem.Size = New System.Drawing.Size(225, 23)
		Me.btnNextPayItem.TabIndex = 11
		Me.btnNextPayItem.Text = "Next Pay Item For This Station"
		Me.btnNextPayItem.UseVisualStyleBackColor = True
		'
		'cmbContractor
		'
		Me.cmbContractor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbContractor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbContractor.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbContractor.FormattingEnabled = True
		Me.cmbContractor.Location = New System.Drawing.Point(123, 152)
		Me.cmbContractor.Name = "cmbContractor"
		Me.cmbContractor.Size = New System.Drawing.Size(118, 21)
		Me.cmbContractor.TabIndex = 2
		Me.cmbContractor.TabStop = False
		'
		'lblContractor
		'
		Me.lblContractor.AutoSize = True
		Me.lblContractor.Location = New System.Drawing.Point(61, 155)
		Me.lblContractor.Name = "lblContractor"
		Me.lblContractor.Size = New System.Drawing.Size(56, 13)
		Me.lblContractor.TabIndex = 24
		Me.lblContractor.Text = "Contractor"
		Me.lblContractor.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSite
		'
		Me.lblSite.AutoSize = True
		Me.lblSite.Location = New System.Drawing.Point(92, 85)
		Me.lblSite.Name = "lblSite"
		Me.lblSite.Size = New System.Drawing.Size(25, 13)
		Me.lblSite.TabIndex = 20
		Me.lblSite.Text = "Site"
		Me.lblSite.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtSite
		'
		Me.txtSite.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSite.Location = New System.Drawing.Point(123, 82)
		Me.txtSite.Name = "txtSite"
		Me.txtSite.Size = New System.Drawing.Size(118, 20)
		Me.txtSite.TabIndex = 0
		'
		'lblUnit
		'
		Me.lblUnit.AutoSize = True
		Me.lblUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUnit.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblUnit.Location = New System.Drawing.Point(179, 258)
		Me.lblUnit.Name = "lblUnit"
		Me.lblUnit.Size = New System.Drawing.Size(30, 13)
		Me.lblUnit.TabIndex = 37
		Me.lblUnit.Text = "Unit"
		Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNumberOfSupports
		'
		Me.lblNumberOfSupports.AutoSize = True
		Me.lblNumberOfSupports.Location = New System.Drawing.Point(16, 309)
		Me.lblNumberOfSupports.Name = "lblNumberOfSupports"
		Me.lblNumberOfSupports.Size = New System.Drawing.Size(101, 13)
		Me.lblNumberOfSupports.TabIndex = 28
		Me.lblNumberOfSupports.Text = "Number of Supports"
		Me.lblNumberOfSupports.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtNumberOfSupports
		'
		Me.txtNumberOfSupports.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtNumberOfSupports.Location = New System.Drawing.Point(123, 306)
		Me.txtNumberOfSupports.Name = "txtNumberOfSupports"
		Me.txtNumberOfSupports.Size = New System.Drawing.Size(50, 20)
		Me.txtNumberOfSupports.TabIndex = 8
		Me.txtNumberOfSupports.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblPayItemDesc
		'
		Me.lblPayItemDesc.AutoSize = True
		Me.lblPayItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPayItemDesc.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPayItemDesc.Location = New System.Drawing.Point(120, 132)
		Me.lblPayItemDesc.Name = "lblPayItemDesc"
		Me.lblPayItemDesc.Size = New System.Drawing.Size(124, 13)
		Me.lblPayItemDesc.TabIndex = 36
		Me.lblPayItemDesc.Text = "Pay Item Description"
		'
		'lblSignCode
		'
		Me.lblSignCode.AutoSize = True
		Me.lblSignCode.Location = New System.Drawing.Point(61, 206)
		Me.lblSignCode.Name = "lblSignCode"
		Me.lblSignCode.Size = New System.Drawing.Size(56, 13)
		Me.lblSignCode.TabIndex = 25
		Me.lblSignCode.Text = "Sign Code"
		Me.lblSignCode.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cmbPayItem
		'
		Me.cmbPayItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbPayItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbPayItem.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbPayItem.DropDownHeight = 200
		Me.cmbPayItem.IntegralHeight = False
		Me.cmbPayItem.Location = New System.Drawing.Point(123, 108)
		Me.cmbPayItem.Name = "cmbPayItem"
		Me.cmbPayItem.Size = New System.Drawing.Size(118, 21)
		Me.cmbPayItem.TabIndex = 1
		'
		'lblPayItemID
		'
		Me.lblPayItemID.AutoSize = True
		Me.lblPayItemID.Location = New System.Drawing.Point(69, 111)
		Me.lblPayItemID.Name = "lblPayItemID"
		Me.lblPayItemID.Size = New System.Drawing.Size(48, 13)
		Me.lblPayItemID.TabIndex = 21
		Me.lblPayItemID.Text = "Pay Item"
		Me.lblPayItemID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cmbATMJob
		'
		Me.cmbATMJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cmbATMJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbATMJob.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbATMJob.FormattingEnabled = True
		Me.cmbATMJob.Location = New System.Drawing.Point(123, 38)
		Me.cmbATMJob.Name = "cmbATMJob"
		Me.cmbATMJob.Size = New System.Drawing.Size(95, 21)
		Me.cmbATMJob.TabIndex = 16
		Me.cmbATMJob.TabStop = False
		'
		'dgvJobPayItems
		'
		Me.dgvJobPayItems.AllowUserToAddRows = False
		Me.dgvJobPayItems.AllowUserToDeleteRows = False
		Me.dgvJobPayItems.AllowUserToResizeRows = False
		Me.dgvJobPayItems.BackgroundColor = System.Drawing.Color.White
		Me.dgvJobPayItems.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvJobPayItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvJobPayItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvJobPayItems.ColumnHeadersHeight = 18
		Me.dgvJobPayItems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvJobPayItems.EnableHeadersVisualStyles = False
		Me.dgvJobPayItems.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvJobPayItems.Location = New System.Drawing.Point(0, 0)
		Me.dgvJobPayItems.Name = "dgvJobPayItems"
		Me.dgvJobPayItems.ReadOnly = True
		Me.dgvJobPayItems.RowHeadersVisible = False
		Me.dgvJobPayItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvJobPayItems.Size = New System.Drawing.Size(336, 636)
		Me.dgvJobPayItems.TabIndex = 0
		Me.dgvJobPayItems.TabStop = False
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 614)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(832, 22)
		Me.StatusStrip1.TabIndex = 8
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
		Me.ToolStripStatusLabel1.Text = "Ready"
		'
		'ToolTip1
		'
		Me.ToolTip1.AutomaticDelay = 0
		Me.ToolTip1.AutoPopDelay = 6000
		Me.ToolTip1.InitialDelay = 500
		Me.ToolTip1.IsBalloon = True
		Me.ToolTip1.ReshowDelay = 20
		Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.ToolTip1.ToolTipTitle = "View .PDF"
		'
		'ckbRepeat
		'
		Me.ckbRepeat.AutoSize = True
		Me.ckbRepeat.Location = New System.Drawing.Point(409, 427)
		Me.ckbRepeat.Name = "ckbRepeat"
		Me.ckbRepeat.Size = New System.Drawing.Size(61, 17)
		Me.ckbRepeat.TabIndex = 42
		Me.ckbRepeat.Text = "Repeat"
		Me.ckbRepeat.UseVisualStyleBackColor = True
		'
		'frmEnterNewStation
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(832, 636)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.SplitContainer1)
		Me.DoubleBuffered = True
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.Name = "frmEnterNewStation"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Enter New Station"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		Me.PanelATMDailyProductions.ResumeLayout(False)
		Me.PanelATMDailyProductions.PerformLayout()
		CType(Me.dgvSessionAdded, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nudAutoRemQty, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		CType(Me.picSignImage, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvJobPayItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblATMJob As System.Windows.Forms.Label
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents PanelATMDailyProductions As System.Windows.Forms.Panel
	Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
	Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents cmbATMJob As System.Windows.Forms.ComboBox
	Friend WithEvents lblSite As System.Windows.Forms.Label
	Friend WithEvents txtSite As System.Windows.Forms.TextBox
	Friend WithEvents lblUnit As System.Windows.Forms.Label
	Friend WithEvents lblNumberOfSupports As System.Windows.Forms.Label
	Friend WithEvents txtNumberOfSupports As System.Windows.Forms.TextBox
	Friend WithEvents lblPayItemDesc As System.Windows.Forms.Label
	Friend WithEvents lblSignCode As System.Windows.Forms.Label
	Friend WithEvents cmbPayItem As System.Windows.Forms.ComboBox
	Friend WithEvents lblPayItemID As System.Windows.Forms.Label
	Friend WithEvents btnNextPayItem As System.Windows.Forms.Button
	Friend WithEvents cmbContractor As System.Windows.Forms.ComboBox
	Friend WithEvents lblContractor As System.Windows.Forms.Label
	Friend WithEvents lblJobLocation As System.Windows.Forms.Label
	Friend WithEvents dgvJobPayItems As System.Windows.Forms.DataGridView
	Friend WithEvents txtSignHeight As System.Windows.Forms.TextBox
	Friend WithEvents lblContractQty As System.Windows.Forms.Label
	Friend WithEvents lblSignHeight As System.Windows.Forms.Label
	Friend WithEvents lblSignWidth As System.Windows.Forms.Label
	Friend WithEvents txtContractQty As System.Windows.Forms.TextBox
	Friend WithEvents txtSignCode As System.Windows.Forms.TextBox
	Friend WithEvents txtSignWidth As System.Windows.Forms.TextBox
	Friend WithEvents btnNextRecord As System.Windows.Forms.Button
	Friend WithEvents lblStationWithSupport As System.Windows.Forms.Label
	Friend WithEvents txtStationWithSupport As System.Windows.Forms.TextBox
	Friend WithEvents ckbSupportAtThisStation As System.Windows.Forms.CheckBox
	Friend WithEvents lblPlanIssueNotes As System.Windows.Forms.Label
	Friend WithEvents txtPlanIssueNotes As System.Windows.Forms.TextBox
	Friend WithEvents picSignImage As System.Windows.Forms.PictureBox
	Friend WithEvents cmbSignCodes As System.Windows.Forms.ComboBox
	Friend WithEvents lblContractorID As System.Windows.Forms.Label
	Friend WithEvents lblPID As System.Windows.Forms.Label
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents tsbHidePayItems As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents tsbDailyProductions As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents tsbNextRecord As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents tsbNextPayItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents btnAddRemoval As System.Windows.Forms.Button
	Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
	Friend WithEvents lblRemovalQty As System.Windows.Forms.Label
	Friend WithEvents lblType As System.Windows.Forms.Label
	Friend WithEvents lblSignCodeDesc As System.Windows.Forms.Label
	Friend WithEvents lblPdfTitle As System.Windows.Forms.Label
	Friend WithEvents nudAutoRemQty As System.Windows.Forms.NumericUpDown
	Friend WithEvents btnGR As System.Windows.Forms.Button
	Friend WithEvents lblGuardRailStations As System.Windows.Forms.Label
	Friend WithEvents dgvSessionAdded As System.Windows.Forms.DataGridView
	Friend WithEvents ckbRepeat As System.Windows.Forms.CheckBox
End Class
