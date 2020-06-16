<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSheetingUsage
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblSheeting = New System.Windows.Forms.Label
        Me.lblSheetingColor = New System.Windows.Forms.Label
        Me.PictureBoxSheeting = New System.Windows.Forms.PictureBox
        Me.dgvSheetingListing = New System.Windows.Forms.DataGridView
        Me.cmbFieldToFilter = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCriteria = New System.Windows.Forms.TextBox
        Me.lblFilter = New System.Windows.Forms.Label
        Me.txtUsage = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        CType(Me.PictureBoxSheeting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSheetingListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSheeting
        '
        Me.lblSheeting.AutoSize = True
        Me.lblSheeting.BackColor = System.Drawing.Color.Transparent
        Me.lblSheeting.Location = New System.Drawing.Point(23, 260)
        Me.lblSheeting.Name = "lblSheeting"
        Me.lblSheeting.Size = New System.Drawing.Size(105, 13)
        Me.lblSheeting.TabIndex = 4
        Me.lblSheeting.Text = "Sheeting Description"
        '
        'lblSheetingColor
        '
        Me.lblSheetingColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSheetingColor.Location = New System.Drawing.Point(143, 259)
        Me.lblSheetingColor.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSheetingColor.Name = "lblSheetingColor"
        Me.lblSheetingColor.Size = New System.Drawing.Size(211, 16)
        Me.lblSheetingColor.TabIndex = 96
        Me.lblSheetingColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBoxSheeting
        '
        Me.PictureBoxSheeting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxSheeting.Location = New System.Drawing.Point(134, 256)
        Me.PictureBoxSheeting.Name = "PictureBoxSheeting"
        Me.PictureBoxSheeting.Size = New System.Drawing.Size(229, 21)
        Me.PictureBoxSheeting.TabIndex = 95
        Me.PictureBoxSheeting.TabStop = False
        '
        'dgvSheetingListing
        '
        Me.dgvSheetingListing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSheetingListing.BackgroundColor = System.Drawing.Color.White
        Me.dgvSheetingListing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSheetingListing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSheetingListing.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSheetingListing.EnableHeadersVisualStyles = False
        Me.dgvSheetingListing.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSheetingListing.Location = New System.Drawing.Point(19, 49)
        Me.dgvSheetingListing.Name = "dgvSheetingListing"
        Me.dgvSheetingListing.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSheetingListing.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSheetingListing.RowHeadersVisible = False
        Me.dgvSheetingListing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSheetingListing.Size = New System.Drawing.Size(362, 200)
        Me.dgvSheetingListing.TabIndex = 2
        '
        'cmbFieldToFilter
        '
        Me.cmbFieldToFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbFieldToFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFieldToFilter.DropDownHeight = 300
        Me.cmbFieldToFilter.FormattingEnabled = True
        Me.cmbFieldToFilter.IntegralHeight = False
        Me.cmbFieldToFilter.Items.AddRange(New Object() {"Roll Width", "Code", "Lot", "Drum"})
        Me.cmbFieldToFilter.Location = New System.Drawing.Point(51, 22)
        Me.cmbFieldToFilter.Name = "cmbFieldToFilter"
        Me.cmbFieldToFilter.Size = New System.Drawing.Size(95, 21)
        Me.cmbFieldToFilter.TabIndex = 1
        Me.cmbFieldToFilter.Text = "Search Field"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(152, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "By"
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(177, 22)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(204, 20)
        Me.txtCriteria.TabIndex = 0
        Me.txtCriteria.Text = "Type search text here"
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.BackColor = System.Drawing.Color.Transparent
        Me.lblFilter.Location = New System.Drawing.Point(16, 25)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(29, 13)
        Me.lblFilter.TabIndex = 128
        Me.lblFilter.Text = "Filter"
        '
        'txtUsage
        '
        Me.txtUsage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUsage.Location = New System.Drawing.Point(26, 359)
        Me.txtUsage.Name = "txtUsage"
        Me.txtUsage.Size = New System.Drawing.Size(244, 56)
        Me.txtUsage.TabIndex = 1
        Me.txtUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 301)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 31)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Usage:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(281, 283)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 133
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(281, 312)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 23)
        Me.Button2.TabIndex = 134
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.signINver2.My.Resources.Resources.addNewJobPNG_24
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(281, 359)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 56)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'frmSheetingUsage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(401, 482)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsage)
        Me.Controls.Add(Me.lblSheetingColor)
        Me.Controls.Add(Me.cmbFieldToFilter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCriteria)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.dgvSheetingListing)
        Me.Controls.Add(Me.PictureBoxSheeting)
        Me.Controls.Add(Me.lblSheeting)
        Me.DoubleBuffered = True
        Me.Name = "frmSheetingUsage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sheeting Usage Entry"
        CType(Me.PictureBoxSheeting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSheetingListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSheeting As System.Windows.Forms.Label
    Friend WithEvents lblSheetingColor As System.Windows.Forms.Label
    Friend WithEvents PictureBoxSheeting As System.Windows.Forms.PictureBox
    Friend WithEvents dgvSheetingListing As System.Windows.Forms.DataGridView
    Friend WithEvents cmbFieldToFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents txtUsage As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
