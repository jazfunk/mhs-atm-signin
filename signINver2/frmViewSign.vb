Option Strict On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources






Public Class frmViewSign



    Public Sub New(ByVal sT As Integer, ByVal sI As Integer)


        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        sIdentity = sI
        typeOfSign = sT



    End Sub



#Region " Class-Level Declarations"

    Dim mhsJN As String

    Dim typeOfSign As Integer
    Dim sIdentity As Integer

    Dim extSupport As String



    ' Dictionary(Of TKey, TValue)
    Private dctExtSpt As New Dictionary(Of String, String)
    Private dctHeights As New Dictionary(Of Double, String)
    Private dctEXTSheeting As New Dictionary(Of String, String)
    Private dctPWSpt As New Dictionary(Of String, String)
    Private dctFSSpt As New Dictionary(Of String, String)
    Private dctSheeting As New Dictionary(Of String, String)








#End Region

#Region " Properties"


    'Public Property SignType() As String
    '    Get
    '        Return typeOfSign

    '    End Get
    '    Set(ByVal value As String)
    '        typeOfSign = value
    '    End Set
    'End Property



    Public Property SignID() As Integer
        Get
            Return sIdentity

        End Get
        Set(ByVal value As Integer)
            sIdentity = value
        End Set
    End Property


#End Region

#Region " Events"

    ' Declare an event.
    Public Event SignViewerClosed()


#End Region

#Region " Database Communication"



    
    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)


    ' Sign TOF Item
    Dim signDA As OleDbDataAdapter
    Dim signBS As BindingSource
    Dim signDS As DataSet
    Dim signDT As DataTable
    Dim signDV As DataView

    

    ' MHS Jobs
    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
    Dim mhsJobDV As DataView
    Dim mhsJobDT As DataTable



    ' EXT sheeting (combo box)
    Dim sheetDA As OleDbDataAdapter
    Dim sheetDS As DataSet
    Dim sheetDV As DataView
    Dim sheetDT As DataTable

    ' PW/FS Sheeting
    Dim allSheetDA As OleDbDataAdapter
    Dim allSheetDS As DataSet
    Dim allSheetDV As DataView
    Dim allSheetDT As DataTable

    ' Extruded support/hardware
    'Dim extSptBS As BindingSource
    Dim extSptDA As OleDbDataAdapter
    Dim extSptDS As DataSet
    Dim extSptDT As DataTable
    Dim extSptDV As DataView

    ' Plywood support/hardware
    Dim pwSptDA As OleDbDataAdapter
    Dim pwSptDS As DataSet
    Dim pwSptDT As DataTable
    Dim pwSptDV As DataView

    ' FlatSheet support/hardware
    Dim fsSptDA As OleDbDataAdapter
    Dim fsSptDS As DataSet
    Dim fsSptDT As DataTable
    Dim fsSptDV As DataView


    ' Heights
    Dim heightsDA As OleDbDataAdapter
    Dim heightsDS As DataSet
    Dim heightsDT As DataTable
    Dim heightsDV As DataView

    ' Sign Codes
    Dim scDA As OleDbDataAdapter
    Dim scDS As DataSet
    Dim scDT As DataTable
    Dim scDV As DataView

    ' PreSet Sign Details
    Dim detailsDA As OleDbDataAdapter
    Dim detailsDS As DataSet
    Dim detailsDT As DataTable
    Dim detailsDV As DataView





#End Region

#Region " Methods & Functions"

    Public Sub RetrieveExtrudedSign()

        With Me.cmbSelectType.Items
            .Add("IA")
			.Add("IB")
			.Add("IC")
			.Add("ID")
			.Add("I")
		End With

        ' Show Extruded Panel
        PickPanelToShow(True)


        Try

            '  connection to database
            signDA = New OleDbDataAdapter("SELECT " & _
                                                       "ID, " & _
                                                       "mhsJob, " & _
                                                       "dir, " & _
                                                       "station, " & _
                                                       "parentSign, " & _
                                                       "B2B, " & _
                                                       "type, " & _
                                                       "code, " & _
                                                       "details, " & _
                                                       "width, " & _
                                                       "height, " & _
                                                       "sqrFeet, " & _
                                                       "sptQty, " & _
                                                       "support, " & _
                                                       "retain, " & _
                                                       "sheeting, " & _
                                                       "twelveInch, " & _
                                                       "sixInch, " & _
                                                       "eightWF, " & _
                                                       "sixWF, " & _
                                                       "fiveWF, " & _
                                                       "threeByFour, " & _
                                                       "twoByTwo, " & _
                                                       "hdwQty, " & _
                                                       "hardware, " & _
                                                       "entryDate " & _
                                                       "FROM ExtrudedTOF WHERE ID = " & Me.SignID & "", mhsConn)

            'One CommandBuilder object is required. 
            'It automatically generates DeleteCommand, 
            'UpdateCommand and InsertCommand 
            'for DataAdapter object      
            Dim signCB As OleDbCommandBuilder = New OleDbCommandBuilder(signDA)

            ' Initialize a new instance of the DataSet object
            signDS = New DataSet()

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Fill DataSet
            signDA.Fill(signDS, "ExtrudedTOF")

            ' Close the connection
            mhsConn.Close()

            ' Create binding source
            signBS = New BindingSource(signDS, "ExtrudedTOF")

            ' DataTable -   Fill the DataTable object with data
            signDT = signDS.Tables("ExtrudedTOF")

            ' Set the DataView object to the DataSet object
            signDV = New DataView(signDS.Tables("ExtrudedTOF"))

			

            ' Clear DataBindings
            Me.lblJobNumber.DataBindings.Clear()
            Me.txtStation.DataBindings.Clear()
            Me.cmbSelectType.DataBindings.Clear()
            Me.txtSignCode.DataBindings.Clear()
            Me.txtSignDetails.DataBindings.Clear()

            Me.cmbDirection.DataBindings.Clear()
            Me.txtParent.DataBindings.Clear()
            Me.txtExtB2B.DataBindings.Clear()
            Me.txtExtWidth.DataBindings.Clear()
            Me.txtExtHeight.DataBindings.Clear()
            Me.txtExtSqrFeet.DataBindings.Clear()
            Me.txtExtSptQty.DataBindings.Clear()
            Me.cmbExtMounting.DataBindings.Clear()
            Me.ckbRetain.DataBindings.Clear()
            Me.cmbExtColor.DataBindings.Clear()
            Me.txt12Plank.DataBindings.Clear()
            Me.txt6Plank.DataBindings.Clear()
            Me.cmbBeamsAngle.DataBindings.Clear()




            ' Add DataBindings
            Me.lblJobNumber.DataBindings.Add("Text", signBS, "mhsJob")
            Me.txtStation.DataBindings.Add("Text", signBS, "station")
            Me.cmbSelectType.DataBindings.Add("Text", signBS, "type")
            Me.txtSignCode.DataBindings.Add("Text", signBS, "code")
            Me.txtSignDetails.DataBindings.Add("Text", signBS, "details")


            Me.cmbDirection.DataBindings.Add("Text", signBS, "dir")
            Me.txtParent.DataBindings.Add("Text", signBS, "parentSign")
            Me.txtExtB2B.DataBindings.Add("Text", signBS, "b2b")
            Me.txtExtWidth.DataBindings.Add("Text", signBS, CStr("width"))
            Me.txtExtHeight.DataBindings.Add("Text", signBS, CStr("height"))
            Me.txtExtSqrFeet.DataBindings.Add("Text", signBS, CStr("sqrFeet"))
            Me.txtExtSptQty.DataBindings.Add("Text", signBS, CStr("sptQty"))
            Me.cmbExtMounting.DataBindings.Add("Text", signBS, "support")
            Me.ckbRetain.DataBindings.Add("Checked", signBS, "retain")
            Me.cmbExtColor.DataBindings.Add("Text", signBS, "sheeting")
            Me.txt12Plank.DataBindings.Add("Text", signBS, CStr("twelveInch"))
			Me.txt6Plank.DataBindings.Add("Text", signBS, CStr("sixInch"))


            Me.Icon = My.Resources.new_extruded_1



			'If signDS.Tables.Count <= 0 Then

			'    MessageBox.Show("No Record to show.  Press 'OK' to close")
			'    Me.Close()

			'End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "RetrieveExtrudedSign()")

        End Try



        Me.btnCancel.Select()




    End Sub

    Public Sub RetrievePlywoodSign()

        BindPWSpt()

        With Me.cmbSelectType.Items
            .Add("IIA")
			.Add("IIB")
			.Add("IIC")
			.Add("IID")
			.Add("II")
        End With

        ' Show Plywood/FS Panel
        PickPanelToShow(False)

        Try

            signDA = New OleDbDataAdapter("SELECT ID, " & _
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
                                          "FROM plywoodTOF WHERE ID = " & Me.SignID & "", mhsConn)

            'One CommandBuilder object is required. 
            'It automatically generates DeleteCommand, 
            'UpdateCommand and InsertCommand 
            'for DataAdapter object      
            Dim signCB As OleDbCommandBuilder = New OleDbCommandBuilder(signDA)

            ' Initialize a new instance of the DataSet object
            signDS = New DataSet()

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Fill DataSet
            signDA.Fill(signDS, "plywoodTOF")

            ' Close the connection
            mhsConn.Close()

            ' Create binding source
            signBS = New BindingSource(signDS, "plywoodTOF")

            ' DataTable -   Fill the DataTable object with data
            signDT = signDS.Tables("plywoodTOF")

            ' Set the DataView object to the DataSet object
            signDV = New DataView(signDS.Tables("plywoodTOF"))



            ' Clear DataBindings
            Me.lblJobNumber.DataBindings.Clear()
            Me.txtStation.DataBindings.Clear()
            Me.cmbSelectType.DataBindings.Clear()
            Me.txtSignCode.DataBindings.Clear()
            Me.txtSignDetails.DataBindings.Clear()
            Me.txtSignWidth.DataBindings.Clear()
            Me.txtSignHeight.DataBindings.Clear()
            Me.txtSqrFeet.DataBindings.Clear()
            Me.txtSupportQty.DataBindings.Clear()
            Me.cmbPostType.DataBindings.Clear()
            Me.txtHardwareQty.DataBindings.Clear()
            Me.txtHardware.DataBindings.Clear()
            Me.cmbSheetType.DataBindings.Clear()
          
            ' Add DataBindings
            Me.lblJobNumber.DataBindings.Add("Text", signBS, "mhsJob")
            Me.txtStation.DataBindings.Add("Text", signBS, "station")
            Me.cmbSelectType.DataBindings.Add("Text", signBS, "type")
            Me.txtSignCode.DataBindings.Add("Text", signBS, "code")
            Me.txtSignDetails.DataBindings.Add("Text", signBS, "details")
            Me.txtSignWidth.DataBindings.Add("Text", signBS, "width")
            Me.txtSignHeight.DataBindings.Add("Text", signBS, "height")
            Me.txtSqrFeet.DataBindings.Add("Text", signBS, "sqrFeet")
            Me.txtSupportQty.DataBindings.Add("Text", signBS, "sptQty")
            Me.cmbPostType.DataBindings.Add("Text", signBS, "support")
            Me.txtHardwareQty.DataBindings.Add("Text", signBS, "hdwQty")
            Me.txtHardware.DataBindings.Add("Text", signBS, "hdw")
            Me.cmbSheetType.DataBindings.Add("Text", signBS, "sheeting")
           
            Me.Icon = My.Resources.new_plywood_1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "RetrievePlywoodSign()")

        End Try



        Me.btnCancel.Select()


    End Sub

    Public Sub RetrieveFlatSheetSign()

        BindFSSpt()

        With Me.cmbSelectType.Items
            .Add("IIIA")
			.Add("IIIB")
			.Add("IIIC")
			.Add("IIID")
			.Add("III")
			.Add("VA")
			.Add("VB")
			.Add("VC")
			.Add("V")
		End With


        ' Show Plywood/FS Panel
        PickPanelToShow(False)

        Try

            signDA = New OleDbDataAdapter("SELECT ID, " & _
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
                                          "FROM flatSheetTOF WHERE ID = " & Me.SignID & "", mhsConn)

            'One CommandBuilder object is required. 
            'It automatically generates DeleteCommand, 
            'UpdateCommand and InsertCommand 
            'for DataAdapter object      
            Dim signCB As OleDbCommandBuilder = New OleDbCommandBuilder(signDA)

            ' Initialize a new instance of the DataSet object
            signDS = New DataSet()

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Fill DataSet
            signDA.Fill(signDS, "flatSheetTOF")

            ' Close the connection
            mhsConn.Close()

            ' Create binding source
            signBS = New BindingSource(signDS, "flatSheetTOF")

            ' DataTable -   Fill the DataTable object with data
            signDT = signDS.Tables("flatSheetTOF")

            ' Set the DataView object to the DataSet object
            signDV = New DataView(signDS.Tables("flatSheetTOF"))



            ' Clear DataBindings
            Me.lblJobNumber.DataBindings.Clear()
            Me.txtStation.DataBindings.Clear()
            Me.cmbSelectType.DataBindings.Clear()
            Me.txtSignCode.DataBindings.Clear()
            Me.txtSignDetails.DataBindings.Clear()
            Me.txtSignWidth.DataBindings.Clear()
            Me.txtSignHeight.DataBindings.Clear()
            Me.txtSqrFeet.DataBindings.Clear()
            Me.txtSupportQty.DataBindings.Clear()
            Me.cmbPostType.DataBindings.Clear()
            Me.txtHardwareQty.DataBindings.Clear()
            Me.txtHardware.DataBindings.Clear()
            Me.cmbSheetType.DataBindings.Clear()
          
            ' Add DataBindings
            Me.lblJobNumber.DataBindings.Add("Text", signBS, "mhsJob")
            Me.txtStation.DataBindings.Add("Text", signBS, "station")
            Me.cmbSelectType.DataBindings.Add("Text", signBS, "type")
            Me.txtSignCode.DataBindings.Add("Text", signBS, "code")
            Me.txtSignDetails.DataBindings.Add("Text", signBS, "details")
            Me.txtSignWidth.DataBindings.Add("Text", signBS, "width")
            Me.txtSignHeight.DataBindings.Add("Text", signBS, "height")
            Me.txtSqrFeet.DataBindings.Add("Text", signBS, "sqrFeet")
            Me.txtSupportQty.DataBindings.Add("Text", signBS, "sptQty")
            Me.cmbPostType.DataBindings.Add("Text", signBS, "support")
            Me.txtHardwareQty.DataBindings.Add("Text", signBS, "hdwQty")
            Me.txtHardware.DataBindings.Add("Text", signBS, "hdw")
            Me.cmbSheetType.DataBindings.Add("Text", signBS, "sheeting")
           
            Me.Icon = My.Resources.new_flatsheet_1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "RetrieveFlatSheetSign()")

        End Try


        Me.btnCancel.Select()



    End Sub

    Private Sub RaiseAnEvent()


        RaiseEvent SignViewerClosed()



    End Sub



    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.signBS.EndEdit()

            Dim tbl As String = Nothing
			Select Case typeOfSign
				Case 1
					tbl = "ExtrudedTOF"

				Case 2
					tbl = "plywoodTOF"

				Case 3, 4
					tbl = "flatSheetTOF"
			End Select


			If Not tbl Is Nothing Then
				Me.signDA.Update(Me.signDS.Tables(tbl))
				Me.Text = Me.Text & "   (Updated)"
			Else
				Me.Text = Me.Text & "    NOT UPDATED!!!"
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "updateDB()")

		End Try

    End Sub




    Private Sub PickPanelToShow(ByVal t As Boolean)
        Try

            Select Case t

                Case True
                    ' Extruded Panel
                    Me.SplitContainerTYPES.Panel1Collapsed = False
                    Me.SplitContainerTYPES.Panel2Collapsed = True
                   
                Case False
                    ' FlatSheet and Plywood Panel
                    Me.SplitContainerTYPES.Panel2Collapsed = False
                    Me.SplitContainerTYPES.Panel1Collapsed = True
                    
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "PickPanelToShow()")

        End Try
    End Sub

    Private Sub ShowTypeImage()





    End Sub



    Private Sub ShowSignImageTOF()

      

        Dim imageName As String = Me.txtSignCode.Text.ToString
        Dim viewImage As String = imageName & ".jpg"

        Try
            Me.picSign.Load(My.Resources.imgPath & viewImage)
        Catch ex As Exception
            Me.picSign.Image = My.Resources.none1
            'Me.lblSignCodeDesc.Text = ""
            'Me.lblType.Text = ""
            'Me.lblPdfTitle.Text = ""
        End Try


    End Sub

    Private Sub VisualEXTSheetingColor(ByVal sender As Object, ByVal e As System.EventArgs) _
                            Handles cmbExtColor.SelectedIndexChanged


        Try

            With Me.PictureBoxExtSheeting


                ' Add the Description from the Dictionary
                ' to the textBox
                Me.lblExtSheeting.Text = Me.dctEXTSheeting.Item(Me.cmbExtColor.Text)

                Select Case Me.cmbExtColor.Text

                    Case "3930", "3990", "4090"
                        .BackColor = Color.White
                        Me.lblExtSheeting.ForeColor = Color.Black
                        Me.lblExtSheeting.BackColor = Color.White
                    Case "3935", "3995", "4095", "1175C"
                        .BackColor = Color.Blue
                        Me.lblExtSheeting.ForeColor = Color.White
                        Me.lblExtSheeting.BackColor = Color.Blue
                    Case "3937", "3997", "4097", "1177C"
                        .BackColor = Color.Green
                        Me.lblExtSheeting.ForeColor = Color.White
                        Me.lblExtSheeting.BackColor = Color.Green
                    Case "3939", "4039", "1179C"
                        .BackColor = Color.Brown
                        Me.lblExtSheeting.ForeColor = Color.White
                        Me.lblExtSheeting.BackColor = Color.Brown
                    Case "3981", "4081", "3931"
                        .BackColor = Color.Yellow
                        Me.lblExtSheeting.ForeColor = Color.Black
                        Me.lblExtSheeting.BackColor = Color.Yellow
                    Case "3983", "4083"
                        .BackColor = Color.YellowGreen
                        Me.lblExtSheeting.ForeColor = Color.Black
                        Me.lblExtSheeting.BackColor = Color.YellowGreen
                    Case Else
                        .BackColor = Color.Transparent
                        Me.lblExtSheeting.ForeColor = Color.Black
                        Me.lblExtSheeting.BackColor = Color.White

                End Select

            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, "VisualEXTSheetingColor()")

        End Try




    End Sub

    Private Sub VisualSheetingColor(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbSheetType.SelectedIndexChanged, cmbSheetType.TextChanged


        Try

            ' Add the sheeting description from the Dictionary
            ' to the textBox
            Try
                Me.lblSheetingColor.Text = Me.dctSheeting.Item(Me.cmbSheetType.Text)
            Catch ex As Exception

            End Try

            Select Case cmbSheetType.Text
                Case "3930"
                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White

                Case "3981"
                    Me.PictureBoxSheeting.BackColor = Color.Yellow
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Yellow

                Case "3983"
                    Me.PictureBoxSheeting.BackColor = Color.YellowGreen
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.YellowGreen

                Case "3990"
                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White

                Case "3932"
                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Red

                Case "3935"
                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Blue

                Case "3937"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green

                Case "3939"
                    Me.PictureBoxSheeting.BackColor = Color.Brown
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Brown

                Case "3924"
                    Me.PictureBoxSheeting.BackColor = Color.Orange
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Orange

                Case "1172C"
                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Red

                Case "1175C"
                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Blue

                Case "1177C"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green

                Case "3650-12"
                    Me.PictureBoxSheeting.BackColor = Color.Black
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Black

                Case "3997"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green





                Case "4090"
                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White

                Case "4081"
                    Me.PictureBoxSheeting.BackColor = Color.Yellow
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Yellow

                Case "4083"
                    Me.PictureBoxSheeting.BackColor = Color.YellowGreen
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.YellowGreen




                Case Else
                    Me.PictureBoxSheeting.BackColor = Color.Transparent
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Transparent


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VisualSheetingColor()")
        End Try


    End Sub



    Private Sub EnableAll()

        Me.btnCluster.Enabled = True
        Me.btnConvert.Enabled = True
        Me.btnDown.Enabled = True
        Me.btnUp.Enabled = True
        Me.btnUpdate.Enabled = True
        Me.btnBtoB.Enabled = True
        Me.btnSinglePost.Enabled = True

        Me.PictureBoxSheeting.Visible = True
        Me.PictureBoxExtSheeting.Visible = True


    End Sub

    Public Sub DisableAll()

        btnCluster.Enabled = False
        Me.btnConvert.Enabled = False
        Me.btnDown.Enabled = False
        Me.btnUp.Enabled = False
        Me.btnUpdate.Enabled = False
        Me.btnBtoB.Enabled = False
        Me.btnSinglePost.Enabled = False


    End Sub





    Public Sub CalcSqFt()

        Try
            If Me.txtSignHeight.Text IsNot String.Empty Then
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

    End Sub

    Public Sub CalcEXTSqFt()  ' Also counts number of 12" and 6" plank

        Try
            If Me.txtExtHeight.Text IsNot String.Empty Then
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

        Catch ex As Exception

        End Try

    End Sub

    Public Function ShowDecimalRound(ByVal Argument As Decimal, ByVal Digits As Integer) As Double

        ' Returns a rounded version of the decimal provided
        ' First Argument ("Argument") is the decimal to be rounded
        ' Second Argumnet ("Digits") is the number of decimal places to include
        ' (i.e. ShowDecimalRound(22.2234,2) returns 22.23)

        Try
            Dim rounded As Decimal = Decimal.Round(Argument, Digits)
            Return rounded

        Catch ex As Exception

        End Try

    End Function

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





    '  Great DataTable.Select() Method example
    Private Sub AutoBeamAngleSize(ByVal spt_height As Double)

        Try
            Dim foundRows() As DataRow

            foundRows = Me.heightsDT.Select("metricEquivalent = '" & spt_height & "'")

            If Me.cmbExtMounting.Text = "Exit Panel" Then

                Me.cmbSptSize.SelectedIndex = 13
                Me.cmbWPAngleSize.SelectedIndex = 13

            Else
                Me.cmbSptSize.Text = CStr(foundRows(0)(1))
                Me.cmbWPAngleSize.Text = CStr(foundRows(0)(1))

            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub AutoEXTSupport(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbExtMounting.SelectedIndexChanged
        Try

            extSupport = Me.cmbExtMounting.Text

            ' Add the Hardware from the Dictionary
            ' to the textBox
            Me.txtEXTHdw.Text = Me.dctExtSpt.Item(extSupport)


            Select Case extSupport

                Case "4x6 W/P"


                Case "6x8 W/P"


                Case "Column"

                    Try

                        Dim sHt As Double = CDbl(Me.txtExtHeight.Text)
                        Dim roundUP As Integer = CInt(Math.Ceiling(sHt))
                        Dim hdwQty As Integer = (roundUP + 3) * 2
                        Me.txtExtHdwQty.Text = CStr(hdwQty)
                        Me.cmbBeamsAngle.Text = "2x2"
                        Me.txtExtSptQty.Text = CStr(2)


                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try



                Case "Exit Panel"


                    Try

                        If Me.txt6Plank.Text Is String.Empty Then
                            Me.txtExtHdwQty.Text = CStr(33)
                        Else
                            Me.txtExtHdwQty.Text = CStr(30)
                        End If

                        Me.cmbExtColor.Text = "3937"
                        Me.txtExtSptQty.Text = CStr(3)
                        Me.cmbBeamsAngle.Text = "2x2"
                        Me.cmbSptSize.SelectedIndex = 13         ' (8' - 0")
                        'Me.txtParent.Select()


                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try



                Case "Bridge Conn"

                    Try
                        'Me.cmbBeamsAngle.Select()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try


                Case "C-Truss 50' - 70'"

                    Try
                        Me.cmbBeamsAngle.Text = "5WF"
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        'Me.btnAddSign.Select()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try


                Case "C/D-Truss"

                    Try
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        Me.cmbBeamsAngle.Text = "5WF"
                        'Me.btnAddSign.Select()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try


                Case "E/D/G-Cant"
                    Try
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        Me.cmbBeamsAngle.Text = "5WF"
                        'Me.btnAddSign.Select()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try


                Case "Advisory Panel"

                    Try
                        Me.cmbExtColor.Text = "3981"

                        ' Disable unnecessary fields
                        Me.txtExtHdwQty.Text = String.Empty

                        Me.cmbBeamsAngle.Text = String.Empty
                        Me.cmbSptSize.Text = String.Empty
                        Me.txtExtSptQty.Text = String.Empty

                        Me.btn3WP.Visible = False
                        Me.PanelNotWP.Visible = True
                        Me.PanelWP.Visible = False

                        'Me.txtParent.Select()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try



                Case "E-Truss 50'-105'"

                    Try
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        Me.cmbBeamsAngle.Text = "5WF"
                        'Me.btnAddSign.Select()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try


                Case "E-Truss 110'-140'"

                    Try
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        Me.cmbBeamsAngle.Text = "5WF"
                        'Me.btnAddSign.Select()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                Case "J-Cant"

                    Try
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        Me.cmbBeamsAngle.Text = "5WF"
                        'Me.btnAddSign.Select()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                Case "C-Cant"

                    Try
                        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text)))
                        Me.cmbBeamsAngle.Text = "5WF"
                        'Me.btnAddSign.Select()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)

                    End Try

            End Select




            ' PanelNotWP, PanelWP location x 160, y 105  ----  This is the visible location


            If extSupport = "4x6 W/P" Or extSupport = "6x8 W/P" Then

                PanelNotWP.Visible = False
                PanelWP.Visible = True
                PanelWP.Location = New Point(169, 93)

                Me.lblExtB2B.Visible = False
                Me.txtExtB2B.Visible = False
                Me.btnExtBtoB.Visible = True
                Me.btn3WP.Visible = True

                Me.txt3X4Qty.Text = CStr(2)
                Me.txt2X2Qty.Text = CStr(2)

                Try
                    If Me.txtExtHeight.Text <> String.Empty Then
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
                Catch ex As Exception

                End Try


            Else
                Try

                    Me.btn3WP.Visible = False
                    PanelNotWP.Visible = True
                    PanelWP.Visible = False

                Catch ex As Exception

                End Try
            End If





        Catch ex As Exception

        End Try




    End Sub

    Private Function CantsTrussBeamQty(ByVal sW As Integer) As Integer
        Try
            Dim bQty As Integer

			Select Case sW
				Case 4 To 11
					bQty = 2	' 2 Beams
				Case 12 To 22
					bQty = 3	' 3 Beams
				Case 23 To 33
					bQty = 4	' 4 Beams
				Case Is >= 34
					bQty = 5	' 5 Beams
			End Select

            Return bQty

        Catch ex As Exception
            Return Nothing
        End Try


    End Function




    



    Private Sub addCluster(ByVal jn As String, ByVal site As String, ByVal spt As String)

        ' Declare objects
        Dim objEXTCommand As OleDbCommand = New OleDbCommand

        ' Open the connection
        mhsConn.Open()

        ' Set the OleDbCommand object properties
        objEXTCommand.Connection = mhsConn
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
            Me.Text = Me.Text & "   (Cluster added successfully)"

            'Me.ToolStripStatusLabel1.Text = "Cluster added successfully"

        Catch OleDbExceptionErr As OleDbException
            MessageBox.Show(OleDbExceptionErr.Message)
            'Me.ToolStripStatusLabel1.Text = "Cluster Not Added!"

        End Try

        ' Close the connection
        mhsConn.Close()

    End Sub



    Public Sub IdentifySheetingEXT(ByVal signCode As String)
        Try
            ' Set Sheeting Type and various details
            If signCode.ToUpper.Substring(0, 3) = "D10" Then
                Me.cmbExtColor.Text = "3990"
                Me.txtExtHdwQty.Text = CStr(3)

            ElseIf signCode.ToUpper.Substring(0, 3) = "D11" Then
                Me.cmbExtColor.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 3) = "D12" Then
                Me.cmbExtColor.Text = "3935"

            ElseIf signCode.ToUpper.Substring(0, 3) = "D13" Then
                Me.cmbExtColor.Text = "3935"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D1" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D2" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D3" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D4" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D5" Then
                Me.cmbExtColor.Text = "3935"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D6" Then
                Me.cmbExtColor.Text = "3935"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D7" Then
                Me.cmbExtColor.Text = "3939"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D8" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "D9" Then
                Me.cmbExtColor.Text = "3935"

            ElseIf signCode.ToUpper.Substring(0, 1) = "W" Then
                Me.cmbExtColor.Text = "3981"

            ElseIf signCode.ToUpper.Substring(0, 1) = "O" Then
                Me.cmbExtColor.Text = "3981"
                Me.txtExtHdwQty.Text = CStr(3)

            ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
                Me.cmbExtColor.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbExtColor.Text = "3983"

            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbExtColor.Text = "3983"

            ElseIf signCode.ToUpper.Substring(0, 4) = "E1-5" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Exit Panel"
                Me.txtExtHeight.Text = CStr(2.5)

            ElseIf signCode = "E11-1A" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"

            ElseIf signCode = "E11-1B" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"
                Me.txtExtHeight.Text = CStr(2.5)


            ElseIf signCode = "E11-1C" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"
                Me.txtExtHeight.Text = CStr(2.5)

            ElseIf signCode = "E11-1D" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"
                Me.txtExtHeight.Text = CStr(2.5)

            ElseIf signCode = "E11-1E" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"
                Me.txtExtHeight.Text = CStr(2.5)

            ElseIf signCode = "E11-1F" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"
                Me.txtExtHeight.Text = CStr(2.5)

            ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode = "[SALVAGE]" Then
                Me.cmbExtColor.Text = "NONE"

            ElseIf signCode = "[MDOT]" Then
                Me.cmbExtColor.Text = "NONE"

            ElseIf signCode = "[LOGOS]" Then


            ElseIf signCode = "[TODS]" Then


            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub IdentifySheetingPW(ByVal signCode As String)
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
                Me.cmbSheetType.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                Me.cmbSheetType.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbSheetType.Text = "3983"

            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbSheetType.Text = "3983"

            ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
                Me.cmbSheetType.Text = "3937"

            ElseIf signCode = "[SALVAGE]" Then
                Me.cmbExtColor.Text = "NONE"

            ElseIf signCode = "[MDOT]" Then
                Me.cmbExtColor.Text = "NONE"

            ElseIf signCode = "[LOGOS]" Then


            ElseIf signCode = "[TODS]" Then



            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub IdentifySheetingFS(ByVal signCode As String)
        Try
            ' Set Sheeting Type and various details
            If signCode.ToUpper.Substring(0, 4) = "D10-" Then
                Me.cmbSheetType.Text = "3990"
                Me.txtHardwareQty.Text = CStr(3)

            ElseIf signCode.ToUpper.Substring(0, 1) = "D" Then
                Me.cmbSheetType.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 1) = "W" Then
                Me.cmbSheetType.Text = "3981"

            ElseIf signCode.ToUpper.Substring(0, 1) = "O" Then
                Me.cmbSheetType.Text = "3981"
                Me.txtHardwareQty.Text = CStr(3)

            ElseIf signCode.ToUpper.Substring(0, 4) = "R6-1" Then
                Me.cmbSheetType.Text = "3930"
                Me.txtSignWidth.Text = CStr(36)
                Me.txtSignHeight.Text = CStr(12)
                Me.txtSupportQty.Text = CStr(1)

            ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
                Me.cmbSheetType.Text = "3930"

            ElseIf signCode = "M1-1" Then
                Me.cmbSheetType.Text = "3930"
                Me.txtSupportQty.Text = CStr(1)

            ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
                Me.cmbSheetType.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                Me.cmbSheetType.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbSheetType.Text = "3983"

            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbSheetType.Text = "3983"

            ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
                Me.cmbSheetType.Text = "3930"

            ElseIf signCode = "[SALVAGE]" Then
                Me.cmbSheetType.Text = "NONE"

            ElseIf signCode = "[MDOT]" Then
                Me.cmbSheetType.Text = "NONE"

            ElseIf signCode = "[LOGOS]" Then


            ElseIf signCode = "[TODS]" Then


            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub




#End Region

#Region " Event Handlers"

    

    Private Sub frmViewSign_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        ' Testing to see if I can detect changes
        signBS.EndEdit()

        Select Case signDS.HasChanges

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

                        ' Raise SignViewClosed Event
                        RaiseAnEvent()


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



    Private Sub frmViewSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' Fill DataSet with DataAdapter connected to DataBase
        PopulateEXTSheeting()
        PopulateEXTSupport()
        PopulatePWSupport()
        PopulateFSSupport()
        PopulatePWandFSSheeting()
        PopulateHeights()
        PopulateSignCodes()
        PopulateDetails()

        BindSignCodeFields()
        BindDetails()


        'Me.lblPdfTitle.Visible = False
        Me.lblSignCodeDesc.Visible = False
        Me.lblType.Visible = False
        'Me.picSignImage.Visible = False


        Select Case typeOfSign

            Case 1

                RetrieveExtrudedSign()

                Me.PictureBoxLargeTypeI.Image = My.Resources.new_extruded_11
                Me.PictureBoxLargeTypeII.Image = Nothing

                Me.PictureBoxType.Image = My.Resources.new_extruded_1_24
                Me.lblEXTSignType.Text = "Extruded"


            Case 2

                RetrievePlywoodSign()

                Me.PictureBoxLargeTypeII.Image = My.Resources.new_plywood_11
                Me.PictureBoxLargeTypeI.Image = Nothing

                Me.PictureBoxType.Image = My.Resources.new_plywood_1_24
                Me.lblSignType.Text = "Plywood"


			Case 3, 5

				RetrieveFlatSheetSign()

				Me.PictureBoxLargeTypeII.Image = My.Resources.new_flatsheet_11
				Me.PictureBoxLargeTypeI.Image = Nothing

				Me.PictureBoxType.Image = My.Resources.new_flatsheet_1_24
				Me.lblSignType.Text = "Flatsheet"


			Case 4

				' Develop


			Case Else




		End Select

        PopulateMHSJobs()


    End Sub



    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        updateDb()
        RaiseAnEvent()


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click


        Dim okToDelete As DialogResult

        okToDelete = MessageBox.Show("OK to delete?", "Confirm Deletion", _
                                     MessageBoxButtons.OKCancel, _
                                     MessageBoxIcon.Question)

        Select Case okToDelete
            Case Windows.Forms.DialogResult.OK

                ' Delete record
                Me.signDV.Delete(0)

                ' Then close this form
                Me.Close()


            Case Windows.Forms.DialogResult.Cancel

                ' Do nothing


        End Select


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


        CalcSqFt()

       
    End Sub

    Private Sub txtExtHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtHeight.TextChanged


        CalcEXTSqFt()

        Try


            Dim spt_size As Double = CDbl(Me.txtExtHeight.Text)
            AutoBeamAngleSize(spt_size)

        Catch ex As Exception
			MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtExtWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtWidth.TextChanged


        CalcEXTSqFt()

       
    End Sub

    Private Sub txtExtSptQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtSptQty.TextChanged

        Dim s As String = Me.cmbExtMounting.Text

        Select Case s

            Case "Bridge Conn"

                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

            Case "C-Truss 50' - 70'"

                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text


            Case "C/D-Truss"

                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

            Case "E/D/G-Cant"

                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

            Case "E-Truss 50'-105'"

                'Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

            Case "E-Truss 110'-140'"

                'Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

            Case "J-Cant"

                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

            Case "C-Cant"

                Me.txtExtHdwQty.Text = Me.txtExtSptQty.Text

        End Select


    End Sub

    Private Sub txtSupportQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupportQty.TextChanged
        Try
            If txtSupportQty.Text <> String.Empty Then
                Dim hwareCount As Integer
                Dim supports As Integer = CInt(Me.txtSupportQty.Text)
                hwareCount = supports * 2
                Me.txtHardwareQty.Text = CStr(hwareCount)

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtExtSqrFeet_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtSqrFeet.DoubleClick

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

    Private Sub btnExtBtoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtBtoB.Click

        Try

            ' Hide/Show controls...
            Me.lblExtB2B.Visible = True
            Me.txtExtB2B.Visible = True
            Me.btnExtBtoB.Visible = False

            Me.txtExtHdwQty.Text = CStr(8)

            Me.txtExtB2B.Select()


        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn3WP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3WP.Click


        Try
            'threeWP = True

            Me.txt3X4Qty.Text = CStr(3)
            Dim hqty As Integer = CInt(Me.txtExtHdwQty.Text)
            Dim b As Integer = CInt(hqty / 2)
            Me.txtExtHdwQty.Text = CStr(hqty + b)

            If Me.btnExtBtoB.Visible = False Then
                Me.lblExtB2B.Visible = False
                Me.txtExtB2B.Visible = False
                Me.btnExtBtoB.Visible = True
            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            Dim tempPostCount As Integer = CInt(Me.txtSupportQty.Text)
            If tempPostCount >= 0 Then
                tempPostCount += 1
                Me.txtSupportQty.Text = CStr(tempPostCount)
            ElseIf tempPostCount >= 3 Then

                Dim increaseResult As DialogResult
                increaseResult = MessageBox.Show("Post count is greater than 3, are you sure?", _
                                             "Dubious Post Count", _
                                             MessageBoxButtons.OKCancel, _
                                             MessageBoxIcon.Information, _
                                             MessageBoxDefaultButton.Button1)

                Select Case increaseResult

                    Case Windows.Forms.DialogResult.OK

                        tempPostCount += 1
                        Me.txtSupportQty.Text = CStr(tempPostCount)

                    Case Windows.Forms.DialogResult.Cancel

                End Select

            End If

            tempPostCount = Nothing
            
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
            If tempPostCount > 0 Then
                tempPostCount -= 1
                Me.txtSupportQty.Text = CStr(tempPostCount)
            End If

            tempPostCount = Nothing

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

    Private Sub btnCluster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCluster.Click
        addCluster(Me.mhsJN, Me.txtStation.Text, Me.cmbPostType.Text)
    End Sub

    Private Sub btnBtoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBtoB.Click
        Me.txtSupportQty.Text = CStr(0)
    End Sub

    Private Sub btnSinglePost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinglePost.Click

        Try
            Me.txtSupportQty.Text = CStr(1)

            Me.txtSignDetails.Text = "DRILL FOR SINGLE POST"

        Catch ex As Exception

        End Try



    End Sub



    Private Sub txtHardware_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHardware.DoubleClick

        Me.txtHardware.ReadOnly = False

    End Sub



    Private Sub cmbSignCodes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbSignCodes.TextChanged, _
                        cmbSignCodes.SelectedIndexChanged

        Me.Cursor = Cursors.PanEast

        Try
            Me.txtSignCode.Text = Me.cmbSignCodes.Text

            If Me.cmbSignCodes.SelectedIndex > -1 Then
                Me.lblSignCodeDesc.Visible = True
                Me.lblType.Visible = True
                'Me.picSignImage.Visible = True
            Else

                'Me.cmbSelectType.Enabled = True

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "cmbSignCodes_TextChanged()")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub txtSignCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles txtSignCode.TextChanged, _
                        txtStation.TextChanged, _
                        txtExtSqrFeet.TextChanged, _
                        txtSqrFeet.TextChanged, _
                        cmbPostType.SelectedIndexChanged


        ShowSignImageTOF()

        Try

            Dim sC As String = Me.txtSignCode.Text

            Select Case Me.typeOfSign

                Case 1
                    IdentifySheetingEXT(sC)

                Case 2
                    IdentifySheetingPW(sC)

                Case 3
                    IdentifySheetingFS(sC)

                Case Else
                    IdentifySheetingFS(sC)

            End Select

            'If Me.lblType.Text.Trim = String.Empty Then
            '    Me.cmbSelectType.Enabled = True
            'Else
            '    Me.cmbSelectType.Enabled = False
            'End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


    End Sub



    Private Sub cmbDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetails.SelectedIndexChanged
        Try
            If Me.cmbDetails.Text <> "Preset Details" Then
                Me.txtSignDetails.Text = Me.cmbDetails.Text
            Else
                Me.txtSignDetails.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbPostType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPostType.SelectedIndexChanged

        Try
            '  To determine sign type.
            '  Then give appropriate action

            Select Case Me.typeOfSign


                Case 2

                    '  PLYWOOD
                    ' Add the Hardware from the Dictionary
                    ' to the textBox
                    Me.txtHardware.Text = Me.dctPWSpt.Item(Me.cmbPostType.Text)

                    If Me.cmbPostType.Text = "BRIDGE MOUNT" Then
                        Me.txtSupportQty.Text = CStr(0)
                        Me.txtHardwareQty.Text = CStr(0)

                    End If

                Case 3

                    '  FlATSHEET
                    ' Add the Hardware from the Dictionary
                    ' to the textBox
                    Me.txtHardware.Text = Me.dctFSSpt.Item(Me.cmbPostType.Text)


                Case Else



            End Select


        Catch ex As Exception

        End Try



    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub



#End Region


#Region " Populate ComboBoxes"


    Public Sub PopulateMHSJobs()



        Try

            Me.mhsJN = Me.lblJobNumber.Text.ToString

            mhsJobDA = New OleDbDataAdapter("SELECT custJob, " & _
                                            "cust, " & _
                                            "custJob, " & _
                                            "jobDesc, " & _
                                            "projNum, " & _
                                            "stateNum, " & _
                                            "compDate, " & _
                                            "active, " & _
                                            "MMMDisc FROM mhsJobs WHERE mhsJob = '" & Me.mhsJN & "'", mhsConn)



            'mhsJobDA = New OleDbDataAdapter("SELECT * FROM mhsJobs WHERE mhsJob = '" & Me.mhsJN & "'", mhsConn)


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
            Me.lblCustJob.DataBindings.Add("Text", mhsJobDV, "custJob")
            Me.lblCust.DataBindings.Add("Text", mhsJobDV, "cust")
            Me.lblJobDesc.DataBindings.Add("Text", mhsJobDV, "jobDesc")
            Me.lblProjNum.DataBindings.Add("Text", mhsJobDV, "projNum")
            Me.lblStateNum.DataBindings.Add("Text", mhsJobDV, "stateNum")

            ' Format Date
            Me.lblCompDate.DataBindings.Add("Text", mhsJobDV, "compDate", True).FormatString = "MM/dd/yyyy"
            Me.ckbActive.DataBindings.Add("Checked", mhsJobDV, "Active")
            Me.ckbMMM.DataBindings.Add("Checked", mhsJobDV, "MMMDisc")


            Dim panelType As String = Nothing

            Select Case typeOfSign

                Case 1
                    panelType = "EXT"
                Case 2
                    panelType = "PLY"
                Case 3
                    panelType = "FS"


            End Select


            Me.Text = panelType & ":  " & Me.mhsJN & " | " & Me.txtStation.Text.ToString & ", " & _
                                                    Me.txtSignCode.Text.ToString & " :: " & _
                                                    Me.txtSignDetails.Text.ToString


        Catch ex As Exception

            MessageBox.Show(ex.Message, "PopulateMHSJobs()")


        End Try



    End Sub


    Public Sub PopulateSignCodes()

        Try

            Dim sCCmd As OleDbCommand = New OleDbCommand _
                            ("SELECT * FROM tblSignCodes ORDER By code", mhsConn)

            ' Open connection to Db
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            scDA = New OleDbDataAdapter(sCCmd)

            ' Instantiate DataSet object
            scDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            scDA.Fill(scDS, "tblSignCodes")

            '  Close the connection
            mhsConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateSignCodes()")
        End Try


    End Sub

    Private Sub BindSignCodeFields()

        Try

            ' Set the Dataview object to the Dataset object
            scDV = New DataView(scDS.Tables("tblSignCodes"))

            With Me.cmbSignCodes
                .DataSource = scDV
                .DisplayMember = "code"
                .SelectedIndex = -1
                .Text = "Select"
            End With

            ' Clear previous DataBindings
            Me.lblPdfTitle.DataBindings.Clear()
            Me.lblSignCodeDesc.DataBindings.Clear()
            Me.lblType.DataBindings.Clear()

            ' Add DataBindings
            Me.lblPdfTitle.DataBindings.Add("Text", scDV, "pdfTitle")
            Me.lblSignCodeDesc.DataBindings.Add("Text", scDV, "description")
            Me.lblType.DataBindings.Add("Text", scDV, "type")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindSignCodeFields()")
        End Try



    End Sub



    Public Sub PopulateHeights()

        Try

            heightsDA = New OleDbDataAdapter("SELECT * FROM heightSizes ORDER By metricEquivalent", mhsConn)

            ' Initialize a new instance of the DataSet object
            heightsDS = New DataSet()

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Fill DataSet
            heightsDA.Fill(heightsDS, "heightSizes")

            ' DataTable -   Fill the DataTable object with data
            heightsDT = heightsDS.Tables("heightSizes")

            ' Set the DataView object to the DataSet object
            heightsDV = New DataView(heightsDS.Tables("heightSizes"))


            ' Close the connection
            mhsConn.Close()



            '...............DICTIONARY..............

            ' Add "Select ..." at Item(0)
            Me.dctHeights.Add(0.0, "Size")

            ' Iterate through DataTable and add each row 
            ' to the Dictionary
            For Each row As DataRow In heightsDT.Rows
                ' Add Key/Value to the Dictionary
                dctHeights.Add(CDbl(row.Item(2)), row.Item(1).ToString)
            Next

            ' Create list of the Values of the Dictionary (String Heights, in this case)
            Dim lstHeightsValues As New List(Of String)(dctHeights.Values)
            'Dim lstKeys As New List(Of Double)(dctHeights.Keys)

			'RemoveHandler cmbSptSize.SelectedIndexChanged, AddressOf cmbSptSize_SelectedIndexChanged
			Me.cmbSptSize.DataSource = lstHeightsValues
			Me.cmbWPAngleSize.DataSource = lstHeightsValues
			'AddHandler cmbSptSize.SelectedIndexChanged, AddressOf cmbSptSize_SelectedIndexChanged


        Catch ex As Exception

        End Try

    End Sub



    Public Sub PopulateDetails()

        Try
            Dim detailsCmd As OleDbCommand = New OleDbCommand _
                                ("SELECT details FROM signDetails ORDER BY details", mhsConn)

            ' Open the connection, execute the command
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            detailsDA = New OleDbDataAdapter(detailsCmd)

            ' Instantiate DataSet object
            detailsDS = New DataSet()

            ' Fill DataSet
            detailsDA.Fill(detailsDS, "signDetails")

            ' Set the Dataview object to the Dataset object
            detailsDV = New DataView(detailsDS.Tables("signDetails"))

            ' Fill the DataTable object with data
            detailsDT = detailsDS.Tables("signDetails")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateDetails()")
        End Try

    End Sub

    Private Sub BindDetails()

        Try

            With Me.cmbDetails
                .DataSource = Nothing
                .DataSource = detailsDS.Tables("signDetails")
                .DisplayMember = "details"
                .Text = "Preset Details"
            End With

            ' Close the connection
            mhsConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindEXTSheeting()")
        End Try

    End Sub



    Public Sub PopulatePWSupport()

        Try

            Dim pwSptCmd As OleDbCommand = New OleDbCommand _
                                    ("SELECT PWpostType, PWhardware FROM PWsupport ORDER BY PWpostType", mhsConn)

            ' Open the connection, execute the command
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            pwSptDA = New OleDbDataAdapter(pwSptCmd)

            ' Instantiate DataSet object
            pwSptDS = New DataSet()

            ' Fill DataSet
            pwSptDA.Fill(pwSptDS, "PWsupport")

            ' Fill the DataTable object with data
            pwSptDT = pwSptDS.Tables("PWsupport")

            ' Set the DataView object to the DataSet object
            pwSptDV = New DataView(pwSptDS.Tables("PWsupport"))

            ' Close the connection
            mhsConn.Close()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub BindPWSpt()

        Try


            If Me.dctPWSpt.Count <= 0 Then

                '...............DICTIONARY..............

                ' Add "Select ..." at Item(0)
                Me.dctPWSpt.Add("Select Type II Support", String.Empty)

                ' Iterate through DataTable and add each row 
                ' to the Dictionary
                For Each row As DataRow In pwSptDT.Rows
                    ' Add Key/Value to the Dictionary
                    dctPWSpt.Add(row.Item(0).ToString, row.Item(1).ToString)
                Next

            End If

            RemoveHandler cmbPostType.SelectedValueChanged, AddressOf cmbPostType_SelectedIndexChanged
            ' Create list of the Values of the Dictionary (String Heights, in this case)
            Dim lstPWSPTKeys As New List(Of String)(dctPWSpt.Keys)
            Me.cmbPostType.DataSource = Nothing
            Me.cmbPostType.DataSource = lstPWSPTKeys

            AddHandler cmbPostType.SelectedValueChanged, AddressOf cmbPostType_SelectedIndexChanged


        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindPWSpt()")

        End Try



    End Sub



    Public Sub PopulateFSSupport()

        Try
            Dim fsSptCmd As OleDbCommand = New OleDbCommand _
                                    ("SELECT FSpostType, FShardware FROM FSsupport ORDER BY FSpostType", mhsConn)

            ' Open the connection, execute the command
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            fsSptDA = New OleDbDataAdapter(fsSptCmd)

            ' Instantiate DataSet object
            fsSptDS = New DataSet()

            ' Fill DataSet
            fsSptDA.Fill(fsSptDS, "FSsupport")

            ' Fill the DataTable object with data
            fsSptDT = fsSptDS.Tables("FSsupport")

            ' Set the DataView object to the DataSet object
            fsSptDV = New DataView(fsSptDS.Tables("FSsupport"))

            ' Close the connection
            mhsConn.Close()




        Catch ex As Exception

        End Try


    End Sub

    Private Sub BindFSSpt()

        Try


            If Me.dctFSSpt.Count <= 0 Then

                '...............DICTIONARY..............

                '' Add "Select ..." at Item(0)
                'Me.dctFSSpt.Add("Select Type III Support", String.Empty)

                ' Iterate through DataTable and add each row 
                ' to the Dictionary
                For Each row As DataRow In fsSptDT.Rows
                    ' Add Key/Value to the Dictionary
                    dctFSSpt.Add(row.Item(0).ToString, row.Item(1).ToString)
                Next

            End If


            RemoveHandler cmbPostType.SelectedValueChanged, AddressOf cmbPostType_SelectedIndexChanged
            ' Create list of the Values of the Dictionary (String Heights, in this case)
            Dim lstFSSPTKeys As New List(Of String)(dctFSSpt.Keys)
            Me.cmbPostType.DataSource = Nothing
            Me.cmbPostType.DataSource = lstFSSPTKeys
            AddHandler cmbPostType.SelectedValueChanged, AddressOf cmbPostType_SelectedIndexChanged

        Catch ex As Exception
            MessageBox.Show(ex.Message, "BindFSSpt()")
        End Try

    End Sub



    Public Sub PopulateEXTSupport()

        Try

            Dim extSptCmd As OleDbCommand = New OleDbCommand _
                                    ("SELECT EXTpostType, EXThardware FROM EXTsupport ORDER BY EXTpostType", mhsConn)

            ' Open the connection, execute the command
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            extSptDA = New OleDbDataAdapter(extSptCmd)

            ' Instantiate DataSet object
            extSptDS = New DataSet()

            ' Fill DataSet
            extSptDA.Fill(extSptDS, "EXTsupport")

            ' Fill the DataTable object with data
            extSptDT = extSptDS.Tables("EXTsupport")

            ' Set the DataView object to the DataSet object
            extSptDV = New DataView(extSptDS.Tables("EXTsupport"))

            ' Close the connection
            mhsConn.Close()


            '...............DICTIONARY..............

            ' Add "Select ..." at Item(0)
            Me.dctExtSpt.Add("Select Support", String.Empty)

            ' Iterate through DataTable and add each row 
            ' to the Dictionary
            For Each row As DataRow In extSptDT.Rows
                ' Add Key/Value to the Dictionary
                dctExtSpt.Add(row.Item(0).ToString, row.Item(1).ToString)
            Next

            ' Create list of The Key's of the Dictionary (Support, in this case)
            Dim lstEXTSpt As New List(Of String)(dctExtSpt.Keys)
            Me.cmbExtMounting.DataSource = lstEXTSpt

        Catch ex As Exception

        End Try


    End Sub


    Public Sub PopulateEXTSheeting()

        Try

            ' sheetingType (Db1 Db) Connection
            sheetDA = New OleDbDataAdapter( _
                "SELECT sheetNum, sheetDesc FROM EXTsheeting ORDER By sheetNum", mhsConn)

            ' Initialize a new instance of the DataSet object
            sheetDS = New DataSet()

            ' Open the connection, execute the command
            mhsConn.Open()

            ' Fill DataSet
            sheetDA.Fill(sheetDS, "EXTsheeting")

            ' DataTable -   Fill the DataTable object with data
            sheetDT = sheetDS.Tables("EXTsheeting")

            ' Set the DataView object to the DataSet object
            sheetDV = New DataView(sheetDS.Tables("EXTsheeting"))

            ' Close the connection
            mhsConn.Close()



            '...............DICTIONARY..............

            ' Add "Select ..." at Item(0)
            Me.dctEXTSheeting.Add("Sheeting", String.Empty)

            ' Iterate through DataTable and add each row 
            ' to the Dictionary
            For Each row As DataRow In sheetDT.Rows
                ' Add Key/Value to the Dictionary
                dctEXTSheeting.Add(row.Item(0).ToString, row.Item(1).ToString)
            Next

            ' Create list of the Values of the Dictionary (String Heights, in this case)
            Dim lstEXTSheetingKeys As New List(Of String)(dctEXTSheeting.Keys)
            Me.cmbExtColor.DataSource = lstEXTSheetingKeys

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



            '...............DICTIONARY..............

            ' Add "Select ..." at Item(0)
            Me.dctSheeting.Add("Select Sheeting", String.Empty)

            ' Iterate through DataTable and add each row 
            ' to the Dictionary
            For Each row As DataRow In allSheetDT.Rows
                ' Add Key/Value to the Dictionary
                dctSheeting.Add(row.Item(0).ToString, row.Item(1).ToString)
            Next

            ' Create list of The Key's of the Dictionary (sheeting description, in this case)
            Dim lstSheeting As New List(Of String)(dctSheeting.Keys)
            Me.cmbSheetType.DataSource = lstSheeting

        Catch ex As Exception

        End Try




    End Sub




#End Region






	Private Sub DataSetManualUpdate()


		'  First discover which size support (8WF, 6WF, 5WF, 3x4, 2x2 etc.)
		'  Determine which panel is visible w/p or notWp
		'  Get values from appropriate combobox
		'  Then update the appropriate field with the modified value from

		'  cmbWPAngleSize
		'  txt3X4Qty
		'  txt2X2Qty

		'  cmbBeamsAngle
		'  cmbSptSize



		Dim beams As String = "Beams/Angle:  " & Me.cmbBeamsAngle.Text
		Dim beamSize As String = "Beam Size:  " & Me.cmbSptSize.Text
		Dim wpAngleSize As String = "W/P Angle Size:  " & Me.cmbWPAngleSize.Text
		'MessageBox.Show(beams & vbCrLf & beamSize)

		'Me.txtTESTDATA.Text = beams & ", " & beamSize & " - " & wpAngleSize

		'MessageBox.Show(Me.cmbExtMounting.Text)




	End Sub








	

	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		'DataSetManualUpdate()
	End Sub
End Class