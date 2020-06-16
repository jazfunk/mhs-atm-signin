<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mhsJobList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mhsJobList))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnMoveLast = New System.Windows.Forms.Button
        Me.btnMoveNext = New System.Windows.Forms.Button
        Me.btnMovePrevious = New System.Windows.Forms.Button
        Me.btnMoveFirst = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnPerformSearch = New System.Windows.Forms.Button
        Me.btnPerformSort = New System.Windows.Forms.Button
        Me.txtRecordPosition = New System.Windows.Forms.TextBox
        Me.txtSearchCriteria = New System.Windows.Forms.TextBox
        Me.cmbField = New System.Windows.Forms.ComboBox
        Me.lblSearch = New System.Windows.Forms.Label
        Me.lblField = New System.Windows.Forms.Label
        Me.lblCustFull = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDateEntered = New System.Windows.Forms.Label
        Me.ckbActive = New System.Windows.Forms.CheckBox
        Me.btnViewAll = New System.Windows.Forms.Button
        Me.btnATMInfo = New System.Windows.Forms.Button
        Me.lblEntryDate = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCust = New System.Windows.Forms.Label
        Me.lblStateJobNum = New System.Windows.Forms.Label
        Me.lblProjectNum = New System.Windows.Forms.Label
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.lblCompDate = New System.Windows.Forms.Label
        Me.lblmhsJobNum = New System.Windows.Forms.Label
        Me.txtCompletionDate = New System.Windows.Forms.TextBox
        Me.grpTypes = New System.Windows.Forms.GroupBox
        Me.ckbTypeIV = New System.Windows.Forms.CheckBox
        Me.chkTypeII = New System.Windows.Forms.CheckBox
        Me.chkTypeIII = New System.Windows.Forms.CheckBox
        Me.chkTypeI = New System.Windows.Forms.CheckBox
        Me.txtStateNum = New System.Windows.Forms.TextBox
        Me.lblCustPO = New System.Windows.Forms.Label
        Me.lblCustJN = New System.Windows.Forms.Label
        Me.lblContractor = New System.Windows.Forms.Label
        Me.cmbATMJobNum = New System.Windows.Forms.ComboBox
        Me.cmbContractor = New System.Windows.Forms.ComboBox
        Me.txtmhsJobNum = New System.Windows.Forms.TextBox
        Me.txtProjectNum = New System.Windows.Forms.TextBox
        Me.txtJobDesc = New System.Windows.Forms.TextBox
        Me.txtCustPO = New System.Windows.Forms.TextBox
        Me.txtCustJobNum = New System.Windows.Forms.TextBox
        Me.txt = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 415)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(524, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel2.Text = "Ready"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnMoveLast)
        Me.GroupBox2.Controls.Add(Me.btnMoveNext)
        Me.GroupBox2.Controls.Add(Me.btnMovePrevious)
        Me.GroupBox2.Controls.Add(Me.btnMoveFirst)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Controls.Add(Me.btnUpdate)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.btnNew)
        Me.GroupBox2.Controls.Add(Me.btnPerformSearch)
        Me.GroupBox2.Controls.Add(Me.btnPerformSort)
        Me.GroupBox2.Controls.Add(Me.txtRecordPosition)
        Me.GroupBox2.Controls.Add(Me.txtSearchCriteria)
        Me.GroupBox2.Controls.Add(Me.cmbField)
        Me.GroupBox2.Controls.Add(Me.lblSearch)
        Me.GroupBox2.Controls.Add(Me.lblField)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 242)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(511, 170)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Navigation"
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Location = New System.Drawing.Point(321, 121)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(29, 24)
        Me.btnMoveLast.TabIndex = 11
        Me.btnMoveLast.Text = ">|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Location = New System.Drawing.Point(289, 121)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(29, 24)
        Me.btnMoveNext.TabIndex = 10
        Me.btnMoveNext.Text = ">"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Location = New System.Drawing.Point(169, 121)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(29, 24)
        Me.btnMovePrevious.TabIndex = 9
        Me.btnMovePrevious.Text = "<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Location = New System.Drawing.Point(137, 121)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(29, 24)
        Me.btnMoveFirst.TabIndex = 8
        Me.btnMoveFirst.Text = "|<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(329, 91)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(249, 91)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(72, 24)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(169, 91)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(72, 24)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(89, 91)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(72, 24)
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnPerformSearch
        '
        Me.btnPerformSearch.Location = New System.Drawing.Point(353, 51)
        Me.btnPerformSearch.Name = "btnPerformSearch"
        Me.btnPerformSearch.Size = New System.Drawing.Size(96, 24)
        Me.btnPerformSearch.TabIndex = 3
        Me.btnPerformSearch.Text = "Perform Search"
        Me.btnPerformSearch.UseVisualStyleBackColor = True
        '
        'btnPerformSort
        '
        Me.btnPerformSort.Location = New System.Drawing.Point(353, 19)
        Me.btnPerformSort.Name = "btnPerformSort"
        Me.btnPerformSort.Size = New System.Drawing.Size(96, 24)
        Me.btnPerformSort.TabIndex = 2
        Me.btnPerformSort.Text = "Perform Sort"
        Me.btnPerformSort.UseVisualStyleBackColor = True
        '
        'txtRecordPosition
        '
        Me.txtRecordPosition.Location = New System.Drawing.Point(201, 123)
        Me.txtRecordPosition.Name = "txtRecordPosition"
        Me.txtRecordPosition.Size = New System.Drawing.Size(85, 20)
        Me.txtRecordPosition.TabIndex = 4
        Me.txtRecordPosition.TabStop = False
        Me.txtRecordPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Location = New System.Drawing.Point(137, 48)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(200, 20)
        Me.txtSearchCriteria.TabIndex = 1
        '
        'cmbField
        '
        Me.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbField.FormattingEnabled = True
        Me.cmbField.Location = New System.Drawing.Point(137, 24)
        Me.cmbField.Name = "cmbField"
        Me.cmbField.Size = New System.Drawing.Size(88, 21)
        Me.cmbField.TabIndex = 0
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(57, 51)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(79, 13)
        Me.lblSearch.TabIndex = 1
        Me.lblSearch.Text = "Search Criteria:"
        '
        'lblField
        '
        Me.lblField.AutoSize = True
        Me.lblField.Location = New System.Drawing.Point(57, 26)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(32, 13)
        Me.lblField.TabIndex = 0
        Me.lblField.Text = "Field:"
        '
        'lblCustFull
        '
        Me.lblCustFull.AutoSize = True
        Me.lblCustFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustFull.ForeColor = System.Drawing.Color.Blue
        Me.lblCustFull.Location = New System.Drawing.Point(43, 122)
        Me.lblCustFull.Name = "lblCustFull"
        Me.lblCustFull.Size = New System.Drawing.Size(0, 15)
        Me.lblCustFull.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblDateEntered)
        Me.GroupBox1.Controls.Add(Me.ckbActive)
        Me.GroupBox1.Controls.Add(Me.lblCustFull)
        Me.GroupBox1.Controls.Add(Me.btnViewAll)
        Me.GroupBox1.Controls.Add(Me.btnATMInfo)
        Me.GroupBox1.Controls.Add(Me.lblEntryDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblCustomer)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblCust)
        Me.GroupBox1.Controls.Add(Me.lblStateJobNum)
        Me.GroupBox1.Controls.Add(Me.lblProjectNum)
        Me.GroupBox1.Controls.Add(Me.lblJobDesc)
        Me.GroupBox1.Controls.Add(Me.lblCompDate)
        Me.GroupBox1.Controls.Add(Me.lblmhsJobNum)
        Me.GroupBox1.Controls.Add(Me.txtCompletionDate)
        Me.GroupBox1.Controls.Add(Me.grpTypes)
        Me.GroupBox1.Controls.Add(Me.txtStateNum)
        Me.GroupBox1.Controls.Add(Me.lblCustPO)
        Me.GroupBox1.Controls.Add(Me.lblCustJN)
        Me.GroupBox1.Controls.Add(Me.lblContractor)
        Me.GroupBox1.Controls.Add(Me.cmbATMJobNum)
        Me.GroupBox1.Controls.Add(Me.cmbContractor)
        Me.GroupBox1.Controls.Add(Me.txtmhsJobNum)
        Me.GroupBox1.Controls.Add(Me.txtProjectNum)
        Me.GroupBox1.Controls.Add(Me.txtJobDesc)
        Me.GroupBox1.Controls.Add(Me.txtCustPO)
        Me.GroupBox1.Controls.Add(Me.txtCustJobNum)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(511, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Job Details"
        '
        'lblDateEntered
        '
        Me.lblDateEntered.AutoSize = True
        Me.lblDateEntered.BackColor = System.Drawing.Color.Transparent
        Me.lblDateEntered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateEntered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDateEntered.Location = New System.Drawing.Point(173, 206)
        Me.lblDateEntered.Name = "lblDateEntered"
        Me.lblDateEntered.Size = New System.Drawing.Size(71, 13)
        Me.lblDateEntered.TabIndex = 35
        Me.lblDateEntered.Text = "Entry Date:"
        '
        'ckbActive
        '
        Me.ckbActive.AutoSize = True
        Me.ckbActive.Location = New System.Drawing.Point(105, 41)
        Me.ckbActive.Name = "ckbActive"
        Me.ckbActive.Size = New System.Drawing.Size(56, 17)
        Me.ckbActive.TabIndex = 1
        Me.ckbActive.Text = "Active"
        Me.ckbActive.UseVisualStyleBackColor = True
        '
        'btnViewAll
        '
        Me.btnViewAll.Location = New System.Drawing.Point(364, 157)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(99, 23)
        Me.btnViewAll.TabIndex = 34
        Me.btnViewAll.Text = "View All Jobs"
        Me.ToolTip1.SetToolTip(Me.btnViewAll, "View READ-ONLY job listing")
        Me.btnViewAll.UseVisualStyleBackColor = True
        '
        'btnATMInfo
        '
        Me.btnATMInfo.Location = New System.Drawing.Point(229, 92)
        Me.btnATMInfo.Name = "btnATMInfo"
        Me.btnATMInfo.Size = New System.Drawing.Size(28, 23)
        Me.btnATMInfo.TabIndex = 4
        Me.btnATMInfo.Text = ">"
        Me.ToolTip1.SetToolTip(Me.btnATMInfo, "Click to migrate ATM job info")
        Me.btnATMInfo.UseVisualStyleBackColor = True
        '
        'lblEntryDate
        '
        Me.lblEntryDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEntryDate.Location = New System.Drawing.Point(250, 206)
        Me.lblEntryDate.Name = "lblEntryDate"
        Me.lblEntryDate.Size = New System.Drawing.Size(255, 15)
        Me.lblEntryDate.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(494, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 33
        '
        'lblCustomer
        '
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(109, 42)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(51, 13)
        Me.lblCustomer.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(494, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(494, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(494, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(494, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 29
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.Location = New System.Drawing.Point(6, 124)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(31, 13)
        Me.lblCust.TabIndex = 27
        Me.lblCust.Text = "Cust:"
        '
        'lblStateJobNum
        '
        Me.lblStateJobNum.AutoSize = True
        Me.lblStateJobNum.Location = New System.Drawing.Point(216, 66)
        Me.lblStateJobNum.Name = "lblStateJobNum"
        Me.lblStateJobNum.Size = New System.Drawing.Size(45, 13)
        Me.lblStateJobNum.TabIndex = 25
        Me.lblStateJobNum.Text = "State #:"
        '
        'lblProjectNum
        '
        Me.lblProjectNum.AutoSize = True
        Me.lblProjectNum.Location = New System.Drawing.Point(208, 40)
        Me.lblProjectNum.Name = "lblProjectNum"
        Me.lblProjectNum.Size = New System.Drawing.Size(53, 13)
        Me.lblProjectNum.TabIndex = 24
        Me.lblProjectNum.Text = "Project #:"
        '
        'lblJobDesc
        '
        Me.lblJobDesc.AutoSize = True
        Me.lblJobDesc.Location = New System.Drawing.Point(178, 14)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(83, 13)
        Me.lblJobDesc.TabIndex = 23
        Me.lblJobDesc.Text = "Job Description:"
        '
        'lblCompDate
        '
        Me.lblCompDate.AutoSize = True
        Me.lblCompDate.Location = New System.Drawing.Point(350, 92)
        Me.lblCompDate.Name = "lblCompDate"
        Me.lblCompDate.Size = New System.Drawing.Size(88, 13)
        Me.lblCompDate.TabIndex = 22
        Me.lblCompDate.Text = "Completion Date:"
        '
        'lblmhsJobNum
        '
        Me.lblmhsJobNum.AutoSize = True
        Me.lblmhsJobNum.Location = New System.Drawing.Point(27, 18)
        Me.lblmhsJobNum.Name = "lblmhsJobNum"
        Me.lblmhsJobNum.Size = New System.Drawing.Size(64, 13)
        Me.lblmhsJobNum.TabIndex = 21
        Me.lblmhsJobNum.Text = "MHS Job #:"
        '
        'txtCompletionDate
        '
        Me.txtCompletionDate.Location = New System.Drawing.Point(350, 108)
        Me.txtCompletionDate.Name = "txtCompletionDate"
        Me.txtCompletionDate.Size = New System.Drawing.Size(113, 20)
        Me.txtCompletionDate.TabIndex = 10
        '
        'grpTypes
        '
        Me.grpTypes.Controls.Add(Me.ckbTypeIV)
        Me.grpTypes.Controls.Add(Me.chkTypeII)
        Me.grpTypes.Controls.Add(Me.chkTypeIII)
        Me.grpTypes.Controls.Add(Me.chkTypeI)
        Me.grpTypes.Location = New System.Drawing.Point(267, 87)
        Me.grpTypes.Name = "grpTypes"
        Me.grpTypes.Size = New System.Drawing.Size(77, 113)
        Me.grpTypes.TabIndex = 19
        Me.grpTypes.TabStop = False
        Me.grpTypes.Text = "Types"
        '
        'ckbTypeIV
        '
        Me.ckbTypeIV.AutoSize = True
        Me.ckbTypeIV.Location = New System.Drawing.Point(6, 88)
        Me.ckbTypeIV.Name = "ckbTypeIV"
        Me.ckbTypeIV.Size = New System.Drawing.Size(63, 17)
        Me.ckbTypeIV.TabIndex = 3
        Me.ckbTypeIV.Text = "Type IV"
        Me.ckbTypeIV.UseVisualStyleBackColor = True
        '
        'chkTypeII
        '
        Me.chkTypeII.AutoSize = True
        Me.chkTypeII.Location = New System.Drawing.Point(6, 42)
        Me.chkTypeII.Name = "chkTypeII"
        Me.chkTypeII.Size = New System.Drawing.Size(59, 17)
        Me.chkTypeII.TabIndex = 1
        Me.chkTypeII.Text = "Type II"
        Me.chkTypeII.UseVisualStyleBackColor = True
        '
        'chkTypeIII
        '
        Me.chkTypeIII.AutoSize = True
        Me.chkTypeIII.Location = New System.Drawing.Point(6, 65)
        Me.chkTypeIII.Name = "chkTypeIII"
        Me.chkTypeIII.Size = New System.Drawing.Size(62, 17)
        Me.chkTypeIII.TabIndex = 2
        Me.chkTypeIII.Text = "Type III"
        Me.chkTypeIII.UseVisualStyleBackColor = True
        '
        'chkTypeI
        '
        Me.chkTypeI.AutoSize = True
        Me.chkTypeI.Location = New System.Drawing.Point(6, 19)
        Me.chkTypeI.Name = "chkTypeI"
        Me.chkTypeI.Size = New System.Drawing.Size(56, 17)
        Me.chkTypeI.TabIndex = 0
        Me.chkTypeI.Text = "Type I"
        Me.chkTypeI.UseVisualStyleBackColor = True
        '
        'txtStateNum
        '
        Me.txtStateNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStateNum.Location = New System.Drawing.Point(267, 63)
        Me.txtStateNum.Name = "txtStateNum"
        Me.txtStateNum.Size = New System.Drawing.Size(100, 20)
        Me.txtStateNum.TabIndex = 9
        '
        'lblCustPO
        '
        Me.lblCustPO.AutoSize = True
        Me.lblCustPO.Location = New System.Drawing.Point(72, 176)
        Me.lblCustPO.Name = "lblCustPO"
        Me.lblCustPO.Size = New System.Drawing.Size(59, 13)
        Me.lblCustPO.TabIndex = 14
        Me.lblCustPO.Text = "Cust PO #:"
        '
        'lblCustJN
        '
        Me.lblCustJN.AutoSize = True
        Me.lblCustJN.Location = New System.Drawing.Point(70, 150)
        Me.lblCustJN.Name = "lblCustJN"
        Me.lblCustJN.Size = New System.Drawing.Size(61, 13)
        Me.lblCustJN.TabIndex = 13
        Me.lblCustJN.Text = "Cust Job #:"
        '
        'lblContractor
        '
        Me.lblContractor.AutoSize = True
        Me.lblContractor.Location = New System.Drawing.Point(27, 78)
        Me.lblContractor.Name = "lblContractor"
        Me.lblContractor.Size = New System.Drawing.Size(59, 13)
        Me.lblContractor.TabIndex = 11
        Me.lblContractor.Text = "Contractor:"
        '
        'cmbATMJobNum
        '
        Me.cmbATMJobNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbATMJobNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbATMJobNum.FormattingEnabled = True
        Me.cmbATMJobNum.Location = New System.Drawing.Point(166, 94)
        Me.cmbATMJobNum.Name = "cmbATMJobNum"
        Me.cmbATMJobNum.Size = New System.Drawing.Size(57, 21)
        Me.cmbATMJobNum.TabIndex = 3
        '
        'cmbContractor
        '
        Me.cmbContractor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbContractor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbContractor.FormattingEnabled = True
        Me.cmbContractor.Location = New System.Drawing.Point(30, 94)
        Me.cmbContractor.Name = "cmbContractor"
        Me.cmbContractor.Size = New System.Drawing.Size(130, 21)
        Me.cmbContractor.TabIndex = 2
        '
        'txtmhsJobNum
        '
        Me.txtmhsJobNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmhsJobNum.Location = New System.Drawing.Point(30, 34)
        Me.txtmhsJobNum.Name = "txtmhsJobNum"
        Me.txtmhsJobNum.Size = New System.Drawing.Size(69, 26)
        Me.txtmhsJobNum.TabIndex = 0
        Me.txtmhsJobNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProjectNum
        '
        Me.txtProjectNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProjectNum.Location = New System.Drawing.Point(267, 37)
        Me.txtProjectNum.Name = "txtProjectNum"
        Me.txtProjectNum.Size = New System.Drawing.Size(199, 20)
        Me.txtProjectNum.TabIndex = 8
        '
        'txtJobDesc
        '
        Me.txtJobDesc.Location = New System.Drawing.Point(267, 11)
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Size = New System.Drawing.Size(199, 20)
        Me.txtJobDesc.TabIndex = 7
        '
        'txtCustPO
        '
        Me.txtCustPO.Location = New System.Drawing.Point(137, 173)
        Me.txtCustPO.Name = "txtCustPO"
        Me.txtCustPO.Size = New System.Drawing.Size(86, 20)
        Me.txtCustPO.TabIndex = 6
        '
        'txtCustJobNum
        '
        Me.txtCustJobNum.Location = New System.Drawing.Point(137, 147)
        Me.txtCustJobNum.Name = "txtCustJobNum"
        Me.txtCustJobNum.Size = New System.Drawing.Size(86, 20)
        Me.txtCustJobNum.TabIndex = 5
        '
        'txt
        '
        Me.txt.Location = New System.Drawing.Point(551, 198)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(100, 20)
        Me.txt.TabIndex = 6
        Me.txt.TabStop = False
        '
        'mhsJobList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(524, 437)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "mhsJobList"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MHS Job List"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpTypes.ResumeLayout(False)
        Me.grpTypes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnPerformSearch As System.Windows.Forms.Button
    Friend WithEvents btnPerformSort As System.Windows.Forms.Button
    Friend WithEvents txtRecordPosition As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents cmbField As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblField As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmhsJobNum As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectNum As System.Windows.Forms.TextBox
    Friend WithEvents txtJobDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCustPO As System.Windows.Forms.TextBox
    Friend WithEvents txtCustJobNum As System.Windows.Forms.TextBox
    Friend WithEvents cmbATMJobNum As System.Windows.Forms.ComboBox
    Friend WithEvents cmbContractor As System.Windows.Forms.ComboBox
    Friend WithEvents lblContractor As System.Windows.Forms.Label
    Friend WithEvents lblCustJN As System.Windows.Forms.Label
    Friend WithEvents lblCustPO As System.Windows.Forms.Label
    Friend WithEvents grpTypes As System.Windows.Forms.GroupBox
    Friend WithEvents chkTypeIII As System.Windows.Forms.CheckBox
    Friend WithEvents chkTypeII As System.Windows.Forms.CheckBox
    Friend WithEvents chkTypeI As System.Windows.Forms.CheckBox
    Friend WithEvents txtStateNum As System.Windows.Forms.TextBox
    Friend WithEvents lblmhsJobNum As System.Windows.Forms.Label
    Friend WithEvents txtCompletionDate As System.Windows.Forms.TextBox
    Friend WithEvents lblCompDate As System.Windows.Forms.Label
    Friend WithEvents lblProjectNum As System.Windows.Forms.Label
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
    Friend WithEvents lblStateJobNum As System.Windows.Forms.Label
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnATMInfo As System.Windows.Forms.Button
    Friend WithEvents btnViewAll As System.Windows.Forms.Button
    Friend WithEvents txt As System.Windows.Forms.TextBox
    Friend WithEvents lblCustFull As System.Windows.Forms.Label
    Friend WithEvents ckbTypeIV As System.Windows.Forms.CheckBox
    Friend WithEvents ckbActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblEntryDate As System.Windows.Forms.Label
    Friend WithEvents lblDateEntered As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
