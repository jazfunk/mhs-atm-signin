<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTypeVTOF
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
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.Label8 = New System.Windows.Forms.Label
		Me.cmbSignCodes = New System.Windows.Forms.ComboBox
		Me.txtSignCode = New System.Windows.Forms.TextBox
		Me.cmbDetails = New System.Windows.Forms.ComboBox
		Me.txtSignDetails = New System.Windows.Forms.TextBox
		Me.PictureBoxType = New System.Windows.Forms.PictureBox
		Me.txtStation = New System.Windows.Forms.TextBox
		Me.lblType = New System.Windows.Forms.Label
		Me.lblSignCodeDesc = New System.Windows.Forms.Label
		Me.picSign = New System.Windows.Forms.PictureBox
		Me.cmbSelectType = New System.Windows.Forms.ComboBox
		Me.Panel2 = New System.Windows.Forms.Panel
		Me.btnSinglePost = New System.Windows.Forms.Button
		Me.btnMigrateATM = New System.Windows.Forms.Button
		Me.btnATMPrev = New System.Windows.Forms.Button
		Me.btnATMNext = New System.Windows.Forms.Button
		Me.txtHardware = New System.Windows.Forms.TextBox
		Me.lblSheetingColor = New System.Windows.Forms.Label
		Me.cmbSheetType = New System.Windows.Forms.ComboBox
		Me.txtSqrFeet = New System.Windows.Forms.TextBox
		Me.txtHardwareQty = New System.Windows.Forms.TextBox
		Me.cmbPostType = New System.Windows.Forms.ComboBox
		Me.txtSignWidth = New System.Windows.Forms.TextBox
		Me.txtSignHeight = New System.Windows.Forms.TextBox
		Me.btnCluster = New System.Windows.Forms.Button
		Me.txtSupportQty = New System.Windows.Forms.TextBox
		Me.lblEquals = New System.Windows.Forms.Label
		Me.btnUp = New System.Windows.Forms.Button
		Me.lblX = New System.Windows.Forms.Label
		Me.btnAddSign = New System.Windows.Forms.Button
		Me.btnConvert = New System.Windows.Forms.Button
		Me.btnBtoB = New System.Windows.Forms.Button
		Me.btnDown = New System.Windows.Forms.Button
		Me.PictureBoxSheeting = New System.Windows.Forms.PictureBox
		Me.lblPdfTitle = New System.Windows.Forms.Label
		Me.cmbMhsJob = New System.Windows.Forms.ComboBox
		Me.Panel1.SuspendLayout()
		CType(Me.PictureBoxType, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picSign, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel2.SuspendLayout()
		CType(Me.PictureBoxSheeting, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.cmbMhsJob)
		Me.Panel1.Controls.Add(Me.lblPdfTitle)
		Me.Panel1.Controls.Add(Me.Label8)
		Me.Panel1.Controls.Add(Me.cmbSignCodes)
		Me.Panel1.Controls.Add(Me.txtSignCode)
		Me.Panel1.Controls.Add(Me.cmbDetails)
		Me.Panel1.Controls.Add(Me.txtSignDetails)
		Me.Panel1.Controls.Add(Me.PictureBoxType)
		Me.Panel1.Controls.Add(Me.txtStation)
		Me.Panel1.Controls.Add(Me.lblType)
		Me.Panel1.Controls.Add(Me.lblSignCodeDesc)
		Me.Panel1.Controls.Add(Me.picSign)
		Me.Panel1.Controls.Add(Me.cmbSelectType)
		Me.Panel1.Location = New System.Drawing.Point(12, 12)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(719, 331)
		Me.Panel1.TabIndex = 0
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Location = New System.Drawing.Point(127, 65)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(40, 13)
		Me.Label8.TabIndex = 83
		Me.Label8.Text = "Station"
		'
		'cmbSignCodes
		'
		Me.cmbSignCodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbSignCodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSignCodes.BackColor = System.Drawing.Color.White
		Me.cmbSignCodes.DropDownHeight = 150
		Me.cmbSignCodes.DropDownWidth = 125
		Me.cmbSignCodes.FormattingEnabled = True
		Me.cmbSignCodes.IntegralHeight = False
		Me.cmbSignCodes.Location = New System.Drawing.Point(110, 218)
		Me.cmbSignCodes.Name = "cmbSignCodes"
		Me.cmbSignCodes.Size = New System.Drawing.Size(215, 21)
		Me.cmbSignCodes.TabIndex = 74
		Me.cmbSignCodes.Text = "Select"
		'
		'txtSignCode
		'
		Me.txtSignCode.BackColor = System.Drawing.Color.White
		Me.txtSignCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtSignCode.Location = New System.Drawing.Point(110, 245)
		Me.txtSignCode.Name = "txtSignCode"
		Me.txtSignCode.Size = New System.Drawing.Size(139, 20)
		Me.txtSignCode.TabIndex = 76
		Me.txtSignCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'cmbDetails
		'
		Me.cmbDetails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbDetails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbDetails.BackColor = System.Drawing.Color.White
		Me.cmbDetails.DropDownHeight = 150
		Me.cmbDetails.FormattingEnabled = True
		Me.cmbDetails.IntegralHeight = False
		Me.cmbDetails.Location = New System.Drawing.Point(255, 244)
		Me.cmbDetails.Name = "cmbDetails"
		Me.cmbDetails.Size = New System.Drawing.Size(133, 21)
		Me.cmbDetails.TabIndex = 77
		Me.cmbDetails.Text = "Pre-Set Details"
		'
		'txtSignDetails
		'
		Me.txtSignDetails.Location = New System.Drawing.Point(394, 245)
		Me.txtSignDetails.Name = "txtSignDetails"
		Me.txtSignDetails.Size = New System.Drawing.Size(197, 20)
		Me.txtSignDetails.TabIndex = 78
		'
		'PictureBoxType
		'
		Me.PictureBoxType.Location = New System.Drawing.Point(253, 188)
		Me.PictureBoxType.Name = "PictureBoxType"
		Me.PictureBoxType.Size = New System.Drawing.Size(24, 24)
		Me.PictureBoxType.TabIndex = 79
		Me.PictureBoxType.TabStop = False
		'
		'txtStation
		'
		Me.txtStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtStation.ForeColor = System.Drawing.Color.MediumBlue
		Me.txtStation.Location = New System.Drawing.Point(110, 81)
		Me.txtStation.Name = "txtStation"
		Me.txtStation.Size = New System.Drawing.Size(215, 32)
		Me.txtStation.TabIndex = 73
		Me.txtStation.Text = "22222 22.898+AB"
		Me.txtStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'lblType
		'
		Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblType.Location = New System.Drawing.Point(280, 187)
		Me.lblType.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
		Me.lblType.Name = "lblType"
		Me.lblType.Size = New System.Drawing.Size(37, 25)
		Me.lblType.TabIndex = 82
		Me.lblType.Text = "Type"
		Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblSignCodeDesc
		'
		Me.lblSignCodeDesc.BackColor = System.Drawing.Color.Transparent
		Me.lblSignCodeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSignCodeDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSignCodeDesc.Location = New System.Drawing.Point(328, 61)
		Me.lblSignCodeDesc.Name = "lblSignCodeDesc"
		Me.lblSignCodeDesc.Size = New System.Drawing.Size(267, 19)
		Me.lblSignCodeDesc.TabIndex = 81
		Me.lblSignCodeDesc.Text = "Description"
		Me.lblSignCodeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'picSign
		'
		Me.picSign.BackColor = System.Drawing.Color.White
		Me.picSign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picSign.Location = New System.Drawing.Point(331, 83)
		Me.picSign.Name = "picSign"
		Me.picSign.Size = New System.Drawing.Size(260, 156)
		Me.picSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.picSign.TabIndex = 80
		Me.picSign.TabStop = False
		'
		'cmbSelectType
		'
		Me.cmbSelectType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbSelectType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSelectType.FormattingEnabled = True
		Me.cmbSelectType.Items.AddRange(New Object() {"A", "B", "C", "D"})
		Me.cmbSelectType.Location = New System.Drawing.Point(110, 192)
		Me.cmbSelectType.Name = "cmbSelectType"
		Me.cmbSelectType.Size = New System.Drawing.Size(60, 21)
		Me.cmbSelectType.TabIndex = 75
		Me.cmbSelectType.Text = "Select"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.btnSinglePost)
		Me.Panel2.Controls.Add(Me.btnMigrateATM)
		Me.Panel2.Controls.Add(Me.btnATMPrev)
		Me.Panel2.Controls.Add(Me.btnATMNext)
		Me.Panel2.Controls.Add(Me.txtHardware)
		Me.Panel2.Controls.Add(Me.lblSheetingColor)
		Me.Panel2.Controls.Add(Me.cmbSheetType)
		Me.Panel2.Controls.Add(Me.txtSqrFeet)
		Me.Panel2.Controls.Add(Me.txtHardwareQty)
		Me.Panel2.Controls.Add(Me.cmbPostType)
		Me.Panel2.Controls.Add(Me.txtSignWidth)
		Me.Panel2.Controls.Add(Me.txtSignHeight)
		Me.Panel2.Controls.Add(Me.btnCluster)
		Me.Panel2.Controls.Add(Me.txtSupportQty)
		Me.Panel2.Controls.Add(Me.lblEquals)
		Me.Panel2.Controls.Add(Me.btnUp)
		Me.Panel2.Controls.Add(Me.lblX)
		Me.Panel2.Controls.Add(Me.btnAddSign)
		Me.Panel2.Controls.Add(Me.btnConvert)
		Me.Panel2.Controls.Add(Me.btnBtoB)
		Me.Panel2.Controls.Add(Me.btnDown)
		Me.Panel2.Controls.Add(Me.PictureBoxSheeting)
		Me.Panel2.Location = New System.Drawing.Point(12, 349)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(719, 254)
		Me.Panel2.TabIndex = 1
		'
		'btnSinglePost
		'
		Me.btnSinglePost.Location = New System.Drawing.Point(400, 43)
		Me.btnSinglePost.Name = "btnSinglePost"
		Me.btnSinglePost.Size = New System.Drawing.Size(154, 23)
		Me.btnSinglePost.TabIndex = 130
		Me.btnSinglePost.Text = "Single Post"
		Me.btnSinglePost.UseVisualStyleBackColor = True
		'
		'btnMigrateATM
		'
		Me.btnMigrateATM.Image = Global.signINver2.My.Resources.Resources.lightningBolt16x16
		Me.btnMigrateATM.Location = New System.Drawing.Point(525, 188)
		Me.btnMigrateATM.Name = "btnMigrateATM"
		Me.btnMigrateATM.Size = New System.Drawing.Size(29, 23)
		Me.btnMigrateATM.TabIndex = 129
		Me.btnMigrateATM.UseVisualStyleBackColor = True
		'
		'btnATMPrev
		'
		Me.btnATMPrev.Location = New System.Drawing.Point(401, 188)
		Me.btnATMPrev.Name = "btnATMPrev"
		Me.btnATMPrev.Size = New System.Drawing.Size(20, 23)
		Me.btnATMPrev.TabIndex = 128
		Me.btnATMPrev.Text = "<<"
		Me.btnATMPrev.UseVisualStyleBackColor = True
		'
		'btnATMNext
		'
		Me.btnATMNext.Location = New System.Drawing.Point(499, 188)
		Me.btnATMNext.Name = "btnATMNext"
		Me.btnATMNext.Size = New System.Drawing.Size(20, 23)
		Me.btnATMNext.TabIndex = 127
		Me.btnATMNext.Text = ">>"
		Me.btnATMNext.UseVisualStyleBackColor = True
		'
		'txtHardware
		'
		Me.txtHardware.Location = New System.Drawing.Point(182, 133)
		Me.txtHardware.Name = "txtHardware"
		Me.txtHardware.ReadOnly = True
		Me.txtHardware.Size = New System.Drawing.Size(205, 20)
		Me.txtHardware.TabIndex = 126
		'
		'lblSheetingColor
		'
		Me.lblSheetingColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSheetingColor.Location = New System.Drawing.Point(166, 192)
		Me.lblSheetingColor.Margin = New System.Windows.Forms.Padding(0)
		Me.lblSheetingColor.Name = "lblSheetingColor"
		Me.lblSheetingColor.Size = New System.Drawing.Size(211, 16)
		Me.lblSheetingColor.TabIndex = 125
		Me.lblSheetingColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmbSheetType
		'
		Me.cmbSheetType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbSheetType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbSheetType.DropDownHeight = 150
		Me.cmbSheetType.FormattingEnabled = True
		Me.cmbSheetType.IntegralHeight = False
		Me.cmbSheetType.Location = New System.Drawing.Point(158, 162)
		Me.cmbSheetType.Name = "cmbSheetType"
		Me.cmbSheetType.Size = New System.Drawing.Size(229, 21)
		Me.cmbSheetType.TabIndex = 113
		'
		'txtSqrFeet
		'
		Me.txtSqrFeet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSqrFeet.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSqrFeet.ForeColor = System.Drawing.Color.DarkGreen
		Me.txtSqrFeet.Location = New System.Drawing.Point(313, 60)
		Me.txtSqrFeet.Name = "txtSqrFeet"
		Me.txtSqrFeet.Size = New System.Drawing.Size(74, 29)
		Me.txtSqrFeet.TabIndex = 111
		Me.txtSqrFeet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'txtHardwareQty
		'
		Me.txtHardwareQty.Location = New System.Drawing.Point(158, 133)
		Me.txtHardwareQty.Name = "txtHardwareQty"
		Me.txtHardwareQty.Size = New System.Drawing.Size(20, 20)
		Me.txtHardwareQty.TabIndex = 121
		Me.txtHardwareQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'cmbPostType
		'
		Me.cmbPostType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbPostType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbPostType.DropDownHeight = 150
		Me.cmbPostType.FormattingEnabled = True
		Me.cmbPostType.IntegralHeight = False
		Me.cmbPostType.Location = New System.Drawing.Point(182, 107)
		Me.cmbPostType.Name = "cmbPostType"
		Me.cmbPostType.Size = New System.Drawing.Size(205, 21)
		Me.cmbPostType.TabIndex = 112
		'
		'txtSignWidth
		'
		Me.txtSignWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSignWidth.ForeColor = System.Drawing.Color.DarkRed
		Me.txtSignWidth.Location = New System.Drawing.Point(158, 62)
		Me.txtSignWidth.Name = "txtSignWidth"
		Me.txtSignWidth.Size = New System.Drawing.Size(53, 26)
		Me.txtSignWidth.TabIndex = 109
		Me.txtSignWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'txtSignHeight
		'
		Me.txtSignHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSignHeight.ForeColor = System.Drawing.Color.DarkRed
		Me.txtSignHeight.Location = New System.Drawing.Point(235, 62)
		Me.txtSignHeight.Name = "txtSignHeight"
		Me.txtSignHeight.Size = New System.Drawing.Size(53, 26)
		Me.txtSignHeight.TabIndex = 110
		Me.txtSignHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'btnCluster
		'
		Me.btnCluster.Location = New System.Drawing.Point(401, 101)
		Me.btnCluster.Name = "btnCluster"
		Me.btnCluster.Size = New System.Drawing.Size(153, 23)
		Me.btnCluster.TabIndex = 115
		Me.btnCluster.Text = "Cluster"
		Me.btnCluster.UseVisualStyleBackColor = True
		'
		'txtSupportQty
		'
		Me.txtSupportQty.Location = New System.Drawing.Point(158, 107)
		Me.txtSupportQty.Name = "txtSupportQty"
		Me.txtSupportQty.Size = New System.Drawing.Size(20, 20)
		Me.txtSupportQty.TabIndex = 117
		Me.txtSupportQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'lblEquals
		'
		Me.lblEquals.AutoSize = True
		Me.lblEquals.Location = New System.Drawing.Point(294, 69)
		Me.lblEquals.Name = "lblEquals"
		Me.lblEquals.Size = New System.Drawing.Size(13, 13)
		Me.lblEquals.TabIndex = 120
		Me.lblEquals.Text = "="
		Me.lblEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnUp
		'
		Me.btnUp.Location = New System.Drawing.Point(132, 105)
		Me.btnUp.Name = "btnUp"
		Me.btnUp.Size = New System.Drawing.Size(20, 23)
		Me.btnUp.TabIndex = 123
		Me.btnUp.Text = "+"
		Me.btnUp.UseVisualStyleBackColor = True
		'
		'lblX
		'
		Me.lblX.AutoSize = True
		Me.lblX.Location = New System.Drawing.Point(217, 70)
		Me.lblX.Name = "lblX"
		Me.lblX.Size = New System.Drawing.Size(12, 13)
		Me.lblX.TabIndex = 119
		Me.lblX.Text = "x"
		Me.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnAddSign
		'
		Me.btnAddSign.Location = New System.Drawing.Point(427, 188)
		Me.btnAddSign.Name = "btnAddSign"
		Me.btnAddSign.Size = New System.Drawing.Size(66, 23)
		Me.btnAddSign.TabIndex = 118
		Me.btnAddSign.Text = "Add Sign"
		Me.btnAddSign.UseVisualStyleBackColor = True
		'
		'btnConvert
		'
		Me.btnConvert.Location = New System.Drawing.Point(400, 72)
		Me.btnConvert.Name = "btnConvert"
		Me.btnConvert.Size = New System.Drawing.Size(154, 23)
		Me.btnConvert.TabIndex = 114
		Me.btnConvert.Text = "Convert To Inches"
		Me.btnConvert.UseVisualStyleBackColor = True
		'
		'btnBtoB
		'
		Me.btnBtoB.Location = New System.Drawing.Point(401, 130)
		Me.btnBtoB.Name = "btnBtoB"
		Me.btnBtoB.Size = New System.Drawing.Size(154, 23)
		Me.btnBtoB.TabIndex = 116
		Me.btnBtoB.Text = "Back-To-Back"
		Me.btnBtoB.UseVisualStyleBackColor = True
		'
		'btnDown
		'
		Me.btnDown.Location = New System.Drawing.Point(106, 105)
		Me.btnDown.Name = "btnDown"
		Me.btnDown.Size = New System.Drawing.Size(20, 23)
		Me.btnDown.TabIndex = 122
		Me.btnDown.Text = "-"
		Me.btnDown.UseVisualStyleBackColor = True
		'
		'PictureBoxSheeting
		'
		Me.PictureBoxSheeting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.PictureBoxSheeting.Location = New System.Drawing.Point(158, 191)
		Me.PictureBoxSheeting.Name = "PictureBoxSheeting"
		Me.PictureBoxSheeting.Size = New System.Drawing.Size(229, 21)
		Me.PictureBoxSheeting.TabIndex = 124
		Me.PictureBoxSheeting.TabStop = False
		'
		'lblPdfTitle
		'
		Me.lblPdfTitle.AutoSize = True
		Me.lblPdfTitle.BackColor = System.Drawing.Color.Transparent
		Me.lblPdfTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPdfTitle.ForeColor = System.Drawing.Color.White
		Me.lblPdfTitle.Location = New System.Drawing.Point(189, 195)
		Me.lblPdfTitle.Name = "lblPdfTitle"
		Me.lblPdfTitle.Size = New System.Drawing.Size(58, 13)
		Me.lblPdfTitle.TabIndex = 84
		Me.lblPdfTitle.Text = ".pdf Title"
		'
		'cmbMhsJob
		'
		Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cmbMhsJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbMhsJob.FormattingEnabled = True
		Me.cmbMhsJob.Location = New System.Drawing.Point(110, 15)
		Me.cmbMhsJob.Name = "cmbMhsJob"
		Me.cmbMhsJob.Size = New System.Drawing.Size(191, 21)
		Me.cmbMhsJob.TabIndex = 162
		Me.cmbMhsJob.Text = "Select Job"
		'
		'frmTypeVTOF
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(754, 642)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "frmTypeVTOF"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "FlatSheet Alum. - Type V (.125in) TakeOff"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.PictureBoxType, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picSign, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		CType(Me.PictureBoxSheeting, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents cmbSignCodes As System.Windows.Forms.ComboBox
	Friend WithEvents txtSignCode As System.Windows.Forms.TextBox
	Friend WithEvents cmbDetails As System.Windows.Forms.ComboBox
	Friend WithEvents txtSignDetails As System.Windows.Forms.TextBox
	Friend WithEvents PictureBoxType As System.Windows.Forms.PictureBox
	Friend WithEvents txtStation As System.Windows.Forms.TextBox
	Friend WithEvents lblType As System.Windows.Forms.Label
	Friend WithEvents lblSignCodeDesc As System.Windows.Forms.Label
	Friend WithEvents picSign As System.Windows.Forms.PictureBox
	Friend WithEvents cmbSelectType As System.Windows.Forms.ComboBox
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents btnSinglePost As System.Windows.Forms.Button
	Friend WithEvents btnMigrateATM As System.Windows.Forms.Button
	Friend WithEvents btnATMPrev As System.Windows.Forms.Button
	Friend WithEvents btnATMNext As System.Windows.Forms.Button
	Friend WithEvents txtHardware As System.Windows.Forms.TextBox
	Friend WithEvents lblSheetingColor As System.Windows.Forms.Label
	Friend WithEvents cmbSheetType As System.Windows.Forms.ComboBox
	Friend WithEvents txtSqrFeet As System.Windows.Forms.TextBox
	Friend WithEvents txtHardwareQty As System.Windows.Forms.TextBox
	Friend WithEvents cmbPostType As System.Windows.Forms.ComboBox
	Friend WithEvents txtSignWidth As System.Windows.Forms.TextBox
	Friend WithEvents txtSignHeight As System.Windows.Forms.TextBox
	Friend WithEvents btnCluster As System.Windows.Forms.Button
	Friend WithEvents txtSupportQty As System.Windows.Forms.TextBox
	Friend WithEvents lblEquals As System.Windows.Forms.Label
	Friend WithEvents btnUp As System.Windows.Forms.Button
	Friend WithEvents lblX As System.Windows.Forms.Label
	Friend WithEvents btnAddSign As System.Windows.Forms.Button
	Friend WithEvents btnConvert As System.Windows.Forms.Button
	Friend WithEvents btnBtoB As System.Windows.Forms.Button
	Friend WithEvents btnDown As System.Windows.Forms.Button
	Friend WithEvents PictureBoxSheeting As System.Windows.Forms.PictureBox
	Friend WithEvents lblPdfTitle As System.Windows.Forms.Label
	Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
End Class
