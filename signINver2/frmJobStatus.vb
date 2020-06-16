Option Strict On
Option Explicit On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources




Public Class frmJobStatus




#Region " Class-Level Declarations"






#End Region


#Region " Database Communication"

    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' MHS Jobs List (materialsinventory.mdb/qryJobStatusPopUp)
    Dim jobStatusDA As OleDbDataAdapter
    Dim jobStatusDS As DataSet
    Dim jobStatusDT As DataTable



#End Region



#Region " Functions and Methods"


    Public Sub FillDGV()

        Try

            Dim jobStatusCMD As New OleDbCommand("[qryJobStatusPopUp]", mhsConn)
            jobStatusCMD.CommandType = CommandType.StoredProcedure

            ' Open connection to Db
            mhsConn.Open()

            '  Fill dataAdapter with query result from Db
            jobStatusDA = New OleDbDataAdapter(jobStatusCMD)



            ' Initialize a new instance of the DataSet object
            jobStatusDS = New DataSet()

            ' Fill the DataSet object with Data
            jobStatusDA.Fill(jobStatusDS, "[qryJobStatusPopUp]")


            ' DataTable -   Fill the DataTable object with data
            jobStatusDT = jobStatusDS.Tables("[qryJobStatusPopUp]")

            With Me.dgvJobStatus

                .DataSource = jobStatusDT

                .Columns(1).Visible = False
                .Columns(3).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False



            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "FillDGV()")


        Finally

            mhsConn.Close()

        End Try




    End Sub


    Private Sub HighlightCompDate()

        Try

            For Each r As DataGridViewRow In dgvJobStatus.Rows

                If Not r.Cells.Item(0).Value Is Nothing Then  'if the cell is Not empty continue      

                    Dim cellDate As Date = CDate(r.Cells.Item(0).Value)
                    'then check if the celldate is less than today.  

                    Select Case cellDate

                        Case Is < Date.Today

                            r.Cells.Item(0).Style.BackColor = Color.Red
                            r.Cells.Item(0).Style.ForeColor = Color.White

                        Case Is < Date.Today.AddDays(90)


                            r.Cells.Item(0).Style.BackColor = Color.Green
                            r.Cells.Item(0).Style.ForeColor = Color.White

                    End Select
                    

                End If


            Next



        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try


    End Sub


#End Region



#Region " Event Handlers"



    Private Sub frmJobStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        FillDGV()



    End Sub


	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		HighlightCompDate()

	End Sub




#End Region














End Class