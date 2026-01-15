Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders
    Public Class ChasingDotsLoader
        Inherits LoaderBase

        Private angle As Single = 0F

        <Browsable(True), Category("Appearance")>
        Public Property DotCount As Integer = 8

        <Browsable(True), Category("Appearance")>
        Public Property DotSize As Integer = 10

        <Browsable(True), Category("Appearance")>
        Public Property RotationSpeed As Integer = 8

        <Browsable(True), Category("Appearance")>
        Public Property FadeIntensity As Integer = 180    ' Max alpha

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            angle = (angle + RotationSpeed) Mod 360
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim radius As Integer = Math.Min(Me.Width, Me.Height) \ 3
            Dim centerX As Integer = Me.Width \ 2
            Dim centerY As Integer = Me.Height \ 2

            For i As Integer = 0 To DotCount - 1
                ' Determine dot angle
                Dim dotAngle As Single = angle + (360 / DotCount) * i
                Dim rad As Single = dotAngle * (Math.PI / 180)

                ' Dot position
                Dim x As Integer = centerX + Math.Cos(rad) * radius
                Dim y As Integer = centerY + Math.Sin(rad) * radius

                x -= DotSize \ 2
                y -= DotSize \ 2

                ' Calculate fade based on position in cycle
                Dim alphaFade As Integer = CInt(((i / DotCount) * FadeIntensity) Mod FadeIntensity)

                alphaFade = Math.Max(40, alphaFade)

                Using br As New SolidBrush(Color.FromArgb(alphaFade, LoaderColor))
                    g.FillEllipse(br, New Rectangle(x, y, DotSize, DotSize))
                End Using
            Next

            ' Center text
            If Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim textSize = g.MeasureString(Me.Text, Me.Font)
                Using br As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, br, (Me.Width - textSize.Width) / 2, (Me.Height - textSize.Height) / 2)
                End Using
            End If

        End Sub

    End Class
End Namespace
