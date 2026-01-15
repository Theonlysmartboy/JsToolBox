Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders

    Public Class SpinningSquareLoader
        Inherits LoaderBase

        Private _angle As Single = 0
        Private _squareSize As Integer = 24

        <Category("Appearance")>
        Public Property SquareSize As Integer
            Get
                Return _squareSize
            End Get
            Set(value As Integer)
                _squareSize = Math.Max(4, value)
                Invalidate()
            End Set
        End Property

        Public Sub New()
            DoubleBuffered = True
            Size = New Size(60, 60)
            Start() ' start animation
        End Sub

        ' Animation frame update
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _angle += 10
            If _angle > 360 Then _angle -= 360
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Calculate center
            Dim cx As Integer = Width \ 2
            Dim cy As Integer = Height \ 2
            Dim s As Integer = SquareSize

            ' Build square rect
            Dim rect As New Rectangle(cx - s \ 2, cy - s \ 2, s, s)

            ' Rotate around center
            g.TranslateTransform(cx, cy)
            g.RotateTransform(_angle)
            g.TranslateTransform(-cx, -cy)

            Using br As New SolidBrush(Me.LoaderColor)
                g.FillRectangle(br, rect)
            End Using

            g.ResetTransform()

            ' optional title text (centered)
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim sf As New StringFormat() With {
                    .Alignment = StringAlignment.Center,
                    .LineAlignment = StringAlignment.Center
                }

                Using b As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, b, Me.ClientRectangle, sf)
                End Using
            End If
        End Sub

    End Class
End Namespace
