Option Strict On
Option Explicit On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports System.Drawing.Imaging
Imports System.IO



Public Class frmStationStatus


#Region " Class level variables"



    Dim tofID As Long
    Dim tofSC As String
    Dim tofSize As String
	Dim tofType As String
	Dim tofName As String = Nothing

	Dim lotBG As Integer
	Dim lotLegend As Integer

    ' Dictionary(Of TKey, TValue)
    Private dctUpdatedList As New Dictionary(Of String, Integer)


    'Dim imgByte As MemoryStream







#End Region

#Region " Properties"



#End Region

#Region " Database communication"

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

    ' To populate Sheeting Details
    Dim legendSheetingDT As DataTable
    Dim panelSheetingDT As DataTable


	Dim tofDT As New DataTable

    ' Manually Created DataTable to store combined - 
    ' tof/ss data
    Dim ssTbl As DataTable





#End Region

#Region " Methods and functions"


	''' <summary>
	''' Sample code:  DataTable.Select Method
	''' Modified to represent sIv2 Objects
	''' </summary>
	''' <remarks></remarks>
    Private Sub GetRowsByFilter()

        'Dim table As DataTable = ssDS.Tables("tblStationStatus")

        '' Presuming the DataTable has a column named Date.
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
            Dim updatedRecords As Integer = Me.ssDA.Update(Me.ssDS.Tables("tblStationStatus"))

            If updatedRecords > 0 Then

                For Each row As DataGridViewRow In Me.DataGridView2.Rows
                    If CType(row.Cells.Item(6).Value, Boolean) Then
                        ' Current row is selected
                        Dim site As String = CType(row.Cells.Item(1).Value, String)
                        Dim id As Integer = CType(row.Cells.Item(0).Value, Integer)
                        AddToUpdatedRecords(site, id, Now)
                    Else
                        ' Current row is NOT selected
                        ' Continue loop
                    End If
                Next

                FillSSDT(Me.cmbMhsJob.Text)
                ClearFieldsAfterUpdate()
                SyncTOFwDP()

                MessageBox.Show(updatedRecords.ToString & " Records Updated.", "Updated!")


            Else
                MessageBox.Show("No changes detected.", "Update Cancelled")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "updateSS()")

        End Try

    End Sub

	''' <summary>
	''' Fill the main Station Status DataSet/DataTable
	''' </summary>
    ''' <param name="jn">MHS Job Number</param>
	''' <remarks></remarks>
    Private Sub FillSSDT(ByVal jn As string)

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


        Catch ex As Exception
            MessageBox.Show(ex.Message, "FillSSDT()")

        End Try

	End Sub



	''' <summary>
	''' Bind Station Status Fields
	''' </summary>
	''' <remarks></remarks>
	Private Sub BindSSFields()

        Try
            Me.DataGridView1.DataBindings.Clear()
            With Me.DataGridView1
                .DataSource = ssBS

                .Columns(0).Visible = False ' ID
                .Columns(1).Visible = False ' mhsJob
                .Columns(2).Visible = False ' type

                '.Columns(3).Visible = False ' stationID
                .Columns(3).ReadOnly = True
                .Columns(3).Width = 60
                .Columns(3).HeaderText = "ID"

                .Columns(4).ReadOnly = True ' BuildDate
                .Columns(4).Width = 75
                .Columns(4).HeaderText = "BuildDate"

                .Columns(5).Visible = False ' signTech

                .Columns(6).ReadOnly = True ' ShipDate
                .Columns(6).Width = 75
                .Columns(6).HeaderText = "ShipDate"

                .Columns(7).ReadOnly = True ' ShipperID
                .Columns(7).Width = 50
                .Columns(7).HeaderText = "Shipper"

                '.Columns(8).Visible = False	' lotLegend
                .Columns(8).ReadOnly = False
                .Columns(8).HeaderText = "Legend"

                '.Columns(9).Visible = False	' lotCovered
                .Columns(9).ReadOnly = False
                .Columns(9).HeaderText = "Panel"

                '.Columns(10).Visible = False ' trailer
                .Columns(10).ReadOnly = True
                .Columns(10).HeaderText = "Trailer"

                '.Columns(11).Visible = False ' rack
                .Columns(11).ReadOnly = True
                .Columns(11).HeaderText = "Rack"

            End With

            ' Clear DataBindings
            Me.cmbSignTech.DataBindings.Clear()
            Me.lblBuildDate.DataBindings.Clear()
            'Me.eDtpBuildDate.DataBindings.Clear()
            'Me.txtRackSlot.DataBindings.Clear()
            'Me.txtTrailer.DataBindings.Clear()
            'Me.txtShipper.DataBindings.Clear()
            Me.lblRackBIND.DataBindings.Clear()
            Me.lblTrailerBIND.DataBindings.Clear()
            Me.lblShipperBind.DataBindings.Clear()
            Me.lblShipDateBIND.DataBindings.Clear()

            Me.lblViewBuildDate.DataBindings.Clear()
            Me.lblViewShipDate.DataBindings.Clear()
            Me.lblViewShipper.DataBindings.Clear()
            Me.lblViewSignTech.DataBindings.Clear()



            

            ' Add DataBindings
            Me.cmbSignTech.DataBindings.Add("SelectedValue", ssBS, "SignTech")
            Me.lblBuildDate.DataBindings.Add("Text", ssBS, "BuildDate", True).FormatString = "MM/dd/yyyy"
            'Me.eDtpBuildDate.DataBindings.Add("Value", ssBS, "buildDate")
            'Me.txtRackSlot.DataBindings.Add("Text", ssBS, "Rack")
            'Me.txtTrailer.DataBindings.Add("Text", ssBS, "Trailer")
            'Me.txtShipper.DataBindings.Add("Text", ssBS, "ShipperID")
            Me.lblRackBIND.DataBindings.Add("Text", ssBS, "Rack")
            Me.lblTrailerBIND.DataBindings.Add("Text", ssBS, "Trailer")
            Me.lblShipperBind.DataBindings.Add("Text", ssBS, "ShipperID")
            Me.lblShipDateBIND.DataBindings.Add("Text", ssBS, "ShipDate", True).FormatString = "MM/dd/yyyy"

            Me.lblViewBuildDate.DataBindings.Add("Text", ssBS, "BuildDate", True).FormatString = "MM/dd/yyyy"
            Me.lblViewShipDate.DataBindings.Add("Text", ssBS, "ShipDate", True).FormatString = "MM/dd/yyyy"
            Me.lblViewShipper.DataBindings.Add("Text", ssBS, "ShipperID")
            Me.lblViewSignTech.DataBindings.Add("Text", ssBS, "SignTech")

            
            'Me.txtShipDateTEMP.DataBindings.Add("Text", ssBS, "ShipDate", True).FormatString = "MM/dd/yyyy"
            'Me.txtBuildDateTEMP.DataBindings.Add("Text", ssBS, "BuildDate", True).FormatString = "MM/dd/yyyy"

         

        Catch ex As Exception

            MessageBox.Show(ex.Message, "BindSSFields()")

        End Try

	End Sub

	''' <summary>
	''' Bind ssTBL controls
	''' </summary>
	''' <remarks></remarks>
	Private Sub BindDTControls(ByVal ssDV As DataView)


		' Clear DataBindings
		Me.txtStationID.DataBindings.Clear()
		Me.txtStation.DataBindings.Clear()
		Me.txtSignType.DataBindings.Clear()
		Me.txtSignSize.DataBindings.Clear()
		Me.txtSignCode.DataBindings.Clear()
		Me.txtDetails.DataBindings.Clear()
		Me.DataGridView2.DataBindings.Clear()


		' Add DataBindings
		Me.txtStationID.DataBindings.Add("Text", ssDV, "StationID")
		Me.txtStation.DataBindings.Add("Text", ssDV, "Station")
		Me.txtSignType.DataBindings.Add("Text", ssDV, "signType")
		Me.txtSignSize.DataBindings.Add("Text", ssDV, "signSize")
		Me.txtSignCode.DataBindings.Add("Text", ssDV, "signCode")
		Me.txtDetails.DataBindings.Add("Text", ssDV, "signDetails")


        With Me.DataGridView2

            .DataSource = ssDV

            .Columns(0).Visible = False ' StationID

            '.Columns(1).Width = 75     ' Station
            With .Columns(1)
                .Width = 75
                .HeaderText = "Station"
                .ReadOnly = True
            End With

            '.Columns(2).Width = 30      ' SignType
            With .Columns(2)
                .Width = 30
                .HeaderText = "Type"
                .ReadOnly = True
            End With

            '.Columns(3).Width = 75      ' Code
            With .Columns(3)
                .Width = 75
                .HeaderText = "Sign Code"
                .ReadOnly = True
            End With

            '.Columns(4).Width = 75     ' Details
            With .Columns(4)
                .Width = 85
                .HeaderText = "Details"
                .ReadOnly = True
            End With

            '.Columns(5).Width = 40      ' Size
            With .Columns(5)
                .Width = 40
                .HeaderText = "Size"
                .ReadOnly = True
            End With

            '.Columns(6).Width = 30      ' Select CheckBox
            With .Columns(6)
                .Width = 20
                .HeaderText = "Sel"
                .Name = "Sel"
                .ReadOnly = False
            End With

            .Columns(7).Visible = False ' intType
            .Columns(8).Visible = False ' ssID

            '.Columns(9).Width = 60      ' Sheeting
            With .Columns(9)
                .Width = 60
                .HeaderText = "Sheet"
                .ReadOnly = True
            End With


        End With

        '' Change Back color for each row
        ColorCodeDGV()

        ' Display Row Count
        DisplayRowCount()

        'RemoveHandler cmbStations.SelectedIndexChanged, AddressOf cmbStations_SelectedIndexChanged
        With Me.cmbStations
            .DataSource = ssDV
            .ValueMember = "StationID"
            .DisplayMember = "Station"
        End With
        'AddHandler cmbStations.SelectedIndexChanged, AddressOf cmbStations_SelectedIndexChanged



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
                            "WHERE mhsJob = @mhsJob ORDER By station", connection)

                    '"WHERE mhsJob = @mhsJob ORDER By ID", connection)
                    '"WHERE ID = @ID ORDER By station", connection)

                    'command.Parameters.AddWithValue("@ID", siteID)
                    command.Parameters.AddWithValue("@mhsJob", Me.cmbMhsJob.Text)
                    'command.Parameters.AddWithValue("@noSheet", "NONE")

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
                        "WHERE mhsJob = @mhsJob ORDER By station", connection)

                    '"WHERE mhsJob = @mhsJob ORDER By ID", connection)
                    '"WHERE ID = @ID ORDER By station", connection)

                    'command.Parameters.AddWithValue("@ID", siteID)
                    command.Parameters.AddWithValue("@mhsJob", Me.cmbMhsJob.Text)
                    'command.Parameters.AddWithValue("@noSheet", "NONE")

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
                        "WHERE mhsJob = @mhsJob ORDER By station", connection)

                    '"WHERE mhsJob = @mhsJob ORDER By ID", connection)
                    '"WHERE ID = @ID ORDER By station", connection)

                    'command.Parameters.AddWithValue("@ID", siteID)
                    command.Parameters.AddWithValue("@mhsJob", Me.cmbMhsJob.Text)
                    'command.Parameters.AddWithValue("@noSheet", "NONE")

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


                Dim tofCMD As OleDbCommand = New OleDbCommand("SELECT ID, mhsJob, type, sheeting FROM ExtrudedTOF " & _
                                                                 "WHERE mhsJob = @job " & _
                                                                 "UNION ALL " & _
                                                                 "SELECT ID, mhsJob, type, sheeting FROM PlywoodTOF " & _
                                                                 "WHERE mhsJob = @job " & _
                                                                 "UNION ALL " & _
                                                                 "SELECT ID, mhsJob, type, sheeting FROM FlatSheetTOF " & _
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




    Private Sub LoadSheetingDetails()
        Try
            ' Instantiate new DataTable object
            legendSheetingDT = New DataTable
            panelSheetingDT = New DataTable

            Using connection As New OleDbConnection(My.Settings.INVconn)
                Using command As New OleDbCommand("SELECT " & _
                                                        "ID, " & _
                                                        "rollWidth, " & _
                                                        "rollLength, " & _
                                                        "code, " & _
                                                        "rollQty, " & _
                                                        "po, " & _
                                                        "lot, " & _
                                                        "drum, " & _
                                                        "invoice, " & _
                                                        "shipDate, " & _
                                                        "recvDate, " & _
                                                        "carrier, " & _
                                                        "depleted " & _
                                                        "FROM tblSheetingDetails " & _
                                                        "ORDER By shipDate DESC", connection)


                    connection.Open()

                    Using reader = command.ExecuteReader()
                        legendSheetingDT.Load(reader)
                    End Using

                    panelSheetingDT = legendSheetingDT.Copy()


                End Using
            End Using

            BindSheetingDetails()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "LoadSheetingDetails()")

        End Try

    End Sub


    Private Sub BindSheetingDetails()

        Try
            ' Clear DataBindings
            Me.txtSheetLegendCode.DataBindings.Clear()
            Me.txtSheetLegendDrum.DataBindings.Clear()
            Me.txtSheetLegendLot.DataBindings.Clear()
            Me.txtSheetLegendWidth.DataBindings.Clear()
            Me.txtSheetLegendID.DataBindings.Clear()

            Me.txtSheetPanelCode.DataBindings.Clear()
            Me.txtSheetPanelDrum.DataBindings.Clear()
            Me.txtSheetPanelLot.DataBindings.Clear()
            Me.txtSheetPanelWidth.DataBindings.Clear()
            Me.txtSheetPanelID.DataBindings.Clear()

            ' Add DataBindings
            Me.txtSheetLegendCode.DataBindings.Add("Text", legendSheetingDT, "code")
            Me.txtSheetLegendDrum.DataBindings.Add("Text", legendSheetingDT, "drum")
            Me.txtSheetLegendLot.DataBindings.Add("Text", legendSheetingDT, "lot")
            Me.txtSheetLegendWidth.DataBindings.Add("Text", legendSheetingDT, "rollwidth")
            Me.txtSheetLegendID.DataBindings.Add("Text", legendSheetingDT, "ID")

            Me.txtSheetPanelCode.DataBindings.Add("Text", panelSheetingDT, "code")
            Me.txtSheetPanelDrum.DataBindings.Add("Text", panelSheetingDT, "drum")
            Me.txtSheetPanelLot.DataBindings.Add("Text", panelSheetingDT, "lot")
            Me.txtSheetPanelWidth.DataBindings.Add("Text", panelSheetingDT, "rollwidth")
            Me.txtSheetPanelID.DataBindings.Add("Text", panelSheetingDT, "ID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindSheetingDetails()")

        End Try


    End Sub


    Private Sub FilterSheeting()

        Try
            Dim legID As Integer
            If Integer.TryParse(Me.DataGridView1.CurrentRow.Cells.Item(8).Value.ToString, legID) Then
                ' Clear any previous filter
                Me.legendSheetingDT.DefaultView.RowFilter = Nothing
                Me.legendSheetingDT.DefaultView.RowFilter = "ID = " & legID
            Else
                ' Clear data to show legend sheeting info hasn't been entered
                Me.legendSheetingDT.DefaultView.RowFilter = "ID = 0"
            End If

            Dim panID As Integer
            If Integer.TryParse(Me.DataGridView1.CurrentRow.Cells.Item(9).Value.ToString, panID) Then
                ' Clear any previous filter
                Me.panelSheetingDT.DefaultView.RowFilter = Nothing
                Me.panelSheetingDT.DefaultView.RowFilter = "ID = " & panID
            Else
                ' Clear data to show panel sheeting info hasn't been entered
                Me.panelSheetingDT.DefaultView.RowFilter = "ID = 0"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "FilterSheeting()")

        End Try

    End Sub




    ''' <summary>
    ''' Get Row count of DataGridView2 (Combined TOF)
    ''' </summary>
    ''' <remarks></remarks>
	Private Sub DisplayRowCount()

        Try
            If Me.DataGridView2.Rows.Count > 0 Then
                'Dim allSignsCount As Integer = Me.ssBS.Count
                Dim signByTypeCount As Integer = Me.DataGridView2.Rows.Count

                Me.lblRecCount.Text = signByTypeCount.ToString & " Sign(s)"
            Else
                Me.lblRecCount.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "DisplayRowCount()")
        End Try


	End Sub


	Private Sub SetDGVds()

		Try
			If Not IsNothing(ssTbl) Then

                ssTbl.DefaultView.RowFilter = "Sheeting <> 'NONE'"
                BindDTControls(ssTbl.DefaultView)

                Me.lblDisplayRowfilter.Text = ssTbl.DefaultView.RowFilter


			Else
				MessageBox.Show("too bad....it aint workin'.", "Fuck!!!")

			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Button2_Click()")

		End Try
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
        Dim sSid As Integer = Nothing   '   tblStationStatus Primary Key (ID)
        Dim sheet As String = Nothing   '   Sheeting Code

		Try
            ' Get TakeOff Count
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

				' Index (ID field) for current ssDT row
				Dim i As Integer = CInt(dtRow.Item(0))

				' Get sign type as an integer (i.e. 1, 2 or 3)
				' Late binding is disallowed with Option Strict,
				Dim strType As String = dtRow.Item(2).ToString
				Dim intType As Integer = GetSignType(strType)

				' Get StationID... see above.
				Dim strID As String = dtRow.Item(0).ToString
				Dim intID As Integer = CInt(strID)

				' Build SQL
				Dim expression As String
				expression = "ID = " & intID
				Dim foundRows() As DataRow = Nothing

				' Select which TOF DataTable (already loaded in Memory) to apply SQL Expression
				Select Case intType
					Case 0		' Unknown

						' Code this up to account for all
						' possible situations
						MessageBox.Show("intType = 0")
						Continue For

					Case 1		' Extruded

						' apply expression to appropriate DataTable
						foundRows = EXTsignDT.Select(expression)


					Case 2		' Plywood
						' apply expression to appropriate DataTable
						foundRows = PLYsignDT.Select(expression)


                    Case 3, 5 ' FlatSheet
                        ' apply expression to appropriate DataTable
                        foundRows = FSsignDT.Select(expression)


					Case Else	' Unknown

						' Code this up to account for all
						' possible situations
                        MessageBox.Show("intType = " & intType.ToString, "IterateDTtoFillDGV")
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
                sTOF = intType      ' Store the integer value (1, 2, 3, 5) TOF table
                sheet = foundRows(0).Item("sheeting").ToString

				' Add row to DataTable
                FillssTBL(intID, site, strType, sC, sD, sSize, sSelCB, sTOF, i, sheet)

				If Me.ProgressBar1.Value < totalRecords Then
					Me.ProgressBar1.Value += 1
					recCount += 1
				End If

				Dim y As Double = (ProgressBar1.Value / ProgressBar1.Maximum) * 100
				Dim x As Integer = CInt(Math.Ceiling(y))

				Me.txtProgress.Text = x & "%  (" & recCount.ToString & "  of  " & totalRecords.ToString & ")"
				Me.txtProgress.Refresh()

			Next

			SetDGVds()

            'MessageBox.Show("All Records Loaded", "IterateDTtoFillDGV()")

            'Me.ProgressBar1.Visible = False
            'Me.txtProgress.Visible = False

            ' Enable/Disable buttons based upon record count 
            ' Extruded
            If a = 0 Then
                Me.btnFilterEXT.Enabled = False
            Else
                Me.btnFilterEXT.Enabled = True
            End If

            ' Plywood
            If b = 0 Then
                Me.btnFilterPLY.Enabled = False
            Else
                Me.btnFilterPLY.Enabled = True
            End If

            ' Flatsheet III & V
            If c = 0 Then
                Me.btnFilterFS.Enabled = False
                Me.btnFilterFSV.Enabled = False
            Else
                Me.btnFilterFS.Enabled = True
                Me.btnFilterFSV.Enabled = True
            End If

            


		Catch ex As Exception

            'Dim headerText As String = "Exception Thrown:" & vbCrLf

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
            'colSid.DefaultValue = 50

			' Add the columns to the table. 
			ssTbl.Columns.Add(colSid)	' StationId



			' Station 
			Dim colSta As DataColumn = New DataColumn
			colSta.DataType = System.Type.GetType("System.String")
			colSta.AllowDBNull = False
			colSta.Caption = "tofStation"
			colSta.ColumnName = "Station"
            'colSta.DefaultValue = 50

			' Add the columns to the table. 
			ssTbl.Columns.Add(colSta)	' Station



			' Type
			Dim colType As DataColumn = New DataColumn
			colType.DataType = System.Type.GetType("System.String")
			colType.AllowDBNull = False
			colType.Caption = "Type"
			colType.ColumnName = "signType"
            'colType.DefaultValue = 25

			' Add the columns to the table. 
			ssTbl.Columns.Add(colType)	' Sign Type



			' Code
			Dim colCode As DataColumn = New DataColumn
			colCode.DataType = System.Type.GetType("System.String")
			colCode.AllowDBNull = False
			colCode.Caption = "Code"
			colCode.ColumnName = "signCode"
            'colCode.DefaultValue = 50

			' Add the columns to the table. 
			ssTbl.Columns.Add(colCode)	' Sign Code


			' Details
			Dim colDet As DataColumn = New DataColumn
			colDet.DataType = System.Type.GetType("System.String")
			colDet.AllowDBNull = False
			colDet.Caption = "Details"
			colDet.ColumnName = "signDetails"
            'colDet.DefaultValue = 50

			' Add the columns to the table
			ssTbl.Columns.Add(colDet)	 ' Sign Details



			' Size
			Dim colSize As DataColumn = New DataColumn
			colSize.DataType = System.Type.GetType("System.String")
			colSize.AllowDBNull = False
			colSize.Caption = "Size"
			colSize.ColumnName = "signSize"
            'colSize.DefaultValue = 50

			' Add the columns to the table
			ssTbl.Columns.Add(colSize)	' Sign Size



			' Select
			Dim colSel As DataColumn = New DataColumn
			colSel.DataType = System.Type.GetType("System.Boolean")
			colSel.AllowDBNull = False
			colSel.Caption = "Select"
			colSel.ColumnName = "Select"
            'colSel.DefaultValue = 30

			' Add the columns to the table
			ssTbl.Columns.Add(colSel)	' Select



			' Type (Int)
			Dim colTint As DataColumn = New DataColumn
			colTint.DataType = System.Type.GetType("System.Int32")
			colTint.AllowDBNull = False
			colTint.Caption = "TypeINT"
			colTint.ColumnName = "TypeINT"
            'colTint.DefaultValue = 30

			' Add the columns to the table
			ssTbl.Columns.Add(colTint)	' Type (Integer)



			' tblStationStatus ID
			Dim colssID As DataColumn = New DataColumn
			colssID.DataType = System.Type.GetType("System.Int32")
			colssID.AllowDBNull = False
			colssID.Caption = "ssID"
			colssID.ColumnName = "ssID"
            'colssID.DefaultValue = 30


            ' Add the columns to the table
			ssTbl.Columns.Add(colssID)	' tblStationStatus ID (PK)



            ' sheeting (String)
            Dim colSheeting As DataColumn = New DataColumn
            colSheeting.DataType = System.Type.GetType("System.String")
            colSheeting.AllowDBNull = True
            colSheeting.Caption = "Sheeting"
            colSheeting.ColumnName = "Sheeting"
            'colSheeting.DefaultValue = 30

            ' Add the columns to the table
            ssTbl.Columns.Add(colSheeting)  ' Sheeting




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
         ByVal xssID As Integer, _
         ByVal xSheet As String)

        ' 0     xID       StationID
        ' 1     xSta      Station (Number) 
        ' 2     xType     SignType
        ' 3     xCode     Code
        ' 4     xDet      Details
        ' 5     xSize     Width and Height, concactenated.
        ' 6     xSel      CheckBox column for selection
        ' 7     xTOF      Integer representing appropriate TOF table
        ' 8     xssID     ID (Primary Key Value) from tblStationStatus
        ' 9     xSheet    Sheeting Code



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
            r(0) = xID      ' StationID
            r(1) = xSta     ' Station
            r(2) = xType    ' Type
            r(3) = xCode    ' Code
            r(4) = xDet     ' Details
            r(5) = xSize    ' Size
            r(6) = xSel     ' Select
            r(7) = xTOF     ' Type (INT)
            r(8) = xssID    ' tblStationStatus ID (PK)
            r(9) = xSheet   ' Sheeting Code

            ' Add DataRow() to the DataTable
            ssTbl.Rows.Add(r)

        Catch ex As Exception

            'Dim headerText As String = "Exception Thrown: FillssDT()" & vbCrLf & vbCrLf
            'With Me.txtExErrorMsg
            '    '.Clear()
            '    .Text = headerText & ex.Message & vbCrLf & ex.ToString & vbCrLf & vbCrLf
            '    .SelectAll()
            '    .Copy()
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

            Case Else
                s = 0
                MessageBox.Show(t)
        End Select

        'MessageBox.Show("Sign Type = " & t.ToString, "GetSignType()")


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
            Dim jobCMD As OleDbCommand = New OleDbCommand("SELECT * FROM mhsJobs WHERE Active = True ORDER By mhsJob DESC", db1Conn)

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
	''' Open Sheeting Select Form, returns sheeting info (ID)
	''' to apply to station status table
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub OpenSheetingList(ByVal sender As System.Object, ByVal e As System.EventArgs) _
	  Handles btnLegendLot.Click, _
	  btnBGLot.Click

        ' Identify which button is clicking
        Dim btnName As Button = TryCast(sender, Button)


        If Not IsNothing(btnName) Then
            Select Case btnName.Name
                Case "btnLegendLot"
                    Try
                        Using dialogue As New frmInvSheetingListing("GetLot")

                            Me.lotLegend = Nothing

                            If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                If dialogue.ReturnRow IsNot Nothing Then
                                    ' Get DataGridViewRow from dialogue
                                    Dim r As DataGridViewRow = dialogue.ReturnRow
                                    Dim rW As String = r.Cells.Item(1).Value.ToString & " in"
                                    Dim rL As String = r.Cells.Item(2).Value.ToString & " yds"

                                    ' Assign ID to Class-Level Variable
                                    lotLegend = dialogue.ReturnID

                                    Me.lblLegendID.Text = r.Cells.Item(0).Value.ToString
                                    Me.lblLegendRollWidth.Text = rW & " x " & rL
                                    Me.lblLegendCode.Text = r.Cells.Item(3).Value.ToString
                                    Me.lblLegendPO.Text = r.Cells.Item(5).Value.ToString
                                    Me.lblLegendLot.Text = r.Cells.Item(6).Value.ToString
                                    Me.btnLegendLot.ForeColor = Color.Navy
                                    Me.btnLegendLot.Text = r.Cells.Item(6).Value.ToString & "/" & r.Cells.Item(7).Value.ToString
                                    Me.lblLegendDrum.Text = r.Cells.Item(7).Value.ToString
                                    Me.lblLegendInvoice.Text = r.Cells.Item(8).Value.ToString
                                    Dim shipDate As Date = CDate(r.Cells.Item(9).Value)
                                    Dim recvDate As Date = CDate(r.Cells.Item(10).Value)

                                    ' Trim Time from Date Object
                                    Me.lblLegendShipDate.Text = Format(shipDate.Date, "MM/dd/yyyy")
                                    Me.lblLegendRecvDate.Text = Format(recvDate.Date, "MM/dd/yyyy")
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "OpenSheetingList(btnLegendLot.Click)")
                    Finally
                        GetSheetDescription(Me.lblLegendCode.Text, "Legend")
                    End Try

                Case "btnBGLot"
                    Try
                        Using dialogue As New frmInvSheetingListing("GetLot")

                            Me.lotBG = Nothing

                            If dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                If dialogue.ReturnRow IsNot Nothing Then
                                    Dim r As DataGridViewRow = dialogue.ReturnRow
                                    Dim rW As String = r.Cells.Item(1).Value.ToString & " in"
                                    Dim rL As String = r.Cells.Item(2).Value.ToString & " yds"

                                    ' Assign ID to Class-Level Variable
                                    lotBG = dialogue.ReturnID

                                    Me.lblBGID.Text = r.Cells.Item(0).Value.ToString
                                    Me.lblBGRollWidth.Text = rW & " x " & rL
                                    Me.lblBGCode.Text = r.Cells.Item(3).Value.ToString
                                    Me.lblBGPO.Text = r.Cells.Item(5).Value.ToString
                                    Me.lblBGLot.Text = r.Cells.Item(6).Value.ToString
                                    Me.btnBGLot.ForeColor = Color.Navy
                                    Me.btnBGLot.Text = r.Cells.Item(6).Value.ToString & "/" & r.Cells.Item(7).Value.ToString
                                    Me.lblBGDrum.Text = r.Cells.Item(7).Value.ToString
                                    Me.lblBGInvoice.Text = r.Cells.Item(8).Value.ToString
                                    Dim shipDate As Date = CDate(r.Cells.Item(9).Value)
                                    Dim recvDate As Date = CDate(r.Cells.Item(10).Value)

                                    ' Trim Time from Date Object
                                    Me.lblBGShipDate.Text = Format(shipDate.Date, "MM/dd/yyyy")
                                    Me.lblBGRecvDate.Text = Format(recvDate.Date, "MM/dd/yyyy")
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "OpenSheetingList(btnBGLot.Click)")
                    Finally
                        GetSheetDescription(Me.lblBGCode.Text, "BG")
                    End Try
            End Select
        End If


	End Sub

	''' <summary>
	''' This is seemingly stupid
	''' </summary>
	''' <param name="code"></param>
	''' <param name="BGorLegend"></param>
	''' <remarks></remarks>
	Private Sub GetSheetDescription(ByVal code As String, ByVal BGorLegend As String)

        ' Check for Null values
        If code = String.Empty Then
            Exit Sub
        ElseIf BGorLegend = String.Empty Then
            Exit Sub
        End If

        Using connection As New OleDbConnection(My.Settings.SignINconn)

            ' Example
            ' "SELECT SUM(Quantity) FROM StockItem"

            Using command As New OleDbCommand("SELECT sheetDesc FROM sheetingType WHERE sheetNum = @code", _
              connection)

                command.Parameters.AddWithValue("@code", code)

                connection.Open()

                Dim sheetDesc As String = command.ExecuteScalar().ToString

                If BGorLegend = "Legend" Then
                    Me.lblLegendSheetDesc.Text = sheetDesc
                Else
                    Me.lblBGSheetDesc.Text = sheetDesc

                End If



                '' Example
                'Dim totalQuantity As Double = CDbl(command.ExecuteScalar())

            End Using

        End Using

        

	End Sub

	''' <summary>
	''' Display sheeting color
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub VisualSheetingColor(ByVal sender As System.Object, ByVal e As System.EventArgs) _
	  Handles lblLegendCode.TextChanged, _
	  lblBGCode.TextChanged

		' Cast the sender to be able to access its name property.  
		'Then dertermine a course of action based on its name.
		Dim codeLBL As Label = TryCast(sender, Label)

		Try

			Select Case codeLBL.Name

				Case "lblLegendCode"

					Select Case codeLBL.Text
						Case "3930"
							Me.picLegendSheetingDesc.BackColor = Color.White
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.White

						Case "3981"
							Me.picLegendSheetingDesc.BackColor = Color.Yellow
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.Yellow

						Case "3983"
							Me.picLegendSheetingDesc.BackColor = Color.YellowGreen
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.YellowGreen

						Case "3990"
							Me.picLegendSheetingDesc.BackColor = Color.White
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.White

						Case "3932"
							Me.picLegendSheetingDesc.BackColor = Color.Red
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Red

						Case "3935"
							Me.picLegendSheetingDesc.BackColor = Color.Blue
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Blue

						Case "3937"
							Me.picLegendSheetingDesc.BackColor = Color.Green
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Green

						Case "3939"
							Me.picLegendSheetingDesc.BackColor = Color.Brown
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Brown

						Case "3924"
							Me.picLegendSheetingDesc.BackColor = Color.Orange
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.Orange

						Case "1172C"
							Me.picLegendSheetingDesc.BackColor = Color.Red
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Red

						Case "1175C"
							Me.picLegendSheetingDesc.BackColor = Color.Blue
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Blue

						Case "1177C"
							Me.picLegendSheetingDesc.BackColor = Color.Green
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Green

						Case "3650-12"
							Me.picLegendSheetingDesc.BackColor = Color.Black
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Black

						Case "3997"
							Me.picLegendSheetingDesc.BackColor = Color.Green
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Green


						Case "4090"
							Me.picLegendSheetingDesc.BackColor = Color.White
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.White

						Case "4081"
							Me.picLegendSheetingDesc.BackColor = Color.Yellow
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.Yellow

						Case "4083"
							Me.picLegendSheetingDesc.BackColor = Color.YellowGreen
							Me.lblLegendSheetDesc.ForeColor = Color.Black
							Me.lblLegendSheetDesc.BackColor = Color.YellowGreen

						Case Else
							Me.picLegendSheetingDesc.BackColor = Color.Transparent
							Me.lblLegendSheetDesc.ForeColor = Color.White
							Me.lblLegendSheetDesc.BackColor = Color.Transparent


					End Select


				Case "lblBGCode"

					Select Case codeLBL.Text
						Case "3930"
							Me.picBGSheetingDesc.BackColor = Color.White
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.White

						Case "3981"
							Me.picBGSheetingDesc.BackColor = Color.Yellow
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.Yellow

						Case "3983"
							Me.picBGSheetingDesc.BackColor = Color.YellowGreen
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.YellowGreen

						Case "3990"
							Me.picBGSheetingDesc.BackColor = Color.White
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.White

						Case "3932"
							Me.picBGSheetingDesc.BackColor = Color.Red
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Red

						Case "3935"
							Me.picBGSheetingDesc.BackColor = Color.Blue
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Blue

						Case "3937"
							Me.picBGSheetingDesc.BackColor = Color.Green
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Green

						Case "3939"
							Me.picBGSheetingDesc.BackColor = Color.Brown
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Brown

						Case "3924"
							Me.picBGSheetingDesc.BackColor = Color.Orange
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.Orange

						Case "1172C"
							Me.picBGSheetingDesc.BackColor = Color.Red
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Red

						Case "1175C"
							Me.picBGSheetingDesc.BackColor = Color.Blue
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Blue

						Case "1177C"
							Me.picBGSheetingDesc.BackColor = Color.Green
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Green

						Case "3650-12"
							Me.picBGSheetingDesc.BackColor = Color.Black
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Black

						Case "3997"
							Me.picBGSheetingDesc.BackColor = Color.Green
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Green

						Case "4090"
							Me.picBGSheetingDesc.BackColor = Color.White
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.White

						Case "4081"
							Me.picBGSheetingDesc.BackColor = Color.Yellow
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.Yellow

						Case "4083"
							Me.picBGSheetingDesc.BackColor = Color.YellowGreen
							Me.lblBGSheetDesc.ForeColor = Color.Black
							Me.lblBGSheetDesc.BackColor = Color.YellowGreen


						Case Else
							Me.picBGSheetingDesc.BackColor = Color.Transparent
							Me.lblBGSheetDesc.ForeColor = Color.White
							Me.lblBGSheetDesc.BackColor = Color.Transparent

					End Select

			End Select


		Catch ex As Exception
			'MessageBox.Show(ex.Message, "VisualSheetingColor()")
		End Try


	End Sub

	''' <summary>
    ''' Load Sign Technicians
	''' </summary>
	''' <remarks></remarks>
	Private Sub LoadSignTech()


        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT userID, userName, userSecLev " & _
             "FROM tblUsers " & _
             "ORDER BY userName", secConn)

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
            With Me.cmbSignTech
                .DisplayMember = "userName"
                .ValueMember = "userID"
                .DataSource = stDT
                .Text = "Sign Tech"
            End With
            'AddHandler cmbSignTech.SelectedIndexChanged, AddressOf cmbSignTech_SelectedIndexChanged


        Catch ex As Exception
            MessageBox.Show(ex.Message, "LoadSignTech()")
            secConn.Close()

        End Try

    End Sub





    ' The following Methods are not being used 04.13.2018 - jk

	''' <summary>
    ''' Fill Rack slot #'s based on each racks capacity
    ''' Not used anymore - 04.13.2018 - jk
	''' </summary>
	''' <param name="rN"></param>
	''' <remarks></remarks>
	Private Sub FillSlotNumbers(ByVal rN As Integer)

        'Try
        '	Me.cmbSlot.Items.Clear()

        '	Select Case rN

        '		Case 1

        '			For x = 1 To 35
        '				Me.cmbSlot.Items.Add(x.ToString)
        '			Next

        '		Case 2

        '			For x = 1 To 20
        '				Me.cmbSlot.Items.Add(x.ToString)
        '			Next

        '		Case 3

        '			For x = 1 To 107
        '				Me.cmbSlot.Items.Add(x.ToString)
        '			Next

        '		Case 4

        '			For x = 1 To 40
        '				Me.cmbSlot.Items.Add(x.ToString)
        '			Next

        '		Case 5

        '			For x = 1 To 30
        '				Me.cmbSlot.Items.Add(x.ToString)
        '			Next

        '	End Select


        'Catch ex As Exception

        'End Try



	End Sub

    ''' <summary>
    ''' This method is not used or called anyhwere currently - 04.12.2018 -jk
    ''' </summary>
    ''' <param name="TableName"></param>
    ''' <remarks></remarks>
    Private Sub ViewTakeOff(ByVal TableName As String)

        Try
            Dim dView As DataView = Nothing

            Select Case TableName
                Case "ExtrudedTOF"
                    dView = EXTsignDT.DefaultView
                Case "PlywoodTOF"
                    dView = PLYsignDT.DefaultView
                Case "FlatSheetTOF"
                    dView = FSsignDT.DefaultView
            End Select

            If dView IsNot Nothing Then
                Dim gDgv As New frmGenericDGV(dView)
                gDgv.MdiParent = signINMain1
                gDgv.Show()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

	''' <summary>
	''' Select Specific record from combined DataTable
	''' currently using 'dv2' DataView Object to send without a filter
	''' while retaining the old code... which I'm still trying to 
	''' figure out what the hell I was doing in this form-11.1.12
	''' This method is not currently called anywhere - jk 9.5.15
	''' </summary>
	''' <param name="sID"></param>
	''' <remarks></remarks>
	Private Sub FilterSSTable(ByVal sID As Integer)

		Try
			Dim expression As String = "StationID = '" & sID & "'"
			Dim sortExp As String = "StationID"
			Dim dv As DataView
			'Dim dv2 As DataView
			dv = New DataView(ssTbl, expression, sortExp, DataViewRowState.CurrentRows)
			'dv2 = New DataView(ssTbl, Nothing, sortExp, DataViewRowState.CurrentRows)
			BindDTControls(dv)
			ShowPosition()

		Catch ex As Exception

		End Try

    End Sub


    ' Not working!!!
    'Private Function SignImageFromFile(ByVal stationNum As String, ByVal typeFolder As Integer, ByVal VsignCode As String) As Bitmap

    '	' Determine "Extruded" or "Plywood"
    '	Dim strFolderName As String = Nothing

    '	Select Case typeFolder
    '		Case 0
    '			' Unknown
    '			strFolderName = Nothing
    '		Case 1
    '			'Extruded
    '			strFolderName = "\Extruded"
    '		Case 2
    '			'Plywood
    '			strFolderName = "\Plywood"
    '		Case 3
    '			' No Flatsheet images 
    '			strFolderName = Nothing
    '		Case Else
    '			' Unknown
    '			strFolderName = Nothing
    '	End Select

    '	Dim viewImage As String = "\" & stationNum & ".jpg"
    '	Dim serverURL As String = serverImgPath & Me.cmbMhsJob.Text & strFolderName & viewImage
    '	Dim localURL As String = imgPath & Me.cmbMhsJob.Text & viewImage
    '	Dim signCodeURL As String = imgPath & VsignCode & ".jpg"

    '	Dim rawBMP As Bitmap = Nothing
    '	'Dim img As Bitmap = Nothing

    '	Try	' Try Server first
    '		rawBMP = CType(Image.FromFile(serverURL), Bitmap)
    '	Catch ex1 As Exception
    '		Try	' Then Local
    '			rawBMP = CType(Image.FromFile(localURL), Bitmap)
    '		Catch ex2 As Exception
    '			Try	' Then Sign Code General Image
    '				rawBMP = CType(Image.FromFile(signCodeURL), Bitmap)
    '			Catch ex As Exception
    '				' Finally, give up and show "No Image To Display" image
    '				rawBMP = My.Resources.none1
    '			End Try
    '		End Try
    '	End Try

    '	'rawBMP = My.Resources.none1

    '	'' Clone rawBMP so that it can be disposed
    '	'' thus closing the original file.  
    '	'img = CType(rawBMP.Clone, Bitmap)

    '	'' Return the cloned image (img)
    '	'Return img

    '	'temp
    '	Return rawBMP


    '	' The .FromFile() Method used to get the original
    '	' image leaves the file open and locked from any
    '	' other users accessing it until it's disposed.
    '	rawBMP.Dispose()

    'End Function

    ' Nest form inside another form
    Private Sub NestedFormExample()

        '  open form inside another form (i.e. a panel)

        'Dim f As New Form2()
        'f.TopLevel = False
        'Me.Panel1.Controls.Add(f)
        'f.Show()



    End Sub

    ' End of Methods not being used  04.13.2018 - jk






	''' <summary>
    ''' Displays Current(n) record of Total(nth) records
    ''' No longer used 04.14.2018 - jk
	''' </summary>
	''' <remarks></remarks>
	Private Sub ShowPosition()

        'Try
        '	Dim recCount As Integer = Me.ssBS.Count
        '	Dim curRec As Integer = Me.ssBS.Position + 1
        '	Dim showText As String = curRec.ToString & " of " & recCount.ToString
        '	Me.lblPosition.Text = showText

        'Catch ex As Exception
        '	MessageBox.Show(ex.Message, "ShowPostion()")
        'End Try

	End Sub

    ''' <summary>
    ''' Apply Updated info to selected rows
    ''' </summary>
    ''' <param name="i">ID</param>
    ''' <remarks></remarks>
	Private Sub ApplyUpdate(ByVal i As Integer)

        

        Dim sTech As String = Me.cmbSignTech.SelectedValue.ToString
        Dim bDate As Date = CDate(Me.lblBuildDate.Text)

        Dim rack As String = Me.txtRackSlot.Text
        Dim trailer As String = Me.txtTrailer.Text
        Dim shipper As Integer
        Dim sDate As Date

        ' Validate Shipper Number
        If Integer.TryParse(Me.txtShipper.Text, shipper) Then
            ' Valid Integer, continue Sub
            'MessageBox.Show(shipper.ToString, "shipper #")
        Else
            ' Validation occurs in the calling method
            shipper = Nothing
        End If

        ' Validate Ship Date
        If Date.TryParse(Me.txtShipDate.Text, sDate) Then
            ' Valid Date, continue Sub            
            ' MessageBox.Show(sDate.ToString, "ship date")
        Else
            ' Validating occurs in the calling method
            sDate = Nothing
        End If

        ' Number of Rows to Update
        Dim x As Integer = 0
        'Dim a As Integer = Me.DataGridView1.RowCount

        Try
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                'Dim abc As Integer = CType(row.Cells.Item(3).Value, Integer)
                If CType(row.Cells.Item(3).Value, Integer) = i Then
                    ' Found matching row
                    ' ShipDate
                    If sDate <> Nothing Then
                        row.Cells.Item(6).Value = sDate
                    Else
                        ' Do not overwrite or add date if no sheeting ID selected
                        ' Commented out 04.15.2018 -jk
                        'row.Cells.Item(6).Value = DBNull.Value
                    End If


                    ' ShipperID
                    If shipper <> Nothing Then
                        row.Cells.Item(7).Value = shipper
                    Else
                        ' Do not overwrite or add date if no sheeting ID selected
                        ' Commented out 04.15.2018 -jk
                        'row.Cells.Item(7).Value = DBNull.Value
                    End If


                    ' lotLegend
                    If Me.lotLegend > 0 Then
                        row.Cells.Item(8).Value = Me.lotLegend
                    Else
                        ' Do not overwrite or add date if no sheeting ID selected
                        ' Commented out 04.15.2018 -jk
                        'row.Cells.Item(8).Value = DBNull.Value
                    End If


                    ' lotBG
                    If Me.lotBG > 0 Then
                        row.Cells.Item(9).Value = Me.lotBG
                    Else
                        ' Do not overwrite or add date if no sheeting ID selected
                        ' Commented out 04.15.2018 -jk
                        'row.Cells.Item(9).Value = DBNull.Value
                    End If


                    ' trailer
                    If trailer <> String.Empty Then
                        row.Cells.Item(10).Value = trailer
                    Else
                        ' Do not overwrite or add date if no sheeting ID selected
                        ' Commented out 04.15.2018 -jk
                        'row.Cells.Item(10).Value = DBNull.Value
                    End If


                    ' rack
                    If rack <> String.Empty Then
                        row.Cells.Item(11).Value = rack
                    Else
                        row.Cells.Item(11).Value = DBNull.Value
                    End If


                    ' Sign Tech/Build Date
                    If Me.ckbBatchDP.Checked Then
                        row.Cells.Item(4).Value = bDate
                        row.Cells.Item(5).Value = sTech
                    Else
                        ' Do not ovrewrite or add
                        'row.Cells.Item(4).Value = DBNull.Value
                        'row.Cells.Item(5).Value = DBNull.Value
                    End If

                    'Increment Counter
                    x += 1

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
    ''' Iterate through DataGridView2 and change text/backcolor to match Sheeting
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ColorCodeDGV()

        Try
            If Me.DataGridView2.Rows.Count > 0 Then
                For Each row As DataGridViewRow In Me.DataGridView2.Rows

                    'Dim sColor As String = Me.DataGridView2.CurrentRow.Cells.Item(9).Value.ToString
                    Dim sColor As String = row.Cells.Item(9).Value.ToString

                    Select Case sColor
                        Case "3930"
                            row.DefaultCellStyle.BackColor = Color.AntiqueWhite
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "3981"
                            row.DefaultCellStyle.BackColor = Color.Yellow
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "3983"
                            row.DefaultCellStyle.BackColor = Color.YellowGreen
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "3990"
                            row.DefaultCellStyle.BackColor = Color.WhiteSmoke
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "3932"
                            row.DefaultCellStyle.BackColor = Color.Red
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "3935"
                            row.DefaultCellStyle.BackColor = Color.Blue
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "3937"
                            row.DefaultCellStyle.BackColor = Color.Green
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "3939"
                            row.DefaultCellStyle.BackColor = Color.Brown
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "3924"
                            row.DefaultCellStyle.BackColor = Color.Orange
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "1172C"
                            row.DefaultCellStyle.BackColor = Color.Red
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "1175C"
                            row.DefaultCellStyle.BackColor = Color.Blue
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "1177C"
                            row.DefaultCellStyle.BackColor = Color.Green
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "3650-12"
                            row.DefaultCellStyle.BackColor = Color.Black
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "3997"
                            row.DefaultCellStyle.BackColor = Color.Green
                            row.DefaultCellStyle.ForeColor = Color.White

                        Case "4090"
                            row.DefaultCellStyle.BackColor = Color.White
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "4081"
                            row.DefaultCellStyle.BackColor = Color.Yellow
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case "4083"
                            row.DefaultCellStyle.BackColor = Color.YellowGreen
                            row.DefaultCellStyle.ForeColor = Color.Black

                        Case Else
                            row.DefaultCellStyle.BackColor = Color.Gray
                            row.DefaultCellStyle.ForeColor = Color.LightGray

                    End Select

                Next


                For Each row2 As DataGridViewRow In Me.DataGridView1.Rows
                    Dim sColor2 As Integer = 0
                    If Integer.TryParse(row2.Cells.Item(2).Value.ToString, sColor2) Then
                        Select Case sColor2

                            Case 1
                                row2.DefaultCellStyle.BackColor = Color.Green
                                row2.DefaultCellStyle.ForeColor = Color.White
                            Case 2
                                row2.DefaultCellStyle.BackColor = Color.Yellow
                                row2.DefaultCellStyle.ForeColor = Color.Black
                            Case 3
                                row2.DefaultCellStyle.BackColor = Color.Blue
                                row2.DefaultCellStyle.ForeColor = Color.White
                            Case 5
                                row2.DefaultCellStyle.BackColor = Color.Pink
                                row2.DefaultCellStyle.ForeColor = Color.Black
                            Case Else
                                row2.DefaultCellStyle.BackColor = Color.White
                                row2.DefaultCellStyle.ForeColor = Color.Black
                        End Select
                    End If

                Next
            End If


            '' This is for The Selection Back Color
            'Select Case sColor
            '    Case "3930"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "3981"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Yellow
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "3983"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.YellowGreen
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "3990"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "3932"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Red
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "3935"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "3937"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Green
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "3939"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Brown
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "3924"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Orange
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "1172C"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Red
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "1175C"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "1177C"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Green
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "3650-12"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Black
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "3997"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Green
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            '    Case "4090"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "4081"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Yellow
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case "4083"
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.YellowGreen
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black

            '    Case Else
            '        Me.DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Gray
            '        Me.DataGridView2.DefaultCellStyle.SelectionForeColor = Color.LightGray

            'End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ColorCodeDGV()")

        End Try

    End Sub

    ''' <summary>
    ''' Clear appropriate edit fields after updating Database
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFieldsAfterUpdate()


        Try

            Me.txtRackSlot.Clear()
            Me.txtTrailer.Clear()
            Me.txtShipper.Clear()
            Me.txtShipDate.Clear()

            ' Legend Lot
            Me.lblLegendPO.Text = ""
            Me.lblLegendRollWidth.Text = ""
            Me.lblLegendCode.Text = ""
            Me.lblLegendLot.Text = ""
            Me.lblLegendDrum.Text = ""
            Me.lblLegendInvoice.Text = ""
            Me.lblLegendShipDate.Text = ""
            Me.lblLegendRecvDate.Text = ""
            Me.lblLegendSheetDesc.Text = ""

            Me.lotLegend = Nothing
            Me.lblLegendID.Text = ""

            Me.btnLegendLot.Text = "Legend Lot #"

            ' Panel Lot
            Me.lblBGPO.Text = ""
            Me.lblBGRollWidth.Text = ""
            Me.lblBGCode.Text = ""
            Me.lblBGLot.Text = ""
            Me.lblBGDrum.Text = ""
            Me.lblBGInvoice.Text = ""
            Me.lblBGShipDate.Text = ""
            Me.lblBGRecvDate.Text = ""
            Me.lblBGSheetDesc.Text = ""

            Me.lotBG = Nothing
            Me.lblBGID.Text = ""

            Me.btnBGLot.Text = "Panel Lot #"

            ' Uncheck all Selected
            For Each row As DataGridViewRow In Me.DataGridView2.Rows
                row.Cells.Item(6).Value = False
            Next

            '' Clear Checked Count Label
            'Me.lblCheckedCount.Text = String.Empty
            Me.btnViewSelected.Text = "View Checked - ()"

            ' Clear Sign tech Check Box
            Me.ckbBatchDP.Checked = False



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ClearFieldsAfterUpdate()")

        End Try

    End Sub

    ''' <summary>
    ''' Find matching sign in "ssBS" and move the
    ''' BindingSource Position to matching record
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SyncTOFwDP()

        Try
            'If Me.DataGridView2.Rows.Count > 0 Then
            If Not Me.DataGridView2.DataSource Is Nothing Then
                If CType(Me.DataGridView2.DataSource, DataView).Count > 0 Then
                    If Me.DataGridView2.CurrentRow IsNot Nothing Then
                        If Me.DataGridView2.CurrentRow.Cells.Item(0).Value IsNot Nothing Then
                            'Dim dv As DataView = CType(Me.DataGridView2.DataSource, DataView)
                            'MessageBox.Show(dv.RowFilter)

                            Dim x1 As Integer = CInt(Me.DataGridView2.CurrentRow.Cells.Item(0).Value)
                            If x1 > 0 Then
                                Dim itemFound As Integer = ssBS.Find("StationID", x1)
                                If itemFound >= 0 Then
                                    ssBS.Position = itemFound

                                    ' Display sheeting details, if entered for existing record
                                    If Me.DataGridView1.CurrentRow IsNot Nothing Then
                                        FilterSheeting()
                                    End If


                                Else
                                    ' No Matching Station Status Record Found
                                End If
                            End If
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "SyncTOFwDP()")

        End Try

    End Sub

    ''' <summary>
    ''' Add stations updated to current session list
    ''' This list does not persist from session to session
    ''' Once this form is closed, the list is cleared
    ''' </summary>
    ''' <param name="site">Station Number</param>
    ''' <param name="ID">Site ID</param>
    ''' <remarks></remarks>
    Private Sub AddToUpdatedRecords(ByVal site As String, ByVal ID As Integer, ByVal entryTime As Date)

        Try
            'Me.dctUpdatedList.Add(site, ID)
            Me.dgvUpdatedList.Rows.Insert(0, site, ID, entryTime)

            With Me.dgvUpdatedList
                .Columns(2).DefaultCellStyle.Format = "M/dd/yyyy h:mm:ss tt"
            End With
            'ShowRecordCount()


            ' Deselect all rows
            For Each row As DataGridViewRow In dgvUpdatedList.Rows
                row.Selected = False
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AddToUpdatedRecords()")
        End Try

    End Sub

    ''' <summary>
    ''' Filter Combined DataTable
    ''' This code is causing errors... somewhere
    ''' When the Rowfilter returns 0 records
    ''' the DataGridView throws an IndexOutOfRangeException
    ''' These controls are currently disabled
    ''' 04.29.2018 -jk
    ''' </summary>
    ''' <param name="searchSTR"></param>
    ''' <remarks></remarks>
    Private Sub SortLike(ByVal searchSTR As String)


        Try
            Dim fieldName As String = Nothing
            Dim dv As DataView = TryCast(Me.DataGridView2.DataSource, DataView)

            ' Identify Search Field
            Select Case Me.cmbFilter.SelectedIndex
                Case 0      ' Station
                    fieldName = "Station"
                Case 1      ' Sign Type
                    fieldName = "signType"
                Case 2      ' Sign Code
                    fieldName = "signCode"
                Case 3      ' Details
                    fieldName = "signDetails"
                Case 4      ' Sign Size
                    fieldName = "signSize"
                Case 5      ' Sheeting
                    fieldName = "Sheeting"
            End Select

            If dv IsNot Nothing Then

                ' Temporary to display Rowfilter string in real-time - jk 07.22.2018
                lblDisplayRowfilter.Text = dv.RowFilter

                If dv.RowFilter <> String.Empty Or dv.RowFilter <> Nothing Then
                    Dim dvFilter As String = Nothing
                    Dim dvfNum As String = Nothing
                    Dim dvF As String() = dv.RowFilter.Split(CChar("="))
                    If dvF.Length > 1 Then
                        dvfNum = dvF(1).Substring(1, 1)
                    End If
                    Select Case dvfNum
                        Case "1"    ' Extruded
                            dvFilter = "TypeINT = 1 AND Sheeting <> 'NONE'"
                        Case "2"    ' Plywood
                            dvFilter = "TypeINT = 2 AND Sheeting <> 'NONE'"
                        Case "3"    ' Flatsheet .080in
                            dvFilter = "TypeINT = 3 AND Sheeting <> 'NONE'"
                        Case "5"    ' Flatsheet .125in
                            dvFilter = "TypeINT = 5 AND Sheeting <> 'NONE'"
                        Case Else
                            ' Add all other scenarios
                            'MessageBox.Show(dv.RowFilter, "Case Else, Line 2437")
                            dvFilter = "Sheeting <> 'NONE'"
                    End Select
                    If searchSTR <> String.Empty Then
                        dv.RowFilter = dvFilter & " And " & fieldName & " LIKE '*" & searchSTR & "*'"
                    Else
                        dv.RowFilter = dvFilter
                    End If
                Else
                    ' Rowfilter is currently Nothing
                    If Not searchSTR Is Nothing Then
                        dv.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                    Else
                        dv.RowFilter = Nothing
                    End If
                End If

                ' Temporary to display Rowfilter string in real-time - jk 07.22.2018 
                Me.lblDisplayRowfilter.Text = dv.RowFilter

                ' Call method to display number of records in current filtered dataset (DataView)
                DisplayRowCount()



                ' OLD CODE, NOT USED  -JK 7.22.2018
                'If dv.Count > 0 Then
                'dv.RowFilter = dv.RowFilter & " And " & fieldName & " LIKE '*" & searchSTR & "*'"
                'MessageBox.Show(dv.RowFilter)
                '' Check to see if RowFilter is already set
                'If dv.RowFilter = String.Empty Or dv.RowFilter = Nothing Then
                '    dv.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                'Else
                '    dv.RowFilter = dv.RowFilter & " And " & fieldName & " LIKE '*" & searchSTR & "*'"
                'End If
                ''ColorCodeDGV()
                'End If


            End If

        Catch ex As Exception
            'Me.ssTbl.DefaultView.RowFilter = Nothing
            MessageBox.Show(ex.Message, "SortLike()")
        End Try

    End Sub

    ''' <summary>
    ''' Clear Controls and Class-Level Variable selected values
    ''' </summary>
    ''' <param name="BGorLegend">"BG", "Legend"; These are the only accepted values</param>
    ''' <remarks></remarks>
    Private Sub ClearSheetingSelection(ByVal BGorLegend As String)

        Try

            Select Case BGorLegend

                Case "BG"     ' Panel Lot

                    ' Clear Class Prperty (Integer)
                    Me.lotBG = Nothing

                    ' Reset/Clear Controls
                    Me.lblBGPO.Text = ""
                    Me.lblBGRollWidth.Text = ""
                    Me.lblBGCode.Text = ""
                    Me.lblBGLot.Text = ""
                    Me.lblBGDrum.Text = ""
                    Me.lblBGInvoice.Text = ""
                    Me.lblBGShipDate.Text = ""
                    Me.lblBGRecvDate.Text = ""
                    Me.lblBGSheetDesc.Text = ""
                    Me.btnBGLot.Text = "Panel Lot #"
                    Me.lblBGID.Text = ""


                Case "Legend"     ' Legend Lot

                    ' Clear Class Prperty (Integer)
                    Me.lotLegend = Nothing

                    ' Reset/Clear Controls
                    Me.lblLegendPO.Text = ""
                    Me.lblLegendRollWidth.Text = ""
                    Me.lblLegendCode.Text = ""
                    Me.lblLegendLot.Text = ""
                    Me.lblLegendDrum.Text = ""
                    Me.lblLegendInvoice.Text = ""
                    Me.lblLegendShipDate.Text = ""
                    Me.lblLegendRecvDate.Text = ""
                    Me.lblLegendSheetDesc.Text = ""
                    Me.btnLegendLot.Text = "Legend Lot #"
                    Me.lblLegendID.Text = ""

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ClearSheetingSelection(" & BGorLegend & ")")

        End Try

    End Sub

    ''' <summary>
    ''' Enable or disable buttons in SplitContainer1.Panel1
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToggleEnabledFields()
        Try
            For Each ctl As Control In Me.SplitContainer1.Panel1.Controls
                If TypeOf (ctl) Is Button Then
                    Select Case ctl.Enabled
                        Case True
                            ctl.Enabled = False
                        Case False
                            ctl.Enabled = True
                    End Select
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ToggleEnableFields()")

        End Try
    End Sub

    ''' <summary>
    ''' Open Combine-Migrate form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picLogo_MHS_DoubleClick(sender As Object, e As System.EventArgs) Handles picLogo_MHS.DoubleClick

        Dim combineMigrate As New frmTOFtoStatus
        combineMigrate.MdiParent = Me.MdiParent
        combineMigrate.Show()



    End Sub

#End Region

    



#Region " Event Procedures"

    Private Sub frmStationStatus_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyData

            Case Keys.F1


                e.SuppressKeyPress = True

          
            Case Keys.Control Or Keys.NumPad0

                AutoCheckRow()
                e.SuppressKeyPress = True



        End Select


    End Sub

    Private Sub frmStationStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadSignTech()
        LoadMHSJobs()
        LoadSheetingDetails()

        ' Lock controls until Job is loaded
        Me.SplitContainer2.Enabled = False

        ToggleEnabledFields()

        Me.cmbMhsJob.Focus()


    End Sub

    Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged

        ' Enable Controls
        Me.SplitContainer2.Enabled = True

        If Not Me.btnViewSelected.Enabled Then
            ToggleEnabledFields()
        End If

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

        ' Run filter button method to reconfigure color coding
        ' Sending btnAll as the sender
        Me.btnAll_Filter_Click(Me.btnAll, Nothing)

        Me.DataGridView2.Focus()

        Me.ProgressBar1.Visible = False
        Me.txtProgress.Visible = False


    End Sub

    ''' <summary>
    ''' Not currently used.  All code is commented out. -jk 2018-12-1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ssBS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ssBS.PositionChanged

        ''Dim bs As BindingSource = DirectCast(sender, BindingSource)
        ''Dim dr As DataRowView = DirectCast(bs.Current, DataRowView)
        'Dim dr As DataRowView = CType(DirectCast(sender, BindingSource).Current, DataRowView)

        'Dim x As Integer = CType(dr.Item("StationID"), Integer)
        'FilterSSTable(x)




    End Sub

    Private Sub btnAll_Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnAll.Click, _
        btnFilterEXT.Click, _
        btnFilterPLY.Click, _
        btnFilterFS.Click, _
        btnFilterFSV.Click, _
        btnViewHideNONE.Click, _
        btnViewSelected.Click

        Try
            Dim b As Button = DirectCast(sender, Button)
            Dim x As Integer ' Sign Type
            Dim currentFilter As String = Nothing  ' Which signs are being displayed currently
            Dim filterString As String = Nothing

            Select Case b.Name
                Case "btnViewHideNONE"
                    Me.DataGridView2.GridColor = Color.DimGray
                    Me.DataGridView1.GridColor = Color.DimGray
                    currentFilter = "All TakeOff Records."
                    x = 0
                Case "btnFilterEXT"
                    Me.DataGridView2.GridColor = Color.Green
                    Me.DataGridView1.GridColor = Color.Green
                    currentFilter = "Extruded - Type I"
                    x = 1
                Case "btnFilterPLY"
                    Me.DataGridView2.GridColor = Color.Yellow
                    Me.DataGridView1.GridColor = Color.Yellow
                    currentFilter = "Plywood - Type II"
                    x = 2
                Case "btnFilterFS"
                    Me.DataGridView2.GridColor = Color.Blue
                    Me.DataGridView1.GridColor = Color.Blue
                    currentFilter = "FlatSheet .080in - Type III"
                    x = 3
                Case "btnFilterFSV"
                    Me.DataGridView2.GridColor = Color.Pink
                    Me.DataGridView1.GridColor = Color.Pink
                    currentFilter = "FlatSheet .125in - Type V"

                    x = 5
                Case "btnAll"
                    Me.DataGridView2.GridColor = Color.DimGray
                    Me.DataGridView1.GridColor = Color.DimGray
                    currentFilter = "All Fabricated Signs"
                    x = -1
                Case "btnViewSelected"
                    currentFilter = "Checked Signs"
                    x = -2
            End Select

            Dim expression As String = "TypeINT = " & x & " AND sheeting <> 'NONE'"
            Dim allSignExpression As String = "Sheeting <> 'NONE'"
            Dim checkSignExpression As String = "Select = True"
            Dim sortExp As String = "Station"

            If x > 0 Then
                Dim dv As DataView
                dv = New DataView(ssTbl, expression, sortExp, DataViewRowState.CurrentRows)
                BindDTControls(dv)
                filterString = dv.RowFilter
            ElseIf x = 0 Then
                Dim dvTOF As DataView
                dvTOF = New DataView(ssTbl, Nothing, sortExp, DataViewRowState.CurrentRows)
                BindDTControls(dvTOF)
                filterString = dvTOF.RowFilter
            ElseIf x = -2 Then
                Dim dvChecked As DataView
                dvChecked = New DataView(ssTbl, checkSignExpression, sortExp, DataViewRowState.CurrentRows)
                BindDTControls(dvChecked)
                filterString = dvChecked.RowFilter
            Else
                Dim dv2 As DataView
                dv2 = New DataView(ssTbl, allSignExpression, sortExp, DataViewRowState.CurrentRows)
                BindDTControls(dv2)
                filterString = dv2.RowFilter

            End If

            Me.lblDisplayRowfilter.Text = filterString
            Me.lblCurrentFilter.Text = currentFilter

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnAll_Click()")
        End Try

    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnSelectAll.Click, _
        btnSelectNone.Click


        Try
            Dim labelText As String = String.Empty
            Dim x As Integer = 0
            Dim c As Boolean = False
            Dim btn As Button = TryCast(sender, Button)
            If btn IsNot Nothing Then
                Select Case btn.Name
                    Case "btnSelectAll"
                        c = True
                    Case "btnSelectNone"
                        c = False
                End Select
                For Each row As DataGridViewRow In Me.DataGridView2.Rows
                    row.Cells.Item(6).Value = c
                    If c Then x += 1
                Next
                If x > 0 Then
                    'Me.lblCheckedCount.Text = x.ToString & " Checked"
                    labelText = x.ToString & " Checked"
                Else
                    labelText = String.Empty
                End If
                'Me.lblCheckedCount.Text = labelText
                Me.btnViewSelected.Text = "View Checked - (" & x.ToString & ")"

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnUpdateSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSelected.Click

        Try

            ' Validate there are records selected
            Dim y As Integer = 0
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If CType(r.Cells.Item(6).Value, Boolean) Then
                    y += 1
                End If
            Next
            If y <= 0 Then
                MessageBox.Show("Please select record(s) to be updated.", "Nothing Selected")
                Exit Sub
            End If


            ' Validate Shipper Number
            Dim shipID As Integer = 0
            If Integer.TryParse(Me.txtShipper.Text, shipID) Then
                ' Valid Integer, continue Sub
                If shipID >= 5000 Then
                    ' Valid Shipper number, continue Sub
                Else
                    MessageBox.Show("You must enter a valid MHS Shipper number.", "Invalid Shipper Number")
                    Exit Sub
                End If
            ElseIf Me.txtShipper.Text = String.Empty Then

                ' Disabled this code now that when no value is entered
                ' the cell is ignored; no changes made.
                ' The only problem this creates is if you 
                ' want null values in those fields.
                ' I'll figure out how to do that later.
                ' 04.15.2018 - jk

                'Dim dlg As DialogResult = MessageBox.Show("Empty Shipper Number?", _
                '         "Are you sure?", _
                '         MessageBoxButtons.YesNo, _
                '         MessageBoxIcon.Question)
                'Select Case dlg
                '    Case Windows.Forms.DialogResult.Yes
                '        'Continue Sub
                '    Case Windows.Forms.DialogResult.No
                '        Exit Sub
                'End Select
            Else
                MessageBox.Show("You must enter a valid MHS Shipper number.", "Invalid Shipper Number")
                Exit Sub
            End If


            ' Validate Ship Date
            Dim shipDateTEMP As Date
            If Date.TryParse(Me.txtShipDate.Text, shipDateTEMP) Then
                ' Valid Date, continue Sub
            ElseIf Me.txtShipDate.Text = String.Empty Then

                ' Disabled this code now that when no value is entered
                ' the cell is ignored; no changes made.
                ' The only problem this creates is if you 
                ' want null values in those fields.
                ' I'll figure out how to do that later.
                ' 04.15.2018 - jk

                'Dim dlg As DialogResult = MessageBox.Show("Empty Date?", _
                '                              "Are you sure?", _
                '                              MessageBoxButtons.YesNo, _
                '                              MessageBoxIcon.Question)
                'Select Case dlg
                '    Case Windows.Forms.DialogResult.Yes
                '        'Continue Sub
                '    Case Windows.Forms.DialogResult.No
                '        Exit Sub
                'End Select
            Else
                MessageBox.Show("Must enter a valid date", "Invalid Date Format")
                Exit Sub
            End If




            ' Lefft off 07/19/2018 10:10 pm




            ' Validate Daily Productions Reporting (Batch Mode)
            ' If Daily Productions CheckBox is Checked
            If ckbBatchDP.Checked Then
                ' Make sure a Sign Tech is Selected
                If Me.cmbSignTech.SelectedIndex > 0 Then
                    ' Sign Tech selected, continue method.
                Else
                    MessageBox.Show("Select a Sign Tech")
                    Exit Sub
                End If
            End If







            ' Apply Updated Info to Checked rows before saving back to Database in the UpdateSS() method
            For Each row As DataGridViewRow In Me.DataGridView2.Rows
                If CType(row.Cells.Item(6).Value, Boolean) Then
                    ' Current row is selected
                    ApplyUpdate(CType(row.Cells.Item(0).Value, Integer))
                Else
                    ' Current row is NOT selected
                    ' Continue loop
                End If
            Next







            ' Update using BindingSource.Update Method
            UpdateSS()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnUpdateSelected_Click()")

        End Try


    End Sub

    ''' <summary>
    ''' Used to count number of checked records in real time.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView2_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Try
            Dim checkedCount As Integer = 0
            For Each row As DataGridViewRow In Me.DataGridView2.Rows
                If CBool(row.Cells(6).EditedFormattedValue) Then
                    ' Increment checked row counter
                    checkedCount += 1

                End If
            Next

            'Dim displayCountText As String = Nothing
            'If checkedCount > 0 Then
            '    displayCountText = checkedCount.ToString & " Sign(s) Checked."
            'End If
            'Me.lblCheckedCount.Text = displayCountText
            Me.btnViewSelected.Text = "View Checked - (" & checkedCount.ToString & ")"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "DataGridView2_CellContentClick()")

        End Try



    End Sub

    Private Sub DataGridView1_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        DataGridView1.DataSourceChanged, _
        DataGridView2.DataSourceChanged, _
        DataGridView2.Sorted

        Try

            DisplayRowCount()
            ColorCodeDGV()

            ' Synchronize Combined TOF Tables with 
            ' Daily Production Tables (StationStatus)
            SyncTOFwDP()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "DataGridView1_DataSourceChanged_+2()")
        End Try


    End Sub

    Private Sub DataGridView2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView2.SelectionChanged
        Try
            ' Synchronize Combined TOF Tables with 
            ' Daily Production Tables (StationStatus)
            SyncTOFwDP()

            

        Catch ex As Exception

            MessageBox.Show(ex.Message, "DataGridView2_SelectionChanged()")

        End Try


    End Sub

    ''' <summary>
    ''' Migrate data to the fields that are used for editing
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lblRackBIND_DoubleClick(sender As Object, e As System.EventArgs) Handles _
        lblRackBIND.DoubleClick, _
        lblTrailerBIND.DoubleClick, _
        lblShipperBind.DoubleClick, _
        lblShipDateBIND.DoubleClick


        Dim lbl As Label = DirectCast(sender, Label)
        Dim lblText As String = lbl.Text

        Select Case lbl.Name

            Case "lblRackBIND"
                Me.txtRackSlot.Text = lblText

            Case "lblTrailerBIND"
                Me.txtTrailer.Text = lblText

            Case "lblShipperBind"
                Me.txtShipper.Text = lblText

            Case "lblShipDateBIND"
                Me.txtShipDate.Text = lblText

        End Select

    End Sub

    ''' <summary>
    ''' Filter DataTable as text is entered
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCriteria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCriteria.TextChanged
        Try
            SortLike(Me.txtCriteria.Text)

            ColorCodeDGV()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "txtCriteria_TextChanged()")
        End Try


    End Sub

    ''' <summary>
    ''' Clear Selected Sheeting.  This method does not delete sheeting ID
    ''' for already saved data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearLegendLot_Click(sender As System.Object, e As System.EventArgs) Handles _
            btnClearLegendLot.Click, _
            btnClearPanelLot.Click

        Dim btn As Button = TryCast(sender, Button)
        Dim s As String = String.Empty

        If btn IsNot Nothing Then
            Select Case btn.Name
                Case "btnClearLegendLot"
                    s = "Legend"
                Case "btnClearPanelLot"
                    s = "BG"
            End Select

            If s <> String.Empty Then
                ClearSheetingSelection(s)
            End If
        End If

    End Sub




    Private Sub DataGridView2_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError


        'Dim dvCount As Integer = CType(Me.DataGridView2.DataSource, DataView).Count
        'Dim dvRowFilter As String = CType(Me.DataGridView2.DataSource, DataView).RowFilter

        'MessageBox.Show(dvCount & vbCr & dvRowFilter)


        'MessageBox.Show("Error happened " _
        '    & e.Context.ToString())


        'If (e.Context = DataGridViewDataErrorContexts.Commit) _
        '    Then
        '    MessageBox.Show("Commit error")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts _
        '    .CurrentCellChange) Then
        '    MessageBox.Show("Cell change")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.Parsing) _
        '    Then
        '    MessageBox.Show("parsing error")
        'End If
        'If (e.Context = _
        '    DataGridViewDataErrorContexts.LeaveControl) Then
        '    MessageBox.Show("leave control error")
        'End If



        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
        '        .ErrorText = "an error"

        '    e.ThrowException = False
        'End If

    End Sub

    Private Sub lblBuildDate_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lblBuildDate.DoubleClick

        Try
            'Dim defaultDate As String = Today.ToString("MM/dd/yyyy")
            Dim validatedDate As Date = Nothing
            Dim BuildDate As String = InputBox("Enter Date", "Build Date", Today.ToString("MM/dd/yyyy"))
            If Date.TryParse(BuildDate, validatedDate) Then
                Me.lblBuildDate.Text = validatedDate.ToString("MM/dd/yyyy")

            Else
                MessageBox.Show("Please enter a valid date", "Date Format Error")
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "lblBuildDate_DoubleClick()")

        End Try



    End Sub

    ''' <summary>
    ''' Reload Job Data to avoid having to close and reopen form to obtain updated data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click


        LoadMHSJobs()
        Me.cmbMhsJob.Focus()


    End Sub

    

    ''' <summary>
    ''' Check current datagridview row
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AutoCheckRow()

        Try
            Me.DataGridView2.CurrentRow.Cells(6).Value = True

        Catch ex As Exception

        End Try


    End Sub

    ''' <summary>
    ''' Reload TakeOff and StationStatus data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReLoadTOF_Click(sender As System.Object, e As System.EventArgs) Handles btnReLoadTOF.Click



        Dim dlg As DialogResult = MessageBox.Show("This will reload all data and clear any records currently checked.  Are you sure?", "Reload Data?", MessageBoxButtons.OKCancel)

        Select Case dlg

            Case Windows.Forms.DialogResult.OK
                cmbMhsJob_SelectedIndexChanged(Nothing, Nothing)
            Case Windows.Forms.DialogResult.Cancel

            Case Else

        End Select




    End Sub


    




#End Region





#Region " Old/Unused Code - Saved for possible future use"


	Private Sub RetainedOldShit()


		'Try
		'    '''' v1 =   Sign type as listed in each type's TOF table.
		'    ''''        With considerations for the occasional errant missing 
		'    ''''        "A" or "B", such as the case with MDOT or SALVAGE signs.
		'    ''''        *This value gets processed through the GetTOFData() method
		'    ''''        and returns an integer value (v3) representing each type (i.e. 1, 2, 3)
		'    ''''        which will determine which Method() to run.

		'    '''' v2 =   'SignID' Primary Key field value for each sign related to each TOF table
		'    ''''        Use this to obtain TOF Data

		'    '''' v3 =   See * in v1 description.  Integer representing sign type.

		'    Dim v1 As String = e.DataRepeaterItem.Controls(txtSignType.Name).Text
		'    Dim v2 As Integer = CInt(e.DataRepeaterItem.Controls(txtStationID.Name).Text)
		'    Dim v3 As Integer = GetSignType(v1)

		'    GetTOFData(v3, v2)

		'    'Dim fN As String = e.DataRepeaterItem.Controls(Me.tstStation.Name).Text & ".jpg"
		'    Dim fN As String = "56-12.jpg"
		'    Dim fNPath As String = "c:\sIv2\Simulator\signImages\" & Me.cmbMhsJob.Text & "\" & fN

		'    Me.picStation.Load(fNPath)

		'    'ShowSignImage()

		'Catch ex As Exception
		'    MessageBox.Show(ex.Message, "drpSignList_DrawItem")

		'End Try




	End Sub






#End Region




    
End Class




