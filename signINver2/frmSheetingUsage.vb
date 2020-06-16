Option Strict On
Option Explicit On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources







Public Class frmSheetingUsage




#Region " Class-Level Declarations"

    Private dctSheeting As New Dictionary(Of String, String)





#End Region





#Region " Database Communication"


    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)


    ' Connection to materialsInventory.mdb
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

            '' Create list of The Keys's of the Dictionary (sheeting code, in this case)
            'Dim lstSheeting As New List(Of String)(dctSheeting.Keys)
            'Me.cmbSheetingCode.DataSource = lstSheeting




        Catch ex As Exception




        End Try




    End Sub

    Private Sub FillDGV()

        Try

            '  connection to database
			Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
													   "ID, " & _
													   "rollWidth, " & _
													   "rollLength, " & _
													   "code, " & _
													   "lot, " & _
													   "drum, " & _
													   "depleted " & _
													   "FROM tblSheetingDetails " & _
													   "WHERE depleted = False " & _
													   "ORDER By rollWidth DESC, " & _
													   "code DESC", invConn1)


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

            '' Set the DataView object to the DataSet object
            'invSheetDV = New DataView(invSheetDS.Tables("tblSheetingDetails"))


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

                .DataSource = invSheetDT

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

                ' lot field
                .Columns(4).HeaderText = "Lot#"
                .Columns(4).Width = 70
                .Columns(4).DefaultCellStyle = objAlignMidcellStyle

                ' drum field
                .Columns(5).HeaderText = "Drum#"
                .Columns(5).DefaultCellStyle = objAlignRightcellStyle
                .Columns(5).Width = 50

                ' depleted field
                .Columns(6).Visible = False
                '.Columns(6).HeaderText = "Depleted"
                '.Columns(6).Width = 55


            End With

            ''Clear Databindings
            'Me.txtRollWidth.DataBindings.Clear()
            'Me.txtRollLength.DataBindings.Clear()
            'Me.txtCode.DataBindings.Clear()
            'Me.txtRollQty.DataBindings.Clear()
            'Me.txtPO.DataBindings.Clear()
            'Me.txtLot.DataBindings.Clear()
            'Me.txtDrum.DataBindings.Clear()
            'Me.txtInvoice.DataBindings.Clear()
            'Me.eDtpShipDate.DataBindings.Clear()
            'Me.eDtpRecvDate.DataBindings.Clear()
            'Me.txtCarrier.DataBindings.Clear()
            'Me.ckbDepleted.DataBindings.Clear()


            '' Add Databindings
            'Me.txtRollWidth.DataBindings.Add("Text", invSheetDV, "rollWidth")
            'Me.txtRollLength.DataBindings.Add("Text", invSheetDV, "rollLength")
            'Me.txtCode.DataBindings.Add("Text", invSheetDV, "code")
            'Me.txtRollQty.DataBindings.Add("Text", invSheetDV, "rollQty")
            'Me.txtPO.DataBindings.Add("Text", invSheetDV, "po")
            'Me.txtLot.DataBindings.Add("Text", invSheetDV, "lot")
            'Me.txtDrum.DataBindings.Add("Text", invSheetDV, "drum")
            'Me.txtInvoice.DataBindings.Add("Text", invSheetDV, "invoice")
            'Me.eDtpShipDate.DataBindings.Add("Text", invSheetDV, "shipDate")
            'Me.eDtpRecvDate.DataBindings.Add("Text", invSheetDV, "recvDate")
            'Me.txtCarrier.DataBindings.Add("Text", invSheetDV, "carrier")
            'Me.ckbDepleted.DataBindings.Add("Checked", invSheetDV, "depleted")

            '' Display message
            'Me.ToolStripStatusLabel2.Text = Me.invSheetDV.Count & " Sheeting Inventory items"


        Catch ex As Exception

            ' Display message
            'Me.ToolStripStatusLabel2.Text = "Error!"
            MessageBox.Show(ex.Message, "FillDGV()")


        End Try

    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbFieldToFilter.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field

                Case 0 ' rollWidth
                    fieldName = "rollWidth"

                Case 1 ' code
                    fieldName = "code"

                Case 2 ' lot
                    fieldName = "lot"

                Case 3 ' drum
                    fieldName = "drum"

            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload

                Select Case fieldName

                    Case Is = "rollWidth"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        'Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "] Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"

                        'Case Is = "rollLength"

                        '    Dim str2 As Double = CDbl(searchSTR)

                        '    Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        '    'Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"

                    Case Is = "code"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        'Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                        'Case Is = "rollQty"

                        '    Dim str2 As Double = CDbl(searchSTR)

                        '    Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        '    Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                        'Case Is = "po"

                        '    'Dim str2 As Double = CDbl(searchSTR)

                        '    Me.invSheetDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        '    Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "lot"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        'Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"


                    Case Is = "drum"

                        'Dim str2 As Double = CDbl(searchSTR)

                        Me.invSheetDT.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        'Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"



                    Case Else

                        Me.invSheetDT.DefaultView.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                        'Me.ToolStripStatusLabel2.Text = "Sheeting Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.invSheetDV.Count & " Records)"

                End Select

            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message, "exception from sortLike sub")
            Me.invSheetDT.DefaultView.RowFilter = Nothing

            'Me.ToolStripStatusLabel2.Text = "Extruded T/O >>  (" & Me.invSheetDV.Count & " Records)"
            'Me.txtCriteria.Clear()

        End Try

    End Sub


    Private Sub InsertUsage()

        Try


			Using command As New OleDbCommand("INSERT INTO tblSheetingInv (detailID, usageLF, entryDate, userID) VALUES (@detailID, @usage, Now(), @userID)", invConn1)

				Dim sheetID As Integer = CInt(Me.dgvSheetingListing.CurrentRow.Cells.Item(0).Value)
				Dim lftUsed As Double = CDbl(Me.txtUsage.Text)


				command.Parameters.AddWithValue("@detailID", sheetID)
				command.Parameters.AddWithValue("@usage", lftUsed)
				command.Parameters.AddWithValue("@userID", My.Settings.userID)


				invConn1.Open()
				command.ExecuteNonQuery()
				invConn1.Close()

				MessageBox.Show("Entered successfully", "InsertUsage()")



			End Using


        Catch ex As Exception

			invConn1.Close()
            MessageBox.Show(ex.Message, "InsertUsage()")

        End Try



    End Sub


#End Region




#Region " Event Handlers"

    Private Sub frmSheetingUsage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateSheeting()
        FillDGV()

        Me.cmbFieldToFilter.SelectedIndex = 2   '  Default selection =  Lot #

        Me.txtCriteria.SelectAll()




    End Sub

    'Private Sub VisualSheetingColor(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    '                    Handles cmbSheetingCode.SelectedIndexChanged, cmbSheetingCode.TextChanged


    '    Try

    '        ' Add the sheeting description from the Dictionary
    '        ' to the textBox
    '        Try
    '            Me.lblSheetingColor.Text = Me.dctSheeting.Item(Me.cmbSheetingCode.Text)
    '        Catch ex As Exception

    '        End Try

    '        Select Case cmbSheetingCode.Text
    '            Case "3930"
    '                Me.PictureBoxSheeting.BackColor = Color.White
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.White

    '            Case "3981"
    '                Me.PictureBoxSheeting.BackColor = Color.Yellow
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.Yellow

    '            Case "3983"
    '                Me.PictureBoxSheeting.BackColor = Color.YellowGreen
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.YellowGreen

    '            Case "3990"
    '                Me.PictureBoxSheeting.BackColor = Color.White
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.White

    '            Case "3932"
    '                Me.PictureBoxSheeting.BackColor = Color.Red
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Red

    '            Case "3935"
    '                Me.PictureBoxSheeting.BackColor = Color.Blue
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Blue

    '            Case "3937"
    '                Me.PictureBoxSheeting.BackColor = Color.Green
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Green

    '            Case "3939"
    '                Me.PictureBoxSheeting.BackColor = Color.Brown
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Brown

    '            Case "3924"
    '                Me.PictureBoxSheeting.BackColor = Color.Orange
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.Orange

    '            Case "1172C"
    '                Me.PictureBoxSheeting.BackColor = Color.Red
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Red

    '            Case "1175C"
    '                Me.PictureBoxSheeting.BackColor = Color.Blue
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Blue

    '            Case "1177C"
    '                Me.PictureBoxSheeting.BackColor = Color.Green
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Green



    '            Case "3650-12"
    '                Me.PictureBoxSheeting.BackColor = Color.Black
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Black

    '            Case "3997"
    '                Me.PictureBoxSheeting.BackColor = Color.Green
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Green





    '            Case "4090"
    '                Me.PictureBoxSheeting.BackColor = Color.White
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.White

    '            Case "4081"
    '                Me.PictureBoxSheeting.BackColor = Color.Yellow
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.Yellow

    '            Case "4083"
    '                Me.PictureBoxSheeting.BackColor = Color.YellowGreen
    '                Me.lblSheetingColor.ForeColor = Color.Black
    '                Me.lblSheetingColor.BackColor = Color.YellowGreen




    '            Case Else
    '                Me.PictureBoxSheeting.BackColor = Color.Transparent
    '                Me.lblSheetingColor.ForeColor = Color.White
    '                Me.lblSheetingColor.BackColor = Color.Transparent


    '        End Select
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "VisualSheetingColor()")
    '    End Try


    'End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
        sortLike(Me.txtCriteria.Text)
    End Sub



    Private Sub dgvSheetingListing_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSheetingListing.SelectionChanged


        Try

            Dim sColor As String = Me.dgvSheetingListing.CurrentRow.Cells.Item(3).Value.ToString

            '  Used to display sheeting description
            Try
                Me.lblSheetingColor.Text = Me.dctSheeting.Item(sColor)
                
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "dgvSheetingListing_SelectionChanged()")

            End Try


            Select Case sColor
                Case "3930"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White

                Case "3981"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Yellow
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.Yellow
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Yellow


                Case "3983"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.YellowGreen
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.YellowGreen
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.YellowGreen


                Case "3990"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White


                Case "3932"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Red
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Red


                Case "3935"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Blue
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Blue


                Case "3937"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Green
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green


                Case "3939"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Brown
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Brown
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Brown


                Case "3924"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Orange
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.Orange
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Orange


                Case "1172C"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Red
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Red


                Case "1175C"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Blue
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Blue


                Case "1177C"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Green
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green


                Case "3650-12"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Black
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Black
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Black


                Case "3997"
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Green
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.White

                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green


                Case "4090"

                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Aquamarine
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White

                Case "4081"

                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Yellow
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.Yellow
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Yellow

                Case "4083"

                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.YellowGreen
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.Black

                    Me.PictureBoxSheeting.BackColor = Color.YellowGreen
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.YellowGreen




                Case Else
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionBackColor = Color.Gray
                    Me.dgvSheetingListing.DefaultCellStyle.SelectionForeColor = Color.LightGray




            End Select


        Catch ex As Exception
            'MessageBox.Show(ex.Message, "dgvSheetingListing_SelectionChanged()")
        End Try




    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        InsertUsage()



    End Sub




#End Region








    
End Class