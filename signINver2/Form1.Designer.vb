<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.VisualStudiosTabControl1 = New signINver2.VisualStudiosTabControl
        Me.sTabHome = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
        Me.sTabPreferences = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.sTabUsers = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
        Me.sTabCustomers = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
        Me.sTabManage = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
        Me.sTab = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
        Me.VisualStudiosTabControl1.SuspendLayout()
        Me.sTabPreferences.SuspendLayout()
        Me.SuspendLayout()
        '
        'VisualStudiosTabControl1
        '
        Me.VisualStudiosTabControl1.AutoSize = True
        Me.VisualStudiosTabControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.VisualStudiosTabControl1.Controls.Add(Me.sTabHome)
        Me.VisualStudiosTabControl1.Controls.Add(Me.sTabPreferences)
        Me.VisualStudiosTabControl1.Controls.Add(Me.sTabUsers)
        Me.VisualStudiosTabControl1.Controls.Add(Me.sTabCustomers)
        Me.VisualStudiosTabControl1.Controls.Add(Me.sTabManage)
        Me.VisualStudiosTabControl1.Controls.Add(Me.sTab)
        Me.VisualStudiosTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VisualStudiosTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.VisualStudiosTabControl1.Name = "VisualStudiosTabControl1"
        Me.VisualStudiosTabControl1.SelectedTabPage = Me.sTabHome
        Me.VisualStudiosTabControl1.Size = New System.Drawing.Size(794, 507)
        Me.VisualStudiosTabControl1.Skin.TabControl.DividerSkin.BottomColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabControl.DividerSkin.DrawDividers = True
        Me.VisualStudiosTabControl1.Skin.TabControl.DividerSkin.TopColor = System.Drawing.Color.White
        Me.VisualStudiosTabControl1.Skin.TabControl.GlyphSkin.GlyphBorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabControl.GlyphSkin.GlyphColor = System.Drawing.Color.Black
        Me.VisualStudiosTabControl1.Skin.TabControl.GlyphSkin.GlyphHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabControl.InnerBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabControl.InnerBorderColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabControl.OuterBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabControl.OuterBorderColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.FontSettings.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.FontSettings.FontColor = System.Drawing.SystemColors.ControlText
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.GradientSettings.EndColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.GradientSettings.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.GradientSettings.StartColor = System.Drawing.Color.White
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.TabBorderColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.TabRightBorderColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.TabTipColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.MouseHoverTabPage.TabTipInnerColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.FontSettings.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.FontSettings.FontColor = System.Drawing.SystemColors.ControlText
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.GradientSettings.EndColor = System.Drawing.Color.White
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.GradientSettings.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.GradientSettings.StartColor = System.Drawing.Color.White
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.TabBorderColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.TabRightBorderColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.TabTipColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.SelectedTabPage.TabTipInnerColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.UnselectedTabPage.FontSettings.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.VisualStudiosTabControl1.Skin.TabPage.UnselectedTabPage.FontSettings.FontColor = System.Drawing.SystemColors.ControlText
        Me.VisualStudiosTabControl1.Skin.TabPage.UnselectedTabPage.GradientSettings.EndColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.VisualStudiosTabControl1.Skin.TabPage.UnselectedTabPage.GradientSettings.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.VisualStudiosTabControl1.Skin.TabPage.UnselectedTabPage.GradientSettings.StartColor = System.Drawing.Color.White
        Me.VisualStudiosTabControl1.TabIndex = 1
        '
        'sTabHome
        '
        Me.sTabHome.AutoScroll = True
        Me.sTabHome.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.sTabHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.sTabHome.ImageKey = Nothing
        Me.sTabHome.Location = New System.Drawing.Point(101, 6)
        Me.sTabHome.Name = "sTabHome"
        Me.sTabHome.Padding = New System.Windows.Forms.Padding(6)
        Me.sTabHome.Size = New System.Drawing.Size(687, 495)
        Me.sTabHome.Text = "Home"
        '
        'sTabPreferences
        '
        Me.sTabPreferences.AutoScroll = True
        Me.sTabPreferences.Controls.Add(Me.Panel1)
        Me.sTabPreferences.ImageKey = Nothing
        Me.sTabPreferences.Location = New System.Drawing.Point(101, 6)
        Me.sTabPreferences.Name = "sTabPreferences"
        Me.sTabPreferences.Padding = New System.Windows.Forms.Padding(6)
        Me.sTabPreferences.Size = New System.Drawing.Size(687, 495)
        Me.sTabPreferences.Text = "Preferences"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 483)
        Me.Panel1.TabIndex = 0
        '
        'sTabUsers
        '
        Me.sTabUsers.AutoScroll = True
        Me.sTabUsers.ImageKey = Nothing
        Me.sTabUsers.Location = New System.Drawing.Point(101, 6)
        Me.sTabUsers.Name = "sTabUsers"
        Me.sTabUsers.Padding = New System.Windows.Forms.Padding(6)
        Me.sTabUsers.Size = New System.Drawing.Size(687, 495)
        Me.sTabUsers.Text = "Users"
        '
        'sTabCustomers
        '
        Me.sTabCustomers.AutoScroll = True
        Me.sTabCustomers.ImageKey = Nothing
        Me.sTabCustomers.Location = New System.Drawing.Point(101, 6)
        Me.sTabCustomers.Name = "sTabCustomers"
        Me.sTabCustomers.Padding = New System.Windows.Forms.Padding(6)
        Me.sTabCustomers.Size = New System.Drawing.Size(687, 495)
        Me.sTabCustomers.Text = "Customers"
        '
        'sTabManage
        '
        Me.sTabManage.AutoScroll = True
        Me.sTabManage.ImageKey = Nothing
        Me.sTabManage.Location = New System.Drawing.Point(101, 6)
        Me.sTabManage.Name = "sTabManage"
        Me.sTabManage.Padding = New System.Windows.Forms.Padding(6)
        Me.sTabManage.Size = New System.Drawing.Size(687, 495)
        Me.sTabManage.Text = "Manage"
        '
        'sTab
        '
        Me.sTab.AutoScroll = True
        Me.sTab.ImageKey = Nothing
        Me.sTab.Location = New System.Drawing.Point(101, 6)
        Me.sTab.Name = "sTab"
        Me.sTab.Padding = New System.Windows.Forms.Padding(6)
        Me.sTab.Size = New System.Drawing.Size(687, 495)
        Me.sTab.Text = "TabPage1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(794, 507)
        Me.Controls.Add(Me.VisualStudiosTabControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.VisualStudiosTabControl1.ResumeLayout(False)
        Me.sTabPreferences.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStudiosTabControl1 As signINver2.VisualStudiosTabControl
    Friend sTabHome As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
    Friend sTabPreferences As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
    Friend sTabUsers As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
    Friend sTabCustomers As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
    Friend sTabManage As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
    Friend sTab As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
