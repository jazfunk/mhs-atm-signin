Option Strict On

Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports signINver2.My.Resources
Imports signINver2.Wunnell.Windows.Forms
Imports signINver2.clsUtilities





Public Class signINMain1



#Region "Class-level declarations"

    Private m_ChildFormNumber As Integer

    Private filePath As String



#End Region


#Region " Subs & Functions"

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click

		'' Create a new instance of the child form.
		'Dim ChildForm As New System.Windows.Forms.Form
		'' Make it a child of this MDI form before showing it.
		'ChildForm.MdiParent = Me

		'm_ChildFormNumber += 1
		'ChildForm.Text = "Window " & m_ChildFormNumber

		'ChildForm.Show()
       

    End Sub




    Private Sub FileSave()
        'If Me.filePath Is Nothing Then
        '    Me.FileSaveAs()
        'Else
        '    Try
        '        IO.File.WriteAllText(Me.filePath, Me.TextBox1.Text)
        '    Catch ex As Exception
        '        Debug.WriteLine(ex.ToString())
        '        MessageBox.Show(ex.Message, "Save File Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub





    Private Sub FileSaveAs()
        'Using dialogue As New SaveFileDialog
        '    With dialogue
        '        .FileName = Me.filePath
        '        .Filter = "Text Files (*.txt)|*.txt|All Files|*.*"

        '        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            Me.filePath = dialogue.FileName
        '            Me.FileSave()
        '        End If
        '    End With
        'End Using
    End Sub






    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click

        '   \\Original, Designer created code

        'Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        'If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        '    Dim FileName As String = OpenFileDialog.FileName
        '    ' TODO: Add code here to open the file.
        'End If


        Using dialogue As New OpenFileDialog

            With dialogue

                .FileName = Me.filePath
                .Filter = "Text Files (*.txt)|*.txt|All Files|*.*"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then

                    Try

                    
                        'Me.TextBox1.Text = IO.File.ReadAllText(dialogue.FileName)
                        Me.filePath = dialogue.FileName
                    Catch ex As Exception
                        Debug.WriteLine(ex.ToString())
                        MessageBox.Show(ex.Message, "Open File Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End Try
                End If
            End With
        End Using

    End Sub

    Private Sub mhsJobsList(ByVal sender As Object, ByVal e As EventArgs) _
                Handles JobListingToolStripMenuItem.Click, _
                JobsListingToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Try

           
            Dim jobList As New frmMhsJobListViewAll
            jobList.MdiParent = Me
            jobList.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub addNewJob(ByVal sender As Object, ByVal e As EventArgs) _
                Handles NewJobToolStripMenuItem.Click, _
                NewJobToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Try

            Dim newJob As New frmJob
            newJob.MdiParent = Me
            newJob.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub showAboutBox(ByVal sender As Object, ByVal e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

       
        ' Display the About dialog box
        Using objAbout As New frmAboutBox1
            objAbout.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub showJobLog(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles JobLogToolStripMenuItem.Click, _
                    JobLogToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Dim objJobLog As New frmJobLog(signINver2.My.Settings.userID.ToString)
        objJobLog.MdiParent = Me
        objJobLog.Show()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub resetSettings()


        ' Me.tsbATMNewSite.Visible = True
        Me.tsbATMNewSite.Enabled = True
        Me.NewJobToolStripMenuItem.Enabled = True
        Me.EditTakeOffToolStripMenuItem.Enabled = True
        Me.NewRunToolStripMenuItem.Enabled = True
        Me.EditRunToolStripMenuItem.Enabled = True
        Me.EditTakeOffToolStripMenuItem1.Enabled = True
        Me.EditTakeOffToolStripMenuItem2.Enabled = True
        Me.LegendToolStripMenuItem.Enabled = True
        Me.ShippersToolStripDropDownButton.Enabled = True
        Me.ToolsMenu.Enabled = True
        Me.MenuStrip.Enabled = True

        Me.tsbStatusLabelRight.Image = Nothing

		'My.Settings.userID = Nothing
		'My.Settings.userName = Nothing
		'My.Settings.userSL = Nothing

		'My.Settings.loginDO = False

    End Sub

    Private Sub appLogin(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

			InitializeMySettings()


            Dim login As New LoginForm
            login.MdiParent = Me
            login.Show()


            'For Each ctl As Control In Me.Controls
            '    If TypeOf ctl Is MdiClient Then
            '        'Set properties of ctl here, e.g.  
            '        ctl.BackgroundImage = My.Resources.sIv2SplashScreen_1
            '        'ctl.BackgroundImageLayout.Stretch = 3


            '        Exit For
            '    End If
            'Next ctl

        Catch ex As Exception
            MessageBox.Show(ex.Message, "appLogin() Method")

        End Try



    End Sub

    Private Sub appLock(ByVal lock As Boolean)


        Select Case lock

            Case Is = True  ' lock

                Me.tsbUnlock.Visible = True
                Me.tsbStatusLabelRight.Text = "Locked by User:  " & My.Settings.userName

                For Each frm As Form In Me.MdiChildren
                    frm.Enabled = False
                    frm.WindowState = FormWindowState.Minimized
                Next

                Me.StatusStrip.Enabled = True
                Me.MenuStrip.Enabled = False


            Case Is = False  ' unlock

                For Each frm As Form In Me.MdiChildren
                    frm.Enabled = True
                    frm.WindowState = FormWindowState.Normal
                Next

                Me.tsbUnlock.Visible = False
                Me.MenuStrip.Enabled = True

                Me.tsbStatusLabelRight.Text = "User:  " & My.Settings.userName


        End Select

        

    End Sub

    Private Sub userLogOff(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffSignINToolStripMenuItem.Click

        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next

        

        ' This sub also handled by MyBase.FormClosing
        ' 'Nothing' Overloads must be sent
        userLogOffTime(Nothing, Nothing)

		'Me.tsbStatusLabelRight.Text = "You are now logged off"

        Dim login As New LoginForm
        login.MdiParent = Me
        login.Show()


        ' This triggers the MenuStrip_EnabledChanged sub
        ' and automatically disables Me.ToolStrip
        Me.MenuStrip.Enabled = False

    End Sub

    Private Sub userLogOffTime(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing

        If My.Settings.userName <> Nothing Then

            Try
				Using connection As New OleDbConnection(My.Settings.SECconn)
					Using command As New OleDbCommand("INSERT INTO tblUserLog (userID, userLogTime, logType) " & _
													  "VALUES (@userID, Now(), 0)", connection)
						command.Parameters.AddWithValue("@userID", My.Settings.userID)

						connection.Open()
						command.ExecuteNonQuery()

						resetSettings()

					End Using
				End Using
            Catch ex As Exception
				'MessageBox.Show(ex.Message)
            End Try

        End If

        

    End Sub

    Private Sub newShipper(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles AssignNewShipperToolStripMenuItem.Click, _
                    AssignNewShipperToolStripMenuItem1.Click

       
        Me.Cursor = Cursors.WaitCursor

        Dim assShipper As New frmNewShipper
        assShipper.MdiParent = Me
        assShipper.Show()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub finalizeShipper(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles FinalizeEditShipperToolStripMenuItem.Click, _
                        FinalizeEditShipperToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Dim shipperNum, prompt, title As String
        prompt = "Enter Shipper #."
        title = "View Shipper"
        shipperNum = InputBox(prompt, title)

        If shipperNum.Length = 4 Then
            Try

                Dim editShipper As New frmFinalizeShipper(CInt(shipperNum))
                editShipper.MdiParent = Me
                editShipper.Show()


            Catch ex As Exception
                MessageBox.Show("That shipper # does not exist in database.", "I do not compute!")
            End Try

        Else
            MessageBox.Show("That shipper # does not exist in database.", "I do not compute!")
        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub addShipperItems(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles EditViewShipperItemsToolStripMenuItem.Click, _
                            EditViewShiperItemsToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Dim shipperNum, prompt, title As String
        prompt = "Enter Shipper #."
        title = "View Shipper"
        shipperNum = InputBox(prompt, title)

        If shipperNum.Length = 4 Then
            Try
                Dim shipper As New frmAddShipperItems(shipperNum)
                shipper.MdiParent = Me
                shipper.Show()
            Catch ex As Exception
                MessageBox.Show("That shipper # does not exist in database.", "I do not compute!")
            End Try

        Else
            MessageBox.Show("That shipper # does not exist in database.", "I do not compute!")
        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub shipperList(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles ShipperListingToolStripMenuItem.Click, _
                            ShipperListingToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Dim viewShippers As New frmShipperList
        viewShippers.MdiParent = Me
        viewShippers.Show()

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub itemsListing(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles ItemsListingToolStripMenuItem.Click, _
                            ItemsListingToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Dim itemList As New frmItems
        itemList.MdiParent = Me
        itemList.Show()

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub showEXTTakeOff(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles ViewTakeOffToolStripMenuItem.Click, _
                            GlobalTakeOffToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Dim jobNum, prompt, title As String
        prompt = "Enter Job #."
        title = "MHS Job"
        jobNum = InputBox(prompt, title)

        Try
            Dim extTOF As New frmExtrudedTOF(jobNum)
            extTOF.MdiParent = Me
            extTOF.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute!")
        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub showPLYTakeOff(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles ViewTakeOffToolStripMenuItem1.Click, _
                        ViewTakeOffToolStripMenuItem3.Click

        Me.Cursor = Cursors.WaitCursor

        Dim jobNum, prompt, title As String
        prompt = "Enter Job #."
        title = "MHS Job"
        jobNum = InputBox(prompt, title)

        Try
            Dim plyTOF As New frmPlywoodTOF(jobNum)
            plyTOF.MdiParent = Me
            plyTOF.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute! From showPLYTakeOff Sub in MDI")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ShowPLYSheetingEST(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles SheetingEstimaterToolStripMenuItem.Click, _
                        SheetingEstimatorToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor


        Dim jobNum, prompt, title As String
        prompt = "Enter Job #."
        title = "MHS Job"
        jobNum = InputBox(prompt, title)

        Try
            Dim PLYSheeting As New frmPlywoodSheetingSizes(jobNum)
            PLYSheeting.MdiParent = Me
            PLYSheeting.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute!")

        End Try

        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub showFSTakeOff(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles ViewTakeOffToolStripMenuItem2.Click, _
                        ViewTakeOffToolStripMenuItem4.Click

        Me.Cursor = Cursors.WaitCursor

        Dim jobNum, prompt, title As String
        prompt = "Enter Job #."
        title = "MHS Job"
        jobNum = InputBox(prompt, title)

        Try
            Dim fsTOF As New frmFlatSheetTOF(jobNum)
            fsTOF.MdiParent = Me
            fsTOF.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute! From showFSTakeOff Sub in MDI")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub showGlobalTakeOff(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles TakeOffToolStripSplitButton.ButtonClick

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim globalTOF As New frmGlobalTakeOff
            globalTOF.MdiParent = Me
            globalTOF.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute!")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub showATMNewStation(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterNewStationToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim atmNewSite As New frmEnterNewStation
            atmNewSite.MdiParent = Me
            atmNewSite.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute!")
        End Try

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ShowATMEnterDailyProductions(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterDailyProductionsToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim atmDP As New frmEnterDailyProduction
            atmDP.MdiParent = Me
            atmDP.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "I do not compute!")
        End Try

        Me.Cursor = Cursors.Arrow


    End Sub


#End Region


#Region " Event Handlers"


    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click




    End Sub



    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click

        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If


    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click

        If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then DirectCast(Me.ActiveMdiChild.ActiveControl, TextBox).SelectAll()

    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then
            If DirectCast(Me.ActiveMdiChild.ActiveControl, TextBox).CanUndo Then DirectCast(Me.ActiveMdiChild.ActiveControl, TextBox).Undo()
        End If

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click

        If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then DirectCast(Me.ActiveMdiChild.ActiveControl, TextBox).Cut()

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click

        If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then DirectCast(Me.ActiveMdiChild.ActiveControl, TextBox).Copy()

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click

        If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then DirectCast(Me.ActiveMdiChild.ActiveControl, TextBox).Paste()

    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

        Me.Cursor = Cursors.Arrow

    End Sub



    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

        ' Code snippet for passing parameters through an input box
        '  This used for testing, r&d.


        'Dim jobNum, prompt, title As String
        'prompt = "Enter Job #."
        'title = "MHS Job"
        'jobNum = InputBox(prompt, title)


		Dim test As New frmLogoTakeOff
		test.MdiParent = Me
		test.Show()

        




    End Sub

    Private Sub MenuStrip_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuStrip.EnabledChanged

        Select Case Me.MenuStrip.Enabled
            Case True
                Me.ToolStrip.Enabled = True

            Case False
                Me.ToolStrip.Enabled = False

        End Select

    End Sub

    Private Sub tsbUnlock_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUnlock.ButtonClick
        appLock(False)
    End Sub

    Private Sub LockSignINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockSignINToolStripMenuItem.Click
        appLock(True)

    End Sub

    Private Sub LockToolStripSplitButton_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripSplitButton.ButtonClick

        appLock(True)


    End Sub

    Private Sub SignCodesToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles SignCodesToolStripButton.Click, _
                            SignCodesToolStripMenuItem.Click


        Me.Cursor = Cursors.WaitCursor


        Dim sc As New frmNewSignCodeDetailsEntry
        sc.MdiParent = Me
        sc.Show()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click


        Dim ChangeCred As New frmUserChangePW
        ChangeCred.MdiParent = Me
        ChangeCred.Show()
    End Sub

    Private Sub NewCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCustomerToolStripMenuItem.Click

        Dim cust As New frmNewCust
        cust.MdiParent = Me
        cust.Show()
    End Sub

    Private Sub CustomerListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerListingToolStripMenuItem.Click

        Dim custList As New frmCustomerListing
        custList.MdiParent = Me
        custList.Show()

    End Sub

    Private Sub ToolStrip_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ToolStrip.Paint
        If TypeOf ToolStrip.Renderer Is ToolStripProfessionalRenderer Then
            CType(ToolStrip.Renderer, ToolStripProfessionalRenderer).RoundedEdges = False
        End If
    End Sub




    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSheetingToolStripMenuItem1.Click

        Dim newSheet As New frmInvNewSheeting
        newSheet.MdiParent = Me
        newSheet.Show()

    End Sub

    Private Sub SheetingListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SheetingListingToolStripMenuItem.Click



        Dim sheetList As New frmInvSheetingListing
        sheetList.MdiParent = Me
        sheetList.Show()

    End Sub

    Private Sub ReceiveSalvageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiveSalvageToolStripMenuItem.Click



        Dim newSalvage As New frmNewSalvageSign
        newSalvage.MdiParent = Me
        newSalvage.Show()

    End Sub

    Private Sub SalvageListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvageListingToolStripMenuItem.Click


        Dim salvageList As New frmSalvageInventory
        salvageList.MdiParent = Me
        salvageList.Show()

    End Sub


    Private Sub SheetingUsageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles SheetingUsageToolStripMenuItem.Click, _
                        SheetingUsageToolStripMenuItem1.Click

        Dim SheetUsage As New frmSheetingUsage
        SheetUsage.MdiParent = Me
        SheetUsage.Show()


    End Sub



#End Region












    'Private Sub tsbHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbHome.Click

    '    ' Assign initial value so that only when
    '    ' a form named "frmHome" is found will the
    '    ' value of this variable be anything but
    '    ' 'False'.  
    '    Dim HomeScreenOpen As Boolean = False

    '    For Each Frm As Form In Me.MdiChildren

    '        If Not Frm.Visible Then Frm.Visible = True

    '        If Frm.Name = "frmHome" Then

    '            ' Assign variable noting that the Home screen is
    '            ' currently open.
    '            HomeScreenOpen = True

    '            Select Case Frm.WindowState

    '                Case FormWindowState.Maximized

    '                    Frm.WindowState = FormWindowState.Minimized
    '                    Frm.Visible = False

    '                Case FormWindowState.Minimized

    '                    Frm.WindowState = FormWindowState.Maximized

    '            End Select

    '        End If

    '    Next


    '    Select Case HomeScreenOpen

    '        Case True
    '            ' Do nothing an complete method

    '        Case False

    '            ' Call the method to open a new home screen
    '            Dim newHome As New frmHome
    '            newHome.MdiParent = Me
    '            newHome.Show()

    '    End Select

    'End Sub




#Region " Testing Menu Items"


    Private Sub JobStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobStatusToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Dim JobStatus As New frmJobStatus
        JobStatus.MdiParent = Me
        JobStatus.Show()

        Me.Cursor = Cursors.Arrow


    End Sub





#End Region

    Private Sub StationStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StationStatusToolStripMenuItem.Click


        Me.Cursor = Cursors.WaitCursor

		Dim StationStatus As New frmStationStatus
		StationStatus.MdiParent = Me
		StationStatus.Show()

		'Dim EnterDP As New frmEnterMHSdp
		'EnterDP.MdiParent = Me
		'EnterDP.Show()

        Me.Cursor = Cursors.Arrow



    End Sub

    Private Sub HomeWelcomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeWelcomeToolStripMenuItem.Click



        Me.Cursor = Cursors.WaitCursor


        Dim GoHome As New frmHome
        GoHome.MdiParent = Me
        GoHome.Show()


        Me.Cursor = Cursors.Arrow

        




    End Sub

    
    Private Sub UserListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserListToolStripMenuItem.Click

        Dim uList As New frmUsersList
        uList.MdiParent = Me
        uList.Show()




    End Sub

	Private Sub NewRunToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRunToolStripMenuItem1.Click, NewRunToolStripMenuItem.Click

		Dim extRun As New frmExtrudedRun
		extRun.MdiParent = Me
		extRun.Show()


	End Sub

	
	Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
		Dim settingsGrid As New frmSettings
		settingsGrid.MdiParent = Me
		settingsGrid.Show()

	End Sub

	Private Sub CombineTOFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CombineTOFToolStripMenuItem.Click
		Dim TransferSigns As New frmTOFtoStatus
		TransferSigns.MdiParent = Me
		TransferSigns.Show()

	End Sub

	Private Sub JobStartDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobStartDateToolStripMenuItem.Click

		'Dim jobDate As New frmATMdbTesting
		'jobDate.MdiParent = Me
		'jobDate.Show()

	End Sub

	Private Sub CertificationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CertificationsToolStripMenuItem.Click
		
	End Sub

	Private Sub ReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiveToolStripMenuItem.Click
		Dim rcvCert As New frmCertReceive
		rcvCert.MdiParent = Me
		rcvCert.Show()
	End Sub

	Private Sub RequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequestToolStripMenuItem.Click
		
	End Sub

	Private Sub FlatSheetTypeVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatSheetTypeVToolStripMenuItem.Click

		Dim TypeV As New frmTypeVTOF
		TypeV.MdiParent = Me
		TypeV.Show()

	End Sub

	Private Sub DailyProductionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyProductionsToolStripMenuItem.Click
		Dim EnterDP As New frmEnterMHSdp
		EnterDP.MdiParent = Me
		EnterDP.Show()
	End Sub

	Private Sub CombineMigrateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CombineMigrateToolStripMenuItem.Click

		Dim xferTOF As New frmTOFtoStatus
		xferTOF.MdiParent = Me
		xferTOF.Show()
		

	End Sub

	Private Sub DailyProductionsTouchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyProductionsTouchToolStripMenuItem.Click

		Dim SignCheck As New frmSignCheck
		SignCheck.MdiParent = Me
		SignCheck.Show()

	End Sub

    Private Sub StationStatusToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles StationStatusToolStripMenuItem1.Click
        Dim StationStatusDP As New frmStationStatus
        StationStatusDP.MdiParent = Me
        StationStatusDP.Show()
    End Sub
End Class
