<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob_Station
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob_Station))
        Me.cmbMHSJob = New System.Windows.Forms.ComboBox
        Me.cmbStation = New System.Windows.Forms.ComboBox
        Me.lblJob = New System.Windows.Forms.Label
        Me.lblStation = New System.Windows.Forms.Label
        Me.lblJobDesc = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmbMHSJob
        '
        Me.cmbMHSJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbMHSJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMHSJob.FormattingEnabled = True
        Me.cmbMHSJob.Location = New System.Drawing.Point(53, 28)
        Me.cmbMHSJob.Name = "cmbMHSJob"
        Me.cmbMHSJob.Size = New System.Drawing.Size(121, 21)
        Me.cmbMHSJob.TabIndex = 0
        '
        'cmbStation
        '
        Me.cmbStation.FormattingEnabled = True
        Me.cmbStation.Location = New System.Drawing.Point(234, 28)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(121, 21)
        Me.cmbStation.TabIndex = 1
        '
        'lblJob
        '
        Me.lblJob.AutoSize = True
        Me.lblJob.BackColor = System.Drawing.Color.Transparent
        Me.lblJob.Location = New System.Drawing.Point(50, 12)
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Size = New System.Drawing.Size(24, 13)
        Me.lblJob.TabIndex = 2
        Me.lblJob.Text = "Job"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.BackColor = System.Drawing.Color.Transparent
        Me.lblStation.Location = New System.Drawing.Point(231, 12)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 3
        Me.lblStation.Text = "Station"
        '
        'lblJobDesc
        '
        Me.lblJobDesc.AutoSize = True
        Me.lblJobDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblJobDesc.Location = New System.Drawing.Point(50, 52)
        Me.lblJobDesc.Name = "lblJobDesc"
        Me.lblJobDesc.Size = New System.Drawing.Size(32, 13)
        Me.lblJobDesc.TabIndex = 4
        Me.lblJobDesc.Text = "Desc"
        '
        'frmJob_Station
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.signINver2.My.Resources.Resources.bgForm2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(418, 129)
        Me.Controls.Add(Me.lblJobDesc)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lblJob)
        Me.Controls.Add(Me.cmbStation)
        Me.Controls.Add(Me.cmbMHSJob)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJob_Station"
        Me.Text = "Choose Job and Station"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMHSJob As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStation As System.Windows.Forms.ComboBox
    Friend WithEvents lblJob As System.Windows.Forms.Label
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblJobDesc As System.Windows.Forms.Label
End Class
