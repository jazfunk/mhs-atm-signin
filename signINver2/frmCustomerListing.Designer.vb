<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerListing))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnNew = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.mtxtZip = New System.Windows.Forms.MaskedTextBox
        Me.mtxtFax = New System.Windows.Forms.MaskedTextBox
        Me.mtxtPhone = New System.Windows.Forms.MaskedTextBox
        Me.lblContact = New System.Windows.Forms.Label
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.lblEmail = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.lblWeb = New System.Windows.Forms.Label
        Me.txtWeb = New System.Windows.Forms.TextBox
        Me.lblFax = New System.Windows.Forms.Label
        Me.lblPhone = New System.Windows.Forms.Label
        Me.lblStateZip = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.lblAddress2 = New System.Windows.Forms.Label
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.lblAddress1 = New System.Windows.Forms.Label
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.lblCustFull = New System.Windows.Forms.Label
        Me.txtCustFull = New System.Windows.Forms.TextBox
        Me.lblCust = New System.Windows.Forms.Label
        Me.txtCust = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvCustomers = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(1)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNew)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mtxtZip)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mtxtFax)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mtxtPhone)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtContact)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblEmail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEmail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblWeb)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtWeb)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFax)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblPhone)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblStateZip)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtState)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAddress2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAddress2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAddress1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAddress1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCustFull)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCustFull)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCust)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCust)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCustomers)
        Me.SplitContainer1.Size = New System.Drawing.Size(647, 531)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.TabIndex = 0
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(560, 103)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 49
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = Global.signINver2.My.Resources.Resources.Customers_24
        Me.PictureBox1.Location = New System.Drawing.Point(568, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(560, 158)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 48
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(560, 132)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 47
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'mtxtZip
        '
        Me.mtxtZip.Location = New System.Drawing.Point(120, 168)
        Me.mtxtZip.Mask = "00000-9999"
        Me.mtxtZip.Name = "mtxtZip"
        Me.mtxtZip.ReadOnly = True
        Me.mtxtZip.Size = New System.Drawing.Size(68, 20)
        Me.mtxtZip.TabIndex = 33
        '
        'mtxtFax
        '
        Me.mtxtFax.Location = New System.Drawing.Point(345, 52)
        Me.mtxtFax.Mask = "(999) 000-0000"
        Me.mtxtFax.Name = "mtxtFax"
        Me.mtxtFax.ReadOnly = True
        Me.mtxtFax.Size = New System.Drawing.Size(113, 20)
        Me.mtxtFax.TabIndex = 36
        '
        'mtxtPhone
        '
        Me.mtxtPhone.Location = New System.Drawing.Point(345, 26)
        Me.mtxtPhone.Mask = "(999) 000-0000"
        Me.mtxtPhone.Name = "mtxtPhone"
        Me.mtxtPhone.ReadOnly = True
        Me.mtxtPhone.Size = New System.Drawing.Size(113, 20)
        Me.mtxtPhone.TabIndex = 35
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.BackColor = System.Drawing.Color.Transparent
        Me.lblContact.Location = New System.Drawing.Point(295, 163)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(44, 13)
        Me.lblContact.TabIndex = 46
        Me.lblContact.Text = "Contact"
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(345, 160)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.Size = New System.Drawing.Size(206, 20)
        Me.txtContact.TabIndex = 40
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Location = New System.Drawing.Point(307, 122)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 45
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(345, 119)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(206, 20)
        Me.txtEmail.TabIndex = 39
        '
        'lblWeb
        '
        Me.lblWeb.AutoSize = True
        Me.lblWeb.BackColor = System.Drawing.Color.Transparent
        Me.lblWeb.Location = New System.Drawing.Point(309, 96)
        Me.lblWeb.Name = "lblWeb"
        Me.lblWeb.Size = New System.Drawing.Size(30, 13)
        Me.lblWeb.TabIndex = 44
        Me.lblWeb.Text = "Web"
        '
        'txtWeb
        '
        Me.txtWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeb.ForeColor = System.Drawing.Color.Blue
        Me.txtWeb.Location = New System.Drawing.Point(345, 93)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.ReadOnly = True
        Me.txtWeb.Size = New System.Drawing.Size(206, 20)
        Me.txtWeb.TabIndex = 38
        Me.txtWeb.Text = "http://"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.BackColor = System.Drawing.Color.Transparent
        Me.lblFax.Location = New System.Drawing.Point(315, 55)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(24, 13)
        Me.lblFax.TabIndex = 43
        Me.lblFax.Text = "Fax"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.BackColor = System.Drawing.Color.Transparent
        Me.lblPhone.Location = New System.Drawing.Point(301, 29)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(38, 13)
        Me.lblPhone.TabIndex = 42
        Me.lblPhone.Text = "Phone"
        '
        'lblStateZip
        '
        Me.lblStateZip.AutoSize = True
        Me.lblStateZip.BackColor = System.Drawing.Color.Transparent
        Me.lblStateZip.Location = New System.Drawing.Point(17, 171)
        Me.lblStateZip.Name = "lblStateZip"
        Me.lblStateZip.Size = New System.Drawing.Size(52, 13)
        Me.lblStateZip.TabIndex = 41
        Me.lblStateZip.Text = "State/Zip"
        '
        'txtState
        '
        Me.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtState.Location = New System.Drawing.Point(75, 168)
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.Size = New System.Drawing.Size(39, 20)
        Me.txtState.TabIndex = 31
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.BackColor = System.Drawing.Color.Transparent
        Me.lblCity.Location = New System.Drawing.Point(45, 145)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(24, 13)
        Me.lblCity.TabIndex = 37
        Me.lblCity.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(75, 142)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(206, 20)
        Me.txtCity.TabIndex = 30
        '
        'lblAddress2
        '
        Me.lblAddress2.AutoSize = True
        Me.lblAddress2.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress2.Location = New System.Drawing.Point(15, 119)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(54, 13)
        Me.lblAddress2.TabIndex = 34
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(75, 116)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(206, 20)
        Me.txtAddress2.TabIndex = 28
        '
        'lblAddress1
        '
        Me.lblAddress1.AutoSize = True
        Me.lblAddress1.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress1.Location = New System.Drawing.Point(15, 93)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(54, 13)
        Me.lblAddress1.TabIndex = 32
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(75, 90)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(206, 20)
        Me.txtAddress1.TabIndex = 27
        '
        'lblCustFull
        '
        Me.lblCustFull.AutoSize = True
        Me.lblCustFull.BackColor = System.Drawing.Color.Transparent
        Me.lblCustFull.Location = New System.Drawing.Point(18, 56)
        Me.lblCustFull.Name = "lblCustFull"
        Me.lblCustFull.Size = New System.Drawing.Size(51, 13)
        Me.lblCustFull.TabIndex = 29
        Me.lblCustFull.Text = "Customer"
        '
        'txtCustFull
        '
        Me.txtCustFull.Location = New System.Drawing.Point(75, 53)
        Me.txtCustFull.Name = "txtCustFull"
        Me.txtCustFull.ReadOnly = True
        Me.txtCustFull.Size = New System.Drawing.Size(206, 20)
        Me.txtCustFull.TabIndex = 25
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.BackColor = System.Drawing.Color.Transparent
        Me.lblCust.Location = New System.Drawing.Point(27, 29)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(42, 13)
        Me.lblCust.TabIndex = 26
        Me.lblCust.Text = "Cust ID"
        '
        'txtCust
        '
        Me.txtCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(75, 21)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.ReadOnly = True
        Me.txtCust.Size = New System.Drawing.Size(67, 26)
        Me.txtCust.TabIndex = 24
        Me.txtCust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 305)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(647, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'dgvCustomers
        '
        Me.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomers.BackgroundColor = System.Drawing.Color.White
        Me.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomers.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCustomers.EnableHeadersVisualStyles = False
        Me.dgvCustomers.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCustomers.Location = New System.Drawing.Point(0, 0)
        Me.dgvCustomers.Name = "dgvCustomers"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomers.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCustomers.RowHeadersVisible = False
        Me.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomers.Size = New System.Drawing.Size(647, 327)
        Me.dgvCustomers.TabIndex = 1
        Me.dgvCustomers.TabStop = False
        '
        'frmCustomerListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(647, 531)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCustomerListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Listing"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents mtxtZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtFax As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblWeb As System.Windows.Forms.Label
    Friend WithEvents txtWeb As System.Windows.Forms.TextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblStateZip As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCustFull As System.Windows.Forms.Label
    Friend WithEvents txtCustFull As System.Windows.Forms.TextBox
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents dgvCustomers As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnNew As System.Windows.Forms.Button
End Class
