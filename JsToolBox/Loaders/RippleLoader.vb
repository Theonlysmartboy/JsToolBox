Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders

    Public Class RippleLoader
        Inherits LoaderBase
        Private _waves As Integer = 2
        Private _maxRadius As Integer = 40
        Private _strokeWidth As Integer = 3
        Private _useFill As Boolean = False
        Private _progress As Single = 0
        <Category("Appearance")>
        Public Property WaveCount As Integer
            Get
                Return _waves
            End Get
            Set(value As Integer)
                _waves = Math.Max(1, Math.Min(5, value))
                Me.Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        Public Property MaxRadius As Integer
            Get
                Return _maxRadius
            End Get
            Set(value As Integer)
                _maxRadius = Math.Max(10, value)
                Me.Invalidate()
            End Set
        End Property
        <Category("Appearance")>
        Public Property StrokeWidth As Integer
            Get
                Return _strokeWidth
            End Get
            Set(value As Integer)
                _strokeWidth = Math.Max(1, value)
                Me.Invalidate()
            End Set
        End Property
        <Category("Appearance")>
        Public Property UseFill As Boolean
            Get
                Return _useFill
            End Get
            Set(value As Boolean)
                _useFill = value
                Me.Invalidate()
            End Set
        End Property

        Public Sub New()
            DoubleBuffered = True
            Size = New Size(100, 100)
            Start()
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Smooth progress 0.00 → 1.00
            _progress += 0.02
            If _progress >= 1.0F Then _progress = 0F
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim centerX As Integer = Width \ 2
            Dim centerY As Integer = Height \ 2
            For wave = 0 To _waves - 1
                ' Offset each wave for ripple effect
                Dim localProg As Single = (_progress + (wave / _waves)) Mod 1.0F
                ' Radius expands from 0 → MaxRadius
                Dim radius As Single = localProg * _maxRadius
                ' Fade from full → transparent
                Dim alpha As Integer = CInt(255 * (1 - localProg))
                If alpha < 0 Then alpha = 0
                Dim rippleColor As Color = Color.FromArgb(alpha, LoaderColor)
                Dim rect As New RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2)
                If UseFill Then
                    Using b As New SolidBrush(rippleColor)
                        g.FillEllipse(b, rect)
                    End Using
                Else
                    Using p As New Pen(rippleColor, StrokeWidth)
                        g.DrawEllipse(p, rect)
                    End Using
                End If
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