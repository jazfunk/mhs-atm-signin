Option Strict On
Option Explicit On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports System.Drawing.Imaging
Imports System.IO


Public Class frmEnterMHSdp


#Region " Class-Level Declarations"

	Dim tofID As Long
	Dim tofSC As String
	Dim tofSize As String
	Dim tofType As String
	Dim tofName As String = Nothing


#End Region

#Region " Database Communication"


	'  (Action Traffic.mdb) connection
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

	'  (db1.mdb) connection
	Dim db1Conn As New OleDbConnection(My.Settings.SignINconn)

	' (secured.mdb) connection
	Dim secConn As New OleDbConnection(My.Settings.SECconn)


	' Status Status 
	Friend WithEvents ssBS As BindingSource
	'Dim ssBS As BindingSource
	Dim ssDA As OleDbDataAdapter
	Dim ssDS As DataSet
	Dim ssDT As DataTable

	' Sign Tech
	Dim stBS As BindingSource
	Dim stDA As OleDbDataAdapter
	Dim stDS As DataSet
	Dim stDT As DataTable



	' To populate Job CMB
	Dim jobDT As DataTable

	' To populate sign list
	Dim EXTsignDT As DataTable
	Dim PLYsignDT As DataTable
	Dim FSsignDT As DataTable


	Dim tofDT As New DataTable

	' Manually Created DataTable to store combined - 
	' tof/ss data
	Dim ssTbl As DataTable

	Dim dctTOFssID As New Dictionary(Of Integer, Integer)
	Dim dctUsers As New Dictionary(Of String, String)



#End Region

#Region " Methods & Functions"

	''' <summary>
	''' Sample code:  DataTable.Select Method
	''' Modified to represent sIv2 Objects
	''' </summary>
	''' <remarks></remarks>
	Private Sub GetRowsByFilter()

		'Dim table As DataTable = ssDS.Tables("tblStationStatus")

		'' Presuming the DataTable has a column named BuildDate.
		'Dim expression As String
		'expression = "BuildDate > #10/1/2010# AND BuildDate < #10/31/2010#"
		'Dim foundRows() As DataRow

		'' Use the Select method to find all rows matching the filter.
		'foundRows = table.Select(expression)

		'Dim i As Integer
		'' Print column 0 of each returned row.
		'For i = 0 To foundRows.GetUpperBound(0)
		'    Console.WriteLine(foundRows(i)(0))
		'Next i

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
					command.Parameters.AddWithValue("@mhsJob", Me.cmbMhsJob.Text)

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
					command.Parameters.AddWithValue("@mhsJob", Me.cmbMhsJob.Text)

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
					command.Parameters.AddWithValue("@mhsJob", Me.cmbMhsJob.Text)

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
	''' Get just ID and signType
	''' </summary>
	''' <param name="job">Job Number</param>
	''' <remarks></remarks>
	Private Sub LoadTOFbyJob(ByVal job As String)

		Try
			If Not IsNothing(job) Then

				' Clear previous data, if any, from DataTable
				tofDT.Clear()


				Dim tofCMD As OleDbCommand = New OleDbCommand("SELECT ID, mhsJob, type FROM ExtrudedTOF " & _
							 "WHERE mhsJob = @job " & _
							 "UNION ALL " & _
							 "SELECT ID, mhsJob, type FROM PlywoodTOF " & _
							 "WHERE mhsJob = @job " & _
							 "UNION ALL " & _
							 "SELECT ID, mhsJob, type FROM FlatSheetTOF " & _
							 "WHERE mhsJob = @job", db1Conn)


				' Add parameters
				tofCMD.Parameters.AddWithValue("@job", job)

				' Open the connection, execute the command
				db1Conn.Open()

				' Declare reader object and fill with query result
				Dim reader As OleDbDataReader = tofCMD.ExecuteReader()

				' Load the DataTable with data from the DataReader
				tofDT.Load(reader)

				' Close the reader
				reader.Close()

				' Close the connection
				db1Conn.Close()

			Else
				MessageBox.Show("select a job first.")
			End If


		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoadTOFbyJob()")
			db1Conn.Close()

		End Try

	End Sub


	''' <summary>
	''' Updates Row Count based on current filter
	''' </summary>
	''' <remarks></remarks>
	Private Sub DisplayRowCount()

		Me.TextBox1.Clear()
		Me.TextBox2.Clear()
		Me.TextBox1.Text = Me.DataGridView2.Rows.Count.ToString
		Me.TextBox2.Text = Me.DataGridView1.Rows.Count.ToString

	End Sub


	''' <summary>
	''' Set DataSource of DataGridView2
	''' Note Used - jk 9.6.15
	''' </summary>
	''' <remarks></remarks>
	Private Sub SetDGVds()

		'Try
		'	If Not IsNothing(ssTbl) Then

		'		With Me.DataGridView2
		'			.DataSource = ssTbl

		'			.Columns(0).Visible = False
		'			.Columns(7).Visible = False
		'			.Columns(8).Visible = False

		'		End With
		'		DisplayRowCount()

		'		BindDTControls(ssTbl.DefaultView)


		'	Else
		'		MessageBox.Show("too bad....it aint workin'.", "Fuck!!!")

		'	End If

		'Catch ex As Exception
		'	MessageBox.Show(ex.Message, "Button2_Click()")

		'End Try
	End Sub


	''' <summary>
	''' Combines TakeOff Data from each Sign Type Table
	''' into one DataTable
	''' </summary>
	''' <remarks></remarks>
	Private Sub IterateDTtoFillDGV()

		' Call DataTable creation Method
		MakeDataTable()

		' Declarations for inserting into DGV
		Dim site As String = Nothing	'   Station Number
		Dim sC As String = Nothing		'   Sign Code
		Dim sD As String = Nothing		'   Legend Details
		Dim sSize As String = Nothing	'   Concactenated W & H
		Dim sSelCB As Boolean = False	'   Select item
		Dim sTOF As Integer = Nothing	'   TOF table Primary Key (ID)
		Dim sSid As Integer = Nothing	'   tblStationStatus Primary Key (ID)

		Try


			Dim a As Integer = Me.EXTsignDT.Rows.Count
			Dim b As Integer = Me.PLYsignDT.Rows.Count
			Dim c As Integer = Me.FSsignDT.Rows.Count
			Dim d As Integer = a + b + c
			Dim totalRecords As Integer = d

			Me.ProgressBar1.Visible = True
			Me.txtProgress.Visible = True
			Me.ProgressBar1.Minimum = 0
			Me.ProgressBar1.Maximum = totalRecords

			Me.txtProgress.Clear()

			' Record counter variable
			Dim recCount As Integer = 0

			For Each dtRow As DataRow In tofDT.Rows

				' Get sign type as an integer (i.e. 1, 2 or 3)
				' Late binding is disallowed with Option Strict,
				Dim strType As String = dtRow.Item(2).ToString
				Dim intType As Integer = GetSignType(strType)
				
				' Get StationID... see above.
				Dim strID As String = dtRow.Item(0).ToString
				Dim intID As Integer = CInt(strID)

				Dim i As Integer = 0
				Try
					i = Me.dctTOFssID(intID)
				Catch ex2 As Exception

				End Try

				' Build SQL
				Dim expression As String
				expression = "ID = " & intID
				Dim foundRows() As DataRow = Nothing

				' Select which TOF DataTable (already loaded in Memory) to apply SQL Expression
				Select Case intType
					Case 0		' Unknown

						Continue For

					Case 1		' Extruded

						' Apply expression to appropriate DataTable
						foundRows = EXTsignDT.Select(expression)

					Case 2		' Plywood
						' apply expression to appropriate DataTable
						foundRows = PLYsignDT.Select(expression)

					Case 3, 5		' .080"/.125" FlatSheet

						' Separate Type V when developed.  -jk 7/13/16
						' apply expression to appropriate DataTable
						foundRows = FSsignDT.Select(expression)

					Case 4		' .040" - .063" FlatSheet

						Continue For

                    Case Else   ' Unknown

                        MessageBox.Show("Case else -1?", "LOL")

                        Continue For

                End Select

				' intID already assigned
				site = foundRows(0).Item("station").ToString
				'strType already assigned
				sC = foundRows(0).Item("code").ToString
				sD = foundRows(0).Item("details").ToString

				Dim strSw As String = foundRows(0).Item("width").ToString
				Dim strSh As String = foundRows(0).Item("height").ToString
				sSize = strSw & " x " & strSh
				sSelCB = False		' Selection CheckBox
				sTOF = intType		' Store the integer value (1, 2, 3) TOF table

				' Add row to DataTable
				FillssTBL(intID, site, strType, sC, sD, sSize, sSelCB, sTOF, i)

				If Me.ProgressBar1.Value < totalRecords Then
					Me.ProgressBar1.Value += 1
					recCount += 1
				End If

				Dim y As Double = (ProgressBar1.Value / ProgressBar1.Maximum) * 100
				Dim x As Integer = CInt(Math.Ceiling(y))

				Me.txtProgress.Text = x & "%  (" & recCount.ToString & "  of  " & totalRecords.ToString & ")"
				Me.txtProgress.Refresh()

			Next

            BindDTControls()

		Catch ex As Exception

			Dim headerText As String = "Exception Thrown:" & vbCrLf

            'With Me.txtExErrorMsg
            '	'.Clear()
            '	.Text = headerText & ex.Message & vbCrLf & ex.ToString
            '	.SelectAll()
            '	.Copy()
            'End With

			MessageBox.Show(ex.Message & vbCrLf & _
			 ex.ToString, "IterateDTtoFillDGV()")

		End Try

	End Sub


	''' <summary>
	''' Manually create DataTable
	''' Rethink this...
	''' </summary>
	''' <remarks></remarks>
	Private Sub MakeDataTable()

		Try

			' Create a DataTable. 
			ssTbl = New DataTable("tblSSdetails")


			' StationID
			Dim colSid As DataColumn = New DataColumn
			colSid.DataType = System.Type.GetType("System.Int32")
			colSid.AllowDBNull = False
			colSid.Caption = "tofStationID"
			colSid.ColumnName = "StationID"
			colSid.DefaultValue = 50

			' Add the columns to the table. 
			ssTbl.Columns.Add(colSid)	' StationId



			' Station 
			Dim colSta As DataColumn = New DataColumn
			colSta.DataType = System.Type.GetType("System.String")
			colSta.AllowDBNull = False
			colSta.Caption = "tofStation"
			colSta.ColumnName = "Station"
			colSta.DefaultValue = 50

			' Add the columns to the table. 
			ssTbl.Columns.Add(colSta)	' Station



			' Type
			Dim colType As DataColumn = New DataColumn
			colType.DataType = System.Type.GetType("System.String")
			colType.AllowDBNull = False
			colType.Caption = "Type"
			colType.ColumnName = "signType"
			colType.DefaultValue = 25

			' Add the columns to the table. 
			ssTbl.Columns.Add(colType)	' Sign Type



			' Code
			Dim colCode As DataColumn = New DataColumn
			colCode.DataType = System.Type.GetType("System.String")
			colCode.AllowDBNull = False
			colCode.Caption = "Code"
			colCode.ColumnName = "signCode"
			colCode.DefaultValue = 50

			' Add the columns to the table. 
			ssTbl.Columns.Add(colCode)	' Sign Code


			' Details
			Dim colDet As DataColumn = New DataColumn
			colDet.DataType = System.Type.GetType("System.String")
			colDet.AllowDBNull = False
			colDet.Caption = "Details"
			colDet.ColumnName = "signDetails"
			colDet.DefaultValue = 50

			' Add the columns to the table
			ssTbl.Columns.Add(colDet)	 ' Sign Details



			' Size
			Dim colSize As DataColumn = New DataColumn
			colSize.DataType = System.Type.GetType("System.String")
			colSize.AllowDBNull = False
			colSize.Caption = "Size"
			colSize.ColumnName = "signSize"
			colSize.DefaultValue = 50

			' Add the columns to the table
			ssTbl.Columns.Add(colSize)	' Sign Size



			' Select
			Dim colSel As DataColumn = New DataColumn
			colSel.DataType = System.Type.GetType("System.Boolean")
			colSel.AllowDBNull = False
			colSel.Caption = "Select"
			colSel.ColumnName = "Select"
			colSel.DefaultValue = 30

			' Add the columns to the table
			ssTbl.Columns.Add(colSel)	' Select



			' Type (Int)
			Dim colTint As DataColumn = New DataColumn
			colTint.DataType = System.Type.GetType("System.Int32")
			colTint.AllowDBNull = False
			colTint.Caption = "TypeINT"
			colTint.ColumnName = "TypeINT"
			colTint.DefaultValue = 30

			' Add the columns to the table
			ssTbl.Columns.Add(colTint)	' Type (Integer)



			' tblStationStatus ID
			Dim colssID As DataColumn = New DataColumn
			colssID.DataType = System.Type.GetType("System.Int32")
			colssID.AllowDBNull = False
			colssID.Caption = "ssID"
			colssID.ColumnName = "ssID"
			colssID.DefaultValue = 30

			' Add the columns to the table
			ssTbl.Columns.Add(colssID)	' tblStationStatus ID (PK)


		Catch ex As Exception

		End Try

	End Sub


	''' <summary>
	''' Inserts row into Manually created DataTable
	''' </summary>
	''' <param name="xID"></param>
	''' <param name="xSta"></param>
	''' <param name="xType"></param>
	''' <param name="xCode"></param>
	''' <param name="xDet"></param>
	''' <param name="xSize"></param>
	''' <param name="xSel"></param>
	''' <param name="xTOF"></param>
	''' <param name="xssID"></param>
	''' <remarks></remarks>
	Private Sub FillssTBL(ByVal xID As Integer, _
	 ByVal xSta As String, _
	 ByVal xType As String, _
	 ByVal xCode As String, _
	 ByVal xDet As String, _
	 ByVal xSize As String, _
	 ByVal xSel As Boolean, _
	 ByVal xTOF As Integer, _
	 ByVal xssID As Integer)

		' 0     xID       StationID
		' 1     xSta      Station (Number) 
		' 2     xType     SignType
		' 3     xCode     Code
		' 4     xDet      Details
		' 5     xSize     Width and Height, concactenated.
		' 6     xSel      CheckBox column for selection
		' 7     xTOF      Integer representing appropriate TOF table
		' 8     xssID     ID (Primary Key Value) from tblStationStatus



		''''' Bitmap to Byte()
		''''' Testing.  
		''''' Do I really have to do this?
		'Dim ms As New MemoryStream

		'' Saves this image to the specified stream
		'' in the specified format
		'xImg.Save(ms, ImageFormat.Bmp)

		'' Declare Byte() (aByt) Array with a value of
		'' the number of bytes in the MemoryStream (ms)
		'' Zero-based index starts at zero, so in order
		'' to get the total count, you must subtract one
		'' to account for the "0" (zero)
		'Dim aByt(CInt(ms.Length - 1)) As Byte




		' ''***********************************************
		'''''' Code below will create a stream from the
		'''''' Byte() Array.  Then an image can be
		'''''' instantiated

		'' Sets the position within the current stream
		'' to the specified value, .Begin, in this case
		'ms.Seek(0, SeekOrigin.Begin)

		'' Reads a block of bytes from the current stream
		'' and writes the data to the buffer
		'ms.Read(aByt, 0, CInt(ms.Length))

		'' Creates a stream whose backing store is memory
		'' aByt() in this case
		'imgByte = New MemoryStream(aByt)

		' '' Usage ex.
		' ''Me.BackgroundImage = Bitmap.FromStream(imgByte)
		' ''***********************************************




		' The .NewRow() Method creates a new DataRow 
		' with the same Schema as the DataTable (ssTbl)
		Dim r As DataRow = ssTbl.NewRow


		' Populate DataRow with variables (Incoming Overloads)
		' then add the DataRow() to the DataTable
		Try
			r(0) = xID		' StationID
			r(1) = xSta		' Station
			r(2) = xType	' Type
			r(3) = xCode	' Code
			r(4) = xDet		' Details
			r(5) = xSize	' Size
			r(6) = xSel		' Select
			r(7) = xTOF		' Type (INT)
			r(8) = xssID	' tblStationStatus ID (PK)

			' Add DataRow() to the DataTable
			ssTbl.Rows.Add(r)

		Catch ex As Exception

			Dim headerText As String = "Exception Thrown: FillssDT()" & vbCrLf & vbCrLf
            'With Me.txtExErrorMsg
            '	'.Clear()
            '	.Text = headerText & ex.Message & vbCrLf & ex.ToString & vbCrLf & vbCrLf
            '	.SelectAll()
            '	.Copy()
            'End With

			MessageBox.Show(ex.Message & vbCrLf & _
			 ex.ToString, "FillssTBL()")

			Exit Sub

		End Try

	End Sub


	''' <summary>
	''' Returns sign type and also sets
	''' TakeOff table name member
	''' </summary>
	''' <param name="t"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function GetSignType(ByVal t As String) As Integer

		Dim s As Integer

		Select Case t
			Case "I", "IA", "IB", "IC", "ID"
				s = 1
				tofName = "ExtrudedTOF"

			Case "II", "IIA", "IIB", "IIC", "IID"
				s = 2
				tofName = "PlywoodTOF"

			Case "III", "IIIA", "IIIB", "IIIC", "IIID"
				s = 3
				tofName = "FlatSheetTOF"

			Case "V", "VA", "VB", "VC", "VD"
				s = 5
				tofName = "FlatSheetTOF"
				' Change this to the TypeVTOF when developed -jk 7/13/16
			Case Else
				s = 0
		End Select

		Return s

	End Function


	''' <summary>
	''' Currently not used.  Will use when this form
	''' allows the user to select a specific type and
	''' work with only that type.
	''' </summary>
	''' <param name="sType"></param>
	''' <param name="sID"></param>
	''' <remarks></remarks>
	Private Sub GetTOFData(ByVal sType As Integer, ByVal sID As Integer)

		Select Case sType

			Case 0
				' Use for "Unknown"
				MessageBox.Show("GetTOFData(): sType = 0", "GetTOFData()")
			Case 1
				' ExtrudedTOF
				LoadEXT(sID)
			Case 2
				' PlywoodTOF
				LoadPLY(sID)
			Case 3
				' FlatSheetTOF
				LoadFS(sID)
			Case Else
				' Handle
				MessageBox.Show("Unknown error in GetTOFData(): sType = " & sType & ", sID = " & sID & ",", "GetTOFData()")

		End Select

	End Sub


	''' <summary>
	''' Loads all (*) fields from Jobs Table
	''' Sets ComboBox.DataSource
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

			RemoveHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged
			Me.cmbMhsJob.DataSource = jobDT
			Me.cmbMhsJob.DisplayMember = "mhsJob"
			AddHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged



		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateMHSJobs()")
			db1Conn.Close()

		End Try

	End Sub


	''' <summary>
	''' EndEdit for the BindingSource and Update the DataSource
	''' using the DataAdapter
	''' </summary>
	''' <remarks></remarks>
	Private Sub UpdateSS()

		Try
			'  Write changes back to actual .mdb file
			'  Accept changes from DataGridView object
			Me.Validate()
			Me.ssBS.EndEdit()
			Me.ssDA.Update(Me.ssDS.Tables("tblStationStatus"))

			'FillSSDT(Me.cmbMhsJob.Text)
			'MessageBox.Show("Update Successful", "Updated!")


		Catch ex As Exception

			MessageBox.Show(ex.Message, "updateSS()")

		End Try

	End Sub


	''' <summary>
	''' Fill the main Station Status DataSet/DataTable
	''' </summary>
	''' <param name="jn"></param>
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

			' Bind Controls
			BindSSFields()

			' Create TakeOff ID to StationStatus ID Dictionary
			CreateIDDictionary()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "FillSSDT()")

		End Try

	End Sub


	''' <summary>
	''' Bind Station Status Fields
	''' </summary>
	''' <remarks></remarks>
	Private Sub BindSSFields()

		Me.DataGridView1.DataBindings.Clear()
		With Me.DataGridView1
			.DataSource = ssBS

			.Columns(0).Visible = True	' ID
			.Columns(1).Visible = False	' mhsJob
			.Columns(2).Visible = True	' type
			.Columns(3).Visible = True	' stationID

			.Columns(4).Visible = True	' BuildDate
			.Columns(5).Visible = True	' signTech

			.Columns(6).Visible = False	' ShipDate
			.Columns(7).Visible = False	' Shipper

			.Columns(8).Visible = False	' lotLegend
			.Columns(9).Visible = False	' lotCovered
			.Columns(10).Visible = False ' trailer
			.Columns(11).Visible = False ' rack

		End With

		' Clear DataBindings
		Me.txtSignTechTEMP.DataBindings.Clear()
		Me.lblBuildDate.DataBindings.Clear()
		
		'' Add DataBindings
		Me.txtSignTechTEMP.DataBindings.Add("Text", ssBS, "SignTech")
		Me.lblBuildDate.DataBindings.Add("Text", ssBS, "BuildDate", True).FormatString = "MM/dd/yyyy"
		



	End Sub

	Private Sub CreateIDDictionary()

		Try
			For Each tRow As DataRow In ssDT.Rows
				Dim ssI As Integer = CInt(tRow.Item(0))
				Dim tofI As Integer = CInt(tRow.Item(3))
				If tofI > 0 Then
					If tofI > 0 Then
						Me.dctTOFssID.Add(tofI, ssI)
					End If
				End If

			Next

			'MessageBox.Show(Me.dctTOFssID.Count.ToString & " Items added.", "Create ID Dictionary")

		Catch ex As Exception

		End Try

	End Sub

	Private Sub CreateUserDictionary()

		Try
			For Each uRow As DataRow In stDT.Rows
				Dim uID As String = CStr(uRow.Item(0))
				Dim uName As String = CStr(uRow.Item(1))

				Me.dctUsers.Add(uID, uName)

			Next

			'MessageBox.Show(Me.dctUsers.Count.ToString & " Items added.", "Create User Dictionary")

		Catch ex As Exception

		End Try

	End Sub

	''' <summary>
	''' Bind ssTbl Controls
	''' </summary>
	''' <remarks></remarks>
	Private Sub BindDTControls()

		'ByVal ssDV As DataView

		' Clear DataBindings
		Me.txtStationID.DataBindings.Clear()
		Me.txtStation.DataBindings.Clear()
		Me.txtSignType.DataBindings.Clear()
		Me.txtSignSize.DataBindings.Clear()
		Me.txtSignCode.DataBindings.Clear()
		Me.txtDetails.DataBindings.Clear()
		Me.DataGridView2.DataBindings.Clear()
		Me.cmbStations.DataBindings.Clear()


		' Add DataBindings
		Me.txtStationID.DataBindings.Add("Text", ssTbl, "StationID")
		Me.txtStation.DataBindings.Add("Text", ssTbl, "Station")
		Me.txtSignType.DataBindings.Add("Text", ssTbl, "signType")
		Me.txtSignSize.DataBindings.Add("Text", ssTbl, "signSize")
		Me.txtSignCode.DataBindings.Add("Text", ssTbl, "signCode")
		Me.txtDetails.DataBindings.Add("Text", ssTbl, "signDetails")

		With Me.cmbStations
			.DataSource = ssTbl
			.ValueMember = "Station"
		End With


		' 0     xID       StationID
		' 1     xSta      Station (Number) 
		' 2     xType     SignType
		' 3     xCode     Code
		' 4     xDet      Details
		' 5     xSize     Width and Height, concactenated.
		' 6     xSel      CheckBox column for selection
		' 7     xTOF      Integer representing appropriate TOF table
		' 8     xssID     ID (Primary Key Value) from tblStationStatus

		With Me.DataGridView2

			.DataSource = ssTbl
			.Columns(0).Visible = False

			With .Columns(1)
				.Visible = True
                '.Width = 9
				.HeaderText = "Station"
				.ReadOnly = True
			End With
			With .Columns(2)
				.Visible = True
                .Width = 44
				.HeaderText = "Type"
				.ReadOnly = True
			End With
			With .Columns(3)
				.Visible = True
                '.Width = 9
				.HeaderText = "Sign Code"
				.ReadOnly = True
			End With
			With .Columns(4)
				.Visible = True
                .Width = 200
				.HeaderText = "Legend Details"
				.ReadOnly = True
			End With
			With .Columns(5)
				.Visible = True
                '.Width = 9
				.HeaderText = "Size"
				.ReadOnly = True
			End With
			With .Columns(6)
				.Visible = True
                '.Width = 9
				.HeaderText = "Sel"
			End With

			.Columns(7).Visible = False
			.Columns(8).Visible = False

		End With

		DisplayRowCount()


	End Sub


	''' <summary>
	''' Load Sign Technicians
	''' </summary>
	''' <remarks></remarks>
	Private Sub LoadSignTech()

		'  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT userID, userName, userSecLev " & _
         "FROM tblUsers WHERE userSecLev " & _
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

		RemoveHandler cmbSignTech.SelectedIndexChanged, AddressOf cmbSignTech_SelectedIndexChanged
		With Me.cmbSignTech
			.DisplayMember = "userName"
			.ValueMember = "userID"
			.DataSource = stDT
		End With
		AddHandler cmbSignTech.SelectedIndexChanged, AddressOf cmbSignTech_SelectedIndexChanged

		CreateUserDictionary()


	End Sub


	''' <summary>
	''' Update StationStatus DataGridView
	''' </summary>
	''' <param name="i"></param>
	''' <remarks></remarks>
	Private Sub ApplyUpdate(ByVal i As Integer)

		Dim sTech As String = Me.cmbSignTech.SelectedValue.ToString

		Dim bDate As Date = Me.eDtpBuildDate.Value
		'Dim rack As String = Me.cmbRack.Text & "-" & Me.cmbSlot.Text
		'Dim trailer As String = Me.txtTrailer.Text
		'Dim shipper As Integer = CInt(Me.txtShipper.Text)
		'Dim sDate As Date = Me.eDtpShipDate.Value

		Try
			For Each row As DataGridViewRow In Me.DataGridView1.Rows
				If CType(row.Cells.Item(3).Value, Integer) = i Then
					' Found matching row
					row.Cells.Item(4).Value = bDate
					row.Cells.Item(5).Value = sTech
					'row.Cells.Item(6).Value = sDate
					'row.Cells.Item(7).Value = shipper
					'row.Cells.Item(8).Value = Me.lotLegend
					'row.Cells.Item(9).Value = Me.lotBG
					'row.Cells.Item(10).Value = trailer
					'row.Cells.Item(11).Value = rack

				Else
					' Non matching row
					' Continue loop
				End If
			Next

		Catch ex As Exception
			MessageBox.Show(ex.Message, "ApplyUpdate()")
		End Try




	End Sub



	''' <summary>
	''' To filter on Sign Code only.  Used to isolate sign codes.
	''' </summary>
	''' <param name="searchSTR"></param>
	''' <remarks></remarks>
	Private Sub SortLike(ByVal searchSTR As String)

		Try

			Dim fieldName As String = Nothing

			Select Case Me.cmbSortLike.SelectedIndex
				Case 0 ' Sign Code
					fieldName = "signCode"
				Case 1 ' Station Number
					fieldName = "Station"
			End Select

			Me.ssTbl.DefaultView.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"


			'Me.ssTbl.DefaultView.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"

			'		Case Is = "height"	' integer
			'			'Dim str2 As Double = CDbl(searchSTR)
			'			'Me.fsTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
			'			'Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.fsTOFDV.Count & " Records)"
			'		Case Else ' string
			'			'Me.fsTOFDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
			'			'Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  Filter On:  [" & fieldName & "]   Search:  """ & searchSTR & """     (" & Me.fsTOFDV.Count & " Records)"

		Catch ex As Exception

			'MessageBox.Show(ex.Message, "exception from sortLike sub")
			Me.ssTbl.DefaultView.RowFilter = Nothing

			'Me.txtSortLike.Clear()

		End Try

	End Sub


	''' <summary>
	''' This Method initializes the ExtendedDateTimePicker's value to
	''' the one Day previous to Today's Date, unless it's Monday, then it
	''' selects the Previous Friday's Date.
	''' </summary>
	''' <remarks></remarks>
	Private Sub InitializeInstallDate()
		Dim dateToday As Date = Today.Date
		Try
			Select Case dateToday.DayOfWeek
				Case DayOfWeek.Monday
					eDtpBuildDate.Value = dateToday.AddDays(-3)

				Case Else
					eDtpBuildDate.Value = dateToday.AddDays(-1)

			End Select
		Catch ex As Exception
			eDtpBuildDate.Value = Today.Date
		End Try

	End Sub



#End Region

#Region " Event Handlers"


	Private Sub frmEnterMHSdp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		LoadSignTech()
		LoadMHSJobs()
		InitializeInstallDate()

		Me.ActiveControl = Me.cmbMhsJob




	End Sub

	Private Sub btnAll_Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterEXT_PLY.Click, btnAll.Click, _
	btnFilterEXT.Click, btnFilterPLY.Click, btnFilterFS.Click, btnFilterTypeV.Click

		Try
			Dim b As Button = DirectCast(sender, Button)
			Dim x As Integer = 0
			Dim expression As String = Nothing

			Select Case b.Name
				Case "btnFilterEXT_PLY"
					x = 12
				Case "btnFilterEXT"
					x = 1
				Case "btnFilterPLY"
					x = 2
				Case "btnFilterFS"
					x = 3
				Case "btnFilterTypeV"
					x = 5
				Case Else
					x = -1
			End Select

			Dim sortExp As String = "TypeINT"
			'Dim dv As DataView
			'Dim dv2 As DataView

			Select Case x
				Case 1 To 5	 ' Extruded, Plywood or Flatsheet
					expression = sortExp & " = " & x.ToString
					'dv = New DataView(ssTbl, expression, sortExp, DataViewRowState.CurrentRows)
					'BindDTControls(dv)

					Me.ssTbl.DefaultView.RowFilter = expression
					Me.ssBS.Filter = "type = " & x.ToString
				Case 12	 ' Extruded & Plywood
					expression = sortExp & " >= 1 AND " & sortExp & " <= 2"
					'dv = New DataView(ssTbl, expression, sortExp, DataViewRowState.CurrentRows)
					'BindDTControls(dv)

					Me.ssTbl.DefaultView.RowFilter = expression
					Me.ssBS.Filter = "type >= 1 AND type <= 2"
				Case Else
					'dv2 = New DataView(ssTbl, Nothing, sortExp, DataViewRowState.CurrentRows)
					'BindDTControls(dv2)

					Me.ssTbl.DefaultView.RowFilter = Nothing
					Me.ssBS.Filter = Nothing
			End Select

			DisplayRowCount()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnAll_Click()")
		End Try

	End Sub

	Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click

		For Each row As DataGridViewRow In Me.DataGridView2.Rows

			row.Cells.Item(6).Value = True

		Next

	End Sub

	Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click

		For Each row As DataGridViewRow In Me.DataGridView2.Rows

			row.Cells.Item(6).Value = False

		Next

	End Sub

	Private Sub btnUpdateSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSelected.Click

		Dim x As Integer = 0
		Try
			For Each row As DataGridViewRow In Me.DataGridView2.Rows
				If CType(row.Cells.Item(6).Value, Boolean) Then
					' Current row is selected
					ApplyUpdate(CType(row.Cells.Item(0).Value, Integer))
					x += 1
				Else
					' Current row is NOT selected
					' Continue loop
					' Potentially do something with 
					' this row in the future.
				End If
			Next

			' Update DataSource
			UpdateSS()

			' Clear Selected Items
			btnSelectNone_Click(Nothing, Nothing)

			If x > 0 Then
				MessageBox.Show(x.ToString & " records updated.", "Updated")
			Else
				MessageBox.Show("No Records Updated.", "No Records Updated")
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnUpdateSelected_Click()")

		End Try
	End Sub

	Private Sub cmbSignTech_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignTech.SelectedIndexChanged

	End Sub

	Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged


		FillSSDT(Me.cmbMhsJob.Text)

		' User 0 for the ID overload because I don't really
		' use it now.  Everything is loaded by the JN from the
		' cmbMHSJob.Text property instead of loading one record
		' at a time by the ID.  I'm retaining the overload for 
		' possible future use
		LoadEXT(0)
		LoadPLY(0)
		LoadFS(0)

		LoadTOFbyJob(Me.cmbMhsJob.Text)

		IterateDTtoFillDGV()

	End Sub


	''' <summary>
	''' Update Row Counts
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub DataGridView1_AND_2_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DataSourceChanged, _
	  DataGridView2.DataSourceChanged

		DisplayRowCount()

	End Sub


	''' <summary>
	''' Synchronizes the TakeOff table with the StationStatus table
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub DataGridView2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView2.SelectionChanged

		Try
			Dim x1 As Integer = CInt(Me.DataGridView2.CurrentRow.Cells.Item(8).Value)
			Dim itemFound As Integer = ssBS.Find("ID", x1)
            If itemFound >= 0 Then
                ssBS.Position = itemFound
            Else
                ' No Matching Station Status Record Found
            End If

			' Display username based upon the Dictionary Key, the UserID field, in this case.
			Me.lblUserName.Text = Me.dctUsers(Me.txtSignTechTEMP.Text)

			' Update Row Count
			DisplayRowCount()

		Catch ex As Exception
            Me.lblUserName.Text = Nothing
		End Try

	End Sub


	''' <summary>
	''' Synchronizes the StationStatus table with the TakeOff table
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged

		'Try
		'	Dim x1 As Integer = CInt(Me.DataGridView1.CurrentRow.Cells.Item(3).Value)

		'	Me.ssTbl.Select("ID = " & x1)

		'	'Dim itemFound As Integer = ssBS.Find("ID", x1)
		'	'If itemFound > 0 Then
		'	'	ssBS.Position = itemFound
		'	'Else
		'	'	'MessageBox.Show("No Matching record found in the Station Status Table")
		'	'End If

		'	Me.lblUserName.Text = Me.dctUsers(Me.txtSignTechTEMP.Text)



		'	DisplayRowCount()

		'Catch ex As Exception

		'End Try


	End Sub



	Private Sub txtSortLike_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSortLike.TextChanged

		SortLike(Me.txtSortLike.Text)

	End Sub


	Private Sub ckbUnReported_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbUnReported.CheckedChanged


		If ckbUnReported.Checked Then

			Me.ssBS.Filter = "BuildDate Is Null"

		Else
			Me.ssBS.Filter = Nothing

		End If
	End Sub


	Private Sub btnSignCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignCheck.Click

		Dim signs As New frmSignCheck
		signs.MdiParent = signINMain1
		signs.Show()

	End Sub

#End Region





End Class