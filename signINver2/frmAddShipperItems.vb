Option Strict On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources



Public Class frmAddShipperItems


    Public Sub New(ByVal shipperID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.shipper = CInt(shipperID)

        Me.Text = "#" & shipperID

        Me.lblShipperID.Text = CStr(Me.shipper)

        getViaText(Me.shipper)

    End Sub


#Region " Class-level variables"

	Dim shipperNum As Integer
	Dim mhsJob As String
	Dim payItemID As Integer
	Dim mhsJobTrunc As String

	Dim shipperASS As Boolean

#End Region

#Region " Database comunication"

    '  (db1.mdb) connection
	'Dim objConn As New OleDbConnection(connStr01)
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)

    Dim shipperDA As OleDbDataAdapter
    Dim shipperDS As DataSet
    Dim shipperDV As DataView
    Dim shipperDT As DataTable

    Dim groupDA As OleDbDataAdapter
    Dim groupDS As DataSet
    Dim groupDV As DataView
    Dim groupDT As DataTable

    Dim itemDA As OleDbDataAdapter
    Dim itemDS As DataSet
    Dim itemDV As DataView
    Dim itemDT As DataTable

    Dim itemListDA As OleDbDataAdapter
    Dim itemListDS As DataSet
    Dim itemListDV As DataView
    Dim itemListDT As DataTable

    Dim poDA As OleDbDataAdapter
    Dim poDS As DataSet
    Dim poDV As DataView
    Dim poDT As DataTable

    Dim payItemDA As OleDbDataAdapter
    Dim payItemDS As DataSet
    Dim payItemDV As DataView
    Dim payItemDT As DataTable

    Dim iViewDA As OleDbDataAdapter
    Dim iViewDS As DataSet
    Dim iViewDV As DataView
    Dim iViewDT As DataTable

    Dim iDescDA As OleDbDataAdapter
    Dim iDescDS As DataSet
    Dim iDescDV As DataView
    Dim iDescDT As DataTable

    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
    Dim mhsJobDV As DataView
    Dim mhsJobDT As DataTable

    Dim assDA As OleDbDataAdapter
    Dim assDS As DataSet
    Dim assDV As DataView
    Dim assDT As DataTable


    '  MHS DB connection
	Dim objMHSConn As New OleDbConnection(My.Settings.MHSconn)

    Dim mhsDA As OleDbDataAdapter
    Dim mhsDS As DataSet
    Dim mhsDV As DataView
    Dim mhsDT As DataTable



#End Region

#Region " Properties"

    Public Property shipper() As Integer
        Get
            Return shipperNum
        End Get
        Set(ByVal value As Integer)
            shipperNum = value
        End Set
    End Property

    Public Property mhsJobNum() As String
        Get
            Return mhsJob
        End Get
        Set(ByVal value As String)
            mhsJob = value
        End Set
    End Property

    Public Property parsedMHSJN() As String
        Get
            Return mhsJobTrunc
        End Get
        Set(ByVal value As String)
            mhsJobTrunc = value
        End Set
    End Property


#End Region

#Region " Event Handlers"

    Private Sub frmAddShipperItems_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case shipperDS.HasChanges

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

    Private Sub frmAddShipperItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillDGV()
        fillGroupTypes()
        fillItemsDGV(0)


        getMHSJobNumber()
        Me.mhsJob = Me.lblMhsJob.Text


        '  Prepare job Number for external DB query to pull Unit Price from MHS Database
        Me.mhsJobTrunc = CStr(parseJobNum(Me.mhsJob))


        getPO(Me.mhsJob)

        Me.btnSave.Visible = False

        shipperASS = CBool(isShipperAssigned(Me.shipper))
        Me.CheckBox1.Visible = False

        If shipperASS = False Then
            MessageBox.Show("Shipper not assigned", "I do not compute!")

            Me.Text = "Shipper # " & Me.shipper & " not assigned."

            Me.grpItemDetails.Enabled = False
            Me.dgvShipperItems.Enabled = False
        End If


    End Sub

    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        addItem()
        fillDGV()
        clearFields()

    End Sub

    Private Sub txtPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPO.Click
        enableFields()
    End Sub

    Private Sub dgvItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellClick
        getPayItemID()

    End Sub

    Private Sub cmbGroupTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroupTypes.SelectedIndexChanged
        Dim i As Integer = Me.cmbGroupTypes.SelectedIndex + 1

        fillItemsDGV(i)

    End Sub

    Private Sub ckbShowAllItems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbShowAllItems.CheckedChanged

        Dim viewAll As Boolean = Me.ckbShowAllItems.Checked

        Select Case viewAll
            Case True

                fillItemsDGV(0)

            Case False

                Dim i As Integer = Me.cmbGroupTypes.SelectedIndex + 1

                fillItemsDGV(i)

        End Select

    End Sub

    Private Sub dgvShipperItems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipperItems.CellDoubleClick

        Try
            openViewer()

            Dim i As Integer = CInt(Me.dgvShipperItems.CurrentRow.Cells.Item(0).Value)

            'Dim viewItemID As Integer = Me.dgvShipperItems.CurrentRow.Index
            openItemInViewer(i)

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub dgvShipperItems_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvShipperItems.UserDeletingRow
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

    Private Sub btnHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHide.Click
        closeViewer()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        updateShipper(Me.shipper, Me.txtPO.Text)

    End Sub

    Private Sub lblPayItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPayItem.TextChanged

        Try
            getUnitPrice(Me.mhsJobTrunc, CInt(Me.lblPayItem.Text))
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "lblPayItem TEXT Changed Event")
        End Try

    End Sub

    Private Sub btnAddItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItems.Click
        Dim itemsList As New frmItems()
        itemsList.MdiParent = signINver2.signINMain1
        itemsList.Show()

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        fillItemsDGV(Me.cmbGroupTypes.SelectedIndex)

        Me.ToolStripStatusLabel1.Text = "Items listing re-loaded."
    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click

        updateDb()


    End Sub

#End Region

#Region " Subs and Functions"

    Private Sub fillDGV()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblShipperItems WHERE shipperID = " & Me.shipper & " ORDER BY itemID", objConn)


        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        shipperDA = New OleDbDataAdapter(cmd)


        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim dgvBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(shipperDA)

        ' Instantiate DataSet object
        shipperDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        shipperDA.Fill(shipperDS, "tblShipperItems")

        ' Set the Dataview object to the Dataset object
        shipperDV = New DataView(shipperDS.Tables("tblShipperItems"))


        '  Close the connection
        objConn.Close()

        '  Assign shipper table to the dataGridView object in the designer
        Me.dgvShipperItems.DataSource = shipperDS.Tables("tblShipperItems")


        ' Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        Me.dgvShipperItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        ' Declare and set the log header alignment property
        Dim objAlignMidcellStyle As New DataGridViewCellStyle()
        objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim objBoldFont As New DataGridViewCellStyle()




        '  Hide itemID field
        Me.dgvShipperItems.Columns(0).Visible = False

        '  Hide shipperID field
        Me.dgvShipperItems.Columns(1).Visible = False

        '  groupID field
        Me.dgvShipperItems.Columns(2).Width = 75
        Me.dgvShipperItems.Columns(2).HeaderText = "Group"
        Me.dgvShipperItems.Columns(2).HeaderCell.Style = objAlignMidcellStyle
        Me.dgvShipperItems.Columns(2).DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvShipperItems.Columns(2).DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Bold)


        'Me.dgvShipperItems.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvShipperItems.Columns(3).Width = 35
        Me.dgvShipperItems.Columns(3).HeaderText = "Qty"


        Me.dgvShipperItems.Columns(4).Width = 35
        Me.dgvShipperItems.Columns(4).HeaderText = "Item"
        'Me.dgvShipperItems.Columns(4).ReadOnly = True


        Me.dgvShipperItems.Columns(5).Width = 70
        Me.dgvShipperItems.Columns(5).HeaderText = "Unit Qty"

        Me.dgvShipperItems.Columns(6).Width = 50
        Me.dgvShipperItems.Columns(6).HeaderCell.Style = objAlignMidcellStyle
        Me.dgvShipperItems.Columns(6).DefaultCellStyle.Format = "c"
        Me.dgvShipperItems.Columns(6).DefaultCellStyle.ForeColor = Color.Green
        Me.dgvShipperItems.Columns(6).HeaderText = "Price"

        Me.dgvShipperItems.Columns(7).Width = 150
        Me.dgvShipperItems.Columns(7).HeaderText = "Item Notes"





    End Sub

    Private Sub fillItemsDGV(ByVal grp As Integer)

        '  Count number of records in group types combo box
        Dim grpCount As Integer = Me.cmbGroupTypes.Items.Count

        ' Fill items list based on group type select
        Select Case grp
            Case 1 To grpCount ' Filter by group type
                Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblItems WHERE groupID = " & grp & " ORDER BY groupID, item ASC", objConn)

                ' Open connection to Db
                objConn.Open()

                '  Fill dataAdapter with query result from Db
                itemListDA = New OleDbDataAdapter(cmd)


            Case Else ' All items - No filter
                Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblItems ORDER BY groupID, item ASC", objConn)

                ' Open connection to Db
                objConn.Open()

                '  Fill dataAdapter with query result from Db
                itemListDA = New OleDbDataAdapter(cmd)

        End Select



        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim itemListBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(itemListDA)

        ' Instantiate DataSet object
        itemListDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        itemListDA.Fill(itemListDS, "tblItems")

        ' Set the Dataview object to the Dataset object
        itemListDV = New DataView(itemListDS.Tables("tblItems"))

        '  Close the connection
        objConn.Close()

        '  Assign shipper table to the dataGridView object in the designer
        Me.dgvItems.DataSource = itemListDS.Tables("tblItems")



        ' Declare and set the alternating rows style
        'Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        'objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        'Me.dgvItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        ' Declare and set the log header alignment property
        'Dim objAlignMidcellStyle As New DataGridViewCellStyle()
        'objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Dim objBoldFont As New DataGridViewCellStyle()


        '  Hide ID field
        Me.dgvItems.Columns(0).Visible = False

        ' Item field
        Me.dgvItems.Columns(1).Width = 212

        '  payItem field
        Me.dgvItems.Columns(2).Visible = False

        ' groupID field
        Me.dgvItems.Columns(3).Visible = False



    End Sub

    Private Sub fillGroupTypes()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT groupID FROM tblGroupTypes ORDER BY ID", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        groupDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim groupBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(groupDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        groupDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        groupDA.Fill(groupDS, "tblGroupTypes")


        With Me.cmbGroupTypes
            .DataSource = groupDS.Tables("tblGroupTypes")
            .DisplayMember = "groupID"
            .Text = "Select"
        End With

    End Sub

    Private Sub addItem()

        Dim thisItemID As Integer = CInt(Me.dgvItems.CurrentRow.Cells.Item(0).Value)


        ' Declare local variables and objects
        Dim cmd As OleDbCommand = New OleDbCommand

        ' Open the connection, execute the command
        objConn.Open()

        ' Set the OleDbCommand object properties
        cmd.Connection = objConn
        cmd.CommandText = _
                    "INSERT INTO tblShipperItems " & _
                        "(shipperID, groupID, itemQty, item, unitQty, unitPrice, itemNotes) " & _
                        "VALUES(@shipperID,@groupID,@itemQty,@item,@unitQty,@unitPrice,@itemNotes)"

        ' Add placeholder parameters 
        cmd.Parameters.AddWithValue("@shipperID", Me.shipper)
        cmd.Parameters.AddWithValue("@groupID", Me.cmbGroupTypes.Text)


        '  Convert empty item qty string to dbnull.value
        If Me.txtItemQty.Text = "" Then
            cmd.Parameters.AddWithValue("@itemQty", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@itemQty", Me.txtItemQty.Text)
        End If


        cmd.Parameters.AddWithValue("@item", thisItemID)



        '  Convert empty unit qty string to dbnull.value
        If Me.txtUnitQty.Text = "" Then
            cmd.Parameters.AddWithValue("@unitQty", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@unitQty", Me.txtUnitQty.Text)
        End If



        '  Convert empty unit price string to dbnull.value
        If Me.txtUnitPrice.Text = "" Then
            cmd.Parameters.AddWithValue("@unitPrice", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@unitPrice", Me.txtUnitPrice.Text)
        End If

        cmd.Parameters.AddWithValue("@itemNotes", Me.txtItemNotes.Text)





        ' Execute the OleDbCommand object to insert the new data
        Try
            cmd.ExecuteNonQuery()

            ' Close the connection
            objConn.Close()

            ' Toggle dgv visibility
            'Me.dgvShipperItems.Visible = toggleDGV()

            ' Display a message that the record was added
            ToolStripStatusLabel1.Text = Me.dgvItems.CurrentRow.Cells.Item(1).Value.ToString & " Added to Shipper #" & Me.shipper

        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "addItem SUB")

            ' Close the connection
            objConn.Close()

        End Try



    End Sub

    '  May not need this sub
    Private Sub getViaText(ByVal i As Integer)

        '  connection to database
        Dim cmdVia As OleDbCommand = New OleDbCommand("SELECT via, poNum FROM tblShippers WHERE shipperID = " & i & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        itemDA = New OleDbDataAdapter(cmdVia)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim viaBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(itemDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        itemDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        itemDA.Fill(itemDS, "tblShippers")

        ' Set the Dataview object to the Dataset object
        itemDV = New DataView(itemDS.Tables("tblShippers"))

        ' Clear databindings
        Me.lblVia.DataBindings.Clear()
        Me.txtPO.DataBindings.Clear()

        ' Add databinding
        Me.lblVia.DataBindings.Add("Text", itemDV, "via")
        Me.txtPO.DataBindings.Add("Text", itemDV, "poNum")

    End Sub

    Private Sub clearFields()


        Me.txtItemNotes.Clear()
        Me.txtItemQty.Clear()
        Me.txtUnitPrice.Clear()
        Me.txtUnitQty.Clear()
        Me.lblPayItem.Text = Nothing

        Me.txtPO.ReadOnly = True


    End Sub

    Private Sub getUnitPrice(ByVal jn As String, ByVal payItem As Integer)

        Try
            '  connection to database
            Dim MHScmd As OleDbCommand = New OleDbCommand("SELECT [Price per unit], [Pay Item] FROM [Month to month quotes archive] WHERE [MHS job number] = '" & jn & "'", objMHSConn)


            '("SELECT [Price per unit], [Pay Item] FROM [Month to month quotes archive] WHERE [MHS job number] = '" & jn & "'", objMHSConn)
            '("SELECT [Price per unit] FROM [Month to month quotes archive] WHERE [MHS job number] = '" & jn & "' AND [Pay item] = " & payItem & "", objMHSConn)


            ' Open connection to Db
            objMHSConn.Open()

            '  Fill dataAdapter with query result from Db
            mhsDA = New OleDbDataAdapter(MHScmd)

            'One CommandBuilder object is required. 
            'It automatically generates DeleteCommand, 
            'UpdateCommand and InsertCommand 
            'for DataAdapter object      
            Dim MHSBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(mhsDA)

            '  Close the connection
            objMHSConn.Close()

            ' Instantiate DataSet object
            mhsDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            mhsDA.Fill(mhsDS, "[Month to month quotes archive]")

            ' Set the Dataview object to the Dataset object
            mhsDV = New DataView(mhsDS.Tables("[Month to month quotes archive]"))
            mhsDV.RowFilter = "[Pay Item] = " & payItem


            ' Clear databindings
            Me.txtUnitPrice.DataBindings.Clear()


            ' Add(databinding)
            Try
                'txtUnitPrice.Text = Format(CType(txtUnitPrice.Text, Decimal), "##0.00")
            Catch ex As Exception
                'txtUnitPrice.Text = 0
                'txtUnitPrice.Text = Format(CType(txtUnitPrice.Text, Decimal), "##0.00")



            End Try

            Me.txtUnitPrice.DataBindings.Add("Text", mhsDV, "Price per unit")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "getUnitPrice SUB")
        End Try




    End Sub

    '  Retrieves PO# and Job Description.  Just didn't want to change the 
    '  name of the sub.  Lazy, I am.
    Private Sub getPO(ByVal jn As String)

        '  connection to database
        Dim cmd2 As OleDbCommand = New OleDbCommand("SELECT custPO, jobDesc FROM mhsJobs WHERE mhsJob = '" & jn & "'", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        poDA = New OleDbDataAdapter(cmd2)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim poBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(poDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        poDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        poDA.Fill(poDS, "mhsJobs")

        ' Set the Dataview object to the Dataset object
        poDV = New DataView(poDS.Tables("mhsJobs"))

        ' Clear databindings
        'Me.txtPO.DataBindings.Clear()
        Me.lblJobDesc.DataBindings.Clear()

        ' Add databinding
        'Me.txtPO.DataBindings.Add("Text", poDV, "custPO")
        Me.lblJobDesc.DataBindings.Add("Text", poDV, "jobDesc")

        Me.Text = Me.Text & " For " & Me.mhsJob & " (" & Me.lblJobDesc.Text & ")"



    End Sub

    Private Sub getMHSJobNumber()

        '  connection to database
        Dim cmd3 As OleDbCommand = New OleDbCommand("SELECT mhsJob FROM tblShippers WHERE shipperID = " & Me.shipper & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        mhsJobDA = New OleDbDataAdapter(cmd3)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim mhsJobBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(mhsJobDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        mhsJobDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        mhsJobDA.Fill(mhsJobDS, "tblShippers")

        ' Set the Dataview object to the Dataset object
        mhsJobDV = New DataView(mhsJobDS.Tables("tblShippers"))

        ' Clear databindings
        Me.lblMhsJob.DataBindings.Clear()

        ' Add databinding
        Me.lblMhsJob.DataBindings.Add("Text", mhsJobDV, "mhsJob")
        Me.lblMhsJob.Visible = False


    End Sub

    Private Sub getPayItemID()

        ' WITH THIS CODE
        Dim thisItemID As Integer = CInt(Me.dgvItems.CurrentRow.Cells.Item(0).Value)


        '  connection to database
        Dim cmd3 As OleDbCommand = New OleDbCommand("SELECT payItem FROM tblItems WHERE ID = " & thisItemID & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        payItemDA = New OleDbDataAdapter(cmd3)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim payItemBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(payItemDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        payItemDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        payItemDA.Fill(payItemDS, "tblItems")

        ' Set the Dataview object to the Dataset object
        payItemDV = New DataView(payItemDS.Tables("tblItems"))

        ' Clear databindings
        Me.lblPayItem.DataBindings.Clear()

        Try
            ' Add databinding
            Me.lblPayItem.DataBindings.Add("Text", payItemDV, "payItem")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "getPayItemID SUB")
        End Try


        If Me.lblPayItem.Text <> "" Then
            payItemID = CInt(Me.lblPayItem.Text)
        End If


    End Sub


    '  Not used  09-11-09
    Private Sub updateShipper(ByVal sID As Integer, ByVal po As String)


        Try
            '  connection to database
            Dim cmdVia As OleDbCommand = New OleDbCommand("SELECT * FROM tblShippers WHERE shipperID = " & sID, objConn)

            ' Open connection to Db
            objConn.Open()

            ' Set the OleDbCommand object properties
            cmdVia.Connection = objConn
            cmdVia.CommandText = "UPDATE tblShippers " & _
                                    "SET poNum = @po WHERE shipperID = @ID"

            cmdVia.CommandType = CommandType.Text

            ' Add placeholder parameters 
            cmdVia.Parameters.AddWithValue("@po", po)
            cmdVia.Parameters.AddWithValue("@ID", sID)

            ' Execute the OleDbCommand object to update the data
            cmdVia.ExecuteNonQuery()

            ' Close the connection
            objConn.Close()

            Me.ToolStripStatusLabel1.Text = "PO# updated"

            disableFields()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'shipperAdded = False

        End Try




    End Sub

    Private Sub enableFields()

        Me.txtPO.ReadOnly = False
        Me.btnSave.Visible = True

    End Sub

    Private Sub disableFields()

        Me.btnSave.Visible = False
        Me.txtPO.ReadOnly = True

    End Sub

    Private Sub openViewer()

        Me.Width = 775
        Me.grpViewer.Visible = True

    End Sub

    Private Sub closeViewer()

        Me.grpViewer.Visible = False
        Me.Width = 485

    End Sub

    Private Sub openItemInViewer(ByVal iID As Integer)

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand _
            ("SELECT itemID, groupID, itemQty, item, unitQty, unitPrice, itemNotes FROM tblShipperItems " & _
             "WHERE itemID = " & iID & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        iViewDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim iViewBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(iViewDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        iViewDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        iViewDA.Fill(iViewDS, "tblShipperItems")

        ' Set the Dataview object to the Dataset object
        iViewDV = New DataView(iViewDS.Tables("tblShipperItems"))

        ' Clear databindings
        Me.txtViewGroup.DataBindings.Clear()
        Me.txtViewItem.DataBindings.Clear()
        Me.txtViewItemNotes.DataBindings.Clear()
        Me.txtViewItemQty.DataBindings.Clear()
        Me.txtViewUnitPrice.DataBindings.Clear()
        Me.txtViewUnitQty.DataBindings.Clear()

        ' Add databinding
        Me.txtViewGroup.DataBindings.Add("Text", iViewDV, "groupID")
        Me.txtViewItem.DataBindings.Add("Text", iViewDV, "item")
        Me.txtViewItemNotes.DataBindings.Add("Text", iViewDV, "itemNotes")
        Me.txtViewItemQty.DataBindings.Add("Text", iViewDV, "itemQty")
        Me.txtViewUnitPrice.DataBindings.Add("Text", iViewDV, "unitPrice")
        Me.txtViewUnitQty.DataBindings.Add("Text", iViewDV, "unitQty")

        getItemDesc(CInt(Me.txtViewItem.Text))


    End Sub

    Private Sub getItemDesc(ByVal iX As Integer)

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT item FROM tblItems WHERE ID = " & iX & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        iDescDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim iDescBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(iDescDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        iDescDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        iDescDA.Fill(iDescDS, "tblItems")

        ' Set the Dataview object to the Dataset object
        iDescDV = New DataView(iDescDS.Tables("tblItems"))

        ' Clear databindings
        Me.txtViewItem.DataBindings.Clear()

        ' Add databinding
        Me.txtViewItem.DataBindings.Add("Text", iDescDV, "Item")


    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvShipperItems.EndEdit()
            Me.shipperDA.Update(Me.shipperDS.Tables("tblShipperItems"))

            Me.ToolStripStatusLabel1.Text = "Item Updated"

            ' Get most current record from Db
            openItemInViewer(CInt(Me.dgvShipperItems.CurrentRow.Cells.Item(0).Value))


        Catch ex As Exception
            'MessageBox.Show(ex.Message)

        End Try

    End Sub

    ' Not used yet
    Private Function toggleDGV() As Boolean

        Dim isVis As Boolean

        Select Case Me.dgvShipperItems.ReadOnly
            Case Is = True
                isVis = False
            Case Is = False
                isVis = True
        End Select

        Return isVis

    End Function

    Private Function parseJobNum(ByVal jn As String) As String

        Dim parsedJN As String = ""
        Dim chrCount As Integer = jn.Count
        Dim finalJN As String

        For x As Integer = 0 To chrCount - 1
            If jn.Substring(x, 1) <> Chr(45) Then
                parsedJN = parsedJN & jn.Substring(x, 1)
            End If
        Next

        finalJN = Trim(parsedJN)

        Return finalJN

    End Function

    Private Function isShipperAssigned(ByVal sID As Integer) As Boolean

        Dim ass As Boolean

        '  connection to database
        Dim cmd4 As OleDbCommand = New OleDbCommand("SELECT assigned FROM tblShippers WHERE shipperID = " & Me.shipper & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        assDA = New OleDbDataAdapter(cmd4)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim assBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(assDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        assDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        assDA.Fill(assDS, "tblShippers")

        ' Set the Dataview object to the Dataset object
        assDV = New DataView(assDS.Tables("tblShippers"))

        ' Clear databindings
        Me.CheckBox1.DataBindings.Clear()

        ' Add databinding
        Me.CheckBox1.DataBindings.Add("Checked", assDV, "assigned")

        ass = Me.CheckBox1.Checked

        Return ass

    End Function


#End Region




    ' COMBO BOX CODE TO BE REPLACED WITH DGV CODE
    ' THIS SUB NOT NEEDED

    Private Sub fillItemsList()

        ''  connection to database
        'Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblItems ORDER BY ID", objConn)

        '' Open connection to Db
        'objConn.Open()

        ''  Fill dataAdapter with query result from Db
        'itemListDA = New OleDbDataAdapter(cmd)

        ''One CommandBuilder object is required. 
        ''It automatically generates DeleteCommand, 
        ''UpdateCommand and InsertCommand 
        ''for DataAdapter object      
        'Dim itemBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(itemListDA)

        ''  Close the connection
        'objConn.Close()

        '' Instantiate DataSet object
        'itemListDS = New DataSet()

        '' Fill DataSet with data from dataAdapater
        'itemListDA.Fill(itemListDS, "tblItems")


        'With Me.cmbItems
        '    .DataSource = itemListDS.Tables("tblItems")
        '    .DisplayMember = "item"
        '    .Text = "Select"
        'End With

    End Sub





End Class