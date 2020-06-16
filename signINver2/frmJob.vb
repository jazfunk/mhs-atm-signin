Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources




Public Class frmJob

#Region " Db communication"


    '  (db1.mdb) connection
	'Dim Conn As New OleDbConnection(connStr01)
	Dim Conn As New OleDbConnection(My.Settings.SignINconn)

    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As New DataSet
    Dim mhsJobDV As DataView
    Dim mhsJobDT As DataTable

    Dim custDA As New OleDbDataAdapter("SELECT * From tblCustomers", Conn)
    Dim custDS As DataSet
    Dim custDV As DataView
    Dim custDT As DataTable




    '  (Action Traffic.mdb) connection
	'Dim ATMconn1 As New OleDbConnection(atmConnStr01)
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

	Dim atmJobDA As New OleDbDataAdapter("SELECT [JOB #] As jn From [JOB LIST] As atmJL WHERE Active = True", ATMconn1)
    Dim atmJobDS As DataSet
    Dim atmJobDV As DataView
    Dim atmJobDT As DataTable



#End Region


#Region " Class-level variables"

    Dim mhsJob As String

#End Region


#Region " Event Handlers"

    Private Sub frmAddNewJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        Me.txtMHSJob.Select()

        fillCust()
        fillATMJN()

        Me.cmbATMJobNum.Visible = False
        Me.btnATMInfo.Visible = False

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub cmbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectedIndexChanged

        Me.lblBoundCust.Text = Me.cmbCustomer.Text

        Select Case Me.cmbCustomer.Text
            Case Is = "ATM"
                Me.cmbATMJobNum.Visible = True
                Me.btnATMInfo.Visible = True
                Me.lblBoundCust.Visible = True
            Case Else
                Me.cmbATMJobNum.Visible = False
                Me.btnATMInfo.Visible = False
                Me.lblBoundCust.Visible = True
        End Select

    End Sub

    Private Sub btnATMInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnATMInfo.Click

        PopulateATMJobInfo(Me.cmbATMJobNum.Text)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        addJob()
    End Sub



#End Region

#Region " Subs and Functions"


    Public Sub PopulateATMJobInfo(ByVal jobNum As String)

		Dim atmDA As New OleDbDataAdapter( _
		 "SELECT [JOB #] As atmJN, [PROJECT #] As projNum, " & _
		 "[STATE JOB #] As stateNum, LOCATION, [Completion Date 1] As compDate " & _
		 "FROM [JOB LIST] " & _
		 "WHERE [JOB #] = '" & jobNum & "'", ATMconn1)

        Dim atmDS As DataSet
        Dim atmDV As DataView

        ' Initialize a new instance of the DataSet object
        atmDS = New DataSet()

        ' Open the connection, execute the command
		ATMconn1.Open()

        ' Fill DataSet
        atmDA.Fill(atmDS, "[JOB LIST]")

        ' Close the connection
		ATMconn1.Close()

        ' Set the Contractors DataView object to the DataSet object
        atmDV = New DataView(atmDS.Tables("[JOB LIST]"))

        ' Clear any previous bindings
        Label1.DataBindings.Clear()
        Label2.DataBindings.Clear()
        Label3.DataBindings.Clear()
        Label4.DataBindings.Clear()
        MaskedTextBox1.DataBindings.Clear()

        ' Add new bindings to the DataView object
        Label1.DataBindings.Add("Text", atmDV, "atmJN")
        Label2.DataBindings.Add("Text", atmDV, "LOCATION")
        Label3.DataBindings.Add("Text", atmDV, "projNum")
        Label4.DataBindings.Add("Text", atmDV, "stateNum")

        '  Format Date value
        Me.MaskedTextBox1.DataBindings.Add("Text", atmDV, "compDate", True).FormatString = "MM/dd/yyyy"
        
        ' Migrate ATM databound fields to MHS databound fields
        txtCustJob.Text = Label1.Text
        txtJobDesc.Text = Label2.Text
        txtProjectNum.Text = Label3.Text
        txtStateNum.Text = Label4.Text
        mtxtCompDate.Text = MaskedTextBox1.Text

        ' Hide label bindings
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        MaskedTextBox1.Visible = False
    End Sub

    Private Sub fillCust()

        ' Initialize a new instance of the DataSet object
        custDS = New DataSet()

        Conn.Open()

        ' Fill the DataSet object with Data
        custDA.Fill(custDS, "tblCustomers")

        Conn.Close()

        ' Set the DataView object to the DataSet object
        custDV = New DataView(custDS.Tables("tblCustomers"))

        Me.cmbCustomer.DataSource = custDV
        Me.cmbCustomer.DisplayMember = "cust"
        Me.cmbCustomer.Text = "Select"

    End Sub

    Private Sub fillATMJN()

        ' Initialize a new instance of the DataSet object
        atmJobDS = New DataSet()

		ATMconn1.Open()

        ' Fill the DataSet object with Data
        atmJobDA.Fill(atmJobDS, "atmJL")

        ' Set the DataView object to the DataSet object
        atmJobDV = New DataView(atmJobDS.Tables("atmJL"))

        Me.cmbATMJobNum.DataSource = atmJobDV
        Me.cmbATMJobNum.DisplayMember = "jn"

		ATMconn1.Close()

    End Sub

    Private Sub showAllJobs(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewAll.Click
        Dim allJobs As New frmMhsJobListViewAll
        allJobs.MdiParent = signINver2.signINMain1
        allJobs.Show()
    End Sub

    Private Sub addJob()

        Dim added As Boolean = False

        Dim objCommand As OleDbCommand = New OleDbCommand

        ' Open the connection, execute the command
        Conn.Open()

        ' Set the OleDbCommand object properties
        objCommand.Connection = Conn
        objCommand.CommandText = _
            "INSERT INTO mhsJobs " & _
            "(mhsJob, custJob, cust, custPO, jobDesc, projNum, " & _
            "stateNum, typeI, typeII, typeIII, typeIV, compDate, active, MMMDisc) " & _
            "VALUES(@mhsJob,@custJob,@cust,@custPO,@jobDesc,@projNum, " & _
            "@stateNum,@typeI,@typeII,@typeIII,@typeIV,@compDate,@active,@MMMDisc)"

        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property
        objCommand.Parameters.AddWithValue("@mhsJob", txtMHSJob.Text)
        objCommand.Parameters.AddWithValue("@custJob", txtCustJob.Text)
        objCommand.Parameters.AddWithValue("@cust", lblBoundCust.Text)
        objCommand.Parameters.AddWithValue("@custPO", txtCustPO.Text)
        objCommand.Parameters.AddWithValue("@jobDesc", txtJobDesc.Text)
        objCommand.Parameters.AddWithValue("@projNum", txtProjectNum.Text)
        objCommand.Parameters.AddWithValue("@stateNum", txtStateNum.Text)
        objCommand.Parameters.AddWithValue("@typeI", ckbTypeI.CheckState)
        objCommand.Parameters.AddWithValue("@typeII", ckbTypeII.CheckState)
        objCommand.Parameters.AddWithValue("@typeIII", ckbTypeIII.CheckState)
        objCommand.Parameters.AddWithValue("@typeIV", ckbTypeIV.CheckState)
        objCommand.Parameters.AddWithValue("@compDate", mtxtCompDate.Text)
        objCommand.Parameters.AddWithValue("@active", ckbActive.CheckState)
        objCommand.Parameters.AddWithValue("@MMMDisc", ckbMMM.CheckState)


        ' Execute the OleDbCommand object to insert the new data
        Try
            objCommand.ExecuteNonQuery()

            Me.grpJobDetails.Enabled = False
            Me.btnAdd.Enabled = False

            ' Display a message that the record was added
            ToolStripStatusLabel1.Text = Me.txtMHSJob.Text & " (" & Me.txtJobDesc.Text & ") Added successfully"

            added = True


        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message)

            ToolStripStatusLabel1.Text = "Record not added!"


        End Try

        ' Close the connection
        Conn.Close()

        If added = True Then

            showAllJobs(Nothing, Nothing)

            Me.Close()

        End If



    End Sub




    '  Not needed.  The addJob sub already throws exception because
    '  mhsJob field is a Primary Key and cannot be duplicated.
    '  Saving this code for future use
    Private Function doesJobExist(ByVal job As String) As Boolean

        Dim exists As Boolean

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM mhsJobs WHERE mhsJob = '" & Me.mhsJob & "' ", Conn)

        ' Open connection to Db
        Conn.Open()

        '  Fill dataAdapter with query result from Db
        mhsJobDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, UpdateCommand and InsertCommand for DataAdapter object      
        Dim jobBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(mhsJobDA)

        ' Instantiate DataSet object
        mhsJobDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        mhsJobDA.Fill(mhsJobDS, "mhsJobs")

        ' Set the Dataview object to the Dataset object
        mhsJobDV = New DataView(mhsJobDS.Tables("mhsJobs"))

        '  Close the connection
        Conn.Close()

        ' DataTable -   Fill the DataTable object with data
        mhsJobDT = New DataTable

        'Make sure the dataset is not nothing
        If Not IsNothing(mhsJobDS) Then

            'Make sure there is at least 1 table in the dataset 
            If mhsJobDS.Tables.Count > 0 Then

                mhsJobDT = mhsJobDS.Tables(0)

                'Then make sure the datatable has rows in it   
                If mhsJobDT.Rows.Count > 0 Then

                    ' Job Number already exists
                    exists = True
                Else
                    ' Prepare for new job entry
                    exists = False

                End If
            Else
                ' Prepare for new job entry
                exists = False
            End If
        Else
            ' Prepare for new job entry
            exists = False
        End If

        Return exists


    End Function

    Private Sub bindJobFields(ByVal job As String)

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM mhsJobs WHERE mhsJob = '" & job & "' ", Conn)

        Conn.Open()

        mhsJobDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim jobBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(mhsJobDA)

        Conn.Close()

        '' Instantiate DataSet object
        'mhsJobDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        mhsJobDA.Fill(mhsJobDS, "mhsJobs")

        ' Set the Dataview object to the Dataset object
        mhsJobDV = New DataView(mhsJobDS.Tables("mhsJobs"))


        '  Clear previous bindings
        Me.txtMHSJob.DataBindings.Clear()
        Me.txtCustJob.DataBindings.Clear()
        Me.lblBoundCust.DataBindings.Clear()
        Me.txtCustPO.DataBindings.Clear()
        Me.txtJobDesc.DataBindings.Clear()
        Me.txtProjectNum.DataBindings.Clear()
        Me.txtStateNum.DataBindings.Clear()
        Me.ckbTypeI.DataBindings.Clear()
        Me.ckbTypeII.DataBindings.Clear()
        Me.ckbTypeIII.DataBindings.Clear()
        Me.ckbTypeIV.DataBindings.Clear()
        Me.mtxtCompDate.DataBindings.Clear()
        Me.ckbActive.DataBindings.Clear()
        Me.ckbMMM.DataBindings.Clear()


        '  Add databindings
        Me.txtMHSJob.DataBindings.Add("Text", mhsJobDV, "mhsJob")
        Me.txtCustJob.DataBindings.Add("Text", mhsJobDV, "custJob")
        Me.lblBoundCust.DataBindings.Add("Text", mhsJobDV, "cust")
        Me.txtCustPO.DataBindings.Add("Text", mhsJobDV, "custPO")
        Me.txtJobDesc.DataBindings.Add("Text", mhsJobDV, "jobDesc")
        Me.txtProjectNum.DataBindings.Add("Text", mhsJobDV, "projNum")
        Me.txtStateNum.DataBindings.Add("Text", mhsJobDV, "stateNum")
        Me.ckbTypeI.DataBindings.Add("Checked", mhsJobDV, "typeI")
        Me.ckbTypeII.DataBindings.Add("Checked", mhsJobDV, "typeII")
        Me.ckbTypeIII.DataBindings.Add("Checked", mhsJobDV, "typeIII")
        Me.ckbTypeIV.DataBindings.Add("Checked", mhsJobDV, "typeIV")
        Me.mtxtCompDate.DataBindings.Add("Text", mhsJobDV, "compDate")
        Me.ckbActive.DataBindings.Add("Checked", mhsJobDV, "active")
        Me.ckbMMM.DataBindings.Add("Checked", mhsJobDV, "3MDisc")


    End Sub








    Private Sub testingUsing()

        Dim sqlSTR As String
        sqlSTR = "SELECT SUM(unitQty) FROM tblShipperItems WHERE mhsJob = '" & Me.mhsJob & "' "

        Try
			Using connection As New OleDbConnection(My.Settings.SignINconn)
				Using command As New OleDbCommand(sqlSTR, connection)
					connection.Open()

					Dim totalQuantity As Double = CDbl(command.ExecuteScalar())

					Me.txtCustPO.Text = totalQuantity.ToString

					'Use totalQuantity here.
				End Using
			End Using
        Catch ex As OleDbException
            For Each er As OleDbError In ex.Errors
                MessageBox.Show(er.Message)
            Next
        End Try


    End Sub




#End Region








End Class