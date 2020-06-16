<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinalizeShipper
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFinalizeShipper))
		Me.lblShipperID = New System.Windows.Forms.Label
		Me.lblRecvdBy = New System.Windows.Forms.Label
		Me.lblShipDate = New System.Windows.Forms.Label
		Me.lblMHSJobLabel = New System.Windows.Forms.Label
		Me.lblComments = New System.Windows.Forms.Label
		Me.lblEntryDate = New System.Windows.Forms.Label
		Me.lblShipperNum = New System.Windows.Forms.Label
		Me.lblPO = New System.Windows.Forms.Label
		Me.txtRcvdBy = New System.Windows.Forms.TextBox
		Me.txtEntryDate = New System.Windows.Forms.TextBox
		Me.txtPO = New System.Windows.Forms.TextBox
		Me.txtComments = New System.Windows.Forms.TextBox
		Me.cboShipped = New System.Windows.Forms.CheckBox
		Me.grpShipperInfo = New System.Windows.Forms.GroupBox
		Me.eDTPShipDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker
		Me.lblVia = New System.Windows.Forms.Label
		Me.txtVia = New System.Windows.Forms.TextBox
		Me.btnUpdate = New System.Windows.Forms.Button
		Me.btnEdit = New System.Windows.Forms.Button
		Me.cmbMHSJob = New System.Windows.Forms.ComboBox
		Me.lblMHSJob = New System.Windows.Forms.Label
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.Label13 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.ckbMMM = New System.Windows.Forms.CheckBox
		Me.ckbActive = New System.Windows.Forms.CheckBox
		Me.lblCompDate = New System.Windows.Forms.Label
		Me.lblStateNum = New System.Windows.Forms.Label
		Me.lblProjNum = New System.Windows.Forms.Label
		Me.lblCustJob = New System.Windows.Forms.Label
		Me.lblCust = New System.Windows.Forms.Label
		Me.grpProject = New System.Windows.Forms.GroupBox
		Me.lblJobDesc = New System.Windows.Forms.Label
		Me.grpShipperInfo.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.grpProject.SuspendLayout()
		Me.SuspendLayout()
		'
		'lblShipperID
		'
		Me.lblShipperID.AutoSize = True
		Me.lblShipperID.BackColor = System.Drawing.Color.Transparent
		Me.lblShipperID.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblShipperID.ForeColor = System.Drawing.Color.Navy
		Me.lblShipperID.Location = New System.Drawing.Point(478, 9)
		Me.lblShipperID.Name = "lblShipperID"
		Me.lblShipperID.Size = New System.Drawing.Size(87, 36)
		Me.lblShipperID.TabIndex = 0
		Me.lblShipperID.Text = "5000"
		'
		'lblRecvdBy
		'
		Me.lblRecvdBy.AutoSize = True
		Me.lblRecvdBy.Location = New System.Drawing.Point(20, 160)
		Me.lblRecvdBy.Name = "lblRecvdBy"
		Me.lblRecvdBy.Size = New System.Drawing.Size(68, 13)
		Me.lblRecvdBy.TabIndex = 1
		Me.lblRecvdBy.Text = "Received By"
		'
		'lblShipDate
		'
		Me.lblShipDate.AutoSize = True
		Me.lblShipDate.Location = New System.Drawing.Point(34, 135)
		Me.lblShipDate.Name = "lblShipDate"
		Me.lblShipDate.Size = New System.Drawing.Size(54, 13)
		Me.lblShipDate.TabIndex = 3
		Me.lblShipDate.Text = "Ship Date"
		'
		'lblMHSJobLabel
		'
		Me.lblMHSJobLabel.AutoSize = True
		Me.lblMHSJobLabel.Location = New System.Drawing.Point(14, 53)
		Me.lblMHSJobLabel.Name = "lblMHSJobLabel"
		Me.lblMHSJobLabel.Size = New System.Drawing.Size(61, 13)
		Me.lblMHSJobLabel.TabIndex = 2
		Me.lblMHSJobLabel.Text = "MHS Job #"
		'
		'lblComments
		'
		Me.lblComments.AutoSize = True
		Me.lblComments.Location = New System.Drawing.Point(9, 232)
		Me.lblComments.Name = "lblComments"
		Me.lblComments.Size = New System.Drawing.Size(56, 13)
		Me.lblComments.TabIndex = 7
		Me.lblComments.Text = "Comments"
		'
		'lblEntryDate
		'
		Me.lblEntryDate.AutoSize = True
		Me.lblEntryDate.Location = New System.Drawing.Point(8, 206)
		Me.lblEntryDate.Name = "lblEntryDate"
		Me.lblEntryDate.Size = New System.Drawing.Size(57, 13)
		Me.lblEntryDate.TabIndex = 6
		Me.lblEntryDate.Text = "Entry Date"
		'
		'lblShipperNum
		'
		Me.lblShipperNum.AutoSize = True
		Me.lblShipperNum.BackColor = System.Drawing.Color.Transparent
		Me.lblShipperNum.Location = New System.Drawing.Point(419, 25)
		Me.lblShipperNum.Name = "lblShipperNum"
		Me.lblShipperNum.Size = New System.Drawing.Size(53, 13)
		Me.lblShipperNum.TabIndex = 5
		Me.lblShipperNum.Text = "Shipper #"
		'
		'lblPO
		'
		Me.lblPO.AutoSize = True
		Me.lblPO.Location = New System.Drawing.Point(43, 46)
		Me.lblPO.Name = "lblPO"
		Me.lblPO.Size = New System.Drawing.Size(22, 13)
		Me.lblPO.TabIndex = 4
		Me.lblPO.Text = "PO"
		'
		'txtRcvdBy
		'
		Me.txtRcvdBy.Location = New System.Drawing.Point(94, 157)
		Me.txtRcvdBy.Name = "txtRcvdBy"
		Me.txtRcvdBy.Size = New System.Drawing.Size(141, 20)
		Me.txtRcvdBy.TabIndex = 1
		'
		'txtEntryDate
		'
		Me.txtEntryDate.Location = New System.Drawing.Point(71, 203)
		Me.txtEntryDate.Name = "txtEntryDate"
		Me.txtEntryDate.Size = New System.Drawing.Size(160, 20)
		Me.txtEntryDate.TabIndex = 14
		'
		'txtPO
		'
		Me.txtPO.Location = New System.Drawing.Point(71, 43)
		Me.txtPO.Name = "txtPO"
		Me.txtPO.Size = New System.Drawing.Size(88, 20)
		Me.txtPO.TabIndex = 6
		'
		'txtComments
		'
		Me.txtComments.Location = New System.Drawing.Point(71, 229)
		Me.txtComments.Multiline = True
		Me.txtComments.Name = "txtComments"
		Me.txtComments.Size = New System.Drawing.Size(160, 47)
		Me.txtComments.TabIndex = 8
		'
		'cboShipped
		'
		Me.cboShipped.AutoSize = True
		Me.cboShipped.Location = New System.Drawing.Point(94, 108)
		Me.cboShipped.Name = "cboShipped"
		Me.cboShipped.Size = New System.Drawing.Size(65, 17)
		Me.cboShipped.TabIndex = 2
		Me.cboShipped.Text = "Shipped"
		Me.cboShipped.UseVisualStyleBackColor = True
		'
		'grpShipperInfo
		'
		Me.grpShipperInfo.BackColor = System.Drawing.Color.Transparent
		Me.grpShipperInfo.Controls.Add(Me.eDTPShipDate)
		Me.grpShipperInfo.Controls.Add(Me.lblVia)
		Me.grpShipperInfo.Controls.Add(Me.txtVia)
		Me.grpShipperInfo.Controls.Add(Me.cboShipped)
		Me.grpShipperInfo.Controls.Add(Me.txtPO)
		Me.grpShipperInfo.Controls.Add(Me.lblPO)
		Me.grpShipperInfo.Controls.Add(Me.lblComments)
		Me.grpShipperInfo.Controls.Add(Me.lblShipDate)
		Me.grpShipperInfo.Controls.Add(Me.txtComments)
		Me.grpShipperInfo.Controls.Add(Me.txtEntryDate)
		Me.grpShipperInfo.Controls.Add(Me.lblEntryDate)
		Me.grpShipperInfo.Controls.Add(Me.txtRcvdBy)
		Me.grpShipperInfo.Controls.Add(Me.lblRecvdBy)
		Me.grpShipperInfo.Location = New System.Drawing.Point(12, 48)
		Me.grpShipperInfo.Name = "grpShipperInfo"
		Me.grpShipperInfo.Size = New System.Drawing.Size(246, 313)
		Me.grpShipperInfo.TabIndex = 18
		Me.grpShipperInfo.TabStop = False
		Me.grpShipperInfo.Text = "Shipper Information"
		'
		'eDTPShipDate
		'
		Me.eDTPShipDate.CustomFormat = "MM/dd/yyyy"
		Me.eDTPShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.eDTPShipDate.Location = New System.Drawing.Point(94, 131)
		Me.eDTPShipDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
		Me.eDTPShipDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
		Me.eDTPShipDate.Name = "eDTPShipDate"
		Me.eDTPShipDate.Size = New System.Drawing.Size(141, 20)
		Me.eDTPShipDate.TabIndex = 0
		Me.eDTPShipDate.Value = New Date(2010, 2, 9, 0, 0, 0, 0)
		'
		'lblVia
		'
		Me.lblVia.AutoSize = True
		Me.lblVia.Location = New System.Drawing.Point(43, 72)
		Me.lblVia.Name = "lblVia"
		Me.lblVia.Size = New System.Drawing.Size(22, 13)
		Me.lblVia.TabIndex = 22
		Me.lblVia.Text = "Via"
		'
		'txtVia
		'
		Me.txtVia.Location = New System.Drawing.Point(71, 69)
		Me.txtVia.Name = "txtVia"
		Me.txtVia.Size = New System.Drawing.Size(162, 20)
		Me.txtVia.TabIndex = 7
		'
		'btnUpdate
		'
		Me.btnUpdate.Location = New System.Drawing.Point(484, 338)
		Me.btnUpdate.Name = "btnUpdate"
		Me.btnUpdate.Size = New System.Drawing.Size(108, 23)
		Me.btnUpdate.TabIndex = 3
		Me.btnUpdate.Text = "Update"
		Me.btnUpdate.UseVisualStyleBackColor = True
		'
		'btnEdit
		'
		Me.btnEdit.Location = New System.Drawing.Point(370, 338)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(108, 23)
		Me.btnEdit.TabIndex = 4
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'cmbMHSJob
		'
		Me.cmbMHSJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbMHSJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbMHSJob.FormattingEnabled = True
		Me.cmbMHSJob.Location = New System.Drawing.Point(86, 19)
		Me.cmbMHSJob.Name = "cmbMHSJob"
		Me.cmbMHSJob.Size = New System.Drawing.Size(215, 21)
		Me.cmbMHSJob.TabIndex = 5
		'
		'lblMHSJob
		'
		Me.lblMHSJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMHSJob.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMHSJob.Location = New System.Drawing.Point(81, 43)
		Me.lblMHSJob.Name = "lblMHSJob"
		Me.lblMHSJob.Size = New System.Drawing.Size(247, 26)
		Me.lblMHSJob.TabIndex = 1
		Me.lblMHSJob.Text = "09-999"
		Me.lblMHSJob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 370)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(610, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 19
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
		Me.ToolStripStatusLabel1.Text = "Ready"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.ForeColor = System.Drawing.Color.DimGray
		Me.Label13.Location = New System.Drawing.Point(17, 228)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(59, 13)
		Me.Label13.TabIndex = 89
		Me.Label13.Text = "Completion"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.ForeColor = System.Drawing.Color.DimGray
		Me.Label12.Location = New System.Drawing.Point(14, 164)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(62, 13)
		Me.Label12.TabIndex = 88
		Me.Label12.Text = "State Job #"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.ForeColor = System.Drawing.Color.DimGray
		Me.Label11.Location = New System.Drawing.Point(27, 144)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(50, 13)
		Me.Label11.TabIndex = 87
		Me.Label11.Text = "Project #"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.ForeColor = System.Drawing.Color.DimGray
		Me.Label10.Location = New System.Drawing.Point(43, 125)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(34, 13)
		Me.Label10.TabIndex = 86
		Me.Label10.Text = "Job #"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.ForeColor = System.Drawing.Color.DimGray
		Me.Label9.Location = New System.Drawing.Point(25, 106)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(51, 13)
		Me.Label9.TabIndex = 85
		Me.Label9.Text = "Customer"
		'
		'ckbMMM
		'
		Me.ckbMMM.AutoSize = True
		Me.ckbMMM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.ckbMMM.Enabled = False
		Me.ckbMMM.Location = New System.Drawing.Point(31, 208)
		Me.ckbMMM.Name = "ckbMMM"
		Me.ckbMMM.Size = New System.Drawing.Size(65, 17)
		Me.ckbMMM.TabIndex = 84
		Me.ckbMMM.Text = "3M Disc"
		Me.ckbMMM.UseVisualStyleBackColor = True
		'
		'ckbActive
		'
		Me.ckbActive.AutoSize = True
		Me.ckbActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.ckbActive.Enabled = False
		Me.ckbActive.Location = New System.Drawing.Point(40, 185)
		Me.ckbActive.Name = "ckbActive"
		Me.ckbActive.Size = New System.Drawing.Size(56, 17)
		Me.ckbActive.TabIndex = 83
		Me.ckbActive.Text = "Active"
		Me.ckbActive.UseVisualStyleBackColor = True
		'
		'lblCompDate
		'
		Me.lblCompDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblCompDate.BackColor = System.Drawing.Color.Transparent
		Me.lblCompDate.Location = New System.Drawing.Point(99, 228)
		Me.lblCompDate.Name = "lblCompDate"
		Me.lblCompDate.Size = New System.Drawing.Size(100, 13)
		Me.lblCompDate.TabIndex = 82
		Me.lblCompDate.Text = "compDate"
		'
		'lblStateNum
		'
		Me.lblStateNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblStateNum.BackColor = System.Drawing.Color.Transparent
		Me.lblStateNum.Location = New System.Drawing.Point(99, 164)
		Me.lblStateNum.Name = "lblStateNum"
		Me.lblStateNum.Size = New System.Drawing.Size(100, 13)
		Me.lblStateNum.TabIndex = 81
		Me.lblStateNum.Text = "stateNum"
		'
		'lblProjNum
		'
		Me.lblProjNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblProjNum.BackColor = System.Drawing.Color.Transparent
		Me.lblProjNum.Location = New System.Drawing.Point(99, 143)
		Me.lblProjNum.Name = "lblProjNum"
		Me.lblProjNum.Size = New System.Drawing.Size(100, 13)
		Me.lblProjNum.TabIndex = 80
		Me.lblProjNum.Text = "projNum"
		'
		'lblCustJob
		'
		Me.lblCustJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblCustJob.BackColor = System.Drawing.Color.Transparent
		Me.lblCustJob.Location = New System.Drawing.Point(99, 125)
		Me.lblCustJob.Name = "lblCustJob"
		Me.lblCustJob.Size = New System.Drawing.Size(100, 13)
		Me.lblCustJob.TabIndex = 79
		Me.lblCustJob.Text = "custJob"
		'
		'lblCust
		'
		Me.lblCust.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblCust.BackColor = System.Drawing.Color.Transparent
		Me.lblCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCust.Location = New System.Drawing.Point(98, 101)
		Me.lblCust.Name = "lblCust"
		Me.lblCust.Size = New System.Drawing.Size(100, 24)
		Me.lblCust.TabIndex = 78
		Me.lblCust.Text = "cust"
		'
		'grpProject
		'
		Me.grpProject.BackColor = System.Drawing.Color.Transparent
		Me.grpProject.Controls.Add(Me.lblJobDesc)
		Me.grpProject.Controls.Add(Me.lblCust)
		Me.grpProject.Controls.Add(Me.Label13)
		Me.grpProject.Controls.Add(Me.lblStateNum)
		Me.grpProject.Controls.Add(Me.cmbMHSJob)
		Me.grpProject.Controls.Add(Me.lblCompDate)
		Me.grpProject.Controls.Add(Me.lblMHSJob)
		Me.grpProject.Controls.Add(Me.lblMHSJobLabel)
		Me.grpProject.Controls.Add(Me.Label12)
		Me.grpProject.Controls.Add(Me.lblProjNum)
		Me.grpProject.Controls.Add(Me.ckbActive)
		Me.grpProject.Controls.Add(Me.lblCustJob)
		Me.grpProject.Controls.Add(Me.ckbMMM)
		Me.grpProject.Controls.Add(Me.Label11)
		Me.grpProject.Controls.Add(Me.Label9)
		Me.grpProject.Controls.Add(Me.Label10)
		Me.grpProject.Location = New System.Drawing.Point(264, 48)
		Me.grpProject.Name = "grpProject"
		Me.grpProject.Size = New System.Drawing.Size(334, 261)
		Me.grpProject.TabIndex = 90
		Me.grpProject.TabStop = False
		Me.grpProject.Text = "Project Information"
		'
		'lblJobDesc
		'
		Me.lblJobDesc.BackColor = System.Drawing.Color.Transparent
		Me.lblJobDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblJobDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblJobDesc.Location = New System.Drawing.Point(6, 72)
		Me.lblJobDesc.Name = "lblJobDesc"
		Me.lblJobDesc.Size = New System.Drawing.Size(322, 14)
		Me.lblJobDesc.TabIndex = 90
		Me.lblJobDesc.Text = "Description"
		Me.lblJobDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'frmFinalizeShipper
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(610, 392)
		Me.Controls.Add(Me.grpProject)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.btnUpdate)
		Me.Controls.Add(Me.grpShipperInfo)
		Me.Controls.Add(Me.btnEdit)
		Me.Controls.Add(Me.lblShipperID)
		Me.Controls.Add(Me.lblShipperNum)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmFinalizeShipper"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Edit - Finalize Shipper"
		Me.grpShipperInfo.ResumeLayout(False)
		Me.grpShipperInfo.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.grpProject.ResumeLayout(False)
		Me.grpProject.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents lblShipperID As System.Windows.Forms.Label
    Friend WithEvents lblRecvdBy As System.Windows.Forms.Label
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents lblMHSJobLabel As System.Windows.Forms.Label
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblEntryDate As System.Windows.Forms.Label
    Friend WithEvents lblShipperNum As System.Windows.Forms.Label
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents txtRcvdBy As System.Windows.Forms.TextBox
    Friend WithEvents txtEntryDate As System.Windows.Forms.TextBox
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents cboShipped As System.Windows.Forms.CheckBox
    Friend WithEvents grpShipperInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblMHSJob As System.Windows.Forms.Label
    Friend WithEvents cmbMHSJob As System.Windows.Forms.ComboBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVia As System.Windows.Forms.Label
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents eDTPShipDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ckbMMM As System.Windows.Forms.CheckBox
    Friend WithEvents ckbActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblCompDate As System.Windows.Forms.Label
    Friend WithEvents lblStateNum As System.Windows.Forms.Label
    Friend WithEvents lblProjNum As System.Windows.Forms.Label
    Friend WithEvents lblCustJob As System.Windows.Forms.Label
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents grpProject As System.Windows.Forms.GroupBox
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
End Class
