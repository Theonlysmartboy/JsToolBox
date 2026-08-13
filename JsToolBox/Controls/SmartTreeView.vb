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

        Private _checkMode As SmartTreeViewCheckMode = SmartTreeViewCheckMode.CheckBox

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
            Me.NodeHeight = 24
            IndicatorPosition = SmartTreeViewIndicatorPosition.AfterText
            ParentNodeBackColor = Color.Empty
            GrandParentNodeBackColor = Color.Empty
            ShowNodeDividers = False
            NodeDividerColor = Color.Empty
        End Sub

        ' Appearance
        <Category("Appearance")>
        <DefaultValue(SmartTreeViewIndicatorPosition.BeforeText)>
        Public Property IndicatorPosition As SmartTreeViewIndicatorPosition

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property ParentNodeBackColor As Color

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property GrandParentNodeBackColor As Color

        <Category("Appearance")>
        <DefaultValue(False)>
        Public Property ShowNodeDividers As Boolean

        <Category("Appearance")>
        <DefaultValue(24)>
        Public Property NodeHeight As Integer

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property NodeDividerColor As Color

        ' Behavior
        <Category("Behavior")>
        <DefaultValue(SmartTreeViewCheckMode.CheckBox)>
        Public Property CheckMode As SmartTreeViewCheckMode
            Get
                Return _checkMode
            End Get
            Set(value As SmartTreeViewCheckMode)
                If _checkMode = value Then
                    Return
                End If
                _checkMode = value
                ' Radio buttons allow only one checked node.
                If _checkMode = SmartTreeViewCheckMode.RadioButton Then
                    NormalizeRadioCheckedState()
                End If
                Invalidate()
            End Set
        End Property

        <Category("Behavior")>
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedNode As SmartTreeViewNode
            Get
                For Each node As SmartTreeViewNode In _nodes
                    Dim selected As SmartTreeViewNode = FindSelectedNode(node)
                    If selected IsNot Nothing Then
                        Return selected
                    End If
                Next
                Return Nothing
            End Get
        End Property

        ' Nodes
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Nodes As SmartTreeViewNodeCollection
            Get
                Return _nodes
            End Get
        End Property
        ' Painting
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
            If node.HasChildren Then
                glyphRect = New Rectangle(x, currentY + 6, GlyphSize, GlyphSize)
            Else
                glyphRect = Rectangle.Empty
            End If
            ' Store hit-test information.
            _hitTestItems.Add(New SmartTreeViewHitTestInfo With {
                    .Node = node,
                    .GlyphBounds = glyphRect,
                    .NodeBounds = nodeBounds,
                    .Level = level
                })
            ' Determine hierarchy background
            Dim backgroundColor As Color = GetNodeBackgroundColor(node)
            If backgroundColor <> Color.Empty Then
                Using backgroundBrush As New SolidBrush(backgroundColor)
                    graphics.FillRectangle(backgroundBrush, nodeBounds)
                End Using
            End If
            ' Expand / collapse glyph
            DrawExpandGlyph(graphics, node, x, currentY)
            ' Node text
            Dim textX As Integer = x + GlyphSize + 6
            Dim textColor As Color = If(node.Enabled, ForeColor, Color.Gray)
            Using textBrush As New SolidBrush(textColor)
                graphics.DrawString(node.Text, Font, textBrush, textX, currentY + 3)
            End Using
            ' Divider
            If ShowNodeDividers Then
                Dim dividerColor As Color = If(NodeDividerColor = Color.Empty, Color.LightGray, NodeDividerColor)
                Using dividerPen As New Pen(dividerColor)
                    graphics.DrawLine(dividerPen, 0, currentY + NodeHeight - 1, Width, currentY + NodeHeight - 1)
                End Using
            End If
            currentY += NodeHeight
            ' Children
            If node.Expanded AndAlso node.HasChildren Then
                For Each child As SmartTreeViewNode In node.Nodes
                    DrawNode(graphics, child, level + 1, currentY)
                Next
            End If
        End Sub

        ' Hierarchy background
        Private Function GetNodeBackgroundColor(node As SmartTreeViewNode) As Color
            If Not node.HasChildren Then
                Return Color.Empty
            End If
            ' A grandparent is a node that has at least one
            ' child which itself has children.
            For Each child As SmartTreeViewNode In node.Nodes
                If child.HasChildren Then
                    If GrandParentNodeBackColor <> Color.Empty Then
                        Return GrandParentNodeBackColor
                    End If
                    Exit For
                End If
            Next
            ' Otherwise this is a normal parent.
            If ParentNodeBackColor <> Color.Empty Then
                Return ParentNodeBackColor
            End If
            Return Color.Empty
        End Function

        ' Expand / Collapse Glyph
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
                ' Vertical line means collapsed.
                If Not node.Expanded Then
                    graphics.DrawLine(pen, centerX, glyphRect.Top + 3, centerX, glyphRect.Bottom - 3)
                End If
            End Using
        End Sub

        ' Mouse Interaction
        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button <> MouseButtons.Left Then
                Return
            End If
            For Each item As SmartTreeViewHitTestInfo In _hitTestItems
                ' Expand / Collapse
                If item.GlyphBounds.Contains(e.Location) Then
                    If item.Node.HasChildren AndAlso item.Node.Enabled Then
                        item.Node.Expanded = Not item.Node.Expanded
                        Invalidate()
                    End If
                    Return
                End If
                ' Node area
                ' Indicators will get their own hit-test area
                ' in the next rendering step.
                If item.NodeBounds.Contains(e.Location) Then
                    If item.Node.Enabled Then
                        ' For now, because indicators have not yet
                        ' been rendered, clicking the node row is
                        ' treated as node selection.
                        SelectNode(item.Node)
                    End If
                    Return
                End If
            Next
        End Sub

        ' Selection
        Private Sub SelectNode(node As SmartTreeViewNode)
            If node Is Nothing Then
                Return
            End If
            If Not node.Enabled Then
                Return
            End If
            ' Clear the previous node selection.
            ClearSelectedNodes()
            ' Select this node.
            node.Selected = True
            Invalidate()
        End Sub

        Private Sub CheckNode(node As SmartTreeViewNode)
            If node Is Nothing Then
                Return
            End If
            If Not node.Enabled Then
                Return
            End If
            Select Case CheckMode
                Case SmartTreeViewCheckMode.None
                    Return
                Case SmartTreeViewCheckMode.CheckBox
                    node.Checked = Not node.Checked
                    ApplyCheckStateToChildren(node, node.Checked)
                Case SmartTreeViewCheckMode.RadioButton
                    ClearAllCheckedNodes()
                    node.Checked = True
            End Select
            Invalidate()
        End Sub

        Private Sub ClearSelectedNodes()
            For Each node As SmartTreeViewNode In _nodes
                ClearSelectedRecursive(node)
            Next
        End Sub

        Private Sub ApplyCheckStateToChildren(node As SmartTreeViewNode, checkedState As Boolean)
            For Each child As SmartTreeViewNode In node.Nodes
                child.Checked = checkedState
                ApplyCheckStateToChildren(child, checkedState)
            Next
        End Sub

        Private Sub ClearAllCheckedNodes()
            For Each node As SmartTreeViewNode In _nodes
                ClearCheckedRecursive(node)
            Next
        End Sub

        Private Sub ClearCheckedRecursive(node As SmartTreeViewNode)
            node.Checked = False
            For Each child As SmartTreeViewNode In node.Nodes
                ClearCheckedRecursive(child)
            Next
        End Sub

        Private Sub ClearSelectedRecursive(node As SmartTreeViewNode)
            node.Selected = False
            For Each child As SmartTreeViewNode In node.Nodes
                ClearSelectedRecursive(child)
            Next
        End Sub

        Private Sub NormalizeRadioCheckedState()
            Dim foundCheckedNode As Boolean = False
            For Each node As SmartTreeViewNode In _nodes
                NormalizeRadioCheckedStateRecursive(node, foundCheckedNode)
            Next
        End Sub

        Private Sub NormalizeRadioCheckedStateRecursive(node As SmartTreeViewNode, ByRef foundCheckedNode As Boolean)
            If node.Checked Then
                If foundCheckedNode Then
                    node.Checked = False
                Else
                    foundCheckedNode = True
                End If
            End If
            For Each child As SmartTreeViewNode In node.Nodes
                NormalizeRadioCheckedStateRecursive(child, foundCheckedNode)
            Next
        End Sub

        Private Function FindSelectedNode(node As SmartTreeViewNode) As SmartTreeViewNode
            If node.Selected Then
                Return node
            End If
            For Each child As SmartTreeViewNode In node.Nodes
                Dim selected As SmartTreeViewNode = FindSelectedNode(child)
                If selected IsNot Nothing Then
                    Return selected
                End If
            Next
            Return Nothing
        End Function
    End Class
End Namespace