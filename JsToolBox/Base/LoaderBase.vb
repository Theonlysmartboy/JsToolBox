Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Base
    Public MustInherit Class LoaderBase
        Inherits Control

        ' Timer
        Private _timer As Timer

        ' Backing fields
        Private _loaderColor As Color = Color.DodgerBlue
        Private _speed As Integer = 100

        Public Sub New()
            Me.DoubleBuffered = True

            _timer = New Timer()
            _timer.Interval = _speed

            AddHandler _timer.Tick, AddressOf OnTick
        End Sub

        ' Loader Color
        <Browsable(True), Category("Appearance")>
        Public Property LoaderColor As Color
            Get
                Return _loaderColor
            End Get
            Set(value As Color)
                _loaderColor = value
                Me.Invalidate()
            End Set
        End Property

        ' Speed (fixed – now working)
        <Browsable(True), Category("Behavior")>
        Public Property Speed As Integer
            Get
                Return _speed
            End Get
            Set(value As Integer)
                If value < 1 Then value = 1
                _speed = value
                _timer.Interval = value
            End Set
        End Property

        ' Ensure repaint when text/font/forecolor change
        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e)
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnFontChanged(e As EventArgs)
            MyBase.OnFontChanged(e)
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnForeColorChanged(e As EventArgs)
            MyBase.OnForeColorChanged(e)
            Me.Invalidate()
        End Sub

        ' Start animation
        Public Sub Start()
            _timer.Start()
        End Sub

        ' Stop animation
        Public Sub [Stop]()
            _timer.Stop()
            Me.Invalidate()
        End Sub

        ' Required animation handler
        Protected MustOverride Sub OnTick(sender As Object, e As EventArgs)

    End Class
End Namespace
