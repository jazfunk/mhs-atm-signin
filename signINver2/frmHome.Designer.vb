<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
		Me.vsTabMain = New signINver2.VisualStudiosTabControl
		Me.sTabHome = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.picQRCode = New System.Windows.Forms.PictureBox
		Me.txtQRCodeResult = New System.Windows.Forms.TextBox
		Me.Button1 = New System.Windows.Forms.Button
		Me.sTabSigns = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabReports = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabInventory = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabProjects = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabCustomers = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabSalesOrders = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabPreferences = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.sTabManage = New signINver2.VisualStudiosTabControl.VisualStudiosTabPage
		Me.vsTabMain.SuspendLayout()
		Me.sTabHome.SuspendLayout()
		CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'vsTabMain
		'
		Me.vsTabMain.AutoSize = True
		Me.vsTabMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.vsTabMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.vsTabMain.Controls.Add(Me.sTabHome)
		Me.vsTabMain.Controls.Add(Me.sTabSigns)
		Me.vsTabMain.Controls.Add(Me.sTabReports)
		Me.vsTabMain.Controls.Add(Me.sTabInventory)
		Me.vsTabMain.Controls.Add(Me.sTabProjects)
		Me.vsTabMain.Controls.Add(Me.sTabCustomers)
		Me.vsTabMain.Controls.Add(Me.sTabSalesOrders)
		Me.vsTabMain.Controls.Add(Me.sTabPreferences)
		Me.vsTabMain.Controls.Add(Me.sTabManage)
		Me.vsTabMain.Dock = System.Windows.Forms.DockStyle.Fill
		Me.vsTabMain.Location = New System.Drawing.Point(0, 0)
		Me.vsTabMain.Name = "vsTabMain"
		Me.vsTabMain.SelectedTabPage = Me.sTabHome
		Me.vsTabMain.Size = New System.Drawing.Size(716, 500)
		Me.vsTabMain.Skin.TabControl.DividerSkin.BottomColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(229, Byte), Integer))
		Me.vsTabMain.Skin.TabControl.DividerSkin.DrawDividers = True
		Me.vsTabMain.Skin.TabControl.DividerSkin.TopColor = System.Drawing.Color.White
		Me.vsTabMain.Skin.TabControl.GlyphSkin.GlyphBorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(111, Byte), Integer))
		Me.vsTabMain.Skin.TabControl.GlyphSkin.GlyphColor = System.Drawing.Color.Black
		Me.vsTabMain.Skin.TabControl.GlyphSkin.GlyphHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(194, Byte), Integer))
		Me.vsTabMain.Skin.TabControl.InnerBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(227, Byte), Integer))
		Me.vsTabMain.Skin.TabControl.InnerBorderColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(162, Byte), Integer))
		Me.vsTabMain.Skin.TabControl.OuterBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
		Me.vsTabMain.Skin.TabControl.OuterBorderColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(180, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.FontSettings.Font = New System.Drawing.Font("Tahoma", 8.25!)
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.FontSettings.FontColor = System.Drawing.SystemColors.ControlText
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.GradientSettings.EndColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.GradientSettings.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.GradientSettings.StartColor = System.Drawing.Color.White
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.TabBorderColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(156, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.TabRightBorderColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(162, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.TabTipColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(44, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.MouseHoverTabPage.TabTipInnerColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(60, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.FontSettings.Font = New System.Drawing.Font("Tahoma", 8.25!)
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.FontSettings.FontColor = System.Drawing.SystemColors.ControlText
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.GradientSettings.EndColor = System.Drawing.Color.White
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.GradientSettings.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.GradientSettings.StartColor = System.Drawing.Color.White
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.TabBorderColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(156, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.TabRightBorderColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(204, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.TabTipColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(44, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.SelectedTabPage.TabTipInnerColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(60, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.UnselectedTabPage.FontSettings.Font = New System.Drawing.Font("Tahoma", 8.25!)
		Me.vsTabMain.Skin.TabPage.UnselectedTabPage.FontSettings.FontColor = System.Drawing.SystemColors.ControlText
		Me.vsTabMain.Skin.TabPage.UnselectedTabPage.GradientSettings.EndColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
		Me.vsTabMain.Skin.TabPage.UnselectedTabPage.GradientSettings.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
		Me.vsTabMain.Skin.TabPage.UnselectedTabPage.GradientSettings.StartColor = System.Drawing.Color.White
		Me.vsTabMain.TabIndex = 2
		'
		'sTabHome
		'
		Me.sTabHome.AutoScroll = True
		Me.sTabHome.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabHome.Controls.Add(Me.picQRCode)
		Me.sTabHome.Controls.Add(Me.txtQRCodeResult)
		Me.sTabHome.Controls.Add(Me.Button1)
		Me.sTabHome.ImageKey = Nothing
		Me.sTabHome.Location = New System.Drawing.Point(101, 6)
		Me.sTabHome.Name = "sTabHome"
		Me.sTabHome.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabHome.Size = New System.Drawing.Size(609, 488)
		Me.sTabHome.Text = "Home"
		'
		'picQRCode
		'
		Me.picQRCode.Location = New System.Drawing.Point(80, 68)
		Me.picQRCode.Name = "picQRCode"
		Me.picQRCode.Size = New System.Drawing.Size(350, 350)
		Me.picQRCode.TabIndex = 2
		Me.picQRCode.TabStop = False
		'
		'txtQRCodeResult
		'
		Me.txtQRCodeResult.Location = New System.Drawing.Point(51, 18)
		Me.txtQRCodeResult.Name = "txtQRCodeResult"
		Me.txtQRCodeResult.Size = New System.Drawing.Size(465, 20)
		Me.txtQRCodeResult.TabIndex = 1
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(525, 456)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Button1"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'sTabSigns
		'
		Me.sTabSigns.AutoScroll = True
		Me.sTabSigns.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabSigns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabSigns.ImageKey = Nothing
		Me.sTabSigns.Location = New System.Drawing.Point(101, 6)
		Me.sTabSigns.Name = "sTabSigns"
		Me.sTabSigns.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabSigns.Size = New System.Drawing.Size(609, 488)
		Me.sTabSigns.Text = "Signs"
		'
		'sTabReports
		'
		Me.sTabReports.AutoScroll = True
		Me.sTabReports.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabReports.ImageKey = Nothing
		Me.sTabReports.Location = New System.Drawing.Point(101, 6)
		Me.sTabReports.Name = "sTabReports"
		Me.sTabReports.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabReports.Size = New System.Drawing.Size(609, 488)
		Me.sTabReports.Text = "Reports"
		'
		'sTabInventory
		'
		Me.sTabInventory.AutoScroll = True
		Me.sTabInventory.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabInventory.ImageKey = Nothing
		Me.sTabInventory.Location = New System.Drawing.Point(101, 6)
		Me.sTabInventory.Name = "sTabInventory"
		Me.sTabInventory.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabInventory.Size = New System.Drawing.Size(609, 488)
		Me.sTabInventory.Text = "Inventory"
		'
		'sTabProjects
		'
		Me.sTabProjects.AutoScroll = True
		Me.sTabProjects.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabProjects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabProjects.ImageKey = Nothing
		Me.sTabProjects.Location = New System.Drawing.Point(101, 6)
		Me.sTabProjects.Name = "sTabProjects"
		Me.sTabProjects.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabProjects.Size = New System.Drawing.Size(609, 488)
		Me.sTabProjects.Text = "Projects"
		'
		'sTabCustomers
		'
		Me.sTabCustomers.AutoScroll = True
		Me.sTabCustomers.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabCustomers.ImageKey = Nothing
		Me.sTabCustomers.Location = New System.Drawing.Point(101, 6)
		Me.sTabCustomers.Name = "sTabCustomers"
		Me.sTabCustomers.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabCustomers.Size = New System.Drawing.Size(609, 488)
		Me.sTabCustomers.Text = "Customers"
		'
		'sTabSalesOrders
		'
		Me.sTabSalesOrders.AutoScroll = True
		Me.sTabSalesOrders.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabSalesOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabSalesOrders.ImageKey = Nothing
		Me.sTabSalesOrders.Location = New System.Drawing.Point(101, 6)
		Me.sTabSalesOrders.Name = "sTabSalesOrders"
		Me.sTabSalesOrders.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabSalesOrders.Size = New System.Drawing.Size(609, 488)
		Me.sTabSalesOrders.Text = "Sales"
		'
		'sTabPreferences
		'
		Me.sTabPreferences.AutoScroll = True
		Me.sTabPreferences.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabPreferences.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabPreferences.ImageKey = Nothing
		Me.sTabPreferences.Location = New System.Drawing.Point(101, 6)
		Me.sTabPreferences.Name = "sTabPreferences"
		Me.sTabPreferences.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabPreferences.Size = New System.Drawing.Size(609, 488)
		Me.sTabPreferences.Text = "Preferences"
		'
		'sTabManage
		'
		Me.sTabManage.AutoScroll = True
		Me.sTabManage.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.sTabManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.sTabManage.ImageKey = Nothing
		Me.sTabManage.Location = New System.Drawing.Point(101, 6)
		Me.sTabManage.Name = "sTabManage"
		Me.sTabManage.Padding = New System.Windows.Forms.Padding(6)
		Me.sTabManage.Size = New System.Drawing.Size(609, 488)
		Me.sTabManage.Text = "Manage"
		'
		'frmHome
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.ClientSize = New System.Drawing.Size(716, 500)
		Me.Controls.Add(Me.vsTabMain)
		Me.DoubleBuffered = True
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmHome"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "HOME"
		Me.vsTabMain.ResumeLayout(False)
		Me.sTabHome.ResumeLayout(False)
		Me.sTabHome.PerformLayout()
		CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents vsTabMain As signINver2.VisualStudiosTabControl
	Friend sTabHome As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabPreferences As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabSalesOrders As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabCustomers As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabManage As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabSigns As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabReports As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabInventory As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend sTabProjects As signINver2.VisualStudiosTabControl.VisualStudiosTabPage
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents txtQRCodeResult As System.Windows.Forms.TextBox
	Friend WithEvents picQRCode As System.Windows.Forms.PictureBox
End Class
