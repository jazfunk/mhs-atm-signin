<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterDailyProduction
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnterDailyProduction))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.PanelATMDailyProductions = New System.Windows.Forms.Panel
        Me.ckbNullForeman = New System.Windows.Forms.CheckBox
        Me.ckbNullDate = New System.Windows.Forms.CheckBox
        Me.dgvUpdatedList = New System.Windows.Forms.DataGridView
        Me.station = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dpAutonum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.prodQTY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnNextUpdated = New System.Windows.Forms.Button
        Me.btnPrevUpdated = New System.Windows.Forms.Button
        Me.txtUpdateCount = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAtmJob = New System.Windows.Forms.ComboBox
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.lblAutonum = New System.Windows.Forms.Label
        Me.lblForeman = New System.Windows.Forms.Label
        Me.cmbForeman = New System.Windows.Forms.ComboBox
        Me.lblStation = New System.Windows.Forms.Label
        Me.txtProductionQty = New System.Windows.Forms.TextBox
        Me.lblPQty = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.eDTPInstallDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker
        Me.lblPID = New System.Windows.Forms.Label
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.lblStationWithSupport = New System.Windows.Forms.Label
        Me.txtStationWithSupport = New System.Windows.Forms.TextBox
        Me.txtContractQty = New System.Windows.Forms.TextBox
        Me.lblContractQty = New System.Windows.Forms.Label
        Me.lblUnit = New System.Windows.Forms.Label
        Me.lblPayItemDesc = New System.Windows.Forms.Label
        Me.cmbPayItem = New System.Windows.Forms.ComboBox
        Me.lblPayItemID = New System.Windows.Forms.Label
        Me.dgvDailyProductions = New System.Windows.Forms.DataGridView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelATMDailyProductions.SuspendLayout()
        CType(Me.dgvUpdatedList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDailyProductions, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelATMDailyProductions)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvDailyProductions)
        Me.SplitContainer1.Size = New System.Drawing.Size(1082, 563)
        Me.SplitContainer1.SplitterDistance = 225
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 2
        '
        'PanelATMDailyProductions
        '
        Me.PanelATMDailyProductions.BackColor = System.Drawing.Color.Transparent
        Me.PanelATMDailyProductions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelATMDailyProductions.Controls.Add(Me.ckbNullForeman)
        Me.PanelATMDailyProductions.Controls.Add(Me.ckbNullDate)
        Me.PanelATMDailyProductions.Controls.Add(Me.dgvUpdatedList)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnNextUpdated)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnPrevUpdated)
        Me.PanelATMDailyProductions.Controls.Add(Me.txtUpdateCount)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnSearch)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblJobDesc)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnRefresh)
        Me.PanelATMDailyProductions.Controls.Add(Me.Label1)
        Me.PanelATMDailyProductions.Controls.Add(Me.cmbAtmJob)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnNext)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnPrevious)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblAutonum)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblForeman)
        Me.PanelATMDailyProductions.Controls.Add(Me.cmbForeman)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblStation)
        Me.PanelATMDailyProductions.Controls.Add(Me.txtProductionQty)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblPQty)
        Me.PanelATMDailyProductions.Controls.Add(Me.Label2)
        Me.PanelATMDailyProductions.Controls.Add(Me.eDTPInstallDate)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblPID)
        Me.PanelATMDailyProductions.Controls.Add(Me.btnUpdate)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblStationWithSupport)
        Me.PanelATMDailyProductions.Controls.Add(Me.txtStationWithSupport)
        Me.PanelATMDailyProductions.Controls.Add(Me.txtContractQty)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblContractQty)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblUnit)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblPayItemDesc)
        Me.PanelATMDailyProductions.Controls.Add(Me.cmbPayItem)
        Me.PanelATMDailyProductions.Controls.Add(Me.lblPayItemID)
        Me.PanelATMDailyProductions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelATMDailyProductions.Location = New System.Drawing.Point(0, 0)
        Me.PanelATMDailyProductions.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelATMDailyProductions.Name = "PanelATMDailyProductions"
        Me.PanelATMDailyProductions.Size = New System.Drawing.Size(225, 563)
        Me.PanelATMDailyProductions.TabIndex = 0
        '
        'ckbNullForeman
        '
        Me.ckbNullForeman.AutoSize = True
        Me.ckbNullForeman.Checked = True
        Me.ckbNullForeman.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbNullForeman.Location = New System.Drawing.Point(193, 51)
        Me.ckbNullForeman.Name = "ckbNullForeman"
        Me.ckbNullForeman.Size = New System.Drawing.Size(15, 14)
        Me.ckbNullForeman.TabIndex = 62
        Me.ckbNullForeman.UseVisualStyleBackColor = True
        '
        'ckbNullDate
        '
        Me.ckbNullDate.AutoSize = True
        Me.ckbNullDate.Checked = True
        Me.ckbNullDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbNullDate.Location = New System.Drawing.Point(193, 82)
        Me.ckbNullDate.Name = "ckbNullDate"
        Me.ckbNullDate.Size = New System.Drawing.Size(15, 14)
        Me.ckbNullDate.TabIndex = 61
        Me.ckbNullDate.UseVisualStyleBackColor = True
        '
        'dgvUpdatedList
        '
        Me.dgvUpdatedList.AllowUserToAddRows = False
        Me.dgvUpdatedList.AllowUserToDeleteRows = False
        Me.dgvUpdatedList.AllowUserToResizeRows = False
        Me.dgvUpdatedList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUpdatedList.BackgroundColor = System.Drawing.Color.White
        Me.dgvUpdatedList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUpdatedList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUpdatedList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUpdatedList.ColumnHeadersHeight = 16
        Me.dgvUpdatedList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.station, Me.dpAutonum, Me.prodQTY})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUpdatedList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUpdatedList.EnableHeadersVisualStyles = False
        Me.dgvUpdatedList.GridColor = System.Drawing.Color.White
        Me.dgvUpdatedList.Location = New System.Drawing.Point(12, 389)
        Me.dgvUpdatedList.Name = "dgvUpdatedList"
        Me.dgvUpdatedList.ReadOnly = True
        Me.dgvUpdatedList.RowHeadersVisible = False
        Me.dgvUpdatedList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUpdatedList.Size = New System.Drawing.Size(196, 130)
        Me.dgvUpdatedList.TabIndex = 60
        Me.dgvUpdatedList.TabStop = False
        Me.ToolTip1.SetToolTip(Me.dgvUpdatedList, "Double-Click to navigate to that item")
        '
        'station
        '
        Me.station.FillWeight = 123.8579!
        Me.station.HeaderText = "Updated Stations"
        Me.station.Name = "station"
        Me.station.ReadOnly = True
        '
        'dpAutonum
        '
        Me.dpAutonum.HeaderText = "ID"
        Me.dpAutonum.Name = "dpAutonum"
        Me.dpAutonum.ReadOnly = True
        Me.dpAutonum.Visible = False
        '
        'prodQTY
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.prodQTY.DefaultCellStyle = DataGridViewCellStyle2
        Me.prodQTY.FillWeight = 76.14215!
        Me.prodQTY.HeaderText = "Qty"
        Me.prodQTY.Name = "prodQTY"
        Me.prodQTY.ReadOnly = True
        '
        'btnNextUpdated
        '
        Me.btnNextUpdated.Location = New System.Drawing.Point(163, 525)
        Me.btnNextUpdated.Name = "btnNextUpdated"
        Me.btnNextUpdated.Size = New System.Drawing.Size(45, 26)
        Me.btnNextUpdated.TabIndex = 57
        Me.btnNextUpdated.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.btnNextUpdated, "Next")
        Me.btnNextUpdated.UseVisualStyleBackColor = True
        '
        'btnPrevUpdated
        '
        Me.btnPrevUpdated.Location = New System.Drawing.Point(11, 525)
        Me.btnPrevUpdated.Name = "btnPrevUpdated"
        Me.btnPrevUpdated.Size = New System.Drawing.Size(46, 26)
        Me.btnPrevUpdated.TabIndex = 56
        Me.btnPrevUpdated.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.btnPrevUpdated, "Previous")
        Me.btnPrevUpdated.UseVisualStyleBackColor = True
        '
        'txtUpdateCount
        '
        Me.txtUpdateCount.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtUpdateCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateCount.Location = New System.Drawing.Point(63, 529)
        Me.txtUpdateCount.Name = "txtUpdateCount"
        Me.txtUpdateCount.Size = New System.Drawing.Size(94, 20)
        Me.txtUpdateCount.TabIndex = 55
        Me.txtUpdateCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.signINver2.My.Resources.Resources.search_1
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSearch.Location = New System.Drawing.Point(12, 318)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSearch.Size = New System.Drawing.Size(78, 33)
        Me.btnSearch.TabIndex = 54
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblJobDesc
        '
        Me.lblJobDesc.AutoSize = True
        Me.lblJobDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobDesc.ForeColor = System.Drawing.Color.DimGray
        Me.lblJobDesc.Location = New System.Drawing.Point(78, 11)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(0, 13)
        Me.lblJobDesc.TabIndex = 53
        Me.lblJobDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.signINver2.My.Resources.Resources.reset_16x16
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(63, 357)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(94, 26)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "Refresh")
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 596)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(2, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbAtmJob
        '
        Me.cmbAtmJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbAtmJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAtmJob.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbAtmJob.DropDownHeight = 200
        Me.cmbAtmJob.IntegralHeight = False
        Me.cmbAtmJob.Location = New System.Drawing.Point(12, 8)
        Me.cmbAtmJob.Name = "cmbAtmJob"
        Me.cmbAtmJob.Size = New System.Drawing.Size(60, 21)
        Me.cmbAtmJob.TabIndex = 0
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(162, 357)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(45, 26)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.btnNext, "Next")
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(11, 357)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(45, 26)
        Me.btnPrevious.TabIndex = 6
        Me.btnPrevious.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.btnPrevious, "Previous")
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'lblAutonum
        '
        Me.lblAutonum.AutoSize = True
        Me.lblAutonum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutonum.ForeColor = System.Drawing.Color.White
        Me.lblAutonum.Location = New System.Drawing.Point(12, 564)
        Me.lblAutonum.Name = "lblAutonum"
        Me.lblAutonum.Size = New System.Drawing.Size(2, 15)
        Me.lblAutonum.TabIndex = 48
        Me.lblAutonum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblForeman
        '
        Me.lblForeman.AutoSize = True
        Me.lblForeman.Location = New System.Drawing.Point(12, 32)
        Me.lblForeman.Name = "lblForeman"
        Me.lblForeman.Size = New System.Drawing.Size(48, 13)
        Me.lblForeman.TabIndex = 45
        Me.lblForeman.Text = "Foreman"
        Me.lblForeman.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbForeman
        '
        Me.cmbForeman.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbForeman.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbForeman.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbForeman.DropDownHeight = 200
        Me.cmbForeman.IntegralHeight = False
        Me.cmbForeman.Location = New System.Drawing.Point(12, 48)
        Me.cmbForeman.Name = "cmbForeman"
        Me.cmbForeman.Size = New System.Drawing.Size(175, 21)
        Me.cmbForeman.TabIndex = 1
        '
        'lblStation
        '
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.Location = New System.Drawing.Point(12, 103)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(195, 20)
        Me.lblStation.TabIndex = 43
        Me.lblStation.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtProductionQty
        '
        Me.txtProductionQty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProductionQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductionQty.Location = New System.Drawing.Point(12, 142)
        Me.txtProductionQty.Name = "txtProductionQty"
        Me.txtProductionQty.Size = New System.Drawing.Size(196, 32)
        Me.txtProductionQty.TabIndex = 3
        Me.txtProductionQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPQty
        '
        Me.lblPQty.AutoSize = True
        Me.lblPQty.Location = New System.Drawing.Point(9, 125)
        Me.lblPQty.Name = "lblPQty"
        Me.lblPQty.Size = New System.Drawing.Size(77, 13)
        Me.lblPQty.TabIndex = 41
        Me.lblPQty.Text = "Production Qty"
        Me.lblPQty.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(63, 564)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Unit"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'eDTPInstallDate
        '
        Me.eDTPInstallDate.CustomFormat = "MM/dd/yyyy"
        Me.eDTPInstallDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eDTPInstallDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDTPInstallDate.Location = New System.Drawing.Point(12, 75)
        Me.eDTPInstallDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDTPInstallDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDTPInstallDate.Name = "eDTPInstallDate"
        Me.eDTPInstallDate.Size = New System.Drawing.Size(175, 23)
        Me.eDTPInstallDate.TabIndex = 2
        Me.eDTPInstallDate.Value = New Date(2010, 6, 13, 0, 0, 0, 0)
        '
        'lblPID
        '
        Me.lblPID.AutoSize = True
        Me.lblPID.Location = New System.Drawing.Point(9, 89)
        Me.lblPID.Name = "lblPID"
        Me.lblPID.Size = New System.Drawing.Size(0, 13)
        Me.lblPID.TabIndex = 23
        Me.lblPID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = Global.signINver2.My.Resources.Resources.shipper21
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(96, 318)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnUpdate.Size = New System.Drawing.Size(112, 33)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnUpdate, "Update Record")
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblStationWithSupport
        '
        Me.lblStationWithSupport.AutoSize = True
        Me.lblStationWithSupport.Location = New System.Drawing.Point(9, 276)
        Me.lblStationWithSupport.Name = "lblStationWithSupport"
        Me.lblStationWithSupport.Size = New System.Drawing.Size(81, 13)
        Me.lblStationWithSupport.TabIndex = 29
        Me.lblStationWithSupport.Text = "Site w/ Support"
        Me.lblStationWithSupport.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtStationWithSupport
        '
        Me.txtStationWithSupport.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStationWithSupport.Location = New System.Drawing.Point(12, 292)
        Me.txtStationWithSupport.Name = "txtStationWithSupport"
        Me.txtStationWithSupport.Size = New System.Drawing.Size(196, 20)
        Me.txtStationWithSupport.TabIndex = 8
        '
        'txtContractQty
        '
        Me.txtContractQty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtContractQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractQty.Location = New System.Drawing.Point(12, 193)
        Me.txtContractQty.Name = "txtContractQty"
        Me.txtContractQty.Size = New System.Drawing.Size(196, 20)
        Me.txtContractQty.TabIndex = 6
        Me.txtContractQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblContractQty
        '
        Me.lblContractQty.AutoSize = True
        Me.lblContractQty.Location = New System.Drawing.Point(9, 177)
        Me.lblContractQty.Name = "lblContractQty"
        Me.lblContractQty.Size = New System.Drawing.Size(66, 13)
        Me.lblContractQty.TabIndex = 27
        Me.lblContractQty.Text = "Contract Qty"
        Me.lblContractQty.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUnit
        '
        Me.lblUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.ForeColor = System.Drawing.Color.DimGray
        Me.lblUnit.Location = New System.Drawing.Point(113, 177)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(3, 0, 1, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(94, 13)
        Me.lblUnit.TabIndex = 37
        Me.lblUnit.Text = "Unit"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPayItemDesc
        '
        Me.lblPayItemDesc.AutoSize = True
        Me.lblPayItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayItemDesc.ForeColor = System.Drawing.Color.DimGray
        Me.lblPayItemDesc.Location = New System.Drawing.Point(9, 256)
        Me.lblPayItemDesc.Name = "lblPayItemDesc"
        Me.lblPayItemDesc.Size = New System.Drawing.Size(96, 9)
        Me.lblPayItemDesc.TabIndex = 36
        Me.lblPayItemDesc.Text = "Pay Item Description"
        '
        'cmbPayItem
        '
        Me.cmbPayItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbPayItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPayItem.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbPayItem.DropDownHeight = 200
        Me.cmbPayItem.IntegralHeight = False
        Me.cmbPayItem.Location = New System.Drawing.Point(12, 232)
        Me.cmbPayItem.Name = "cmbPayItem"
        Me.cmbPayItem.Size = New System.Drawing.Size(196, 21)
        Me.cmbPayItem.TabIndex = 7
        '
        'lblPayItemID
        '
        Me.lblPayItemID.AutoSize = True
        Me.lblPayItemID.Location = New System.Drawing.Point(9, 216)
        Me.lblPayItemID.Name = "lblPayItemID"
        Me.lblPayItemID.Size = New System.Drawing.Size(48, 13)
        Me.lblPayItemID.TabIndex = 21
        Me.lblPayItemID.Text = "Pay Item"
        Me.lblPayItemID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dgvDailyProductions
        '
        Me.dgvDailyProductions.AllowUserToAddRows = False
        Me.dgvDailyProductions.AllowUserToDeleteRows = False
        Me.dgvDailyProductions.AllowUserToResizeRows = False
        Me.dgvDailyProductions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDailyProductions.BackgroundColor = System.Drawing.Color.White
        Me.dgvDailyProductions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDailyProductions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDailyProductions.ColumnHeadersHeight = 18
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDailyProductions.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDailyProductions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDailyProductions.EnableHeadersVisualStyles = False
        Me.dgvDailyProductions.GridColor = System.Drawing.Color.White
        Me.dgvDailyProductions.Location = New System.Drawing.Point(0, 0)
        Me.dgvDailyProductions.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvDailyProductions.Name = "dgvDailyProductions"
        Me.dgvDailyProductions.ReadOnly = True
        Me.dgvDailyProductions.RowHeadersVisible = False
        Me.dgvDailyProductions.RowTemplate.Height = 26
        Me.dgvDailyProductions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDailyProductions.Size = New System.Drawing.Size(856, 563)
        Me.dgvDailyProductions.TabIndex = 0
        Me.dgvDailyProductions.TabStop = False
        '
        'frmEnterDailyProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1082, 563)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmEnterDailyProduction"
        Me.Text = "Enter Daily Production"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelATMDailyProductions.ResumeLayout(False)
        Me.PanelATMDailyProductions.PerformLayout()
        CType(Me.dgvUpdatedList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDailyProductions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelATMDailyProductions As System.Windows.Forms.Panel
    Friend WithEvents lblPID As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblStationWithSupport As System.Windows.Forms.Label
    Friend WithEvents txtStationWithSupport As System.Windows.Forms.TextBox
    Friend WithEvents txtContractQty As System.Windows.Forms.TextBox
    Friend WithEvents lblContractQty As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblPayItemDesc As System.Windows.Forms.Label
    Friend WithEvents cmbPayItem As System.Windows.Forms.ComboBox
    Friend WithEvents lblPayItemID As System.Windows.Forms.Label
    Friend WithEvents dgvDailyProductions As System.Windows.Forms.DataGridView
    Friend WithEvents eDTPInstallDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents txtProductionQty As System.Windows.Forms.TextBox
    Friend WithEvents lblPQty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblForeman As System.Windows.Forms.Label
    Friend WithEvents cmbForeman As System.Windows.Forms.ComboBox
    Friend WithEvents lblAutonum As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents cmbAtmJob As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnNextUpdated As System.Windows.Forms.Button
    Friend WithEvents btnPrevUpdated As System.Windows.Forms.Button
    Friend WithEvents txtUpdateCount As System.Windows.Forms.TextBox
    Friend WithEvents dgvUpdatedList As System.Windows.Forms.DataGridView
    Friend WithEvents station As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dpAutonum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ckbNullForeman As System.Windows.Forms.CheckBox
    Friend WithEvents ckbNullDate As System.Windows.Forms.CheckBox
End Class
