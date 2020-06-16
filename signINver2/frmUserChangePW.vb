Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources




Public Class frmUserChangePW

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


#Region " Database communication"

    Dim usersDA As OleDbDataAdapter
    Dim usersDS As DataSet
    Dim usersDV As DataView
    Dim usersDT As DataTable

	Dim objConn As New OleDbConnection(My.Settings.SECconn)

#End Region

#Region " Class level Declarations"





    ' Class-level variables
    Dim userPW As String
    
    ' Declare events 
    Public Event userPWChanged()


#End Region


#Region " Methods & Functions"

    Private Sub LoadUserData()

        '  connection to database
		Dim cmd As OleDbCommand = New OleDbCommand("SELECT userCred FROM tblUsers WHERE userID = @userID", objConn)
		cmd.Parameters.AddWithValue("@userID", My.Settings.userID)


        ' Open connection to Db
        objConn.Open()

        '  Fill dataAdapter with query result from Db
        usersDA = New OleDbDataAdapter(cmd)

        '  Close the connection
        objConn.Close()

        ' Instantiate DataSet object
        usersDS = New DataSet()

        ' Fill DataSet with data from dataAdapater
        usersDA.Fill(usersDS, "tblUsers")

        ' Set the Dataview object to the Dataset object
        usersDV = New DataView(usersDS.Tables("tblUsers"))

        ' DataTable -   Fill the DataTable object with data
        usersDT = New DataTable


    End Sub

    Private Sub ChangeUserData(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Try

            'Make sure the dataset is not nothing
            If Not IsNothing(usersDS) Then

                'Make sure there is at least 1 table in the dataset 
                If usersDS.Tables.Count > 0 Then

                    usersDT = usersDS.Tables(0)

                    'Then make sure the datatable has rows in it   
                    If usersDT.Rows.Count > 0 Then

                        ' Password
                        Dim pW As String = usersDT.Rows(0).Item(0).ToString
                        userPW = Me.PasswordTextBox.Text.Trim

                        If validatePW(pW, userPW) Then

                            Dim newPW As String = Me.txtNewPassword.Text.Trim
                            Dim confirmPW As String = Me.txtConfirmNewPassword.Text.Trim

                            If validatePW(newPW, confirmPW) Then

                                ' Code to change password
                                ChangeCRED(newPW)

                                RaiseEvent userPWChanged()

                                Me.Close()

                            Else

                                MessageBox.Show("New Password and Confirmation do not match.", "I do not compute!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.txtNewPassword.SelectAll()
                                Me.txtConfirmNewPassword.Clear()

                            End If

                        Else

                            Me.PasswordTextBox.SelectAll()
                            MessageBox.Show("Invalid Username/Passwrod", "Try Again")

                        End If

                    End If

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ChangeUserData()")
        End Try


    End Sub

    Shared Function validatePW(ByVal _pw As String, ByVal _userPW As String) As Boolean

        If String.Compare(_pw, _userPW) = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub ChangeCRED(ByVal _pw As String)

        Try
			Using connection As New OleDbConnection(My.Settings.SECconn)

				Using command As New OleDbCommand("UPDATE tblUsers " & _
												  "SET userCred = @userCred " & _
												  "WHERE userID = @userID", connection)
					command.Parameters.AddWithValue("@userCred", _pw)
					command.Parameters.AddWithValue("@userID", My.Settings.userID)

					connection.Open()
					command.ExecuteNonQuery()

					MessageBox.Show("Password changed", "Change User Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End Using
			End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub






#End Region



#Region " Event Procedures"


    Private Sub frmUserChangePW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor

        LoadUserData()
        Me.UsernameTextBox.Text = My.Settings.userName

        Me.Cursor = Cursors.Arrow

    End Sub


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub



#End Region




End Class
