
Option Strict On

Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports signINver2.My.Resources
Imports System.Speech.Synthesis
Imports System.Collections.ObjectModel




Public Class frmDailyProductions


    Public Sub New(ByVal atmJN As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.atmJob = atmJN


    End Sub



#Region " Database Communication"

    '  (Action Traffic.mdb) connection
	'Dim ATMconn As New OleDbConnection(atmConnStr01)
	Dim ATMconn As New OleDbConnection(My.Settings.ATMconn)

    '  (db1.mdb) connection
	'Dim db1Conn As New OleDbConnection(connStr01)
	Dim db1Conn As New OleDbConnection(My.Settings.SignINconn)


    Dim dpDA As OleDbDataAdapter
    Dim dpDS As DataSet
    Dim dpDV As DataView
    Dim dpDT As DataTable



#End Region


#Region " Class-level variables"

    Dim atmJob As String




#End Region


#Region " Methods & Functions"


    Private Sub GetDailyProductions()

        Try

            Dim dpCmd As OleDbCommand = New OleDbCommand _
                         ("SELECT [Daily Productions].[JOB #], " & _
                          "[Daily Productions].[Site], " & _
                          "[Daily Productions].[PayItemID], " & _
                          "[PAY ITEM PICK LIST].[PayItemID], " & _
                          "[PAY ITEM PICK LIST].[CODE], " & _
                          "[PAY ITEM PICK LIST].[DESCRIPTION], " & _
                          "[Daily Productions].[Sign Code], " & _
                          "[Daily Productions].[Contract Qty], " & _
                          "[PAY ITEM PICK LIST].[UNIT], " & _
                          "[Daily Productions].[Number of Supports], " & _
                          "[Daily Productions].[Support at this station], " & _
                          "[Daily Productions].[Sign Width], " & _
                          "[Daily Productions].[Sign Height], " & _
                          "[Daily Productions].[Station with Support], " & _
                          "[Daily Productions].[Contractor ID], " & _ 
						  "[Daily Productions].[Station A], " & _ 
						  "[Daily Productions].[Station B] " & _
                          "FROM [Daily Productions] " & _
                          "LEFT OUTER JOIN [PAY ITEM PICK LIST] " & _
                          "ON [Daily Productions].[PayItemID] = [PAY ITEM PICK LIST].[PayItemID] " & _
                          "WHERE [Daily Productions].[JOB #] = '" & Me.atmJob & "' " & _
                          "ORDER By [Daily Productions].[Site]", ATMconn)

            ' Open connection to Db
            ATMconn.Open()

            '  Fill dataAdapter with query result from Db
            dpDA = New OleDbDataAdapter(dpCmd)

            ' Instantiate DataSet object
            dpDS = New DataSet()

            ' Fill DataSet with data from dataAdapater
            dpDA.Fill(dpDS, "[Job Pay Items]")

            '  Close the connection
            ATMconn.Close()

            ' Set the Dataview object to the Dataset object
            dpDV = New DataView(dpDS.Tables("[Job Pay Items"))

            ' DataTable -   Fill the DataTable object with data
            dpDT = dpDS.Tables(0)




            ' Declare and set the alternating rows style
            Dim objAlternatingCellStyle As New DataGridViewCellStyle()
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke
            Me.dgvDailyProductions.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

            ' Declare and set the alignment property
            Dim objAlignMidcellStyle As New DataGridViewCellStyle()
            objAlignMidcellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Declare and set the alignment property
            Dim objAlignMidRightcellStyle As New DataGridViewCellStyle()
            objAlignMidRightcellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            ' Bind DGV and set properties
            With Me.dgvDailyProductions

                .DataSource = dpDT

                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Site"
                '.Columns(1).Width = 75

                .Columns(2).Visible = False
                .Columns(3).Visible = False

                .Columns(4).HeaderText = "PayItemID"
                .Columns(4).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(4).Width = 45

                .Columns(5).HeaderText = "Description"
                '.Columns(5).Width = 210

                .Columns(6).HeaderText = "Sign Code"
                '.Columns(6).Width = 35

                .Columns(7).HeaderText = "C-Qty"
                .Columns(7).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(7).Width = 25

                .Columns(8).HeaderText = "Unit"
                '.Columns(8).Width = 15

                .Columns(9).HeaderText = "#-Spts"
                .Columns(9).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(9).Width = 15

                .Columns(10).HeaderText = "Spt-Site"
                '.Columns(10).Width = 25

                .Columns(11).HeaderText = "Sign Width"
                .Columns(11).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(11).Width = 25

                .Columns(12).HeaderText = "Sign Height"
                .Columns(12).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(10).Width = 25

                .Columns(13).HeaderText = "Site W-Spt"
                '.Columns(13).Width = 75

                .Columns(14).HeaderText = "Cont"
                '.Columns(14).Width = 25

				.Columns(15).HeaderText = "A"

				.Columns(16).HeaderText = "B"




                '.Columns(3).DefaultCellStyle = objAlignMidRightcellStyle
                '.Columns(3).DefaultCellStyle.Font = New Font(dgvDailyProductions.Font, FontStyle.Bold)
                '.Columns(3).Width = 60

                '.Columns(4).HeaderText = "DESCRIPTION"
                '.Columns(4).Width = 210

                '.Columns(5).HeaderText = "UNIT"
                '.Columns(5).DefaultCellStyle = objAlignMidcellStyle
                '.Columns(5).Width = 50

            End With

            Me.Text = Me.Text & " - For " & Me.atmJob

        Catch ex As Exception
            MessageBox.Show(ex.Message, "GetDailyProductions()")
        End Try


    End Sub




#End Region


#Region " Event Handlers"

    Private Sub frmDailyProductions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetDailyProductions()




    End Sub




#End Region





End Class