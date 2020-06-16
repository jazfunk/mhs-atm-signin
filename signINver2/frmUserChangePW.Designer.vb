<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmUserChangePW
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserChangePW))
		Me.Cancel = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.PasswordTextBox = New System.Windows.Forms.TextBox
		Me.UsernameTextBox = New System.Windows.Forms.TextBox
		Me.PasswordLabel = New System.Windows.Forms.Label
		Me.UsernameLabel = New System.Windows.Forms.Label
		Me.txtNewPassword = New System.Windows.Forms.TextBox
		Me.lblNewPassword = New System.Windows.Forms.Label
		Me.txtConfirmNewPassword = New System.Windows.Forms.TextBox
		Me.lblConfirmPassword = New System.Windows.Forms.Label
		Me.SuspendLayout()
		'
		'Cancel
		'
		Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel.Location = New System.Drawing.Point(44, 249)
		Me.Cancel.Name = "Cancel"
		Me.Cancel.Size = New System.Drawing.Size(65, 23)
		Me.Cancel.TabIndex = 4
		Me.Cancel.Text = "Cancel"
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(115, 249)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(65, 23)
		Me.btnOK.TabIndex = 3
		Me.btnOK.Text = "OK"
		'
		'PasswordTextBox
		'
		Me.PasswordTextBox.Location = New System.Drawing.Point(28, 100)
		Me.PasswordTextBox.Name = "PasswordTextBox"
		Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.PasswordTextBox.Size = New System.Drawing.Size(169, 20)
		Me.PasswordTextBox.TabIndex = 0
		'
		'UsernameTextBox
		'
		Me.UsernameTextBox.BackColor = System.Drawing.Color.WhiteSmoke
		Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UsernameTextBox.Location = New System.Drawing.Point(29, 57)
		Me.UsernameTextBox.Name = "UsernameTextBox"
		Me.UsernameTextBox.ReadOnly = True
		Me.UsernameTextBox.Size = New System.Drawing.Size(166, 20)
		Me.UsernameTextBox.TabIndex = 5
		Me.UsernameTextBox.TabStop = False
		'
		'PasswordLabel
		'
		Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
		Me.PasswordLabel.Location = New System.Drawing.Point(26, 80)
		Me.PasswordLabel.Name = "PasswordLabel"
		Me.PasswordLabel.Size = New System.Drawing.Size(169, 23)
		Me.PasswordLabel.TabIndex = 11
		Me.PasswordLabel.Text = "Old Password"
		Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'UsernameLabel
		'
		Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
		Me.UsernameLabel.Location = New System.Drawing.Point(27, 37)
		Me.UsernameLabel.Name = "UsernameLabel"
		Me.UsernameLabel.Size = New System.Drawing.Size(169, 23)
		Me.UsernameLabel.TabIndex = 10
		Me.UsernameLabel.Text = "&User name"
		Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtNewPassword
		'
		Me.txtNewPassword.Location = New System.Drawing.Point(28, 155)
		Me.txtNewPassword.Name = "txtNewPassword"
		Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.txtNewPassword.Size = New System.Drawing.Size(169, 20)
		Me.txtNewPassword.TabIndex = 1
		'
		'lblNewPassword
		'
		Me.lblNewPassword.BackColor = System.Drawing.Color.Transparent
		Me.lblNewPassword.Location = New System.Drawing.Point(26, 135)
		Me.lblNewPassword.Name = "lblNewPassword"
		Me.lblNewPassword.Size = New System.Drawing.Size(169, 23)
		Me.lblNewPassword.TabIndex = 14
		Me.lblNewPassword.Text = "New Password"
		Me.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtConfirmNewPassword
		'
		Me.txtConfirmNewPassword.Location = New System.Drawing.Point(27, 198)
		Me.txtConfirmNewPassword.Name = "txtConfirmNewPassword"
		Me.txtConfirmNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.txtConfirmNewPassword.Size = New System.Drawing.Size(169, 20)
		Me.txtConfirmNewPassword.TabIndex = 2
		'
		'lblConfirmPassword
		'
		Me.lblConfirmPassword.BackColor = System.Drawing.Color.Transparent
		Me.lblConfirmPassword.Location = New System.Drawing.Point(25, 178)
		Me.lblConfirmPassword.Name = "lblConfirmPassword"
		Me.lblConfirmPassword.Size = New System.Drawing.Size(169, 23)
		Me.lblConfirmPassword.TabIndex = 16
		Me.lblConfirmPassword.Text = "Confirm Password"
		Me.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'frmUserChangePW
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.BackgroundImage = Global.signINver2.My.Resources.Resources.sI_Splash_EXP
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.CancelButton = Me.Cancel
		Me.ClientSize = New System.Drawing.Size(496, 303)
		Me.Controls.Add(Me.txtConfirmNewPassword)
		Me.Controls.Add(Me.lblConfirmPassword)
		Me.Controls.Add(Me.txtNewPassword)
		Me.Controls.Add(Me.lblNewPassword)
		Me.Controls.Add(Me.Cancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.PasswordTextBox)
		Me.Controls.Add(Me.UsernameTextBox)
		Me.Controls.Add(Me.PasswordLabel)
		Me.Controls.Add(Me.UsernameLabel)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmUserChangePW"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "frmEditUser"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents txtConfirmNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label

End Class
