Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base

Namespace Loaders
    Public Class CircularLoader
        Inherits LoaderBase

        Private _angle As Integer = 0
        Private _lineThickness As Integer = 4
        Private _arcLength As Integer = 270
        Private _showTitle As Boolean = False

        <Browsable(True), Category("Appearance")>
        Public Overloads Property LoaderColor As Color
            Get
                Return MyBase.LoaderColor
            End Get
            Set(value As Color)
                MyBase.LoaderColor = value
                Me.Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property LineThickness As Integer
            Get
                Return _lineThickness
            End Get
            Set(value As Integer)
                _lineThickness = value
                Me.Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property ArcLength As Integer
            Get
                Return _arcLength
            End Get
            Set(value As Integer)
                _arcLength = value
                Me.Invalidate()
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property ShowTitle As Boolean
            Get
                Return _showTitle
            End Get
            Set(value As Boolean)
                _showTitle = value
                Me.Invalidate()
            End Set
        End Property

        ' Ticker
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _angle = (_angle + 20) Mod 360
            Me.Invalidate()
        End Sub

        ' Draw loader + optional title
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Draw arc
            Dim rect As New Rectangle(LineThickness,
                                      LineThickness,
                                      Me.Width - 2 * LineThickness,
                                      Me.Height - 2 * LineThickness)

            Using pen As New Pen(LoaderColor, LineThickness)
                g.DrawArc(pen, rect, _angle, ArcLength)
            End Using

            ' Draw title if enabled
            If ShowTitle AndAlso Not String.IsNullOrWhiteSpace(Me.Text) Then
                Dim textSize = g.MeasureString(Me.Text, Me.Font)

                Dim x = (Me.Width - textSize.Width) / 2
                Dim y = (Me.Height - textSize.Height) / 2

                Using br As New SolidBrush(Me.ForeColor)
                    g.DrawString(Me.Text, Me.Font, br, x, y)
                End Using
            End If
        End Sub

    End Class
End Namespace
