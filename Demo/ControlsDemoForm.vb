Imports JsToolBox.Controls.TreeView

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
        suppliers.Nodes.Add("Local Suppliers")
        suppliers.Nodes.Add("International Suppliers")
        Dim customerA = retail.Nodes(0)
        Debug.WriteLine(customerA.Text)
        Debug.WriteLine(customerA.Parent.Text)
        Debug.WriteLine(customerA.Parent.Parent.Text)
        tree.Location = New Point(610, 100)
        tree.Size = New Size(350, 300)
        Controls.Add(tree)
    End Sub
End Class