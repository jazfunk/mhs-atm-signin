Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.clsUtilities




Public Class frmGlobalTakeOff

#Region " Class-level variables, etc."

    Dim atmJN As String
    Dim mhsJN As String
    Dim mhsCust As String

    ' Declare qualifier variable to skip
    ' row selection , and showSignImage() Method  (variable is for findSign() Method)
    Dim isSelected As Boolean

    ' Declare variable to skip adding to entered items DGV
    Dim isAdded As Boolean = False


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
    Dim extSupport As String



    ' Db variables
    Dim signIdentity As Integer
    Public staNum As String
    Public sType As String
    Public sCode As String
    Public sDetails As String

    ' width, height, square feet
    Public sW As Double
    Public sH As Double
    Public sFT As Double

    Public ssQty As Integer
    Public support As String
    Public hdwQty As Integer
    Public hdw As String
    Public sheeting As String


    Public thisSignType As String = Nothing
    Public thisPanelType As String = Nothing


    ' Used for TryCasting grpTypes checked RadioButton
    Private signTypeRDO As RadioButton



    ' Dictionary(Of TKey, TValue)
    Private dctExtSpt As New Dictionary(Of String, String)
    Private dctHeights As New Dictionary(Of Double, String)
    Private dctEXTSheeting As New Dictionary(Of String, String)
    Private dctPWSpt As New Dictionary(Of String, String)
    Private dctFSSpt As New Dictionary(Of String, String)
    Private dctSheeting As New Dictionary(Of String, String)






#End Region


#Region " Database Communication"



    ' Connection to Action Traffic.mdb
	'Dim ATMconn1 As New OleDbConnection(atmConnStr01)
	Dim atmConn1 As New OleDbConnection(My.Settings.ATMconn)

    ' Connection to db1.mdb
	'Dim mhsConn As New OleDbConnection(connStr01)
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' MHS Jobs
    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
    Dim mhsJobDV As DataView
    Dim mhsJobDT As DataTable


    ' Daily Production table
    Dim atmDA As OleDbDataAdapter
    Dim atmDS As DataSet
    Dim atmDV As DataView
    Dim atmDT As DataTable


    ' site list (station #'s)
    Dim siteDA As OleDbDataAdapter
    Dim siteDS As DataSet
    Dim siteDV As DataView


    ' payItemID
    Dim pIDDA As OleDbDataAdapter
    Dim pIDDS As DataSet
    Dim pIDDV As DataView
    Dim pIDDT As DataTable

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
    Dim scBS As BindingSource
    Dim scDS As DataSet
    Dim scDT As DataTable
    Dim scDV As DataView

    ' PreSet Sign Details
    Dim detailsDA As OleDbDataAdapter
    Dim detailsDS As DataSet
    Dim detailsDT As DataTable
    Dim detailsDV As DataView

    



#End Region


#Region " Subs & Functions"

    '**************** ATM ********************

	''' <summary>
	''' Load all items from [Daily Production]
	''' </summary>
	''' <remarks>Filtered by job #</remarks>
    Private Sub getAtmTOF()

        Try

            Me.Cursor = Cursors.PanNorth

			Dim cmd As New OleDbCommand _
						 ("SELECT [Daily Production].[Job #], " & _
						  "[Daily Production].[site], " & _
						  "[Daily Production].[PayItemID], " & _
						  "[PAY ITEM PICK LIST].[CODE], " & _
						  "[PAY ITEM PICK LIST].[DESCRIPTION], " & _
						  "[Daily Production].[Sign Code], " & _
						  "[Daily Production].[Sign Width], " & _
						  "[Daily Production].[Sign Height], " & _
						  "[Daily Production].[Contract Qty], " & _
						  "[PAY ITEM PICK LIST].[UNIT], " & _
						  "[Daily Production].[Number of Supports], " & _
						  "[PAY ITEM PICK LIST].[PayItemID], " & _ 
						  "[Daily Production].[Plan Issue Notes], " & _ 
						  "[Daily Production].[AutoNum] " & _
						  "FROM [Daily Production] " & _
						  "LEFT OUTER JOIN [PAY ITEM PICK LIST] " & _
						  "ON [Daily Production].[PayItemID] = " & _
						  "[PAY ITEM PICK LIST].[PayItemID]" & _
						  "WHERE [Daily Production].[Job #] = '" & Me.atmJN & "'", atmConn1)




            ' Open connection to Db
			atmConn1.Open()

            '  Fill dataAdapter with query result from Db
            atmDA = New OleDbDataAdapter(cmd)

            ' Instantiate DataSet object
            atmDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            atmDA.Fill(atmDS, "[Daily Production]")

            '  Close the connection
			atmConn1.Close()

            ' Set the Dataview object to the Dataset object
            atmDV = New DataView(atmDS.Tables("[Daily Production]"))


			'Me.lblItemsPerLocation.Text = Me.atmDV.Count.ToString & " Items"


			' Set Align-MiddleCenter object
			Dim objAlignMidcellStyle As New DataGridViewCellStyle()
			objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

			' Set Align-MiddleRight object
			Dim objAlignRightcellStyle As New DataGridViewCellStyle
			objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

			' Declare and set the alternating rows style
			Dim objAlternatingCellStyle As New DataGridViewCellStyle()
			objAlternatingCellStyle.BackColor = Color.WhiteSmoke



			With Me.dgvATMTOF

				.DataSource = Nothing
				.DataSource = atmDV
				.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

				'.Columns(0).HeaderText = "Job #"
				.Columns(0).Visible = False

				'.Columns(1).Width = 105
				'.Columns(1).HeaderText = "Site"
				'.Columns(1).HeaderCell.Style = objAlignMidcellStyle
				.Columns(1).Visible = False

				.Columns(2).HeaderText = "Daily Production.PayItemID"
				.Columns(2).Visible = False

				'.Columns(3).Width = 65
				'.Columns(3).HeaderText = "PayItemID"
				'.Columns(3).HeaderCell.Style = objAlignMidcellStyle
				.Columns(3).Visible = False

				.Columns(4).Width = 125
				.Columns(4).HeaderText = "Description"
				.Columns(4).HeaderCell.Style = objAlignMidcellStyle

				.Columns(5).Width = 85
				.Columns(5).HeaderText = "Sign Code"
				.Columns(5).HeaderCell.Style = objAlignMidcellStyle
				.Columns(5).DefaultCellStyle = objAlignRightcellStyle


				.Columns(6).Width = 40
				.Columns(6).HeaderText = "Width"
				.Columns(6).HeaderCell.Style = objAlignMidcellStyle
				.Columns(6).DefaultCellStyle = objAlignRightcellStyle


				.Columns(7).Width = 40
				.Columns(7).HeaderText = "Height"
				.Columns(7).HeaderCell.Style = objAlignMidcellStyle
				.Columns(7).DefaultCellStyle = objAlignRightcellStyle

				.Columns(8).Width = 55
				.Columns(8).HeaderText = "C-Qty"
				.Columns(8).HeaderCell.Style = objAlignMidcellStyle
				.Columns(8).DefaultCellStyle = objAlignRightcellStyle
				'.Columns(8).Visible = False


				'.Columns(9).Width = 35
				'.Columns(9).HeaderText = "Unit"
				'.Columns(9).HeaderCell.Style = objAlignMidcellStyle
				'.Columns(9).DefaultCellStyle = objAlignRightcellStyle
				.Columns(9).Visible = False


				.Columns(10).Width = 45
				.Columns(10).HeaderText = "#-Spts"
				.Columns(10).HeaderCell.Style = objAlignMidcellStyle
				.Columns(10).DefaultCellStyle = objAlignRightcellStyle
				.Columns(10).Visible = False

				.Columns(11).Visible = False

				.Columns(12).Visible = False

				.Columns(13).Visible = False

			End With

			Me.txtNotes.DataBindings.Clear()
			Me.lblSite.DataBindings.Clear()

			Me.txtNotes.DataBindings.Add("Text", atmDV, "Plan Issue Notes")
			Me.lblSite.DataBindings.Add("Text", atmDV, "site")


			'Me.lblItemsPerJob.Text = CStr(Me.dgvATMTOF.Rows.Count) & " Records"

		Catch ex As Exception
			MessageBox.Show(ex.Message, "getAtmTOF()")
		End Try

		Me.Cursor = Cursors.Arrow

	End Sub



	''' <summary>
	''' Load all site's (station #'s) 
	''' </summary>
	''' <remarks>Grouped by [site]</remarks>
	Private Sub getAtmSiteList()

		Try
			Dim siteCmd As OleDbCommand = New OleDbCommand _
			   ("SELECT site FROM [Daily Production] " & _
				"WHERE [Job #] = '" & Me.atmJN & "' " & _
				"GROUP By site ORDER BY site", atmConn1)

			' Open connection to Db
			atmConn1.Open()

			'  Fill dataAdapter with query result from Db
			siteDA = New OleDbDataAdapter(siteCmd)

			' Instantiate DataSet object
			siteDS = New DataSet()

			' Fill DataSet with data from dataAdapater
			siteDA.Fill(siteDS, "[Daily Production]")

			'  Close the connection
			atmConn1.Close()

			' Set the Dataview object to the Dataset object
			siteDV = New DataView(siteDS.Tables("[Daily Production]"))

			With Me.cmbATMStations
				.DataSource = siteDV
				.DisplayMember = "site"

				'Dim sites As Integer = .Items.Count - 1
				'Me.lblLocationsPerJob.Text = sites.ToString & " Stations"

			End With

			'Me.lblJobNumber.Text = atmJN


		Catch ex As Exception
			MessageBox.Show(ex.Message, "getAtmSiteList()")

		End Try




	End Sub



	Private Sub filterAndSelect()

		Try
			If atmDV IsNot Nothing Then
				Me.atmDV.RowFilter = "site = '" & Me.cmbATMStations.Text.ToString & "'"
				Me.atmDV.Sort = "[Sign Height] DESC, [Sign Width] DESC, [Sign Code]"
				'Me.lblItemsPerLocation.Text = Me.atmDV.Count.ToString & " Items"

				'  Highlight SIGN pay item
				findSign()

			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "filterAndSelect()")

		End Try


	End Sub

    Private Sub findSign()

        ' Selects items where the [Sign Width] field is not null 
        ' Indicating a SIGN
        Try

            ' De-Select previously selected row
            For Each row As DataGridViewRow In dgvATMTOF.Rows
                row.Selected = False
            Next

            For i As Integer = 0 To Me.dgvATMTOF.Rows.Count - 1

                If Not isSelected Then
                    If Me.dgvATMTOF.Rows(i).Cells.Item("Sign Width").Value Is DBNull.Value Then

                        ' This is not a SIGN PayItem
                        Me.dgvATMTOF.Rows(i).Selected = False
                        isSelected = False

                    Else

                        ' This is a SIGN PayItem
                        Me.dgvATMTOF.Rows(i).Selected = True
                        isSelected = True

                        showSignImage()

                    End If
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "findSign()")

        End Try
    End Sub

    Private Sub showSignImage()

        Try
            Dim imageName As String = Me.dgvATMTOF.CurrentRow.Cells.Item("Sign Code").Value.ToString
            Dim viewImage As String = imageName & ".jpg"

            Me.picSignImage.Visible = True
            Me.picSignImage.Load(My.Resources.imgPath & viewImage)
        Catch ex As Exception
            Me.picSignImage.Image = My.Resources.none1
        End Try

    End Sub

    Private Sub PickPanelToShow(ByVal t As Boolean)
        Try

            Select Case t

                Case True
                    ' Extruded Panel
                    Me.SplitContainerTYPES.Panel1Collapsed = False
                    Me.SplitContainerTYPES.Panel2Collapsed = True
                    'Me.tsbSwitchTypesPanel.Text = "Show PLY/FS Panel"

                Case False
                    ' FlatSheet and Plywood Panel
                    Me.SplitContainerTYPES.Panel2Collapsed = False
                    Me.SplitContainerTYPES.Panel1Collapsed = True
                    'Me.tsbSwitchTypesPanel.Text = "Show EXT Panel"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "PickPanelToShow()")

        End Try
	End Sub

    Private Sub getPayItemPickList()

        Try

			Dim pIDCmd As OleDbCommand = New OleDbCommand _
						("SELECT * FROM [PAY ITEM PICK LIST]", atmConn1)

            ' Open connection to Db
			atmConn1.Open()

            '  Fill dataAdapter with query result from Db
            pIDDA = New OleDbDataAdapter(pIDCmd)

            ' Instantiate DataSet object
            pIDDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            pIDDA.Fill(pIDDS, "[PAY ITEM PICK LIST]")

            '  Close the connection
			atmConn1.Close()

            ' Set the Dataview object to the Dataset object
            pIDDV = New DataView(pIDDS.Tables("[PAY ITEM PICK LIST]"))

            ' DataTable -   Fill the DataTable object with data
            pIDDT = pIDDS.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "getPayItemPickList()")
        End Try


	End Sub

	Public Function GetSignType(ByVal pID As Integer) As String


		' Extruded - Type I:  680, 692, 452, 669, 751, 790, 1886, 1904, 1906, 1907, 1908, 1909
		' Plywood - Type II:  622, 624, 626, 672, 608, 670, 752, 813, 1887, 1910, 1912, 1913, 1914, 1915
		' FlatSheet - Type III:  623, 625, 627, 673, 453, 671, 753, 812, 814, 1515, 1888, 1916, 1918, 1919, 1920, 1921


		Dim signType As String = Nothing

		Try
			Select Case pID


				' Extruded - Type I
				'680, 692, 452, 669, 751, 790, , 1886, 1904, 1906, 1907, 1908, 1909

				Case 680, 1906
					signType = "IA"

				Case 692, 1907
					signType = "IB"

				Case 1908
					signType = "IC"

				Case 1909
					signType = "ID"

				Case 751, 1904
					' [SALV]
					signType = "I"

				Case 452, 669, 790, 1886
					' [MDOT]
					signType = "I"






					' Plywood - Type II
					'622, 624, 626, 672, 608, 670, 752, 813, 1887, 1910, 1912, 1913, 1914, 1915

				Case 622, 1912
					signType = "IIA"

				Case 624, 672, 1913
					signType = "IIB"

				Case 1914
					signType = "IIC"

				Case 1915
					signType = "IID"

				Case 626, 752, 1910
					' [SALV]
					signType = "II"

				Case 608, 670, 813, 1887
					' [MDOT]
					signType = "II"






					' FlatSheet - Type III
					'623, 625, 627, 673, 453, 671, 753, 812, 814, 1515, 1888, 1916, 1918, 1919, 1920, 1921

				Case 623, 1918
					signType = "IIIA"

				Case 625, 673, 1919
					signType = "IIIB"

				Case 1920
					signType = "IIIC"

				Case 1921
					signType = "IIID"

				Case 627, 753, 812, 1916
					' [SALV]
					signType = "III"

				Case 453, 671, 814, 1515, 1888
					' [MDOT]
					signType = "III"

				Case Else

			End Select



		Catch ex As Exception
			MessageBox.Show(ex.Message, "GetSignType()")

		End Try


		Return signType


	End Function



	''' <summary>
	''' Updates ATM Location ("Plan Issue Notes")
	''' </summary>
	''' <param name="siteID">"AutoNum" field from ATM Db</param>
	''' <param name="siteNotes">Notes to be added</param>
	''' <remarks></remarks>
	Private Sub UpdateLocationNotes(ByVal siteID As Integer, ByVal siteNotes As String)

		Dim x As Integer = 0

		Try
			Using connection As New OleDbConnection(My.Settings.ATMconn)
				Using command As New OleDbCommand("UPDATE [Daily Production] SET " & _
				  "[Daily Production].[Plan Issue Notes] = @notes " & _
				  "WHERE [Daily Production].[Autonum] = @ID", connection)

					If siteNotes <> Nothing Then
						command.Parameters.AddWithValue("@notes", siteNotes)
					Else
						command.Parameters.AddWithValue("@notes", DBNull.Value)
					End If

					command.Parameters.AddWithValue("@ID", siteID)

					connection.Open()
					x = command.ExecuteNonQuery()

				End Using
			End Using

			If x > 0 Then
				MessageBox.Show("Station Note(s) added/updated")
			Else
				MessageBox.Show("Station Note(s) NOT added!")

			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "UpdateLocationNotes()")

		End Try
	End Sub




    '**************** MHS ***************************


    Private Sub showSignImageTOF()

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
                    Case "3932", "4092", "1172C"
                        Me.lblExtSheeting.ForeColor = Color.White
                        Me.lblExtSheeting.BackColor = Color.Red
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
                    Case "3924", "4024"
                        Me.lblExtSheeting.ForeColor = Color.Black
                        Me.lblExtSheeting.BackColor = Color.Orange
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
                        Handles cmbSheetType.SelectedIndexChanged

        Try

            ' Add the sheeting description from the Dictionary
            ' to the textBox
            Me.lblSheetingColor.Text = Me.dctSheeting.Item(Me.cmbSheetType.Text)


            Select Case cmbSheetType.Text
                Case "3930", "3990", "4090"
                    Me.PictureBoxSheeting.BackColor = Color.White
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.White

                Case "3981", "4081", "3931"
                    Me.PictureBoxSheeting.BackColor = Color.Yellow
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Yellow

                Case "3983", "4083"
                    Me.PictureBoxSheeting.BackColor = Color.YellowGreen
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.YellowGreen

                Case "3924", "4024"
                    Me.PictureBoxSheeting.BackColor = Color.Orange
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Red

                Case "3935", "3995", "4095", "1175C"
                    Me.PictureBoxSheeting.BackColor = Color.Blue
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Blue

                Case "3937", "3997", "4097", "1177C"
                    Me.PictureBoxSheeting.BackColor = Color.Green
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Green

                Case "3939", "4039", "1179C"
                    Me.PictureBoxSheeting.BackColor = Color.Brown
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Brown

                Case "3932", "4092", "1172C"
                    Me.PictureBoxSheeting.BackColor = Color.Red
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Red


                Case "3650-12"
                    Me.PictureBoxSheeting.BackColor = Color.Black
                    Me.lblSheetingColor.ForeColor = Color.White
                    Me.lblSheetingColor.BackColor = Color.Black

                Case Else
                    Me.PictureBoxSheeting.BackColor = Color.Transparent
                    Me.lblSheetingColor.ForeColor = Color.Black
                    Me.lblSheetingColor.BackColor = Color.Transparent


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VisualSheetingColor()")
        End Try


    End Sub

	''' <summary>
	''' 
	''' </summary>
	''' <param name="sT"></param>
	''' <remarks></remarks>
    Private Sub migrateExtrudedSign(ByVal sT As String)

		Try

			Dim site As String = Nothing
			Dim sCode As String = Nothing
			Dim sWidth As String = Nothing
			Dim sHeight As String = Nothing
			Dim sSqrFt As String = Nothing

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value, "") IsNot "" Then _
					  site = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value, "") IsNot "" Then _
					  sCode = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value, "") IsNot "" Then _
					  sWidth = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value, "") IsNot "" Then _
					sHeight = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value, "") IsNot "" Then _
					 sSqrFt = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value, String)



			'Dim site As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value)
			'Dim sCode As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value)
			'Dim sWidth As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value)
			'Dim sHeight As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value)
			'Dim sSqrFt As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value)

			Me.rdoExtruded.Checked = True
			Me.txtStation.Clear()
			Me.txtStation.Text = site
			Me.cmbSignCodes.Text = sCode

			Me.txtExtWidth.Clear()
			Me.txtExtHeight.Clear()
			Me.txtExtSqrFeet.Clear()

			' Automatically convert Extruded inches to feet, if necessary
			Try
				Dim numberW As Double
				Dim numberH As Double
				Dim resultW As Boolean = Double.TryParse(sWidth, numberW)
				Dim resultH As Boolean = Double.TryParse(sHeight, numberH)

				' Sign Width
				If resultW And numberW > My.Settings.maxExtWidth Then
					sWidth = CType((numberW / 12), String)
					'Me.txtExtWidth.Text = CType((numberW / 12), String)
				End If

				' Sign Height
				If resultH And numberW > My.Settings.maxExtWidth Then
					sHeight = CType(numberH / 12, String)
					'Me.txtExtHeight.Text = CType(numberH / 12, String)
				End If

				Me.txtExtWidth.Text = sWidth
				Me.txtExtHeight.Text = sHeight

			Catch ex As Exception
				' Do nothing
			End Try

			Me.ToolStripStatusLabel1.Text = site & " Migrated Successfully"

		Catch ex As Exception
			MessageBox.Show(ex.Message, "migrateExtrudedSign()")

		End Try

    End Sub

    Private Sub migratePlywoodSign(ByVal sT As String)

		Try

			Dim site As String = Nothing
			Dim sCode As String = Nothing
			Dim sWidth As String = Nothing
			Dim sHeight As String = Nothing
			Dim sSqrFt As String = Nothing

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value, "") IsNot "" Then _
				site = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value, "") IsNot "" Then _
				sCode = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value, "") IsNot "" Then _
				sWidth = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value, "") IsNot "" Then _
			  sHeight = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value, "") IsNot "" Then _
			   sSqrFt = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value, String)



			'Dim site As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value)
			'Dim sCode As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value)
			'Dim sWidth As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value)
			'Dim sHeight As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value)
			'Dim sSqrFt As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value)



			Me.rdoPlywood.Checked = True
			Me.txtStation.Clear()
			Me.txtStation.Text = Site
			Me.cmbSignCodes.Text = sCode

			Me.txtSignWidth.Clear()
			Me.txtSignHeight.Clear()
			Me.txtSqrFeet.Clear()

			Me.txtSignWidth.Text = sWidth
			Me.txtSignHeight.Text = sHeight
			'Me.txtSqrFeet.Text = sSqrFt

			Me.ToolStripStatusLabel1.Text = site & " Migrated Successfully"

			'Me.ToolStripStatusLabel1.Text = Site & " (" & sWidth & " x " & sHeight & ")  Migrated Successfully"

		Catch ex As Exception
			MessageBox.Show(ex.Message, "migratePlywoodSign()")

		End Try

    End Sub

    Private Sub migrateFlatSheetSign(ByVal sT As String)

		Try

			Dim site As String = Nothing
			Dim sCode As String = Nothing
			Dim sWidth As String = Nothing
			Dim sHeight As String = Nothing
			Dim sSqrFt As String = Nothing

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value, "") IsNot "" Then _
				site = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value, "") IsNot "" Then _
				sCode = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value, "") IsNot "" Then _
				sWidth = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value, "") IsNot "" Then _
			  sHeight = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value, String)

			If NotNull(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value, "") IsNot "" Then _
			   sSqrFt = CType(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value, String)



			'Dim site As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("site").Value)
			'Dim sCode As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign code").Value)
			'Dim sWidth As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign width").Value)
			'Dim sHeight As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Sign height").Value)
			'Dim sSqrFt As String = CStr(Me.dgvATMTOF.CurrentRow.Cells.Item("Contract Qty").Value)



			Me.rdoFlatSheet.Checked = True
			Me.txtStation.Clear()
			Me.txtStation.Text = site
			Me.cmbSignCodes.Text = sCode

			Me.txtSignWidth.Clear()
			Me.txtSignHeight.Clear()
			Me.txtSqrFeet.Clear()

			Me.txtSignWidth.Text = sWidth
			Me.txtSignHeight.Text = sHeight
			'Me.txtSqrFeet.Text = sSqrFt

			Me.ToolStripStatusLabel1.Text = site & " Migrated Successfully"

			'Me.ToolStripStatusLabel1.Text = site & " (" & sWidth & " x " & sHeight & ")  Migrated Successfully"


		Catch ex As Exception
			MessageBox.Show(ex.Message, "migrateFlatSheetSign()")

		End Try

    End Sub

    Private Sub FilterMHSJobDV()

        Try
            If mhsJobDV IsNot Nothing Then

                Me.mhsJN = Me.tsbCmbMHSJob.Text

                mhsJobDV.RowFilter = "mhsJob = '" & Me.mhsJN & "'"
                Me.mhsCust = mhsJobDV.Item(0).Item("cust").ToString
                Me.atmJN = mhsJobDV.Item(0).Item("custJob").ToString
                Me.Text = "Global TakeOff| " & Me.mhsJN & "  (" & mhsJobDV.Item(0).Item("jobDesc").ToString & ")"

                If Me.mhsCust = "ATM" Then
                    getAtmTOF()
                    getAtmSiteList()
                    getPayItemPickList()
					'getAtmTOF()
                    filterAndSelect()

                    ' Show ATM SplitContainer Panel
                    Me.SplitContainer1.Panel1Collapsed = False
                    Me.tsbTOFHideATM.Enabled = True
                    Me.tsbMigrateATMData.Enabled = True

                    ' Enable MHS TOF fields
                    Me.btnATMPrev.Enabled = True
                    Me.btnATMNext.Enabled = True
                    Me.btnMigrateATM.Enabled = True
                    Me.btnEXTATMPrev.Enabled = True
                    Me.btnEXTATMNext.Enabled = True
                    Me.btnEXTMigrateATM.Enabled = True


                Else
                    ' Hide ATM SplitContainer Panel
                    Me.SplitContainer1.Panel1Collapsed = True
                    Me.tsbTOFHideATM.Enabled = False
                    Me.tsbMigrateATMData.Enabled = False

                    ' Disable MHS TOF fields
                    Me.btnATMPrev.Enabled = False
                    Me.btnATMNext.Enabled = False
                    Me.btnMigrateATM.Enabled = False
                    Me.btnEXTATMPrev.Enabled = False
                    Me.btnEXTATMNext.Enabled = False
                    Me.btnEXTMigrateATM.Enabled = False

                End If


            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "FilterMHSJobDV()")

        End Try

    End Sub


    ' Not used
    Private Sub showPrepTypeImage(ByVal signType As Integer)

        'Try

        '    If signType = 680 Or signType = 692 Then
        '        'Select Case signType
        '        '    Case 680
        '        '        Me.txtSignType.Text = "IA"

        '        '    Case 692
        '        '        Me.txtSignType.Text = "IB"
        '        'End Select
        '        Me.PictureBoxType.Image = My.Resources.new_extruded_1_24
        '    End If

        '    If signType = 622 Or signType = 624 Or signType = 672 Then
        '        'Select Case signType
        '        '    Case 622
        '        '        Me.txtSignType.Text = "IIA"
        '        '    Case 624
        '        '        Me.txtSignType.Text = "IIB"
        '        '    Case 672
        '        '        Me.txtSignType.Text = "IIB"
        '        'End Select
        '        Me.PictureBoxType.Image = My.Resources.new_plywood_1_24
        '    End If

        '    If signType = 623 Or signType = 625 Or signType = 673 Then
        '        'Select Case signType
        '        '    Case 623
        '        '        Me.txtSignType.Text = "IIIA"
        '        '    Case 625
        '        '        Me.txtSignType.Text = "IIIB"
        '        '    Case 673
        '        '        Me.txtSignType.Text = "IIIB"
        '        'End Select
        '        Me.PictureBoxType.Image = My.Resources.new_flatsheet_1_24

        '    End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub showSignSpecPDF(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles picSignImage.DoubleClick, _
                        picSign.DoubleClick, _
                        tsbViewPDF.Click

        Me.Cursor = Cursors.WaitCursor

        Try

            If Me.lblPdfTitle.Text <> String.Empty Then
                Dim specSheet As New frmViewPDF(Me.lblPdfTitle.Text, Me.txtSignCode.Text, Me.lblSignCodeDesc.Text)
                specSheet.MdiParent = signINver2.signINMain1
                specSheet.Show()
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.No
            MessageBox.Show(ex.Message, "showSignSpecPDF()")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub



    Private Sub enableAll()

        Me.btnCluster.Enabled = True
        Me.btnConvert.Enabled = True
        Me.btnDown.Enabled = True
        Me.btnUp.Enabled = True
        Me.btnAddSign.Enabled = True
        Me.btnBtoB.Enabled = True
        Me.btnSinglePost.Enabled = True

        Me.PictureBoxSheeting.Visible = True
        Me.PictureBoxExtSheeting.Visible = True


    End Sub

    Public Sub disableAll()

        Me.btnConvert.Enabled = False
        Me.btnDown.Enabled = False
        Me.btnUp.Enabled = False
        Me.btnAddSign.Enabled = False
        Me.btnBtoB.Enabled = False
        Me.btnSinglePost.Enabled = False
        

    End Sub



    Private Sub ResetAfterAdd()

        Try

            'Triggers Default State
            Me.rdoDefault.Checked = True

            isAdded = False
            
            Me.btnCluster.Enabled = False
            Me.btnConvert.Enabled = False
            Me.btnDown.Enabled = False
            Me.btnUp.Enabled = False
            Me.btnAddSign.Enabled = False
            Me.btnBtoB.Enabled = False
            Me.btnSinglePost.Enabled = False

            Me.txtSignCode.Clear()
            Me.txtStation.Clear()
            Me.txtStation.Select()
            Me.cmbSelectType.SelectedIndex = 0
            Me.cmbSelectType.Text = "Select"

            Me.cmbDetails.SelectedIndex = -1
            Me.cmbDetails.SelectedIndex = -1
            Me.cmbDetails.Text = "PreSet Details"
            Me.txtSignDetails.Clear()


            ' Plywood/FlatSheet

            Me.lblSignType.Text = String.Empty
            Me.cmbPostType.DataSource = Nothing
            Me.cmbPostType.Text = String.Empty
            Me.txtHardware.Clear()

            Me.txtSupportQty.Clear()
            Me.txtHardwareQty.Clear()
            Me.txtHardware.ReadOnly = True

            Me.txtSignWidth.Clear()
            Me.txtSignHeight.Clear()
            Me.txtSqrFeet.Clear()

            Me.cmbSheetType.SelectedIndex = 0
            Me.PictureBoxSheeting.BackColor = Color.Transparent
            Me.PictureBoxLargeTypeII.Image = Nothing



            ' Extruded

            ' PanelWP location x 169, y 158  ----  This is the hidden location
            ' PanelNotWP location x 163, y 111  ----  This is the hidden location

            Me.lblEXTSignType.Text = String.Empty

            Me.txtExtWidth.Clear()
            Me.txtExtHeight.Clear()
            Me.txtExtSqrFeet.Clear()
            Me.cmbDirection.Text = "Direction"
            Me.cmbExtColor.Text = "Sheeting"

            Me.txt12Plank.Clear()
            Me.txt6Plank.Clear()
            Me.ckbRetain.Checked = False
            Me.txtParent.Clear()
            Me.txtExtHdwQty.Clear()

            Me.cmbBeamsAngle.Text = String.Empty
            Me.txtExtSptQty.Clear()
            Me.cmbSptSize.SelectedIndex = 0
            Me.cmbExtMounting.SelectedIndex = 0
            Me.txtEXTHdw.ReadOnly = True

            Me.txt3X4Qty.Clear()
            Me.txt2X2Qty.Clear()
            Me.txtExtB2B.Clear()

            Me.PictureBoxLargeTypeI.Image = Nothing
            Me.PictureBoxExtSheeting.BackColor = Color.Transparent
            Me.PictureBoxType.Image = Nothing

            Me.PanelWP.Visible = False
            Me.PanelNotWP.Visible = True
            Me.btn3WP.Visible = False

			'Me.cmbSelectType.Enabled = False

			
            Me.ToolStripStatusLabel1.Text = "Ready"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "resetAfterAdd()")

        End Try




    End Sub



    Private Sub AddSignToList(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles tsbAddSign.Click, _
                        btnAddSign.Click, _
                        btnExtAddSign.Click



        Me.Cursor = Cursors.WaitCursor



        Try

            Dim ib As Bitmap = CType(Me.picSign.Image.Clone, Bitmap)
            Me.staNum = Trim(Me.txtStation.Text)
            Me.sCode = Trim(Me.txtSignCode.Text)
            Me.sDetails = Trim(Me.txtSignDetails.Text)

            sW = Nothing
            sH = Nothing
            sFT = Nothing



            ' Validate Station
            If Me.staNum Is String.Empty Then
                MessageBox.Show("You must assign a Station Number.", _
                                "Missing Required Data", _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If


			' Copy Station Number to the clipboard for faster duplicate entries
			My.Computer.Clipboard.SetText(Me.txtStation.Text)


            ' Validate Sign Code
            If Me.sCode Is String.Empty Then
                MessageBox.Show("You must designate a Sign Code.", _
                                "Missing Required Data", _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If


            ' Validate further per PanelType
            Select Case Me.thisPanelType

                Case Is = "Extruded"


                    ' Validate Support
                    
                    If Me.cmbExtMounting.SelectedIndex = 0 Then
                        MessageBox.Show("You must select a support.", _
                                        "Missing Required Data", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If




                    ' Validate Sheeting
                    If Me.cmbExtColor.SelectedIndex = 0 Then
                        MessageBox.Show("You must select the appropriate sheeting.", _
                                        "Missing Required Data", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If



                    sW = CDbl(Me.txtExtWidth.Text)
                    sH = CDbl(Me.txtExtHeight.Text)
                    sFT = CDbl(Me.txtExtSqrFeet.Text)


                    PrepareEXTforAdding()


                    If Me.cmbDirection.Text = "Direction" Then
                        MessageBox.Show("Please select a direction", "Direction not selected!", _
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                                            MessageBoxDefaultButton.Button1)

                        Me.Cursor = Cursors.Arrow
                        Me.ToolStripStatusLabel1.Text = "Record not added!"
                        Exit Sub

                    Else
                        AddEXTSign()

                    End If



                Case Is = "Plywood"



                    Dim sptCheck As String = Me.cmbPostType.Text

                    If sptCheck.ToUpper.Substring(0, 3) = "SEL" Then
                        MessageBox.Show("You must select a support.")
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If


                    If Me.cmbSheetType.Text = "Select" Then
                        Me.Cursor = Cursors.Arrow
                        MessageBox.Show("You must select the appropriate sheeting.", _
                                        "Missing Required Data", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                        Exit Sub
                    End If



                    sW = CDbl(Me.txtSignWidth.Text)
                    sH = CDbl(Me.txtSignHeight.Text)
                    sFT = CDbl(Me.txtSqrFeet.Text)


                    ' This sub calls the addPWSign sub
                    PreparePLY_FSforAdding()


				Case Is = "Flatsheet", "TypeV"


					Dim sptCheck As String = Me.cmbPostType.Text

					If sptCheck.ToUpper.Substring(0, 3) = "SEL" Then
						MessageBox.Show("You must select a support.", _
							"Missing Required Data", _
							MessageBoxButtons.OK, _
							MessageBoxIcon.Information)
						Me.Cursor = Cursors.Arrow
						Exit Sub
					End If


					If Me.cmbSheetType.Text = "Select" Then
						MessageBox.Show("You must select the appropriate sheeting.", _
							"Missing Required Data", _
							MessageBoxButtons.OK, _
							MessageBoxIcon.Information)
						Me.Cursor = Cursors.Arrow
						Exit Sub
					End If



					sW = CDbl(Me.txtSignWidth.Text)
					sH = CDbl(Me.txtSignHeight.Text)
					sFT = CDbl(Me.txtSqrFeet.Text)

					' This sub calls the addFSSign sub
					PreparePLY_FSforAdding()


                Case Else

                    Dim sptCheck As String = Me.cmbPostType.Text

                    If sptCheck.ToUpper.Substring(0, 3) = "SEL" Then
                        MessageBox.Show("You must select a support.", _
                                        "Missing Required Data", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If Me.cmbSheetType.Text = "Select" Then
                        Me.Cursor = Cursors.Arrow
                        MessageBox.Show("You must select the appropriate sheeting.", _
                                        "Missing Required Data", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                        Exit Sub
                    End If


                    sW = CDbl(Me.txtSignWidth.Text)
                    sH = CDbl(Me.txtSignHeight.Text)
                    sFT = CDbl(Me.txtSqrFeet.Text)


            End Select


            If isAdded Then
                ' Insert row
                With Me.dgvSignsAdded
                    .Rows.Insert(0, ib, Me.staNum, sCode, sDetails, Me.thisSignType, sW.ToString, sH.ToString, signIdentity)
                End With

                ' De-Select the row
                For Each row As DataGridViewRow In dgvSignsAdded.Rows
                    row.Selected = False
                Next

            End If

			ResetAfterAdd()
			BindSignCodeFields()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "addSignToList()")
        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub PrepareEXTforAdding()

        Try

           
			direction = Me.cmbDirection.Text

			' Parent
			If Me.txtParent.Text <> String.Empty Then
				sParent = Me.txtParent.Text.Trim
			Else
				sParent = Nothing
			End If


			' Details
			If Me.txtSignDetails.Text <> String.Empty Then
				sDetails = Me.txtSignDetails.Text.Trim
			Else
				sDetails = Nothing
			End If


            retain = CBool(Me.ckbRetain.CheckState)
            EXTsheeting = Me.cmbExtColor.Text


            Try
                twelve = CInt(Me.txt12Plank.Text)
            Catch ex As Exception
                twelve = 0
            End Try



            Try
                six = CInt(Me.txt6Plank.Text)
            Catch ex As Exception
                six = 0
            End Try



            Select Case sCode

                Case Is = "[MDOT]"

                    six = 0
                    twelve = 0

                Case Is = "[SALVAGE]"

                    six = 0
                    twelve = 0

                Case Is = "[LOGOS]"


                Case Is = "[TODS]"


            End Select




            If Me.cmbExtMounting.Text = "4x6 W/P" Or Me.cmbExtMounting.Text = "6x8 W/P" Then

				eightWF = Nothing
				sixWF = Nothing
				fiveWF = Nothing

                threeByFour = Me.txt3X4Qty.Text.ToString & " )  " & Me.cmbWPAngleSize.Text
                twoByTwo = Me.txt2X2Qty.Text.ToString & " )  " & Me.cmbWPAngleSize.Text

                Select Case threeWP
                    Case True
                        ssQty = 3
                    Case False
                        ssQty = 2
                End Select

				If Me.txtExtB2B.Text <> String.Empty Then
					b2b = Me.txtExtB2B.Text
				Else
					b2b = Nothing
				End If
               
            ElseIf Me.cmbExtMounting.Text = "Advisory Panel" Then

				eightWF = Nothing
				sixWF = Nothing
				fiveWF = Nothing
				threeByFour = Nothing
				twoByTwo = Nothing

                ssQty = 0

				b2b = Nothing


            Else

                ' Determine proper support variable assignment
                Select Case Me.cmbBeamsAngle.SelectedIndex

                    Case -1 ' None selected
						eightWF = Nothing
						sixWF = Nothing
						fiveWF = Nothing
						threeByFour = Nothing
						twoByTwo = Nothing

					Case 0 ' 8WF
						eightWF = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
						sixWF = Nothing
						fiveWF = Nothing
						threeByFour = Nothing
						twoByTwo = Nothing

					Case 1 ' 6WF
						eightWF = Nothing
						sixWF = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
						fiveWF = Nothing
						threeByFour = Nothing
						twoByTwo = Nothing

					Case 2 ' 5WF
						eightWF = Nothing
						sixWF = Nothing
						fiveWF = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
						threeByFour = Nothing
						twoByTwo = Nothing

					Case 3 ' 3x4
						eightWF = Nothing
						sixWF = Nothing
						fiveWF = Nothing
						threeByFour = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text
						twoByTwo = Nothing

					Case 4 ' 2x2
						eightWF = Nothing
						sixWF = Nothing
						fiveWF = Nothing
						threeByFour = Nothing
						twoByTwo = Me.txtExtSptQty.Text.ToString & " )  " & Me.cmbSptSize.Text

				End Select


                Try
                    ssQty = CInt(Me.txtExtSptQty.Text)
                Catch ex As Exception
                    ssQty = 0
                End Try

				b2b = Nothing

            End If


            Try
                hdwQty = CInt(Me.txtExtHdwQty.Text)
            Catch ex As Exception
                hdwQty = 0
            End Try

            hardware = Me.txtEXTHdw.Text
            entryDate = Now.Date

            Me.ToolStripStatusLabel1.Text = "Sign Data Prepared for Extruded Entry."




        Catch ex As Exception

            MessageBox.Show(ex.Message, "PrepareEXTforAdding()")
            Me.ToolStripStatusLabel1.Text = "Error occurred when processing Extruded Sign Data."

        End Try



    End Sub

    Private Sub PreparePLY_FSforAdding()

        Try

            ssQty = CInt(Me.txtSupportQty.Text)
            support = Me.cmbPostType.Text
            hdwQty = CInt(Me.txtHardwareQty.Text)
            hdw = Me.txtHardware.Text
            sheeting = Me.cmbSheetType.Text


            Me.ToolStripStatusLabel1.Text = "Sign Data Prepared for Sign Entry."

            Select Case Me.thisPanelType

                Case "Plywood"
                    AddPWSign()

				Case "Flatsheet", "TypeV"
					AddFSSign()

                Case Else
                    Me.ToolStripStatusLabel1.Text = "No work was done. Not accepted Panel type."

            End Select

        Catch ex As Exception

            Me.ToolStripStatusLabel1.Text = "Error occurred while processing sign Data."

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
						Me.cmbSptSize.SelectedIndex = 13		 ' (8' - 0")
						'Me.txtParent.Select()

					Catch ex As Exception
						MessageBox.Show(ex.Message)
					End Try


				Case "Advisory Panel"
					Try
                        Me.cmbExtColor.Text = "4081"

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


				Case "Bridge Conn"
					Try
						'Me.cmbBeamsAngle.Select()

					Catch ex As Exception
						MessageBox.Show(ex.Message)
					End Try


				Case "C-Truss 50' - 70'", "C/D-Truss", "E-Truss 50'-105'", "E-Truss 110'-140'"
					Try
						Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 1))
						Me.cmbBeamsAngle.Text = "5WF"
						'Me.btnAddSign.Select()

					Catch ex As Exception
						'MessageBox.Show(ex.Message)
					End Try


				Case "E/D/G-Cant", "J-Cant", "C-Cant", "H-Cant"
					Try
						Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 0))
						Me.cmbBeamsAngle.Text = "5WF"
						'Me.btnAddSign.Select()
					Catch ex As Exception
						'MessageBox.Show(ex.Message)
					End Try



					'Case "C/D-Truss"

					'    Try
					'        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 1))
					'        Me.cmbBeamsAngle.Text = "5WF"
					'        'Me.btnAddSign.Select()
					'    Catch ex As Exception
					'        'MessageBox.Show(ex.Message)
					'    End Try

					'Case "E-Truss 50'-105'", "E-Truss 110'-140'"

					'	Try
					'		Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 1))
					'		Me.cmbBeamsAngle.Text = "5WF"
					'		'Me.btnAddSign.Select()
					'	Catch ex As Exception
					'		'MessageBox.Show(ex.Message)
					'	End Try

					'Case "E-Truss 110'-140'"

					'    Try
					'        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 1))
					'        Me.cmbBeamsAngle.Text = "5WF"
					'        'Me.btnAddSign.Select()
					'    Catch ex As Exception
					'        'MessageBox.Show(ex.Message)
					'    End Try








					'Case "E/D/G-Cant"
					'    Try
					'        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 0))
					'        Me.cmbBeamsAngle.Text = "5WF"
					'        'Me.btnAddSign.Select()

					'    Catch ex As Exception
					'        'MessageBox.Show(ex.Message)
					'    End Try


					'Case "C-Cant"

					'    Try
					'        Me.txtExtSptQty.Text = CStr(CantsTrussBeamQty(CInt(Me.txtExtWidth.Text), 0))
					'        Me.cmbBeamsAngle.Text = "5WF"
					'        'Me.btnAddSign.Select()
					'    Catch ex As Exception
					'        'MessageBox.Show(ex.Message)

					'    End Try

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


    Private Function CantsTrussBeamQty(ByVal sW As Integer, ByVal CantOrTruss As Integer) As Integer
        Try
            Dim bQty As Integer

            Select Case CantOrTruss

                Case 0 '  Cantilever

                    Select Case sW
                        Case 4 To 11
                            bQty = 2    ' 2 Beams
                        Case 12 To 22
                            bQty = 3    ' 3 Beams
                        Case 23 To 33
                            bQty = 4    ' 4 Beams
                        Case Is >= 34
                            bQty = 5    ' 5 Beams
                    End Select


                Case 1 '  Truss

                    Select Case sW
                        Case 4 To 16
                            bQty = 2    ' 2 Beams
                        Case 17 To 28
                            bQty = 3    ' 3 Beams
                        Case Is >= 29
                            bQty = 4    ' 4 Beams
                    End Select


            End Select

            Return bQty

        Catch ex As Exception
            Return Nothing
        End Try


    End Function


    Private Sub AddEXTSign()


        ' Declare objects
        Dim cmdInsertEXT As OleDbCommand = New OleDbCommand

        ' Open the connection
        mhsConn.Open()

        ' Set the OleDbCommand object properties
        cmdInsertEXT.Connection = mhsConn
        cmdInsertEXT.CommandText = _
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
        cmdInsertEXT.Parameters.AddWithValue("@mhsJob", mhsJN)
        cmdInsertEXT.Parameters.AddWithValue("@dir", direction)
		cmdInsertEXT.Parameters.AddWithValue("@station", staNum)

		' Parent
		If sParent IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@parentSign", sParent)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@parentSign", DBNull.Value)
		End If


		' Back to Back
		If b2b IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@b2b", b2b)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@b2b", DBNull.Value)
		End If


		cmdInsertEXT.Parameters.AddWithValue("@type", thisSignType)
        cmdInsertEXT.Parameters.AddWithValue("@code", sCode)

		' Details
		If sDetails IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@details", sDetails)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@details", DBNull.Value)
		End If


		'' 
		'If xxx IsNot Nothing Then
		'	cmdInsertEXT.Parameters.AddWithValue("@xxx", xxx)
		'Else
		'	cmdInsertEXT.Parameters.AddWithValue("@xxx", DBNull.Value)
		'End If


		cmdInsertEXT.Parameters.AddWithValue("@width", sW)
		cmdInsertEXT.Parameters.AddWithValue("@height", sH)
        cmdInsertEXT.Parameters.AddWithValue("@sqrFeet", sFT)
        cmdInsertEXT.Parameters.AddWithValue("@sptQty", ssQty)
        cmdInsertEXT.Parameters.AddWithValue("@support", extSupport)
        cmdInsertEXT.Parameters.AddWithValue("@retain", retain)
        cmdInsertEXT.Parameters.AddWithValue("@sheeting", EXTsheeting)
        cmdInsertEXT.Parameters.AddWithValue("@twelveInch", twelve)
		cmdInsertEXT.Parameters.AddWithValue("@sixInch", six)

		' 8" WF H-Beams
		If eightWF IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@eightWF", eightWF)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@eightWF", DBNull.Value)
		End If


		' 6" WF H-Beams
		If sixWF IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@sixWF", sixWF)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@sixWF", DBNull.Value)
		End If

		
		' 5" WF H-Beams
		If fiveWF IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@fiveWF", fiveWF)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@fiveWF", DBNull.Value)
		End If

		
		' 3x4 Angle
		If threeByFour IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@threeByFour", threeByFour)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@threeByFour", DBNull.Value)
		End If
		

		' 2x2 Angle
		If twoByTwo IsNot Nothing Then
			cmdInsertEXT.Parameters.AddWithValue("@twoByTwo", twoByTwo)
		Else
			cmdInsertEXT.Parameters.AddWithValue("@twoByTwo", DBNull.Value)
		End If


		cmdInsertEXT.Parameters.AddWithValue("@hdwQty", hdwQty)
		cmdInsertEXT.Parameters.AddWithValue("@hardware", hardware)
        cmdInsertEXT.Parameters.AddWithValue("@entryDate", entryDate)


        ' Execute the OleDbCommand object to insert the new data
        Try
            cmdInsertEXT.ExecuteNonQuery()

            'Create OleDbCommand for SELECT @@IDENTITY statement
            cmdInsertEXT.CommandText = "SELECT @@IDENTITY"
            signIdentity = CInt(cmdInsertEXT.ExecuteScalar())

            isAdded = True
            Me.ToolStripStatusLabel1.Text = "(" & staNum & ") added successfully"

        Catch OleDbExceptionErr As OleDbException
            isAdded = False
            Me.ToolStripStatusLabel1.Text = "(" & staNum & ") Not added!"
            MessageBox.Show(OleDbExceptionErr.Message, "AddEXTSign()")

        End Try

        ' Close the connection
        mhsConn.Close()


    End Sub

    Private Sub AddPWSign()


        ' Declare objects
        Dim cmdInsertPLY As OleDbCommand = New OleDbCommand

        ' Open the connection
        mhsConn.Open()

        ' Set the OleDbCommand object properties
        cmdInsertPLY.Connection = mhsConn
        cmdInsertPLY.CommandText = _
                    "INSERT INTO PlywoodTOF " & _
                        "(mhsJob, station, type, code, " & _
                        "details, width, height, sqrFeet, " & _
                        "sptQty, support, hdwQty, hdw, sheeting) " & _
                        "VALUES(@mhsJob, @station, @type, @code, " & _
                        "@details, @width, @height, @sqrFeet, " & _
                        "@sptQty, @support, @hdwQty, @hdw, @sheeting)"


        ' Add placeholder parameters 
        cmdInsertPLY.Parameters.AddWithValue("@mhsJob", mhsJN)
        cmdInsertPLY.Parameters.AddWithValue("@station", staNum)
        cmdInsertPLY.Parameters.AddWithValue("@type", thisSignType)
        cmdInsertPLY.Parameters.AddWithValue("@code", sCode)
        cmdInsertPLY.Parameters.AddWithValue("@details", sDetails)
        cmdInsertPLY.Parameters.AddWithValue("@width", sW)
        cmdInsertPLY.Parameters.AddWithValue("@height", sH)
        cmdInsertPLY.Parameters.AddWithValue("@sqrFeet", sFT)
        cmdInsertPLY.Parameters.AddWithValue("@sptQty", ssQty)
        cmdInsertPLY.Parameters.AddWithValue("@support", support)
        cmdInsertPLY.Parameters.AddWithValue("@hdwQty", hdwQty)
        cmdInsertPLY.Parameters.AddWithValue("@hdw", hdw)
        cmdInsertPLY.Parameters.AddWithValue("@sheeting", sheeting)

        ' Execute the OleDbCommand object to insert the new data
        Try
            cmdInsertPLY.ExecuteNonQuery()

            'Create OleDbCommand for SELECT @@IDENTITY statement
            cmdInsertPLY.CommandText = "SELECT @@IDENTITY"
            signIdentity = CInt(cmdInsertPLY.ExecuteScalar())

           isAdded = True
            Me.ToolStripStatusLabel1.Text = "(" & staNum & ") added successfully"

        Catch OleDbExceptionErr As OleDbException
            isAdded = False
            Me.ToolStripStatusLabel1.Text = "(" & staNum & ") Not added!"
            MessageBox.Show(OleDbExceptionErr.Message, "AddPWSign()")

        End Try

        ' Close the connection
        mhsConn.Close()

    End Sub

    Private Sub AddFSSign()


        ' Declare objects
        Dim cmdInsertFS As OleDbCommand = New OleDbCommand

        ' Open the connection
        mhsConn.Open()

        ' Set the OleDbCommand object properties
        cmdInsertFS.Connection = mhsConn
        cmdInsertFS.CommandText = _
                    "INSERT INTO FlatSheetTOF " & _
                        "(mhsJob, station, type, code, " & _
                        "details, width, height, sqrFeet, " & _
                        "sptQty, support, hdwQty, hdw, sheeting) " & _
                        "VALUES(@mhsJob, @station, @type, @code, " & _
                        "@details, @width, @height, @sqrFeet, " & _
                        "@sptQty, @support, @hdwQty, @hdw, @sheeting)"


        ' Add placeholder parameters 
        cmdInsertFS.Parameters.AddWithValue("@mhsJob", mhsJN)
        cmdInsertFS.Parameters.AddWithValue("@station", staNum)
        cmdInsertFS.Parameters.AddWithValue("@type", thisSignType)
        cmdInsertFS.Parameters.AddWithValue("@code", sCode)
        cmdInsertFS.Parameters.AddWithValue("@details", sDetails)
        cmdInsertFS.Parameters.AddWithValue("@width", sW)
        cmdInsertFS.Parameters.AddWithValue("@height", sH)
        cmdInsertFS.Parameters.AddWithValue("@sqrFeet", sFT)
        cmdInsertFS.Parameters.AddWithValue("@sptQty", ssQty)
        cmdInsertFS.Parameters.AddWithValue("@support", support)
        cmdInsertFS.Parameters.AddWithValue("@hdwQty", hdwQty)
        cmdInsertFS.Parameters.AddWithValue("@hdw", hdw)
        cmdInsertFS.Parameters.AddWithValue("@sheeting", sheeting)

        ' Execute the OleDbCommand object to insert the new data
        Try
            cmdInsertFS.ExecuteNonQuery()

            'Create OleDbCommand for SELECT @@IDENTITY statement
            cmdInsertFS.CommandText = "SELECT @@IDENTITY"
            signIdentity = CInt(cmdInsertFS.ExecuteScalar())

            isAdded = True
            Me.ToolStripStatusLabel1.Text = "(" & staNum & ") added successfully"

        Catch OleDbExceptionErr As OleDbException
            isAdded = False
            Me.ToolStripStatusLabel1.Text = "(" & staNum & ") Not added!"
            MessageBox.Show(OleDbExceptionErr.Message, "addFSSign()")
        End Try

        ' Close the connection
        mhsConn.Close()

    End Sub



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
                Me.ToolStripStatusLabel1.Text = "Cluster added successfully"

            Catch OleDbExceptionErr As OleDbException
                MessageBox.Show(OleDbExceptionErr.Message)
                Me.ToolStripStatusLabel1.Text = "Cluster Not Added!"

            End Try

            ' Close the connection
            mhsConn.Close()

    End Sub



    Public Sub calcSqFt()

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

    Public Sub calcEXTSqFt()  ' Also counts number of 12" and 6" plank

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



    Public Sub IdentifySheetingEXT(ByVal signCode As String)
        Try
            ' Set Sheeting Type and various details
            If signCode.ToUpper.Substring(0, 3) = "D10" Then
                Me.cmbExtColor.Text = "4090"
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
                Me.cmbExtColor.Text = "4081"

            ElseIf signCode.ToUpper.Substring(0, 1) = "O" Then
                Me.cmbExtColor.Text = "4081"
                Me.txtExtHdwQty.Text = CStr(3)

            ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
                Me.cmbExtColor.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                Me.cmbExtColor.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbExtColor.Text = "4083"

            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbExtColor.Text = "4083"

            ElseIf signCode.ToUpper.Substring(0, 4) = "E1-5" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Exit Panel"
                Me.txtExtHeight.Text = CStr(2.5)



            ElseIf signCode = "E11-1" Then
                Me.cmbExtMounting.SelectedIndex = 0
                Me.cmbExtMounting.Text = "Advisory Panel"

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
			ElseIf signCode = "OVERLAY" Then
				Me.cmbExtColor.Text = "3935"
			ElseIf signCode = "MAINLINE" Then
				Me.cmbExtColor.Text = "3935"
			ElseIf signCode = "RAMP" Then
				Me.cmbExtColor.Text = "3935"

			End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

	End Sub

	Public Sub IdentifySheetingPW_OLD(ByVal signCode As String)
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
			ElseIf signCode = "OVERLAY" Then
				Me.cmbExtColor.Text = "3935"
			ElseIf signCode = "MAINLINE" Then
				Me.cmbExtColor.Text = "3935"
			ElseIf signCode = "RAMP" Then
				Me.cmbExtColor.Text = "3935"


			End If

		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try

	End Sub

	Public Sub IdentifySheetingPW_NEW(ByVal signCode As String)


	End Sub

    Public Sub IdentifySheetingPW(ByVal signCode As String)
        Try
            ' Set Sheeting Type and various details
            If signCode.ToUpper.Substring(0, 3) = "D10" Then
                Me.cmbSheetType.Text = "4090"
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
                Me.cmbSheetType.Text = "4081"

            ElseIf signCode.ToUpper.Substring(0, 1) = "O" Then
                Me.cmbSheetType.Text = "4081"
                Me.txtHardwareQty.Text = CStr(3)

            ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
                Me.cmbSheetType.Text = "3930"

            ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
                Me.cmbSheetType.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
                Me.cmbSheetType.Text = "3937"

            ElseIf signCode.ToUpper.Substring(0, 2) = "S1" Then
                Me.cmbSheetType.Text = "4083"

            ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
                Me.cmbSheetType.Text = "4083"

            ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
                Me.cmbSheetType.Text = "3937"

            ElseIf signCode = "[SALVAGE]" Then
                Me.cmbExtColor.Text = "NONE"

            ElseIf signCode = "[MDOT]" Then
                Me.cmbExtColor.Text = "NONE"

			ElseIf signCode = "OVERLAY" Then
				Me.cmbExtColor.Text = "3935"
			ElseIf signCode = "MAINLINE" Then
				Me.cmbExtColor.Text = "3935"
			ElseIf signCode = "RAMP" Then
				Me.cmbExtColor.Text = "3935"


			End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

	End Sub

	Public Sub IdentifySheetingFW_OLD(ByVal signCode As String)
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
				'Me.txtSignWidth.Text = CStr(36)
				'Me.txtSignHeight.Text = CStr(12)
				'Me.txtSupportQty.Text = CStr(1)

			ElseIf signCode.ToUpper.Substring(0, 1) = "R" Then
				Me.cmbSheetType.Text = "3930"


			ElseIf signCode.ToUpper.Substring(0, 3) = "M1-" Then
				Me.cmbSheetType.Text = "3990"
				Me.txtSupportQty.Text = CStr(1)

			ElseIf signCode.ToUpper.Substring(0, 1) = "M" Then
				Me.cmbSheetType.Text = "3930"

			ElseIf signCode.ToUpper.Substring(0, 1) = "I" Then
				Me.cmbSheetType.Text = "3930"

			ElseIf signCode.ToUpper.Substring(0, 3) = "S1-" Then
				Me.cmbSheetType.Text = "3983"

			ElseIf signCode.ToUpper.Substring(0, 4) = "S4-3" Then
				Me.cmbSheetType.Text = "3983"

			ElseIf signCode.ToUpper.Substring(0, 1) = "E" Then
				Me.cmbSheetType.Text = "3930"

			ElseIf signCode = "[SALVAGE]" Then
				Me.cmbSheetType.Text = "NONE"

			ElseIf signCode = "[MDOT]" Then
				Me.cmbSheetType.Text = "NONE"

			ElseIf signCode = "OVERLAY" Then
				Me.cmbSheetType.Text = "3935"
			ElseIf signCode = "MAINLINE" Then
				Me.cmbSheetType.Text = "3935"
			ElseIf signCode = "RAMP" Then
				Me.cmbSheetType.Text = "3935"

			End If

		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try
	End Sub

	Public Sub IdentifySheetingFS_NEW(ByVal signCode As String)

		' Set Sheeting Type and various details
		Try
			Dim sheetCode As String = "NONE"
			Dim signCodeTEMP As String = Nothing

			Select Case signCode
				Case "OVERLAY", "MAINLINE", "RAMP"
					sheetCode = "3935"
				Case "W20-4C", "W23-2", "W25-1", "W25-2"
					sheetCode = "3981"
				Case "[SALVAGE]", "[MDOT]"
					sheetCode = "NONE"
				Case Else  ' Broader Range of Sign Codes
					' 4-digit comparison
					signCodeTEMP = signCode.ToUpper.Substring(0, 4)
					Select Case signCodeTEMP
						Case "S1-1", "S3-2", "S4-3", "S4-5", "S4-7"
							sheetCode = "3983"
						Case "S3-3", "S4-1", "S4-4", "S4-6", "S5-1", "S5-2", "S5-3"
							sheetCode = "3930"
						Case "D10-"
							sheetCode = "3990"
							Me.txtHardwareQty.Text = "3"
						Case "D3-1"
							sheetCode = "3930"
						Case "OM-3", "E13-"
							sheetCode = "3981"
							Me.txtHardwareQty.Text = "3"
						Case "OM-4"
							sheetCode = "3932"
						Case "W20-", "W21-", "W22-", "W23-", "W24-", "G20-", "E5-2", "M4-8", "M4-9", "M4-1"
							sheetCode = "3924"

						Case Else
							' 1-digit comparison
							signCodeTEMP = signCode.ToUpper.Substring(0, 1)
							Select Case signCodeTEMP
								Case "D", "M"
									sheetCode = "3990"
								Case "W", "O"
									sheetCode = "3981"
								Case "R", "E", "I"
									sheetCode = "3930"
							End Select
					End Select
			End Select

			Me.cmbSheetType.Text = sheetCode

		Catch ex As Exception
			MessageBox.Show(ex.Message, "IdentifySheetingFS()")
		End Try


	End Sub

    Public Sub IdentifySheetingFS(ByVal signCode As String)

		' Set Sheeting Type and various details
		Try
			If signCode.Length <= 0 Then
				Exit Sub
			End If

			Dim sheetCode As String = "NONE"
			Dim signCodeTEMP As String = Nothing

			Select Case signCode
				Case "OVERLAY", "MAINLINE", "RAMP"
					sheetCode = "3935"
				Case "W20-4C", "W23-2", "W25-1", "W25-2"
                    sheetCode = "4081"
				Case "[SALVAGE]", "[MDOT]"
					sheetCode = "NONE"
				Case Else  ' Broader Range of Sign Codes

					If signCode.Length > 3 Then
						' 4-digit comparison
						signCodeTEMP = signCode.ToUpper.Substring(0, 4)
						Select Case signCodeTEMP
							Case "S1-1", "S3-2", "S4-3", "S4-5", "S4-7"
                                sheetCode = "4083"
							Case "S3-3", "S4-1", "S4-4", "S4-6", "S5-1", "S5-2", "S5-3"
								sheetCode = "3930"
							Case "D10-"
								sheetCode = "4090"
								Me.txtHardwareQty.Text = "3"
							Case "D3-1", "D3-2"
								sheetCode = "3930"
							Case "OM-3", "E13-"
                                sheetCode = "4081"
								Me.txtHardwareQty.Text = "3"
							Case "OM-4"
								sheetCode = "3932"
							Case "W20-", "W21-", "W22-", "W23-", "W24-", "G20-", "E5-2", "M4-8", "M4-9", "M4-1"
								sheetCode = "3924"
							Case Else
								' 1-digit comparison
								signCodeTEMP = signCode.ToUpper.Substring(0, 1)
								Select Case signCodeTEMP
									Case "M"
                                        sheetCode = "4090"
									Case "W", "O"
                                        sheetCode = "4081"
									Case "R", "E", "I"
										sheetCode = "3930"
									Case "G"
										sheetCode = "3924"
									Case Else
										sheetCode = "3930"
								End Select
						End Select
					Else
						' 1-digit comparison
						signCodeTEMP = signCode.ToUpper.Substring(0, 1)
						Select Case signCodeTEMP
							Case "M"
                                sheetCode = "4090"
							Case "W", "O"
                                sheetCode = "4081"
							Case "R", "E", "I"
								sheetCode = "3930"
							Case "G"
								sheetCode = "3924"
							Case Else
								sheetCode = "3930"
						End Select
					End If

			End Select

			Me.cmbSheetType.Text = sheetCode

		Catch ex As Exception
			MessageBox.Show(ex.Message, "IdentifySheetingFS()")
		End Try

    End Sub

    
    Private Sub ViewSign(ByVal sType As Integer, ByVal sID As Integer)


        Dim vSign As New frmViewSign(sType, sID)
        vSign.MdiParent = signINMain1
        vSign.Show()



    End Sub






    ' Testing - 
    Private Sub MaximizeCurrentFormOnly()

        For Each f As Form In Me.ParentForm.MdiChildren

            If Not f.Name = Me.Name Then
                f.WindowState = FormWindowState.Normal
            End If

        Next


    End Sub




#End Region


#Region " Event Procedures"

    Private Sub frmGlobalTakeOff_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown


        Select Case e.KeyData

            Case Keys.F1

                ' Select Extruded Panel Type
                Me.rdoExtruded.Checked = True
                e.SuppressKeyPress = True

            Case Keys.F2

                ' Select Plywood Panel Type
                Me.rdoPlywood.Checked = True
                e.SuppressKeyPress = True

            Case Keys.F3

                ' Select FlatSheet Panel Type
                Me.rdoFlatSheet.Checked = True
				e.SuppressKeyPress = True

			Case Keys.F4

				' Select FlatSheet Panel Type
				Me.rdoFSOverlay.Checked = True
				e.SuppressKeyPress = True


			Case Keys.F5

				' Select Type V Panel Type
				Me.rdoFSTypeV.Checked = True
				e.SuppressKeyPress = True

			Case Keys.Control Or Keys.R

				' Reset TakeOff Form
				Me.tsbReset_Click(Nothing, Nothing)
				e.SuppressKeyPress = True

            Case Keys.Control Or Keys.M

                ' Migrate ATM Data
                Me.dgvATMTOF_DoubleClick(Nothing, Nothing)
                e.SuppressKeyPress = True

            Case Keys.Control Or Keys.U

                ' Add Sign To DataBase
				AddSignToList(Nothing, Nothing)
				e.SuppressKeyPress = True

			Case Keys.Control Or Keys.N
				btnAtmTOFNext_Click(Nothing, Nothing)
				e.SuppressKeyPress = True

			Case Keys.Control Or Keys.B
				btnAtmTOFPrev_Click(Nothing, Nothing)
				e.SuppressKeyPress = True







			Case Keys.Control Or Keys.D3
				' Visi-Strips 3'
				btnsVisi36_72_Click(Me.btn36inVisi, Nothing)
				e.SuppressKeyPress = True

			Case Keys.Control Or Keys.D6
				' Visi-Strips 6'
				btnsVisi36_72_Click(Me.btn72inVisi, Nothing)
				e.SuppressKeyPress = True

			Case Keys.Control Or Keys.Shift Or Keys.R
				btnVisi_Color_Click(Me.btnRed, Nothing)

			Case Keys.Control Or Keys.Shift Or Keys.Y
				btnVisi_Color_Click(Me.btnYellow, Nothing)

			Case Keys.Control Or Keys.Shift Or Keys.W
				btnVisi_Color_Click(Me.btnWhite, Nothing)

			Case Keys.Control Or Keys.Shift Or Keys.O
				btnVisi_Color_Click(Me.btnOther, Nothing)


		End Select


    End Sub

    Private Sub frmGlobalTakeOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        Me.SplitContainer1.Panel1Collapsed = True

        ' Fill DataSet with DataAdapter connected to DataBase
        PopulateEXTSheeting()
        PopulateEXTSupport()
        PopulatePWSupport()
        PopulateFSSupport()
        PopulatePWandFSSheeting()
        PopulateHeights()
        PopulateMHSJobs()
        PopulateSignCodes()
        PopulateDetails()

        BindSignCodeFields()
        BindDetails()


        'Me.lblPdfTitle.Visible = False
        Me.lblSignCodeDesc.Visible = False
        Me.lblType.Visible = False
        Me.picSignImage.Visible = False


        ResetAfterAdd()


        Me.ToolStripStatusLabel1.Text = "Ready"

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub btnAtmTOFNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles btnAtmTOFNext.Click, _
                        btnATMNext.Click, _
                        btnEXTATMNext.Click


        '  Selected next item in combo box
        '  triggering payItemID list and 
        '  sign selection 
        Try

            Dim x As Integer = Me.cmbATMStations.SelectedIndex
            Dim y As Integer = Me.cmbATMStations.Items.Count - 1

            If x < y Then
                Me.cmbATMStations.SelectedIndex += 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "button1_click()")

        End Try

    End Sub

    Private Sub btnAtmTOFPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles btnAtmTOFPrev.Click, _
                        btnATMPrev.Click, _
                        btnEXTATMPrev.Click


        '  Selected next item in combo box
        '  triggering payItemID list and 
        '  sign selection 
        Try

            If Me.cmbATMStations.SelectedIndex >= 1 Then
                Me.cmbATMStations.SelectedIndex -= 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "button2_click()")

        End Try
    End Sub

    Private Sub cmbATMStations_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbATMStations.SelectedIndexChanged

        If Me.cmbATMStations.SelectedIndex >= 0 Then
            filterAndSelect()
        End If


    End Sub

    Private Sub dgvATMTOF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
                        Handles dgvATMTOF.DoubleClick, _
                        tsbMigrateATMData.Click, _
                        btnEXTMigrateATM.Click, _
                        btnMigrateATM.Click



        Me.Cursor = Cursors.PanSouth

        Try
            '' Declare variable for PayItemID value
            'Dim value As String = Me.dgvATMTOF.CurrentRow.Cells.Item(2).Value.ToString
            'Me.txtSignDetails.Text = value

            Dim x As Integer = CInt(Me.dgvATMTOF.CurrentRow.Cells.Item(2).Value)

            ' Convert PayItemID to conventional sign type.
            ' This method also handles the SplitContainers
            ' and how they function for each type.

            Dim s As String = GetSignType(x)

            Select Case s

				Case Is = "IA", "IB", "IC", "ID", "I"
					migrateExtrudedSign(s)

				Case Is = "IIA", "IIB", "IIC", "IID", "II"
					migratePlywoodSign(s)

				Case Is = "IIIA", "IIIB", "IIIC", "IIID", "III"
					migrateFlatSheetSign(s)

                Case Else
					MessageBox.Show("This item is not supported in the MHS DBMS System.", "Item Error", _
						   MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message, "dgvATMTOF_DoubleClick()")
        End Try


        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub dgvATMTOF_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvATMTOF.SelectionChanged

        showSignImage()


    End Sub


    Private Sub ToolStrip_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ToolStrip1.Paint
        If TypeOf ToolStrip1.Renderer Is ToolStripProfessionalRenderer Then
            CType(ToolStrip1.Renderer, ToolStripProfessionalRenderer).RoundedEdges = False
        End If
    End Sub

    Private Sub tsbTOFHideATM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTOFHideATM.Click
        If Me.SplitContainer1.Panel1Collapsed Then
            Me.SplitContainer1.Panel1Collapsed = False
            Me.tsbTOFHideATM.Text = "Hide ATM TakeOff"
        Else
            Me.SplitContainer1.Panel1Collapsed = True
            Me.tsbTOFHideATM.Text = "Show ATM TakeOff"
        End If
    End Sub

    Private Sub tsbSwitchTypesPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSwitchTypesPanel.Click

        Dim t As Boolean = Me.SplitContainerTYPES.Panel1Collapsed

        '  If Extruded Panel (SplitContainerTYPES.Panel1)
        '  is collapsed then open it and collapse
        '  II and III Panel (SplitContainerTYPES.Panel2)


        Select Case t

            Case True
                ' Extruded Panel
                Me.SplitContainerTYPES.Panel1Collapsed = False
                Me.SplitContainerTYPES.Panel2Collapsed = True
                'Me.tsbSwitchTypesPanel.Text = "Show PLY/FS Panel"

            Case False
                ' FlatSheet and Plywood Panel
                Me.SplitContainerTYPES.Panel2Collapsed = False
                Me.SplitContainerTYPES.Panel1Collapsed = True
                'Me.tsbSwitchTypesPanel.Text = "Show EXT Panel"

        End Select


    End Sub

    Private Sub tsbCmbMHSJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbCmbMHSJob.SelectedIndexChanged


		
        FilterMHSJobDV()
		BindMHSJobs()

		Me.ToolStripStatusLabel1.Text = "ATM TakeOff Loaded"



    End Sub

    Private Sub cmbSignCodes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbSignCodes.TextChanged, _
                        cmbSignCodes.SelectedIndexChanged, _
                        tsbMigrateATMData.Click


		'Me.Cursor = Cursors.PanEast

        Try
            Me.txtSignCode.Text = Me.cmbSignCodes.Text

			If Me.cmbSignCodes.SelectedIndex > -1 Then
				Me.lblSignCodeDesc.Visible = True
				Me.lblType.Visible = True
				Me.picSignImage.Visible = True
			Else

				'Me.cmbSelectType.Enabled = True

			End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "cmbSignCodes_TextChanged()")
        End Try

		'Me.Cursor = Cursors.Arrow

	End Sub


	'' Old
	'Private Sub txtSignCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
	'					   Handles txtSignCode.TextChanged, _
	'					   txtStation.TextChanged, _
	'					   txtExtSqrFeet.TextChanged, _
	'					   txtSqrFeet.TextChanged, _
	'					   cmbPostType.SelectedIndexChanged


	'	showSignImageTOF()

	'	Try

	'		Dim sC As String = Me.txtSignCode.Text

	'		Select Case Me.thisPanelType

	'			Case "Extruded"
	'				IdentifySheetingEXT(sC)

	'			Case "Plywood"
	'				IdentifySheetingPW(sC)

	'			Case "Flatsheet"
	'				IdentifySheetingFS(sC)

	'			Case Else
	'				IdentifySheetingFS(sC)

	'		End Select

	'		'If Me.lblType.Text.Trim = String.Empty Then
	'		'    Me.cmbSelectType.Enabled = True
	'		'Else
	'		'    Me.cmbSelectType.Enabled = False
	'		'End If

	'	Catch ex As Exception
	'		'MessageBox.Show(ex.Message)
	'	End Try


	'End Sub



	Private Sub txtSignCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSignCode.TextChanged

		showSignImageTOF()

		Try

			Dim sC As String = Me.txtSignCode.Text

			Select Case Me.thisPanelType

				Case "Extruded"
					IdentifySheetingEXT(sC)

				Case "Plywood"
					IdentifySheetingPW(sC)

				Case "Flatsheet"
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

    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, _
                                           ByVal e As System.EventArgs) Handles rdoExtruded.CheckedChanged, _
                                                                                rdoFlatSheet.CheckedChanged, _
                                                                                rdoPlywood.CheckedChanged, _
                                                                                rdoFSOverlay.CheckedChanged, _ 
																				rdoFSTypeV.CheckedChanged, _ 
                                                                                rdoDefault.CheckedChanged
        Dim opt As RadioButton = DirectCast(sender, RadioButton)

        If opt.Checked Then
            Me.signTypeRDO = opt
        End If


        If Me.btnConvert.Enabled = False Then
            enableAll()
        End If


        Me.thisSignType = Nothing

        Select Case Me.signTypeRDO.Name

            Case "rdoExtruded"

                PickPanelToShow(True)
                Me.PictureBoxLargeTypeI.Image = My.Resources.new_extruded_11
                Me.PictureBoxLargeTypeII.Image = Nothing

                Me.PictureBoxType.Image = My.Resources.new_extruded_1_24
                Me.lblEXTSignType.Text = "Extruded"
                Me.thisSignType = "I"
                Me.thisPanelType = "Extruded"


            Case "rdoPlywood"

                PickPanelToShow(False)
                Me.PictureBoxLargeTypeII.Image = My.Resources.new_plywood_11
                Me.PictureBoxLargeTypeI.Image = Nothing

                Me.PictureBoxType.Image = My.Resources.new_plywood_1_24
                Me.lblSignType.Text = "Plywood"
                Me.thisSignType = "II"
                Me.thisPanelType = "Plywood"
                BindPWSpt()


            Case "rdoFlatSheet"

                PickPanelToShow(False)
                Me.PictureBoxLargeTypeII.Image = My.Resources.new_flatsheet_11
                Me.PictureBoxLargeTypeI.Image = Nothing

                Me.PictureBoxType.Image = My.Resources.new_flatsheet_1_24
                Me.lblSignType.Text = "Flatsheet"
                Me.thisSignType = "III"
                Me.thisPanelType = "Flatsheet"
                BindFSSpt()


            Case "rdoFSOverlay"

                PickPanelToShow(False)
                Me.PictureBoxLargeTypeII.Image = Nothing
                Me.PictureBoxLargeTypeI.Image = Nothing

                Me.PictureBoxType.Image = Nothing
                Me.lblSignType.Text = "Flatsheet Overlay"
                Me.thisSignType = "IV"
                Me.thisPanelType = "FS-Overlay"
				BindFSSpt()

			Case "rdoFSTypeV"

				PickPanelToShow(False)
				Me.PictureBoxLargeTypeII.Image = My.Resources.new_flatsheet_11
				Me.PictureBoxLargeTypeI.Image = Nothing

				Me.PictureBoxType.Image = My.Resources.new_flatsheet_1_24
				Me.lblSignType.Text = "Type V"
				Me.thisSignType = "V"
				Me.thisPanelType = "TypeV"
				BindFSSpt()

			Case "rdoDefault"

				Me.PictureBoxLargeTypeII.Image = Nothing
				Me.PictureBoxLargeTypeI.Image = Nothing

				Me.PictureBoxType.Image = Nothing
				Me.lblSignType.Text = String.Empty
				Me.thisSignType = Nothing
				Me.thisPanelType = Nothing
				BindPWSpt()


		End Select


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

    Private Sub cmbSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles cmbSelectType.SelectedIndexChanged


        Select Case Me.thisPanelType

            Case "Extruded"

                Me.thisSignType = "I"

            Case "Plywood"

                Me.thisSignType = "II"

            Case "Flatsheet"

				Me.thisSignType = "III"

			Case "TypeV"

				Me.thisSignType = "V"

		End Select



        Try


            ' Process for each possible type
            Select Case Me.cmbSelectType.SelectedIndex
                Case 0
                    Me.thisSignType = Me.thisSignType & "A"

                Case 1
                    Me.thisSignType = Me.thisSignType & "B"

                Case 2
                    Me.thisSignType = Me.thisSignType & "C"

            End Select

            ' Display newly changed sign type
            Me.ToolStripStatusLabel1.Text = "Sign Type:  " & Me.thisSignType


        Catch ex As Exception

            MessageBox.Show(ex.Message)


        End Try



    End Sub

    Private Sub lblType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles lblType.TextChanged

        Try

            Select Case Me.thisPanelType

                Case "Extruded"

                    Me.thisSignType = "I"

                Case "Plywood"

                    Me.thisSignType = "II"

                Case "Flatsheet"

					Me.thisSignType = "III"

				Case "TypeV"
					Me.thisSignType = "V"


			End Select


            Dim t As String = Me.lblType.Text.ToUpper.Trim

            ' Process for each possible type
            Select Case t
                Case "A", "B", "C"
                    Me.thisSignType = Me.thisSignType & t

                Case String.Empty
                    Me.cmbSelectType.Enabled = True
					'Me.cmbSelectType.Focus()

                Case Else
                    'Me.cmbSelectType.Enabled = True
                    'Me.cmbSelectType.Focus()

            End Select

            ' Display newly changed sign type
            Me.ToolStripStatusLabel1.Text = "Sign Type:  " & Me.thisSignType

        Catch ex As Exception

            MessageBox.Show(ex.Message, "lblType_TextChanged()")


        End Try


	End Sub

    Private Sub lblPdfTitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPdfTitle.TextChanged

        ' Toggle PDF viewer button 
        Select Case Me.lblPdfTitle.Text
            Case String.Empty
                Me.tsbViewPDF.Enabled = False
            Case Else
                Me.tsbViewPDF.Enabled = True
        End Select

    End Sub

    Private Sub dgvSignsAdded_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSignsAdded.Click
        'MessageBox.Show("Test", "Testing")
    End Sub

	Private Sub dgvSignsAdded_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSignsAdded.DoubleClick

		Try

			Dim signTOFID As Integer = CType(Me.dgvSignsAdded.CurrentRow.Cells.Item(7).Value, Integer)
			Dim sT As String = Me.dgvSignsAdded.CurrentRow.Cells.Item(4).Value.ToString

			Dim intT As Integer = 0

			Select Case sT
				Case "I", "IA", "IB", "IC", "ID"
					intT = 1

				Case "II", "IIA", "IIB", "IIC", "IID"
					intT = 2

				Case "III", "IIIA", "IIIB", "IIIC", "IIID"
					intT = 3

				Case "IV", "IVA", "IVB", "IVC", "IVD"
					intT = 4

				Case "V", "VA", "VB", "VC", "VD"
					intT = 5
			End Select

			ViewSign(intT, signTOFID)

		Catch ex As Exception

		End Try


	End Sub

    Private Sub cmbPostType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPostType.SelectedIndexChanged

        Try
            '  To determine sign type.
            '  Then give appropriate action

            Select Case Me.thisPanelType

                Case "Plywood"

                    '  PLYWOOD
                    ' Add the Hardware from the Dictionary
                    ' to the textBox
                    Me.txtHardware.Text = Me.dctPWSpt.Item(Me.cmbPostType.Text)

                    If Me.cmbPostType.Text = "BRIDGE MOUNT" Then
                        Me.txtSupportQty.Text = CStr(0)
                        Me.txtHardwareQty.Text = CStr(0)

                    End If

                    'Me.btnAddSign.Select()


				Case "Flatsheet", "TypeV"

					'  FlATSHEET
					' Add the Hardware from the Dictionary
					' to the textBox
					Me.txtHardware.Text = Me.dctFSSpt.Item(Me.cmbPostType.Text)


                Case Else



            End Select

        Catch ex As Exception

        End Try



    End Sub

    Private Sub txtHardware_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHardware.DoubleClick

        Me.txtHardware.ReadOnly = False

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
            AutoBeamAngleSize(spt_size)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtExtWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtWidth.TextChanged
        Try
            calcEXTSqFt()


            If Me.cmbExtMounting.SelectedIndex > 0 Then

                AutoEXTSupport(Nothing, Nothing)

            End If


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEXTHdw_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEXTHdw.DoubleClick

        Me.txtEXTHdw.ReadOnly = False

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
            'signCode = Me.txtSignCode.Text
            'sType = Me.txtSignType.Text
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

            Me.ToolStripStatusLabel1.Text = "Parameters adjusted for 3 Wood Posts."


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBtoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBtoB.Click
        Me.txtSupportQty.Text = CStr(0)
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




        'Try
        '    Dim tempPostCount As Integer = CInt(Me.txtSupportQty.Text)
        '    tempPostCount += 1
        '    Me.txtSupportQty.Text = CStr(tempPostCount)
        'Catch ex As Exception
        '    MessageBox.Show("Value must be a number to increment.", _
        '                 "Hold UP!!!", _
        '                 MessageBoxButtons.OK, _
        '                 MessageBoxIcon.Question, _
        '                 MessageBoxDefaultButton.Button1)
        'End Try
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














        'Try
        '    Dim tempPostCount As Integer = CInt(Me.txtSupportQty.Text)
        '    tempPostCount -= 1
        '    Me.txtSupportQty.Text = CStr(tempPostCount)
        'Catch ex As Exception
        '    MessageBox.Show("Value must be a number to increment.", _
        '                 "Hold UP!!!", _
        '                 MessageBoxButtons.OK, _
        '                 MessageBoxIcon.Question, _
        '                 MessageBoxDefaultButton.Button1)
        'End Try
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        convertToInches()
    End Sub

    Private Sub btnCluster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCluster.Click
        addCluster(Me.mhsJN, Me.txtStation.Text, Me.cmbPostType.Text)
    End Sub

    Private Sub tsbReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReset.Click


        Try

            Dim resetDialogResult As New DialogResult
            resetDialogResult = MessageBox.Show("Are you sure you want to clear all form data?", _
                                                "Clear Form Data", _
                                                MessageBoxButtons.OKCancel, _
                                                MessageBoxIcon.Question)

            Select Case resetDialogResult

                Case Windows.Forms.DialogResult.OK

                    ResetAfterAdd()
                    BindSignCodeFields()


                Case Windows.Forms.DialogResult.Cancel

                    ' Do nothing and return to form


            End Select




        Catch ex As Exception
            'MessageBox.Show(ex.Message, "tsbReset_Click()")

        End Try


    End Sub

    Private Sub btnSinglePost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinglePost.Click

        Try
            Me.txtSupportQty.Text = CStr(1)

            Me.txtSignDetails.Text = "DRILL FOR SINGLE POST"

        Catch ex As Exception

        End Try



    End Sub

	Private Sub btnAddNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNotes.Click



		Try

			Dim note As String = Me.txtNotes.Text.Trim
			Dim noteID As Integer = CType(Me.dgvATMTOF.CurrentRow.Cells.Item(13).Value, Integer)
			Dim result As DialogResult = Windows.Forms.DialogResult.OK

			If note = Nothing Then
				result = MessageBox.Show _
				 ("You are attempting to add an empty note " & vbCrLf & _
				  "Click OK to continue", "Add ATM Station Note", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
			End If

			Select Case result
				Case Windows.Forms.DialogResult.OK
					UpdateLocationNotes(noteID, note)
				Case Else
					Exit Sub
			End Select


		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnAddNotes_Click()")

		End Try



	End Sub

	Private Sub btnsVisi36_72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn36inVisi.Click, btn72inVisi.Click

		Try

			Dim b As Button = DirectCast(sender, Button)
			Dim x As Integer = 0
			Dim expression As String = Nothing

			Select Case b.Name
				Case "btn36inVisi"
					x = 36
				Case "btn72inVisi"
					x = 72
				Case Else
					x = -1
			End Select

			AutoPopulateVisi(x)




		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnsVisi36_72_Click()")

		End Try


	End Sub

	Private Sub AutoPopulateVisi(ByVal size As Integer)

		Me.rdoFlatSheet.Checked = True
		Me.cmbSignCodes.Text = "VISI-STRIPS"
		Me.txtSignWidth.Text = "3"
		Me.txtSignHeight.Text = size.ToString
		Me.cmbPostType.Text = "3-lb. Post"
		Me.txtSqrFeet.Text = "1"
		Me.txtHardwareQty.Text = "3"


	End Sub


	Private Sub btnVisi_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRed.Click, btnYellow.Click, btnWhite.Click, btnOther.Click

		Try

			Dim b As Button = DirectCast(sender, Button)
			Dim x As Integer = 0
			Dim colorCode As String = Nothing

			Select Case b.Name
				Case "btnRed"
					colorCode = "3932"
				Case "btnYellow"
                    colorCode = "4081"
				Case "btnWhite"
					colorCode = "3930"
				Case "btnOther"
					colorCode = "NONE"
					Me.cmbSheetType.Focus()
					Me.cmbSheetType.SelectAll()
					Exit Sub
			End Select

			' Set ComboBox 3M Sheeting Code
			Me.cmbSheetType.Text = colorCode

            '' Add legend details
            'Me.txtSignDetails.Text = "3x" & Me.txtSignHeight.Text & " on " & colorCode

			' Disabled here due to it being called during AddSignToList() method
			'' Copy Station Number to the clipboard for faster duplicate entries
			'My.Computer.Clipboard.SetText(Me.txtStation.Text)

			' Insert Record into database 
			AddSignToList(Nothing, Nothing)
			

		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnVisi_Color_Click()")

		End Try


	End Sub


#End Region



#Region " Load combo boxes"

	Public Sub PopulateMHSJobs()

		Try

			mhsJobDA = New OleDbDataAdapter("SELECT * FROM mhsJobs WHERE Active = True ORDER By mhsJob DESC", mhsConn)

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

			Me.tsbLblMHSJob.Text = String.Empty

			RemoveHandler tsbCmbMHSJob.SelectedIndexChanged, AddressOf tsbCmbMHSJob_SelectedIndexChanged
			' Populate tsbCmbMHSJob combo box
			With Me.tsbCmbMHSJob
				.ComboBox.DataSource = mhsJobDT
				.ComboBox.DisplayMember = "mhsJob"
			End With
			AddHandler tsbCmbMHSJob.SelectedIndexChanged, AddressOf tsbCmbMHSJob_SelectedIndexChanged

			Me.tsbCmbMHSJob.Text = "Select"


		Catch ex As Exception

		End Try



	End Sub

	Private Sub BindMHSJobs()

		If Me.tsbCmbMHSJob.ComboBox.Items.Count > 1 Then

			' Clear DataBinding
			Me.lblCustJob.DataBindings.Clear()
			Me.lblCust.DataBindings.Clear()
			Me.lblJobDesc.DataBindings.Clear()
			Me.lblProjNum.DataBindings.Clear()
			Me.lblStateNum.DataBindings.Clear()
			Me.lblCompDate.DataBindings.Clear()
			'Me.ckbActive.DataBindings.Clear()
			'Me.ckbMMM.DataBindings.Clear()

			' Add DataBinding
			Me.lblCustJob.DataBindings.Add("Text", mhsJobDT, "custJob")
			Me.lblCust.DataBindings.Add("Text", mhsJobDT, "cust")
			Me.lblJobDesc.DataBindings.Add("Text", mhsJobDT, "jobDesc")
			Me.lblProjNum.DataBindings.Add("Text", mhsJobDT, "projNum")
			Me.lblStateNum.DataBindings.Add("Text", mhsJobDT, "stateNum")

			' Format Date
			Me.lblCompDate.DataBindings.Add("Text", mhsJobDT, "compDate", True).FormatString = "MM/dd/yyyy"
			'Me.ckbActive.DataBindings.Add("Checked", mhsJobDT, "Active")
			'Me.ckbMMM.DataBindings.Add("Checked", mhsJobDT, "MMMDisc")

		End If

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

			' Create binding source
			scBS = New BindingSource(scDS, "tblSignCodes")

			' DataTable -   Fill the DataTable object with data
			scDT = scDS.Tables("tblSignCodes")

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
			Me.cmbSptSize.DataSource = lstHeightsValues
			Me.cmbWPAngleSize.DataSource = lstHeightsValues

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
			MessageBox.Show(ex.Message, "BindDetails()")
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


			' Create list of the Values of the Dictionary (String Heights, in this case)
			Dim lstPWSPTKeys As New List(Of String)(dctPWSpt.Keys)
			Me.cmbPostType.DataSource = Nothing
			Me.cmbPostType.DataSource = lstPWSPTKeys


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

				' Add "Select ..." at Item(0)
				Me.dctFSSpt.Add("Select Type III Support", String.Empty)

				' Iterate through DataTable and add each row 
				' to the Dictionary
				For Each row As DataRow In fsSptDT.Rows
					' Add Key/Value to the Dictionary
					dctFSSpt.Add(row.Item(0).ToString, row.Item(1).ToString)
				Next

			End If


			' Create list of the Values of the Dictionary (String Heights, in this case)
			Dim lstFSSPTKeys As New List(Of String)(dctFSSpt.Keys)
			Me.cmbPostType.DataSource = Nothing
			Me.cmbPostType.DataSource = lstFSSPTKeys


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










#Region " Unused Misc code"

	'Case Is = "8100175" 'IA

	'    'imageColumn.Icon = My.Resources.new_extruded_1



	'Case Is = "8100179"  'IB

	'    'imageColumn.Icon = My.Resources.new_extruded_1



	'Case Is = "8100176"  'IIA

	'    imageColumn.Icon = My.Resources.new_plywood_1



	'Case Is = "8100180"  'IIB

	'    imageColumn.Icon = My.Resources.new_plywood_1


	'Case Is = "8100177"  'IIIA

	'    imageColumn.Icon = My.Resources.new_flatsheet_1




	'Case Is = "8100181"  'IIIB






	' Discard
	Private Sub filterPayItemID()
		Try
			If pIDDV IsNot Nothing Then
				pIDDV.RowFilter = "payItemID = '" & CInt(Me.dgvATMTOF.CurrentRow.Cells.Item(2).Value) & "'"
				pIDDT.Select()
				'Me.Label2.Text = pIDDV.Item(0).Item(2).ToString
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "filterPayItemID()")

		End Try

	End Sub


	' Discard
	Private Sub replacePayItemIDWithDescription()

		'Try
		'    If Me.atmDV IsNot Nothing Then
		'        For Each row As DataGridViewRow In Me.DataGridView1.Rows
		'            Dim payItem As Integer = CInt(Me.DataGridView1.CurrentRow.Cells.Item(2).Value)
		'            pIDDV.RowFilter = "payItemID = '" & payItem & "'"

		'            ' This does not work because the payItemID field is an integer
		'            ' and the description is a string.  I have to figure out how
		'            ' to convert the column data type first

		'            Me.DataGridView1.CurrentRow.Cells.Item(2).Value = pIDDV.Item(0).Item(2).ToString
		'        Next
		'    End If

		'Catch ex As Exception
		'    MessageBox.Show(ex.Message, "replacePayItemIDWithDescription()")

		'End Try


	End Sub

	' Discard
	Private Sub getATMJobNumber()

		'Dim jobNum, prompt, title As String
		'prompt = "Enter Job #."
		'title = "ATM Job"
		'jobNum = InputBox(prompt, title)

		'Me.atmJN = jobNum

	End Sub









	' Not used
	Private Sub CreateUnboundImageColumn()

		' Initialize the image column.
		Dim imageColumn As New DataGridViewImageColumn

		With imageColumn
			.Width = 50
			.HeaderText = "Type"
			.Name = "signType"
			.ValuesAreIcons = True
			.Icon = Nothing
		End With

		' Add the image column to the control.
		dgvATMTOF.Columns.Insert(12, imageColumn)


		'Try

		'    For Each row As DataGridViewRow In dgvATMTOF.Rows

		'        Dim p As Integer = CInt(row.Cells.Item(2).Value)


		'        Select Case p

		'            Case 680  'IA

		'                imageColumn.Icon = My.Resources.new_extruded_1


		'            Case 692  'IB

		'                imageColumn.Icon = My.Resources.new_extruded_1



		'            Case 622  'IIA

		'                imageColumn.Icon = My.Resources.new_plywood_1

		'            Case 624  'IIB

		'                imageColumn.Icon = My.Resources.new_plywood_1

		'            Case 672  'IIB

		'                imageColumn.Icon = My.Resources.new_plywood_1




		'            Case 623  'IIIA

		'                imageColumn.Icon = My.Resources.new_flatsheet_1

		'            Case 625  'IIIB

		'                imageColumn.Icon = My.Resources.new_flatsheet_1

		'            Case 673  'IIIB

		'                imageColumn.Icon = My.Resources.new_flatsheet_1




		'            Case Else

		'                imageColumn.Icon = Nothing

		'        End Select
		'    Next
		'Catch ex As Exception
		'    'MessageBox.Show(ex.Message, "CreateUnboundImageColumn()")
		'    imageColumn.Icon = Nothing
		'End Try





	End Sub





	' For future use.  Not necessarily this form/class
	Private Function GetSelectedRowCollection() As List(Of String)

		' This function returns list (set column below) of 
		' selected rows.

		If Me.dgvATMTOF.SelectedRows.Count > 0 Then
			Dim drc As DataGridViewSelectedRowCollection = dgvATMTOF.SelectedRows
			Dim ids As New List(Of String)
			For i As Integer = 0 To drc.Count - 1
				Dim id As Integer = CInt(drc(i).Cells(0).Value)
				ids.Add(id.ToString)
			Next
			Return ids
		Else
			Return Nothing
		End If


	End Function







	'Private Sub loadEXTSupport()

	'    With Me.cmbExtMounting
	'        .DataSource = Nothing
	'        .DataSource = extSptDT
	'        .DisplayMember = "EXTpostType"
	'        .Text = "Select"

	'    End With

	'    With Me.cmbExtHardware
	'        .DataSource = Nothing
	'        .DataSource = extSptDT
	'        .DisplayMember = "EXThardware"
	'        .Text = "Select"
	'    End With

	'End Sub

	'Private Sub loadPWSupport()

	'    With Me.cmbPostType
	'        .DataSource = Nothing
	'        .DataSource = pwSptDT
	'        .DisplayMember = "PWpostType"
	'        .Text = "Select"

	'    End With

	'    With Me.cmbHardware
	'        .DataSource = Nothing
	'        .DataSource = pwSptDT
	'        .DisplayMember = "PWhardware"
	'        .Text = "Select"
	'    End With

	'End Sub

	'Private Sub loadFSSupport()

	'    With Me.cmbPostType
	'        .DataSource = Nothing
	'        .DataSource = fsSptDT
	'        .DisplayMember = "FSpostType"
	'        .Text = "Select"

	'    End With

	'    With Me.cmbHardware
	'        .DataSource = Nothing
	'        .DataSource = fsSptDT
	'        .DisplayMember = "FShardware"
	'        .Text = "Select"
	'    End With

	'End Sub

	'Private Sub loadSupport(ByVal typeID As Integer)


	'    Select Case typeID

	'        Case 680  'IA
	'            loadEXTSupport()

	'        Case 692  'IB
	'            loadEXTSupport()



	'        Case 622  'IIA
	'            loadPWSupport()

	'        Case 624  'IIB
	'            loadPWSupport()

	'        Case 672  'IIB
	'            loadPWSupport()



	'        Case 623  'IIIA
	'            loadFSSupport()

	'        Case 625  'IIIB
	'            loadFSSupport()

	'        Case 673  'IIIB
	'            loadFSSupport()


	'        Case Else


	'    End Select






	'End Sub




	'Me.extTOFDV.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", fieldName, str2)




	'Private Function LocateSignCodeIndex(ByVal sC As String) As Integer

	'Dim scIndex As Integer

	'    Try
	'        Me.scDV.Sort = "code"
	'        Me.scDV.Find(sC)
	'        scIndex = CInt(Me.scDV.Item(0).Item(1).value)

	'    Catch ex As Exception
	'        scIndex = Nothing

	'    End Try

	'    Return scIndex

	'End Function







	'  Creates havoc with the DGV indices.


	' Not used
	'Private Sub BindEXTSpt()

	'    Try

	'        'With Me.cmbExtMounting

	'        '    .DataSource = dctExtSpt
	'        '    .DisplayMember = "Value"
	'        '    .SelectedIndex = 0

	'        '    '.Items.Clear()
	'        '    .DataSource = extSptDS.Tables("EXTsupport")
	'        '    .DisplayMember = "EXTPostType"
	'        '    .Text = "Support"
	'        'End With




	'        ' cmbExtHardware is being replaced by a TextBox
	'        ' remove this code when new design is in place 
	'        ' and working properly

	'        'With Me.cmbExtHardware
	'        '    .DataSource = Nothing
	'        '    .DataSource = extSptDS.Tables("EXTsupport")
	'        '    .DisplayMember = "EXTsupport"
	'        'End With


	'    Catch ex As Exception
	'        MessageBox.Show(ex.Message, "BindEXTSpt()")
	'    End Try


	'End Sub

	' Not used
	'Private Sub BindPWandFSSheeting()


	'    'Try

	'    '    With Me.cmbSheetType
	'    '        .DataSource = Nothing
	'    '        .DataSource = allSheetDS.Tables("sheetingType")
	'    '        .DisplayMember = "sheetNum"
	'    '        .Text = "Sheeting"
	'    '    End With

	'    '    With Me.cmbSheetDesc
	'    '        .DataSource = Nothing
	'    '        .DataSource = allSheetDS.Tables("sheetingType")
	'    '        .DisplayMember = "sheetDesc"
	'    '    End With


	'    'Catch ex As Exception
	'    '    MessageBox.Show(ex.Message, "BindPWandFSSheeting()")
	'    'End Try


	'End Sub


	' Not used
	'Private Sub BindEXTSheeting()

	'    'Try
	'    '    With Me.cmbExtColor
	'    '        .DataSource = Nothing
	'    '        .DataSource = sheetDS.Tables("EXTsheeting")
	'    '        .DisplayMember = "sheetNum"
	'    '        .Text = "Sheeting"
	'    '    End With

	'    'Catch ex As Exception
	'    '    MessageBox.Show(ex.Message, "BindEXTSheeting()")
	'    'End Try


	'End Sub




	' Not Used
	'Private Sub BindHeights()

	'    'Try

	'    '    ' Populate combo box
	'    '    With Me.cmbSptSize
	'    '        .DataSource = Nothing
	'    '        .DataSource = heightsDS.Tables("heightSizes")
	'    '        '.DataSource = heightsDT
	'    '        .DisplayMember = "height"
	'    '        .Text = "Select"
	'    '    End With


	'    '    ' Populate 3x4Sizes combo box
	'    '    With Me.cmbWPAngleSize
	'    '        .DataSource = Nothing
	'    '        .DataSource = heightsDS.Tables("heightSizes")
	'    '        .DisplayMember = "height"

	'    '    End With

	'    'Catch ex As Exception
	'    '    MessageBox.Show(ex.Message, "BindHeights()")
	'    'End Try

	'End Sub



#End Region




End Class




Public Class Sign

    Private _image As Bitmap
    Private _station As String
    Private _signCode As String
    Private _signType As String
    Private _signWidth As String
    Private _signHeight As String
    Private _signSft As String


    Public Property image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
        End Set
    End Property

    Public Property Station() As String
        Get
            Return _station
        End Get
        Set(ByVal value As String)
            _station = value
        End Set
    End Property

    Public Property SignCode() As String
        Get
            Return _signCode
        End Get
        Set(ByVal value As String)
            _signCode = value
        End Set
    End Property

    Public Property SignType() As String
        Get
            Return _signType
        End Get
        Set(ByVal value As String)
            _signType = value
        End Set
    End Property

    Public Property SignWidth() As String
        Get
            Return _signWidth
        End Get
        Set(ByVal value As String)
            _signWidth = value
        End Set
    End Property

    Public Property SignHeight() As String
        Get
            Return _signHeight
        End Get
        Set(ByVal value As String)
            _signHeight = value
        End Set
    End Property

    Public Property SqFt() As String
        Get
            Return _signSft
        End Get
        Set(ByVal value As String)
            _signSft = value
        End Set
    End Property

    Public Sub New(ByVal i As Bitmap, _
                   ByVal stn As String, _
                   ByVal sC As String, _
                   ByVal sT As String, _
                   ByVal sW As String, _
                   ByVal sH As String, _
                   ByVal sF As String)
        Me._image = i
        Me._station = stn
        Me._signCode = sC
        Me._signType = sT
        Me._signWidth = sW
        Me._signHeight = sH
        Me._signSft = sF

    End Sub

End Class