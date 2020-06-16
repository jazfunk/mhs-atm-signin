


Public Class frmCap


	'\\  This code controls the built-in webcam and can save an image


	'Create constant using attend in function of DLL file.

	Const CAP As Short = &H400S
	Const CAP_DRIVER_CONNECT As Integer = CAP + 10
	Const CAP_DRIVER_DISCONNECT As Integer = CAP + 11
	Const CAP_EDIT_COPY As Integer = CAP + 30
	Const CAP_SET_PREVIEW As Integer = CAP + 50
	Const CAP_SET_PREVIEWRATE As Integer = CAP + 52
	Const CAP_SET_SCALE As Integer = CAP + 53
	Const WS_CHILD As Integer = &H40000000
	Const WS_VISIBLE As Integer = &H10000000
	Const SWP_NOMOVE As Short = &H2S
	Const SWP_NOSIZE As Short = 1
	Const SWP_NOZORDER As Short = &H4S
	Const HWND_BOTTOM As Short = 1

	Dim iDevice As Integer = 0 ' Normal device ID
	Dim hHwnd As Integer ' Handle value to preview window

	' Declare function from AVI capture DLL.

	Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
	(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
	ByVal lParam As Object) As Integer

	Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
	ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
	ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

	Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

	Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
	(ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
	ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
	ByVal nHeight As Short, ByVal hWndParent As Integer, _
	ByVal nID As Integer) As Integer


	Private Sub OpenForm()
		Dim iHeight As Integer = picCapture.Height
		Dim iWidth As Integer = picCapture.Width

		' Open Preview window in picturebox .
		' Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.

		hHwnd = capCreateCaptureWindowA(CStr(iDevice), WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
		480, picCapture.Handle.ToInt32, 0)
		' Connect to device
		If CBool(SendMessage(hHwnd, CAP_DRIVER_CONNECT, iDevice, 0)) Then

			' Set the preview scale
			SendMessage(hHwnd, CAP_SET_SCALE, CInt(True), 0)

			' Set the preview rate in milliseconds
			SendMessage(hHwnd, CAP_SET_PREVIEWRATE, 66, 0)

			' Start previewing the image from the camera
			SendMessage(hHwnd, CAP_SET_PREVIEW, CInt(True), 0)

			' Resize window to fit in picturebox
			SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, _
			SWP_NOMOVE Or SWP_NOZORDER)
		Else
			' Error connecting to device close window
			DestroyWindow(hHwnd)

		End If
	End Sub

	' Use SendMessage to copy the data to the clipboard Then transfer the image to the picture box.

	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		Dim data As IDataObject
		Dim bmap As Image
		' Copy image to clipboard
		SendMessage(hHwnd, CAP_EDIT_COPY, 0, 0)

		' Get image from clipboard and convert it to a bitmap
		data = Clipboard.GetDataObject()
		If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
			bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
			picCapture.Image = bmap

			Dim saveFileDialog1 As New SaveFileDialog()
			saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
			saveFileDialog1.Title = "Save an Image File"
			saveFileDialog1.FileName = "Image001"
			saveFileDialog1.ShowDialog()

			' If the file name is not an empty string open it for saving.
			If saveFileDialog1.FileName <> "" Then
				' Saves the Image via a FileStream created by the OpenFile method.
				Dim fs As System.IO.FileStream = CType _
				(saveFileDialog1.OpenFile(), System.IO.FileStream)
				picCapture.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
				fs.Close()
			End If

		End If
	End Sub

	Private Sub frmcap_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
		' Disconnect from device
		SendMessage(hHwnd, CAP_DRIVER_DISCONNECT, iDevice, 0)
		' close window
		DestroyWindow(hHwnd)
	End Sub


	Private Sub frmCap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		OpenForm()
	End Sub
End Class