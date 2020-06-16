<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewCust
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewCust))
        Me.txtCust = New System.Windows.Forms.TextBox
        Me.lblCust = New System.Windows.Forms.Label
        Me.lblCustFull = New System.Windows.Forms.Label
        Me.txtCustFull = New System.Windows.Forms.TextBox
        Me.lblAddress1 = New System.Windows.Forms.Label
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.lblAddress2 = New System.Windows.Forms.Label
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.lblStateZip = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.lblPhone = New System.Windows.Forms.Label
        Me.lblFax = New System.Windows.Forms.Label
        Me.lblWeb = New System.Windows.Forms.Label
        Me.txtWeb = New System.Windows.Forms.TextBox
        Me.lblEmail = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.lblContact = New System.Windows.Forms.Label
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.mtxtPhone = New System.Windows.Forms.MaskedTextBox
        Me.mtxtFax = New System.Windows.Forms.MaskedTextBox
        Me.mtxtZip = New System.Windows.Forms.MaskedTextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BalloonToolTip1 = New QSS.Components.Windows.Forms.BalloonToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCust
        '
        Me.txtCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(78, 14)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.Size = New System.Drawing.Size(67, 26)
        Me.txtCust.TabIndex = 0
        Me.txtCust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BalloonToolTip1.SetToolTip(Me.txtCust, "Must be a unique, typically 3-Digit ID.  This ID is how all Data is related to th" & _
                "is customer.  Choose wisely.")
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.BackColor = System.Drawing.Color.Transparent
        Me.lblCust.Location = New System.Drawing.Point(30, 22)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(42, 13)
        Me.lblCust.TabIndex = 1
        Me.lblCust.Text = "Cust ID"
        '
        'lblCustFull
        '
        Me.lblCustFull.AutoSize = True
        Me.lblCustFull.BackColor = System.Drawing.Color.Transparent
        Me.lblCustFull.Location = New System.Drawing.Point(21, 49)
        Me.lblCustFull.Name = "lblCustFull"
        Me.lblCustFull.Size = New System.Drawing.Size(51, 13)
        Me.lblCustFull.TabIndex = 3
        Me.lblCustFull.Text = "Customer"
        '
        'txtCustFull
        '
        Me.txtCustFull.Location = New System.Drawing.Point(78, 46)
        Me.txtCustFull.Name = "txtCustFull"
        Me.txtCustFull.Size = New System.Drawing.Size(206, 20)
        Me.txtCustFull.TabIndex = 1
        Me.BalloonToolTip1.SetToolTip(Me.txtCustFull, "Full Customer Name")
        '
        'lblAddress1
        '
        Me.lblAddress1.AutoSize = True
        Me.lblAddress1.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress1.Location = New System.Drawing.Point(18, 90)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(54, 13)
        Me.lblAddress1.TabIndex = 5
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(78, 87)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(206, 20)
        Me.txtAddress1.TabIndex = 2
        Me.BalloonToolTip1.SetToolTip(Me.txtAddress1, "Street Address")
        '
        'lblAddress2
        '
        Me.lblAddress2.AutoSize = True
        Me.lblAddress2.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress2.Location = New System.Drawing.Point(18, 116)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(54, 13)
        Me.lblAddress2.TabIndex = 7
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(78, 113)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(206, 20)
        Me.txtAddress2.TabIndex = 3
        Me.BalloonToolTip1.SetToolTip(Me.txtAddress2, "Extended Address")
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.BackColor = System.Drawing.Color.Transparent
        Me.lblCity.Location = New System.Drawing.Point(48, 142)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(24, 13)
        Me.lblCity.TabIndex = 9
        Me.lblCity.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(78, 139)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(206, 20)
        Me.txtCity.TabIndex = 4
        '
        'lblStateZip
        '
        Me.lblStateZip.AutoSize = True
        Me.lblStateZip.BackColor = System.Drawing.Color.Transparent
        Me.lblStateZip.Location = New System.Drawing.Point(20, 168)
        Me.lblStateZip.Name = "lblStateZip"
        Me.lblStateZip.Size = New System.Drawing.Size(52, 13)
        Me.lblStateZip.TabIndex = 11
        Me.lblStateZip.Text = "State/Zip"
        '
        'txtState
        '
        Me.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtState.Location = New System.Drawing.Point(78, 165)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(39, 20)
        Me.txtState.TabIndex = 5
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.BackColor = System.Drawing.Color.Transparent
        Me.lblPhone.Location = New System.Drawing.Point(34, 209)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(38, 13)
        Me.lblPhone.TabIndex = 15
        Me.lblPhone.Text = "Phone"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.BackColor = System.Drawing.Color.Transparent
        Me.lblFax.Location = New System.Drawing.Point(48, 235)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(24, 13)
        Me.lblFax.TabIndex = 17
        Me.lblFax.Text = "Fax"
        '
        'lblWeb
        '
        Me.lblWeb.AutoSize = True
        Me.lblWeb.BackColor = System.Drawing.Color.Transparent
        Me.lblWeb.Location = New System.Drawing.Point(42, 276)
        Me.lblWeb.Name = "lblWeb"
        Me.lblWeb.Size = New System.Drawing.Size(30, 13)
        Me.lblWeb.TabIndex = 19
        Me.lblWeb.Text = "Web"
        '
        'txtWeb
        '
        Me.txtWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeb.ForeColor = System.Drawing.Color.Blue
        Me.txtWeb.Location = New System.Drawing.Point(78, 273)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(206, 20)
        Me.txtWeb.TabIndex = 9
        Me.txtWeb.Text = "http://"
        Me.BalloonToolTip1.SetToolTip(Me.txtWeb, "Website address (if any)")
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Location = New System.Drawing.Point(40, 302)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 21
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(78, 299)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(206, 20)
        Me.txtEmail.TabIndex = 10
        Me.BalloonToolTip1.SetToolTip(Me.txtEmail, "Business or Contact eMail address.  Must be a valid eMail address.")
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.BackColor = System.Drawing.Color.Transparent
        Me.lblContact.Location = New System.Drawing.Point(28, 343)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(44, 13)
        Me.lblContact.TabIndex = 23
        Me.lblContact.Text = "Contact"
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(78, 340)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(206, 20)
        Me.txtContact.TabIndex = 11
        Me.BalloonToolTip1.SetToolTip(Me.txtContact, "Contact Person (if any)")
        '
        'mtxtPhone
        '
        Me.mtxtPhone.Location = New System.Drawing.Point(78, 206)
        Me.mtxtPhone.Mask = "(999) 000-0000"
        Me.mtxtPhone.Name = "mtxtPhone"
        Me.mtxtPhone.Size = New System.Drawing.Size(113, 20)
        Me.mtxtPhone.TabIndex = 7
        '
        'mtxtFax
        '
        Me.mtxtFax.Location = New System.Drawing.Point(78, 232)
        Me.mtxtFax.Mask = "(999) 000-0000"
        Me.mtxtFax.Name = "mtxtFax"
        Me.mtxtFax.Size = New System.Drawing.Size(113, 20)
        Me.mtxtFax.TabIndex = 8
        '
        'mtxtZip
        '
        Me.mtxtZip.Location = New System.Drawing.Point(123, 165)
        Me.mtxtZip.Mask = "00000-9999"
        Me.mtxtZip.Name = "mtxtZip"
        Me.mtxtZip.Size = New System.Drawing.Size(68, 20)
        Me.mtxtZip.TabIndex = 6
        Me.BalloonToolTip1.SetToolTip(Me.mtxtZip, "ZIP+4")
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(209, 386)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.BalloonToolTip1.SetToolTip(Me.btnAdd, "Add This Customer and close this window.")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(128, 386)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.BalloonToolTip1.SetToolTip(Me.btnCancel, "Cancel and close this window.")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = Global.signINver2.My.Resources.Resources.Customers_24
        Me.PictureBox1.Location = New System.Drawing.Point(248, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'BalloonToolTip1
        '
        Me.BalloonToolTip1.BalloonPosition = New System.Drawing.Point(0, 0)
        Me.BalloonToolTip1.Icon = QSS.Components.Windows.Forms.BalloonIcon.Information
        Me.BalloonToolTip1.Title = "Formatting Convention Tips"
        '
        'frmNewCust
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(296, 421)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.mtxtZip)
        Me.Controls.Add(Me.mtxtFax)
        Me.Controls.Add(Me.mtxtPhone)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblWeb)
        Me.Controls.Add(Me.txtWeb)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblStateZip)
        Me.Controls.Add(Me.txtState)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.lblAddress2)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.lblAddress1)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.lblCustFull)
        Me.Controls.Add(Me.txtCustFull)
        Me.Controls.Add(Me.lblCust)
        Me.Controls.Add(Me.txtCust)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNewCust"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Customer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents lblCustFull As System.Windows.Forms.Label
    Friend WithEvents txtCustFull As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblStateZip As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblWeb As System.Windows.Forms.Label
    Friend WithEvents txtWeb As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents mtxtPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtFax As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BalloonToolTip1 As QSS.Components.Windows.Forms.BalloonToolTip
End Class
