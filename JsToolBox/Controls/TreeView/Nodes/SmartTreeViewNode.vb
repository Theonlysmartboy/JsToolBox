Imports System.ComponentModel

Namespace Controls.TreeView.Nodes

    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class SmartTreeViewNode

        Private _parent As SmartTreeViewNode
        Private ReadOnly _nodes As SmartTreeViewNodeCollection

        Public Sub New()
            Me.Text = String.Empty
            Me.Enabled = True
            Me.Expanded = False
            Me.Checked = False
            Me.Selected = False
            _nodes = New SmartTreeViewNodeCollection(Me)
        End Sub

        Public Sub New(text As String)
            Me.New()
            If String.IsNullOrWhiteSpace(text) Then
                Throw New ArgumentException(
                    "Node text cannot be empty.",
                    NameOf(text))
            End If
            Me.Text = text
        End Sub

        ' Identity
        <Category("Data")>
        <DefaultValue(GetType(Object), Nothing)>
        Public Property Id As Object

        <Category("Data")>
        Public Property Value As Object

        <Category("Data")>
        Public Property Tag As Object

        ' Appearance
        <Category("Appearance")>
        <DefaultValue("")>
        Public Property Text As String

        ' Behavior
        <Category("Behavior")>
        <DefaultValue(False)>
        Public Property Checked As Boolean

        <Category("Behavior")>
        <DefaultValue(False)>
        Public Property Selected As Boolean

        <Category("Behavior")>
        <DefaultValue(False)>
        Public Property Expanded As Boolean

        <Category("Behavior")>
        <DefaultValue(True)>
        Public Property Enabled As Boolean

        ' Hierarchy
        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property Parent As SmartTreeViewNode
            Get
                Return _parent
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property HasParent As Boolean
            Get
                Return _parent IsNot Nothing
            End Get
        End Property

        <Category("Nodes")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public ReadOnly Property Nodes As SmartTreeViewNodeCollection
            Get
                Return _nodes
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property HasChildren As Boolean
            Get
                Return _nodes.Count > 0
            End Get
        End Property

        ' Position
        <Browsable(False)>
        Public ReadOnly Property Index As Integer
            Get
                If _parent Is Nothing Then
                    Return -1
                End If
                Return _parent.Nodes.IndexOf(Me)
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property Level As Integer
            Get
                Dim nodeLevel As Integer = 0
                Dim current As SmartTreeViewNode = _parent
                While current IsNot Nothing
                    nodeLevel += 1
                    current = current.Parent
                End While
                Return nodeLevel
            End Get
        End Property

        ' Root
        <Browsable(False)>
        Public ReadOnly Property Root As SmartTreeViewNode
            Get
                Dim current As SmartTreeViewNode = Me
                While current.Parent IsNot Nothing
                    current = current.Parent
                End While
                Return current
            End Get
        End Property

        ' Path
        <Browsable(False)>
        Public ReadOnly Property Path As String
            Get
                Dim parts As New List(Of String)
                Dim current As SmartTreeViewNode = Me
                While current IsNot Nothing
                    parts.Insert(0, current.Text)
                    current = current.Parent
                End While
                Return String.Join(" > ", parts)
            End Get
        End Property

        ' Internal
        Friend Sub SetParent(parent As SmartTreeViewNode)
            _parent = parent
        End Sub

        ' Utility
        Public Overrides Function ToString() As String
            If String.IsNullOrWhiteSpace(Text) Then
                Return "(Node)"
            End If
            Return Text
        End Function
    End Class
End Namespace