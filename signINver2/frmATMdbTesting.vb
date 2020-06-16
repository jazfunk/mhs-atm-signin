Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports signINver2.My.Resources




Public Class frmATMdbTesting


#Region " Class-level declarations"

	Private _atmJob As String

	Dim jobList As New List(Of String)


#End Region



#Region " Database Communication"

	' Connection to Action Traffic.mdb
	Dim ATMconn1 As New OleDbConnection(My.Settings.ATMconn)

	' Jobs List
	Dim atmJobDA As OleDbDataAdapter
	Dim atmJobDS As DataSet
	Dim atmJobDT As DataTable

	' Daily Productions
	Dim productionDA As OleDbDataAdapter
	Dim productionDS As DataSet
	Dim productionDT As DataTable


#End Region

#Region " Properties"


	Public Property AtmJob() As String
		Get
			Return _atmJob
		End Get
		Set(ByVal value As String)
			_atmJob = value
		End Set
	End Property



#End Region



#Region " Methods & Functions"

	Private Sub LoadActiveATMJobs()

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

			' Fill DataTable
			atmJobDT = atmJobDS.Tables("atmJL")

			With Me.ComboBox1
				.DataSource = atmJobDT
				.ValueMember = "jn"
			End With

		
			'  Close the connection
			ATMconn1.Close()

		Catch ex As Exception
			MessageBox.Show(ex.Message, "LoadActiveATMJobs()")

		End Try

	End Sub

	Private Sub LoadProduction()

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
			  "ORDER By [Daily Production].[Autonum]", ATMconn1)

			'"WHERE ((([Daily Production].[JOB #])=@atmJob)) ORDER By [Daily Production].[Autonum]", ATMconn1)

			'cmdProduction.Parameters.AddWithValue("@atmJob", Me.AtmJob)

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

			' DataTable -   Fill the DataTable object with data
			productionDT = productionDS.Tables("Daily Production")


			With Me.ComboBox2
				.DataSource = productionDT
				.ValueMember = "site"
			End With


		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateProduction()")

		End Try

	End Sub

	Private Function FindJob(ByVal dv As DataView, ByVal startDate As Date) As Boolean

		' Iterate through Production DataTable record until 
		' date requirements are met, then return true.
		' If no records meet date requirements return false

		Dim x As Date = Nothing
		Dim isJob As Boolean = False

		For Each row As DataRowView In dv
			Dim t As String = row.Item(7).ToString
			If Date.TryParse(t, x) Then
				If x < startDate Then
					isJob = False
				Else
					isJob = True
				End If
			End If
		Next

		Return isJob

	End Function


	Private Sub IterateProductions()

		Dim jnum As String = Nothing
		Dim startDate As Date = #1/1/2011#
		Dim newDV As DataView = productionDT.DefaultView

		For Each row As DataRow In Me.atmJobDT.Rows
			jnum = row.Item(0).ToString
			newDV.RowFilter = "[JOB #] = '" & jnum & "'"
			If FindJob(newDV, startDate) Then
				Me.jobList.Add(jnum)
			End If
		Next

		Me.ListBox1.DataSource = Me.jobList

	End Sub

#End Region



#Region " Event Handlers"

	Private Sub frmATMdbTesting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		LoadActiveATMJobs()
		LoadProduction()

	End Sub


#End Region



	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

		IterateProductions()


	End Sub
End Class