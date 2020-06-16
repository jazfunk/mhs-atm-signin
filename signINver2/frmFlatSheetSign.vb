Option Strict Off

Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing
Imports signINver2.My.Resources



Public Class frmFlatSheetSign


    Public Sub New(ByVal aryJobInfo As Array, ByVal arySignInfo As Array)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.mhsJob = aryJobInfo(0)
        Me.jobDesc = aryJobInfo(1)
        Me.projNum = aryJobInfo(2)
        Me.jobNum = aryJobInfo(3)

        Me.station = arySignInfo(0)
        Me.signCode = arySignInfo(1)
        Me.signDetails = arySignInfo(2)
        Me.signWidth = arySignInfo(3)
        Me.signHeight = arySignInfo(4)


    End Sub


    Dim mhsJob As String
    Dim jobDesc As String
    Dim projNum As String
    Dim jobNum As String
    Dim station As String
    Dim signCode As String
    Dim signDetails As String
    Dim signWidth As String
    Dim signHeight As String


    Private Sub frmFlatSheetSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class