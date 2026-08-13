Imports System.ComponentModel

Namespace Controls.TreeView.Nodes

    <ListBindable(False)>
    Public Class SmartTreeViewNodeCollection
        Inherits List(Of SmartTreeViewNode)

        Private ReadOnly _owner As SmartTreeViewNode

        Friend Sub New(owner As SmartTreeViewNode)
            _owner = owner
        End Sub

        Public Shadows Function Add(text As String) As SmartTreeViewNode
            If String.IsNullOrWhiteSpace(text) Then
                Throw New ArgumentException("Node text cannot be empty.", NameOf(text))
            End If
            Dim node As New SmartTreeViewNode(text)
            AddNode(node)
            Return node
        End Function

        Public Shadows Sub Add(node As SmartTreeViewNode)
            If node Is Nothing Then
                Throw New ArgumentNullException(NameOf(node))
            End If
            AddNode(node)
        End Sub

        Private Sub AddNode(node As SmartTreeViewNode)
            node.SetParent(_owner)
            MyBase.Add(node)
        End Sub

        Public Shadows Function Insert(index As Integer, text As String) As SmartTreeViewNode
            If String.IsNullOrWhiteSpace(text) Then
                Throw New ArgumentException("Node text cannot be empty.", NameOf(text))
            End If
            Dim node As New SmartTreeViewNode(text)
            node.SetParent(_owner)
            MyBase.Insert(index, node)
            Return node
        End Function

        Public Overrides Function ToString() As String
            Return $"Count = {Count}"
        End Function
    End Class
End Namespace