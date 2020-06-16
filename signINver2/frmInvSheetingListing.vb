
Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources






Public Class frmInvSheetingListing

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    ' Alternate Constructor for calling from frmStationStatus
    ' where this form will return the tblSheetingInv PK to 
    ' update sign record in tblStationStatus

    '*** Maybe consider passing the entire DGV Row back to the
    '*** calling form so I have all the Data without going 
    '*** back to the DataBase

    Public Sub New(ByVal i As String)

        If i = "GetLot" Then

            isInquiry = True

        End If

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If isInquiry Then Me.btnOK.Enabled = True
        

    End Sub


#Region " Class-level variables"

    Private dctSheeting As New Dictionary(Of String, String)
    Private _ReturnID As Integer
    Private isInquiry As Boolean
    Private _ReturnRow As DataGridViewRow



#End Region



#Region " Properties"

    ' The PK from tblSheetingInv
    Public Property ReturnID() As Integer
        Get
            Return _ReturnID

        End Get
        Set(ByVal value As Integer)
            _ReturnID = value

        End Set
    End Property




    ' The entire DataGridViewRow
    Public ReadOnly Property ReturnRow() As DataGridViewRow
        Get
            Return _ReturnRow

        End Get

    End Property



#End Region




#Region " Database Communication"



    ' Connection to db1.mdb
	'Dim mhsConn As New OleDbConnection(connStr01)
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)


    ' Connection to materialsInventory.mdb
	'Dim invConn1 As New OleDbConnection(inventoryConnStr01)
	Dim invConn1 As New OleDbConnection(My.Settings.INVconn)


    ' Inventory Sheeting (materialsinventory.mdb)
    Dim invSheetDA As OleDbDataAdapter
    Dim invSheetDS As DataSet
    Dim invSheetDV As DataView
    Dim invSheetDT As DataTable


    ' Sheeting (db1.mdb)
    Dim allSheetDA As OleDbDataAdapter
    Dim allSheetDS As DataSet
    Dim allSheetDV As DataView
    Dim allSheetDT As DataTable







#End Region




#Region " Functions & Methods"


    Private Sub FillDGVandBindFields()

        Try

            '  connection to database
			Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
													   "ID, " & _
													   "rollWidth, " & _
													   "rollLength, " & _
													   "code, " & _
													   "rollQty, " & _
													   "po, " & _
													   "lot, " & _
													   "drum, " & _
													   "invoice, " & _
													   "shipDate, " & _
													   "recvDate, " & _
													   "carrier, " & _
													   "depleted " & _
													   "FROM tblSheetingDetails " & _
													   "ORDER By shipDate DESC", invConn1)


            ' Open connection to Db
			invConn1.Open()

            '  Fill dataAdapter with query result from Db
            invSheetDA = New OleDbDataAdapter(cmd)

			invConn1.Close()

            ' Initialize a new instance of the DataSet object
            invSheetDS = New DataSet()

            ' Fill the DataSet object with Data
            invSheetDA.Fill(invSheetDS, "tblSheetingDetails")

            Dim invSheetCB As New OleDbCommandBuilder(invSheetDA)

            ' DataTable -   Fill the DataTable object with data
            invSheetDT = invSheetDS.Tables("tblSheetingDetails")

            ' Set the DataView object to the DataSet object
            invSheetDV = New DataView(invSheetDS.Tables("tblSheetingDetails"))


            ' Set Align-MiddleCenter object
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke


            With Me.dgvSheetingListing

                .DataSource = invSheetDV

                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' ID field
                .Columns(0).Visible = False

                ' rollWidth field
                .Columns(1).HeaderText = "Width(in)"
                .Columns(1).Width = 65
                .Columns(1).DefaultCellStyle = objAlignRightcellStyle
                .Columns(1).DefaultCellStyle.ForeColor = Color.Black
                .Columns(1).DefaultCellStyle.Font = New Font(dgvSheetingListing.Font, FontStyle.Bold)

                ' rollLength field
                .Columns(2).HeaderText = "Length(yds)"
                .Columns(2).DefaultCellStyle = objAlignRightcellStyle
                .Columns(2).Width = 65

                ' code field
                .Columns(3).HeaderText = "Code"
                .Columns(3).Width = 75

                ' rollQty field
                .Columns(4).HeaderText = "Roll Qty"
                .Columns(4).DefaultCellStyle = objAlignRightcellStyle
                .Columns(4).Width = 55

                ' po field
                .Columns(5).HeaderText = "PO#"
                .Columns(5).Width = 45

                ' lot field
                .Columns(6).HeaderText = "Lot#"
                .Columns(6).Width = 70
                .Columns(6).DefaultCellStyle = objAlignMidcellStyle

                ' drum field
                .Columns(7).HeaderText = "Drum#"
                .Columns(7).DefaultCellStyle = objAlignRightcellStyle
                .Columns(7).Width = 50

                ' invoice field
                .Columns(8).HeaderText = "Invoice"
                .Columns(8).Width = 70

                ' shipDate field
                .Columns(9).HeaderText = "Ship Date"
                .Columns(9).DefaultCellStyle = objAlignRightcellStyle
                .Columns(9).Width = 70

                ' recvDate field
                .Columns(10).HeaderText = "Rcvd Date"
                .Columns(10).DefaultCellStyle = objAlignRightcellStyle
                .Columns(10).Width = 70

                ' carrier field
                .Columns(11).HeaderText = "Carrier"
                .Columns(11).Width = 50

                ' depleted field
                .Columns(12).HeaderText = "Depleted"
                .Columns(12).Width = 55


            End With

            'Clear Databindings
            Me.txtRollWidth.DataBindings.Clear()
            Me.txtRollLength.DataBindings.Clear()
            Me.txtCode.DataBindings.Clear()
            Me.txtRollQty.DataBindings.Clear()
            Me.txtPO.DataBindings.Clear()
            Me.txtLot.DataBindings.Clear()
            Me.txtDrum.DataBindings.Clear()
            Me.txtInvoice.DataBindings.Clear()
            Me.eDtpShipDate.DataBindings.Clear()
            Me.eDtpRecvDate.DataBindings.Clear()
            Me.txtCarrier.DataBindings.Clear()
			Me.ckbDepleted.DataBindings.Clear()
			Me.lblSheetingID.DataBindings.Clear()



            ' Add Databindings
            Me.txtRollWidth.DataBindings.Add("Text", invSheetDV, "rollWidth")
            Me.txtRollLength.DataBindings.Add("Text", invSheetDV, "rollLength")
            Me.txtCode.DataBindings.Add("Text", invSheetDV, "code")
            Me.txtRollQty.DataBindings.Add("Text", invSheetDV, "rollQty")
            Me.txtPO.DataBindings.Add("Text", invSheetDV, "po")
            Me.txtLot.DataBindings.Add("Text", invSheetDV, "lot")
            Me.txtDrum.DataBindings.Add("Text", invSheetDV, "drum")
            Me.txtInvoice.DataBindings.Add("Text", invSheetDV, "invoice")
            Me.eDtpShipDate.DataBindings.Add("Text", invSheetDV, "shipDate")
            Me.eDtpRecvDate.DataBindings.Add("Text", invSheetDV, "recvDate")
            Me.txtCarrier.DataBindings.Add("Text", invSheetDV, "carrier")
			Me.ckbDepleted.DataBindings.Add("Checked", invSheetDV, "depleted")
			Me.lblSheetingID.DataBindings.Add("Text", invSheetDV, "ID")

            ' Display message
            Me.ToolStripStatusLabel2.Text = Me.invSheetDV.Count & " Sheeting Inventory items"


        Catch ex As Exception

            ' Display message
            Me.ToolStripStatusLabel2.Text = "Error!"
            MessageBox.Show(ex.Message, "FillDGVandBindFields()")


        End Try

    End Sub

    Public Sub PopulateSheeting()

        Try

            Dim allSheetCmd As OleDbCommand = New OleDbCommand _
                                    ("SELECT sheetNum, sheetDesc FROM sheetingType ORDER By sheetNum", mhsConn)

            ' Open the connection, execute the command
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            allSheetDA = New OleDbDataAdapter(allSheetCmd)

            ' Instantiate DataSet object
            allSheetDS = New DataSet()

            ' Fill DataSet
            allSheetDA.Fill(allSheetDS, "sheetingType")

            ' Fill the DataTable object with data
            allSheetDT = allSheetDS.Tables("sheetingType")

            ' Set the DataView object to the DataSet object
            allSheetDV = New DataView(allSheetDS.Tables("sheetingType"))

            ' Close the connection
            mhsConn.Close()



            '...............DICTIONARY..............

            ' Add "Select" at Item(0)
            Me.dctSheeting.Add("Select", String.Empty)

            ' Iterate through DataTable and add each row 
            ' to the Dictionary
            For Each row As DataRow In allSheetDT.Rows
                ' Add Key/Value to the Dictionary
                dctSheeting.Add(row.Item(0).ToString, row.Item(1).ToString)
            Next


            RemoveHandler Me.cmbSheetingCode.SelectedIndexChanged, AddressOf cmbSheetingCode_SelectedIndexChanged

            ' Create list of The Key's of the Dictionary (sheeting description, in this case)
            Dim lstSheeting As New List(Of String)(dctSheeting.Keys)
            Me.cmbSheetingCode.DataSource = lstSheeting

            AddHandler Me.cmbSheetingCode.SelectedIndexChanged, AddressOf cmbSheetingCode_SelectedIndexChanged



        Catch ex As Exception




        End Try




    End Sub

    Private Sub EnableFields()


        Me.cmbSheetingCode.Enabled = True
        Me.txtCode.ReadOnly = False
        Me.txtRollQty.ReadOnly = False
        Me.txtRollWidth.ReadOnly = False
        Me.txtRollLength.ReadOnly = False
        Me.txtPO.ReadOnly = False
        Me.txtLot.ReadOnly = False
        Me.txtDrum.ReadOnly = False
        Me.txtInvoice.ReadOnly = False

        Me.txtCarrier.ReadOnly = False
        Me.ckbDepleted.Enabled = True

        Me.eDtpShipDate.Enabled = True
        Me.eDtpRecvDate.Enabled = True

        Me.btnSaveChanges.Enabled = True

        Me.dgvSheetingListing.ReadOnly = False

        Me.cmbSheetingCode.Select()

        Me.ToolStripStatusLabel2.Text = "Edit-MODE now enabled."


    End Sub

    Private Sub DisableFields()

        Me.cmbSheetingCode.Enabled = False
        Me.cmbSheetingCode.SelectedIndex = 0
        Me.txtCode.ReadOnly = True
        Me.txtRollQty.ReadOnly = True
        Me.txtRollWidth.ReadOnly = True
        Me.txtRollLength.ReadOnly = True
        Me.txtPO.ReadOnly = True
        Me.txtLot.ReadOnly = True
        Me.txtDrum.ReadOnly = True
        Me.txtInvoice.ReadOnly = True
        Me.txtCarrier.ReadOnly = True
        Me.ckbDepleted.Enabled = False

        Me.eDtpShipDate.Enabled = False
        Me.eDtpRecvDate.Enabled = False

        Me.btnSaveChanges.Enabled = False

        Me.dgvSheetingListing.ReadOnly = True

    End Sub

    Private Sub updateDb()

        Try

            dgvSheetingListing_SelectionChanged(Nothing, Nothing)

            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvSheetingListing.EndEdit()
            Me.invSheetDA.Update(Me.invSheetDS.Tables("tblSheetingDetails"))

            Me.ToolStripStatusLabel2.Text = "Sheeting Inventory Updated"

            DisableFields()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub VisualSheetingColor(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles txtCode.TextChanged


        Try

            ' Add the sheeting description from the Dictionary
            ' to the textBox
            Me.lblSheeting.Text = Me.dctSheeting.Item(Me.txtCode.Text)


            Select Case txtCode.Text
                Case "3930"
                    Me.picSheetingDesc.BackColor = Color.White
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.White

                Case "3981"
                    Me.picSheetingDesc.BackColor = Color.Yellow
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.Yellow

                Case "3983"
                    Me.picSheetingDesc.BackColor = Color.YellowGreen
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.YellowGreen

                Case "3990"
                    Me.picSheetingDesc.BackColor = Color.White
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.White

                Case "3932"
                    Me.picSheetingDesc.BackColor = Color.Red
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Red

                Case "3935"
                    Me.picSheetingDesc.BackColor = Color.Blue
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Blue

                Case "3937"
                    Me.picSheetingDesc.BackColor = Color.Green
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Green

                Case "3939"
                    Me.picSheetingDesc.BackColor = Color.Brown
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Brown

                Case "3924"
                    Me.picSheetingDesc.BackColor = Color.Orange
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.Orange

                Case "1172C"
                    Me.picSheetingDesc.BackColor = Color.Red
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Red

                Case "1175C"
                    Me.picSheetingDesc.BackColor = Color.Blue
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Blue

                Case "1177C"
                    Me.picSheetingDesc.BackColor = Color.Green
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Green

                Case "3650-12"
                    Me.picSheetingDesc.BackColor = Color.Black
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Black

                Case "3997"
                    Me.picSheetingDesc.BackColor = Color.Green
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Green


                Case "4090"
                    Me.picSheetingDesc.BackColor = Color.White
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.White

                Case "4081"
                    Me.picSheetingDesc.BackColor = Color.Yellow
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.Yellow

                Case "4083"
                    Me.picSheetingDesc.BackColor = Color.YellowGreen
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.YellowGreen


                Case Else
                    Me.picSheetingDesc.BackColor = Color.Transparent
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Transparent


            End Select
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "VisualSheetingColor()")
        End Try


    End Sub

    Public Function CalcSft() As String

        Dim sFtString As String = Nothing

        Try

            Dim lFt As Double = CDbl(CDbl(Me.txtRollLength.Text) * 3)
            Dim inchesToFeet As Double = CDbl(Me.txtRollWidth.Text) / 12
            Dim sFt As Double = inchesToFeet * lFt
            Dim totSft As Double = sFt * CDbl(Me.txtRollQty.Text)

            sFtString = totSft & " sFt"

            Return sFtString


        Catch ex As Exception

            Return String.Empty

        End Try



    End Function

    Public Sub DisplaySqrFootage(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles txtRollQty.TextChanged, _
                        txtRollWidth.TextChanged, _
                        txtRollLength.TextChanged

        Me.lblSqrFt.Text = CalcSft()


    End Sub

    Private Sub ResetToDefaultState(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles MyBase.Load, _
                        btnRefresh.Click


        FillDGVandBindFields()
        PopulateSheeting()
        Me.cmbEXTTOFFields.SelectedIndex = 5
        DisableFields()


    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbEXTTOFFields.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field

                Case 0 ' rollWidth
                    fieldName = "rollWidth"

                Case 1 ' rollLength
                    fieldName = "rollLength"

                Case 2 ' code
                    fieldName = "code"

                Case 3 ' rollQty
                    fieldName = "rollQty"

                Case 4 ' po
                    fieldName = "po"

                Case 5 ' lot
                    fieldName = "lot"

                Case 6 ' drum
                    fieldName = "drum"

                Case 7 ' invoice
                    fieldName = "invoice"

                Case 8 ' carrier
                    fieldName = "carrier"


            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload

                Select Case fieldName

                    Case Is = "rollWidth"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "] Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"

                    Case Is = "rollLength"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"

                    Case Is = "code"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "rollQty"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "po"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "lot"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "drum"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "invoice"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "carrier"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Else

                        Me.invSheetDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                        Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"

                End Select

            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message, "exception from sortLike sub")
            Me.invSheetDV.RowFilter = Nothing

            'Me.ToolStripStatusLabel2.Text = "Extruded T/O >>  (" & Me.invSheetDV.Count & " Records)"
            'Me.txtCriteria.Clear()

        End Try

    End Sub




#End Region



#Region " Event Procedures"

    Private Sub frmInvSheetingListing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case invSheetDS.HasChanges

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

    Private Sub frmInvSheetingListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        '  SEE:  ResetToDefaultState() Method

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim sheetInv As New frmInvNewSheeting
        sheetInv.MdiParent = signINMain1
        sheetInv.Show()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EnableFields()

    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        updateDb()
    End Sub

    Private Sub dgvSheetingListing_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSheetingListing.DoubleClick


        'If isInquiry Then Me.btnOK_Click(Nothing, Nothing)



    End Sub

    Private Sub dgvSheetingListing_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSheetingListing.SelectionChanged


        Try

            Dim sColor As String = Me.dgvSheetingListing.CurrentRow.Cells.Item(3).Value.ToString

            Select Case sColor
                Case "3930"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                Case "3981"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Yellow
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                Case "3983"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.YellowGreen
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                Case "3990"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                Case "3932"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Red
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "3935"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Blue
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "3937"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Green
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "3939"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Brown
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "3924"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Orange
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                Case "1172C"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Red
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "1175C"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Blue
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "1177C"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Green
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "3650-12"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Black
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                Case "3997"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Green
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White



                Case "4090"

                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    'Me.picSheetingDesc.BackColor = Color.White
                    'Me.lblSheeting.ForeColor = Color.Black
                    'Me.lblSheeting.BackColor = Color.White

                Case "4081"

                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Yellow
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black


                    'Me.picSheetingDesc.BackColor = Color.Yellow
                    'Me.lblSheeting.ForeColor = Color.Black
                    'Me.lblSheeting.BackColor = Color.Yellow

                Case "4083"

                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.YellowGreen
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    'Me.picSheetingDesc.BackColor = Color.YellowGreen
                    'Me.lblSheeting.ForeColor = Color.Black
                    'Me.lblSheeting.BackColor = Color.YellowGreen



                Case Else
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Gray
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.LightGray

            End Select
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "VisualSheetingColor()")

        End Try




    End Sub

    Private Sub ckbDepleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDepleted.CheckedChanged

        Select Case Me.ckbDepleted.Checked

            Case True
                Me.ckbDepleted.ForeColor = Color.Red

            Case False
                Me.ckbDepleted.ForeColor = Color.DarkGreen

        End Select

    End Sub

    Private Sub cmbSheetingCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSheetingCode.SelectedIndexChanged

        ' If the "Enable" button has been clicked and
        ' user has entered Edit mode then allow the
        ' text from cmbSheetingCode to be transferred to txtCode
        If Me.cmbSheetingCode.Enabled Then

            Me.txtCode.Text = Me.cmbSheetingCode.Text

        End If


    End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
        sortLike(Me.txtCriteria.Text)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If isInquiry Then

            ' Assign current rows PK to the ReturnID property via the _ReturnID variable
            _ReturnID = CInt(Me.dgvSheetingListing.CurrentRow.Cells.Item(0).Value)

            _ReturnRow = Me.dgvSheetingListing.CurrentRow

            ' Close form and return OK to calling form
            Me.DialogResult = Windows.Forms.DialogResult.OK


        End If




    End Sub


#End Region


















    
End Class