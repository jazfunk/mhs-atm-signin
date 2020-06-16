Option Strict On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources



Public Class frmCustomerListing



#Region " Database communication"


	'Dim mhsConn As New OleDbConnection(connStr01)
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)


    Dim customersDA As New OleDbDataAdapter
    Dim customersDS As New DataSet
    Dim customersDT As DataTable
    Dim customersDV As New DataView



#End Region


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


    'Private Sub AddNewCustomer()


    '    Try
	'        Using connection As New OleDbConnection(My.Settings.SignINconn)

    '            Using command As New OleDbCommand("INSERT Into tblCustomers " & _
    '                                              "(cust, " & _
    '                                              "custFull, " & _
    '                                              "Address1, " & _
    '                                              "Address2, " & _
    '                                              "city, " & _
    '                                              "state, " & _
    '                                              "zip, " & _
    '                                              "phone, " & _
    '                                              "fax, " & _
    '                                              "web, " & _
    '                                              "email, " & _
    '                                              "contact) " & _
    '                                              "VALUES(@cust," & _
    '                                              "@custFull," & _
    '                                              "@Address1," & _
    '                                              "@Address2," & _
    '                                              "@city," & _
    '                                              "@state," & _
    '                                              "@zip," & _
    '                                              "@phone," & _
    '                                              "@fax," & _
    '                                              "@web," & _
    '                                              "@email," & _
    '                                              "@contact)", connection)

    '                command.Parameters.AddWithValue("@cust", Me.txtCust.Text.Trim)
    '                command.Parameters.AddWithValue("@custFull", Me.txtCustFull.Text.Trim)
    '                command.Parameters.AddWithValue("@Address1", Me.txtAddress1.Text.Trim)
    '                command.Parameters.AddWithValue("@Address2", Me.txtAddress2.Text.Trim)
    '                command.Parameters.AddWithValue("@city", Me.txtCity.Text.Trim)
    '                command.Parameters.AddWithValue("@state", Me.txtState.Text.Trim)

    '                ' Format for empty entries.   
    '                Dim zC As String = Me.mtxtZip.Text
    '                If zC.Substring(0, 1) = " " Then
    '                    command.Parameters.AddWithValue("@zip", String.Empty)
    '                Else
    '                    command.Parameters.AddWithValue("@zip", Me.mtxtZip.Text)
    '                End If


    '                ' Format for empty entries.  
    '                Dim tph As String = Me.mtxtPhone.Text
    '                If tph.ToUpper.Substring(0, 2) = "( " Then
    '                    command.Parameters.AddWithValue("@phone", String.Empty)
    '                Else
    '                    command.Parameters.AddWithValue("@phone", Me.mtxtPhone.Text.Trim)
    '                End If



    '                ' Format for empty entries.  
    '                Dim fax As String = Me.mtxtFax.Text
    '                If fax.ToUpper.Substring(0, 2) = "( " Then
    '                    command.Parameters.AddWithValue("@fax", String.Empty)
    '                Else
    '                    command.Parameters.AddWithValue("@fax", Me.mtxtFax.Text.Trim)
    '                End If



    '                ' Format for empty entries.
    '                If Me.txtWeb.Text = "http://" Then
    '                    command.Parameters.AddWithValue("@web", String.Empty)
    '                Else
    '                    command.Parameters.AddWithValue("@web", Me.txtWeb.Text.Trim)
    '                End If


    '                command.Parameters.AddWithValue("@email", Me.txtEmail.Text.Trim)
    '                command.Parameters.AddWithValue("@contact", Me.txtCust.Text.Trim)

    '                connection.Open()
    '                command.ExecuteNonQuery()

    '                Dim result As DialogResult = _
    '                                    MessageBox.Show(Me.txtCustFull.Text & " added to the Customers Database.", Me.txtCust.Text & " Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                Select Case result


    '                    Case Windows.Forms.DialogResult.OK
    '                        ' Close form after clicking OK in the messageBox
    '                        Me.Close()

    '                End Select
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show("Customer not added!" & vbCrLf & ex.Message, "I do not compute!", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '    End Try



    'End Sub


    Private Sub FillDGVandBindFields()

        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT " & _
                                                       "custID, " & _
                                                       "cust, " & _
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
                                                       "contact " & _
                                                       "FROM tblCustomers", mhsConn)


            ' Open connection to Db
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            customersDA = New OleDbDataAdapter(cmd)

            mhsConn.Close()

            ' Initialize a new instance of the DataSet object
            customersDS = New DataSet()

            ' Fill the DataSet object with Data
            customersDA.Fill(customersDS, "tblCustomers")

            Dim customersCB As New OleDbCommandBuilder(customersDA)

            ' DataTable -   Fill the DataTable object with data
            customersDT = customersDS.Tables("tblCustomers")

            ' Set the DataView object to the DataSet object
            customersDV = New DataView(customersDS.Tables("tblCustomers"))


            ' Set Align-MiddleCenter object
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Set Align-MiddleRight object
            Dim objAlignRightcellStyle As New DataGridViewCellStyle
            objAlignRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke


            With Me.dgvCustomers

                .DataSource = customersDV

                .AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ' ID field
                .Columns(0).Visible = False

                ' cust field
                .Columns(1).HeaderText = "ID"
                .Columns(1).Width = 60
                .Columns(1).DefaultCellStyle.ForeColor = Color.Black
                .Columns(1).DefaultCellStyle.Font = New Font(dgvCustomers.Font, FontStyle.Bold)

                ' custFull field
                .Columns(2).HeaderText = "Customer"
                .Columns(2).Width = 120

                ' address1 field
                .Columns(3).HeaderText = "Address 1"
                .Columns(3).Width = 75

                ' address2 field
                .Columns(4).HeaderText = "Address 2"
                .Columns(4).Width = 55

                ' city field
                .Columns(5).HeaderText = "City"
                .Columns(5).Width = 55

                ' state field
                .Columns(6).HeaderText = "State"
                .Columns(6).Width = 35
                .Columns(6).DefaultCellStyle = objAlignMidcellStyle

                ' Zip Code field
                .Columns(7).HeaderText = "Zip"
                .Columns(7).Width = 40

                ' phone field
                .Columns(8).HeaderText = "Phone"
                .Columns(8).Width = 50

                ' fX field
                .Columns(9).HeaderText = "Fax"
                .Columns(9).Width = 50

                ' web field
                .Columns(10).HeaderText = "Web"
                .Columns(10).Width = 50

                ' email field
                .Columns(11).HeaderText = "email"
                .Columns(11).Width = 50

                ' contact field
                .Columns(12).HeaderText = "Contact"
                .Columns(12).Width = 50

            End With


            Me.ToolStripStatusLabel1.Text = Me.customersDV.Count & " Customers)"


            'Clear Databindings
            Me.txtCust.DataBindings.Clear()
            Me.txtCustFull.DataBindings.Clear()
            Me.txtAddress1.DataBindings.Clear()
            Me.txtAddress2.DataBindings.Clear()
            Me.txtCity.DataBindings.Clear()
            Me.txtState.DataBindings.Clear()
            Me.mtxtZip.DataBindings.Clear()
            Me.mtxtPhone.DataBindings.Clear()
            Me.mtxtFax.DataBindings.Clear()
            Me.txtWeb.DataBindings.Clear()
            Me.txtEmail.DataBindings.Clear()
            Me.txtContact.DataBindings.Clear()

            ' Add Databindings
            Me.txtCust.DataBindings.Add("Text", customersDV, "cust")
            Me.txtCustFull.DataBindings.Add("Text", customersDV, "custFull")
            Me.txtAddress1.DataBindings.Add("Text", customersDV, "address1")
            Me.txtAddress2.DataBindings.Add("Text", customersDV, "address2")
            Me.txtCity.DataBindings.Add("Text", customersDV, "city")
            Me.txtState.DataBindings.Add("Text", customersDV, "state")
            Me.mtxtZip.DataBindings.Add("Text", customersDV, "zip")
            Me.mtxtPhone.DataBindings.Add("Text", customersDV, "phone")
            Me.mtxtFax.DataBindings.Add("Text", customersDV, "fax")
            Me.txtWeb.DataBindings.Add("Text", customersDV, "web")
            Me.txtEmail.DataBindings.Add("Text", customersDV, "email")
            Me.txtContact.DataBindings.Add("Text", customersDV, "contact")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "filldgv sub")

        End Try

    End Sub

    Private Sub updateDb()

        Try
            '  Write changes back to actual .mdb file
            '  Accept changes from DataGridView object
            Me.Validate()
            Me.dgvCustomers.EndEdit()
            Me.customersDA.Update(Me.customersDS.Tables("tblCustomers"))

            Me.ToolStripStatusLabel1.Text = "Customer Updated"

            DisableFields()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub EnableFields()

        Me.txtCustFull.ReadOnly = False
        Me.txtAddress1.ReadOnly = False
        Me.txtAddress2.ReadOnly = False
        Me.txtCity.ReadOnly = False
        Me.txtState.ReadOnly = False
        Me.mtxtZip.ReadOnly = False
        Me.mtxtPhone.ReadOnly = False
        Me.mtxtFax.ReadOnly = False
        Me.txtWeb.ReadOnly = False
        Me.txtEmail.ReadOnly = False
        Me.txtContact.ReadOnly = False
        Me.btnSave.Enabled = True

        Me.btnEdit.Enabled = False


    End Sub

    Private Sub DisableFields()

        Me.txtCust.ReadOnly = True
        Me.txtCustFull.ReadOnly = True
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress2.ReadOnly = True
        Me.txtCity.ReadOnly = True
        Me.txtState.ReadOnly = True
        Me.mtxtZip.ReadOnly = True
        Me.mtxtPhone.ReadOnly = True
        Me.mtxtFax.ReadOnly = True
        Me.txtWeb.ReadOnly = True
        Me.txtEmail.ReadOnly = True
        Me.txtContact.ReadOnly = True
        Me.btnSave.Enabled = True

        Me.btnEdit.Enabled = True


    End Sub

    Private Sub frmCustomerListing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        '  Detects whether DataSet has changes which the DataAdapter 
        '  has not updated to the DataSource

        Select Case customersDS.HasChanges

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

    Private Sub frmCustomerListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDGVandBindFields()

        DisableFields()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim newCust As New frmNewCust
        newCust.MdiParent = signINMain1
        newCust.Show()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EnableFields()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Me.txtEmail.Text = String.Empty Then
            updateDb()
        ElseIf IsValidEmail(Me.txtEmail.Text) Then
            updateDb()
        Else
            MessageBox.Show(Me.txtEmail.Text & "  is not a valid email address.", "I do not compute!")
        End If

    End Sub
End Class