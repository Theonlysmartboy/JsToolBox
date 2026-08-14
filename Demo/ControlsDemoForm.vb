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
        customers.Id = 1
        customers.Value = "CUSTOMERS"
        Dim retail = customers.Nodes.Add("Retail Customers")
        retail.Id = 10
        retail.Value = "RETAIL"
        Dim customerA = retail.Nodes.Add("Customer A")
        customerA.Id = 101
        customerA.Value = "Customer A"
        retail.Nodes.Add("Customer B")
        retail.Nodes.Add("Customer C")
        retail.Nodes.Add("Customer D")
        retail.Nodes.Add("Customer E")
        retail.Nodes.Add("Customer F")
        retail.Nodes.Add("Customer G")
        retail.Nodes.Add("Customer H")
        retail.Nodes.Add("Customer I")
        retail.Nodes.Add("Customer J")
        retail.Nodes.Add("Customer K")
        retail.Nodes.Add("Customer L")
        retail.Nodes.Add("Customer M")
        retail.Nodes.Add("Customer N")
        retail.Nodes.Add("Customer O")
        retail.Nodes.Add("Customer P")

        Dim wholesale = customers.Nodes.Add("Wholesale Customers")
        wholesale.Nodes.Add("Customer Q")
        Dim suppliers = tree.Nodes.Add("Suppliers")
        Dim localSuppliers = suppliers.Nodes.Add("Local Suppliers")
        localSuppliers.Nodes.Add("Supplier A")
        localSuppliers.Nodes.Add("Supplier B")
        localSuppliers.Nodes.Add("Supplier C")
        localSuppliers.Nodes.Add("Supplier D")
        localSuppliers.Nodes.Add("Supplier E")
        localSuppliers.Nodes.Add("Supplier F")
        localSuppliers.Nodes.Add("Supplier G")
        localSuppliers.Nodes.Add("Supplier H")
        localSuppliers.Nodes.Add("Supplier I")
        localSuppliers.Nodes.Add("Supplier J")
        localSuppliers.Nodes.Add("Supplier K")
        localSuppliers.Nodes.Add("Supplier L")
        localSuppliers.Nodes.Add("Supplier M")
        localSuppliers.Nodes.Add("Supplier N")
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