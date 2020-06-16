<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm
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
	Friend WithEvents PasswordLabel As System.Windows.Forms.Label
	Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
		Me.PasswordLabel = New System.Windows.Forms.Label
		Me.PasswordTextBox = New System.Windows.Forms.TextBox
		Me.OK = New System.Windows.Forms.Button
		Me.Cancel = New System.Windows.Forms.Button
		Me.cmbUsers = New System.Windows.Forms.ComboBox
		Me.SuspendLayout()
		'
		'PasswordLabel
		'
		Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
		Me.PasswordLabel.Location = New System.Drawing.Point(27, 126)
		Me.PasswordLabel.Name = "PasswordLabel"
		Me.PasswordLabel.Size = New System.Drawing.Size(169, 23)
		Me.PasswordLabel.TabIndex = 5
		Me.PasswordLabel.Text = "&Password"
		Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'PasswordTextBox
		'
		Me.PasswordTextBox.Location = New System.Drawing.Point(29, 146)
		Me.PasswordTextBox.Name = "PasswordTextBox"
		Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.PasswordTextBox.Size = New System.Drawing.Size(169, 20)
		Me.PasswordTextBox.TabIndex = 1
		'
		'OK
		'
		Me.OK.Location = New System.Drawing.Point(426, 275)
		Me.OK.Name = "OK"
		Me.OK.Size = New System.Drawing.Size(65, 23)
		Me.OK.TabIndex = 2
		Me.OK.Text = "Login"
		'
		'Cancel
		'
		Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel.Location = New System.Drawing.Point(355, 275)
		Me.Cancel.Name = "Cancel"
		Me.Cancel.Size = New System.Drawing.Size(65, 23)
		Me.Cancel.TabIndex = 3
		Me.Cancel.Text = "Cancel"
		'
		'cmbUsers
		'
		Me.cmbUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbUsers.FormattingEnabled = True
		Me.cmbUsers.Location = New System.Drawing.Point(29, 95)
		Me.cmbUsers.Name = "cmbUsers"
		Me.cmbUsers.Size = New System.Drawing.Size(169, 28)
		Me.cmbUsers.TabIndex = 7
		'
		'LoginForm
		'
		Me.AcceptButton = Me.OK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.BackgroundImage = Global.signINver2.My.Resources.Resources.sI_Splash_EXP
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.CancelButton = Me.Cancel
		Me.ClientSize = New System.Drawing.Size(496, 303)
		Me.Controls.Add(Me.cmbUsers)
		Me.Controls.Add(Me.Cancel)
		Me.Controls.Add(Me.OK)
		Me.Controls.Add(Me.PasswordTextBox)
		Me.Controls.Add(Me.PasswordLabel)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "LoginForm"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Enter your user name and password"
		Me.TopMost = True
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents cmbUsers As System.Windows.Forms.ComboBox

End Class
