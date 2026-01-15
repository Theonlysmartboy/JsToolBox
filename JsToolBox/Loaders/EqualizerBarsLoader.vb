Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders
    Public Class EqualizerBarsLoader
        Inherits LoaderBase
        Private _bars As Integer = 5
        Private _barWidth As Integer = 6
        Private _barSpacing As Integer = 4
        Private _maxHeight As Integer = 30
        Private _phase As Double = 0
        Private _barValues As Single()

        Public Enum EqualizerStyle
            ClassicEqualizer = 0
            Wave = 1
            DJ = 2
        End Enum
        Private _style As EqualizerStyle = EqualizerStyle.ClassicEqualizer

        <Category("Appearance")>
        Public Property BarCount As Integer
            Get
                Return _bars
            End Get
            Set(value As Integer)
                _bars = Math.Max(1, Math.Min(12, value))
                ReDim _barValues(_bars - 1)
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property BarWidth As Integer
            Get
                Return _barWidth
            End Get
            Set(value As Integer)
                _barWidth = Math.Max(1, value)
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property BarSpacing As Integer
            Get
                Return _barSpacing
            End Get
            Set(value As Integer)
                _barSpacing = Math.Max(0, value)
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property MaxBarHeight As Integer
            Get
                Return _maxHeight
            End Get
            Set(value As Integer)
                _maxHeight = Math.Max(10, value)
                Invalidate()
            End Set
        End Property

        <Category("Behavior")>
        Public Property Style As EqualizerStyle
            Get
                Return _style
            End Get
            Set(value As EqualizerStyle)
                _style = value
                Invalidate()
            End Set
        End Property

        Public Sub New()
            DoubleBuffered = True
            ReDim _barValues(_bars - 1)
            Me.Size = New Size(100, 40)
            Start()
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            Select Case _style
                Case EqualizerStyle.ClassicEqualizer
                    ' Each bar moves independently between 0 and max
                    Dim rnd As New Random
                    For i = 0 To _bars - 1
                        _barValues(i) = rnd.Next(10, _maxHeight)
                    Next
                Case EqualizerStyle.Wave
                    ' Bars follow a wave pattern
                    _phase += 0.2
                    For i = 0 To _bars - 1
                        _barValues(i) = CInt((_maxHeight / 2) + Math.Sin(_phase + (i * 0.7)) * (_maxHeight / 2))
                    Next
                Case EqualizerStyle.DJ
                    ' “DJ Style” – random spikes but stays lively
                    Dim rnd As New Random
                    For i = 0 To _bars - 1
                        If rnd.NextDouble() < 0.3 Then
                            _barValues(i) = _maxHeight
                        Else
                            _barValues(i) = rnd.Next(5, _maxHeight - 5)
                        End If
                    Next
            End Select
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim totalWidth As Integer = (_bars * _barWidth) + ((_bars - 1) * _barSpacing)
            Dim startX As Integer = (Width - totalWidth) \ 2
            Dim bottomY As Integer = Height - 5
            For i = 0 To _bars - 1
                Dim barHeight As Integer = CInt(_barValues(i))
                Dim x As Integer = startX + i * (_barWidth + _barSpacing)
                Dim y As Integer = bottomY - barHeight
                Using b As New SolidBrush(Me.LoaderColor)
                    g.FillRectangle(b, x, y, _barWidth, barHeight)
                End Using
            Next
            ' Optional center text
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim sf As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
                Using br As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, br, Me.ClientRectangle, sf)
                End Using
            End If
        End Sub
    End Class
End Namespace