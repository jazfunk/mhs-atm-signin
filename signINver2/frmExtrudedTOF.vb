Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources


Public Class frmExtrudedTOF

    Public Sub New(ByVal jn As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.mhsJN = jn

    End Sub


#Region " Class-level variables"

    Dim mhsJN As String
    Dim jobDescription As String


#End Region


#Region " Database Communication"

	'Dim conn As New OleDbConnection(connStr01)
	Dim conn As New OleDbConnection(My.Settings.SignINconn)


    Dim extTOFDA As New OleDbDataAdapter

    Dim extTOFDS As New DataSet
    Dim extTOFDT As DataTable
    Dim extTOFDV As New DataView

    Dim jobDescDA As New OleDbDataAdapter
    Dim jobDescDS As New DataSet
    Dim jobDescDV As New DataView

#End Region


#Region " Event Handlers"

    Private Sub frmExtrudedTOF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case extTOFDS.HasChanges

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

    Private Sub frmExtrudedTOF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillDGV()
        getJobDesc()

        Me.cmbEXTTOFFields.SelectedIndex = 0
        Me.txtCriteria.Select()

    End Sub

    Private Sub txtCriteria_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriteria.GotFocus

        Me.txtCriteria.Select(0, Me.txtCriteria.Text.Length)


    End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
        sortLike(Me.txtCriteria.Text)

    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)  _ 
                                    Handles btnSaveChanges.Click
        updateDb()

    End Sub

    Private Sub dgvEXTTOF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEXTTOF.DoubleClick


        Try

            Dim signTOFID As Integer = CType(Me.dgvEXTTOF.CurrentRow.Cells.Item(0).Value, Integer)

            ViewSign(1, signTOFID)


        Catch ex As Exception

        End Try



    End Sub

    Private Sub dgvEXTTOF_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvEXTTOF.UserDeletingRow
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


#Region " Subs and Functions"

    Private Sub fillDGV()

        Try


            Dim i As Integer = 0
            If extTOFDS.Tables.Count > 0 Then
                i = CType(dgvEXTTOF.CurrentRow.Cells.Item(0).Value, Integer)
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
                                                       "FROM ExtrudedTOF WHERE mhsJob = '" & Me.mhsJN & "' ORDER By station", conn)

            ' Open connection to Db
            conn.Open()

            '  Fill dataAdapter with query result from Db
            extTOFDA = New OleDbDataAdapter(cmd)

            conn.Close()

            ' Initialize a new instance of the DataSet object
            extTOFDS = New DataSet()

			' Fill the DataSet object with Data, check for data
			Dim recCount As Integer = extTOFDA.Fill(extTOFDS, "ExtrudedTOF")
			If recCount <= 0 Then
				MessageBox.Show("No records found")
				Exit Sub
			End If


            Dim extTOFCB As New OleDbCommandBuilder(extTOFDA)

            ' DataTable -   Fill the DataTable object with data
            extTOFDT = extTOFDS.Tables("ExtrudedTOF")

            ' Set the DataView object to the DataSet object
            extTOFDV = New DataView(extTOFDS.Tables("ExtrudedTOF"))


            ' Set Align-MiddleCenter object
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke


            With Me.dgvEXTTOF

                .DataSource = extTOFDV

                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' ID field
                .Columns(0).Visible = False

                ' mhsJob field
                .Columns(1).HeaderText = "MHS #"
                .Columns(1).Width = 60
                .Columns(1).DefaultCellStyle.ForeColor = Color.Black
                .Columns(1).DefaultCellStyle.Font = New Font(dgvEXTTOF.Font, FontStyle.Bold)

                ' dir field
                .Columns(2).HeaderText = "Dir"
                .Columns(2).Width = 50
                .Columns(2).DefaultCellStyle = objAlignMidcellStyle

                ' station field
                .Columns(3).HeaderText = "Station"
                .Columns(3).Width = 65

                ' parentSign field
                .Columns(4).HeaderText = "Parent"
                .Columns(4).Width = 55

                ' b2b field
                .Columns(5).HeaderText = "B2B"
                .Columns(5).Width = 55

                ' type field
                .Columns(6).HeaderText = "Type"
                .Columns(6).Width = 35
                .Columns(6).DefaultCellStyle = objAlignMidcellStyle

                ' code field
                .Columns(7).HeaderText = "Sign code"
                .Columns(7).Width = 100

                ' details field
                .Columns(8).HeaderText = "Sign Details"
                .Columns(8).Width = 125

                ' width field
                .Columns(9).HeaderText = "Width"
                .Columns(9).Width = 45
                .Columns(9).DefaultCellStyle = objAlignRightcellStyle

                ' height field
                .Columns(10).HeaderText = "Height"
                .Columns(10).Width = 45
                .Columns(10).DefaultCellStyle = objAlignRightcellStyle

                ' sqrFeet field
                .Columns(11).HeaderText = "SqFt"
                .Columns(11).Width = 45
                .Columns(11).DefaultCellStyle = objAlignRightcellStyle
                '.Columns(11).DefaultCellStyle.Font = New Font(dgvEXTTOF.Font, FontStyle.Bold)

                ' sptQty field
                .Columns(12).HeaderText = "S-Qty"
                .Columns(12).Width = 35
                .Columns(12).DefaultCellStyle = objAlignRightcellStyle

                ' support field
                .Columns(13).HeaderText = "Support"
                .Columns(13).Width = 100

                ' retain field
                .Columns(14).HeaderText = "Retain"
                .Columns(14).Width = 45

                ' sheeting field
                .Columns(15).HeaderText = "Sheeting"
                .Columns(15).Width = 55

                ' twelveInch field
                .Columns(16).HeaderText = "12"""
                .Columns(16).Width = 35
                .Columns(16).DefaultCellStyle = objAlignRightcellStyle

                ' sixInch field
                .Columns(17).HeaderText = "6"""
                .Columns(17).Width = 35
                .Columns(17).DefaultCellStyle = objAlignRightcellStyle

                ' eightWF field
                .Columns(18).HeaderText = "8WF"
                .Columns(18).Width = 65

                ' sixWF field
                .Columns(19).HeaderText = "6WF"
                .Columns(19).Width = 65

                ' fiveWF field
                .Columns(20).HeaderText = "5WF"
                .Columns(20).Width = 65

                ' threeByFour field
                .Columns(21).HeaderText = "3x4"
                .Columns(21).Width = 65

                ' twoByTwo field
                .Columns(22).HeaderText = "2x2"
                .Columns(22).Width = 65

                ' hdwQty field
                .Columns(23).HeaderText = "H-Qty"
                .Columns(23).Width = 35
                .Columns(23).DefaultCellStyle = objAlignRightcellStyle
                '.Columns("hdwQty").DefaultCellStyle.Font = New Font(dgvEXTTOF.Font, FontStyle.Bold)

                ' hardware field
                .Columns(24).HeaderText = "Hardware"
                .Columns(24).Width = 100

                ' entryDate field
                .Columns(25).HeaderText = "Entry Date"
                .Columns(25).Width = 75
                .Columns(25).ReadOnly = True
                .Columns(25).DefaultCellStyle = objAlignRightcellStyle

                Me.ToolStripStatusLabel1.Text = "Extruded T/O  (" & Me.extTOFDV.Count & " Records)"


            End With

            If i > 0 Then
                For Each row As DataGridViewRow In dgvEXTTOF.Rows

                    If CType(row.Cells.Item(0).Value, Integer) = i Then
                        row.Selected = True
                    Else
                        row.Selected = False
                    End If

                Next
            End If

            

            'If i > 0 Then
            '    Try

            '        'Me.dgvEXTTOF.Rows(i).Selected = True

            '    Catch ex As Exception

            '    End Try

            'End If

        Catch ex As Exception
            'MessageBox.Show("Try/Catch exception from the fillDGV sub.", "I do not compute!", _
            '    MessageBoxButtons.OK, _
            '    MessageBoxIcon.Information, _
            '    MessageBoxDefaultButton.Button1)

            MessageBox.Show(ex.Message, "filldgv sub")
        End Try

    End Sub

    Public Sub FillDataSetAndView()

        ''  connection to database
        'Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM ExtrudedTOF WHERE mhsJob = '" & Me.mhsJN & "' ORDER By station", conn)

        '' Open connection to Db
        'conn.Open()

        ''  Fill dataAdapter with query result from Db
        'extTOFDA = New OleDbDataAdapter(cmd)

        'conn.Close()

        '' Initialize a new instance of the DataSet object
        'extTOFDS = New DataSet()

        '' Fill the DataSet object with Data
        'extTOFDA.Fill(extTOFDS, "ExtrudedTOF")



        '' Set the DataView object to the DataSet object
        'extTOFDV = New DataView(extTOFDS.Tables("ExtrudedTOF"))

        '' Set the DGV datasource to the DataView object
        'Me.dgvEXTTOF.DataSource = extTOFDV

        '' This sub previously handled filling the DataSet
        '' and formatting the DGV.  Now they are two 
        '' different subs.  This calls the formatting
        '' portion of the code
        'fillDGV()

    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbEXTTOFFields.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field

                Case 0 ' station
                    fieldName = "station"

                Case 1 ' parent
                    fieldName = "parentSign"

                Case 2 ' B2B
                    fieldName = "B2B"

                Case 3 ' type
                    fieldName = "type"

                Case 4 ' code
                    fieldName = "code"

                Case 5 ' details
                    fieldName = "details"

                Case 6 ' width
                    fieldName = "width"

                Case 7 ' height
                    fieldName = "height"

                Case 8 ' sqrFeet
                    fieldName = "sqrFeet"

                Case 9 ' support
                    fieldName = "support"

                Case 10 ' sheeting
                    fieldName = "sheeting"

                Case 11 ' direction
                    fieldName = "dir"

            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload

                Select Case fieldName

                    Case Is = "width"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.extTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  Filter On:  [" & fieldName & "] Search:  """ & searchSTR & """     (" & Me.extTOFDV.Count & " Records)"

                    Case Is = "height"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.extTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.extTOFDV.Count & " Records)"

                    Case Is = "sqrFeet"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.extTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.extTOFDV.Count & " Records)"


                    Case Else

                        Me.extTOFDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                        Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.extTOFDV.Count & " Records)"

                End Select

            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message, "exception from sortLike sub")
            Me.extTOFDV.RowFilter = Nothing

            Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  (" & Me.extTOFDV.Count & " Records)"
            Me.txtCriteria.Clear()

        End Try

    End Sub

    Private Sub getJobDesc()

        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT jobDesc FROM mhsJobs WHERE mhsJob = '" & Me.mhsJN & "'", conn)

            ' Open connection to Db
            conn.Open()

            '  Fill dataAdapter with query result from Db
            jobDescDA = New OleDbDataAdapter(cmd)

            '  Close the connection
            conn.Close()

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

                ' Me.jobDescription = CStr(row.Item(0))
                Me.jobDescription = row.Item(0).ToString

                Me.Text = Me.Text & "  >> " & Me.mhsJN & " (" & Me.jobDescription & ")"
                'Me.Text = Me.mhsJN & ":  " & Me.Text

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try



    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvEXTTOF.EndEdit()
            Me.extTOFDA.Update(Me.extTOFDS.Tables("ExtrudedTOF"))

            Me.ToolStripStatusLabel1.Text = "Station Updated"


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub ViewSign(ByVal sType As Integer, ByVal sID As Integer)


        Dim ExtSignViewer As New frmViewSign(sType, sID)

        ' Associate an event handler with an event.
        AddHandler ExtSignViewer.SignViewerClosed, AddressOf fillDGV

        ' Set parent to MDI container
        ExtSignViewer.MdiParent = signINMain1

        ' Show the form
        ExtSignViewer.Show()


    End Sub



#End Region










End Class