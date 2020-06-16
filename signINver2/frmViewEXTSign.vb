Option Strict On


Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources







Public Class frmViewEXTSign




    Public Sub New(ByVal sI As Integer)


        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

       
        sIdentity = sI



    End Sub

    Public Property SignID() As Integer
        Get
            Return sIdentity

        End Get
        Set(ByVal value As Integer)
            sIdentity = value
        End Set
    End Property


    Dim sIdentity As Integer












    
    Private Sub frmViewEXTSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.TextBox1.Text = Me.SignID.ToString


    End Sub
End Class