Namespace Helpers.Db
    Public Class DatabaseHelper
        Public Shared Function GetConnectionString() As String
            Dim server = "localhost"
            Dim user = "root"
            Dim pass = ""
            Dim dbName = "arifex"

            ' Build connection string
            Return $"server={server};user id={user};password={pass};database={dbName};"
        End Function
    End Class
End Namespace