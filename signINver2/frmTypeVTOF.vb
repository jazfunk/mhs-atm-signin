Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.clsUtilities



Public Class frmTypeVTOF

#Region " Class-Level Declarations"

	Private dctFSSpt As New Dictionary(Of String, String)
	Private dctSheeting As New Dictionary(Of String, String)




#End Region


#Region " Database Communication"



	' Connection to Action Traffic.mdb
	'Dim ATMconn1 As New OleDbConnection(atmConnStr01)
	Dim atmConn1 As New OleDbConnection(My.Settings.ATMconn)

	' Connection to db1.mdb
	'Dim mhsConn As New OleDbConnection(connStr01)
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

	' MHS Jobs
	Dim mhsJobDA As OleDbDataAdapter
	Dim mhsJobDS As DataSet
	Dim mhsJobDV As DataView
	Dim mhsJobDT As DataTable

	' PW/FS Sheeting
	Dim allSheetDA As OleDbDataAdapter
	Dim allSheetDS As DataSet
	Dim allSheetDV As DataView
	Dim allSheetDT As DataTable

	' FlatSheet support/hardware
	Dim fsSptDA As OleDbDataAdapter
	Dim fsSptDS As DataSet
	Dim fsSptDT As DataTable
	Dim fsSptDV As DataView

	' Sign Codes
	Dim scDA As OleDbDataAdapter
	Dim scBS As BindingSource
	Dim scDS As DataSet
	Dim scDT As DataTable
	Dim scDV As DataView

	' PreSet Sign Details
	Dim detailsDA As OleDbDataAdapter
	Dim detailsDS As DataSet
	Dim detailsDT As DataTable
	Dim detailsDV As DataView













#End Region


#Region " Properties"


#End Region


#Region " Methods & Functions"


	Public Sub PopulateMHSJobs()

		Try

			mhsJobDA = New OleDbDataAdapter("SELECT * FROM mhsJobs WHERE Active = True ORDER By mhsJob DESC", mhsConn)

			' Initialize a new instance of the DataSet object
			mhsJobDS = New DataSet()

			' Open the connection, execute the command
			mhsConn.Open()

			' Fill DataSet
			mhsJobDA.Fill(mhsJobDS, "mhsJobs")

			' Close the connection
			mhsConn.Close()

			' DataTable -   Fill the DataTable object with data
			mhsJobDT = mhsJobDS.Tables("mhsJobs")

			' Set the DataView object to the DataSet object
			mhsJobDV = New DataView(mhsJobDS.Tables("mhsJobs"))

			'Me.tsbLblMHSJob.Text = String.Empty

			'RemoveHandler tsbCmbMHSJob.SelectedIndexChanged, AddressOf tsbCmbMHSJob_SelectedIndexChanged
			' Populate cmbMHSJob combo box
			With Me.cmbMhsJob
				.DataSource = mhsJobDT
				.DisplayMember = "mhsJob"
			End With
			'AddHandler tsbCmbMHSJob.SelectedIndexChanged, AddressOf tsbCmbMHSJob_SelectedIndexChanged

			Me.cmbMhsJob.Text = "Select"


		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateMHSJobs()")

		End Try



	End Sub

	Public Sub PopulateSignCodes()

		Try

			Dim sCCmd As OleDbCommand = New OleDbCommand _
			 ("SELECT * FROM tblSignCodes ORDER By code", mhsConn)

			' Open connection to Db
			mhsConn.Open()

			'  Fill dataAdapter with query result from Db
			scDA = New OleDbDataAdapter(sCCmd)

			' Instantiate DataSet object
			scDS = New DataSet()

			' Fill DataSet with data from dataAdapater
			scDA.Fill(scDS, "tblSignCodes")

			'  Close the connection
			mhsConn.Close()

			' Create binding source
			scBS = New BindingSource(scDS, "tblSignCodes")

			' DataTable -   Fill the DataTable object with data
			scDT = scDS.Tables("tblSignCodes")

		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateSignCodes()")
		End Try


	End Sub

	Private Sub BindSignCodeFields()

		Try

			' Set the Dataview object to the Dataset object
			'scDV = New DataView(scDS.Tables("tblSignCodes"))

			With Me.cmbSignCodes
				.DataSource = scBS
				.DisplayMember = "code"
				'.SelectedIndex = -1
				.Text = "Select"
			End With

			' Clear previous DataBindings
			Me.lblPdfTitle.DataBindings.Clear()
			Me.lblSignCodeDesc.DataBindings.Clear()
			Me.lblType.DataBindings.Clear()

			' Add DataBindings
			Me.lblPdfTitle.DataBindings.Add("Text", scBS, "pdfTitle")
			Me.lblSignCodeDesc.DataBindings.Add("Text", scBS, "description")
			Me.lblType.DataBindings.Add("Text", scBS, "type")


		Catch ex As Exception
			MessageBox.Show(ex.Message, "BindSignCodeFields()")
		End Try



	End Sub

	Public Sub PopulateDetails()

		Try
			Dim detailsCmd As OleDbCommand = New OleDbCommand _
				 ("SELECT details FROM signDetails ORDER BY details", mhsConn)

			' Open the connection, execute the command
			mhsConn.Open()

			'  Fill dataAdapter with query result from Db
			detailsDA = New OleDbDataAdapter(detailsCmd)

			' Instantiate DataSet object
			detailsDS = New DataSet()

			' Fill DataSet
			detailsDA.Fill(detailsDS, "signDetails")

			' Set the Dataview object to the Dataset object
			detailsDV = New DataView(detailsDS.Tables("signDetails"))

			' Fill the DataTable object with data
			detailsDT = detailsDS.Tables("signDetails")


		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateDetails()")
		End Try

	End Sub

	Private Sub BindDetails()

		Try

			With Me.cmbDetails
				.DataSource = Nothing
				.DataSource = detailsDT
				.DisplayMember = "details"
				.Text = "Preset Details"
			End With

			' Close the connection
			mhsConn.Close()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "BindDetails()")
		End Try

	End Sub

	Public Sub PopulateFSSupport()

		Try
			Dim fsSptCmd As OleDbCommand = New OleDbCommand _
				  ("SELECT FSpostType, FShardware FROM FSsupport ORDER BY FSpostType", mhsConn)

			' Open the connection, execute the command
			mhsConn.Open()

			'  Fill dataAdapter with query result from Db
			fsSptDA = New OleDbDataAdapter(fsSptCmd)

			' Instantiate DataSet object
			fsSptDS = New DataSet()

			' Fill DataSet
			fsSptDA.Fill(fsSptDS, "FSsupport")

			' Fill the DataTable object with data
			fsSptDT = fsSptDS.Tables("FSsupport")

			' Set the DataView object to the DataSet object
			fsSptDV = New DataView(fsSptDS.Tables("FSsupport"))

			' Close the connection
			mhsConn.Close()




		Catch ex As Exception

		End Try


	End Sub

	Private Sub BindFSSpt()

		Try

			If Me.dctFSSpt.Count <= 0 Then

				'...............DICTIONARY..............

				' Add "Select ..." at Item(0)
				Me.dctFSSpt.Add("Select Type V Support", String.Empty)

				' Iterate through DataTable and add each row 
				' to the Dictionary
				For Each row As DataRow In fsSptDT.Rows
					' Add Key/Value to the Dictionary
					dctFSSpt.Add(row.Item(0).ToString, row.Item(1).ToString)
				Next

			End If


			' Create list of the Values of the Dictionary (String Heights, in this case)
			Dim lstFSSPTKeys As New List(Of String)(dctFSSpt.Keys)
			Me.cmbPostType.DataSource = Nothing
			Me.cmbPostType.DataSource = lstFSSPTKeys


		Catch ex As Exception
			MessageBox.Show(ex.Message, "BindFSSpt()")
		End Try

	End Sub

	Public Sub PopulateFSSheeting()

		Try

			Dim allSheetCmd As OleDbCommand = New OleDbCommand _
			   ("SELECT sheetNum, sheetDesc FROM sheetingType ORDER By sheetNum", mhsConn)

			' Open the connection, execute the command
			mhsConn.Open()

			'  Fill dataAdapter with query result from Db
			allSheetDA = New OleDbDataAdapter(allSheetCmd)

			' Instantiate DataSet object
			allSheetDS = New DataSet()

			' Fill DataSet
			allSheetDA.Fill(allSheetDS, "sheetingType")

			' Fill the DataTable object with data
			allSheetDT = allSheetDS.Tables("sheetingType")

			' Set the DataView object to the DataSet object
			allSheetDV = New DataView(allSheetDS.Tables("sheetingType"))

			' Close the connection
			mhsConn.Close()



			'...............DICTIONARY..............

			' Add "Select ..." at Item(0)
			Me.dctSheeting.Add("Select Sheeting", String.Empty)

			' Iterate through DataTable and add each row 
			' to the Dictionary
			For Each row As DataRow In allSheetDT.Rows
				' Add Key/Value to the Dictionary
				dctSheeting.Add(row.Item(0).ToString, row.Item(1).ToString)
			Next

			' Create list of The Key's of the Dictionary (sheeting description, in this case)
			Dim lstSheeting As New List(Of String)(dctSheeting.Keys)
			Me.cmbSheetType.DataSource = lstSheeting

		Catch ex As Exception

		End Try




	End Sub



#End Region


#Region " Event Handlers"

	Private Sub frmTypeVTOF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


		' Fill DataSet with DataAdapter connected to DataBase
		PopulateFSSupport()
		PopulateFSSheeting()
		PopulateMHSJobs()
		PopulateSignCodes()
		PopulateDetails()

		BindSignCodeFields()
		BindDetails()
		BindFSSpt()




	End Sub

#End Region






End Class