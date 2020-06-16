Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.clsUtilities




'Select Case Me.ListType
'	Case "btnJobList"
'	Case "btnSignType"
'	Case "btnStationList"
'	Case "btnStandard"
'	Case "btnSignTech"
'	Case "bttnBuildDate"
'	Case "btnPic"
'End Select

'With Me.dgvGenericList
'						.Columns(0).Visible = False	' ID
'						.Columns(1).Visible = True	' mhsJob
'						.Columns(2).Visible = False
'						.Columns(3).Visible = False
'						.Columns(4).Visible = False
'						.Columns(5).Visible = False	' jobDesc
'						.Columns(6).Visible = False
'						.Columns(7).Visible = False
'						.Columns(8).Visible = False
'						.Columns(9).Visible = False
'						.Columns(10).Visible = False
'						.Columns(11).Visible = False
'						.Columns(12).Visible = False
'						.Columns(13).Visible = False
'						.Columns(14).Visible = False
'						.Columns(15).Visible = False
'					End With






Public Class frmDGV_SignCheck

	''' <summary>
	''' Send a DataView and a String to populate
	''' </summary>
	''' <param name="dv">Any DataView</param>
	''' <param name="lt">List Type:  Jobs, Stations, Codes, Techs,etc.</param>
	''' <remarks></remarks>
	Public Sub New(ByVal dv As DataView, ByVal lt As String)

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me._data_View = dv
		Me._listType = lt

	End Sub


#Region " Props"


	Private _listType As String
	Public Property ListType() As String
		Get
			Return _listType
		End Get
		Set(ByVal value As String)
			_listType = value
		End Set
	End Property


	Private _data_View As DataView
	Public Property Data_View() As DataView
		Get
			Return _data_View
		End Get
		Set(ByVal value As DataView)
			_data_View = value
		End Set
	End Property


	Private _mhsJob As String
	Public Property MhsJob() As String
		Get
			Return _mhsJob
		End Get
		Set(ByVal value As String)
			_mhsJob = value
		End Set
	End Property


	Private _signType As String
	Public Property SignType() As String
		Get
			Return _signType
		End Get
		Set(ByVal value As String)
			_signType = value
		End Set
	End Property


	Private _station As String
	Public Property Station() As String
		Get
			Return _station
		End Get
		Set(ByVal value As String)
			_station = value
		End Set
	End Property



	Private _signCode As String
	Public Property SignCode() As String
		Get
			Return _signCode
		End Get
		Set(ByVal value As String)
			_signCode = value
		End Set
	End Property



	Private _signCodeCount As Integer
	Public Property SignCodeCount() As Integer
		Get
			Return _signCodeCount
		End Get
		Set(ByVal value As Integer)
			_signCodeCount = value
		End Set
	End Property




	Private _legendDetails As String
	Public Property LegendDetails() As String
		Get
			Return _legendDetails
		End Get
		Set(ByVal value As String)
			_legendDetails = value
		End Set
	End Property



	Private _signWidth As String
	Public Property SignWidth() As String
		Get
			Return _signWidth
		End Get
		Set(ByVal value As String)
			_signWidth = value
		End Set
	End Property



	Private _signHeight As String
	Public Property SignHeight() As String
		Get
			Return _signHeight
		End Get
		Set(ByVal value As String)
			_signHeight = value
		End Set
	End Property



	Private _sheeting As String
	Public Property Sheeting() As String
		Get
			Return _sheeting
		End Get
		Set(ByVal value As String)
			_sheeting = value
		End Set
	End Property



	Private _signTech As String
	Public Property SignTech() As String
		Get
			Return _signTech
		End Get
		Set(ByVal value As String)
			_signTech = value
		End Set
	End Property



	Private _buildDate As Date
	Public Property BuildDate() As Date
		Get
			Return _buildDate
		End Get
		Set(ByVal value As Date)
			_buildDate = value
		End Set
	End Property



	Private _signImage As String
	Public Property SignImage() As String
		Get
			Return _signImage
		End Get
		Set(ByVal value As String)
			_signImage = value
		End Set
	End Property


	Private _signID As Integer
	Public Property SignID() As Integer
		Get
			Return _signID
		End Get
		Set(ByVal value As Integer)
			_signID = value
		End Set
	End Property




#End Region



#Region " Methods & Functions"



	Private Sub determineListType()

		Try
			Select Case Me.ListType

				Case "btnJobList"
					'hide the following columns
					Me.SuspendLayout()
					For Each col As DataGridViewColumn In dgvGenericList.Columns
						If col.Name = "mhsJob" Then
							col.Visible = True
						Else
							col.Visible = False
						End If
					Next
					Me.ResumeLayout()


				Case "btnSignType"
					With Me.dgvGenericList
						.Columns.Add("SignType", "Type")
						.Columns.Add("intType", "IntType")
						.Rows.Add(New String() {"Extruded", "1"})
						.Rows.Add(New String() {"Plywood", "2"})
						.Rows.Add(New String() {"FlatSheet .080", "3"})
						.Rows.Add(New String() {"FlatSheet .063", "4"})
						.Rows.Add(New String() {"FlatSheet .125", "5"})
					End With


				Case "btnStationList"
					'hide the following columns
					Me.SuspendLayout()
					For Each col As DataGridViewColumn In dgvGenericList.Columns
						If col.Name = "station" Or col.Name = "code" Or col.Name = "details" Then
							col.Visible = True
						Else
							col.Visible = False
						End If
					Next
					Me.ResumeLayout()

				Case "btnSignTech"
					'hide the following columns
					Me.SuspendLayout()
					For Each col As DataGridViewColumn In dgvGenericList.Columns
						If col.Name = "userName" Or col.Name = "userID" Then
							col.Visible = True
						Else
							col.Visible = False
						End If
					Next
					Me.ResumeLayout()


				Case "btnBuildDate"
					Me.dgvGenericList.Visible = False
					With Me.dtpBuildDate
						.Visible = True
						.Value = Now
					End With


				Case "btnStandard"

					' Hide all columns but code, count
					Me.SuspendLayout()
					For Each c As DataGridViewColumn In Me.dgvGenericList.Columns
						If c.Name = "code" Or c.Name = "Count" Then
							c.Visible = True
						Else
							c.Visible = False
						End If
					Next
					Me.ResumeLayout()


				Case "btnStandard_2"

					' Hide all columns but station, code, width and height
					Me.SuspendLayout()
					For Each c As DataGridViewColumn In Me.dgvGenericList.Columns
						If c.Name = "station" Or c.Name = "code" Or c.Name = "width" Or c.Name = "height" Then
							c.Visible = True
						Else
							c.Visible = False
						End If
					Next
					Me.ResumeLayout()


				Case "btnPic"

					' Still developing picture taking capabilities


				Case "btnStationStatus"

					' Hide all columns but 
					Me.SuspendLayout()
					For Each c As DataGridViewColumn In Me.dgvGenericList.Columns
						If c.Name = "mhsJob" Or c.Name = "type" Or c.Name = "StationID" Or c.Name = "BuildDate" Or c.Name = "SignTech" Then
							c.Visible = True
						Else
							c.Visible = False
						End If
					Next
					Me.ResumeLayout()

			End Select

			' Display Data in Title Bar
			Me.Text = Me.MhsJob & "/" & Me.SignType & "/" & Me.Station & "/" & Me.SignTech & "/"


		Catch ex As Exception

		End Try



	End Sub



#End Region



#Region " Event Handlers"


	Private Sub frmDGV_SignCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		If Me.Data_View IsNot Nothing Then Me.dgvGenericList.DataSource = Me.Data_View

		determineListType()


	End Sub

	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

		If Me.dtpBuildDate.Visible Then
			Me._buildDate = Me.dtpBuildDate.Value
		End If

		' Close form and return OK to calling form
		Me.DialogResult = Windows.Forms.DialogResult.OK






	End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

		' Close form and return Cancel to calling form
		Me.DialogResult = Windows.Forms.DialogResult.Cancel

	End Sub

	Private Sub dgvGenericList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvGenericList.SelectionChanged

		Try
			Select Case Me.ListType
				Case "btnJobList"
					Me._mhsJob = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("mhsJob").Value)
					
				Case "btnSignType"
					Me._signType = CStr(Me.dgvGenericList.CurrentRow.Cells.Item(0).Value)
					
				Case "btnStationList"
					Me._signID = CInt(Me.dgvGenericList.CurrentRow.Cells.Item("ID").Value)
					Me._mhsJob = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("mhsJob").Value)
					Me._signType = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("type").Value)
					Me._station = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("station").Value)
					Me._signCode = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("code").Value)
					If Me.dgvGenericList.CurrentRow.Cells.Item("details").Value IsNot DBNull.Value Then
						Me._legendDetails = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("details").Value)
					End If
					If Me.dgvGenericList.CurrentRow.Cells.Item("width").Value IsNot DBNull.Value Then
						Me._signWidth = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("width").Value)
					End If
					If Me.dgvGenericList.CurrentRow.Cells.Item("height").Value IsNot DBNull.Value Then
						Me._signHeight = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("height").Value)
					End If
					Me._sheeting = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("sheeting").Value)

				Case "btnSignTech"
					Me._signTech = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("userName").Value)

				Case "btnBuildDate"
					' Not related as the DataGridView is hidden with the BuildDate selection active.

				Case "btnStandard"
					Me._signCode = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("code").Value)
					Me._signCodeCount = CInt(Me.dgvGenericList.CurrentRow.Cells.Item("Count").Value)

				Case "btnStandard_2"
					Me._signID = CInt(Me.dgvGenericList.CurrentRow.Cells.Item("ID").Value)
					Me._mhsJob = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("mhsJob").Value)
					Me._signType = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("type").Value)
					Me._station = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("station").Value)
					Me._signCode = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("code").Value)
					If Me.dgvGenericList.CurrentRow.Cells.Item("details").Value IsNot DBNull.Value Then
						Me._legendDetails = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("details").Value)
					End If
					If Me.dgvGenericList.CurrentRow.Cells.Item("width").Value IsNot DBNull.Value Then
						Me._signWidth = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("width").Value)
					End If
					If Me.dgvGenericList.CurrentRow.Cells.Item("height").Value IsNot DBNull.Value Then
						Me._signHeight = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("height").Value)
					End If
					Me._sheeting = CStr(Me.dgvGenericList.CurrentRow.Cells.Item("sheeting").Value)


				Case "btnPic"


			End Select




		Catch ex As Exception
			MessageBox.Show(ex.Message, "dgvSelectionChanged")

		End Try

	End Sub







#End Region






End Class