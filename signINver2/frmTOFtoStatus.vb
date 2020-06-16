Option Strict On
Option Explicit On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources



Public Class frmTOFtoStatus



    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' MHS Jobs
    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
    Dim mhsJobDT As DataTable


    'Dim tofDA As OleDbDataAdapter
    'Dim tofDS As DataSet
	Dim tofDT As New DataTable
	Dim stopDupDT As New DataTable


	' Status Status 
	Friend WithEvents ssBS As BindingSource
	'Dim ssBS As BindingSource
	Dim ssDA As OleDbDataAdapter
	Dim ssDS As DataSet
	Dim ssDT As DataTable


	Dim tofTypeFilter As String





    Public Sub PopulateMHSJobs()

        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT mhsJob FROM mhsJobs " & _
                                                       "ORDER By mhsJob DESC", mhsConn)

            'cmd.Parameters.AddWithValue("@job", Me.cmbMhsJob.Text)

            mhsJobDA = New OleDbDataAdapter(cmd)

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

            ' Populate tsbCmbMHSJob combo box
            RemoveHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged
            With Me.cmbMhsJob
                .DataSource = mhsJobDT
                .DisplayMember = "mhsJob"
            End With
            AddHandler cmbMhsJob.SelectedIndexChanged, AddressOf cmbMhsJob_SelectedIndexChanged


        Catch ex As Exception

        End Try



    End Sub

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
                                                           "WHERE mhsJob = @job", mhsConn)


                ' Add parameters
                tofCMD.Parameters.AddWithValue("@job", job)

                ' Open the connection, execute the command
                mhsConn.Open()

                ' Declare reader object and fill with query result
                Dim reader As OleDbDataReader = tofCMD.ExecuteReader()

                ' Load the DataTable with data from the DataReader
                tofDT.Load(reader)

                ' Close the reader
                reader.Close()

                ' Close the connection
                mhsConn.Close()

            Else
                MessageBox.Show("select a job first.")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "LoadTOFbyJob()")
            mhsConn.Close()


        End Try

    End Sub

	Private Function StopDuplicate(ByVal mhsJob As String, ByVal type As Integer, ByVal IDCheck As Integer) As Boolean

		Try
			Me.ssBS.Filter = "mhsJob = '" & mhsJob & "' AND type = " & type & " AND StationID = " & IDCheck

			If Me.ssBS.List.Count > 0 Then
				'MessageBox.Show("Duplicate Found")
				Return True
			Else
				'MessageBox.Show("No Duplicate")
				Return False
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "StopDuplicate()")
		End Try


		'Try

		'	' Clear previous data, if any, from DataTable
		'	stopDupDT.Clear()


		'	Dim tofCheckCMD As OleDbCommand = New OleDbCommand("SELECT ID, mhsJob, type, StationID FROM tblStationStatus " & _
		'	   "WHERE (mhsJob = @job) AND (type = @type) AND (StationID = @StationID)", mhsConn)


		'	' Add parameters
		'	tofCheckCMD.Parameters.AddWithValue("@job", mhsJob)
		'	tofCheckCMD.Parameters.AddWithValue("@type", type)
		'	tofCheckCMD.Parameters.AddWithValue("@StationID", IDCheck)

		'	' Open the connection, execute the command
		'	mhsConn.Open()

		'	' Declare reader object and fill with query result
		'	Dim reader As OleDbDataReader = tofCheckCMD.ExecuteReader()


		'	If reader.HasRows Then

		'		'MessageBox.Show("Record already exists in Station Status Table", "Duplicate Record")
		'		' Load the DataTable with data from the DataReader
		'		stopDupDT.Load(reader)

		'		' Close the reader
		'		reader.Close()

		'		' Close the connection
		'		mhsConn.Close()

		'		Return True


		'	Else


		'		' Close the connection
		'		mhsConn.Close()


		'		Return False

		'	End If

		'	'Dim oleRdr as new OleDbReader = sqlCheck.ExecuteReader()
		'	'If oleRdr.HasRows = True Then
		'	'	oleRdr.Read()
		'	'	If oleRdr.Item(0) = 0 Then
		'	'		'username is available and you can do insert command now
		'	'	Else
		'	'		'username is not available
		'	'	End If
		'	'End If

		'	' Close the connection
		'	mhsConn.Close()



		'Catch ex As Exception
		'	MessageBox.Show(ex.Message, "StopDuplicate()")
		'	mhsConn.Close()


		'End Try




	End Function




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


			Case "II", "IIA", "IIB", "IIC", "IID"
				s = 2
				
			Case "III", "IIIA", "IIIB", "IIIC", "IIID"
				s = 3

			Case "V", "VA", "VB", "VC", "VD"
				s = 5

			Case Else
				s = 0
		End Select

		Return s

	End Function



	''' <summary>
	''' Load up currenty records from tblStationStatus
	''' I've created all the ADO.Net objectso to add/update/delete
	''' Only need to read to check for duplicates at this point
	''' 7/13/16
	''' </summary>
	''' <param name="jn">MHS Job Number</param>
	''' <remarks></remarks>
	Private Sub FillSSDT(ByVal jn As String)

		
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
			  "WHERE mhsJob = @mhsJob", mhsConn)

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
			mhsConn.Open()

			' Fill DataSet with data via DataAdapater
			ssDA.Fill(ssDS, "tblStationStatus")
			cmdSS.Parameters.Clear()


			'  Close the connection
			mhsConn.Close()
			'-----------------------

			' Create binding source
			ssBS = New BindingSource(ssDS, "tblStationStatus")

			' DataTable -   Fill the DataTable object with data
			ssDT = ssDS.Tables("tblStationStatus")

			

		Catch ex As Exception
			MessageBox.Show(ex.Message, "FillSSDT()")

		End Try

	End Sub



	'ByVal siteID As Integer, ByVal jn As String, ByVal siteType As String
	Private Sub InsertStationStatus(ByVal jn As String, ByVal sT As Integer, ByVal siteID As Integer)

		
		Try
			Using connection As New OleDbConnection(My.Settings.SignINconn)
				Using command As New OleDbCommand("INSERT INTO tblStationStatus (mhsJob, type, StationID) " & _
				 "VALUES (@mhsJob, @type, @ID)", connection)
					command.Parameters.AddWithValue("@mhsJob", jn)
					command.Parameters.AddWithValue("@type", sT)
					command.Parameters.AddWithValue("@ID", siteID)

					connection.Open()
					command.ExecuteNonQuery()
				End Using
			End Using

		Catch ex As Exception
			MessageBox.Show(ex.Message, "InsertStationstatus()")

		End Try
	End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Try
			Dim totalRecords As Integer = Me.DataGridView1.Rows.Count

			Dim jobNum As String
			Dim sType As Integer
			Dim ssID As Integer
			Dim skipCount As Integer = 0
			Dim totalCount As Integer = 0



            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Maximum = totalRecords
            
			For Each row As DataGridViewRow In DataGridView1.Rows

				jobNum = CType(row.Cells.Item(1).Value, String)
				sType = GetSignType(CType(row.Cells.Item(2).Value, String))
				ssID = CType(row.Cells.Item(0).Value, Integer)

				If StopDuplicate(jobNum, sType, ssID) Then
					skipCount += 1
				Else
					InsertStationStatus(jobNum, sType, ssID)
				End If


				Me.ProgressBar1.Value += 1

				Dim y As Double = (ProgressBar1.Value / ProgressBar1.Maximum) * 100
				Dim x As Integer = CInt(Math.Ceiling(y))

				Me.TextBox1.Text = x & "%"
				Me.TextBox1.Refresh()

			Next

			totalCount = totalRecords - skipCount

			MessageBox.Show(totalCount.ToString & " Records added, out of " & totalRecords.ToString & " , " & skipCount.ToString & " records skipped to avoid duplicates.", "Results")

		Catch ex As Exception
			MessageBox.Show(ex.Message, "button1.click()")

        End Try




    End Sub

    Private Sub frmTOFtoStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateMHSJobs()


    End Sub

    Private Sub cmbMhsJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMhsJob.SelectedIndexChanged

		LoadTOFbyJob(Me.cmbMhsJob.Text)
		FillSSDT(Me.cmbMhsJob.Text)

    End Sub


	Private Sub UpdateRecordCount()
		Me.TextBox1.Clear()
		Me.TextBox1.Text = Me.DataGridView1.Rows.Count.ToString

	End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try
            If Not IsNothing(tofDT) Then

                Me.DataGridView1.DataSource = tofDT
				UpdateRecordCount()

            Else
                MessageBox.Show("too bad....it aint workin'.", "Fuck!!!")

            End If





        Catch ex As Exception
            MessageBox.Show(ex.Message, "Button2_Click()")

        End Try

	End Sub





	Private Sub btnAll_Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click, _
	   btnFilterEXT.Click, btnFilterPLY.Click, btnFilterFS.Click, btnFilterTypeV.Click

		Try
			Dim b As Button = DirectCast(sender, Button)
			Dim x As Integer

			Select Case b.Name
				Case "btnFilterEXT"
					x = 1
					tofDT.DefaultView.RowFilter = "type Like 'I' or type Like 'IA' or type Like 'IB' or type Like 'IC' or type Like 'ID'"
				Case "btnFilterPLY"
					x = 2
					tofDT.DefaultView.RowFilter = "type Like 'II' or type Like 'IIA' or type Like 'IIB' or type Like 'IIC' or type Like 'IID'"

				Case "btnFilterFS"
					x = 3
					tofDT.DefaultView.RowFilter = "type Like 'III' or type Like 'IIIA' or type Like 'IIIB' or type Like 'IIIC' or type Like 'IIID'"

				Case "btnFilterTypeV"
					x = 5
					tofDT.DefaultView.RowFilter = "type Like 'V' or type Like 'VA' or type Like 'VB' or type Like 'VC' or type Like 'VD'"

				Case Else
					x = -1
					tofDT.DefaultView.RowFilter = Nothing

			End Select

			UpdateRecordCount()


			'Dim expression As String = "type = '" & tofTypeFilter "'"
			'Dim sortExp As String = "TypeINT"

			'If x > 0 Then
			'	Dim dv As DataView
			'	dv = New DataView(ssTbl, expression, sortExp, DataViewRowState.CurrentRows)
			'	'BindDTControls(dv)
			'Else
			'	Dim dv2 As DataView
			'	dv2 = New DataView(ssTbl, Nothing, sortExp, DataViewRowState.CurrentRows)
			'	'BindDTControls(dv2)
			'End If

			'ShowPosition()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnAll_Filter_Click()")
		End Try

	End Sub





















	
End Class