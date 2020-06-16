Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.clsUtilities



Public Class frmLogoTakeOff

#Region " Class-Level Declarations"


	'Dim dtbl As DataTable = CType(Me.QryMyDPTodayBindingSource.List, DataView).ToTable

	Dim importedDA As OleDbDataAdapter
	Dim importedDS As DataSet
	Dim importedBS As BindingSource
	Dim importedDT As DataTable


#End Region



#Region " Properties"




#End Region



#Region " Database Communication"

	Dim sIv2Con As New OleDbConnection(My.Settings.SignINconn)

	' Logo Take Off
	Dim logoDA As OleDbDataAdapter
	Dim logoBS As BindingSource
	Dim logoDS As DataSet
	Dim logoDT As DataTable
	Dim logoCloneDT As DataTable


	' Work Order Grouping
	Dim woDA As OleDbDataAdapter
	Dim woBS As BindingSource
	Dim woDS As DataSet
	Dim woDT As DataTable


	

#End Region




#Region " Methods & Functions"

	Private Sub LoadTakeOff()

		Try

			'  connection to database
			Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
			 "StructureNumber, " & _
			 "OrderedDate, " & _
			 "Width, " & _
			 "Height, " & _
			 "WorkType, " & _
			 "Comments, " & _
			 "CompletionDate, " & _
			 "County, " & _
			 "Crossroad, " & _
			 "City, " & _
			 "Latitude, " & _
			 "Longitude, " & _
			 "Route, " & _
			 "Exit, " & _
			 "Direction, " & _
			 "Service, " & _
			 "sType " & _
			 "FROM tblLogoWorkOrderImport " & _
			 "ORDER By OrderedDate", sIv2Con)


			' Open connection to Db
			sIv2Con.Open()

			'  Fill dataAdapter with query result from Db
			logoDA = New OleDbDataAdapter(cmd)

			'  Close the connection
			sIv2Con.Close()

			'One CommandBuilder object is required. 
			'It automatically generates DeleteCommand, 
			'UpdateCommand and InsertCommand 
			'for DataAdapter object      
			Dim logoBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(logoDA)

			' Instantiate DataSet object
			logoDS = New DataSet()

			' Fill DataSet with data from dataAdapater
			logoDA.Fill(logoDS, "tblLogoWorkOrderImport")


			' DataTable -   Fill the DataTable object with data
			logoDT = logoDS.Tables("tblLogoWorkOrderImport")

			'' Set the Dataview object to the Dataset object
			'logoDV = New DataView(logoDS.Tables("tblLogoWorkOrderImport"))

			logoBS = New BindingSource(logoDS, "tblLogoWorkOrderImport")

			GroupWorkOrderDates()


			'Me.dgvLogoTOF.DataSource = logoBS

			'Me.tb_Latitude.DataBindings.Clear()
			'Me.tb_Longitude.DataBindings.Clear()

			'Me.tb_Latitude.DataBindings.Add("Text", logoBS, "Latitude")
			'Me.tb_Longitude.DataBindings.Add("Text", logoBS, "Longitude")



		Catch ex As Exception
			MessageBox.Show(ex.Message)

		End Try


	End Sub

	Private Sub sortLike(ByVal searchSTR As String)


		Try
			Dim str2 As String
			Dim dbl2 As Double
			Dim date2 As Date
			Dim field As Integer = Me.cmbFields.SelectedIndex
			Dim fieldName As String = Nothing

			Select Case field

				Case 0
					fieldName = "StructureNumber"
					dbl2 = CDbl(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, dbl2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 1, 6
					If field = 1 Then fieldName = "OrderedDate" Else fieldName = "CompletionDate"
					date2 = CDate(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("{0} = #{1:M/dd/yyyy}#", fieldName, date2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 2
					fieldName = "Width"
					dbl2 = CDbl(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, dbl2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 3
					fieldName = "Height"
					dbl2 = CDbl(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, dbl2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 4
					fieldName = "WorkType"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 5
					fieldName = "Comments"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 7
					fieldName = "County"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 8
					fieldName = "Crossroad"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 9
					fieldName = "City"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 10
					fieldName = "Latitude"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 11
					fieldName = "Longitude"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 12
					fieldName = "Route"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 13
					fieldName = "Exit"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 14
					fieldName = "Direction"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 15
					fieldName = "Service"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


				Case 16
					fieldName = "sType"
					str2 = CStr(searchSTR)
					Me.logoCloneDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
					Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.logoCloneDT.DefaultView.Count.ToString & " Records)"


			End Select

			



		Catch ex As Exception

			'MessageBox.Show(ex.Message, "exception from sortLike sub")
			'Me.fsTOFDV.RowFilter = Nothing

			'Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  (" & Me.fsTOFDV.Count & " Records)"
			'Me.txtCriteria.Clear()

		End Try

	End Sub

	Private Sub GroupWorkOrderDates()

		Try

			'  connection to database
			Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
			 "OrderedDate " & _
			 "FROM tblLogoWorkOrderImport " & _
			 "GROUP By OrderedDate ORDER By OrderedDate", sIv2Con)
			
			' Open connection to Db
			sIv2Con.Open()

			'  Fill dataAdapter with query result from Db
			woDA = New OleDbDataAdapter(cmd)

			'  Close the connection
			sIv2Con.Close()

			' Instantiate DataSet object
			woDS = New DataSet()

			' Fill DataSet with data from dataAdapater
			woDA.Fill(woDS, "tblLogoWorkOrderImport")

			' DataTable -   Fill the DataTable object with data
			woDT = woDS.Tables("tblLogoWorkOrderImport")

			'Me.cmbWorkOrderDate.DataSource = woDT
			With Me.cmbWorkOrderDate
				.DataSource = woDT
				.DisplayMember = "OrderedDate"
			End With

		Catch ex As Exception
			MessageBox.Show(ex.Message)

		End Try

	End Sub

	Private Sub LoadXLS()
		Try


			Dim OpenFileDialog1 As New OpenFileDialog
			With OpenFileDialog1
				.FileName = ""
				.Title = "Import Work Order (.xls File)"
				.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
				.Filter = "Excel files|*.xls"
			End With

			If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
				Dim FileName As String = OpenFileDialog1.FileName
				Dim Builder As New OleDbConnectionStringBuilder With {.DataSource = FileName}
				'Me.btnLoadXML.Text = FileName

				If IO.Path.GetExtension(FileName) = ".XLSX" Then
					Builder.Provider = "Microsoft.ACE.OLEDB.12.0"
					Builder.Add("Extended Properties", "Excel 12.0;HDR=Yes;")
				Else
					Builder.Provider = "Microsoft.Jet.OLEDB.4.0"
					Builder.Add("Extended Properties", "Excel 8.0;HDR=Yes;")
				End If

				Using cn As New OleDbConnection With {.ConnectionString = Builder.ConnectionString}

					Dim cmd As New OleDbCommand With _
					{ _
					 .CommandText = "SELECT * FROM [" & IO.Path.GetFileNameWithoutExtension(FileName) & "$]", _
					 .Connection = cn _
					}
					cn.Open()
					'  Fill dataAdapter with query result from XLS file
					importedDA = New OleDbDataAdapter(cmd)

					' Instantiate DataSet object
					importedDS = New DataSet()

					' Fill DataSet with data from dataAdapater
					importedDA.Fill(importedDS, "tblLogoWorkOrderImport")

					importedBS = New BindingSource(importedDS, "tblLogoWorkOrderImport")

					' DataTable -   Fill the DataTable object with data
					importedDT = importedDS.Tables("tblLogoWorkOrderImport")

					'Dim dt As New DataTable
					'dt.Load(cmd.ExecuteReader)
					Me.dgvLogoTOF.DataSource = importedBS

					BindImportedFields()

					'Me.tb_Latitude.DataBindings.Clear()
					'Me.tb_Longitude.DataBindings.Clear()
					'Me.tb_Latitude.DataBindings.Add("Text", importedBS, "Latitude")
					'Me.tb_Longitude.DataBindings.Add("Text", importedBS, "Longitude")

				End Using
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoadXML()")

		End Try


	End Sub


	Private Sub BindImportedFields()


		Me.tb_Latitude.DataBindings.Clear()
		Me.tb_Longitude.DataBindings.Clear()
		Me.tb_Latitude.DataBindings.Add("Text", importedBS, "Latitude")
		Me.tb_Longitude.DataBindings.Add("Text", importedBS, "Longitude")


		Me.txtStructureNumber.DataBindings.Clear()
		Me.txtOrderedDate.DataBindings.Clear()
		Me.txtWidth.DataBindings.Clear()
		Me.txtHeight.DataBindings.Clear()
		Me.txtWorkType.DataBindings.Clear()
		Me.txtComments.DataBindings.Clear()
		Me.txtCompletionDate.DataBindings.Clear()
		Me.txtCounty.DataBindings.Clear()
		Me.txtCrossRoad.DataBindings.Clear()
		Me.txtCity.DataBindings.Clear()
		Me.txtLatitude.DataBindings.Clear()
		Me.txtLongitude.DataBindings.Clear()
		Me.txtRoute.DataBindings.Clear()
		Me.txtExit.DataBindings.Clear()
		Me.txtDirection.DataBindings.Clear()
		Me.txtService.DataBindings.Clear()
		Me.txtsType.DataBindings.Clear()

		Me.txtStructureNumber.DataBindings.Add("Text", Me.importedBS, "StructureNumber")
		Me.txtOrderedDate.DataBindings.Add("Text", Me.importedBS, "OrderedDate", True).FormatString = "MM/dd/yyyy"
		Me.txtWidth.DataBindings.Add("Text", Me.importedBS, "Width")
		Me.txtHeight.DataBindings.Add("Text", Me.importedBS, "Height")
		Me.txtWorkType.DataBindings.Add("Text", Me.importedBS, "WorkType")
		Me.txtComments.DataBindings.Add("Text", Me.importedBS, "Comments")
		Me.txtCompletionDate.DataBindings.Add("Text", Me.importedBS, "CompletionDate", True).FormatString = "MM/dd/yyyy"
		Me.txtCounty.DataBindings.Add("Text", Me.importedBS, "County")
		Me.txtCrossRoad.DataBindings.Add("Text", Me.importedBS, "CrossRoad")
		Me.txtCity.DataBindings.Add("Text", Me.importedBS, "City")
		Me.txtLatitude.DataBindings.Add("Text", Me.importedBS, "Latitude")
		Me.txtLongitude.DataBindings.Add("Text", Me.importedBS, "Longitude")
		Me.txtRoute.DataBindings.Add("Text", Me.importedBS, "Route")
		Me.txtExit.DataBindings.Add("Text", Me.importedBS, "Exit")
		Me.txtDirection.DataBindings.Add("Text", Me.importedBS, "Direction")
		Me.txtService.DataBindings.Add("Text", Me.importedBS, "Service")
		Me.txtsType.DataBindings.Add("Text", Me.importedBS, "sType")


	End Sub


#End Region



#Region " Event Handlers"




	Private Sub frmLogoTakeOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		RemoveHandler cmbWorkOrderDate.SelectedIndexChanged, AddressOf cmbWorkOrderDate_SelectedIndexChanged
		LoadTakeOff()
		AddHandler cmbWorkOrderDate.SelectedIndexChanged, AddressOf cmbWorkOrderDate_SelectedIndexChanged


	End Sub

	Private Sub btn_ShowMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ShowMap.Click

		Dim strLat As String = CType(Me.dgvLogoTOF.CurrentRow.Cells.Item("Latitude").Value, String)
		Dim strLon As String = CType(Me.dgvLogoTOF.CurrentRow.Cells.Item("Longitude").Value, String)
		Dim googleQuery As String = "http://maps.google.com/maps?q=" & strLat & "%2C" & strLon

		'Dim dblLat As Double = CType(Me.dgvLogoTOF.CurrentRow.Cells.Item("Latitude").Value, Double)
		'Dim dblLon As Double = CType(Me.dgvLogoTOF.CurrentRow.Cells.Item("Longitude").Value, Double)
		'Dim googleQuery As String = "http://maps.google.com/maps?q=" & dblLat.ToString & "%2C" & dblLon.ToString

		'Dim googleQuery As String = "http://maps.google.com/maps?q=" & Me.tb_Latitude.Text & "%2C" & Me.tb_Longitude.Text

		System.Diagnostics.Process.Start(googleQuery)

	End Sub

	Private Sub txtCriteria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
		sortLike(Me.txtCriteria.Text)
	End Sub


	Private Sub cmbWorkOrderDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkOrderDate.SelectedIndexChanged

		'Try
		'	Me.logoBS.Filter = String.Format("{0} = #{1:M/dd/yyyy}#", "OrderedDate", CDate(Me.cmbWorkOrderDate.Text))
		'	Me.txtStatusText.Text = "Logo T/O >>  Filter On:  [OrderedDate]    Search:  """ & Me.cmbWorkOrderDate.Text & """     (" & Me.logoBS.List.Count & " Records)"

		'	Me.logoCloneDT = CType(Me.logoBS.List, DataView).ToTable

		'	Me.dgvLogoTOF.DataSource = logoCloneDT

		'	Me.tb_Latitude.DataBindings.Clear()
		'	Me.tb_Longitude.DataBindings.Clear()

		'	Me.tb_Latitude.DataBindings.Add("Text", logoCloneDT, "Latitude")
		'	Me.tb_Longitude.DataBindings.Add("Text", logoCloneDT, "Longitude")


		'Catch ex As Exception
		'	MessageBox.Show(ex.Message, "cmbWorkOrderDate_SelectedIndexChanged()")

		'End Try



	End Sub

	Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click

		Try
			Me.logoBS.Filter = Nothing
			Me.txtStatusText.Text = "Logo T/O (All Orders) >>  (" & Me.logoBS.List.Count & " Records)"

			Me.logoCloneDT = CType(Me.logoBS.List, DataView).ToTable

			Me.dgvLogoTOF.DataSource = logoCloneDT

			Me.tb_Latitude.DataBindings.Clear()
			Me.tb_Longitude.DataBindings.Clear()

			Me.tb_Latitude.DataBindings.Add("Text", logoCloneDT, "Latitude")
			Me.tb_Longitude.DataBindings.Add("Text", logoCloneDT, "Longitude")


		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnAll_Click()")

		End Try

	End Sub


	Private Sub btnLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadXML.Click
		LoadXLS()

	End Sub


	Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
		Me.importedBS.MovePrevious()

	End Sub

	Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
		Me.importedBS.MoveNext()

	End Sub

	Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
		Me.importedBS.MoveFirst()

	End Sub

	Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
		Me.importedBS.MoveLast()

	End Sub



	Private Sub txtStructureNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStructureNumber.TextChanged

		Dim detailsText As String = Me.txtDirection.Text & "B, " & Me.txtRoute.Text & " x" & Me.txtExit.Text & ", " & Me.txtService.Text
		Me.lblDetailString.Text = detailsText


	End Sub









#End Region





End Class