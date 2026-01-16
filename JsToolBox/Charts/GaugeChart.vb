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
            Dim padding As Integer = 30 ' margin from edges
            '--------------------------------------------------
            ' 1. Compute Diameter that ALWAYS fits inside control
            '--------------------------------------------------
            Dim maxDiameterWidth As Integer = Width - padding * 2
            Dim maxDiameterHeight As Integer = (Height - padding * 2) * 2
            Dim diameter As Integer = Math.Min(maxDiameterWidth, maxDiameterHeight)
            If diameter < 10 Then Exit Sub
            '--------------------------------------------------
            ' 2. Compute center and radius
            '--------------------------------------------------
            Dim radius As Single = diameter / 2.0F
            Dim tickMargin As Single = radius * 0.08F ' small offset for ticks to touch arc
            Dim cy As Single = Height - padding - radius * 0.1F  ' move slightly down so top fits
            Dim cx As Single = Width / 2.0F  ' bottom margin
            '--------------------------------------------------
            ' 3. Draw gauge arcs, ticks, needle, and value
            '--------------------------------------------------
            DrawGaugeArc(g, cx, cy, radius)
            DrawTicks(g, cx, cy, radius, tickMargin)
            DrawNeedle(g, cx, cy, radius * 0.85F) ' slightly shorter
            DrawTextValue(g, cx, cy - radius * 0.45F)
        End Sub

        '=========================================================
        ' Draw colored zones (arcs)
        '=========================================================
        Private Sub DrawGaugeArc(g As Graphics, cx As Single, cy As Single, radius As Single)
            Dim totalRange = _maxValue - _minValue
            Dim zones = {
                (0, _zoneGreen, Color.LimeGreen),
                (_zoneGreen, _zoneYellow, Color.Gold),
                (_zoneYellow, _zoneRed, Color.Red)
            }

            Dim penWidth As Single = radius * 0.15F

            For Each z In zones
                Dim startVal = z.Item1
                Dim endVal = z.Item2
                Dim col = z.Item3
                If endVal <= startVal Then Continue For

                Dim startAngle = 180 + (startVal / totalRange) * 180
                Dim sweep = (endVal - startVal) / totalRange * 180

                ' Centered rectangle for full circle around cx, cy
                Dim rect As New RectangleF(cx - radius, cy - radius, radius * 2, radius * 2)
                Using p As New Pen(col, penWidth)
                    p.LineJoin = LineJoin.Round
                    g.DrawArc(p, rect, CSng(startAngle), CSng(sweep))
                End Using
            Next
        End Sub

        '=========================================================
        ' Draw ticks
        '=========================================================
        Private Sub DrawTicks(g As Graphics, cx As Single, cy As Single, radius As Single, tickMargin As Single)
            Dim startAngle As Integer = 180
            Dim endAngle As Integer = 360
            For angle As Integer = startAngle To endAngle Step 5
                Dim isMajor As Boolean = (angle Mod 15 = 0)
                Dim thickness As Single = If(isMajor, 3.5F, 1.5F)
                Dim tickLength As Single = If(isMajor, radius * 0.18F, radius * 0.1F)

                Dim rad As Double = angle * Math.PI / 180
                Dim xOuter As Single = cx + Math.Cos(rad) * (radius + tickMargin)
                Dim yOuter As Single = cy + Math.Sin(rad) * (radius + tickMargin)
                Dim xInner As Single = cx + Math.Cos(rad) * (radius - tickLength)
                Dim yInner As Single = cy + Math.Sin(rad) * (radius - tickLength)

                Using p As New Pen(Color.Black, thickness)
                    g.DrawLine(p, xInner, yInner, xOuter, yOuter)
                End Using
            Next
        End Sub

        '=========================================================
        ' Draw needle
        '=========================================================
        Private Sub DrawNeedle(g As Graphics, cx As Single, cy As Single, length As Single)
            Dim range = _maxValue - _minValue
            Dim percent = (_animatedValue - _minValue) / range
            Dim angle = 180 + (percent * 180)
            Dim rad = angle * Math.PI / 180
            Dim baseRadius As Single = length * 0.08F  ' 8% of needle length, tweak as needed
            Using b As New SolidBrush(Color.Black)
                g.FillEllipse(b, cx - baseRadius, cy - baseRadius, baseRadius * 2, baseRadius * 2)
            End Using
            ' Needle endpoint
            Dim x2 As Single = cx + Math.Cos(rad) * length
            Dim y2 As Single = cy + Math.Sin(rad) * length
            ' Draw needle shaft
            Using p As New Pen(Color.Black, 4)
                g.DrawLine(p, cx, cy, x2, y2)
            End Using
            ' Needle arrowhead
            Dim headSize As Single = length * 0.15F
            Dim halfWidth As Single = headSize / 3
            Dim leftAngle = rad + Math.PI / 2
            Dim rightAngle = rad - Math.PI / 2
            Dim xLeft = x2 + Math.Cos(leftAngle) * halfWidth
            Dim yLeft = y2 + Math.Sin(leftAngle) * halfWidth
            Dim xRight = x2 + Math.Cos(rightAngle) * halfWidth
            Dim yRight = y2 + Math.Sin(rightAngle) * halfWidth
            Dim xTip = x2 + Math.Cos(rad) * headSize
            Dim yTip = y2 + Math.Sin(rad) * headSize
            Dim pts As PointF() = {
                New PointF(xLeft, yLeft),
                New PointF(xRight, yRight),
                New PointF(xTip, yTip)
            }
            Using b As New SolidBrush(Color.Black)
                g.FillPolygon(b, pts)
            End Using
        End Sub

        '=========================================================
        ' Draw numeric value
        '=========================================================
        Private Sub DrawTextValue(g As Graphics, cx As Single, cy As Single)
            Dim txt = $"{CInt(_animatedValue)}"
            Dim f As New Font("Segoe UI", 18, FontStyle.Bold)
            Dim size = g.MeasureString(txt, f)
            g.DrawString(txt, f, Brushes.Black, cx - size.Width / 2, cy - size.Height / 2)
        End Sub

        '=========================================================
        ' Unused (required override from ChartBase)
        '=========================================================
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
        End Sub
    End Class
End Namespace
