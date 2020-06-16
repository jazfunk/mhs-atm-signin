Option Strict On

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources




Public Class frmShipperList




#Region " Database Communication"


    '  (db1.mdb) connection
	Dim objConn As New OleDbConnection(My.Settings.SignINconn)

    Dim shipperDA As OleDbDataAdapter
    Dim shipperDS As DataSet
    Dim shipperDV As DataView
    Dim shipperDT As DataTable



#End Region



#Region " Event Handlers"

    Private Sub frmShipperList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmShipperList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        fillDGV()
		Me.cmbShippersFields.SelectedIndex = 1
        Me.txtCriteria.Focus()

        Me.txtCriteria.Select()

    End Sub

    Private Sub dgvShipperList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipperList.CellDoubleClick
        Dim i As Integer = CInt(Me.dgvShipperList.CurrentRow.Cells.Item(0).Value)
        openShipper(i)

    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        updateDb()
    End Sub

    Private Sub dgvShipperList_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvShipperList.UserDeletingRow
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

    Private Sub txtCriteria_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
        sortLike(Me.txtCriteria.Text)
    End Sub

#End Region




#Region " Subs and Functions"

    Private Sub fillDGV()

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblShippers WHERE assigned = TRUE ORDER BY shipperID DESC", objConn)


        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        shipperDA = New OleDbDataAdapter(cmd)


        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim shipperBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(shipperDA)

        ' Instantiate DataSet object
        shipperDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        shipperDA.Fill(shipperDS, "tblShippers")

        ' Set the Dataview object to the Dataset object
        shipperDV = New DataView(shipperDS.Tables("tblShippers"))


        '  Close the connection
        objConn.Close()

        '  Assign shipper table to the dataGridView object in the designer
        Me.dgvShipperList.DataSource = shipperDV
        'Me.dgvShipperList.DataSource = shipperDS.Tables("tblShippers")


        ' Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        Me.dgvShipperList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        ' Declare and set the log header alignment property
        Dim objAlignMidcellStyle As New DataGridViewCellStyle()
        objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim objBoldFont As New DataGridViewCellStyle()

        ' Declare and set the dates right alignment property
        Dim objRightAlignMidcellStyle As New DataGridViewCellStyle()
        objRightAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        '  shipperID field
        Me.dgvShipperList.Columns("shipperID").ReadOnly = True
        Me.dgvShipperList.Columns("shipperID").Width = 50
        Me.dgvShipperList.Columns("shipperID").HeaderText = "Shipper"
        Me.dgvShipperList.Columns("shipperID").DefaultCellStyle = objAlignMidcellStyle
        Me.dgvShipperList.Columns("shipperID").DefaultCellStyle.ForeColor = Color.Navy
        Me.dgvShipperList.Columns("shipperID").DefaultCellStyle.Font = New Font(Control.DefaultFont, FontStyle.Bold)


        '  mhsJob field
        Me.dgvShipperList.Columns("mhsJob").Width = 65
        Me.dgvShipperList.Columns("mhsJob").HeaderText = "Job"

        '  via field
        Me.dgvShipperList.Columns("via").Width = 130
        Me.dgvShipperList.Columns("via").HeaderText = "Via"

        ' shipped field
        Me.dgvShipperList.Columns("shipped").Width = 35
        Me.dgvShipperList.Columns("shipped").DefaultCellStyle = objAlignMidcellStyle
        Me.dgvShipperList.Columns("shipped").HeaderText = "Shpd"

        ' shipDate field
        Me.dgvShipperList.Columns("shipDate").Width = 75
        Me.dgvShipperList.Columns("shipDate").DefaultCellStyle = objRightAlignMidcellStyle
        Me.dgvShipperList.Columns("shipDate").HeaderText = "Ship Date"

        ' recvdBy field
        Me.dgvShipperList.Columns("recvdBy").Width = 110
        Me.dgvShipperList.Columns("recvdBy").HeaderText = "Recvd By"

        ' entryDate field
        Me.dgvShipperList.Columns("entryDate").ReadOnly = True
        Me.dgvShipperList.Columns("entryDate").Width = 75
        Me.dgvShipperList.Columns("entryDate").DefaultCellStyle = objRightAlignMidcellStyle
        Me.dgvShipperList.Columns("entryDate").HeaderText = "Entry Date"

        ' comments field
        Me.dgvShipperList.Columns("comments").Width = 135
        Me.dgvShipperList.Columns("comments").HeaderText = "Comments"

        ' Hide assigned field
        Me.dgvShipperList.Columns("assigned").Visible = False

        ' poNum field
        Me.dgvShipperList.Columns("poNum").Width = 45
        Me.dgvShipperList.Columns("poNum").HeaderText = "PO#"

        Me.ToolStripStatusLabel1.Text = "Double-click a Shipper to view or add items."

    End Sub

    Private Sub openShipper(ByVal sID As Integer)

        Dim thisShipper As New frmAddShipperItems(CStr(sID))
        thisShipper.MdiParent = signINver2.signINMain1
        thisShipper.Show()

    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvShipperList.EndEdit()
            Me.shipperDA.Update(Me.shipperDS.Tables("tblShippers"))

            Dim i As Integer = CInt(Me.dgvShipperList.CurrentRow.Cells.Item(0).Value)

            Me.ToolStripStatusLabel1.Text = "Shipper " & i & " Updated"

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbShippersFields.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field

                Case 0 ' shipperID
                    fieldName = "shipperID"

                Case 1 ' mhsJob
                    fieldName = "mhsJob"

                Case 2 ' via
                    fieldName = "via"

                Case 3 ' recvdBy
                    fieldName = "recvdBy"

                Case 4 ' comments
                    fieldName = "comments"

                Case 5 ' poNum
                    fieldName = "poNum"

            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload

                Select Case fieldName
                    Case Is = "shipperID"
                        Dim str2 As Double = CDbl(searchSTR)

                        Me.shipperDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "Filter On:  [" & fieldName & "] Search:  " & searchSTR

                    Case Else

                        Me.shipperDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                        Me.ToolStripStatusLabel1.Text = "Filter On:  [" & fieldName & "] Search:  " & searchSTR

                End Select

            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message, "exception from sortLike sub")

        End Try

    End Sub


#End Region









End Class