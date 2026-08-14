Namespace Controls.TreeView.Enums

    ''' <summary>
    ''' Represents the effective checkbox state of a tree node.
    ''' </summary>
    Public Enum SmartTreeViewCheckState

        ''' <summary>
        ''' The node and all of its descendants are unchecked.
        ''' </summary>
        Unchecked

        ''' <summary>
        ''' The node and/or its descendants are partially checked.
        ''' </summary>
        [Partial]

        ''' <summary>
        ''' The node and all of its descendants are checked.
        ''' </summary>
        Checked

    End Enum

End Namespace