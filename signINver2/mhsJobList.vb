Option Strict Off

Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources


Public Class mhsJobList
    'Dim appPath As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\King Designs\signIN\"

    Dim objConnection As New OleDbConnection(connStr01)

    Dim objDataAdapter As New OleDbDataAdapter( _
        "SELECT * FROM mhsJobs " & _
        "ORDER BY mhsJob", objConnection)
    Dim objDataSet As DataSet
    Dim objDataView As DataView
    Dim objCurrencyManager As CurrencyManager



    Private Sub FillDataSetAndView()

        ' Initialize a new instance of the DataSet object
        objDataSet = New DataSet()

        ' Fill the DataSet object with Data
        objDataAdapter.Fill(objDataSet, "mhsJobs")

        ' Set the DataView object to the DataSet object
        objDataView = New DataView(objDataSet.Tables("mhsJobs"))

        ' Set the CurrencyManager object to the DataView object
        objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)
    End Sub

    Private Sub BindFields()
        ' Clear any previous bindings
        txtmhsJobNum.DataBindings.Clear()
        txtCustJobNum.DataBindings.Clear()
        lblCustomer.DataBindings.Clear()
        txtCustPO.DataBindings.Clear()
        txtJobDesc.DataBindings.Clear()
        txtProjectNum.DataBindings.Clear()
        txtStateNum.DataBindings.Clear()
        chkTypeI.DataBindings.Clear()
        chkTypeII.DataBindings.Clear()
        chkTypeIII.DataBindings.Clear()
        ckbTypeIV.DataBindings.Clear()
        txtCompletionDate.DataBindings.Clear()
        lblEntryDate.DataBindings.Clear()
        ckbActive.DataBindings.Clear()


        ' Add new bindings to the DataView object
        txtmhsJobNum.DataBindings.Add("Text", objDataView, "mhsJob")
        txtCustJobNum.DataBindings.Add("Text", objDataView, "custJob")
        lblCustomer.DataBindings.Add("Text", objDataView, "cust")
        txtCustPO.DataBindings.Add("Text", objDataView, "custPO")
        txtJobDesc.DataBindings.Add("Text", objDataView, "jobDesc")
        txtProjectNum.DataBindings.Add("Text", objDataView, "projNum")
        txtStateNum.DataBindings.Add("Text", objDataView, "stateNum")
        chkTypeI.DataBindings.Add("Checked", objDataView, "typeI")
        chkTypeII.DataBindings.Add("Checked", objDataView, "typeII")
        chkTypeIII.DataBindings.Add("Checked", objDataView, "typeIII")
        ckbTypeIV.DataBindings.Add("Checked", objDataView, "typeIV")
        txtCompletionDate.DataBindings.Add("Text", objDataView, "compDate")
        lblEntryDate.DataBindings.Add("Text", objDataView, "entryDate")
        ckbActive.DataBindings.Add("Checked", objDataView, "active")

    End Sub

    Private Sub ShowPosition()
        ' Display the current position and the number of records
        txtRecordPosition.Text = objCurrencyManager.Position + 1 & _
        " of " & objCurrencyManager.Count
    End Sub

    Private Sub mhsJobList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Call populate ATM Job # function
        'PopulateATMJobNum()

        ' Clear cust job #
        'txtCustJobNum.Clear()

        ' Add items to the combo box
        cmbField.Items.Add("MHS Job#")
        cmbField.Items.Add("Customer Job#")
        cmbField.Items.Add("Customer")

        ' Make the first item selected
        cmbField.SelectedIndex = 0

        ' Check boxes to false
        'chkTypeI.Checked = False
        'chkTypeII.Checked = False
        'chkTypeIII.Checked = False

        ' Fill the DataSet and bind the fields
        FillDataSetAndView()
        BindFields()

        ' Show the current record position
        ShowPosition()

        ' Call populate contractor function
        PopulateContractor()

        ' Disable ATM Job# combo box and ATM Info button
        cmbATMJobNum.Enabled = False
        btnATMInfo.Enabled = False

        ' Display "Ready" Message
        ToolStripStatusLabel2.Text = "Ready"
    End Sub

    Private Sub btnMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFirst.Click
        ' Set the record position to the first record
        objCurrencyManager.Position = 0

        ' Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnMovePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovePrevious.Click
        ' Move to the previous record
        objCurrencyManager.Position -= 1

        ' Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveNext.Click
        ' Move to the next record
        objCurrencyManager.Position += 1

        ' Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLast.Click
        ' Set the record position to the last record
        objCurrencyManager.Position = objCurrencyManager.Count - 1

        ' Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnPerformSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformSort.Click
        ' Determine the appropriate item selected and set the
        ' Sort property of the DataView object
        Select Case cmbField.SelectedIndex
            Case 0 ' MHS Job #
                objDataView.Sort = "mhsJob"
            Case 1 ' Customer Job #
                objDataView.Sort = "custJob"
            Case 2 ' Customer
                objDataView.Sort = "cust"
        End Select

        ' Call the click event for the MoveFirst button
        btnMoveFirst_Click(Nothing, Nothing)

        ' Display a message that the records have been sorted
        ToolStripStatusLabel2.Text = "Records Sorted"
    End Sub

    Private Sub btnPerformSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformSearch.Click
        ' Declare local variables
        Dim intPosition As Integer

        ' Determine the appropriate item selected and set the
        ' Sort property of the DataView object
        Select Case cmbField.SelectedIndex
            Case 0 ' MHS Job #
                objDataView.Sort = "mhsJob"
            Case 1 ' Customer Job #
                objDataView.Sort = "custJob"
            Case 2 ' Customer
                objDataView.Sort = "cust"
        End Select

        ' Find search item
        intPosition = objDataView.Find(txtSearchCriteria.Text)
        If intPosition = -1 Then
            ' Display a message that the record was not found
            ToolStripStatusLabel1.Text = "Record Not Found"
        Else
            ' Otherwise display a message that the record was
            ' found and reposition the CurrencyManager to that
            ' record
            ToolStripStatusLabel2.Text = "Record Found"
            objCurrencyManager.Position = intPosition
        End If

        ' Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim clearFields As DialogResult

        clearFields = MessageBox.Show("Clear Fields?", "Add New Job", _
                      MessageBoxButtons.OKCancel, _
                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        Select Case clearFields
            Case Windows.Forms.DialogResult.OK
                txtmhsJobNum.Text = ""
                lblCustomer.Text = ""
                txtCustJobNum.Text = ""
                txtCustPO.Text = ""
                txtJobDesc.Text = ""
                txtProjectNum.Text = ""
                txtStateNum.Text = ""
                chkTypeI.Checked = False
                chkTypeII.Checked = False
                chkTypeIII.Checked = False
                ckbTypeIV.Checked = False
                txtCompletionDate.Text = Nothing
                ckbActive.Checked = False
                lblCustFull.Text = ""
                lblEntryDate.Text = ""
                Me.cmbContractor.Text = "Select Customer"

                ToolStripStatusLabel2.Text = "Enter new job details"

            Case Windows.Forms.DialogResult.Cancel
                ' Do nothing and return to form
        End Select
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' Declare local variables and objects

        Dim intPosition As Integer
        Dim objCommand As OleDbCommand = New OleDbCommand

        ' Save the current record position
        intPosition = objCurrencyManager.Position

        ' Open the connection, execute the command
        objConnection.Open()

        ' Set the OleDbCommand object properties
        objCommand.Connection = objConnection
        objCommand.CommandText = _
            "INSERT INTO mhsJobs " & _
            "(mhsJob, custJob, cust, custPO, jobDesc, projNum, " & _
            "stateNum, typeI, typeII, typeIII, typeIV, compDate, active) " & _
            "VALUES(@mhsJob,@custJob,@cust,@custPO,@jobDesc,@projNum, " & _
            "@stateNum,@typeI,@typeII,@typeIII,@typeIV,@compDate,@active)"

        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property
        objCommand.Parameters.AddWithValue("@mhsJob", txtmhsJobNum.Text)
        objCommand.Parameters.AddWithValue("@custJob", txtCustJobNum.Text)
        objCommand.Parameters.AddWithValue("@cust", lblCustomer.Text)
        objCommand.Parameters.AddWithValue("@custPO", txtCustPO.Text)
        objCommand.Parameters.AddWithValue("@jobDesc", txtJobDesc.Text)
        objCommand.Parameters.AddWithValue("@projNum", txtProjectNum.Text)
        objCommand.Parameters.AddWithValue("@stateNum", txtStateNum.Text)
        objCommand.Parameters.AddWithValue("@typeI", chkTypeI.CheckState)
        objCommand.Parameters.AddWithValue("@typeII", chkTypeII.CheckState)
        objCommand.Parameters.AddWithValue("@typeIII", chkTypeIII.CheckState)
        objCommand.Parameters.AddWithValue("@typeIV", ckbTypeIV.CheckState)
        objCommand.Parameters.AddWithValue("@compDate", txtCompletionDate.Text)
        'objCommand.Parameters.AddWithValue("@entryDate", Now())
        objCommand.Parameters.AddWithValue("@active", ckbActive.CheckState)

        ' Execute the OleDbCommand object to insert the new data
        Try
            objCommand.ExecuteNonQuery()

            ' Display a message that the record was added
            ToolStripStatusLabel2.Text = Me.txtmhsJobNum.Text & " (" & Me.txtJobDesc.Text & ") Added successfully"

        Catch OleDbExceptionErr As OleDbException
            MessageBox.Show(OleDbExceptionErr.Message)

            ToolStripStatusLabel2.Text = "Record not added!"
        End Try

        ' Close the connection
        objConnection.Close()

        ' Fill the dataset and bind the fields
        FillDataSetAndView()
        BindFields()

        'Set the record position to the saved record
        objCurrencyManager.Position = intPosition

        ' Show the current record position
        ShowPosition()

        

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ' Declare local variables and objects
        Dim intPosition As Integer
        Dim objCommand As OleDbCommand = New OleDbCommand

        ' Save the current record position
        intPosition = objCurrencyManager.Position

        ' Set the OleDbCommand object properties
        objCommand.Connection = objConnection
        objCommand.CommandText = "UPDATE mhsJobs " & _
            "SET mhsJob = @mhsJob, custJob = @custJob, " & _
            "cust = @cust, custPO = @custPO, jobDesc = @jobDesc, " & _
            "projNum = @projNum, stateNum = @stateNum, " & _
            "typeI = @typeI, typeII = @typeII, typeIII = @typeIII, typeIV = @typeIV, " & _
            "compDate = @compDate, active = @active " & _
            "WHERE ID = @ID"
        objCommand.CommandType = CommandType.Text

        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property        
        objCommand.Parameters.AddWithValue("@mhsJob", txtmhsJobNum.Text)
        objCommand.Parameters.AddWithValue("@custJob", txtCustJobNum.Text)
        objCommand.Parameters.AddWithValue("@cust", lblCustomer.Text)
        objCommand.Parameters.AddWithValue("@custPO", txtCustPO.Text)
        objCommand.Parameters.AddWithValue("@jobDesc", txtJobDesc.Text)
        objCommand.Parameters.AddWithValue("@projNum", txtProjectNum.Text)
        objCommand.Parameters.AddWithValue("@stateNum", txtStateNum.Text)
        objCommand.Parameters.AddWithValue("@typeI", chkTypeI.CheckState)
        objCommand.Parameters.AddWithValue("@typeII", chkTypeII.CheckState)
        objCommand.Parameters.AddWithValue("@typeIII", chkTypeIII.CheckState)
        objCommand.Parameters.AddWithValue("@typeIV", ckbTypeIV.CheckState)
        objCommand.Parameters.AddWithValue("@compDate", txtCompletionDate.Text)
        'objCommand.Parameters.AddWithValue("@entryDate", Now())
        objCommand.Parameters.AddWithValue("@active", ckbActive.CheckState)
        objCommand.Parameters.AddWithValue("@ID", _
                                          BindingContext(objDataView).Current("ID"))

        ' Open the connection
        objConnection.Open()

        ' Execute the OleDbCommand object to update the data
        objCommand.ExecuteNonQuery()

        ' Display a message that the record was updated
        ToolStripStatusLabel2.Text = Me.txtmhsJobNum.Text & ", (" & Me.txtJobDesc.Text & ") Updated"

        ' Close the connection
        objConnection.Close()

        ' Fill DataSet and bind fields
        FillDataSetAndView()
        BindFields()

        ' Set the record position to the one saved
        objCurrencyManager.Position = intPosition

        ' Show the current record position
        ShowPosition()

        
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim deleteRecord As DialogResult

        deleteRecord = MessageBox.Show("Confirm deletion?", "Delete Record", _
                      MessageBoxButtons.OKCancel, _
                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        Select Case deleteRecord
            Case Windows.Forms.DialogResult.OK
                'Declare local variables and objects
                Dim intPosition As Integer
                Dim objCommand As OleDbCommand = New OleDbCommand

                ' Save the current record position -1 for the one to be deleted
                intPosition = Me.BindingContext(objDataView).Position - 1

                ' If the position is less than 0 set it to 0
                If intPosition < 0 Then
                    intPosition = 0
                End If

                ' Set the Command object properties
                objCommand.Connection = objConnection
                objCommand.CommandText = "DELETE FROM mhsJobs " & _
                        "WHERE ID = @ID"

                objCommand.Parameters.AddWithValue("@ID", _
                                                    BindingContext(objDataView).Current("ID"))

                ' Open the database connection
                objConnection.Open()

                ' Execute the OleDbCommand object to update the data
                objCommand.ExecuteNonQuery()

                ' Close the connection
                objConnection.Close()

                ' Fill the DataSet and bind the fields
                FillDataSetAndView()
                BindFields()

                ' Set the record position to the one saved
                Me.BindingContext(objDataView).Position = intPosition

                ' Show the current record position
                ShowPosition()

                ' Display a message that the record was deleted
                ToolStripStatusLabel2.Text = "Record Deleted"
            Case Windows.Forms.DialogResult.Cancel
                'Do nothing and return to form
        End Select
    End Sub

    Public Sub PopulateContractor()


        ' contractors (db1 Db) Connection
        Dim objCustConnection  As New OleDbConnection(connStr01)
        Dim objCustDataAdapter As New OleDbDataAdapter( _
            "SELECT * FROM contractors ORDER By cont", objCustConnection)

        Dim objCustDataSet As DataSet
        Dim objCustDataView As DataView

        ' Initialize a new instance of the DataSet object
        objCustDataSet = New DataSet()

        ' Open the connection, execute the command
        objCustConnection.Open()

        ' Fill DataSet
        objCustDataAdapter.Fill(objCustDataSet, "contractors")

        ' Close the connection
        objCustConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objCustDataView = New DataView(objCustDataSet.Tables("contractors"))

        ' Populate contractor combo box
        Me.cmbContractor.DataSource = objCustDataSet.Tables("contractors")
        Me.cmbContractor.DisplayMember = "cont"
        Me.cmbContractor.Text = "Select Customer"

    End Sub

    Public Sub PopulateATMJobInfo()
        ' Declare job# variable
        Dim jobNum As String = Me.txtCustJobNum.Text

        ' Job List (ATM Db) Connection
        Dim objJobConnection2 As New OleDbConnection(atmConnStr01)

        Dim objJobDataAdapter2 As New OleDbDataAdapter( _
            "SELECT [JOB #] As atmJN, [PROJECT #] As projNum, " & _
            "[STATE JOB #] As stateNum, LOCATION, [Completion Date] As compDate " & _
            "FROM [JOB LIST] " & _
            "WHERE [JOB #] = '" & jobNum & "'", objJobConnection2)

        Dim objJobDataSet2 As DataSet
        Dim objJobDataView2 As DataView

        ' Initialize a new instance of the DataSet object
        objJobDataSet2 = New DataSet()

        ' Open the connection, execute the command
        objJobConnection2.Open()

        ' Fill DataSet
        objJobDataAdapter2.Fill(objJobDataSet2, "[JOB LIST]")

        ' Close the connection
        objJobConnection2.Close()

        ' Set the Contractors DataView object to the DataSet object
        objJobDataView2 = New DataView(objJobDataSet2.Tables("[JOB LIST]"))

        '' Declare variables and Populate Text Fields
        ''lblCustomer.Text = cmbContractor.Text

        ' Clear any previous bindings
        Label1.DataBindings.Clear()
        Label2.DataBindings.Clear()
        Label3.DataBindings.Clear()
        Label4.DataBindings.Clear()
        Label5.DataBindings.Clear()

        ' Add new bindings to the DataView object
        Label1.DataBindings.Add("Text", objJobDataView2, "atmJN")
        Label2.DataBindings.Add("Text", objJobDataView2, "LOCATION")
        Label3.DataBindings.Add("Text", objJobDataView2, "projNum")
        Label4.DataBindings.Add("Text", objJobDataView2, "stateNum")
        Label5.DataBindings.Add("Text", objJobDataView2, "compDate")

        ' Migrate ATM databound fields to MHS databound fields
        txtCustJobNum.Text = Label1.Text
        txtJobDesc.Text = Label2.Text
        txtProjectNum.Text = Label3.Text
        txtStateNum.Text = Label4.Text
        txtCompletionDate.Text = Label5.Text

        ' Hide label bindings
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
    End Sub

    Public Sub PopulateATMJobNum()
        ' Job List (ATM Db) Connection
        Dim objJobConnection As New OleDbConnection(atmConnStr01)
        Dim objJobDataAdapter As New OleDbDataAdapter( _
            "SELECT [JOB #] As jn FROM [JOB LIST] ORDER BY [JOB #]", objJobConnection)

        Dim objJobDataSet As DataSet
        Dim objJobDataView As DataView

        ' Initialize a new instance of the DataSet object
        objJobDataSet = New DataSet()

        ' Open the connection, execute the command
        objJobConnection.Open()

        ' Fill DataSet
        objJobDataAdapter.Fill(objJobDataSet, "[JOB LIST]")

        ' Set the Contractors DataView object to the DataSet object
        objJobDataView = New DataView(objJobDataSet.Tables("[JOB LIST]"))

        ' Close the connection
        objJobConnection.Close()

        ' Populate contractor combo box
        Me.cmbATMJobNum.DataSource = objJobDataSet.Tables("[JOB LIST]")
        Me.cmbATMJobNum.DisplayMember = "jn"
    End Sub

    Public Sub customerFull()

        Dim contractor As String = Me.lblCustomer.Text

        ' contractors (db1 Db) Connection
        Dim objFullConnection  As New OleDbConnection(connStr01)
        Dim objFullDataAdapter As New OleDbDataAdapter( _
            "SELECT * FROM contractors WHERE cont = '" & contractor & "' ORDER By cont", objFullConnection)

        Dim objFullDataSet As DataSet
        Dim objFullDataView As DataView

        ' Initialize a new instance of the DataSet object
        objFullDataSet = New DataSet()

        ' Open the connection, execute the command
        objFullConnection.Open()

        ' Fill DataSet
        objFullDataAdapter.Fill(objFullDataSet, "contractors")

        ' Close the connection
        objFullConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objFullDataView = New DataView(objFullDataSet.Tables("contractors"))

        ' Clear databindings
        lblCustFull.DataBindings.Clear()

        ' Add databindings
        lblCustFull.DataBindings.Add("Text", objFullDataView, "full")

    End Sub

    Private Sub cmbContractor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbContractor.SelectedIndexChanged
        If cmbContractor.Text = "ATM" Then
            cmbATMJobNum.Enabled = True
            btnATMInfo.Enabled = True
            ' Call populate ATM job # function
            PopulateATMJobNum()
        Else
            cmbATMJobNum.Enabled = False
            btnATMInfo.Enabled = False
        End If

        lblCustomer.Text = cmbContractor.Text


    End Sub

    Private Sub cmbATMJobNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbATMJobNum.SelectedIndexChanged

        ' Migrate Customer Job#
        Me.txtCustJobNum.Text = Me.cmbATMJobNum.Text

    End Sub

    Private Sub btnATMInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnATMInfo.Click
        ' Call populate ATM Job Info function
        PopulateATMJobInfo()
    End Sub

    Private Sub btnViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAll.Click
        Dim viewAllMHSJobs As New frmMhsJobListViewAll()
        viewAllMHSJobs.MdiParent = signINver2.signINMain1
        viewAllMHSJobs.Show()
    End Sub

    Private Sub lblCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCustomer.TextChanged
        customerFull()
    End Sub
End Class