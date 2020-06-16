Option Strict On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources



Public Class frmFlatSheetTOF


    Public Sub New(ByVal jn As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.mhsJN = jn.ToUpper



    End Sub


#Region " Class-level Variables"


    Dim mhsJN As String
    Dim jobDescription As String



#End Region



#Region " Database Communication"

    '  (db1.mdb) connection
	'Dim objConn As New OleDbConnection(connStr01)
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)

    ' Flat Sheet Take Off
    Dim fsTOFDA As OleDbDataAdapter
    Dim fsTOFDS As DataSet
    Dim fsTOFDT As DataTable
    Dim fsTOFDV As DataView


    '  Job Description
    Dim jobDescDA As New OleDbDataAdapter
    Dim jobDescDS As New DataSet
    Dim jobDescDV As New DataView

#End Region




#Region " Event Handlers"

    Private Sub frmFlatSheetTOF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case fsTOFDS.HasChanges

            Case True

                Dim saveResult As DialogResult

                saveResult = MessageBox.Show("Do you want to save your changes?", _
                                             "Save Changes", _
                                             MessageBoxButtons.YesNoCancel, _
                                             MessageBoxIcon.Question, _
                                             MessageBoxDefaultButton.Button1)

                Select Case saveResult

                    Case DialogResult.Yes
                        ' Write changes back to DataSource (database)
                        updateDb()

                    Case DialogResult.No
                        ' Changes detected and user
                        ' selects not to save changes and
                        ' continue with closing the form
                        e.Cancel = False

                    Case DialogResult.Cancel
                        ' Cancel the form closing
                        e.Cancel = True
                End Select

            Case False
                ' continue with closing the form
                e.Cancel = False
        End Select
    End Sub

    Private Sub frmPlywoodTOF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillDGV()
        getJobDesc()

        Me.cmbFSTOFFields.SelectedIndex = 0
        Me.txtCriteria.Select()

    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        updateDb()
    End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
        sortLike(Me.txtCriteria.Text)
    End Sub

    Private Sub dgvFSTOF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFSTOF.DoubleClick

        Try

            Dim signTOFID As Integer = CType(Me.dgvFSTOF.CurrentRow.Cells.Item(0).Value, Integer)

            ViewSign(3, signTOFID)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvFSTOF_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvFSTOF.UserDeletingRow
        Dim okToDelete As DialogResult

        okToDelete = MessageBox.Show("OK to delete?", "Confirm Deletion", _
                                     MessageBoxButtons.OKCancel, _
                                     MessageBoxIcon.Question)

        Select Case okToDelete
            Case Windows.Forms.DialogResult.OK
                e.Cancel = False
            Case Windows.Forms.DialogResult.Cancel
                e.Cancel = True
        End Select
    End Sub

    Private Sub tsbNormalView_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNormalView.ButtonClick
        Me.SplitContainer1.Panel1Collapsed = False
        Me.tsbNormalView.Visible = False
        Me.tsbSave.Visible = False
        Me.txtCriteria.Select()
    End Sub

    Private Sub lblHideSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHideSearch.Click
        Me.SplitContainer1.Panel1Collapsed = True
        Me.tsbNormalView.Visible = True
        Me.tsbSave.Visible = True
    End Sub

    Private Sub tsbSave_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.ButtonClick
        updateDb()

    End Sub

#End Region



#Region " Subs & Functions"



    Public Sub fillDGV()



        ' Get currently selected row if refreshing from update
        ' so that after the refresh, the row will be re-selected
        ' or if refreshing after deleting the row before it will
        ' be selected
        Dim i As Integer = 0
        Try
            If dgvFSTOF.Rows.Count > 0 Then
                i = CType(dgvFSTOF.CurrentRow.Cells.Item(0).Value, Integer)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "declare var for record ID error")

        End Try



        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM FlatsheetTOF " & _
                                                       "WHERE mhsJob = '" & Me.mhsJN & "' ORDER By station", objConn)


            ' Open connection to Db
            objConn.Open()

            '  Fill dataAdapter with query result from Db
            fsTOFDA = New OleDbDataAdapter(cmd)


            'One CommandBuilder object is required. 
            'It automatically generates DeleteCommand, 
            'UpdateCommand and InsertCommand 
            'for DataAdapter object      
            Dim plyTOFBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(fsTOFDA)

            ' Instantiate DataSet object
            fsTOFDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            fsTOFDA.Fill(fsTOFDS, "FlatsheetTOF")

            ' DataTable -   Fill the DataTable object with data
            fsTOFDT = fsTOFDS.Tables("FlatsheetTOF")

            ' Set the Dataview object to the Dataset object
            fsTOFDV = New DataView(fsTOFDS.Tables("FlatsheetTOF"))


            '  Close the connection
            objConn.Close()


            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke
            Me.dgvFSTOF.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

            ' Declare and set the header alignment property
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim objBoldFont As New DataGridViewCellStyle()

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            With Me.dgvFSTOF

                .DataSource = Me.fsTOFDV

                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' ID field
                .Columns(0).Visible = False

                ' mhsJob field
                .Columns(1).HeaderText = "MHS #"
                .Columns(1).Width = 50
                '.Columns(1).DefaultCellStyle.ForeColor = Color.Black
                .Columns(1).DefaultCellStyle.Font = New Font(Me.dgvFSTOF.Font, FontStyle.Bold)

                ' station field
                .Columns(2).HeaderText = "Station"
                .Columns(2).Width = 85

                ' type field
                .Columns(3).HeaderText = "Type"
                .Columns(3).Width = 35
                .Columns(3).DefaultCellStyle = objAlignMidcellStyle

                ' code field
                .Columns(4).HeaderText = "Sign code"
                .Columns(4).Width = 75

                ' details field
                .Columns(5).HeaderText = "Sign Details"
                .Columns(5).Width = 150

                ' width field
                .Columns(6).HeaderText = "Width"
                .Columns(6).Width = 35
                .Columns(6).DefaultCellStyle = objAlignRightcellStyle

                ' height field
                .Columns(7).HeaderText = "Height"
                .Columns(7).Width = 35
                .Columns(7).DefaultCellStyle = objAlignRightcellStyle

                ' sqrFeet field
                .Columns(8).HeaderText = "SqFt"
                .Columns(8).Width = 45
                .Columns(8).DefaultCellStyle = objAlignRightcellStyle
                '.Columns(8).DefaultCellStyle.Font = New Font(Me.dgvPLYTOF.Font, FontStyle.Bold)

                ' sptQty field
                .Columns(9).HeaderText = "S-Qty"
                .Columns(9).Width = 35
                .Columns(9).DefaultCellStyle = objAlignRightcellStyle

                ' support field
                .Columns(10).HeaderText = "Support"
                .Columns(10).Width = 100

                ' hdwQty field
                .Columns(11).HeaderText = "H-Qty"
                .Columns(11).Width = 35
                .Columns(11).DefaultCellStyle = objAlignRightcellStyle
                '.Columns(11).DefaultCellStyle.Font = New Font(Me.dgvPLYTOF.Font, FontStyle.Bold)

                ' hardware field
                .Columns(12).HeaderText = "Hardware"
                .Columns(12).Width = 100

                ' sheeting field
                .Columns(13).HeaderText = "Sheeting"
                .Columns(13).Width = 55

                Me.ToolStripStatusLabel1.Text = "FlatSheet T/O  (" & Me.fsTOFDV.Count & " Records)"



            End With

            Try
                If i > 0 Then
                    For Each row As DataGridViewRow In dgvFSTOF.Rows

                        If CType(row.Cells.Item(0).Value, Integer) = i Then
                            row.Selected = True
                        Else
                            row.Selected = False
                        End If
                    Next
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message, "row selection process error")

            End Try


        Catch ex As Exception

            MessageBox.Show(ex.Message, "filldgv sub")

        End Try


    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvFSTOF.EndEdit()
            Me.fsTOFDA.Update(Me.fsTOFDS.Tables("FlatsheetTOF"))

            ' Refresh DataSet from the DataBase
            fillDGV()

            ' Declare 'station' number variable
            Dim sign As String = Me.dgvFSTOF.CurrentRow.Cells.Item(2).Value.ToString

            ' Expand this to include more details about updated record
            Me.ToolStripStatusLabel1.Text = sign & " Updated"


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbFSTOFFields.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field

                Case 0 ' station
                    fieldName = "station"

                Case 1 ' type
                    fieldName = "type"

                Case 2 ' code
                    fieldName = "code"

                Case 3 ' details
                    fieldName = "details"

                Case 4 ' width
                    fieldName = "width"

                Case 5 ' height
                    fieldName = "height"

                Case 6 ' support
                    fieldName = "support"

                Case 7 ' sheeting
                    fieldName = "sheeting"

            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload

                Select Case fieldName

                    '  Sorting has to be formatted differently for integers.
                    '  This separates 'width' and 'height', which are numbers,
                    '  and need to be formatted for .Rowfilter method

                    Case Is = "width"  ' integer
                        Dim str2 As Double = CDbl(searchSTR)

                        Me.fsTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.fsTOFDV.Count & " Records)"


                    Case Is = "height"  ' integer

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.fsTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.fsTOFDV.Count & " Records)"

                    Case Else ' string

                        Me.fsTOFDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                        Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  Filter On:  [" & fieldName & "]   Search:  """ & searchSTR & """     (" & Me.fsTOFDV.Count & " Records)"

                End Select

            End If



        Catch ex As Exception

            'MessageBox.Show(ex.Message, "exception from sortLike sub")
            Me.fsTOFDV.RowFilter = Nothing

            Me.ToolStripStatusLabel1.Text = "FlatSheet T/O >>  (" & Me.fsTOFDV.Count & " Records)"
            Me.txtCriteria.Clear()

        End Try

    End Sub

    Private Sub getJobDesc()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT jobDesc FROM mhsJobs WHERE mhsJob = '" & Me.mhsJN & "'", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        jobDescDA = New OleDbDataAdapter(cmd)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        jobDescDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        jobDescDA.Fill(jobDescDS, "mhsJobs")

        ' Set the Dataview object to the Dataset object
        'jobDescDV = New DataView(jobDescDS.Tables("mhsJobs"))

        ' Declare object
        Dim row As DataRow

        'Iterate through DataSet
        For Each row In jobDescDS.Tables("mhsJobs").Rows

            'Me.jobDescription = CStr(row.Item(0))
            Me.jobDescription = row.Item(0).ToString

            'Me.Text = Me.Text & " (" & Me.jobDescription & ")"
            Me.Text = Me.Text & "  >> " & Me.mhsJN & " (" & Me.jobDescription & ")"

        Next



    End Sub

    Private Sub ViewSign(ByVal sType As Integer, ByVal sID As Integer)


        Dim FsSignViewer As New frmViewSign(sType, sID)

        ' Associate an event handler with an event.
        AddHandler FsSignViewer.SignViewerClosed, AddressOf fillDGV

        ' Set parent to MDI container
        FsSignViewer.MdiParent = signINMain1

        ' Show the form
        FsSignViewer.Show()



    End Sub



    'Sub TestEvents()
    '    Dim Obj As New Class1
    '    ' Associate an event handler with an event.
    '    AddHandler Obj.Ev_Event, AddressOf EventHandler
    '    ' Call the method to raise the event.
    '    Obj.CauseSomeEvent()
    '    ' Stop handling events.
    '    RemoveHandler Obj.Ev_Event, AddressOf EventHandler
    '    ' This event will not be handled.
    '    Obj.CauseSomeEvent()
    'End Sub

    'Sub EventHandler()
    '    ' Handle the event.
    '    MsgBox("EventHandler caught event.")
    'End Sub

    'Public Class Class1
    '    ' Declare an event.
    '    Public Event Ev_Event()
    '    Sub CauseSomeEvent()
    '        ' Raise an event.
    '        RaiseEvent Ev_Event()
    '    End Sub
    'End Class




#End Region













End Class