Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources



Public Class frmHome



#Region " Class-level variables"







#End Region


#Region " Database Communication"

    ' Connection to db1.mdb
	Dim mhsConn As New OleDbConnection(My.Settings.SignINconn)

    ' MHS Jobs
    Dim mhsJobDA As OleDbDataAdapter
    Dim mhsJobDS As DataSet
	Dim mhsJobDT As DataTable

	' Connection to Action Traffic.mdb
	Dim atmConn1 As New OleDbConnection(My.Settings.ATMconn)






#End Region



#Region " Functions & Methods"


	Public Sub ToggleHomeForm()

		Select Case Me.Visible
			Case True
				Me.WindowState = FormWindowState.Minimized
				Me.Visible = False

			Case False
				Me.Visible = True
				Me.WindowState = FormWindowState.Maximized
		End Select

	End Sub

	Public Sub TestingQRCode()

		'fn: virtually unique file name based on date and time
		Dim fn As String = "QR_" & String.Format("{0:MMddyyhhmmss}", DateTime.Now()) & ".png"
		Dim txt As String = Me.txtQRCodeResult.Text

		Try
			Dim client As New System.Net.WebClient
			client.DownloadFile("http://chart.apis.google.com/chart?cht=qr&chs=300x300&chl=" & txt, "c:\sIv2\" & fn)
			client = Nothing
		Catch
		End Try

		'Display resulting filePath
		Me.txtQRCodeResult.Text = "c:\sIv2\" & fn

		'Display QR Code Image
		With Me.picQRCode
			.SizeMode = PictureBoxSizeMode.CenterImage
			.Load(Me.txtQRCodeResult.Text)
		End With
		

	End Sub


#End Region



#Region " Event Procedures"

    Private Sub frmHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.vsTabMain.SelectedTabPage = sTabHome


    End Sub

    Private Sub frmHome_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        'Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

		'ToggleHomeForm()
		TestingQRCode()


    End Sub

    Private Sub frmHome_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

        'Select Case Me.WindowState

        '    Case FormWindowState.Maximized

        '        signINMain1.tsbHome.Enabled = False

        '    Case FormWindowState.Minimized

        '        signINMain1.tsbHome.Enabled = True

        'End Select

    End Sub

    Private Sub frmHome_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

        'Select Case Me.Visible

        '    Case True

        '        signINMain1.tsbHome.Enabled = False

        '    Case False

        '        signINMain1.tsbHome.Enabled = True


        'End Select


    End Sub

    Private Sub vsTabMain_SelectedTabChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vsTabMain.SelectedTabChanged

        Try
            Dim thisTab As VisualStudiosTabControl
            thisTab = CType(sender, VisualStudiosTabControl)

            Me.Text = thisTab.SelectedTabPage.Text

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

#End Region









End Class