Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports signINver2.My.Resources



Public Class frmEnterDailyProduction



#Region " Database Communication"

    '  (Action Traffic.mdb) connection
	'Dim ATMconn1 As New OleDbConnection(atmConnStr01)
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

    '  (db1.mdb) connection
	'Dim db1Conn1 As New OleDbConnection(connStr01)
	Dim db1Conn1 As New OleDbConnection(My.Settings.SignINconn)



	'Dim atmJobDA As New OleDbDataAdapter("SELECT [JOB #] As jn From [JOB LIST] As atmJL WHERE Active = True", ATMconn1)
    Dim atmJobDA As OleDbDataAdapter
    Dim atmJobDS As DataSet
    Dim atmJobDV As DataView
    Dim atmJobDT As DataTable

    'Dim productionCB As OleDbCommandBuilder
    Dim productionBS As BindingSource
    Dim productionDA As OleDbDataAdapter
    Dim productionDS As DataSet
    Dim productionDV As DataView
    Dim productionDT As DataTable


    Dim payItemDA As OleDbDataAdapter
    Dim payItemDS As DataSet
    Dim payItemDV As DataView
    Dim payItemDT As DataTable

    Dim foremanDA As OleDbDataAdapter
    Dim foremanDS As DataSet
    Dim foremanDT As DataTable

    'Dim recordsBS As BindingSource
    'Dim recordsDS As DataSet
    Dim recordsDT As DataTable


#End Region

#Region " Class-Level Declarations"

    Dim recCount As Integer  ' Updated record counting variable

    Private updatedList() As String


    ' Dictionary(Of TKey, TValue)
    Private dctUpdatedList As New Dictionary(Of Double, String)



#End Region

#Region " Subs & Methods"


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

            RemoveHandler cmbAtmJob.SelectedIndexChanged, AddressOf cmbATMJob_SelectedIndexChanged
            With Me.cmbAtmJob
                .DataSource = atmJobDV
                .DisplayMember = "jn"
                .Text = "Job#"
            End With
            AddHandler cmbAtmJob.SelectedIndexChanged, AddressOf cmbAtmJob_SelectedIndexChanged

            Me.SelectNextControl(Me.cmbAtmJob, True, True, True, True)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "populateActiveATMJobs()")

        End Try

    End Sub

    Private Sub BindJobFields()
        Me.lblJobDesc.DataBindings.Clear()
        Me.lblJobDesc.DataBindings.Add("Text", atmJobDV, "location")

    End Sub

    Private Sub GetJobPayItems()

        Try

			'("SELECT * FROM [PAY ITEM PICK LIST]", ATMconn1)

			Dim payItemCmd As OleDbCommand = New OleDbCommand _
						 ("SELECT [Job Pay Items].[Job #], [Job Pay Items].[PayItemID] as jPid, " & _
						 "[PAY ITEM PICK LIST].[PayItemID], [PAY ITEM PICK LIST].[CODE], " & _
						 "[PAY ITEM PICK LIST].[DESCRIPTION], [PAY ITEM PICK LIST].[UNIT] " & _
						 "FROM [Job Pay Items] " & _
						 "LEFT OUTER JOIN [PAY ITEM PICK LIST] " & _
						 "ON [Job Pay Items].[PayItemID] = [PAY ITEM PICK LIST].[PayItemID]" & _
						 "WHERE [Job Pay Items].[Job #] = @atmJobNum", ATMconn1)

            payItemCmd.Parameters.AddWithValue("@atmJobNum", Me.cmbAtmJob.Text)


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

            ' Bind pay item combo box and set properties
            With Me.cmbPayItem
                .DataSource = payItemDT
                .ValueMember = "jPid"
                .DisplayMember = "CODE"
            End With

            Me.Label1.DataBindings.Clear()
            Me.lblPayItemDesc.DataBindings.Clear()

            Me.Label1.DataBindings.Add("Text", payItemDT, "jPid")
            Me.lblPayItemDesc.DataBindings.Add("Text", payItemDT, "DESCRIPTION")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "getJobPayItems()")
        End Try

    End Sub

    Private Sub PopulateProduction()

        Try
			Dim cmdProduction As OleDbCommand = New OleDbCommand _
			 ("SELECT [Daily Production].[JOB #], " & _
			  "[Daily Production].Site, " & _
			  "[PAY ITEM PICK LIST].CODE, " & _
			  "[PAY ITEM PICK LIST].DESCRIPTION, " & _
			  "[Daily Production].[Daily Production], " & _
			  "[PAY ITEM PICK LIST].UNIT, " & _
			  "[Daily Production].[Contract Qty], " & _
			  "[Daily Production].Date, " & _
			  "[Daily Production].[Station with Support], " & _
			  "[Daily Production].Foreman, " & _
			  "[Daily Production].[Autonum] " & _
			  "FROM [Daily Production] " & _
			  "INNER JOIN [PAY ITEM PICK LIST] ON [Daily Production].PayItemID = [PAY ITEM PICK LIST].PayItemID " & _
			  "WHERE ((([Daily Production].[JOB #])=@atmJob)) ORDER By [Daily Production].Site, [PAY ITEM PICK LIST].DESCRIPTION", ATMconn1)

            cmdProduction.Parameters.AddWithValue("@atmJob", Me.cmbAtmJob.Text)

            ' Open connection to Db
			ATMconn1.Open()

            '  Fill dataAdapter with query result from Db
            productionDA = New OleDbDataAdapter(cmdProduction)

            ' Instantiate DataSet object
            productionDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            productionDA.Fill(productionDS, "Daily Production")

            '  Close the connection
			ATMconn1.Close()

            ' Create binding source
            productionBS = New BindingSource(productionDS, "Daily Production")

            ' DataTable -   Fill the DataTable object with data
            productionDT = productionDS.Tables("Daily Production")

            ' Set the Dataview object to the Dataset object
            productionDV = New DataView(productionDS.Tables("Daily Production"))

            ' Declare and set the alignment property
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Declare and set the alignment property
            Dim objAlignMidRightcellStyle As New DataGridViewCellStyle()
            objAlignMidRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            With Me.dgvDailyProductions

                .DataSource = productionBS


                .Columns(0).Visible = False

                .Columns(1).Width = 85

                .Columns(2).Visible = False

                .Columns(3).HeaderText = "Pay Item"
                .Columns(3).Width = 200

                .Columns(4).HeaderText = "P-Qty"
                .Columns(4).DefaultCellStyle = objAlignMidRightcellStyle
                .Columns(4).Width = 50

                .Columns(5).HeaderText = "Unit"
                .Columns(5).Width = 30

                .Columns(6).HeaderText = "C-Qty"
                .Columns(6).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(6).DefaultCellStyle.Font = New Font(dgvDailyProductions.Font, FontStyle.Bold)

                ' Specify a larger font for the "Ratings" column. 
                Dim font As New Font( _
                    .DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold)
                Try
                    .Columns(6).DefaultCellStyle.Font = font
                Finally
                    font.Dispose()
                End Try




                .Columns(6).Width = 50

                .Columns(7).DefaultCellStyle = objAlignMidRightcellStyle
                .Columns(7).Width = 100

                .Columns(8).Visible = False

                .Columns(9).HeaderText = "ForeMan"
                .Columns(9).Width = 75

                ' Autonum
                .Columns(10).Visible = False



            End With


            ' Clear DataBindings
            'Me.lblATMJob.DataBindings.Clear()
            Me.cmbAtmJob.DataBindings.Clear()
            Me.lblStation.DataBindings.Clear()
            Me.txtProductionQty.DataBindings.Clear()
            'Me.Label2.DataBindings.Clear()
            'Me.eDTPInstallDate.DataBindings.Clear()
            'Me.cmbForeman.DataBindings.Clear()
            Me.cmbPayItem.DataBindings.Clear()
            'Me.lblPayItemDesc.DataBindings.Clear()
            Me.txtContractQty.DataBindings.Clear()
            Me.lblUnit.DataBindings.Clear()
            Me.txtStationWithSupport.DataBindings.Clear()
            Me.lblAutonum.DataBindings.Clear()


            ' Add DataBindings
            Me.cmbAtmJob.DataBindings.Add("Text", productionBS, "JOB #")
            Me.lblStation.DataBindings.Add("Text", productionBS, "SITE")
            Me.txtProductionQty.DataBindings.Add("Text", productionBS, "Daily Production")
            'Me.Label2.DataBindings.Add("Text", productionBS, "UNIT")
            'Me.eDTPInstallDate.DataBindings.Add("DBValue", productionBS, "DATE")
            'Me.cmbForeman.DataBindings.Add("Text", productionBS, "FOREMAN")
            Me.cmbPayItem.DataBindings.Add("Text", productionBS, "CODE")
            'Me.lblPayItemDesc.DataBindings.Add("Text", productionBS, "DESCRIPTION")
            Me.txtContractQty.DataBindings.Add("Text", productionBS, "Contract Qty")
            Me.lblUnit.DataBindings.Add("Text", productionBS, "UNIT")
            Me.txtStationWithSupport.DataBindings.Add("Text", productionBS, "Station with Support")
            Me.lblAutonum.DataBindings.Add("Text", productionBS, "Autonum")

            CommonSiteDGVBackColor()



        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateProduction()")

        End Try

    End Sub

    Private Sub PopulateForeman()


        Try
			Dim foremanCmd As OleDbCommand = New OleDbCommand _
				("SELECT Foreman FROM Foreman", ATMconn1)

            ' Open connection to Db
			ATMconn1.Open()

            '  Fill dataAdapter with query result from Db
            foremanDA = New OleDbDataAdapter(foremanCmd)

            ' Instantiate DataSet object
            foremanDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            foremanDA.Fill(foremanDS, "Foreman")

            ' DataTable -   Fill the DataTable object with data
            foremanDT = foremanDS.Tables("Foreman")

            '  Close the connection
			ATMconn1.Close()

            RemoveHandler cmbForeman.SelectedIndexChanged, AddressOf cmbForeman_SelectedIndexChanged
            With Me.cmbForeman
                .DataSource = foremanDT
                .DisplayMember = "Foreman"
                .Text = "Select"
            End With
            AddHandler cmbForeman.SelectedIndexChanged, AddressOf cmbForeman_SelectedIndexChanged

        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateForeman()")

        End Try



    End Sub


    '  Not used anymore in this Class
    Private Sub sortLike(ByVal searchSTR As String)

        'Try
        '    ' Sort DataView by overload
        '    Me.productionDV.RowFilter = "site LIKE '*" & searchSTR & "*'"

        '    For Each row As DataGridViewRow In dgvDailyProductions.Rows

        '        If row.Cells.Item(6).Value.ToString = String.Empty Then
        '            row.Selected = True
        '        Else
        '            row.Selected = False

        '        End If


        '    Next

        '    'Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  Filter On:  [" & fieldName & "]    Search:  """ & searchSTR & """     (" & Me.productionDV.Count & " Records)"

        'Catch ex As Exception
        '    Me.productionDV.RowFilter = Nothing
        '    'Me.ToolStripStatusLabel1.Text = "Extruded T/O >>  (" & Me.productionFDV.Count & " Records)"
        'End Try

        

    End Sub

    Private Sub updateDb()

        Me.Cursor = Cursors.WaitCursor


        Try

			Dim cmdUpdateProduction As New OleDbCommand("UPDATE [Daily Production] SET " & _
														"[Daily Production].[PayItemID] = @pID, " & _
														"[Daily Production].[Daily Production] = @dp, " & _
														"[Daily Production].[Contract Qty] = @cQty, " & _
														"[Daily Production].[Date] = @InstallDate, " & _
														"[Daily Production].[Station with Support] = @sptStn, " & _
														"[Daily Production].[Foreman] = @foreMan " & _
														"WHERE [Daily Production].[Autonum] = @ID", ATMconn1)



            cmdUpdateProduction.Parameters.AddWithValue("@pID", CDbl(Me.Label1.Text))



            If Me.txtProductionQty.Text = String.Empty Then
                cmdUpdateProduction.Parameters.AddWithValue("@dp", DBNull.Value)
            Else
                cmdUpdateProduction.Parameters.AddWithValue("@dp", Me.txtProductionQty.Text)
            End If



            If Me.txtContractQty.Text = String.Empty Then
                cmdUpdateProduction.Parameters.AddWithValue("cQty", DBNull.Value)
            Else
                cmdUpdateProduction.Parameters.AddWithValue("@cQty", Me.txtContractQty.Text)
            End If




            If Not Me.ckbNullDate.Checked Or Me.txtProductionQty.Text = CStr(0) Then
                cmdUpdateProduction.Parameters.AddWithValue("@InstallDate", DBNull.Value)
            Else
                cmdUpdateProduction.Parameters.AddWithValue("@InstallDate", Me.eDTPInstallDate.Value)
            End If





            If Me.txtStationWithSupport.Text = String.Empty Then
                cmdUpdateProduction.Parameters.AddWithValue("sptStn", DBNull.Value)
            Else
                cmdUpdateProduction.Parameters.AddWithValue("@sptStn", Me.txtStationWithSupport.Text)
            End If


            If Not Me.ckbNullForeman.Checked Or Me.cmbForeman.Text = String.Empty Then
                cmdUpdateProduction.Parameters.AddWithValue("@foreMan", DBNull.Value)
            Else
                cmdUpdateProduction.Parameters.AddWithValue("@foreMan", Me.cmbForeman.Text)
            End If




            Dim dpID As Double
            Try
                dpID = CDbl(Me.lblAutonum.Text)

            Catch ex As Exception
                'dpID = 1
            End Try

            cmdUpdateProduction.Parameters.AddWithValue("@ID", dpID)


			ATMconn1.Open()
            ' use this variable later to display number of records updated
            Dim updateCount As Integer = cmdUpdateProduction.ExecuteNonQuery()
			ATMconn1.Close()

            signINMain1.tsbStatusLabelLeft.Text = Me.lblStation.Text & ", " & Me.txtProductionQty.Text & " " & Me.lblUnit.Text & ",  " & Me.lblPayItemDesc.Text & " Updated Sucessfully."

            AddToUpdatedRecords(Me.lblStation.Text, dpID, Me.txtProductionQty.Text)

            Me.dgvDailyProductions.Select()



        Catch ex As Exception
            MessageBox.Show(ex.Message, "updateDB()")
			ATMconn1.Close()

            signINMain1.tsbStatusLabelLeft.Text = "Error during Update Process.  No Data Has Been Changed."


        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub GetSearchCriteria()

        Try
            Dim station, prompt, title As String
            prompt = "Enter Station #."
            title = "Search for Station"
            station = InputBox(prompt, title)

            SearchForSite(station)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SearchForSite(ByVal site As String)

        DeSelectAllDGVRows()

        Me.Cursor = Cursors.WaitCursor

        Dim found As Boolean = False
        Try



            Dim rowindex = (From dgvr In dgvDailyProductions.Rows _
            Let row = DirectCast(dgvr, DataGridViewRow) _
            Where Not row.IsNewRow AndAlso row.Cells(1).Value.ToString.ToUpper = site.ToUpper _
            Select row.Index).ToArray
            If rowindex.Count > 0 Then
                dgvDailyProductions.CurrentCell = dgvDailyProductions(1, rowindex(0))
                dgvDailyProductions.FirstDisplayedScrollingRowIndex = rowindex(0)
                found = True
            End If

            If Not found Then MessageBox.Show(site & " not found.", "Search")

            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SearchForSite()")
        End Try

        Me.Cursor = Cursors.Arrow


    End Sub


    '  This Method initializes the ExtendedDateTimePicker's value to
    '  the one Day previous to Today's Date, unless it's Monday, then it
    '  selects the Previous Friday's Date.
    Private Sub InitializeInstallDate()
        Dim dateToday As Date = Today.Date
        Try
            Select Case dateToday.DayOfWeek
                Case DayOfWeek.Monday
                    eDTPInstallDate.Value = dateToday.AddDays(-3)

                Case Else
                    eDTPInstallDate.Value = dateToday.AddDays(-1)

            End Select
        Catch ex As Exception
            eDTPInstallDate.Value = Today.Date
        End Try


    End Sub

    Private Sub CommonSiteDGVBackColor()

        Me.Cursor = Cursors.WaitCursor

        Dim switchBackColor As Boolean = False
        Dim prevSite As String = Nothing
        Dim x As Integer = 0  ' Counter to switch row colors 

        Me.dgvDailyProductions.DefaultCellStyle.BackColor = Color.LightGray

        Try
            For Each row As DataGridViewRow In dgvDailyProductions.Rows

                ' If stations numbers are different then respond accordingly
                If row.Cells.Item(1).Value.ToString = prevSite Then
                    switchBackColor = False

                    Select Case x
                        Case 0
                            ' Maintain light gray
                        Case 1
                            row.DefaultCellStyle.BackColor = Color.WhiteSmoke
                            x = 1
                    End Select
                Else
                    If x = 0 Then
                        row.DefaultCellStyle.BackColor = Color.WhiteSmoke
                        x = 1
                    Else
                        row.DefaultCellStyle.BackColor = Color.LightGray
                        x = 0
                    End If
                End If


                ' Detect color and switch to alternate color
                Select Case switchBackColor
                    Case True
                        row.DefaultCellStyle.BackColor = Color.WhiteSmoke
                    Case False
                        ' Do Nothing
                End Select

                prevSite = row.Cells.Item(1).Value.ToString


            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "CommonSiteDGVBackColor()")
        End Try


        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub AdjustTitleBarText()

        Dim dateToday As Date = Me.eDTPInstallDate.Value

        Me.Text = "Daily Production:  " & Me.cmbAtmJob.Text & " (" & Me.lblJobDesc.Text & ") For " & dateToday.DayOfWeek.ToString & ", " & dateToday

    End Sub

    Private Sub DeSelectAllDGVRows()

        For Each row As DataGridViewRow In dgvDailyProductions.Rows
            row.Selected = False
        Next

    End Sub

    Private Sub AddToUpdatedRecords(ByVal site As String, ByVal ID As Double, ByVal qty As String)

        Try
            Me.dctUpdatedList.Add(ID, site)
            Me.dgvUpdatedList.Rows.Insert(0, site, ID, qty)
            ShowRecordCount()

            ' Deselect all rows
            For Each row As DataGridViewRow In dgvUpdatedList.Rows
                row.Selected = False
            Next

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "AddToUpdatedRecords()")
        End Try

    End Sub

    Private Sub ShowRecordCount()

        Try
            Dim currentRecord As Integer = Me.dgvUpdatedList.CurrentRow.Index + 1
            recCount = 0
            For Each r As DataGridViewRow In Me.dgvUpdatedList.Rows
                recCount += 1
            Next

            Me.txtUpdateCount.Text = currentRecord.ToString & "  of " & recCount

        Catch ex As Exception
            Me.txtUpdateCount.Text = "-0-"

        End Try


    End Sub

    Private Sub ShowUpdatedRecord(ByVal ID As Double)

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim rowindex = (From dgvr In dgvDailyProductions.Rows _
            Let row = DirectCast(dgvr, DataGridViewRow) _
            Where Not row.IsNewRow AndAlso CDbl(row.Cells(10).Value) = ID _
            Select row.Index).ToArray
            If rowindex.Count > 0 Then
                dgvDailyProductions.CurrentCell = dgvDailyProductions(1, rowindex(0))
                dgvDailyProductions.FirstDisplayedScrollingRowIndex = rowindex(0)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ShowUpdatedRecord()")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub MoveNext()
        Try

            Dim address As Point = Me.dgvUpdatedList.CurrentCellAddress
            If address.Y < Me.dgvUpdatedList.RowCount - 1 Then
                address.Y += 1
            End If
            Me.dgvUpdatedList.CurrentCell = Me.dgvUpdatedList(address.X, address.Y)

            ShowRecordCount()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub MovePrevious()

        Try

            Dim address As Point = Me.dgvUpdatedList.CurrentCellAddress
            If address.Y > 0 Then
                address.Y -= 1
            End If
            Me.dgvUpdatedList.CurrentCell = Me.dgvUpdatedList(address.X, address.Y)

            ShowRecordCount()


        Catch ex As Exception

        End Try


    End Sub


#End Region



#Region " Event Procedures"

    Private Sub frmEnterDailyProduction_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            signINMain1.tsbStatusLabelLeft.Text = String.Empty

        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmEnterDailyProduction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown


        If ((e.KeyCode = Keys.F) AndAlso (e.Modifiers = (Keys.Control))) Then
            GetSearchCriteria()                         '  Keyboard shortcut - "ctrl+F" 
            e.SuppressKeyPress = True

        ElseIf (e.KeyCode = Keys.F2) Then
            Me.txtProductionQty.Select()                ' Get focus to the Production Qty text box

        ElseIf ((e.KeyCode = Keys.N) AndAlso (e.Modifiers = (Keys.Control))) Then
            Me.btnNext_Click(Nothing, Nothing)          ' Select next DataGridView row
            e.SuppressKeyPress = True

        ElseIf ((e.KeyCode = Keys.B) AndAlso (e.Modifiers = (Keys.Control))) Then
            Me.btnPrevious_Click(Nothing, Nothing)      ' select previous DataGridView row
            e.SuppressKeyPress = True

        ElseIf (e.KeyCode = Keys.F5) Then
            Me.btnRefresh_Click(Nothing, Nothing)       '  Refresh Daily Productions DataGridView 

        ElseIf ((e.KeyCode = Keys.U) AndAlso (e.Modifiers = (Keys.Control))) Then
            Me.btnUpdate_Click(Nothing, Nothing)        '  Update DataBase
            e.SuppressKeyPress = True
        End If




    End Sub

    Private Sub frmEnterDailyProduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        populateActiveATMJobs()
        InitializeInstallDate()

        Me.ckbNullForeman.Checked = True
        Me.ckbNullDate.Checked = True

        Me.Text = "Enter Daily Productions"

        Me.Cursor = Cursors.Arrow





    End Sub

    Private Sub cmbAtmJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAtmJob.SelectedIndexChanged, cmbAtmJob.SelectionChangeCommitted


        Me.Cursor = Cursors.WaitCursor

        BindJobFields()
        GetJobPayItems()
        PopulateProduction()
        PopulateForeman()

        If Me.dgvUpdatedList.Rows.Count <= 0 Then
            ' Clear the dgv for a new job
            For Each row As DataGridViewRow In dgvUpdatedList.Rows
                dgvUpdatedList.Rows.RemoveAt(row.Index)
            Next

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        Me.productionBS.MoveNext()



    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click

        Me.productionBS.MovePrevious()



    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        updateDb()

    End Sub

    Private Sub dgvDailyProductions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDailyProductions.DoubleClick
        Me.txtProductionQty.Select()

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        Me.Cursor = Cursors.WaitCursor

        Dim x As Integer = CInt(Me.dgvDailyProductions.CurrentRow.Cells.Item(10).Value)
        PopulateProduction()

        Try

            Dim rowindex = (From dgvr In dgvDailyProductions.Rows _
            Let row = DirectCast(dgvr, DataGridViewRow) _
            Where Not row.IsNewRow AndAlso CInt(row.Cells.Item(10).Value) = x _
            Select row.Index).ToArray
            If rowindex.Count > 0 Then
                dgvDailyProductions.CurrentCell = dgvDailyProductions(1, rowindex(0))
                dgvDailyProductions.FirstDisplayedScrollingRowIndex = rowindex(0)
                'Me.productionBS.Find("Autonum", CInt(dgvDailyProductions.Rows(rowindex(0)).Cells.Item(10).Value))

            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow

        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub cmbPayItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPayItem.SelectedIndexChanged

		'MessageBox.Show(Me.Label1.Text & vbCrLf & Me.cmbPayItem.Text & vbCrLf & vbCrLf & lblPayItemDesc.Text)


    End Sub

    Private Sub cmbForeman_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForeman.SelectedIndexChanged



    End Sub

    Private Sub dgvDailyProductions_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDailyProductions.Sorted
        CommonSiteDGVBackColor()

    End Sub

    Private Sub eDTPInstallDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles eDTPInstallDate.ValueChanged
        AdjustTitleBarText()

    End Sub

    Private Sub lblJobDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblJobDesc.TextChanged
        AdjustTitleBarText()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        GetSearchCriteria()


    End Sub

    Private Sub btnPrevUpdated_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevUpdated.Click
        Try
            MovePrevious()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNextUpdated_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextUpdated.Click

        Try
            MoveNext()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GoToUpdatedRecord(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvUpdatedList.CellDoubleClick

        Try
            'Dim r As Integer = Me.dgvUpdatedList.CurrentRow.Index
            Dim i As Double = CDbl(Me.dgvUpdatedList.CurrentRow.Cells.Item(1).Value)
            ShowUpdatedRecord(i)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnGo_Click()")
        End Try


    End Sub

    Private Sub dgvUpdatedList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUpdatedList.SelectionChanged

        ShowRecordCount()


    End Sub



#End Region














End Class