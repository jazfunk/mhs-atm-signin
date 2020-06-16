Option Strict On
Option Explicit On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources




Public Class frmCertRequest



#Region " Database Communication"

	' (db1.mdb) connection
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)


	' mhsJobs
	Dim jobDA As OleDbDataAdapter
	Dim jobDS As DataSet
	Dim jobDV As DataView
	Dim jobDT As DataTable

	' tblFScertDetails
	Dim certDA As OleDbDataAdapter
	Dim certBS As BindingSource
	Dim certDS As DataSet
	Dim certDT As DataTable


#End Region



#Region " Class-level Declarations"




#End Region



#Region " Methods & Functions"

	Private Sub FillJobList()

		'  connection to database
		Dim cmd As OleDbCommand = New OleDbCommand("SELECT mhsJob, jobDesc FROM mhsJobs ORDER By mhsJob Desc", objConn)

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

	Private Sub FillCertRequests()

		'  connection to database
		Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, jobNum, rathcoSalesOrder, mhsPO, requestDate, rathcoInvoice, rcvDate FROM tblFScertDetails ORDER By jobNum Desc", objConn)

		' Open connection to Db
		objConn.Open()

		'  Fill dataAdapter with query result from Db
		certDA = New OleDbDataAdapter(cmd)

		'One CommandBuilder object is required. 
		'It automatically generates DeleteCommand, 
		'UpdateCommand and InsertCommand 
		'for DataAdapter object      
		Dim certBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(certDA)

		'  Close the connection
		objConn.Close()

		' Instantiate DataSet object
		certDS = New DataSet()

		' Fill DataSet with data from dataAdapater
		certDA.Fill(certDS, "tblFScertDetails")

		certBS = New BindingSource(certDS, "tblFScertDetails")

		' DataTable -   Fill the DataTable object with data
		certDT = certDS.Tables("tblFScertDetails")

		With Me.dgvCertsRequested
			.DataSource = certBS
			.Columns(0).Visible = False
		End With

	End Sub

	Private Sub BindFields()

		'' Clear previous bindings
		'Me.lbl_JobNumber.DataBindings.Clear()
		'Me.txtRathcoSalesOrder.DataBindings.Clear()
		'Me.txtPO.DataBindings.Clear()
		'Me.txtRequestDate.DataBindings.Clear()
		''Me.dtpRequest.DataBindings.Clear()
		'Me.txtRathcoInvoice.DataBindings.Clear()
		'Me.txtReceiveDate.DataBindings.Clear()
		''Me.dtpReceived.DataBindings.Clear()


		'' Bind Fields
		'Me.lbl_JobNumber.DataBindings.Add("Text", certBS, "jobNum")
		'Me.txtRathcoSalesOrder.DataBindings.Add("Text", certBS, "rathcoSalesOrder")
		'Me.txtPO.DataBindings.Add("Text", certBS, "mhsPO")
		'Me.txtRequestDate.DataBindings.Add("Text", certBS, "requestDate", True).FormatString = "MM/dd/yyyy"
		''Me.dtpRequest.DataBindings.Add("Text", certBS, "requestDate", True).FormatString = "MM/dd/yyyy"
		'Me.txtRathcoInvoice.DataBindings.Add("Text", certBS, "rathcoInvoice")
		'Me.txtReceiveDate.DataBindings.Add("Text", certBS, "rcvDate", True).FormatString = "MM/dd/yyyy"
		''Me.dtpReceived.DataBindings.Add("Text", certBS, "rcvDate", True).FormatString = "MM/dd/yyyy"
		


	End Sub

	Private Sub ClearFields()

		Me.lbl_JobNumber.Text = Nothing
		Me.txtRathcoSalesOrder.Clear()
		Me.txtPO.Clear()
		Me.txtRequestDate.Clear()
		'Me.dtpRequest.DataBindings.Clear()
		Me.txtReceiveDate.Clear()
		'Me.dtpReceived.DataBindings.Clear()
		Me.txtRathcoInvoice.Clear()
		
	End Sub

	Private Sub AddRequest()

		' Declare local variables and objects
		Dim cmd As OleDbCommand = New OleDbCommand

		' Open the connection, execute the command
		objConn.Open()

		' Set the OleDbCommand object properties
		cmd.Connection = objConn
		cmd.CommandText = _
		   "INSERT INTO tblFScertDetails " & _
		 "(jobNum, rathcoSalesOrder, mhsPO, requestDate, rathcoInvoice, rcvDate) " & _
		 "VALUES(@jobNum, @rathcoSalesOrder, @mhsPO, @requestDate, @rathcoInvoice, @rcvDate)"

		' Add placeholder parameters 
		cmd.Parameters.AddWithValue("@jobNum", Me.cmbMhsJob.Text)

		If Me.txtRathcoSalesOrder.Text = "" Then
			cmd.Parameters.AddWithValue("@rathcoSalesOrder", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@rathcoSalesOrder", Me.txtRathcoSalesOrder.Text)
		End If

		If Me.txtPO.Text = "" Then
			cmd.Parameters.AddWithValue("@mhsPO", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@mhsPO", Me.txtPO.Text)
		End If


		'  Convert empty item qty string to dbnull.value
		If Me.txtRequestDate.Text = "" Then
			cmd.Parameters.AddWithValue("@requestDate", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@requestDate", Me.txtRequestDate.Text)
		End If

		If Me.txtRathcoInvoice.Text = "" Then
			cmd.Parameters.AddWithValue("@rathcoInvoice", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@rathcoInvoice", Me.txtRathcoInvoice.Text)
		End If


		If Me.txtReceiveDate.Text = "" Then
			cmd.Parameters.AddWithValue("@rcvDate", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@rcvDate", Me.txtReceiveDate.Text)
		End If


		' Execute the OleDbCommand object to insert the new data
		Try
			cmd.ExecuteNonQuery()

			' Close the connection
			objConn.Close()

			' Reload Data from DB
			FillCertRequests()

		Catch OleDbExceptionErr As OleDbException

			MessageBox.Show(OleDbExceptionErr.Message, "AddRequest()")

			' Close the connection
			objConn.Close()

		End Try



	End Sub

	Private Sub UpdateDb()

		Try
			'  Write changes back to actual .mdb file
			'  Accept changes from DataGridView object
			Me.Validate()
			Me.certBS.EndEdit()
			Me.certDA.Update(Me.certDS.Tables("tblFScertDetails"))

			' Refresh DataSet from the DataBase
			FillCertRequests()


		Catch ex As Exception
			MessageBox.Show(ex.Message, "UpdateDb()")

		End Try

	End Sub



#End Region



#Region " Event Handlers"



	Private Sub frmCertRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


		FillJobList()
		FillCertRequests()



	End Sub

	Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged

		'Me.certBS.Filter = "jobNum = '" & Me.cmbMhsJob.Text & "'"


		Me.lblJobDesc.DataBindings.Clear()
		Me.lblJobDesc.DataBindings.Add("Text", jobDT, "jobDesc")


	End Sub

	Private Sub NavigateBS(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click, btnNext.Click

		Dim btn As Button = DirectCast(sender, Button)

		Try
			If btn.Name = "btnNext" Then
				Me.certBS.MoveNext()
			ElseIf btn.Name = "btnPrevious" Then
				Me.certBS.MovePrevious()
			Else
				' Do nothing, at this point
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "navigateBS()")

		End Try

	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

		Me.certBS.Filter = Nothing

	End Sub

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

		AddRequest()


	End Sub

	Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click


		Try
			
			Dim addNew As New dlgAddCert

			If addNew.ShowDialog = Windows.Forms.DialogResult.OK Then
				MessageBox.Show(addNew.rathcoSalesOrder & vbCrLf & _
				 addNew.mhsPO & vbCrLf & _
				 addNew.requestDate & vbCrLf & _
				 addNew.rathcoInvoice & vbCrLf & _
				 addNew.rcvDate, "Added")

			End If

			' Dispose of the Dialog.  Forms using the ShowDialog Method do not automatically Dispose of their 
			' object.
			addNew.Dispose()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnNew_Click()", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand)
		Finally

		End Try


	End Sub

	Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

		Try
			Me.certBS.Filter = "jobNum LIKE '*" & Me.txtSearch.Text & "*'"

		Catch ex As Exception
			Me.certBS.Filter = Nothing

		End Try
		
	End Sub

	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


		UpdateDb()



	End Sub


#End Region














End Class