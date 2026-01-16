Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports JsToolBox.Base.Controls

Namespace Controls

    <DefaultEvent("TextChanged")>
    Public Class SmartTextBox
        Inherits ControlBase

        '------------------------------------------------------------
        ' ENUMS AND FIELDS
        '------------------------------------------------------------
        Public Enum SmartInputType
            Text
            Email
            Phone
            Password
            Number
            DecimalNumber
            Currency
            Username
            Search
            Multiline
            Url
            IdNumber
            CustomRegex
        End Enum

        Private _labelText As String = "Label"
        Private _smartType As SmartInputType = SmartInputType.Text
        Private _isFocused As Boolean = False
        Private _floatProgress As Single = 0 '0 = down, 1 = up
        Private ReadOnly _floatTimer As Timer
        Private _eyeVisible As Boolean = False
        Private _passwordHidden As Boolean = True
        Private ReadOnly _errorLabel As Label
        Private _errorMessage As String = ""
        Private _isValid As Boolean = True

        ' Left icon
        Private _leftIcon As Image

        ' Internal TextBox
        Private WithEvents _innerTextBox As New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Location = New Point(4, 24),
            .Font = New Font("Segoe UI", 10)
        }

        '------------------------------------------------------------
        ' PUBLIC CUSTOMIZABLE PROPERTIES (Old API compatibility)
        '------------------------------------------------------------
        <Browsable(True)>
        Public Shadows Property BorderColor As Color
            Get
                Return MyBase.BorderColor
            End Get
            Set(value As Color)
                MyBase.BorderColor = value
                Invalidate()
            End Set
        End Property

        <Browsable(True)>
        Public Shadows Property BorderColorError As Color
            Get
                Return MyBase.BorderErrorColor
            End Get
            Set(value As Color)
                MyBase.BorderErrorColor = value
                Invalidate()
            End Set
        End Property

        <Browsable(True)>
        Public Property FloatingSpeed As Integer = 10

        <Browsable(True)>
        Public Property FloatingLabelColor As Color = Color.Gray
        <Browsable(True)>
        Public Property FloatingLabelActiveColor As Color = Color.DodgerBlue
        <Browsable(True)>
        Public Property ErrorColor As Color = Color.Red
        <Browsable(True)>
        Public Property TextColor As Color = Color.Black

        <Browsable(True)>
        Public Property LeftIcon As Image
            Get
                Return _leftIcon
            End Get
            Set(value As Image)
                _leftIcon = value
                Invalidate()
            End Set
        End Property

        <Browsable(True)>
        Public Property SmartType As SmartInputType
            Get
                Return _smartType
            End Get
            Set(value As SmartInputType)
                _smartType = value
                _eyeVisible = (value = SmartInputType.Password)
                Invalidate()
            End Set
        End Property

        <Browsable(True)>
        Public Property LabelText As String
            Get
                Return _labelText
            End Get
            Set(value As String)
                _labelText = value
                Invalidate()
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                Return _innerTextBox.Text
            End Get
            Set(value As String)
                _innerTextBox.Text = value
                ValidateInput()
                Invalidate()
            End Set
        End Property

        <Browsable(False)>
        Public ReadOnly Property IsValid As Boolean
            Get
                Return _isValid
            End Get
        End Property

        <Browsable(True)>
        Public Property ErrorMessage As String
            Get
                Return _errorMessage
            End Get
            Set(value As String)
                _errorMessage = value
                ShowError(Not String.IsNullOrEmpty(value))
            End Set
        End Property

        '------------------------------------------------------------
        ' CONSTRUCTOR
        '------------------------------------------------------------
        Public Sub New()
            Me.DoubleBuffered = True
            Me.Height = 52

            ' Add inner TextBox
            Me.Controls.Add(_innerTextBox)

            ' Timer for floating label animation
            _floatTimer = New Timer() With {.Interval = 15}
            AddHandler _floatTimer.Tick, AddressOf AnimateFloating

            ' Error label
            _errorLabel = New Label() With {
                .AutoSize = False,
                .ForeColor = ErrorColor,
                .Height = 15,
                .Top = Me.Height - 15,
                .Left = 0,
                .Text = "",
                .Visible = False
            }
            Me.Controls.Add(_errorLabel)
        End Sub

        '------------------------------------------------------------
        ' EVENT HANDLERS
        '------------------------------------------------------------
        Private Sub _innerTextBox_Enter(sender As Object, e As EventArgs) Handles _innerTextBox.Enter
            _isFocused = True
            _floatTimer.Start()
            _hasFocus = True
            UpdateBorderColor()
        End Sub

        Private Sub _innerTextBox_Leave(sender As Object, e As EventArgs) Handles _innerTextBox.Leave
            _isFocused = False
            _floatTimer.Start()
            ValidateInput()
            _hasFocus = False
            UpdateBorderColor()
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            If Me.Width <= 0 OrElse Me.Height <= 0 Then Return

            If _innerTextBox IsNot Nothing Then
                _innerTextBox.Width = If(_leftIcon IsNot Nothing, Me.Width - 28, Me.Width - 8)
            End If
        End Sub

        Protected Overrides Sub OnEnter(e As EventArgs)
            MyBase.OnEnter(e)
            _isFocused = True
            _floatTimer.Start()
            _hasFocus = True
            UpdateBorderColor()
            If _smartType = SmartInputType.Currency Then RemoveCurrencyFormatting()
            Invalidate()
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)
            _isFocused = False
            _floatTimer.Start()
            _hasFocus = False
            UpdateBorderColor()
            If _smartType = SmartInputType.Currency Then ApplyCurrencyFormatting()
            ValidateInput()
            Invalidate()
        End Sub

        Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
            MyBase.OnKeyPress(e)
            If _smartType = SmartInputType.Number OrElse _smartType = SmartInputType.Phone Then
                If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If _eyeVisible Then
                Dim eyeRect = GetEyeRect()
                If eyeRect.Contains(e.Location) Then
                    _passwordHidden = Not _passwordHidden
                    Invalidate()
                End If
            End If
        End Sub

        '------------------------------------------------------------
        ' PAINT
        '------------------------------------------------------------
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            DrawFloatingLabel(g)
            DrawInputLine(g)
            DrawText(g)

            If _eyeVisible Then DrawEyeIcon(g)
            If Not _isValid Then DrawErrorLine(g)

            ' Left icon
            If _leftIcon IsNot Nothing Then
                g.DrawImage(_leftIcon, 2, 24, 20, 20)
                _innerTextBox.Location = New Point(24, 24)
                _innerTextBox.Width = Me.Width - 28
            Else
                _innerTextBox.Location = New Point(4, 24)
            End If
        End Sub

        '------------------------------------------------------------
        ' DRAWING METHODS
        '------------------------------------------------------------
        Private Sub DrawFloatingLabel(g As Graphics)
            Dim startY As Single = 22
            Dim endY As Single = 6
            Dim y As Single = startY + (_floatProgress * (endY - startY))
            Dim startSize As Single = 10
            Dim endSize As Single = 8
            Dim size As Single = startSize + (_floatProgress * (endSize - startSize))
            Dim c As Color = If(_isFocused, FloatingLabelActiveColor, FloatingLabelColor)
            Using f As New Font("Segoe UI", size), b As New SolidBrush(c)
                g.DrawString(_labelText, f, b, If(_leftIcon IsNot Nothing, 24, 2), y)
            End Using
        End Sub

        Private Sub DrawInputLine(g As Graphics)
            Dim lineY As Integer = Me.Height - 18
            Using p As New Pen(If(_isValid, BorderColor, BorderColorError), If(_isFocused, 2, 1))
                g.DrawLine(p, 0, lineY, Me.Width, lineY)
            End Using
        End Sub

        Private Sub DrawErrorLine(g As Graphics)
            Using p As New Pen(BorderColorError, 2)
                g.DrawLine(p, 0, Me.Height - 18, Me.Width, Me.Height - 18)
            End Using
        End Sub

        Private Sub DrawText(g As Graphics)
            Dim drawText As String = _innerTextBox.Text
            If _smartType = SmartInputType.Password AndAlso _passwordHidden Then
                drawText = New String("*"c, drawText.Length)
            End If
            Using f As New Font("Segoe UI", 10), b As New SolidBrush(TextColor)
                g.DrawString(drawText, f, b, If(_leftIcon IsNot Nothing, 24, 2), 24)
            End Using
        End Sub

        Private Function GetEyeRect() As Rectangle
            Return New Rectangle(Me.Width - 26, 20, 22, 22)
        End Function

        Private Sub DrawEyeIcon(g As Graphics)
            Dim r = GetEyeRect()
            Using p As New Pen(Color.Gray, 2)
                g.DrawEllipse(p, r.Left + 4, r.Top + 6, 14, 10)
                g.FillEllipse(Brushes.Gray, r.Left + 10, r.Top + 10, 4, 4)
            End Using
        End Sub

        '------------------------------------------------------------
        ' FLOATING ANIMATION
        '------------------------------------------------------------
        Private Sub AnimateFloating(sender As Object, e As EventArgs)
            Dim target As Single = If(_isFocused OrElse _innerTextBox.Text.Length > 0, 1, 0)
            If target = 1 AndAlso _floatProgress < 1 Then
                _floatProgress += 0.08
            ElseIf target = 0 AndAlso _floatProgress > 0 Then
                _floatProgress -= 0.08
            Else
                _floatTimer.Stop()
            End If
            Invalidate()
        End Sub

        '------------------------------------------------------------
        ' VALIDATION
        '------------------------------------------------------------
        Private Sub ValidateInput()
            _isValid = True
            _errorLabel.Visible = False
            Select Case _smartType
                Case SmartInputType.Email
                    If _innerTextBox.Text.Length > 0 AndAlso Not Regex.IsMatch(_innerTextBox.Text, "^[^\s@]+@[^\s@]+\.[^\s@]+$") Then
                        ShowError(True, "Invalid email address")
                    End If
                Case SmartInputType.Phone
                    If _innerTextBox.Text.Length > 0 AndAlso Not Regex.IsMatch(_innerTextBox.Text, "^\d{7,15}$") Then
                        ShowError(True, "Invalid phone number")
                    End If
                Case SmartInputType.Number
                    If _innerTextBox.Text.Length > 0 AndAlso Not Double.TryParse(_innerTextBox.Text, Nothing) Then
                        ShowError(True, "Numbers only")
                    End If
            End Select
        End Sub

        Private Sub ShowError(state As Boolean, Optional msg As String = "")
            _isValid = Not state
            _errorLabel.Text = If(state, msg, "")
            _errorLabel.Visible = state
            _hasError = state
            UpdateBorderColor()
            Invalidate()
        End Sub

        '------------------------------------------------------------
        ' CURRENCY FORMAT
        '------------------------------------------------------------
        Private Sub ApplyCurrencyFormatting()
            If _smartType = SmartInputType.Currency AndAlso IsNumeric(_innerTextBox.Text) Then
                _innerTextBox.Text = FormatNumber(CDbl(_innerTextBox.Text), 2)
            End If
        End Sub

        Private Sub RemoveCurrencyFormatting()
            If _smartType = SmartInputType.Currency Then
                _innerTextBox.Text = _innerTextBox.Text.Replace(",", "")
            End If
        End Sub

    End Class

End Namespace
