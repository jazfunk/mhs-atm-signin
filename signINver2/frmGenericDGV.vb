Option Strict On
Option Explicit On



Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.clsUtilities



Public Class frmGenericDGV


	Public Sub New(ByVal dv As DataView)

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.


        Me._data_View = dv
        Me.Text = Me._data_View.Table.TableName



	End Sub


	Private _data_View As DataView
	Public Property Data_View() As DataView
		Get
			Return _data_View
		End Get
		Set(ByVal value As DataView)
			_data_View = value
		End Set
	End Property



	Private Sub frmGenericDGV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dgvSignList.DataSource = Me.Data_View


	End Sub
End Class