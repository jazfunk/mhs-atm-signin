<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvNewSheeting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvNewSheeting))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.txtInvoice = New System.Windows.Forms.TextBox()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.txtRollLength = New System.Windows.Forms.TextBox()
        Me.lblRowWidth = New System.Windows.Forms.Label()
        Me.txtRollWidth = New System.Windows.Forms.TextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblRollQty = New System.Windows.Forms.Label()
        Me.txtRollQty = New System.Windows.Forms.TextBox()
        Me.txtLot = New System.Windows.Forms.TextBox()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.txtDrum = New System.Windows.Forms.TextBox()
        Me.lblDrum = New System.Windows.Forms.Label()
        Me.eDtpShipDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker()
        Me.lblShipDate = New System.Windows.Forms.Label()
        Me.eDtpRecvDate = New QSS.Components.Windows.Forms.ExtendedDateTimePicker()
        Me.lblRcvDate = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblRollLength = New System.Windows.Forms.Label()
        Me.lblYards = New System.Windows.Forms.Label()
        Me.lblInches = New System.Windows.Forms.Label()
        Me.grpDimensions = New System.Windows.Forms.GroupBox()
        Me.lblSheeting = New System.Windows.Forms.Label()
        Me.picSheetingDesc = New System.Windows.Forms.PictureBox()
        Me.cmbSheetingCode = New System.Windows.Forms.ComboBox()
        Me.lblSqrFt = New System.Windows.Forms.Label()
        Me.cmbCarrier = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl3M = New System.Windows.Forms.Label()
        Me.pic3M = New System.Windows.Forms.PictureBox()
        Me.grpDimensions.SuspendLayout()
        CType(Me.picSheetingDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.pic3M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(207, 423)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(126, 423)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblInvoice
        '
        Me.lblInvoice.AutoSize = True
        Me.lblInvoice.BackColor = System.Drawing.Color.Transparent
        Me.lblInvoice.Location = New System.Drawing.Point(19, 344)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Size = New System.Drawing.Size(42, 13)
        Me.lblInvoice.TabIndex = 46
        Me.lblInvoice.Text = "Invoice"
        '
        'txtInvoice
        '
        Me.txtInvoice.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoice.ForeColor = System.Drawing.Color.DimGray
        Me.txtInvoice.Location = New System.Drawing.Point(67, 341)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(87, 20)
        Me.txtInvoice.TabIndex = 6
        Me.txtInvoice.Text = "TP210221"
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.BackColor = System.Drawing.Color.Transparent
        Me.lblPO.Location = New System.Drawing.Point(39, 254)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(22, 13)
        Me.lblPO.TabIndex = 43
        Me.lblPO.Text = "PO"
        '
        'txtPO
        '
        Me.txtPO.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPO.Location = New System.Drawing.Point(67, 251)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(67, 20)
        Me.txtPO.TabIndex = 3
        Me.txtPO.Text = "3989"
        '
        'txtRollLength
        '
        Me.txtRollLength.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRollLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollLength.ForeColor = System.Drawing.Color.Black
        Me.txtRollLength.Location = New System.Drawing.Point(94, 41)
        Me.txtRollLength.Name = "txtRollLength"
        Me.txtRollLength.Size = New System.Drawing.Size(58, 29)
        Me.txtRollLength.TabIndex = 1
        Me.txtRollLength.Text = "50"
        Me.txtRollLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRowWidth
        '
        Me.lblRowWidth.AutoSize = True
        Me.lblRowWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblRowWidth.Location = New System.Drawing.Point(7, 25)
        Me.lblRowWidth.Name = "lblRowWidth"
        Me.lblRowWidth.Size = New System.Drawing.Size(56, 13)
        Me.lblRowWidth.TabIndex = 34
        Me.lblRowWidth.Text = "Roll Width"
        Me.lblRowWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtRollWidth
        '
        Me.txtRollWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRollWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollWidth.ForeColor = System.Drawing.Color.Black
        Me.txtRollWidth.Location = New System.Drawing.Point(10, 41)
        Me.txtRollWidth.Name = "txtRollWidth"
        Me.txtRollWidth.Size = New System.Drawing.Size(78, 29)
        Me.txtRollWidth.TabIndex = 0
        Me.txtRollWidth.Text = "48"
        Me.txtRollWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Location = New System.Drawing.Point(11, 60)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(50, 13)
        Me.lblCode.TabIndex = 32
        Me.lblCode.Text = "3M Code"
        '
        'lblRollQty
        '
        Me.lblRollQty.AutoSize = True
        Me.lblRollQty.BackColor = System.Drawing.Color.Transparent
        Me.lblRollQty.Location = New System.Drawing.Point(14, 149)
        Me.lblRollQty.Name = "lblRollQty"
        Me.lblRollQty.Size = New System.Drawing.Size(52, 13)
        Me.lblRollQty.TabIndex = 41
        Me.lblRollQty.Text = "# of Rolls"
        Me.lblRollQty.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtRollQty
        '
        Me.txtRollQty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRollQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRollQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollQty.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.txtRollQty.Location = New System.Drawing.Point(15, 165)
        Me.txtRollQty.Name = "txtRollQty"
        Me.txtRollQty.Size = New System.Drawing.Size(86, 44)
        Me.txtRollQty.TabIndex = 1
        Me.txtRollQty.Text = "32"
        Me.txtRollQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLot
        '
        Me.txtLot.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLot.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtLot.Location = New System.Drawing.Point(67, 277)
        Me.txtLot.Name = "txtLot"
        Me.txtLot.Size = New System.Drawing.Size(202, 26)
        Me.txtLot.TabIndex = 4
        Me.txtLot.Text = "2BTI4"
        Me.txtLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLot
        '
        Me.lblLot.AutoSize = True
        Me.lblLot.BackColor = System.Drawing.Color.Transparent
        Me.lblLot.Location = New System.Drawing.Point(29, 285)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(32, 13)
        Me.lblLot.TabIndex = 58
        Me.lblLot.Text = "Lot #"
        '
        'txtDrum
        '
        Me.txtDrum.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDrum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDrum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrum.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.txtDrum.Location = New System.Drawing.Point(67, 309)
        Me.txtDrum.Name = "txtDrum"
        Me.txtDrum.Size = New System.Drawing.Size(67, 26)
        Me.txtDrum.TabIndex = 5
        Me.txtDrum.Text = "1"
        Me.txtDrum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDrum
        '
        Me.lblDrum.AutoSize = True
        Me.lblDrum.BackColor = System.Drawing.Color.Transparent
        Me.lblDrum.Location = New System.Drawing.Point(19, 317)
        Me.lblDrum.Name = "lblDrum"
        Me.lblDrum.Size = New System.Drawing.Size(42, 13)
        Me.lblDrum.TabIndex = 60
        Me.lblDrum.Text = "Drum #"
        '
        'eDtpShipDate
        '
        Me.eDtpShipDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpShipDate.Location = New System.Drawing.Point(177, 340)
        Me.eDtpShipDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpShipDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpShipDate.Name = "eDtpShipDate"
        Me.eDtpShipDate.Size = New System.Drawing.Size(92, 20)
        Me.eDtpShipDate.TabIndex = 8
        Me.eDtpShipDate.Value = New Date(2010, 2, 27, 0, 0, 0, 0)
        '
        'lblShipDate
        '
        Me.lblShipDate.AutoSize = True
        Me.lblShipDate.BackColor = System.Drawing.Color.Transparent
        Me.lblShipDate.Location = New System.Drawing.Point(174, 324)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(54, 13)
        Me.lblShipDate.TabIndex = 63
        Me.lblShipDate.Text = "Ship Date"
        '
        'eDtpRecvDate
        '
        Me.eDtpRecvDate.CustomFormat = "MM/dd/yyyy"
        Me.eDtpRecvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eDtpRecvDate.Location = New System.Drawing.Point(177, 387)
        Me.eDtpRecvDate.MaxDate = New Date(2222, 12, 31, 0, 0, 0, 0)
        Me.eDtpRecvDate.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
        Me.eDtpRecvDate.Name = "eDtpRecvDate"
        Me.eDtpRecvDate.Size = New System.Drawing.Size(92, 20)
        Me.eDtpRecvDate.TabIndex = 9
        Me.eDtpRecvDate.Value = New Date(2010, 2, 27, 0, 0, 0, 0)
        '
        'lblRcvDate
        '
        Me.lblRcvDate.AutoSize = True
        Me.lblRcvDate.BackColor = System.Drawing.Color.Transparent
        Me.lblRcvDate.Location = New System.Drawing.Point(174, 371)
        Me.lblRcvDate.Name = "lblRcvDate"
        Me.lblRcvDate.Size = New System.Drawing.Size(79, 13)
        Me.lblRcvDate.TabIndex = 65
        Me.lblRcvDate.Text = "Received Date"
        '
        'lblCarrier
        '
        Me.lblCarrier.AutoSize = True
        Me.lblCarrier.BackColor = System.Drawing.Color.Transparent
        Me.lblCarrier.Location = New System.Drawing.Point(14, 371)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(37, 13)
        Me.lblCarrier.TabIndex = 67
        Me.lblCarrier.Text = "Carrier"
        '
        'lblRollLength
        '
        Me.lblRollLength.AutoSize = True
        Me.lblRollLength.BackColor = System.Drawing.Color.Transparent
        Me.lblRollLength.Location = New System.Drawing.Point(91, 25)
        Me.lblRollLength.Name = "lblRollLength"
        Me.lblRollLength.Size = New System.Drawing.Size(61, 13)
        Me.lblRollLength.TabIndex = 38
        Me.lblRollLength.Text = "Roll Length"
        Me.lblRollLength.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblYards
        '
        Me.lblYards.AutoSize = True
        Me.lblYards.BackColor = System.Drawing.Color.Transparent
        Me.lblYards.Location = New System.Drawing.Point(118, 73)
        Me.lblYards.Name = "lblYards"
        Me.lblYards.Size = New System.Drawing.Size(34, 13)
        Me.lblYards.TabIndex = 68
        Me.lblYards.Text = "Yards"
        Me.lblYards.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInches
        '
        Me.lblInches.AutoSize = True
        Me.lblInches.BackColor = System.Drawing.Color.Transparent
        Me.lblInches.Location = New System.Drawing.Point(49, 73)
        Me.lblInches.Name = "lblInches"
        Me.lblInches.Size = New System.Drawing.Size(39, 13)
        Me.lblInches.TabIndex = 69
        Me.lblInches.Text = "Inches"
        Me.lblInches.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpDimensions
        '
        Me.grpDimensions.BackColor = System.Drawing.Color.Transparent
        Me.grpDimensions.Controls.Add(Me.lblRowWidth)
        Me.grpDimensions.Controls.Add(Me.lblInches)
        Me.grpDimensions.Controls.Add(Me.txtRollWidth)
        Me.grpDimensions.Controls.Add(Me.lblYards)
        Me.grpDimensions.Controls.Add(Me.txtRollLength)
        Me.grpDimensions.Controls.Add(Me.lblRollLength)
        Me.grpDimensions.Location = New System.Drawing.Point(108, 134)
        Me.grpDimensions.Name = "grpDimensions"
        Me.grpDimensions.Size = New System.Drawing.Size(161, 100)
        Me.grpDimensions.TabIndex = 2
        Me.grpDimensions.TabStop = False
        Me.grpDimensions.Text = "Sheeting Dimensions"
        '
        'lblSheeting
        '
        Me.lblSheeting.BackColor = System.Drawing.Color.Transparent
        Me.lblSheeting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSheeting.Location = New System.Drawing.Point(14, 105)
        Me.lblSheeting.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSheeting.Name = "lblSheeting"
        Me.lblSheeting.Size = New System.Drawing.Size(253, 16)
        Me.lblSheeting.TabIndex = 96
        Me.lblSheeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picSheetingDesc
        '
        Me.picSheetingDesc.BackColor = System.Drawing.Color.Transparent
        Me.picSheetingDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSheetingDesc.Location = New System.Drawing.Point(12, 103)
        Me.picSheetingDesc.Name = "picSheetingDesc"
        Me.picSheetingDesc.Size = New System.Drawing.Size(257, 21)
        Me.picSheetingDesc.TabIndex = 95
        Me.picSheetingDesc.TabStop = False
        '
        'cmbSheetingCode
        '
        Me.cmbSheetingCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSheetingCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSheetingCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbSheetingCode.DropDownHeight = 124
        Me.cmbSheetingCode.FormattingEnabled = True
        Me.cmbSheetingCode.IntegralHeight = False
        Me.cmbSheetingCode.Location = New System.Drawing.Point(12, 76)
        Me.cmbSheetingCode.Name = "cmbSheetingCode"
        Me.cmbSheetingCode.Size = New System.Drawing.Size(86, 21)
        Me.cmbSheetingCode.TabIndex = 0
        Me.cmbSheetingCode.Text = "Sheeting"
        '
        'lblSqrFt
        '
        Me.lblSqrFt.AutoSize = True
        Me.lblSqrFt.BackColor = System.Drawing.Color.Transparent
        Me.lblSqrFt.Location = New System.Drawing.Point(12, 212)
        Me.lblSqrFt.Name = "lblSqrFt"
        Me.lblSqrFt.Size = New System.Drawing.Size(51, 13)
        Me.lblSqrFt.TabIndex = 97
        Me.lblSqrFt.Text = "6,000 sFt"
        Me.lblSqrFt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbCarrier
        '
        Me.cmbCarrier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCarrier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCarrier.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbCarrier.DropDownHeight = 350
        Me.cmbCarrier.FormattingEnabled = True
        Me.cmbCarrier.IntegralHeight = False
        Me.cmbCarrier.Items.AddRange(New Object() {"Select", "UPS", "O. D.", "Yellow", "FedEx", "Holland", "Other"})
        Me.cmbCarrier.Location = New System.Drawing.Point(15, 388)
        Me.cmbCarrier.Name = "cmbCarrier"
        Me.cmbCarrier.Size = New System.Drawing.Size(139, 21)
        Me.cmbCarrier.TabIndex = 7
        Me.cmbCarrier.Text = "Select"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 458)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(293, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 99
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel2.Text = "Ready"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'lbl3M
        '
        Me.lbl3M.AutoSize = True
        Me.lbl3M.BackColor = System.Drawing.Color.Transparent
        Me.lbl3M.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3M.Location = New System.Drawing.Point(162, 62)
        Me.lbl3M.Name = "lbl3M"
        Me.lbl3M.Size = New System.Drawing.Size(110, 14)
        Me.lbl3M.TabIndex = 129
        Me.lbl3M.Text = "Authorized Fabricator"
        '
        'pic3M
        '
        Me.pic3M.BackColor = System.Drawing.Color.Transparent
        Me.pic3M.Image = Global.signINver2.My.Resources.Resources.MMMLogo
        Me.pic3M.Location = New System.Drawing.Point(167, 12)
        Me.pic3M.Name = "pic3M"
        Me.pic3M.Size = New System.Drawing.Size(100, 50)
        Me.pic3M.TabIndex = 128
        Me.pic3M.TabStop = False
        '
        'frmInvNewSheeting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm3
        Me.ClientSize = New System.Drawing.Size(293, 480)
        Me.Controls.Add(Me.lbl3M)
        Me.Controls.Add(Me.pic3M)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmbCarrier)
        Me.Controls.Add(Me.lblSqrFt)
        Me.Controls.Add(Me.lblSheeting)
        Me.Controls.Add(Me.picSheetingDesc)
        Me.Controls.Add(Me.cmbSheetingCode)
        Me.Controls.Add(Me.grpDimensions)
        Me.Controls.Add(Me.lblCarrier)
        Me.Controls.Add(Me.eDtpRecvDate)
        Me.Controls.Add(Me.lblRcvDate)
        Me.Controls.Add(Me.eDtpShipDate)
        Me.Controls.Add(Me.lblShipDate)
        Me.Controls.Add(Me.txtDrum)
        Me.Controls.Add(Me.lblDrum)
        Me.Controls.Add(Me.txtLot)
        Me.Controls.Add(Me.lblLot)
        Me.Controls.Add(Me.txtRollQty)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblInvoice)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.lblPO)
        Me.Controls.Add(Me.txtPO)
        Me.Controls.Add(Me.lblRollQty)
        Me.Controls.Add(Me.lblCode)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInvNewSheeting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Sheeting Inventory"
        Me.grpDimensions.ResumeLayout(False)
        Me.grpDimensions.PerformLayout()
        CType(Me.picSheetingDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.pic3M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblInvoice As System.Windows.Forms.Label
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents txtRollLength As System.Windows.Forms.TextBox
    Friend WithEvents lblRowWidth As System.Windows.Forms.Label
    Friend WithEvents txtRollWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblRollQty As System.Windows.Forms.Label
    Friend WithEvents txtRollQty As System.Windows.Forms.TextBox
    Friend WithEvents txtLot As System.Windows.Forms.TextBox
    Friend WithEvents lblLot As System.Windows.Forms.Label
    Friend WithEvents txtDrum As System.Windows.Forms.TextBox
    Friend WithEvents lblDrum As System.Windows.Forms.Label
    Friend WithEvents eDtpShipDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents eDtpRecvDate As QSS.Components.Windows.Forms.ExtendedDateTimePicker
    Friend WithEvents lblRcvDate As System.Windows.Forms.Label
    Friend WithEvents lblCarrier As System.Windows.Forms.Label
    Friend WithEvents lblRollLength As System.Windows.Forms.Label
    Friend WithEvents lblYards As System.Windows.Forms.Label
    Friend WithEvents lblInches As System.Windows.Forms.Label
    Friend WithEvents grpDimensions As System.Windows.Forms.GroupBox
    Friend WithEvents lblSheeting As System.Windows.Forms.Label
    Friend WithEvents picSheetingDesc As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSheetingCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblSqrFt As System.Windows.Forms.Label
    Friend WithEvents cmbCarrier As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl3M As System.Windows.Forms.Label
    Friend WithEvents pic3M As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
End Class
