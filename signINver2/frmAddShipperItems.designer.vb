<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddShipperItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddShipperItems))
        Me.dgvShipperItems = New System.Windows.Forms.DataGridView
        Me.btnAddItem = New System.Windows.Forms.Button
        Me.lblGroups = New System.Windows.Forms.Label
        Me.txtItemQty = New System.Windows.Forms.TextBox
        Me.cmbGroupTypes = New System.Windows.Forms.ComboBox
        Me.grpItemDetails = New System.Windows.Forms.GroupBox
        Me.ckbShowAllItems = New System.Windows.Forms.CheckBox
        Me.dgvItems = New System.Windows.Forms.DataGridView
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnAddItems = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.lblPayItem = New System.Windows.Forms.Label
        Me.lblPO = New System.Windows.Forms.Label
        Me.txtUnitPrice = New System.Windows.Forms.TextBox
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.txtItemNotes = New System.Windows.Forms.TextBox
        Me.lblItemNotes = New System.Windows.Forms.Label
        Me.lblUnitPrice = New System.Windows.Forms.Label
        Me.txtUnitQty = New System.Windows.Forms.TextBox
        Me.lblUnitQty = New System.Windows.Forms.Label
        Me.lblItemQty = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.lblMhsJob = New System.Windows.Forms.Label
        Me.lblVia = New System.Windows.Forms.Label
        Me.txtVia = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtViewGroup = New System.Windows.Forms.TextBox
        Me.txtViewItemQty = New System.Windows.Forms.TextBox
        Me.txtViewUnitQty = New System.Windows.Forms.TextBox
        Me.txtViewItem = New System.Windows.Forms.TextBox
        Me.txtViewItemNotes = New System.Windows.Forms.TextBox
        Me.txtViewUnitPrice = New System.Windows.Forms.TextBox
        Me.lblViewGroup = New System.Windows.Forms.Label
        Me.lblViewItemQty = New System.Windows.Forms.Label
        Me.lblViewUnitQty = New System.Windows.Forms.Label
        Me.lblViewItem = New System.Windows.Forms.Label
        Me.lblViewItemNotes = New System.Windows.Forms.Label
        Me.lblViewUnitPrice = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnHide = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpViewer = New System.Windows.Forms.GroupBox
        Me.lblShipperID = New System.Windows.Forms.Label
        Me.lblShipperNum = New System.Windows.Forms.Label
        Me.btnSaveChanges = New System.Windows.Forms.Button
        CType(Me.dgvShipperItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItemDetails.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpViewer.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvShipperItems
        '
        Me.dgvShipperItems.AllowUserToOrderColumns = True
        Me.dgvShipperItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvShipperItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipperItems.Location = New System.Drawing.Point(12, 315)
        Me.dgvShipperItems.Name = "dgvShipperItems"
        Me.dgvShipperItems.RowHeadersWidth = 20
        Me.dgvShipperItems.Size = New System.Drawing.Size(456, 159)
        Me.dgvShipperItems.TabIndex = 0
        '
        'btnAddItem
        '
        Me.btnAddItem.Location = New System.Drawing.Point(273, 226)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(163, 23)
        Me.btnAddItem.TabIndex = 6
        Me.btnAddItem.Text = "Add Item To Shipper"
        Me.ToolTip1.SetToolTip(Me.btnAddItem, "Add to Shipper")
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Location = New System.Drawing.Point(6, 28)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(36, 13)
        Me.lblGroups.TabIndex = 2
        Me.lblGroups.Text = "Group"
        '
        'txtItemQty
        '
        Me.txtItemQty.Location = New System.Drawing.Point(252, 25)
        Me.txtItemQty.Name = "txtItemQty"
        Me.txtItemQty.Size = New System.Drawing.Size(40, 20)
        Me.txtItemQty.TabIndex = 1
        '
        'cmbGroupTypes
        '
        Me.cmbGroupTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbGroupTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGroupTypes.DropDownHeight = 250
        Me.cmbGroupTypes.FormattingEnabled = True
        Me.cmbGroupTypes.IntegralHeight = False
        Me.cmbGroupTypes.Location = New System.Drawing.Point(48, 25)
        Me.cmbGroupTypes.Name = "cmbGroupTypes"
        Me.cmbGroupTypes.Size = New System.Drawing.Size(136, 21)
        Me.cmbGroupTypes.TabIndex = 0
        '
        'grpItemDetails
        '
        Me.grpItemDetails.BackColor = System.Drawing.Color.Transparent
        Me.grpItemDetails.Controls.Add(Me.ckbShowAllItems)
        Me.grpItemDetails.Controls.Add(Me.dgvItems)
        Me.grpItemDetails.Controls.Add(Me.btnRefresh)
        Me.grpItemDetails.Controls.Add(Me.btnAddItems)
        Me.grpItemDetails.Controls.Add(Me.btnSave)
        Me.grpItemDetails.Controls.Add(Me.lblJobDesc)
        Me.grpItemDetails.Controls.Add(Me.lblPayItem)
        Me.grpItemDetails.Controls.Add(Me.lblPO)
        Me.grpItemDetails.Controls.Add(Me.btnAddItem)
        Me.grpItemDetails.Controls.Add(Me.txtUnitPrice)
        Me.grpItemDetails.Controls.Add(Me.txtPO)
        Me.grpItemDetails.Controls.Add(Me.txtItemNotes)
        Me.grpItemDetails.Controls.Add(Me.lblItemNotes)
        Me.grpItemDetails.Controls.Add(Me.lblUnitPrice)
        Me.grpItemDetails.Controls.Add(Me.txtUnitQty)
        Me.grpItemDetails.Controls.Add(Me.lblUnitQty)
        Me.grpItemDetails.Controls.Add(Me.cmbGroupTypes)
        Me.grpItemDetails.Controls.Add(Me.lblGroups)
        Me.grpItemDetails.Controls.Add(Me.lblItemQty)
        Me.grpItemDetails.Controls.Add(Me.txtItemQty)
        Me.grpItemDetails.Location = New System.Drawing.Point(12, 48)
        Me.grpItemDetails.Name = "grpItemDetails"
        Me.grpItemDetails.Size = New System.Drawing.Size(456, 261)
        Me.grpItemDetails.TabIndex = 5
        Me.grpItemDetails.TabStop = False
        Me.grpItemDetails.Text = "Shipper Item Details"
        '
        'ckbShowAllItems
        '
        Me.ckbShowAllItems.AutoSize = True
        Me.ckbShowAllItems.Location = New System.Drawing.Point(369, 27)
        Me.ckbShowAllItems.Name = "ckbShowAllItems"
        Me.ckbShowAllItems.Size = New System.Drawing.Size(67, 17)
        Me.ckbShowAllItems.TabIndex = 29
        Me.ckbShowAllItems.Text = "Show All"
        Me.ckbShowAllItems.UseVisualStyleBackColor = True
        '
        'dgvItems
        '
        Me.dgvItems.AllowUserToAddRows = False
        Me.dgvItems.AllowUserToDeleteRows = False
        Me.dgvItems.AllowUserToResizeRows = False
        Me.dgvItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.ColumnHeadersVisible = False
        Me.dgvItems.Location = New System.Drawing.Point(203, 49)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.RowHeadersVisible = False
        Me.dgvItems.RowHeadersWidth = 4
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItems.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItems.RowTemplate.Height = 18
        Me.dgvItems.Size = New System.Drawing.Size(233, 171)
        Me.dgvItems.TabIndex = 28
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(20, 226)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 23)
        Me.btnRefresh.TabIndex = 27
        Me.btnRefresh.Text = "Refresh"
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "Click to refresh items listing after adding new item.")
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnAddItems
        '
        Me.btnAddItems.Location = New System.Drawing.Point(104, 226)
        Me.btnAddItems.Name = "btnAddItems"
        Me.btnAddItems.Size = New System.Drawing.Size(80, 23)
        Me.btnAddItems.TabIndex = 25
        Me.btnAddItems.Text = "New Item"
        Me.ToolTip1.SetToolTip(Me.btnAddItems, "Click to add new item")
        Me.btnAddItems.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(119, 50)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(30, 23)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "+"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblJobDesc
        '
        Me.lblJobDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJobDesc.Location = New System.Drawing.Point(517, 16)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(58, 13)
        Me.lblJobDesc.TabIndex = 23
        '
        'lblPayItem
        '
        Me.lblPayItem.AutoSize = True
        Me.lblPayItem.Location = New System.Drawing.Point(116, 139)
        Me.lblPayItem.Name = "lblPayItem"
        Me.lblPayItem.Size = New System.Drawing.Size(49, 13)
        Me.lblPayItem.TabIndex = 14
        Me.lblPayItem.Text = "8100202"
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.Location = New System.Drawing.Point(20, 55)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(22, 13)
        Me.lblPO.TabIndex = 22
        Me.lblPO.Text = "PO"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Location = New System.Drawing.Point(119, 116)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(65, 20)
        Me.txtUnitPrice.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtUnitPrice, "Click to change")
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(48, 52)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.ReadOnly = True
        Me.txtPO.Size = New System.Drawing.Size(65, 20)
        Me.txtPO.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.txtPO, "Click to change")
        '
        'txtItemNotes
        '
        Me.txtItemNotes.Location = New System.Drawing.Point(9, 163)
        Me.txtItemNotes.Multiline = True
        Me.txtItemNotes.Name = "txtItemNotes"
        Me.txtItemNotes.Size = New System.Drawing.Size(188, 57)
        Me.txtItemNotes.TabIndex = 4
        '
        'lblItemNotes
        '
        Me.lblItemNotes.AutoSize = True
        Me.lblItemNotes.Location = New System.Drawing.Point(6, 147)
        Me.lblItemNotes.Name = "lblItemNotes"
        Me.lblItemNotes.Size = New System.Drawing.Size(58, 13)
        Me.lblItemNotes.TabIndex = 13
        Me.lblItemNotes.Text = "Item Notes"
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.AutoSize = True
        Me.lblUnitPrice.Location = New System.Drawing.Point(59, 119)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(62, 13)
        Me.lblUnitPrice.TabIndex = 11
        Me.lblUnitPrice.Text = "Unit Price $"
        '
        'txtUnitQty
        '
        Me.txtUnitQty.Location = New System.Drawing.Point(119, 90)
        Me.txtUnitQty.Name = "txtUnitQty"
        Me.txtUnitQty.Size = New System.Drawing.Size(65, 20)
        Me.txtUnitQty.TabIndex = 3
        '
        'lblUnitQty
        '
        Me.lblUnitQty.AutoSize = True
        Me.lblUnitQty.Location = New System.Drawing.Point(67, 93)
        Me.lblUnitQty.Name = "lblUnitQty"
        Me.lblUnitQty.Size = New System.Drawing.Size(45, 13)
        Me.lblUnitQty.TabIndex = 9
        Me.lblUnitQty.Text = "Unit Qty"
        '
        'lblItemQty
        '
        Me.lblItemQty.AutoSize = True
        Me.lblItemQty.Location = New System.Drawing.Point(200, 28)
        Me.lblItemQty.Name = "lblItemQty"
        Me.lblItemQty.Size = New System.Drawing.Size(46, 13)
        Me.lblItemQty.TabIndex = 5
        Me.lblItemQty.Text = "Item Qty"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(485, 527)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 26
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'lblMhsJob
        '
        Me.lblMhsJob.AutoSize = True
        Me.lblMhsJob.Location = New System.Drawing.Point(608, 527)
        Me.lblMhsJob.Name = "lblMhsJob"
        Me.lblMhsJob.Size = New System.Drawing.Size(58, 13)
        Me.lblMhsJob.TabIndex = 25
        Me.lblMhsJob.Text = "MHS Job#"
        '
        'lblVia
        '
        Me.lblVia.BackColor = System.Drawing.Color.Transparent
        Me.lblVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVia.Location = New System.Drawing.Point(12, 21)
        Me.lblVia.Name = "lblVia"
        Me.lblVia.Size = New System.Drawing.Size(283, 13)
        Me.lblVia.TabIndex = 15
        Me.lblVia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVia
        '
        Me.txtVia.Location = New System.Drawing.Point(280, 267)
        Me.txtVia.Name = "txtVia"
        Me.txtVia.Size = New System.Drawing.Size(93, 20)
        Me.txtVia.TabIndex = 4
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 506)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(479, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'txtViewGroup
        '
        Me.txtViewGroup.Location = New System.Drawing.Point(67, 27)
        Me.txtViewGroup.Name = "txtViewGroup"
        Me.txtViewGroup.ReadOnly = True
        Me.txtViewGroup.Size = New System.Drawing.Size(175, 20)
        Me.txtViewGroup.TabIndex = 7
        '
        'txtViewItemQty
        '
        Me.txtViewItemQty.Location = New System.Drawing.Point(67, 72)
        Me.txtViewItemQty.Name = "txtViewItemQty"
        Me.txtViewItemQty.ReadOnly = True
        Me.txtViewItemQty.Size = New System.Drawing.Size(63, 20)
        Me.txtViewItemQty.TabIndex = 8
        '
        'txtViewUnitQty
        '
        Me.txtViewUnitQty.Location = New System.Drawing.Point(67, 141)
        Me.txtViewUnitQty.Name = "txtViewUnitQty"
        Me.txtViewUnitQty.ReadOnly = True
        Me.txtViewUnitQty.Size = New System.Drawing.Size(63, 20)
        Me.txtViewUnitQty.TabIndex = 10
        '
        'txtViewItem
        '
        Me.txtViewItem.Location = New System.Drawing.Point(67, 98)
        Me.txtViewItem.Name = "txtViewItem"
        Me.txtViewItem.ReadOnly = True
        Me.txtViewItem.Size = New System.Drawing.Size(175, 20)
        Me.txtViewItem.TabIndex = 9
        '
        'txtViewItemNotes
        '
        Me.txtViewItemNotes.Location = New System.Drawing.Point(67, 213)
        Me.txtViewItemNotes.Multiline = True
        Me.txtViewItemNotes.Name = "txtViewItemNotes"
        Me.txtViewItemNotes.ReadOnly = True
        Me.txtViewItemNotes.Size = New System.Drawing.Size(175, 54)
        Me.txtViewItemNotes.TabIndex = 12
        '
        'txtViewUnitPrice
        '
        Me.txtViewUnitPrice.Location = New System.Drawing.Point(67, 167)
        Me.txtViewUnitPrice.Name = "txtViewUnitPrice"
        Me.txtViewUnitPrice.ReadOnly = True
        Me.txtViewUnitPrice.Size = New System.Drawing.Size(63, 20)
        Me.txtViewUnitPrice.TabIndex = 11
        '
        'lblViewGroup
        '
        Me.lblViewGroup.AutoSize = True
        Me.lblViewGroup.Location = New System.Drawing.Point(25, 30)
        Me.lblViewGroup.Name = "lblViewGroup"
        Me.lblViewGroup.Size = New System.Drawing.Size(36, 13)
        Me.lblViewGroup.TabIndex = 15
        Me.lblViewGroup.Text = "Group"
        '
        'lblViewItemQty
        '
        Me.lblViewItemQty.AutoSize = True
        Me.lblViewItemQty.Location = New System.Drawing.Point(15, 75)
        Me.lblViewItemQty.Name = "lblViewItemQty"
        Me.lblViewItemQty.Size = New System.Drawing.Size(46, 13)
        Me.lblViewItemQty.TabIndex = 16
        Me.lblViewItemQty.Text = "Item Qty"
        '
        'lblViewUnitQty
        '
        Me.lblViewUnitQty.AutoSize = True
        Me.lblViewUnitQty.Location = New System.Drawing.Point(16, 144)
        Me.lblViewUnitQty.Name = "lblViewUnitQty"
        Me.lblViewUnitQty.Size = New System.Drawing.Size(45, 13)
        Me.lblViewUnitQty.TabIndex = 18
        Me.lblViewUnitQty.Text = "Unit Qty"
        '
        'lblViewItem
        '
        Me.lblViewItem.AutoSize = True
        Me.lblViewItem.Location = New System.Drawing.Point(34, 101)
        Me.lblViewItem.Name = "lblViewItem"
        Me.lblViewItem.Size = New System.Drawing.Size(27, 13)
        Me.lblViewItem.TabIndex = 17
        Me.lblViewItem.Text = "Item"
        '
        'lblViewItemNotes
        '
        Me.lblViewItemNotes.AutoSize = True
        Me.lblViewItemNotes.Location = New System.Drawing.Point(3, 216)
        Me.lblViewItemNotes.Name = "lblViewItemNotes"
        Me.lblViewItemNotes.Size = New System.Drawing.Size(58, 13)
        Me.lblViewItemNotes.TabIndex = 20
        Me.lblViewItemNotes.Text = "Item Notes"
        '
        'lblViewUnitPrice
        '
        Me.lblViewUnitPrice.AutoSize = True
        Me.lblViewUnitPrice.Location = New System.Drawing.Point(5, 170)
        Me.lblViewUnitPrice.Name = "lblViewUnitPrice"
        Me.lblViewUnitPrice.Size = New System.Drawing.Size(62, 13)
        Me.lblViewUnitPrice.TabIndex = 19
        Me.lblViewUnitPrice.Text = "Unit Price $"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnHide)
        Me.Panel1.Controls.Add(Me.txtViewGroup)
        Me.Panel1.Controls.Add(Me.lblViewItemNotes)
        Me.Panel1.Controls.Add(Me.txtViewItemQty)
        Me.Panel1.Controls.Add(Me.lblViewUnitPrice)
        Me.Panel1.Controls.Add(Me.txtViewItem)
        Me.Panel1.Controls.Add(Me.lblViewUnitQty)
        Me.Panel1.Controls.Add(Me.txtViewUnitQty)
        Me.Panel1.Controls.Add(Me.lblViewItem)
        Me.Panel1.Controls.Add(Me.txtViewUnitPrice)
        Me.Panel1.Controls.Add(Me.lblViewItemQty)
        Me.Panel1.Controls.Add(Me.txtViewItemNotes)
        Me.Panel1.Controls.Add(Me.lblViewGroup)
        Me.Panel1.Location = New System.Drawing.Point(8, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 347)
        Me.Panel1.TabIndex = 21
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(167, 321)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(75, 23)
        Me.btnHide.TabIndex = 22
        Me.btnHide.Text = "Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'grpViewer
        '
        Me.grpViewer.BackColor = System.Drawing.Color.Transparent
        Me.grpViewer.Controls.Add(Me.Panel1)
        Me.grpViewer.Controls.Add(Me.txtVia)
        Me.grpViewer.Location = New System.Drawing.Point(492, 48)
        Me.grpViewer.Name = "grpViewer"
        Me.grpViewer.Size = New System.Drawing.Size(264, 449)
        Me.grpViewer.TabIndex = 22
        Me.grpViewer.TabStop = False
        Me.grpViewer.Text = "Shipper Item"
        '
        'lblShipperID
        '
        Me.lblShipperID.AutoSize = True
        Me.lblShipperID.BackColor = System.Drawing.Color.Transparent
        Me.lblShipperID.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipperID.ForeColor = System.Drawing.Color.Navy
        Me.lblShipperID.Location = New System.Drawing.Point(380, 9)
        Me.lblShipperID.Name = "lblShipperID"
        Me.lblShipperID.Size = New System.Drawing.Size(87, 36)
        Me.lblShipperID.TabIndex = 23
        Me.lblShipperID.Text = "5000"
        '
        'lblShipperNum
        '
        Me.lblShipperNum.AutoSize = True
        Me.lblShipperNum.BackColor = System.Drawing.Color.Transparent
        Me.lblShipperNum.Location = New System.Drawing.Point(321, 21)
        Me.lblShipperNum.Name = "lblShipperNum"
        Me.lblShipperNum.Size = New System.Drawing.Size(53, 13)
        Me.lblShipperNum.TabIndex = 24
        Me.lblShipperNum.Text = "Shipper #"
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Location = New System.Drawing.Point(393, 480)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveChanges.TabIndex = 27
        Me.btnSaveChanges.Text = "Save Changes"
        Me.btnSaveChanges.UseVisualStyleBackColor = True
        '
        'frmAddShipperItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(479, 528)
        Me.Controls.Add(Me.btnSaveChanges)
        Me.Controls.Add(Me.lblShipperID)
        Me.Controls.Add(Me.lblShipperNum)
        Me.Controls.Add(Me.grpViewer)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.lblMhsJob)
        Me.Controls.Add(Me.grpItemDetails)
        Me.Controls.Add(Me.dgvShipperItems)
        Me.Controls.Add(Me.lblVia)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddShipperItems"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipper - Add Items"
        CType(Me.dgvShipperItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItemDetails.ResumeLayout(False)
        Me.grpItemDetails.PerformLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpViewer.ResumeLayout(False)
        Me.grpViewer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvShipperItems As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddItem As System.Windows.Forms.Button
    Friend WithEvents lblGroups As System.Windows.Forms.Label
    Friend WithEvents txtItemQty As System.Windows.Forms.TextBox
    Friend WithEvents cmbGroupTypes As System.Windows.Forms.ComboBox
    Friend WithEvents grpItemDetails As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblItemNotes As System.Windows.Forms.Label
    Friend WithEvents txtItemNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitQty As System.Windows.Forms.Label
    Friend WithEvents txtUnitQty As System.Windows.Forms.TextBox
    Friend WithEvents lblItemQty As System.Windows.Forms.Label
    Friend WithEvents lblPayItem As System.Windows.Forms.Label
    Friend WithEvents txtViewGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtViewItemQty As System.Windows.Forms.TextBox
    Friend WithEvents txtViewUnitQty As System.Windows.Forms.TextBox
    Friend WithEvents txtViewItem As System.Windows.Forms.TextBox
    Friend WithEvents txtViewItemNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtViewUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblViewGroup As System.Windows.Forms.Label
    Friend WithEvents lblViewItemQty As System.Windows.Forms.Label
    Friend WithEvents lblViewUnitQty As System.Windows.Forms.Label
    Friend WithEvents lblViewItem As System.Windows.Forms.Label
    Friend WithEvents lblViewItemNotes As System.Windows.Forms.Label
    Friend WithEvents lblViewUnitPrice As System.Windows.Forms.Label
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents lblVia As System.Windows.Forms.Label
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
    Friend WithEvents btnHide As System.Windows.Forms.Button
    Friend WithEvents grpViewer As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblMhsJob As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblShipperID As System.Windows.Forms.Label
    Friend WithEvents lblShipperNum As System.Windows.Forms.Label
    Friend WithEvents btnAddItems As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents ckbShowAllItems As System.Windows.Forms.CheckBox
    Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
End Class
