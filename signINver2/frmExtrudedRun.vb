Option Strict On
Option Explicit On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.Code128_CharacterSetB
Imports signINver2.clsUtilities





Public Class frmExtrudedRun



#Region " Class-Level Declarations"

	Public imageName As String
	Public viewImage As String
	Public url As String
	Public signCode As String
	Public jobNum As String
	Public skip As Boolean
	Public title As String
	Public b As String
	Public sptQty As Integer
	Public sptHt As String
	Public bc As Code128_CharacterSetB
	Public barCodeData As String
	Public bcBMP As Bitmap
	Public bcFileName As String

	Public beamDetails As String
	Public ang3x4Details As String
	Public ang2x2Details As String



#End Region



#Region " Properties"



#End Region



#Region " Database Objects"

	' (db1.mdb) connection
	'Dim objConn As New OleDbConnection(connStr01)
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)


	' MHS Jobs
	Dim mhsJobDA As OleDbDataAdapter
	Dim mhsJobDS As DataSet
	Dim mhsJobDV As DataView
	Dim mhsJobDT As DataTable

	Dim WithEvents extTOFBS As BindingSource
	Dim extTOFDA As New OleDbDataAdapter
	Dim extTOFDS As New DataSet
	Dim extTOFDT As DataTable
	Dim extTOFDV As New DataView



#End Region



#Region " Methods & Functions"

	Private Sub FillDataSetAndView()


		Dim i As Integer = -1
		If Me.extTOFBS IsNot Nothing Then
			Dim currentRow = DirectCast(Me.extTOFBS.Current, DataRowView)
			If extTOFDS.Tables.Count > 0 Then
				'i = CType(currentRow.Item(0), Integer)
				i = extTOFBS.Position
			End If
		End If
		

		'  connection to database
		Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
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
					 "FROM ExtrudedTOF WHERE mhsJob = @job ORDER By station", objConn)

		cmd.Parameters.AddWithValue("@job", Me.cmbJobs.Text)


		' Open connection to Db
		objConn.Open()

		'  Fill dataAdapter with query result from Db
		extTOFDA = New OleDbDataAdapter(cmd)

		objConn.Close()

		' Initialize a new instance of the DataSet object
		extTOFDS = New DataSet()

		' Fill the DataSet object with Data
		extTOFDA.Fill(extTOFDS, "ExtrudedTOF")

		' Create binding source
		extTOFBS = New BindingSource(extTOFDS, "ExtrudedTOF")

		If i >= 0 Then extTOFBS.Position = i

		Bindfields()


	End Sub

	Public Sub Bindfields()

		' Clear previous bindings
		'Me.lblMHSJob.DataBindings.Clear()
		Me.txtDir.DataBindings.Clear()
		Me.txtCode.DataBindings.Clear()
		Me.txtStation.DataBindings.Clear()
		Me.txtExtWidth.DataBindings.Clear()
		Me.txtExtHeight.DataBindings.Clear()
		Me.txtExtSqrFeet.DataBindings.Clear()
		Me.txtSupport.DataBindings.Clear()
		Me.ckbRetain.DataBindings.Clear()
		Me.txtSheeting.DataBindings.Clear()
		Me.txt12Plank.DataBindings.Clear()
		Me.txt6Plank.DataBindings.Clear()
		Me.txtParent.DataBindings.Clear()
		Me.cmbStations.DataBindings.Clear()



		' Clear beams/angle/hardware bindings
		Me.txt8WF.DataBindings.Clear()
		Me.txt6WF.DataBindings.Clear()
		Me.txt5WF.DataBindings.Clear()
		Me.txt3x4.DataBindings.Clear()
		Me.txt2x2.DataBindings.Clear()
		Me.txtHdwQty_.DataBindings.Clear()
		Me.txtHardware_.DataBindings.Clear()



		' Add new bindings to the DataView object
		'Me.lblMHSJob.DataBindings.Add("Text", extTOFBS, "mhsJob")
		Me.txtDir.DataBindings.Add("Text", extTOFBS, "dir")
		Me.txtStation.DataBindings.Add("Text", extTOFBS, "station")
		Me.txtCode.DataBindings.Add("Text", extTOFBS, "code")
		Me.txtExtWidth.DataBindings.Add("Text", extTOFBS, "width")
		Me.txtExtHeight.DataBindings.Add("Text", extTOFBS, "height")
		Me.txtExtSqrFeet.DataBindings.Add("Text", extTOFBS, "sqrFeet")
		Me.txtSupport.DataBindings.Add("Text", extTOFBS, "support")
		Me.ckbRetain.DataBindings.Add("Checked", extTOFBS, "retain")
		Me.txtSheeting.DataBindings.Add("Text", extTOFBS, "sheeting")
		Me.txt12Plank.DataBindings.Add("Text", extTOFBS, "twelveInch")
		Me.txt6Plank.DataBindings.Add("Text", extTOFBS, "sixInch")
		Me.txtParent.DataBindings.Add("Text", extTOFBS, "parentSign")

		With Me.cmbStations
			.DataSource = extTOFBS
			.DisplayMember = "station"
		End With

		' beams/angle/hardware bindings 
		Me.txt8WF.DataBindings.Add("Text", extTOFBS, "eightWF")
		Me.txt6WF.DataBindings.Add("Text", extTOFBS, "sixWF")
		Me.txt5WF.DataBindings.Add("Text", extTOFBS, "fiveWF")
		Me.txt3x4.DataBindings.Add("Text", extTOFBS, "threeByFour")
		Me.txt2x2.DataBindings.Add("Text", extTOFBS, "twoByTwo")
		Me.txtHdwQty_.DataBindings.Add("Text", extTOFBS, "hdwQty")
		Me.txtHardware_.DataBindings.Add("Text", extTOFBS, "hardware")

		DisplayCounter()
		imagePreview()

		Me.extTOFBS.MoveNext()
		Me.extTOFBS.MovePrevious()



	End Sub

	Public Sub CalcSupport()

		' Clear fields
		Me.txtQty_.Clear()
		Me.txtSptHeight_.Clear()
		Me.lblBeamSize.Text = ""
		Me.txt3x4Qty_.Clear()
		Me.txt3x4Height_.Clear()
		Me.txt2x2Qty_.Clear()
		Me.txt2x2Height_.Clear()


		' 8WF
		If Me.txt8WF.Text <> "" Then
			Me.txtQty_.Text = Me.txt8WF.Text.Substring(0, 1)
			Me.lblBeamSize.Text = "8WF"
			Me.txtSptHeight_.Text = Me.txt8WF.Text.Substring(5)
		End If

		' 6WF
		If Me.txt6WF.Text <> "" Then
			Me.txtQty_.Text = Me.txt6WF.Text.Substring(0, 1)
			Me.lblBeamSize.Text = "6WF"
			Me.txtSptHeight_.Text = Me.txt6WF.Text.Substring(5)
		End If

		' 5WF
		If Me.txt5WF.Text <> "" Then
			Me.txtQty_.Text = Me.txt5WF.Text.Substring(0, 1)
			Me.lblBeamSize.Text = "5WF"
			Me.txtSptHeight_.Text = Me.txt5WF.Text.Substring(5)
		End If

		' 3x4
		If Me.txt3x4.Text <> "" Then
			Me.txt3x4Qty_.Text = Me.txt3x4.Text.Substring(0, 1)
			Me.txt3x4Height_.Text = Me.txt3x4.Text.Substring(5)
		End If

		' 2x2
		If Me.txt2x2.Text <> "" Then
			Me.txt2x2Qty_.Text = Me.txt2x2.Text.Substring(0, 1)
			Me.txt2x2Height_.Text = Me.txt2x2.Text.Substring(5)
		End If


	End Sub

	Public Sub imagePreview()

		Try
			If My.Settings.serverPresent Then
				jobNum = Me.lblJobNumber.Text
				imageName = Me.txtStation.Text
				viewImage = imageName & ".jpg"
				url = "\\attermserv01\company data\MHS Pre Production\signImages\" & jobNum & "\Extruded\" & viewImage

				' Change pictureboxEXTSign dimensions to match stationNum.jpg dimensions (to avoid image deformation)
				'Me.picSign.Location = New Point(246, 60)
				'Me.picSign.Size = New Size(208, 152)

				Me.picSign.SizeMode = PictureBoxSizeMode.StretchImage
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

				
				'Me.picSign.Location = New Point(317, 82)
				'Me.picSign.Size = New Size(104, 104)

				imageName = Me.txtCode.Text
				viewImage = imageName & ".jpg"
				url = imgPath & viewImage

				Me.picSign.Load(url)
				Me.picSign.SizeMode = PictureBoxSizeMode.CenterImage


			Catch ex2 As Exception

				Me.picSign.Image = My.Resources.none1

			End Try

		End If

		skip = False

	End Sub

	Public Sub PopulateMHSJobs()

		Try

			mhsJobDA = New OleDbDataAdapter("SELECT mhsJob, " & _
			  "cust, " & _
			  "custJob, " & _
			  "jobDesc, " & _
			  "projNum, " & _
			  "stateNum, " & _
			  "compDate, " & _
			  "active, " & _
			  "MMMDisc FROM mhsJobs WHERE Active = True ORDER By mhsJob DESC", objConn)

			' Initialize a new instance of the DataSet object
			mhsJobDS = New DataSet()

			' Open the connection, execute the command
			objConn.Open()

			' Fill DataSet
			mhsJobDA.Fill(mhsJobDS, "mhsJobs")

			' Close the connection
			objConn.Close()

			' DataTable -   Fill the DataTable object with data
			mhsJobDT = mhsJobDS.Tables("mhsJobs")

			' Set the DataView object to the DataSet object
			mhsJobDV = New DataView(mhsJobDS.Tables("mhsJobs"))



			RemoveHandler cmbJobs.SelectedIndexChanged, AddressOf cmbJobs_SelectedIndexChanged
			With Me.cmbJobs
				.DataSource = mhsJobDV
				.DisplayMember = "mhsJob"
			End With
			AddHandler cmbJobs.SelectedIndexChanged, AddressOf cmbJobs_SelectedIndexChanged

			Me.cmbJobs.Text = "Select"

			BindData()



		Catch ex As Exception

			MessageBox.Show(ex.Message, "PopulateMHSJobs()")


		End Try



	End Sub

	Private Sub BindData()


		' Clear DataBinding
		Me.lblJobNumber.DataBindings.Clear()
		Me.lblCustJob.DataBindings.Clear()
		Me.lblCust.DataBindings.Clear()
		Me.lblJobDesc.DataBindings.Clear()
		Me.lblProjNum.DataBindings.Clear()
		Me.lblStateNum.DataBindings.Clear()
		Me.lblCompDate.DataBindings.Clear()
		Me.ckbActive.DataBindings.Clear()
		Me.ckbMMM.DataBindings.Clear()

		' Add DataBinding
		Me.lblJobNumber.DataBindings.Add("Text", mhsJobDV, "mhsJob")
		Me.lblCustJob.DataBindings.Add("Text", mhsJobDV, "custJob")
		Me.lblCust.DataBindings.Add("Text", mhsJobDV, "cust")
		Me.lblJobDesc.DataBindings.Add("Text", mhsJobDV, "jobDesc")
		Me.lblProjNum.DataBindings.Add("Text", mhsJobDV, "projNum")
		Me.lblStateNum.DataBindings.Add("Text", mhsJobDV, "stateNum")

		' Format Date
		Me.lblCompDate.DataBindings.Add("Text", mhsJobDV, "compDate", True).FormatString = "MM/dd/yyyy"
		Me.ckbActive.DataBindings.Add("Checked", mhsJobDV, "Active")
		Me.ckbMMM.DataBindings.Add("Checked", mhsJobDV, "MMMDisc")


	End Sub


	Private Sub AddSign()

		' Declare local variables and objects

		Dim objEXTRunCommand As OleDbCommand = New OleDbCommand

		' Open the connection, execute the command
		objConn.Open()

		' Set the OleDbCommand object properties
		objEXTRunCommand.Connection = objConn
		objEXTRunCommand.CommandText = _
		   "INSERT INTO EXTRun " & _
			"(mhsJob, runID, station, support, parentSign, dir, retain, sheeting, " & _
			"width, height, sqrFeet, twelveInch, sixInch, trailer, loadDate, shipDate, " & _
			"beamSize, beamQty, beamHeight, beamDetails, threeByFourQty, threeByFourHeight, threeByFourDetails, " & _
			"twoByTwoQty, twoByTwoHeight, twoByTwoDetails, hdwQty, hardware, barCode) " & _
			"VALUES(@mhsJob,@runID,@station,@support,@parentSign,@dir,@retain,@sheeting," & _
			"@width,@height,@sqrFeet,@twelveInch,@sixInch,@trailer,@loadDate,@shipDate," & _
			"@beamSize,@beamQty,@beamHeight,@beamDetails,@threeByFourQty,@threeByFourHeight,@threeByFourDetails," & _
			"@twoByTwoQty,@twoByTwoHeight,@twoByTwoDetails,@hdwQty,@hardware,@barCode)"

		' Add placeholder parameters 
		objEXTRunCommand.Parameters.AddWithValue("@mhsJob", Me.lblJobNumber.Text)
		objEXTRunCommand.Parameters.AddWithValue("@runID", Me.txtRunID.Text)
		objEXTRunCommand.Parameters.AddWithValue("@station", Me.txtStation.Text)
		objEXTRunCommand.Parameters.AddWithValue("@support", Me.txtSupport.Text)

		If Me.txtParent.Text = String.Empty Then
			objEXTRunCommand.Parameters.AddWithValue("@parentSign", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@parentSign", Me.txtParent.Text)
		End If

		objEXTRunCommand.Parameters.AddWithValue("@dir", Me.txtDir.Text)
		objEXTRunCommand.Parameters.AddWithValue("@retain", Me.ckbRetain.CheckState)
		objEXTRunCommand.Parameters.AddWithValue("@sheeting", Me.txtSheeting.Text)
		objEXTRunCommand.Parameters.AddWithValue("@width", Me.txtExtWidth.Text)
		objEXTRunCommand.Parameters.AddWithValue("@height", Me.txtExtHeight.Text)
		objEXTRunCommand.Parameters.AddWithValue("@sqrFeet", Me.txtExtSqrFeet.Text)
		objEXTRunCommand.Parameters.AddWithValue("@twelveInch", Me.txt12Plank.Text)
		objEXTRunCommand.Parameters.AddWithValue("@sixInch", Me.txt6Plank.Text)
		objEXTRunCommand.Parameters.AddWithValue("@trailer", DBNull.Value)
		objEXTRunCommand.Parameters.AddWithValue("@loadDate", DBNull.Value)
		
		objEXTRunCommand.Parameters.AddWithValue("@shipDate", DBNull.Value)


		If Me.lblBeamSize.Text = String.Empty Then
			objEXTRunCommand.Parameters.AddWithValue("@beamSize", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@beamSize", Me.lblBeamSize.Text)
		End If



		If Me.txtQty_.Text = "" Then
			objEXTRunCommand.Parameters.AddWithValue("@beamQty", 0)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@beamQty", CInt(Me.txtQty_.Text))
		End If

		If Me.txtSptHeight_.Text = String.Empty Then
			objEXTRunCommand.Parameters.AddWithValue("@beamHeight", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@beamHeight", Me.txtSptHeight_.Text)
		End If

		If beamDetails = String.Empty Or Nothing Then
			objEXTRunCommand.Parameters.AddWithValue("@beamDetails", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@beamDetails", beamDetails)
		End If



		If Me.txt3x4Qty_.Text = "" Then
			objEXTRunCommand.Parameters.AddWithValue("@threeByFourQty", 0)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@threeByFourQty", CInt(Me.txt3x4Qty_.Text))
		End If


		If Me.txt3x4Height_.Text = String.Empty Then
			objEXTRunCommand.Parameters.AddWithValue("@threeByFourHeight", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@threeByFourHeight", Me.txt3x4Height_.Text)

		End If

		If ang3x4Details = String.Empty Or Nothing Then
			objEXTRunCommand.Parameters.AddWithValue("@threeByFourDetails", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@threeByFourDetails", ang3x4Details)
		End If


		If Me.txt2x2Qty_.Text = "" Then
			objEXTRunCommand.Parameters.AddWithValue("@twoByTwoQty", 0)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@twoByTwoQty", CInt(Me.txt2x2Qty_.Text))
		End If

		If Me.txt2x2Height_.Text = String.Empty Then
			objEXTRunCommand.Parameters.AddWithValue("@twoByTwoHeight", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@twoByTwoHeight", Me.txt2x2Height_.Text)
		End If


		If ang2x2Details = String.Empty Or Nothing Then
			objEXTRunCommand.Parameters.AddWithValue("@twoByTwoDetails", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@twoByTwoDetails", ang2x2Details)
		End If


		If Me.txtHdwQty_.Text = "" Then
			objEXTRunCommand.Parameters.AddWithValue("@hdwQty", 0)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@hdwQty", CInt(Me.txtHdwQty_.Text))
		End If


		If Me.txtHardware_.Text = String.Empty Then
			objEXTRunCommand.Parameters.AddWithValue("@hardware", DBNull.Value)
		Else
			objEXTRunCommand.Parameters.AddWithValue("@hardware", Me.txtHardware_.Text)
		End If

		bcFileName = Me.cmbJobs.Text & "_" & Me.txtStation.Text & ".bmp"

		objEXTRunCommand.Parameters.AddWithValue("@barCode", bcFileName)
		
		' Execute the OleDbCommand object to insert the new data
		Try
			objEXTRunCommand.ExecuteNonQuery()
			Dim statusText As String = Me.txtStation.Text & " added to " & Me.txtRunID.Text & " Run for " & jobNum

			' Display a message that the record was added
			ToolStripStatusLabel1.Text = statusText

			'Me.lblAdded.Text = statusText

		Catch OleDbExceptionErr As OleDbException

			MessageBox.Show(OleDbExceptionErr.Message)

			ToolStripStatusLabel1.Text = "Record not added!"

		End Try

		' Close the connection
		objConn.Close()



	End Sub

	Private Sub ViewSign(ByVal sType As Integer, ByVal sID As Integer)


		Dim ExtSignViewer As New frmViewSign(sType, sID)

		' Associate an event handler with an event.
		AddHandler ExtSignViewer.SignViewerClosed, AddressOf FillDataSetAndView

		' Set parent to MDI container
		ExtSignViewer.MdiParent = signINMain1

		' Show the form
		ExtSignViewer.Show()


	End Sub

	Private Sub DisplayCounter()

		Try
			Dim x1 As CurrencyManager = Me.extTOFBS.CurrencyManager
			Dim x As Integer = x1.Position + 1
			Dim y As Integer = Me.extTOFBS.Count
			Me.txtRecordPosition.Text = x & "  of  " & y.ToString
		Catch ex As Exception

		Finally

		End Try

	End Sub

	Private Sub CreateBarCode()

		Try

			'imagePreview()

			' Create barCode
			bc = New Code128_CharacterSetB
			barCodeData = Me.cmbJobs.Text & " " & Me.lblCustJob.Text & " " & Me.txtStation.Text
			bcBMP = CType(bc.Generate(barCodeData), Bitmap)
			Me.picBarCodeBMP.Image = bcBMP

			'' Reset "Options Fields" to default
			'defaultOptionsFields()

			'Me.lblAdded.Text = Nothing

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Sub

	Private Sub GetSearchCriteria()

		Try
			Dim station, prompt, title As String
			prompt = "Enter Station #."
			title = "Search for Station"
			station = InputBox(prompt, title)

			SearchForSite(station)

		Catch ex As Exception

		End Try

	End Sub

	Private Sub SearchForSite(ByVal site As String)

		Me.Cursor = Cursors.WaitCursor
		Dim i As Integer
		Dim found As Boolean = False

		Try
			i = Me.extTOFBS.Find("station", site)
			If i >= 0 Then
				Me.extTOFBS.Position = i
				found = True
			End If

			If Not found Then MessageBox.Show(site & " not found.", "Search")

		Catch ex As Exception
			MessageBox.Show(ex.Message, "SearchForSite()")
		End Try

		Me.Cursor = Cursors.Arrow


	End Sub


#End Region



#Region " Event Handlers"


	Private Sub frmExtrudedRun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		PopulateMHSJobs()


		For Each ctl As Control In Me.grpTOF.Controls
			If TypeOf ctl Is TextBox Then
				ctl.Enabled = False
			End If
		Next





	End Sub

	Private Sub txtStation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStation.TextChanged


		'CreateBarCode()


	End Sub

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

		If Me.txtRunID.Text = "" Then
			MessageBox.Show("You must designate a Run ID.", "Run ID not designated!", _
				 MessageBoxButtons.OK, MessageBoxIcon.Warning, _
				 MessageBoxDefaultButton.Button1)
		Else

			If beamDetails = Nothing Then
				beamDetails = ""
			End If

			If ang2x2Details = Nothing Then
				ang2x2Details = ""
			End If

			If ang3x4Details = Nothing Then
				ang3x4Details = ""
			End If


			AddSign()


			Try

				Dim strFileName As String = Me.cmbJobs.Text & "_" & Me.txtStation.Text

				Dim bcPath As String = "\\attermserv01\company data\MHS Pre Production\bcImages\" & Me.cmbJobs.Text

				If System.IO.Directory.Exists(bcPath) Then
					bcBMP.Save(bcPath & "\" & strFileName & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)
				Else
					System.IO.Directory.CreateDirectory(bcPath)
					bcBMP.Save(bcPath & "\" & strFileName & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)
				End If

			Catch ex As Exception
				MessageBox.Show(ex.Message, "Create BarCode Image")
			End Try


		End If


	End Sub

	Private Sub cmbJobs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJobs.SelectedIndexChanged

		Me.jobNum = Me.cmbJobs.Text

		BindData()

		FillDataSetAndView()

		Me.title = "Extruded Run - "

		Me.Text = title & ":  " & Me.jobNum


	End Sub

	Private Sub lblCustJob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCustJob.TextChanged
		CreateBarCode()

	End Sub

	Private Sub txtRecordPosition_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecordPosition.TextChanged


	End Sub

	Private Sub btnMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveNext.Click

		Me.extTOFBS.MoveNext()


	End Sub

	Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
		Me.extTOFBS.MovePrevious()

	End Sub

	Private Sub btnMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLast.Click
		Me.extTOFBS.MoveLast()

	End Sub

	Private Sub btnMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFirst.Click
		Me.extTOFBS.MoveFirst()

	End Sub

	Private Sub extTOFBS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles extTOFBS.PositionChanged

		imagePreview()
		DisplayCounter()
		CalcSupport()
		CreateBarCode()
		defaultOptionsFields()
		showHideOptionFields()



	End Sub

	Private Sub btnEditTOF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTOF.Click


		Try

			Dim currentRow = DirectCast(Me.extTOFBS.Current, DataRowView)
			Dim signTOFID As Integer = CInt(currentRow.Item(0))

			ViewSign(1, signTOFID)


		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnEditTOF_Click()")

		End Try


	End Sub

	Private Sub txtSheeting_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSheeting.TextChanged

		Me.PictureBoxExtSheeting.BackColor = VisualSheetingColor(Me.txtSheeting.Text)

	End Sub

	Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
		GetSearchCriteria()

	End Sub



	' Options Fields Subs

	Public Sub showHideOptionFields()

		'' Show/Hide Options Fields
		'Dim supportVar As String = Me.txtSupport.Text
		'Select Case supportVar

		'	Case "4x6 W/P"
		'		Me.ckb6Btm.Enabled = False
		'		Me.ckb6TandB.Enabled = False
		'		Me.ckbB2B.Enabled = True
		'		Me.ckbNo6.Enabled = False
		'		Me.ckbW6.Enabled = False
		'		Me.ckbSignOnly.Enabled = False

		'	Case "6x8 W/P"
		'		Me.ckb6Btm.Enabled = False
		'		Me.ckb6TandB.Enabled = False
		'		Me.ckbB2B.Enabled = True
		'		Me.ckbNo6.Enabled = False
		'		Me.ckbW6.Enabled = False
		'		Me.ckbSignOnly.Enabled = False

		'	Case "Column"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = False
		'		Me.ckbW6.Enabled = False
		'		Me.ckbSignOnly.Enabled = False

		'	Case "Exit Panel"
		'		Me.ckb6Btm.Enabled = False
		'		Me.ckb6TandB.Enabled = False
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "Bridge Conn"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = True

		'	Case "C-Truss 50'-70'"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "C/D-Truss"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "E/D/G/-Cant"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "Advisory Panel"
		'		Me.ckb6Btm.Enabled = False
		'		Me.ckb6TandB.Enabled = False
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = False
		'		Me.ckbW6.Enabled = False
		'		Me.ckbSignOnly.Enabled = False

		'	Case "E-Truss 50'-105'"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "E-Truss 110'-140'"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "J-Cant"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "C-Cant"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'	Case "Cantilever"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'		' Temporary to allow for records entered before EXTSupport table updates.
		'	Case "C-Truss"
		'		Me.ckb6Btm.Enabled = True
		'		Me.ckb6TandB.Enabled = True
		'		Me.ckbB2B.Enabled = False
		'		Me.ckbNo6.Enabled = True
		'		Me.ckbW6.Enabled = True
		'		Me.ckbSignOnly.Enabled = False

		'End Select

	End Sub

	Public Sub defaultOptionsFields()

		With Me.ckb6Btm
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckb6TandB
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckbB2B
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckbNo6
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckbW6
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckbSignOnly
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckb24Top
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckb30no6
			.Enabled = True
			.CheckState = CheckState.Unchecked
		End With

		With Me.ckb30w6
			.Enabled = True
			.CheckState = CheckState.Unchecked
        End With

        With Me.ckb36w6
            .Enabled = True
            .CheckState = CheckState.Unchecked
        End With


	End Sub

	Private Sub ckbSignOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbSignOnly.CheckedChanged

		Select Case ckbSignOnly.CheckState
			Case CheckState.Checked
				beamDetails = "Sign only"
			Case CheckState.Unchecked
				beamDetails = ""
		End Select

	End Sub

	Private Sub ckbNo6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbNo6.CheckedChanged

		Select Case Me.txtSupport.Text
			Case "Exit Panel", "Column", "4x6 W/P", "6x8 W/P"
				Select Case ckbNo6.CheckState
					Case CheckState.Checked
						ang2x2Details = "No 6-Inch"
						If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "No 6-Inch"
					Case CheckState.Unchecked
						ang2x2Details = ""
				End Select
			Case Else
				Select Case ckbNo6.CheckState
					Case CheckState.Checked
						beamDetails = "No 6-Inch"
					Case CheckState.Unchecked
						beamDetails = ""
				End Select
		End Select

	End Sub

	Private Sub ckbW6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbW6.CheckedChanged

		Select Case Me.txtSupport.Text
			Case "Exit Panel", "Column", "4x6 W/P", "6x8 W/P"
				Select Case ckbW6.CheckState
					Case CheckState.Checked
						ang2x2Details = "w/6-Inch"
						If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "w/6-Inch"
					Case CheckState.Unchecked
						ang2x2Details = ""
				End Select
			Case Else
				Select Case ckbW6.CheckState
					Case CheckState.Checked
						beamDetails = "w/6-Inch"
					Case CheckState.Unchecked
						beamDetails = ""
				End Select
		End Select

	End Sub

	Private Sub ckbB2B_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbB2B.CheckedChanged

		Select Case ckbB2B.CheckState
			Case CheckState.Checked
				ang3x4Details = "B/B"
			Case CheckState.Unchecked
				ang3x4Details = ""
		End Select
	End Sub

	Private Sub ckb6Btm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckb6Btm.CheckedChanged

		If Me.txtSupport.Text = "Column" Then
			Select Case ckb6Btm.CheckState
				Case CheckState.Checked
					ang2x2Details = "6-Inch Btm"
				Case CheckState.Unchecked
					ang2x2Details = ""
			End Select
		Else
			Select Case ckb6Btm.CheckState
				Case CheckState.Checked
					beamDetails = "6-Inch Btm"
				Case CheckState.Unchecked
					beamDetails = ""
			End Select
		End If


	End Sub

	Private Sub ckb6TandB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckb6TandB.CheckedChanged

		If Me.txtSupport.Text = "Column" Then
			Select Case ckb6TandB.CheckState
				Case CheckState.Checked
					ang2x2Details = "6-Inch T/B"
				Case CheckState.Unchecked
					ang2x2Details = ""
			End Select
		Else
			Select Case ckb6TandB.CheckState
				Case CheckState.Checked
					beamDetails = "6-Inch T/B"
				Case CheckState.Unchecked
					beamDetails = ""
			End Select
		End If



	End Sub

	Private Sub ckb24Top_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckb24Top.CheckedChanged
		Select Case ckb24Top.CheckState
			Case CheckState.Checked
				ang2x2Details = "+2'Top"
			Case CheckState.Unchecked
				ang2x2Details = ""
		End Select
	End Sub

	Private Sub ckb30no6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckb30no6.CheckedChanged

		Select Case Me.txtSupport.Text
			Case "Exit Panel", "Column", "4x6 W/P", "6x8 W/P"
				Select Case Me.ckb30no6.CheckState
					Case CheckState.Checked
						ang2x2Details = "30in No-6in"
						If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "30in No-6in"
					Case CheckState.Unchecked
						ang2x2Details = ""
				End Select
			Case Else
				Select Case Me.ckb30no6.CheckState
					Case CheckState.Checked
						beamDetails = "30in No-6in"
						If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "30in No-6in"
					Case CheckState.Unchecked
						beamDetails = ""
				End Select
		End Select


		'If Me.txtSupport.Text = "Column" Then
		'	Select Case Me.ckb30no6.CheckState
		'		Case CheckState.Checked
		'			ang2x2Details = "30in No-6in"
		'		Case CheckState.Unchecked
		'			ang2x2Details = ""
		'	End Select
		'Else
		'	Select Case Me.ckb30no6.CheckState
		'		Case CheckState.Checked
		'			beamDetails = "30in No-6in"
		'		Case CheckState.Unchecked
		'			beamDetails = ""
		'	End Select
		'End If



	End Sub

	Private Sub ckb30w6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckb30w6.CheckedChanged

		Select Case Me.txtSupport.Text
			Case "Exit Panel", "Column", "4x6 W/P", "6x8 W/P"
				Select Case Me.ckb30w6.CheckState
					Case CheckState.Checked
						ang2x2Details = "30in w/6in"
						If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "30in w/6in"
					Case CheckState.Unchecked
						ang2x2Details = ""
				End Select
			Case Else
				Select Case Me.ckb30w6.CheckState
					Case CheckState.Checked
						beamDetails = "30in w/6in"
						If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "30in w/6in"
					Case CheckState.Unchecked
						beamDetails = ""
				End Select
		End Select

		'If Me.txtSupport.Text = "Column" Then
		'	Select Case Me.ckb30w6.CheckState
		'		Case CheckState.Checked
		'			ang2x2Details = "30in w/6in"
		'		Case CheckState.Unchecked
		'			ang2x2Details = ""
		'	End Select
		'Else
		'	Select Case Me.ckb30w6.CheckState
		'		Case CheckState.Checked
		'			beamDetails = "30in w/6in"
		'		Case CheckState.Unchecked
		'			beamDetails = ""
		'	End Select
		'End If

    End Sub






#End Region



    Private Sub ckb36w6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckb36w6.CheckedChanged

        Select Case Me.txtSupport.Text
            Case "Exit Panel", "Column", "4x6 W/P", "6x8 W/P"
                Select Case Me.ckb36w6.CheckState
                    Case CheckState.Checked
                        ang2x2Details = "36in w/6in"
                        If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "36in w/6in"
                    Case CheckState.Unchecked
                        ang2x2Details = ""
                End Select
            Case Else
                Select Case Me.ckb36w6.CheckState
                    Case CheckState.Checked
                        beamDetails = "36in w/6in"
                        If Not Me.txt3x4Height_.Text = Nothing Then ang3x4Details = "36in w/6in"
                    Case CheckState.Unchecked
                        beamDetails = ""
                End Select
        End Select


    End Sub
End Class