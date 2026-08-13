Imports System.Drawing

Namespace Controls.TreeView

    Friend Class SmartTreeViewHitTestInfo
        Public Property Node As Nodes.SmartTreeViewNode
        Public Property GlyphBounds As Rectangle
        Public Property NodeBounds As Rectangle
        Public Property Level As Integer
    End Class
End Namespace