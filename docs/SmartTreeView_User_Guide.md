# SmartTreeView User Guide

## 1. Introduction

SmartTreeView is a custom WinForms tree control that provides a lightweight, fully-managed alternative to the built-in `TreeView` with richer node metadata and flexible checkbox/radio indicator modes. It focuses on clarity, designer usability, and a small API surface useful for business applications.

It solves problems such as: simpler node identity (`Id`, `Value`, `Tag`), predictable checkbox propagation, easy traversal/search APIs, and a straightforward rendering model without depending on heavy native wrappers.

What makes it different from the standard WinForms `TreeView`:
- Simple, explicit node identity and application-data fields (`Id`, `Value`, `Tag`).
- Built-in checkbox and radio-button indicator modes with parent/child propagation and partial states.
- Lightweight custom painting designed for reliability and easy customization.

## 2. Requirements

- .NET Framework 4.8 or later
- Windows Forms (WinForms)
- Visual Studio (any recent edition that supports VB.NET WinForms)

## 3. Installing the DLL

1. Add a project reference to `JsToolBox.dll` (the compiled library produced by this package).
2. In Visual Studio, right-click References &rarr; Add Reference &rarr; Browse &rarr; select `JsToolBox.dll`.
3. Import namespace where needed: `Imports JsToolBox.Controls.TreeView`
4. To add the control programmatically, simply create an instance of `SmartTreeView` and add it to a form's `Controls` collection.

To add to the Toolbox, right-click the Toolbox &rarr; Choose Items &rarr; Browse &rarr; select `JsToolBox.dll`.

## 4. Your First SmartTreeView

Example:

Dim tree As New SmartTreeView()

tree.Location = New Point(10, 10)
tree.Size = New Size(300, 250)

Dim customers = tree.Nodes.Add("Customers")
Dim retail = customers.Nodes.Add("Retail Customers")
retail.Nodes.Add("Customer A")
retail.Nodes.Add("Customer B")

Me.Controls.Add(tree)

Explanation:
- Create the control and set basic layout properties.
- `Nodes.Add` returns a `SmartTreeViewNode` so you can continue building the hierarchy.

## 5. Understanding Nodes

`SmartTreeViewNode` represents a single node. Important properties:
- `Parent` - immediate parent node (Nothing for root nodes)
- `GrandParent` - parent's parent, or Nothing
- `Root` - the top-most ancestor
- `Ancestors` - list of ancestors
- `Descendants` - list of all descendant nodes
- `Level` - depth (root = 0)
- `Index` - index within parent's `Nodes` collection
- `IsRoot`, `IsLeaf`, `HasChildren`

Examples are shown throughout this guide.

## 6. Node Identity and Data

`SmartTreeViewNode` exposes three fields for application data:

- `Id` (Object): Stable identifier. Use this for database primary keys or other permanent identifiers.
- `Value` (Object): Application-specific object or domain value associated with the node.
- `Tag` (Object): Arbitrary metadata useful for UI state or temporary values.

Use `Id` for identity lookups, `Value` for attaching domain objects, and `Tag` for ad-hoc metadata.

## 7. Creating Hierarchical Data

Example building a company tree:

Dim root = tree.Nodes.Add("Company")
Dim customers = root.Nodes.Add("Customers")
customers.Nodes.Add("Retail")
customers.Nodes.Add("Wholesale")

## 8. Searching Nodes

- `FindNodeById(id)` - returns the first node whose `Id` equals `id`.
- `FindNodeByValue(value)` - returns the first node whose `Value` equals `value`.
- `FindByTag(tag)` - returns a list of nodes with matching `Tag`.
- `FindByText(text)` - returns the first node with matching `Text` (case-insensitive).

## 9. Retrieving Nodes

- `GetAllNodes()` - enumerates every node in the tree.
- `GetCheckedNodes()` / `GetUncheckedNodes()`
- `GetCheckedLeafNodes()` - checked nodes that are leaves.
- `GetEnabledNodes()` / `GetDisabledNodes()`
- `GetSelectedNodes()`
- `GetGrandParentNodes()`
- `GetLeafNodes()`
- `GetNodesByLevel(level)`

## 10. Checkbox Mode

Set `CheckMode = SmartTreeViewCheckMode.CheckBox` to show checkboxes. Checking a parent propagates to children; parents reflect partial or full checked states based on descendants.

## 11. Radio Button Mode

Set `CheckMode = SmartTreeViewCheckMode.RadioButton`. Only one node may be checked at a time; setting a node checks it and clears others.

## 12. Indicator Modes

`SmartTreeViewCheckMode` controls whether indicators are shown. `SmartTreeViewIndicatorPosition` controls whether the indicator is rendered before or after the text.

## 13. Selection

`SelectedNode` returns the currently selected node (first selected). The control raises `NodeSelected` when selection changes.

## 14. Enabling and Disabling Nodes

Use `EnableNode`, `DisableNode`, or `SetNodeEnabled(node, enabled, includeChildren)` to control enabled state. Passing `includeChildren = True` will propagate to descendants.

## 15. Expansion and Collapse

Use `node.Expanded = True` or `False` to expand/collapse. The control supports expand/collapse via the glyph and programmatically.

## 16. Appearance Customization

The control exposes appearance properties such as `ParentNodeBackColor`, `GrandParentNodeBackColor`, `SelectedNodeBackColor`, `SelectedNodeForeColor`, `NodeDividerColor`, `ShowNodeDividers`, `NodeHeight`, `IndicatorSize`, `IndicatorGap`, `TextLeftGap`, and `IndicatorPosition`.

## 17. Events

Public events:
- `NodeSelected` - raised when a node is selected. EventArgs: `SmartTreeViewNodeEventArgs` with property `Node`.

## 18. Working with Database Records

Example:

Dim customerNode = retail.Nodes.Add(customer.Name)
customerNode.Id = customer.Id
customerNode.Value = customer
customerNode.Tag = "Customer"

## 19. Working with Large Trees

Use `GetAllNodes()` and careful traversal. The control paints all visible nodes and calculates content height; it is not virtualized.

## 20. Error Handling and Null Safety

APIs return Nothing when not found. Check for Nothing before referencing `Parent`, `Root`, or `SelectedNode`.

## 21. Advanced Usage

The node model is compatible with LINQ: `GetAllNodes().Where(Function(n) ...)`.

## 22. API Reference

See the source for full signatures. Major types:
- `SmartTreeView` (control)
- `SmartTreeViewNode` (node)
- `SmartTreeViewNodeCollection` (node collection)
- Enums: `SmartTreeViewCheckMode`, `SmartTreeViewCheckState`, `SmartTreeViewIndicatorPosition`
- `SmartTreeViewNodeEventArgs`

## 23. Complete Example

See section 4 and other examples above; combine them to create a real application.

## 24. Troubleshooting

- Ensure the `JsToolBox.dll` is referenced and the `JsToolBox.Controls.TreeView` namespace imported.
- If the control does not appear, ensure size and location are set and the form's `Controls.Add(tree)` was called.





