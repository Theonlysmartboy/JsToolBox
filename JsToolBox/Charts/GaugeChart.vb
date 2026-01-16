Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Charts
    Public Class GaugeChart
        Inherits ChartBase

        '=========================================================
        ' Private fields
        '=========================================================
        Private _minValue As Integer = 0
        Private _maxValue As Integer = 100
        Private _value As Integer = 0
        Private _animatedValue As Single = 0
        Private _animationTimer As Timer
        ' Multi-segment zones
        Private _zoneGreen As Integer = 40
        Private _zoneYellow As Integer = 70
        Private _zoneRed As Integer = 100
        ' Gradient colors
        Private _gradientStart As Color = Color.LightGray
        Private _gradientEnd As Color = Color.DimGray

        Public Sub New()
            MyBase.New()
            ' Disable MSChart visuals
            _chart.Visible = False
            _chart.Enabled = False
            DoubleBuffered = True
            _animationTimer = New Timer With {.Interval = 15}
            AddHandler _animationTimer.Tick, AddressOf Animate
        End Sub

        '=========================================================
        ' Designer Properties
        '=========================================================
        <Category("Gauge"), Description("Minimum gauge value.")>
        Public Property Minimum As Integer
            Get
                Return _minValue
            End Get
            Set(value As Integer)
                _minValue = value
                Invalidate()
            End Set
        End Property

        <Category("Gauge"), Description("Maximum gauge value.")>
        Public Property Maximum As Integer
            Get
                Return _maxValue
            End Get
            Set(value As Integer)
                _maxValue = value
                Invalidate()
            End Set
        End Property

        <Category("Gauge"), Description("Current value of the gauge.")>
        Public Property Value As Integer
            Get
                Return _value
            End Get
            Set(val As Integer)
                _value = Math.Max(_minValue, Math.Min(_maxValue, val))
                _animationTimer.Start()
            End Set
        End Property

        <Category("Gauge"), Description("Gradient start color.")>
        Public Property GradientStart As Color
            Get
                Return _gradientStart
            End Get
            Set(value As Color)
                _gradientStart = value
                Invalidate()
            End Set
        End Property

        <Category("Gauge"), Description("Gradient end color.")>
        Public Property GradientEnd As Color
            Get
                Return _gradientEnd
            End Get
            Set(value As Color)
                _gradientEnd = value
                Invalidate()
            End Set
        End Property

        <Category("Gauge Zones"), Description("Cutoff for green zone.")>
        Public Property ZoneGreen As Integer
            Get
                Return _zoneGreen
            End Get
            Set(value As Integer)
                _zoneGreen = value
                Invalidate()
            End Set
        End Property

        <Category("Gauge Zones"), Description("Cutoff for yellow zone.")>
        Public Property ZoneYellow As Integer
            Get
                Return _zoneYellow
            End Get
            Set(value As Integer)
                _zoneYellow = value
                Invalidate()
            End Set
        End Property

        <Category("Gauge Zones"), Description("Cutoff for red zone.")>
        Public Property ZoneRed As Integer
            Get
                Return _zoneRed
            End Get
            Set(value As Integer)
                _zoneRed = value
                Invalidate()
            End Set
        End Property

        '=========================================================
        ' Animation
        '=========================================================
        Private Sub Animate(sender As Object, e As EventArgs)
            Dim diff = _value - _animatedValue
            If Math.Abs(diff) < 0.5 Then
                _animatedValue = _value
                _animationTimer.Stop()
            Else
                _animatedValue += diff * 0.15F
            End If
            Invalidate()
        End Sub

        '=========================================================
        ' Rendering
        '=========================================================
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim rect = New Rectangle(10, 10, Width - 20, Height * 2 - 40)
            Dim radius = rect.Width \ 2
            Dim cx = Width \ 2
            Dim cy = Height - 10
            ' Draw multi-zone arc (green/yellow/red)
            DrawGaugeArc(g, rect)
            ' Draw needle
            DrawNeedle(g, cx, cy, radius - 20)
            ' Draw text
            DrawTextValue(g, cx, cy - 20)
        End Sub


        '=========================================================
        ' Draw colored zones
        '=========================================================
        Private Sub DrawGaugeArc(g As Graphics, r As Rectangle)
            Dim totalRange = _maxValue - _minValue
            Dim zones = {
                (0, _zoneGreen, Color.LimeGreen),
                (_zoneGreen, _zoneYellow, Color.Gold),
                (_zoneYellow, _zoneRed, Color.Red)
            }
            For Each z In zones
                Dim startVal = z.Item1
                Dim endVal = z.Item2
                Dim col = z.Item3
                If endVal <= startVal Then Continue For
                Dim startAngle = 180 + (startVal / totalRange) * 180
                Dim sweep = (endVal - startVal) / totalRange * 180
                Using p As New Pen(col, 20)
                    g.DrawArc(p, New RectangleF(r.X, r.Y, r.Width, r.Height), CSng(startAngle), CSng(sweep))
                End Using
            Next
        End Sub

        '=========================================================
        ' Draw the needle
        '=========================================================
        Private Sub DrawNeedle(g As Graphics, cx As Integer, cy As Integer, length As Integer)
            Dim range = _maxValue - _minValue
            Dim percent = (_animatedValue - _minValue) / range
            Dim angle = 180 + (percent * 180)
            Dim rad = angle * Math.PI / 180
            Dim x2 = cx + Math.Cos(rad) * length
            Dim y2 = cy + Math.Sin(rad) * length
            Dim x2s As Single = CSng(x2)
            Dim y2s As Single = CSng(y2)
            Using p As New Pen(Color.Black, 4)
                g.DrawLine(p, CSng(cx), CSng(cy), x2s, y2s)
            End Using
            Using b As New SolidBrush(Color.Black)
                g.FillEllipse(b, cx - 6, cy - 6, 12, 12)
            End Using
        End Sub

        '=========================================================
        ' Draw value text
        '=========================================================
        Private Sub DrawTextValue(g As Graphics, cx As Integer, cy As Integer)
            Dim txt = $"{CInt(_animatedValue)}"
            Dim f As New Font("Segoe UI", 18, FontStyle.Bold)
            Dim size = g.MeasureString(txt, f)
            g.DrawString(txt, f, Brushes.Black, cx - size.Width / 2, cy - size.Height / 2)
        End Sub

        '=========================================================
        ' Unused (required override from ChartBase)
        '=========================================================
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Not used for gauge.
        End Sub
    End Class
End Namespace
