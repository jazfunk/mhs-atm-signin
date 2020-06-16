Option Strict On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources




Public Class frmItems



#Region " Database Communication"



    ' (db1.mdb) connection
	'Dim objConn As New OleDbConnection(connStr01)
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)

    '  Items
    Dim itemsDA As OleDbDataAdapter
    Dim itemsDS As DataSet
    Dim itemsDV As DataView
    Dim itemsDT As DataTable

    ' groupTypes
    Dim groupsDA As OleDbDataAdapter
    Dim groupsDS As DataSet
    Dim groupsDV As DataView
    Dim groupsDT As DataTable



#End Region

#Region " Class Variables"


#End Region



#Region " Event Handlers"

    Private Sub frmItems_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case itemsDS.HasChanges

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


    Private Sub frmItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillDGV()
        fillGroupTypes()



    End Sub

    Private Sub dgvItems_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvItems.UserDeletingRow
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
        updateDb()

    End Sub

#End Region

#Region " Subs and Functions"

    Private Sub fillDGV()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblItems ORDER BY groupID, item", objConn)


        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        itemsDA = New OleDbDataAdapter(cmd)


        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim itemsBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(itemsDA)

        ' Instantiate DataSet object
        itemsDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        itemsDA.Fill(itemsDS, "tblItems")

        ' Set the Dataview object to the Dataset object
        itemsDV = New DataView(itemsDS.Tables("tblItems"))


        '  Close the connection
        objConn.Close()

        '  Assign shipper table to the dataGridView object in the designer
        Me.dgvItems.DataSource = itemsDS.Tables("tblItems")


        ' Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        Me.dgvItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        ' Declare and set the header alignment property
        Dim objAlignMidcellStyle As New DataGridViewCellStyle()
        objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim objBoldFont As New DataGridViewCellStyle()


        '  Disable editing of ID field
        Me.dgvItems.Columns(0).ReadOnly = True
        Me.dgvItems.Columns(0).Width = 45

        '  Item field
        Me.dgvItems.Columns(1).Width = 308


        '  payItem field
        Me.dgvItems.Columns(2).HeaderText = "Pay Item"
        Me.dgvItems.Columns(2).Width = 75
        Me.dgvItems.Columns(2).DefaultCellStyle = objAlignMidcellStyle
        Me.dgvItems.Columns(2).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvItems.Columns(2).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Bold)


        '  groupID field
        Me.dgvItems.Columns(3).Width = 45
        Me.dgvItems.Columns(3).HeaderText = "Group"
        Me.dgvItems.Columns(3).DefaultCellStyle = objAlignMidcellStyle



    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvItems.EndEdit()
            Me.itemsDA.Update(Me.itemsDS.Tables("tblItems"))

            Me.ToolStripStatusLabel1.Text = "Items Updated"



        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        fillDGV()


    End Sub

    Private Sub fillGroupTypes()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblGroupTypes ORDER BY ID", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        groupsDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim groupsBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(groupsDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        groupsDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        groupsDA.Fill(groupsDS, "tblGroupTypes")

        ' Declare object
        Dim row As DataRow

        'Iterate through DataSet
        For Each row In groupsDS.Tables("tblGroupTypes").Rows

            lstGroups.Items.Add(String.Format("{0} {1}", CInt(row.Item(0)), " - " & row.Item(1).ToString))

        Next


    End Sub

#End Region







End Class
