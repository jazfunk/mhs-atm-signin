<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlywoodSheetingSizes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlywoodSheetingSizes))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvPLYTOF = New System.Windows.Forms.DataGridView
        Me.grpJobInfo = New System.Windows.Forms.GroupBox
        Me.lblCust = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblCustJob = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblProjNum = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblStateNum = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblCompDate = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ckbActive = New System.Windows.Forms.CheckBox
        Me.ckbMMM = New System.Windows.Forms.CheckBox
        Me.lblRunID = New System.Windows.Forms.Label
        Me.txtRunID = New System.Windows.Forms.TextBox
        Me.lblSignDetails = New System.Windows.Forms.Label
        Me.txtSignDetails = New System.Windows.Forms.TextBox
        Me.grpSheetDetails = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ckbTwoPartSign = New System.Windows.Forms.CheckBox
        Me.lblSheetingCode = New System.Windows.Forms.Label
        Me.lblSheetingWidth = New System.Windows.Forms.Label
        Me.txtSheeting = New System.Windows.Forms.TextBox
        Me.cmbSizes = New System.Windows.Forms.ComboBox
        Me.lblSheetDesc = New System.Windows.Forms.Label
        Me.cmbSheetType = New System.Windows.Forms.ComboBox
        Me.txtEstLFT = New System.Windows.Forms.TextBox
        Me.PictureBoxSheeting = New System.Windows.Forms.PictureBox
        Me.cmbStations = New System.Windows.Forms.ComboBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblMHSJob = New System.Windows.Forms.Label
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnForward = New System.Windows.Forms.Button
        Me.txtSqrFeet = New System.Windows.Forms.TextBox
        Me.txtSignWidth = New System.Windows.Forms.TextBox
        Me.txtSignHeight = New System.Windows.Forms.TextBox
        Me.lblSqrFeet = New System.Windows.Forms.Label
        Me.picSign = New System.Windows.Forms.PictureBox
        Me.lblEquals = New System.Windows.Forms.Label
        Me.lblX = New System.Windows.Forms.Label
        Me.lblType = New System.Windows.Forms.Label
        Me.lblStation = New System.Windows.Forms.Label
        Me.lblSignCode = New System.Windows.Forms.Label
        Me.txtSignCode = New System.Windows.Forms.TextBox
        Me.txtSignType = New System.Windows.Forms.TextBox
        Me.txtStation = New System.Windows.Forms.TextBox
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvPLYTOF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJobInfo.SuspendLayout()
        Me.grpSheetDetails.SuspendLayout()
        CType(Me.PictureBoxSheeting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(896, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvPLYTOF)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblJobDesc)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpJobInfo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRunID)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtRunID)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignDetails)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSignDetails)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpSheetDetails)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbStations)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAdd)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblMHSJob)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnBack)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnForward)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSqrFeet)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSignWidth)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSignHeight)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSqrFeet)
        Me.SplitContainer1.Panel2.Controls.Add(Me.picSign)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblEquals)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblX)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblStation)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSignCode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSignCode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSignType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtStation)
        Me.SplitContainer1.Size = New System.Drawing.Size(896, 497)
        Me.SplitContainer1.SplitterDistance = 396
        Me.SplitContainer1.TabIndex = 1
        '
        'dgvPLYTOF
        '
        Me.dgvPLYTOF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPLYTOF.BackgroundColor = System.Drawing.Color.White
        Me.dgvPLYTOF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPLYTOF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPLYTOF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPLYTOF.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPLYTOF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPLYTOF.EnableHeadersVisualStyles = False
        Me.dgvPLYTOF.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPLYTOF.Location = New System.Drawing.Point(0, 0)
        Me.dgvPLYTOF.Name = "dgvPLYTOF"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPLYTOF.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPLYTOF.RowHeadersVisible = False
        Me.dgvPLYTOF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPLYTOF.Size = New System.Drawing.Size(396, 497)
        Me.dgvPLYTOF.TabIndex = 1
        Me.dgvPLYTOF.TabStop = False
        '
        'grpJobInfo
        '
        Me.grpJobInfo.Controls.Add(Me.lblCust)
        Me.grpJobInfo.Controls.Add(Me.Label13)
        Me.grpJobInfo.Controls.Add(Me.lblCustJob)
        Me.grpJobInfo.Controls.Add(Me.Label12)
        Me.grpJobInfo.Controls.Add(Me.lblProjNum)
        Me.grpJobInfo.Controls.Add(Me.Label11)
        Me.grpJobInfo.Controls.Add(Me.lblStateNum)
        Me.grpJobInfo.Controls.Add(Me.Label10)
        Me.grpJobInfo.Controls.Add(Me.lblCompDate)
        Me.grpJobInfo.Controls.Add(Me.Label9)
        Me.grpJobInfo.Controls.Add(Me.ckbActive)
        Me.grpJobInfo.Controls.Add(Me.ckbMMM)
        Me.grpJobInfo.Location = New System.Drawing.Point(313, 53)
        Me.grpJobInfo.Name = "grpJobInfo"
        Me.grpJobInfo.Size = New System.Drawing.Size(173, 258)
        Me.grpJobInfo.TabIndex = 113
        Me.grpJobInfo.TabStop = False
        Me.grpJobInfo.Text = "Project Details"
        '
        'lblCust
        '
        Me.lblCust.BackColor = System.Drawing.Color.Transparent
        Me.lblCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCust.Location = New System.Drawing.Point(81, 27)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(82, 24)
        Me.lblCust.TabIndex = 101
        Me.lblCust.Text = "cust"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(16, 213)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Completion"
        '
        'lblCustJob
        '
        Me.lblCustJob.BackColor = System.Drawing.Color.Transparent
        Me.lblCustJob.Location = New System.Drawing.Point(81, 56)
        Me.lblCustJob.Name = "lblCustJob"
        Me.lblCustJob.Size = New System.Drawing.Size(82, 13)
        Me.lblCustJob.TabIndex = 102
        Me.lblCustJob.Text = "custJob"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(14, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "State Job #"
        '
        'lblProjNum
        '
        Me.lblProjNum.BackColor = System.Drawing.Color.Transparent
        Me.lblProjNum.Location = New System.Drawing.Point(81, 82)
        Me.lblProjNum.Name = "lblProjNum"
        Me.lblProjNum.Size = New System.Drawing.Size(82, 13)
        Me.lblProjNum.TabIndex = 103
        Me.lblProjNum.Text = "projNum"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(26, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Project #"
        '
        'lblStateNum
        '
        Me.lblStateNum.BackColor = System.Drawing.Color.Transparent
        Me.lblStateNum.Location = New System.Drawing.Point(82, 111)
        Me.lblStateNum.Name = "lblStateNum"
        Me.lblStateNum.Size = New System.Drawing.Size(82, 13)
        Me.lblStateNum.TabIndex = 104
        Me.lblStateNum.Text = "stateNum"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(42, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Job #"
        '
        'lblCompDate
        '
        Me.lblCompDate.BackColor = System.Drawing.Color.Transparent
        Me.lblCompDate.Location = New System.Drawing.Point(81, 213)
        Me.lblCompDate.Name = "lblCompDate"
        Me.lblCompDate.Size = New System.Drawing.Size(83, 13)
        Me.lblCompDate.TabIndex = 105
        Me.lblCompDate.Text = "compDate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(25, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Customer"
        '
        'ckbActive
        '
        Me.ckbActive.AutoSize = True
        Me.ckbActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbActive.Enabled = False
        Me.ckbActive.Location = New System.Drawing.Point(58, 147)
        Me.ckbActive.Name = "ckbActive"
        Me.ckbActive.Size = New System.Drawing.Size(56, 17)
        Me.ckbActive.TabIndex = 106
        Me.ckbActive.Text = "Active"
        Me.ckbActive.UseVisualStyleBackColor = True
        '
        'ckbMMM
        '
        Me.ckbMMM.AutoSize = True
        Me.ckbMMM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbMMM.Enabled = False
        Me.ckbMMM.Location = New System.Drawing.Point(49, 170)
        Me.ckbMMM.Name = "ckbMMM"
        Me.ckbMMM.Size = New System.Drawing.Size(65, 17)
        Me.ckbMMM.TabIndex = 107
        Me.ckbMMM.Text = "3M Disc"
        Me.ckbMMM.UseVisualStyleBackColor = True
        '
        'lblRunID
        '
        Me.lblRunID.AutoSize = True
        Me.lblRunID.BackColor = System.Drawing.Color.Transparent
        Me.lblRunID.Location = New System.Drawing.Point(10, 24)
        Me.lblRunID.Name = "lblRunID"
        Me.lblRunID.Size = New System.Drawing.Size(41, 13)
        Me.lblRunID.TabIndex = 99
        Me.lblRunID.Text = "Run ID"
        '
        'txtRunID
        '
        Me.txtRunID.BackColor = System.Drawing.Color.White
        Me.txtRunID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRunID.Location = New System.Drawing.Point(58, 13)
        Me.txtRunID.Name = "txtRunID"
        Me.txtRunID.Size = New System.Drawing.Size(249, 29)
        Me.txtRunID.TabIndex = 0
        Me.txtRunID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSignDetails
        '
        Me.lblSignDetails.AutoSize = True
        Me.lblSignDetails.BackColor = System.Drawing.Color.Transparent
        Me.lblSignDetails.Location = New System.Drawing.Point(13, 117)
        Me.lblSignDetails.Name = "lblSignDetails"
        Me.lblSignDetails.Size = New System.Drawing.Size(39, 13)
        Me.lblSignDetails.TabIndex = 97
        Me.lblSignDetails.Text = "Details"
        '
        'txtSignDetails
        '
        Me.txtSignDetails.BackColor = System.Drawing.Color.White
        Me.txtSignDetails.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSignDetails.Location = New System.Drawing.Point(58, 114)
        Me.txtSignDetails.Name = "txtSignDetails"
        Me.txtSignDetails.ReadOnly = True
        Me.txtSignDetails.Size = New System.Drawing.Size(249, 20)
        Me.txtSignDetails.TabIndex = 96
        Me.txtSignDetails.TabStop = False
        Me.txtSignDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpSheetDetails
        '
        Me.grpSheetDetails.Controls.Add(Me.Label1)
        Me.grpSheetDetails.Controls.Add(Me.ckbTwoPartSign)
        Me.grpSheetDetails.Controls.Add(Me.lblSheetingCode)
        Me.grpSheetDetails.Controls.Add(Me.lblSheetingWidth)
        Me.grpSheetDetails.Controls.Add(Me.txtSheeting)
        Me.grpSheetDetails.Controls.Add(Me.cmbSizes)
        Me.grpSheetDetails.Controls.Add(Me.lblSheetDesc)
        Me.grpSheetDetails.Controls.Add(Me.cmbSheetType)
        Me.grpSheetDetails.Controls.Add(Me.txtEstLFT)
        Me.grpSheetDetails.Controls.Add(Me.PictureBoxSheeting)
        Me.grpSheetDetails.Location = New System.Drawing.Point(10, 343)
        Me.grpSheetDetails.Name = "grpSheetDetails"
        Me.grpSheetDetails.Size = New System.Drawing.Size(476, 100)
        Me.grpSheetDetails.TabIndex = 95
        Me.grpSheetDetails.TabStop = False
        Me.grpSheetDetails.Text = "Sheeting Details"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(282, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "lft"
        '
        'ckbTwoPartSign
        '
        Me.ckbTwoPartSign.AutoSize = True
        Me.ckbTwoPartSign.Location = New System.Drawing.Point(405, 45)
        Me.ckbTwoPartSign.Name = "ckbTwoPartSign"
        Me.ckbTwoPartSign.Size = New System.Drawing.Size(54, 17)
        Me.ckbTwoPartSign.TabIndex = 100
        Me.ckbTwoPartSign.Text = "2-Part"
        Me.ckbTwoPartSign.UseVisualStyleBackColor = True
        '
        'lblSheetingCode
        '
        Me.lblSheetingCode.AutoSize = True
        Me.lblSheetingCode.Location = New System.Drawing.Point(10, 31)
        Me.lblSheetingCode.Name = "lblSheetingCode"
        Me.lblSheetingCode.Size = New System.Drawing.Size(32, 13)
        Me.lblSheetingCode.TabIndex = 85
        Me.lblSheetingCode.Text = "Code"
        '
        'lblSheetingWidth
        '
        Me.lblSheetingWidth.AutoSize = True
        Me.lblSheetingWidth.Location = New System.Drawing.Point(153, 31)
        Me.lblSheetingWidth.Name = "lblSheetingWidth"
        Me.lblSheetingWidth.Size = New System.Drawing.Size(35, 13)
        Me.lblSheetingWidth.TabIndex = 1
        Me.lblSheetingWidth.Text = "Width"
        '
        'txtSheeting
        '
        Me.txtSheeting.Location = New System.Drawing.Point(242, 146)
        Me.txtSheeting.Name = "txtSheeting"
        Me.txtSheeting.Size = New System.Drawing.Size(92, 20)
        Me.txtSheeting.TabIndex = 93
        '
        'cmbSizes
        '
        Me.cmbSizes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSizes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSizes.FormattingEnabled = True
        Me.cmbSizes.Items.AddRange(New Object() {"6", "12", "18", "24", "30", "36", "42", "48"})
        Me.cmbSizes.Location = New System.Drawing.Point(194, 28)
        Me.cmbSizes.Name = "cmbSizes"
        Me.cmbSizes.Size = New System.Drawing.Size(64, 21)
        Me.cmbSizes.TabIndex = 1
        '
        'lblSheetDesc
        '
        Me.lblSheetDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSheetDesc.Location = New System.Drawing.Point(13, 58)
        Me.lblSheetDesc.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSheetDesc.Name = "lblSheetDesc"
        Me.lblSheetDesc.Size = New System.Drawing.Size(354, 21)
        Me.lblSheetDesc.TabIndex = 91
        Me.lblSheetDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbSheetType
        '
        Me.cmbSheetType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSheetType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSheetType.DropDownHeight = 350
        Me.cmbSheetType.FormattingEnabled = True
        Me.cmbSheetType.IntegralHeight = False
        Me.cmbSheetType.Location = New System.Drawing.Point(48, 28)
        Me.cmbSheetType.Name = "cmbSheetType"
        Me.cmbSheetType.Size = New System.Drawing.Size(90, 21)
        Me.cmbSheetType.TabIndex = 0
        '
        'txtEstLFT
        '
        Me.txtEstLFT.Location = New System.Drawing.Point(303, 28)
        Me.txtEstLFT.Name = "txtEstLFT"
        Me.txtEstLFT.Size = New System.Drawing.Size(64, 20)
        Me.txtEstLFT.TabIndex = 2
        Me.txtEstLFT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBoxSheeting
        '
        Me.PictureBoxSheeting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxSheeting.Location = New System.Drawing.Point(10, 54)
        Me.PictureBoxSheeting.Name = "PictureBoxSheeting"
        Me.PictureBoxSheeting.Size = New System.Drawing.Size(358, 30)
        Me.PictureBoxSheeting.TabIndex = 88
        Me.PictureBoxSheeting.TabStop = False
        '
        'cmbStations
        '
        Me.cmbStations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStations.DropDownHeight = 350
        Me.cmbStations.FormattingEnabled = True
        Me.cmbStations.IntegralHeight = False
        Me.cmbStations.Location = New System.Drawing.Point(95, 461)
        Me.cmbStations.Name = "cmbStations"
        Me.cmbStations.Size = New System.Drawing.Size(122, 21)
        Me.cmbStations.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(363, 459)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(123, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblMHSJob
        '
        Me.lblMHSJob.BackColor = System.Drawing.Color.Transparent
        Me.lblMHSJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMHSJob.ForeColor = System.Drawing.Color.Navy
        Me.lblMHSJob.Location = New System.Drawing.Point(315, 22)
        Me.lblMHSJob.Name = "lblMHSJob"
        Me.lblMHSJob.Size = New System.Drawing.Size(165, 35)
        Me.lblMHSJob.TabIndex = 92
        Me.lblMHSJob.Text = "MHS Job"
        Me.lblMHSJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(223, 459)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(53, 23)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "<<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(282, 459)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(53, 23)
        Me.btnForward.TabIndex = 0
        Me.btnForward.Text = ">>"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'txtSqrFeet
        '
        Me.txtSqrFeet.BackColor = System.Drawing.Color.White
        Me.txtSqrFeet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSqrFeet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSqrFeet.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtSqrFeet.Location = New System.Drawing.Point(220, 317)
        Me.txtSqrFeet.Name = "txtSqrFeet"
        Me.txtSqrFeet.ReadOnly = True
        Me.txtSqrFeet.Size = New System.Drawing.Size(60, 21)
        Me.txtSqrFeet.TabIndex = 81
        Me.txtSqrFeet.TabStop = False
        Me.txtSqrFeet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSignWidth
        '
        Me.txtSignWidth.BackColor = System.Drawing.Color.White
        Me.txtSignWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignWidth.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSignWidth.Location = New System.Drawing.Point(58, 317)
        Me.txtSignWidth.Name = "txtSignWidth"
        Me.txtSignWidth.ReadOnly = True
        Me.txtSignWidth.Size = New System.Drawing.Size(54, 20)
        Me.txtSignWidth.TabIndex = 79
        Me.txtSignWidth.TabStop = False
        Me.txtSignWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSignHeight
        '
        Me.txtSignHeight.BackColor = System.Drawing.Color.White
        Me.txtSignHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignHeight.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSignHeight.Location = New System.Drawing.Point(136, 317)
        Me.txtSignHeight.Name = "txtSignHeight"
        Me.txtSignHeight.ReadOnly = True
        Me.txtSignHeight.Size = New System.Drawing.Size(54, 20)
        Me.txtSignHeight.TabIndex = 80
        Me.txtSignHeight.TabStop = False
        Me.txtSignHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSqrFeet
        '
        Me.lblSqrFeet.AutoSize = True
        Me.lblSqrFeet.Location = New System.Drawing.Point(286, 320)
        Me.lblSqrFeet.Name = "lblSqrFeet"
        Me.lblSqrFeet.Size = New System.Drawing.Size(21, 13)
        Me.lblSqrFeet.TabIndex = 82
        Me.lblSqrFeet.Text = "sFt"
        '
        'picSign
        '
        Me.picSign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSign.Location = New System.Drawing.Point(58, 150)
        Me.picSign.Name = "picSign"
        Me.picSign.Size = New System.Drawing.Size(249, 161)
        Me.picSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picSign.TabIndex = 4
        Me.picSign.TabStop = False
        '
        'lblEquals
        '
        Me.lblEquals.AutoSize = True
        Me.lblEquals.Location = New System.Drawing.Point(201, 320)
        Me.lblEquals.Name = "lblEquals"
        Me.lblEquals.Size = New System.Drawing.Size(13, 13)
        Me.lblEquals.TabIndex = 84
        Me.lblEquals.Text = "="
        Me.lblEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(118, 320)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(12, 13)
        Me.lblX.TabIndex = 83
        Me.lblX.Text = "x"
        Me.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.Location = New System.Drawing.Point(21, 204)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(31, 13)
        Me.lblType.TabIndex = 78
        Me.lblType.Text = "Type"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.BackColor = System.Drawing.Color.Transparent
        Me.lblStation.Location = New System.Drawing.Point(12, 64)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 77
        Me.lblStation.Text = "Station"
        '
        'lblSignCode
        '
        Me.lblSignCode.AutoSize = True
        Me.lblSignCode.BackColor = System.Drawing.Color.Transparent
        Me.lblSignCode.Location = New System.Drawing.Point(20, 91)
        Me.lblSignCode.Name = "lblSignCode"
        Me.lblSignCode.Size = New System.Drawing.Size(32, 13)
        Me.lblSignCode.TabIndex = 76
        Me.lblSignCode.Text = "Code"
        '
        'txtSignCode
        '
        Me.txtSignCode.BackColor = System.Drawing.Color.White
        Me.txtSignCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSignCode.Location = New System.Drawing.Point(58, 88)
        Me.txtSignCode.Name = "txtSignCode"
        Me.txtSignCode.ReadOnly = True
        Me.txtSignCode.Size = New System.Drawing.Size(249, 20)
        Me.txtSignCode.TabIndex = 75
        Me.txtSignCode.TabStop = False
        Me.txtSignCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSignType
        '
        Me.txtSignType.BackColor = System.Drawing.Color.White
        Me.txtSignType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignType.Location = New System.Drawing.Point(13, 220)
        Me.txtSignType.Name = "txtSignType"
        Me.txtSignType.ReadOnly = True
        Me.txtSignType.Size = New System.Drawing.Size(39, 24)
        Me.txtSignType.TabIndex = 73
        Me.txtSignType.TabStop = False
        Me.txtSignType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStation
        '
        Me.txtStation.BackColor = System.Drawing.Color.White
        Me.txtStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtStation.Location = New System.Drawing.Point(58, 53)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.ReadOnly = True
        Me.txtStation.Size = New System.Drawing.Size(249, 29)
        Me.txtStation.TabIndex = 74
        Me.txtStation.TabStop = False
        Me.txtStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblJobDesc
        '
        Me.lblJobDesc.AutoSize = True
        Me.lblJobDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblJobDesc.Location = New System.Drawing.Point(313, 9)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(0, 13)
        Me.lblJobDesc.TabIndex = 114
        '
        'frmPlywoodSheetingSizes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(896, 519)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPlywoodSheetingSizes"
        Me.Text = "Plywood Sheeting Estimator"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvPLYTOF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJobInfo.ResumeLayout(False)
        Me.grpJobInfo.PerformLayout()
        Me.grpSheetDetails.ResumeLayout(False)
        Me.grpSheetDetails.PerformLayout()
        CType(Me.PictureBoxSheeting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents picSign As System.Windows.Forms.PictureBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cmbSizes As System.Windows.Forms.ComboBox
    Friend WithEvents lblSheetingWidth As System.Windows.Forms.Label
    Friend WithEvents txtEstLFT As System.Windows.Forms.TextBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblSignCode As System.Windows.Forms.Label
    Friend WithEvents txtSignCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSignType As System.Windows.Forms.TextBox
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtSqrFeet As System.Windows.Forms.TextBox
    Friend WithEvents txtSignWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtSignHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblSqrFeet As System.Windows.Forms.Label
    Friend WithEvents lblEquals As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblSheetingCode As System.Windows.Forms.Label
    Friend WithEvents cmbSheetType As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBoxSheeting As System.Windows.Forms.PictureBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnForward As System.Windows.Forms.Button
    Friend WithEvents lblSheetDesc As System.Windows.Forms.Label
    Friend WithEvents dgvPLYTOF As System.Windows.Forms.DataGridView
    Friend WithEvents lblMHSJob As System.Windows.Forms.Label
    Friend WithEvents txtSheeting As System.Windows.Forms.TextBox
    Friend WithEvents cmbStations As System.Windows.Forms.ComboBox
    Friend WithEvents grpSheetDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSignDetails As System.Windows.Forms.Label
    Friend WithEvents txtSignDetails As System.Windows.Forms.TextBox
    Friend WithEvents lblRunID As System.Windows.Forms.Label
    Friend WithEvents txtRunID As System.Windows.Forms.TextBox
    Friend WithEvents ckbTwoPartSign As System.Windows.Forms.CheckBox
    Friend WithEvents grpJobInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblCustJob As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblProjNum As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblStateNum As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCompDate As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ckbActive As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMMM As System.Windows.Forms.CheckBox
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
End Class
