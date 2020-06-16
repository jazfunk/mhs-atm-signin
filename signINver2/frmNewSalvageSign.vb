Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources








Public Class frmNewSalvageSign



#Region " Database Communication"

    '  (Action Traffic.mdb) connection
    Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

    Dim atmJobDA As OleDbDataAdapter
    Dim atmJobDS As DataSet
    Dim atmJobDV As DataView
    Dim atmJobDT As DataTable

    Dim stationDA As OleDbDataAdapter
    Dim stationDS As DataSet
    Dim stationDV As DataView
    Dim stationDT As DataTable


    '' Connection to db1.mdb
    'Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    '' Sheeting
    'Dim salvageDA As OleDbDataAdapter
    'Dim salvageDS As DataSet
    'Dim salvageDV As DataView
    'Dim salvageDT As DataTable



    ' Connection to materialsInventory.mdb
    'Dim invConn As New OleDbConnection(My.Settings.INVconn)


#End Region



#Region " Functions & Methods"



    Private Sub AddNewSalvageInventory()


        Try
            ' Connection to database
			Using connection As New OleDbConnection(My.Settings.SignINconn)

				Using command As New OleDbCommand("INSERT Into tblSalvageInventory " & _
												  "(atmJob, " & _
												  "station, " & _
												  "type, " & _
												  "width, " & _
												  "height, " & _
												  "recvDate, " & _
												  "location, " & _
												  "reInstalled, " & _
												  "shipDate) " & _
												  "VALUES(@atmJob, " & _
												  "@station, " & _
												  "@type, " & _
												  "@width, " & _
												  "@height, " & _
												  "@recvDate, " & _
												  "@location, " & _
												  "@reInstalled, " & _
												  "@shipDate)", connection)

					command.Parameters.AddWithValue("@atmJob", Me.txtAtmJob.Text)
					command.Parameters.AddWithValue("@station", Me.txtStation.Text)
					command.Parameters.AddWithValue("@type", Me.txtSignType.Text)
					command.Parameters.AddWithValue("@width", CDbl(Me.txtSignWidth.Text))
					command.Parameters.AddWithValue("@height", CDbl(Me.txtSignHeight.Text))
					command.Parameters.AddWithValue("@recvDate", Me.eDtpRecvDate.Value.Date)
                    command.Parameters.AddWithValue("@location", Me.txtRcvdLocation.Text)
					command.Parameters.AddWithValue("@reInstalled", False)
					command.Parameters.AddWithValue("@shipDate", DBNull.Value)

					connection.Open()

					command.ExecuteNonQuery()

					Me.ToolStripStatusLabel1.Text = "Salvage Sign (" & Me.txtStation.Text & _
																	" " & _
																	Me.txtSignWidth.Text & _
																	" x " & _
																	Me.txtSignHeight.Text & _
																	") Entered Successfully"

					Dim result As DialogResult = MessageBox.Show(Me.txtStation.Text & ", " & _
																 Me.txtSignWidth.Text & " x " & _
																 Me.txtSignHeight.Text & _
																 "  Added Successfully." & _
																 vbCrLf & _
																 vbCrLf & _
																 "Enter additional salvage items?", _
																 "Salvage Inventory", _
																 MessageBoxButtons.YesNo, _
																 MessageBoxIcon.Question)



					Select Case result

						Case Windows.Forms.DialogResult.Yes

							'  Clear the form for new entry
							ResetAfterAdd()

						Case Windows.Forms.DialogResult.No

							' Close form
							Me.Close()

					End Select

				End Using

			End Using



        Catch ex As Exception

            Me.ToolStripStatusLabel1.Text = "Salvage Sign Not Added"
            MessageBox.Show("Record not added!" & _
                            vbCrLf & _
                            ex.Message, "AddNewSalvageInventory()", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)


        End Try



    End Sub

    Private Sub ResetAfterAdd()

        Try

            Me.txtStation.Clear()

            'Me.cmbSignType.SelectedIndex = 0
            Me.cmbSignType.Text = "Select Sign Type"
            Me.txtSignType.Clear()

            Me.txtSignWidth.Clear()
            Me.txtSignHeight.Clear()

            'Me.cmbLocation.SelectedIndex = 0
            Me.cmbLocation.Text = "Select Storage Location"
            Me.txtLocation.Clear()

            Me.txtStation.Clear()
            Me.txtReceivedFrom.Clear()

            Me.cmbStation.Text = "Select Station Number"

            Me.cmbAtmJob.Select()



        Catch ex As Exception

        End Try


    End Sub

    Private Sub PopulateActiveATMJobs()


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

            RemoveHandler cmbAtmJob.SelectedIndexChanged, AddressOf cmbAtmJob_SelectedIndexChanged
            With Me.cmbAtmJob
                .DataSource = atmJobDV
                .DisplayMember = "jn"
                .Text = "Select ATM Job"
            End With
            AddHandler cmbAtmJob.SelectedIndexChanged, AddressOf cmbAtmJob_SelectedIndexChanged

        Catch ex As Exception
            '  Close the connection
            ATMconn1.Close()
            MessageBox.Show(ex.Message, "PopulateActiveATMJobs()")

        End Try

    End Sub

    Private Sub FillStationNumberByJob(ByVal jobNumber As String)


        Try
            Dim stationCmd As OleDbCommand = New OleDbCommand _
             ("SELECT DISTINCT Site " & _
              "From [Daily Production] " & _
              "WHERE [JOB #] = '" & jobNumber & "' " & _
              "ORDER By Site", ATMconn1)

            ' Open connection to Db
            ATMconn1.Open()

            '  Fill dataAdapter with query result from Db
            stationDA = New OleDbDataAdapter(stationCmd)

            ' Instantiate DataSet object
            stationDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            stationDA.Fill(stationDS, "site")

            '  Close the connection
            ATMconn1.Close()

            ' Set the Dataview object to the Dataset object
            stationDV = New DataView(stationDS.Tables("site"))

            RemoveHandler cmbStation.SelectedIndexChanged, AddressOf cmbStation_SelectedIndexChanged
            With Me.cmbStation
                .DataSource = stationDV
                .DisplayMember = "site"
                .Text = "Select Station"
            End With
            AddHandler cmbStation.SelectedIndexChanged, AddressOf cmbStation_SelectedIndexChanged

        Catch ex As Exception
            '  Close the connection
            ATMconn1.Close()
            MessageBox.Show(ex.Message, "FillStationNumberByJob()")

        End Try


    End Sub

    Private Sub CombineFromAndLocation()

        Dim x As String = Me.txtReceivedFrom.Text
        Dim y As String = Me.txtLocation.Text

        Me.txtRcvdLocation.Text = y & " - (" & x & ")"



    End Sub


#End Region




#Region " Event Procedures"

    Private Sub frmNewSalvageSign_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'Dim saveResult As DialogResult

        'saveResult = MessageBox.Show("Do you want to exit?", _
        '                             "Close Form?", _
        '                             MessageBoxButtons.OKCancel, _
        '                             MessageBoxIcon.Question, _
        '                             MessageBoxDefaultButton.Button1)

        'Select Case saveResult

        '    Case Windows.Forms.DialogResult.OK
        '        ' Close the form
        '        e.Cancel = False

        '    Case DialogResult.Cancel
        '        ' Cancel the form closing
        '        e.Cancel = True
        'End Select

    End Sub

    Private Sub frmNewSalvageSign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown


        Select Case e.KeyData

            Case Keys.F1

                ' Extruded
                Me.cmbSignType.Text = "Extruded"
                MessageBox.Show("Extruded")
                e.SuppressKeyPress = True

            Case Keys.F2

                ' Plywood
                Me.cmbSignType.Text = "Plywood"
                e.SuppressKeyPress = True

            Case Keys.F3

                ' Flatsheet .080
                Me.cmbSignType.Text = "Flatsheet .080"
                e.SuppressKeyPress = True

            Case Keys.F5

                ' Flatsheet .125
                Me.cmbSignType.Text = "Flatsheet .125"
                e.SuppressKeyPress = True


        End Select

    End Sub

    Private Sub frmNewSalvageSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.eDtpRecvDate.Value = Today.Date

        ResetAfterAdd()
        Me.txtAtmJob.Clear()  ' Only clear this when the form initially loads.  
        PopulateActiveATMJobs()


    End Sub

    Private Sub cmbSignType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSignType.SelectedIndexChanged

        Me.txtSignType.Text = Me.cmbSignType.Text


    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click


        Try


            Dim sW As Double = CDbl(Me.txtSignWidth.Text)
            Dim sH As Double = CDbl(Me.txtSignHeight.Text)

            If Me.txtAtmJob.Text IsNot String.Empty Then
                If Me.txtStation.Text IsNot String.Empty Then
                    If Me.txtSignType.Text IsNot String.Empty Then
                        If Me.txtLocation.Text IsNot String.Empty Then
                            AddNewSalvageInventory()
                        Else
                            Me.ToolStripStatusLabel1.Text = "Missing required Data.  Record not added."
                        End If
                    End If
                Else
                    Me.ToolStripStatusLabel1.Text = "Missing required Data.  Record not added."
                End If
            Else
                Me.ToolStripStatusLabel1.Text = "Missing required Data.  Record not added."
            End If

        Catch ex As Exception

            Me.ToolStripStatusLabel1.Text = "Missing required data."
            MessageBox.Show("You must enter all required information.", "I do not compute!")

        End Try





    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click



        Me.Close()


    End Sub

    Private Sub btnListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListing.Click

        Dim salvList As New frmSalvageInventory
        salvList.MdiParent = signINMain1
        salvList.Show()

    End Sub

    Private Sub cmbLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocation.SelectedIndexChanged

        Me.txtLocation.Text = Me.cmbLocation.Text

    End Sub

    Private Sub cmbAtmJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAtmJob.SelectedIndexChanged

        Me.txtAtmJob.Text = Me.cmbAtmJob.Text

        FillStationNumberByJob(Me.cmbAtmJob.Text)



    End Sub

    Private Sub cmbStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStation.SelectedIndexChanged


        Me.txtStation.Text = Me.cmbStation.Text


    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged, txtReceivedFrom.TextChanged


        CombineFromAndLocation()


    End Sub


#End Region


















End Class