Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders
    Public Class DualRingLoader
        Inherits LoaderBase

        Private _angle As Integer = 0
        Private _innerAngle As Integer = 0

        Private _outerRingColor As Color = Color.DodgerBlue
        Private _innerRingColor As Color = Color.DeepSkyBlue
        Private _ringThickness As Integer = 4
        Private _arcLength As Integer = 220

        <Category("Appearance")>
        Public Property OuterRingColor As Color
            Get
                Return _outerRingColor
            End Get
            Set(value As Color)
                _outerRingColor = value
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property InnerRingColor As Color
            Get
                Return _innerRingColor
            End Get
            Set(value As Color)
                _innerRingColor = value
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property RingThickness As Integer
            Get
                Return _ringThickness
            End Get
            Set(value As Integer)
                _ringThickness = Math.Max(1, value)
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property ArcLength As Integer
            Get
                Return _arcLength
            End Get
            Set(value As Integer)
                _arcLength = Math.Max(10, Math.Min(350, value))
                Invalidate()
            End Set
        End Property

        Public Sub New()
            DoubleBuffered = True
            Me.Size = New Size(70, 70)
            Start()
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _angle = (_angle + 4) Mod 360
            _innerAngle = (_innerAngle - 6) Mod 360
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim cx As Integer = Width \ 2
            Dim cy As Integer = Height \ 2

            Dim radiusOuter As Integer = Math.Min(Width, Height) - RingThickness * 2
            Dim radiusInner As Integer = radiusOuter - (RingThickness * 4)

            Dim rectOuter As New Rectangle(RingThickness, RingThickness, radiusOuter, radiusOuter)
            Dim rectInner As New Rectangle(RingThickness * 3, RingThickness * 3, radiusInner, radiusInner)

            ' OUTER RING
            Using p1 As New Pen(OuterRingColor, RingThickness)
                g.DrawArc(p1, rectOuter, _angle, ArcLength)
            End Using

            ' INNER RING
            Using p2 As New Pen(InnerRingColor, RingThickness)
                g.DrawArc(p2, rectInner, _innerAngle, ArcLength)
            End Using

            ' Optional center text
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim format As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }

                Using b As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, b, Me.ClientRectangle, format)
                End Using
            End If
        End Sub

    End Class
End Namespace