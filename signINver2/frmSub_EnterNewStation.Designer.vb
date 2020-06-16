<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSub_EnterNewStation
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSub_EnterNewStation))
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.lblGuardRailStations = New System.Windows.Forms.Label
		Me.lblRemovalQty = New System.Windows.Forms.Label
		Me.txtRemovalQty = New System.Windows.Forms.TextBox
		Me.btnAddRemoval = New System.Windows.Forms.Button
		Me.lblpID = New System.Windows.Forms.Label
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.btnDone = New System.Windows.Forms.Button
		Me.lblContractorID = New System.Windows.Forms.Label
		Me.cmbContractor = New System.Windows.Forms.ComboBox
		Me.lblContractor = New System.Windows.Forms.Label
		Me.btnNextRecord = New System.Windows.Forms.Button
		Me.picSignImage = New System.Windows.Forms.PictureBox
		Me.cmbSignCodes = New System.Windows.Forms.ComboBox
		Me.txtContractQty = New System.Windows.Forms.TextBox
		Me.txtSignCode = New System.Windows.Forms.TextBox
		Me.txtSignWidth = New System.Windows.Forms.TextBox
		Me.txtSignHeight = New System.Windows.Forms.TextBox
		Me.lblContractQty = New System.Windows.Forms.Label
		Me.lblSignHeight = New System.Windows.Forms.Label
		Me.lblSignWidth = New System.Windows.Forms.Label
		Me.lblUnit = New System.Windows.Forms.Label
		Me.lblSignCode = New System.Windows.Forms.Label
		Me.lblPayItemDesc = New System.Windows.Forms.Label
		Me.cmbPayItem = New System.Windows.Forms.ComboBox
		Me.lblPayItemID = New System.Windows.Forms.Label
		Me.lblSite = New System.Windows.Forms.Label
		Me.lblJob = New System.Windows.Forms.Label
		Me.lblStation = New System.Windows.Forms.Label
		Me.lblATMJob = New System.Windows.Forms.Label
		Me.dgvPID = New System.Windows.Forms.DataGridView
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		CType(Me.picSignImage, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvPID, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(1)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
		Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblGuardRailStations)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblRemovalQty)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtRemovalQty)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddRemoval)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblpID)
		Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip1)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnDone)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblContractorID)
		Me.SplitContainer1.Panel1.Controls.Add(Me.cmbContractor)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblContractor)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnNextRecord)
		Me.SplitContainer1.Panel1.Controls.Add(Me.picSignImage)
		Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSignCodes)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtContractQty)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtSignCode)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtSignWidth)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtSignHeight)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblContractQty)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblSignHeight)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblSignWidth)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblUnit)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblSignCode)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblPayItemDesc)
		Me.SplitContainer1.Panel1.Controls.Add(Me.cmbPayItem)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblPayItemID)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblSite)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblJob)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblStation)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblATMJob)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm1
		Me.SplitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPID)
		Me.SplitContainer1.Size = New System.Drawing.Size(779, 272)
		Me.SplitContainer1.SplitterDistance = 435
		Me.SplitContainer1.SplitterWidth = 1
		Me.SplitContainer1.TabIndex = 0
		'
		'lblGuardRailStations
		'
		Me.lblGuardRailStations.AutoSize = True
		Me.lblGuardRailStations.Location = New System.Drawing.Point(211, 23)
		Me.lblGuardRailStations.Name = "lblGuardRailStations"
		Me.lblGuardRailStations.Size = New System.Drawing.Size(0, 13)
		Me.lblGuardRailStations.TabIndex = 60
		Me.lblGuardRailStations.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblRemovalQty
		'
		Me.lblRemovalQty.AutoSize = True
		Me.lblRemovalQty.Location = New System.Drawing.Point(10, 222)
		Me.lblRemovalQty.Name = "lblRemovalQty"
		Me.lblRemovalQty.Size = New System.Drawing.Size(68, 13)
		Me.lblRemovalQty.TabIndex = 59
		Me.lblRemovalQty.Text = "Removal Qty"
		Me.lblRemovalQty.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtRemovalQty
		'
		Me.txtRemovalQty.Enabled = False
		Me.txtRemovalQty.Location = New System.Drawing.Point(84, 219)
		Me.txtRemovalQty.Multiline = True
		Me.txtRemovalQty.Name = "txtRemovalQty"
		Me.txtRemovalQty.Size = New System.Drawing.Size(53, 20)
		Me.txtRemovalQty.TabIndex = 7
		Me.txtRemovalQty.Text = "1"
		Me.txtRemovalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'btnAddRemoval
		'
		Me.btnAddRemoval.Enabled = False
		Me.btnAddRemoval.Location = New System.Drawing.Point(146, 217)
		Me.btnAddRemoval.Name = "btnAddRemoval"
		Me.btnAddRemoval.Size = New System.Drawing.Size(123, 23)
		Me.btnAddRemoval.TabIndex = 8
		Me.btnAddRemoval.Text = "Add Sign Removal"
		Me.btnAddRemoval.UseVisualStyleBackColor = True
		'
		'lblpID
		'
		Me.lblpID.AutoSize = True
		Me.lblpID.Location = New System.Drawing.Point(185, 49)
		Me.lblpID.Name = "lblpID"
		Me.lblpID.Size = New System.Drawing.Size(0, 13)
		Me.lblpID.TabIndex = 56
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 250)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(435, 22)
		Me.StatusStrip1.TabIndex = 55
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
		Me.ToolStripStatusLabel1.Text = "Ready"
		'
		'btnDone
		'
		Me.btnDone.Location = New System.Drawing.Point(317, 217)
		Me.btnDone.Name = "btnDone"
		Me.btnDone.Size = New System.Drawing.Size(110, 23)
		Me.btnDone.TabIndex = 9
		Me.btnDone.Text = "Finished"
		Me.btnDone.UseVisualStyleBackColor = True
		'
		'lblContractorID
		'
		Me.lblContractorID.AutoSize = True
		Me.lblContractorID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblContractorID.Location = New System.Drawing.Point(185, 183)
		Me.lblContractorID.Name = "lblContractorID"
		Me.lblContractorID.Size = New System.Drawing.Size(0, 13)
		Me.lblContractorID.TabIndex = 53
		Me.lblContractorID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cmbContractor
		'
		Me.cmbContractor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbContractor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbContractor.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbContractor.FormattingEnabled = True
		Me.cmbContractor.Location = New System.Drawing.Point(84, 180)
		Me.cmbContractor.Name = "cmbContractor"
		Me.cmbContractor.Size = New System.Drawing.Size(95, 21)
		Me.cmbContractor.TabIndex = 10
		'
		'lblContractor
		'
		Me.lblContractor.AutoSize = True
		Me.lblContractor.BackColor = System.Drawing.Color.Transparent
		Me.lblContractor.Location = New System.Drawing.Point(22, 183)
		Me.lblContractor.Name = "lblContractor"
		Me.lblContractor.Size = New System.Drawing.Size(56, 13)
		Me.lblContractor.TabIndex = 52
		Me.lblContractor.Text = "Contractor"
		Me.lblContractor.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnNextRecord
		'
		Me.btnNextRecord.Location = New System.Drawing.Point(188, 154)
		Me.btnNextRecord.Name = "btnNextRecord"
		Me.btnNextRecord.Size = New System.Drawing.Size(123, 23)
		Me.btnNextRecord.TabIndex = 6
		Me.btnNextRecord.Text = "Add"
		Me.btnNextRecord.UseVisualStyleBackColor = True
		'
		'picSignImage
		'
		Me.picSignImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picSignImage.Location = New System.Drawing.Point(317, 101)
		Me.picSignImage.Name = "picSignImage"
		Me.picSignImage.Size = New System.Drawing.Size(110, 110)
		Me.picSignImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picSignImage.TabIndex = 49
		Me.picSignImage.TabStop = False
		'
		'cmbSignCodes
		'
		Me.cmbSignCodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbSignCodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSignCodes.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbSignCodes.FormattingEnabled = True
		Me.cmbSignCodes.Location = New System.Drawing.Point(84, 101)
		Me.cmbSignCodes.Name = "cmbSignCodes"
		Me.cmbSignCodes.Size = New System.Drawing.Size(95, 21)
		Me.cmbSignCodes.TabIndex = 2
		'
		'txtContractQty
		'
		Me.txtContractQty.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtContractQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtContractQty.Location = New System.Drawing.Point(84, 154)
		Me.txtContractQty.Multiline = True
		Me.txtContractQty.Name = "txtContractQty"
		Me.txtContractQty.Size = New System.Drawing.Size(50, 20)
		Me.txtContractQty.TabIndex = 1
		Me.txtContractQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtSignCode
		'
		Me.txtSignCode.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSignCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtSignCode.Location = New System.Drawing.Point(188, 101)
		Me.txtSignCode.Multiline = True
		Me.txtSignCode.Name = "txtSignCode"
		Me.txtSignCode.Size = New System.Drawing.Size(123, 20)
		Me.txtSignCode.TabIndex = 2
		Me.txtSignCode.TabStop = False
		Me.txtSignCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'txtSignWidth
		'
		Me.txtSignWidth.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSignWidth.Location = New System.Drawing.Point(84, 128)
		Me.txtSignWidth.Multiline = True
		Me.txtSignWidth.Name = "txtSignWidth"
		Me.txtSignWidth.Size = New System.Drawing.Size(50, 20)
		Me.txtSignWidth.TabIndex = 3
		Me.txtSignWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtSignHeight
		'
		Me.txtSignHeight.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSignHeight.Location = New System.Drawing.Point(211, 128)
		Me.txtSignHeight.Multiline = True
		Me.txtSignHeight.Name = "txtSignHeight"
		Me.txtSignHeight.Size = New System.Drawing.Size(50, 20)
		Me.txtSignHeight.TabIndex = 4
		Me.txtSignHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblContractQty
		'
		Me.lblContractQty.AutoSize = True
		Me.lblContractQty.BackColor = System.Drawing.Color.Transparent
		Me.lblContractQty.Location = New System.Drawing.Point(12, 157)
		Me.lblContractQty.Name = "lblContractQty"
		Me.lblContractQty.Size = New System.Drawing.Size(66, 13)
		Me.lblContractQty.TabIndex = 48
		Me.lblContractQty.Text = "Contract Qty"
		Me.lblContractQty.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSignHeight
		'
		Me.lblSignHeight.AutoSize = True
		Me.lblSignHeight.BackColor = System.Drawing.Color.Transparent
		Me.lblSignHeight.Location = New System.Drawing.Point(143, 131)
		Me.lblSignHeight.Name = "lblSignHeight"
		Me.lblSignHeight.Size = New System.Drawing.Size(62, 13)
		Me.lblSignHeight.TabIndex = 47
		Me.lblSignHeight.Text = "Sign Height"
		Me.lblSignHeight.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSignWidth
		'
		Me.lblSignWidth.AutoSize = True
		Me.lblSignWidth.BackColor = System.Drawing.Color.Transparent
		Me.lblSignWidth.Location = New System.Drawing.Point(19, 131)
		Me.lblSignWidth.Name = "lblSignWidth"
		Me.lblSignWidth.Size = New System.Drawing.Size(59, 13)
		Me.lblSignWidth.TabIndex = 46
		Me.lblSignWidth.Text = "Sign Width"
		Me.lblSignWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblUnit
		'
		Me.lblUnit.AutoSize = True
		Me.lblUnit.BackColor = System.Drawing.Color.Transparent
		Me.lblUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUnit.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblUnit.Location = New System.Drawing.Point(140, 157)
		Me.lblUnit.Name = "lblUnit"
		Me.lblUnit.Size = New System.Drawing.Size(30, 13)
		Me.lblUnit.TabIndex = 44
		Me.lblUnit.Text = "Unit"
		Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblSignCode
		'
		Me.lblSignCode.AutoSize = True
		Me.lblSignCode.BackColor = System.Drawing.Color.Transparent
		Me.lblSignCode.Location = New System.Drawing.Point(22, 104)
		Me.lblSignCode.Name = "lblSignCode"
		Me.lblSignCode.Size = New System.Drawing.Size(56, 13)
		Me.lblSignCode.TabIndex = 45
		Me.lblSignCode.Text = "Sign Code"
		Me.lblSignCode.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblPayItemDesc
		'
		Me.lblPayItemDesc.AutoSize = True
		Me.lblPayItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPayItemDesc.ForeColor = System.Drawing.SystemColors.ActiveCaption
		Me.lblPayItemDesc.Location = New System.Drawing.Point(81, 70)
		Me.lblPayItemDesc.Name = "lblPayItemDesc"
		Me.lblPayItemDesc.Size = New System.Drawing.Size(124, 13)
		Me.lblPayItemDesc.TabIndex = 21
		Me.lblPayItemDesc.Text = "Pay Item Description"
		'
		'cmbPayItem
		'
		Me.cmbPayItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbPayItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbPayItem.BackColor = System.Drawing.Color.WhiteSmoke
		Me.cmbPayItem.FormattingEnabled = True
		Me.cmbPayItem.Location = New System.Drawing.Point(84, 46)
		Me.cmbPayItem.Name = "cmbPayItem"
		Me.cmbPayItem.Size = New System.Drawing.Size(95, 21)
		Me.cmbPayItem.TabIndex = 0
		'
		'lblPayItemID
		'
		Me.lblPayItemID.AutoSize = True
		Me.lblPayItemID.BackColor = System.Drawing.Color.Transparent
		Me.lblPayItemID.Location = New System.Drawing.Point(30, 49)
		Me.lblPayItemID.Name = "lblPayItemID"
		Me.lblPayItemID.Size = New System.Drawing.Size(48, 13)
		Me.lblPayItemID.TabIndex = 22
		Me.lblPayItemID.Text = "Pay Item"
		Me.lblPayItemID.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblSite
		'
		Me.lblSite.AutoSize = True
		Me.lblSite.BackColor = System.Drawing.Color.Transparent
		Me.lblSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSite.ForeColor = System.Drawing.Color.DarkSlateGray
		Me.lblSite.Location = New System.Drawing.Point(211, 7)
		Me.lblSite.Name = "lblSite"
		Me.lblSite.Size = New System.Drawing.Size(56, 16)
		Me.lblSite.TabIndex = 19
		Me.lblSite.Text = "Station"
		Me.lblSite.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblJob
		'
		Me.lblJob.AutoSize = True
		Me.lblJob.BackColor = System.Drawing.Color.Transparent
		Me.lblJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblJob.Location = New System.Drawing.Point(78, 7)
		Me.lblJob.Name = "lblJob"
		Me.lblJob.Size = New System.Drawing.Size(34, 16)
		Me.lblJob.TabIndex = 18
		Me.lblJob.Text = "Job"
		Me.lblJob.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblStation
		'
		Me.lblStation.AutoSize = True
		Me.lblStation.BackColor = System.Drawing.Color.Transparent
		Me.lblStation.Location = New System.Drawing.Point(180, 9)
		Me.lblStation.Name = "lblStation"
		Me.lblStation.Size = New System.Drawing.Size(25, 13)
		Me.lblStation.TabIndex = 17
		Me.lblStation.Text = "Site"
		Me.lblStation.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblATMJob
		'
		Me.lblATMJob.AutoSize = True
		Me.lblATMJob.BackColor = System.Drawing.Color.Transparent
		Me.lblATMJob.Location = New System.Drawing.Point(12, 9)
		Me.lblATMJob.Name = "lblATMJob"
		Me.lblATMJob.Size = New System.Drawing.Size(60, 13)
		Me.lblATMJob.TabIndex = 16
		Me.lblATMJob.Text = "ATM Job #"
		Me.lblATMJob.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'dgvPID
		'
		Me.dgvPID.AllowUserToAddRows = False
		Me.dgvPID.AllowUserToDeleteRows = False
		Me.dgvPID.BackgroundColor = System.Drawing.Color.White
		Me.dgvPID.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvPID.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvPID.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvPID.EnableHeadersVisualStyles = False
		Me.dgvPID.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvPID.Location = New System.Drawing.Point(0, 0)
		Me.dgvPID.Name = "dgvPID"
		Me.dgvPID.ReadOnly = True
		Me.dgvPID.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		Me.dgvPID.RowHeadersVisible = False
		Me.dgvPID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvPID.Size = New System.Drawing.Size(343, 272)
		Me.dgvPID.TabIndex = 57
		Me.dgvPID.TabStop = False
		'
		'frmSub_EnterNewStation
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(779, 272)
		Me.Controls.Add(Me.SplitContainer1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmSub_EnterNewStation"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Sub-Form  Enter New Station"
		Me.TopMost = True
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		CType(Me.picSignImage, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvPID, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblATMJob As System.Windows.Forms.Label
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents lblJob As System.Windows.Forms.Label
    Friend WithEvents lblPayItemDesc As System.Windows.Forms.Label
    Friend WithEvents cmbPayItem As System.Windows.Forms.ComboBox
    Friend WithEvents lblPayItemID As System.Windows.Forms.Label
    Friend WithEvents picSignImage As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSignCodes As System.Windows.Forms.ComboBox
    Friend WithEvents txtContractQty As System.Windows.Forms.TextBox
    Friend WithEvents txtSignCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSignWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtSignHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblContractQty As System.Windows.Forms.Label
    Friend WithEvents lblSignHeight As System.Windows.Forms.Label
    Friend WithEvents lblSignWidth As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblSignCode As System.Windows.Forms.Label
    Friend WithEvents btnNextRecord As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents lblContractorID As System.Windows.Forms.Label
    Friend WithEvents cmbContractor As System.Windows.Forms.ComboBox
    Friend WithEvents lblContractor As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblpID As System.Windows.Forms.Label
    Friend WithEvents dgvPID As System.Windows.Forms.DataGridView
    Friend WithEvents lblRemovalQty As System.Windows.Forms.Label
    Friend WithEvents txtRemovalQty As System.Windows.Forms.TextBox
	Friend WithEvents btnAddRemoval As System.Windows.Forms.Button
	Friend WithEvents lblGuardRailStations As System.Windows.Forms.Label
End Class
