<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpJobDetails = New System.Windows.Forms.GroupBox
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtCompDate = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblBoundCust = New System.Windows.Forms.Label
        Me.ckbMMM = New System.Windows.Forms.CheckBox
        Me.ckbActive = New System.Windows.Forms.CheckBox
        Me.lblStateJobNum = New System.Windows.Forms.Label
        Me.lblProjectNum = New System.Windows.Forms.Label
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.lblCompDate = New System.Windows.Forms.Label
        Me.lblmhsJobNum = New System.Windows.Forms.Label
        Me.btnATMInfo = New System.Windows.Forms.Button
        Me.grpTypes = New System.Windows.Forms.GroupBox
        Me.ckbTypeIV = New System.Windows.Forms.CheckBox
        Me.ckbTypeII = New System.Windows.Forms.CheckBox
        Me.ckbTypeIII = New System.Windows.Forms.CheckBox
        Me.ckbTypeI = New System.Windows.Forms.CheckBox
        Me.txtStateNum = New System.Windows.Forms.TextBox
        Me.lblCustPO = New System.Windows.Forms.Label
        Me.lblCustJN = New System.Windows.Forms.Label
        Me.lblCust = New System.Windows.Forms.Label
        Me.cmbCustomer = New System.Windows.Forms.ComboBox
        Me.cmbATMJobNum = New System.Windows.Forms.ComboBox
        Me.txtMHSJob = New System.Windows.Forms.TextBox
        Me.txtProjectNum = New System.Windows.Forms.TextBox
        Me.txtJobDesc = New System.Windows.Forms.TextBox
        Me.txtCustPO = New System.Windows.Forms.TextBox
        Me.txtCustJob = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnViewAll = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.grpJobDetails.SuspendLayout()
        Me.grpTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 290)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(556, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'grpJobDetails
        '
        Me.grpJobDetails.BackColor = System.Drawing.Color.Transparent
        Me.grpJobDetails.Controls.Add(Me.MaskedTextBox1)
        Me.grpJobDetails.Controls.Add(Me.mtxtCompDate)
        Me.grpJobDetails.Controls.Add(Me.Label4)
        Me.grpJobDetails.Controls.Add(Me.Label3)
        Me.grpJobDetails.Controls.Add(Me.Label2)
        Me.grpJobDetails.Controls.Add(Me.Label1)
        Me.grpJobDetails.Controls.Add(Me.lblBoundCust)
        Me.grpJobDetails.Controls.Add(Me.ckbMMM)
        Me.grpJobDetails.Controls.Add(Me.ckbActive)
        Me.grpJobDetails.Controls.Add(Me.lblStateJobNum)
        Me.grpJobDetails.Controls.Add(Me.lblProjectNum)
        Me.grpJobDetails.Controls.Add(Me.lblJobDesc)
        Me.grpJobDetails.Controls.Add(Me.lblCompDate)
        Me.grpJobDetails.Controls.Add(Me.lblmhsJobNum)
        Me.grpJobDetails.Controls.Add(Me.btnATMInfo)
        Me.grpJobDetails.Controls.Add(Me.grpTypes)
        Me.grpJobDetails.Controls.Add(Me.txtStateNum)
        Me.grpJobDetails.Controls.Add(Me.lblCustPO)
        Me.grpJobDetails.Controls.Add(Me.lblCustJN)
        Me.grpJobDetails.Controls.Add(Me.lblCust)
        Me.grpJobDetails.Controls.Add(Me.cmbCustomer)
        Me.grpJobDetails.Controls.Add(Me.cmbATMJobNum)
        Me.grpJobDetails.Controls.Add(Me.txtMHSJob)
        Me.grpJobDetails.Controls.Add(Me.txtProjectNum)
        Me.grpJobDetails.Controls.Add(Me.txtJobDesc)
        Me.grpJobDetails.Controls.Add(Me.txtCustPO)
        Me.grpJobDetails.Controls.Add(Me.txtCustJob)
        Me.grpJobDetails.Location = New System.Drawing.Point(12, 12)
        Me.grpJobDetails.Name = "grpJobDetails"
        Me.grpJobDetails.Size = New System.Drawing.Size(531, 239)
        Me.grpJobDetails.TabIndex = 1
        Me.grpJobDetails.TabStop = False
        Me.grpJobDetails.Text = "Project Details"
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(561, 103)
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.MaskedTextBox1.TabIndex = 32
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'mtxtCompDate
        '
        Me.mtxtCompDate.Location = New System.Drawing.Point(267, 201)
        Me.mtxtCompDate.Mask = "00/00/0000"
        Me.mtxtCompDate.Name = "mtxtCompDate"
        Me.mtxtCompDate.Size = New System.Drawing.Size(100, 20)
        Me.mtxtCompDate.TabIndex = 31
        Me.mtxtCompDate.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(558, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(558, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(558, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(558, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Label1"
        '
        'lblBoundCust
        '
        Me.lblBoundCust.AutoSize = True
        Me.lblBoundCust.Location = New System.Drawing.Point(106, 86)
        Me.lblBoundCust.Name = "lblBoundCust"
        Me.lblBoundCust.Size = New System.Drawing.Size(39, 13)
        Me.lblBoundCust.TabIndex = 25
        Me.lblBoundCust.Text = "Label1"
        Me.lblBoundCust.Visible = False
        '
        'ckbMMM
        '
        Me.ckbMMM.AutoSize = True
        Me.ckbMMM.Location = New System.Drawing.Point(277, 169)
        Me.ckbMMM.Name = "ckbMMM"
        Me.ckbMMM.Size = New System.Drawing.Size(86, 17)
        Me.ckbMMM.TabIndex = 10
        Me.ckbMMM.Text = "3M Discount"
        Me.ckbMMM.UseVisualStyleBackColor = True
        '
        'ckbActive
        '
        Me.ckbActive.AutoSize = True
        Me.ckbActive.Location = New System.Drawing.Point(277, 146)
        Me.ckbActive.Name = "ckbActive"
        Me.ckbActive.Size = New System.Drawing.Size(100, 17)
        Me.ckbActive.TabIndex = 9
        Me.ckbActive.Text = "Currently Active"
        Me.ckbActive.UseVisualStyleBackColor = True
        '
        'lblStateJobNum
        '
        Me.lblStateJobNum.AutoSize = True
        Me.lblStateJobNum.Location = New System.Drawing.Point(216, 74)
        Me.lblStateJobNum.Name = "lblStateJobNum"
        Me.lblStateJobNum.Size = New System.Drawing.Size(45, 13)
        Me.lblStateJobNum.TabIndex = 22
        Me.lblStateJobNum.Text = "State #:"
        '
        'lblProjectNum
        '
        Me.lblProjectNum.AutoSize = True
        Me.lblProjectNum.Location = New System.Drawing.Point(208, 48)
        Me.lblProjectNum.Name = "lblProjectNum"
        Me.lblProjectNum.Size = New System.Drawing.Size(53, 13)
        Me.lblProjectNum.TabIndex = 21
        Me.lblProjectNum.Text = "Project #:"
        '
        'lblJobDesc
        '
        Me.lblJobDesc.AutoSize = True
        Me.lblJobDesc.Location = New System.Drawing.Point(178, 22)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(83, 13)
        Me.lblJobDesc.TabIndex = 20
        Me.lblJobDesc.Text = "Job Description:"
        '
        'lblCompDate
        '
        Me.lblCompDate.AutoSize = True
        Me.lblCompDate.Location = New System.Drawing.Point(173, 204)
        Me.lblCompDate.Name = "lblCompDate"
        Me.lblCompDate.Size = New System.Drawing.Size(88, 13)
        Me.lblCompDate.TabIndex = 19
        Me.lblCompDate.Text = "Completion Date:"
        '
        'lblmhsJobNum
        '
        Me.lblmhsJobNum.AutoSize = True
        Me.lblmhsJobNum.Location = New System.Drawing.Point(22, 22)
        Me.lblmhsJobNum.Name = "lblmhsJobNum"
        Me.lblmhsJobNum.Size = New System.Drawing.Size(64, 13)
        Me.lblmhsJobNum.TabIndex = 15
        Me.lblmhsJobNum.Text = "MHS Job #:"
        '
        'btnATMInfo
        '
        Me.btnATMInfo.Location = New System.Drawing.Point(338, 102)
        Me.btnATMInfo.Name = "btnATMInfo"
        Me.btnATMInfo.Size = New System.Drawing.Size(62, 23)
        Me.btnATMInfo.TabIndex = 3
        Me.btnATMInfo.Text = "^"
        Me.btnATMInfo.UseVisualStyleBackColor = True
        Me.btnATMInfo.Visible = False
        '
        'grpTypes
        '
        Me.grpTypes.Controls.Add(Me.ckbTypeIV)
        Me.grpTypes.Controls.Add(Me.ckbTypeII)
        Me.grpTypes.Controls.Add(Me.ckbTypeIII)
        Me.grpTypes.Controls.Add(Me.ckbTypeI)
        Me.grpTypes.Location = New System.Drawing.Point(430, 63)
        Me.grpTypes.Name = "grpTypes"
        Me.grpTypes.Size = New System.Drawing.Size(77, 113)
        Me.grpTypes.TabIndex = 12
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
        'ckbTypeII
        '
        Me.ckbTypeII.AutoSize = True
        Me.ckbTypeII.Location = New System.Drawing.Point(6, 42)
        Me.ckbTypeII.Name = "ckbTypeII"
        Me.ckbTypeII.Size = New System.Drawing.Size(59, 17)
        Me.ckbTypeII.TabIndex = 1
        Me.ckbTypeII.Text = "Type II"
        Me.ckbTypeII.UseVisualStyleBackColor = True
        '
        'ckbTypeIII
        '
        Me.ckbTypeIII.AutoSize = True
        Me.ckbTypeIII.Location = New System.Drawing.Point(6, 65)
        Me.ckbTypeIII.Name = "ckbTypeIII"
        Me.ckbTypeIII.Size = New System.Drawing.Size(62, 17)
        Me.ckbTypeIII.TabIndex = 2
        Me.ckbTypeIII.Text = "Type III"
        Me.ckbTypeIII.UseVisualStyleBackColor = True
        '
        'ckbTypeI
        '
        Me.ckbTypeI.AutoSize = True
        Me.ckbTypeI.Location = New System.Drawing.Point(6, 19)
        Me.ckbTypeI.Name = "ckbTypeI"
        Me.ckbTypeI.Size = New System.Drawing.Size(56, 17)
        Me.ckbTypeI.TabIndex = 0
        Me.ckbTypeI.Text = "Type I"
        Me.ckbTypeI.UseVisualStyleBackColor = True
        '
        'txtStateNum
        '
        Me.txtStateNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStateNum.Location = New System.Drawing.Point(267, 71)
        Me.txtStateNum.Name = "txtStateNum"
        Me.txtStateNum.Size = New System.Drawing.Size(134, 20)
        Me.txtStateNum.TabIndex = 8
        '
        'lblCustPO
        '
        Me.lblCustPO.AutoSize = True
        Me.lblCustPO.Location = New System.Drawing.Point(44, 160)
        Me.lblCustPO.Name = "lblCustPO"
        Me.lblCustPO.Size = New System.Drawing.Size(59, 13)
        Me.lblCustPO.TabIndex = 18
        Me.lblCustPO.Text = "Cust PO #:"
        '
        'lblCustJN
        '
        Me.lblCustJN.AutoSize = True
        Me.lblCustJN.Location = New System.Drawing.Point(42, 134)
        Me.lblCustJN.Name = "lblCustJN"
        Me.lblCustJN.Size = New System.Drawing.Size(61, 13)
        Me.lblCustJN.TabIndex = 17
        Me.lblCustJN.Text = "Cust Job #:"
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.Location = New System.Drawing.Point(49, 107)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(54, 13)
        Me.lblCust.TabIndex = 16
        Me.lblCust.Text = "Customer:"
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(109, 104)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(119, 21)
        Me.cmbCustomer.TabIndex = 1
        '
        'cmbATMJobNum
        '
        Me.cmbATMJobNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbATMJobNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbATMJobNum.FormattingEnabled = True
        Me.cmbATMJobNum.Location = New System.Drawing.Point(267, 104)
        Me.cmbATMJobNum.Name = "cmbATMJobNum"
        Me.cmbATMJobNum.Size = New System.Drawing.Size(66, 21)
        Me.cmbATMJobNum.TabIndex = 2
        Me.cmbATMJobNum.Visible = False
        '
        'txtMHSJob
        '
        Me.txtMHSJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMHSJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMHSJob.Location = New System.Drawing.Point(25, 42)
        Me.txtMHSJob.Name = "txtMHSJob"
        Me.txtMHSJob.Size = New System.Drawing.Size(120, 26)
        Me.txtMHSJob.TabIndex = 0
        Me.txtMHSJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProjectNum
        '
        Me.txtProjectNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProjectNum.Location = New System.Drawing.Point(267, 45)
        Me.txtProjectNum.Name = "txtProjectNum"
        Me.txtProjectNum.Size = New System.Drawing.Size(134, 20)
        Me.txtProjectNum.TabIndex = 7
        '
        'txtJobDesc
        '
        Me.txtJobDesc.Location = New System.Drawing.Point(267, 19)
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Size = New System.Drawing.Size(217, 20)
        Me.txtJobDesc.TabIndex = 6
        '
        'txtCustPO
        '
        Me.txtCustPO.Location = New System.Drawing.Point(109, 157)
        Me.txtCustPO.Name = "txtCustPO"
        Me.txtCustPO.Size = New System.Drawing.Size(119, 20)
        Me.txtCustPO.TabIndex = 5
        '
        'txtCustJob
        '
        Me.txtCustJob.Location = New System.Drawing.Point(109, 131)
        Me.txtCustJob.Name = "txtCustJob"
        Me.txtCustJob.Size = New System.Drawing.Size(119, 20)
        Me.txtCustJob.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(459, 257)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add Job"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnViewAll
        '
        Me.btnViewAll.Location = New System.Drawing.Point(369, 257)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(84, 23)
        Me.btnViewAll.TabIndex = 1
        Me.btnViewAll.Text = "View All Jobs"
        Me.btnViewAll.UseVisualStyleBackColor = True
        '
        'frmJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(556, 312)
        Me.Controls.Add(Me.grpJobDetails)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnViewAll)
        Me.Controls.Add(Me.btnAdd)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJob"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Job"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpJobDetails.ResumeLayout(False)
        Me.grpJobDetails.PerformLayout()
        Me.grpTypes.ResumeLayout(False)
        Me.grpTypes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpJobDetails As System.Windows.Forms.GroupBox
    Friend WithEvents ckbActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnViewAll As System.Windows.Forms.Button
    Friend WithEvents btnATMInfo As System.Windows.Forms.Button
    Friend WithEvents lblStateJobNum As System.Windows.Forms.Label
    Friend WithEvents lblProjectNum As System.Windows.Forms.Label
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
    Friend WithEvents lblCompDate As System.Windows.Forms.Label
    Friend WithEvents lblmhsJobNum As System.Windows.Forms.Label
    Friend WithEvents grpTypes As System.Windows.Forms.GroupBox
    Friend WithEvents ckbTypeIV As System.Windows.Forms.CheckBox
    Friend WithEvents ckbTypeII As System.Windows.Forms.CheckBox
    Friend WithEvents ckbTypeIII As System.Windows.Forms.CheckBox
    Friend WithEvents ckbTypeI As System.Windows.Forms.CheckBox
    Friend WithEvents txtStateNum As System.Windows.Forms.TextBox
    Friend WithEvents lblCustPO As System.Windows.Forms.Label
    Friend WithEvents lblCustJN As System.Windows.Forms.Label
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents cmbATMJobNum As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents txtMHSJob As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectNum As System.Windows.Forms.TextBox
    Friend WithEvents txtJobDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCustPO As System.Windows.Forms.TextBox
    Friend WithEvents txtCustJob As System.Windows.Forms.TextBox
    Friend WithEvents ckbMMM As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblBoundCust As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtxtCompDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
End Class
