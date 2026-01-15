Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders

    Public Class PulseLoader
        Inherits LoaderBase

        Private _scale As Single = 1.0F
        Private _growing As Boolean = True

        <Browsable(True), Category("Appearance")>
        Public Property MinScale As Single = 0.7F

        <Browsable(True), Category("Appearance")>
        Public Property MaxScale As Single = 1.4F

        <Browsable(True), Category("Appearance")>
        Public Property PulseStep As Single = 0.05F

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            If _growing Then
                _scale += PulseStep
                If _scale >= MaxScale Then _growing = False
            Else
                _scale -= PulseStep
                If _scale <= MinScale Then _growing = True
            End If

            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim centerX = Me.Width \ 2
            Dim centerY = Me.Height \ 2

            Dim size = CInt(Math.Min(Me.Width, Me.Height) * _scale * 0.6)
            Dim rect As New Rectangle(centerX - size \ 2, centerY - size \ 2, size, size)

            Using brush As New SolidBrush(Me.LoaderColor)
                g.FillEllipse(brush, rect)
            End Using

            ' Optional center text
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim txtSize = g.MeasureString(Me.Text, Me.Font)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), centerX - txtSize.Width / 2, centerY - txtSize.Height / 2)
            End If

        End Sub

    End Class

End Namespace
