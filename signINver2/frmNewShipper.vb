Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources





Public Class frmNewShipper




#Region " Class-level variables"

    Dim shipperAdded As Boolean = False



#End Region



#Region " Database Communication"

    '  Shipper
    Dim shipperDA As OleDbDataAdapter
    Dim shipperDS As DataSet
    Dim shipperDV As DataView
    Dim shipperDT As DataTable


    ' mhsJobs
    Dim jobDA As OleDbDataAdapter
    Dim jobDS As DataSet
    Dim jobDV As DataView
    Dim jobDT As DataTable


    'jobDesc (mhsJobs)
    Dim descDA As OleDbDataAdapter
    Dim descDS As DataSet
    Dim descDV As DataView
    Dim descDT As DataTable


    ' (db1.mdb) connection
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)


#End Region



#Region " Subs and functions"

    Public Sub getNextShipper()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblShippers WHERE assigned = False ORDER By shipperID", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        shipperDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim shipperBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(shipperDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        shipperDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        shipperDA.Fill(shipperDS, "tblShippers")

        ' Set the Dataview object to the Dataset object
        shipperDV = New DataView(shipperDS.Tables("tblShippers"))



        ' DataTable -   Fill the DataTable object with data
        shipperDT = New DataTable

        'Make sure the dataset is not nothing
        If Not IsNothing(shipperDS) Then

            'Make sure there is at least 1 table in the dataset 
            If shipperDS.Tables.Count > 0 Then

                shipperDT = shipperDS.Tables(0)

                'Then make sure the datatable has rows in it   
                If shipperDT.Rows.Count > 0 Then

                    Dim IsAssigned As Boolean = CBool(shipperDT.Rows(0).Item(8))

                    If IsAssigned = False Then

                        bindFields()
                        disableFields()

                        Me.ToolStripStatusLabel1.Text = "Click the 'Assign Shipper' button to reserve shipper #" & Me.lblShipperID.Text & " and enter information."

                        Exit Sub

                    End If

                End If

            End If

        End If



        ''Iterate through DataSet
        'For Each row As DataRow In shipperDS.Tables("tblShippers").Rows

        '    Dim shipperAssigned As Boolean = CType(row.Item(8), Boolean)

        '    If shipperAssigned = False Then

        '        bindFields()
        '        disableFields()

        '        Me.ToolStripStatusLabel1.Text = "Add Shipper #: " & Me.txtShipperID.Text & " Information."

        '        Exit Sub

        '    End If

        '    ''Add [station] to ListBox1
        '    'ListBox1.Items.Add(row.Item(2))
        'Next


    End Sub

    Private Sub assignShipperID(ByVal sID As Integer)

        ' Declare local variables and objects
        Dim objCommand As OleDbCommand = New OleDbCommand

        '' Save the current record position
        'intPosition = objCurrencyManager.Position

        ' Set the OleDbCommand object properties
        objCommand.Connection = objConn
        objCommand.CommandText = "UPDATE tblShippers " & _
            "SET assigned = @assigned WHERE shipperID = @shipperID"
        objCommand.CommandType = CommandType.Text

        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property        
        objCommand.Parameters.AddWithValue("@assigned", True)
        objCommand.Parameters.AddWithValue("@shipperID", sID)

        ' Open the connection
        objConn.Open()

        ' Execute the OleDbCommand object to update the data
        objCommand.ExecuteNonQuery()

        ' Close the connection
        objConn.Close()

        ' Display a message that the record was updated
        ToolStripStatusLabel1.Text = "Shipper #" & sID & " has been reserved.  Enter information."

        ' Adjust label, etc. accordingly
        Me.lblShipperNum.Text = "Using Shipper #"
        Me.lblShipperNum.ForeColor = Color.Blue
        Me.lblShipperID.BackColor = Color.Firebrick
        Me.lblShipperID.ForeColor = Color.White

        ' Disable 'Assign Shipper' button
        Me.btnEnable.Enabled = False

        ' Enable 'Add Shipper' button
        Me.btnAddShipper.Enabled = True

    End Sub

    Private Sub releaseShipperID(ByVal sID As Integer)

        ' Declare local variables and objects
        Dim objCommand As OleDbCommand = New OleDbCommand

        '' Save the current record position
        'intPosition = objCurrencyManager.Position

        ' Set the OleDbCommand object properties
        objCommand.Connection = objConn
        objCommand.CommandText = "UPDATE tblShippers " & _
            "SET assigned = @assigned WHERE shipperID = @shipperID"
        objCommand.CommandType = CommandType.Text

        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property        
        objCommand.Parameters.AddWithValue("@assigned", False)
        objCommand.Parameters.AddWithValue("@shipperID", sID)

        ' Open the connection
        objConn.Open()

        ' Execute the OleDbCommand object to update the data
        objCommand.ExecuteNonQuery()

        ' Close the connection
        objConn.Close()

        ' Display a message that the record was updated
        ToolStripStatusLabel1.Text = "Shipper # " & sID & " has been release and is available."

    End Sub

    Private Sub bindFields()

        ' Clear previous bindings
        Me.lblShipperID.DataBindings.Clear()
        Me.txtMHSJob.DataBindings.Clear()
        Me.cboShipped.DataBindings.Clear()
        Me.txtShipDate.DataBindings.Clear()
        Me.txtRecBy.DataBindings.Clear()
        Me.txtComments.DataBindings.Clear()

        ' Bind Fields
        Me.lblShipperID.DataBindings.Add("Text", shipperDV, "shipperID")
        Me.txtMHSJob.DataBindings.Add("Text", shipperDV, "mhsJob")
        Me.cboShipped.DataBindings.Add("Checked", shipperDV, "shipped")

        '  Format Date value
        Me.txtShipDate.DataBindings.Add("Text", shipperDV, "shipDate", True).FormatString = "MM/dd/yyyy"
        Me.txtRecBy.DataBindings.Add("Text", shipperDV, "recvdBy")
        Me.txtComments.DataBindings.Add("Text", shipperDV, "comments")

    End Sub

    Private Sub disableFields()

        Me.cmbMhsJob.Enabled = False
        Me.lblJobDesc.Visible = False
        Me.txtMHSJob.ReadOnly = True
        Me.txtVia.ReadOnly = True
        Me.cboShipped.Enabled = False
        Me.txtShipDate.ReadOnly = True
        Me.txtRecBy.ReadOnly = True
        Me.txtComments.ReadOnly = True

    End Sub

    Private Sub enableFields()

        Me.cmbMhsJob.Enabled = True
        'Me.cmbMhsJob.Text = "Select Job"
        
        Me.txtMHSJob.ReadOnly = False
        Me.txtVia.ReadOnly = False
        Me.cboShipped.Enabled = True
        Me.txtShipDate.ReadOnly = False
        Me.txtRecBy.ReadOnly = False
        Me.txtComments.ReadOnly = False

    End Sub

    Private Sub fillJobList()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT mhsJob FROM mhsJobs ORDER By mhsJob Desc", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        jobDA = New OleDbDataAdapter(cmd)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        jobDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        jobDA.Fill(jobDS, "mhsJobs")

        ' DataTable -   Fill the DataTable object with data
        jobDT = jobDS.Tables("mhsJobs")

        
        RemoveHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged
        With Me.cmbMhsJob
            .DataSource = jobDT
            .DisplayMember = "mhsJob"
            .Text = "Select"
        End With
        AddHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged



    End Sub

    '  Also retrieves custPO field
    Private Sub fillJobDesc(ByVal jNum As String)

        Try
            
            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT mhsJob, custJob, cust, custPO, jobDesc FROM mhsJobs " & _
                "WHERE mhsJob = '" & jNum & "' " & _
                "ORDER BY mhsJob", objConn)

            ' Open connection to Db
            objConn.Open()

            '  Fill dataAdapter with query result from Db
            descDA = New OleDbDataAdapter(cmd)

            '  Close the connection
            objConn.Close()

            ' Instantiate DataSet object
            descDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            descDA.Fill(descDS, "mhsJobs")

            ' Set the Dataview object to the Dataset object
            descDV = New DataView(descDS.Tables("mhsJobs"))

            ' Clear bindings
            Me.lblJobDesc.DataBindings.Clear()
            Me.txtPO.DataBindings.Clear()

            ' Bind fields
            Me.lblJobDesc.DataBindings.Add("Text", descDV, "jobDesc")
            Me.txtPO.DataBindings.Add("Text", descDV, "custPO")

        Catch ex As Exception

            Me.lblJobDesc.Text = ""

        End Try


    End Sub

    Private Sub updateDb(ByVal sID As Integer)

        Try
            '  connection to database
            Dim cmd As New OleDbCommand ' = New OleDbCommand("SELECT * FROM tblShippers WHERE shipperID = " & sID, objConn)

            ' Open connection to Db
            objConn.Open()

            ' Set the OleDbCommand object properties
            cmd.Connection = objConn
            cmd.CommandText = "UPDATE tblShippers " & _
                                    "SET mhsJob = @mhsJob, poNum = @poNum, via = @via, entryDate = @entryDate, comments = @comments WHERE shipperID = @ID"

            cmd.CommandType = CommandType.Text

            ' Add placeholder parameters 
            cmd.Parameters.AddWithValue("@mhsJob", Me.txtMHSJob.Text)
            cmd.Parameters.AddWithValue("@poNum", Me.txtPO.Text)
            cmd.Parameters.AddWithValue("@via", Me.txtVia.Text)
            cmd.Parameters.AddWithValue("@entryDate", Now.Date)
            cmd.Parameters.AddWithValue("@comments", Me.txtComments.Text)
            cmd.Parameters.AddWithValue("@ID", sID)

            ' Execute the OleDbCommand object to update the data
            cmd.ExecuteNonQuery()

            ' Close the connection
            objConn.Close()

            Me.ToolStripStatusLabel1.Text = "Shipper #" & sID & " for Job #" & Me.txtMHSJob.Text & " added.  Click 'Add Items' to add items to shipper."

            disableFields()

        Catch ex As Exception
            Me.ToolStripStatusLabel1.Text = "Shipper #" & sID & " NOT added!"
            MessageBox.Show("An error occurred while processing the request. " & vbCrLf & _
                            "See error message below:  " & vbCrLf & ex.Message, _
                            "I do not compute!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            shipperAdded = False

            enableFields()

        End Try

    End Sub

    
    


#End Region



#Region " Event Handlers"

    Private Sub frmNewShipper_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason

            Case CloseReason.ApplicationExitCall
                'The user perfromed an action that caused your code to call Application.Exit.
                'You could go either way here but I'd suggest that you shouldn't be calling Application.Exit
                'if you don't actually want the application to exit.  In that case close the main form instead.
                'Me.NotifyIcon1.Visible = False

                If shipperAdded = False Then

                    releaseShipperID(CInt(Me.lblShipperID.Text))

                End If

                e.Cancel = False


            Case CloseReason.FormOwnerClosing
                'This form is a modeless dialogue, which you shouldn't be minimising to the system tray anyway.
                'Me.NotifyIcon1.Visible = False
                e.Cancel = False
            Case CloseReason.MdiFormClosing
                'This form is an MDI child form, which you shouldn't be minimising to the system tray anyway.
                'Me.NotifyIcon1.Visible = False
                e.Cancel = False

            Case CloseReason.None

                'If the reason can't be determined then something funky is going on so I'd suggest you let the form close.
                'Me.NotifyIcon1.Visible = False
                e.Cancel = False

            Case CloseReason.TaskManagerClosing

                'The user pressed the End Task button on the Applications tab (NOT the Processes tab) of the Task Manager.
                'You could go either way here too.  It really depends on your app and if you don't want the user to be able to exit
                'this way.  I'd suggest letting the form close but there would definitely be legitimate reasons for preventing it.
                'Me.NotifyIcon1.Visible = False

                If shipperAdded = False Then

                    releaseShipperID(CInt(Me.lblShipperID.Text))

                End If

                e.Cancel = False



            Case CloseReason.UserClosing

                'The user clicked the Close button on the title bar, pressed Alt+F4, selected Close from the
                'system menu or performed some action that caused your code to call the form's Close method.
                'Don't let the form close.
                'e.Cancel = True
                'Me.Visible = False
                'Me.NotifyIcon1.Visible = True

                If shipperAdded = False Then

                    releaseShipperID(CInt(Me.lblShipperID.Text))

                End If

                e.Cancel = False


            Case CloseReason.WindowsShutDown

                'Windows is shutting down.
                'Definitely let the form close or you'll prevent Windows shutting down normally.
                'Me.NotifyIcon1.Visible = False
                e.Cancel = False

        End Select
    End Sub

    Private Sub frmNewShipper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        getNextShipper()
        disableFields()
        fillJobList()
        Me.lblEntryDate.Text = CStr(Now.Date)



    End Sub

    Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged

        If Me.cmbMhsJob.Enabled Then
            If Me.cmbMhsJob.Text = "Select Job" Then
                Me.lblJobDesc.Visible = False

            Else
                Me.lblJobDesc.Visible = True
                fillJobDesc(Me.cmbMhsJob.Text)
                Me.txtMHSJob.Text = Me.cmbMhsJob.Text

            End If
        End If


    End Sub

    Private Sub btnEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnable.Click

        enableFields()
        assignShipperID(CInt(Me.lblShipperID.Text))
        Me.cmbMhsJob.Select()


    End Sub



    Private Sub btnAddShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddShipper.Click

        If Me.cmbMhsJob.SelectedIndex < 0 Then
            MessageBox.Show("You must select a job #.", "Job Number not selected.")

            ' Fires the releaseShipper sub
            shipperAdded = False
        Else
            updateDb(CInt(Me.lblShipperID.Text))
            
            Me.btnAddShipper.Enabled = False
            Me.btnAddItems.Enabled = True

            shipperAdded = True

        End If



    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAddItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItems.Click

        Dim sID As Integer = CInt(Me.lblShipperID.Text)
        Dim mhsJN As String = Me.cmbMhsJob.Text

        Dim enterShipperItems As New frmAddShipperItems(CStr(sID))
        enterShipperItems.MdiParent = signINver2.signINMain1
        enterShipperItems.Show()
        Me.Close()

    End Sub

    Private Sub txtPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPO.Click
        Me.txtPO.ReadOnly = False
    End Sub


#End Region








End Class