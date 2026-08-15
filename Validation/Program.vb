Imports System
Imports System.Windows.Forms
Imports JsToolBox.Controls.TreeView

Module Program
    Sub Main()
        ' The purpose of this small validation program is to ensure
        ' that the compiled JsToolBox.dll can be referenced and that
        ' the SmartTreeView type is available at compile time.

        Dim tree As SmartTreeView = Nothing
        ' Create instance to validate type resolution at compile time.
        Try
            tree = New SmartTreeView()
            Console.WriteLine("SmartTreeView type resolved successfully.")
        Catch ex As Exception
            Console.WriteLine("Failed to instantiate SmartTreeView: " & ex.Message)
        End Try
    End Sub
End Module
