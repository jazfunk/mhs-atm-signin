Option Strict On
Option Explicit On




Public Class frmGuardRailStations


	Private StationA_ As String
	Public Property StationA() As String
		Get
			Return StationA_
		End Get
		Set(ByVal value As String)
			StationA_ = value
		End Set
	End Property


	Private StationB_ As String
	Public Property StationB() As String
		Get
			Return StationB_
		End Get
		Set(ByVal value As String)
			StationB_ = value
		End Set
	End Property



	Private Sub frmGuardRailStations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Me.txtStationA.Select()

	End Sub

	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

		

		If Me.txtStationA.Text IsNot Nothing Then
			StationA_ = Me.txtStationA.Text
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Else
			MessageBox.Show("Please enter a value for Station A.", "Required Info Missing")
			Exit Sub
		End If

		If Me.txtStationB.Text IsNot Nothing Then
			StationB_ = Me.txtStationB.Text
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Else
			MessageBox.Show("Please enter a value for Station B.", "Required Info Missing")
			Exit Sub
		End If

		Me.Close()


	End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub
End Class