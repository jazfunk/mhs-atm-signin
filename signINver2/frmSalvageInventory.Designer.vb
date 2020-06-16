<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalvageInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalvageInventory))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.txtSignType = New System.Windows.Forms.TextBox
        Me.txtAtmJob = New System.Windows.Forms.TextBox
        Me.cmbSignType = New System.Windows.Forms.ComboBox
        Me.picSign = New System.Windows.Forms.PictureBox
        Me.ckbReInstalled = New System.Windows.Forms.CheckBox
        Me.cmbSalvageFields = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCriteria = New System.Windows.Forms.TextBox
        Me.btnSaveChanges = New System.Windows.Forms.Button
        Me.lblFilter = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.grpSignSize = New System.Windows.Forms.GroupBox
        Me.lblSignWidth = New System.Windows.Forms.Label
        Me.txtSignWidth = New System.Windows.Forms.TextBox
        Me.txtSignHeight = New System.Windows.Forms.TextBox
        Me.lblSignHeight = New System.Windows.Forms.Label
        Me.lblLocation = New System.Windows.Forms.Label
        Me.eDtpRecvDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker
        Me.lblRcvDate = New System.Windows.Forms.Label
        Me.eDtpShipDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker
        Me.lblShipDate = New System.Windows.Forms.Label
        Me.txtStation = New System.Windows.Forms.TextBox
        Me.lblStation = New System.Windows.Forms.Label
        Me.lblSignType = New System.Windows.Forms.Label
        Me.lblAtmJob = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.dgvSalvageListing = New System.Windows.Forms.DataGridView
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSignSize.SuspendLayout()
        CType(Me.dgvSalvageListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 559)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(775, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNew)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSignType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAtmJob)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSignType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.picSign)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ckbReInstalled)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSalvageFields)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCriteria)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSaveChanges)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLocation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSignSize)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblLocation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.eDtpRecvDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRcvDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.eDtpShipDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblShipDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtStation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblStation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSignType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAtmJob)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEdit)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvSalvageListing)
        Me.SplitContainer1.Size = New System.Drawing.Size(775, 559)
        Me.SplitContainer1.SplitterDistance = 245
        Me.SplitContainer1.TabIndex = 2
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(663, 124)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 23)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(663, 95)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(100, 23)
        Me.btnNew.TabIndex = 127
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtSignType
        '
        Me.txtSignType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignType.Location = New System.Drawing.Point(118, 128)
        Me.txtSignType.Name = "txtSignType"
        Me.txtSignType.Size = New System.Drawing.Size(110, 20)
        Me.txtSignType.TabIndex = 3
        '
        'txtAtmJob
        '
        Me.txtAtmJob.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAtmJob.Location = New System.Drawing.Point(26, 39)
        Me.txtAtmJob.Name = "txtAtmJob"
        Me.txtAtmJob.Size = New System.Drawing.Size(86, 20)
        Me.txtAtmJob.TabIndex = 0
        '
        'cmbSignType
        '
        Me.cmbSignType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSignType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSignType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbSignType.DropDownHeight = 124
        Me.cmbSignType.FormattingEnabled = True
        Me.cmbSignType.IntegralHeight = False
        Me.cmbSignType.Items.AddRange(New Object() {"Extruded", "Plywood", "Flatsheet", "Other"})
        Me.cmbSignType.Location = New System.Drawing.Point(26, 128)
        Me.cmbSignType.Name = "cmbSignType"
        Me.cmbSignType.Size = New System.Drawing.Size(86, 21)
        Me.cmbSignType.TabIndex = 2
        Me.cmbSignType.Text = "Select Type"
        '
        'picSign
        '
        Me.picSign.BackColor = System.Drawing.Color.White
        Me.picSign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSign.Location = New System.Drawing.Point(422, 8)
        Me.picSign.Name = "picSign"
        Me.picSign.Size = New System.Drawing.Size(235, 200)
        Me.picSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSign.TabIndex = 126
        Me.picSign.TabStop = False
        '
        'ckbReInstalled
        '
        Me.ckbReInstalled.AutoSize = True
        Me.ckbReInstalled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbReInstalled.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbReInstalled.ForeColor = System.Drawing.Color.DarkGreen
        Me.ckbReInstalled.Location = New System.Drawing.Point(282, 124)
        Me.ckbReInstalled.Name = "ckbReInstalled"
        Me.ckbReInstalled.Size = New System.Drawing.Size(126, 24)
        Me.ckbReInstalled.TabIndex = 6
        Me.ckbReInstalled.Text = "Re-Installed"
        Me.ckbReInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbReInstalled.UseVisualStyleBackColor = True
        '
        'cmbSalvageFields
        '
        Me.cmbSalvageFields.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSalvageFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSalvageFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSalvageFields.DropDownHeight = 300
        Me.cmbSalvageFields.FormattingEnabled = True
        Me.cmbSalvageFields.IntegralHeight = False
        Me.cmbSalvageFields.Items.AddRange(New Object() {"Job #", "Station", "Type", "Width", "Height", "Location"})
        Me.cmbSalvageFields.Location = New System.Drawing.Point(38, 216)
        Me.cmbSalvageFields.Name = "cmbSalvageFields"
        Me.cmbSalvageFields.Size = New System.Drawing.Size(192, 21)
        Me.cmbSalvageFields.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(240, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "By"
        '
        'txtCriteria
        '
        Me.txtCriteria.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCriteria.Location = New System.Drawing.Point(265, 216)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(392, 20)
        Me.txtCriteria.TabIndex = 10
        Me.txtCriteria.Text = "Type search text here"
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSaveChanges.Location = New System.Drawing.Point(663, 214)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(100, 23)
        Me.btnSaveChanges.TabIndex = 11
        Me.btnSaveChanges.Text = "Save Changes"
        Me.btnSaveChanges.UseVisualStyleBackColor = True
        '
        'lblFilter
        '
        Me.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFilter.AutoSize = True
        Me.lblFilter.BackColor = System.Drawing.Color.Transparent
        Me.lblFilter.Location = New System.Drawing.Point(3, 219)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(29, 13)
        Me.lblFilter.TabIndex = 124
        Me.lblFilter.Text = "Filter"
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLocation.Location = New System.Drawing.Point(26, 168)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(137, 20)
        Me.txtLocation.TabIndex = 4
        '
        'grpSignSize
        '
        Me.grpSignSize.BackColor = System.Drawing.Color.Transparent
        Me.grpSignSize.Controls.Add(Me.lblSignWidth)
        Me.grpSignSize.Controls.Add(Me.txtSignWidth)
        Me.grpSignSize.Controls.Add(Me.txtSignHeight)
        Me.grpSignSize.Controls.Add(Me.lblSignHeight)
        Me.grpSignSize.Location = New System.Drawing.Point(270, 23)
        Me.grpSignSize.Name = "grpSignSize"
        Me.grpSignSize.Size = New System.Drawing.Size(144, 85)
        Me.grpSignSize.TabIndex = 5
        Me.grpSignSize.TabStop = False
        Me.grpSignSize.Text = "Sign Dimensions"
        '
        'lblSignWidth
        '
        Me.lblSignWidth.AutoSize = True
        Me.lblSignWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblSignWidth.Location = New System.Drawing.Point(7, 25)
        Me.lblSignWidth.Name = "lblSignWidth"
        Me.lblSignWidth.Size = New System.Drawing.Size(59, 13)
        Me.lblSignWidth.TabIndex = 34
        Me.lblSignWidth.Text = "Sign Width"
        Me.lblSignWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSignWidth
        '
        Me.txtSignWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignWidth.ForeColor = System.Drawing.Color.Black
        Me.txtSignWidth.Location = New System.Drawing.Point(10, 41)
        Me.txtSignWidth.Name = "txtSignWidth"
        Me.txtSignWidth.Size = New System.Drawing.Size(60, 29)
        Me.txtSignWidth.TabIndex = 0
        Me.txtSignWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSignHeight
        '
        Me.txtSignHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignHeight.ForeColor = System.Drawing.Color.Black
        Me.txtSignHeight.Location = New System.Drawing.Point(76, 41)
        Me.txtSignHeight.Name = "txtSignHeight"
        Me.txtSignHeight.Size = New System.Drawing.Size(60, 29)
        Me.txtSignHeight.TabIndex = 1
        Me.txtSignHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSignHeight
        '
        Me.lblSignHeight.AutoSize = True
        Me.lblSignHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblSignHeight.Location = New System.Drawing.Point(76, 25)
        Me.lblSignHeight.Name = "lblSignHeight"
        Me.lblSignHeight.Size = New System.Drawing.Size(62, 13)
        Me.lblSignHeight.TabIndex = 38
        Me.lblSignHeight.Text = "Sign Height"
        Me.lblSignHeight.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Location = New System.Drawing.Point(23, 152)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(48, 13)
        Me.lblLocation.TabIndex = 116
        Me.lblLocation.Text = "Location"
        '
        'eDtpRecvDate
        '
        Me.eDtpRecvDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpRecvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpRecvDate.Location = New System.Drawing.Point(215, 176)
        Me.eDtpRecvDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpRecvDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpRecvDate.Name = "eDtpRecvDate"
        Me.eDtpRecvDate.Size = New System.Drawing.Size(92, 20)
        Me.eDtpRecvDate.TabIndex = 7
        Me.eDtpRecvDate.Value = New Date(2010, 3, 19, 0, 0, 0, 0)
        '
        'lblRcvDate
        '
        Me.lblRcvDate.AutoSize = True
        Me.lblRcvDate.BackColor = System.Drawing.Color.Transparent
        Me.lblRcvDate.Location = New System.Drawing.Point(212, 160)
        Me.lblRcvDate.Name = "lblRcvDate"
        Me.lblRcvDate.Size = New System.Drawing.Size(79, 13)
        Me.lblRcvDate.TabIndex = 115
        Me.lblRcvDate.Text = "Received Date"
        '
        'eDtpShipDate
        '
        Me.eDtpShipDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpShipDate.Location = New System.Drawing.Point(322, 176)
        Me.eDtpShipDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpShipDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpShipDate.Name = "eDtpShipDate"
        Me.eDtpShipDate.Size = New System.Drawing.Size(92, 20)
        Me.eDtpShipDate.TabIndex = 8
        Me.eDtpShipDate.Value = New Date(2010, 3, 19, 0, 0, 0, 0)
        '
        'lblShipDate
        '
        Me.lblShipDate.AutoSize = True
        Me.lblShipDate.BackColor = System.Drawing.Color.Transparent
        Me.lblShipDate.Location = New System.Drawing.Point(319, 160)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(54, 13)
        Me.lblShipDate.TabIndex = 114
        Me.lblShipDate.Text = "Ship Date"
        '
        'txtStation
        '
        Me.txtStation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStation.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtStation.Location = New System.Drawing.Point(26, 82)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(202, 26)
        Me.txtStation.TabIndex = 1
        Me.txtStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.BackColor = System.Drawing.Color.Transparent
        Me.lblStation.Location = New System.Drawing.Point(23, 66)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 112
        Me.lblStation.Text = "Station"
        '
        'lblSignType
        '
        Me.lblSignType.AutoSize = True
        Me.lblSignType.BackColor = System.Drawing.Color.Transparent
        Me.lblSignType.Location = New System.Drawing.Point(23, 112)
        Me.lblSignType.Name = "lblSignType"
        Me.lblSignType.Size = New System.Drawing.Size(55, 13)
        Me.lblSignType.TabIndex = 110
        Me.lblSignType.Text = "Sign Type"
        '
        'lblAtmJob
        '
        Me.lblAtmJob.AutoSize = True
        Me.lblAtmJob.BackColor = System.Drawing.Color.Transparent
        Me.lblAtmJob.Location = New System.Drawing.Point(23, 23)
        Me.lblAtmJob.Name = "lblAtmJob"
        Me.lblAtmJob.Size = New System.Drawing.Size(57, 13)
        Me.lblAtmJob.TabIndex = 108
        Me.lblAtmJob.Text = "ATM Job#"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(663, 66)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 23)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'dgvSalvageListing
        '
        Me.dgvSalvageListing.AllowUserToOrderColumns = True
        Me.dgvSalvageListing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSalvageListing.BackgroundColor = System.Drawing.Color.White
        Me.dgvSalvageListing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSalvageListing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSalvageListing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSalvageListing.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSalvageListing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSalvageListing.EnableHeadersVisualStyles = False
        Me.dgvSalvageListing.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSalvageListing.Location = New System.Drawing.Point(0, 0)
        Me.dgvSalvageListing.Name = "dgvSalvageListing"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSalvageListing.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSalvageListing.RowHeadersVisible = False
        Me.dgvSalvageListing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSalvageListing.Size = New System.Drawing.Size(775, 310)
        Me.dgvSalvageListing.TabIndex = 0
        Me.dgvSalvageListing.TabStop = False
        '
        'frmSalvageInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(775, 581)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSalvageInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salvage Sign Inventory"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSignSize.ResumeLayout(False)
        Me.grpSignSize.PerformLayout()
        CType(Me.dgvSalvageListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents picSign As System.Windows.Forms.PictureBox
    Friend WithEvents ckbReInstalled As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSalvageFields As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents grpSignSize As System.Windows.Forms.GroupBox
    Friend WithEvents lblSignWidth As System.Windows.Forms.Label
    Friend WithEvents txtSignWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtSignHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblSignHeight As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents eDtpRecvDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents lblRcvDate As System.Windows.Forms.Label
    Friend WithEvents eDtpShipDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblSignType As System.Windows.Forms.Label
    Friend WithEvents lblAtmJob As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents dgvSalvageListing As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSignType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAtmJob As System.Windows.Forms.TextBox
    Friend WithEvents txtSignType As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
End Class
