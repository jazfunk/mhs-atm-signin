<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewShipper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewShipper))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblShipperNum = New System.Windows.Forms.Label
        Me.lblMHSJob = New System.Windows.Forms.Label
        Me.txtMHSJob = New System.Windows.Forms.TextBox
        Me.cboShipped = New System.Windows.Forms.CheckBox
        Me.lblShipDate = New System.Windows.Forms.Label
        Me.txtShipDate = New System.Windows.Forms.TextBox
        Me.lblRecBy = New System.Windows.Forms.Label
        Me.txtRecBy = New System.Windows.Forms.TextBox
        Me.lblEntryDate = New System.Windows.Forms.Label
        Me.lblComments = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.grpNewshipper = New System.Windows.Forms.GroupBox
        Me.lblPO = New System.Windows.Forms.Label
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.lblShipperID = New System.Windows.Forms.Label
        Me.lblVia = New System.Windows.Forms.Label
        Me.txtVia = New System.Windows.Forms.TextBox
        Me.btnAddItems = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAddShipper = New System.Windows.Forms.Button
        Me.btnEnable = New System.Windows.Forms.Button
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.cmbMhsJob = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.grpNewshipper.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 289)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(422, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'lblShipperNum
        '
        Me.lblShipperNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipperNum.Location = New System.Drawing.Point(270, 18)
        Me.lblShipperNum.Name = "lblShipperNum"
        Me.lblShipperNum.Size = New System.Drawing.Size(116, 13)
        Me.lblShipperNum.TabIndex = 15
        Me.lblShipperNum.Text = "Next Shipper #"
        Me.lblShipperNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMHSJob
        '
        Me.lblMHSJob.AutoSize = True
        Me.lblMHSJob.Location = New System.Drawing.Point(12, 37)
        Me.lblMHSJob.Name = "lblMHSJob"
        Me.lblMHSJob.Size = New System.Drawing.Size(61, 13)
        Me.lblMHSJob.TabIndex = 12
        Me.lblMHSJob.Text = "MHS Job #"
        '
        'txtMHSJob
        '
        Me.txtMHSJob.BackColor = System.Drawing.Color.White
        Me.txtMHSJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMHSJob.ForeColor = System.Drawing.Color.Black
        Me.txtMHSJob.Location = New System.Drawing.Point(441, 85)
        Me.txtMHSJob.Name = "txtMHSJob"
        Me.txtMHSJob.Size = New System.Drawing.Size(131, 44)
        Me.txtMHSJob.TabIndex = 3
        Me.txtMHSJob.TabStop = False
        Me.txtMHSJob.Text = "M10-03"
        Me.txtMHSJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboShipped
        '
        Me.cboShipped.AutoSize = True
        Me.cboShipped.Location = New System.Drawing.Point(321, 357)
        Me.cboShipped.Name = "cboShipped"
        Me.cboShipped.Size = New System.Drawing.Size(65, 17)
        Me.cboShipped.TabIndex = 17
        Me.cboShipped.TabStop = False
        Me.cboShipped.Text = "Shipped"
        Me.cboShipped.UseVisualStyleBackColor = True
        '
        'lblShipDate
        '
        Me.lblShipDate.AutoSize = True
        Me.lblShipDate.Location = New System.Drawing.Point(226, 325)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(54, 13)
        Me.lblShipDate.TabIndex = 21
        Me.lblShipDate.Text = "Ship Date"
        '
        'txtShipDate
        '
        Me.txtShipDate.Location = New System.Drawing.Point(286, 322)
        Me.txtShipDate.Name = "txtShipDate"
        Me.txtShipDate.Size = New System.Drawing.Size(100, 20)
        Me.txtShipDate.TabIndex = 19
        Me.txtShipDate.TabStop = False
        '
        'lblRecBy
        '
        Me.lblRecBy.AutoSize = True
        Me.lblRecBy.Location = New System.Drawing.Point(212, 299)
        Me.lblRecBy.Name = "lblRecBy"
        Me.lblRecBy.Size = New System.Drawing.Size(68, 13)
        Me.lblRecBy.TabIndex = 20
        Me.lblRecBy.Text = "Received By"
        '
        'txtRecBy
        '
        Me.txtRecBy.Location = New System.Drawing.Point(286, 296)
        Me.txtRecBy.Name = "txtRecBy"
        Me.txtRecBy.Size = New System.Drawing.Size(100, 20)
        Me.txtRecBy.TabIndex = 18
        Me.txtRecBy.TabStop = False
        '
        'lblEntryDate
        '
        Me.lblEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntryDate.Location = New System.Drawing.Point(243, 127)
        Me.lblEntryDate.Name = "lblEntryDate"
        Me.lblEntryDate.Size = New System.Drawing.Size(143, 32)
        Me.lblEntryDate.TabIndex = 11
        Me.lblEntryDate.Text = "Entry Date"
        Me.lblEntryDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(34, 188)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(56, 13)
        Me.lblComments.TabIndex = 13
        Me.lblComments.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(96, 188)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(290, 39)
        Me.txtComments.TabIndex = 3
        '
        'grpNewshipper
        '
        Me.grpNewshipper.BackColor = System.Drawing.Color.Transparent
        Me.grpNewshipper.Controls.Add(Me.lblPO)
        Me.grpNewshipper.Controls.Add(Me.txtPO)
        Me.grpNewshipper.Controls.Add(Me.lblShipperID)
        Me.grpNewshipper.Controls.Add(Me.lblVia)
        Me.grpNewshipper.Controls.Add(Me.txtVia)
        Me.grpNewshipper.Controls.Add(Me.btnAddItems)
        Me.grpNewshipper.Controls.Add(Me.btnCancel)
        Me.grpNewshipper.Controls.Add(Me.btnAddShipper)
        Me.grpNewshipper.Controls.Add(Me.btnEnable)
        Me.grpNewshipper.Controls.Add(Me.lblJobDesc)
        Me.grpNewshipper.Controls.Add(Me.txtMHSJob)
        Me.grpNewshipper.Controls.Add(Me.cmbMhsJob)
        Me.grpNewshipper.Controls.Add(Me.txtComments)
        Me.grpNewshipper.Controls.Add(Me.lblComments)
        Me.grpNewshipper.Controls.Add(Me.lblShipperNum)
        Me.grpNewshipper.Controls.Add(Me.lblEntryDate)
        Me.grpNewshipper.Controls.Add(Me.lblMHSJob)
        Me.grpNewshipper.Controls.Add(Me.lblRecBy)
        Me.grpNewshipper.Controls.Add(Me.cboShipped)
        Me.grpNewshipper.Controls.Add(Me.txtRecBy)
        Me.grpNewshipper.Controls.Add(Me.txtShipDate)
        Me.grpNewshipper.Controls.Add(Me.lblShipDate)
        Me.grpNewshipper.Location = New System.Drawing.Point(12, 12)
        Me.grpNewshipper.Name = "grpNewshipper"
        Me.grpNewshipper.Size = New System.Drawing.Size(398, 267)
        Me.grpNewshipper.TabIndex = 0
        Me.grpNewshipper.TabStop = False
        Me.grpNewshipper.Text = "Shipper Details"
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.Location = New System.Drawing.Point(68, 139)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(22, 13)
        Me.lblPO.TabIndex = 27
        Me.lblPO.Text = "PO"
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(96, 136)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.ReadOnly = True
        Me.txtPO.Size = New System.Drawing.Size(65, 20)
        Me.txtPO.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtPO, "Click to change")
        '
        'lblShipperID
        '
        Me.lblShipperID.Font = New System.Drawing.Font("Trebuchet MS", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipperID.ForeColor = System.Drawing.Color.Blue
        Me.lblShipperID.Location = New System.Drawing.Point(268, 37)
        Me.lblShipperID.Margin = New System.Windows.Forms.Padding(0)
        Me.lblShipperID.Name = "lblShipperID"
        Me.lblShipperID.Size = New System.Drawing.Size(118, 37)
        Me.lblShipperID.TabIndex = 14
        Me.lblShipperID.Text = "5000"
        Me.lblShipperID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVia
        '
        Me.lblVia.AutoSize = True
        Me.lblVia.Location = New System.Drawing.Point(68, 165)
        Me.lblVia.Name = "lblVia"
        Me.lblVia.Size = New System.Drawing.Size(22, 13)
        Me.lblVia.TabIndex = 22
        Me.lblVia.Text = "Via"
        '
        'txtVia
        '
        Me.txtVia.Location = New System.Drawing.Point(96, 162)
        Me.txtVia.Name = "txtVia"
        Me.txtVia.Size = New System.Drawing.Size(290, 20)
        Me.txtVia.TabIndex = 2
        '
        'btnAddItems
        '
        Me.btnAddItems.Enabled = False
        Me.btnAddItems.Location = New System.Drawing.Point(149, 232)
        Me.btnAddItems.Name = "btnAddItems"
        Me.btnAddItems.Size = New System.Drawing.Size(75, 23)
        Me.btnAddItems.TabIndex = 5
        Me.btnAddItems.Text = "Add Items"
        Me.btnAddItems.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(311, 232)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddShipper
        '
        Me.btnAddShipper.Enabled = False
        Me.btnAddShipper.Location = New System.Drawing.Point(230, 232)
        Me.btnAddShipper.Name = "btnAddShipper"
        Me.btnAddShipper.Size = New System.Drawing.Size(75, 23)
        Me.btnAddShipper.TabIndex = 4
        Me.btnAddShipper.Text = "Add Shipper"
        Me.btnAddShipper.UseVisualStyleBackColor = True
        '
        'btnEnable
        '
        Me.btnEnable.Location = New System.Drawing.Point(149, 51)
        Me.btnEnable.Name = "btnEnable"
        Me.btnEnable.Size = New System.Drawing.Size(116, 23)
        Me.btnEnable.TabIndex = 1
        Me.btnEnable.Text = "Assign Shipper"
        Me.btnEnable.UseVisualStyleBackColor = True
        '
        'lblJobDesc
        '
        Me.lblJobDesc.Font = New System.Drawing.Font("Trebuchet MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJobDesc.Location = New System.Drawing.Point(6, 77)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(380, 43)
        Me.lblJobDesc.TabIndex = 16
        Me.lblJobDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMhsJob
        '
        Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMhsJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMhsJob.FormattingEnabled = True
        Me.cmbMhsJob.Location = New System.Drawing.Point(15, 53)
        Me.cmbMhsJob.Name = "cmbMhsJob"
        Me.cmbMhsJob.Size = New System.Drawing.Size(128, 21)
        Me.cmbMhsJob.TabIndex = 0
        '
        'frmNewShipper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(422, 311)
        Me.Controls.Add(Me.grpNewshipper)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNewShipper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Shipper"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpNewshipper.ResumeLayout(False)
        Me.grpNewshipper.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblShipperNum As System.Windows.Forms.Label
    Friend WithEvents lblMHSJob As System.Windows.Forms.Label
    Friend WithEvents txtMHSJob As System.Windows.Forms.TextBox
    Friend WithEvents cboShipped As System.Windows.Forms.CheckBox
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents txtShipDate As System.Windows.Forms.TextBox
    Friend WithEvents lblRecBy As System.Windows.Forms.Label
    Friend WithEvents txtRecBy As System.Windows.Forms.TextBox
    Friend WithEvents lblEntryDate As System.Windows.Forms.Label
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents grpNewshipper As System.Windows.Forms.GroupBox
    Friend WithEvents lblShipperID As System.Windows.Forms.Label
    Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
    Friend WithEvents btnEnable As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddShipper As System.Windows.Forms.Button
    Friend WithEvents btnAddItems As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblVia As System.Windows.Forms.Label
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
End Class
