Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.clsUtilities



Public Class frmVisiSelect



	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.



	End Sub

	Public Sub New(ByVal size As Integer)

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.VisiSize = size

	End Sub




	Private _visiSize As Integer
	Public Property VisiSize() As Integer
		Get
			Return _visiSize
		End Get
		Set(ByVal value As Integer)
			_visiSize = value
		End Set
	End Property



	Private _visiColor As String
	Public Property VisiColor() As String
		Get
			Return _visiColor
		End Get
		Set(ByVal value As String)
			_visiColor = value
		End Set
	End Property



	Private Sub frmVisiSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



	End Sub
End Class