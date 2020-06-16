Option Strict On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources




Public Class frmNewCust

    'inventoryConnStr01

    ''' <summary>
    ''' method for determining if the user provided a valid email address
    ''' We use regular expressions in this check, as it is a more thorough
    ''' way of checking the address provided
    ''' </summary>
    ''' <param name="email">email address to validate</param>
    ''' <returns>true is valid, false if not valid</returns>
    Public Function IsValidEmail(ByVal email As String) As Boolean

        'regular expression pattern for valid email
        'addresses, allows for the following domains:
        'com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv

        Dim pattern As String = "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." & _
        "(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
        'Regular expression object

        Dim check As New System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace)
        'boolean variable to return to calling method
        Dim valid As Boolean = False


        'make sure an email address was provided
        If String.IsNullOrEmpty(email) Then
            valid = False
        Else
            'use IsMatch to validate the address
            valid = check.IsMatch(email)
        End If


        'return the value to the calling method
        Return valid

    End Function




    Private Sub AddNewCustomer()


        Try
			Using connection As New OleDbConnection(My.Settings.SignINconn)

				Using command As New OleDbCommand("INSERT Into tblCustomers " & _
												  "(cust, " & _
												  "custFull, " & _
												  "Address1, " & _
												  "Address2, " & _
												  "city, " & _
												  "state, " & _
												  "zip, " & _
												  "phone, " & _
												  "fax, " & _
												  "web, " & _
												  "email, " & _
												  "contact) " & _
												  "VALUES(@cust," & _
												  "@custFull," & _
												  "@Address1," & _
												  "@Address2," & _
												  "@city," & _
												  "@state," & _
												  "@zip," & _
												  "@phone," & _
												  "@fax," & _
												  "@web," & _
												  "@email," & _
												  "@contact)", connection)

					command.Parameters.AddWithValue("@cust", Me.txtCust.Text.Trim)
					command.Parameters.AddWithValue("@custFull", Me.txtCustFull.Text.Trim)
					command.Parameters.AddWithValue("@Address1", Me.txtAddress1.Text.Trim)
					command.Parameters.AddWithValue("@Address2", Me.txtAddress2.Text.Trim)
					command.Parameters.AddWithValue("@city", Me.txtCity.Text.Trim)
					command.Parameters.AddWithValue("@state", Me.txtState.Text.Trim)

					' Format for empty entries.   
					Dim zC As String = Me.mtxtZip.Text
					If zC.Substring(0, 1) = " " Then
						command.Parameters.AddWithValue("@zip", String.Empty)
					Else
						command.Parameters.AddWithValue("@zip", Me.mtxtZip.Text)
					End If


					' Format for empty entries.  
					Dim tph As String = Me.mtxtPhone.Text
					If tph.ToUpper.Substring(0, 2) = "( " Then
						command.Parameters.AddWithValue("@phone", String.Empty)
					Else
						command.Parameters.AddWithValue("@phone", Me.mtxtPhone.Text.Trim)
					End If



					' Format for empty entries.  
					Dim fax As String = Me.mtxtFax.Text
					If fax.ToUpper.Substring(0, 2) = "( " Then
						command.Parameters.AddWithValue("@fax", String.Empty)
					Else
						command.Parameters.AddWithValue("@fax", Me.mtxtFax.Text.Trim)
					End If



					' Format for empty entries.
					If Me.txtWeb.Text = "http://" Then
						command.Parameters.AddWithValue("@web", String.Empty)
					Else
						command.Parameters.AddWithValue("@web", Me.txtWeb.Text.Trim)
					End If


					command.Parameters.AddWithValue("@email", Me.txtEmail.Text.Trim)
					command.Parameters.AddWithValue("@contact", Me.txtContact.Text.Trim)

					connection.Open()
					command.ExecuteNonQuery()

					Dim result As DialogResult = _
										MessageBox.Show(Me.txtCustFull.Text & " added to the Customers Database.", Me.txtCust.Text & " Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

					Select Case result


						Case Windows.Forms.DialogResult.OK
							' Close form after clicking OK in the messageBox
							Me.Close()

					End Select
				End Using
			End Using

        Catch ex As Exception
            MessageBox.Show("Customer not added!" & vbCrLf & ex.Message, "I do not compute!", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End Try



    End Sub

    




    Private Sub frmNewCust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If Me.txtEmail.Text = String.Empty Then
            AddNewCustomer()
        ElseIf IsValidEmail(Me.txtEmail.Text) Then
            AddNewCustomer()
        Else
            MessageBox.Show(Me.txtEmail.Text & "  is not a valid email address.", "I do not compute!")
        End If


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()


    End Sub
End Class