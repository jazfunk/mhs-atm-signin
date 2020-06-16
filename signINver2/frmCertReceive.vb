Option Strict On
Option Explicit On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources



Public Class frmCertReceive



#Region " Class-level Declarations"

	Private ChangeMe As Object
	Dim jobInfo As New Dictionary(Of String, String)
	Dim itemInfo As New Dictionary(Of Integer, String)
	Dim typeInfo As New Dictionary(Of String, double)





#End Region



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

	' tblFScertItems
	Dim rcvDA As OleDbDataAdapter
	Dim rcvBS As BindingSource
	Dim rcvDS As DataSet
	Dim rcvDT As DataTable

	'tblItems
	Dim itemDA As OleDbDataAdapter
	Dim itemBS As BindingSource
	Dim itemDS As DataSet
	Dim itemDT As DataTable

	'Joined tblItems, tblFScertDetails, tblFScertItems
	Dim joinDA As OleDbDataAdapter
	Dim WithEvents joinBS As BindingSource
	Dim joinDS As DataSet
	Dim joinDT As DataTable





#End Region



#Region " Methods & Functions"


	Private Sub FillJobList()

		Try

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

			Me.lblJobDesc.DataBindings.Clear()
			Me.lblJobDesc.DataBindings.Add("Text", jobDT, "jobDesc")


		Catch ex As Exception
			MessageBox.Show(ex.Message, "FillJobList()")
		End Try


	End Sub

	Private Sub FillCertRequests()
		Try

			'  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, " & _
                         "jobNum, " & _
                         "rathcoSalesOrder, " & _
                         "mhsPO, " & _
                         "requestDate, " & _
                         "rathcoInvoice, " & _
                         "rcvDate, " & _
                         "shipDate " & _
                         "FROM tblFScertDetails " & _
                         "ORDER By ID DESC", objConn)

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

			With Me.dgvRequests
				.DataSource = certBS
				.Columns("ID").Visible = False
				.Columns("jobNum").Visible = False
				.Columns("rathcoSalesOrder").HeaderText = "Sales Order"
				.Columns("rathcoSalesOrder").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				.Columns("mhsPO").HeaderText = "PO"
				.Columns("mhsPO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				.Columns("requestDate").HeaderText = "Requested"
				.Columns("requestDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
				.Columns("rathcoInvoice").HeaderText = "Invoice"
				.Columns("rathcoInvoice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				.Columns("rcvDate").HeaderText = "Received"
				.Columns("rcvDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
				.Columns("shipDate").HeaderText = "Shipped"
				.Columns("shipDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			End With

			BindFields()
            cmbMhsJob_SelectedIndexChanged(Nothing, Nothing)

			
		Catch ex As Exception
			MessageBox.Show(ex.InnerException.Message, "FillCertRequests()")
		End Try



	End Sub

	' Not used 06.26.2012
	Private Sub FillCertItems()

		'Try



		'	'  connection to database
		'	Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, detailsID, itemID, itemQty, itemDetails FROM tblFScertItems ORDER By ID ASC", objConn)

		'	' Open connection to Db
		'	objConn.Open()

		'	'  Fill dataAdapter with query result from Db
		'	rcvDA = New OleDbDataAdapter(cmd)

		'	'One CommandBuilder object is required. 
		'	'It automatically generates DeleteCommand, 
		'	'UpdateCommand and InsertCommand 
		'	'for DataAdapter object      
		'	Dim rcvBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(rcvDA)

		'	'  Close the connection
		'	objConn.Close()

		'	' Instantiate DataSet object
		'	rcvDS = New DataSet()

		'	' Fill DataSet with data from dataAdapater
		'	rcvDA.Fill(rcvDS, "tblFScertItems")

		'	rcvBS = New BindingSource(rcvDS, "tblFScertItems")

		'	' DataTable -   Fill the DataTable object with data
		'	rcvDT = rcvDS.Tables("tblFScertItems")

		'	'RemoveHandler dgvRequests.SelectionChanged, AddressOf dgvRequests_SelectionChanged
		'	'With Me.dgvReceived
		'	'	.DataSource = rcvBS
		'	'	.Columns(0).Visible = False
		'	'End With
		'	'AddHandler dgvRequests.SelectionChanged, AddressOf dgvRequests_SelectionChanged
		'Catch ex As Exception
		'	'  Close the connection
		'	objConn.Close()
		'End Try


	End Sub

	Private Sub FillItemList()

		Try

			'  connection to database
			Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, item, groupID FROM tblItems ORDER By groupID, item", objConn)

			' Open connection to Db
			objConn.Open()

			'  Fill dataAdapter with query result from Db
			itemDA = New OleDbDataAdapter(cmd)

			'  Close the connection
			objConn.Close()

			' Instantiate DataSet object
			itemDS = New DataSet()

			' Fill DataSet with data from dataAdapater
			itemDA.Fill(itemDS, "tblItems")

			' Instantiate BindingSource object
			itemBS = New BindingSource(itemDS, "tblItems")

			' DataTable -   Fill the DataTable object with data
			itemDT = itemDS.Tables("tblItems")

			' Filter BindingSource to include only Type III and Sheeting Items
            Me.itemBS.Filter = "groupID = 3 Or groupID = 16 or groupID = 17"

			CreateItemInfoDictionary()


			With Me.dgvItemList
				.DataSource = itemBS
				.Columns(0).Visible = False
				.Columns(2).Visible = False
			End With


		Catch ex As Exception
			MessageBox.Show(ex.Message, "FillItemList()")

		End Try


	End Sub

	Private Sub FillJoinedCerts()

		Try
            Dim joinCmd As OleDbCommand = New OleDbCommand _
            ("SELECT tblFScertDetails.jobNum As Job, " & _
               "tblFScertDetails.mhsPO As PO, " & _
               "tblFScertDetails.rathcoInvoice As Invoice, " & _
               "tblItems.item As Item, " & _
               "tblFScertItems.itemDetails As Details, " & _
               "tblFScertItems.itemQty As Qty, " & _
               "tblFScertItems.ID As myID, " & _
               "tblFScertItems.detailsID As detID, " & _
               "tblFScertItems.itemID As ifkID, " & _
               "tblFScertDetails.ID As dID, " & _
               "tblItems.ID As iID, " & _
               "tblItems.groupID As gfkID " & _
               "FROM (tblFScertItems " & _
               "INNER JOIN tblFScertDetails ON tblFScertItems.detailsID = tblFScertDetails.ID) " & _
               "INNER JOIN tblItems ON tblFScertItems.itemID = tblItems.ID " & _
               "ORDER By tblFScertItems.ID", objConn)

			' Open connection to Db
			objConn.Open()

			'  Fill dataAdapter with query result from Db
			joinDA = New OleDbDataAdapter(joinCmd)

			' Instantiate DataSet object
			joinDS = New DataSet()

			' Fill DataSet with data from dataAdapater
			joinDA.Fill(joinDS, "tblFScertItems")

			' Instantiate BindingSource object
			joinBS = New BindingSource(joinDS, "tblFScertItems")

			' DataTable -   Fill the DataTable object with data
			joinDT = joinDS.Tables("tblFScertItems")

			'  Close the connection
			objConn.Close()

			RemoveHandler Me.dgvJoinedCerts.SelectionChanged, AddressOf dgvJoinedCerts_SelectionChanged
			With Me.dgvJoinedCerts
				.DataSource = joinBS

				.Columns(0).Visible = False
				.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

				' Item Details field
				'.Columns(4).Visible = False

				.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

				' All Primary/Foreign Key's
				.Columns(6).Visible = False
				.Columns(7).Visible = False
				.Columns(8).Visible = False
				.Columns(9).Visible = False
				.Columns(10).Visible = False
				.Columns(11).Visible = False
			End With
			AddHandler Me.dgvJoinedCerts.SelectionChanged, AddressOf dgvJoinedCerts_SelectionChanged

		Catch ex As Exception
			MessageBox.Show(ex.Message, "FillJoinedCerts()")
			'  Close the connection
			objConn.Close()
		End Try

	End Sub

	Private Sub BindFields()


		Try

			' Clear previous bindings
			Me.txtJob.DataBindings.Clear()
			Me.txtRathcoSalesOrder.DataBindings.Clear()
			Me.txtPO.DataBindings.Clear()
			Me.txtRequestDate.DataBindings.Clear()
			Me.txtRathcoInvoice.DataBindings.Clear()
			Me.txtReceiveDate.DataBindings.Clear()
			Me.txtShipDate.DataBindings.Clear()


			' Bind Fields
			Me.txtJob.DataBindings.Add("Text", certBS, "jobNum")
			Me.txtRathcoSalesOrder.DataBindings.Add("Text", certBS, "rathcoSalesOrder")
			Me.txtPO.DataBindings.Add("Text", certBS, "mhsPO")
			Me.txtRequestDate.DataBindings.Add("Text", certBS, "requestDate", True).FormatString = "MM/dd/yyyy"
			Me.txtRathcoInvoice.DataBindings.Add("Text", certBS, "rathcoInvoice")
			Me.txtReceiveDate.DataBindings.Add("Text", certBS, "rcvDate", True).FormatString = "MM/dd/yyyy"
			Me.txtShipDate.DataBindings.Add("Text", certBS, "shipDate", True).FormatString = "MM/dd/yyyy"



			' Disable fields
			ToggleEnableReqFields(False)

		Catch ex As Exception
			MessageBox.Show(ex.Message, "BindFields()")

		End Try



	End Sub

	Private Sub ClearFields()

		Me.txtItemQty.Clear()
		Me.txtItemDetails.Clear()

	End Sub

	Private Sub ToggleEnableReqFields(ByVal status As Boolean)

		Select Case status

			Case True

				'Enable Fields
				Me.txtJob.Enabled = True
				Me.txtRathcoSalesOrder.Enabled = True
				Me.txtPO.Enabled = True
				Me.txtRequestDate.Enabled = True
				Me.txtReceiveDate.Enabled = True
				Me.txtRathcoInvoice.Enabled = True
				Me.txtShipDate.Enabled = True

			Case False

				'Disable Fields
				Me.txtJob.Enabled = False
				Me.txtRathcoSalesOrder.Enabled = False
				Me.txtPO.Enabled = False
				Me.txtRequestDate.Enabled = False
				Me.txtReceiveDate.Enabled = False
				Me.txtRathcoInvoice.Enabled = False
				Me.txtShipDate.Enabled = False

		End Select

	End Sub



	Private Sub AddCert()

		' Declare local variables and objects
        Dim cmd As OleDbCommand = New OleDbCommand

        ' Item Quantity
        Dim q As Double = 0


		' Open the connection, execute the command
		objConn.Open()

		' Set the OleDbCommand object properties
		cmd.Connection = objConn
		cmd.CommandText = _
		   "INSERT INTO tblFScertItems " & _
		 "(detailsID, itemID, itemQty, itemDetails) " & _
		 "VALUES(@detailsID, @itemID, @itemQty, @itemDetails)"


        ' Add placeholder parameters 
        cmd.Parameters.AddWithValue("@detailsID", CType(Me.dgvRequests.CurrentRow.Cells.Item("ID").Value, Integer))
        cmd.Parameters.AddWithValue("@itemID", CType(Me.dgvItemList.CurrentRow.Cells.Item("ID").Value, Integer))

        'cmd.Parameters.AddWithValue("@itemQty", CType(Me.txtItemQty.Text, Double))

        ' Check for numeric value in Item Quantity Text box
        If Double.TryParse(Me.txtItemQty.Text, q) Then
            cmd.Parameters.AddWithValue("@itemQty", q)
        Else
            MessageBox.Show("You must enter a valid Item Quantity.  Please enter a numeric value.", "Invalid Item Quantity")
            ' Close the connection
            objConn.Close()
            Exit Sub
        End If

        cmd.Parameters.AddWithValue("@itemDetails", CType(Me.txtItemDetails.Text, String))



        'If Me.txtReceiveDate.Text = "" Then
        '	cmd.Parameters.AddWithValue("@rcvDate", DBNull.Value)
        'Else
        '	cmd.Parameters.AddWithValue("@rcvDate", Me.txtReceiveDate.Text)
        'End If


        ' Execute the OleDbCommand object to insert the new data
        Try
            cmd.ExecuteNonQuery()

            ' Close the connection
            objConn.Close()

            ' Reload Data from DB
            'FillCertItems()
            FillJoinedCerts()
            FilterJoinedCerts()


            ClearFields()



        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "AddCert()")

            ' Close the connection
            objConn.Close()

        End Try



    End Sub

	Private Sub AddRequest(ByVal jn As String, ByVal so As String, ByVal po As String, ByVal rd As Date, ByVal ri As String, ByVal rcvd As Date)

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
		cmd.Parameters.AddWithValue("@jobNum", jn)
		'cmd.Parameters.AddWithValue("@rathcoSalesOrder", so)
		'cmd.Parameters.AddWithValue("@mhsPO", po)
		'cmd.Parameters.AddWithValue("@requestDate", rd)
		'cmd.Parameters.AddWithValue("@rathcoInvoice", ri)
		'cmd.Parameters.AddWithValue("@rcvDate", rcvd)


		If so = "" Then
			cmd.Parameters.AddWithValue("@rathcoSalesOrder", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@rathcoSalesOrder", so)
		End If

		If po = "" Then
			cmd.Parameters.AddWithValue("@mhsPO", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@mhsPO", po)
		End If


		'  Convert empty item qty string to dbnull.value
		If rd = Nothing Then
			cmd.Parameters.AddWithValue("@requestDate", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@requestDate", rd)
		End If

		If ri = "" Then
			cmd.Parameters.AddWithValue("@rathcoInvoice", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@rathcoInvoice", ri)
		End If

		If rcvd = Nothing Then
			cmd.Parameters.AddWithValue("@rcvDate", DBNull.Value)
		Else
			cmd.Parameters.AddWithValue("@rcvDate", rcvd)
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



	Private Sub UpdateRequest()

		Try
			'  Write changes back to actual .mdb file
			'  Accept changes from DataGridView object
			Me.Validate()
			Me.dgvRequests.EndEdit()
			Me.certBS.EndEdit()
			Me.certDA.Update(Me.certDS.Tables("tblFScertDetails"))



            '' Hidden 03.19.18 - No need to refresh from datasource at this stage
            '' Refresh DataSet from the DataBase
            'FillCertRequests()
            'Me.certBS.Filter = "jobNum = '" & Me.cmbMhsJob.Text & "'"



            FillJoinedCerts()
            FilterJoinedCerts()

            ' Disable fields
            ToggleEnableReqFields(False)



		Catch ex As Exception
			MessageBox.Show(ex.Message, "UpdateRequest()")

		End Try

	End Sub

	Private Sub FilterJoinedCerts()

		Try
			' Current DataGridView SelectedRow
			Dim x As Integer = Me.dgvRequests.CurrentRow.Index
			'MessageBox.Show(x.ToString)

			' ID value from column 0
			Dim y As Integer = CInt(Me.dgvRequests.CurrentRow.Cells.Item("ID").Value)

			If Me.joinBS IsNot Nothing Then
				Me.joinBS.Filter = "detID = " & y

			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "FilterJoinedCerts()")

		End Try
	End Sub


    Private Sub DeleteReceived()

        Try

            Dim okToDelete As DialogResult = MessageBox.Show("Are you sure you want to delete the current record?", "Delete?", MessageBoxButtons.YesNo)
            If okToDelete = Windows.Forms.DialogResult.Yes Then

                Dim cmdDeleteReceived As New OleDbCommand("Delete From tblFScertItems WHERE ID = @ID", objConn)
                cmdDeleteReceived.Parameters.AddWithValue("@ID", CType(Me.dgvJoinedCerts.CurrentRow.Cells.Item(6).Value, Integer))

                objConn.Open()
                ' use this variable later to display number of records deleted
                Dim updateCount As Integer = cmdDeleteReceived.ExecuteNonQuery()
                objConn.Close()

                FillJoinedCerts()
                FilterJoinedCerts()

                MessageBox.Show(updateCount.ToString & " Record(s) deleted.", "Record Deleted")


                'provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
                'dataFile = "C:\Users\Jimmy\Documents\Test Database.accdb"
                'connString = provider & dataFile
                'myConnection.ConnectionString = connString
                'myConnection.Open()
                'Dim str As String
                'str = "Delete from Items Where UPC = '" & UpcTxtBox.Text & "'"
                'Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
                'Try
                '    cmd.ExecuteNonQuery()
                '    cmd.Dispose()
                '    myConnection.Close()
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try


            ElseIf okToDelete = Windows.Forms.DialogResult.No Then
                Exit Sub

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "DeleteReceived()")

        End Try


    End Sub

	Private Sub UpdateReceived()

		Me.Cursor = Cursors.WaitCursor


		Try

			Dim cmdUpdateReceived As New OleDbCommand("UPDATE tblFScertItems SET " & _
				"detailsID = @detailsID, " & _
				"itemID = @itemID, " & _
				"itemQty = @itemQty, " & _
				"itemDetails = @itemDetails " & _
				"WHERE ID = @ID", objConn)

			cmdUpdateReceived.Parameters.AddWithValue("@detailsID", CType(Me.dgvRequests.CurrentRow.Cells.Item(0).Value, Integer))
			cmdUpdateReceived.Parameters.AddWithValue("@itemID", CType(Me.dgvItemList.CurrentRow.Cells.Item(0).Value, Integer))
			cmdUpdateReceived.Parameters.AddWithValue("@itemQty", CType(Me.txtItemQty.Text, Double))
			cmdUpdateReceived.Parameters.AddWithValue("@itemDetails", Me.txtItemDetails.Text)
			cmdUpdateReceived.Parameters.AddWithValue("@ID", CType(Me.dgvJoinedCerts.CurrentRow.Cells.Item(6).Value, Integer))


			objConn.Open()
			' use this variable later to display number of records updated
			Dim updateCount As Integer = cmdUpdateReceived.ExecuteNonQuery()
            objConn.Close()

            FillJoinedCerts()
            FilterJoinedCerts()

			MessageBox.Show(updateCount.ToString & " Record(s) updated")

		Catch ex As Exception
			MessageBox.Show(ex.Message, "UpdateReceived()")
			objConn.Close()

			signINMain1.tsbStatusLabelLeft.Text = "Error during Update Process.  No Data Has Been Changed."


		End Try

		Me.Cursor = Cursors.Arrow


	End Sub



	Private Sub CreateItemInfoDictionary()
		If Me.itemDT IsNot Nothing Then
			For Each row As DataRow In Me.itemDT.Rows
				Dim i As Integer = CType(row.Item(0), Integer)
				Dim s As String = CType(row.Item(1), String)
				Me.itemInfo.Add(i, s)
			Next
		End If
	End Sub

	Private Sub CreateTypeInfoDictionary()

		'' Available itemID's
		'Dim sTypes() As Integer = {55, 58, 61, 64, 149, 150, 151}

		'' ID
		'Dim i As Integer = Nothing

		'' Type Details
		'Dim s As String = Nothing

		'' Loop Integer Array and add Key/Value Pair to the Dictionary
		'For Each i In sTypes
		'	Select Case i
		'		Case 55, 58
		'			s = "IIIA"
		'		Case 64, 61
		'			s = "IIIB"
		'		Case 149 To 151
		'			s = "Decals"
		'	End Select
		'	Me.typeInfo.Add(s, i)
		'Next




		'Dim months() As String = {"Jan", "Feb", "Mar", "Apr", "May"}
		'Dim element As String

		'For Each element In months
		'	'Your code here
		'Next element




	End Sub



	''' <summary>
	''' Sums value of itemQty (tblFScertItems.itemQty) by given itemID (tblItems.ID)
	''' </summary>
	''' <param name="x">itemID</param>
	''' <param name="dt">joinBS - Datatable</param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function SumTypeValues(ByVal x As Integer, ByVal dt As DataTable) As Double
		Dim d As Double = 0
		Try
			d = CType(dt.Compute("SUM(Qty)", "iID = " & x), Double)
			If d >= 0 Then
				Return d
			Else
				Return 0
			End If
		Catch ex As Exception
			Return 0
		End Try
	End Function

	''' <summary>
	''' Loop through flatsheet items and sum each type
	''' </summary>
	''' <remarks></remarks>
	Private Sub LoopAndSum()

		Try
			' Clear List Items
			Me.ListBox1.Items.Clear()

			'Me.joinBS.Filter = "job = '" & Me.txtJob.Text & "'"
			Dim dtbl As DataTable = CType(Me.joinBS.List, DataView).ToTable
			'MessageBox.Show(dtbl.Rows.Count.ToString & " Rows in joinBS.List/dtbl")

			' Counter for Type Sum
			'IIIA
			Dim a As Double = 0
			'IIIB
			Dim b As Double = 0
			'DECALS
            Dim d As Double = 0
            'VA
            Dim e As Double = 0
            'VB
            Dim f As Double = 0
            'visi
            Dim g As Double = 0
           

			' Available itemID's
            Dim sTypes() As Integer = {55, 58, 61, 64, 149, 150, 151, 172, 173, 174, 175}

			For Each i As Integer In sTypes
				Select Case i
					Case 55, 58
						a += SumTypeValues(i, dtbl)
					Case 61, 64
						b += SumTypeValues(i, dtbl)
					Case 149 To 151
                        d += SumTypeValues(i, dtbl)
                    Case 172 To 173
                        f += SumTypeValues(i, dtbl)
                    Case 174 To 175
                        e += SumTypeValues(i, dtbl)
                    Case 153
                        g += SumTypeValues(i, dtbl)
                End Select
			Next

			With Me.ListBox1.Items
				.Add("IIIA = " & a.ToString)
                .Add("IIIB = " & b.ToString)
                .Add("VA = " & e.ToString)
                .Add("VB = " & f.ToString)
                .Add("Visi = " & g.ToString)
                .Add("Decals = " & d.ToString)
			End With


		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoopAndSum()")
		End Try



	End Sub

	''' <summary>
	''' Upon selecting an item from a specific certification received
	''' Select the corresponding item in the Items List DataGridView by
	''' iterating/looping each row and selecting the row matching the ID
	''' </summary>
	''' <param name="i">ID</param>
	''' <param name="q">itemQty</param>
	''' <param name="d">itemDetails</param>
	''' <remarks></remarks>
	Private Sub SyncCertItems(ByVal i As Integer, ByVal q As Double, ByVal d As String)

		Try
			If Me.dgvItemList IsNot Nothing Then
				For Each row As DataGridViewRow In Me.dgvItemList.Rows
					If CType(row.Cells.Item(0).Value, Integer) = i Then
						row.Selected = True
					Else
						row.Selected = False
					End If
				Next
			End If

			With Me.txtItemQty
				.Clear()
				.Text = q.ToString
			End With

			With Me.txtItemDetails
				.Clear()
				.Text = d
			End With
			
		Catch ex As Exception
			MessageBox.Show(ex.Message, "SyncCertItems(i, q, d)")

		End Try




	End Sub

	Private Sub DisplayTypeImage()






	End Sub




	Private Sub FindNotRcvd()

		For Each row As DataGridViewRow In Me.dgvRequests.Rows


			If row.Cells.Item("rcvDate").Value Is DBNull.Value Then
				row.DefaultCellStyle.BackColor = Color.Red
			End If

		Next


	End Sub





	' Not used yet - 06.22.2012
	Private Sub CreateJobInfoDictionary()

		For Each row As DataRow In Me.jobDT.Rows
			Dim jn As String = CType(row.Item(0), String)
			Dim jt As String = CType(row.Item(1), String)
			Me.jobInfo.Add(jn, jt)
		Next



	End Sub



	' Not used yet - 06.21.2012
	Private Sub NotReceivedDGVBackColor()

		' Change Cursor, Signal to user the application is thinking
		Me.Cursor = Cursors.WaitCursor

		Dim switchBackColor As Boolean = False
		Dim prevSite As String = Nothing
		Dim x As Integer = 0  ' Counter to switch row colors 
		Dim d As Date = Nothing
		Dim LightBackColor As New Color
		Dim DarkBackColor As New Color

		LightBackColor = Color.WhiteSmoke
		DarkBackColor = Color.Aquamarine

		'Dim oFont As New Font(Me.QryDPDataGridView.Font, FontStyle.Regular)
		'Me.QryDPDataGridView.Rows(rowindex).DefaultCellStyle = BoldRow


		Try

			' Set initial backcolor here
			'Me.QryDPDataGridView.DefaultCellStyle.BackColor = LightBackColor
			Me.dgvRequests.DefaultCellStyle.BackColor = LightBackColor


			For Each row As DataGridViewRow In Me.dgvRequests.Rows

				Try
					d = CDate(row.Cells.Item("requestDate").Value)
				Catch ex As Exception
					d = Nothing
				End Try

				If d <> Nothing Then
					row.DefaultCellStyle.BackColor = DarkBackColor
				Else
					row.DefaultCellStyle.BackColor = LightBackColor
				End If

				'' If stations numbers are different then respond accordingly
				'If row.Cells.Item(3).Value.ToString = prevSite Then
				'	switchBackColor = False
				'	Select Case x
				'		Case 0
				'			' Maintain
				'			row.DefaultCellStyle.BackColor = LightBackColor
				'		Case 1
				'			row.DefaultCellStyle.BackColor = DarkBackColor
				'			x = 1
				'	End Select
				'Else
				'	If x = 0 Then
				'		row.DefaultCellStyle.BackColor = DarkBackColor
				'		x = 1
				'	Else
				'		row.DefaultCellStyle.BackColor = LightBackColor
				'		x = 0
				'	End If
				'End If

				'' Detect color and switch to alternate color
				'Select Case switchBackColor
				'	Case True
				'		row.DefaultCellStyle.BackColor = DarkBackColor
				'	Case False
				'		' Do Nothing
				'End Select

				'' Remember the Previous Station Number (Site)
				'prevSite = row.Cells.Item(3).Value.ToString

			Next

		Catch ex As Exception
			MessageBox.Show(ex.Message, "NotReceivedDGVBackColor()")
		Finally

			' Change Cursor to Normal
			Me.Cursor = Cursors.Arrow
		End Try


	End Sub






#End Region



#Region " Event Handlers"

	'  Form/Class Objects

	Private Sub frmCertReceive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

		If ((e.KeyCode = Keys.F) AndAlso (e.Modifiers = (Keys.Control))) Then
			''  Keyboard shortcut - "ctrl+F" 
			'e.SuppressKeyPress = True

			'ElseIf (e.KeyCode = Keys.F2) Then


		ElseIf ((e.KeyCode = Keys.N) AndAlso (e.Modifiers = (Keys.Control))) Then
			Me.btnNew_Click(Nothing, Nothing)
			e.SuppressKeyPress = True

			'ElseIf ((e.KeyCode = Keys.B) AndAlso (e.Modifiers = (Keys.Control))) Then
			'	e.SuppressKeyPress = True

			'ElseIf (e.KeyCode = Keys.F5) Then

		ElseIf ((e.KeyCode = Keys.U) AndAlso (e.Modifiers = (Keys.Control))) Then
			Me.btnSave_Click(Nothing, Nothing)
			e.SuppressKeyPress = True
		End If


	End Sub

	Private Sub frmCertReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        FillJobList()

        FillCertRequests()

        FillJoinedCerts()
        
		FillItemList()

		'FillCertItems()



	End Sub

	Private Sub joinBS_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles joinBS.ListChanged
		'FindNotRcvd()

	End Sub



	' Combo Boxes

	Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged

		Try
			If Me.certBS IsNot Nothing Then Me.certBS.Filter = "jobNum = '" & Me.cmbMhsJob.Text & "'"
            If Me.joinBS IsNot Nothing Then Me.joinBS.Filter = "job = '" & Me.cmbMhsJob.Text & "'"

        Catch ex As Exception
            'Me.certBS.Filter = Nothing
            'Me.joinBS.Filter = Nothing

		End Try

	End Sub



	' DataGridViews

	Private Sub dgvRequests_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRequests.SelectionChanged

		If Me.dgvRequests.CurrentRow IsNot Nothing Then
			FilterJoinedCerts()
		End If



	End Sub

	Private Sub dgvJoinedCerts_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvJoinedCerts.SelectionChanged

		Dim ii As Integer = 0
		Dim iQ As Double = 0
		Dim iD As String = Nothing

		Try
			Dim row As DataGridViewRow = Me.dgvJoinedCerts.CurrentRow

			ii = CType(row.Cells.Item(8).Value, Integer)
			iQ = CType(row.Cells.Item(5).Value, Double)
			iD = CType(row.Cells.Item(4).Value, String)

		Catch ex As Exception
			'MessageBox.Show(ex.Message, "dgvJoinedCerts_SelectionChanged()")
		End Try

		' Synchronize other Data Controls with currently
		' selected cert item
		SyncCertItems(ii, iQ, iD)


	End Sub



	' Buttons

	Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

		If Me.txtPO.Enabled Then
			ToggleEnableReqFields(False)
		Else
			ToggleEnableReqFields(True)
		End If

	End Sub

	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		UpdateRequest()

	End Sub

	Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
		FillCertRequests()

	End Sub

	Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

		Dim reqD As Date = Nothing
		Dim rcvD As Date = Nothing
		Try
			Dim addNew As New dlgAddCert
			If addNew.ShowDialog = Windows.Forms.DialogResult.OK Then
				Date.TryParse(addNew.requestDate, reqD)
				Date.TryParse(addNew.rcvDate, rcvD)
				AddRequest(Me.cmbMhsJob.Text, addNew.rathcoSalesOrder, addNew.mhsPO, reqD, addNew.rathcoInvoice, rcvD)
                cmbMhsJob_SelectedIndexChanged(Nothing, Nothing)

                ' Re-filter Joine Certs DGV
                FilterJoinedCerts()

			End If
			addNew.Dispose()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnNew_Click()", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand)
		End Try

	End Sub

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

		AddCert()



	End Sub

	Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

		Try
			Me.joinBS.Filter = "Job = '" & Me.cmbMhsJob.Text & "'"

		Catch ex As Exception

		End Try

	End Sub

	Private Sub btnSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSum.Click

		LoopAndSum()

	End Sub

	Private Sub bntUpdateRcvd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntUpdateRcvd.Click

		UpdateReceived()

	End Sub

    Private Sub btnDeleteCertRcvd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCertRcvd.Click

        DeleteReceived()

    End Sub



	Private Sub TextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPO.Validating, _
		txtRathcoSalesOrder.Validating, _
		txtRathcoInvoice.Validating, _
		txtReceiveDate.Validating, _
		txtRequestDate.Validating, _
		txtShipDate.Validating

		Dim CurrentBox As TextBox = DirectCast(sender, TextBox)

		If CurrentBox.Text = String.Empty Then
			Dim currentRow As DataRowView = TryCast(certBS.Current, DataRowView)
			Dim FieldName As String = CurrentBox.DataBindings.Item("Text").BindingMemberInfo.BindingField

			currentRow.Row(FieldName) = System.DBNull.Value

		End If

	End Sub

	Private Sub txtJob_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtJob.Validating

		Try

			Dim s As String = Me.txtJob.Text
			Dim x As Integer = 0

			For Each row As DataRow In Me.jobDT.Rows
				If row.Item("mhsJob").ToString = s.ToUpper Then
					x = 0
					Exit For
				Else
					x = -1
				End If
			Next

			If x = -1 Then
				e.Cancel = True
				MessageBox.Show("Choose a valid Job Number.", "Job Not Found!")
				Me.txtJob.Select(0, Me.txtJob.Text.Length)

			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "txtJob_Validating()")
		End Try

	End Sub


    Private Sub txtItemQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemQty.GotFocus

        Me.txtItemQty.SelectAll()

    End Sub
















#End Region






    Private Sub TestDataPreserved()


        'Try
        '	Dim CurrentBox = DirectCast(sender, TextBox)

        '	If CurrentBox.Text.Equals(String.Empty) Then
        '		Dim currentRow As DataRowView = TryCast(certBS.Current, DataRowView)
        '		Dim FieldName As String = CurrentBox.DataBindings.Item("Text") _
        '		  .BindingMemberInfo.BindingField

        '		currentRow.Row(FieldName) = System.DBNull.Value
        '		'If chkUseNull.Checked Then
        '		'	currentRow.Row(FieldName) = System.DBNull.Value
        '		'Else
        '		'	currentRow.Row(FieldName) = 0
        '		'End If
        '	End If
        'Catch ex As Exception

        'End Try



    End Sub


    Private Sub SendGmail()

        Dim smtpServer As New System.Net.Mail.SmtpClient()
        Dim mail As New System.Net.Mail.MailMessage

        With smtpServer
            .Credentials = New Net.NetworkCredential("yourEmail@gmail.com", "yourPassword")
            .Port = 587
            .EnableSsl = True
            .Host = "smtp.gmail.com"
        End With

        mail = New System.Net.Mail.MailMessage()
        With mail
            .From = New System.Net.Mail.MailAddress("yourEmail@gmail.com")
            .To.Add("yourRecipientEmail@ddress.com")
            .Subject = "Your Subject"
            .Body = "Your Message Here"
        End With

        smtpServer.Send(mail)

        MessageBox.Show("Your message has been sent", "Sent!")


    End Sub







    
End Class