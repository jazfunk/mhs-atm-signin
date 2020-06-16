



Public Class dlgAddCert


	Private _rathcoSalesOrder As String
	Public Property rathcoSalesOrder() As String
		Get
			Return _rathcoSalesOrder
		End Get
		Set(ByVal value As String)
			_rathcoSalesOrder = value
		End Set
	End Property


	Private _mhsPO As String
	Public Property mhsPO() As String
		Get
			Return _mhsPO
		End Get
		Set(ByVal value As String)
			_mhsPO = value
		End Set
	End Property


	Private _requestDate As String
	Public Property requestDate() As String
		Get
			Return _requestDate
		End Get
		Set(ByVal value As String)
			_requestDate = value
		End Set
	End Property


	Private _rathcoInvoice As String
	Public Property rathcoInvoice() As String
		Get
			Return _rathcoInvoice
		End Get
		Set(ByVal value As String)
			_rathcoInvoice = value
		End Set
	End Property


	Private _rcvDate As String
	Public Property rcvDate() As String
		Get
			Return _rcvDate
		End Get
		Set(ByVal value As String)
			_rcvDate = value
		End Set
	End Property







	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click


		Me.rathcoSalesOrder = Me.txtRathcoSalesOrder.Text
		Me.mhsPO = Me.txtPO.Text
		Me.requestDate = Me.txtRequestDate.Text
		Me.rathcoInvoice = Me.txtRathcoInvoice.Text
		Me.rcvDate = Me.txtReceiveDate.Text

		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()


	End Sub


	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()


	End Sub
End Class