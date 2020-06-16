<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSalvageSign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSalvageSign))
        Me.txtSignType = New System.Windows.Forms.TextBox
        Me.txtAtmJob = New System.Windows.Forms.TextBox
        Me.cmbSignType = New System.Windows.Forms.ComboBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.grpSignSize = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSignWidth = New System.Windows.Forms.Label
        Me.txtSignWidth = New System.Windows.Forms.TextBox
        Me.txtSignHeight = New System.Windows.Forms.TextBox
        Me.lblSignHeight = New System.Windows.Forms.Label
        Me.lblLocation = New System.Windows.Forms.Label
        Me.lblRcvDate = New System.Windows.Forms.Label
        Me.txtStation = New System.Windows.Forms.TextBox
        Me.lblStation = New System.Windows.Forms.Label
        Me.lblSignType = New System.Windows.Forms.Label
        Me.lblAtmJob = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.eDtpRecvDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker
        Me.btnListing = New System.Windows.Forms.Button
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.cmbAtmJob = New System.Windows.Forms.ComboBox
        Me.cmbStation = New System.Windows.Forms.ComboBox
        Me.txtReceivedFrom = New System.Windows.Forms.TextBox
        Me.lblRcvdFrom = New System.Windows.Forms.Label
        Me.txtRcvdLocation = New System.Windows.Forms.TextBox
        Me.grpSignSize.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSignType
        '
        Me.txtSignType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignType.Location = New System.Drawing.Point(15, 187)
        Me.txtSignType.Name = "txtSignType"
        Me.txtSignType.Size = New System.Drawing.Size(226, 20)
        Me.txtSignType.TabIndex = 6
        '
        'txtAtmJob
        '
        Me.txtAtmJob.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAtmJob.Location = New System.Drawing.Point(15, 25)
        Me.txtAtmJob.Name = "txtAtmJob"
        Me.txtAtmJob.Size = New System.Drawing.Size(86, 20)
        Me.txtAtmJob.TabIndex = 1
        '
        'cmbSignType
        '
        Me.cmbSignType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSignType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSignType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbSignType.DropDownHeight = 124
        Me.cmbSignType.FormattingEnabled = True
        Me.cmbSignType.IntegralHeight = False
        Me.cmbSignType.Items.AddRange(New Object() {"Extruded", "Plywood", "Flatsheet .080", "Flatsheet .125", "Other"})
        Me.cmbSignType.Location = New System.Drawing.Point(15, 213)
        Me.cmbSignType.Name = "cmbSignType"
        Me.cmbSignType.Size = New System.Drawing.Size(226, 21)
        Me.cmbSignType.TabIndex = 5
        Me.cmbSignType.Text = "Select Sign Type"
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLocation.Location = New System.Drawing.Point(15, 283)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(226, 20)
        Me.txtLocation.TabIndex = 8
        '
        'grpSignSize
        '
        Me.grpSignSize.BackColor = System.Drawing.Color.Transparent
        Me.grpSignSize.Controls.Add(Me.Label2)
        Me.grpSignSize.Controls.Add(Me.Label1)
        Me.grpSignSize.Controls.Add(Me.lblSignWidth)
        Me.grpSignSize.Controls.Add(Me.txtSignWidth)
        Me.grpSignSize.Controls.Add(Me.txtSignHeight)
        Me.grpSignSize.Controls.Add(Me.lblSignHeight)
        Me.grpSignSize.Location = New System.Drawing.Point(15, 336)
        Me.grpSignSize.Name = "grpSignSize"
        Me.grpSignSize.Size = New System.Drawing.Size(226, 108)
        Me.grpSignSize.TabIndex = 9
        Me.grpSignSize.TabStop = False
        Me.grpSignSize.Text = "Sign Dimensions"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(22, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Use either Feet or Inches"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(103, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "x"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSignWidth
        '
        Me.lblSignWidth.AutoSize = True
        Me.lblSignWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblSignWidth.Location = New System.Drawing.Point(22, 27)
        Me.lblSignWidth.Name = "lblSignWidth"
        Me.lblSignWidth.Size = New System.Drawing.Size(59, 13)
        Me.lblSignWidth.TabIndex = 34
        Me.lblSignWidth.Text = "Sign Width"
        Me.lblSignWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSignWidth
        '
        Me.txtSignWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignWidth.ForeColor = System.Drawing.Color.Black
        Me.txtSignWidth.Location = New System.Drawing.Point(25, 43)
        Me.txtSignWidth.Name = "txtSignWidth"
        Me.txtSignWidth.Size = New System.Drawing.Size(72, 29)
        Me.txtSignWidth.TabIndex = 0
        Me.txtSignWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSignHeight
        '
        Me.txtSignHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignHeight.ForeColor = System.Drawing.Color.Black
        Me.txtSignHeight.Location = New System.Drawing.Point(124, 43)
        Me.txtSignHeight.Name = "txtSignHeight"
        Me.txtSignHeight.Size = New System.Drawing.Size(73, 29)
        Me.txtSignHeight.TabIndex = 1
        Me.txtSignHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSignHeight
        '
        Me.lblSignHeight.AutoSize = True
        Me.lblSignHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblSignHeight.Location = New System.Drawing.Point(137, 27)
        Me.lblSignHeight.Name = "lblSignHeight"
        Me.lblSignHeight.Size = New System.Drawing.Size(62, 13)
        Me.lblSignHeight.TabIndex = 38
        Me.lblSignHeight.Text = "Sign Height"
        Me.lblSignHeight.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Location = New System.Drawing.Point(12, 241)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(48, 13)
        Me.lblLocation.TabIndex = 132
        Me.lblLocation.Text = "Location"
        '
        'lblRcvDate
        '
        Me.lblRcvDate.AutoSize = True
        Me.lblRcvDate.BackColor = System.Drawing.Color.Transparent
        Me.lblRcvDate.Location = New System.Drawing.Point(12, 447)
        Me.lblRcvDate.Name = "lblRcvDate"
        Me.lblRcvDate.Size = New System.Drawing.Size(79, 13)
        Me.lblRcvDate.TabIndex = 131
        Me.lblRcvDate.Text = "Received Date"
        '
        'txtStation
        '
        Me.txtStation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStation.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtStation.Location = New System.Drawing.Point(15, 68)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(226, 26)
        Me.txtStation.TabIndex = 3
        Me.txtStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.BackColor = System.Drawing.Color.Transparent
        Me.lblStation.Location = New System.Drawing.Point(12, 52)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 129
        Me.lblStation.Text = "Station"
        '
        'lblSignType
        '
        Me.lblSignType.AutoSize = True
        Me.lblSignType.BackColor = System.Drawing.Color.Transparent
        Me.lblSignType.Location = New System.Drawing.Point(12, 171)
        Me.lblSignType.Name = "lblSignType"
        Me.lblSignType.Size = New System.Drawing.Size(55, 13)
        Me.lblSignType.TabIndex = 128
        Me.lblSignType.Text = "Sign Type"
        '
        'lblAtmJob
        '
        Me.lblAtmJob.AutoSize = True
        Me.lblAtmJob.BackColor = System.Drawing.Color.Transparent
        Me.lblAtmJob.Location = New System.Drawing.Point(12, 9)
        Me.lblAtmJob.Name = "lblAtmJob"
        Me.lblAtmJob.Size = New System.Drawing.Size(57, 13)
        Me.lblAtmJob.TabIndex = 127
        Me.lblAtmJob.Text = "ATM Job#"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(15, 509)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(222, 46)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(15, 561)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(222, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 627)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(258, 22)
        Me.StatusStrip1.TabIndex = 134
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'eDtpRecvDate
        '
        Me.eDtpRecvDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpRecvDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eDtpRecvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpRecvDate.Location = New System.Drawing.Point(15, 463)
        Me.eDtpRecvDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpRecvDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpRecvDate.Name = "eDtpRecvDate"
        Me.eDtpRecvDate.Size = New System.Drawing.Size(222, 40)
        Me.eDtpRecvDate.TabIndex = 10
        Me.eDtpRecvDate.Value = New Date(2010, 3, 19, 0, 0, 0, 0)
        '
        'btnListing
        '
        Me.btnListing.Location = New System.Drawing.Point(15, 590)
        Me.btnListing.Name = "btnListing"
        Me.btnListing.Size = New System.Drawing.Size(222, 23)
        Me.btnListing.TabIndex = 12
        Me.btnListing.Text = "View Listing"
        Me.btnListing.UseVisualStyleBackColor = True
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbLocation.DropDownHeight = 124
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.IntegralHeight = False
        Me.cmbLocation.Items.AddRange(New Object() {"Shop", "Barn", "Rack", "Other"})
        Me.cmbLocation.Location = New System.Drawing.Point(15, 309)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(226, 21)
        Me.cmbLocation.TabIndex = 7
        Me.cmbLocation.Text = "Select Storage Location"
        '
        'cmbAtmJob
        '
        Me.cmbAtmJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbAtmJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAtmJob.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbAtmJob.DropDownHeight = 124
        Me.cmbAtmJob.FormattingEnabled = True
        Me.cmbAtmJob.IntegralHeight = False
        Me.cmbAtmJob.Location = New System.Drawing.Point(107, 24)
        Me.cmbAtmJob.Name = "cmbAtmJob"
        Me.cmbAtmJob.Size = New System.Drawing.Size(134, 21)
        Me.cmbAtmJob.TabIndex = 0
        Me.cmbAtmJob.Text = "Select ATM Job"
        '
        'cmbStation
        '
        Me.cmbStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbStation.DropDownHeight = 124
        Me.cmbStation.FormattingEnabled = True
        Me.cmbStation.IntegralHeight = False
        Me.cmbStation.Location = New System.Drawing.Point(15, 100)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(226, 21)
        Me.cmbStation.TabIndex = 2
        Me.cmbStation.Text = "Select Station Number"
        '
        'txtReceivedFrom
        '
        Me.txtReceivedFrom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtReceivedFrom.Location = New System.Drawing.Point(15, 144)
        Me.txtReceivedFrom.Name = "txtReceivedFrom"
        Me.txtReceivedFrom.Size = New System.Drawing.Size(226, 20)
        Me.txtReceivedFrom.TabIndex = 4
        '
        'lblRcvdFrom
        '
        Me.lblRcvdFrom.AutoSize = True
        Me.lblRcvdFrom.BackColor = System.Drawing.Color.Transparent
        Me.lblRcvdFrom.Location = New System.Drawing.Point(12, 128)
        Me.lblRcvdFrom.Name = "lblRcvdFrom"
        Me.lblRcvdFrom.Size = New System.Drawing.Size(79, 13)
        Me.lblRcvdFrom.TabIndex = 136
        Me.lblRcvdFrom.Text = "Received From"
        '
        'txtRcvdLocation
        '
        Me.txtRcvdLocation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRcvdLocation.Enabled = False
        Me.txtRcvdLocation.Location = New System.Drawing.Point(15, 257)
        Me.txtRcvdLocation.Name = "txtRcvdLocation"
        Me.txtRcvdLocation.Size = New System.Drawing.Size(226, 20)
        Me.txtRcvdLocation.TabIndex = 137
        '
        'frmNewSalvageSign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(258, 649)
        Me.Controls.Add(Me.txtRcvdLocation)
        Me.Controls.Add(Me.txtReceivedFrom)
        Me.Controls.Add(Me.lblRcvdFrom)
        Me.Controls.Add(Me.cmbStation)
        Me.Controls.Add(Me.cmbAtmJob)
        Me.Controls.Add(Me.cmbLocation)
        Me.Controls.Add(Me.btnListing)
        Me.Controls.Add(Me.eDtpRecvDate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtSignType)
        Me.Controls.Add(Me.txtAtmJob)
        Me.Controls.Add(Me.cmbSignType)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.grpSignSize)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblRcvDate)
        Me.Controls.Add(Me.txtStation)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lblSignType)
        Me.Controls.Add(Me.lblAtmJob)
        Me.Controls.Add(Me.btnOK)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmNewSalvageSign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive Salvage Sign"
        Me.grpSignSize.ResumeLayout(False)
        Me.grpSignSize.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSignType As System.Windows.Forms.TextBox
    Friend WithEvents txtAtmJob As System.Windows.Forms.TextBox
    Friend WithEvents cmbSignType As System.Windows.Forms.ComboBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents grpSignSize As System.Windows.Forms.GroupBox
    Friend WithEvents lblSignWidth As System.Windows.Forms.Label
    Friend WithEvents txtSignWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtSignHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblSignHeight As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblRcvDate As System.Windows.Forms.Label
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblSignType As System.Windows.Forms.Label
    Friend WithEvents lblAtmJob As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents eDtpRecvDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents btnListing As System.Windows.Forms.Button
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAtmJob As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStation As System.Windows.Forms.ComboBox
    Friend WithEvents txtReceivedFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblRcvdFrom As System.Windows.Forms.Label
    Friend WithEvents txtRcvdLocation As System.Windows.Forms.TextBox
End Class
