Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders
    Public Class FacebookShimmerLoader
        Inherits LoaderBase

        Private _cornerRadius As Integer = 12
        Private _shineWidth As Integer = 80
        Private _shineOpacity As Integer = 120
        Private _progress As Single = 0

        <Category("Appearance")>
        Public Property CornerRadius As Integer
            Get
                Return _cornerRadius
            End Get
            Set(value As Integer)
                _cornerRadius = Math.Max(0, value)
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property ShineWidth As Integer
            Get
                Return _shineWidth
            End Get
            Set(value As Integer)
                _shineWidth = Math.Max(20, value)
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property ShineOpacity As Integer
            Get
                Return _shineOpacity
            End Get
            Set(value As Integer)
                _shineOpacity = Math.Max(10, Math.Min(255, value))
                Invalidate()
            End Set
        End Property

        Public Sub New()
            DoubleBuffered = True
            Size = New Size(200, 60)
            Start()
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _progress += 0.02
            If _progress > 1 Then _progress = 0
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.PixelOffsetMode = PixelOffsetMode.HighQuality
            Dim rect As Rectangle = Me.ClientRectangle
            ' 1. Background placeholder block
            Using bgBrush As New SolidBrush(Color.FromArgb(60, LoaderColor))
                g.FillPath(bgBrush, RoundedRect(rect, CornerRadius))
            End Using
            ' 2. Moving shimmer band
            Dim shimmerRect As New Rectangle(
            CInt((_progress * (Width + ShineWidth * 2)) - ShineWidth), 0, ShineWidth, Height)
            Dim shineColor As Color = Color.FromArgb(ShineOpacity, Color.White)

            Using lg As New LinearGradientBrush(shimmerRect, Color.Transparent, shineColor, 45.0F)
                g.FillRectangle(lg, shimmerRect)
            End Using
            ' 3. Draw overlay text (optional)
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim sf As New StringFormat With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
                Using br As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, br, rect, sf)
                End Using
            End If
        End Sub

        Private Function RoundedRect(bounds As Rectangle, radius As Integer) As GraphicsPath
            Dim p As New GraphicsPath
            Dim dia As Integer = radius * 2
            If radius = 0 Then
                p.AddRectangle(bounds)
                Return p
            End If
            p.AddArc(bounds.X, bounds.Y, dia, dia, 180, 90)
            p.AddArc(bounds.Right - dia, bounds.Y, dia, dia, 270, 90)
            p.AddArc(bounds.Right - dia, bounds.Bottom - dia, dia, dia, 0, 90)
            p.AddArc(bounds.X, bounds.Bottom - dia, dia, dia, 90, 90)
            p.CloseFigure()
            Return p
        End Function
    End Class
End Namespace