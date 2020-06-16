Option Strict On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources




Public Class frmInvNewSheeting


#Region " Class-level variables, etc."



    Private dctSheeting As New Dictionary(Of String, String)

    Dim rolls As Double
    Dim rWidth As Double
    Dim rLength As Double


#End Region


#Region " Database Communication"

    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' Sheeting
    Dim allSheetDA As OleDbDataAdapter
    Dim allSheetDS As DataSet
    Dim allSheetDV As DataView
    Dim allSheetDT As DataTable



    ' Connection to materialsInventory.mdb
	'Dim invConn As New OleDbConnection(My.Settings.INVconn)

    


#End Region


#Region " Functions & Methods"

    Public Sub ResetAfterAdd()

        Try
            Me.cmbSheetingCode.SelectedIndex = 0
            
            Me.txtRollQty.Clear()

            Me.txtRollWidth.Clear()
            Me.txtRollLength.Clear()

            Me.txtPO.Clear()
            Me.txtLot.Clear()
            Me.txtDrum.Clear()
            Me.txtInvoice.Clear()

            Me.eDtpShipDate.Value = Today
            Me.eDtpRecvDate.Value = Today

            Me.cmbCarrier.SelectedIndex = 0

            Me.btnAdd.Enabled = False

            Me.cmbSheetingCode.Select()

            Me.ToolStripStatusLabel2.Text = "Ready"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.ToolStripStatusLabel2.Text = "Error in ResetAfterAdd() Method.  Error Details:  " & ex.Message

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

            ' Create list of The Key's of the Dictionary (sheeting description, in this case)
            Dim lstSheeting As New List(Of String)(dctSheeting.Keys)
            Me.cmbSheetingCode.DataSource = lstSheeting




        Catch ex As Exception




        End Try




    End Sub

    Private Sub VisualSheetingColor(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbSheetingCode.SelectedIndexChanged


        Try

            ' Add the sheeting description from the Dictionary
            ' to the textBox
            Me.lblSheeting.Text = Me.dctSheeting.Item(Me.cmbSheetingCode.Text)

            Select Case cmbSheetingCode.Text
                Case "3930", "3990", "4090"
                    Me.picSheetingDesc.BackColor = Color.White
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.White

                Case "3981", "4081", "3931"
                    Me.picSheetingDesc.BackColor = Color.Yellow
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.Yellow

                Case "3983", "4083"
                    Me.picSheetingDesc.BackColor = Color.YellowGreen
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.YellowGreen

                Case "3932", "3992", "4092", "1172C"
                    Me.picSheetingDesc.BackColor = Color.Red
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Red

                Case "3935", "3995", "4095", "1175C"
                    Me.picSheetingDesc.BackColor = Color.Blue
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Blue

                Case "3937", "3997", "4097", "1177C"
                    Me.picSheetingDesc.BackColor = Color.Green
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Green

                Case "3939", "4039", "1179C"
                    Me.picSheetingDesc.BackColor = Color.Brown
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Brown

                Case "3924", "4024"
                    Me.picSheetingDesc.BackColor = Color.Orange
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.Orange

                Case "3650-12"
                    Me.picSheetingDesc.BackColor = Color.Black
                    Me.lblSheeting.ForeColor = Color.White
                    Me.lblSheeting.BackColor = Color.Black

                Case Else
                    Me.picSheetingDesc.BackColor = Color.Transparent
                    Me.lblSheeting.ForeColor = Color.Black
                    Me.lblSheeting.BackColor = Color.Transparent


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VisualSheetingColor()")
        End Try


    End Sub

    Private Sub ValidateInventoryValues()




        ' Sheeting Code
        If Me.cmbSheetingCode.SelectedIndex = 0 Then

            MessageBox.Show("You must select sheeting")

            Exit Sub

        End If




        ' rollQty, rollWidth, rollLength
        Try

            rolls = CDbl(Me.txtRollQty.Text.Trim)
            rWidth = CDbl(Me.txtRollWidth.Text.Trim)
            rLength = CDbl(Me.txtRollLength.Text.Trim)

        Catch ex As Exception

            MessageBox.Show("You must select roll quatity," & vbCrLf & _
                            "roll width, and roll length")

            Exit Sub

        End Try


        '  PO#
        If Me.txtPO.Text.Trim = String.Empty Then

            MessageBox.Show("You must include the purchase order # used for this roll")

            Exit Sub

        End If



        '  Lot#
        If Me.txtLot.Text.Trim = String.Empty Then

            MessageBox.Show("You must include Lot #")

            Exit Sub

        End If

        '  Drum#
        If Me.txtDrum.Text.Trim = String.Empty Then

            MessageBox.Show("You must include Drum #")

            Exit Sub

        End If



        '  Invoice#
        If Me.txtInvoice.Text.Trim = String.Empty Then

            MessageBox.Show("You must include the invoice #")

            Exit Sub

        End If


        '  Ship Date
        If Me.eDtpShipDate.Value = Today Then

            MessageBox.Show("If this shipped today then you could not have received it today")

            Exit Sub

        End If


        If Me.cmbCarrier.SelectedIndex = 0 Then

            MessageBox.Show("You must select a shipping carrier")

            Exit Sub


        End If


        AddNewSheetingInventory()




    End Sub

    Private Sub AddNewSheetingInventory()


        Try
            ' Connection to materialsInventory.mdb
			Using connection As New OleDbConnection(My.Settings.INVconn)

				Using command As New OleDbCommand("INSERT Into tblSheetingDetails " & _
												  "(rollWidth, " & _
												  "rollLength, " & _
												  "code, " & _
												  "rollQty, " & _
												  "po, " & _
												  "lot, " & _
												  "drum, " & _
												  "invoice, " & _
												  "shipDate, " & _
												  "recvDate, " & _
												  "carrier) " & _
												  "VALUES(@rollWidth," & _
												  "@rollLength," & _
												  "@code," & _
												  "@rollQty," & _
												  "@po," & _
												  "@lot," & _
												  "@drum," & _
												  "@invoice," & _
												  "@shipDate," & _
												  "@recvDate," & _
												  "@carrier)", connection)

					command.Parameters.AddWithValue("@rollWidth", Me.rWidth)
					command.Parameters.AddWithValue("@rollLength", Me.rLength)
					command.Parameters.AddWithValue("@code", Me.cmbSheetingCode.Text)
					command.Parameters.AddWithValue("@rollQty", Me.rolls)
					command.Parameters.AddWithValue("@po", Me.txtPO.Text.Trim)
					command.Parameters.AddWithValue("@lot", Me.txtLot.Text.Trim)
					command.Parameters.AddWithValue("@drum", Me.txtDrum.Text.Trim)
					command.Parameters.AddWithValue("@invoice", Me.txtInvoice.Text.Trim)
					command.Parameters.AddWithValue("@shipDate", Me.eDtpShipDate.Value)
					command.Parameters.AddWithValue("@recvDate", Me.eDtpRecvDate.Value)
					command.Parameters.AddWithValue("@carrier", Me.cmbCarrier.Text)

					connection.Open()

					command.ExecuteNonQuery()

					Me.ToolStripStatusLabel2.Text = "Sheeting inventory added"

					Dim result As DialogResult = MessageBox.Show(Me.txtRollWidth.Text & """ x " & _
																 Me.txtRollLength.Text & " yds, " & _
																 Me.cmbSheetingCode.Text & _
																 " (" & Me.lblSheeting.Text & ") added to inventory." & vbCrLf & _
																 vbCrLf & _
																 "Enter additional sheeting inventory items?", _
																 "Inventory", _
																 MessageBoxButtons.YesNo, _
																 MessageBoxIcon.Question)



					Select Case result

						Case Windows.Forms.DialogResult.Yes

							ResetAfterAdd()

						Case Windows.Forms.DialogResult.No

							' Close form
							Me.Close()

					End Select

				End Using

			End Using



        Catch ex As Exception

            Me.ToolStripStatusLabel2.Text = "Sheeting inventory added"
            MessageBox.Show("Inventory not added!" & _
                            vbCrLf & _
                            ex.Message, "I do not compute!", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)


        End Try



    End Sub


#End Region


#Region " Event Handlers"

    Private Sub frmInvNewSheeting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


        Dim saveResult As DialogResult

        saveResult = MessageBox.Show("Do you want to exit?", _
                                     "Close form?", _
                                     MessageBoxButtons.OKCancel, _
                                     MessageBoxIcon.Question, _
                                     MessageBoxDefaultButton.Button1)

        Select Case saveResult

            Case Windows.Forms.DialogResult.OK
                ' Close the form
                e.Cancel = False

            Case DialogResult.Cancel
                ' Cancel the form closing
                e.Cancel = True
        End Select

    End Sub

    Private Sub frmInvNewSheeting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateSheeting()
        ResetAfterAdd()



    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click


        Me.Close()


    End Sub

    Private Sub cmbSheetingCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSheetingCode.SelectedIndexChanged

        Me.btnAdd.Enabled = True

    End Sub

    Private Sub txtRollQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRollQty.TextChanged

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        ValidateInventoryValues()


    End Sub

#End Region









End Class