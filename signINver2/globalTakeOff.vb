Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
'Imports signIN.IDAutomationEncoder


Public Class globalTakeOff



#Region " Class-Level Variables "
    Public atmJN As String
    Public jobDesc As String
    Public imageName As String
    Public viewImage As String
    Public url As String
    Public signType As Integer
    Public SignCode As String
    Public signWidth_Added As Double
    Public signHeight_Added As Double
    Public SqrFt_Added As Double
    Public added As Boolean

    ' Extruded var's
    Public direction As String
    Public sParent As String
    Public b2b As String
    Public retain As Boolean
    Public EXTsheeting As String
    Public twelve As Integer
    Public six As Integer
    Public eightWF As String
    Public sixWF As String
    Public fiveWF As String
    Public threeByFour As String
    Public twoByTwo As String
    Public hardware As String
    Public entryDate As Date
    Dim threeWP As Boolean = False


    ' Db variables
    Public mhsJN As String
    Public staNum As String
    Public sType As String
    Public sCode As String
    Public sDetails As String
    Public ssQty As Integer
    Public support As String
    Public hdwQty As Integer
    Public hdw As String
    Public sheeting As String



#End Region

#Region " Database Communication "


    '  This code is missing the "From ExtrudedTOF" clause.  weird.
    ' ExtrudedTOF (db1.mdb) Connection
	Dim objEXTConnection As New OleDbConnection _
		(My.Settings.SignINconn)
    Dim objEXTdataAdapter As New OleDbDataAdapter( _
        "SELECT mhsJob, dir, station, parentSign, type, " & _
        "code, width, height, sqrFeet, sptQty, support, " & _
        "retain, sheeting, twelveInch, sixInch, eightWF, sixWF, fiveWF, " & _
        "threeByFour, twoByTwo, hdwQty, hardware, entryDate " & _
        "ORDER BY mhsJob, station", objEXTConnection)
    Dim objEXTDataSet As DataSet
    Dim objEXTDataView As DataView


    ' PlywoodTOF (db1.mdb) Connection
	Dim objPWConnection As New OleDbConnection _
		(My.Settings.SignINconn)
    Dim objPWDataAdapter As New OleDbDataAdapter( _
        "SELECT mhsJob, station, type, code, " & _
        "details, width, height, sqrFeet, " & _
        "sptQty, support, hdwQty, hdw, sheeting FROM PlywoodTOF " & _
        "ORDER BY mhsJob, station", objPWConnection)
    Dim objPWDataSet As DataSet
    Dim objPWDataview As DataView


    ' FlatSheetTOF (db1.mdb) Connection
	Dim objFSConnection As New OleDbConnection _
		(My.Settings.SignINconn)
    Dim objFSDataAdapter As New OleDbDataAdapter( _
        "SELECT mhsJob, station, type, code, " & _
        "details, width, height, sqrFeet, " & _
        "sptQty, support, hdwQty, hdw, sheeting FROM FlatSheetTOF " & _
        "ORDER BY mhsJob, station", objFSConnection)
    Dim objFSDataSet As DataSet
    Dim objFSDataview As DataView

#End Region

#Region " Sub Procedures and Functions "
    Public Sub isATM()
        'Me.AtmDbModule1.Enabled = True
        'AtmDbModule1.atmJobNum = atmJN
    End Sub

    Public Sub notATM()
        'Me.AtmDbModule1.Enabled = False
    End Sub

    Public Sub imagePreview()
        imageName = Me.txtSignCode.Text
        viewImage = imageName & ".jpg"
		url = "\\attermserv01\company data\MHS Pre Production\signIN\images\thumbNails\" & viewImage
        Try
            Me.PictureBoxPrep.Load(url)
        Catch ex As Exception
            Me.PictureBoxPrep.Image = My.Resources.none1
        End Try
    End Sub

    Private Sub showPrepTypeImage(ByVal signType As Integer)

        If signType = 680 Or signType = 692 Then
            Select Case signType
                Case 680
                    Me.txtSignType.Text = "IA"

                Case 692
                    Me.txtSignType.Text = "IB"
            End Select
            Me.PictureBoxType.Image = My.Resources.new_extruded_1_24
        End If

        If signType = 622 Or signType = 624 Or signType = 672 Then
            Select Case signType
                Case 622
                    Me.txtSignType.Text = "IIA"
                Case 624
                    Me.txtSignType.Text = "IIB"
                Case 672
                    Me.txtSignType.Text = "IIB"
            End Select
            Me.PictureBoxType.Image = My.Resources.new_plywood_1_24
        End If

        If signType = 623 Or signType = 625 Or signType = 673 Then
            Select Case signType
                Case 623
                    Me.txtSignType.Text = "IIIA"
                Case 625
                    Me.txtSignType.Text = "IIIB"
                Case 673
                    Me.txtSignType.Text = "IIIB"
            End Select
            Me.PictureBoxType.Image = My.Resources.new_flatsheet_1_24
        End If
    End Sub

    Private Sub convertToInches()
        Try
            Dim h As Double
            Dim hI As Double
            Dim w As Double
            Dim wI As Double

            h = CDbl(Me.txtSignHeight.Text)
            w = CDbl(Me.txtSignWidth.Text)
            hI = h * 12
            wI = w * 12

            Me.txtSignWidth.Text = CStr(wI)
            Me.txtSignHeight.Text = CStr(hI)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub IdentifySheeting(ByVal signCode As String)
        Try
            ' Set Sheeting Type and various details
            If signCode.ToUpper.Substring(0, 3) = "D10" Then
                Me.cmbSheetType.Text = "3990"
                Me.txtHardwareQty.Text = CStr(3)
            ElseIf signCode.ToUpper.Substring(0, 3) = "D11" Then
                Me.cmbSheetType.Text = "3930"
            ElseIf signCode.ToUpper.Substring(0, 3) = "D12" Then
                Me.cmbSheetType.Text = "3935"
            ElseIf signCode.ToUpper.Substring(0, 3) = "D13" Then
                Me.cmbSheetType.Text = "3935"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D1" Then
                Me.cmbSheetType.Text = "3937"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D2" Then
                Me.cmbSheetType.Text = "3937"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D3" Then
                Me.cmbSheetType.Text = "3937"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D4" Then
                Me.cmbSheetType.Text = "3937"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D5" Then
                Me.cmbSheetType.Text = "3935"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D6" Then
                Me.cmbSheetType.Text = "3935"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D7" Then
                Me.cmbSheetType.Text = "3939"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D8" Then
                Me.cmbSheetType.Text = "3937"
            ElseIf signCode.ToUpper.Substring(0, 2) = "D9" Then
                Me.cmbSheetType.Text = "3935"
            ElseIf signCode.ToUpper.Substring(0, 1) = "W" Then
                Me.cmbSheetType.Text = "3981"
            ElseIf signCode.ToUpper.Substring(0, 1) = "O" Then
                Me.cmbSheetType.Text = "3981"
                Me.txtHardwareQty.Text = CStr(3)
            ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
                Me.cmbSheetType.Text = "3930"
            ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
                If Me.txtSignType.Text = "IIA" Or Me.txtSignType.Text = "IIB" Then
                    Me.cmbSheetType.Text = "3937"
                ElseIf Me.txtSignType.Text = "IIIA" Or Me.txtSignType.Text = "IIIB" Then
                    Me.cmbSheetType.Text = "3930"
                End If
            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                If Me.txtSignType.Text = "IIA" Or Me.txtSignType.Text = "IIB" Then
                    Me.cmbSheetType.Text = "3937"
                ElseIf Me.txtSignType.Text = "IIIA" Or Me.txtSignType.Text = "IIIB" Then
                    Me.cmbSheetType.Text = "3930"
                End If
            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbSheetType.Text = "3983"
            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbSheetType.Text = "3983"
            ElseIf signCode.ToUpper.Substring(0, 4) = "R6-1" Then
                Me.txtSupportQty.Text = CStr(1)
            ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
                Me.cmbSheetType.Text = "3937"
            ElseIf signCode.ToUpper.Substring(0, 2) = "[S" Then
                Me.cmbSheetType.Text = "NONE"
            ElseIf signCode.ToUpper.Substring(0, 2) = "[M" Then
                Me.cmbSheetType.Text = "NONE"
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub IdentifySheeting2(ByVal signCode As String)
        Try
            ' Set Sheeting Type and various details
            If signCode.ToUpper.Substring(0, 3) = "D10" Then
                Me.cmbSheetType.Text = "3990"
                Me.txtHardwareQty.Text = CStr(3)
                'Me.cmbSelectType.Text = "IIA"
            ElseIf signCode.ToUpper.Substring(0, 1) = "W" Then
                Me.cmbSheetType.Text = "3981"
                'Me.cmbSelectType.Text = "IIB"
            ElseIf signCode.ToUpper.Substring(0, 1) = "O" Then
                Me.cmbSheetType.Text = "3981"
                'Me.cmbSelectType.Text = "IIB"
            ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
                Me.cmbSheetType.Text = "3930"
                'Me.cmbSelectType.Text = "IIA"
            ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
                Me.cmbSheetType.Text = "3930"
                'Me.cmbSelectType.Text = "IIB"
            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                Me.cmbSheetType.Text = "3930"
                'Me.cmbSelectType.Text = "IIB"
            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbSheetType.Text = "3983"
                'Me.cmbSelectType.Text = "IIB"
            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbSheetType.Text = "3983"
                'Me.cmbSelectType.Text = "IIB"
            ElseIf signCode.ToUpper.Substring(0, 4) = "R6-1" Then
                Me.txtSupportQty.Text = CStr(1)
            ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
                Me.cmbSheetType.Text = "3930"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub hideHeaderFields()
        Me.lblMHSJobDesc.Visible = False
        Me.lblMHSJobNum.Visible = False
        Me.lblCust.Visible = False
        Me.txtCustJobNum.Visible = False
    End Sub

    Public Sub showHeaderFields()
        Me.lblMHSJobDesc.Visible = True
        Me.lblMHSJobNum.Visible = True
        Me.lblCust.Visible = True
        Me.txtCustJobNum.Visible = True
    End Sub

    Public Sub enableAll()

        Me.btnConvert.Enabled = True
        Me.btnDown.Enabled = True
        Me.btnUp.Enabled = True
        Me.btnAddSign.Enabled = True
        Me.btnBtoB.Enabled = True

        Me.PanelPrep.Enabled = True
        Me.PanelExtruded.Enabled = True
    End Sub

    Public Sub disableAll()
        Me.txtSignCode.Text = ""
        Me.lblType.Text = ""
        hideHeaderFields()

        Me.PictureBoxSheeting.BackColor = Color.White
        Me.txtSignType.BackColor = Color.White
        Me.PictureBoxPrep.Image = Nothing
        Me.btnConvert.Enabled = False
        Me.btnDown.Enabled = False
        Me.btnUp.Enabled = False
        Me.btnAddSign.Enabled = False
        Me.btnBtoB.Enabled = False

        Me.PanelPrep.Enabled = False
        'Me.AtmDbModule1.Enabled = False
    End Sub

    Public Sub resetAfterAdd()

        Me.cmbSelectType.Text = "Select"
        Me.cmbSignCodes.Text = ""
        Me.txtSignCode.Text = ""
        Me.txtSignType.Text = ""
        Me.txtStation.Text = ""
        Me.txtSignDetails.Text = ""

        Me.txtSignWidth.Clear()
        Me.txtSignHeight.Clear()
        Me.txtSqrFeet.Clear()

        Me.txtSupportQty.Text = ""
        Me.cmbPostType.Text = "Select Support"

        PopulateSheeting()

        Me.txtHardwareQty.Text = ""
        Me.cmbHardware.Text = ""

        Me.PanelPrep2.Enabled = False
    End Sub

    Public Sub activateOnNew()
        Me.PanelPrep2.Enabled = True
        Me.PanelExtruded.Enabled = True

    End Sub

    Public Function ShowDecimalRound(ByVal Argument As Decimal, ByVal Digits As Integer) As Double
        Dim rounded As Decimal = Decimal.Round(Argument, Digits)
        Return rounded
    End Function

    Public Sub addEXTSign(ByVal size_1 As String)

        Try
            ' Declare objects
            Dim objEXTCommand As OleDbCommand = New OleDbCommand

            ' Open the connection
            objEXTConnection.Open()

            ' Set the OleDbCommand object properties
            objEXTCommand.Connection = objEXTConnection
            objEXTCommand.CommandText = _
                        "INSERT INTO ExtrudedTOF " & _
                            "(mhsJob, dir, station, parentSign, b2b, type, code, details, " & _
                            "width, height, sqrFeet, sptQty, support, " & _
                            "retain, sheeting, twelveInch, sixInch, " & _
                            "eightWF, sixWF, fiveWF, threeByFour, twoByTwo, hdwQty, hardware, entryDate) " & _
                            "VALUES(@mhsJob,@dir,@station,@parentSign,@b2b,@type,@code,@details," & _
                            "@width,@height,@sqrFeet,@sptQty,@support," & _
                            "@retain,@sheeting,@twelveInch,@sixInch," & _
                            "@eightWF,@sixWF,@fiveWF,@threeByFour,@twoByTwo,@hdwQty,@hardware,@entryDate)"


            ' Add placeholder parameters 
            objEXTCommand.Parameters.AddWithValue("@mhsJob", mhsJN)
            objEXTCommand.Parameters.AddWithValue("@dir", direction)
            objEXTCommand.Parameters.AddWithValue("@station", staNum)
            objEXTCommand.Parameters.AddWithValue("@parentSign", sParent)
            objEXTCommand.Parameters.AddWithValue("@b2b", b2b)
            objEXTCommand.Parameters.AddWithValue("@type", sType)
            objEXTCommand.Parameters.AddWithValue("@code", SignCode)
            objEXTCommand.Parameters.AddWithValue("@details", sDetails)
            objEXTCommand.Parameters.AddWithValue("@width", signWidth_Added)
            objEXTCommand.Parameters.AddWithValue("@height", signHeight_Added)
            objEXTCommand.Parameters.AddWithValue("@sqrFeet", SqrFt_Added)
            objEXTCommand.Parameters.AddWithValue("@sptQty", ssQty)
            objEXTCommand.Parameters.AddWithValue("@support", support)
            objEXTCommand.Parameters.AddWithValue("@retain", retain)
            objEXTCommand.Parameters.AddWithValue("@sheeting", EXTsheeting)
            objEXTCommand.Parameters.AddWithValue("@twelveInch", twelve)
            objEXTCommand.Parameters.AddWithValue("@sixInch", six)
            objEXTCommand.Parameters.AddWithValue("@eightWF", eightWF)
            objEXTCommand.Parameters.AddWithValue("@sixWF", sixWF)
            objEXTCommand.Parameters.AddWithValue("@fiveWF", fiveWF)
            objEXTCommand.Parameters.AddWithValue("@threeByFour", threeByFour)
            objEXTCommand.Parameters.AddWithValue("@twoByTwo", twoByTwo)
            objEXTCommand.Parameters.AddWithValue("@hdwQty", hdwQty)
            objEXTCommand.Parameters.AddWithValue("@hardware", hardware)
            objEXTCommand.Parameters.AddWithValue("@entryDate", entryDate)


            ' Execute the OleDbCommand object to insert the new data
            Try
                objEXTCommand.ExecuteNonQuery()
            Catch OleDbExceptionErr As OleDbException
                MessageBox.Show(OleDbExceptionErr.Message)
            End Try

            ' Close the connection
            objEXTConnection.Close()

            Me.ToolStripStatusLabel1.Text = _
                        staNum & ", " & sCode & " (" & size_1 & ") added successfully"

        Catch NullExceptionErr As NullReferenceException
            MessageBox.Show(NullExceptionErr.Message)
        End Try
    End Sub

    Public Sub addPWSign(ByVal size_1 As String)

        Try
            ' Declare objects
            Dim objPWCommand As OleDbCommand = New OleDbCommand

            ' Open the connection
            objPWConnection.Open()

            ' Set the OleDbCommand object properties
            objPWCommand.Connection = objPWConnection
            objPWCommand.CommandText = _
                        "INSERT INTO PlywoodTOF " & _
                            "(mhsJob, station, type, code, " & _
                            "details, width, height, sqrFeet, " & _
                            "sptQty, support, hdwQty, hdw, sheeting) " & _
                            "VALUES(@mhsJob, @station, @type, @code, " & _
                            "@details, @width, @height, @sqrFeet, " & _
                            "@sptQty, @support, @hdwQty, @hdw, @sheeting)"


            ' Add placeholder parameters 
            objPWCommand.Parameters.AddWithValue("@mhsJob", mhsJN)
            objPWCommand.Parameters.AddWithValue("@station", staNum)
            objPWCommand.Parameters.AddWithValue("@type", sType)
            objPWCommand.Parameters.AddWithValue("@code", sCode)
            objPWCommand.Parameters.AddWithValue("@details", sDetails)
            objPWCommand.Parameters.AddWithValue("@width", signWidth_Added)
            objPWCommand.Parameters.AddWithValue("@height", signHeight_Added)
            objPWCommand.Parameters.AddWithValue("@sqrFeet", SqrFt_Added)
            objPWCommand.Parameters.AddWithValue("@sptQty", ssQty)
            objPWCommand.Parameters.AddWithValue("@support", support)
            objPWCommand.Parameters.AddWithValue("@hdwQty", hdwQty)
            objPWCommand.Parameters.AddWithValue("@hdw", hdw)
            objPWCommand.Parameters.AddWithValue("@sheeting", sheeting)

            ' Execute the OleDbCommand object to insert the new data
            Try
                objPWCommand.ExecuteNonQuery()
            Catch OleDbExceptionErr As OleDbException
                MessageBox.Show(OleDbExceptionErr.Message)
            End Try

            ' Close the connection
            objPWConnection.Close()

            Me.ToolStripStatusLabel1.Text = _
                        staNum & ", " & sCode & " (" & size_1 & ") added successfully"

        Catch NullExceptionErr As NullReferenceException
            MessageBox.Show(NullExceptionErr.Message)
        End Try
    End Sub

    Public Sub addFSSign(ByVal size_1 As String)

        Try
            ' Declare objects
            Dim objFSCommand As OleDbCommand = New OleDbCommand

            ' Open the connection
            objFSConnection.Open()

            ' Set the OleDbCommand object properties
            objFSCommand.Connection = objFSConnection
            objFSCommand.CommandText = _
                        "INSERT INTO FlatSheetTOF " & _
                            "(mhsJob, station, type, code, " & _
                            "details, width, height, sqrFeet, " & _
                            "sptQty, support, hdwQty, hdw, sheeting) " & _
                            "VALUES(@mhsJob, @station, @type, @code, " & _
                            "@details, @width, @height, @sqrFeet, " & _
                            "@sptQty, @support, @hdwQty, @hdw, @sheeting)"


            ' Add placeholder parameters 
            objFSCommand.Parameters.AddWithValue("@mhsJob", mhsJN)
            objFSCommand.Parameters.AddWithValue("@station", staNum)
            objFSCommand.Parameters.AddWithValue("@type", sType)
            objFSCommand.Parameters.AddWithValue("@code", sCode)
            objFSCommand.Parameters.AddWithValue("@details", sDetails)
            objFSCommand.Parameters.AddWithValue("@width", signWidth_Added)
            objFSCommand.Parameters.AddWithValue("@height", signHeight_Added)
            objFSCommand.Parameters.AddWithValue("@sqrFeet", SqrFt_Added)
            objFSCommand.Parameters.AddWithValue("@sptQty", ssQty)
            objFSCommand.Parameters.AddWithValue("@support", support)
            objFSCommand.Parameters.AddWithValue("@hdwQty", hdwQty)
            objFSCommand.Parameters.AddWithValue("@hdw", hdw)
            objFSCommand.Parameters.AddWithValue("@sheeting", sheeting)

            ' Execute the OleDbCommand object to insert the new data
            Try
                objFSCommand.ExecuteNonQuery()
            Catch OleDbExceptionErr As OleDbException
                MessageBox.Show(OleDbExceptionErr.Message)
            End Try

            ' Close the connection
            objFSConnection.Close()

            Me.ToolStripStatusLabel1.Text = _
                        staNum & ", " & sCode & " (" & size_1 & ") added successfully"

        Catch NullExceptionErr As NullReferenceException
            MessageBox.Show(NullExceptionErr.Message)
        End Try
    End Sub

    Public Sub showExtrudedPanel()
        PanelIIandIII.Visible = False
        PanelExtruded.Visible = True
        PanelExtruded.Enabled = True
        PanelPrep2.Controls.Add(PanelExtruded)
        PanelExtruded.Location = New Point(4, 3)

    End Sub

    Public Sub calcSqFt()

        ' calculate Support Qty.
        If Me.txtSignHeight.Text IsNot Nothing Then

            Try
                If Me.txtSignHeight.Text IsNot Nothing Then
                    ' Calculate square footage
                    Dim sWidth As Double = CDbl(Me.txtSignWidth.Text)
                    Dim sHeight As Double = CDbl(Me.txtSignHeight.Text)
                    Dim sqrFeet As Double

                    sqrFeet = sWidth * sHeight / 144

                    Me.txtSqrFeet.Text = CStr(ShowDecimalRound(CDec(sqrFeet), 2))
                    Me.btnConvert.Enabled = True
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Public Sub calcEXTSqFt()

        If Me.txtExtHeight.Text IsNot Nothing Then
            ' Calculate square footage
            Dim sWidth As Double = CDbl(Me.txtExtWidth.Text)
            Dim sHeight As Double = CDbl(Me.txtExtHeight.Text)
            Dim sqrFeet As Double

            sqrFeet = sWidth * sHeight

            Me.txtExtSqrFeet.Text = CStr(ShowDecimalRound(CDec(sqrFeet), 2))

            Dim ft As Decimal = CDec(Math.Floor(sHeight))
            Dim inch As Decimal = CDec(sHeight - ft)

            Me.txt12Plank.Clear()
            Me.txt6Plank.Clear()

            If ft > 0 Then Me.txt12Plank.Text = CStr(ft)
            If inch > 0 Then Me.txt6Plank.Text = CStr(1) Else Me.txt6Plank.Text = Nothing

        End If
    End Sub

    Public Sub resetEXTafterAdd()

        PopulateEXTSheeting()
        PopulateEXTSupport()

        Me.txtExtWidth.Clear()
        Me.txtExtHeight.Clear()
        Me.txtExtSqrFeet.Clear()

        Me.cmbDirection.Text = "Direction"
        Me.cmbExtColor.Text = "Select"

        Me.txt12Plank.Clear()
        Me.txt6Plank.Clear()

        Me.ckbRetain.Checked = False
        Me.txtParent.Clear()

        Me.cmbExtMounting.Text = ""
        Me.txtExtHdwQty.Clear()

        Me.cmbExtHardware.Text = ""
        Me.cmbBeamsAngle.Text = ""

        Me.txtExtSptQty.Clear()
        Me.cmbSptSize.Text = ""

        Me.txt3X4Qty.Clear()
        Me.txt2X2Qty.Clear()

        Me.cmbWPAngleSize.Text = ""
        Me.txtExtB2B.Clear()

        Me.PictureBoxExtSheeting.Visible = False
        Me.lblExtSheetDesc.Text = ""


        Me.PanelWP.Visible = False
        Me.PanelNotWP.Visible = True

        Me.btn3WP.Visible = False

        Me.PanelExtruded.Enabled = False

    End Sub

    Public Sub bindSheetDesc()

        ' Declare job number variable
        Dim sheetN As String = Me.cmbExtColor.Text

        ' EXTsheeting (Db1 Db) Connection
		Dim objExtSheetDescConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objExtSheetDescDataAdapter As New OleDbDataAdapter( _
            "SELECT sheetNum, sheetDesc FROM EXTsheeting " & _
            "WHERE sheetNum = '" & sheetN & "' " & _
            "ORDER BY sheetNum", objExtSheetDescConnection)

        Dim objExtSheetDescDataSet As DataSet
        Dim objExtSheetDescDataView As DataView

        ' Initialize a new instance of the DataSet object
        objExtSheetDescDataSet = New DataSet()

        ' Open the connection, execute the command
        objExtSheetDescConnection.Open()

        ' Fill DataSet
        objExtSheetDescDataAdapter.Fill(objExtSheetDescDataSet, "EXTsheeting")

        ' Set the DataView object to the DataSet object
        objExtSheetDescDataView = New DataView(objExtSheetDescDataSet.Tables("EXTsheeting"))

        ' Close the connection
        objExtSheetDescConnection.Close()

        ' Clear databindings
        Me.lblExtSheetDesc.DataBindings.Clear()

        ' Bind data (job description) to fields
        Me.lblExtSheetDesc.DataBindings.Add("Text", objExtSheetDescDataView, "sheetDesc")


    End Sub

    Public Sub autoBeamAngleSize(ByVal spt_height As Double)

        ' heightSizes (Db1 Db) Connection
		Dim objEXTsptHeightConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objEXTsptHeight As New OleDbDataAdapter( _
            "SELECT * FROM heightSizes " & _
            "WHERE metricEquivalent = " & spt_height & " " & _
            "ORDER BY ID", objEXTsptHeightConnection)


        Dim objEXTsptHeightDataSet As DataSet
        Dim objEXTsptHeightDataView As DataView


        ' Initialize a new instance of the DataSet object
        objEXTsptHeightDataSet = New DataSet()

        ' Open the connection, execute the command
        objEXTsptHeightConnection.Open()

        ' Fill DataSet
        objEXTsptHeight.Fill(objEXTsptHeightDataSet, "heightSizes")

        ' Close the connection
        objEXTsptHeightConnection.Close()

        ' Set the heightSizes DataView object to the DataSet object
        objEXTsptHeightDataView = New DataView(objEXTsptHeightDataSet.Tables("heightSizes"))

        ' Clear databindings
        Me.txtAutoSize.DataBindings.Clear()

        ' Bind data to fields
        Me.txtAutoSize.DataBindings.Add("Text", objEXTsptHeightDataView, "ID")

        Dim autoSize As Integer = CInt(Me.txtAutoSize.Text)

        Me.cmbSptSize.SelectedIndex = autoSize - 1
        Me.cmbWPAngleSize.SelectedIndex = autoSize - 1

    End Sub

    Public Sub EXT(ByVal sC As String)

        If sC.Substring(0, 5) = "E11-1" Then
            Me.cmbExtColor.Text = "3981"

            ' Disable unnecessary fields
            Me.cmbExtMounting.Text = ""
            'Me.cmbExtMounting.Enabled = False
            Me.txtExtHdwQty.Text = ""
            'Me.txtExtHdwQty.Enabled = False
            Me.cmbExtHardware.Text = ""
            'Me.cmbExtHardware.Enabled = False

            Me.cmbBeamsAngle.Text = ""
            Me.cmbSptSize.Text = ""
            Me.txtExtSptQty.Text = ""

            Me.btn3WP.Visible = False
            Me.PanelNotWP.Visible = True
            Me.PanelWP.Visible = False

        Else
            'Me.PanelNotWP.Enabled = True
            'Me.cmbExtMounting.Enabled = True
            'Me.txtExtHdwQty.Enabled = True
            'Me.cmbExtHardware.Enabled = True

        End If

    End Sub

#End Region

#Region " Event Handlers "

    Private Sub globalTakeOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateMHSJobNum()
        PopulateSignCodes()
        PopulateSheeting()
        PopulateEXTSheeting()
        PopulateSelectType()
        PopulateDetails()
        PopulateEXTSupport()
        PopulateHeights()

        disableAll()

        Me.ToolStripStatusLabel1.Text = "Ready"
    End Sub

    Private Sub cmbMHSJobNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMHSJobNum.SelectedIndexChanged
        Try
            Me.lblMHSJobNum.Text = Me.cmbMHSJobNum.Text
            populateJobDesc()
            showHeaderFields()
            Me.PanelPrep.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbSignCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignCodes.SelectedIndexChanged
        Try
            If Me.cmbSignCodes.Text <> "Select" Then
                Me.txtSignCode.Text = Me.cmbSignCodes.Text
            Else
                Me.txtSignCode.Text = ""
            End If

            activateOnNew()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSelectType.SelectedIndexChanged
        Try
            Select Case cmbSelectType.SelectedIndex
                Case 0 ' IA
                    signType = 680
                    showPrepTypeImage(signType)
                    showExtrudedPanel()

                Case 1 ' IB
                    signType = 692
                    showPrepTypeImage(signType)
                    showExtrudedPanel()

                Case 2 ' IIA
                    signType = 622
                    showPrepTypeImage(signType)

                    If Me.PanelExtruded.Visible = True Then
                        Me.PanelExtruded.Visible = False
                        Me.PanelIIandIII.Visible = True
                    End If

                Case 3 ' IIB
                    signType = 624
                    showPrepTypeImage(signType)

                    If Me.PanelExtruded.Visible = True Then
                        Me.PanelExtruded.Visible = False
                        Me.PanelIIandIII.Visible = True
                    End If

                Case 4 ' IIIA
                    signType = 623
                    showPrepTypeImage(signType)

                    If Me.PanelExtruded.Visible = True Then
                        Me.PanelExtruded.Visible = False
                        Me.PanelIIandIII.Visible = True
                    End If

                Case 5 ' IIIB
                    signType = 625
                    showPrepTypeImage(signType)
                    If Me.PanelExtruded.Visible = True Then
                        Me.PanelExtruded.Visible = False
                        Me.PanelIIandIII.Visible = True
                    End If

            End Select
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

        activateOnNew()

    End Sub

    Private Sub cmbDetails_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDetails.TextChanged
        Try
            If Me.cmbDetails.Text <> "Preset Details" Then
                Me.txtSignDetails.Text = Me.cmbDetails.Text
            Else
                Me.txtSignDetails.Text = ""
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbPostType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPostType.SelectedIndexChanged
        If Me.cmbPostType.Text = "2 Pole Band" Then
            Me.txtHardwareQty.Text = CStr(2)
        ElseIf Me.cmbPostType.Text = "3 Pole Band" Then
            Me.txtHardwareQty.Text = CStr(3)
        End If
    End Sub

    Private Sub cmbSheetType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSheetType.SelectedIndexChanged
        If Me.cmbSheetType.Text <> "" Then
            Try
                Select Case cmbSheetType.Text
                    Case "3930"
                        Me.PictureBoxSheeting.BackColor = Color.White

                    Case "3981"
                        Me.PictureBoxSheeting.BackColor = Color.Yellow

                    Case "3983"
                        Me.PictureBoxSheeting.BackColor = Color.YellowGreen

                    Case "3990"
                        Me.PictureBoxSheeting.BackColor = Color.White

                    Case "3932"
                        Me.PictureBoxSheeting.BackColor = Color.Red

                    Case "3935"
                        Me.PictureBoxSheeting.BackColor = Color.Blue

                    Case "3937"
                        Me.PictureBoxSheeting.BackColor = Color.Green

                    Case "3939"
                        Me.PictureBoxSheeting.BackColor = Color.Brown

                    Case "3924"
                        Me.PictureBoxSheeting.BackColor = Color.Orange

                    Case "1172C"
                        Me.PictureBoxSheeting.BackColor = Color.Red

                    Case "1175C"
                        Me.PictureBoxSheeting.BackColor = Color.Blue

                    Case "1177C"
                        Me.PictureBoxSheeting.BackColor = Color.Green

                    Case "3650-12"
                        Me.PictureBoxSheeting.BackColor = Color.Black

                    Case "3997"
                        Me.PictureBoxSheeting.BackColor = Color.Green

                    Case Else
                        Me.PictureBoxSheeting.BackColor = Color.White

                End Select
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbExtMounting_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExtMounting.SelectedIndexChanged

        Dim extSupport As String = Me.cmbExtMounting.Text

        Select Case extSupport
            Case "4x6 W/P"

            Case "6x8 W/P"

            Case "Column"

                Dim sHt As Double = CDbl(Me.txtExtHeight.Text)
                Dim roundUP As Integer = CInt(Math.Ceiling(sHt))
                Dim hdwQty As Integer = (roundUP + 3) * 2
                Me.txtExtHdwQty.Text = CStr(hdwQty)
                Me.cmbBeamsAngle.Text = "2x2"
                Me.txtExtSptQty.Text = CStr(2)


            Case "Exit Panel"

                If Me.txt6Plank.Text IsNot Nothing Then
                    Me.txtExtHdwQty.Text = CStr(33)
                Else
                    Me.txtExtHdwQty.Text = CStr(30)
                End If

                Me.cmbExtColor.SelectedIndex = 0
                Me.txtExtSptQty.Text = CStr(3)
                Me.cmbBeamsAngle.Text = "2x2"
                Me.cmbSptSize.Text = "8' - 0"""
                Me.txtParent.Focus()



            Case "Bridge Conn"

            Case "C-Truss"

                Me.cmbBeamsAngle.Text = "5WF"
                Me.txtExtSptQty.Focus()

                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try


            Case "C/D-Truss"

                Me.cmbBeamsAngle.Text = "5WF"
                'Me.txtExtSptQty.Focus()

                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try


            Case "E/D/G-Cant"

                Me.cmbBeamsAngle.Text = "5WF"
                'Me.txtExtSptQty.Focus()

                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try


            Case "Advisory Panel"
                Me.cmbExtColor.Text = "3981"

                ' Disable unnecessary fields
                Me.cmbExtMounting.Text = ""
                'Me.cmbExtMounting.Enabled = False
                Me.txtExtHdwQty.Text = ""
                'Me.txtExtHdwQty.Enabled = False
                Me.cmbExtHardware.Text = ""
                'Me.cmbExtHardware.Enabled = False

                Me.cmbBeamsAngle.Text = ""
                Me.cmbSptSize.Text = ""
                Me.txtExtSptQty.Text = ""

                Me.btn3WP.Visible = False
                Me.PanelNotWP.Visible = True
                Me.PanelWP.Visible = False

            Case "E-Truss 50'-105'"
                Me.cmbBeamsAngle.Text = "5WF"

                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try


            Case "E-Truss 110'-140'"
                Me.cmbBeamsAngle.Text = "5WF"
                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            Case "J-Cant"
                Me.cmbBeamsAngle.Text = "5WF"
                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            Case "C-Cant"
                Me.cmbBeamsAngle.Text = "5WF"

                Try
                    Me.txtExtSptQty.Text = CStr(cantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try

        End Select

        If extSupport = "4x6 W/P" Or extSupport = "6x8 W/P" Then
            PanelNotWP.Visible = False
            PanelWP.Visible = True
            PanelExtruded.Controls.Add(PanelWP)
            PanelWP.Location = New Point(6, 100)

            Me.lblExtB2B.Visible = False
            Me.txtExtB2B.Visible = False
            Me.btnExtBtoB.Visible = True
            Me.btn3WP.Visible = True

            Me.txt3X4Qty.Text = CStr(2)
            Me.txt2X2Qty.Text = CStr(2)

            If Me.txtExtHeight.Text <> "" Then
                Dim h As Double = CDbl(Me.txtExtHeight.Text)

                Select Case h
                    Case Is <= 4.5
                        Me.txtExtHdwQty.Text = CStr(4)
                    Case Is <= 7
                        Me.txtExtHdwQty.Text = CStr(6)
                    Case Is <= 9.5
                        Me.txtExtHdwQty.Text = CStr(8)
                    Case Is >= 10
                        Me.txtExtHdwQty.Text = CStr(10)
                End Select
            End If

        Else
            Me.btn3WP.Visible = False
            PanelNotWP.Visible = True
            PanelWP.Visible = False
        End If

    End Sub

    Private Sub cmbExtColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExtColor.SelectedIndexChanged

        Me.PictureBoxExtSheeting.Visible = True

        Select Case Me.cmbExtColor.SelectedIndex
            Case 0 ' Green
                Me.PictureBoxExtSheeting.BackColor = Color.Green
            Case 1 ' Yellow
                Me.PictureBoxExtSheeting.BackColor = Color.Yellow
            Case 2 ' White
                Me.PictureBoxExtSheeting.BackColor = Color.White
            Case 3 ' Blue
                Me.PictureBoxExtSheeting.BackColor = Color.Blue
            Case 4 ' Brown
                Me.PictureBoxExtSheeting.BackColor = Color.Brown
            Case 5 ' None
                Me.PictureBoxExtSheeting.Visible = False
        End Select

        bindSheetDesc()

    End Sub

    Private Sub txtSignCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSignCode.TextChanged
        Try
            If added = False Then
                imagePreview()
                SignCode = Me.txtSignCode.Text
                IdentifySheeting(SignCode)
                activateOnNew()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtCustJobNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustJobNum.TextChanged
        Try
            atmJN = Me.txtCustJobNum.Text
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtSupportQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupportQty.TextChanged
        Try
            SignCode = Me.txtSignCode.Text
            sType = Me.txtSignType.Text
            If txtSupportQty.Text <> "" Then
                Dim hwareCount As Integer
                Dim supports As Integer = CInt(Me.txtSupportQty.Text)
                hwareCount = supports * 2
                Me.txtHardwareQty.Text = CStr(hwareCount)
                'If signCode.ToUpper.Substring(0, 4) = "R6-1" Then
                '    Me.txtSupportQty.Text = 1
                'End If
                IdentifySheeting(SignCode)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtSignWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSignWidth.TextChanged
        Try
            If CDbl(Me.txtSignWidth.Text) >= 36 Then
                Me.txtSupportQty.Text = CStr(2)
            Else
                Me.txtSupportQty.Text = CStr(1)
            End If

            calcSqFt()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtSignHeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSignHeight.TextChanged

        Try
            calcSqFt()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtExtHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtHeight.TextChanged

        Try
            calcEXTSqFt()

            Dim spt_size As Double = CDbl(Me.txtExtHeight.Text)
            autoBeamAngleSize(spt_size)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtExtWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtWidth.TextChanged
        Try
            calcEXTSqFt()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lblExtSqrFt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExtSqrFt.DoubleClick
        Try
            Dim h As Double
            Dim hF As Double
            Dim w As Double
            Dim wF As Double

            h = CDbl(Me.txtExtHeight.Text)
            w = CDbl(Me.txtExtWidth.Text)
            hF = h / 12
            wF = w / 12

            Me.txtExtWidth.Text = CStr(wF)
            Me.txtExtHeight.Text = CStr(hF)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtSignType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSignType.TextChanged
        If Me.btnConvert.Enabled = False Then
            enableAll()
        End If

        Select Case Me.txtSignType.Text
            Case "IA"
                Me.lblType.Text = "Extruded"
                signType = 680
                showPrepTypeImage(signType)
            Case "IB"
                Me.lblType.Text = "Extruded"
                signType = 692
                showPrepTypeImage(signType)
            Case "IIA"
                Me.lblType.Text = "Plywood"
                signType = 622
                showPrepTypeImage(signType)
                Me.cmbPostType.DataSource = Nothing
                Me.cmbHardware.DataSource = Nothing
                PopulatePWSupport()
            Case "IIB"
                Me.lblType.Text = "Plywood"
                signType = 624
                showPrepTypeImage(signType)
                Me.cmbPostType.DataSource = Nothing
                Me.cmbHardware.DataSource = Nothing
                PopulatePWSupport()
            Case "IIIA"
                Me.lblType.Text = "Flatsheet"
                signType = 623
                showPrepTypeImage(signType)
                Me.cmbPostType.DataSource = Nothing
                Me.cmbHardware.DataSource = Nothing
                PopulateFSSupport()
            Case "IIIB"
                Me.lblType.Text = "Flatsheet"
                signType = 625
                showPrepTypeImage(signType)
                Me.cmbPostType.DataSource = Nothing
                Me.cmbHardware.DataSource = Nothing
                PopulateFSSupport()
        End Select
        sType = Me.txtSignType.Text
    End Sub


    ' Update this to reflect EXTSupport table changes  6/11/09
    Private Sub txtExtSptQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtSptQty.TextChanged

        Dim s As String = Me.cmbExtMounting.Text

        Select Case s

            Case "Cantilever"
                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text
            Case "C-Truss"
                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text
            Case "C/D-Truss"
                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text
            Case "Bridge Conn"
                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text
        End Select


    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            Dim tempPostCount As Integer = CInt(Me.txtSupportQty.Text)
            tempPostCount += 1
            Me.txtSupportQty.Text = CStr(tempPostCount)
        Catch ex As Exception
            MessageBox.Show("Value must be a number to increment.", _
                         "Hold UP!!!", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Question, _
                         MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            Dim tempPostCount As Integer = CInt(Me.txtSupportQty.Text)
            tempPostCount -= 1
            Me.txtSupportQty.Text = CStr(tempPostCount)
        Catch ex As Exception
            MessageBox.Show("Value must be a number to increment.", _
                         "Hold UP!!!", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Question, _
                         MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        convertToInches()
    End Sub

    Private Sub btnBtoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBtoB.Click
        Me.txtSupportQty.Text = CStr(0)
    End Sub

    Private Sub btnAddSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSign.Click

        Dim supportCheck As String = Me.cmbPostType.Text


        
        If supportCheck.ToUpper.Substring(0, 3) = "SEL" Then
            MessageBox.Show("Please select a support", "Support not selected!", _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                                MessageBoxDefaultButton.Button1)
        Else

            ' This is used so that when txtSignCode.Text changes the preview image
            ' will not show none1.png
            added = True

            ' Transfer data to "Added" panel
            Me.lblStationNum_Added.Text = Me.txtStation.Text
            Me.lblSignCode_Added.Text = Me.txtSignCode.Text
            Me.lblDetails_Added.Text = Me.txtSignDetails.Text
            Me.lblType_Added.Text = Me.txtSignType.Text


            ' For displaying data only
            Dim tempSupport As String
            tempSupport = Me.txtSupportQty.Text.ToString & ") " & Me.cmbPostType.Text
            Me.lblSupport_Added.Text = tempSupport
            Me.lblSheeting_Added.Text = Me.cmbSheetDesc.Text

            ' Declared for display and adding to db
            signWidth_Added = CDbl(Me.txtSignWidth.Text)
            signHeight_Added = CDbl(Me.txtSignHeight.Text)
            SqrFt_Added = CDbl(Me.txtSqrFeet.Text)

            ' Display
            Dim tempSize As String
            tempSize = signWidth_Added.ToString & " x " & signHeight_Added.ToString
            Me.lblSize_Added.Text = tempSize

            Dim tempImage As Image
            tempImage = CType(Me.PictureBoxType.Image.Clone, Image)
            Me.PictureBoxType_Added.Image = tempImage
            Me.PictureBoxType.Image = Nothing

            ' Transfer to added panel and clear
            Dim tempImage2 As Image
            tempImage2 = CType(Me.PictureBoxPrep.Image.Clone, Image)
            Me.PictureBoxSign_Added.Image = tempImage2
            Me.PictureBoxPrep.Image = Nothing

            ' Finish declaring variables
            mhsJN = Me.lblMHSJobNum.Text
            staNum = Me.txtStation.Text
            sType = Me.txtSignType.Text
            sCode = Me.txtSignCode.Text
            sDetails = Me.txtSignDetails.Text
            ssQty = CInt(Me.txtSupportQty.Text)
            support = Me.cmbPostType.Text
            hdwQty = CInt(Me.txtHardwareQty.Text)
            hdw = Me.cmbHardware.Text
            sheeting = Me.cmbSheetType.Text

            ' Send size as concactenated string
            Dim size_1a As String
            size_1a = Me.txtSignWidth.Text.ToString() & _
                        " x " & Me.txtSignHeight.Text.ToString



            Select Case Me.lblType.Text
                Case "Extruded"

                Case "Plywood"
                    addPWSign(size_1a)
                Case "Flatsheet"
                    addFSSign(size_1a)
            End Select


            'Begin resetting controls for next sign
            Me.cmbDetails.Text = "Preset Details"
            Me.txtSignDetails.Text = Nothing

            resetAfterAdd()

            added = False



        End If

    End Sub

    Private Sub btnExtBtoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtBtoB.Click

        ' Hide/Show controls...
        Me.lblExtB2B.Visible = True
        Me.txtExtB2B.Visible = True
        Me.btnExtBtoB.Visible = False

        Me.txtExtHdwQty.Text = CStr(8)

        Me.txtExtB2B.Focus()


    End Sub

    Private Sub btn3WP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3WP.Click

        threeWP = True

        Me.txt3X4Qty.Text = CStr(3)
        Dim hqty As Integer = CInt(Me.txtExtHdwQty.Text)
        Dim b As Integer = CInt(hqty / 2)
        Me.txtExtHdwQty.Text = CStr(hqty + b)

        If Me.btnExtBtoB.Visible = False Then
            Me.lblExtB2B.Visible = False
            Me.txtExtB2B.Visible = False
            Me.btnExtBtoB.Visible = True
        End If
    End Sub

    Private Sub btnExtAddSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtAddSign.Click

        'Dim directionCheck As String = Me.cmbDirection.Text

        If Me.cmbDirection.Text = "Direction" Then
            MessageBox.Show("Please select a direction", "Direction not selected!", _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                                MessageBoxDefaultButton.Button1)
        Else

            ' This is used so that when txtSignCode.Text changes the preview image
            ' will not show none1.png
            added = True

            ' Transfer data to "Added" panel
            Me.lblStationNum_Added.Text = Me.txtStation.Text
            Me.lblSignCode_Added.Text = Me.txtSignCode.Text
            Me.lblDetails_Added.Text = Me.txtSignDetails.Text
            Me.lblType_Added.Text = Me.txtSignType.Text

            ' For displaying data only
            'Dim tempSupport As String
            'tempSupport = Me.txtSupportQty.Text.ToString & ") " & Me.cmbPostType.Text
            Me.lblSupport_Added.Text = Me.cmbExtMounting.Text
            Me.lblSheeting_Added.Text = Me.lblExtSheetDesc.Text

            ' Declared for display and adding to db
            signWidth_Added = CDbl(Me.txtExtWidth.Text)
            signHeight_Added = CDbl(Me.txtExtHeight.Text)
            SqrFt_Added = CDbl(Me.txtExtSqrFeet.Text)

            ' Display
            Dim tempSize As String
            tempSize = signWidth_Added.ToString & " x " & signHeight_Added.ToString
            Me.lblSize_Added.Text = tempSize

            Dim tempImage As Image
            tempImage = CType(Me.PictureBoxType.Image.Clone, Image)
            Me.PictureBoxType_Added.Image = tempImage
            Me.PictureBoxType.Image = Nothing

            ' Transfer to added panel and clear
            Dim tempImage2 As Image
            tempImage2 = CType(Me.PictureBoxPrep.Image.Clone, Image)
            Me.PictureBoxSign_Added.Image = tempImage2
            Me.PictureBoxPrep.Image = Nothing

            ' Finish declaring variables
            mhsJN = Me.lblMHSJobNum.Text
            direction = Me.cmbDirection.Text
            staNum = Me.txtStation.Text
            sParent = Me.txtParent.Text
            sType = Me.txtSignType.Text
            SignCode = Me.txtSignCode.Text
            sDetails = Me.txtSignDetails.Text

            support = Me.cmbExtMounting.Text
            retain = CBool(Me.ckbRetain.CheckState)
            EXTsheeting = Me.cmbExtColor.Text
            twelve = CInt(Me.txt12Plank.Text)

            If Me.txt6Plank.Text = Nothing Then
                six = 0
            Else
                six = CInt(Me.txt6Plank.Text)
            End If


            If Me.cmbExtMounting.Text = "4x6 W/P" Or Me.cmbExtMounting.Text = "6x8 W/P" Then

                eightWF = ""
                sixWF = ""
                fiveWF = ""

                threeByFour = Me.txt3X4Qty.Text.ToString & " )  " & Me.cmbWPAngleSize.Text
                twoByTwo = Me.txt2X2Qty.Text.ToString & " )  " & Me.cmbWPAngleSize.Text

                Select Case threeWP
                    Case True
                        ssQty = 3
                    Case False
                        ssQty = 2
                End Select

                b2b = Me.txtExtB2B.Text

            ElseIf SignCode.Substring(0, 4) = "E11-" Then

                eightWF = ""
                sixWF = ""
                fiveWF = ""
                threeByFour = ""
                twoByTwo = ""

                ssQty = 0

                b2b = ""

            Else

                ' Determine proper support variable assignment
                Select Case Me.cmbBeamsAngle.SelectedIndex

                    Case -1 ' None selected
                        eightWF = ""
                        sixWF = ""
                        fiveWF = ""
                        threeByFour = ""
                        twoByTwo = ""

                    Case 0 ' 8WF
                        eightWF = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
                        sixWF = ""
                        fiveWF = ""
                        threeByFour = ""
                        twoByTwo = ""

                    Case 1 ' 6WF
                        eightWF = ""
                        sixWF = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
                        fiveWF = ""
                        threeByFour = ""
                        twoByTwo = ""

                    Case 2 ' 5WF
                        eightWF = ""
                        sixWF = ""
                        fiveWF = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
                        threeByFour = ""
                        twoByTwo = ""

                    Case 3 ' 3x4
                        eightWF = ""
                        sixWF = ""
                        fiveWF = ""
                        threeByFour = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
                        twoByTwo = ""

                    Case 4 ' 2x2
                        eightWF = ""
                        sixWF = ""
                        fiveWF = ""
                        threeByFour = ""
                        twoByTwo = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text

                End Select

                If Me.txtExtSptQty.Text = Nothing Then
                    ssQty = 0
                Else
                    ssQty = CInt(Me.txtExtSptQty.Text)
                End If

                b2b = ""

            End If




            If Me.txtExtHdwQty.Text = Nothing Then
                hdwQty = 0
            Else
                hdwQty = CInt(Me.txtExtHdwQty.Text)
            End If

            hardware = Me.cmbExtHardware.Text
            entryDate = Now.Date


            ' Send size as concactenated string
            Dim size_1a As String
            size_1a = Me.txtExtWidth.Text.ToString() & _
                        " x " & Me.txtExtHeight.Text.ToString


            Select Case Me.lblType.Text
                Case "Extruded"
                    addEXTSign(size_1a)
                Case "Plywood"

                Case "Flatsheet"

            End Select

            'Begin resetting controls for next sign
            Me.cmbDetails.Text = "Preset Details"
            Me.txtSignDetails.Text = Nothing
            Me.cmbSignCodes.Text = "Select"
            Me.txtSignCode.Clear()
            Me.txtSignType.Clear()
            Me.lblType.Text = Nothing
            'Me.PictureBoxType.Image = Nothing
            Me.txtStation.Text = Nothing

            resetEXTafterAdd()

            added = False

        End If


    End Sub

#End Region

#Region " ATM Db Event Handlers "

    'Private Sub AtmDbModule1_dbLoaded(ByVal jnATM As String) Handles AtmDbModule1.dbLoaded
    '    Me.ToolStripStatusLabel1.Text = "ATM Job#: " & jnATM & " Loaded"
    '    Me.cmbMHSJobNum.Visible = False
    'End Sub

    'Private Sub AtmDbModule1_dbLoading(ByVal jnATM As String) Handles AtmDbModule1.dbLoading
    '    jobDesc = Me.lblMHSJobDesc.Text
    '    Me.ToolStripStatusLabel1.Text = "Loading ATM Job#: " & jnATM & " (" & jobDesc & ")"
    'End Sub

    'Private Sub AtmDbModule1_migrated(ByVal payItem As Integer, ByVal signCode As String, ByVal stationNum As String, ByVal signWidth As Double, ByVal signHeight As Double, ByVal supportQty As Integer) Handles AtmDbModule1.migrated
    '    Try
    '        If payItem = 680 Or payItem = 692 Then

    '            showExtrudedPanel()

    '            showPrepTypeImage(payItem)

    '            ' Clear fields
    '            Me.txtSignCode.Clear()
    '            Me.txtStation.Clear()
    '            Me.txtExtWidth.Text = CStr(0)
    '            Me.txtExtHeight.Text = CStr(0)

    '            ' Fill fields
    '            Me.txtSignCode.Text = signCode
    '            Me.txtStation.Text = stationNum
    '            Me.txtExtWidth.Text = CStr(signWidth)
    '            Me.txtExtHeight.Text = CStr(signHeight)


    '            EXT(signCode)


    '            Me.cmbDirection.Focus()

    '            Me.ToolStripStatusLabel1.Text = stationNum & " Data Migrated"

    '        Else

    '            If Me.PanelExtruded.Visible = True Then
    '                Me.PanelExtruded.Visible = False
    '                Me.PanelIIandIII.Visible = True
    '            End If

    '            showPrepTypeImage(payItem)
    '            IdentifySheeting(signCode)

    '            ' Clear fields
    '            Me.txtSignCode.Clear()
    '            Me.txtStation.Clear()
    '            Me.txtSignWidth.Text = CStr(0)
    '            Me.txtSignHeight.Text = CStr(0)
    '            Me.txtSupportQty.Text = CStr(0)

    '            ' Fill fields
    '            Me.txtSignCode.Text = signCode
    '            Me.txtStation.Text = stationNum
    '            Me.txtSignWidth.Text = CStr(signWidth)
    '            Me.txtSignHeight.Text = CStr(signHeight)
    '            Me.txtSupportQty.Text = CStr(supportQty)

    '            activateOnNew()
    '            Me.cmbPostType.Focus()

    '            Me.ToolStripStatusLabel1.Text = stationNum & " Data Migrated"
    '        End If

    '    Catch ex As Exception
    '        'MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

#End Region

#Region " Populate combo boxes"

    Public Sub PopulateMHSJobNum()
        ' mhsJobs (Db1 Db) Connection
		Dim objMHSJobConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objMHSJobDataAdapter As New OleDbDataAdapter( _
            "SELECT mhsJob, jobDesc FROM mhsJobs ORDER BY mhsJob DESC", objMHSJobConnection)

        Dim objMHSJobDataSet As DataSet
        Dim objMHSJobDataView As DataView

        ' Initialize a new instance of the DataSet object
        objMHSJobDataSet = New DataSet()

        ' Open the connection, execute the command
        objMHSJobConnection.Open()

        ' Fill DataSet
        objMHSJobDataAdapter.Fill(objMHSJobDataSet, "mhsJobs")

        ' Set the DataView object to the DataSet object
        objMHSJobDataView = New DataView(objMHSJobDataSet.Tables("mhsJobs"))

        ' Close the connection
        objMHSJobConnection.Close()

        ' Populate job number combo box
        Me.cmbMHSJobNum.DataSource = objMHSJobDataSet.Tables("mhsJobs")
        Me.cmbMHSJobNum.DisplayMember = "mhsJob"

        ' Clear databindings
        Me.lblMHSJobDesc.DataBindings.Clear()

        ' Bind data (job description) to fields
        Me.lblMHSJobDesc.DataBindings.Add("Text", objMHSJobDataView, "jobDesc")
        Me.cmbMHSJobNum.Text = "Select MHS Job"
    End Sub

    Public Sub populateJobDesc()
        ' Declare job number variable
        Dim jobN As String = Me.cmbMHSJobNum.Text

        ' mhsJobList (Db1 Db) Connection
		Dim objMHSJobDescConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objMHSJobDescDataAdapter As New OleDbDataAdapter( _
            "SELECT mhsJob, custJob, cust, jobDesc FROM mhsJobs " & _
            "WHERE mhsJob = '" & jobN & "' " & _
            "ORDER BY mhsJob", objMHSJobDescConnection)

        Dim objMHSJobDescDataSet As DataSet
        Dim objMHSJobDescDataView As DataView

        ' Initialize a new instance of the DataSet object
        objMHSJobDescDataSet = New DataSet()

        ' Open the connection, execute the command
        objMHSJobDescConnection.Open()

        ' Fill DataSet
        objMHSJobDescDataAdapter.Fill(objMHSJobDescDataSet, "mhsJobs")

        ' Set the DataView object to the DataSet object
        objMHSJobDescDataView = New DataView(objMHSJobDescDataSet.Tables("mhsJobs"))

        ' Close the connection
        objMHSJobDescConnection.Close()

        ' Clear databindings
        Me.lblMHSJobDesc.DataBindings.Clear()
        Me.lblCust.DataBindings.Clear()
        Me.txtCustJobNum.DataBindings.Clear()

        ' Bind data (job description) to fields
        Me.lblMHSJobDesc.DataBindings.Add("Text", objMHSJobDescDataView, "jobDesc")
        Me.lblCust.DataBindings.Add("Text", objMHSJobDescDataView, "cust")
        Me.txtCustJobNum.DataBindings.Add("Text", objMHSJobDescDataView, "custJob")

        If Me.lblCust.Text = "ATM" Then
            isATM()
        Else
            notATM()
        End If

    End Sub

    Public Sub PopulateSignCodes()
        ' signCodes (Db1 Db) Connection
		Dim objCodeConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objCodeDataAdapter As New OleDbDataAdapter( _
            "SELECT code FROM signCodes ORDER BY code", objCodeConnection)

        Dim objCodeDataSet As DataSet
        Dim objCodeDataView As DataView

        ' Initialize a new instance of the DataSet object
        objCodeDataSet = New DataSet()

        ' Open the connection, execute the command
        objCodeConnection.Open()

        ' Fill DataSet
        objCodeDataAdapter.Fill(objCodeDataSet, "signCodes")

        ' Close the connection
        objCodeConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objCodeDataView = New DataView(objCodeDataSet.Tables("signCodes"))

        ' Populate contractor combo box
        Me.cmbSignCodes.DataSource = objCodeDataSet.Tables("signCodes")
        Me.cmbSignCodes.DisplayMember = "code"
        Me.cmbSignCodes.Text = "Select"
    End Sub

    Public Sub PopulateSheeting()
        ' sheetingType (Db1 Db) Connection
		Dim objSheetConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objSheetDataAdapter As New OleDbDataAdapter( _
            "SELECT sheetNum, sheetDesc FROM sheetingType", objSheetConnection)

        Dim objSheetDataSet As DataSet
        Dim objSheetDataView As DataView

        ' Initialize a new instance of the DataSet object
        objSheetDataSet = New DataSet()

        ' Open the connection, execute the command
        objSheetConnection.Open()

        ' Fill DataSet
        objSheetDataAdapter.Fill(objSheetDataSet, "sheetingType")

        ' Close the connection
        objSheetConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objSheetDataView = New DataView(objSheetDataSet.Tables("sheetingType"))

        ' Populate sheetNum combo box
        Me.cmbSheetType.DataSource = objSheetDataSet.Tables("sheetingType")
        Me.cmbSheetType.DisplayMember = "sheetNum"
        Me.cmbSheetType.Text = ""

        ' Populate sheetingDesc combo box
        Me.cmbSheetDesc.DataSource = objSheetDataSet.Tables("sheetingType")
        Me.cmbSheetDesc.DisplayMember = "sheetDesc"
        Me.cmbSheetDesc.Text = ""

        'Populate Extruded sheeting combo box
        Me.cmbExtColor.DataSource = objSheetDataSet.Tables("sheetingType")
        Me.cmbExtColor.DisplayMember = "sheetNum"
        Me.cmbExtColor.Text = ""

    End Sub

    Public Sub PopulatePWSupport()
        ' PWsupport (Db1 Db) Connection
		Dim objSptConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objSptDataAdapter As New OleDbDataAdapter( _
            "SELECT PWpostType, PWhardware FROM PWsupport ORDER BY PWpostType", objSptConnection)

        Dim objSptDataSet As DataSet
        Dim objSptDataView As DataView

        ' Initialize a new instance of the DataSet object
        objSptDataSet = New DataSet()

        ' Open the connection, execute the command
        objSptConnection.Open()

        ' Fill DataSet
        objSptDataAdapter.Fill(objSptDataSet, "PWsupport")

        ' Close the connection
        objSptConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objSptDataView = New DataView(objSptDataSet.Tables("PWsupport"))


        ' Populate postType combo box
        Me.cmbPostType.DataSource = objSptDataSet.Tables("PWsupport")
        Me.cmbPostType.DisplayMember = "PWpostType"
        Me.cmbPostType.Text = "Select Type II Support"


        ' Populate hardware combo box
        Me.cmbHardware.DataSource = objSptDataSet.Tables("PWsupport")
        Me.cmbHardware.DisplayMember = "PWhardware"
        Me.cmbHardware.Text = ""
    End Sub

    Public Sub PopulateFSSupport()
        ' FSsupport (Db1 Db) Connection
		Dim objFSSptConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objFSSptDataAdapter As New OleDbDataAdapter( _
            "SELECT FSpostType, FShardware FROM FSsupport ORDER BY FSpostType", objFSSptConnection)

        Dim objFSSptDataSet As DataSet
        Dim objFSSptDataView As DataView

        ' Initialize a new instance of the DataSet object
        objFSSptDataSet = New DataSet()

        ' Open the connection, execute the command
        objFSSptConnection.Open()

        ' Fill DataSet
        objFSSptDataAdapter.Fill(objFSSptDataSet, "FSsupport")

        ' Close the connection
        objFSSptConnection.Close()

        ' Set the DataView object to the DataSet object
        objFSSptDataView = New DataView(objFSSptDataSet.Tables("FSsupport"))

        ' Populate postType combo box
        Me.cmbPostType.DataSource = objFSSptDataSet.Tables("FSsupport")
        Me.cmbPostType.DisplayMember = "FSpostType"
        Me.cmbPostType.Text = "Select Type III Support"

        ' Populate hardware combo box
        Me.cmbHardware.DataSource = objFSSptDataSet.Tables("FSsupport")
        Me.cmbHardware.DisplayMember = "FShardware"
        Me.cmbHardware.Text = ""

    End Sub

    Public Sub PopulateEXTSupport()
        ' EXTsupport (Db1 Db) Connection
		Dim objExtSptConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objExtSptDataAdapter As New OleDbDataAdapter( _
            "SELECT EXTpostType, EXThardware FROM EXTsupport ORDER BY EXTpostType", objExtSptConnection)

        Dim objExtSptDataSet As DataSet
        Dim objExtSptDataView As DataView

        ' Initialize a new instance of the DataSet object
        objExtSptDataSet = New DataSet()

        ' Open the connection, execute the command
        objExtSptConnection.Open()

        ' Fill DataSet
        objExtSptDataAdapter.Fill(objExtSptDataSet, "EXTsupport")

        ' Close the connection
        objExtSptConnection.Close()

        ' Set the EXTsupport DataView object to the DataSet object
        objExtSptDataView = New DataView(objExtSptDataSet.Tables("EXTsupport"))

        ' Populate postType combo box
        Me.cmbExtMounting.DataSource = objExtSptDataSet.Tables("EXTsupport")
        Me.cmbExtMounting.DisplayMember = "EXTpostType"
        Me.cmbExtMounting.Text = "Select"

        ' Populate hardware combo box
        Me.cmbExtHardware.DataSource = objExtSptDataSet.Tables("EXTsupport")
        Me.cmbExtHardware.DisplayMember = "EXThardware"
        Me.cmbExtHardware.Text = "Select"

    End Sub

    Public Sub PopulateHeights()

        ' sizes (Db1 Db) Connection
		Dim objHeightConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objHeightDataAdapter As New OleDbDataAdapter( _
            "SELECT * FROM heightSizes ORDER By ID", objHeightConnection)

        Dim objHeightDataSet As DataSet
        Dim objHeightDataView As DataView

        ' Initialize a new instance of the DataSet object
        objHeightDataSet = New DataSet()

        ' Open the connection, execute the command
        objHeightConnection.Open()

        ' Fill DataSet
        objHeightDataAdapter.Fill(objHeightDataSet, "heightSizes")

        ' Close the connection
        objHeightConnection.Close()

        ' Set the EXTsupport DataView object to the DataSet object
        objHeightDataView = New DataView(objHeightDataSet.Tables("heightSizes"))

        ' Populate SptSizes combo box
        Me.cmbSptSize.DataSource = objHeightDataSet.Tables("heightSizes")
        Me.cmbSptSize.DisplayMember = "height"
        Me.cmbSptSize.Text = "Select"

        ' Populate 3x4Sizes combo box
        Me.cmbWPAngleSize.DataSource = objHeightDataSet.Tables("heightSizes")
        Me.cmbWPAngleSize.DisplayMember = "height"
        Me.cmbWPAngleSize.Text = "Select"

    End Sub

    Public Sub PopulateSelectType()
        With cmbSelectType.Items
            .Add("IA")
            .Add("IB")
            .Add("IIA")
            .Add("IIB")
            .Add("IIIA")
            .Add("IIIB")
        End With
        Me.cmbSelectType.Text = "Type"
    End Sub

    Public Sub PopulateDetails()
        ' signDetails (Db1 Db) Connection
		Dim objDetailsConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objDetailsDataAdapter As New OleDbDataAdapter( _
            "SELECT details FROM signDetails ORDER BY details", objDetailsConnection)

        Dim objDetailsDataSet As DataSet
        Dim objDetailsDataView As DataView

        ' Initialize a new instance of the DataSet object
        objDetailsDataSet = New DataSet()

        ' Open the connection, execute the command
        objDetailsConnection.Open()

        ' Fill DataSet
        objDetailsDataAdapter.Fill(objDetailsDataSet, "signDetails")

        ' Close the connection
        objDetailsConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objDetailsDataView = New DataView(objDetailsDataSet.Tables("signDetails"))

        ' Populate contractor combo box
        Me.cmbDetails.DataSource = objDetailsDataSet.Tables("signDetails")
        Me.cmbDetails.DisplayMember = "details"
        Me.cmbDetails.Text = "Preset Details"
    End Sub

    Public Sub PopulateEXTSheeting()

        ' sheetingType (Db1 Db) Connection
		Dim objEXTSheetConnection As New OleDbConnection _
		   (My.Settings.SignINconn)
        Dim objSheetDataAdapter As New OleDbDataAdapter( _
            "SELECT sheetNum, sheetDesc FROM EXTsheeting", objEXTSheetConnection)
        Dim objEXTSheetDataSet As DataSet
        Dim objEXTSheetDataView As DataView


        ' Initialize a new instance of the DataSet object
        objEXTSheetDataSet = New DataSet()

        ' Open the connection, execute the command
        objEXTSheetConnection.Open()

        ' Fill DataSet
        objSheetDataAdapter.Fill(objEXTSheetDataSet, "EXTsheeting")

        ' Close the connection
        objEXTSheetConnection.Close()

        ' Set the Contractors DataView object to the DataSet object
        objEXTSheetDataView = New DataView(objEXTSheetDataSet.Tables("EXTsheeting"))

        'Populate Extruded sheeting combo box
        Me.cmbExtColor.DataSource = objEXTSheetDataSet.Tables("EXTsheeting")
        Me.cmbExtColor.DisplayMember = "sheetNum"
        Me.cmbExtColor.Text = ""



    End Sub

#End Region


    Public Function cantsTrussBeamQty(ByVal sW As Integer) As Integer

        Dim bQty As Integer

        Select Case sW
            Case 4 To 16
                bQty = 2
            Case 17 To 28
                bQty = 3
            Case Is >= 29
                bQty = 4
        End Select

        Return bQty

    End Function

    Private Sub addCluster(ByVal jn As String, ByVal site As String, ByVal spt As String)

        Try
            ' Declare objects
            Dim objEXTCommand As OleDbCommand = New OleDbCommand

            ' Open the connection
            objEXTConnection.Open()

            ' Set the OleDbCommand object properties
            objEXTCommand.Connection = objEXTConnection
            objEXTCommand.CommandText = _
                        "INSERT INTO tblClusters " & _
                            "(mhsJob, station, support) " & _
                            "VALUES(@mhsJob,@station,@support)"


            ' Add placeholder parameters 
            objEXTCommand.Parameters.AddWithValue("@mhsJob", jn)
            objEXTCommand.Parameters.AddWithValue("@station", site)
            objEXTCommand.Parameters.AddWithValue("@support", spt)



            ' Execute the OleDbCommand object to insert the new data
            Try
                objEXTCommand.ExecuteNonQuery()
            Catch OleDbExceptionErr As OleDbException
                MessageBox.Show(OleDbExceptionErr.Message)
            End Try

            ' Close the connection
            objEXTConnection.Close()

            Me.ToolStripStatusLabel1.Text = "Cluster added successfully"

        Catch NullExceptionErr As NullReferenceException
            MessageBox.Show(NullExceptionErr.Message)
        End Try


    End Sub

    Private Sub btnCluster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCluster.Click

        addCluster(Me.cmbMHSJobNum.Text, Me.txtStation.Text, Me.cmbPostType.Text)

    End Sub
End Class