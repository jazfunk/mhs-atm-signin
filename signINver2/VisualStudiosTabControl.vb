Option Strict On
Option Explicit On
Option Infer On

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.ComponentModel.Design
Imports System.Drawing.Design

<System.ComponentModel.Designer(GetType(VisualStudiosTabControl.VisualStudiosTabControlDesigner))> _
<System.ComponentModel.DefaultEvent(VisualStudiosTabControl.VisualStudiosTabControlResources.SelectedTabChangedEventName)> _
Public Class VisualStudiosTabControl
    Inherits System.Windows.Forms.Panel

    'Fields
    Private components As System.ComponentModel.IContainer = Nothing

    'Events
    Public Event SelectedTabChanged As EventHandler(Of System.EventArgs)
    Public Event SelectedIndexChanged As EventHandler(Of System.EventArgs)
    Public Event TabGlyphClicked As EventHandler(Of System.EventArgs)
    Public Event TabDropDownItemClicked As EventHandler(Of System.EventArgs)
    Public Event TabWidthInflationChanged As EventHandler(Of System.EventArgs)

    'Properties
    <System.ComponentModel.Editor(GetType(VisualStudiosTabPageCollectionEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    <System.ComponentModel.Description(VisualStudiosTabControlResources.TabPagesDescription)> _
    Public ReadOnly Property TabPages() As ControlCollection
        Get
            Return MyBase.Controls
        End Get
    End Property

    Private _TabDropDownMenuStrip As ContextMenuStrip = Nothing
    Protected ReadOnly Property TabDropDownMenuStrip() As ContextMenuStrip
        Get
            Return Me._TabDropDownMenuStrip
        End Get
    End Property

    Protected ReadOnly Property ClientCursorPosition() As Point
        Get
            Return (Me.PointToClient(System.Windows.Forms.Cursor.Position))
        End Get
    End Property

    Private _SelectedTabPage As VisualStudiosTabPage = Nothing
    <System.ComponentModel.TypeConverter(GetType(VisualStudiosTabPageConverter))> _
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
    <System.ComponentModel.Description(VisualStudiosTabControlResources.SelectedTabPageDescription)> _
    Public Property SelectedTabPage() As VisualStudiosTabPage
        Get
            Return Me._SelectedTabPage
        End Get
        Set(ByVal value As VisualStudiosTabPage)
            Dim changed As Boolean = Not Object.Equals(value, Me._SelectedTabPage)
            'Needs the ToArray call, otherwise it does not work properly
            Dim oldOrder As New Dictionary(Of String, Integer)()
            For Each t As Control In Me.TabPages
                Dim tab As VisualStudiosTabPage = TryCast(t, VisualStudiosTabPage)
                If tab IsNot Nothing AndAlso tab.Name <> String.Empty AndAlso Not oldOrder.ContainsKey(tab.Name) Then
                    oldOrder.Add(tab.Name, tab.Index)
                End If
            Next

            For Each t As VisualStudiosTabPage In Me.TabPages
                t.Visible = False
            Next

            Me._SelectedTabPage = value
            If Me._SelectedTabPage IsNot Nothing Then
                'Very interesting thing happens here, setting this control to visible 
                'changes the actual sequence order of the Controls collection (should set it to index 0)
                'This is why I need to use oldOrder to set the order back (below)
                Me._SelectedTabPage.Visible = True
            End If
            For Each element As KeyValuePair(Of String, Integer) In oldOrder
                If element.Key <> String.Empty Then
                    Me.Controls.SetChildIndex(Me.TabPages(element.Key), element.Value)
                End If
            Next
            If changed Then
                Me.OnSelectedTabChanged(EventArgs.Empty)
            End If
            Me.Invalidate()
        End Set
    End Property

    <System.ComponentModel.Browsable(False)> _
    <Description(VisualStudiosTabControlResources.TabCountDescription)> _
    Public ReadOnly Property TabCount() As Integer
        Get
            Return Me.TabPages.Count
        End Get
    End Property

    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property SelectedIndex() As Integer
        Get
            If Me.SelectedTabPage IsNot Nothing Then
                Return Me.SelectedTabPage.Index
            End If
            Return -1
        End Get
    End Property

    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property DefaultChildSize() As Size
        Get
            Return New Size(Me.Width - 107 - Me._TabWidthInflation, Me.Height - 12)
        End Get
    End Property

    <System.ComponentModel.Browsable(False)> _
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return Color.Transparent
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value
        End Set
    End Property

    <System.ComponentModel.Browsable(False)> _
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overloads Property BorderStyle() As BorderStyle
        Get
            Return Windows.Forms.BorderStyle.None
        End Get
        Set(ByVal value As BorderStyle)
            MyBase.BorderStyle = value
        End Set
    End Property

    Private _ImageList As System.Windows.Forms.ImageList = Nothing
    <DefaultValue(GetType(ImageList), Nothing)> _
    <Description(VisualStudiosTabControlResources.ImageListDescription)> _
    Public Property ImageList() As System.Windows.Forms.ImageList
        Get
            Return Me._ImageList
        End Get
        Set(ByVal value As System.Windows.Forms.ImageList)
            Me._ImageList = value
            If Me._ImageList Is Nothing Then
                For Each t As VisualStudiosTabPage In Me.TabPages
                    t.ImageKey = Nothing
                Next
            End If
        End Set
    End Property

    Private _TabWidthInflation As Integer = 0
    <DefaultValue(GetType(Integer), "0")> _
    <Description(VisualStudiosTabControlResources.TabWidthInflationDescription)> _
    Public Property TabWidthInflation() As Integer
        Get
            Return Me._TabWidthInflation
        End Get
        Set(ByVal value As Integer)
            If Not (value >= 0 AndAlso value <= 100) Then
                Throw New ArgumentException(VisualStudiosTabControlResources.InvalidTabWidthInflation)
            End If
            Dim changed As Boolean = Not Object.Equals(value, Me._TabWidthInflation)
            Me._TabWidthInflation = value
            If changed Then
                Me.OnTabWidthInflationChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Protected ReadOnly Property TabDropDownIsShown() As Boolean
        Get
            Return (Me.MaxShowableTabIndex < Me.TabPages.Count)
        End Get
    End Property

    Protected ReadOnly Property MinimumTabDraw() As Integer
        Get
            If Me.MaxShowableTabIndex > Me.TabCount Then
                Return Me.TabCount
            End If
            Return Me.MaxShowableTabIndex
        End Get
    End Property

    <Browsable(False)> _
    <Bindable(False)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property RightToLeft() As System.Windows.Forms.RightToLeft
        Get
            Return MyBase.RightToLeft
        End Get
        Set(ByVal value As System.Windows.Forms.RightToLeft)
            MyBase.RightToLeft = value
        End Set
    End Property

    Protected ReadOnly Property MaxShowableTabIndex() As Integer
        Get
            Return CInt(Math.Floor((Me.Height - 38) / 32))
        End Get
    End Property

    <DefaultValue(GetType(Size), "300, 150")> _
    <Browsable(False)> _
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

    Protected NotOverridable Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(300, 300)
        End Get
    End Property

    Private _Skin As New VisualStudiosTabControlSkin(Me)
    <System.ComponentModel.Editor(GetType(VisualStudiosTabControlSkinEditor), GetType(UITypeEditor))> _
    <System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    <System.ComponentModel.Description(VisualStudiosTabControlResources.SkinDescription)> _
    Public ReadOnly Property Skin() As VisualStudiosTabControlSkin
        Get
            Return Me._Skin
        End Get
    End Property

    'Constuctor
    Public Sub New()
        MyBase.New()
        Me.InitializeComponent()
    End Sub

    'Methods
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MinimumSize = New Size(300, 150)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me._Skin.TabPage.SelectedTabPage.GradientSettings.StartColor = Color.White
        Me._Skin.TabPage.SelectedTabPage.GradientSettings.EndColor = Color.White
        Me._Skin.TabPage.MouseHoverTabPage.TabRightBorderColor = Color.FromArgb(131, 151, 162)
    End Sub

    Private Sub SetSelectedTabDesignMode(ByVal tab As VisualStudiosTabPage)
        If Me.DesignMode Then
            Dim changeService As IComponentChangeService = TryCast(Me.GetService(GetType(IComponentChangeService)), IComponentChangeService)
            If changeService IsNot Nothing Then
                changeService.OnComponentChanging(Me, TypeDescriptor.GetProperties(Me)("SelectedTab"))
                Dim service As ISelectionService = TryCast(Me.Site.GetService(GetType(ISelectionService)), ISelectionService)
                If service IsNot Nothing Then
                    service.SetSelectedComponents(New IComponent() {tab})
                End If
                changeService.OnComponentChanged(Me, TypeDescriptor.GetProperties(Me)("SelectedTab"), Nothing, Nothing)
            End If
        End If
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Protected Overridable Sub OnSelectedTabChanged(ByVal e As EventArgs)
        RaiseEvent SelectedTabChanged(Me, e)
        Me.OnSelectedIndexChanged(EventArgs.Empty)
    End Sub

    Protected Overridable Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Protected Overridable Sub OnTabGlyphClicked(ByVal e As System.EventArgs)
        RaiseEvent TabGlyphClicked(Me, e)
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        If Not TypeOf e.Control Is VisualStudiosTabPage Then
            Throw New ArgumentException(VisualStudiosTabControlResources.InvalidControlAdded)
        End If
        If Not Me._SelectedTabPage Is Nothing Then
            Me._SelectedTabPage.Visible = False
        End If
        Me._SelectedTabPage = DirectCast(e.Control, VisualStudiosTabPage)
        Me._SelectedTabPage.Visible = True
        Me.SetSelectedTabDesignMode(Me._SelectedTabPage)
        MyBase.OnControlAdded(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
        If Not TypeOf e.Control Is VisualStudiosTabPage Then
            Return
        End If
        If Me.TabPages.Count > 0 Then
            Me.SelectedTabPage = DirectCast(Me.TabPages(0), VisualStudiosTabPage)
        Else
            Me.SelectedTabPage = Nothing
        End If
        MyBase.OnControlRemoved(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.OnDrawFillGradient(e)
        Me.OnDrawBorder(e)
        Me.OnDrawTabs(e)
        Me.OnDrawTabContent(e)
        Me.OnDrawTabDropDown(e)
    End Sub

    Protected Overridable Sub OnTabWidthInflationChanged(ByVal e As System.EventArgs)
        If Me.TabCount > 0 Then
            For Each t As VisualStudiosTabPage In Me.TabPages
                If Me._TabWidthInflation = 0 Then
                    t.Location = New Point(101, 6)
                Else
                    t.Location = New Point(101 + Me._TabWidthInflation, 6)
                End If
                t.Size = Me.DefaultChildSize
            Next
        End If
        Me.Invalidate()
        RaiseEvent TabWidthInflationChanged(Me, e)
    End Sub

    Protected Overridable Sub OnDrawBorder(ByVal e As PaintEventArgs)
        With e.Graphics
            Dim min As Integer = Me.MinimumTabDraw
            .SmoothingMode = SmoothingMode.HighQuality
            Using outerPen As New Pen(Me.Skin.TabControl.OuterBorderColor)
                .DrawArc(outerPen, 1, 0, 10, 10, 180, 90)
                .DrawLine(outerPen, 6, 0, Me.ClientRectangle.Width - 1, 0)
                .DrawLine(outerPen, Me.ClientRectangle.Width - 1, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
                .DrawArc(outerPen, 1, (32 * min), 9, 10, 90, 90)
                .DrawLine(outerPen, 1, 6, 1, (32 * (min)) + 4)
                .DrawArc(outerPen, 85 + Me._TabWidthInflation, (32 * (min + 1)), 10, 10, -90, 90)
                .DrawLine(outerPen, 95 + Me._TabWidthInflation, Me.ClientRectangle.Height - 1, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
                .DrawLine(outerPen, 95 + Me._TabWidthInflation, (32 * (min + 1)) + 6, 95 + Me._TabWidthInflation, Me.ClientRectangle.Height - 1)
                .DrawLine(outerPen, 6, (32 * (min) + 11), 90 + Me._TabWidthInflation, 32 * (min + 1))
            End Using
            If Me.SelectedTabPage Is Nothing AndAlso Me.DesignMode Then
                Using dashPen As New Pen(Me.Skin.TabControl.InnerBorderColor)
                    .SmoothingMode = SmoothingMode.None
                    dashPen.DashStyle = DashStyle.Dot
                    .DrawRectangle(dashPen, New Rectangle(101 + Me._TabWidthInflation, 6, Me.Width - 108 - Me._TabWidthInflation, Me.Height - 13))
                    .SmoothingMode = SmoothingMode.HighQuality
                End Using
                Using fontBrush As New SolidBrush(Me.ForeColor)
                    Using font As New Font("Tahoma", 8.25F, FontStyle.Italic)
                        .DrawString(VisualStudiosTabControlResources.UnselectedString, font, fontBrush, CSng(Me.Width / 2) + 35, CSng(Me.Height / 2) - 3)
                    End Using
                End Using
            ElseIf Me.SelectedTabPage Is Nothing AndAlso Not Me.DesignMode Then
                Using innerBorder As New Pen(Me.Skin.TabControl.InnerBorderColor)
                    .SmoothingMode = SmoothingMode.None
                    .DrawRectangle(innerBorder, New Rectangle(101 + Me._TabWidthInflation, 6, Me.Width - 108 - Me._TabWidthInflation, Me.Height - 13))
                    .SmoothingMode = SmoothingMode.HighQuality
                End Using
            End If
        End With
    End Sub

    Protected Overridable Sub OnDrawFillGradient(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim min As Integer = Me.MinimumTabDraw
        Using path As New GraphicsPath()
            path.AddLine(New PointF(4, 0), New PointF(Me.Width, 0))
            path.AddLine(path.GetLastPoint(), New PointF(Me.Width, Me.Height))
            path.AddLine(path.GetLastPoint(), New PointF(95 + Me._TabWidthInflation, Me.Height))
            path.AddLine(path.GetLastPoint(), New PointF(95 + Me._TabWidthInflation, 32 * (min + 1) + 3))
            path.AddLine(path.GetLastPoint(), New PointF(93 + Me._TabWidthInflation, 32 * (min + 1) + 1))
            path.AddLine(path.GetLastPoint(), New PointF(6, (32 * (min) + 11)))
            path.AddLine(path.GetLastPoint(), New PointF(4, (min * 32) + 11))
            path.AddLine(path.GetLastPoint(), New PointF(1, 7 + (min * 32)))
            path.AddLine(path.GetLastPoint(), New PointF(0, 4))
            path.CloseFigure()
            e.Graphics.SetClip(path)
        End Using
        Using tabBrush As LinearGradientBrush = New Drawing2D.LinearGradientBrush(New Rectangle(1, 0, 95 + Me._TabWidthInflation, Me.Height), _
                                                                                  Me.Skin.TabPage.UnselectedTabPage.GradientSettings.StartColor, _
                                                                                  Me.Skin.TabPage.UnselectedTabPage.GradientSettings.EndColor, _
                                                                                  Me.Skin.TabPage.UnselectedTabPage.GradientSettings.LinearGradientMode)
            e.Graphics.FillRectangle(tabBrush, tabBrush.Rectangle)
        End Using
        Using backBrush As New SolidBrush(Me.Skin.TabControl.OuterBackColor)
            e.Graphics.FillRectangle(backBrush, New Rectangle(95 + Me._TabWidthInflation, 0, Me.Width - 96, Me.Height - 1))
        End Using
        e.Graphics.ResetClip()
    End Sub

    Protected Overridable Sub OnDrawTabs(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.None

        Dim index As Integer = 0
        Dim min As Integer = Me.MinimumTabDraw
        Dim y As Integer = 0
        Dim drawDividers As Boolean = True
        Dim tab As VisualStudiosTabPage = Nothing
        Dim mouseOver As Boolean = False

        Do Until index = min
            tab = DirectCast(Me.TabPages(index), VisualStudiosTabPage)
            y = tab.SideTabClientRectangle.Y
            mouseOver = tab.SideTabClientRectangle.Contains(Me.ClientCursorPosition)
            If Me.Skin.TabControl.DividerSkin.DrawDividers Then
                If index = 0 Then
                    Using bottomPen As New Pen(Me.Skin.TabControl.DividerSkin.BottomColor)
                        e.Graphics.DrawLine(bottomPen, 6, 5, 93 + Me._TabWidthInflation, 5)
                    End Using
                ElseIf index = min - 1 Then
                    Using topPen As New Pen(Me.Skin.TabControl.DividerSkin.TopColor)
                        e.Graphics.DrawLine(topPen, 6, y + 32, 93 + Me._TabWidthInflation, y + 32)
                    End Using
                End If

                Using topPen As New Pen(Me.Skin.TabControl.DividerSkin.TopColor)
                    e.Graphics.DrawLine(topPen, 6, y, 93 + Me._TabWidthInflation, y)
                End Using
                Using bottomPen As New Pen(Me.Skin.TabControl.DividerSkin.BottomColor)
                    e.Graphics.DrawLine(bottomPen, 6, y + 31, 93 + Me._TabWidthInflation, y + 31)
                End Using
            End If

            Select Case True
                Case mouseOver AndAlso Not Me.DesignMode AndAlso Not Me.SelectedTabPage Is Me.TabPages(index)
                    Using tabTip As New Pen(Me.Skin.TabPage.MouseHoverTabPage.TabTipColor)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 2, y)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 0, y + 29)
                        e.Graphics.DrawLine(tabTip, 0, y + 29, 2, y + 31)
                    End Using
                    Using tabBorder As New Pen(Me.Skin.TabPage.MouseHoverTabPage.TabBorderColor)
                        e.Graphics.DrawLine(tabBorder, 3, y, 100 + Me._TabWidthInflation, y)
                        e.Graphics.DrawLine(tabBorder, 3, y + 31, 100 + Me._TabWidthInflation, y + 31)
                    End Using
                    Using tabTipInside As New Pen(Me.Skin.TabPage.MouseHoverTabPage.TabTipInnerColor)
                        e.Graphics.DrawLine(tabTipInside, 1, y + 2, 1, y + 29)
                        e.Graphics.DrawLine(tabTipInside, 2, y + 1, 2, y + 30)
                    End Using
                    Using tabBorderRight As New Pen(Me.Skin.TabPage.MouseHoverTabPage.TabRightBorderColor)
                        e.Graphics.DrawLine(tabBorderRight, 101 + Me._TabWidthInflation, y + 1, 101 + Me._TabWidthInflation, y + 30)
                    End Using
                    Using fillBrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(3, y + 1, 98 + Me._TabWidthInflation, 30), _
                                                                                     Me.Skin.TabPage.MouseHoverTabPage.GradientSettings.StartColor, _
                                                                                     Me.Skin.TabPage.MouseHoverTabPage.GradientSettings.EndColor, _
                                                                                     Me.Skin.TabPage.MouseHoverTabPage.GradientSettings.LinearGradientMode)
                        e.Graphics.FillRectangle(fillBrush, fillBrush.Rectangle)
                    End Using
                Case Me.SelectedTabPage Is Me.TabPages(index)
                    Using tabTip As New Pen(Me.Skin.TabPage.SelectedTabPage.TabTipColor)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 2, y)
                        e.Graphics.DrawLine(tabTip, 0, y + 2, 0, y + 29)
                        e.Graphics.DrawLine(tabTip, 0, y + 29, 2, y + 31)
                    End Using
                    Using tabBorder As New Pen(Me.Skin.TabPage.SelectedTabPage.TabBorderColor)
                        e.Graphics.DrawLine(tabBorder, 3, y, 100 + Me._TabWidthInflation, y)
                        e.Graphics.DrawLine(tabBorder, 3, y + 31, 100 + Me._TabWidthInflation, y + 31)
                    End Using
                    Using tabBorderRight As New Pen(Me.Skin.TabPage.SelectedTabPage.TabRightBorderColor)
                        e.Graphics.DrawLine(tabBorderRight, 101 + Me._TabWidthInflation, y + 1, 101 + Me._TabWidthInflation, y + 30)
                    End Using

                    Using fillBrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(2, y + 1, 99 + Me._TabWidthInflation, 30), _
                                                                                     Me.Skin.TabPage.SelectedTabPage.GradientSettings.StartColor, _
                                                                                     Me.Skin.TabPage.SelectedTabPage.GradientSettings.EndColor, _
                                                                                     Me.Skin.TabPage.SelectedTabPage.GradientSettings.LinearGradientMode)
                        e.Graphics.FillRectangle(fillBrush, fillBrush.Rectangle)
                    End Using
                    Using tabTipInside As New Pen(Me.Skin.TabPage.SelectedTabPage.TabTipInnerColor)
                        e.Graphics.DrawLine(tabTipInside, 1, y + 2, 1, y + 29)
                        e.Graphics.DrawLine(tabTipInside, 2, y + 1, 2, y + 30)
                    End Using
            End Select
            tab.Invalidate()
            index += 1
        Loop

    End Sub

    Protected Overridable Sub OnDrawTabContent(ByVal e As PaintEventArgs)
        Dim textSize As Size = Nothing
        Dim index As Integer = 0
        Dim min As Integer = Me.MinimumTabDraw
        Dim text As String = Nothing
        Dim location As New PointF(12.0F, 0)
        Dim tab As VisualStudiosTabPage = Nothing
        Dim increase As Integer = 0

        Do Until index = min
            increase = 0
            location.Y = DirectCast(Me.TabPages(index), VisualStudiosTabPage).SideTabClientRectangle.Y
            text = Me.TabPages(index).Text
            tab = DirectCast(Me.TabPages(index), VisualStudiosTabPage)
            If tab.ImageKey IsNot Nothing AndAlso tab.ImageKey <> String.Empty AndAlso tab.ImageKey <> VisualStudiosTabControlResources.NoneString AndAlso Me._ImageList IsNot Nothing AndAlso _
               Me._ImageList.Images.Keys.Contains(tab.ImageKey) Then
                Dim image As Image = Me._ImageList.Images(tab.ImageKey)
                increase = image.Width - 4
                e.Graphics.DrawImage(image, New Rectangle(6, CInt(location.Y + image.Height / 2), 16, 16))
            End If
            Select Case True
                Case Me.SelectedTabPage Is DirectCast(Me.TabPages(index), VisualStudiosTabPage)
                    textSize = TextRenderer.MeasureText(text, Me.Skin.TabPage.SelectedTabPage.FontSettings.Font)
                    Using textBrush As New SolidBrush(Me.Skin.TabPage.SelectedTabPage.FontSettings.FontColor)
                        e.Graphics.DrawString(text, _
                                              Me.Skin.TabPage.SelectedTabPage.FontSettings.Font, textBrush, location.X + increase, _
                                              CSng(location.Y + (15 - (textSize.Height / 2))))
                    End Using
                Case DirectCast(Me.TabPages(index), VisualStudiosTabPage).SideTabClientRectangle.Contains(Me.ClientCursorPosition) AndAlso Not Me.DesignMode
                    textSize = TextRenderer.MeasureText(text, Me.Skin.TabPage.MouseHoverTabPage.FontSettings.Font)
                    Using textBrush As New SolidBrush(Me.Skin.TabPage.MouseHoverTabPage.FontSettings.FontColor)
                        e.Graphics.DrawString(text, _
                                              Me.Skin.TabPage.MouseHoverTabPage.FontSettings.Font, textBrush, location.X + increase, _
                                              CSng(location.Y + (15 - (textSize.Height / 2))))
                    End Using
                Case Else
                    textSize = TextRenderer.MeasureText(text, Me.Skin.TabPage.UnselectedTabPage.FontSettings.Font)
                    Using textBrush As New SolidBrush(Me.Skin.TabPage.UnselectedTabPage.FontSettings.FontColor)
                        e.Graphics.DrawString(text, _
                                              Me.Skin.TabPage.UnselectedTabPage.FontSettings.Font, textBrush, location.X + increase, _
                                              CSng(location.Y + (15 - (textSize.Height / 2))))
                    End Using
            End Select

            index += 1
        Loop

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseClick(e)
        Dim cursorPosition As Point = Me.ClientCursorPosition
        Dim tabClientRect As Rectangle = Nothing
        Dim min As Integer = Me.MinimumTabDraw
        Dim tabdropDownClientRect As Rectangle = New Rectangle(81 + Me._TabWidthInflation, (32 * min) + 12, 14, 14)
        If tabdropDownClientRect.Contains(cursorPosition) AndAlso Me.TabDropDownIsShown AndAlso Not Me.DesignMode Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If Me._TabDropDownMenuStrip IsNot Nothing Then Me._TabDropDownMenuStrip.Dispose()
                Me._TabDropDownMenuStrip = New ContextMenuStrip()
                With Me._TabDropDownMenuStrip
                    For Each t As VisualStudiosTabPage In Me.TabPages
                        If Not t.SideTabVisible Then
                            Dim item As New ToolStripMenuItem(t.Text, Nothing, AddressOf Me.OnTabDropDownItemClicked)
                            item.Tag = t.Index
                            .Items.Add(item)
                        End If
                    Next
                End With
                Me.OnTabGlyphClicked(EventArgs.Empty)
                Me._TabDropDownMenuStrip.Show(Me, New Point(81 + Me._TabWidthInflation, (32 * min) + 27))
            End If
            Return
        End If
        For Each tab As VisualStudiosTabPage In Me.TabPages
            If tab.SideTabVisible AndAlso _
               tab.SideTabClientRectangle.Contains(cursorPosition) AndAlso _
               e.Button = Windows.Forms.MouseButtons.Left Then
                Me.SelectedTabPage = DirectCast(Me.TabPages(tab.Index), VisualStudiosTabPage)
                Me.SetSelectedTabDesignMode(Me.SelectedTabPage)
            End If
        Next
    End Sub

    Protected Overridable Sub OnDrawTabDropDown(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.None
        Dim min As Integer = Me.MinimumTabDraw
        If Me.MaxShowableTabIndex < Me.TabPages.Count Then
            Dim clientRect As Rectangle = New Rectangle(81 + Me._TabWidthInflation, (32 * min) + 12, 14, 14)
            Dim points() As Point = {New Point(85 + Me._TabWidthInflation, (32 * min) + 19), _
                                     New Point(88 + Me._TabWidthInflation, (32 * min) + 23), _
                                     New Point(92 + Me._TabWidthInflation, (32 * min) + 19)}
            If clientRect.Contains(Me.ClientCursorPosition) AndAlso Not Me.DesignMode Then
                Using selectionPen As New Pen(Me.Skin.TabControl.GlyphSkin.GlyphBorderColor)
                    e.Graphics.DrawRectangle(selectionPen, clientRect)
                End Using
                Using selectionBrush As New SolidBrush(Me.Skin.TabControl.GlyphSkin.GlyphHighlightColor)
                    e.Graphics.FillRectangle(selectionBrush, New Rectangle(clientRect.X + 1, clientRect.Y + 1, 13, 13))
                End Using
            End If
            Using glyphBrush As New SolidBrush(Me.Skin.TabControl.GlyphSkin.GlyphColor)
                e.Graphics.SmoothingMode = SmoothingMode.None
                e.Graphics.FillRectangle(glyphBrush, 85 + Me._TabWidthInflation, (32 * min) + 16, 7, 2)
                e.Graphics.FillPolygon(glyphBrush, points)
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            End Using
        End If
    End Sub

    Protected Overridable Sub OnTabDropDownItemClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim from As Integer = CInt(DirectCast(sender, ToolStripMenuItem).Tag)
        Dim [to] As Integer = DirectCast(Me.TabPages(Me.MinimumTabDraw - 1), VisualStudiosTabPage).Index
        Dim tab As VisualStudiosTabPage = DirectCast(Me.TabPages(from), VisualStudiosTabPage)
        Me.Controls.SetChildIndex(Me.TabPages([to]), from)
        Me.Controls.SetChildIndex(tab, [to])
        Me.SelectedTabPage = DirectCast(Me.TabPages([to]), VisualStudiosTabPage)
        Me.Invalidate()
        RaiseEvent TabDropDownItemClicked(Me, e)
    End Sub

    'Nested types
    <Designer(GetType(VisualStudiosTabPage.VisualStudiosTabDesigner))> _
    <ToolboxItem(False)> _
    Public Class VisualStudiosTabPage
        Inherits System.Windows.Forms.ScrollableControl

        'Properties
        <Browsable(False)> _
        Public ReadOnly Property Index() As Integer
            Get
                Dim owner As VisualStudiosTabControl = Me.Owner
                If owner IsNot Nothing Then
                    Return owner.TabPages.IndexOf(Me)
                End If
                Return -1
            End Get
        End Property

        <Browsable(False)> _
       <EditorBrowsable(EditorBrowsableState.Never)> _
       Public Overrides Property Anchor() As AnchorStyles
            Get
                Return MyBase.Anchor
            End Get
            Set(ByVal value As AnchorStyles)
                MyBase.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Bottom
            End Set
        End Property

        <Browsable(False)> _
        Public ReadOnly Property Selected() As Boolean
            Get
                Dim owner As VisualStudiosTabControl = Me.Owner
                If owner IsNot Nothing Then
                    Return owner.SelectedTabPage Is Me
                End If
                Return False
            End Get
        End Property

        <Browsable(False)> _
        Public ReadOnly Property SideTabClientRectangle() As Rectangle
            Get
                Dim owner As VisualStudiosTabControl = Me.Owner
                If owner IsNot Nothing Then
                    Return New Rectangle(2, 6 + (Me.Index * 32), 99 + owner._TabWidthInflation, 31)
                End If
                Return Rectangle.Empty
            End Get
        End Property

        <Browsable(False)> _
        Public ReadOnly Property SideTabVisible() As Boolean
            Get
                Dim owner As VisualStudiosTabControl = Me.Owner
                If owner IsNot Nothing Then
                    Return (Me.Index < owner.MinimumTabDraw)
                End If
                Return False
            End Get
        End Property

        <Browsable(False)> _
        Public ReadOnly Property Owner() As VisualStudiosTabControl
            Get
                Dim tabControl As VisualStudiosTabControl = TryCast(Me.Parent,  _
                                                                    VisualStudiosTabControl)
                If tabControl IsNot Nothing Then
                    Return tabControl
                End If
                Return Nothing
            End Get
        End Property

        <Browsable(False)> _
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Property BackColor() As System.Drawing.Color
            Get
                Dim owner As VisualStudiosTabControl = Me.Owner
                If owner IsNot Nothing Then
                    Return owner.Skin.TabControl.InnerBackColor
                End If
                Return MyBase.BackColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                MyBase.BackColor = value
            End Set
        End Property

        <Browsable(False)> _
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overloads Property Size() As Size
            Get
                Return MyBase.Size
            End Get
            Set(ByVal value As Size)
                MyBase.Size = value
            End Set
        End Property

        Private _ImageKey As String = Nothing
        <TypeConverter(GetType(VisualStudiosTabPageImageKeyConverter))> _
        <DefaultValue(GetType(String), Nothing)> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Editor(GetType(VisualStudiosTabPageImageKeyEditor), GetType(UITypeEditor))> _
        Public Property ImageKey() As String
            Get
                Return Me._ImageKey
            End Get
            Set(ByVal value As String)
                Dim owner As VisualStudiosTabControl = Me.Owner
                If owner IsNot Nothing Then
                    If owner.ImageList IsNot Nothing AndAlso Not owner.ImageList.Images.Keys.Contains(value) Then
                        Me._ImageKey = Nothing
                        owner.Invalidate()
                        Return
                    End If
                End If
                If value Is Nothing Then
                    Me._ImageKey = Nothing
                End If
                Me._ImageKey = value
                If owner IsNot Nothing Then
                    owner.Invalidate()
                End If
            End Set
        End Property

        'Contructor
        Public Sub New()
            MyBase.New()
            MyBase.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Bottom
            MyBase.Padding = New Padding(6)
            MyBase.AutoScroll = True
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Dim owner As VisualStudiosTabControl = Me.Owner
            If owner IsNot Nothing Then
                Me.Size = owner.DefaultChildSize
            End If
        End Sub

        'Methods
        Protected Overrides Sub InitLayout()
            MyBase.InitLayout()
            MyBase.Location = New Point(101, 6)
        End Sub

        Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
            MyBase.OnLocationChanged(e)
            Dim owner As VisualStudiosTabControl = Me.Owner
            If owner Is Nothing Then
                MyBase.Location = New Point(101, 6)
            Else
                MyBase.Location = New Point(101 + owner._TabWidthInflation, 6)
            End If
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
            MyBase.OnSizeChanged(e)
            If Me.Parent IsNot Nothing AndAlso TypeOf Me.Parent Is VisualStudiosTabControl Then
                Me.Size = DirectCast(Me.Parent, VisualStudiosTabControl).DefaultChildSize
            End If
        End Sub

        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)
            If Not (TypeOf Me.Parent Is VisualStudiosTabControl) AndAlso Not (Me.Parent Is Nothing) Then
                Throw New ArgumentException(VisualStudiosTabControlResources.InvalidControlAdded)
            End If
            MyBase.OnParentChanged(e)
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            MyBase.OnTextChanged(e)
            Dim parent As VisualStudiosTabControl = TryCast(Me.Parent, VisualStudiosTabControl)
            If parent IsNot Nothing Then
                parent.Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            MyBase.OnPaint(e)
            Dim owner As VisualStudiosTabControl = Me.Owner
            If owner IsNot Nothing Then
                Using borderPen As New Pen(owner.Skin.TabControl.InnerBorderColor)
                    e.Graphics.DrawRectangle(borderPen, New Rectangle(Me.ClientRectangle.Location, _
                                                                      New Size(Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)))
                End Using

                If Me.Selected AndAlso Me.SideTabVisible Then
                    Using tabBorderRight As New Pen(owner.Skin.TabPage.SelectedTabPage.TabRightBorderColor)
                        e.Graphics.DrawLine(tabBorderRight, 0, (Me.Index * 32) + 1, 0, (Me.Index * 32) + 30)
                    End Using
                End If

                Dim index As Integer = 0
                Dim mouseOver As Boolean = False
                Dim tab As VisualStudiosTabPage = Nothing
                Do Until index = owner.MinimumTabDraw
                    tab = DirectCast(owner.TabPages(index), VisualStudiosTabPage)
                    mouseOver = tab.SideTabClientRectangle.Contains(owner.ClientCursorPosition)

                    If mouseOver AndAlso Not tab.Selected AndAlso Not Me.DesignMode Then
                        Using tabBorderRight As New Pen(owner.Skin.TabPage.MouseHoverTabPage.TabRightBorderColor)
                            e.Graphics.DrawLine(tabBorderRight, 0, (index * 32) + 1, 0, (index * 32) + 30)
                        End Using
                    End If

                    index += 1
                Loop
            End If
        End Sub

        Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
            MyBase.OnMouseEnter(e)
            Me.Owner.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            Me.Owner.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            Me.Owner.Invalidate()
        End Sub

        Protected Overrides Sub OnScroll(ByVal se As System.Windows.Forms.ScrollEventArgs)
            MyBase.OnScroll(se)
            Me.Invalidate()
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetType().Name
        End Function

        'Nested types
        Protected Friend NotInheritable Class VisualStudiosTabDesigner
            Inherits System.Windows.Forms.Design.ScrollableControlDesigner

            'Properties
            Public ReadOnly Property HostControl() As VisualStudiosTabPage
                Get
                    Return DirectCast(Me.Control, VisualStudiosTabPage)
                End Get
            End Property

            Private _Verbs As New DesignerVerbCollection(New DesignerVerb() {New DesignerVerb("Select VisualStudiosTabControl", AddressOf Me.OnSelectHostControl)})
            Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
                Get
                    Return Me._Verbs
                End Get
            End Property

            Private _SelectionService As ISelectionService = Nothing
            Public ReadOnly Property SelectionService() As ISelectionService
                Get
                    If Me._SelectionService Is Nothing Then
                        Me._SelectionService = DirectCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
                    End If
                    Return Me._SelectionService
                End Get
            End Property

            Private _DesignerActionUIService As DesignerActionUIService
            Public ReadOnly Property DesignerActionUIService() As DesignerActionUIService
                Get
                    If Me._DesignerActionUIService Is Nothing Then
                        Me._DesignerActionUIService = DirectCast(Me.GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
                    End If
                    Return Me._DesignerActionUIService
                End Get
            End Property

            'Contructor
            Public Sub New()
                MyBase.New()
            End Sub

            'Methods
            Private Sub OnSelectHostControl(ByVal sender As Object, ByVal e As EventArgs)
                If Me.HostControl.Parent IsNot Nothing Then
                    Me.SelectionService.SetSelectedComponents(New IComponent() {Me.HostControl.Parent})
                    Me.DesignerActionUIService.HideUI(Me.HostControl)
                End If
            End Sub

            Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
                Get
                    Return System.Windows.Forms.Design.SelectionRules.Visible
                End Get
            End Property

            Protected Overrides Sub PostFilterProperties(ByVal properties As System.Collections.IDictionary)
                properties.Remove("Anchor")
                properties.Remove("TabStop")
                properties.Remove("TabIndex")
                properties.Remove("Dock")
                properties.Remove("BackColor")
                MyBase.PostFilterProperties(properties)
            End Sub

            Public Overrides Sub InitializeNewComponent(ByVal defaultValues As System.Collections.IDictionary)
                MyBase.InitializeNewComponent(defaultValues)
                Me.Control.Visible = True
            End Sub

        End Class

    End Class

    <System.Serializable()> _
    Public Class VisualStudiosTabControlSkin

        'Properties
        Private _Owner As VisualStudiosTabControl
        Protected ReadOnly Property Owner() As VisualStudiosTabControl
            Get
                Return Me._Owner
            End Get
        End Property

        Private _TabControl As New TabControlSkin()
        <Category("VisualStudiosTabControlSkinSettings")> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property TabControl() As TabControlSkin
            Get
                Return Me._TabControl
            End Get
        End Property

        Private _TabPage As New TabPageSkin()
        <Category("VisualStudiosTabControlSkinSettings")> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property TabPage() As TabPageSkin
            Get
                Return Me._TabPage
            End Get
        End Property

        Private _PropertyValueUIService As Drawing.Design.IPropertyValueUIService
        Protected ReadOnly Property PropertyValueUIService() As Drawing.Design.IPropertyValueUIService
            Get
                If Me._PropertyValueUIService Is Nothing AndAlso Me._Owner IsNot Nothing Then
                    Me._PropertyValueUIService = TryCast(Me._Owner.GetService(GetType(IPropertyValueUIService)), IPropertyValueUIService)
                End If
                Return Me._PropertyValueUIService
            End Get
        End Property

        'Constructor
        Public Sub New(ByVal owner As VisualStudiosTabControl)
            If owner Is Nothing Then
                Throw New ArgumentNullException("owner")
            End If
            Me._Owner = owner
            If Me.PropertyValueUIService IsNot Nothing Then
                AddHandler Me.PropertyValueUIService.PropertyUIValueItemsChanged, AddressOf Me.OnPropertyValueUIItemsChanged
            End If
        End Sub

        'Methods
        Public Overrides Function ToString() As String
            Return Me.GetType().Name
        End Function

        Protected Overridable Sub OnPropertyValueUIItemsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me._Owner.Invalidate()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            If Me.PropertyValueUIService IsNot Nothing Then
                RemoveHandler Me.PropertyValueUIService.PropertyUIValueItemsChanged, AddressOf Me.OnPropertyValueUIItemsChanged
            End If
        End Sub

        Public Function Clone() As VisualStudiosTabControlSkin
            Return VisualStudiosTabControlSkin.Clone(Me)
        End Function

        Public Shared Function Clone(ByVal prototype As VisualStudiosTabControlSkin) As VisualStudiosTabControlSkin
            Dim copy As New VisualStudiosTabControlSkin(prototype.Owner)
            With copy

                With .TabControl
                    .DividerSkin.BottomColor = prototype.TabControl.DividerSkin.BottomColor
                    .DividerSkin.DrawDividers = prototype.TabControl.DividerSkin.DrawDividers
                    .DividerSkin.TopColor = prototype.TabControl.DividerSkin.TopColor
                    .GlyphSkin.GlyphBorderColor = prototype.TabControl.GlyphSkin.GlyphBorderColor
                    .GlyphSkin.GlyphColor = prototype.TabControl.GlyphSkin.GlyphColor
                    .GlyphSkin.GlyphHighlightColor = prototype.TabControl.GlyphSkin.GlyphHighlightColor
                    .InnerBackColor = prototype.TabControl.InnerBackColor
                    .InnerBorderColor = prototype.TabControl.InnerBorderColor
                    .OuterBackColor = prototype.TabControl.OuterBackColor
                    .OuterBorderColor = prototype.TabControl.OuterBorderColor
                End With

                With .TabPage
                    .MouseHoverTabPage.FontSettings.Font = DirectCast(prototype.TabPage.MouseHoverTabPage.FontSettings.Font.Clone(), Drawing.Font)
                    .MouseHoverTabPage.FontSettings.FontColor = prototype.TabPage.MouseHoverTabPage.FontSettings.FontColor
                    .MouseHoverTabPage.GradientSettings.EndColor = prototype.TabPage.MouseHoverTabPage.GradientSettings.EndColor
                    .MouseHoverTabPage.GradientSettings.LinearGradientMode = prototype.TabPage.MouseHoverTabPage.GradientSettings.LinearGradientMode
                    .MouseHoverTabPage.GradientSettings.StartColor = prototype.TabPage.MouseHoverTabPage.GradientSettings.StartColor
                    .MouseHoverTabPage.TabBorderColor = prototype.TabPage.MouseHoverTabPage.TabBorderColor
                    .MouseHoverTabPage.TabRightBorderColor = prototype.TabPage.MouseHoverTabPage.TabRightBorderColor
                    .MouseHoverTabPage.TabTipColor = prototype.TabPage.MouseHoverTabPage.TabTipColor
                    .MouseHoverTabPage.TabTipInnerColor = prototype.TabPage.MouseHoverTabPage.TabTipInnerColor

                    .SelectedTabPage.FontSettings.Font = DirectCast(prototype.TabPage.SelectedTabPage.FontSettings.Font.Clone(), Drawing.Font)
                    .SelectedTabPage.FontSettings.FontColor = prototype.TabPage.SelectedTabPage.FontSettings.FontColor
                    .SelectedTabPage.GradientSettings.EndColor = prototype.TabPage.SelectedTabPage.GradientSettings.EndColor
                    .SelectedTabPage.GradientSettings.LinearGradientMode = prototype.TabPage.SelectedTabPage.GradientSettings.LinearGradientMode
                    .SelectedTabPage.GradientSettings.StartColor = prototype.TabPage.SelectedTabPage.GradientSettings.StartColor
                    .SelectedTabPage.TabBorderColor = prototype.TabPage.SelectedTabPage.TabBorderColor
                    .SelectedTabPage.TabRightBorderColor = prototype.TabPage.SelectedTabPage.TabRightBorderColor
                    .SelectedTabPage.TabTipColor = prototype.TabPage.SelectedTabPage.TabTipColor
                    .SelectedTabPage.TabTipInnerColor = prototype.TabPage.SelectedTabPage.TabTipInnerColor

                    .UnselectedTabPage.FontSettings.Font = DirectCast(prototype.TabPage.UnselectedTabPage.FontSettings.Font.Clone(), Drawing.Font)
                    .UnselectedTabPage.FontSettings.FontColor = prototype.TabPage.UnselectedTabPage.FontSettings.FontColor
                    .UnselectedTabPage.GradientSettings.EndColor = prototype.TabPage.UnselectedTabPage.GradientSettings.EndColor
                    .UnselectedTabPage.GradientSettings.LinearGradientMode = prototype.TabPage.UnselectedTabPage.GradientSettings.LinearGradientMode
                    .UnselectedTabPage.GradientSettings.StartColor = prototype.TabPage.UnselectedTabPage.GradientSettings.StartColor
                End With

            End With
            Return copy
        End Function

        'Nested types
        <TypeConverter(GetType(ExpandableObjectConverter))> _
        <System.Serializable()> _
        Public Class TabControlSkin

            'Properties
            Private _GlyphSkin As New TabControlGlyphSkin()
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
            Public ReadOnly Property GlyphSkin() As TabControlGlyphSkin
                Get
                    Return Me._GlyphSkin
                End Get
            End Property

            Private _DividerSkin As New TabControlDividerSkin()
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
            Public ReadOnly Property DividerSkin() As TabControlDividerSkin
                Get
                    Return Me._DividerSkin
                End Get
            End Property

            Private _OuterBorderColor As Color = Color.FromArgb(145, 167, 180)
            Public Property OuterBorderColor() As Color
                Get
                    Return Me._OuterBorderColor
                End Get
                Set(ByVal value As Color)
                    Me._OuterBorderColor = value
                End Set
            End Property

            Private _InnerBorderColor As Color = Color.FromArgb(131, 151, 162)
            Public Property InnerBorderColor() As Color
                Get
                    Return Me._InnerBorderColor
                End Get
                Set(ByVal value As Color)
                    Me._InnerBorderColor = value
                End Set
            End Property

            Private _OuterBackColor As Color = Color.FromArgb(214, 214, 222)
            Public Property OuterBackColor() As Color
                Get
                    Return Me._OuterBackColor
                End Get
                Set(ByVal value As Color)
                    Me._OuterBackColor = value
                End Set
            End Property

            Private _InnerBackColor As Color = Color.FromArgb(224, 223, 227)
            Public Property InnerBackColor() As Color
                Get
                    Return Me._InnerBackColor
                End Get
                Set(ByVal value As Color)
                    Me._InnerBackColor = value
                End Set
            End Property

            'Methods
            Public Overrides Function ToString() As String
                Return Me.GetType().Name
            End Function

            'Nested types
            <TypeConverter(GetType(ExpandableObjectConverter))> _
            Public Class TabControlGlyphSkin

                'Properties
                Private _GlyphColor As Color = Color.Black
                Public Property GlyphColor() As Color
                    Get
                        Return Me._GlyphColor
                    End Get
                    Set(ByVal value As Color)
                        Me._GlyphColor = value
                    End Set
                End Property

                Private _GlyphBorderColor As Color = Color.FromArgb(75, 75, 111)
                Public Property GlyphBorderColor() As Color
                    Get
                        Return Me._GlyphBorderColor
                    End Get
                    Set(ByVal value As Color)
                        Me._GlyphBorderColor = value
                    End Set
                End Property

                Private _GlyphHighlightColor As Color = Color.FromArgb(255, 238, 194)
                Public Property GlyphHighlightColor() As Color
                    Get
                        Return Me._GlyphHighlightColor
                    End Get
                    Set(ByVal value As Color)
                        Me._GlyphHighlightColor = value
                    End Set
                End Property

                'Methods
                Public Overrides Function ToString() As String
                    Return Me.GetType().Name
                End Function

            End Class

            <TypeConverter(GetType(ExpandableObjectConverter))> _
            Public Class TabControlDividerSkin

                'Properties
                Private _TopColor As Color = Color.White
                Public Property TopColor() As Color
                    Get
                        Return Me._TopColor
                    End Get
                    Set(ByVal value As Color)
                        Me._TopColor = value
                    End Set
                End Property

                Private _BottomColor As Color = Color.FromArgb(222, 222, 229)
                Public Property BottomColor() As Color
                    Get
                        Return Me._BottomColor
                    End Get
                    Set(ByVal value As Color)
                        Me._BottomColor = value
                    End Set
                End Property

                Private _DrawDividers As Boolean = True
                Public Property DrawDividers() As Boolean
                    Get
                        Return Me._DrawDividers
                    End Get
                    Set(ByVal value As Boolean)
                        Me._DrawDividers = value
                    End Set
                End Property

                'Methods
                Public Overrides Function ToString() As String
                    Return Me.GetType().Name
                End Function

            End Class

        End Class

        <TypeConverter(GetType(ExpandableObjectConverter))> _
        <System.Serializable()> _
        Public Class TabPageSkin

            'Properties
            Private _SelectedTabPage As New TabPageSkin()
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
            Public ReadOnly Property SelectedTabPage() As TabPageSkin
                Get
                    Return Me._SelectedTabPage
                End Get
            End Property

            Private _MouseHoverTabPage As New TabPageSkin()
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
            Public ReadOnly Property MouseHoverTabPage() As TabPageSkin
                Get
                    Return Me._MouseHoverTabPage
                End Get
            End Property

            Private _UnselectedTabPage As New TabPageUnselectedSkin()
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
            Public ReadOnly Property UnselectedTabPage() As TabPageUnselectedSkin
                Get
                    Return Me._UnselectedTabPage
                End Get
            End Property

            'Methods
            Public Overrides Function ToString() As String
                Return Me.GetType().Name
            End Function

            'Nested types
            <TypeConverter(GetType(ExpandableObjectConverter))> _
            Public Class TabPageSkin

                'Properties
                Private _TabTipColor As Color = Color.FromArgb(230, 139, 44)
                Public Property TabTipColor() As Color
                    Get
                        Return Me._TabTipColor
                    End Get
                    Set(ByVal value As Color)
                        Me._TabTipColor = value
                    End Set
                End Property

                Private _TabTipInnerColor As Color = Color.FromArgb(255, 199, 60)
                Public Property TabTipInnerColor() As Color
                    Get
                        Return Me._TabTipInnerColor
                    End Get
                    Set(ByVal value As Color)
                        Me._TabTipInnerColor = value
                    End Set
                End Property

                Private _TabBorderColor As Color = Color.FromArgb(145, 155, 156)
                Public Property TabBorderColor() As Color
                    Get
                        Return Me._TabBorderColor
                    End Get
                    Set(ByVal value As Color)
                        Me._TabBorderColor = value
                    End Set
                End Property

                Private _TabRightBorderColor As Color = Color.FromArgb(173, 190, 204)
                Public Property TabRightBorderColor() As Color
                    Get
                        Return Me._TabRightBorderColor
                    End Get
                    Set(ByVal value As Color)
                        Me._TabRightBorderColor = value
                    End Set
                End Property

                Private _FontSettings As New VisualStudiosTabControlFontSettings()
                <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
                Public ReadOnly Property FontSettings() As VisualStudiosTabControlFontSettings
                    Get
                        Return Me._FontSettings
                    End Get
                End Property

                Private _GradientSettings As New TabPageGradientSettings()
                <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
                Public ReadOnly Property GradientSettings() As TabPageGradientSettings
                    Get
                        Return Me._GradientSettings
                    End Get
                End Property

                'Methods
                Public Overrides Function ToString() As String
                    Return Me.GetType().Name
                End Function

            End Class

            <TypeConverter(GetType(ExpandableObjectConverter))> _
            Public Class TabPageGradientSettings

                'Properties
                Private _LinearGradientMode As System.Drawing.Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal
                Public Property LinearGradientMode() As System.Drawing.Drawing2D.LinearGradientMode
                    Get
                        Return Me._LinearGradientMode
                    End Get
                    Set(ByVal value As System.Drawing.Drawing2D.LinearGradientMode)
                        Me._LinearGradientMode = value
                    End Set
                End Property

                Private _StartColor As Color = Color.White
                Public Property StartColor() As Color
                    Get
                        Return Me._StartColor
                    End Get
                    Set(ByVal value As Color)
                        Me._StartColor = value
                    End Set
                End Property

                Private _EndColor As Color = Color.FromArgb(214, 214, 222)
                Public Property EndColor() As Color
                    Get
                        Return Me._EndColor
                    End Get
                    Set(ByVal value As Color)
                        Me._EndColor = value
                    End Set
                End Property

                'Methods
                Public Overrides Function ToString() As String
                    Return Me.GetType().Name
                End Function

            End Class

            <TypeConverter(GetType(ExpandableObjectConverter))> _
            Public Class TabPageUnselectedSkin

                'Properties
                Private _FontSettings As New VisualStudiosTabControlFontSettings()
                <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
                Public ReadOnly Property FontSettings() As VisualStudiosTabControlFontSettings
                    Get
                        Return Me._FontSettings
                    End Get
                End Property

                Private _GradientSettings As New TabPageGradientSettings()
                <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
                Public ReadOnly Property GradientSettings() As TabPageGradientSettings
                    Get
                        Return Me._GradientSettings
                    End Get
                End Property

                'Methods
                Public Overrides Function ToString() As String
                    Return Me.GetType().Name
                End Function

            End Class

        End Class

    End Class

    Private Class VisualStudiosTabPageConverter
        Inherits ReferenceConverter

        'Contructor
        Public Sub New()
            MyBase.New(GetType(VisualStudiosTabPage))
        End Sub

        'Methods
        Protected Overrides Function IsValueAllowed(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object) As Boolean
            If context IsNot Nothing AndAlso value IsNot Nothing Then
                Dim host As VisualStudiosTabControl = DirectCast(context.Instance, VisualStudiosTabControl)
                Return host.TabPages.Contains(DirectCast(value, VisualStudiosTabPage))
            End If
        End Function

    End Class

    Private Class VisualStudiosTabPageImageKeyConverter
        Inherits StringConverter

        'Methods
        Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
            Dim tab As VisualStudiosTabPage = TryCast(context.Instance, VisualStudiosTabPage)
            If tab IsNot Nothing Then
                Dim owner As VisualStudiosTabControl = tab.Owner
                If owner IsNot Nothing Then
                    If owner.ImageList IsNot Nothing Then
                        Dim source As New List(Of String)(owner.ImageList.Images.Keys.Count + 1)
                        For Each element As String In owner.ImageList.Images.Keys
                            source.Add(element)
                        Next
                        source.Add(String.Empty)
                        Return New StandardValuesCollection(source)
                    Else
                        Return New StandardValuesCollection(New String() {String.Empty})
                    End If
                End If
            End If
            Return MyBase.GetStandardValues(context)
        End Function

        Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
            Return ((sourceType Is GetType(String)) OrElse MyBase.CanConvertFrom(context, sourceType))
        End Function

        Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As Globalization.CultureInfo, ByVal value As Object) As Object
            If TypeOf value Is String Then
                Return value.ToString()
            End If
            If (value Is Nothing) Then
                Return String.Empty
            End If
            Return MyBase.ConvertFrom(context, culture, value)
        End Function

        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
            If destinationType Is Nothing Then
                Throw New ArgumentNullException("destinationType")
            End If
            If TypeOf value Is String AndAlso value.ToString() = String.Empty Then
                Return VisualStudiosTabControlResources.NoneString
            End If
            If ((destinationType Is GetType(String)) AndAlso (value Is Nothing)) Then
                Return VisualStudiosTabControlResources.NoneString
            End If
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function

        Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return True
        End Function

        Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return True
        End Function

    End Class

    Private Class VisualStudiosTabPageImageKeyEditor
        Inherits UITypeEditor

        'Properties
        Private _ImageEditor As UITypeEditor = DirectCast(TypeDescriptor.GetEditor(GetType(Image), GetType(UITypeEditor)), UITypeEditor)
        Protected ReadOnly Property ImageEditor() As UITypeEditor
            Get
                Return Me._ImageEditor
            End Get
        End Property

        'Methods
        Public Overrides Function GetPaintValueSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return ((Not Me._ImageEditor Is Nothing) AndAlso Me._ImageEditor.GetPaintValueSupported(context))
        End Function

        Public Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)
            If (Not Me._ImageEditor Is Nothing) Then
                Dim image As Image = Nothing
                If TypeOf e.Value Is String Then
                    image = Me.GetImage(e.Context, e.Value.ToString())
                End If
                If (Not image Is Nothing) Then
                    Me._ImageEditor.PaintValue(New PaintValueEventArgs(e.Context, image, e.Graphics, e.Bounds))
                End If
            End If
        End Sub

        Protected Overridable Function GetImage(ByVal context As ITypeDescriptorContext, ByVal key As String) As Image
            Dim instance As Object = context.Instance
            Dim imageList As ImageList = Nothing
            If instance IsNot Nothing AndAlso TypeOf instance Is VisualStudiosTabPage Then
                instance = DirectCast(instance, VisualStudiosTabPage).Owner
                If instance IsNot Nothing Then
                    imageList = DirectCast(TypeDescriptor.GetProperties(instance)(VisualStudiosTabControlResources.ImageListPropertyName).GetValue(instance), System.Windows.Forms.ImageList)
                    If imageList IsNot Nothing Then
                        Return imageList.Images(key)
                    End If
                End If
            End If
            Return Nothing
        End Function

    End Class

    Private Class VisualStudiosTabPageCollectionEditor
        Inherits CollectionEditor

        'Properties
        Public Overrides ReadOnly Property IsDropDownResizable() As Boolean
            Get
                Return True
            End Get
        End Property

        'Contructor
        Public Sub New(ByVal type As System.Type)
            MyBase.New(type)
        End Sub

        'Methods
        Protected Overrides Function CreateCollectionItemType() As System.Type
            Return GetType(VisualStudiosTabPage)
        End Function

        Protected Overrides Function CreateInstance(ByVal itemType As System.Type) As Object
            If itemType Is GetType(VisualStudiosTabPage) Then
                Dim designerHost As IDesignerHost = TryCast(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
                If designerHost IsNot Nothing Then
                    Dim tab As VisualStudiosTabPage = DirectCast(designerHost.CreateComponent(GetType(VisualStudiosTabPage)), VisualStudiosTabPage)
                    Dim host As VisualStudiosTabControl = TryCast(Me.Context.Instance, VisualStudiosTabControl)
                    tab.Text = tab.Name.Replace(GetType(VisualStudiosTabPage).Name, "TabPage")
                    If host IsNot Nothing Then
                        tab.Size = host.DefaultChildSize
                    End If
                    Return tab
                End If
            End If
            Return MyBase.CreateInstance(itemType)
        End Function

    End Class

    <TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class VisualStudiosTabControlFontSettings

        'Properties
        Private _Font As New Font("Tahoma", 8.25F, FontStyle.Regular)
        Public Property Font() As Font
            Get
                Return Me._Font
            End Get
            Set(ByVal value As Font)
                Me._Font = value
            End Set
        End Property

        Private _FontColor As Color = SystemColors.ControlText
        Public Property FontColor() As Color
            Get
                Return Me._FontColor
            End Get
            Set(ByVal value As Color)
                Me._FontColor = value
            End Set
        End Property

        'Methods
        Public Overrides Function ToString() As String
            Return Me.GetType().Name
        End Function

    End Class

    Friend Class VisualStudiosTabControlResources

        'Constants
        Friend Const NoneString As String = "(none)"
        Friend Const ImageListPropertyName As String = "ImageList"
        Friend Const TabPagesDescription As String = "The VisualStudioTabPages in the VisualStudioTabControl."
        Friend Const SelectedTabPageDescription As String = "Gets or sets the selected VisualStudioTabPage."
        Friend Const TabCountDescription As String = "Gets the amount of VisualStudioTabPages."
        Friend Const ImageListDescription As String = "Indicates the ImageList object that this control's tabs will take its images from."
        Friend Const TabWidthInflationDescription As String = "Indicates the amount in pixels that the tab's width should increase."
        Friend Const SkinDescription As String = "Indicates the visual skin to be applied to the control."
        Friend Const InvalidControlAdded As String = "Only a VisualStudiosTabPage can be added to a VisualStudiosTabControl"
        Friend Const UnselectedString As String = "(Unselected)"
        Friend Const AddTabVerbText As String = "Add Tab"
        Friend Const RemoveTabVerbText As String = "Remove Tab"
        Friend Const TabPagesPropertyName As String = "TabPages"
        Friend Const SelectedTabChangedEventName As String = "SelectedTabChanged"
        Friend Const InvalidTabWidthInflation As String = "TabWidthInflation must be greater than or equal to 0 and less then or equal to 100."

        'Properties
        Friend Shared ReadOnly Property Icon() As Icon
            Get
                Dim image() As Byte = {0, 0, 1, 0, 1, 0, 16, 16, 0, 0, 1, 0, 32, 0, 104, 4, 0, 0, 22, 0, 0, 0, 40, 0, 0, 0, 16, _
                                       0, 0, 0, 32, 0, 0, 0, 1, 0, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, _
                                       0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 169, 113, 81, 169, 195, 142, 104, _
                                       255, 192, 139, 102, 255, 190, 136, 100, 255, 187, 133, 97, 255, 185, 131, 95, 255, 180, _
                                       126, 92, 255, 178, 124, 90, 255, 177, 123, 88, 255, 174, 121, 87, 255, 173, 118, 86, 255, _
                                       171, 117, 84, 255, 169, 115, 83, 255, 169, 113, 81, 255, 169, 113, 81, 169, 255, 255, 255, _
                                       0, 200, 146, 108, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 255, 255, 220, 167, 123, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 169, 114, 81, 255, 255, 255, 255, 0, 202, 148, 110, 255, 255, 255, 255, 255, _
                                       255, 142, 43, 255, 149, 149, 149, 255, 135, 135, 135, 255, 255, 255, 255, 255, 220, 167, _
                                       123, 255, 255, 255, 255, 255, 254, 254, 252, 255, 254, 254, 252, 255, 254, 254, 250, 255, _
                                       254, 254, 250, 255, 252, 252, 249, 255, 255, 255, 255, 255, 170, 115, 83, 255, 255, 255, _
                                       255, 0, 204, 151, 111, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 255, 255, 255, 255, 220, 167, 123, 255, 255, 255, 255, 255, 253, 253, _
                                       250, 255, 253, 253, 250, 255, 253, 253, 250, 255, 252, 252, 247, 255, 251, 251, 246, 255, _
                                       255, 255, 255, 255, 172, 117, 84, 255, 255, 255, 255, 0, 209, 156, 115, 255, 255, 255, 255, _
                                       255, 255, 158, 58, 255, 159, 159, 159, 255, 153, 153, 153, 255, 255, 255, 255, 255, 220, 167, _
                                       123, 255, 255, 255, 255, 255, 253, 253, 248, 255, 251, 251, 249, 255, 251, 250, 247, 255, 251, _
                                       250, 246, 255, 251, 248, 244, 255, 255, 255, 255, 255, 176, 122, 88, 255, 255, 255, 255, 0, 212, _
                                       158, 117, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 220, 167, 123, 255, 255, 255, 255, 255, 251, 249, 247, 255, 251, 249, 245, _
                                       255, 251, 248, 244, 255, 251, 247, 242, 255, 251, 245, 242, 255, 255, 255, 255, 255, 178, 124, _
                                       90, 255, 255, 255, 255, 0, 213, 160, 118, 255, 255, 255, 255, 255, 255, 191, 104, 255, 175, _
                                       175, 175, 255, 170, 170, 170, 255, 255, 255, 255, 255, 220, 167, 123, 255, 255, 255, 255, 255, _
                                       251, 248, 244, 255, 251, 247, 243, 255, 251, 245, 242, 255, 250, 243, 239, 255, 248, 242, 236, _
                                       255, 255, 255, 255, 255, 181, 126, 92, 255, 255, 255, 255, 0, 216, 162, 121, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 220, 167, _
                                       123, 255, 255, 255, 255, 255, 251, 246, 241, 255, 248, 244, 238, 255, 247, 242, 235, 255, 247, _
                                       240, 234, 255, 246, 236, 232, 255, 255, 255, 255, 255, 183, 129, 94, 255, 255, 255, 255, 0, 217, _
                                       163, 121, 255, 255, 255, 255, 255, 255, 191, 104, 255, 189, 189, 189, 255, 183, 183, 183, 255, 255, _
                                       255, 255, 255, 220, 167, 123, 255, 255, 255, 255, 255, 247, 243, 237, 255, 246, 239, 234, 255, 245, _
                                       235, 231, 255, 243, 234, 228, 255, 242, 231, 222, 255, 255, 255, 255, 255, 186, 133, 96, 255, 255, _
                                       255, 255, 0, 219, 164, 122, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 255, 255, 255, 220, 167, 123, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, _
                                       255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 189, _
                                       135, 99, 255, 255, 255, 255, 0, 220, 167, 123, 255, 220, 167, 123, 255, 220, 167, 123, 255, 220, 167, _
                                       123, 255, 220, 167, 123, 255, 220, 167, 123, 255, 220, 167, 123, 255, 220, 167, 123, 255, 220, _
                                       167, 123, 255, 220, 167, 123, 255, 220, 167, 123, 255, 220, 167, 123, 255, 220, 167, 123, 255, _
                                       220, 167, 123, 255, 192, 139, 102, 255, 255, 255, 255, 0, 221, 172, 133, 253, 232, 185, 146, 255, _
                                       232, 185, 146, 255, 232, 185, 146, 255, 232, 185, 146, 255, 232, 185, 146, 255, 232, 185, 146, 255, _
                                       232, 185, 146, 255, 232, 185, 146, 255, 232, 185, 146, 255, 232, 185, 146, 255, 232, 185, 146, 255, _
                                       232, 185, 146, 255, 232, 185, 146, 255, 193, 144, 111, 253, 255, 255, 255, 0, 169, 113, 81, 107, _
                                       221, 177, 141, 244, 220, 167, 123, 255, 220, 166, 122, 255, 218, 164, 122, 255, 216, 162, 121, _
                                       255, 213, 160, 118, 255, 212, 158, 117, 255, 210, 157, 115, 255, 207, 154, 114, 255, 206, 153, _
                                       112, 255, 203, 150, 111, 255, 201, 148, 108, 255, 196, 154, 122, 244, 169, 113, 81, 107, 255, 255, _
                                       255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, _
                                       255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, 255, 255, 255, 0, _
                                       255, 255, 0, 0, 255, 255, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, _
                                       0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 128, 3, 0, 0, 255, 255, 0, 0}
                Using stream As New IO.MemoryStream(image)
                    Return New Icon(stream)
                End Using
            End Get
        End Property

    End Class

    Private NotInheritable Class VisualStudiosTabControlSkinEditor
        Inherits UITypeEditor

        'Methods
        Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            If provider IsNot Nothing Then
                Dim control As VisualStudiosTabControl = TryCast(context.Instance, VisualStudiosTabControl)
                Dim editService As System.Windows.Forms.Design.IWindowsFormsEditorService = TryCast(provider.GetService(GetType(System.Windows.Forms.Design.IWindowsFormsEditorService)), System.Windows.Forms.Design.IWindowsFormsEditorService)
                If editService Is Nothing Then
                    Return value
                End If
                If control IsNot Nothing Then
                    Using contentUI As New ContentUI(control)
                        If editService.ShowDialog(contentUI) = DialogResult.OK Then
                            value = contentUI.SelectedSkin
                            context.OnComponentChanging()
                            control._Skin = contentUI.SelectedSkin
                            control.Invalidate()
                            context.OnComponentChanged()
                        Else
                            Return control.Skin
                        End If
                    End Using
                End If
            End If
            Return MyBase.EditValue(context, provider, value)
        End Function

        Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
            Return UITypeEditorEditStyle.Modal
        End Function

        'Nested types
        Private NotInheritable Class ContentUI
            Inherits System.Windows.Forms.Form

            'Fields
            Private components As System.ComponentModel.IContainer
            Friend WithEvents PropertyGridSkin As System.Windows.Forms.PropertyGrid
            Friend WithEvents PanelVisualStudiosTabControlHost As System.Windows.Forms.Panel
            Friend WithEvents ButtonCancel As System.Windows.Forms.Button
            Friend WithEvents ButtonOK As System.Windows.Forms.Button
            Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer

            'Properties
            Private _SelectedSkin As VisualStudiosTabControl.VisualStudiosTabControlSkin
            Public Property SelectedSkin() As VisualStudiosTabControl.VisualStudiosTabControlSkin
                Get
                    Return Me._SelectedSkin
                End Get
                Set(ByVal value As VisualStudiosTabControl.VisualStudiosTabControlSkin)
                    Me._SelectedSkin = value
                End Set
            End Property

            'Constructor
            Public Sub New(ByVal owner As VisualStudiosTabControl)
                Me._SelectedSkin = owner.Skin.Clone()
                Me.InitializeComponent()
                Me.PropertyGridSkin.SelectedObject = Me._SelectedSkin
                Me.PropertyGridSkin.Select()
                Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
                Me.SetStyle(ControlStyles.ResizeRedraw, True)
                Me.SetStyle(ControlStyles.UserPaint, True)
                Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            End Sub

            'Methods
            Private Sub OnPanelVisualStudiosTabControlHostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelVisualStudiosTabControlHost.Paint
                Me.OnDrawFillGradient(e)
                Me.OnDrawBorder(e)
                Me.OnDrawTabs(e)
                Me.OnDrawTabText(e)
                Me.OnDrawTabDropDown(e)
            End Sub

            Protected Sub OnDrawBorder(ByVal e As PaintEventArgs)
                With e.Graphics
                    .SmoothingMode = SmoothingMode.HighQuality
                    Dim rect As Rectangle = Me.PanelVisualStudiosTabControlHost.ClientRectangle
                    Using outerPen As New Pen(Me._SelectedSkin.TabControl.OuterBorderColor)
                        .DrawArc(outerPen, 1, 0, 10, 10, 180, 90)
                        .DrawLine(outerPen, 6, 0, rect.Width - 1, 0)
                        .DrawLine(outerPen, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1)
                        .DrawArc(outerPen, 1, 96, 9, 10, 90, 90)
                        .DrawArc(outerPen, 85, 128, 10, 10, -90, 90)
                        .DrawLine(outerPen, 95, rect.Height - 1, rect.Width - 1, rect.Height - 1)
                        .DrawLine(outerPen, 95, 128 + 6, 95, rect.Height - 1)
                        .DrawLine(outerPen, 1, 6, 1, 100)
                        .DrawLine(outerPen, 6, 107, 90, 128)
                    End Using
                    rect = New Rectangle(101, 6, rect.Width - 107, rect.Height - 12)
                    Using innerPen As New Pen(Me._SelectedSkin.TabControl.InnerBorderColor)
                        e.Graphics.DrawRectangle(innerPen, rect)
                    End Using
                End With
            End Sub

            Protected Sub OnDrawTabs(ByVal e As PaintEventArgs)
                e.Graphics.SmoothingMode = SmoothingMode.None

                Dim index As Integer = 0
                Dim y As Integer = 6
                Dim drawDividers As Boolean = True
                Dim mouseOver As Boolean = False
                Dim selected As Boolean = False

                Do Until index = 3
                    Select Case index
                        Case 0
                            selected = True
                        Case 1
                            mouseOver = True
                        Case 2
                            selected = False
                            mouseOver = False
                    End Select

                    If Me._SelectedSkin.TabControl.DividerSkin.DrawDividers Then
                        If index = 0 Then
                            Using bottomPen As New Pen(Me._SelectedSkin.TabControl.DividerSkin.BottomColor)
                                e.Graphics.DrawLine(bottomPen, 6, 5, 93, 5)
                            End Using
                        ElseIf index = 2 Then
                            Using topPen As New Pen(Me._SelectedSkin.TabControl.DividerSkin.TopColor)
                                e.Graphics.DrawLine(topPen, 6, y + 32, 93, y + 32)
                            End Using
                        End If

                        Using topPen As New Pen(Me._SelectedSkin.TabControl.DividerSkin.TopColor)
                            e.Graphics.DrawLine(topPen, 6, y, 93, y)
                        End Using
                        Using bottomPen As New Pen(Me._SelectedSkin.TabControl.DividerSkin.BottomColor)
                            e.Graphics.DrawLine(bottomPen, 6, y + 31, 93, y + 31)
                        End Using
                    End If

                    Select Case True
                        Case mouseOver
                            Using tabTip As New Pen(Me._SelectedSkin.TabPage.MouseHoverTabPage.TabTipColor)
                                e.Graphics.DrawLine(tabTip, 0, y + 2, 2, y)
                                e.Graphics.DrawLine(tabTip, 0, y + 2, 0, y + 29)
                                e.Graphics.DrawLine(tabTip, 0, y + 29, 2, y + 31)
                            End Using
                            Using tabBorder As New Pen(Me._SelectedSkin.TabPage.MouseHoverTabPage.TabBorderColor)
                                e.Graphics.DrawLine(tabBorder, 3, y, 100, y)
                                e.Graphics.DrawLine(tabBorder, 3, y + 31, 100, y + 31)
                            End Using
                            Using tabTipInner As New Pen(Me._SelectedSkin.TabPage.MouseHoverTabPage.TabTipInnerColor)
                                e.Graphics.DrawLine(tabTipInner, 1, y + 2, 1, y + 29)
                                e.Graphics.DrawLine(tabTipInner, 2, y + 1, 2, y + 30)
                            End Using
                            Using tabBorderRight As New Pen(Me._SelectedSkin.TabPage.MouseHoverTabPage.TabRightBorderColor)
                                e.Graphics.DrawLine(tabBorderRight, 101, y + 1, 101, y + 30)
                            End Using
                            Using fillBrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(3, y + 1, 98, 30), _
                                                                                             Me._SelectedSkin.TabPage.MouseHoverTabPage.GradientSettings.StartColor, _
                                                                                             Me._SelectedSkin.TabPage.MouseHoverTabPage.GradientSettings.EndColor, _
                                                                                             Me._SelectedSkin.TabPage.MouseHoverTabPage.GradientSettings.LinearGradientMode)
                                e.Graphics.FillRectangle(fillBrush, fillBrush.Rectangle)
                            End Using
                        Case selected
                            Using tabTip As New Pen(Me._SelectedSkin.TabPage.SelectedTabPage.TabTipColor)
                                e.Graphics.DrawLine(tabTip, 0, y + 2, 2, y)
                                e.Graphics.DrawLine(tabTip, 0, y + 2, 0, y + 29)
                                e.Graphics.DrawLine(tabTip, 0, y + 29, 2, y + 31)
                            End Using
                            Using tabBorder As New Pen(Me._SelectedSkin.TabPage.SelectedTabPage.TabBorderColor)
                                e.Graphics.DrawLine(tabBorder, 3, y, 100, y)
                                e.Graphics.DrawLine(tabBorder, 3, y + 31, 100, y + 31)
                            End Using
                            Using tabBorderRight As New Pen(Me._SelectedSkin.TabPage.SelectedTabPage.TabRightBorderColor)
                                e.Graphics.DrawLine(tabBorderRight, 101, y + 1, 101, y + 30)
                            End Using
                            Using tabTipInner As New Pen(Me._SelectedSkin.TabPage.SelectedTabPage.TabTipInnerColor)
                                e.Graphics.DrawLine(tabTipInner, 1, y + 2, 1, y + 29)
                                e.Graphics.DrawLine(tabTipInner, 2, y + 1, 2, y + 30)
                            End Using
                            Using fillBrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(3, y + 1, 98, 30), _
                                                                                            Me._SelectedSkin.TabPage.SelectedTabPage.GradientSettings.StartColor, _
                                                                                            Me._SelectedSkin.TabPage.SelectedTabPage.GradientSettings.EndColor, _
                                                                                            Me._SelectedSkin.TabPage.SelectedTabPage.GradientSettings.LinearGradientMode)
                                e.Graphics.FillRectangle(fillBrush, fillBrush.Rectangle)
                            End Using
                    End Select
                    y += 32
                    index += 1
                Loop

            End Sub

            Protected Sub OnDrawTabText(ByVal e As PaintEventArgs)
                Dim textSize As Size = Nothing
                Dim index As Integer = 0
                Dim text As String = Nothing
                Dim y As Integer = 6

                Do Until index = 3
                    Select Case True
                        Case index = 0
                            text = "Selected"
                            textSize = TextRenderer.MeasureText(text, Me._SelectedSkin.TabPage.SelectedTabPage.FontSettings.Font)
                            Using textBrush As New SolidBrush(Me._SelectedSkin.TabPage.SelectedTabPage.FontSettings.FontColor)
                                e.Graphics.DrawString(text, _
                                                      Me._SelectedSkin.TabPage.SelectedTabPage.FontSettings.Font, textBrush, 12.0!, _
                                                      CSng(y + (15 - (textSize.Height / 2))))
                            End Using
                        Case index = 1
                            text = "Mouse Hover"
                            textSize = TextRenderer.MeasureText(text, Me._SelectedSkin.TabPage.MouseHoverTabPage.FontSettings.Font)
                            Using textBrush As New SolidBrush(Me._SelectedSkin.TabPage.MouseHoverTabPage.FontSettings.FontColor)
                                e.Graphics.DrawString(text, _
                                                      Me._SelectedSkin.TabPage.MouseHoverTabPage.FontSettings.Font, textBrush, 12.0!, _
                                                      CSng(y + (15 - (textSize.Height / 2))))
                            End Using
                        Case Else
                            text = "Unselected"
                            textSize = TextRenderer.MeasureText(text, Me._SelectedSkin.TabPage.UnselectedTabPage.FontSettings.Font)
                            Using textBrush As New SolidBrush(Me._SelectedSkin.TabPage.UnselectedTabPage.FontSettings.FontColor)
                                e.Graphics.DrawString(text, _
                                                      Me._SelectedSkin.TabPage.UnselectedTabPage.FontSettings.Font, textBrush, 12.0!, _
                                                      CSng(y + (15 - (textSize.Height / 2))))
                            End Using
                    End Select
                    y += 32
                    index += 1
                Loop

            End Sub

            Protected Sub OnDrawTabDropDown(ByVal e As PaintEventArgs)
                e.Graphics.SmoothingMode = SmoothingMode.None

                Dim clientRect As Rectangle = New Rectangle(81, 108, 14, 14)
                Dim points() As Point = {New Point(85, 96 + 19), _
                                         New Point(88, 96 + 23), _
                                         New Point(92, 96 + 19)}
                Using selectionPen As New Pen(Me._SelectedSkin.TabControl.GlyphSkin.GlyphBorderColor)
                    e.Graphics.DrawRectangle(selectionPen, clientRect)
                End Using
                Using selectionBrush As New SolidBrush(Me._SelectedSkin.TabControl.GlyphSkin.GlyphHighlightColor)
                    e.Graphics.FillRectangle(selectionBrush, New Rectangle(clientRect.X + 1, clientRect.Y + 1, 13, 13))
                End Using
                Using glyphBrush As New SolidBrush(Me._SelectedSkin.TabControl.GlyphSkin.GlyphColor)
                    e.Graphics.SmoothingMode = SmoothingMode.None
                    e.Graphics.FillRectangle(glyphBrush, 85, (96) + 16, 7, 2)
                    e.Graphics.FillPolygon(glyphBrush, points)
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality
                End Using
            End Sub

            Protected Sub OnDrawFillGradient(ByVal e As PaintEventArgs)
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality

                Using path As New GraphicsPath()
                    path.AddLine(New PointF(4, 0), New PointF(Me.Width, 0))
                    path.AddLine(path.GetLastPoint(), New PointF(Me.Width, Me.Height))
                    path.AddLine(path.GetLastPoint(), New PointF(95, Me.Height))
                    path.AddLine(path.GetLastPoint(), New PointF(95, 129))
                    path.AddLine(path.GetLastPoint(), New PointF(93, 129))
                    path.AddLine(path.GetLastPoint(), New PointF(6, 107))
                    path.AddLine(path.GetLastPoint(), New PointF(4, 107))
                    path.AddLine(path.GetLastPoint(), New PointF(1, 103))
                    path.AddLine(path.GetLastPoint(), New PointF(0, 4))
                    path.CloseFigure()
                    e.Graphics.SetClip(path)
                End Using

                Using tabBrush As LinearGradientBrush = New Drawing2D.LinearGradientBrush(New Rectangle(1, 0, 95, Me.Height), _
                                                                                          Me._SelectedSkin.TabPage.UnselectedTabPage.GradientSettings.StartColor, _
                                                                                          Me._SelectedSkin.TabPage.UnselectedTabPage.GradientSettings.EndColor, _
                                                                                          Me._SelectedSkin.TabPage.UnselectedTabPage.GradientSettings.LinearGradientMode)
                    e.Graphics.FillRectangle(tabBrush, tabBrush.Rectangle)
                End Using

                Using outerbackBrush As New SolidBrush(Me._SelectedSkin.TabControl.OuterBackColor)
                    e.Graphics.FillRectangle(outerbackBrush, New Rectangle(95, 0, Me.Width - 96, Me.Height - 1))
                End Using

                Using innerbackBrush As New SolidBrush(Me._SelectedSkin.TabControl.InnerBackColor)
                    e.Graphics.FillRectangle(innerbackBrush, New Rectangle(101, 6, Me.PanelVisualStudiosTabControlHost.ClientRectangle.Width - 107, Me.PanelVisualStudiosTabControlHost.ClientRectangle.Height - 12))
                End Using



                e.Graphics.ResetClip()
            End Sub

            Private Sub OnPropertyGridSkinPropertyValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGridSkin.PropertyValueChanged
                Me.PanelVisualStudiosTabControlHost.Invalidate()
            End Sub

            Private Sub OnSplitContainerMainSplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainerMain.SplitterMoved
                Me.PanelVisualStudiosTabControlHost.Invalidate()
            End Sub

            Protected Overrides Sub Dispose(ByVal disposing As Boolean)
                Try
                    If disposing AndAlso components IsNot Nothing Then
                        components.Dispose()
                    End If
                Finally
                    MyBase.Dispose(disposing)
                End Try
            End Sub

            Private Sub InitializeComponent()
                Me.PropertyGridSkin = New System.Windows.Forms.PropertyGrid
                Me.PanelVisualStudiosTabControlHost = New System.Windows.Forms.Panel
                Me.ButtonCancel = New System.Windows.Forms.Button
                Me.ButtonOK = New System.Windows.Forms.Button
                Me.SplitContainerMain = New System.Windows.Forms.SplitContainer
                Me.SplitContainerMain.Panel1.SuspendLayout()
                Me.SplitContainerMain.Panel2.SuspendLayout()
                Me.SplitContainerMain.SuspendLayout()
                Me.SuspendLayout()
                '
                'PropertyGridSkin
                '
                Me.PropertyGridSkin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                            Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.PropertyGridSkin.HelpVisible = False
                Me.PropertyGridSkin.Location = New System.Drawing.Point(0, 0)
                Me.PropertyGridSkin.Name = "PropertyGridSkin"
                Me.PropertyGridSkin.Size = New System.Drawing.Size(264, 171)
                Me.PropertyGridSkin.TabIndex = 0
                Me.PropertyGridSkin.ToolbarVisible = False
                '
                'PanelVisualStudiosTabControlHost
                '
                Me.PanelVisualStudiosTabControlHost.Dock = System.Windows.Forms.DockStyle.Fill
                Me.PanelVisualStudiosTabControlHost.Location = New System.Drawing.Point(0, 0)
                Me.PanelVisualStudiosTabControlHost.Name = "PanelVisualStudiosTabControlHost"
                Me.PanelVisualStudiosTabControlHost.Size = New System.Drawing.Size(200, 200)
                Me.PanelVisualStudiosTabControlHost.TabIndex = 1
                '
                'ButtonCancel
                '
                Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.ButtonCancel.Location = New System.Drawing.Point(190, 177)
                Me.ButtonCancel.Name = "ButtonCancel"
                Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
                Me.ButtonCancel.TabIndex = 2
                Me.ButtonCancel.Text = "&Cancel"
                Me.ButtonCancel.UseVisualStyleBackColor = True
                '
                'ButtonOK
                '
                Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.ButtonOK.Location = New System.Drawing.Point(109, 177)
                Me.ButtonOK.Name = "ButtonOK"
                Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
                Me.ButtonOK.TabIndex = 3
                Me.ButtonOK.Text = "&OK"
                Me.ButtonOK.UseVisualStyleBackColor = True
                '
                'SplitContainerMain
                '
                Me.SplitContainerMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                            Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.SplitContainerMain.Location = New System.Drawing.Point(12, 12)
                Me.SplitContainerMain.Name = "SplitContainerMain"
                '
                'SplitContainerMain.Panel1
                '
                Me.SplitContainerMain.Panel1.Controls.Add(Me.PanelVisualStudiosTabControlHost)
                Me.SplitContainerMain.Panel1MinSize = 200
                '
                'SplitContainerMain.Panel2
                '
                Me.SplitContainerMain.Panel2.Controls.Add(Me.PropertyGridSkin)
                Me.SplitContainerMain.Panel2.Controls.Add(Me.ButtonOK)
                Me.SplitContainerMain.Panel2.Controls.Add(Me.ButtonCancel)
                Me.SplitContainerMain.Size = New System.Drawing.Size(468, 200)
                Me.SplitContainerMain.Panel2MinSize = 200
                Me.SplitContainerMain.SplitterDistance = 200
                Me.SplitContainerMain.TabIndex = 4
                '
                'VisualStudiosTabControlSkinDesigner
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.SystemColors.Window
                Me.ClientSize = New System.Drawing.Size(492, 224)
                Me.Controls.Add(Me.SplitContainerMain)
                Me.DoubleBuffered = True
                Me.Icon = VisualStudiosTabControlResources.Icon
                Me.MinimizeBox = False
                Me.MaximizeBox = False
                Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                Me.MinimumSize = New System.Drawing.Size(500, 250)
                Me.Name = "VisualStudiosTabControlSkinDesigner"
                Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
                Me.StartPosition = FormStartPosition.CenterScreen
                Me.Text = "VisualStudiosTabControlSkinDesigner"
                Me.SplitContainerMain.Panel1.ResumeLayout(False)
                Me.SplitContainerMain.Panel2.ResumeLayout(False)
                Me.SplitContainerMain.ResumeLayout(False)
                Me.ResumeLayout(False)
            End Sub

        End Class

    End Class

    Protected Friend NotInheritable Class VisualStudiosTabControlDesigner
        Inherits System.Windows.Forms.Design.ParentControlDesigner

        'Properties
        Public ReadOnly Property HostControl() As VisualStudiosTabControl
            Get
                Return DirectCast(Me.Control, VisualStudiosTabControl)
            End Get
        End Property

        Private _DesignerHost As IDesignerHost = Nothing
        Public ReadOnly Property DesignerHost() As IDesignerHost
            Get
                If Me._DesignerHost Is Nothing Then
                    Me._DesignerHost = DirectCast(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
                End If
                Return Me._DesignerHost
            End Get
        End Property

        Private _SelectionService As ISelectionService = Nothing
        Public ReadOnly Property SelectionService() As ISelectionService
            Get
                If Me._SelectionService Is Nothing Then
                    Me._SelectionService = DirectCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
                End If
                Return Me._SelectionService
            End Get
        End Property

        Private _DesignerActionUIService As DesignerActionUIService
        Public ReadOnly Property DesignerActionUIService() As DesignerActionUIService
            Get
                If Me._DesignerActionUIService Is Nothing Then
                    Me._DesignerActionUIService = DirectCast(Me.GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
                End If
                Return Me._DesignerActionUIService
            End Get
        End Property

        Private _Verbs As New DesignerVerbCollection()
        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            Get
                If Me._Verbs.Count = 3 Then
                    If Me.HostControl.TabPages.Count > 0 Then
                        For Each verb As DesignerVerb In Me._Verbs
                            If verb.Text = VisualStudiosTabControlResources.RemoveTabVerbText Then
                                verb.Enabled = True
                                Return Me._Verbs
                            End If
                        Next
                    Else
                        For Each verb As DesignerVerb In Me._Verbs
                            If verb.Text = VisualStudiosTabControlResources.RemoveTabVerbText Then
                                verb.Enabled = False
                                Return Me._Verbs
                            End If
                        Next
                    End If
                End If
                Return Me._Verbs
            End Get
        End Property

        'Contructor
        Public Sub New()
            MyBase.New()
            Me._Verbs.AddRange(New DesignerVerb() {New DesignerVerb(VisualStudiosTabControlResources.AddTabVerbText, AddressOf Me.OnAddTab), _
                                                   New DesignerVerb(VisualStudiosTabControlResources.RemoveTabVerbText, AddressOf Me.OnRemoveTab)})
        End Sub

        'Methods
        Private Sub AddTab()
            Dim oldTabs As Control.ControlCollection = Me.HostControl.Controls
            Me.RaiseComponentChanging(TypeDescriptor.GetProperties(Me.HostControl)(VisualStudiosTabControlResources.TabPagesPropertyName))
            Dim tab As VisualStudiosTabPage = DirectCast(Me.DesignerHost.CreateComponent(GetType(VisualStudiosTabPage)), VisualStudiosTabPage)
            tab.Text = tab.Name.Replace(GetType(VisualStudiosTabPage).Name, "TabPage")
            tab.Size = Me.HostControl.DefaultChildSize
            Me.HostControl.TabPages.Add(tab)
            Me.RaiseComponentChanged(TypeDescriptor.GetProperties(Me.HostControl)(VisualStudiosTabControlResources.TabPagesPropertyName), oldTabs, Me.HostControl.TabPages)
            Me.HostControl.SelectedTabPage = tab
            Me.SetVerbs()
            Me.SelectionService.SetSelectedComponents(New IComponent() {Me.Component})
        End Sub

        Private Sub OnAddTab(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.AddTab()
        End Sub

        Private Sub OnRemoveTab(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.HostControl.SelectedTabPage Is Nothing Then
                Return
            End If
            Dim oldTabs As Control.ControlCollection = Me.HostControl.Controls
            Me.RaiseComponentChanging(TypeDescriptor.GetProperties(Me.HostControl)(VisualStudiosTabControlResources.TabPagesPropertyName))
            Me.DesignerHost.DestroyComponent(Me.HostControl.SelectedTabPage)
            Me.SelectionService.SetSelectedComponents(New IComponent() {Me.HostControl}, SelectionTypes.Auto)
            Me.RaiseComponentChanged(TypeDescriptor.GetProperties(Me.HostControl)(VisualStudiosTabControlResources.TabPagesPropertyName), oldTabs, Me.HostControl.TabPages)
            Me.SetVerbs()
        End Sub

        Private Sub SetVerbs()
            Select Case Me.HostControl.TabPages.Count
                Case 0
                    For Each verb As DesignerVerb In Me._Verbs
                        If verb.Text = VisualStudiosTabControlResources.RemoveTabVerbText Then
                            verb.Enabled = False
                            Return
                        End If
                    Next
                Case 1
                    For Each verb As DesignerVerb In Me._Verbs
                        If verb.Text = VisualStudiosTabControlResources.RemoveTabVerbText Then
                            verb.Enabled = True
                            Return
                        End If
                    Next
            End Select
        End Sub

        Protected Overrides Function GetHitTest(ByVal point As System.Drawing.Point) As Boolean
            Dim cursor As Point = Me.HostControl.ClientCursorPosition
            For Each t As VisualStudiosTabPage In Me.HostControl.TabPages
                If Not t.Selected AndAlso t.SideTabVisible AndAlso t.SideTabClientRectangle.Contains(cursor) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Protected Overrides Sub PostFilterProperties(ByVal properties As System.Collections.IDictionary)
            properties.Remove("AutoScroll")
            properties.Remove("AutoScrollMargin")
            properties.Remove("AutoScrollMinSize")
            properties.Remove("Text")
            properties.Remove("BackColor")
            properties.Remove("BorderStyle")
            properties.Remove("RightToLeft")
            MyBase.PostFilterProperties(properties)
        End Sub

        Public Overrides Sub OnSetComponentDefaults()
            For defaultCount As Integer = 0 To 1
                Me.AddTab()
            Next
            Me.HostControl.SelectedTabPage = DirectCast(Me.HostControl.TabPages(0), VisualStudiosTabPage)
        End Sub

    End Class

End Class
