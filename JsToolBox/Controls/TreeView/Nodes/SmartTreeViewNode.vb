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
            _nodes = New SmartTreeViewNodeCollection(Me)
        End Sub

        Public Sub New(text As String)
            Me.New()
            If String.IsNullOrWhiteSpace(text) Then
                Throw New ArgumentException("Node text cannot be empty.", NameOf(text))
            End If
            Me.Text = text
        End Sub

        <Category("Appearance")>
        <DefaultValue("")>
        Public Property Text As String

        <Category("Data")>
        Public Property Value As Object

        <Category("Data")>
        Public Property Tag As Object

        <Category("Behavior")>
        <DefaultValue(False)>
        Public Property Checked As Boolean

        <Category("Behavior")>
        <DefaultValue(False)>
        Public Property Expanded As Boolean

        <Category("Behavior")>
        <DefaultValue(True)>
        Public Property Enabled As Boolean

        <Browsable(False)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property Parent As SmartTreeViewNode
            Get
                Return _parent
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

        Friend Sub SetParent(parent As SmartTreeViewNode)
            _parent = parent
        End Sub

        Public Overrides Function ToString() As String
            If String.IsNullOrWhiteSpace(Text) Then
                Return "(Node)"
            End If
            Return Text
        End Function
    End Class
End Namespace