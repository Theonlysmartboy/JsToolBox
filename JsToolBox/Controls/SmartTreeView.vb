Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
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
            Me.IndicatorSize = 12
            Me.IndicatorGap = 6
            Me.TextLeftGap = 6
            IndicatorPosition = SmartTreeViewIndicatorPosition.AfterText
            ParentNodeBackColor = Color.Empty
            GrandParentNodeBackColor = Color.Empty
            ShowNodeDividers = False
            NodeDividerColor = Color.Empty
        End Sub

        ' Appearance
        <Category("Appearance")>
        <DefaultValue(SmartTreeViewIndicatorPosition.AfterText)>
        Public Property IndicatorPosition As SmartTreeViewIndicatorPosition

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property ParentNodeBackColor As Color

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property GrandParentNodeBackColor As Color

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property NodeDividerColor As Color

        <Category("Appearance")>
        <DefaultValue(False)>
        Public Property ShowNodeDividers As Boolean

        <Category("Appearance")>
        <DefaultValue(24)>
        Public Property NodeHeight As Integer

        <Category("Appearance")>
        <DefaultValue(14)>
        Public Property IndicatorSize As Integer

        <Category("Appearance")>
        <DefaultValue(6)>
        Public Property IndicatorGap As Integer

        <Category("Appearance")>
        <DefaultValue(6)>
        Public Property TextLeftGap As Integer

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
            Dim nodeBounds As New Rectangle(0, currentY, Width, NodeHeight)            ' Hierarchy background
            Dim backgroundColor As Color = GetNodeBackgroundColor(node)
            If backgroundColor <> Color.Empty Then
                Using backgroundBrush As New SolidBrush(backgroundColor)
                    graphics.FillRectangle(backgroundBrush, nodeBounds)
                End Using
            End If
            ' Expand / Collapse glyph
            ' This ALWAYS remains before the text.
            Dim glyphRect As Rectangle = Rectangle.Empty
            If node.HasChildren Then
                glyphRect = New Rectangle(x, currentY + (NodeHeight - GlyphSize) \ 2, GlyphSize, GlyphSize)
            End If
            ' Determine text position
            Dim textStartX As Integer = x + GlyphSize + TextLeftGap
            Dim textY As Integer = currentY + (NodeHeight - Font.Height) \ 2
            ' Measure text
            Dim textSize As SizeF = graphics.MeasureString(node.Text, Font)
            Dim textBounds As New Rectangle(textStartX, currentY, CInt(Math.Ceiling(textSize.Width)), NodeHeight)
            ' Indicator
            Dim indicatorBounds As Rectangle = Rectangle.Empty
            If CheckMode <> SmartTreeViewCheckMode.None Then
                Dim indicatorY As Integer = currentY + (NodeHeight - IndicatorSize) \ 2
                If IndicatorPosition = SmartTreeViewIndicatorPosition.BeforeText Then
                    indicatorBounds = New Rectangle(textStartX, indicatorY, IndicatorSize, IndicatorSize)
                    textStartX = indicatorBounds.Right + IndicatorGap
                    textBounds = New Rectangle(textStartX, currentY, CInt(Math.Ceiling(textSize.Width)), NodeHeight)
                Else
                    indicatorBounds = New Rectangle(textBounds.Right + IndicatorGap, indicatorY, IndicatorSize, IndicatorSize)
                End If
            End If
            ' Store hit-test information
            _hitTestItems.Add(New SmartTreeViewHitTestInfo With {
                .Node = node,
                .GlyphBounds = glyphRect,
                .IndicatorBounds = indicatorBounds,
                .TextBounds = textBounds,
                .NodeBounds = nodeBounds,
                .Level = level
            })
            ' Draw expand/collapse glyph
            DrawExpandGlyph(graphics, node, x, currentY)
            ' Draw node text
            Dim textColor As Color = If(node.Enabled, ForeColor, Color.Gray)
            Using textBrush As New SolidBrush(textColor)
                graphics.DrawString(node.Text, Font, textBrush, textStartX, textY)
            End Using
            ' Draw checkbox / radio button
            If CheckMode <> SmartTreeViewCheckMode.None Then
                DrawIndicator(graphics, node, indicatorBounds)
            End If
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

        Private Sub DrawIndicator(graphics As Graphics, node As SmartTreeViewNode, bounds As Rectangle)
            If bounds = Rectangle.Empty Then
                Return
            End If
            Dim borderColor As Color
            Dim fillColor As Color
            If node.Enabled Then
                borderColor = Color.Gray
                fillColor = Color.White
            Else
                borderColor = Color.LightGray
                fillColor = Color.Gainsboro
            End If
            Select Case CheckMode
                Case SmartTreeViewCheckMode.CheckBox
                    DrawCheckBoxIndicator(graphics, node, bounds, borderColor, fillColor)
                Case SmartTreeViewCheckMode.RadioButton
                    DrawRadioButtonIndicator(graphics, node, bounds, borderColor, fillColor)
            End Select
        End Sub

        Private Sub DrawCheckBoxIndicator(graphics As Graphics, node As SmartTreeViewNode,
                                          bounds As Rectangle, borderColor As Color, fillColor As Color)
            Using fillBrush As New SolidBrush(fillColor)
                graphics.FillRectangle(fillBrush, bounds)
            End Using
            Using borderPen As New Pen(borderColor, 1)
                graphics.DrawRectangle(borderPen, bounds)
            End Using
            If Not node.Checked Then
                Return
            End If
            Dim checkColor As Color = If(node.Enabled, Color.Black, Color.Gray)
            Using checkPen As New Pen(checkColor, 2)
                checkPen.StartCap = LineCap.Round
                checkPen.EndCap = LineCap.Round
                checkPen.LineJoin = LineJoin.Round
                Dim x1 As Integer = bounds.Left + 3
                Dim y1 As Integer = bounds.Top + bounds.Height \ 2
                Dim x2 As Integer = bounds.Left + bounds.Width \ 2 - 1
                Dim y2 As Integer = bounds.Bottom - 4
                Dim x3 As Integer = bounds.Right - 3
                Dim y3 As Integer = bounds.Top + 3
                graphics.DrawLines(checkPen, {
                    New Point(x1, y1),
                    New Point(x2, y2),
                    New Point(x3, y3)
                })
            End Using
        End Sub

        Private Sub DrawRadioButtonIndicator(graphics As Graphics, node As SmartTreeViewNode,
                                             bounds As Rectangle, borderColor As Color, fillColor As Color)
            Using fillBrush As New SolidBrush(fillColor)
                graphics.FillEllipse(fillBrush, bounds)
            End Using
            Using borderPen As New Pen(borderColor, 1)
                graphics.DrawEllipse(borderPen, bounds)
            End Using
            If Not node.Checked Then
                Return
            End If
            Dim innerSize As Integer = Math.Max(4, bounds.Width - 7)
            Dim innerX As Integer = bounds.Left + (bounds.Width - innerSize) \ 2
            Dim innerY As Integer = bounds.Top + (bounds.Height - innerSize) \ 2
            Dim innerBounds As New Rectangle(innerX, innerY, innerSize, innerSize)
            Dim fillColorInner As Color = If(node.Enabled, Color.Black, Color.Gray)
            Using innerBrush As New SolidBrush(fillColorInner)
                graphics.FillEllipse(innerBrush, innerBounds)
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
                ' The expand/collapse glyph always has priority.
                If item.GlyphBounds.Contains(e.Location) Then
                    If item.Node.HasChildren AndAlso item.Node.Enabled Then
                        item.Node.Expanded = Not item.Node.Expanded
                        Invalidate()
                    End If
                    Return
                End If
                ' Checkbox / Radio Button
                ' This changes Checked only without changing Selected.
                If CheckMode <> SmartTreeViewCheckMode.None AndAlso item.IndicatorBounds.Contains(e.Location) Then
                    If item.Node.Enabled Then
                        CheckNode(item.Node)
                    End If
                    Return
                End If
                ' Node text
                ' This changes Selected only.
                ' It does NOT change Checked.
                If item.TextBounds.Contains(e.Location) Then
                    If item.Node.Enabled Then
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
            ClearSelectedNodes()
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