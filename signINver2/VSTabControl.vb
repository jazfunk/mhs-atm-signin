'Downloaded from http://www.vbforums.com/showthread.php?t=580655 - all credits to ForumAccount for his great work
'Modified by i00 (Kris) to use windows colors and support transparent BGs

Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel.Design

<DefaultEvent("TabMouseClick"), Designer(GetType(VSTabControl.VSTabControlDesigner))> _
Public Class VSTabControl
    Inherits Panel
    '
    'Fields
    '
    Private components As System.ComponentModel.IContainer = Nothing
    Private _TabDropDownMenuStrip As ContextMenuStrip = Nothing
    '
    'Properties
    '
    Private _Tabs As SideTabCollection
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(False)> _
    Public ReadOnly Property Tabs() As SideTabCollection
        Get
            Me.Invalidate()
            Return _Tabs
        End Get
    End Property

    Private _TabSkin As SideTabSkin
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property TabSkin() As SideTabSkin
        Get
            Return _TabSkin
        End Get
        Set(ByVal value As SideTabSkin)
            _TabSkin = value
        End Set
    End Property

    Private _GlyphSkin As DropDownGlyphSkin
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property GlyphSkin() As DropDownGlyphSkin
        Get
            Return _GlyphSkin
        End Get
        Set(ByVal value As DropDownGlyphSkin)
            _GlyphSkin = value
        End Set
    End Property

    Private _InnerBackColor As Color = SystemColors.Control
    <DefaultValue(GetType(Color), "Control")> _
    Public Property InnerBackColor() As Color
        Get
            Return _InnerBackColor
        End Get
        Set(ByVal value As Color)
            _InnerBackColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _InnerBorderColor As Color = Color.FromKnownColor(KnownColor.ControlDark) 'Color.FromArgb(145, 155, 156)
    <DefaultValue(GetType(Color), "145, 155, 156")> _
    Public Property InnerBorderColor() As Color
        Get
            Return _InnerBorderColor
        End Get
        Set(ByVal value As Color)
            _InnerBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _OuterBorderColor As Color = Color.FromKnownColor(KnownColor.ControlDark) 'Color.FromArgb(145, 167, 180)
    <DefaultValue(GetType(Color), "145, 167, 180")> _
    Public Property OuterBorderColor() As Color
        Get
            Return _OuterBorderColor
        End Get
        Set(ByVal value As Color)
            _OuterBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(False)> _
    Public ReadOnly Property SelectedTab() As SideTab
        Get
            Return (From t As SideTab In Me._Tabs Where t.Selected Select t).FirstOrDefault()
        End Get
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property Font() As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.ForeColor = value
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property BackgroundImage() As System.Drawing.Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            MyBase.BackgroundImage = value
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property BackgroundImageLayout() As System.Windows.Forms.ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(ByVal value As System.Windows.Forms.ImageLayout)
            MyBase.BackgroundImageLayout = value
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property RightToLeft() As System.Windows.Forms.RightToLeft
        Get
            Return MyBase.RightToLeft
        End Get
        Set(ByVal value As System.Windows.Forms.RightToLeft)
            MyBase.RightToLeft = value
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overloads Property ImeMode() As ImeMode
        Get
            Return Windows.Forms.ImeMode.NoControl
        End Get
        Set(ByVal value As ImeMode)
            Return
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overloads Property Padding() As Padding
        Get
            Return New Padding(0)
        End Get
        Set(ByVal value As Padding)
            Return
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overloads Property UseWaitCursor() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            Return
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overloads Property TabIndex() As Integer
        Get
            Return -1
        End Get
        Set(ByVal value As Integer)
            Return
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overloads Property TabStop() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            Return
        End Set
    End Property

    Protected ReadOnly Property MaxShowableTabIndex() As Integer
        Get
            Return CInt(Math.Floor((Me.Height - 38) / 32))
        End Get
    End Property

    Protected ReadOnly Property MinimumTabDraw() As Integer
        Get
            Return (New Integer() {Me.MaxShowableTabIndex, Me._Tabs.Count}).Min()
        End Get
    End Property

    Protected ReadOnly Property TabDropDownIsShown() As Boolean
        Get
            Return (Me.MaxShowableTabIndex < Me._Tabs.Count)
        End Get
    End Property

    Protected ReadOnly Property ClientCursorPosition() As Point
        Get
            Return (Me.PointToClient(Cursor.Position))
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property ParentForm() As Form
        Get
            Return Me.FindForm()
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property TabCount() As Integer
        Get
            If Me._Tabs IsNot Nothing Then Return Me._Tabs.Count Else Return -1
        End Get
    End Property

    <DefaultValue(GetType(Size), "300, 150")> _
    Public NotOverridable Overrides Property MinimumSize() As System.Drawing.Size
        Get
            Return MyBase.MinimumSize
        End Get
        Set(ByVal value As System.Drawing.Size)
            If value.Height >= 150 AndAlso value.Width >= 300 Then
                MyBase.MinimumSize = value
            End If
        End Set
    End Property

    Private _DrawTabDividers As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property DrawTabDividers() As Boolean
        Get
            Return _DrawTabDividers
        End Get
        Set(ByVal value As Boolean)
            _DrawTabDividers = value
            Me.Invalidate()
        End Set
    End Property
    '
    'Events
    '
    Public Event TabAdded As VSTabControlEventHandler
    Public Event TabRemoved As VSTabControlEventHandler
    Public Event TabMouseClick As VSTabControlMouseEventHandler
    Public Event SelectedTabChanged As VSTabControlEventHandler
    Public Event TabTextChanged As VSTabControlEventHandler
    Public Event TabFontChanged As VSTabControlEventHandler
    Public Event TabForeColorChanged As VSTabControlEventHandler
    Public Event TabDropDownClicked As MouseEventHandler
    '
    'Delegates
    '
    Public Delegate Sub VSTabControlEventHandler(ByVal sender As Object, ByVal e As VSTabControlEventArgs)
    Public Delegate Sub VSTabControlMouseEventHandler(ByVal sender As Object, ByVal e As VSTabControlMouseEventArgs)
    '
    'Methods
    '
    Public Sub New()
        Me._TabSkin = New SideTabSkin()
        Me._GlyphSkin = New DropDownGlyphSkin()
        Me.InitializeComponent()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub InitLayout()
        MyBase.InitLayout()
        If Me.ParentForm IsNot Nothing Then
            AddHandler Me.ParentForm.Resize, AddressOf OnParentResizeAndMove
            AddHandler Me.ParentForm.Move, AddressOf OnParentResizeAndMove
        End If
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseClick(e)
        Dim cursorPosition = Me.ClientCursorPosition
        Dim tabClientRect As Rectangle = Nothing
        Dim tabdropDownClientRect = New Rectangle(81, (32 * Me.MinimumTabDraw) + 12, 14, 14)
        Dim oldTabIndex As Integer = If(Me.SelectedTab IsNot Nothing, Me.SelectedTab.Index, -1)
        Dim newTabIndex As Integer = 0
        If tabdropDownClientRect.Contains(cursorPosition) AndAlso Me.TabDropDownIsShown Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim tabsNotShown = From t As SideTab In Me._Tabs Where Not t.Shown Select t
                If Me._TabDropDownMenuStrip IsNot Nothing Then Me._TabDropDownMenuStrip.Dispose()
                Me._TabDropDownMenuStrip = New ContextMenuStrip()
                With Me._TabDropDownMenuStrip
                    For Each t As SideTab In tabsNotShown
                        .Items.Add(New ToolStripMenuItem(t.Text, Nothing, AddressOf Me.OnTabDropDownItemClicked) With {.Tag = t.Index})
                    Next
                End With
                Me._TabDropDownMenuStrip.Show(Me, New Point(81, (32 * Me.MinimumTabDraw) + 27))
            End If
            Me.OnTabDropDownClicked(e)
            Return
        End If
        For Each tab As SideTab In Me._Tabs
            If tab.Shown AndAlso tab.ClientRectangle.Contains(cursorPosition) AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                newTabIndex = tab.Index
                tab.Selected = True
                Me.OnTabMouseClick(New VSTabControlMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, tab))
                If oldTabIndex <> newTabIndex Then
                    Me.OnSelectedTabChanged(New VSTabControlEventArgs(tab))
                End If
                Return
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Me._Tabs.Update()
        MyBase.OnPaint(e)
        Me.OnDrawFillGradient(e)
        Me.OnDrawOuterBorder(e)
        Me.OnDrawInnerColor(e)
        Me.OnDrawInnerBorder(e)
        Me.OnDrawTabs(e)
        Me.OnDrawTabText(e)
        Me.OnDrawTabDropDown(e)
    End Sub

    Protected Overridable Sub OnDrawTabDropDown(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        If Me.MaxShowableTabIndex < Me._Tabs.Count Then
            Dim clientRect = New Rectangle(81, (32 * Me.MinimumTabDraw) + 12, 14, 14)
            Dim points() As Point = {New Point(85, (32 * Me.MinimumTabDraw) + 19), _
                                     New Point(88, (32 * Me.MinimumTabDraw) + 23), _
                                     New Point(92, (32 * Me.MinimumTabDraw) + 19)}
            If clientRect.Contains(ClientCursorPosition) AndAlso Not Me.DesignMode Then
                Using selectionPen As New Pen(Me._GlyphSkin.SelectionBorderColor)
                    e.Graphics.DrawRectangle(selectionPen, clientRect)
                End Using
                Using selectionBrush As New SolidBrush(Me._GlyphSkin.SelectionFillColor)
                    e.Graphics.FillRectangle(selectionBrush, New Rectangle(clientRect.X + 1, clientRect.Y + 1, 13, 13))
                End Using
            End If
            Using glyphBrush As New SolidBrush(Me._GlyphSkin.GlyphColor)
                e.Graphics.SmoothingMode = SmoothingMode.None
                e.Graphics.FillRectangle(glyphBrush, 85, (32 * Me.MinimumTabDraw) + 16, 7, 2)
                e.Graphics.FillPolygon(glyphBrush, points)
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            End Using
        End If
    End Sub

    Protected Overridable Sub OnDrawOuterBorder(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Using outerPen As New Pen(Me._OuterBorderColor)
            'Top left arc
            e.Graphics.DrawArc(outerPen, 1, 0, 10, 10, 180, 90)
            'Top line
            e.Graphics.DrawLine(outerPen, 6, 0, Me.ClientRectangle.Width - 1, 0)
            'Right line
            e.Graphics.DrawLine(outerPen, Me.ClientRectangle.Width - 1, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
            'Bottom left arc
            e.Graphics.DrawArc(outerPen, 1, (32 * Me.MinimumTabDraw), 9, 10, 90, 90)
            'Bottom right arc
            e.Graphics.DrawArc(outerPen, 85, (32 * (Me.MinimumTabDraw + 1)), 10, 10, -90, 90)
            'Bottom line
            e.Graphics.DrawLine(outerPen, 95, Me.ClientRectangle.Height - 1, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
            'Left middle connecting line
            e.Graphics.DrawLine(outerPen, 95, (32 * (Me.MinimumTabDraw + 1)) + 6, 95, Me.ClientRectangle.Height - 1)
            'Left side line
            e.Graphics.DrawLine(outerPen, 1, 6, 1, (32 * (Me.MinimumTabDraw)) + 4)
            'Middle connecting line
            e.Graphics.DrawLine(outerPen, 6, (32 * (Me.MinimumTabDraw) + 11), 90, 32 * (Me.MinimumTabDraw + 1))
        End Using
    End Sub

    Protected Overridable Sub OnDrawTabText(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim textSize As Size = Nothing
        Dim index As Integer = 0
        Dim min As Integer = Me.MinimumTabDraw
        Dim text As String = Nothing

        Do Until index = min
            text = Me._Tabs(index).Text
            Select Case True
                Case Me._Tabs(index).Selected
                    textSize = TextRenderer.MeasureText(text, Me._TabSkin.SelectedSkin.Font)
                    Using textBrush As New SolidBrush(Me._TabSkin.SelectedSkin.ForeColor)
                        e.Graphics.DrawString(Me._Tabs(index).Text, Me._TabSkin.SelectedSkin.Font, textBrush, 12.0!, CSng(Me._Tabs(index).ClientRectangle.Y + (15 - (textSize.Height / 2))))
                    End Using
                Case Me._Tabs(index).Highlighted AndAlso Not Me.DesignMode
                    textSize = TextRenderer.MeasureText(text, Me._TabSkin.HighlightedSkin.Font)
                    Using textBrush As New SolidBrush(Me._TabSkin.HighlightedSkin.ForeColor)
                        e.Graphics.DrawString(Me._Tabs(index).Text, Me._TabSkin.HighlightedSkin.Font, textBrush, 12.0!, CSng(Me._Tabs(index).ClientRectangle.Y + (15 - (textSize.Height / 2))))
                    End Using
                Case Else
                    textSize = TextRenderer.MeasureText(text, Me._TabSkin.UnselectedSkin.Font)
                    Using textBrush As New SolidBrush(Me._TabSkin.UnselectedSkin.ForeColor)
                        e.Graphics.DrawString(Me._Tabs(index).Text, Me._TabSkin.UnselectedSkin.Font, textBrush, 12.0!, CSng(Me._Tabs(index).ClientRectangle.Y + (15 - (textSize.Height / 2))))
                    End Using
            End Select
            index += 1
        Loop

    End Sub

    Protected Overridable Sub OnDrawInnerBorder(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Using innerPen As New Pen(Me._InnerBorderColor)
            e.Graphics.DrawRectangle(innerPen, New Rectangle(101, 6, Me.ClientRectangle.Width - 108, Me.ClientRectangle.Height - 13))
        End Using
    End Sub

    Protected Overridable Sub OnDrawInnerColor(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Using innerBrush As New SolidBrush(Me._InnerBackColor)
            e.Graphics.FillRectangle(innerBrush, New Rectangle(101, 6, Me.ClientRectangle.Width - 108, Me.ClientRectangle.Height - 13))
        End Using
    End Sub

    Protected Overridable Sub OnDrawTabs(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim y As Integer = 0
        Dim mouseOver As Boolean = False
        Dim cursorPosition As Point = Me.ClientCursorPosition
        Dim index As Integer = 0

        Do Until index = Me.MinimumTabDraw
            y = Me._Tabs(index).ClientRectangle.Y
            mouseOver = Me._Tabs(index).ClientRectangle.Contains(cursorPosition)
            Me._Tabs(index).AssignHighlighted((mouseOver AndAlso Not Me._Tabs(index).Selected))
            If Me._DrawTabDividers Then
                If index = 0 Then
                    Using bottomPen As New Pen(Me._TabSkin.DividerSkin.BottomLineColor)
                        e.Graphics.DrawLine(bottomPen, 6, 5, 93, 5)
                    End Using
                ElseIf index = Me.MinimumTabDraw - 1 Then
                    Using topPen As New Pen(Me._TabSkin.DividerSkin.TopLineColor)
                        e.Graphics.DrawLine(topPen, 6, y + 32, 93, y + 32)
                    End Using
                End If
                Using topPen As New Pen((Me._TabSkin.DividerSkin.TopLineColor))
                    e.Graphics.DrawLine(topPen, 6, y, 93, y)
                End Using
                Using bottomPen As New Pen(Me._TabSkin.DividerSkin.BottomLineColor)
                    e.Graphics.DrawLine(bottomPen, 6, y + 31, 93, y + 31)
                End Using
            End If
            Select Case True
                Case Me._Tabs(index).Selected
                    Using tabTip As New Pen(Me._TabSkin.SelectedSkin.TabTipColor)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 2, y)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 0, y + 29)
                        e.Graphics.DrawLine(tabTip, 0, y + 29, 2, y + 31)
                    End Using
                    Using tabBorder As New Pen(Me._TabSkin.SelectedSkin.BorderColor)
                        e.Graphics.DrawLine(tabBorder, 3, y, 100, y)
                        e.Graphics.DrawLine(tabBorder, 3, y + 31, 100, y + 31)
                    End Using
                    Using tabBorderRight As New Pen(Me._TabSkin.SelectedSkin.MiddleBorderColor)
                        e.Graphics.DrawLine(tabBorderRight, 101, y + 1, 101, y + 30)
                    End Using
                    Using tabTipInside As New Pen(Me._TabSkin.SelectedSkin.InsideTabTipColor)
                        e.Graphics.DrawLine(tabTipInside, 1, y + 2, 1, y + 29)
                        e.Graphics.DrawLine(tabTipInside, 2, y + 1, 2, y + 30)
                    End Using
                    If Me._TabSkin.SelectedSkin.TabGradient.ColorsAreEqual Then
                        Using fillBrush As SolidBrush = Me._TabSkin.SelectedSkin.TabGradient.GetBrush()
                            e.Graphics.FillRectangle(fillBrush, New Rectangle(3, y + 1, 98, 30))
                        End Using
                    Else
                        Using fillBrush As LinearGradientBrush = Me._TabSkin.SelectedSkin.TabGradient.GetBrush(New Rectangle(3, y + 1, 98, 30), LinearGradientMode.Horizontal)
                            e.Graphics.FillRectangle(fillBrush, fillBrush.Rectangle)
                        End Using
                    End If
                Case mouseOver AndAlso Not Me.DesignMode
                    Using tabTip As New Pen(Me._TabSkin.HighlightedSkin.TabTipColor)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 2, y)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 0, y + 29)
                        e.Graphics.DrawLine(tabTip, 0, y + 29, 2, y + 31)
                    End Using
                    Using tabBorder As New Pen(Me._TabSkin.HighlightedSkin.BorderColor)
                        e.Graphics.DrawLine(tabBorder, 3, y, 100, y)
                        e.Graphics.DrawLine(tabBorder, 3, y + 31, 100, y + 31)
                    End Using
                    Using tabTipInside As New Pen(Me._TabSkin.HighlightedSkin.InsideTabTipColor)
                        e.Graphics.DrawLine(tabTipInside, 1, y + 2, 1, y + 29)
                        e.Graphics.DrawLine(tabTipInside, 2, y + 1, 2, y + 30)
                    End Using
                    If Me._TabSkin.HighlightedSkin.TabGradient.ColorsAreEqual Then
                        Using fillBrush As SolidBrush = Me._TabSkin.HighlightedSkin.TabGradient.GetBrush()
                            e.Graphics.FillRectangle(fillBrush, New Rectangle(3, y + 1, 98, 30))
                        End Using
                    Else
                        Using fillBrush As LinearGradientBrush = Me._TabSkin.HighlightedSkin.TabGradient.GetBrush(New Rectangle(3, y + 1, 98, 30), LinearGradientMode.Horizontal)
                            e.Graphics.FillRectangle(fillBrush, fillBrush.Rectangle)
                        End Using
                    End If
            End Select
            index += 1
        Loop
    End Sub

    Protected Overridable Sub OnDrawFillGradient(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim gp As New GraphicsPath
        gp.AddLine(New PointF(4, 0), New PointF(Me.Width, 0))
        gp.AddLine(gp.GetLastPoint, New PointF(Me.Width, Me.Height))
        gp.AddLine(gp.GetLastPoint, New PointF(95, Me.Height))
        gp.AddLine(gp.GetLastPoint, New PointF(95, 32 * (Me.MinimumTabDraw + 1) + 3))
        gp.AddLine(gp.GetLastPoint, New PointF(93, 32 * (Me.MinimumTabDraw + 1) + 1))
        gp.AddLine(gp.GetLastPoint, New PointF(6, (32 * (Me.MinimumTabDraw) + 11)))
        gp.AddLine(gp.GetLastPoint, New PointF(4, (Me.MinimumTabDraw * 32) + 11))
        gp.AddLine(gp.GetLastPoint, New PointF(1, 7 + (Me.MinimumTabDraw * 32)))
        gp.AddLine(gp.GetLastPoint, New PointF(0, 4))
        gp.CloseFigure()
        'e.Graphics.FillPath(Brushes.Red, gp)
        e.Graphics.SetClip(gp)

        If Me._TabSkin.TabGradient.ColorsAreEqual Then
            Using tabBrush As SolidBrush = Me._TabSkin.TabGradient.GetBrush()
                e.Graphics.FillRectangle(tabBrush, New Rectangle(1, 0, 95, Me.Height))
            End Using
        Else
            Using tabBrush As LinearGradientBrush = Me._TabSkin.TabGradient.GetBrush(New Rectangle(1, 0, 95, Me.Height), LinearGradientMode.Horizontal)
                e.Graphics.FillRectangle(tabBrush, tabBrush.Rectangle)
            End Using
        End If
        Using backBrush As New SolidBrush(Me._TabSkin.TabGradient.EndColor)
            e.Graphics.FillRectangle(backBrush, New Rectangle(96, 0, Me.Width - 95, Me.Height - 1))
        End Using
        e.Graphics.ResetClip()

    End Sub

    Protected Overridable Sub OnTabAdded(ByVal e As VSTabControlEventArgs)
        RaiseEvent TabAdded(Me, e)
    End Sub

    Protected Overridable Sub OnTabRemoved(ByVal e As VSTabControlEventArgs)
        RaiseEvent TabRemoved(Me, e)
    End Sub

    Protected Overridable Sub OnTabMouseClick(ByVal e As VSTabControlMouseEventArgs)
        RaiseEvent TabMouseClick(Me, e)
    End Sub

    Protected Overridable Sub OnTabTextChanged(ByVal e As VSTabControlEventArgs)
        RaiseEvent TabTextChanged(Me, e)
    End Sub

    Protected Overridable Sub OnTabFontChanged(ByVal e As VSTabControlEventArgs)
        RaiseEvent TabFontChanged(Me, e)
    End Sub

    Protected Overridable Sub OnTabForeColorChanged(ByVal e As VSTabControlEventArgs)
        RaiseEvent TabForeColorChanged(Me, e)
    End Sub

    Protected Overridable Sub OnTabDropDownClicked(ByVal e As MouseEventArgs)
        RaiseEvent TabDropDownClicked(Me, e)
    End Sub

    Protected Overridable Sub OnTabDropDownItemClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Me._Tabs.Swap(CInt(DirectCast(sender, ToolStripMenuItem).Tag), Me._Tabs(Me.MinimumTabDraw - 1).Index)
    End Sub

    Protected Overridable Sub OnSelectedTabChanged(ByVal e As VSTabControlEventArgs)
        RaiseEvent SelectedTabChanged(Me, e)
    End Sub

    Protected Overridable Sub OnParentResizeAndMove(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.Size = New Size(300, 150)
        MyBase.MinimumSize = New Size(300, 150)
        Me._Tabs = New SideTabCollection(Me)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        If Me.ParentForm IsNot Nothing Then
            RemoveHandler Me.ParentForm.Resize, AddressOf OnParentResizeAndMove
            RemoveHandler Me.ParentForm.Move, AddressOf OnParentResizeAndMove
        End If
        If Me._TabSkin IsNot Nothing Then
            Me._TabSkin.HighlightedSkin.Font.Dispose()
            Me._TabSkin.SelectedSkin.Font.Dispose()
            Me._TabSkin.UnselectedSkin.Font.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    '
    'Nested types
    '
    Public Class SideTab : Implements IComparer(Of SideTab)
        '
        'Properties
        '
        Private _Name As String = "SideTab"
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _Text As String = "SideTab"
        Public Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal value As String)
                Dim oldValue As String = Me._Text
                _Text = value
                Me.Invalidate()
                If oldValue <> Me._Text Then
                    Me.OnTextChanged(EventArgs.Empty)
                End If
            End Set
        End Property

        Private _Selected As Boolean = False
        Public Property Selected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                If value AndAlso Me._Parent IsNot Nothing Then
                    Me._Parent._Tabs.UnselectAllTabs()
                End If
                _Selected = value
                Me.Invalidate()
            End Set
        End Property

        Private _Highlighted As Boolean = False
        <Browsable(False)> _
        Public ReadOnly Property Highlighted() As Boolean
            Get
                Return _Highlighted
            End Get
        End Property

        Private _Parent As VSTabControl
        <Browsable(False)> _
        Public ReadOnly Property Parent() As VSTabControl
            Get
                Return _Parent
            End Get
        End Property

        Private _ClientRectangle As Rectangle
        <Browsable(False)> _
        Public ReadOnly Property ClientRectangle() As Rectangle
            Get
                Return _ClientRectangle
            End Get
        End Property

        Private _Index As Integer
        <Browsable(False)> _
        Public ReadOnly Property Index() As Integer
            Get
                Return _Index
            End Get
        End Property

        Private _Shown As Boolean
        <Browsable(False)> _
        Public ReadOnly Property Shown() As Boolean
            Get
                If Me._Parent IsNot Nothing Then
                    Return (Me._Parent.MinimumTabDraw > Me._Index)
                Else
                    Return False
                End If
            End Get
        End Property
        '
        'Methods
        '
        Friend Overridable Sub AssignHighlighted(ByVal highlighted As Boolean)
            Me._Highlighted = highlighted
        End Sub

        Friend Overridable Sub AssignParent(ByVal parent As VSTabControl)
            If parent Is Nothing Then Throw New ArgumentNullException("parent")
            If Not TypeOf parent Is VSTabControl Then Throw New ArgumentException("parent")
            Me._Parent = parent
        End Sub

        Friend Overridable Sub AssignClientRectangle(ByVal rectangle As Rectangle)
            If rectangle = Nothing Then Throw New ArgumentNullException("rectangle")
            Me._ClientRectangle = rectangle
        End Sub

        Friend Overridable Sub AssignIndex(ByVal index As Integer)
            If index < 0 Then Throw New ArgumentException("index")
            Me._Index = index
        End Sub

        Protected Overridable Sub OnTextChanged(ByVal e As System.EventArgs)
            If Me._Parent IsNot Nothing Then
                Me._Parent.OnTabTextChanged(New VSTabControlEventArgs(Me))
            End If
        End Sub

        Protected Overridable Sub OnFontChanged(ByVal e As System.EventArgs)
            If Me._Parent IsNot Nothing Then
                Me._Parent.OnTabFontChanged(New VSTabControlEventArgs(Me))
            End If
        End Sub

        Protected Overridable Sub OnForeColorChanged(ByVal e As System.EventArgs)
            If Me._Parent IsNot Nothing Then
                Me._Parent.OnTabForeColorChanged(New VSTabControlEventArgs(Me))
            End If
        End Sub

        Private Sub Invalidate()
            If Me.Parent IsNot Nothing Then
                Me._Parent.Invalidate(Me.ClientRectangle)
            End If
        End Sub

        Public Overrides Function ToString() As String
            Return Me._Text
        End Function

        Public Function Compare(ByVal x As SideTab, ByVal y As SideTab) As Integer Implements System.Collections.Generic.IComparer(Of SideTab).Compare
            Return String.Compare(x.Text, y.Text)
        End Function

    End Class

    Public Class VSTabControlEventArgs
        Inherits EventArgs
        '
        'Properties
        '
        Private _Tab As SideTab
        Public ReadOnly Property Tab() As SideTab
            Get
                Return _Tab
            End Get
        End Property
        '
        'Methods
        '
        Public Sub New(ByVal tab As SideTab)
            Me._Tab = tab
        End Sub

    End Class

    Public Class VSTabControlMouseEventArgs
        Inherits MouseEventArgs
        '
        'Properties
        '
        Private _Tab As SideTab
        Public ReadOnly Property Tab() As SideTab
            Get
                Return _Tab
            End Get
        End Property
        '
        'Methods
        '
        Public Sub New(ByVal button As MouseButtons, ByVal clicks As Integer, ByVal x As Integer, ByVal y As Integer, ByVal delta As Integer, ByVal tab As SideTab)
            MyBase.New(button, clicks, x, y, delta)
            If tab Is Nothing Then Throw New ArgumentNullException("tab")
            If Not TypeOf tab Is SideTab Then Throw New ArgumentException("tab")
            Me._Tab = tab
        End Sub

    End Class

    <TypeConverter(GetType(GradientSettings.GradientSettingsTypeConverter))> _
    Public Class GradientSettings
        '
        'Properties
        '
        Private _StartColor As Color = SystemColors.Window
        <DefaultValue(GetType(Color), "Window")> _
        Public Property StartColor() As Color
            Get
                Return _StartColor
            End Get
            Set(ByVal value As Color)
                _StartColor = value
            End Set
        End Property

        Private _EndColor As Color = SystemColors.Control
        <DefaultValue(GetType(Color), "Control")> _
        Public Property EndColor() As Color
            Get
                Return _EndColor
            End Get
            Set(ByVal value As Color)
                _EndColor = value
            End Set
        End Property

        <Browsable(False)> _
        Public ReadOnly Property ColorsAreEqual() As Boolean
            Get
                Return (Me._StartColor = Me._EndColor)
            End Get
        End Property
        '
        'Methods
        '
        Public Function GetBrush() As SolidBrush
            If Me.ColorsAreEqual Then
                Return New SolidBrush(Me._StartColor)
            End If
            Throw New InvalidOperationException("StartColor and EndColor must be the same.")
        End Function

        Public Function GetBrush(ByVal rectangle As Rectangle, ByVal mode As LinearGradientMode) As LinearGradientBrush
            Return New LinearGradientBrush(rectangle, Me._StartColor, Me._EndColor, mode)
        End Function
        '
        'Nested types
        '
        Friend Class GradientSettingsTypeConverter
            Inherits ExpandableObjectConverter

            'Methods

            Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                Return (destinationType Is GetType(String))
            End Function

            Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                If TypeOf value Is GradientSettings Then
                    Return String.Empty
                End If
                Return MyBase.ConvertTo(context, destinationType)
            End Function

            Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                Return MyBase.GetProperties(context, value, attributes)
            End Function

        End Class

    End Class

    <TypeConverter(GetType(SideTabSkin.SideTabSkinTypeConverter))> _
    Public Class SideTabSkin
        '
        'Properties
        '
        Private _DividerSkin As DividerTabSkin
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property DividerSkin() As DividerTabSkin
            Get
                Return _DividerSkin
            End Get
            Set(ByVal value As DividerTabSkin)
                _DividerSkin = value
            End Set
        End Property

        Private _TabGradient As GradientSettings
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property TabGradient() As GradientSettings
            Get
                Return _TabGradient
            End Get
            Set(ByVal value As GradientSettings)
                _TabGradient = value
            End Set
        End Property

        Private _SelectedSkin As SelectedTabSkin
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property SelectedSkin() As SelectedTabSkin
            Get
                Return _SelectedSkin
            End Get
            Set(ByVal value As SelectedTabSkin)
                _SelectedSkin = value
            End Set
        End Property

        Private _HighlightedSkin As HighlightedTabSkin
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property HighlightedSkin() As HighlightedTabSkin
            Get
                Return _HighlightedSkin
            End Get
            Set(ByVal value As HighlightedTabSkin)
                _HighlightedSkin = value
            End Set
        End Property

        Private _UnselectedSkin As UnselectedTabSkin
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property UnselectedSkin() As UnselectedTabSkin
            Get
                Return _UnselectedSkin
            End Get
            Set(ByVal value As UnselectedTabSkin)
                _UnselectedSkin = value
            End Set
        End Property
        '
        'Methods
        '
        Public Sub New()
            Me._TabGradient = New GradientSettings() With {.StartColor = SystemColors.Window, .EndColor = SystemColors.ControlLight}
            Me._DividerSkin = New DividerTabSkin()
            Me._HighlightedSkin = New HighlightedTabSkin()
            Me._SelectedSkin = New SelectedTabSkin()
            Me._UnselectedSkin = New UnselectedTabSkin()
        End Sub
        '
        'Nested types
        '
        <TypeConverter(GetType(DividerTabSkin.TabDividerSkinTypeConverter))> _
        Public Class DividerTabSkin
            '
            'Properties
            '
            Private _TopLineColor As Color = SystemColors.Control
            <DefaultValue(GetType(Color), "Control")> _
            Public Property TopLineColor() As Color
                Get
                    Return _TopLineColor
                End Get
                Set(ByVal value As Color)
                    _TopLineColor = value
                End Set
            End Property

            Private _BottomLineColor As Color = SystemColors.Window
            <DefaultValue(GetType(Color), "Window")> _
            Public Property BottomLineColor() As Color
                Get
                    Return _BottomLineColor
                End Get
                Set(ByVal value As Color)
                    _BottomLineColor = value
                End Set
            End Property
            '
            'Nested types
            '
            Friend Class TabDividerSkinTypeConverter
                Inherits ExpandableObjectConverter
                '
                'Methods
                '
                Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                    Return (destinationType Is GetType(String))
                End Function

                Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                    Return String.Empty
                End Function

                Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                    Return MyBase.GetProperties(context, value, attributes)
                End Function

            End Class

        End Class

        <TypeConverter(GetType(HighlightedTabSkin.HighlightedTabSkinTypeConverter))> _
        Public Class HighlightedTabSkin
            '
            'Properties
            '
            Private _BorderColor As Color = Color.FromKnownColor(KnownColor.ControlDark) 'Color.FromArgb(145, 155, 156)
            Public Property BorderColor() As Color
                Get
                    Return _BorderColor
                End Get
                Set(ByVal value As Color)
                    _BorderColor = value
                End Set
            End Property

            Private _TabTipColor As Color = Color.FromKnownColor(KnownColor.Highlight) 'Color.FromArgb(230, 139, 44)
            Public Property TabTipColor() As Color
                Get
                    Return _TabTipColor
                End Get
                Set(ByVal value As Color)
                    _TabTipColor = value
                End Set
            End Property

            Private _InsideTabTipColor As Color = Color.FromKnownColor(KnownColor.Highlight) 'Color.FromArgb(255, 199, 60)

            Public Property InsideTabTipColor() As Color
                Get
                    Return _InsideTabTipColor
                End Get
                Set(ByVal value As Color)
                    _InsideTabTipColor = value
                End Set
            End Property

            Private _Font As Font = New Font("Tahoma", 8.25!)
            <DefaultValue(GetType(Font), "Tahoma, 8.25pt")> _
            Public Property Font() As Font
                Get
                    Return _Font
                End Get
                Set(ByVal value As Font)
                    _Font = value
                End Set
            End Property

            Private _ForeColor As Color = SystemColors.ControlText
            <DefaultValue(GetType(Color), "ControlText")> _
            Public Property ForeColor() As Color
                Get
                    Return _ForeColor
                End Get
                Set(ByVal value As Color)
                    _ForeColor = value
                End Set
            End Property

            Private _TabGradient As GradientSettings
            Property TabGradient() As GradientSettings
                Get
                    Return _TabGradient
                End Get
                Set(ByVal value As GradientSettings)
                    _TabGradient = value
                End Set
            End Property
            '
            'Methods
            '
            Public Sub New()
                _TabGradient = New GradientSettings() With {.StartColor = SystemColors.Window, .EndColor = SystemColors.ControlLight}
            End Sub
            '
            'Nested types
            '
            Friend Class HighlightedTabSkinTypeConverter
                Inherits ExpandableObjectConverter
                '
                'Methods
                '
                Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                    Return (destinationType Is GetType(String))
                End Function

                Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                    Return String.Empty
                End Function

                Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                    Return MyBase.GetProperties(context, value, attributes)
                End Function

            End Class

        End Class

        <TypeConverter(GetType(SelectedTabSkin.SelectedTabSkinTypeConverter))> _
        Public Class SelectedTabSkin
            '
            'Properties
            '
            Private _BorderColor As Color = Color.FromKnownColor(KnownColor.ControlDark) 'Color.FromArgb(145, 155, 156)
            Public Property BorderColor() As Color
                Get
                    Return _BorderColor
                End Get
                Set(ByVal value As Color)
                    _BorderColor = value
                End Set
            End Property

            Private _MiddleBorderColor As Color = Color.FromKnownColor(KnownColor.ControlLight) 'Color.FromArgb(173, 190, 204)

            Public Property MiddleBorderColor() As Color
                Get
                    Return _MiddleBorderColor
                End Get
                Set(ByVal value As Color)
                    _MiddleBorderColor = value
                End Set
            End Property

            Private _TabTipColor As Color = Color.FromKnownColor(KnownColor.Highlight)

            Public Property TabTipColor() As Color
                Get
                    Return _TabTipColor
                End Get
                Set(ByVal value As Color)
                    _TabTipColor = value
                End Set
            End Property

            Private _InsideTabTipColor As Color = Color.FromKnownColor(KnownColor.Highlight) 'Color.FromArgb(255, 199, 60)

            Public Property InsideTabTipColor() As Color
                Get
                    Return _InsideTabTipColor
                End Get
                Set(ByVal value As Color)
                    _InsideTabTipColor = value
                End Set
            End Property

            Private _TabGradient As GradientSettings
            Public Property TabGradient() As GradientSettings
                Get
                    Return _TabGradient
                End Get
                Set(ByVal value As GradientSettings)
                    _TabGradient = value
                End Set
            End Property

            Private _Font As Font = New Font("Tahoma", 8.25!)
            <DefaultValue(GetType(Font), "Tahoma, 8.25pt")> _
            Public Property Font() As Font
                Get
                    Return _Font
                End Get
                Set(ByVal value As Font)
                    _Font = value
                End Set
            End Property

            Private _ForeColor As Color = SystemColors.ControlText
            <DefaultValue(GetType(Color), "ControlText")> _
            Public Property ForeColor() As Color
                Get
                    Return _ForeColor
                End Get
                Set(ByVal value As Color)
                    _ForeColor = value
                End Set
            End Property
            '
            'Methods
            '
            Public Sub New()
                Me._TabGradient = New GradientSettings() With {.StartColor = SystemColors.Window, .EndColor = SystemColors.Window}
            End Sub
            '
            'Nested types
            '
            Friend Class SelectedTabSkinTypeConverter
                Inherits ExpandableObjectConverter
                '
                'Methods
                '
                Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                    Return (destinationType Is GetType(String))
                End Function

                Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                    Return String.Empty
                End Function

                Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                    Return MyBase.GetProperties(context, value, attributes)
                End Function

            End Class

        End Class

        <TypeConverter(GetType(UnselectedTabSkin.UnselectedTabSkinTypeConverter))> _
        Public Class UnselectedTabSkin
            '
            'Properties
            '
            Private _Font As Font = New Font("Tahoma", 8.25!)
            <DefaultValue(GetType(Font), "Tahoma, 8.25pt")> _
            Public Property Font() As Font
                Get
                    Return _Font
                End Get
                Set(ByVal value As Font)
                    _Font = value
                End Set
            End Property

            Private _ForeColor As Color = SystemColors.ControlText
            <DefaultValue(GetType(Color), "ControlText")> _
            Public Property ForeColor() As Color
                Get
                    Return _ForeColor
                End Get
                Set(ByVal value As Color)
                    _ForeColor = value
                End Set
            End Property
            '
            'Nested types
            '
            Friend Class UnselectedTabSkinTypeConverter
                Inherits ExpandableObjectConverter
                '
                'Methods
                '
                Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                    Return (destinationType Is GetType(String))
                End Function

                Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                    Return String.Empty
                End Function

                Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                    Return MyBase.GetProperties(context, value, attributes)
                End Function

            End Class

        End Class

        Friend Class SideTabSkinTypeConverter
            Inherits ExpandableObjectConverter
            '
            'Methods
            '
            Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                Return (destinationType Is GetType(String))
            End Function

            Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                Return String.Empty
            End Function

            Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                Return MyBase.GetProperties(context, value, attributes)
            End Function

        End Class

    End Class

    <TypeConverter(GetType(DropDownGlyphSkin.DropDownGlyphSkinTypeConverter))> _
    Public Class DropDownGlyphSkin
        '
        'Properties
        '
        Private _GlyphColor As Color = Color.FromKnownColor(KnownColor.ControlText)

        Public Property GlyphColor() As Color
            Get
                Return _GlyphColor
            End Get
            Set(ByVal value As Color)
                _GlyphColor = value
            End Set
        End Property

        Private _SelectionBorderColor As Color = Color.FromKnownColor(KnownColor.ControlDark) ' Color.FromArgb(75, 75, 111)

        Public Property SelectionBorderColor() As Color
            Get
                Return _SelectionBorderColor
            End Get
            Set(ByVal value As Color)
                _SelectionBorderColor = value
            End Set
        End Property

        Private _SelectionFillColor As Color = Color.FromKnownColor(KnownColor.Control) 'Color.FromArgb(255, 238, 194)

        Public Property SelectionFillColor() As Color
            Get
                Return _SelectionFillColor
            End Get
            Set(ByVal value As Color)
                _SelectionFillColor = value
            End Set
        End Property
        '
        'Methods
        '
        Friend Class DropDownGlyphSkinTypeConverter
            Inherits ExpandableObjectConverter
            '
            'Methods
            '
            Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                Return (destinationType Is GetType(String))
            End Function

            Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                Return String.Empty
            End Function

            Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
                Return MyBase.GetProperties(context, value, attributes)
            End Function

        End Class

    End Class

    Public NotInheritable Class SideTabCollection
        Inherits List(Of SideTab)
        '
        'Properties
        '
        Private _Owner As VSTabControl
        Public ReadOnly Property Owner() As VSTabControl
            Get
                Return _Owner
            End Get
        End Property

        Default Public Overloads ReadOnly Property Item(ByVal name As String) As SideTab
            Get
                Return (From t As SideTab In Me Where t.Name = name Select t).FirstOrDefault()
            End Get
        End Property
        '
        'Methods
        '
        Public Sub New(ByVal owner As VSTabControl)
            If owner Is Nothing Then Throw New ArgumentNullException("owner")
            If Not TypeOf owner Is VSTabControl Then Throw New ArgumentException("owner")
            Me._Owner = owner
        End Sub

        Public Overloads Sub Add()
            Me.Add(New SideTab())
        End Sub

        Public Overloads Sub Add(ByVal text As String)
            Me.Add(New SideTab() With {.Text = text})
        End Sub

        Public Overloads Sub Add(ByVal name As String, ByVal text As String)
            Me.Add(New SideTab() With {.Name = name, .Text = text})
        End Sub

        Public Overloads Sub Add(ByVal item As SideTab)
            MyBase.Add(item)
            item.AssignParent(Me._Owner)
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
            Me._Owner.Invalidate()
            Me._Owner.OnTabAdded(New VSTabControlEventArgs(item))
        End Sub

        Public Overloads Sub AddRange(ByVal collection As IEnumerable(Of SideTab))
            Me.ForEach(New Action(Of SideTab)(AddressOf Add))
        End Sub

        Public Overloads Sub Insert(ByVal index As Integer, ByVal item As SideTab)
            MyBase.Insert(index, item)
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
            Me._Owner.Invalidate()
        End Sub

        Public Overloads Sub Clear()
            MyBase.Clear()
            Me._Owner.Invalidate()
        End Sub

        Public Overloads Sub Remove(ByVal item As SideTab)
            MyBase.Remove(item)
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
            Me._Owner.Invalidate()
            Me._Owner.OnTabRemoved(New VSTabControlEventArgs(item))
        End Sub

        Public Overloads Sub Remove(ByVal name As String)
            Dim tab = Me(name)
            If tab IsNot Nothing Then
                Me.Remove(tab)
            End If
        End Sub

        Public Overloads Sub RemoveAt(ByVal index As Integer)
            Dim removedTab As SideTab = Me(index)
            MyBase.RemoveAt(index)
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
            Me._Owner.Invalidate()
            Me._Owner.OnTabRemoved(New VSTabControlEventArgs(removedTab))
        End Sub

        Public Overloads Sub RemoveAll(ByVal match As Predicate(Of SideTab))
            MyBase.RemoveAll(match)
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
            Me._Owner.Invalidate()
            Me._Owner.OnTabRemoved(New VSTabControlEventArgs(Nothing))
        End Sub

        Public Overloads Sub RemoveRange(ByVal index As Integer, ByVal count As Integer)
            MyBase.RemoveRange(index, count)
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
            Me._Owner.Invalidate()
        End Sub

        Public Overloads Sub Sort()
            MyBase.Sort(DirectCast(New SideTab(), IComparer(Of SideTab)))
            Me._Owner.Invalidate()
        End Sub

        Public Sub Swap(ByVal swapFrom As Integer, ByVal swapWith As Integer)
            If swapFrom > Me.Count Then Throw New ArgumentException("swapFrom")
            If swapWith > Me.Count Then Throw New ArgumentException("swapWith")
            Dim tab = Me(swapFrom)
            Me(swapFrom) = Me(swapWith)
            Me(swapWith) = tab
            Me._Owner.Invalidate()
        End Sub

        Public Function UnselectAllTabs() As Integer
            Dim tabs = From t As SideTab In Me Where t.Selected Select t
            For Each tab As SideTab In tabs
                tab.Selected = False
            Next
            Return tabs.Count()
        End Function

        Public Overrides Function ToString() As String
            Return "SideTabCollection"
        End Function

        Friend Sub Update()
            Me.UpdateClientRectangles()
            Me.UpdateIndices()
        End Sub

        Protected Sub UpdateClientRectangles()
            Dim y As Integer = 6
            For x = 0 To Me.Count - 1
                Me(x).AssignClientRectangle(New Rectangle(0, y, 102, 31))
                y += 32
            Next
        End Sub

        Protected Sub UpdateIndices()
            For x = 0 To Me.Count - 1
                Me(x).AssignIndex(x)
            Next
        End Sub

    End Class

    Friend NotInheritable Class VSTabControlDesigner
        Inherits ParentControlDesigner
        '
        'Fields
        '
        Private _ActionLists As DesignerActionListCollection
        Private _HandlerAdded As Boolean = False
        '
        'Properties
        '
        Public Overrides ReadOnly Property ActionLists() As System.ComponentModel.Design.DesignerActionListCollection
            Get
                If Me._ActionLists Is Nothing Then
                    Me._ActionLists = New DesignerActionListCollection()
                    Me._ActionLists.Add(New VSTabControlActionList(Me.Component))
                End If
                If Not Me._HandlerAdded Then
                    AddHandler Me.Control.DockChanged, AddressOf DockChanged
                    Me._HandlerAdded = True
                End If
                Return Me._ActionLists
            End Get
        End Property
        '
        'Methods
        '
        Private Sub DockChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.RaiseComponentChanged(TypeDescriptor.GetProperties(Me.Control)("Dock"), Nothing, Nothing)
        End Sub
        '
        'Nested types
        '
        Protected NotInheritable Class VSTabControlActionList
            Inherits DesignerActionList
            '
            'Fields 
            '
            Private _VSTabControl As VSTabControl
            Private _ActionUIService As DesignerActionUIService
            '
            'Properties
            '
            Private _Tabs As SideTabCollection
            Public ReadOnly Property Tabs() As SideTabCollection
                Get
                    Return _VSTabControl.Tabs
                End Get
            End Property
            '
            'Methods
            '
            Public Sub New(ByVal component As IComponent)
                MyBase.New(component)
                If TypeOf component Is VSTabControl Then
                    Me._VSTabControl = DirectCast(component, VSTabControl)
                    Me._ActionUIService = DirectCast(Me.GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
                End If
            End Sub

            Public Sub ToggleDock()
                Me._ActionUIService.Refresh(Me._VSTabControl)
                If Me._VSTabControl.Dock = DockStyle.Fill Then
                    Me._VSTabControl.Dock = DockStyle.None
                Else
                    Me._VSTabControl.Dock = DockStyle.Fill
                End If
                Me._ActionUIService.Refresh(Me._VSTabControl)
            End Sub

            Public Overrides Function GetSortedActionItems() As System.ComponentModel.Design.DesignerActionItemCollection
                Dim collection As New DesignerActionItemCollection()
                With collection
                    .Add(New DesignerActionHeaderItem("Properties"))
                    .Add(New DesignerActionPropertyItem("Tabs", "Tabs", "Properties", String.Empty))
                    .Add(New DesignerActionMethodItem(Me, "ToggleDock", "Toggle parent container docking", String.Empty, String.Empty, True))
                End With
                Return collection
            End Function

        End Class

    End Class

End Class
