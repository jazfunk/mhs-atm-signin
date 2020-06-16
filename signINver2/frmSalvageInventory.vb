Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources





Public Class frmSalvageInventory

#Region " Class-level declarations"


    Dim atmJobDA As OleDbDataAdapter
    Dim atmJobDS As DataSet
    Dim atmJobDV As DataView
    Dim atmJobDT As DataTable



#End Region



#Region " Database Communication"


    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    Dim salvageDA As OleDbDataAdapter
    Dim salvageDS As DataSet
    Dim salvageDV As DataView
    Dim salvageDT As DataTable




#End Region




#Region " Functions & Methods"


    Private Sub FillDGVandBindFields()

        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
                                                       "ID, " & _
                                                       "atmJob, " & _
                                                       "station, " & _
                                                       "type, " & _
                                                       "width, " & _
                                                       "height, " & _
                                                       "recvDate, " & _
                                                       "location, " & _
                                                       "reInstalled, " & _
                                                       "shipDate " & _
                                                       "FROM tblSalvageInventory " & _
                                                       "ORDER By atmJob DESC", mhsConn)


            ' Open connection to Db
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            salvageDA = New OleDbDataAdapter(cmd)

            mhsConn.Close()

            ' Initialize a new instance of the DataSet object
            salvageDS = New DataSet()

            ' Fill the DataSet object with Data
            salvageDA.Fill(salvageDS, "tblSalvageInventory")

            Dim salvageCB As New OleDbCommandBuilder(salvageDA)

            ' DataTable -   Fill the DataTable object with data
            salvageDT = salvageDS.Tables("tblSalvageInventory")

            ' Set the DataView object to the DataSet object
            salvageDV = New DataView(salvageDS.Tables("tblSalvageInventory"))


            ' Set Align-MiddleCenter object
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke


            With Me.dgvSalvageListing

                .DataSource = salvageDV

                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' ID field
                .Columns(0).Visible = False

                ' atmJob
                .Columns(1).HeaderText = "Job #"
                .Columns(1).Width = 65
                '.Columns(1).DefaultCellStyle = objAlignRightcellStyle
                .Columns(1).DefaultCellStyle.ForeColor = Color.Black
                .Columns(1).DefaultCellStyle.Font = New Font(dgvSalvageListing.Font, FontStyle.Bold)

                ' station
                .Columns(2).HeaderText = "Station"
                .Columns(2).Width = 65

                ' type
                .Columns(3).HeaderText = "Type"
                .Columns(3).Width = 65

                ' width
                .Columns(4).HeaderText = "Width"
                .Columns(4).DefaultCellStyle = objAlignRightcellStyle
                .Columns(4).Width = 55

                ' height
                .Columns(5).HeaderText = "Height"
                .Columns(5).DefaultCellStyle = objAlignRightcellStyle
                .Columns(5).Width = 55

                ' recvDate
                .Columns(6).HeaderText = "Recvd"
                .Columns(6).Width = 70
                .Columns(6).DefaultCellStyle = objAlignRightcellStyle

                ' location
                .Columns(7).HeaderText = "Location"
                .Columns(7).Width = 50

                ' reInstalled
                .Columns(8).HeaderText = "Out"
                .Columns(8).Width = 50

                ' shipDate field
                .Columns(9).HeaderText = "Ship Date"
                .Columns(9).DefaultCellStyle = objAlignRightcellStyle
                .Columns(9).Width = 70

            End With

            'Clear Databindings
            Me.txtAtmJob.DataBindings.Clear()
            Me.txtStation.DataBindings.Clear()
            Me.txtSignType.DataBindings.Clear()
            Me.txtSignWidth.DataBindings.Clear()
            Me.txtSignHeight.DataBindings.Clear()
            Me.eDtpRecvDate.DataBindings.Clear()
            Me.txtLocation.DataBindings.Clear()
            Me.ckbReInstalled.DataBindings.Clear()
            Me.eDtpShipDate.DataBindings.Clear()



            ' Add Databindings
            Me.txtAtmJob.DataBindings.Add("Text", salvageDV, "atmJob")
            Me.txtStation.DataBindings.Add("Text", salvageDV, "station")
            Me.txtSignType.DataBindings.Add("Text", salvageDV, "type")
            Me.txtSignWidth.DataBindings.Add("Text", salvageDV, "width")
            Me.txtSignHeight.DataBindings.Add("Text", salvageDV, "height")
            Me.eDtpRecvDate.DataBindings.Add("Text", salvageDV, "recvDate")
            Me.txtLocation.DataBindings.Add("Text", salvageDV, "location")
            Me.ckbReInstalled.DataBindings.Add("Checked", salvageDV, "reInstalled")
            Me.eDtpShipDate.DataBindings.Add("Text", salvageDV, "shipDate")

            ' Display message
            Me.ToolStripStatusLabel1.Text = Me.salvageDV.Count & " Salvaged Signs"


        Catch ex As Exception

            ' Display message
            Me.ToolStripStatusLabel1.Text = "Error!"
            MessageBox.Show(ex.Message, "FillDGVandBindFields()")


        End Try

    End Sub

    Private Sub showSignImage()

        Dim imageName As String = "Salvage\" & Me.txtAtmJob.Text & "\" & Me.txtAtmJob.Text & "_" & Me.txtStation.Text
        Dim viewImage As String = imageName & ".jpg"

        Try
            Me.picSign.Load(My.Resources.serverImgPath & viewImage)
        Catch ex As Exception
            Me.picSign.Image = My.Resources.none1
        End Try

    End Sub

    Private Sub UpdateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvSalvageListing.EndEdit()
            Me.salvageDA.Update(Me.salvageDS.Tables("tblSalvageInventory"))

            Me.ToolStripStatusLabel1.Text = "Records Updated"

            DisableFields()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub DisableFields()

        Try

            Me.txtAtmJob.ReadOnly = True
            Me.txtStation.ReadOnly = True
            Me.txtSignType.ReadOnly = True
            Me.cmbSignType.Enabled = False
            Me.txtSignWidth.ReadOnly = True
            Me.txtSignHeight.ReadOnly = True
            Me.eDtpRecvDate.Enabled = False
            Me.txtLocation.ReadOnly = True
            Me.ckbReInstalled.Enabled = False
            Me.eDtpShipDate.Enabled = False
            Me.dgvSalvageListing.ReadOnly = True
            Me.btnSaveChanges.Enabled = False




        Catch ex As Exception

        End Try

    End Sub

    Private Sub EnableFields()

        Try

            Me.txtAtmJob.ReadOnly = False
            Me.txtStation.ReadOnly = False
            Me.txtSignType.ReadOnly = False
            Me.cmbSignType.Enabled = True
            Me.txtSignWidth.ReadOnly = False
            Me.txtSignHeight.ReadOnly = False
            Me.eDtpRecvDate.Enabled = True
            Me.txtLocation.ReadOnly = False
            Me.ckbReInstalled.Enabled = True
            Me.eDtpShipDate.Enabled = True
            Me.dgvSalvageListing.ReadOnly = False
            Me.btnSaveChanges.Enabled = True



        Catch ex As Exception

        End Try


    End Sub

    Private Sub sortLike(ByVal searchSTR As String)

        Try

            Dim field As Integer = Me.cmbSalvageFields.SelectedIndex
            Dim fieldName As String = Nothing

            Select Case field

                Case 0
                    fieldName = "atmJob"

                Case 1
                    fieldName = "station"

                Case 2
                    fieldName = "type"

                Case 3
                    fieldName = "width"

                Case 4
                    fieldName = "height"

                Case 5
                    fieldName = "location"


            End Select

            If fieldName IsNot Nothing Then

                ' Sort DataView by overload

                Select Case fieldName

                    Case Is = "atmJob"

                        Me.salvageDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"

                    Case Is = "station"

                        Me.salvageDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"


                    Case Is = "type"

                        Me.salvageDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"


                    Case Is = "width"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.salvageDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "] Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"


                    Case Is = "height"

                        Dim str2 As Double = CDbl(searchSTR)

                        Me.salvageDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "] Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"

                    Case Is = "location"

                        Me.salvageDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, searchSTR)
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"


                    Case Else

                        Me.salvageDV.RowFilter = fieldName & " LIKE '*" & searchSTR & "*'"
                        Me.ToolStripStatusLabel1.Text = "Salvage Sign Inventory >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.salvageDV.Count & " Records)"

                End Select

            End If
        Catch ex As OleDbException

            'MessageBox.Show(ex.Message, "exception from sortLike sub")
            Me.salvageDV.RowFilter = Nothing

        End Try

    End Sub




#End Region




#Region " Event Procedures"

    Private Sub frmSalvageInventory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case salvageDS.HasChanges

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

    Private Sub frmSalvageInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillDGVandBindFields()

        DisableFields()

        Me.cmbSalvageFields.SelectedIndex = 0




    End Sub







    Private Sub txtStation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStation.TextChanged
        showSignImage()

    End Sub

    Private Sub cmbSignType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignType.SelectedIndexChanged

        Me.txtSignType.Text = Me.cmbSignType.Text

    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click

        updateDb()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EnableFields()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim newSign As New frmNewSalvageSign
        newSign.MdiParent = signINMain1
        newSign.Show()



    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        FillDGVandBindFields()

    End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged

        sortLike(Me.txtCriteria.Text)

    End Sub

#End Region


















End Class