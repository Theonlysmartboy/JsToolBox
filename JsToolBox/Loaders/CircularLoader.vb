Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports JsToolBox.Base
Namespace Loaders

    Public Class CircularLoader
        Inherits LoaderBase

        ' Backing fields
        Private _angle As Integer = 0
        Private _loaderColor As Color = Color.DodgerBlue
        Private _lineThickness As Integer = 4
        Private _arcLength As Integer = 270

        ' Designer-visible properties
        <Browsable(True), Category("Appearance")>
        Public Overloads Property LoaderColor As Color
            Get
                Return _loaderColor
            End Get
            Set(value As Color)
                _loaderColor = value
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

        ' Animation tick
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            _angle = (_angle + 20) Mod 360
            Me.Invalidate()
        End Sub

        ' Draw the circular loader
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim rect As New Rectangle(LineThickness, LineThickness, Me.Width - 2 * LineThickness, Me.Height - 2 * LineThickness)
            Using pen As New Pen(LoaderColor, LineThickness)
                g.DrawArc(pen, rect, _angle, ArcLength)
            End Using
        End Sub
    End Class
End Namespace
