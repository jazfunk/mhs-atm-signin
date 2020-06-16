Option Strict On


Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources




Public Class Form1


    ' atmConnStr


    ' Local
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\Action\Action Traffic.mdb

    ' Remote
    'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\Action Traffic.mdb

    '**********************************



    ' connStr01


    ' Local
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\MHS Pre Production\signIN\db1.mdb


    ' Remote
    'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\db1.mdb

    '**********************************


    ' connStrMHS01


    ' Local
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\Michigan Highway\MHS Database.mdb


    ' Remote
    'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\MHS Database.mdb

    '**********************************



    ' securedConnStr


    ' Local
	'Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=j0hns0n; Data Source=\\attermserv01\company data\MHS Pre Production\signIN\secured.mdb;Persist Security Info=False


    ' Remote
    'Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=j0hns0n; Data Source=c:\sIv2\secured.mdb;Persist Security Info=False

    '**********************************




    ' inventoryConnStr01


    ' Local
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\MHS Pre Production\signIN\materialsInventory.mdb


    ' Remote
    'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\materialsInventory.mdb

    '**********************************




    ' imgPath


    'Local
	'\\attermserv01\company data\MHS Pre Production\signIN\signImages\

    'Remote
    'c:\sIv2\signImages\

    '**********************************




    ' jobsDirectory

    'Local 
	'\\attermserv01\company data\MHS Pre Production\Jobs\

    'Remote
    'c:\sIv2\Jobs\


    '**********************************





    '  Handling key presses.  Using "DELETE" Key in this example
    'Private Sub frmFollow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Delete Then MsgBox("You have pressed delete")
    'End Sub

    '**********************************




    ' Iterate through DGV, in this example,
    ' uncheck or check checkboxes
    ' Button2 is "Select All"
    ' Button3 is "Select None"
    'Private Sub UpdateSelection(ByVal sender As System.Object, _
    '                        ByVal e As System.EventArgs) Handles Button2.Click _
    '                                                             Button3.Click
    '    Dim selected As Boolean = (sender Is Button2)
    '    Dim table As DataTable = DirectCast(DataGridView1.DataSource, DataTable)

    '    For Each row As DataRow In table.Rows
    '        row("Selection") = selected
    '    Next
    'End Sub


    '**********************************




    '  Format Date value to trim time
    'Me.TextBox1.DataBindings.Add("Text", _ 
    '    Me.BindingSource1, _ 
    '    "Date", _ 
    '    True).FormatString = "MM/dd/yyyy" 

    '**********************************




    '  Reference for selecting item in DGV
    'Dim j As String = Me.dgvMHSJobs.CurrentRow.Cells.Item(1).Value.ToString
    'Dim d As String = Me.dgvMHSJobs.CurrentRow.Cells.Item(3).Value.ToString

    '**********************************



    'This code is saying get each string 'f' in the list of strings 'flowers' 
    'where 'f' starts with whatever's in the TextBox, 
    'then put those matching values into an array and bind that to the ListBox, which 
    'will display the values. 

    'myListBox.DataSource = (From f in flowers Where f.StartsWith(myTextBox.Text)).ToArray() 

    '**********************************




    '  Modify and use this code to Delete Dynamically created textboxes 
    'and listboxes in the new Legend form
    'Private Sub ComboBoxes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    'Handles comboBox1.SelectedIndexChanged, comboBox2.SelectedIndexChanged .., etc 

    'Dim key As ComboBox = DirectCast(sender, ComboBox)    
    'Me.comboBoxes(key).Enabled = (key.Text = "Small")
    'End Sub 

    '**********************************



    'Private Sub PayItemToSpeech(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvJobPayItems.MouseUp

    '    Using SpeakingLabel As New SpeechSynthesizer
    '        'SpeakingLabel.SelectVoice("Miscrosoft Sam")
    '        SpeakingLabel.Speak(Me.lblPayItemDesc.Text)
    '    End Using


    '    'Using textToSpeech As New SpeechSynthesizer
    '    '    textToSpeech.Speak(Me.txtSignCode.Text)
    '    'End Using


    '**********************************


    ''' <summary>
    ''' method for determining is the user provided a valid email address
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

    '**********************************


    Private Sub IterateDictionary()

        ''  Iterate through Dictionary Object
        'For Each kvp As KeyValuePair(Of Double, String) In dctUpdatedList
        '    Dim v1 As Double = kvp.Key
        '    Dim v2 As String = kvp.Value

        '    '' Create list of the Values of the Dictionary (Daily Production ID ("Autonum"), in this case)
        '    'Dim lstFSSPTKeys As New List(Of Double)(dctUpdatedList.Keys)

        '    recCount += 1





        '    'Debug.WriteLine("Key: " + v1.ToString _
        '    '       + " Value: " + v2)


        'Next

    End Sub






    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'signINMain1.StatusStrip.Text = "User:  " & My.Settings.userName

        '' Connection to db1.mdb
		'Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

        '' MHS Jobs
        'Dim fsDA As OleDbDataAdapter
        'Dim fsDS As DataSet
        'Dim fsDV As DataView
        'Dim fsDT As DataTable

        'fsDA = New OleDbDataAdapter("SELECT mhsJob, station, code FROM PlywoodTOF WHERE mhsJob = '09-76' ORDER By station", mhsConn)

        '' Initialize a new instance of the DataSet object
        'fsDS = New DataSet()

        '' Open the connection, execute the command
        'mhsConn.Open()

        '' Fill DataSet
        'fsDA.Fill(fsDS, "PlywoodTOF")

        '' Close the connection
        'mhsConn.Close()

        '' Set the DataView object to the DataSet object
        'fsDV = New DataView(fsDS.Tables("PlywoodTOF"))

        'fsDT = fsDS.Tables(0)




        ' '' Clear DataBinding
        ''Me.DataRepeater1.Controls("TextBox1").DataBindings.Clear()
        ''Me.DataRepeater1.Controls("TextBox2").DataBindings.Clear()

        ' '' Add DataBinding
        ''Me.DataRepeater1.Controls("TextBox1").DataBindings.Add("Text", fsDT, "station")
        ''Me.DataRepeater1.Controls("TextBox2").DataBindings.Add("Text", fsDT, "signCode")

        'Me.DataRepeater1.DataSource = fsDT






    End Sub

    

    
End Class
