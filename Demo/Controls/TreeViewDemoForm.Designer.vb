<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TreeViewDemoForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbUsers = New System.Windows.Forms.ComboBox()
        Me.lblPermissions = New System.Windows.Forms.Label()
        Me.lblAssignedRoles = New System.Windows.Forms.Label()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.stvPermissions = New JsToolBox.Controls.TreeView.SmartTreeView()
        Me.SuspendLayout()
        '
        'cmbUsers
        '
        Me.cmbUsers.FormattingEnabled = True
        Me.cmbUsers.Location = New System.Drawing.Point(12, 12)
        Me.cmbUsers.Name = "cmbUsers"
        Me.cmbUsers.Size = New System.Drawing.Size(250, 21)
        Me.cmbUsers.TabIndex = 1
        '
        'lblPermissions
        '
        Me.lblPermissions.AutoSize = True
        Me.lblPermissions.Location = New System.Drawing.Point(9, 44)
        Me.lblPermissions.Name = "lblPermissions"
        Me.lblPermissions.Size = New System.Drawing.Size(39, 13)
        Me.lblPermissions.TabIndex = 2
        Me.lblPermissions.Text = "Label1"
        '
        'lblAssignedRoles
        '
        Me.lblAssignedRoles.AutoSize = True
        Me.lblAssignedRoles.Location = New System.Drawing.Point(9, 57)
        Me.lblAssignedRoles.Name = "lblAssignedRoles"
        Me.lblAssignedRoles.Size = New System.Drawing.Size(39, 13)
        Me.lblAssignedRoles.TabIndex = 3
        Me.lblAssignedRoles.Text = "Label2"
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(12, 84)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(250, 300)
        Me.txtDetails.TabIndex = 4
        '
        'stvPermissions
        '
        Me.stvPermissions.BackColor = System.Drawing.Color.White
        Me.stvPermissions.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.stvPermissions.ForeColor = System.Drawing.Color.Black
        Me.stvPermissions.GrandParentNodeBackColor = System.Drawing.Color.LightBlue
        Me.stvPermissions.Location = New System.Drawing.Point(388, 12)
        Me.stvPermissions.Name = "stvPermissions"
        Me.stvPermissions.ParentNodeBackColor = System.Drawing.Color.MediumAquamarine
        Me.stvPermissions.SelectedNodeBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.stvPermissions.SelectedNodeForeColor = System.Drawing.Color.White
        Me.stvPermissions.Size = New System.Drawing.Size(400, 515)
        Me.stvPermissions.TabIndex = 0
        Me.stvPermissions.Text = "SmartTreeView1"
        '
        'TreeViewDemoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 561)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.lblAssignedRoles)
        Me.Controls.Add(Me.lblPermissions)
        Me.Controls.Add(Me.cmbUsers)
        Me.Controls.Add(Me.stvPermissions)
        Me.Name = "TreeViewDemoForm"
        Me.Text = "TreeViewDemo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stvPermissions As JsToolBox.Controls.TreeView.SmartTreeView
    Friend WithEvents cmbUsers As ComboBox
    Friend WithEvents lblPermissions As Label
    Friend WithEvents lblAssignedRoles As Label
    Friend WithEvents txtDetails As TextBox
End Class
