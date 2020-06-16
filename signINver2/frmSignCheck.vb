Option Strict Off
Option Explicit On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports System.Drawing.Imaging
Imports System.IO
Imports signINver2.clsUtilities




Public Class frmSignCheck


#Region " Class-Level Declarations"

	Dim LocalPath As String = "C:\sIv2\"
	Dim JobListTxtFile As String = "JobList.txt"
	Dim PlyListTxtFile As String = "PlyList.txt"
	Dim ExtListTxtFile As String = "ExtList.txt"
	Dim FS080ListTxtFile As String = "FS080List.txt"
	Dim FS063ListTxtFile As String = "FS063List.txt"
	Dim FS125ListTxtFile As String = "FS125List.txt"




	'My.Computer.FileSystem.WriteAllText(LocalPath & "JobList.txt", String.Empty, False)
	'My.Computer.FileSystem.WriteAllText(LocalPath & "PlyStationList.txt", String.Empty, False)
	'My.Computer.FileSystem.WriteAllText(LocalPath & "ExtStationList.txt", String.Empty, False)
	'My.Computer.FileSystem.WriteAllText(LocalPath & "FS080StationList.txt", String.Empty, False)
	'My.Computer.FileSystem.WriteAllText(LocalPath & "FS063StationList.txt", String.Empty, False)
	'My.Computer.FileSystem.WriteAllText(LocalPath & "FS125StationList.txt", String.Empty, False)






#End Region


#Region " Properties"


	Private _mhsJob As String
	Public Property MhsJob() As String
		Get
			Return _mhsJob
		End Get
		Set(ByVal value As String)
			_mhsJob = value
		End Set
	End Property


	Private _signType As String
	Public Property SignType() As String
		Get
			Return _signType
		End Get
		Set(ByVal value As String)
			_signType = value
		End Set
	End Property


	Private _station As String
	Public Property Station() As String
		Get
			Return _station
		End Get
		Set(ByVal value As String)
			_station = value
		End Set
	End Property



	Private _signCode As String
	Public Property SignCode() As String
		Get
			Return _signCode
		End Get
		Set(ByVal value As String)
			_signCode = value
		End Set
	End Property



	Private _signCodeCount As Integer
	Public Property SignCodeCount() As Integer
		Get
			Return _signCodeCount
		End Get
		Set(ByVal value As Integer)
			_signCodeCount = value
		End Set
	End Property




	Private _legendDetails As String
	Public Property LegendDetails() As String
		Get
			Return _legendDetails
		End Get
		Set(ByVal value As String)
			_legendDetails = value
		End Set
	End Property



	Private _signWidth As String
	Public Property SignWidth() As String
		Get
			Return _signWidth
		End Get
		Set(ByVal value As String)
			_signWidth = value
		End Set
	End Property



	Private _signHeight As String
	Public Property SignHeight() As String
		Get
			Return _signHeight
		End Get
		Set(ByVal value As String)
			_signHeight = value
		End Set
	End Property



	Private _sheeting As String
	Public Property Sheeting() As String
		Get
			Return _sheeting
		End Get
		Set(ByVal value As String)
			_sheeting = value
		End Set
	End Property



	Private _signTech As String
	Public Property SignTech() As String
		Get
			Return _signTech
		End Get
		Set(ByVal value As String)
			_signTech = value
		End Set
	End Property



	Private _buildDate As Date
	Public Property BuildDate() As Date
		Get
			Return _buildDate
		End Get
		Set(ByVal value As Date)
			_buildDate = value
		End Set
	End Property



	Private _signImage As String
	Public Property SignImage() As String
		Get
			Return _signImage
		End Get
		Set(ByVal value As String)
			_signImage = value
		End Set
	End Property


	Private _signID As Integer
	Public Property SignID() As Integer
		Get
			Return _signID
		End Get
		Set(ByVal value As Integer)
			_signID = value
		End Set
	End Property






#End Region


#Region " Database Communication"


	'******* DB Connections ********

	'  (Action Traffic.mdb) connection
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

	'  (db1.mdb) connection
	Dim db1Conn As New OleDbConnection(My.Settings.SignINconn)

	' (secured.mdb) connection
	Dim secConn As New OleDbConnection(My.Settings.SECconn)

	'*************************



	' MHS Jobs
	Dim jobDT As DataTable


	' Sign Tech
	Dim WithEvents stBS As BindingSource
	Dim stDA As OleDbDataAdapter
	Dim stDS As DataSet
	Dim stDT As DataTable


	' Station Status
	Dim WithEvents ssBS As BindingSource
	Dim ssDA As New OleDbDataAdapter
	Dim ssDS As New DataSet
	Dim ssDT As DataTable



	' To populate sign list
	Dim EXTsignDT As DataTable
	Dim PLYsignDT As DataTable
	Dim FSsignDT As DataTable





#End Region



#Region " Methods & Functions"


	''' <summary>
	''' Loads all (*) fields from Jobs Table
	''' </summary>
	''' <remarks></remarks>
	Private Sub LoadMHSJobs()

		Try
			Dim jobCMD As OleDbCommand = New OleDbCommand("SELECT * FROM mhsJobs WHERE Active = True Order By mhsJob DESC", db1Conn)

			' Open the connection, execute the command
			db1Conn.Open()

			' Declare reader object and fill with query result
			Dim reader As OleDbDataReader = jobCMD.ExecuteReader()

			' Load the DataTable with data from the DataReader
			jobDT = New DataTable
			jobDT.Load(reader)

			' Close the reader
			reader.Close()

			' Close the connection
			db1Conn.Close()

			'RemoveHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged
			'Me.cmbMhsJob.DataSource = jobDT
			'Me.cmbMhsJob.DisplayMember = "mhsJob"
			'AddHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged


			

		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateMHSJobs()")
			db1Conn.Close()

		End Try

	End Sub

	''' <summary>
	''' These methods utilitize the Reader Object and do not
	''' provide Methods to write back to the DataSource.
	''' </summary>
	''' <param name="siteID"></param>
	''' <remarks></remarks>
	Private Sub LoadEXT(ByVal siteID As Integer)

		Try

			Dim reader As OleDbDataReader

			' Instantiate new DataTable object
			EXTsignDT = New DataTable

			Using connection As New OleDbConnection(My.Settings.SignINconn)
				Using command As New OleDbCommand("SELECT " & _
							"ID, " & _
							"mhsJob, " & _
							"dir, " & _
							"station, " & _
							"parentSign, " & _
							"B2B, " & _
							"type, " & _
							"code, " & _
							"details, " & _
							"width, " & _
							"height, " & _
							"sqrFeet, " & _
							"sptQty, " & _
							"support, " & _
							"retain, " & _
							"sheeting, " & _
							"twelveInch, " & _
							"sixInch, " & _
							"eightWF, " & _
							"sixWF, " & _
							"fiveWF, " & _
							"threeByFour, " & _
							"twoByTwo, " & _
							"hdwQty, " & _
							"hardware, " & _
							"entryDate " & _
							"FROM ExtrudedTOF " & _
							"WHERE mhsJob = @mhsJob ORDER By ID", connection)

					'"WHERE mhsJob = @mhsJob ORDER By ID", connection)
					'"WHERE ID = @ID ORDER By station", connection)

					'command.Parameters.AddWithValue("@ID", siteID)
					command.Parameters.AddWithValue("@mhsJob", Me.MhsJob)

					connection.Open()

					' Declare reader object and fill with query result
					reader = command.ExecuteReader()

					' Load the DataTable with data from the DataReader
					EXTsignDT.Load(reader)

					' Close the reader
					reader.Close()

				End Using
			End Using

		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoadEXT()")

		End Try





	End Sub

	Private Sub LoadPLY(ByVal siteID As Integer)

		Try

			Dim reader As OleDbDataReader

			' Instantiate new DataTable object
			PLYsignDT = New DataTable

			Using connection As New OleDbConnection(My.Settings.SignINconn)
				Using command As New OleDbCommand("SELECT ID, " & _
						"mhsJob, " & _
						"station, " & _
						"type, " & _
						"code, " & _
						"details, " & _
						"width, " & _
						"height, " & _
						"sqrFeet, " & _
						"sptQty, " & _
						"support, " & _
						"hdwQty, " & _
						"hdw, " & _
						"sheeting " & _
						"FROM PlywoodTOF " & _
						"WHERE mhsJob = @mhsJob ORDER By ID", connection)

					'"WHERE mhsJob = @mhsJob ORDER By ID", connection)
					'"WHERE ID = @ID ORDER By station", connection)

					'command.Parameters.AddWithValue("@ID", siteID)
					command.Parameters.AddWithValue("@mhsJob", Me.MhsJob)

					connection.Open()

					' Declare reader object and fill with query result
					reader = command.ExecuteReader()

					' Load the DataTable with data from the DataReader
					PLYsignDT.Load(reader)

					' Close the reader
					reader.Close()

				End Using
			End Using

		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoadPLY()")

		End Try

	End Sub

	Private Sub LoadFS(ByVal siteID As Integer)

		Try

			Dim reader As OleDbDataReader

			' Instantiate new DataTable object
			FSsignDT = New DataTable

			Using connection As New OleDbConnection(My.Settings.SignINconn)
				Using command As New OleDbCommand("SELECT ID, " & _
						"mhsJob, " & _
						"station, " & _
						"type, " & _
						"code, " & _
						"details, " & _
						"width, " & _
						"height, " & _
						"sqrFeet, " & _
						"sptQty, " & _
						"support, " & _
						"hdwQty, " & _
						"hdw, " & _
						"sheeting " & _
						"FROM FlatSheetTOF " & _
						"WHERE mhsJob = @mhsJob ORDER By ID", connection)

					'"WHERE mhsJob = @mhsJob ORDER By ID", connection)
					'"WHERE ID = @ID ORDER By station", connection)

					'command.Parameters.AddWithValue("@ID", siteID)
					command.Parameters.AddWithValue("@mhsJob", Me.MhsJob)

					connection.Open()

					' Declare reader object and fill with query result
					reader = command.ExecuteReader()

					' Load the DataTable with data from the DataReader
					FSsignDT.Load(reader)

					' Close the reader
					reader.Close()

				End Using
			End Using

		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoadFS()")

		End Try

	End Sub



	''' <summary>
	''' Load Sign Technicians
	''' </summary>
	''' <remarks></remarks>
	Private Sub LoadSignTech()

		'  connection to database
		Dim cmd As OleDbCommand = New OleDbCommand("SELECT userID, userName, userSecLev " & _
		 "FROM tblUsers WHERE userSecLev <= 3 " & _
		 "ORDER BY userID, userName", secConn)

		' Open connection to Db
		secConn.Open()

		'  Fill dataAdapter with query result from Db
		stDA = New OleDbDataAdapter(cmd)

		'  Close the connection
		secConn.Close()

		' Instantiate DataSet object
		stDS = New DataSet()

		' Fill DataSet with data from dataAdapater
		stDA.Fill(stDS, "tblUsers")

		' DataTable -   Fill the DataTable object with data
		stDT = stDS.Tables("tblUsers")

		'RemoveHandler cmbSignTech.SelectedIndexChanged, AddressOf cmbSignTech_SelectedIndexChanged
		'With Me.cmbSignTech
		'	.DisplayMember = "userName"
		'	.ValueMember = "userID"
		'	.DataSource = stDT
		'End With
		'AddHandler cmbSignTech.SelectedIndexChanged, AddressOf cmbSignTech_SelectedIndexChanged

	End Sub


	Public Sub imagePreview()
		Dim imageName As String
		Dim viewImage As String
		Dim url As String = Nothing
		Dim skip As Boolean

		Try
			If My.Settings.serverPresent Then

				url = "\\attermserv01\company data\MHS Pre Production\signImages\" & Me.MhsJob & "\" & Me.btnSignType.Text & "\" & Me.Station & ".jpg"
				Me.TextBox1.Text = url
				'Me.picSign.SizeMode = PictureBoxSizeMode.CenterImage
				Me.picSign.Load(url)

				skip = True
			Else
				skip = False
			End If

		Catch ex1 As Exception
			skip = False
		End Try

		If skip = False Then
			Try
				imageName = Me.SignCode
				viewImage = imageName & ".jpg"
				url = imgPath & viewImage
				Me.TextBox1.Text = url
				Me.picSign.Load(url)
				Me.picSign.SizeMode = PictureBoxSizeMode.CenterImage

			Catch ex2 As Exception
				Me.picSign.Image = My.Resources.none1
			End Try
		End If

		skip = False

	End Sub


	''' <summary>
	''' Bind properties to the appropriate TextBoxes
	''' </summary>
	''' <remarks></remarks>
	Private Sub BindDetails()

		Try
			Me.txtStationID.Text = Me.SignID.ToString
			Me.txtSignCode.Text = Me.SignCode
			Me.txtSignSize.Text = Me.SignWidth & " x " & Me.SignHeight
			Me.txtSignType.Text = Me.SignType
			Me.txtStation.Text = Me.Station
			Me.txtSheeting.Text = Me.Sheeting
			Me.txtLegendDetails.Text = Me.LegendDetails

			IsSignBuilt(Me.MhsJob, Me.SignID)


		Catch ex As Exception
			MessageBox.Show(ex.Message, "bindDetails()")

		End Try


	End Sub


	''' <summary>
	''' Set default values in Text Files
	''' to avoid numerous and lengthy
	''' database calls
	''' </summary>
	''' <remarks></remarks>
	Private Sub LoadTxtFiles()



		My.Computer.FileSystem.WriteAllText(LocalPath & "JobList.txt", String.Empty, False)
		My.Computer.FileSystem.WriteAllText(LocalPath & "PlyStationList.txt", String.Empty, False)
		My.Computer.FileSystem.WriteAllText(LocalPath & "ExtStationList.txt", String.Empty, False)
		My.Computer.FileSystem.WriteAllText(LocalPath & "FS080StationList.txt", String.Empty, False)
		My.Computer.FileSystem.WriteAllText(LocalPath & "FS063StationList.txt", String.Empty, False)
		My.Computer.FileSystem.WriteAllText(LocalPath & "FS125StationList.txt", String.Empty, False)




	End Sub


	Private Sub ResetDefaultButtons()


		Me.btnAddInfo.Enabled = False
		Me.btnApprove.Enabled = False
		Me.btnBuildDate.Enabled = False
		Me.btnPic.Enabled = False
		Me.btnSignTech.Enabled = False
		Me.btnSignType.Enabled = False
		Me.btnStandard.Enabled = False
		Me.btnStationList.Enabled = False



	End Sub



	''' <summary>
	''' Fill the main Station Status DataSet/DataTable
	''' </summary>
	''' <param name="jn">MHS Job Number</param>
	''' <remarks></remarks>
	Private Sub FillSSDT(ByVal jn As String)

		' This Method handles all the Data Access functions
		' for tblStationStatus. 
		' By filling the DataTable and using the BindingSource,
		' I can update this table on the fly with a call to an Update method

		Try
			Dim cmdSS As OleDbCommand = New OleDbCommand _
			 ("SELECT ID, " & _
			  "mhsJob, " & _
			  "type, " & _
			  "StationID, " & _
			  "BuildDate, " & _
			  "SignTech, " & _
			  "ShipDate, " & _
			  "ShipperID, " & _
			  "LotLegend, " & _
			  "LotCovered, " & _
			  "Trailer, " & _
			  "Rack " & _
			  "FROM tblStationStatus " & _
			  "WHERE mhsJob = @mhsJob", db1Conn)

			cmdSS.Parameters.AddWithValue("@mhsJob", jn)

			'  Instantiate DataAdapter (Db Connection), executing the SQL
			ssDA = New OleDbDataAdapter(cmdSS)

			'One CommandBuilder object is required. Automatic DeleteCommand,
			'UpdateCommand and InsertCommand for DataAdapter object      
			Dim ssCB As OleDbCommandBuilder = New OleDbCommandBuilder(ssDA)

			' Instantiate DataSet object
			ssDS = New DataSet()

			'-----------------------
			' Open connection to Db
			db1Conn.Open()

			' Fill DataSet with data via DataAdapater
			ssDA.Fill(ssDS, "tblStationStatus")
			cmdSS.Parameters.Clear()


			'  Close the connection
			db1Conn.Close()
			'-----------------------

			' Create binding source
			ssBS = New BindingSource(ssDS, "tblStationStatus")

			' DataTable -   Fill the DataTable object with data
			ssDT = ssDS.Tables("tblStationStatus")

			'' Bind Controls
			'BindSSFields()

			'' Create TakeOff ID to StationStatus ID Dictionary
			'CreateIDDictionary()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "FillSSDT()")

		End Try

	End Sub


	Private Sub IsSignBuilt(ByVal jn As String, ByVal sID As Integer)

		Me.ssBS.Filter = "mhsJob = '" & jn & "'" & "AND StationID = " & sID.ToString

		If Me.ssBS.List.Count > 0 Then

			'MessageBox.Show("record found")
			With Me.txtBuildDate
				.DataBindings.Clear()
				.DataBindings.Add("Text", ssBS, "BuildDate")

			End With

			With Me.txtSignTech
				.DataBindings.Clear()
				.DataBindings.Add("Text", ssBS, "SignTech")

			End With

		Else
			MessageBox.Show("no record found")


		End If

	End Sub

	






#End Region



#Region " Event Handlers"

	Private Sub frmSignCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		' Populate MhsJobs DataTable
		LoadMHSJobs()

		' Populate Sign Tech DataTable
		LoadSignTech()




	End Sub

	''' <summary>
	''' One Method to handle each "Control" button
	''' Modify as needed, as new "Control" buttons are added
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnControlButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
	 btnJobList.Click, _
	 btnBuildDate.Click, _
	 btnPic.Click, _
	 btnSignTech.Click, _
	 btnSignType.Click, _
	 btnStandard.Click, _
	 btnStationList.Click, _
	 btnStationStatus.Click


		' Cast the sender, button in this case, as a button to 
		' be able to access its name property.  Then determine 
		' a course of action based on its name.
		Dim btnName As Button = TryCast(sender, Button)

		If Not IsNothing(btnName) Then
			Select Case btnName.Name

				Case "btnJobList"
					Dim loadResult As DialogResult
					loadResult = MessageBox.Show("New Job?", _
					  "Job Number", _
					  MessageBoxButtons.YesNo, _
					  MessageBoxIcon.Question, _
					  MessageBoxDefaultButton.Button1)
					Select Case loadResult
						Case DialogResult.Yes
							Try
								Using dialogue As New frmDGV_SignCheck(jobDT.DefaultView, btnName.Name)
									If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
										Me._mhsJob = dialogue.MhsJob
										Me.btnJobList.Text = Me.MhsJob

									End If
								End Using
							Catch ex As Exception
								MessageBox.Show(ex.Message, "btnJobList - btnControlButtons_Click")
							End Try
						Case DialogResult.No
							' Do nothing, retain current job number
							Me.btnAddInfo.Enabled = True
							Me.btnApprove.Enabled = True
							Me.btnBuildDate.Enabled = True
							Me.btnPic.Enabled = True
							Me.btnSignTech.Enabled = True
							Me.btnSignType.Enabled = True
							Me.btnStandard.Enabled = True
							Me.btnStationList.Enabled = True
					End Select

					' Enable the next button
					If Not Me.btnSignType.Enabled Then Me.btnSignType.Enabled = True

					' Fill StationStatus DataSet
					FillSSDT(Me.MhsJob)


				Case "btnSignType"
					Try
						Using dialogue As New frmDGV_SignCheck(Nothing, btnName.Name)
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
								Me._signType = dialogue.SignType
								Me.btnSignType.Text = Me.SignType
							End If
						End Using

						' Enable the next button
						If Not Me.btnStationList.Enabled Then Me.btnStationList.Enabled = True
						If Me.btnSignType.Text = "Plywood" Then
							If Not Me.btnStandard.Enabled Then Me.btnStandard.Enabled = True
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "btnSignType - btnControlButtons_Click")
					End Try

				Case "btnStationList"

					Dim tempDV As New DataView
					Try
						Select Case Me.SignType
							Case "Extruded"
								' Preload TakeOff Data
								LoadEXT(0)
								tempDV = EXTsignDT.DefaultView
							Case "Plywood"
								' Preload TakeOff Data
								LoadPLY(0)
								tempDV = PLYsignDT.DefaultView
							Case "Else"
								' Preload TakeOff Data
								LoadFS(0)
								tempDV = FSsignDT.DefaultView
						End Select
						Using dialogue As New frmDGV_SignCheck(tempDV, btnName.Name)
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
								Me._signID = dialogue.SignID
								Me._station = dialogue.Station
								Me._signCode = dialogue.SignCode
								Me._mhsJob = dialogue.MhsJob
								Me._signType = dialogue.SignType
								Me._legendDetails = dialogue.LegendDetails
								Me._signWidth = dialogue.SignWidth
								Me._signHeight = dialogue.SignHeight
								Me._sheeting = dialogue.Sheeting

								Me.btnStationList.Text = Me.Station
							End If
						End Using

						' Enable the next button
						'If Not Me.btnSignTech.Enabled Then Me.btnSignTech.Enabled = True
						Me.btnSignTech.Enabled = True

					Catch ex As Exception
						MessageBox.Show(ex.Message, "btnStationList - btnControlButtons_Click")
					End Try


				Case "btnSignTech"
					Try
						Using dialogue As New frmDGV_SignCheck(stDT.DefaultView, btnName.Name)
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
								Me._signTech = dialogue.SignTech
								Me.btnSignTech.Text = Me.SignTech
							End If
						End Using

						' Enable next button
						'If Not Me.btnBuildDate.Enabled Then Me.btnBuildDate.Enabled = True
						Me.btnBuildDate.Enabled = True

					Catch ex As Exception
						MessageBox.Show(ex.Message, "btnSignTech - btnControlButtons_Click")
					End Try

				Case "btnBuildDate"
					Try
						Using dialogue As New frmDGV_SignCheck(Nothing, btnName.Name)
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
								Me._buildDate = dialogue.BuildDate
								Me.btnBuildDate.Text = Format(Me.BuildDate, "MM/dd/yyyy")
							End If
						End Using

						' Enable next button
						If Not Me.btnAddInfo.Enabled Then Me.btnAddInfo.Enabled = True
						If Not Me.btnApprove.Enabled Then Me.btnApprove.Enabled = True
						If Not Me.btnPic.Enabled Then Me.btnPic.Enabled = True


					Catch ex As Exception
						MessageBox.Show(ex.Message, "btnBuildDate - btnControlButtons_Click")
					End Try


				Case "btnPic"
					Dim pic As New frmCap
					pic.MdiParent = signINMain1
					pic.Show()

				Case "btnStandard"

					' Fill DataTable
					LoadPLY(0)

					Dim dt As New DataTable
					dt.Columns.Add("code")
					dt.Columns.Add("Count")
					Dim query = (From dr In (From d In PLYsignDT.AsEnumerable Select New With {.code = d("code")}) Select dr.code Distinct)
					For Each colName As String In query
						Dim cName = colName
						Dim cCount = (From row In PLYsignDT.Rows Select row Where row("Code").ToString = cName).Count
						dt.Rows.Add(colName, cCount)
					Next

					Try
						Using dialogue As New frmDGV_SignCheck(dt.DefaultView, btnName.Name)
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
								Me._signCode = dialogue.SignCode
								Me._signCodeCount = dialogue.SignCodeCount
								Me.btnStandard.Text = Me.SignCodeCount.ToString & ")  " & Me.SignCode

							End If
						End Using

						' Enable next button
						If Not Me.btnBuildDate.Enabled Then Me.btnBuildDate.Enabled = True
						If Not Me.btnSignTech.Enabled Then Me.btnSignTech.Enabled = True
						If Not Me.btnAddInfo.Enabled Then Me.btnAddInfo.Enabled = True
						If Not Me.btnApprove.Enabled Then Me.btnApprove.Enabled = True
						If Not Me.btnPic.Enabled Then Me.btnPic.Enabled = True

						' Filter DataTable by currently selected SignCode
						PLYsignDT.DefaultView.RowFilter = "code = '" & Me.SignCode & "'"

						' Display filtered DataView based upon currently selected SignCode
						Using dialogue As New frmDGV_SignCheck(PLYsignDT.DefaultView, "btnStandard_2")
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
								Me._signID = dialogue.SignID
								Me._station = dialogue.Station
								Me._signCode = dialogue.SignCode
								Me._mhsJob = dialogue.MhsJob
								Me._signType = dialogue.SignType
								Me._legendDetails = dialogue.LegendDetails
								Me._signWidth = dialogue.SignWidth
								Me._signHeight = dialogue.SignHeight
								Me._sheeting = dialogue.Sheeting

								Me.btnStationList.Text = Me.Station

							End If
						End Using

					Catch ex As Exception
						MessageBox.Show(ex.Message, "btnBuildDate - btnControlButtons_Click")
					End Try

				Case "btnStationStatus"

					Try
						Using dialogue As New frmDGV_SignCheck(ssDT.DefaultView, btnName.Name)
							If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then

							End If
						End Using

					Catch ex As Exception
						MessageBox.Show(ex.Message, "btnSignType - btnControlButtons_Click")
					End Try


			End Select
		End If
	End Sub

	Private Sub btnStationList_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStationList.TextChanged

		imagePreview()
		BindDetails()

	End Sub

	Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

		' Disable all buttons except for Jobs
		ResetDefaultButtons()


		Try
			Dim strFilePath As String = LocalPath & "JobList.txt"
			Dim stm As StreamWriter
			Dim i As Integer

			stm = New StreamWriter(strFilePath, False)

			For i = 0 To jobDT.Columns.Count - 2
				stm.Write(jobDT.Columns(i).ColumnName + ",")
			Next i

			stm.Write(jobDT.Columns(i).ColumnName)
			stm.WriteLine()


			For Each row As DataRow In jobDT.Rows
				Dim array() As Object = row.ItemArray
				For i = 0 To array.Length - 2
					stm.Write(array(i).ToString() + ",")
				Next i
				stm.Write(array(i).ToString())
			Next row

			stm.Close()
			MessageBox.Show("Completed!", "Daily Productions")

		Catch ex As Exception
			MessageBox.Show(ex.Message & " - Text file writer testing", "btnApprove_Click")

		End Try



	End Sub





#End Region



#Region " Misc Code"


	Private Sub testing()


	End Sub

	Private Sub WriteDataTableToTextFile()
		Dim dtr As OleDbDataReader
		Dim cmd As New OleDbCommand
		Dim tbl As New DataTable
		Dim strFilePath As String
		Dim stm As StreamWriter
		Dim i As Integer

		db1Conn.Open()

		With cmd
			.Connection = db1Conn
			.CommandType = CommandType.Text
			.CommandText = "SELECT * FROM mhsJobs"
			dtr = .ExecuteReader
		End With
		If dtr.HasRows Then
			tbl.Load(dtr)
		Else
			Exit Sub
		End If

		Try
			strFilePath = "c:\tblProducts.txt"
			stm = New StreamWriter(strFilePath, False)

			For i = 0 To tbl.Columns.Count - 2

				stm.Write(tbl.Columns(i).ColumnName + ",")

			Next i
			stm.Write(tbl.Columns(i).ColumnName)
			stm.WriteLine()


			For Each row As DataRow In tbl.Rows
				Dim array() As Object = row.ItemArray

				For i = 0 To array.Length - 2
					stm.Write(array(i).ToString() + ",")
				Next i
				stm.Write(array(i).ToString())


			Next row

			stm.Close()
			MessageBox.Show("job done!")
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Text file writer testing")

		End Try
	End Sub

	Private Function Text_to_DataTable(ByVal path As String) As DataTable
		'Create a new datatable
		Dim dt As DataTable = New DataTable
		'Create a new data connection using the JET engine
		Dim con As OleDb.OleDbConnection = New OleDb.OleDbConnection(String.Format("Provider={0};Data Source={1};Extended Properties=""Text;HDR=YES;FMT=Delimited""", "Microsoft.Jet.OLEDB.4.0", "C:\sIv2\"))
		'Use the command to select all the records
		Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM " & path, con)

		'Set up a dataadapter
		Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter

		'Open the connection
		con.Open()

		'Set the select command and fill
		da.SelectCommand = cmd
		da.Fill(dt)

		'Close the connection
		con.Close()

		Return dt
	End Function



#End Region



	
End Class