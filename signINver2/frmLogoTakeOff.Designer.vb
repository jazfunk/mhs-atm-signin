<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogoTakeOff
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
		Me.dgvLogoTOF = New System.Windows.Forms.DataGridView
		Me.SplitContainerTOF = New System.Windows.Forms.SplitContainer
		Me.lblLongitude = New System.Windows.Forms.Label
		Me.lblLatitude = New System.Windows.Forms.Label
		Me.TableLayoutPanelNAV = New System.Windows.Forms.TableLayoutPanel
		Me.btnLoadXML = New System.Windows.Forms.Button
		Me.btn_ShowMap = New System.Windows.Forms.Button
		Me.btnLast = New System.Windows.Forms.Button
		Me.btnFirst = New System.Windows.Forms.Button
		Me.btnNext = New System.Windows.Forms.Button
		Me.btnPrev = New System.Windows.Forms.Button
		Me.tb_Longitude = New System.Windows.Forms.TextBox
		Me.btnAll = New System.Windows.Forms.Button
		Me.cmbWorkOrderDate = New System.Windows.Forms.ComboBox
		Me.tb_Latitude = New System.Windows.Forms.TextBox
		Me.lblWorkOrder = New System.Windows.Forms.Label
		Me.lblFilter = New System.Windows.Forms.Label
		Me.txtCriteria = New System.Windows.Forms.TextBox
		Me.cmbFields = New System.Windows.Forms.ComboBox
		Me.lblBy = New System.Windows.Forms.Label
		Me.btnSaveChanges = New System.Windows.Forms.Button
		Me.SplitContainerMain = New System.Windows.Forms.SplitContainer
		Me.SplitContainerTOP = New System.Windows.Forms.SplitContainer
		Me.SplitContainerMID = New System.Windows.Forms.SplitContainer
		Me.txtsType = New System.Windows.Forms.TextBox
		Me.txtService = New System.Windows.Forms.TextBox
		Me.txtDirection = New System.Windows.Forms.TextBox
		Me.txtExit = New System.Windows.Forms.TextBox
		Me.txtRoute = New System.Windows.Forms.TextBox
		Me.txtLongitude = New System.Windows.Forms.TextBox
		Me.txtLatitude = New System.Windows.Forms.TextBox
		Me.txtCity = New System.Windows.Forms.TextBox
		Me.txtCrossRoad = New System.Windows.Forms.TextBox
		Me.txtCounty = New System.Windows.Forms.TextBox
		Me.txtCompletionDate = New System.Windows.Forms.TextBox
		Me.txtComments = New System.Windows.Forms.TextBox
		Me.txtWorkType = New System.Windows.Forms.TextBox
		Me.txtHeight = New System.Windows.Forms.TextBox
		Me.txtWidth = New System.Windows.Forms.TextBox
		Me.txtOrderedDate = New System.Windows.Forms.TextBox
		Me.txtStructureNumber = New System.Windows.Forms.TextBox
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.txtStatusText = New System.Windows.Forms.ToolStripStatusLabel
		Me.grpWorkOrderDetails = New System.Windows.Forms.GroupBox
		Me.lblDetailString = New System.Windows.Forms.Label
		CType(Me.dgvLogoTOF, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainerTOF.Panel1.SuspendLayout()
		Me.SplitContainerTOF.Panel2.SuspendLayout()
		Me.SplitContainerTOF.SuspendLayout()
		Me.TableLayoutPanelNAV.SuspendLayout()
		Me.SplitContainerMain.Panel1.SuspendLayout()
		Me.SplitContainerMain.Panel2.SuspendLayout()
		Me.SplitContainerMain.SuspendLayout()
		Me.SplitContainerTOP.Panel1.SuspendLayout()
		Me.SplitContainerTOP.Panel2.SuspendLayout()
		Me.SplitContainerTOP.SuspendLayout()
		Me.SplitContainerMID.Panel2.SuspendLayout()
		Me.SplitContainerMID.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.grpWorkOrderDetails.SuspendLayout()
		Me.SuspendLayout()
		'
		'dgvLogoTOF
		'
		Me.dgvLogoTOF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvLogoTOF.BackgroundColor = System.Drawing.Color.White
		Me.dgvLogoTOF.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvLogoTOF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle4.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvLogoTOF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvLogoTOF.DefaultCellStyle = DataGridViewCellStyle5
		Me.dgvLogoTOF.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvLogoTOF.EnableHeadersVisualStyles = False
		Me.dgvLogoTOF.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvLogoTOF.Location = New System.Drawing.Point(0, 0)
		Me.dgvLogoTOF.Name = "dgvLogoTOF"
		DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Yellow
		DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvLogoTOF.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
		Me.dgvLogoTOF.RowHeadersVisible = False
		Me.dgvLogoTOF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvLogoTOF.Size = New System.Drawing.Size(1258, 264)
		Me.dgvLogoTOF.TabIndex = 1
		Me.dgvLogoTOF.TabStop = False
		'
		'SplitContainerTOF
		'
		Me.SplitContainerTOF.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainerTOF.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainerTOF.IsSplitterFixed = True
		Me.SplitContainerTOF.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainerTOF.Name = "SplitContainerTOF"
		Me.SplitContainerTOF.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainerTOF.Panel1
		'
		Me.SplitContainerTOF.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
		Me.SplitContainerTOF.Panel1.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm1
		Me.SplitContainerTOF.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.lblLongitude)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.lblLatitude)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.TableLayoutPanelNAV)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.tb_Longitude)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.btnAll)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.cmbWorkOrderDate)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.tb_Latitude)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.lblWorkOrder)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.lblFilter)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.txtCriteria)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.cmbFields)
		Me.SplitContainerTOF.Panel1.Controls.Add(Me.lblBy)
		'
		'SplitContainerTOF.Panel2
		'
		Me.SplitContainerTOF.Panel2.Controls.Add(Me.dgvLogoTOF)
		Me.SplitContainerTOF.Size = New System.Drawing.Size(1258, 316)
		Me.SplitContainerTOF.SplitterWidth = 2
		Me.SplitContainerTOF.TabIndex = 2
		'
		'lblLongitude
		'
		Me.lblLongitude.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.lblLongitude.AutoSize = True
		Me.lblLongitude.BackColor = System.Drawing.Color.Transparent
		Me.lblLongitude.Location = New System.Drawing.Point(1068, 29)
		Me.lblLongitude.Name = "lblLongitude"
		Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
		Me.lblLongitude.TabIndex = 29
		Me.lblLongitude.Text = "Longitude"
		'
		'lblLatitude
		'
		Me.lblLatitude.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.lblLatitude.AutoSize = True
		Me.lblLatitude.BackColor = System.Drawing.Color.Transparent
		Me.lblLatitude.Location = New System.Drawing.Point(1077, 7)
		Me.lblLatitude.Name = "lblLatitude"
		Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
		Me.lblLatitude.TabIndex = 28
		Me.lblLatitude.Text = "Latitude"
		'
		'TableLayoutPanelNAV
		'
		Me.TableLayoutPanelNAV.ColumnCount = 6
		Me.TableLayoutPanelNAV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
		Me.TableLayoutPanelNAV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
		Me.TableLayoutPanelNAV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
		Me.TableLayoutPanelNAV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
		Me.TableLayoutPanelNAV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
		Me.TableLayoutPanelNAV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
		Me.TableLayoutPanelNAV.Controls.Add(Me.btnLoadXML, 5, 0)
		Me.TableLayoutPanelNAV.Controls.Add(Me.btn_ShowMap, 4, 0)
		Me.TableLayoutPanelNAV.Controls.Add(Me.btnLast, 3, 0)
		Me.TableLayoutPanelNAV.Controls.Add(Me.btnFirst, 2, 0)
		Me.TableLayoutPanelNAV.Controls.Add(Me.btnNext, 1, 0)
		Me.TableLayoutPanelNAV.Controls.Add(Me.btnPrev, 0, 0)
		Me.TableLayoutPanelNAV.Location = New System.Drawing.Point(567, 13)
		Me.TableLayoutPanelNAV.Margin = New System.Windows.Forms.Padding(1)
		Me.TableLayoutPanelNAV.Name = "TableLayoutPanelNAV"
		Me.TableLayoutPanelNAV.RowCount = 1
		Me.TableLayoutPanelNAV.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanelNAV.Size = New System.Drawing.Size(497, 29)
		Me.TableLayoutPanelNAV.TabIndex = 27
		'
		'btnLoadXML
		'
		Me.btnLoadXML.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnLoadXML.Location = New System.Drawing.Point(413, 1)
		Me.btnLoadXML.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
		Me.btnLoadXML.Name = "btnLoadXML"
		Me.btnLoadXML.Size = New System.Drawing.Size(81, 27)
		Me.btnLoadXML.TabIndex = 16
		Me.btnLoadXML.Text = "Import"
		Me.btnLoadXML.UseVisualStyleBackColor = True
		'
		'btn_ShowMap
		'
		Me.btn_ShowMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btn_ShowMap.Location = New System.Drawing.Point(331, 1)
		Me.btn_ShowMap.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
		Me.btn_ShowMap.Name = "btn_ShowMap"
		Me.btn_ShowMap.Size = New System.Drawing.Size(76, 27)
		Me.btn_ShowMap.TabIndex = 14
		Me.btn_ShowMap.Text = "Show Map"
		Me.btn_ShowMap.UseVisualStyleBackColor = True
		'
		'btnLast
		'
		Me.btnLast.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnLast.Location = New System.Drawing.Point(249, 1)
		Me.btnLast.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
		Me.btnLast.Name = "btnLast"
		Me.btnLast.Size = New System.Drawing.Size(76, 27)
		Me.btnLast.TabIndex = 24
		Me.btnLast.Text = "Last >>"
		Me.btnLast.UseVisualStyleBackColor = True
		'
		'btnFirst
		'
		Me.btnFirst.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnFirst.Location = New System.Drawing.Point(167, 1)
		Me.btnFirst.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
		Me.btnFirst.Name = "btnFirst"
		Me.btnFirst.Size = New System.Drawing.Size(76, 27)
		Me.btnFirst.TabIndex = 23
		Me.btnFirst.Text = "<< First"
		Me.btnFirst.UseVisualStyleBackColor = True
		'
		'btnNext
		'
		Me.btnNext.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnNext.Location = New System.Drawing.Point(85, 1)
		Me.btnNext.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
		Me.btnNext.Name = "btnNext"
		Me.btnNext.Size = New System.Drawing.Size(76, 27)
		Me.btnNext.TabIndex = 22
		Me.btnNext.Text = "Next >"
		Me.btnNext.UseVisualStyleBackColor = True
		'
		'btnPrev
		'
		Me.btnPrev.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnPrev.Location = New System.Drawing.Point(3, 1)
		Me.btnPrev.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
		Me.btnPrev.Name = "btnPrev"
		Me.btnPrev.Size = New System.Drawing.Size(76, 27)
		Me.btnPrev.TabIndex = 21
		Me.btnPrev.Text = "< Previous"
		Me.btnPrev.UseVisualStyleBackColor = True
		'
		'tb_Longitude
		'
		Me.tb_Longitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tb_Longitude.Location = New System.Drawing.Point(1128, 27)
		Me.tb_Longitude.Name = "tb_Longitude"
		Me.tb_Longitude.Size = New System.Drawing.Size(127, 18)
		Me.tb_Longitude.TabIndex = 13
		'
		'btnAll
		'
		Me.btnAll.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnAll.Location = New System.Drawing.Point(174, 14)
		Me.btnAll.Name = "btnAll"
		Me.btnAll.Size = New System.Drawing.Size(65, 23)
		Me.btnAll.TabIndex = 26
		Me.btnAll.Text = "All Orders"
		Me.btnAll.UseVisualStyleBackColor = True
		'
		'cmbWorkOrderDate
		'
		Me.cmbWorkOrderDate.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.cmbWorkOrderDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbWorkOrderDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbWorkOrderDate.DropDownHeight = 300
		Me.cmbWorkOrderDate.FormattingEnabled = True
		Me.cmbWorkOrderDate.IntegralHeight = False
		Me.cmbWorkOrderDate.Location = New System.Drawing.Point(76, 16)
		Me.cmbWorkOrderDate.Name = "cmbWorkOrderDate"
		Me.cmbWorkOrderDate.Size = New System.Drawing.Size(92, 21)
		Me.cmbWorkOrderDate.TabIndex = 25
		'
		'tb_Latitude
		'
		Me.tb_Latitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tb_Latitude.Location = New System.Drawing.Point(1128, 5)
		Me.tb_Latitude.Name = "tb_Latitude"
		Me.tb_Latitude.Size = New System.Drawing.Size(127, 18)
		Me.tb_Latitude.TabIndex = 12
		'
		'lblWorkOrder
		'
		Me.lblWorkOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.lblWorkOrder.AutoSize = True
		Me.lblWorkOrder.BackColor = System.Drawing.Color.Transparent
		Me.lblWorkOrder.Location = New System.Drawing.Point(13, 19)
		Me.lblWorkOrder.Name = "lblWorkOrder"
		Me.lblWorkOrder.Size = New System.Drawing.Size(57, 13)
		Me.lblWorkOrder.TabIndex = 24
		Me.lblWorkOrder.Text = "W/O Date"
		'
		'lblFilter
		'
		Me.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.lblFilter.AutoSize = True
		Me.lblFilter.BackColor = System.Drawing.Color.Transparent
		Me.lblFilter.Location = New System.Drawing.Point(240, 19)
		Me.lblFilter.Name = "lblFilter"
		Me.lblFilter.Size = New System.Drawing.Size(29, 13)
		Me.lblFilter.TabIndex = 21
		Me.lblFilter.Text = "Filter"
		'
		'txtCriteria
		'
		Me.txtCriteria.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.txtCriteria.Location = New System.Drawing.Point(363, 17)
		Me.txtCriteria.Name = "txtCriteria"
		Me.txtCriteria.Size = New System.Drawing.Size(110, 20)
		Me.txtCriteria.TabIndex = 19
		Me.txtCriteria.Text = "Type search text here"
		'
		'cmbFields
		'
		Me.cmbFields.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.cmbFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbFields.DropDownHeight = 300
		Me.cmbFields.FormattingEnabled = True
		Me.cmbFields.IntegralHeight = False
		Me.cmbFields.Items.AddRange(New Object() {"StructureNumber", "OrderedDate", "Width", "Height", "WorkType", "Comments", "CompletionDate", "County", "Crossroad", "City", "Latitude", "Longitude", "Route", "Exit", "Direction", "Service", "sType"})
		Me.cmbFields.Location = New System.Drawing.Point(275, 16)
		Me.cmbFields.Name = "cmbFields"
		Me.cmbFields.Size = New System.Drawing.Size(60, 21)
		Me.cmbFields.TabIndex = 18
		'
		'lblBy
		'
		Me.lblBy.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.lblBy.AutoSize = True
		Me.lblBy.BackColor = System.Drawing.Color.Transparent
		Me.lblBy.Location = New System.Drawing.Point(338, 20)
		Me.lblBy.Name = "lblBy"
		Me.lblBy.Size = New System.Drawing.Size(19, 13)
		Me.lblBy.TabIndex = 22
		Me.lblBy.Text = "By"
		'
		'btnSaveChanges
		'
		Me.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.btnSaveChanges.Location = New System.Drawing.Point(1128, 12)
		Me.btnSaveChanges.Name = "btnSaveChanges"
		Me.btnSaveChanges.Size = New System.Drawing.Size(102, 23)
		Me.btnSaveChanges.TabIndex = 20
		Me.btnSaveChanges.Text = "Save Changes"
		Me.btnSaveChanges.UseVisualStyleBackColor = True
		'
		'SplitContainerMain
		'
		Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainerMain.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainerMain.Name = "SplitContainerMain"
		Me.SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainerMain.Panel1
		'
		Me.SplitContainerMain.Panel1.Controls.Add(Me.SplitContainerTOP)
		'
		'SplitContainerMain.Panel2
		'
		Me.SplitContainerMain.Panel2.Controls.Add(Me.SplitContainerTOF)
		Me.SplitContainerMain.Size = New System.Drawing.Size(1258, 640)
		Me.SplitContainerMain.SplitterDistance = 320
		Me.SplitContainerMain.TabIndex = 16
		'
		'SplitContainerTOP
		'
		Me.SplitContainerTOP.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainerTOP.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainerTOP.IsSplitterFixed = True
		Me.SplitContainerTOP.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainerTOP.Name = "SplitContainerTOP"
		Me.SplitContainerTOP.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainerTOP.Panel1
		'
		Me.SplitContainerTOP.Panel1.Controls.Add(Me.btnSaveChanges)
		Me.SplitContainerTOP.Panel1MinSize = 50
		'
		'SplitContainerTOP.Panel2
		'
		Me.SplitContainerTOP.Panel2.Controls.Add(Me.SplitContainerMID)
		Me.SplitContainerTOP.Size = New System.Drawing.Size(1258, 320)
		Me.SplitContainerTOP.SplitterWidth = 2
		Me.SplitContainerTOP.TabIndex = 17
		'
		'SplitContainerMID
		'
		Me.SplitContainerMID.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainerMID.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainerMID.Name = "SplitContainerMID"
		'
		'SplitContainerMID.Panel2
		'
		Me.SplitContainerMID.Panel2.Controls.Add(Me.lblDetailString)
		Me.SplitContainerMID.Panel2.Controls.Add(Me.grpWorkOrderDetails)
		Me.SplitContainerMID.Panel2.Controls.Add(Me.txtOrderedDate)
		Me.SplitContainerMID.Size = New System.Drawing.Size(1258, 268)
		Me.SplitContainerMID.SplitterDistance = 623
		Me.SplitContainerMID.TabIndex = 0
		'
		'txtsType
		'
		Me.txtsType.Location = New System.Drawing.Point(72, 19)
		Me.txtsType.Name = "txtsType"
		Me.txtsType.Size = New System.Drawing.Size(56, 20)
		Me.txtsType.TabIndex = 16
		Me.txtsType.Text = "sType"
		'
		'txtService
		'
		Me.txtService.Location = New System.Drawing.Point(134, 45)
		Me.txtService.Name = "txtService"
		Me.txtService.Size = New System.Drawing.Size(147, 20)
		Me.txtService.TabIndex = 15
		Me.txtService.Text = "Service"
		'
		'txtDirection
		'
		Me.txtDirection.Location = New System.Drawing.Point(15, 71)
		Me.txtDirection.Name = "txtDirection"
		Me.txtDirection.Size = New System.Drawing.Size(51, 20)
		Me.txtDirection.TabIndex = 14
		Me.txtDirection.Text = "Direction"
		'
		'txtExit
		'
		Me.txtExit.Location = New System.Drawing.Point(134, 71)
		Me.txtExit.Name = "txtExit"
		Me.txtExit.Size = New System.Drawing.Size(41, 20)
		Me.txtExit.TabIndex = 13
		Me.txtExit.Text = "Exit"
		'
		'txtRoute
		'
		Me.txtRoute.Location = New System.Drawing.Point(72, 71)
		Me.txtRoute.Name = "txtRoute"
		Me.txtRoute.Size = New System.Drawing.Size(56, 20)
		Me.txtRoute.TabIndex = 12
		Me.txtRoute.Text = "Route"
		'
		'txtLongitude
		'
		Me.txtLongitude.Location = New System.Drawing.Point(134, 149)
		Me.txtLongitude.Name = "txtLongitude"
		Me.txtLongitude.Size = New System.Drawing.Size(147, 20)
		Me.txtLongitude.TabIndex = 11
		Me.txtLongitude.Text = "Longitude"
		'
		'txtLatitude
		'
		Me.txtLatitude.Location = New System.Drawing.Point(134, 123)
		Me.txtLatitude.Name = "txtLatitude"
		Me.txtLatitude.Size = New System.Drawing.Size(147, 20)
		Me.txtLatitude.TabIndex = 10
		Me.txtLatitude.Text = "Latitude"
		'
		'txtCity
		'
		Me.txtCity.Location = New System.Drawing.Point(15, 123)
		Me.txtCity.Name = "txtCity"
		Me.txtCity.Size = New System.Drawing.Size(113, 20)
		Me.txtCity.TabIndex = 9
		Me.txtCity.Text = "City"
		'
		'txtCrossRoad
		'
		Me.txtCrossRoad.Location = New System.Drawing.Point(15, 97)
		Me.txtCrossRoad.Name = "txtCrossRoad"
		Me.txtCrossRoad.Size = New System.Drawing.Size(266, 20)
		Me.txtCrossRoad.TabIndex = 8
		Me.txtCrossRoad.Text = "CrossRoad"
		'
		'txtCounty
		'
		Me.txtCounty.Location = New System.Drawing.Point(15, 149)
		Me.txtCounty.Name = "txtCounty"
		Me.txtCounty.Size = New System.Drawing.Size(113, 20)
		Me.txtCounty.TabIndex = 7
		Me.txtCounty.Text = "County"
		'
		'txtCompletionDate
		'
		Me.txtCompletionDate.Location = New System.Drawing.Point(181, 71)
		Me.txtCompletionDate.Name = "txtCompletionDate"
		Me.txtCompletionDate.Size = New System.Drawing.Size(100, 20)
		Me.txtCompletionDate.TabIndex = 6
		Me.txtCompletionDate.Text = "CompletionDate"
		'
		'txtComments
		'
		Me.txtComments.Location = New System.Drawing.Point(15, 175)
		Me.txtComments.Multiline = True
		Me.txtComments.Name = "txtComments"
		Me.txtComments.Size = New System.Drawing.Size(266, 60)
		Me.txtComments.TabIndex = 5
		Me.txtComments.Text = "Comments"
		'
		'txtWorkType
		'
		Me.txtWorkType.Location = New System.Drawing.Point(134, 19)
		Me.txtWorkType.Name = "txtWorkType"
		Me.txtWorkType.Size = New System.Drawing.Size(147, 20)
		Me.txtWorkType.TabIndex = 4
		Me.txtWorkType.Text = "Work Type"
		'
		'txtHeight
		'
		Me.txtHeight.Location = New System.Drawing.Point(72, 45)
		Me.txtHeight.Name = "txtHeight"
		Me.txtHeight.Size = New System.Drawing.Size(56, 20)
		Me.txtHeight.TabIndex = 3
		Me.txtHeight.Text = "Height"
		'
		'txtWidth
		'
		Me.txtWidth.Location = New System.Drawing.Point(15, 45)
		Me.txtWidth.Name = "txtWidth"
		Me.txtWidth.Size = New System.Drawing.Size(51, 20)
		Me.txtWidth.TabIndex = 2
		Me.txtWidth.Text = "Width"
		'
		'txtOrderedDate
		'
		Me.txtOrderedDate.Location = New System.Drawing.Point(322, 23)
		Me.txtOrderedDate.Name = "txtOrderedDate"
		Me.txtOrderedDate.Size = New System.Drawing.Size(100, 20)
		Me.txtOrderedDate.TabIndex = 1
		Me.txtOrderedDate.Text = "OrderedDate"
		'
		'txtStructureNumber
		'
		Me.txtStructureNumber.Location = New System.Drawing.Point(15, 19)
		Me.txtStructureNumber.Name = "txtStructureNumber"
		Me.txtStructureNumber.Size = New System.Drawing.Size(51, 20)
		Me.txtStructureNumber.TabIndex = 0
		Me.txtStructureNumber.Text = "Structure Number"
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStatusText})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 618)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(1258, 22)
		Me.StatusStrip1.TabIndex = 17
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'txtStatusText
		'
		Me.txtStatusText.Name = "txtStatusText"
		Me.txtStatusText.Size = New System.Drawing.Size(35, 17)
		Me.txtStatusText.Text = "Done"
		'
		'grpWorkOrderDetails
		'
		Me.grpWorkOrderDetails.Controls.Add(Me.txtStructureNumber)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtsType)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtWidth)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtService)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtHeight)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtDirection)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtWorkType)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtExit)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtComments)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtRoute)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtCompletionDate)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtLongitude)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtCounty)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtLatitude)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtCrossRoad)
		Me.grpWorkOrderDetails.Controls.Add(Me.txtCity)
		Me.grpWorkOrderDetails.Location = New System.Drawing.Point(12, 13)
		Me.grpWorkOrderDetails.Name = "grpWorkOrderDetails"
		Me.grpWorkOrderDetails.Size = New System.Drawing.Size(294, 241)
		Me.grpWorkOrderDetails.TabIndex = 17
		Me.grpWorkOrderDetails.TabStop = False
		Me.grpWorkOrderDetails.Text = "Work Order Details"
		'
		'lblDetailString
		'
		Me.lblDetailString.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.lblDetailString.AutoSize = True
		Me.lblDetailString.BackColor = System.Drawing.Color.Transparent
		Me.lblDetailString.Location = New System.Drawing.Point(319, 91)
		Me.lblDetailString.Name = "lblDetailString"
		Me.lblDetailString.Size = New System.Drawing.Size(45, 13)
		Me.lblDetailString.TabIndex = 30
		Me.lblDetailString.Text = "Latitude"
		'
		'frmLogoTakeOff
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1258, 640)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.SplitContainerMain)
		Me.Name = "frmLogoTakeOff"
		Me.Text = "Logo Take Off"
		CType(Me.dgvLogoTOF, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainerTOF.Panel1.ResumeLayout(False)
		Me.SplitContainerTOF.Panel1.PerformLayout()
		Me.SplitContainerTOF.Panel2.ResumeLayout(False)
		Me.SplitContainerTOF.ResumeLayout(False)
		Me.TableLayoutPanelNAV.ResumeLayout(False)
		Me.SplitContainerMain.Panel1.ResumeLayout(False)
		Me.SplitContainerMain.Panel2.ResumeLayout(False)
		Me.SplitContainerMain.ResumeLayout(False)
		Me.SplitContainerTOP.Panel1.ResumeLayout(False)
		Me.SplitContainerTOP.Panel2.ResumeLayout(False)
		Me.SplitContainerTOP.ResumeLayout(False)
		Me.SplitContainerMID.Panel2.ResumeLayout(False)
		Me.SplitContainerMID.Panel2.PerformLayout()
		Me.SplitContainerMID.ResumeLayout(False)
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.grpWorkOrderDetails.ResumeLayout(False)
		Me.grpWorkOrderDetails.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents dgvLogoTOF As System.Windows.Forms.DataGridView
	Friend WithEvents SplitContainerTOF As System.Windows.Forms.SplitContainer
	Friend WithEvents btn_ShowMap As System.Windows.Forms.Button
	Friend WithEvents tb_Longitude As System.Windows.Forms.TextBox
	Friend WithEvents tb_Latitude As System.Windows.Forms.TextBox
	Friend WithEvents lblFilter As System.Windows.Forms.Label
	Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
	Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
	Friend WithEvents cmbFields As System.Windows.Forms.ComboBox
	Friend WithEvents lblBy As System.Windows.Forms.Label
	Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
	Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
	Friend WithEvents txtStatusText As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents lblWorkOrder As System.Windows.Forms.Label
	Friend WithEvents cmbWorkOrderDate As System.Windows.Forms.ComboBox
	Friend WithEvents btnAll As System.Windows.Forms.Button
	Friend WithEvents btnLoadXML As System.Windows.Forms.Button
	Friend WithEvents SplitContainerTOP As System.Windows.Forms.SplitContainer
	Friend WithEvents SplitContainerMID As System.Windows.Forms.SplitContainer
	Friend WithEvents TableLayoutPanelNAV As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents btnLast As System.Windows.Forms.Button
	Friend WithEvents btnFirst As System.Windows.Forms.Button
	Friend WithEvents btnNext As System.Windows.Forms.Button
	Friend WithEvents btnPrev As System.Windows.Forms.Button
	Friend WithEvents lblLongitude As System.Windows.Forms.Label
	Friend WithEvents lblLatitude As System.Windows.Forms.Label
	Friend WithEvents txtWidth As System.Windows.Forms.TextBox
	Friend WithEvents txtOrderedDate As System.Windows.Forms.TextBox
	Friend WithEvents txtStructureNumber As System.Windows.Forms.TextBox
	Friend WithEvents txtCounty As System.Windows.Forms.TextBox
	Friend WithEvents txtCompletionDate As System.Windows.Forms.TextBox
	Friend WithEvents txtComments As System.Windows.Forms.TextBox
	Friend WithEvents txtWorkType As System.Windows.Forms.TextBox
	Friend WithEvents txtHeight As System.Windows.Forms.TextBox
	Friend WithEvents txtsType As System.Windows.Forms.TextBox
	Friend WithEvents txtService As System.Windows.Forms.TextBox
	Friend WithEvents txtDirection As System.Windows.Forms.TextBox
	Friend WithEvents txtExit As System.Windows.Forms.TextBox
	Friend WithEvents txtRoute As System.Windows.Forms.TextBox
	Friend WithEvents txtLongitude As System.Windows.Forms.TextBox
	Friend WithEvents txtLatitude As System.Windows.Forms.TextBox
	Friend WithEvents txtCity As System.Windows.Forms.TextBox
	Friend WithEvents txtCrossRoad As System.Windows.Forms.TextBox
	Friend WithEvents grpWorkOrderDetails As System.Windows.Forms.GroupBox
	Friend WithEvents lblDetailString As System.Windows.Forms.Label
End Class
