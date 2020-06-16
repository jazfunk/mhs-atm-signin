<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSignCodeDetailsEntry
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSignCodeDetailsEntry))
		Me.lblSignsCode = New System.Windows.Forms.Label
		Me.txtCodeID = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.txtPdfTitle = New System.Windows.Forms.TextBox
		Me.txtType = New System.Windows.Forms.TextBox
		Me.lblPdfTitle = New System.Windows.Forms.Label
		Me.lblDesc = New System.Windows.Forms.Label
		Me.lblType = New System.Windows.Forms.Label
		Me.btnSave = New System.Windows.Forms.Button
		Me.cmbSignCodes = New System.Windows.Forms.ComboBox
		Me.picSignImage = New System.Windows.Forms.PictureBox
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.btnForward = New System.Windows.Forms.Button
		Me.btnBack = New System.Windows.Forms.Button
		Me.btnEdit = New System.Windows.Forms.Button
		Me.btnAddNew = New System.Windows.Forms.Button
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.picPDFSheet = New System.Windows.Forms.PictureBox
		Me.dgvSignCodes = New System.Windows.Forms.DataGridView
		Me.BalloonToolTip1 = New QSS.Components.Windows.Forms.BalloonToolTip(Me.components)
		CType(Me.picSignImage, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.picPDFSheet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvSignCodes, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'lblSignsCode
		'
		Me.lblSignsCode.AutoSize = True
		Me.lblSignsCode.BackColor = System.Drawing.Color.Transparent
		Me.lblSignsCode.Location = New System.Drawing.Point(49, 34)
		Me.lblSignsCode.Name = "lblSignsCode"
		Me.lblSignsCode.Size = New System.Drawing.Size(56, 13)
		Me.lblSignsCode.TabIndex = 11
		Me.lblSignsCode.Text = "Sign Code"
		Me.lblSignsCode.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtCodeID
		'
		Me.txtCodeID.Location = New System.Drawing.Point(238, 31)
		Me.txtCodeID.Name = "txtCodeID"
		Me.txtCodeID.ReadOnly = True
		Me.txtCodeID.Size = New System.Drawing.Size(46, 20)
		Me.txtCodeID.TabIndex = 10
		Me.txtCodeID.TabStop = False
		Me.txtCodeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtDescription
		'
		Me.txtDescription.BackColor = System.Drawing.Color.White
		Me.txtDescription.Location = New System.Drawing.Point(13, 90)
		Me.txtDescription.Name = "txtDescription"
		Me.txtDescription.ReadOnly = True
		Me.txtDescription.Size = New System.Drawing.Size(219, 20)
		Me.txtDescription.TabIndex = 6
		'
		'txtPdfTitle
		'
		Me.txtPdfTitle.BackColor = System.Drawing.Color.White
		Me.txtPdfTitle.Location = New System.Drawing.Point(111, 116)
		Me.txtPdfTitle.Name = "txtPdfTitle"
		Me.txtPdfTitle.ReadOnly = True
		Me.txtPdfTitle.Size = New System.Drawing.Size(121, 20)
		Me.txtPdfTitle.TabIndex = 7
		'
		'txtType
		'
		Me.txtType.BackColor = System.Drawing.Color.White
		Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtType.Location = New System.Drawing.Point(169, 156)
		Me.txtType.Name = "txtType"
		Me.txtType.ReadOnly = True
		Me.txtType.Size = New System.Drawing.Size(63, 38)
		Me.txtType.TabIndex = 8
		Me.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'lblPdfTitle
		'
		Me.lblPdfTitle.AutoSize = True
		Me.lblPdfTitle.BackColor = System.Drawing.Color.Transparent
		Me.lblPdfTitle.Location = New System.Drawing.Point(57, 119)
		Me.lblPdfTitle.Name = "lblPdfTitle"
		Me.lblPdfTitle.Size = New System.Drawing.Size(48, 13)
		Me.lblPdfTitle.TabIndex = 13
		Me.lblPdfTitle.Text = ".pdf Title"
		'
		'lblDesc
		'
		Me.lblDesc.AutoSize = True
		Me.lblDesc.BackColor = System.Drawing.Color.Transparent
		Me.lblDesc.Location = New System.Drawing.Point(10, 74)
		Me.lblDesc.Name = "lblDesc"
		Me.lblDesc.Size = New System.Drawing.Size(60, 13)
		Me.lblDesc.TabIndex = 12
		Me.lblDesc.Text = "Description"
		'
		'lblType
		'
		Me.lblType.AutoSize = True
		Me.lblType.BackColor = System.Drawing.Color.Transparent
		Me.lblType.Location = New System.Drawing.Point(132, 174)
		Me.lblType.Name = "lblType"
		Me.lblType.Size = New System.Drawing.Size(31, 13)
		Me.lblType.TabIndex = 0
		Me.lblType.Text = "Type"
		'
		'btnSave
		'
		Me.btnSave.Enabled = False
		Me.btnSave.Location = New System.Drawing.Point(111, 269)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(121, 23)
		Me.btnSave.TabIndex = 2
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'cmbSignCodes
		'
		Me.cmbSignCodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbSignCodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSignCodes.BackColor = System.Drawing.Color.White
		Me.cmbSignCodes.DropDownHeight = 300
		Me.cmbSignCodes.FormattingEnabled = True
		Me.cmbSignCodes.IntegralHeight = False
		Me.cmbSignCodes.Location = New System.Drawing.Point(111, 31)
		Me.cmbSignCodes.Name = "cmbSignCodes"
		Me.cmbSignCodes.Size = New System.Drawing.Size(121, 21)
		Me.cmbSignCodes.TabIndex = 5
		'
		'picSignImage
		'
		Me.picSignImage.BackColor = System.Drawing.Color.White
		Me.picSignImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picSignImage.Location = New System.Drawing.Point(238, 90)
		Me.picSignImage.Name = "picSignImage"
		Me.picSignImage.Size = New System.Drawing.Size(189, 173)
		Me.picSignImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picSignImage.TabIndex = 50
		Me.picSignImage.TabStop = False
		Me.BalloonToolTip1.SetToolTip(Me.picSignImage, "Spec Sheet Viewing has been disabled.")
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 317)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(842, 22)
		Me.StatusStrip1.TabIndex = 51
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
		Me.ToolStripStatusLabel1.Text = "Ready"
		'
		'btnForward
		'
		Me.btnForward.Location = New System.Drawing.Point(335, 269)
		Me.btnForward.Name = "btnForward"
		Me.btnForward.Size = New System.Drawing.Size(77, 23)
		Me.btnForward.TabIndex = 4
		Me.btnForward.Text = ">>"
		Me.btnForward.UseVisualStyleBackColor = True
		'
		'btnBack
		'
		Me.btnBack.Location = New System.Drawing.Point(252, 269)
		Me.btnBack.Name = "btnBack"
		Me.btnBack.Size = New System.Drawing.Size(77, 23)
		Me.btnBack.TabIndex = 3
		Me.btnBack.Text = "<<"
		Me.btnBack.UseVisualStyleBackColor = True
		'
		'btnEdit
		'
		Me.btnEdit.Location = New System.Drawing.Point(111, 211)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(121, 23)
		Me.btnEdit.TabIndex = 0
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'btnAddNew
		'
		Me.btnAddNew.Location = New System.Drawing.Point(111, 240)
		Me.btnAddNew.Name = "btnAddNew"
		Me.btnAddNew.Size = New System.Drawing.Size(121, 23)
		Me.btnAddNew.TabIndex = 1
		Me.btnAddNew.Text = "New"
		Me.btnAddNew.UseVisualStyleBackColor = True
		'
		'SplitContainer1
		'
		Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.SplitContainer1.Panel1.Controls.Add(Me.picPDFSheet)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblSignsCode)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddNew)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtCodeID)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnEdit)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtDescription)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnBack)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtPdfTitle)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnForward)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtType)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblDesc)
		Me.SplitContainer1.Panel1.Controls.Add(Me.picSignImage)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblPdfTitle)
		Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSignCodes)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblType)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnSave)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.dgvSignCodes)
		Me.SplitContainer1.Size = New System.Drawing.Size(842, 317)
		Me.SplitContainer1.SplitterDistance = 450
		Me.SplitContainer1.TabIndex = 0
		'
		'picPDFSheet
		'
		Me.picPDFSheet.Image = Global.signINver2.My.Resources.Resources.PDF_641
		Me.picPDFSheet.Location = New System.Drawing.Point(363, 20)
		Me.picPDFSheet.Name = "picPDFSheet"
		Me.picPDFSheet.Size = New System.Drawing.Size(64, 64)
		Me.picPDFSheet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picPDFSheet.TabIndex = 54
		Me.picPDFSheet.TabStop = False
		Me.BalloonToolTip1.SetToolTip(Me.picPDFSheet, "Spec Sheet Viewing has been disabled.")
		'
		'dgvSignCodes
		'
		Me.dgvSignCodes.AllowUserToOrderColumns = True
		Me.dgvSignCodes.AllowUserToResizeRows = False
		Me.dgvSignCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvSignCodes.BackgroundColor = System.Drawing.Color.White
		Me.dgvSignCodes.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dgvSignCodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvSignCodes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvSignCodes.ColumnHeadersHeight = 18
		Me.dgvSignCodes.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvSignCodes.EnableHeadersVisualStyles = False
		Me.dgvSignCodes.GridColor = System.Drawing.Color.WhiteSmoke
		Me.dgvSignCodes.Location = New System.Drawing.Point(0, 0)
		Me.dgvSignCodes.Name = "dgvSignCodes"
		Me.dgvSignCodes.RowHeadersVisible = False
		Me.dgvSignCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvSignCodes.Size = New System.Drawing.Size(388, 317)
		Me.dgvSignCodes.TabIndex = 0
		Me.dgvSignCodes.TabStop = False
		'
		'BalloonToolTip1
		'
		Me.BalloonToolTip1.BalloonPosition = New System.Drawing.Point(0, 0)
		Me.BalloonToolTip1.Icon = QSS.Components.Windows.Forms.BalloonIcon.Information
		'
		'frmNewSignCodeDetailsEntry
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.WhiteSmoke
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(842, 339)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.StatusStrip1)
		Me.DoubleBuffered = True
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmNewSignCodeDetailsEntry"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Manage Sign Code Data"
		CType(Me.picSignImage, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		CType(Me.picPDFSheet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvSignCodes, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents lblSignsCode As System.Windows.Forms.Label
    Friend WithEvents txtCodeID As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPdfTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents lblPdfTitle As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbSignCodes As System.Windows.Forms.ComboBox
    Friend WithEvents picSignImage As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnForward As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvSignCodes As System.Windows.Forms.DataGridView
    Friend WithEvents picPDFSheet As System.Windows.Forms.PictureBox
    Friend WithEvents BalloonToolTip1 As QSS.Components.Windows.Forms.BalloonToolTip
End Class
