Imports MySql.Data.MySqlClient

Public Class UserPermissionRepository

    Private ReadOnly _connectionString As String

    Public Sub New(connectionString As String)
        If String.IsNullOrWhiteSpace(connectionString) Then
            Throw New ArgumentException("Database connection string cannot be empty.",
                NameOf(connectionString))
        End If
        _connectionString = connectionString
    End Sub

    Public Function GetUsers() As DataTable
        Const sql As String = "SELECT id, " &
            "name, username, email " &
            "FROM users ORDER BY name;"
        Return ExecuteDataTable(sql)
    End Function

    Public Function GetRolesForUser(userId As Long) As DataTable
        Const sql As String = "SELECT r.id, r.name " &
            "FROM roles r INNER JOIN model_has_roles mhr " &
            "ON mhr.role_id = r.id WHERE mhr.model_id = @userId " &
            "AND mhr.model_type = 'App\Models\User' ORDER BY r.name;"
        Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@userId", MySqlDbType.UInt64) With {
                .Value = userId
            }
        }
        Return ExecuteDataTable(sql, parameters)
    End Function


    Public Function GetAllPermissions() As DataTable
        Const sql As String = "SELECT id, name, guard_name " &
            "FROM permissions WHERE guard_name = 'web' " &
            "ORDER BY name;"
        Return ExecuteDataTable(sql)
    End Function

    Public Function GetDirectPermissionIds(userId As Long) As HashSet(Of Long)
        Const sql As String = "SELECT permission_id FROM " &
            "model_has_permissions WHERE model_id = @userId " &
            "AND model_type = 'App\Models\User';"
        Return ExecuteIdSet(sql, New MySqlParameter("@userId", MySqlDbType.UInt64) With {
                .Value = userId
            })
    End Function

    Public Function GetRolePermissionIds(userId As Long) As HashSet(Of Long)
        Const sql As String = "SELECT DISTINCT rhp.permission_id " &
            "FROM role_has_permissions rhp INNER JOIN model_has_roles mhr " &
            "ON mhr.role_id = rhp.role_id WHERE mhr.model_id = @userId " &
            "AND mhr.model_type = 'App\Models\User';"
        Return ExecuteIdSet(sql, New MySqlParameter("@userId", MySqlDbType.UInt64) With {
                .Value = userId
            })
    End Function

    Public Function GetEffectivePermissionIds(userId As Long) As HashSet(Of Long)
        Dim effectivePermissions As New HashSet(Of Long)
        Dim directPermissions = GetDirectPermissionIds(userId)
        Dim rolePermissions = GetRolePermissionIds(userId)
        effectivePermissions.UnionWith(directPermissions)
        effectivePermissions.UnionWith(rolePermissions)
        Return effectivePermissions
    End Function

    Private Function ExecuteDataTable(sql As String, Optional parameters As List(Of MySqlParameter) = Nothing
    ) As DataTable
        Dim table As New DataTable()
        Using connection As New MySqlConnection(_connectionString)
            Using command As New MySqlCommand(sql, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters.ToArray())
                End If
                Using adapter As New MySqlDataAdapter(command)
                    connection.Open()
                    adapter.Fill(table)
                End Using
            End Using
        End Using
        Return table
    End Function


    Private Function ExecuteIdSet(sql As String, ParamArray parameters() As MySqlParameter) As HashSet(Of Long)
        Dim result As New HashSet(Of Long)
        Using connection As New MySqlConnection(_connectionString)
            Using command As New MySqlCommand(sql, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) Then
                            result.Add(Convert.ToInt64(reader.GetValue(0)))
                        End If
                    End While
                End Using
            End Using
        End Using
        Return result
    End Function
End Class