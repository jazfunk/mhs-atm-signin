Option Strict On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources





Public Class frmPlywoodSheetingSizes

    Public Sub New(ByVal jn As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.mhsJob = jn

    End Sub




#Region " Class-level variables"

    Dim skip As Boolean

    Dim mhsJob As String
    Dim station As String
    Dim sheetWidth As Integer
    Dim sheetCode As String
    Dim estLFT As Double



#End Region


#Region " Database Communication"


    ' Connection to Action Traffic.mdb
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' MHS Jobs
    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
    Dim mhsJobDV As DataView
    Dim mhsJobDT As DataTable

    ' Plywood TakeOff
    Dim pwTOFDA As OleDbDataAdapter
    Dim pwTOFDS As DataSet
    Dim pwTOFDT As DataTable
    Dim pwTOFDV As DataView

    ' Sheeting
    Dim allSheetDA As OleDbDataAdapter
    Dim allSheetDS As DataSet
    Dim allSheetDV As DataView
    Dim allSheetDT As DataTable


#End Region




#Region " Methods and Functions"


    Private Sub VisualSheetingColor(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbSheetType.SelectedIndexChanged




        Try

            Select Case cmbSheetType.Text
                Case "3930"
                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetDesc.ForeColor = Color.Black
                    Me.lblSheetDesc.BackColor = Color.White

                Case "3981"
                    Me.PictureBoxSheeting.BackColor = Color.Yellow
                    Me.lblSheetDesc.ForeColor = Color.Black
                    Me.lblSheetDesc.BackColor = Color.Yellow

                Case "3983"
                    Me.PictureBoxSheeting.BackColor = Color.YellowGreen
                    Me.lblSheetDesc.ForeColor = Color.Black
                    Me.lblSheetDesc.BackColor = Color.YellowGreen

                Case "3990"
                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetDesc.ForeColor = Color.Black
                    Me.lblSheetDesc.BackColor = Color.White

                Case "3932"
                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Red

                Case "3935"
                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Blue

                Case "3937"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Green

                Case "3939"
                    Me.PictureBoxSheeting.BackColor = Color.Brown
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Brown

                Case "3924"
                    Me.PictureBoxSheeting.BackColor = Color.Orange
                    Me.lblSheetDesc.ForeColor = Color.Black
                    Me.lblSheetDesc.BackColor = Color.Orange

                Case "1172C"
                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Red

                Case "1175C"
                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Blue

                Case "1177C"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Green

                Case "3650-12"
                    Me.PictureBoxSheeting.BackColor = Color.Black
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Black

                Case "3997"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetDesc.ForeColor = Color.White
                    Me.lblSheetDesc.BackColor = Color.Green

                Case Else
                    Me.PictureBoxSheeting.BackColor = Color.Transparent
                    Me.lblSheetDesc.ForeColor = Color.Black
                    Me.lblSheetDesc.BackColor = Color.Transparent


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VisualSheetingColor()")
        End Try


    End Sub

    Public Sub imagePreview(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles dgvPLYTOF.SelectionChanged

        Try
            If My.Settings.serverPresent Then

                Dim viewImage As String = Me.txtStation.Text.Trim & ".jpg"

                Dim url As String = serverImgPath & Me.mhsJob & "\Plywood\" & viewImage

                Me.picSign.Load(url)

                skip = True

                Me.picSign.SizeMode = PictureBoxSizeMode.Zoom

            Else

                skip = False

            End If


        Catch ex1 As Exception

            'MessageBox.Show(ex1.Message, "imagePreview()")

            skip = False

        End Try

        
        If Not skip Then

            Try

                Dim viewImage As String = Me.txtSignCode.Text.Trim & ".jpg"
                Dim url As String = imgPath & viewImage

                Me.picSign.Load(url)
                Me.picSign.SizeMode = PictureBoxSizeMode.CenterImage

            Catch ex2 As Exception

                Me.picSign.SizeMode = PictureBoxSizeMode.CenterImage
                Me.picSign.Image = My.Resources.none1

            End Try

        End If

        skip = False

        Me.cmbSheetType.Text = Me.txtSheeting.Text

        ToggleAddButton(True)

        Try
            ChooseSheetWidth(CDbl(Me.txtSignWidth.Text), CDbl(Me.txtSignHeight.Text))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AddSheetingEstimate(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles btnAdd.Click

        ' Check for empty Run ID field and exit sub if so
        If Me.txtRunID.Text = String.Empty Then
            MessageBox.Show("You must designate a Run ID.", _
                            "I do not compute!", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.ToolStripStatusLabel1.Text = "Designate a Run ID before adding records."
            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor

        Try

            Me.station = Me.txtStation.Text.Trim

            ' Convert sheeting width to Type Integer
            Try
                Me.sheetWidth = CType(Me.cmbSizes.Text.Trim, Integer)
            Catch ex As Exception
                MessageBox.Show("You must select a sheeting width." & vbCrLf & ex.Message, _
                                "I do not compute!", _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)

                ToolStripStatusLabel1.Text = "Record not added! Sheeting Width not selected."
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try

            Me.sheetCode = Me.cmbSheetType.Text.Trim


            ' Convert estimated linear feet to Type Double 
            Try
                Me.estLFT = CDbl(Me.txtEstLFT.Text)
            Catch ex As Exception
                MessageBox.Show("You must estimate linear feet." & vbCrLf & ex.Message, _
                                "I do not compute!", _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)

                ToolStripStatusLabel1.Text = "Record not added!  Estimated linear feet not entered."
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End Try


            Dim objCommand As OleDbCommand = New OleDbCommand

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Set the OleDbCommand object properties
            objCommand.Connection = mhsConn
            objCommand.CommandText = _
                "INSERT INTO tblPlywoodSheetingSizes " & _
                "(runID, mhsJob, station, sheetWidth, sheetCode, estLFT, stationID) " & _
                "VALUES(@runID,@mhsJob,@station,@sheetWidth,@sheetCode,@estLFT, @stationID)"

            ' Add parameters for the placeholders in the SQL in the
            ' CommandText property
            objCommand.Parameters.AddWithValue("@runID", Me.txtRunID.Text.Trim)
            objCommand.Parameters.AddWithValue("@mhsJob", Me.mhsJob)
            objCommand.Parameters.AddWithValue("@station", Me.station)
            objCommand.Parameters.AddWithValue("@sheetWidth", Me.sheetWidth)
            objCommand.Parameters.AddWithValue("@sheetCode", Me.sheetCode)
            objCommand.Parameters.AddWithValue("@estLFT", Me.estLFT)
            objCommand.Parameters.AddWithValue("@stationID", CInt(Me.dgvPLYTOF.CurrentRow.Cells.Item(0).Value))




            ' Execute the OleDbCommand object to insert the new data
            Try
                objCommand.ExecuteNonQuery()

                ResetAfterAdd()

                ' Display a message that the record was added
                ToolStripStatusLabel1.Text = "(" & Me.station & ")  " & Me.estLFT.ToString & " linear feet of " & Me.sheetWidth.ToString & " inch " & Me.sheetCode & " added."

                Me.btnForward.Select()

            Catch OleDbExceptionErr As OleDbException

                MessageBox.Show(OleDbExceptionErr.Message)

                ToolStripStatusLabel1.Text = "Record not added!"

            End Try

            ' Close the connection
            mhsConn.Close()

        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub ChooseSheetWidth(ByVal sW As Double, ByVal sH As Double)

        Me.Cursor = Cursors.PanSouth

        Try

            Me.ckbTwoPartSign.Checked = False

            ' Choose smallest sign size parameter
            If sW < sH Then

                Select Case sW
                    Case 0 To 6
                        Me.cmbSizes.SelectedIndex = 0
                    Case 7 To 12
                        Me.cmbSizes.SelectedIndex = 1
                    Case 13 To 18
                        Me.cmbSizes.SelectedIndex = 2
                    Case 19 To 24
                        Me.cmbSizes.SelectedIndex = 3
                    Case 25 To 30
                        Me.cmbSizes.SelectedIndex = 4
                    Case 31 To 36
                        Me.cmbSizes.SelectedIndex = 5
                    Case 37 To 42
                        Me.cmbSizes.SelectedIndex = 6
                    Case 43 To 48
                        Me.cmbSizes.SelectedIndex = 7
                    Case Is > 48
                        Me.cmbSizes.SelectedIndex = -1
                        Me.ckbTwoPartSign.Checked = True
                        Me.ToolStripStatusLabel1.Text = "Using sign Width"
                End Select

                ' Convert inches to feet
                Dim sH_LinearFT As Double = sH / 12
                Me.txtEstLFT.Text = sH_LinearFT.ToString


            Else

                Select Case sH
                    Case 0 To 6
                        Me.cmbSizes.SelectedIndex = 0
                    Case 7 To 12
                        Me.cmbSizes.SelectedIndex = 1
                    Case 13 To 18
                        Me.cmbSizes.SelectedIndex = 2
                    Case 19 To 24
                        Me.cmbSizes.SelectedIndex = 3
                    Case 25 To 30
                        Me.cmbSizes.SelectedIndex = 4
                    Case 31 To 36
                        Me.cmbSizes.SelectedIndex = 5
                    Case 37 To 42
                        Me.cmbSizes.SelectedIndex = 6
                    Case 43 To 48
                        Me.cmbSizes.SelectedIndex = 7
                    Case Is > 48
                        Me.cmbSizes.SelectedIndex = -1
                        Me.ckbTwoPartSign.Checked = True
                        Me.ToolStripStatusLabel1.Text = "Using sign Width"
                End Select

                Dim sW_LInearFT As Double = sW / 12
                Me.txtEstLFT.Text = sW_LInearFT.ToString

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ChooseSheetingWidth()")
        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub ResetAfterAdd()


        Try


            Select Case Me.ckbTwoPartSign.Checked

                Case True

                    ' Do not reset fields
                    'MessageBox.Show("This sign size requires two sheeting entries", "Don't forget!")
                    Me.ToolStripStatusLabel1.Text = "This sign size requires two sheeting entries"
                    Me.cmbSizes.Select()
                    Me.ckbTwoPartSign.Checked = False

                Case False

                    ' Continue with resetting fields
                    Me.cmbSizes.SelectedIndex = -1
                    Me.txtEstLFT.Clear()

                    ToggleAddButton(False)

                    Me.ToolStripStatusLabel1.Text = "Ready"

            End Select


           

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToggleAddButton(ByVal x As Boolean)

        Select Case x
            Case True
                Me.btnAdd.Enabled = True
            Case False
                Me.btnAdd.Enabled = False
        End Select

    End Sub



#End Region


#Region " Event Procedures"


    Private Sub frmPlywoodSheetingSizes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        PopulatePWandFSSheeting()
        BindPWandFSSheeting()
        PopulateMHSJobs()
        BindMHSJobs()
        GetPlywoodTOF()

        Me.Text = "Plywood Sheeting Estimator" & "| " & Me.mhsJob & "  (" & Me.lblJobDesc.Text & ")"

        Me.btnForward.Select()

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        Try

            If Me.cmbStations.SelectedIndex >= 1 Then
                Me.cmbStations.SelectedIndex -= 1
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnBack_Click()")

        End Try

    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click


        Try

            Dim x As Integer = Me.cmbStations.SelectedIndex
            Dim y As Integer = Me.cmbStations.Items.Count - 1

            If x < y Then
                Me.cmbStations.SelectedIndex += 1
                Me.btnAdd.Select()
            End If

            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnForward_Click()")

        End Try

    End Sub



#End Region





#Region " Load Data"

    Public Sub PopulateMHSJobs()

        Try

            mhsJobDA = New OleDbDataAdapter("SELECT * FROM mhsJobs WHERE mhsJob = '" & Me.mhsJob & "'", mhsConn)

            ' Initialize a new instance of the DataSet object
            mhsJobDS = New DataSet()

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Fill DataSet
            mhsJobDA.Fill(mhsJobDS, "mhsJobs")

            ' Close the connection
            mhsConn.Close()

            ' DataTable -   Fill the DataTable object with data
            mhsJobDT = mhsJobDS.Tables("mhsJobs")

            ' Set the DataView object to the DataSet object
            mhsJobDV = New DataView(mhsJobDS.Tables("mhsJobs"))


        Catch ex As Exception

        End Try



    End Sub

    Private Sub BindMHSJobs()

        Try

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
            Me.lblCustJob.DataBindings.Add("Text", mhsJobDT, "custJob")
            Me.lblCust.DataBindings.Add("Text", mhsJobDT, "cust")
            Me.lblJobDesc.DataBindings.Add("Text", mhsJobDT, "jobDesc")
            Me.lblProjNum.DataBindings.Add("Text", mhsJobDT, "projNum")
            Me.lblStateNum.DataBindings.Add("Text", mhsJobDT, "stateNum")

            ' Format Date
            Me.lblCompDate.DataBindings.Add("Text", mhsJobDT, "compDate", True).FormatString = "MM/dd/yyyy"
            Me.ckbActive.DataBindings.Add("Checked", mhsJobDT, "Active")
            Me.ckbMMM.DataBindings.Add("Checked", mhsJobDT, "MMMDisc")


        Catch ex As Exception

        End Try




    End Sub


    Public Sub PopulatePWandFSSheeting()

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

        Catch ex As Exception

        End Try




    End Sub

    Private Sub BindPWandFSSheeting()

        Try

            With Me.cmbSheetType
                .DataSource = Nothing
                .DataSource = allSheetDT
                .DisplayMember = "sheetNum"
                .Text = "Select"
            End With

            ' Clear previous DataBindings
            Me.lblSheetDesc.DataBindings.Clear()

            ' Add DataBindings
            Me.lblSheetDesc.DataBindings.Add("Text", allSheetDT, "sheetDesc")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindPWandFSSheeting()")
        End Try

    End Sub


    Public Sub GetPlywoodTOF()

        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
                                                       "ID, " & _
                                                       "mhsJob, " & _
                                                       "station, " & _
                                                       "type, " & _
                                                       "code, " & _
                                                       "details, " & _
                                                       "width, " & _
                                                       "height, " & _
                                                       "sqrFeet, " & _
                                                       "sptQty, " & _
                                                       "support, " & _
                                                       "hdwQty, " & _
                                                       "hdw, " & _
                                                       "sheeting " & _
                                                       "FROM PlywoodTOF " & _
                                                       "WHERE mhsJob = '" & Me.mhsJob & "' ORDER By station", mhsConn)


            ' Open connection to Db
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            pwTOFDA = New OleDbDataAdapter(cmd)


            'One CommandBuilder object is required. 
            'It automatically generates DeleteCommand, 
            'UpdateCommand and InsertCommand 
            'for DataAdapter object      
            'Dim pwTOFBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(pwTOFDA)

            ' Instantiate DataSet object
            pwTOFDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            pwTOFDA.Fill(pwTOFDS, "PlywoodTOF")

            ' DataTable -   Fill the DataTable object with data
            pwTOFDT = pwTOFDS.Tables("PlywoodTOF")

            ' Set the Dataview object to the Dataset object
            pwTOFDV = New DataView(pwTOFDS.Tables("PlywoodTOF"))


            '  Close the connection
            mhsConn.Close()


            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke
            Me.dgvPLYTOF.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

            ' Declare and set the header alignment property
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim objBoldFont As New DataGridViewCellStyle()

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            With Me.dgvPLYTOF

                .DataSource = pwTOFDV

                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' ID field
                .Columns("ID").Visible = False

                ' mhsJob field
                .Columns("mhsJob").Visible = False
                '.Columns("mhsJob").HeaderText = "MHS #"
                '.Columns("mhsJob").Width = 50
                '.Columns("mhsJob").DefaultCellStyle.ForeColor = Color.Black
                '.Columns("mhsJob").DefaultCellStyle.Font = New Font(Me.dgvPLYTOF.Font, FontStyle.Bold)

                ' station field
                .Columns("station").HeaderText = "Station"
                .Columns("station").Width = 85

                ' type field
                .Columns("type").HeaderText = "Type"
                .Columns("type").Width = 35
                .Columns("type").DefaultCellStyle = objAlignMidcellStyle

                ' code field
                .Columns("code").HeaderText = "Sign code"
                .Columns("code").Width = 75

                ' details field
                '.Columns("details").Visible = False
                .Columns("details").HeaderText = "Sign Details"
                .Columns("details").Width = 150

                ' width field
                .Columns("width").Visible = False
                .Columns("width").HeaderText = "Width"
                .Columns("width").Width = 35
                .Columns("width").DefaultCellStyle = objAlignRightcellStyle

                ' height field
                .Columns("height").Visible = False
                .Columns("height").HeaderText = "Height"
                .Columns("height").Width = 35
                .Columns("height").DefaultCellStyle = objAlignRightcellStyle

                ' sqrFeet field
                .Columns("sqrFeet").Visible = False
                .Columns("sqrFeet").HeaderText = "SqFt"
                .Columns("sqrFeet").Width = 45
                .Columns("sqrFeet").DefaultCellStyle = objAlignRightcellStyle
                '.Columns("sqrFeet").DefaultCellStyle.Font = New Font(Me.dgvPLYTOF.Font, FontStyle.Bold)

                ' sptQty field
                .Columns("sptQty").Visible = False
                .Columns("sptQty").HeaderText = "S-Qty"
                .Columns("sptQty").Width = 35
                .Columns("sptQty").DefaultCellStyle = objAlignRightcellStyle

                ' support field
                .Columns("support").Visible = False
                .Columns("support").HeaderText = "Support"
                .Columns("support").Width = 100

                ' hdwQty field
                .Columns("hdwQty").Visible = False
                .Columns("hdwQty").HeaderText = "H-Qty"
                .Columns("hdwQty").Width = 35
                .Columns("hdwQty").DefaultCellStyle = objAlignRightcellStyle
                '.Columns("hdwQty").DefaultCellStyle.Font = New Font(Me.dgvPLYTOF.Font, FontStyle.Bold)

                ' hardware field
                .Columns("hdw").Visible = False
                .Columns("hdw").HeaderText = "Hardware"
                .Columns("hdw").Width = 100

                ' sheeting field
                .Columns("sheeting").HeaderText = "Sheeting"
                .Columns("sheeting").Width = 55

                Me.ToolStripStatusLabel1.Text = "Plywood T/O  (" & Me.pwTOFDV.Count & " Records)"

            End With



            With Me.cmbStations

                .DataSource = pwTOFDV
                .DisplayMember = "station"

            End With




            ' Clear previous DataBindings
            Me.lblMHSJob.DataBindings.Clear()
            Me.txtStation.DataBindings.Clear()
            Me.txtSignType.DataBindings.Clear()
            Me.txtSignCode.DataBindings.Clear()
            Me.txtSignDetails.DataBindings.Clear()
            Me.txtSignWidth.DataBindings.Clear()
            Me.txtSignHeight.DataBindings.Clear()
            Me.txtSqrFeet.DataBindings.Clear()
            Me.txtSheeting.DataBindings.Clear()


            ' Add DataBindings
            Me.lblMHSJob.DataBindings.Add("Text", pwTOFDV, "mhsJob")
            Me.txtStation.DataBindings.Add("Text", pwTOFDV, "station")
            Me.txtSignType.DataBindings.Add("Text", pwTOFDV, "type")
            Me.txtSignCode.DataBindings.Add("Text", pwTOFDV, "code")
            Me.txtSignDetails.DataBindings.Add("Text", pwTOFDV, "details")
            Me.txtSignWidth.DataBindings.Add("Text", pwTOFDV, "width")
            Me.txtSignHeight.DataBindings.Add("Text", pwTOFDV, "height")
            Me.txtSqrFeet.DataBindings.Add("Text", pwTOFDV, "sqrFeet")
            Me.txtSheeting.DataBindings.Add("Text", pwTOFDV, "sheeting")



        Catch ex As Exception

            MessageBox.Show(ex.Message, "GetPlywoodTOF()")

        End Try




    End Sub




#End Region








    
End Class