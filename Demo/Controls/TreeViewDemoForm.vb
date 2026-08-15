Imports Demo.Helpers.Db
Imports JsToolBox.Controls.TreeView.Enums
Imports JsToolBox.Controls.TreeView.Nodes
Imports JsToolBox.Controls.TreeView.SmartTreeView

Public Class TreeViewDemoForm

    Private _repository As UserPermissionRepository
    Private _loadingUser As Boolean = False
    Private _currentUserId As Long?

    Private Sub UserPermissionsDemoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeTree()
        Dim connectionString = DatabaseHelper.GetConnectionString()
        If String.IsNullOrWhiteSpace(connectionString) Then
            MessageBox.Show("Database connection settings are not available.",
                            "Database", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            _repository = New UserPermissionRepository(connectionString)
            LoadUsers()
        Catch ex As Exception
            MessageBox.Show("Unable to initialize the user permission demo." &
                Environment.NewLine & Environment.NewLine &
                ex.Message, "Database Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeTree()
        stvPermissions.CheckMode = SmartTreeViewCheckMode.CheckBox
        stvPermissions.IndicatorPosition = SmartTreeViewIndicatorPosition.AfterText
        stvPermissions.ParentNodeBackColor = Color.LightBlue
        stvPermissions.GrandParentNodeBackColor = Color.LightYellow
        stvPermissions.ShowNodeDividers = True
        stvPermissions.NodeDividerColor = Color.LightGray
        AddHandler stvPermissions.NodeSelected, AddressOf Tree_NodeSelected
    End Sub

    Private Sub LoadUsers()
        _loadingUser = True
        Try
            Dim users As DataTable = _repository.GetUsers()
            cmbUsers.DataSource = Nothing
            cmbUsers.DisplayMember = "name"
            cmbUsers.ValueMember = "id"
            cmbUsers.DataSource = users
            If users.Rows.Count > 0 Then
                cmbUsers.SelectedIndex = 0
            End If
        Finally
            _loadingUser = False
        End Try
        If cmbUsers.SelectedValue IsNot Nothing Then
            Dim userId As Long
            If Long.TryParse(cmbUsers.SelectedValue.ToString(), userId) Then
                LoadUserPermissions(userId)
            End If
        End If
    End Sub

    Private Sub cmbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsers.SelectedIndexChanged
        If _loadingUser Then
            Return
        End If
        If cmbUsers.SelectedValue Is Nothing Then
            Return
        End If
        Dim userId As Long
        If Not Long.TryParse(cmbUsers.SelectedValue.ToString(), userId) Then
            Return
        End If
        LoadUserPermissions(userId)
    End Sub


    Private Sub LoadUserPermissions(userId As Long)
        If _repository Is Nothing Then
            Return
        End If
        Try
            _currentUserId = userId
            Dim roles As DataTable = _repository.GetRolesForUser(userId)
            Dim permissions As DataTable = _repository.GetAllPermissions()
            Dim effectivePermissionIds As HashSet(Of Long) = _repository.GetEffectivePermissionIds(userId)
            BuildPermissionTree(permissions, effectivePermissionIds)
            DisplayUserRoles(roles)
            lblPermissions.Text = "Permissions: " & effectivePermissionIds.Count.ToString()
        Catch ex As Exception
            MessageBox.Show("Unable to load user permissions." &
            Environment.NewLine & Environment.NewLine &
            ex.Message, "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuildPermissionTree(permissions As DataTable, checkedPermissionIds As HashSet(Of Long))
        stvPermissions.BeginUpdate()
        Try
            stvPermissions.Nodes.Clear()
            Dim modules As New Dictionary(Of String,
                SmartTreeViewNode)(StringComparer.OrdinalIgnoreCase)
            For Each row As DataRow In permissions.Rows
                Dim permissionId As Long = Convert.ToInt64(row("id"))
                Dim permissionName As String = row("name").ToString().Trim()
                If String.IsNullOrWhiteSpace(permissionName) Then
                    Continue For
                End If
                Dim moduleName As String
                Dim actionName As String
                SplitPermissionName(permissionName, moduleName, actionName)
                Dim moduleNode As SmartTreeViewNode = Nothing
                If Not modules.TryGetValue(moduleName, moduleNode) Then
                    moduleNode = stvPermissions.Nodes.Add(moduleName)
                    moduleNode.Value = moduleName
                    moduleNode.Tag = "MODULE"
                    moduleNode.Expanded = True
                    modules.Add(moduleName, moduleNode)
                End If
                Dim permissionNode = moduleNode.Nodes.Add(actionName)
                permissionNode.Id = permissionId
                permissionNode.Value = permissionName
                permissionNode.Tag = "PERMISSION"
                permissionNode.Checked = checkedPermissionIds.Contains(permissionId)
            Next
        Finally
            stvPermissions.EndUpdate()
        End Try
    End Sub

    Private Sub SplitPermissionName(permissionName As String, ByRef moduleName As String,
                                    ByRef actionName As String)
        Dim separatorIndex As Integer = permissionName.IndexOf(" "c)
        If separatorIndex <= 0 Then
            moduleName = "Other"
            actionName = permissionName
            Return
        End If
        Dim action As String = permissionName.Substring(0, separatorIndex).Trim()
        Dim resource As String = permissionName.Substring(separatorIndex + 1).Trim()
        If String.IsNullOrWhiteSpace(resource) Then
            moduleName = "Other"
            actionName = permissionName
            Return
        End If
        moduleName = ToTitleCase(resource)
        actionName = ToTitleCase(action)
    End Sub

    Private Function ToTitleCase(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then
            Return value
        End If
        Dim parts = value.Split({" "c, "-"c, "_"c},
                                StringSplitOptions.RemoveEmptyEntries)
        Dim result As New List(Of String)
        For Each part In parts
            If part.Length = 1 Then
                result.Add(part.ToUpperInvariant())
            Else
                result.Add(Char.ToUpperInvariant(part(0)) &
                    part.Substring(1).ToLowerInvariant())
            End If
        Next
        Return String.Join(" ", result)
    End Function

    Private Sub DisplayUserRoles(roles As DataTable)
        If roles.Rows.Count = 0 Then
            lblAssignedRoles.Text = "Roles: None"
            Return
        End If
        Dim roleNames As New List(Of String)
        For Each row As DataRow In roles.Rows
            roleNames.Add(row("name").ToString())
        Next
        lblAssignedRoles.Text = "Roles: " & String.Join(", ", roleNames)
    End Sub

    Private Sub Tree_NodeSelected(sender As Object, e As SmartTreeViewNodeEventArgs)
        If e.Node Is Nothing Then
            Return
        End If
        ShowSelectedNode(e.Node)
    End Sub

    Private Sub ShowSelectedNode(node As SmartTreeViewNode)
        txtDetails.Clear()
        txtDetails.AppendText("SELECTED NODE" & Environment.NewLine)
        txtDetails.AppendText("=============" & Environment.NewLine)
        txtDetails.AppendText($"Text: {node.Text}" & Environment.NewLine)
        txtDetails.AppendText($"Id: {node.Id}" & Environment.NewLine)
        txtDetails.AppendText($"Value: {node.Value}" & Environment.NewLine)
        txtDetails.AppendText($"Tag: {node.Tag}" & Environment.NewLine)
        txtDetails.AppendText($"Checked: {node.Checked}" & Environment.NewLine)
        txtDetails.AppendText($"Selected: {node.Selected}" & Environment.NewLine)
        txtDetails.AppendText($"Level: {node.Level}" & Environment.NewLine)
    End Sub
End Class