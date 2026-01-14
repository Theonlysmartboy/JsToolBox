Imports System.Drawing
Imports System.Windows.Forms

Public MustInherit Class LoaderBase
    Inherits Control

    Private _timer As Timer

    Public Property LoaderColor As Color = Color.DodgerBlue
    Public Property Speed As Integer = 100 ' ms interval

    Public Sub New()
        Me.DoubleBuffered = True
        _timer = New Timer()
        _timer.Interval = Speed
        AddHandler _timer.Tick, AddressOf OnTick
    End Sub

    Public Sub Start()
        _timer.Start()
    End Sub

    Public Sub [Stop]()
        _timer.Stop()
        Me.Invalidate()
    End Sub

    Protected MustOverride Sub OnTick(sender As Object, e As EventArgs)
End Class
