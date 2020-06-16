Option Strict On
Option Explicit On

Imports System.IO
Imports System.Xml.Serialization
Imports System.Data.OleDb

Imports System.Text
Imports System.Security.Cryptography
Imports System.IO.Ports
Imports System.Net




Public Class clsUtilities



#Region " Various String Path Reference"


	' atmConnStr
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\Action\Action Traffic.mdb
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\Action Traffic.mdb
	'**********************************

	' connStr01
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\MHS Pre Production\signIN\db1.mdb
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\db1.mdb
	'**********************************

	' connStrMHS01
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\Michigan Highway\MHS Database.mdb		' 
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\MHS Database.mdb
	'**********************************

	' securedConnStr
	'Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=j0hns0n; Data Source=\\attermserv01\company data\MHS Pre Production\signIN\secured.mdb;Persist Security Info=False
	'Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=j0hns0n; Data Source=c:\sIv2\secured.mdb;Persist Security Info=False
	'**********************************

	' inventoryConnStr01
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\attermserv01\company data\MHS Pre Production\signIN\materialsInventory.mdb
	'Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\sIv2\materialsInventory.mdb
	'**********************************

	' imgPath
	'\\attermserv01\company data\MHS Pre Production\signIN\signImages\
	'c:\sIv2\signImages\
	'**********************************

	' jobsDirectory
	'\\attermserv01\company data\MHS Pre Production\Jobs\
	'c:\sIv2\Jobs\



#End Region



	''' <summary>
	''' Determine/Set Default My.Settings
	''' </summary>
	''' <remarks></remarks>
	Public Shared Sub InitializeMySettings()


		'''''''''' Detect Environment ''''''''''

        If My.Computer.Name = "KINGMOFO2017" Then
            My.Settings.serverPresent = False
        Else
            My.Settings.serverPresent = True
        End If


		'''''''''' Database Connections ''''''''''

		Select Case My.Settings.serverPresent
			Case True
				My.Settings.ATMconn = My.Settings.atmConStrLocal
				My.Settings.SignINconn = My.Settings.conStrLocal
				My.Settings.MHSconn = My.Settings.mhsConStrLocal
				My.Settings.SECconn = My.Settings.secConStrLocal
				My.Settings.INVconn = My.Settings.inventoryConStrLocal

				'  Change this to display icon or message in the 
				'  status bar
				signINMain1.tsbStatusLabelRight.Text = "(Connected to Server)"

			Case Else

				My.Settings.ATMconn = My.Settings.atmConStrRemote
				My.Settings.SignINconn = My.Settings.conStrRemote
				My.Settings.MHSconn = My.Settings.mhsConStrRemote
				My.Settings.SECconn = My.Settings.secConStrRemote
				My.Settings.INVconn = My.Settings.inventoryConStrRemote

				'  Change this to display icon or message in the 
				'  status bar
				signINMain1.tsbStatusLabelRight.Text = "(<---DEVELOPER MODE--->)"

		End Select






		'''''''''' Extruded - Type I Settings ''''''''''

		My.Settings.maxExtWidth = 45




		'''''''''' Plywood - Type II Settings ''''''''''






		'''''''''' FlatSheet - Type III Settings ''''''''''








	End Sub



	''' <summary>
	''' Displays a visual representation of the current
	''' Color Selected based on 3M Sheeting Codes
	''' </summary>
	''' <param name="sheetingCode">3M Sheeting Code eg: 3930, 3937, 3990, etc.</param>
	''' <returns>A Color Object (Structure)</returns>
	''' <remarks></remarks>
	Public Shared Function VisualSheetingColor(ByVal sheetingCode As String) As Color

		Dim objColor As Color = Nothing

		Try
			Select Case sheetingCode
				Case "3930", "3990", "4090"
					objColor = Color.White
				Case "3932"
					objColor = Color.Red
				Case "3935"
					objColor = Color.Blue
				Case "3937"
					objColor = Color.Green
				Case "3939"
					objColor = Color.Brown
				Case "3981"
					objColor = Color.Yellow
				Case Else
					objColor = Color.Transparent
			End Select

		Catch ex As Exception
			objColor = Color.Gray

		End Try

		Return objColor

	End Function



	''' <summary>
	''' This method was developed to solve the TypeCasting issues, using only Generics, when dealing
	''' with DBNull, Nothing, String.Empty, "".  
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <param name="Value">The Object to be checked and expected to be of T</param>
	''' <param name="DefaultValue">If Object fails TypeCasting, force the use of this value.</param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Shared Function NotNull(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
		If Value Is Nothing OrElse IsDBNull(Value) Then
			Return DefaultValue
		Else
			Return Value
		End If
	End Function



	''' <summary>
	''' Rounds the given decimal to the given digits
	''' </summary>
	''' <param name="Argument">Decimal to be rounded</param>
	''' <param name="Digits">Number of decimal places to round to</param>
	''' <returns>A Decimal rounded to nearest given digits</returns>
	''' <remarks></remarks>
	Public Shared Function ShowDecimalRound(ByVal Argument As Decimal, ByVal Digits As Integer) As Double

		Try
			Dim rounded As Decimal = Decimal.Round(Argument, Digits)
			Return rounded

		Catch ex As Exception

		End Try

	End Function


	''' <summary>
	''' Reads an XML file and returns a DataSet base on the XML Schema
	''' </summary>
	''' <param name="DataSyncToClean">Path to XML file</param>
	''' <returns>DataSet representing data from XML file</returns>
	''' <remarks></remarks>
	Public Shared Function ReadDataSyncToDataSet(ByVal DataSyncToClean As String) As DataSet
		' Function returns a DataSet based on xml file provided
		Dim cleanDS As DataSet
		Try
			cleanDS = New DataSet(Path.GetFileName(DataSyncToClean))
			cleanDS.ReadXml(DataSyncToClean)
		Catch ex As Exception
			cleanDS = Nothing
		End Try
		Return cleanDS
	End Function





	Private Structure fraction
		Dim numerator As Integer
		Dim denominator As Integer
		Public Overrides Function ToString() As String
			Return String.Format("{0}/{1}", Me.numerator, Me.denominator)
		End Function
	End Structure

	'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
	'	MsgBox(findFraction(0.375D).ToString) '3/8
	'End Sub

	Private Function findFraction(ByVal input As Decimal) As fraction

		Dim n As Integer = 1
		Do While n / input Mod 1 <> 0
			n += 1
		Loop

		Dim d As Integer = CInt(n / input)

		Dim f As New fraction
		f.numerator = n
		f.denominator = d

		Return f

	End Function




End Class
