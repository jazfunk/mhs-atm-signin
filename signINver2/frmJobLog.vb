Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources


Public Class frmJobLog


#Region " Variables"

    Dim logItemID As Integer
    Dim thisUser As String


    Dim jobLogDA As OleDbDataAdapter
    Dim jobLogDS As DataSet
    Dim jobLogDV As DataView
    Dim jobLogDT As DataTable

    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet

    Dim logItemDA As OleDbDataAdapter
    Dim logItemDS As DataSet
    Dim logItemDV As DataView
    Dim logItemDT As DataTable


#End Region


#Region " Db Communication"

    ' tblJobLog (secured.mdb) connection
	Dim objConn As New OleDbConnection(My.Settings.SECconn)
    '  mhsJobs (db1.mdb) connection
	Dim objJobConn As New OleDbConnection(My.Settings.SignINconn)



    Private Sub fillJobList()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT mhsJob FROM mhsJobs", objJobConn)

        ' Open connection to Db
        objJobConn.Open()

        '  Fill dataAdapter with query result from Db
        mhsJobDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim jobBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(mhsJobDA)

        '  Close the connection
        objJobConn.Close()

        ' Instantiate DataSet object
        mhsJobDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        mhsJobDA.Fill(mhsJobDS, "mhsJobs")


        With Me.cmbMhsJob
            .DataSource = mhsJobDS.Tables("mhsJobs")
            .DisplayMember = "mhsJob"
        End With

        Me.ToolStripStatusLabel1.Text = "Job # List loaded."


    End Sub

    Private Sub fillDGV()

        Dim jN As String = Me.cmbMhsJob.Text

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblJobLog WHERE mhsJob = '" & jN & "' ORDER BY ID", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        jobLogDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim dgvBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(jobLogDA)

        ' Instantiate DataSet object
        jobLogDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        jobLogDA.Fill(jobLogDS, "tblJobLog")

        ' Set the Dataview object to the Dataset object
        jobLogDV = New DataView(jobLogDS.Tables("tblJobLog"))


        '  Close the connection
        objConn.Close()

        '  Assign jobLog table to the dataGridView object in the designer
        Me.dgvLogItems.DataSource = jobLogDS.Tables("tblJobLog")


        ' Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        Me.dgvLogItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        ' Declare and set the log header alignment property
        Dim objAlignMidcellStyle As New DataGridViewCellStyle()
        objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        '  Hide ID field
        Me.dgvLogItems.Columns(0).Visible = False

        '  Hide job# field
        Me.dgvLogItems.Columns(1).Visible = False

        '  log field
        Me.dgvLogItems.Columns(2).Width = 240
        Me.dgvLogItems.Columns(2).HeaderText = "Log Detail"
        Me.dgvLogItems.Columns(2).HeaderCell.Style = objAlignMidcellStyle
        Me.dgvLogItems.Columns(2).DefaultCellStyle.ForeColor = Color.Navy

        '  Autosize the entryDate and userID fields
        Me.dgvLogItems.Columns(3).Width = 115
        Me.dgvLogItems.Columns(3).HeaderText = "Entry Date"
        Me.dgvLogItems.Columns(3).ReadOnly = True

        Me.dgvLogItems.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvLogItems.Columns(4).HeaderText = "User ID"
        Me.dgvLogItems.Columns(4).ReadOnly = True

        '  Hide other fields
        Me.dgvLogItems.Columns(5).Visible = False
        Me.dgvLogItems.Columns(6).Visible = False


    End Sub

    Private Sub findLogItem(ByVal logID As Integer)

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblJobLog WHERE ID = " & logID, objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        logItemDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, UpdateCommand and InsertCommand for DataAdapter object      
        Dim logBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(logItemDA)

        ' Instantiate DataSet object
        logItemDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        logItemDA.Fill(logItemDS, "tblJobLog")

        ' Set the Dataview object to the Dataset object
        logItemDV = New DataView(logItemDS.Tables("tblJobLog"))

        '  Close the connection
        objConn.Close()

        clearFields()


        '  Databinding text boxes on form to DataView
        With Me.lblDate
            .DataBindings.Clear()
            .DataBindings.Add("Text", logItemDV, "entryDate")
        End With

        With Me.txtLog
            .DataBindings.Clear()
            .DataBindings.Add("Text", logItemDV, "log")
        End With

        With Me.lblUser
            .DataBindings.Clear()
            .DataBindings.Add("Text", logItemDV, "userID")
        End With

        With Me.lblEditDate
            .DataBindings.Clear()
            .DataBindings.Add("Text", logItemDV, "editDate")
        End With

        With Me.lblEditedBy
            .DataBindings.Clear()
            .DataBindings.Add("Text", logItemDV, "editUserId")
        End With

        Me.ToolStripStatusLabel1.Text = "Ready"


    End Sub




#End Region


#Region " Event Handlers"

    Public Sub New(ByVal userID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        thisUser = userID

        Me.Text = Me.Text & " - Logged in as:  " & My.Settings.userName

    End Sub

    Private Sub jobLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillJobList()

        clearFields()

        Me.Label7.Text = thisUser

        Me.ToolStripStatusLabel1.Text = "Ready"


    End Sub

    Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged

        populateJobDesc()

        fillDGV()

        clearFields()

        Me.ToolStripStatusLabel1.Text = Me.cmbMhsJob.Text & " Job log items loaded."



    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        logItemID = CInt(Me.dgvLogItems.CurrentRow.Cells.Item(0).Value.ToString)

        updateLog(logItemID, thisUser)

    End Sub


    Private Sub dgvLogItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLogItems.CellClick

        findLogItem(CInt(Me.dgvLogItems.CurrentRow.Cells.Item(0).Value))

    End Sub

    Private Sub dgvLogItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLogItems.CellEndEdit

        'updateDb()

    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        addNewLog()
    End Sub



#End Region


#Region " Subs & Functions"

    Private Sub clearFields()

        Me.lblDate.Text = ""
        Me.txtLog.Clear()
        Me.lblUser.Text = ""

        Me.lblEditDate.Text = ""
        Me.lblEditedBy.Text = ""

        Me.ToolStripStatusLabel1.Text = "Ready"

    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.jobLogDA.Update(Me.jobLogDS.Tables("tblJobLog"))
            Me.jobLogDS.AcceptChanges()

            Me.ToolStripStatusLabel1.Text = "Record Updated"

            findLogItem(CInt(Me.dgvLogItems.CurrentRow.Cells.Item(0).Value))

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub populateJobDesc()
        ' Declare job number variable
        Dim jobN As String = Me.cmbMhsJob.Text

        ' mhsJobList (Db1 Db) Connection
		Dim objMHSJobDescConnection As New OleDbConnection(My.Settings.SignINconn)
        Dim objMHSJobDescDataAdapter As New OleDbDataAdapter( _
            "SELECT mhsJob, custJob, cust, jobDesc FROM mhsJobs " & _
            "WHERE mhsJob = '" & jobN & "' " & _
            "ORDER BY mhsJob", objMHSJobDescConnection)

        Dim objMHSJobDescDataSet As DataSet
        Dim objMHSJobDescDataView As DataView

        ' Initialize a new instance of the DataSet object
        objMHSJobDescDataSet = New DataSet()

        ' Open the connection, execute the command
        objMHSJobDescConnection.Open()

        ' Fill DataSet
        objMHSJobDescDataAdapter.Fill(objMHSJobDescDataSet, "mhsJobs")

        ' Set the DataView object to the DataSet object
        objMHSJobDescDataView = New DataView(objMHSJobDescDataSet.Tables("mhsJobs"))

        ' Close the connection
        objMHSJobDescConnection.Close()

        ' Clear databindings
        Me.lblJobDesc.DataBindings.Clear()
        Me.lblMhsJob.DataBindings.Clear()
        Me.lblCust.DataBindings.Clear()
        Me.lblCustJob.DataBindings.Clear()

        ' Bind data (job description) to fields
        Me.lblJobDesc.DataBindings.Add("Text", objMHSJobDescDataView, "jobDesc")
        Me.lblMhsJob.DataBindings.Add("Text", objMHSJobDescDataView, "mhsJob")
        Me.lblCust.DataBindings.Add("Text", objMHSJobDescDataView, "cust")
        Me.lblCustJob.DataBindings.Add("Text", objMHSJobDescDataView, "custJob")



    End Sub

    Private Sub updateLog(ByVal itemID As Integer, ByVal userID As String)

        Dim cmd As OleDbCommand = New OleDbCommand

        ' Open the connection
        objConn.Open()

        Try

            ' Set the OleDbCommand object properties
            cmd.Connection = objConn
            cmd.CommandText = "UPDATE tblJobLog " & _
                                    "SET log = @log, editDate = Now(), editUserID = @userID WHERE ID = @ID"

            cmd.CommandType = CommandType.Text

            ' Add placeholder parameters 
            cmd.Parameters.AddWithValue("@log", Me.txtLog.Text)
            cmd.Parameters.AddWithValue("@userID", thisUser)
            cmd.Parameters.AddWithValue("@ID", itemID)

            ' Execute the OleDbCommand object to update the data
            cmd.ExecuteNonQuery()

            ' Close the connection
            objConn.Close()

            ' Display a message that the record was updated
            ToolStripStatusLabel1.Text = "Record Updated"

            '  Refresh DataGridView
            fillDGV()


        Catch OleDbExceptionErr As OleDbException
            MessageBox.Show(OleDbExceptionErr.Message)
        End Try





    End Sub

    Private Sub addNewLog()

        ' Declare local variables and objects
        Dim cmd As OleDbCommand = New OleDbCommand

        ' Open the connection, execute the command
        objConn.Open()

        ' Set the OleDbCommand object properties
        cmd.Connection = objConn
        cmd.CommandText = _
                    "INSERT INTO tblJobLog " & _
                        "(mhsJob, log, userId, editUserID) " & _
                        "VALUES(@mhsJob, @log, @userId, @editUserID)"

        ' Add placeholder parameters 
        cmd.Parameters.AddWithValue("@mhsJob", Me.lblMhsJob.Text)
        cmd.Parameters.AddWithValue("@log", Me.txtNewLog.Text)
        cmd.Parameters.AddWithValue("@userID", thisUser)
        cmd.Parameters.AddWithValue("@editUserID", thisUser)


        ' Execute the OleDbCommand object to insert the new data
        Try
            cmd.ExecuteNonQuery()

            Me.txtNewLog.Clear()

            ' Close the connection
            objConn.Close()

            fillDGV()

            clearFields()

            ' Display a message that the record was added
            ToolStripStatusLabel1.Text = "Record Added"


        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message)

            ' Close the connection
            objConn.Close()

        End Try





    End Sub

#End Region






















End Class