Imports JsToolBox.Controls.TreeView
Imports JsToolBox.Controls.TreeView.Enums

Public Class ControlsDemoForm

    Private Sub ControlsDemoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tree As New SmartTreeView()
        tree.CheckMode = SmartTreeViewCheckMode.CheckBox
        tree.IndicatorPosition = SmartTreeViewIndicatorPosition.AfterText
        tree.ParentNodeBackColor = Color.AliceBlue
        tree.GrandParentNodeBackColor = Color.LightYellow
        tree.ShowNodeDividers = True
        Dim customers = tree.Nodes.Add("Customers")
        Dim retail = customers.Nodes.Add("Retail Customers")
        retail.Nodes.Add("Customer A")
        retail.Nodes.Add("Customer B")
        Dim wholesale = customers.Nodes.Add("Wholesale Customers")
        wholesale.Nodes.Add("Customer C")
        Dim suppliers = tree.Nodes.Add("Suppliers")
        Dim localSuppliers = suppliers.Nodes.Add("Local Suppliers")
        localSuppliers.Nodes.Add("Supplier A")
        suppliers.Nodes.Add("International Suppliers")
        customers.Expanded = True
        retail.Expanded = True
        wholesale.Expanded = True
        suppliers.Expanded = True
        tree.Location = New Point(413, 28)
        tree.Size = New Size(350, 300)
        Controls.Add(tree)
    End Sub
End Class