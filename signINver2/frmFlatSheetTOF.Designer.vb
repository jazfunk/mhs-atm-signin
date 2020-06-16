<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlatSheetTOF
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlatSheetTOF))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsbNormalView = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripSplitButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFSTOFFields = New System.Windows.Forms.ComboBox()
        Me.dgvFSTOF = New System.Windows.Forms.DataGridView()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblHideSearch = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvFSTOF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsbNormalView, Me.tsbSave})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 544)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(857, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(842, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Ready"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsbNormalView
        '
        Me.tsbNormalView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbNormalView.Image = Global.signINver2.My.Resources.Resources.search_1
        Me.tsbNormalView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNormalView.Margin = New System.Windows.Forms.Padding(45, 2, 0, 0)
        Me.tsbNormalView.Name = "tsbNormalView"
        Me.tsbNormalView.Size = New System.Drawing.Size(74, 20)
        Me.tsbNormalView.Text = "Search"
        Me.tsbNormalView.ToolTipText = "Show Search"
        Me.tsbNormalView.Visible = False
        '
        'tsbSave
        '
        Me.tsbSave.Image = Global.signINver2.My.Resources.Resources.save_1
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Margin = New System.Windows.Forms.Padding(22, 2, 0, 0)
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(63, 20)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(223, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "By"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(11, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Filter"
        '
        'cmbFSTOFFields
        '
        Me.cmbFSTOFFields.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbFSTOFFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFSTOFFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFSTOFFields.DropDownHeight = 300
        Me.cmbFSTOFFields.FormattingEnabled = True
        Me.cmbFSTOFFields.IntegralHeight = False
        Me.cmbFSTOFFields.Items.AddRange(New Object() {"Station", "Sign Type", "Sign Code", "Sign Details", "Sign Width", "Sign Height", "Sign Support", "Sheeting"})
        Me.cmbFSTOFFields.Location = New System.Drawing.Point(46, 5)
        Me.cmbFSTOFFields.Name = "cmbFSTOFFields"
        Me.cmbFSTOFFields.Size = New System.Drawing.Size(171, 21)
        Me.cmbFSTOFFields.TabIndex = 0
        '
        'dgvFSTOF
        '
        Me.dgvFSTOF.AllowUserToResizeRows = False
        Me.dgvFSTOF.BackgroundColor = System.Drawing.Color.White
        Me.dgvFSTOF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFSTOF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFSTOF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFSTOF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFSTOF.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFSTOF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFSTOF.EnableHeadersVisualStyles = False
        Me.dgvFSTOF.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvFSTOF.Location = New System.Drawing.Point(0, 0)
        Me.dgvFSTOF.Name = "dgvFSTOF"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFSTOF.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFSTOF.RowHeadersVisible = False
        Me.dgvFSTOF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFSTOF.Size = New System.Drawing.Size(855, 511)
        Me.dgvFSTOF.TabIndex = 0
        Me.dgvFSTOF.TabStop = False
        '
        'txtCriteria
        '
        Me.txtCriteria.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCriteria.Location = New System.Drawing.Point(248, 5)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(281, 20)
        Me.txtCriteria.TabIndex = 1
        Me.txtCriteria.Text = "Type search text here"
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSaveChanges.Location = New System.Drawing.Point(742, 3)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(102, 23)
        Me.btnSaveChanges.TabIndex = 2
        Me.btnSaveChanges.Text = "Save Changes"
        Me.btnSaveChanges.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblHideSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCriteria)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSaveChanges)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbFSTOFFields)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvFSTOF)
        Me.SplitContainer1.Size = New System.Drawing.Size(857, 544)
        Me.SplitContainer1.SplitterDistance = 30
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 18
        '
        'lblHideSearch
        '
        Me.lblHideSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHideSearch.AutoSize = True
        Me.lblHideSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHideSearch.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblHideSearch.Location = New System.Drawing.Point(535, 8)
        Me.lblHideSearch.Name = "lblHideSearch"
        Me.lblHideSearch.Size = New System.Drawing.Size(77, 13)
        Me.lblHideSearch.TabIndex = 19
        Me.lblHideSearch.Text = "Hide Search"
        '
        'frmFlatSheetTOF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(857, 566)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFlatSheetTOF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FlatSheet Take Off"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvFSTOF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFSTOFFields As System.Windows.Forms.ComboBox
    Friend WithEvents dgvFSTOF As System.Windows.Forms.DataGridView
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblHideSearch As System.Windows.Forms.Label
    Friend WithEvents tsbNormalView As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripSplitButton
End Class
