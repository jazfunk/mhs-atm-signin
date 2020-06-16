Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Wunnell.Windows.Forms
    <ToolboxBitmap(GetType(ToolStripStatusLabel))> _
    Public Class ToolStripDateTimeStatusLabel
        Inherits ToolStripStatusLabel
#Region "Constants"

        ''' <summary>
        ''' The default value for the CustomFormat property.
        ''' </summary>
        Private Const DEFAULT_CUSTOM_FORMAT As String = CStr(Nothing)
        ''' <summary>
        ''' The default value for the Format property.
        ''' </summary>
        Private Const DEFAULT_FORMAT As DateTimePickerFormat = DateTimePickerFormat.Time

#End Region ' Constants

#Region "Variables"

        ''' <summary>
        ''' The custom format string used to format the date and/or time in the control.
        ''' </summary>
        Private _customFormat As String
        ''' <summary>
        ''' Determines whether dates and times are displayed using standard or custom formatting.
        ''' </summary>
        Private _format As DateTimePickerFormat

#End Region ' Variables

#Region "Properties"

        ''' <summary>
        ''' Gets or sets the custom date/time format string.
        ''' </summary>
        ''' <value>
        ''' A string that represents the custom date/time format. The default is a null reference (<b>Nothing</b> in Visual Basic).
        ''' </value>
        <Category("Behavior"), DefaultValue(DEFAULT_CUSTOM_FORMAT), Description("The custom format string used to format the date and/or time in the control.")> _
        Public Property CustomFormat() As String
            Get
                Return Me._customFormat
            End Get
            Set(ByVal value As String)
                If Value <> Me._customFormat Then
                    Me._customFormat = Value
                    Me.UpdateText()

                    If Me._format = DateTimePickerFormat.Custom Then
                        Me.OnFormatChanged(EventArgs.Empty)
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the format of the date and time displayed in the control.
        ''' </summary>
        ''' <value>
        ''' One of the <see cref="DateTimePickerFormat"/> values. The default is <see cref="DateTimePickerFormat">Time</see>.
        ''' </value>
        <Category("Appearance"), DefaultValue(DEFAULT_FORMAT), Description("Determines whether dates and times are displayed using standard or custom formatting.")> _
        Public Property Format() As DateTimePickerFormat
            Get
                Return Me._format
            End Get
            Set(ByVal value As DateTimePickerFormat)
                If Value <> Me._format Then
                    Me._format = Value
                    Me.UpdateText()
                    Me.OnFormatChanged(EventArgs.Empty)
                End If
            End Set
        End Property


#Region "Hidden Base Properties"

        ''' <summary>
        ''' Gets the color used to display an active link.
        ''' </summary>
        ''' <value></value>


        <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property ActiveLinkColor() As Color
            Get
                Return Color.Empty
            End Get
            'Set(ByVal value)

            'End Set
        End Property

        ''' <summary>
        ''' Gets a value indicating whether the ToolStripLabel is a hyperlink.
        ''' </summary>
        ''' <value>
        ''' Always returns <b>false</b>.
        ''' </value>
        <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property IsLink() As Boolean
            Get
                Return False
            End Get
        End Property

        ''' <summary>
        ''' Gets a value that represents the behavior of a link
        ''' </summary>
        ''' <value>
        ''' Always returns <see cref="LinkBehavior.SystemDefault"/>.
        ''' </value>
        <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property LinkBehavior() As LinkBehavior
            Get
                Return LinkBehavior.SystemDefault
            End Get
        End Property

        ''' <summary>
        ''' Gets the color used to display an active link.
        ''' </summary>
        ''' <value>
        ''' Always returns <see cref="Color.Empty"/>.
        ''' </value>
        <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property LinkColor() As Color
            Get
                Return Color.Empty
            End Get
        End Property

        ''' <summary>
        ''' Overridden.  Gets the text that is to be displayed on the item.
        ''' </summary>
        <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property Text() As String
            Get
                Return MyBase.Text
            End Get
        End Property

        ''' <summary>
        ''' Gets the color used when displaying a link that that has been previously visited.
        ''' </summary>
        ''' <value>
        ''' Always returns <see cref="Color.Empty"/>.
        ''' </value>
        <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property VisitedLinkColor() As Color
            Get
                Return Color.Empty
            End Get
        End Property

#End Region ' Hidden Base Properties.

#End Region ' Properties

#Region "Constructors"

        ''' <summary>
        ''' Initializes a new instance of the <b>ToolStripDateTimeStatusLabel</b> class.
        ''' </summary>
        ''' <remarks>
        ''' This constructor sets the initial <see cref="Format"/> property value to <see cref="DateTimePickerFormat">Time</see>.
        ''' </remarks>
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()

            ' Set the default property values.
            Me._format = DEFAULT_FORMAT
            Me._customFormat = DEFAULT_CUSTOM_FORMAT

            ' Display the initial formatted date and time.
            Me.UpdateText()
        End Sub

#End Region ' Constructors

#Region "Events"

        ''' <summary>
        ''' Occurs when the <see cref="Format"/> property value has changed or else the <b>Format</b> property value is
        ''' <see cref="DateTimePickerFormat">Custom</see> and the <see cref="CustomFormat"/> property value has changed.
        ''' </summary>
        <Description("Occurs when the format used to display date and/or time values in the control has changed.")> _
        Public Event FormatChanged As EventHandler

#End Region ' Events

#Region "Event Handlers"

        Private Sub clock_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles clock.Tick
            Me.UpdateText()
        End Sub

#End Region ' Event Handlers

#Region "Methods"

        ''' <summary>
        ''' Gets a string representing the current date and/or time formatted in
        ''' accordance with the current Format and CustomFormat property values.
        ''' </summary>
        ''' <returns>
        ''' A formatted string representing the current date and/or time.
        ''' </returns>
        Private Function GetFormattedDateAndTime() As String
            Dim formattedString As String

            Select Case Me._format
                Case DateTimePickerFormat.Long
                    formattedString = DateTime.Now.ToLongDateString()
                Case DateTimePickerFormat.Short
                    formattedString = DateTime.Now.ToShortDateString()
                Case DateTimePickerFormat.Time
                    formattedString = DateTime.Now.ToLongTimeString()
                Case Else
                    formattedString = DateTime.Now.ToString(Me._customFormat)
            End Select

            Return formattedString
        End Function

        ''' <summary>
        ''' Raises the <see cref="FormatChanged"/> event.
        ''' </summary>
        ''' <param name="e">
        ''' An <seealso cref="EventArgs"/> that contains the event data.
        ''' </param>
        Protected Overridable Sub OnFormatChanged(ByVal e As EventArgs)
            If Not Me.FormatChangedEvent Is Nothing Then
                RaiseEvent FormatChanged(Me, e)
            End If
        End Sub

        '''' <summary>
        '''' Raises the <see cref="ParentChanged"/> event.
        '''' </summary>
        ''' <param name="oldParent">
        ''' The original parent of the item.
        ''' </param>
        ''' <param name="newParent">
        ''' The new parent of the item.
        ''' </param>
        Protected Overrides Sub OnParentChanged(ByVal oldParent As ToolStrip, ByVal newParent As ToolStrip)
            ' Enable the timer if an only if the button is displayed in a run time form.
            Me.clock.Enabled = ((Not Me.DesignMode) AndAlso Not newParent Is Nothing)

            If Me.clock.Enabled Then
                Me.UpdateText()
            End If

            MyBase.OnParentChanged(oldParent, newParent)
        End Sub

        ''' <summary>
        ''' Displays a formatted string representing the current date and/or time.
        ''' </summary>
        Private Sub UpdateText()
            MyBase.Text = Me.GetFormattedDateAndTime()
        End Sub

#End Region ' Methods

#Region "Auto-generated Code"

        Private WithEvents clock As Timer
        Private components As IContainer

        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.clock = New System.Windows.Forms.Timer(Me.components)
            ' 
            ' clock
            ' 
            Me.clock.Interval = 1000
            '			Me.clock.Tick += New System.EventHandler(Me.clock_Tick);

        End Sub

#End Region ' Auto-generated Code
    End Class
End Namespace
