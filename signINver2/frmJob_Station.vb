Option Strict On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources






Public Class frmJob_Station




#Region " Database Communication"


    ' Connection to db1.mdb
	'Dim mhsConn As New OleDbConnection(connStr01)
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' MHS Jobs
    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
    Dim mhsJobDV As DataView
    Dim mhsJobDT As DataTable


    ' Stations Per Job
    Dim stationsDA As OleDbDataAdapter
    Dim stationsDS As DataSet
    Dim stationsDV As DataView
    Dim stationsDT As DataTable


    Dim cmdStations As OleDbCommand



#End Region



#Region " Subs & Methods"




    Private Sub GetSchemaInfo()
		'Using connection As New OleDbConnection(My.Settings.SignInConn)
        '    Dim command As OleDbCommand = New OleDbCommand( _
        '      "Select ID, station From ExtrudedTOF Where mhsJob = @mhsJob " & _
        '                                       "Union Select ID, station From PlywoodTOF Where mhsJob = @mhsJob " & _
        '                                       "Union Select ID, station From FlatsheetTOF Where mhsJob = @mhsJob", _
        '                                       connection)
        '    connection.Open()

        '    Dim reader As OleDbDataReader = command.ExecuteReader()
        '    stationsDT = reader.GetSchemaTable()

        '    With Me.cmbStation
        '        .DataSource = stationsDT
        '        .Text = "Select Station"
        '    End With

        '    'Dim row As DataRow
        '    'Dim column As DataColumn

        '    'For Each row In schemaTable.Rows
        '    '    For Each column In schemaTable.Columns
        '    '        Console.WriteLine(String.Format("{0} = {1}", _
        '    '          column.ColumnName, row(column)))
        '    '    Next
        '    '    Console.WriteLine()
        '    'Next
        '    reader.Close()
        'End Using
    End Sub




    Private Sub test()


    End Sub



    Public Sub PopulateMHSJobs()

        Try

            mhsJobDA = New OleDbDataAdapter("SELECT mhsJob, jobDesc FROM mhsJobs ORDER By mhsJob DESC", mhsConn)

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

            Me.lblJobDesc.DataBindings.Clear()
            Me.lblJobDesc.DataBindings.Add("Text", mhsJobDT, "jobDesc")

            ' Populate tsbCmbMHSJob combo box
            RemoveHandler cmbMHSJob.SelectedIndexChanged, AddressOf cmbMHSJob_SelectedIndexChanged
            With Me.cmbMHSJob
                .DataSource = mhsJobDT
                .DisplayMember = "mhsJob"
            End With
            AddHandler cmbMHSJob.SelectedIndexChanged, AddressOf cmbMHSJob_SelectedIndexChanged


        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateMHSJobs()")

        End Try

    End Sub

    Private Sub AllSigns()

        Try
			'Using connection As New OleDbConnection(My.Settings.SignINconn)
            '    Dim command As OleDbCommand = New OleDbCommand( _
            '      "Select ID, station From ExtrudedTOF Where mhsJob = @mhsJob " & _
            '                                       "Union Select ID, station From PlywoodTOF Where mhsJob = @mhsJob " & _
            '                                       "Union Select ID, station From FlatsheetTOF Where mhsJob = @mhsJob", _
            '                                       connection)

            '    command.Parameters.AddWithValue("@mhsJob", Me.cmbStation.Text)

            '    connection.Open()

            '    Dim reader As OleDbDataReader = command.ExecuteReader()

            '    stationsDT = reader.GetSchemaTable()

            '    With Me.cmbStation
            '        .DataSource = stationsDT
            '        .Text = "Select Station"
            '    End With

            '    'Dim row As DataRow
            '    'Dim column As DataColumn

            '    'For Each row In schemaTable.Rows
            '    '    For Each column In schemaTable.Columns
            '    '        Console.WriteLine(String.Format("{0} = {1}", _
            '    '          column.ColumnName, row(column)))
            '    '    Next
            '    '    Console.WriteLine()
            '    'Next
            '    reader.Close()
            'End Using


        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "AllSigns()")

        End Try

    End Sub






#End Region


#Region " Event Procdures"


    Private Sub frmJob_Station_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateMHSJobs()

    End Sub

    Private Sub cmbMHSJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMHSJob.SelectedIndexChanged

        AllSigns()

    End Sub


#End Region






End Class