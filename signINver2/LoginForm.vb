Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources


Public Class LoginForm

    Dim usersDA As OleDbDataAdapter
    Dim usersDS As DataSet
    Dim usersDV As DataView
    Dim usersDT As DataTable

    Dim thisUser As String

    ' Declare events 
    Public Event userLoggedInEvent()

	'Dim objConn As New OleDbConnection(securedConnStr)
	Dim objConn As New OleDbConnection(My.Settings.SECconn)


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

		Dim thisUser As String = Me.cmbUsers.SelectedValue.ToString
		Dim thisName As String = Me.cmbUsers.Text
		Dim userPW As String = Me.PasswordTextBox.Text

        '  connection to database
		Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblUsers WHERE userID = @userID ORDER BY userSecLev", objConn)

		cmd.Parameters.AddWithValue("@userID", thisUser)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        usersDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, UpdateCommand and InsertCommand for DataAdapter object      
        Dim logBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(usersDA)

        ' Instantiate DataSet object
        usersDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        usersDA.Fill(usersDS, "tblUsers")

        ' Set the Dataview object to the Dataset object
        usersDV = New DataView(usersDS.Tables("tblUsers"))

        '  Close the connection
        objConn.Close()



        ' DataTable -   Fill the DataTable object with data
        usersDT = New DataTable

        'Make sure the dataset is not nothing
        If Not IsNothing(usersDS) Then

            'Make sure there is at least 1 table in the dataset 
            If usersDS.Tables.Count > 0 Then

                usersDT = usersDS.Tables(0)

                'Then make sure the datatable has rows in it   
                If usersDT.Rows.Count > 0 Then

                    ' Password and Security Level
                    Dim pW As String = usersDT.Rows(0).Item(2).ToString
                    Dim sL As Integer = CInt(usersDT.Rows(0).Item(3))


                    If validatePW(pW, userPW) = True Then

                        My.Settings.userID = thisUser
                        My.Settings.userName = thisName
                        My.Settings.loginDO = True
                        My.Settings.userSL = sL

                        RaiseEvent userLoggedInEvent()

                        ' LogIn time
                        userLogInTime()

                        signINMain1.tsbStatusLabelLeft.Text = Nothing
						signINMain1.tsbStatusLabelRight.Text = _
							 signINMain1.tsbStatusLabelRight.Text & "    User:  " & My.Settings.userName


                        Select Case My.Settings.userName

                            Case "Jeff King"
                                'signINMain1.tsbStatusLabelRight.Image = My.Resources.kingMoFo
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.Lion24x24
                                showAdvanced()

                            Case "Tonya King"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.SpartanHelmet_24
                                showAdvanced()

                            Case "Administrator"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.admin24
                                showAdvanced()

                            Case "Tom Peake"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.redWings24
                                showAdvanced()

                            Case "Paul Roth"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.redWings24
                                showAdvanced()

							Case "Kevin Brocklebank"
								signINMain1.tsbStatusLabelRight.Image = Nothing
								showATMPedestrian()


                            Case "Michael Peake"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.michaelPeakeCrane
								showATMPedestrian()

							Case "TJ Peake"
								signINMain1.tsbStatusLabelRight.Image = My.Resources.SpartanHelmet_24
								showATMPedestrian()


                            Case "Jim Rider"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.jimsHouse24
                                showPedestrian()


                            Case "Ian Klukowski"
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.Bike_24
								showAdvanced()

							
							Case "Andrew Piper"
								signINMain1.tsbStatusLabelRight.Image = My.Resources.Lion24x24
								showAdvanced()

                            Case "Brenden Pudduck"
                                'signINMain1.tsbStatusLabelRight.Image = My.Resources.redWings24
                                showATMPedestrian()

                            Case "Bryce Benedict"
                                signINMain1.tsbStatusLabelRight.Image = Nothing
                                'signINMain1.tsbStatusLabelRight.Image = My.Resources.redWings24
                                showATMPedestrian()

                            Case "Cris LeMarbe"
                                'signINMain1.tsbStatusLabelRight.Image = Nothing
                                signINMain1.tsbStatusLabelRight.Image = My.Resources.MontrealCanadiesn_24x24
                                showAdvanced()

                            Case Else
                                signINMain1.tsbStatusLabelRight.Image = Nothing
                                showPedestrian()

                        End Select

                        Me.Close()

                    Else

                        Me.PasswordTextBox.SelectAll()
                        MessageBox.Show("Invalid Username/Passwrod", "Try Again")

                    End If

                End If

            End If

        End If



	End Sub

    Shared Function validatePW(ByVal pw As String, ByVal userPW As String) As Boolean
        If String.Compare(pw, userPW) = 0 Then
            Return True
        Else
            Return False
        End If
	End Function

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        signINMain1.Close()

	End Sub

	Private Sub LoginForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData

            Case Keys.F1

                ' Tonya
                Me.cmbUsers.Text = "Tonya King"
                Me.PasswordTextBox.Text = "jeffking72"

            Case Keys.F2

                ' Jeff
                Me.cmbUsers.Text = "Jeff King"
                Me.PasswordTextBox.Text = "j0hns0n"

            Case Keys.F3

                ' Andrew
                Me.cmbUsers.Text = "Andrew Piper"
                Me.PasswordTextBox.Text = "discordie"

            Case Keys.F9

                ' Ian
                Me.cmbUsers.Text = "Ian Klukowski"
                Me.PasswordTextBox.Text = "ianmhs"


            Case Keys.F11

                ' Jim
                Me.cmbUsers.Text = "Jim Rider"
                Me.PasswordTextBox.Text = "kingjames"


        End Select
	End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        signINMain1.tsbUnlock.Visible = False

        ' load users with security level overload
        loadUsers(98)

		'  If previous login detected then select that user
		'  so each time they login their name is already selected
		If Not IsNothing(My.Settings.userName) Then
			Me.cmbUsers.Text = My.Settings.userName
		Else
			Me.cmbUsers.Text = "Select..."
		End If
		
		Me.PasswordTextBox.Select()


    End Sub

    Private Sub loadUsers(ByVal sec As Integer)

        '  connection to database
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblUsers WHERE userSecLev <= " & sec & " ORDER BY userSecLev ASC, userID DESC, userName DESC", objConn)

        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        usersDA = New OleDbDataAdapter(cmd)

        'One CommandBuilder object is required. 
        'It automatically generates DeleteCommand, 
        'UpdateCommand and InsertCommand 
        'for DataAdapter object      
        Dim usersBuilder As OleDbCommandBuilder = New OleDbCommandBuilder(usersDA)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        usersDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        usersDA.Fill(usersDS, "tblUsers")

        ' Set the Dataview object to the Dataset object
		usersDV = New DataView(usersDS.Tables("tblUsers"))

		With Me.cmbUsers
			.DataSource = usersDV
			.DisplayMember = "userName"
			.ValueMember = "userID"
		End With

	End Sub

	Private Sub ShowHomeScreen()

		Dim myHome As New frmHome
		myHome.MdiParent = signINMain1
		myHome.Show()

	End Sub

	Public Sub showAdvanced()

		Me.MdiParent.MainMenuStrip.Enabled = True
		signINMain1.ShippersToolStripDropDownButton.Enabled = True
		signINMain1.ToolStripSeparator14.Visible = True
		signINMain1.tsbATMNewSite.Visible = True
		signINMain1.TestingToolStripMenuItem.Enabled = True
		signINMain1.tsbHome.Visible = True

		'ShowHomeScreen()


	End Sub

    Public Sub showPedestrian()

        Me.MdiParent.MainMenuStrip.Enabled = True
        signINMain1.ToolStripSeparator14.Visible = False
        signINMain1.tsbATMNewSite.Visible = False

    End Sub

    Public Sub ShowLimited()


        Me.MdiParent.MainMenuStrip.Enabled = True
        signINMain1.tsbATMNewSite.Visible = True
        signINMain1.tsbATMNewSite.Enabled = False
        signINMain1.NewJobToolStripMenuItem.Enabled = False
        signINMain1.EditTakeOffToolStripMenuItem.Enabled = False
        signINMain1.NewRunToolStripMenuItem.Enabled = False
        signINMain1.EditRunToolStripMenuItem.Enabled = False
        signINMain1.EditTakeOffToolStripMenuItem1.Enabled = False
        signINMain1.EditTakeOffToolStripMenuItem2.Enabled = False
        signINMain1.LegendToolStripMenuItem.Enabled = False
        signINMain1.ShippersToolStripDropDownButton.Enabled = False
        signINMain1.ToolsMenu.Enabled = False






    End Sub

    Public Sub showATMAdvanced()

        Me.MdiParent.MainMenuStrip.Enabled = True
        signINMain1.ToolStripSeparator14.Visible = True
        signINMain1.tsbATMNewSite.Visible = True
		signINMain1.ShippersToolStripDropDownButton.Visible = True
		signINMain1.JobStartDateToolStripMenuItem.Enabled = True
        'signINMain1.ToolStripSeparator16.Visible = True


    End Sub

    Public Sub showATMPedestrian()

        Me.MdiParent.MainMenuStrip.Enabled = True
        signINMain1.ToolStripSeparator14.Visible = True
        signINMain1.tsbATMNewSite.Visible = True
        signINMain1.ShippersToolStripDropDownButton.Enabled = False
        'signINMain1.ToolStripSeparator16.Visible = False


	End Sub

    Private Sub userLogInTime()

		Using connection As New OleDbConnection(My.Settings.SECconn)

			Using command As New OleDbCommand("INSERT INTO tblUserLog (userID, userLogTime, logType) " & _
											  "VALUES (@userID, Now(), 1)", connection)
				command.Parameters.AddWithValue("@userID", My.Settings.userID)

				connection.Open()
				command.ExecuteNonQuery()
			End Using
		End Using

    End Sub

	Private Sub cmbUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsers.SelectedIndexChanged
		Me.PasswordTextBox.Select()
	End Sub
End Class
