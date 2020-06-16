<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsersList
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.drpUsers = New Microsoft.VisualBasic.PowerPacks.DataRepeater
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.drpUsers.ItemTemplate.SuspendLayout()
        Me.drpUsers.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.drpUsers)
        Me.SplitContainer1.Size = New System.Drawing.Size(556, 577)
        Me.SplitContainer1.SplitterDistance = 100
        Me.SplitContainer1.TabIndex = 0
        '
        'drpUsers
        '
        Me.drpUsers.AllowUserToAddItems = False
        Me.drpUsers.AllowUserToDeleteItems = False
        Me.drpUsers.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.drpUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.drpUsers.ItemHeaderVisible = False
        '
        'drpUsers.ItemTemplate
        '
        Me.drpUsers.ItemTemplate.BackColor = System.Drawing.Color.White
        Me.drpUsers.ItemTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.drpUsers.ItemTemplate.Controls.Add(Me.TextBox6)
        Me.drpUsers.ItemTemplate.Controls.Add(Me.TextBox5)
        Me.drpUsers.ItemTemplate.Controls.Add(Me.TextBox3)
        Me.drpUsers.ItemTemplate.Controls.Add(Me.TextBox4)
        Me.drpUsers.ItemTemplate.Controls.Add(Me.TextBox2)
        Me.drpUsers.ItemTemplate.Controls.Add(Me.TextBox1)
        Me.drpUsers.ItemTemplate.Margin = New System.Windows.Forms.Padding(1)
        Me.drpUsers.ItemTemplate.Size = New System.Drawing.Size(454, 100)
        Me.drpUsers.Location = New System.Drawing.Point(76, 21)
        Me.drpUsers.Margin = New System.Windows.Forms.Padding(1)
        Me.drpUsers.Name = "drpUsers"
        Me.drpUsers.Padding = New System.Windows.Forms.Padding(1)
        Me.drpUsers.Size = New System.Drawing.Size(458, 392)
        Me.drpUsers.TabIndex = 0
        Me.drpUsers.Text = "Users List"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(163, 66)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(100, 20)
        Me.TextBox6.TabIndex = 5
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(163, 40)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(163, 14)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(57, 66)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(57, 40)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(57, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        '
        'frmUsersList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(556, 577)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Name = "frmUsersList"
        Me.Text = "Users"
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.drpUsers.ItemTemplate.ResumeLayout(False)
        Me.drpUsers.ItemTemplate.PerformLayout()
        Me.drpUsers.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents drpUsers As Microsoft.VisualBasic.PowerPacks.DataRepeater
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
