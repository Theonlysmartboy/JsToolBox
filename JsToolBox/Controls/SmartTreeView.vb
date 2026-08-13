Imports System.Drawing
Imports System.Windows.Forms
Imports JsToolBox.Controls.TreeView.Nodes

Namespace Controls.TreeView

    Public Class SmartTreeView
        Inherits Control

        Private ReadOnly _nodes As SmartTreeViewNodeCollection

        Public Sub New()
            _nodes = New SmartTreeViewNodeCollection(Nothing)
            Me.SetStyle(ControlStyles.UserPaint Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer Or
                ControlStyles.ResizeRedraw, True)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
        End Sub

        Public ReadOnly Property Nodes As SmartTreeViewNodeCollection
            Get
                Return _nodes
            End Get
        End Property
    End Class
End Namespace
