Option Strict On


Public Class frmViewPDF

    Dim pdfFile As String
    Dim signCode As String
    Dim signDesc As String



    Public Sub New(ByVal sC As String, ByVal sCode As String, ByVal sD As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        pdfFile = sC.Trim
        signCode = sCode.Trim
        signDesc = sD.Trim

    End Sub


    Private Sub frmViewPDF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		' Disabled due to no 64 bit adobe object browser available 
		' Moving sIv2 to new computer and this is no longer an option.
		'AxAcroPDF1.src = "C:\sIv2\SignsSpecsAll\" & pdfFile

        If signDesc = String.Empty Then
            Me.Text = signCode & "  -  Sign Specification"
        Else
            Me.Text = signCode & " (" & signDesc & ")  -" & "  Sign Specification"
        End If

    End Sub














End Class