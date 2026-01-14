Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Base
    Public MustInherit Class LoaderBase
        Inherits Control

        ' Timer for animation
        Private _timer As Timer

        ' Backing field for color
        Private _loaderColor As Color = Color.DodgerBlue

        ' Property visible in designer
        <Browsable(True), Category("Appearance")>
        Public Property LoaderColor As Color
            Get
                Return _loaderColor
            End Get
            Set(value As Color)
                _loaderColor = value
                Me.Invalidate() ' Redraw when color changes
            End Set
        End Property

        ' Animation speed
        Public Property Speed As Integer = 100

        ' Constructor
        Public Sub New()
            Me.DoubleBuffered = True
            _timer = New Timer()
            _timer.Interval = Speed
            AddHandler _timer.Tick, AddressOf OnTick
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

        ' Must be implemented in derived loader
        Protected MustOverride Sub OnTick(sender As Object, e As EventArgs)
    End Class
End Namespace
