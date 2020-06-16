
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports signINver2.My.Resources


Public Class frmEnterNewStation


#Region " Database Communication"



    '  (Action Traffic.mdb) connection
	'Dim ATMconn1 As New OleDbConnection(atmConnStr01)
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

    '  (db1.mdb) connection
	'Dim db1Conn As New OleDbConnection(connStr01)
	Dim db1Conn1 As New OleDbConnection(My.Settings.SignINconn)



	'Dim atmJobDA As New OleDbDataAdapter("SELECT [JOB #] As jn From [JOB LIST] As atmJL WHERE Active = True", ATMconn1)
    Dim atmJobDA As OleDbDataAdapter
    Dim atmJobDS As DataSet
    Dim atmJobDV As DataView
    Dim atmJobDT As DataTable

    Dim payItemDA As OleDbDataAdapter
    Dim payItemDS As DataSet
    Dim payItemDV As DataView
    Dim payItemDT As DataTable

    Dim pIPLDA As OleDbDataAdapter
    Dim pIPLDS As DataSet
    Dim pIPLDV As DataView
    Dim pIPLDT As DataTable

    Dim contDA As OleDbDataAdapter
    Dim contDS As DataSet
    Dim contDV As DataView
    Dim contDT As DataTable

    Dim sCDA As OleDbDataAdapter
    Dim scDS As DataSet
    Dim scDV As DataView
    Dim scDT As DataTable

#End Region


#Region " Class-level variables"

	' Guard Rail declarations
	Dim stationA_ As String
	Dim stationB_ As String

	' Use to retain newly inserted record ID
	' for Session List viewing and record retrieval/duplication
	Dim recordIdentity As Integer




#End Region


#Region " Subs & Functions"

    Private Sub populateActiveATMJobs()

        Try
			Dim atmJobCmd As OleDbCommand = New OleDbCommand _
				("SELECT [JOB #] As jn, [LOCATION] As location From [JOB LIST] As atmJL WHERE Active = True ORDER By [JOB #] DESC", ATMconn1)

            ' Open connection to Db
			ATMconn1.Open()

            '  Fill dataAdapter with query result from Db
            atmJobDA = New OleDbDataAdapter(atmJobCmd)

            ' Instantiate DataSet object
            atmJobDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            atmJobDA.Fill(atmJobDS, "atmJL")

            '  Close the connection
			ATMconn1.Close()

            ' Set the Dataview object to the Dataset object
            atmJobDV = New DataView(atmJobDS.Tables("atmJL"))


            RemoveHandler cmbATMJob.SelectedIndexChanged, AddressOf cmbATMJob_SelectedIndexChanged
            With Me.cmbATMJob
                .DataSource = atmJobDV
                .DisplayMember = "jn"
                .Text = "Select Job"
            End With
            AddHandler cmbATMJob.SelectedIndexChanged, AddressOf cmbATMJob_SelectedIndexChanged




        Catch ex As Exception
            MessageBox.Show(ex.Message, "populateActiveATMJobs()")

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
			  "WHERE [Job Pay Items].[Job #] = @atmJobNum ORDER BY [PAY ITEM PICK LIST].[CODE]", ATMconn1)

			payItemCmd.Parameters.AddWithValue("@atmJobNum", Me.cmbATMJob.Text)


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
			payItemDV = New DataView(payItemDS.Tables("[Job Pay Items]"))

			' DataTable -   Fill the DataTable object with data
			payItemDT = payItemDS.Tables(0)


			' Declare and set the alternating rows style
			Dim objAlternatingCellStyle As New DataGridViewCellStyle()
			objAlternatingCellStyle.BackColor = Color.WhiteSmoke
			Me.dgvJobPayItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

			' Declare and set the alignment property
			Dim objAlignMidcellStyle As New DataGridViewCellStyle()
			objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

			' Declare and set the alignment property
			Dim objAlignMidRightcellStyle As New DataGridViewCellStyle()
			objAlignMidRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


			' Bind DGV and set properties
			With Me.dgvJobPayItems

				.DataSource = payItemDT

				.Columns(0).Visible = False

				.Columns(1).Visible = False
				.Columns(2).Visible = False

				.Columns(3).HeaderText = "Pay Item"
				.Columns(3).DefaultCellStyle = objAlignMidRightcellStyle
				.Columns(3).DefaultCellStyle.Font = New Font(dgvJobPayItems.Font, FontStyle.Bold)
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
				'.ValueMember = "[Job Pay Items].[PayItemID]"
				.Text = "Select Pay Item"
			End With

			' Clear previous simple control bindings
			Me.lblPayItemDesc.DataBindings.Clear()
			Me.lblUnit.DataBindings.Clear()


			' Bind simple controls
			Me.lblPayItemDesc.DataBindings.Add("Text", payItemDT, "DESCRIPTION")
			Me.lblUnit.DataBindings.Add("Text", payItemDT, "UNIT")

			'  Bind Job info controls after Job has been selected
			' Clear previous bindings
			Me.lblJobLocation.DataBindings.Clear()

			' Bind simple control
			Me.lblJobLocation.DataBindings.Add("Text", atmJobDV, "location")

			'For Each row As DataGridViewRow In dgvJobPayItems.Rows
			'	row.Selected = False
			'Next

		Catch ex As Exception
			MessageBox.Show(ex.Message, "getJobPayItems()")
		End Try

	End Sub

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
							("SELECT * FROM tblSignCodes ORDER By code", db1Conn1)

            ' Open connection to Db
			db1Conn1.Open()

            '  Fill dataAdapter with query result from Db
            sCDA = New OleDbDataAdapter(sCCmd)

            ' Instantiate DataSet object
            scDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            sCDA.Fill(scDS, "tblSignCodes")

            '  Close the connection
			db1Conn1.Close()

            ' Set the Dataview object to the Dataset object
            scDV = New DataView(scDS.Tables("tblSignCodes"))

            ' DataTable -   Fill the DataTable object with data
            scDT = scDS.Tables(0)

            With Me.cmbSignCodes
                .DataSource = scDV
                .DisplayMember = "code"
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
            MessageBox.Show(ex.Message, "getSignCodes()")
        End Try




    End Sub

    Private Sub ShowHideDGV(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbHidePayItems.Click

        If Me.SplitContainer1.Panel2Collapsed Then
            Me.SplitContainer1.Panel2Collapsed = False
            Me.tsbHidePayItems.Text = "Pay Items"
        Else
            Me.SplitContainer1.Panel2Collapsed = True
            Me.tsbHidePayItems.Text = "Show Pay Items"
        End If


    End Sub

    Private Sub addToDailyProductions(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles btnNextRecord.Click, _
                        tsbNextRecord.Click


		Try

			'  Station Number
			If Me.txtSite.Text = String.Empty Then
				MessageBox.Show("You must assign a station number.", _
								"I do not compute!", _
								MessageBoxButtons.OK, _
								MessageBoxIcon.Exclamation)
				Exit Sub
			End If



			'  Pay Item
			If Not CheckPayItem() Then
				MessageBox.Show("That Pay Item does not exist for this Job.", _
							   "I do not compute!", _
							   MessageBoxButtons.OK, _
							   MessageBoxIcon.Exclamation)

				Exit Sub
			End If



			Me.Cursor = Cursors.WaitCursor


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
			insertDailyProductionsCMD.Parameters.AddWithValue("@jN", Me.cmbATMJob.Text)
			insertDailyProductionsCMD.Parameters.AddWithValue("@site", Me.txtSite.Text)

			' Add Station A and Station B here
			If Me.stationA_ IsNot Nothing Then
				insertDailyProductionsCMD.Parameters.AddWithValue("@stationA", Me.stationA_)
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@stationA", DBNull.Value)
			End If

			If Me.stationB_ IsNot Nothing Then
				insertDailyProductionsCMD.Parameters.AddWithValue("@StationB", Me.stationB_)
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@stationA", DBNull.Value)
			End If


			insertDailyProductionsCMD.Parameters.AddWithValue("@payItemID", CInt(Me.dgvJobPayItems.CurrentRow.Cells.Item(1).Value))
			'CInt(Me.dgvJobPayItems.CurrentRow.Cells.Item(1)

			'  Sign Code
			If Me.txtSignCode.Text.Trim = String.Empty Then
				If Me.cmbSignCodes.SelectedIndex = -1 Then
					If Me.txtSignWidth.Text.Trim IsNot Nothing Then
						If Me.txtSignWidth.Text.Trim IsNot Nothing Then
							insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.cmbSignCodes.Text.ToUpper)
						End If
					Else
						insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.txtSignCode.Text.ToUpper)
					End If
				Else
					insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.txtSignCode.Text.ToUpper)
				End If
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@signCode", Me.txtSignCode.Text.ToUpper)
			End If


			If Me.txtContractQty.Text = "" Then
				insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", DBNull.Value)
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", Me.txtContractQty.Text)
			End If



			If Me.txtNumberOfSupports.Text = "" Then
				insertDailyProductionsCMD.Parameters.AddWithValue("@numOfSupports", DBNull.Value)
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@numOfSupports", Me.txtNumberOfSupports.Text)
			End If


			insertDailyProductionsCMD.Parameters.AddWithValue("@supportAtThisStation", ckbSupportAtThisStation.Checked)



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



			If Me.txtStationWithSupport.Text = "" Then
				insertDailyProductionsCMD.Parameters.AddWithValue("@stationWithSupport", DBNull.Value)
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@stationWithSupport", Me.txtStationWithSupport.Text)
			End If


			If Me.txtPlanIssueNotes.Text = "" Then
				insertDailyProductionsCMD.Parameters.AddWithValue("@planIssueNotes", DBNull.Value)
			Else
				insertDailyProductionsCMD.Parameters.AddWithValue("@planIssueNotes", Me.txtPlanIssueNotes.Text)
			End If

			insertDailyProductionsCMD.Parameters.AddWithValue("@contractorID", CInt(Me.lblContractorID.Text))

			' Execute the OleDbCommand object to insert the new data
			' Validate PayItem
			If Me.cmbPayItem.SelectedIndex = -1 Then
				MessageBox.Show("Selected Pay Item Is Not Valid.", "I do not compute!")

			Else
				insertDailyProductionsCMD.ExecuteNonQuery()

				' Gets the ID for the newly inserted record
				' And assigns it to the local variable 
				' Create OleDbCommand for SELECT @@IDENTITY statement
				insertDailyProductionsCMD.CommandText = "SELECT @@IDENTITY"
				recordIdentity = CInt(insertDailyProductionsCMD.ExecuteScalar())


				' Call AddToSessionList Method Here
				AddToSessionList(recordIdentity.ToString, Me.txtSite.Text, Me.lblPayItemDesc.Text, Me.txtSignCode.Text.ToUpper, Me.txtContractQty.Text)


				ToolStripStatusLabel1.Text = Me.txtSite.Text & " (" & Me.lblPayItemDesc.Text & ") Added successfully"

				clearFields()

			End If


		Catch ex As Exception
			MessageBox.Show(ex.Message, "addToDailyProductions()")
			ToolStripStatusLabel1.Text = "Record not added!"

		End Try



		' Close the connection
		ATMconn1.Close()

		Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub autoSignRemoval()

        Me.Cursor = Cursors.WaitCursor

        If Me.txtSite.Text = String.Empty Then
            MessageBox.Show("You must assign a station number.", _
                            "I do not compute!", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If




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
        insertDailyProductionsCMD.Parameters.AddWithValue("@jN", Me.cmbATMJob.Text)
        insertDailyProductionsCMD.Parameters.AddWithValue("@site", Me.txtSite.Text)


        Dim p As Integer = CInt(Me.dgvJobPayItems.CurrentRow.Cells.Item(1).Value)
        Dim pI As Integer = SelectRemovalType(p)
        insertDailyProductionsCMD.Parameters.AddWithValue("@payItemID", pI)


        insertDailyProductionsCMD.Parameters.AddWithValue("@contractQty", Me.nudAutoRemQty.Value.ToString)

        insertDailyProductionsCMD.Parameters.AddWithValue("@contractorID", CInt(Me.lblContractorID.Text))


        ' Execute the OleDbCommand object to insert the new data
        Try
			insertDailyProductionsCMD.ExecuteNonQuery()
			' Gets the ID for the newly inserted record
			' And assigns it to the local variable 
			' Create OleDbCommand for SELECT @@IDENTITY statement
			insertDailyProductionsCMD.CommandText = "SELECT @@IDENTITY"
			recordIdentity = CInt(insertDailyProductionsCMD.ExecuteScalar())

			ToolStripStatusLabel1.Text = Me.txtSite.Text & " (Sign Removal) Added successfully"
            
        Catch OleDbExceptionErr As OleDbException

            MessageBox.Show(OleDbExceptionErr.Message, "autoSignRemoval()")
            ToolStripStatusLabel1.Text = "Record not added!"

        End Try

        ' Close the connection
		ATMconn1.Close()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub clearFields()

		' Do not clear fields if repeating
		If Me.ckbRepeat.Checked Then Exit Sub

		Me.Cursor = Cursors.WaitCursor

        Me.txtSite.Clear()
        Me.txtSignWidth.Clear()
        Me.txtSignHeight.Clear()

        Me.txtContractQty.Clear()
        Me.txtNumberOfSupports.Clear()
        Me.ckbSupportAtThisStation.Checked = False
        Me.txtStationWithSupport.Clear()
        Me.txtPlanIssueNotes.Clear()
        Me.txtSite.Select()
		Me.lblGuardRailStations.Text = String.Empty

        Me.cmbSignCodes.Text = "Select"
        Me.txtSignCode.Clear()

        Me.lblPdfTitle.Visible = False
        Me.lblSignCodeDesc.Visible = False
        Me.lblType.Visible = False

        Me.nudAutoRemQty.Value = 1
        
        For Each row As DataGridViewRow In dgvJobPayItems.Rows
            row.Selected = False
        Next

        Me.Cursor = Cursors.Arrow

	End Sub


	Public Sub AddToSessionList(ByVal ID As String, ByVal site As String, ByVal description As String, ByVal sc As String, ByVal cqty As String)

		Try

			' Insert row
			With Me.dgvSessionAdded
				.Rows.Insert(0, ID, site, description, sc, cqty)
			End With

			' De-Select the row
			For Each row As DataGridViewRow In dgvSessionAdded.Rows
				row.Selected = False
			Next


		Catch ex As Exception
			MessageBox.Show(ex.Message, "AddToSessionList()")

		End Try



	End Sub

	Private Sub FormatSessionListDGV()

		With Me.dgvSessionAdded

			.Columns.Add("ID", "ID")
			.Columns.Add("Site", "Site")
			.Columns.Add("Description", "Desc")
			.Columns.Add("SignCode", "Sign Code")
			.Columns.Add("Qty", "C-Qty")

		End With

	End Sub



    Private Sub showNewPI_Sub_Form(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles btnNextPayItem.Click, _
                        tsbNextPayItem.Click


        Try

       

            If Me.txtSite.Text.Trim = String.Empty Then
                MessageBox.Show("You must assign a station number.", _
                                "I do not compute!", _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Exclamation)
            Else

                Me.Cursor = Cursors.WaitCursor

                Dim parentID As Integer = CInt(Me.dgvJobPayItems.CurrentRow.Cells.Item(1).Value)
				Dim newSiteSubForm As New frmSub_EnterNewStation(Me.cmbATMJob.Text.ToString, _ 
																 Me.txtSite.Text.ToString, parentID, _ 
																 Me.cmbContractor.SelectedIndex, _ 
																 Me.stationA_, _ 
																 Me.stationB_)

				newSiteSubForm.MdiParent = signINver2.signINMain1
                newSiteSubForm.Show()

                Me.Cursor = Cursors.Arrow

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "showNewPI_Sub_Form()")

        End Try

        

    End Sub

    Private Sub showDailyProductions(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles tsbDailyProductions.Click
        Try

            Dim dailyProductions As New frmDailyProductions(Me.cmbATMJob.Text.ToString)
            dailyProductions.MdiParent = signINver2.signINMain1
            dailyProductions.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "showDailyProductions()")

        End Try

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

        Try

            Dim table As DataTable = DirectCast(dgvJobPayItems.DataSource, DataTable)

            For Each row As DataRow In table.Rows

                Dim x As String = row.Item(3).ToString
                Dim y As String = Me.cmbPayItem.Text

                If validatePI(x, y) Then
                    payItemExists = True
                End If

            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, "CheckPayItem()")

        End Try

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

		' Extruded - Type I:  680, 692, 452, 669, 751, 790, 1886, 1904, 1906, 1907, 1908, 1909
		' Plywood - Type II:  622, 624, 626, 672, 608, 670, 752, 813, 1887, 1910, 1912, 1913, 1914, 1915
		' FlatSheet - Type III:  623, 625, 627, 673, 453, 671, 753, 812, 814, 1515, 1888, 1916, 1918, 1919, 1920, 1921


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


		End Select

		Return removalPI


	End Function

    Private Sub HandleEnterAsTab(ByVal sender As Object, _
                                 ByVal e As System.Windows.Forms.KeyEventArgs) _
                                 Handles cmbATMJob.KeyDown, _
                                 txtSite.KeyDown, _
                                 cmbPayItem.KeyDown, _
                                 cmbContractor.KeyDown, _
                                 cmbSignCodes.KeyDown, _
                                 txtSignCode.KeyDown, _
                                 txtSignWidth.KeyDown, _
                                 txtSignHeight.KeyDown, _
                                 txtContractQty.KeyDown, _
                                 txtNumberOfSupports.KeyDown, _
                                 ckbSupportAtThisStation.KeyDown, _
                                 txtStationWithSupport.KeyDown


        If e.KeyCode = Keys.Enter Then
            Dim CurrentControl As Control = CType(sender, Control)
            Me.SelectNextControl(CurrentControl, True, True, True, True)
            e.SuppressKeyPress = True
            'e.Handled = True

        End If
	End Sub

	Private Sub EnterGuardRailStations()

		Try
			
			Dim gr As New frmGuardRailStations()
			If gr.ShowDialog = Windows.Forms.DialogResult.OK Then
				Me.stationA_ = gr.StationA
				Me.stationB_ = gr.StationB
				'MessageBox.Show(Me.stationA_ & ", " & Me.stationB_)
				Me.lblGuardRailStations.Text = Me.stationA_ & ", " & Me.stationB_
			End If

			' Dispose of the Dialog.  Forms using the ShowDialog Method do not automatically Dispose of their 
			' object.
			gr.Dispose()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "EnterGuardRailStations()()", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand)
		Finally

		End Try



	End Sub

    


#End Region


#Region " Event Handlers"

	Private Sub frmEnterNewStation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown


		'________________________________________()
		' EXAMPLE:  Combo Characters (eg. ctrl+B)

		'ElseIf ((e.KeyCode = Keys.B) AndAlso (e.Modifiers = (Keys.Control))) Then
		'	Add Functionality
		'	e.SuppressKeyPress = True



		'__________________________________()
		' EXAMPLE:  Function Key Characters

		'ElseIf (e.KeyCode = Keys.F5) Then
		'	Add Functionality





		If ((e.KeyCode = Keys.G) AndAlso (e.Modifiers = (Keys.Control))) Then
			'  ctrl+G 
			'  GuardRail Stations Sub Form
			Me.btnGR_Click(Nothing, Nothing)
			e.SuppressKeyPress = True


		ElseIf (e.KeyCode = Keys.F2) Then
			'  F2 Key
			'  Input Focus to Contract Qty TextBox
			Me.txtContractQty.Select()


		ElseIf ((e.KeyCode = Keys.N) AndAlso (e.Modifiers = (Keys.Control))) Then
			'  ctrl+N
			'  Next Pay Item Sub Form
			Me.showNewPI_Sub_Form(Nothing, Nothing)
			e.SuppressKeyPress = True


		ElseIf ((e.KeyCode = Keys.U) AndAlso (e.Modifiers = (Keys.Control))) Then
			'  ctrl+U
			'  Call Method to insert into DB
			Me.addToDailyProductions(Nothing, Nothing)
			e.SuppressKeyPress = True

		End If


	End Sub



	Private Sub frmEnterDailyProductions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Me.Cursor = Cursors.WaitCursor

		populateActiveATMJobs()
		getContractors()
		getSignCodes()
		Me.txtSignCode.Clear()
		Me.lblPdfTitle.Visible = False
		Me.lblSignCodeDesc.Visible = False
		Me.lblType.Visible = False
		Me.picSignImage.Visible = False

		' Create Session List DGV Columns
		FormatSessionListDGV()




		Me.cmbATMJob.Select()

		Me.Cursor = Cursors.Arrow


	End Sub

	Private Sub cmbATMJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbATMJob.SelectedIndexChanged

		Me.Cursor = Cursors.WaitCursor

		getJobPayItems()



		Me.Cursor = Cursors.Arrow

	End Sub

	Private Sub lblJobLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblJobLocation.TextChanged

		' Change title bar text after DataGridView has been DataBound
		Me.Text = "ATM - Enter New Station  " & Me.cmbATMJob.Text & " (" & Me.lblJobLocation.Text & ")"


	End Sub

	Private Sub cmbSignCodes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSignCodes.SelectedIndexChanged

		Me.Cursor = Cursors.WaitCursor

		Me.txtSignCode.Text = Me.cmbSignCodes.Text

		If Me.cmbSignCodes.Text <> "Select" Then
			Me.lblPdfTitle.Visible = True
			Me.lblSignCodeDesc.Visible = True
			Me.lblType.Visible = True
			Me.picSignImage.Visible = True
		End If

		Me.Cursor = Cursors.Arrow

	End Sub

	Private Sub txtSignCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSignCode.TextChanged
		showSignImage()

		Me.lblSignCodeDesc.Visible = True
		Me.lblType.Visible = True

	End Sub

	Private Sub ToolStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ToolStrip1.Paint

		' Make ToolStrip corners square as opposed to round
		If TypeOf ToolStrip1.Renderer Is ToolStripProfessionalRenderer Then
			CType(ToolStrip1.Renderer, ToolStripProfessionalRenderer).RoundedEdges = False
		End If
	End Sub

	Private Sub picSignImage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picSignImage.DoubleClick

		Me.Cursor = Cursors.WaitCursor

		Try

			If Me.lblPdfTitle.Text <> String.Empty Then

				Dim specSheet As New frmViewPDF(Me.lblPdfTitle.Text, Me.txtSignCode.Text, Me.lblSignCodeDesc.Text)
				specSheet.MdiParent = signINver2.signINMain1
				specSheet.Show()

			End If

		Catch ex As Exception

		End Try

		Me.Cursor = Cursors.Arrow

	End Sub

	Private Sub btnAddRemoval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRemoval.Click

		Me.Cursor = Cursors.WaitCursor
		Try

			Dim x As Integer = CInt(Me.dgvJobPayItems.CurrentRow.Cells.Item(1).Value)
			Dim y As Integer = SelectRemovalType(x)

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

		Catch ex As Exception
			MessageBox.Show(ex.Message, "btnAddRemoval_Click()")

		End Try

		Me.Cursor = Cursors.Arrow

	End Sub

	Private Sub btnGR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGR.Click

		EnterGuardRailStations()


	End Sub


	Private Sub dgvSessionAdded_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSessionAdded.DoubleClick



		MessageBox.Show("Future Multi-Entry Form", "Beta Testing")



	End Sub





#End Region














End Class