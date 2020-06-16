Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources



Public Class frmMhsJobListViewAll


#Region " DB communication"

	Dim conn As New OleDbConnection(My.Settings.SignINconn)

    Dim jobDA As New OleDbDataAdapter("SELECT * FROM mhsJobs ORDER By mhsJob DESC", conn)
    Dim jobCB As New OleDbCommandBuilder(jobDA)

    Dim jobDS As New DataSet
    Dim jobDV As New DataView

#End Region


#Region " Event Handlers"

    Private Sub mhsJobListViewAll_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case jobDS.HasChanges

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
                        updateDB()

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

    Private Sub mhsJobListViewAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillDataSetAndView()
        Me.cmbJobsFields.SelectedIndex = 0
        Me.txtCriteria.Focus()

        Me.txtCriteria.Select()
        Me.dgvMHSJobs.ClearSelection()

    End Sub

    Private Sub dgvMHSJobs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvMHSJobs.UserDeletingRow

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

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click

        updateDB()

    End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged

        sortLike(Me.txtCriteria.Text)

    End Sub


#End Region


#Region " Subs & Functions"

    Private Sub fillDGV()

        Try

            ' Set Align-MiddleCenter object
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke


            With Me.dgvMHSJobs

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' Change column names and styles using the column index
                '.Columns(0).HeaderText = "ID"
                '.Columns(0).Width = 5
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "MHS #"
                .Columns(1).Width = 65
                .Columns(1).DefaultCellStyle.ForeColor = Color.Black
                .Columns(1).DefaultCellStyle.Font = New Font(dgvMHSJobs.Font, FontStyle.Bold)

                .Columns(2).HeaderText = "Cust #"
                .Columns(2).Width = 55
                .Columns(2).HeaderCell.Style = objAlignMidcellStyle

                .Columns(3).HeaderText = "Cust"
                .Columns(3).Width = 45
                .Columns(3).HeaderCell.Style = objAlignMidcellStyle

                .Columns(4).HeaderText = "PO"
                .Columns(4).Width = 45
                .Columns(4).HeaderCell.Style = objAlignMidcellStyle

                .Columns(5).HeaderText = "Description/Location"
                .Columns(5).Width = 245
                .Columns(5).HeaderCell.Style = objAlignMidcellStyle

                .Columns(6).HeaderText = "Project"
                .Columns(6).Width = 75
                .Columns(6).HeaderCell.Style = objAlignMidcellStyle


                .Columns(7).HeaderText = "State #"
                .Columns(7).Width = 65
                .Columns(7).HeaderCell.Style = objAlignMidcellStyle

                .Columns(8).HeaderText = "I"
                .Columns(8).Width = 25
                .Columns(8).HeaderCell.Style = objAlignMidcellStyle

                .Columns(9).HeaderText = "II"
                .Columns(9).Width = 25
                .Columns(9).HeaderCell.Style = objAlignMidcellStyle


                .Columns(10).HeaderText = "III"
                .Columns(10).Width = 25
                .Columns(10).HeaderCell.Style = objAlignMidcellStyle

                .Columns(11).HeaderText = "IV"
                .Columns(11).Width = 25
                .Columns(11).HeaderCell.Style = objAlignMidcellStyle


                .Columns(12).HeaderText = "Completion"
                .Columns(12).Width = 75
                .Columns(12).DefaultCellStyle = objAlignRightcellStyle

                ' Hide entryDate field
                .Columns(13).Visible = False
                '.Columns(13).HeaderText = "Entry Date"
                '.Columns(13).ReadOnly = True
                '.Columns(13).Width = 110
                '.Columns(13).HeaderCell.Style = objAlignMidcellStyle

                .Columns(14).HeaderText = "Active"
                .Columns(14).Width = 45
                .Columns(14).HeaderCell.Style = objAlignMidcellStyle

                .Columns(15).HeaderText = "3MDisc"
                .Columns(15).Width = 45
                .Columns(15).HeaderCell.Style = objAlignMidcellStyle



            End With

        Catch ex As Exception
            MessageBox.Show("Try/Catch exception from the fillDGV sub.", "I do not compute!", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Information, _
                MessageBoxDefaultButton.Button1)

            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub updateDB()

        Try
            '  Write changes back to actual .mdb file
            Me.Validate()
            Me.dgvMHSJobs.EndEdit()
            Me.jobDA.Update(Me.jobDS.Tables("mhsJobs"))

            Me.ToolStripStatusLabel1.Text = "Updated"

        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "updateDB sub")

        End Try


    End Sub

    Public Sub FillDataSetAndView()

        ' Initialize a new instance of the DataSet object
        jobDS = New DataSet()

        ' Fill the DataSet object with Data
        jobDA.Fill(jobDS, "mhsJobs")

        ' Set the DataView object to the DataSet object
        jobDV = New DataView(jobDS.Tables("mhsJobs"))

        ' Set the DGV datasource to the DataView object
        Me.dgvMHSJobs.DataSource = jobDV

        ' This sub previously handled filling the DataSet
        ' and formatting the DGV.  Now they are two 
        ' different subs.  This calls the formatting
        ' portion of the code
        fillDGV()

    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbJobsFields.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field
                Case 0 ' mhsJob
                    fieldName = "mhsJob"

                Case 1 ' custJob
                    fieldName = "custJob"

                Case 2 ' cust
                    fieldName = "cust"

                Case 3 ' custPO
                    fieldName = "custPO"

                Case 4 ' jobDesc
                    fieldName = "jobDesc"

                Case 5 ' projNum
                    fieldName = "projNum"

                Case 6 ' stateNum
                    fieldName = "stateNum"

            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload
                Me.jobDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                Me.ToolStripStatusLabel1.Text = "Filter On:  [" & fieldName & "] Search:  " & searchSTR

            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message, "exception from sortLike sub")

        End Try

    End Sub


    '  This sub not working 11.03.09
    Private Sub testingUsing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMHSJobs.CellDoubleClick


        'Dim jn As String = Me.dgvMHSJobs.CurrentRow.Cells(1).Value.ToString

        ''Dim sqlSTR As String = "SELECT SUM(unitQty) FROM tblShipperItems WHERE mhsJob = '" & jn & "' "

        'Try
		'    Using connection As New OleDbConnection(My.Settings.SignINconn)
        '        Using command As New OleDbCommand("SELECT SUM(unitQty) FROM tblShipperItems WHERE mhsJob = '" & jn & "' ", connection)
        '            connection.Open()

        '            Dim totalQuantity As Double = CDbl(command.ExecuteScalar())

        '            Me.TextBox1.Text = totalQuantity.ToString

        '            'Use totalQuantity here.
        '        End Using
        '    End Using
        'Catch ex As OleDbException
        '    For Each er As OleDbError In ex.Errors
        '        MessageBox.Show(er.Message)
        '    Next
        'End Try


    End Sub

#End Region









End Class