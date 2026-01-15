Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders
    Public Class WaveBarsLoader
        Inherits LoaderBase

        Private _tick As Integer = 0

        <Browsable(True), Category("Appearance")>
        Public Property BarCount As Integer = 5

        <Browsable(True), Category("Appearance")>
        Public Property BarWidth As Integer = 6

        <Browsable(True), Category("Appearance")>
        Public Property BarSpacing As Integer = 4

        <Browsable(True), Category("Appearance")>
        Public Property Amplitude As Integer = 12

        <Browsable(True), Category("Behavior")>
        Public Property SpeedFactor As Integer = 4

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _tick += 1
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim totalWidth = (BarCount * BarWidth) + ((BarCount - 1) * BarSpacing)
            Dim startX = (Me.Width - totalWidth) \ 2
            Dim centerY = Me.Height \ 2

            For i As Integer = 0 To BarCount - 1
                Dim waveOffset = Math.Sin((_tick + (i * SpeedFactor)) * 0.2)
                Dim barHeight = (Me.Height \ 3) + CInt(waveOffset * Amplitude)

                Dim x = startX + i * (BarWidth + BarSpacing)
                Dim y = centerY - (barHeight \ 2)
                Dim rect = New Rectangle(x, y, BarWidth, barHeight)

                Using br As New SolidBrush(Me.LoaderColor)
                    g.FillRectangle(br, rect)
                End Using
            Next

            ' Optional Center title text
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim txtSize = g.MeasureString(Me.Text, Me.Font)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), (Me.Width - txtSize.Width) / 2, (Me.Height - txtSize.Height) / 2)
            End If

        End Sub

    End Class
End Namespace
