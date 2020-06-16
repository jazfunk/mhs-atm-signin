<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisiSelect
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
		Me.btnRed = New System.Windows.Forms.Button
		Me.btnYellow = New System.Windows.Forms.Button
		Me.btnWhite = New System.Windows.Forms.Button
		Me.Button1 = New System.Windows.Forms.Button
		Me.Button2 = New System.Windows.Forms.Button
		Me.Button3 = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'btnRed
		'
		Me.btnRed.BackColor = System.Drawing.Color.Red
		Me.btnRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 63.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRed.Location = New System.Drawing.Point(70, 287)
		Me.btnRed.Name = "btnRed"
		Me.btnRed.Size = New System.Drawing.Size(150, 100)
		Me.btnRed.TabIndex = 0
		Me.btnRed.Text = "R"
		Me.btnRed.UseVisualStyleBackColor = False
		'
		'btnYellow
		'
		Me.btnYellow.BackColor = System.Drawing.Color.Yellow
		Me.btnYellow.Font = New System.Drawing.Font("Microsoft Sans Serif", 63.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnYellow.Location = New System.Drawing.Point(220, 287)
		Me.btnYellow.Name = "btnYellow"
		Me.btnYellow.Size = New System.Drawing.Size(150, 100)
		Me.btnYellow.TabIndex = 1
		Me.btnYellow.Text = "Y"
		Me.btnYellow.UseVisualStyleBackColor = False
		'
		'btnWhite
		'
		Me.btnWhite.BackColor = System.Drawing.Color.White
		Me.btnWhite.Font = New System.Drawing.Font("Microsoft Sans Serif", 63.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnWhite.Location = New System.Drawing.Point(370, 287)
		Me.btnWhite.Name = "btnWhite"
		Me.btnWhite.Size = New System.Drawing.Size(150, 100)
		Me.btnWhite.TabIndex = 2
		Me.btnWhite.Text = "W"
		Me.btnWhite.UseVisualStyleBackColor = False
		'
		'Button1
		'
		Me.Button1.BackColor = System.Drawing.Color.White
		Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button1.Location = New System.Drawing.Point(337, 103)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(32, 32)
		Me.Button1.TabIndex = 5
		Me.Button1.Text = "W"
		Me.Button1.UseVisualStyleBackColor = False
		'
		'Button2
		'
		Me.Button2.BackColor = System.Drawing.Color.Yellow
		Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button2.Location = New System.Drawing.Point(305, 103)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(32, 32)
		Me.Button2.TabIndex = 4
		Me.Button2.Text = "Y"
		Me.Button2.UseVisualStyleBackColor = False
		'
		'Button3
		'
		Me.Button3.BackColor = System.Drawing.Color.Red
		Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button3.Location = New System.Drawing.Point(273, 103)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(32, 32)
		Me.Button3.TabIndex = 3
		Me.Button3.Text = "R"
		Me.Button3.UseVisualStyleBackColor = False
		'
		'frmVisiSelect
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(919, 534)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.btnWhite)
		Me.Controls.Add(Me.btnYellow)
		Me.Controls.Add(Me.btnRed)
		Me.Name = "frmVisiSelect"
		Me.Text = "Visi-Strip Parameters Selection"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnRed As System.Windows.Forms.Button
	Friend WithEvents btnYellow As System.Windows.Forms.Button
	Friend WithEvents btnWhite As System.Windows.Forms.Button
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
