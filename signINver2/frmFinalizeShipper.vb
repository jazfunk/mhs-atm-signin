Option Strict On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources




Public Class frmFinalizeShipper

    Public Sub New(ByVal sID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.

        Me.shipper = sID


    End Sub

#Region " Class-level Variables"

    Dim shipperNum As Integer
    Dim mhsJob As String

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

    


#End Region

#Region " Database communication"

    '  (db1.mdb) connection
	'Dim objConn As New OleDbConnection(connStr01)
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)

    Dim shipperDA As OleDbDataAdapter
    Dim shipperDS As DataSet
    Dim shipperDV As DataView
    Dim shipperDT As DataTable

    Dim jobDA As OleDbDataAdapter
    Dim jobDS As DataSet
    Dim jobDV As DataView
    Dim jobDT As DataTable

    Dim thisShipperJobDA As OleDbDataAdapter
    Dim thisShipperJobDS As DataSet
    Dim thisShipperJobDT As DataTable
    Dim thisShipperJobDV As DataView



#End Region

#Region " Event Handlers"

    Private Sub frmFinalizeShipper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        getShipper()
        FillJobList()
        disableFields()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Me.Cursor = Cursors.WaitCursor

        enableFields()

        Me.btnEdit.Enabled = False

        Me.Cursor = Cursors.Arrow

    End Sub

    

    Private Sub cmbMHSJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMHSJob.SelectedIndexChanged

        Try

            If Me.cmbMHSJob.Enabled Then

                Me.mhsJobNum = Me.cmbMHSJob.Text
                BindNewJobNumInfo()

                Me.jobDT.Select("mhsJob = '" & Me.mhsJobNum & "'")


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "cmbMHSJob_SelectedIndexChanged()")

        End Try


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Me.Cursor = Cursors.WaitCursor

        updateDb()
        disableFields()

        Me.Cursor = Cursors.Arrow

    End Sub




#End Region

#Region " Subs and Functions"

    Public Sub GetShipper()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblShippers WHERE shipperID = " & Me.shipper & "", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        shipperDA = New OleDbDataAdapter(cmd)

        ''One CommandBuilder object is required. 
        ''It automatically generates DeleteCommand, 
        ''UpdateCommand and InsertCommand 
        ''for DataAdapter object      
        'Dim shipperBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(shipperDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        shipperDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        shipperDA.Fill(shipperDS, "tblShippers")

        ' Set the Dataview object to the Dataset object
        shipperDV = New DataView(shipperDS.Tables("tblShippers"))

        ' Clear databindings
        Me.lblShipperID.DataBindings.Clear()
        Me.lblMHSJob.DataBindings.Clear()
        Me.txtVia.DataBindings.Clear()
        Me.cboShipped.DataBindings.Clear()
        Me.eDTPShipDate.DataBindings.Clear()

        Me.txtRcvdBy.DataBindings.Clear()
        Me.txtEntryDate.DataBindings.Clear()
        Me.txtComments.DataBindings.Clear()
        Me.txtPO.DataBindings.Clear()


        Try
            ' Add databinding
            Me.lblShipperID.DataBindings.Add("Text", shipperDV, "shipperID")
            Me.lblMHSJob.DataBindings.Add("Text", shipperDV, "mhsJob")

            Me.txtVia.DataBindings.Add("Text", shipperDV, "via")
            Me.cboShipped.DataBindings.Add("Checked", shipperDV, "shipped")

            ' ExtendedDateTimePicker
            Me.eDTPShipDate.DataBindings.Add("DBValue", shipperDV, "shipDate")

            If Me.shipperDV.Item(0).Item(4).ToString = String.Empty Then
                Me.eDTPShipDate.Value = Now.Date
            End If

            Me.txtRcvdBy.DataBindings.Add("Text", shipperDV, "RecvdBy")

            '  Format Date value
            Me.txtEntryDate.DataBindings.Add("Text", shipperDV, "entryDate", True).FormatString = "MM/dd/yyyy"
            Me.txtComments.DataBindings.Add("Text", shipperDV, "comments")
            Me.txtPO.DataBindings.Add("Text", shipperDV, "poNum")

            '' Assign this shipper's job # to the mhsJobNum property
            'Me.mhsJobNum = Me.lblMHSJob.Text

            ' Assign this shipper's job # to the mhsJobNum property
            Me.mhsJobNum = Me.shipperDV.Item(0).Item(1).ToString

            ' Populate Job Info
            FillThisShipperJobInfo()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "getShipper()")
        End Try


    End Sub

    Private Sub FillJobList()


        Try
            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM mhsJobs", objConn)

            ' Open connection to Db
            objConn.Open()

            '  Fill dataAdapter with query result from Db
            jobDA = New OleDbDataAdapter(cmd)

            ''One CommandBuilder object is required. 
            ''It automatically generates DeleteCommand, 
            ''UpdateCommand and InsertCommand 
            ''for DataAdapter object      
            'Dim jobBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(jobDA)

            '  Close the connection
            objConn.Close()

            ' Instantiate DataSet object
            jobDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            jobDA.Fill(jobDS, "mhsJobs")

            ' DataTable -   Fill the DataTable object with data
            jobDT = jobDS.Tables("mhsJobs")


            RemoveHandler cmbMHSJob.SelectedIndexChanged, AddressOf cmbMHSJob_SelectedIndexChanged
            With Me.cmbMHSJob
                .DataSource = jobDT
                .DisplayMember = "mhsJob"
                .Text = "Select"
            End With
            AddHandler cmbMHSJob.SelectedIndexChanged, AddressOf cmbMHSJob_SelectedIndexChanged


        Catch ex As Exception

        End Try



    End Sub

    Private Sub FillThisShipperJobInfo()

        Try
            '  connection to database
            Dim cmdThisShipper As OleDbCommand = New OleDbCommand("SELECT * FROM mhsJobs WHERE mhsJob = '" & Me.mhsJobNum & "'", objConn)

            ' Open connection to Db
            objConn.Open()

            '  Fill dataAdapter with query result from Db
            thisShipperJobDA = New OleDbDataAdapter(cmdThisShipper)

            '  Close the connection
            objConn.Close()

            ' Instantiate DataSet object
            thisShipperJobDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            thisShipperJobDA.Fill(thisShipperJobDS, "mhsJobs")

            ' DataTable -   Fill the DataTable object with data
            thisShipperJobDT = thisShipperJobDS.Tables("mhsJobs")



            ' Clear DataBinding
            Me.lblCustJob.DataBindings.Clear()
            Me.lblCust.DataBindings.Clear()
            Me.lblJobDesc.DataBindings.Clear()
            Me.lblProjNum.DataBindings.Clear()
            Me.lblStateNum.DataBindings.Clear()
            Me.lblCompDate.DataBindings.Clear()
            Me.ckbActive.DataBindings.Clear()
            Me.ckbMMM.DataBindings.Clear()

            ' Add DataBinding
            Me.lblCustJob.DataBindings.Add("Text", thisShipperJobDT, "custJob")
            Me.lblCust.DataBindings.Add("Text", thisShipperJobDT, "cust")
            Me.lblJobDesc.DataBindings.Add("Text", thisShipperJobDT, "jobDesc")
            Me.lblProjNum.DataBindings.Add("Text", thisShipperJobDT, "projNum")
            Me.lblStateNum.DataBindings.Add("Text", thisShipperJobDT, "stateNum")

            ' Format Date
            Me.lblCompDate.DataBindings.Add("Text", thisShipperJobDT, "compDate", True).FormatString = "MM/dd/yyyy"
            Me.ckbActive.DataBindings.Add("Checked", thisShipperJobDT, "Active")
            Me.ckbMMM.DataBindings.Add("Checked", thisShipperJobDT, "MMMDisc")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Is there an error here?")

        End Try




    End Sub

    Private Sub BindNewJobNumInfo()

        ' This binds data when job number is changed
        Try

            ' Clear DataBinding
            Me.lblMHSJob.DataBindings.Clear()
            Me.lblCustJob.DataBindings.Clear()
            Me.lblCust.DataBindings.Clear()
            Me.lblJobDesc.DataBindings.Clear()
            Me.lblProjNum.DataBindings.Clear()
            Me.lblStateNum.DataBindings.Clear()
            Me.lblCompDate.DataBindings.Clear()
            Me.ckbActive.DataBindings.Clear()
            Me.ckbMMM.DataBindings.Clear()

            ' Add DataBinding
            Me.lblMHSJob.DataBindings.Add("Text", jobDT, "mhsJob")
            Me.lblCustJob.DataBindings.Add("Text", jobDT, "custJob")
            Me.lblCust.DataBindings.Add("Text", jobDT, "cust")
            Me.lblJobDesc.DataBindings.Add("Text", jobDT, "jobDesc")
            Me.lblProjNum.DataBindings.Add("Text", jobDT, "projNum")
            Me.lblStateNum.DataBindings.Add("Text", jobDT, "stateNum")

            ' Format Date
            Me.lblCompDate.DataBindings.Add("Text", jobDT, "compDate", True).FormatString = "MM/dd/yyyy"
            Me.ckbActive.DataBindings.Add("Checked", jobDT, "Active")
            Me.ckbMMM.DataBindings.Add("Checked", jobDT, "MMMDisc")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindNewJobNumInfo()")

        End Try




    End Sub




    Private Sub disableFields()

        Me.txtComments.ReadOnly = True
        Me.txtEntryDate.ReadOnly = True
        Me.txtPO.ReadOnly = True
        Me.txtVia.ReadOnly = True
        Me.cmbMHSJob.Enabled = False


    End Sub

    Private Sub enableFields()

        Me.txtComments.ReadOnly = False
        'Me.txtEntryDate.ReadOnly = False
        Me.txtPO.ReadOnly = False
        Me.txtVia.ReadOnly = False
        Me.cmbMHSJob.Enabled = True

    End Sub

    Private Sub updateDb()

        Dim cmdUpdate As OleDbCommand = New OleDbCommand

        ' Open the connection
        objConn.Open()

        Try

            ' Set the OleDbCommand object properties
            cmdUpdate.Connection = objConn
            cmdUpdate.CommandText = "UPDATE tblShippers " & _
                                    "SET mhsJob = @mhsJob, " & _
                                    "via = @via,  " & _
                                    "shipped = @shipped, " & _
                                    "shipDate = @shipDate, " & _
                                    "RecvdBy = @RecvdBy, " & _
                                    "comments = @comments, " & _
                                    "poNum = @poNum " & _
                                    "WHERE shipperID = @ID"

            cmdUpdate.CommandType = CommandType.Text

            ' Add placeholder parameters 
            cmdUpdate.Parameters.AddWithValue("@mhsJob", Me.lblMHSJob.Text)
            cmdUpdate.Parameters.AddWithValue("@via", Me.txtVia.Text)
            cmdUpdate.Parameters.AddWithValue("@shipped", Me.cboShipped.Checked)

            Select Case cboShipped.Checked

                Case True
                    cmdUpdate.Parameters.AddWithValue("@shipDate", eDTPShipDate.Value)

                Case False
                    cmdUpdate.Parameters.AddWithValue("@shipDate", DBNull.Value)

            End Select

            cmdUpdate.Parameters.AddWithValue("@RecvdBy", Me.txtRcvdBy.Text)
            cmdUpdate.Parameters.AddWithValue("@comments", Me.txtComments.Text)
            cmdUpdate.Parameters.AddWithValue("@poNum", Me.txtPO.Text)
            cmdUpdate.Parameters.AddWithValue("@ID", Me.shipper)

            ' Execute the OleDbCommand object to update the data
            cmdUpdate.ExecuteNonQuery()

            ' Close the connection
            objConn.Close()

            ' Display a message that the record was updated
            ToolStripStatusLabel1.Text = "Shipper #:  " & Me.shipper & " Updated Successfully."

            ' Refresh DataSet
            GetShipper()

            Me.btnEdit.Enabled = True


        Catch OleDbExceptionErr As OleDbException
            MessageBox.Show(OleDbExceptionErr.Message)
            ToolStripStatusLabel1.Text = "Shipper #:  " & Me.shipper & "Not Updated!"

            ' Close the connection
            objConn.Close()
        End Try


    End Sub

#End Region






    
End Class