Imports JsToolBox.Controls.TreeView
Imports JsToolBox.Controls.TreeView.Enums

Public Class ControlsDemoForm

    Private Sub ControlsDemoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tree As New SmartTreeView()
        Dim customers = tree.Nodes.Add("Customers")
        customers.Expanded = True
        Dim retail = customers.Nodes.Add("Retail Customers")
        retail.Expanded = True
        retail.Nodes.Add("Customer A")
        retail.Nodes.Add("Customer B")
        Dim wholesale = customers.Nodes.Add("Wholesale Customers")
        wholesale.Nodes.Add("Customer C")
        Dim suppliers = tree.Nodes.Add("Suppliers")
        Dim localSuppliers = suppliers.Nodes.Add("Local Suppliers")
        localSuppliers.Nodes.Add("Local Supplier A")
        suppliers.Nodes.Add("International Suppliers")
        Dim customerA = retail.Nodes(0)
        tree.Location = New Point(610, 100)
        tree.Size = New Size(350, 300)
        tree.ParentNodeBackColor = Color.LightYellow
        tree.GrandParentNodeBackColor = Color.LightBlue
        tree.ShowNodeDividers = True
        tree.CheckMode = SmartTreeViewCheckMode.CheckBox
        Controls.Add(tree)
    End Sub
End Class