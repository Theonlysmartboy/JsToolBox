Namespace Controls.TreeView.Nodes

    Public Class SmartTreeViewNode
        Private _parent As SmartTreeViewNode
        Private ReadOnly _nodes As SmartTreeViewNodeCollection

        Public Sub New(text As String)
            If String.IsNullOrWhiteSpace(text) Then
                Throw New ArgumentException("Node text cannot be empty.", NameOf(text))
            End If
            Me.Text = text
            Me.Enabled = True
            Me.Expanded = False
            Me.Checked = False
            _nodes = New SmartTreeViewNodeCollection(Me)
        End Sub

        Public Property Text As String
        Public Property Value As Object
        Public Property Tag As Object
        Public Property Checked As Boolean
        Public Property Expanded As Boolean
        Public Property Enabled As Boolean

        Public ReadOnly Property Parent As SmartTreeViewNode
            Get
                Return _parent
            End Get
        End Property

        Public ReadOnly Property Nodes As SmartTreeViewNodeCollection
            Get
                Return _nodes
            End Get
        End Property

        Public ReadOnly Property HasChildren As Boolean
            Get
                Return _nodes.Count > 0
            End Get
        End Property

        Friend Sub SetParent(parent As SmartTreeViewNode)
            _parent = parent
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class
End Namespace
