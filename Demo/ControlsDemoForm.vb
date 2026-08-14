Imports JsToolBox.Controls.TreeView
Imports JsToolBox.Controls.TreeView.Enums
Imports JsToolBox.Controls.TreeView.Nodes
Imports JsToolBox.Controls.TreeView.SmartTreeView

Public Class ControlsDemoForm
    Private _tree As SmartTreeView

    Private Sub ControlsDemoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _tree = New SmartTreeView()
        _tree.CheckMode = SmartTreeViewCheckMode.CheckBox
        _tree.IndicatorPosition = SmartTreeViewIndicatorPosition.AfterText
        _tree.ParentNodeBackColor = Color.LightBlue
        _tree.GrandParentNodeBackColor = Color.LightYellow
        _tree.ShowNodeDividers = True
        Dim customers = _tree.Nodes.Add("Customers")
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
        Dim suppliers = _tree.Nodes.Add("Suppliers")
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
        _tree.Location = New Point(395, 28)
        _tree.Size = New Size(350, 480)
        Controls.Add(_tree)
        'AddHandler _tree.MouseDown, AddressOf Tree_MouseDown
        AddHandler _tree.NodeSelected, AddressOf Tree_NodeSelected
    End Sub

    Private Sub WriteOutput(text As String)
        txtTestOutput.AppendText(text & Environment.NewLine)
    End Sub

    Private Sub ClearOutput()
        txtTestOutput.Clear()
    End Sub

    Private Sub btnTestFindById_Click(sender As Object, e As EventArgs) Handles btnTestFindById.Click
        ClearOutput()
        Dim node = _tree.FindNodeById(101)
        If node Is Nothing Then
            WriteOutput("Node with ID 101 was NOT found.")
            Return
        End If
        WriteOutput("FindNodeById(101)")
        WriteOutput("-------------------")
        WriteOutput($"Text: {node.Text}")
        WriteOutput($"Id: {node.Id}")
        WriteOutput($"Value: {node.Value}")
        WriteOutput($"Index: {node.Index}")
        WriteOutput($"Level: {node.Level}")
    End Sub

    Private Sub btnTestFindByText_Click(sender As Object, e As EventArgs) Handles btnTestFindByText.Click
        ClearOutput()
        Dim node = _tree.FindByText("Supplier A")
        If node Is Nothing Then
            WriteOutput("Supplier A was NOT found.")
            Return
        End If
        WriteOutput("FindByText(""Supplier A"")")
        WriteOutput("-------------------------")
        WriteOutput($"Text: {node.Text}")
        WriteOutput($"Id: {node.Id}")
        WriteOutput($"Value: {node.Value}")
        WriteOutput($"Index: {node.Index}")
        WriteOutput($"Level: {node.Level}")
    End Sub

    Private Sub btnTestChecked_Click(sender As Object, e As EventArgs) Handles btnTestChecked.Click
        ClearOutput()
        Dim nodes = _tree.GetCheckedNodes()
        WriteOutput($"Checked nodes: {nodes.Count}")
        WriteOutput("-------------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Level={node.Level}")
        Next
    End Sub

    Private Sub btnTestUnchecked_Click(sender As Object, e As EventArgs) Handles btnTestUnchecked.Click
        ClearOutput()
        Dim nodes = _tree.GetUncheckedNodes()
        WriteOutput($"Unchecked nodes: {nodes.Count}")
        WriteOutput("---------------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Level={node.Level}")
        Next
    End Sub

    Private Sub btnTestEnabled_Click(sender As Object, e As EventArgs) Handles btnTestEnabled.Click
        ClearOutput()
        Dim nodes = _tree.GetEnabledNodes()
        WriteOutput($"Enabled nodes: {nodes.Count}")
        WriteOutput("-------------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Level={node.Level}")
        Next
    End Sub

    Private Sub btnTestDisabled_Click(sender As Object, e As EventArgs) Handles btnTestDisabled.Click
        ClearOutput()
        Dim nodes = _tree.GetDisabledNodes()
        WriteOutput($"Disabled nodes: {nodes.Count}")
        WriteOutput("--------------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Level={node.Level}")
        Next
    End Sub

    Private Sub btnTestSelected_Click(sender As Object, e As EventArgs) Handles btnTestSelected.Click
        ClearOutput()
        Dim nodes = _tree.GetSelectedNodes()
        WriteOutput($"Selected nodes: {nodes.Count}")
        WriteOutput("--------------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Level={node.Level}")
        Next
    End Sub

    Private Sub btnTestLeaves_Click(sender As Object, e As EventArgs) Handles btnTestLeaves.Click
        ClearOutput()
        Dim nodes = _tree.GetLeafNodes()
        WriteOutput($"Leaf nodes: {nodes.Count}")
        WriteOutput("----------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Index={node.Index}, Level={node.Level}")
        Next
    End Sub

    Private Sub btnTestCheckedLeaves_Click(sender As Object, e As EventArgs) Handles btnTestCheckedLeaves.Click
        ClearOutput()
        Dim nodes = _tree.GetCheckedLeafNodes()
        WriteOutput($"Checked leaf nodes: {nodes.Count}")
        WriteOutput("-----------------------------")
        For Each node In nodes
            WriteOutput($"Text={node.Text}, Id={node.Id}, Value={node.Value}")
        Next
    End Sub

    Private Sub btnTestLevels_Click(sender As Object, e As EventArgs) Handles btnTestLevels.Click
        ClearOutput()
        For level As Integer = 0 To 2
            Dim nodes = _tree.GetNodesByLevel(level)
            WriteOutput($"LEVEL {level}")
            WriteOutput($"Count: {nodes.Count}")
            WriteOutput("----------------")
            For Each node In nodes
                WriteOutput($"Text={node.Text}, Id={node.Id}")
            Next
            WriteOutput("")
        Next
    End Sub

    Private Sub btnDisableRetail_Click(sender As Object, e As EventArgs) Handles btnDisableRetail.Click
        Dim retail = _tree.FindNodeById(10)
        If retail Is Nothing Then
            Return
        End If
        _tree.DisableNode(retail)
    End Sub

    Private Sub btnEnableRetail_Click(sender As Object, e As EventArgs) Handles btnEnableRetail.Click
        Dim retail = _tree.FindNodeById(10)
        If retail Is Nothing Then
            Return
        End If
        _tree.EnableNode(retail)
    End Sub

    Private Sub btnDisableChildren_Click(sender As Object, e As EventArgs) Handles btnDisableChildren.Click
        Dim retail = _tree.FindNodeById(10)
        If retail Is Nothing Then
            Return
        End If
        _tree.SetNodeEnabled(retail, False, True)
    End Sub

    Private Sub btnEnableChildren_Click(sender As Object, e As EventArgs) Handles btnEnableChildren.Click
        Dim retail = _tree.FindNodeById(10)
        If retail Is Nothing Then
            Return
        End If
        _tree.SetNodeEnabled(retail, True, True)
    End Sub

    Private Sub Tree_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Left Then
            Return
        End If
        Dim tree = DirectCast(sender, SmartTreeView)
        Dim node = tree.SelectedNode
        If node Is Nothing Then
            Return
        End If
        ShowNodeDetails(node)
    End Sub

    Private Sub Tree_NodeSelected(sender As Object, e As SmartTreeViewNodeEventArgs)
        ShowNodeDetails(e.Node)
    End Sub

    Private Sub ShowNodeDetails(node As SmartTreeViewNode)
        ClearOutput()
        WriteOutput("NODE DETAILS")
        WriteOutput("============")
        WriteOutput($"Text: {node.Text}")
        WriteOutput($"Id: {node.Id}")
        WriteOutput($"Value: {node.Value}")
        WriteOutput($"Tag: {node.Tag}")
        WriteOutput($"Index: {node.Index}")
        WriteOutput($"Level: {node.Level}")
        WriteOutput($"Checked: {node.Checked}")
        WriteOutput($"Selected: {node.Selected}")
        WriteOutput($"Enabled: {node.Enabled}")
        WriteOutput($"Expanded: {node.Expanded}")
        WriteOutput($"IsRoot: {node.IsRoot}")
        WriteOutput($"IsLeaf: {node.IsLeaf}")
        WriteOutput($"HasChildren: {node.HasChildren}")
        If node.Parent IsNot Nothing Then
            WriteOutput($"Parent: {node.Parent.Text}")
        Else
            WriteOutput("Parent: <None>")
        End If
        If node.GrandParent IsNot Nothing Then
            WriteOutput($"GrandParent: {node.GrandParent.Text}")
        Else
            WriteOutput("GrandParent: <None>")
        End If
        If node.Root IsNot Nothing Then
            WriteOutput($"Root: {node.Root.Text}")
        End If
    End Sub
End Class