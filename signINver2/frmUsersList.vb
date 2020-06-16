Option Strict On


Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources



Public Class frmUsersList



#Region " Database communication"

    Dim usersDA As OleDbDataAdapter
    Dim usersDS As DataSet
    Dim usersBS As BindingSource
    Dim usersDT As DataTable

	Dim objConn As New OleDbConnection(My.Settings.SECconn)

#End Region

#Region " Class level Declarations"


    ' Class-level variables
    Dim userPW As String

   

#End Region



    Private Sub LoadUserDataBindFields()

        Try

            '  connection to database
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT userID, " & _
                                                       "userName, " & _
                                                       "userCred, " & _
                                                       "userSecLev, " & _
                                                       "entryDate, " & _
                                                       "editDate " & _
                                                       "FROM tblUsers ORDER By userSecLev, userName, entryDate", objConn)

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

            ' Create binding source
            usersBS = New BindingSource(usersDS, "tblUsers")

            ' DataTable -   Fill the DataTable object with data
            usersDT = usersDS.Tables("tblUsers")

            ' Add DataBinding
            Me.TextBox1.DataBindings.Add("Text", usersBS, "userID")
            Me.TextBox2.DataBindings.Add("Text", usersBS, "userName")
            Me.TextBox3.DataBindings.Add("Text", usersBS, "userCred")
            Me.TextBox4.DataBindings.Add("Text", usersBS, "userSecLev")
            Me.TextBox5.DataBindings.Add("Text", usersBS, "entryDate")
            Me.TextBox6.DataBindings.Add("Text", usersBS, "editDate")

            ' Bind DataRepeater to DataTable
            Me.drpUsers.DataSource = usersBS

        Catch ex As Exception
            MessageBox.Show(ex.Message, "LoadUserData()")

        End Try



    End Sub




    Private Sub frmUsersList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        LoadUserDataBindFields()




    End Sub
End Class