﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmATMdbTesting
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmATMdbTesting))
		Me.ListBox1 = New System.Windows.Forms.ListBox
		Me.Button1 = New System.Windows.Forms.Button
		Me.ComboBox1 = New System.Windows.Forms.ComboBox
		Me.ComboBox2 = New System.Windows.Forms.ComboBox
		Me.SuspendLayout()
		'
		'ListBox1
		'
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(35, 25)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(120, 472)
		Me.ListBox1.TabIndex = 0
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(182, 25)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = "Button1"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'ComboBox1
		'
		Me.ComboBox1.FormattingEnabled = True
		Me.ComboBox1.Location = New System.Drawing.Point(301, 106)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
		Me.ComboBox1.TabIndex = 2
		'
		'ComboBox2
		'
		Me.ComboBox2.FormattingEnabled = True
		Me.ComboBox2.Location = New System.Drawing.Point(439, 106)
		Me.ComboBox2.Name = "ComboBox2"
		Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
		Me.ComboBox2.TabIndex = 3
		'
		'frmATMdbTesting
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(838, 543)
		Me.Controls.Add(Me.ComboBox2)
		Me.Controls.Add(Me.ComboBox1)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.ListBox1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmATMdbTesting"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ATM Database Testing"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
	Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
End Class
