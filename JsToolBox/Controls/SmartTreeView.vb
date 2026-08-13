Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports JsToolBox.Controls.TreeView.Enums
Imports JsToolBox.Controls.TreeView.Nodes

Namespace Controls.TreeView

    Public Class SmartTreeView
        Inherits Control

        Private ReadOnly _nodes As SmartTreeViewNodeCollection
        Private ReadOnly _hitTestItems As New List(Of SmartTreeViewHitTestInfo)
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
            IndicatorPosition = SmartTreeViewIndicatorPosition.BeforeText
            NodeHeight = 24
            ParentNodeBackColor = Color.Empty
            ShowNodeDividers = False
            NodeDividerColor = Color.Empty
        End Sub

        <Category("Appearance")>
        <DefaultValue(SmartTreeViewIndicatorPosition.BeforeText)>
        Public Property IndicatorPosition As SmartTreeViewIndicatorPosition

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property ParentNodeBackColor As Color

        <Category("Appearance")>
        <DefaultValue(False)>
        Public Property ShowNodeDividers As Boolean

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property NodeDividerColor As Color

        <Category("Appearance")>
        <DefaultValue(24)>
        Public Property NodeHeight As Integer

        <Category("Behavior")>
        <DefaultValue(SmartTreeViewSelectionMode.MultiSelect)>
        Public Property SelectionMode As SmartTreeViewSelectionMode

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Nodes As SmartTreeViewNodeCollection
            Get
                Return _nodes
            End Get
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            _hitTestItems.Clear()
            Dim currentY As Integer = 0
            For Each node As SmartTreeViewNode In _nodes
                DrawNode(e.Graphics, node, 0, currentY)
            Next
        End Sub

        Private Sub DrawNode(graphics As Graphics, node As SmartTreeViewNode, level As Integer, ByRef currentY As Integer)
            Dim x As Integer = level * IndentWidth
            Dim nodeBounds As New Rectangle(0, currentY, Width, NodeHeight)
            Dim glyphRect As Rectangle
            If node.HasChildren AndAlso ParentNodeBackColor <> Color.Empty Then
                Using backgroundBrush As New SolidBrush(ParentNodeBackColor)
                    graphics.FillRectangle(backgroundBrush, nodeBounds)
                End Using
            End If
            If node.HasChildren Then
                glyphRect = New Rectangle(x, currentY + 6, GlyphSize, GlyphSize)
            Else
                glyphRect = Rectangle.Empty
            End If
            _hitTestItems.Add(New SmartTreeViewHitTestInfo With {
                .Node = node,
                .GlyphBounds = glyphRect,
                .NodeBounds = nodeBounds,
                .Level = level
            })
            DrawExpandGlyph(graphics, node, x, currentY)
            Dim textX As Integer = x + GlyphSize + 6
            Using textBrush As New SolidBrush(If(node.Enabled, ForeColor, Color.Gray))
                graphics.DrawString(node.Text, Font, textBrush, textX, currentY + 3)
            End Using
            If ShowNodeDividers Then
                Dim dividerColor As Color = If(NodeDividerColor = Color.Empty, Color.LightGray, NodeDividerColor)
                Using dividerPen As New Pen(dividerColor)
                    graphics.DrawLine(dividerPen, 0, currentY + NodeHeight - 1, Width, currentY + NodeHeight - 1)
                End Using
            End If
            currentY += NodeHeight
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

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button <> MouseButtons.Left Then
                Return
            End If
            For Each item In _hitTestItems
                If item.GlyphBounds.Contains(e.Location) Then
                    If item.Node.HasChildren AndAlso item.Node.Enabled Then
                        item.Node.Expanded = Not item.Node.Expanded
                        Invalidate()
                    End If
                    Return
                End If
            Next
        End Sub
    End Class
End Namespace