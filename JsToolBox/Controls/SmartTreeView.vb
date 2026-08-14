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
        Private _vScrollBar As VScrollBar
        Private _scrollOffset As Integer = 0
        Private _contentHeight As Integer = 0
        Private _initializing As Boolean = True
        Private _selectedNodeBackColor As Color = Color.FromArgb(51, 153, 255)
        Private _selectedNodeForeColor As Color = Color.White

        Public Sub New()
            _nodes = New SmartTreeViewNodeCollection(Nothing)
            Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Font = New Font("Segoe UI", 9.0F)
            Me.Size = New Size(300, 250)
            Me.TabStop = True
            Me.NodeHeight = 24
            Me.IndicatorSize = 10
            Me.IndicatorGap = 6
            Me.TextLeftGap = 6
            IndicatorPosition = SmartTreeViewIndicatorPosition.AfterText
            ParentNodeBackColor = Color.Empty
            GrandParentNodeBackColor = Color.Empty
            ShowNodeDividers = False
            NodeDividerColor = Color.Empty
            SelectedNodeBackColor = Color.FromArgb(51, 153, 255)
            SelectedNodeForeColor = Color.White
            ' Create scrollbar BEFORE adding it to Controls.
            _vScrollBar = New VScrollBar()
            With _vScrollBar
                .Dock = DockStyle.Right
                .Visible = False
                .Minimum = 0
                .SmallChange = NodeHeight
                .LargeChange = 1
            End With
            AddHandler _vScrollBar.Scroll, AddressOf VScrollBar_Scroll
            Me.Controls.Add(_vScrollBar)
            _initializing = False
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
        <DefaultValue(10)>
        Public Property IndicatorSize As Integer

        <Category("Appearance")>
        <DefaultValue(6)>
        Public Property IndicatorGap As Integer

        <Category("Appearance")>
        <DefaultValue(6)>
        Public Property TextLeftGap As Integer

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property SelectedNodeBackColor As Color
            Get
                Return _selectedNodeBackColor
            End Get
            Set(value As Color)
                _selectedNodeBackColor = value
                Invalidate()
            End Set
        End Property

        <Category("Appearance")>
        <DefaultValue(GetType(Color), "")>
        Public Property SelectedNodeForeColor As Color
            Get
                Return _selectedNodeForeColor
            End Get
            Set(value As Color)
                _selectedNodeForeColor = value
                Invalidate()
            End Set
        End Property

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
            If _initializing Then
                Return
            End If
            _hitTestItems.Clear()
            Dim currentY As Integer = -_scrollOffset
            For Each node As SmartTreeViewNode In _nodes
                DrawNode(e.Graphics, node, 0, currentY)
            Next
        End Sub

        Private Sub DrawNode(graphics As Graphics, node As SmartTreeViewNode, level As Integer, ByRef currentY As Integer)
            Dim x As Integer = level * IndentWidth
            Dim nodeBounds As New Rectangle(0, currentY, Width, NodeHeight)
            ' Hierarchy background
            Dim backgroundColor As Color
            If node.Selected Then
                backgroundColor = SelectedNodeBackColor
            Else
                backgroundColor = GetNodeBackgroundColor(node, level)
            End If
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
            Dim textColor As Color
            If Not node.Enabled Then
                textColor = Color.Gray
            ElseIf node.Selected Then
                textColor = SelectedNodeForeColor
            Else
                textColor = ForeColor
            End If
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
        Private Function GetNodeBackgroundColor(node As SmartTreeViewNode, level As Integer) As Color
            Select Case level
                Case 0
                    If GrandParentNodeBackColor <> Color.Empty Then
                        Return GrandParentNodeBackColor
                    End If
                Case 1
                    If ParentNodeBackColor <> Color.Empty Then
                        Return ParentNodeBackColor
                    End If
            End Select
            Return Color.Empty
        End Function

        Private Sub UpdateScrollBar()
            If _initializing OrElse _vScrollBar Is Nothing Then
                Return
            End If
            Dim availableHeight As Integer = ClientSize.Height
            If availableHeight <= 0 Then
                _vScrollBar.Visible = False
                _scrollOffset = 0
                Return
            End If
            _contentHeight = CalculateContentHeight()
            If _contentHeight <= availableHeight Then
                _scrollOffset = 0
                _vScrollBar.Visible = False
                Return
            End If
            Dim maxScroll As Integer = Math.Max(0, _contentHeight - availableHeight)
            ' Prevent invalid scrollbar values.
            _scrollOffset = Math.Max(0, Math.Min(_scrollOffset, maxScroll))
            _vScrollBar.Minimum = 0
            ' LargeChange represents the visible portion.
            _vScrollBar.LargeChange = Math.Max(1, availableHeight)
            _vScrollBar.SmallChange = Math.Max(1, NodeHeight)
            ' WinForms scrollbar Maximum includes LargeChange.
            _vScrollBar.Maximum = maxScroll + _vScrollBar.LargeChange - 1
            Dim maximumValue As Integer =
        Math.Max(_vScrollBar.Minimum, _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
            _vScrollBar.Value = Math.Min(_scrollOffset, maximumValue)
            _vScrollBar.Visible = True
        End Sub

        Private Function CalculateContentHeight() As Integer
            Dim height As Integer = 0
            For Each node As SmartTreeViewNode In _nodes
                CalculateNodeHeight(node, height)
            Next
            Return height
        End Function

        Private Sub CalculateNodeHeight(node As SmartTreeViewNode, ByRef height As Integer)
            height += NodeHeight
            If node.Expanded AndAlso node.HasChildren Then
                For Each child As SmartTreeViewNode In node.Nodes
                    CalculateNodeHeight(child, height)
                Next
            End If
        End Sub

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

        Private Sub DrawCheckBoxIndicator(graphics As Graphics, node As SmartTreeViewNode, bounds As Rectangle,
                                          borderColor As Color, fillColor As Color)
            Using fillBrush As New SolidBrush(fillColor)
                graphics.FillRectangle(fillBrush, bounds)
            End Using
            Using borderPen As New Pen(borderColor, 1)
                graphics.DrawRectangle(borderPen, bounds)
            End Using
            Dim state As SmartTreeViewCheckState = GetCheckState(node)
            Select Case state
                Case SmartTreeViewCheckState.Checked
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
                Case SmartTreeViewCheckState.Partial
                    Dim partialColor As Color = If(node.Enabled, Color.Black, Color.Gray)
                    Dim padding As Integer = 3
                    Dim partialBounds As New Rectangle(bounds.Left + padding,
                                                bounds.Top + bounds.Height \ 2 - 1,
                                                bounds.Width - padding * 2, 2)
                    Using partialBrush As New SolidBrush(partialColor)
                        graphics.FillRectangle(partialBrush, partialBounds)
                    End Using
            End Select
        End Sub

        Private Function GetCheckState(node As SmartTreeViewNode) As SmartTreeViewCheckState
            If node Is Nothing Then
                Return SmartTreeViewCheckState.Unchecked
            End If
            ' Leaf node
            If Not node.HasChildren Then
                If node.Checked Then
                    Return SmartTreeViewCheckState.Checked
                End If
                Return SmartTreeViewCheckState.Unchecked
            End If
            Dim checkedCount As Integer = 0
            Dim partialFound As Boolean = False
            For Each child As SmartTreeViewNode In node.Nodes
                Dim childState As SmartTreeViewCheckState = GetCheckState(child)
                Select Case childState
                    Case SmartTreeViewCheckState.Checked
                        checkedCount += 1
                    Case SmartTreeViewCheckState.Partial
                        partialFound = True
                End Select
            Next
            ' Everything underneath this node is checked.
            If checkedCount = node.Nodes.Count AndAlso Not partialFound Then
                Return SmartTreeViewCheckState.Checked
            End If
            ' Nothing underneath this node is checked.
            If checkedCount = 0 AndAlso Not partialFound Then
                Return SmartTreeViewCheckState.Unchecked
            End If
            ' Some descendants are checked.
            Return SmartTreeViewCheckState.Partial
        End Function

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
                        UpdateScrollBar()
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

        Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
            MyBase.OnMouseWheel(e)
            If _initializing OrElse _vScrollBar Is Nothing OrElse Not _vScrollBar.Visible Then
                Return
            End If
            Dim maxScroll As Integer = Math.Max(0, _contentHeight - ClientSize.Height)
            Dim scrollAmount As Integer = Math.Max(1, NodeHeight * 3)
            Dim newOffset As Integer = _scrollOffset - (e.Delta \ 120) * scrollAmount
            newOffset = Math.Max(0, Math.Min(newOffset, maxScroll))
            If newOffset = _scrollOffset Then
                Return
            End If
            _scrollOffset = newOffset
            Dim maximumValue As Integer = Math.Max(_vScrollBar.Minimum, _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
            _vScrollBar.Value = Math.Min(_scrollOffset, maximumValue)
            Invalidate()
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
            EnsureNodeVisible(node)
            Invalidate()
        End Sub

        Private Sub EnsureNodeVisible(node As SmartTreeViewNode)
            Dim item As SmartTreeViewHitTestInfo = Nothing
            For Each hit As SmartTreeViewHitTestInfo In _hitTestItems
                If hit.Node Is node Then
                    item = hit
                    Exit For
                End If
            Next
            If item Is Nothing Then
                Return
            End If
            Dim visibleHeight As Integer = ClientSize.Height
            If item.NodeBounds.Top < 0 Then
                _scrollOffset += item.NodeBounds.Top
            ElseIf item.NodeBounds.Bottom > visibleHeight Then
                _scrollOffset += item.NodeBounds.Bottom - visibleHeight
            End If
            _scrollOffset = Math.Max(0, _scrollOffset)
            Dim maxScroll As Integer = Math.Max(0, _contentHeight - visibleHeight)
            _scrollOffset = Math.Min(_scrollOffset, maxScroll)
            If _vScrollBar.Visible Then
                Dim maxValue As Integer = _vScrollBar.Maximum - _vScrollBar.LargeChange + 1
                _vScrollBar.Value = Math.Min(_scrollOffset, Math.Max(0, maxValue))
            End If
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
                    Dim newCheckedState As Boolean = Not node.Checked
                    node.Checked = newCheckedState
                    ' Parent/root checked state propagates downward.
                    ApplyCheckStateToChildren(node, newCheckedState)
                    ' Recalculate ancestors.
                    UpdateParentCheckStates(node.Parent)
                Case SmartTreeViewCheckMode.RadioButton
                    ClearAllCheckedNodes()
                    node.Checked = True
            End Select
            Invalidate()
        End Sub

        Private Sub UpdateParentCheckStates(parent As SmartTreeViewNode)
            If parent Is Nothing Then
                Return
            End If
            Dim allChecked As Boolean = True
            Dim anyChecked As Boolean = False
            For Each child As SmartTreeViewNode In parent.Nodes
                Dim childState As SmartTreeViewCheckState = GetCheckState(child)
                If childState <> SmartTreeViewCheckState.Checked Then
                    allChecked = False
                End If
                If childState <> SmartTreeViewCheckState.Unchecked Then
                    anyChecked = True
                End If
            Next
            If allChecked Then
                parent.Checked = True
            ElseIf Not anyChecked Then
                parent.Checked = False
            Else
                ' The parent itself remains unchecked because
                ' Partial is an effective visual state.
                parent.Checked = False
            End If
            ' Continue toward the root.
            UpdateParentCheckStates(parent.Parent)
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

        Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs)
            If _initializing Then
                Return
            End If
            _scrollOffset = e.NewValue
            Invalidate()
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            If _initializing OrElse _vScrollBar Is Nothing Then
                Return
            End If
            UpdateScrollBar()
            Invalidate()
        End Sub

        ' Node lookup
        'Finding by Id
        Public Function FindNodeById(id As Object) As SmartTreeViewNode
            If id Is Nothing Then
                Return Nothing
            End If
            For Each node As SmartTreeViewNode In _nodes
                Dim result As SmartTreeViewNode = FindNodeByIdRecursive(node, id)
                If result IsNot Nothing Then
                    Return result
                End If
            Next
            Return Nothing
        End Function

        Private Function FindNodeByIdRecursive(node As SmartTreeViewNode, id As Object) As SmartTreeViewNode
            If node Is Nothing Then
                Return Nothing
            End If
            If node.Id IsNot Nothing AndAlso Object.Equals(node.Id, id) Then
                Return node
            End If
            For Each child As SmartTreeViewNode In node.Nodes
                Dim result As SmartTreeViewNode = FindNodeByIdRecursive(child, id)
                If result IsNot Nothing Then
                    Return result
                End If
            Next
            Return Nothing
        End Function

        'Finding by value
        Public Function FindNodeByValue(value As Object) As SmartTreeViewNode
            For Each node As SmartTreeViewNode In _nodes
                Dim result As SmartTreeViewNode = FindNodeByValueRecursive(node, value)
                If result IsNot Nothing Then
                    Return result
                End If
            Next
            Return Nothing
        End Function

        Private Function FindNodeByValueRecursive(node As SmartTreeViewNode, value As Object) As SmartTreeViewNode
            If node Is Nothing Then
                Return Nothing
            End If
            If Object.Equals(node.Value, value) Then
                Return node
            End If
            For Each child As SmartTreeViewNode In node.Nodes
                Dim result As SmartTreeViewNode = FindNodeByValueRecursive(child, value)
                If result IsNot Nothing Then
                    Return result
                End If
            Next
            Return Nothing
        End Function

        'Find by tag
        Public Function FindByTag(tag As Object) As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n)
                                           Return Object.Equals(n.Tag, tag)
                                       End Function).ToList()
        End Function

        'Find by text
        Public Function FindByText(text As String) As SmartTreeViewNode
            If String.IsNullOrWhiteSpace(text) Then
                Return Nothing
            End If
            Return GetAllNodes().FirstOrDefault(Function(n)
                                                    Return String.Equals(n.Text, text, StringComparison.OrdinalIgnoreCase)
                                                End Function)
        End Function

        'Get checked nodes
        Public Function GetCheckedNodes() As List(Of SmartTreeViewNode)
            Dim result As New List(Of SmartTreeViewNode)
            For Each node As SmartTreeViewNode In GetAllNodes()
                If node.Checked Then
                    result.Add(node)
                End If
            Next
            Return result
        End Function

        Public Function GetUncheckedNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n) Not n.Checked).ToList()
        End Function

        Public Function GetEnabledNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n) n.Enabled).ToList()
        End Function

        Public Function GetDisabledNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n) Not n.Enabled).ToList()
        End Function

        Public Function GetSelectedNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n) n.Selected).ToList()
        End Function

        Public Function GetGrandParentNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n)
                                           Return n.Nodes.Any(Function(child) child.HasChildren)
                                       End Function).ToList()
        End Function

        Public Function GetLeafNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n) n.IsLeaf).ToList()
        End Function

        'Get all nodes in the tree, including descendants
        Public Iterator Function GetAllNodes() As IEnumerable(Of SmartTreeViewNode)
            For Each node As SmartTreeViewNode In _nodes
                Yield node
                For Each descendant As SmartTreeViewNode In GetDescendants(node)
                    Yield descendant
                Next
            Next
        End Function

        Private Iterator Function GetDescendants(node As SmartTreeViewNode) As IEnumerable(Of SmartTreeViewNode)
            For Each child As SmartTreeViewNode In node.Nodes
                Yield child
                For Each descendant As SmartTreeViewNode In GetDescendants(child)
                    Yield descendant
                Next
            Next
        End Function

        'Enable and disable nodes
        Public Sub EnableNode(node As SmartTreeViewNode)
            If node Is Nothing Then
                Return
            End If
            node.Enabled = True
            Invalidate()
        End Sub

        Public Sub DisableNode(node As SmartTreeViewNode)
            If node Is Nothing Then
                Return
            End If
            node.Enabled = False
            Invalidate()
        End Sub

        Public Sub SetNodeEnabled(node As SmartTreeViewNode, enabled As Boolean, includeChildren As Boolean)
            If node Is Nothing Then
                Return
            End If
            node.Enabled = enabled
            If includeChildren Then
                For Each child As SmartTreeViewNode In node.Nodes
                    SetNodeEnabled(child, enabled, True)
                Next
            End If
            Invalidate()
        End Sub

        Public Function GetNodesByLevel(level As Integer) As List(Of SmartTreeViewNode)
            If level < 0 Then
                Return New List(Of SmartTreeViewNode)
            End If
            Return GetAllNodes().Where(Function(n) n.Level = level).ToList()
        End Function

        Public Function GetCheckedLeafNodes() As List(Of SmartTreeViewNode)
            Return GetAllNodes().Where(Function(n)
                                           Return n.Checked AndAlso n.IsLeaf
                                       End Function).ToList()
        End Function
    End Class
End Namespace