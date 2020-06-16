<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddCert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAddCert))
        Me.lblRequest = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReceiveDate = New System.Windows.Forms.TextBox
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.txtRequestDate = New System.Windows.Forms.TextBox
        Me.lblPO = New System.Windows.Forms.Label
        Me.txtRathcoSalesOrder = New System.Windows.Forms.TextBox
        Me.lblRathcoSalesOrder = New System.Windows.Forms.Label
        Me.txtRathcoInvoice = New System.Windows.Forms.TextBox
        Me.lblRathcoInvoice = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblRequest
        '
        Me.lblRequest.AutoSize = True
        Me.lblRequest.BackColor = System.Drawing.Color.Transparent
        Me.lblRequest.Location = New System.Drawing.Point(12, 65)
        Me.lblRequest.Name = "lblRequest"
        Me.lblRequest.Size = New System.Drawing.Size(76, 13)
        Me.lblRequest.TabIndex = 26
        Me.lblRequest.Text = "Request Date:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(162, 137)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Receive Date:"
        '
        'txtReceiveDate
        '
        Me.txtReceiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiveDate.Location = New System.Drawing.Point(12, 117)
        Me.txtReceiveDate.Name = "txtReceiveDate"
        Me.txtReceiveDate.Size = New System.Drawing.Size(100, 20)
        Me.txtReceiveDate.TabIndex = 5
        Me.txtReceiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPO
        '
        Me.txtPO.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPO.Location = New System.Drawing.Point(221, 46)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(100, 26)
        Me.txtPO.TabIndex = 0
        Me.txtPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequestDate
        '
        Me.txtRequestDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestDate.Location = New System.Drawing.Point(12, 78)
        Me.txtRequestDate.Name = "txtRequestDate"
        Me.txtRequestDate.Size = New System.Drawing.Size(100, 20)
        Me.txtRequestDate.TabIndex = 4
        Me.txtRequestDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPO
        '
        Me.lblPO.AutoSize = True
        Me.lblPO.BackColor = System.Drawing.Color.Transparent
        Me.lblPO.Location = New System.Drawing.Point(190, 49)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(25, 13)
        Me.lblPO.TabIndex = 11
        Me.lblPO.Text = "PO:"
        '
        'txtRathcoSalesOrder
        '
        Me.txtRathcoSalesOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRathcoSalesOrder.Location = New System.Drawing.Point(12, 42)
        Me.txtRathcoSalesOrder.Name = "txtRathcoSalesOrder"
        Me.txtRathcoSalesOrder.Size = New System.Drawing.Size(100, 20)
        Me.txtRathcoSalesOrder.TabIndex = 3
        Me.txtRathcoSalesOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRathcoSalesOrder
        '
        Me.lblRathcoSalesOrder.AutoSize = True
        Me.lblRathcoSalesOrder.BackColor = System.Drawing.Color.Transparent
        Me.lblRathcoSalesOrder.Location = New System.Drawing.Point(12, 29)
        Me.lblRathcoSalesOrder.Name = "lblRathcoSalesOrder"
        Me.lblRathcoSalesOrder.Size = New System.Drawing.Size(65, 13)
        Me.lblRathcoSalesOrder.TabIndex = 32
        Me.lblRathcoSalesOrder.Text = "Sales Order:"
        '
        'txtRathcoInvoice
        '
        Me.txtRathcoInvoice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRathcoInvoice.Location = New System.Drawing.Point(221, 78)
        Me.txtRathcoInvoice.Name = "txtRathcoInvoice"
        Me.txtRathcoInvoice.Size = New System.Drawing.Size(100, 26)
        Me.txtRathcoInvoice.TabIndex = 1
        Me.txtRathcoInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRathcoInvoice
        '
        Me.lblRathcoInvoice.AutoSize = True
        Me.lblRathcoInvoice.BackColor = System.Drawing.Color.Transparent
        Me.lblRathcoInvoice.Location = New System.Drawing.Point(170, 81)
        Me.lblRathcoInvoice.Name = "lblRathcoInvoice"
        Me.lblRathcoInvoice.Size = New System.Drawing.Size(45, 13)
        Me.lblRathcoInvoice.TabIndex = 33
        Me.lblRathcoInvoice.Text = "Invoice:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(268, 137)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(53, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dlgAddCert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(342, 172)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblRequest)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReceiveDate)
        Me.Controls.Add(Me.txtPO)
        Me.Controls.Add(Me.txtRequestDate)
        Me.Controls.Add(Me.lblPO)
        Me.Controls.Add(Me.txtRathcoSalesOrder)
        Me.Controls.Add(Me.lblRathcoSalesOrder)
        Me.Controls.Add(Me.txtRathcoInvoice)
        Me.Controls.Add(Me.lblRathcoInvoice)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "dlgAddCert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive New Certification"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents lblRequest As System.Windows.Forms.Label
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtReceiveDate As System.Windows.Forms.TextBox
	Friend WithEvents txtPO As System.Windows.Forms.TextBox
	Friend WithEvents txtRequestDate As System.Windows.Forms.TextBox
	Friend WithEvents lblPO As System.Windows.Forms.Label
	Friend WithEvents txtRathcoSalesOrder As System.Windows.Forms.TextBox
	Friend WithEvents lblRathcoSalesOrder As System.Windows.Forms.Label
	Friend WithEvents txtRathcoInvoice As System.Windows.Forms.TextBox
	Friend WithEvents lblRathcoInvoice As System.Windows.Forms.Label
	Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
