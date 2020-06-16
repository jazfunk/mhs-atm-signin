<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignCheck
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
		Me.btnJobList = New System.Windows.Forms.Button
		Me.btnSignType = New System.Windows.Forms.Button
		Me.btnStationList = New System.Windows.Forms.Button
		Me.btnSignTech = New System.Windows.Forms.Button
		Me.btnBuildDate = New System.Windows.Forms.Button
		Me.btnPic = New System.Windows.Forms.Button
		Me.btnStandard = New System.Windows.Forms.Button
		Me.pnlControl = New System.Windows.Forms.Panel
		Me.txtSignTech = New System.Windows.Forms.TextBox
		Me.txtBuildDate = New System.Windows.Forms.TextBox
		Me.btnStationStatus = New System.Windows.Forms.Button
		Me.txtLegendDetails = New System.Windows.Forms.TextBox
		Me.btnApprove = New System.Windows.Forms.Button
		Me.txtSheeting = New System.Windows.Forms.TextBox
		Me.btnAddInfo = New System.Windows.Forms.Button
		Me.txtSignType = New System.Windows.Forms.TextBox
		Me.txtSignCode = New System.Windows.Forms.TextBox
		Me.txtStation = New System.Windows.Forms.TextBox
		Me.txtSignSize = New System.Windows.Forms.TextBox
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.txtStationID = New System.Windows.Forms.TextBox
		Me.picSign = New System.Windows.Forms.PictureBox
		Me.pnlControl.SuspendLayout()
		CType(Me.picSign, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnJobList
		'
		Me.btnJobList.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnJobList.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnJobList.Location = New System.Drawing.Point(3, 3)
		Me.btnJobList.Name = "btnJobList"
		Me.btnJobList.Size = New System.Drawing.Size(248, 66)
		Me.btnJobList.TabIndex = 0
		Me.btnJobList.Text = "Job Number"
		Me.btnJobList.UseVisualStyleBackColor = True
		'
		'btnSignType
		'
		Me.btnSignType.Enabled = False
		Me.btnSignType.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSignType.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnSignType.Location = New System.Drawing.Point(254, 3)
		Me.btnSignType.Name = "btnSignType"
		Me.btnSignType.Size = New System.Drawing.Size(248, 66)
		Me.btnSignType.TabIndex = 1
		Me.btnSignType.Text = "Sign Type"
		Me.btnSignType.UseVisualStyleBackColor = True
		'
		'btnStationList
		'
		Me.btnStationList.Enabled = False
		Me.btnStationList.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnStationList.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnStationList.Location = New System.Drawing.Point(3, 69)
		Me.btnStationList.Name = "btnStationList"
		Me.btnStationList.Size = New System.Drawing.Size(248, 66)
		Me.btnStationList.TabIndex = 2
		Me.btnStationList.Text = "Station Number"
		Me.btnStationList.UseVisualStyleBackColor = True
		'
		'btnSignTech
		'
		Me.btnSignTech.Enabled = False
		Me.btnSignTech.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSignTech.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnSignTech.Location = New System.Drawing.Point(3, 135)
		Me.btnSignTech.Name = "btnSignTech"
		Me.btnSignTech.Size = New System.Drawing.Size(248, 66)
		Me.btnSignTech.TabIndex = 3
		Me.btnSignTech.Text = "Sign Tech"
		Me.btnSignTech.UseVisualStyleBackColor = True
		'
		'btnBuildDate
		'
		Me.btnBuildDate.Enabled = False
		Me.btnBuildDate.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnBuildDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnBuildDate.Location = New System.Drawing.Point(254, 135)
		Me.btnBuildDate.Name = "btnBuildDate"
		Me.btnBuildDate.Size = New System.Drawing.Size(248, 66)
		Me.btnBuildDate.TabIndex = 4
		Me.btnBuildDate.Text = "Build Date"
		Me.btnBuildDate.UseVisualStyleBackColor = True
		'
		'btnPic
		'
		Me.btnPic.Enabled = False
		Me.btnPic.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPic.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnPic.Location = New System.Drawing.Point(3, 201)
		Me.btnPic.Name = "btnPic"
		Me.btnPic.Size = New System.Drawing.Size(248, 66)
		Me.btnPic.TabIndex = 5
		Me.btnPic.Text = "Snapshot"
		Me.btnPic.UseVisualStyleBackColor = True
		'
		'btnStandard
		'
		Me.btnStandard.Enabled = False
		Me.btnStandard.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnStandard.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnStandard.Location = New System.Drawing.Point(254, 69)
		Me.btnStandard.Name = "btnStandard"
		Me.btnStandard.Size = New System.Drawing.Size(248, 66)
		Me.btnStandard.TabIndex = 6
		Me.btnStandard.Text = "Standard Signs"
		Me.btnStandard.UseVisualStyleBackColor = True
		'
		'pnlControl
		'
		Me.pnlControl.BackColor = System.Drawing.Color.Transparent
		Me.pnlControl.Controls.Add(Me.txtSignTech)
		Me.pnlControl.Controls.Add(Me.txtBuildDate)
		Me.pnlControl.Controls.Add(Me.btnStationStatus)
		Me.pnlControl.Controls.Add(Me.txtLegendDetails)
		Me.pnlControl.Controls.Add(Me.btnApprove)
		Me.pnlControl.Controls.Add(Me.txtSheeting)
		Me.pnlControl.Controls.Add(Me.btnAddInfo)
		Me.pnlControl.Controls.Add(Me.txtSignType)
		Me.pnlControl.Controls.Add(Me.btnJobList)
		Me.pnlControl.Controls.Add(Me.btnStandard)
		Me.pnlControl.Controls.Add(Me.txtSignCode)
		Me.pnlControl.Controls.Add(Me.txtStation)
		Me.pnlControl.Controls.Add(Me.btnSignType)
		Me.pnlControl.Controls.Add(Me.btnPic)
		Me.pnlControl.Controls.Add(Me.txtSignSize)
		Me.pnlControl.Controls.Add(Me.btnStationList)
		Me.pnlControl.Controls.Add(Me.btnBuildDate)
		Me.pnlControl.Controls.Add(Me.btnSignTech)
		Me.pnlControl.Location = New System.Drawing.Point(600, 6)
		Me.pnlControl.Name = "pnlControl"
		Me.pnlControl.Size = New System.Drawing.Size(505, 481)
		Me.pnlControl.TabIndex = 7
		'
		'txtSignTech
		'
		Me.txtSignTech.Location = New System.Drawing.Point(348, 440)
		Me.txtSignTech.Name = "txtSignTech"
		Me.txtSignTech.Size = New System.Drawing.Size(154, 20)
		Me.txtSignTech.TabIndex = 161
		Me.txtSignTech.Text = "SignTech"
		'
		'txtBuildDate
		'
		Me.txtBuildDate.Location = New System.Drawing.Point(188, 440)
		Me.txtBuildDate.Name = "txtBuildDate"
		Me.txtBuildDate.Size = New System.Drawing.Size(154, 20)
		Me.txtBuildDate.TabIndex = 160
		Me.txtBuildDate.Text = "BuildDate"
		'
		'btnStationStatus
		'
		Me.btnStationStatus.BackColor = System.Drawing.Color.Transparent
		Me.btnStationStatus.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnStationStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnStationStatus.Location = New System.Drawing.Point(254, 369)
		Me.btnStationStatus.Margin = New System.Windows.Forms.Padding(1)
		Me.btnStationStatus.Name = "btnStationStatus"
		Me.btnStationStatus.Size = New System.Drawing.Size(248, 67)
		Me.btnStationStatus.TabIndex = 159
		Me.btnStationStatus.Text = "StationStatus"
		Me.btnStationStatus.UseVisualStyleBackColor = False
		'
		'txtLegendDetails
		'
		Me.txtLegendDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLegendDetails.Location = New System.Drawing.Point(3, 373)
		Me.txtLegendDetails.Name = "txtLegendDetails"
		Me.txtLegendDetails.Size = New System.Drawing.Size(247, 26)
		Me.txtLegendDetails.TabIndex = 158
		Me.txtLegendDetails.Text = "Legend Details"
		'
		'btnApprove
		'
		Me.btnApprove.BackColor = System.Drawing.Color.Transparent
		Me.btnApprove.Enabled = False
		Me.btnApprove.Font = New System.Drawing.Font("Wingdings", 72.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(2, Byte))
		Me.btnApprove.ForeColor = System.Drawing.Color.LimeGreen
		Me.btnApprove.Location = New System.Drawing.Point(254, 271)
		Me.btnApprove.Margin = New System.Windows.Forms.Padding(1)
		Me.btnApprove.Name = "btnApprove"
		Me.btnApprove.Size = New System.Drawing.Size(248, 96)
		Me.btnApprove.TabIndex = 157
		Me.btnApprove.Text = "ü"
		Me.btnApprove.UseVisualStyleBackColor = False
		'
		'txtSheeting
		'
		Me.txtSheeting.Location = New System.Drawing.Point(3, 405)
		Me.txtSheeting.Name = "txtSheeting"
		Me.txtSheeting.Size = New System.Drawing.Size(154, 20)
		Me.txtSheeting.TabIndex = 156
		Me.txtSheeting.Text = "Sheeting"
		'
		'btnAddInfo
		'
		Me.btnAddInfo.Enabled = False
		Me.btnAddInfo.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnAddInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark
		Me.btnAddInfo.Location = New System.Drawing.Point(254, 201)
		Me.btnAddInfo.Name = "btnAddInfo"
		Me.btnAddInfo.Size = New System.Drawing.Size(248, 66)
		Me.btnAddInfo.TabIndex = 156
		Me.btnAddInfo.Text = "Notes"
		Me.btnAddInfo.UseVisualStyleBackColor = True
		'
		'txtSignType
		'
		Me.txtSignType.Location = New System.Drawing.Point(163, 405)
		Me.txtSignType.Name = "txtSignType"
		Me.txtSignType.Size = New System.Drawing.Size(87, 20)
		Me.txtSignType.TabIndex = 154
		Me.txtSignType.Text = "Type"
		'
		'txtSignCode
		'
		Me.txtSignCode.BackColor = System.Drawing.SystemColors.Window
		Me.txtSignCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSignCode.Location = New System.Drawing.Point(3, 341)
		Me.txtSignCode.Name = "txtSignCode"
		Me.txtSignCode.Size = New System.Drawing.Size(247, 26)
		Me.txtSignCode.TabIndex = 153
		Me.txtSignCode.Text = "Code"
		'
		'txtStation
		'
		Me.txtStation.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtStation.Location = New System.Drawing.Point(3, 273)
		Me.txtStation.Name = "txtStation"
		Me.txtStation.Size = New System.Drawing.Size(247, 30)
		Me.txtStation.TabIndex = 150
		Me.txtStation.Text = "Station#"
		Me.txtStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtSignSize
		'
		Me.txtSignSize.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSignSize.Location = New System.Drawing.Point(3, 309)
		Me.txtSignSize.Name = "txtSignSize"
		Me.txtSignSize.Size = New System.Drawing.Size(247, 26)
		Me.txtSignSize.TabIndex = 151
		Me.txtSignSize.Text = "Size"
		Me.txtSignSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(12, 434)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(494, 20)
		Me.TextBox1.TabIndex = 155
		Me.TextBox1.Text = "Path"
		'
		'txtStationID
		'
		Me.txtStationID.Location = New System.Drawing.Point(512, 434)
		Me.txtStationID.Name = "txtStationID"
		Me.txtStationID.Size = New System.Drawing.Size(82, 20)
		Me.txtStationID.TabIndex = 152
		Me.txtStationID.Text = "StationID"
		'
		'picSign
		'
		Me.picSign.BackColor = System.Drawing.SystemColors.Window
		Me.picSign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picSign.Location = New System.Drawing.Point(12, 6)
		Me.picSign.Name = "picSign"
		Me.picSign.Size = New System.Drawing.Size(582, 422)
		Me.picSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picSign.TabIndex = 8
		Me.picSign.TabStop = False
		'
		'frmSignCheck
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(1117, 489)
		Me.Controls.Add(Me.picSign)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.pnlControl)
		Me.Controls.Add(Me.txtStationID)
		Me.DoubleBuffered = True
		Me.Name = "frmSignCheck"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Production Reporting & Quality Control"
		Me.pnlControl.ResumeLayout(False)
		Me.pnlControl.PerformLayout()
		CType(Me.picSign, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents btnJobList As System.Windows.Forms.Button
	Friend WithEvents btnSignType As System.Windows.Forms.Button
	Friend WithEvents btnStationList As System.Windows.Forms.Button
	Friend WithEvents btnSignTech As System.Windows.Forms.Button
	Friend WithEvents btnBuildDate As System.Windows.Forms.Button
	Friend WithEvents btnPic As System.Windows.Forms.Button
	Friend WithEvents btnStandard As System.Windows.Forms.Button
	Friend WithEvents pnlControl As System.Windows.Forms.Panel
	Friend WithEvents picSign As System.Windows.Forms.PictureBox
	Friend WithEvents txtSignType As System.Windows.Forms.TextBox
	Friend WithEvents txtStationID As System.Windows.Forms.TextBox
	Friend WithEvents txtSignSize As System.Windows.Forms.TextBox
	Friend WithEvents txtSignCode As System.Windows.Forms.TextBox
	Friend WithEvents txtStation As System.Windows.Forms.TextBox
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents txtSheeting As System.Windows.Forms.TextBox
	Friend WithEvents btnAddInfo As System.Windows.Forms.Button
	Friend WithEvents btnApprove As System.Windows.Forms.Button
	Friend WithEvents txtLegendDetails As System.Windows.Forms.TextBox
	Friend WithEvents btnStationStatus As System.Windows.Forms.Button
	Friend WithEvents txtSignTech As System.Windows.Forms.TextBox
	Friend WithEvents txtBuildDate As System.Windows.Forms.TextBox
End Class
