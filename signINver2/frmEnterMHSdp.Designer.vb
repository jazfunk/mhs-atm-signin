<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterMHSdp
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbSignTech = New System.Windows.Forms.ComboBox()
        Me.eDtpBuildDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker()
        Me.cmbMhsJob = New System.Windows.Forms.ComboBox()
        Me.btnSelectNone = New System.Windows.Forms.Button()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnUpdateSelected = New System.Windows.Forms.Button()
        Me.btnFilterFS = New System.Windows.Forms.Button()
        Me.btnFilterPLY = New System.Windows.Forms.Button()
        Me.btnFilterEXT = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.cmbStations = New System.Windows.Forms.ComboBox()
        Me.txtSignType = New System.Windows.Forms.TextBox()
        Me.txtStationID = New System.Windows.Forms.TextBox()
        Me.txtSignSize = New System.Windows.Forms.TextBox()
        Me.txtSignCode = New System.Windows.Forms.TextBox()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtProgress = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btnFilterEXT_PLY = New System.Windows.Forms.Button()
        Me.txtSignTechTEMP = New System.Windows.Forms.TextBox()
        Me.txtSortLike = New System.Windows.Forms.TextBox()
        Me.lblCodeFilter = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblBuildDate = New System.Windows.Forms.Label()
        Me.cmbSortLike = New System.Windows.Forms.ComboBox()
        Me.btnFilterTypeV = New System.Windows.Forms.Button()
        Me.ckbUnReported = New System.Windows.Forms.CheckBox()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.btnSignCheck = New System.Windows.Forms.Button()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbSignTech
        '
        Me.cmbSignTech.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSignTech.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSignTech.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSignTech.FormattingEnabled = True
        Me.cmbSignTech.Location = New System.Drawing.Point(8, 82)
        Me.cmbSignTech.Name = "cmbSignTech"
        Me.cmbSignTech.Size = New System.Drawing.Size(127, 21)
        Me.cmbSignTech.TabIndex = 148
        Me.cmbSignTech.Text = "Sign Tech"
        '
        'eDtpBuildDate
        '
        Me.eDtpBuildDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpBuildDate.Location = New System.Drawing.Point(141, 82)
        Me.eDtpBuildDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpBuildDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpBuildDate.Name = "eDtpBuildDate"
        Me.eDtpBuildDate.Size = New System.Drawing.Size(100, 20)
        Me.eDtpBuildDate.TabIndex = 149
        Me.eDtpBuildDate.Value = New Date(2015, 9, 6, 0, 0, 0, 0)
        '
        'cmbMhsJob
        '
        Me.cmbMhsJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMhsJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMhsJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMhsJob.FormattingEnabled = True
        Me.cmbMhsJob.Location = New System.Drawing.Point(8, 17)
        Me.cmbMhsJob.Name = "cmbMhsJob"
        Me.cmbMhsJob.Size = New System.Drawing.Size(98, 21)
        Me.cmbMhsJob.TabIndex = 161
        Me.cmbMhsJob.Text = "Select Job"
        '
        'btnSelectNone
        '
        Me.btnSelectNone.Location = New System.Drawing.Point(653, 17)
        Me.btnSelectNone.Name = "btnSelectNone"
        Me.btnSelectNone.Size = New System.Drawing.Size(74, 23)
        Me.btnSelectNone.TabIndex = 179
        Me.btnSelectNone.Text = "Select None"
        Me.btnSelectNone.UseVisualStyleBackColor = True
        '
        'btnAll
        '
        Me.btnAll.Location = New System.Drawing.Point(344, 17)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(41, 23)
        Me.btnAll.TabIndex = 177
        Me.btnAll.Text = "All"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(590, 17)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(63, 23)
        Me.btnSelectAll.TabIndex = 178
        Me.btnSelectAll.Text = "SelectAll"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnUpdateSelected
        '
        Me.btnUpdateSelected.Location = New System.Drawing.Point(727, 17)
        Me.btnUpdateSelected.Name = "btnUpdateSelected"
        Me.btnUpdateSelected.Size = New System.Drawing.Size(106, 23)
        Me.btnUpdateSelected.TabIndex = 180
        Me.btnUpdateSelected.Text = "Update Selected"
        Me.btnUpdateSelected.UseVisualStyleBackColor = True
        '
        'btnFilterFS
        '
        Me.btnFilterFS.Location = New System.Drawing.Point(508, 17)
        Me.btnFilterFS.Name = "btnFilterFS"
        Me.btnFilterFS.Size = New System.Drawing.Size(41, 23)
        Me.btnFilterFS.TabIndex = 176
        Me.btnFilterFS.Text = "III"
        Me.btnFilterFS.UseVisualStyleBackColor = True
        '
        'btnFilterPLY
        '
        Me.btnFilterPLY.Location = New System.Drawing.Point(467, 17)
        Me.btnFilterPLY.Name = "btnFilterPLY"
        Me.btnFilterPLY.Size = New System.Drawing.Size(41, 23)
        Me.btnFilterPLY.TabIndex = 175
        Me.btnFilterPLY.Text = "II"
        Me.btnFilterPLY.UseVisualStyleBackColor = True
        '
        'btnFilterEXT
        '
        Me.btnFilterEXT.Location = New System.Drawing.Point(426, 17)
        Me.btnFilterEXT.Name = "btnFilterEXT"
        Me.btnFilterEXT.Size = New System.Drawing.Size(41, 23)
        Me.btnFilterEXT.TabIndex = 174
        Me.btnFilterEXT.Text = "I"
        Me.btnFilterEXT.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(773, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(60, 20)
        Me.TextBox1.TabIndex = 172
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(247, 68)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 22
        Me.DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(586, 486)
        Me.DataGridView2.TabIndex = 173
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(27, 277)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.ReadOnly = True
        Me.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetails.Size = New System.Drawing.Size(194, 43)
        Me.txtDetails.TabIndex = 189
        '
        'cmbStations
        '
        Me.cmbStations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStations.DropDownHeight = 300
        Me.cmbStations.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStations.FormattingEnabled = True
        Me.cmbStations.IntegralHeight = False
        Me.cmbStations.Location = New System.Drawing.Point(27, 161)
        Me.cmbStations.Name = "cmbStations"
        Me.cmbStations.Size = New System.Drawing.Size(194, 32)
        Me.cmbStations.TabIndex = 186
        Me.cmbStations.Text = "601012 00.000+AR"
        '
        'txtSignType
        '
        Me.txtSignType.Location = New System.Drawing.Point(156, 251)
        Me.txtSignType.Name = "txtSignType"
        Me.txtSignType.ReadOnly = True
        Me.txtSignType.Size = New System.Drawing.Size(65, 20)
        Me.txtSignType.TabIndex = 188
        Me.txtSignType.Text = "Type"
        '
        'txtStationID
        '
        Me.txtStationID.Location = New System.Drawing.Point(156, 199)
        Me.txtStationID.Name = "txtStationID"
        Me.txtStationID.ReadOnly = True
        Me.txtStationID.Size = New System.Drawing.Size(65, 20)
        Me.txtStationID.TabIndex = 183
        Me.txtStationID.Text = "StationID"
        '
        'txtSignSize
        '
        Me.txtSignSize.Location = New System.Drawing.Point(27, 251)
        Me.txtSignSize.Name = "txtSignSize"
        Me.txtSignSize.ReadOnly = True
        Me.txtSignSize.Size = New System.Drawing.Size(123, 20)
        Me.txtSignSize.TabIndex = 182
        Me.txtSignSize.Text = "Size"
        '
        'txtSignCode
        '
        Me.txtSignCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSignCode.Location = New System.Drawing.Point(27, 225)
        Me.txtSignCode.Name = "txtSignCode"
        Me.txtSignCode.ReadOnly = True
        Me.txtSignCode.Size = New System.Drawing.Size(194, 20)
        Me.txtSignCode.TabIndex = 185
        Me.txtSignCode.Text = "Code"
        '
        'txtStation
        '
        Me.txtStation.Location = New System.Drawing.Point(27, 199)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.ReadOnly = True
        Me.txtStation.Size = New System.Drawing.Size(123, 20)
        Me.txtStation.TabIndex = 181
        Me.txtStation.Text = "Station#"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(112, 17)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(225, 21)
        Me.ProgressBar1.TabIndex = 160
        Me.ProgressBar1.Visible = False
        '
        'txtProgress
        '
        Me.txtProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProgress.Location = New System.Drawing.Point(8, 43)
        Me.txtProgress.Margin = New System.Windows.Forms.Padding(0)
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Size = New System.Drawing.Size(329, 20)
        Me.txtProgress.TabIndex = 161
        Me.txtProgress.Text = "No Activity Detected..."
        Me.txtProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtProgress.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(839, 68)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 22
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(298, 486)
        Me.DataGridView1.TabIndex = 191
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(1077, 46)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(60, 20)
        Me.TextBox2.TabIndex = 192
        '
        'btnFilterEXT_PLY
        '
        Me.btnFilterEXT_PLY.Location = New System.Drawing.Point(385, 17)
        Me.btnFilterEXT_PLY.Name = "btnFilterEXT_PLY"
        Me.btnFilterEXT_PLY.Size = New System.Drawing.Size(41, 23)
        Me.btnFilterEXT_PLY.TabIndex = 193
        Me.btnFilterEXT_PLY.Text = "I - II"
        Me.btnFilterEXT_PLY.UseVisualStyleBackColor = True
        '
        'txtSignTechTEMP
        '
        Me.txtSignTechTEMP.Location = New System.Drawing.Point(27, 428)
        Me.txtSignTechTEMP.Name = "txtSignTechTEMP"
        Me.txtSignTechTEMP.ReadOnly = True
        Me.txtSignTechTEMP.Size = New System.Drawing.Size(79, 20)
        Me.txtSignTechTEMP.TabIndex = 195
        Me.txtSignTechTEMP.Text = "Sign Tech"
        '
        'txtSortLike
        '
        Me.txtSortLike.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSortLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSortLike.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSortLike.Location = New System.Drawing.Point(506, 44)
        Me.txtSortLike.Name = "txtSortLike"
        Me.txtSortLike.Size = New System.Drawing.Size(261, 20)
        Me.txtSortLike.TabIndex = 196
        '
        'lblCodeFilter
        '
        Me.lblCodeFilter.AutoSize = True
        Me.lblCodeFilter.BackColor = System.Drawing.Color.Transparent
        Me.lblCodeFilter.Location = New System.Drawing.Point(344, 44)
        Me.lblCodeFilter.Name = "lblCodeFilter"
        Me.lblCodeFilter.Size = New System.Drawing.Size(29, 13)
        Me.lblCodeFilter.TabIndex = 197
        Me.lblCodeFilter.Text = "Filter"
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserName.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(27, 451)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(194, 29)
        Me.lblUserName.TabIndex = 198
        '
        'lblBuildDate
        '
        Me.lblBuildDate.BackColor = System.Drawing.Color.Transparent
        Me.lblBuildDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBuildDate.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuildDate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblBuildDate.Location = New System.Drawing.Point(27, 480)
        Me.lblBuildDate.Name = "lblBuildDate"
        Me.lblBuildDate.Size = New System.Drawing.Size(194, 29)
        Me.lblBuildDate.TabIndex = 199
        '
        'cmbSortLike
        '
        Me.cmbSortLike.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSortLike.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSortLike.FormattingEnabled = True
        Me.cmbSortLike.Items.AddRange(New Object() {"Sign Code", "Station Number"})
        Me.cmbSortLike.Location = New System.Drawing.Point(379, 43)
        Me.cmbSortLike.Name = "cmbSortLike"
        Me.cmbSortLike.Size = New System.Drawing.Size(121, 21)
        Me.cmbSortLike.TabIndex = 200
        Me.cmbSortLike.Text = "Select..."
        '
        'btnFilterTypeV
        '
        Me.btnFilterTypeV.Location = New System.Drawing.Point(549, 17)
        Me.btnFilterTypeV.Name = "btnFilterTypeV"
        Me.btnFilterTypeV.Size = New System.Drawing.Size(41, 23)
        Me.btnFilterTypeV.TabIndex = 201
        Me.btnFilterTypeV.Text = "V"
        Me.btnFilterTypeV.UseVisualStyleBackColor = True
        '
        'ckbUnReported
        '
        Me.ckbUnReported.AutoSize = True
        Me.ckbUnReported.BackColor = System.Drawing.Color.Transparent
        Me.ckbUnReported.Location = New System.Drawing.Point(839, 45)
        Me.ckbUnReported.Name = "ckbUnReported"
        Me.ckbUnReported.Size = New System.Drawing.Size(79, 17)
        Me.ckbUnReported.TabIndex = 203
        Me.ckbUnReported.Text = "Unreported"
        Me.ckbUnReported.UseVisualStyleBackColor = False
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.BackColor = System.Drawing.Color.Transparent
        Me.lblStation.Location = New System.Drawing.Point(24, 145)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(80, 13)
        Me.lblStation.TabIndex = 204
        Me.lblStation.Text = "Station Number"
        '
        'btnSignCheck
        '
        Me.btnSignCheck.Location = New System.Drawing.Point(1031, 17)
        Me.btnSignCheck.Name = "btnSignCheck"
        Me.btnSignCheck.Size = New System.Drawing.Size(106, 23)
        Me.btnSignCheck.TabIndex = 205
        Me.btnSignCheck.Text = "Sign Check"
        Me.btnSignCheck.UseVisualStyleBackColor = True
        '
        'frmEnterMHSdp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1149, 570)
        Me.Controls.Add(Me.btnSignCheck)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ckbUnReported)
        Me.Controls.Add(Me.btnFilterTypeV)
        Me.Controls.Add(Me.cmbSortLike)
        Me.Controls.Add(Me.lblBuildDate)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblCodeFilter)
        Me.Controls.Add(Me.txtSortLike)
        Me.Controls.Add(Me.txtSignTechTEMP)
        Me.Controls.Add(Me.txtProgress)
        Me.Controls.Add(Me.cmbSignTech)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnFilterEXT_PLY)
        Me.Controls.Add(Me.eDtpBuildDate)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.cmbStations)
        Me.Controls.Add(Me.btnUpdateSelected)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnSelectNone)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnFilterFS)
        Me.Controls.Add(Me.btnFilterPLY)
        Me.Controls.Add(Me.btnFilterEXT)
        Me.Controls.Add(Me.txtSignType)
        Me.Controls.Add(Me.txtStationID)
        Me.Controls.Add(Me.txtSignSize)
        Me.Controls.Add(Me.txtSignCode)
        Me.Controls.Add(Me.txtStation)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.cmbMhsJob)
        Me.DoubleBuffered = True
        Me.Name = "frmEnterMHSdp"
        Me.Text = "MHS Daily Productions"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents cmbSignTech As System.Windows.Forms.ComboBox
	Friend WithEvents eDtpBuildDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
	Friend WithEvents cmbMhsJob As System.Windows.Forms.ComboBox
	Friend WithEvents btnSelectNone As System.Windows.Forms.Button
	Friend WithEvents btnAll As System.Windows.Forms.Button
	Friend WithEvents btnSelectAll As System.Windows.Forms.Button
	Friend WithEvents btnUpdateSelected As System.Windows.Forms.Button
	Friend WithEvents btnFilterFS As System.Windows.Forms.Button
	Friend WithEvents btnFilterPLY As System.Windows.Forms.Button
	Friend WithEvents btnFilterEXT As System.Windows.Forms.Button
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
	Friend WithEvents txtDetails As System.Windows.Forms.TextBox
	Friend WithEvents cmbStations As System.Windows.Forms.ComboBox
	Friend WithEvents txtSignType As System.Windows.Forms.TextBox
    Friend WithEvents txtStationID As System.Windows.Forms.TextBox
	Friend WithEvents txtSignSize As System.Windows.Forms.TextBox
	Friend WithEvents txtSignCode As System.Windows.Forms.TextBox
	Friend WithEvents txtStation As System.Windows.Forms.TextBox
	Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
	Friend WithEvents txtProgress As System.Windows.Forms.TextBox
	Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
	Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
	Friend WithEvents btnFilterEXT_PLY As System.Windows.Forms.Button
	Friend WithEvents txtSignTechTEMP As System.Windows.Forms.TextBox
	Friend WithEvents txtSortLike As System.Windows.Forms.TextBox
	Friend WithEvents lblCodeFilter As System.Windows.Forms.Label
	Friend WithEvents lblUserName As System.Windows.Forms.Label
	Friend WithEvents lblBuildDate As System.Windows.Forms.Label
	Friend WithEvents cmbSortLike As System.Windows.Forms.ComboBox
	Friend WithEvents btnFilterTypeV As System.Windows.Forms.Button
	Friend WithEvents ckbUnReported As System.Windows.Forms.CheckBox
	Friend WithEvents lblStation As System.Windows.Forms.Label
	Friend WithEvents btnSignCheck As System.Windows.Forms.Button
End Class
