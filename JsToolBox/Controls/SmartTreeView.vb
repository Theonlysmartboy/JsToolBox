Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports JsToolBox.Controls.TreeView.Nodes

Namespace Controls.TreeView

    Public Class SmartTreeView
        Inherits Control

        Private ReadOnly _nodes As SmartTreeViewNodeCollection
        Private Const NodeHeight As Integer = 24
        Private Const IndentWidth As Integer = 20
        Private Const GlyphSize As Integer = 12

        Public Sub New()
            _nodes = New SmartTreeViewNodeCollection(Nothing)
            Me.SetStyle(ControlStyles.UserPaint Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer Or
                ControlStyles.ResizeRedraw,
                True)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Font = New Font("Segoe UI", 9.0F)
            Me.Size = New Size(300, 250)
            Me.TabStop = True
        End Sub

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Nodes As SmartTreeViewNodeCollection
            Get
                Return _nodes
            End Get
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim currentY As Integer = 0
            For Each node As SmartTreeViewNode In _nodes
                DrawNode(e.Graphics, node, 0, currentY)
            Next
        End Sub

        Private Sub DrawNode(graphics As Graphics, node As SmartTreeViewNode, level As Integer, ByRef currentY As Integer)
            Dim x As Integer = level * IndentWidth
            ' Draw expand/collapse indicator
            DrawExpandGlyph(graphics, node, x, currentY)
            Dim textX As Integer = x + GlyphSize + 6
            Using textBrush As New SolidBrush(ForeColor)
                graphics.DrawString(node.Text, Font, textBrush, textX, currentY + 3)
            End Using
            currentY += NodeHeight
            ' Draw children only when expanded
            If node.Expanded AndAlso node.HasChildren Then
                For Each child As SmartTreeViewNode In node.Nodes
                    DrawNode(graphics, child, level + 1, currentY)
                Next
            End If
        End Sub

        Private Sub DrawExpandGlyph(graphics As Graphics, node As SmartTreeViewNode, x As Integer, y As Integer)
            If Not node.HasChildren Then
                Return
            End If
            Dim glyphRect As New Rectangle(x, y + 6, GlyphSize, GlyphSize)
            Using pen As New Pen(Color.Gray, 1)
                graphics.DrawRectangle(pen, glyphRect)
                Dim centerX As Integer = glyphRect.Left + glyphRect.Width \ 2
                Dim centerY As Integer = glyphRect.Top + glyphRect.Height \ 2
                ' Horizontal line
                graphics.DrawLine(pen, glyphRect.Left + 3, centerY, glyphRect.Right - 3, centerY)
                ' Vertical line = collapsed
                If Not node.Expanded Then
                    graphics.DrawLine(pen, centerX, glyphRect.Top + 3, centerX, glyphRect.Bottom - 3)
                End If
            End Using
        End Sub
    End Class
End Namespace