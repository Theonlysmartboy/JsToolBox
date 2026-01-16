Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Base.Controls
    Public MustInherit Class ControlBase
        Inherits UserControl

        Protected _borderColor As Color = Color.FromArgb(180, 180, 180)
        Protected _borderFocusColor As Color = Color.FromArgb(56, 128, 255)
        Protected _backColorDisabled As Color = Color.FromArgb(240, 240, 240)
        Protected _borderErrorColor As Color = Color.FromArgb(220, 50, 50)
        Protected _currentBorderColor As Color = _borderColor

        Protected _hasFocus As Boolean = False
        Protected _hasError As Boolean = False
        Protected _cornerRadius As Integer = 8

        Public Sub New()
            DoubleBuffered = True
            Size = New Size(200, 34)
        End Sub

        <Browsable(True), Category("Appearance")>
        Public Property CornerRadius As Integer
            Get
                Return _cornerRadius
            End Get
            Set(value As Integer)
                _cornerRadius = value
                Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(value As Color)
                _borderColor = value
                If Not _hasFocus AndAlso Not _hasError Then
                    _currentBorderColor = value
                End If
                Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property BorderFocusColor As Color
            Get
                Return _borderFocusColor
            End Get
            Set(value As Color)
                _borderFocusColor = value
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property BorderErrorColor As Color
            Get
                Return _borderErrorColor
            End Get
            Set(value As Color)
                _borderErrorColor = value
            End Set
        End Property

        <Browsable(False)>
        Public Property HasError As Boolean
            Get
                Return _hasError
            End Get
            Set(value As Boolean)
                _hasError = value
                UpdateBorderColor()
            End Set
        End Property

        Protected Sub UpdateBorderColor()
            If _hasError Then
                _currentBorderColor = _borderErrorColor
            ElseIf _hasFocus Then
                _currentBorderColor = _borderFocusColor
            Else
                _currentBorderColor = _borderColor
            End If

            Invalidate()
        End Sub

        Protected Overrides Sub OnEnter(e As EventArgs)
            MyBase.OnEnter(e)
            _hasFocus = True
            UpdateBorderColor()
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)
            _hasFocus = False
            UpdateBorderColor()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim rect = New Rectangle(0, 0, Width - 1, Height - 1)

            Using path = GetRoundPath(rect, _cornerRadius)
                Using pen As New Pen(_currentBorderColor, 1.6F)
                    g.DrawPath(pen, path)
                End Using
            End Using
        End Sub

        Private Function GetRoundPath(r As Rectangle, radius As Integer) As GraphicsPath
            Dim path As New GraphicsPath()

            Dim d = radius * 2
            path.AddArc(r.X, r.Y, d, d, 180, 90)
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
            path.CloseFigure()

            Return path
        End Function
    End Class
End Namespace
