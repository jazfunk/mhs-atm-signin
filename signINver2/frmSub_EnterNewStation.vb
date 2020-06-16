
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports signINver2.My.Resources
Imports System.Speech.Synthesis
Imports System.Collections.ObjectModel




Public Class frmSub_EnterNewStation

    Public Sub New(ByVal jobNumber As String, _ 
    			   ByVal station As String, _ 
    			   ByVal pID As Integer, _ 
    			   ByVal contractorID As Integer, _ 
    			   ByVal stA as string, _ 
    			   ByVal stB as string)		

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.atmJob = jobNumber
		Me.siteStation = station
		Me.parentPID = pID
		Me.cID = contractorID
		Me.stationA = stA
		Me.stationB = stB

	End Sub


#Region " Database Communication"

    '  (Action Traffic.mdb) connection
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

    '  (db1.mdb) connection
	Dim db1Conn As New OleDbConnection(My.Settings.SignINconn)

    Dim payItemDA As OleDbDataAdapter
    Dim payItemDS As DataSet
    Dim payItemDV As DataView
    Dim payItemDT As DataTable

    Dim contDA As OleDbDataAdapter
    Dim contDS As DataSet
    Dim contDV As DataView
    Dim contDT As DataTable

    Dim sCDA As OleDbDataAdapter
    Dim scDS As DataSet
    Dim scDV As DataView
    Dim scDT As DataTable

    Dim pIDDA As OleDbDataAdapter
    Dim pIDDS As DataSet
    Dim piDDV As DataView
    Dim piDDT As DataTable

#End Region



#Region " Class level variables"

    Dim atmJob As String
    Dim siteStation As String
    Dim parentPID As Integer
	Dim cID As Integer
	Dim stationA As String
	Dim stationB As String


#End Region


#Region " Subs/Methods & Functions"

    Private Sub getContractors()

        Try

			Dim contCmd As OleDbCommand = New OleDbCommand _
							("SELECT [Contractor ID] as cID, Contractor FROM Contractors ORDER By Contractor", ATMconn1)

            ' Open connection to Db
			ATMconn1.Open()

            '  Fill dataAdapter with query result from Db
            contDA = New OleDbDataAdapter(contCmd)

            ' Instantiate DataSet object
            contDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            contDA.Fill(contDS, "payItemList")

            '  Close the connection
			ATMconn1.Close()

            ' Set the Dataview object to the Dataset object
            contDV = New DataView(contDS.Tables("payItemList"))

            ' DataTable -   Fill the DataTable object with data
            contDT = contDS.Tables(0)

            With Me.cmbContractor
                .DataSource = contDV
                .DisplayMember = "Contractor"
            End With

            ' Clear previous bindings
            Me.lblContractorID.DataBindings.Clear()

            ' Bind simple control
            Me.lblContractorID.DataBindings.Add("Text", contDV, "cID")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "getContractors()")
        End Try

    End Sub

    Private Sub getSignCodes()

        Try

            Dim sCCmd As OleDbCommand = New OleDbCommand _
                            ("SELECT code FROM tblSignCodes ORDER By code", db1Conn)

            ' Open connection to Db
            db1Conn.Open()

            '  Fill dataAdapter with query result from Db
            sCDA = New OleDbDataAdapter(sCCmd)

            ' Instantiate DataSet object
            scDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            sCDA.Fill(scDS, "tblSignCodes")

            '  Close the connection
            db1Conn.Close()

            ' Set the Dataview object to the Dataset object
            scDV = New DataView(scDS.Tables("tblSignCodes"))

            ' DataTable -   Fill the DataTable object with data
            scDT = scDS.Tables(0)

            With Me.cmbSignCodes
                .DataSource = scDV
                .DisplayMember = "code"
                .Text = "Select"
            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, "getSignCodes()")
        End Try




    End Sub

    Private Sub getJobPayItems()

        Try

			'("SELECT * FROM [PAY ITEM PICK LIST]", ATMconn1)

			Dim payItemCmd As OleDbCommand = New OleDbCommand _
						 ("SELECT [Job Pay Items].[Job #], [Job Pay Items].[PayItemID], " & _
						 "[PAY ITEM PICK LIST].[PayItemID], [PAY ITEM PICK LIST].[CODE], " & _
						 "[PAY ITEM PICK LIST].[DESCRIPTION], [PAY ITEM PICK LIST].[UNIT] " & _
						 "FROM [Job Pay Items] " & _
						 "LEFT OUTER JOIN [PAY ITEM PICK LIST] " & _
						 "ON [Job Pay Items].[PayItemID] = [PAY ITEM PICK LIST].[PayItemID]" & _
						 "WHERE [Job Pay Items].[Job #] = '" & Me.atmJob & "'", ATMconn1)

            ' Open connection to Db
			ATMconn1.Open()

            '  Fill dataAdapter with query result from Db
            payItemDA = New OleDbDataAdapter(payItemCmd)

            ' Instantiate DataSet object
            payItemDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            payItemDA.Fill(payItemDS, "[Job Pay Items]")

            '  Close the connection
			ATMconn1.Close()

            ' Set the Dataview object to the Dataset object
            payItemDV = New DataView(payItemDS.Tables("[Job Pay Items"))

            ' DataTable -   Fill the DataTable object with data
            payItemDT = payItemDS.Tables(0)




            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke
            Me.dgvPID.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

            ' Declare and set the alignment property
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Declare and set the alignment property
            Dim objAlignMidRightcellStyle As New DataGridViewCellStyle()
            objAlignMidRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            ' Bind DGV and set properties
            With Me.dgvPID

                .DataSource = payItemDT

                .Columns(0).Visible = False

                .Columns(1).Visible = False
                .Columns(2).Visible = False

                .Columns(3).HeaderText = "Pay Item"
                .Columns(3).DefaultCellStyle = objAlignMidRightcellStyle
                .Columns(3).DefaultCellStyle.Font = New Font(dgvPID.Font, FontStyle.Bold)
                .Columns(3).Width = 60

                .Columns(4).HeaderText = "DESCRIPTION"
                .Columns(4).Width = 210

                .Columns(5).HeaderText = "UNIT"
                .Columns(5).DefaultCellStyle = objAlignMidcellStyle
                .Columns(5).Width = 50

            End With



            ' Bind pay item combo box and set properties
            With Me.cmbPayItem
                .DataSource = payItemDT
                .DisplayMember = "CODE"
            End With

            ' Clear previous simple control bindings
            Me.lblPayItemDesc.DataBindings.Clear()
            Me.lblUnit.DataBindings.Clear()


            ' Bind simple controls
            Me.lblPayItemDesc.DataBindings.Add("Text", payItemDT, "DESCRIPTION")
            Me.lblUnit.DataBindings.Add("Text", payItemDT, "UNIT")

            Me.Text = "Additional Pay Items for site - " & Me.siteStation

        Catch ex As Exception
            MessageBox.Show(ex.Message, "getPayItems()")
        End Try


    End Sub

    Private Sub addToDailyProductions(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextRecord.Click



        '  Pay Item
        If Not CheckPayItem() Then
            MessageBox.Show("That Pay Item does not exist for this Job.", _
                           "I do not compute!", _
                           MessageBoxButtons.OK, _
                           MessageBoxIcon.Exclamation)

            Exit Sub
        End If

        Dim insertDailyProductionsCMD As OleDbCommand = New OleDbCommand

        ' Open the connection, execute the command
		ATMconn1.Open()

        ' Set the OleDbCommand object properties
		insertDailyProductionsCMD.Connection = ATMconn1
		insertDailyProductionsCMD.CommandText = _
			"INSERT INTO [Daily Productions] " & _
			"([JOB #], [Site], [Station A], [Station B], [PayItemID], [Sign Code], " & _
			"[Contract Qty], [Number of Supports], [Support at this station], " & _
			"[Sign Width], [Sign Height], [Station with Support], [Plan Issue Notes], " & _
			"[Contractor ID]) " & _
			"VALUES(@jN,@site,@stationA, @stationB, @payItemID,@signCode," & _
			"@contractQty,@numOfSupports,@supportAtThisStation," & _
			"@signWidth,@signHeight,@stationWithSupport,@planIssueNotes,@contractorID)"


        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property
        insertDailyProductionsCMD.Parameters.AddWithValue("@jN", Me.lblJob.Text)
		insertDailyProductionsCMD.Parameters.AddWithValue("@site", Me.lblSite.Text)


		' Add Station A and Station B here
		If Me.stationA IsNot Nothing Then
			insertDailyProductionsCMD.Parameters.AddWithValue("@stationA", Me.stationA)
		Else
			insertDailyProductionsCMD.Parameters.AddWithValue("@statoinA", DBNull.Value)
		End If

		If Me.stationB IsNot Nothing Then
			insertDailyProductionsCMD.Parameters.AddWithValue("@StationB", Me.stationB)
		Else
			insertDailyProductionsCMD.Parameters.AddWithValue("@statoinA", DBNull.Value)
		End If


        insertDailyProductionsCMD.Parameters.AddWithValue("@payItemID", CInt(Me.dgvPID.CurrentRow.Cells.Item(1).Value))

        '  Sign Code
        If Me.txtSignCode.Text.Trim = String.Empty Then
            If Me.cmbSignCodes.SelectedIndex = -1 Then
                If Me.txtSignWidth.Text.Trim IsNot Nothing Then
                    If Me.txtSignWidth.Text.Trim IsNot Nothing Then
                        insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.cmbSignCodes.Text)
                    End If
                Else
                    insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.txtSignCode.Text)
                End If
            Else
                insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.txtSignCode.Text)
            End If
        Else
            insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.txtSignCode.Text)
        End If


        If Me.txtContractQty.Text = "" Then
            insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", DBNull.Value)
        Else
            insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", Me.txtContractQty.Text)
        End If

        insertDailyProductionsCMD.Parameters.AddWithValue("@numOfSupports", DBNull.Value)

        insertDailyProductionsCMD.Parameters.AddWithValue("@supportAtThisStation", False)


        If Me.txtSignWidth.Text = "" Then
            insertDailyProductionsCMD.Parameters.AddWithValue("@signWidth", DBNull.Value)
        Else
            insertDailyProductionsCMD.Parameters.AddWithValue("@signWidth", Me.txtSignWidth.Text)
        End If


        If Me.txtSignHeight.Text = "" Then
            insertDailyProductionsCMD.Parameters.AddWithValue("@signHeight", DBNull.Value)
        Else
            insertDailyProductionsCMD.Parameters.AddWithValue("@signHeight", Me.txtSignHeight.Text)
        End If



        insertDailyProductionsCMD.Parameters.AddWithValue("@stationWithSupport", DBNull.Value)

        insertDailyProductionsCMD.Parameters.AddWithValue("@planIssueNotes", DBNull.Value)

        insertDailyProductionsCMD.Parameters.AddWithValue("@contractorID", CInt(Me.lblContractorID.Text))


        ' Execute the OleDbCommand object to insert the new data
        Try

            ' Validate PayItem
            If Me.cmbPayItem.SelectedIndex = -1 Then
                MessageBox.Show("Selected Pay Item Is Not Valid.", "I do not compute!")

            Else
                insertDailyProductionsCMD.ExecuteNonQuery()
                ToolStripStatusLabel1.Text = Me.lblSite.Text & " (" & Me.lblPayItemDesc.Text & ") Added successfully"
                clearFields()

                Me.cmbPayItem.Select()

            End If



        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "addToDailyProductions()")
            ToolStripStatusLabel1.Text = "Record not added!"


        End Try


		ATMconn1.Close()



    End Sub

    Private Sub autoSignRemoval()


        If Not CheckPayItem() Then
            MessageBox.Show("That Pay Item does not exist for this Job.", _
                           "I do not compute!", _
                           MessageBoxButtons.OK, _
                           MessageBoxIcon.Exclamation)

            Exit Sub
        End If




        Dim insertDailyProductionsCMD As OleDbCommand = New OleDbCommand

        ' Open the connection, execute the command
		ATMconn1.Open()

        ' Set the OleDbCommand object properties
		insertDailyProductionsCMD.Connection = ATMconn1
        insertDailyProductionsCMD.CommandText = _
            "INSERT INTO [Daily Productions] " & _
            "([JOB #], [Site], [PayItemID], [Contract Qty], [Contractor ID]) " & _
            "VALUES(@jN,@site,@payItemID,@contractQty,@contractorID)"


        ' Add parameters for the placeholders in the SQL in the
        ' CommandText property
        insertDailyProductionsCMD.Parameters.AddWithValue("@jN", Me.lblJob.Text)
        insertDailyProductionsCMD.Parameters.AddWithValue("@site", Me.lblSite.Text)


        'Dim p As Integer = CInt(Me.dgvPID.CurrentRow.Cells.Item(1).Value)
        Dim pI As Integer = SelectRemovalType(Me.parentPID)
        insertDailyProductionsCMD.Parameters.AddWithValue("@payItemID", pI)


        If Me.txtRemovalQty.Text = String.Empty Then
            Dim q As String = "1"
            insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", q)
        Else
            insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", Me.txtRemovalQty.Text)
        End If


        insertDailyProductionsCMD.Parameters.AddWithValue("@contractorID", CInt(Me.lblContractorID.Text))


        ' Execute the OleDbCommand object to insert the new data
        Try
            insertDailyProductionsCMD.ExecuteNonQuery()
            ToolStripStatusLabel1.Text = Me.lblSite.Text & " (Sign Removal) Added successfully"
            Me.txtRemovalQty.Text = CStr(1)


        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "autoSignRemoval()")
            ToolStripStatusLabel1.Text = "Record not added!"

        End Try

        ' Close the connection
		ATMconn1.Close()






    End Sub

    Private Sub clearFields()

        Me.cmbSignCodes.Text = "Select"
        Me.txtSignCode.Clear()
        Me.txtSignWidth.Clear()
        Me.txtSignHeight.Clear()
		Me.txtContractQty.Clear()

		Me.lblGuardRailStations.Text = String.Empty




    End Sub

    Private Sub showSignImage()

        Dim imageName As String = Me.txtSignCode.Text.ToString
        Dim viewImage As String = imageName & ".jpg"

        Try
            Me.picSignImage.Load(My.Resources.imgPath & viewImage)
        Catch ex As Exception
            Me.picSignImage.Image = My.Resources.none1
        End Try

    End Sub

    Private Function CheckPayItem() As Boolean

        Dim payItemExists As Boolean

        Dim table As DataTable = DirectCast(dgvPID.DataSource, DataTable)

        For Each row As DataRow In table.Rows

            Dim x As String = row.Item(3).ToString
            Dim y As String = Me.cmbPayItem.Text

            If validatePI(x, y) Then
                payItemExists = True
            End If

        Next

        Return payItemExists


    End Function

    Shared Function validatePI(ByVal pi As String, ByVal enteredPI As String) As Boolean

        ' Compares entered payItem and each Pay Item in dgvJobPayItems
        If String.Compare(pi, enteredPI) = 0 Then
            ' Strings match
            Return True
        Else
            ' Strings do not match.
            Return False
        End If

    End Function

    Private Function SelectRemovalType(ByVal signType As Integer) As Integer

        Dim removalPI As Integer = Nothing

        Select Case signType

			Case 680, 692, 452, 669, 751, 790  ' Type I

				' Type I Removal
				removalPI = 674

			Case 1906, 1907, 1908, 1909, 1904, 1886

				' Type I Removal - NEW Feb. 2012
				removalPI = 1905


			Case 622, 624, 626, 672, 608, 670, 752, 813	 'Type II

				' Type II Removal
				removalPI = 628

			Case 1912, 1913, 1914, 1915, 1910, 1887

				' Type II Removal - NEW Feb. 2012
				removalPI = 1911

			Case 623, 625, 627, 673, 453, 671, 753, 812, 814, 1515	'Type III

				' Type III Removal
				removalPI = 776

			Case 1918, 1919, 1920, 1921, 1916, 1888

				' Type III Removal - NEW Feb. 2012
				removalPI = 1917


			Case Else

				' Trigger error and cancel auto removal entry
				removalPI = 0



				'Case 680  'IA

				'    ' Type I Removal
				'    removalPI = 674



				'Case 692  'IB

				'    ' Type I Removal
				'    removalPI = 674




				'Case 622  'IIA

				'    ' Type II Removal
				'    removalPI = 628


				'Case 624  'IIB

				'    ' Type II Removal
				'    removalPI = 628


				'Case 672  'IIB

				'    ' Type II Removal
				'    removalPI = 628





				'Case 623  'IIIA

				'    ' Type III Removal
				'    removalPI = 776


				'Case 625  'IIIB

				'    ' Type III Removal
				'    removalPI = 776


				'Case 673  'IIIB

				'    ' Type III Removal
				'    removalPI = 776


				'Case Else

				'    removalPI = 0


		End Select

        Return removalPI


    End Function

    Private Sub HandleEnterAsTab(ByVal sender As Object, _
                                 ByVal e As System.Windows.Forms.KeyEventArgs) _
                                 Handles cmbPayItem.KeyDown, _
                                 cmbSignCodes.KeyDown, _
                                 txtSignCode.KeyDown, _
                                 txtSignWidth.KeyDown, _
                                 txtSignHeight.KeyDown, _
                                 txtContractQty.KeyDown, _
                                 txtRemovalQty.KeyDown


        If e.KeyCode = Keys.Enter Then
            Dim CurrentControl As Control = CType(sender, Control)
            Me.SelectNextControl(CurrentControl, True, True, True, True)
            e.SuppressKeyPress = True
            'e.Handled = True

        End If
    End Sub


#End Region


#Region " Event Handlers"

    Private Sub frmSub_EnterNewStation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        getContractors()
        getJobPayItems()
        getSignCodes()

        Me.txtSignCode.Clear()

        Me.lblJob.Text = Me.atmJob
        Me.lblSite.Text = Me.siteStation
		Me.cmbContractor.SelectedIndex = Me.cID

		If Me.stationA IsNot String.Empty AndAlso Me.stationA IsNot Nothing Then
			Me.lblGuardRailStations.Text = Me.stationA & ", " & Me.stationB
		End If



    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Me.Close()

    End Sub

    Private Sub cmbSignCodes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSignCodes.SelectedIndexChanged
        Me.txtSignCode.Text = Me.cmbSignCodes.Text

    End Sub

    Private Sub txtSignCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSignCode.TextChanged
        showSignImage()

    End Sub

    Private Sub btnAddRemoval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRemoval.Click


        'Dim x As Integer = CInt(Me.dgvPID.CurrentRow.Cells.Item(1).Value)
        Dim y As Integer = SelectRemovalType(Me.parentPID)

        Select Case y

            Case 0
                Me.ToolStripStatusLabel1.Text = "Removal not added.  Selected Pay Item is not a Sign Type."
                MessageBox.Show("Selected Pay Item is not a Sign Type.", "Removal not added.")
                Me.cmbPayItem.Select()

            Case Else

                ' Add Removal 
                autoSignRemoval()
                Me.btnNextRecord.Select()

        End Select


    End Sub

#End Region










End Class