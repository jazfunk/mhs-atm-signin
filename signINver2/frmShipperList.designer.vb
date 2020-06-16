<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShipperList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShipperList))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvShipperList = New System.Windows.Forms.DataGridView()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.panelShipperList = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbShippersFields = New System.Windows.Forms.ComboBox()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvShipperList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelShipperList.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(765, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'dgvShipperList
        '
        Me.dgvShipperList.AllowUserToAddRows = False
        Me.dgvShipperList.AllowUserToDeleteRows = False
        Me.dgvShipperList.AllowUserToOrderColumns = True
        Me.dgvShipperList.AllowUserToResizeRows = False
        Me.dgvShipperList.BackgroundColor = System.Drawing.Color.White
        Me.dgvShipperList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShipperList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipperList.ColumnHeadersHeight = 20
        Me.dgvShipperList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvShipperList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShipperList.EnableHeadersVisualStyles = False
        Me.dgvShipperList.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvShipperList.Location = New System.Drawing.Point(0, 0)
        Me.dgvShipperList.Name = "dgvShipperList"
        Me.dgvShipperList.RowHeadersVisible = False
        Me.dgvShipperList.RowHeadersWidth = 20
        Me.dgvShipperList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShipperList.Size = New System.Drawing.Size(740, 412)
        Me.dgvShipperList.TabIndex = 1
        Me.dgvShipperList.VirtualMode = True
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Location = New System.Drawing.Point(677, 12)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveChanges.TabIndex = 2
        Me.btnSaveChanges.Text = "Save"
        Me.btnSaveChanges.UseVisualStyleBackColor = True
        '
        'panelShipperList
        '
        Me.panelShipperList.BackColor = System.Drawing.Color.Transparent
        Me.panelShipperList.Controls.Add(Me.dgvShipperList)
        Me.panelShipperList.Location = New System.Drawing.Point(12, 41)
        Me.panelShipperList.Name = "panelShipperList"
        Me.panelShipperList.Size = New System.Drawing.Size(740, 412)
        Me.panelShipperList.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(221, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "By"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Filter"
        '
        'cmbShippersFields
        '
        Me.cmbShippersFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbShippersFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbShippersFields.FormattingEnabled = True
        Me.cmbShippersFields.Items.AddRange(New Object() {"Shipper #", "MHS Job #", "Via", "Received By", "Comments", "Customer Purchase Order"})
        Me.cmbShippersFields.Location = New System.Drawing.Point(44, 14)
        Me.cmbShippersFields.Name = "cmbShippersFields"
        Me.cmbShippersFields.Size = New System.Drawing.Size(171, 21)
        Me.cmbShippersFields.TabIndex = 8
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(246, 14)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(281, 20)
        Me.txtCriteria.TabIndex = 7
        Me.txtCriteria.Text = "Type search text here"
        '
        'frmShipperList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(765, 478)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbShippersFields)
        Me.Controls.Add(Me.txtCriteria)
        Me.Controls.Add(Me.panelShipperList)
        Me.Controls.Add(Me.btnSaveChanges)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmShipperList"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shippers Listing"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvShipperList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelShipperList.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvShipperList As System.Windows.Forms.DataGridView
    Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
    Friend WithEvents panelShipperList As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbShippersFields As System.Windows.Forms.ComboBox
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
End Class
