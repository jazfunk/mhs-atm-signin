<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobLog))
        Me.cmbMhsJob = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.grpNewLog = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNewLog = New System.Windows.Forms.TextBox
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.dgvLogItems = New System.Windows.Forms.DataGridView
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.lblEditedBy = New System.Windows.Forms.Label
        Me.lblEditDate = New System.Windows.Forms.Label
        Me.grpLogControl = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMhsJob = New System.Windows.Forms.Label
        Me.lblCust = New System.Windows.Forms.Label
        Me.lblCustJob = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpNewLog.SuspendLayout()
        CType(Me.dgvLogItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLogControl.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMhsJob
        '
        Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMhsJob.DropDownHeight = 300
        Me.cmbMhsJob.FormattingEnabled = True
        Me.cmbMhsJob.IntegralHeight = False
        Me.cmbMhsJob.Location = New System.Drawing.Point(83, 23)
        Me.cmbMhsJob.Name = "cmbMhsJob"
        Me.cmbMhsJob.Size = New System.Drawing.Size(79, 21)
        Me.cmbMhsJob.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MHS Job#:"
        '
        'lblJobDesc
        '
        Me.lblJobDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblJobDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJobDesc.Location = New System.Drawing.Point(197, 31)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(365, 13)
        Me.lblJobDesc.TabIndex = 2
        Me.lblJobDesc.Text = "Job Description"
        Me.lblJobDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblDate.Location = New System.Drawing.Point(69, 37)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(175, 13)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Entry Date"
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(69, 50)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(175, 13)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "Entered By"
        '
        'grpNewLog
        '
        Me.grpNewLog.BackColor = System.Drawing.Color.Transparent
        Me.grpNewLog.Controls.Add(Me.Label6)
        Me.grpNewLog.Controls.Add(Me.btnAddNew)
        Me.grpNewLog.Controls.Add(Me.Label7)
        Me.grpNewLog.Controls.Add(Me.txtNewLog)
        Me.grpNewLog.Location = New System.Drawing.Point(12, 284)
        Me.grpNewLog.Name = "grpNewLog"
        Me.grpNewLog.Size = New System.Drawing.Size(454, 112)
        Me.grpNewLog.TabIndex = 5
        Me.grpNewLog.TabStop = False
        Me.grpNewLog.Text = "Enter New Log Item:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(258, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "User:"
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(355, 83)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(93, 23)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "Add New Log"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(292, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 12
        '
        'txtNewLog
        '
        Me.txtNewLog.Location = New System.Drawing.Point(6, 19)
        Me.txtNewLog.Multiline = True
        Me.txtNewLog.Name = "txtNewLog"
        Me.txtNewLog.Size = New System.Drawing.Size(224, 87)
        Me.txtNewLog.TabIndex = 0
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.SystemColors.Window
        Me.txtLog.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtLog.Location = New System.Drawing.Point(472, 60)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(250, 158)
        Me.txtLog.TabIndex = 7
        '
        'dgvLogItems
        '
        Me.dgvLogItems.AllowUserToAddRows = False
        Me.dgvLogItems.AllowUserToDeleteRows = False
        Me.dgvLogItems.AllowUserToOrderColumns = True
        Me.dgvLogItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvLogItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLogItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLogItems.ColumnHeadersHeight = 20
        Me.dgvLogItems.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvLogItems.Location = New System.Drawing.Point(12, 60)
        Me.dgvLogItems.Name = "dgvLogItems"
        Me.dgvLogItems.ReadOnly = True
        Me.dgvLogItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvLogItems.RowHeadersWidth = 12
        Me.dgvLogItems.Size = New System.Drawing.Size(454, 218)
        Me.dgvLogItems.TabIndex = 8
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(169, 143)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblEditedBy
        '
        Me.lblEditedBy.AutoSize = True
        Me.lblEditedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblEditedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditedBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEditedBy.Location = New System.Drawing.Point(68, 106)
        Me.lblEditedBy.Name = "lblEditedBy"
        Me.lblEditedBy.Size = New System.Drawing.Size(61, 13)
        Me.lblEditedBy.TabIndex = 10
        Me.lblEditedBy.Text = "Edited By"
        '
        'lblEditDate
        '
        Me.lblEditDate.AutoSize = True
        Me.lblEditDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEditDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditDate.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEditDate.Location = New System.Drawing.Point(69, 93)
        Me.lblEditDate.Name = "lblEditDate"
        Me.lblEditDate.Size = New System.Drawing.Size(60, 13)
        Me.lblEditDate.TabIndex = 9
        Me.lblEditDate.Text = "Edit Date"
        '
        'grpLogControl
        '
        Me.grpLogControl.BackColor = System.Drawing.Color.Transparent
        Me.grpLogControl.Controls.Add(Me.Label5)
        Me.grpLogControl.Controls.Add(Me.Label4)
        Me.grpLogControl.Controls.Add(Me.lblEditedBy)
        Me.grpLogControl.Controls.Add(Me.lblUser)
        Me.grpLogControl.Controls.Add(Me.Label3)
        Me.grpLogControl.Controls.Add(Me.lblEditDate)
        Me.grpLogControl.Controls.Add(Me.Label2)
        Me.grpLogControl.Controls.Add(Me.btnUpdate)
        Me.grpLogControl.Controls.Add(Me.lblDate)
        Me.grpLogControl.Location = New System.Drawing.Point(472, 224)
        Me.grpLogControl.Name = "grpLogControl"
        Me.grpLogControl.Size = New System.Drawing.Size(250, 172)
        Me.grpLogControl.TabIndex = 11
        Me.grpLogControl.TabStop = False
        Me.grpLogControl.Text = "Log Item Info:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(34, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "User:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last Edited:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(34, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "User:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Entry Date:"
        '
        'lblMhsJob
        '
        Me.lblMhsJob.BackColor = System.Drawing.Color.Transparent
        Me.lblMhsJob.Font = New System.Drawing.Font("Trebuchet MS", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMhsJob.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMhsJob.Location = New System.Drawing.Point(571, 9)
        Me.lblMhsJob.Name = "lblMhsJob"
        Me.lblMhsJob.Size = New System.Drawing.Size(154, 35)
        Me.lblMhsJob.TabIndex = 11
        Me.lblMhsJob.Text = "Job#"
        Me.lblMhsJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.BackColor = System.Drawing.Color.Transparent
        Me.lblCust.Location = New System.Drawing.Point(495, 9)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(30, 13)
        Me.lblCust.TabIndex = 12
        Me.lblCust.Text = "ATM"
        '
        'lblCustJob
        '
        Me.lblCustJob.AutoSize = True
        Me.lblCustJob.BackColor = System.Drawing.Color.Transparent
        Me.lblCustJob.Location = New System.Drawing.Point(531, 9)
        Me.lblCustJob.Name = "lblCustJob"
        Me.lblCustJob.Size = New System.Drawing.Size(31, 13)
        Me.lblCustJob.TabIndex = 13
        Me.lblCustJob.Text = "0848"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 411)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(737, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'frmJobLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(737, 433)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblCustJob)
        Me.Controls.Add(Me.lblCust)
        Me.Controls.Add(Me.lblMhsJob)
        Me.Controls.Add(Me.grpLogControl)
        Me.Controls.Add(Me.dgvLogItems)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.grpNewLog)
        Me.Controls.Add(Me.lblJobDesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMhsJob)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJobLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Log"
        Me.grpNewLog.ResumeLayout(False)
        Me.grpNewLog.PerformLayout()
        CType(Me.dgvLogItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLogControl.ResumeLayout(False)
        Me.grpLogControl.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents grpNewLog As System.Windows.Forms.GroupBox
    Friend WithEvents txtNewLog As System.Windows.Forms.TextBox
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents dgvLogItems As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblEditedBy As System.Windows.Forms.Label
    Friend WithEvents lblEditDate As System.Windows.Forms.Label
    Friend WithEvents grpLogControl As System.Windows.Forms.GroupBox
    Friend WithEvents lblMhsJob As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents lblCustJob As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
