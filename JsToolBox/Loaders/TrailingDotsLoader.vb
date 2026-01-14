Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders

    Public Class TrailingDotsLoader
        Inherits LoaderBase

        Private _dotCount As Integer = 8
        Private _radius As Integer = 15
        Private _dotSize As Integer = 6
        Private _currentIndex As Integer = 0

        <Browsable(True), Category("Appearance")>
        Public Property DotCount As Integer
            Get
                Return _dotCount
            End Get
            Set(value As Integer)
                If value < 3 Then value = 3
                _dotCount = value
                Me.Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property Radius As Integer
            Get
                Return _radius
            End Get
            Set(value As Integer)
                _radius = value
                Me.Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property DotSize As Integer
            Get
                Return _dotSize
            End Get
            Set(value As Integer)
                _dotSize = value
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _currentIndex = (_currentIndex + 1) Mod _dotCount
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim centerX = Me.Width \ 2
            Dim centerY = Me.Height \ 2

            For i As Integer = 0 To _dotCount - 1

                Dim angle = (360 / _dotCount) * i
                Dim rad = angle * Math.PI / 180

                Dim x = centerX + Math.Cos(rad) * _radius
                Dim y = centerY + Math.Sin(rad) * _radius

                ' Highlight the active dot (bigger/brighter)
                Dim scale As Single = If(i = _currentIndex, 1.6F, 1.0F)
                Dim alpha As Integer = If(i = _currentIndex, 255, 100)

                Dim size = CInt(_dotSize * scale)
                Dim dotRect As New Rectangle(CInt(x - size / 2), CInt(y - size / 2), size, size)

                Using brush As New SolidBrush(Color.FromArgb(alpha, Me.LoaderColor))
                    g.FillEllipse(brush, dotRect)
                End Using

            Next

            ' Optional centered title text
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim textSize = g.MeasureString(Me.Text, Me.Font)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor),
                             centerX - textSize.Width / 2,
                             centerY - textSize.Height / 2)
            End If

        End Sub

    End Class

End Namespace
