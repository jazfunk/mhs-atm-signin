<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCap
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
		Me.btnSave = New System.Windows.Forms.Button
		Me.picCapture = New System.Windows.Forms.PictureBox
		CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnSave
		'
		Me.btnSave.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSave.Location = New System.Drawing.Point(12, 358)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(632, 52)
		Me.btnSave.TabIndex = 1
		Me.btnSave.Text = "Save"
		Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'picCapture
		'
		Me.picCapture.Location = New System.Drawing.Point(12, 12)
		Me.picCapture.Name = "picCapture"
		Me.picCapture.Size = New System.Drawing.Size(632, 340)
		Me.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picCapture.TabIndex = 2
		Me.picCapture.TabStop = False
		'
		'frmCap
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(658, 422)
		Me.Controls.Add(Me.picCapture)
		Me.Controls.Add(Me.btnSave)
		Me.Name = "frmCap"
		Me.Text = "Capture Image"
		CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents picCapture As System.Windows.Forms.PictureBox
End Class
