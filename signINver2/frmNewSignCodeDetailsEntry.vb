
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports signINver2.My.Resources
Imports System.Speech.Synthesis
Imports System.Collections.ObjectModel



Public Class frmNewSignCodeDetailsEntry



    '  (Action Traffic.mdb) connection
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

    '  (db1.mdb) connection
	Dim db1Conn As New OleDbConnection(My.Settings.SignINconn)

    Dim sCodeDA As OleDbDataAdapter
    Dim sCodeDS As DataSet
    Dim sCodeDV As DataView
    Dim sCodeDT As DataTable

    Private addOrClear As Boolean = False



    Private Sub getSignCodes()

        Try

            Dim sCodeCmd As OleDbCommand = New OleDbCommand _
                            ("SELECT codeID, " & _
                             "code, " & _
                             "description, " & _
                             "pdfTitle, " & _
                             "type " & _
                             "FROM tblSignCodes ORDER By code", db1Conn)

            ' Open connection to Db
            db1Conn.Open()

            '  Fill dataAdapter with query result from Db
            sCodeDA = New OleDbDataAdapter(sCodeCmd)

            ' Instantiate DataSet object
            sCodeDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            sCodeDA.Fill(sCodeDS, "tblSignCodes")

            ' Auto DataAdapter update methods
            Dim sCodeCB As New OleDbCommandBuilder(sCodeDA)

            '  Close the connection
            db1Conn.Close()

            ' DataTable -   Fill the DataTable object with data
            sCodeDT = sCodeDS.Tables("tblSignCodes")

            '' Set the Dataview object to the Dataset object
            'sCodeDV = New DataView(sCodeDS.Tables("tblSignCodes"))

            ' Bind Combo Box
            With Me.cmbSignCodes
                .DataSource = sCodeDT
                .DisplayMember = "code"
                '.Text = "Select"
            End With

            ' Bind DataGridView
            With Me.dgvSignCodes
                .DataSource = sCodeDT
                .Columns("codeID").ReadOnly = True
            End With

            ' Clear previous DataBindings
            Me.txtCodeID.DataBindings.Clear()
            Me.txtDescription.DataBindings.Clear()
            Me.txtPdfTitle.DataBindings.Clear()
            Me.txtType.DataBindings.Clear()

            ' Add DataBindings
            Me.txtCodeID.DataBindings.Add("Text", sCodeDT, "codeID")
            Me.txtDescription.DataBindings.Add("Text", sCodeDT, "description")
            Me.txtPdfTitle.DataBindings.Add("Text", sCodeDT, "pdfTitle")
            Me.txtType.DataBindings.Add("Text", sCodeDT, "type")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "getSignCodes()")
        End Try




    End Sub

    Private Sub updateDb()

        Me.Cursor = Cursors.WaitCursor

        ' Get selected items' index to re-select after successful add
        Dim x As Integer = CInt(Me.dgvSignCodes.CurrentRow.Cells.Item(0).Value)

        Try

            Me.btnForward_Click(Nothing, Nothing)

            '  Write changes back to actual .mdb file
            Me.Validate()
            Me.dgvSignCodes.EndEdit()
            Me.sCodeDA.Update(Me.sCodeDS.Tables("tblSignCodes"))
            Me.ToolStripStatusLabel1.Text = "Record(s) Updated"

            ' Refresh DataSet
            getSignCodes()

            ' Disable fields
            DisableFields()

            ' Select updated Sign Code
            For Each row As DataGridViewRow In dgvSignCodes.Rows

                ' De-Select all other rows
                row.Selected = False

                ' Find origniating row and select
                If CInt(row.Cells.Item(0).Value) = x Then
                    row.Selected = True
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub addSignCode()

        'Dim added As Boolean = False

        Dim scAddCMD As OleDbCommand = New OleDbCommand

        ' Open the connection, execute the command
        db1Conn.Open()

        ' Set the OleDbCommand object properties
        scAddCMD.Connection = db1Conn
        scAddCMD.CommandText = _
            "INSERT INTO tblSignCodes (code, description, pdfTitle, type) " & _
            "VALUES(@code,@description,@pdfTitle,@type)"

        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property
        scAddCMD.Parameters.AddWithValue("@code", Me.cmbSignCodes.Text)
        scAddCMD.Parameters.AddWithValue("@description", Me.txtDescription.Text)
        scAddCMD.Parameters.AddWithValue("@pdfTitle", Me.txtPdfTitle.Text)
        scAddCMD.Parameters.AddWithValue("@type", Me.txtType.Text)
        

        ' Execute the OleDbCommand object to insert the new data
        Try
            scAddCMD.ExecuteNonQuery()

            ' Display a message that the record was added
            ToolStripStatusLabel1.Text = "(sign code here) Added successfully"

        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message)

            ToolStripStatusLabel1.Text = "Record not added!"


        End Try

        ' Close the connection
        db1Conn.Close()

    End Sub

    Private Sub showSignImage()

        Dim imageName As String = Me.cmbSignCodes.Text
        Dim viewImage As String = imageName & ".jpg"

        Try
            Me.picSignImage.Load(My.Resources.imgPath & viewImage)
        Catch ex As Exception
            Me.picSignImage.Image = My.Resources.none1
        End Try

    End Sub

    Private Sub addOrClearFields(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles btnAddNew.Click

        ' Clearing Fields:  addOrClear = False
        ' Adding New Record:  addOrClear = true

        Me.Cursor = Cursors.WaitCursor

        Try

            Select Case addOrClear

                Case True


                    ' Code for adding record to Db goes here
                    addSignCode()

                    ' Disable fields
                    DisableFields()

                    ' Reset adding or clearing logic variable
                    addOrClear = False

                    ' Refresh DataSet
                    getSignCodes()


                    ' Get ID of newly added record so that
                    ' When the DataSet gets refreshed, the 
                    ' Last record added can be selected


                    ' Reset Button text
                    Me.btnAddNew.Text = "New"


                Case False

                    ' Clear appropriate fields
                    Me.cmbSignCodes.Text = String.Empty
                    Me.txtCodeID.Clear()
                    Me.txtDescription.Clear()
                    Me.txtPdfTitle.Clear()
                    Me.txtType.Clear()
                    Me.picSignImage.Image = Nothing

                    ' Call EnableFields() Method
                    EnableFields(Nothing, Nothing)

                    ' Reset Button text
                    Me.btnAddNew.Text = "Add"

                    ' Reset adding or clearing logic variable
                    addOrClear = True

                    ' Display notification in status strip label
                    Me.ToolStripStatusLabel1.Text = "Fields ready for New Sign Code entry."


            End Select


        Catch ex As Exception

            MessageBox.Show(ex.Message, "addOrClearFields()")
            Me.ToolStripStatusLabel1.Text = "(Sign Code Here) Not Added!"

        End Try


        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub EnableFields(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Me.txtDescription.ReadOnly = False
        Me.txtPdfTitle.ReadOnly = False
        Me.txtType.ReadOnly = False

        If Me.cmbSignCodes.Text = String.Empty Then
            Me.btnSave.Enabled = False
        Else
            Me.btnSave.Enabled = True
        End If
        
    End Sub

    Private Sub DisableFields()

        Me.txtDescription.ReadOnly = True
        Me.txtPdfTitle.ReadOnly = True
        Me.txtType.ReadOnly = True
        Me.btnSave.Enabled = True

    End Sub






    Private Sub frmNewSignCodeDetailsEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        getSignCodes()
        Me.picPDFSheet.Visible = False

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        updateDb()


    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            If Me.cmbSignCodes.SelectedIndex >= 0 Then
                Me.cmbSignCodes.SelectedIndex -= 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnBack_click()")

        End Try
    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click
        Try
            Dim x As Integer = Me.cmbSignCodes.SelectedIndex
            Dim y As Integer = Me.cmbSignCodes.Items.Count - 1

            If x < y Then
                Me.cmbSignCodes.SelectedIndex += 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnForward_click()")

        End Try

    End Sub

    Private Sub picSignImage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picSignImage.DoubleClick
		'Try
		'    Me.Cursor = Cursors.WaitCursor

		'    Dim specSheet As New frmViewPDF(Me.txtPdfTitle.Text, Me.cmbSignCodes.Text, Me.txtDescription.Text)
		'    specSheet.MdiParent = signINver2.signINMain1
		'    specSheet.Show()

		'Catch ex As Exception

		'End Try

		'Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPDFSheet.Click

		'picSignImage_DoubleClick(Nothing, Nothing)

    End Sub

    Private Sub cmbSignCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignCodes.SelectedIndexChanged
        showSignImage()

    End Sub

    Private Sub frmNewSignCodeDetailsEntry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case sCodeDS.HasChanges

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

    Private Sub txtPdfTitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPdfTitle.TextChanged

        Select Case Me.txtPdfTitle.Text

            Case String.Empty
                Me.picPDFSheet.Visible = False
            Case Else
                Me.picPDFSheet.Visible = True

        End Select

    End Sub
End Class