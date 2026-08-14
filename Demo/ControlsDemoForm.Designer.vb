<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlsDemoForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim SmartTreeViewNode1 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode2 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode3 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode4 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode5 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode6 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode7 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode8 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode9 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode10 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode11 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode12 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode13 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode14 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Me.SmartTreeView2 = New JsToolBox.Controls.TreeView.SmartTreeView()
        Me.SmartTreeView1 = New JsToolBox.Controls.TreeView.SmartTreeView()
        Me.SmartTextBox4 = New JsToolBox.Controls.SmartTextBox()
        Me.SmartTextBox3 = New JsToolBox.Controls.SmartTextBox()
        Me.SmartTextBox2 = New JsToolBox.Controls.SmartTextBox()
        Me.SmartTextBox1 = New JsToolBox.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SmartTreeView2
        '
        Me.SmartTreeView2.BackColor = System.Drawing.Color.White
        Me.SmartTreeView2.CheckMode = JsToolBox.Controls.TreeView.Enums.SmartTreeViewCheckMode.None
        Me.SmartTreeView2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SmartTreeView2.ForeColor = System.Drawing.Color.Black
        Me.SmartTreeView2.GrandParentNodeBackColor = System.Drawing.Color.Yellow
        Me.SmartTreeView2.Location = New System.Drawing.Point(182, 316)
        Me.SmartTreeView2.Name = "SmartTreeView2"
        Me.SmartTreeView2.NodeDividerColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SmartTreeView2.NodeHeight = 25
        SmartTreeViewNode1.Expanded = True
        SmartTreeViewNode3.Tag = Nothing
        SmartTreeViewNode3.Text = "View Users"
        SmartTreeViewNode3.Value = Nothing
        SmartTreeViewNode4.Tag = Nothing
        SmartTreeViewNode4.Text = "View accounts"
        SmartTreeViewNode4.Value = Nothing
        SmartTreeViewNode2.Nodes.Add(SmartTreeViewNode3)
        SmartTreeViewNode2.Nodes.Add(SmartTreeViewNode4)
        SmartTreeViewNode2.Tag = Nothing
        SmartTreeViewNode2.Text = "Admin"
        SmartTreeViewNode2.Value = Nothing
        SmartTreeViewNode6.Tag = Nothing
        SmartTreeViewNode6.Text = "View acounts"
        SmartTreeViewNode6.Value = Nothing
        SmartTreeViewNode7.Tag = Nothing
        SmartTreeViewNode7.Text = "Create Reports"
        SmartTreeViewNode7.Value = Nothing
        SmartTreeViewNode5.Nodes.Add(SmartTreeViewNode6)
        SmartTreeViewNode5.Nodes.Add(SmartTreeViewNode7)
        SmartTreeViewNode5.Tag = Nothing
        SmartTreeViewNode5.Text = "Accountant"
        SmartTreeViewNode5.Value = Nothing
        SmartTreeViewNode1.Nodes.Add(SmartTreeViewNode2)
        SmartTreeViewNode1.Nodes.Add(SmartTreeViewNode5)
        SmartTreeViewNode1.Tag = Nothing
        SmartTreeViewNode1.Text = "Roles and permissions"
        SmartTreeViewNode1.Value = Nothing
        Me.SmartTreeView2.Nodes.Add(SmartTreeViewNode1)
        Me.SmartTreeView2.ParentNodeBackColor = System.Drawing.Color.Teal
        Me.SmartTreeView2.ShowNodeDividers = True
        Me.SmartTreeView2.Size = New System.Drawing.Size(200, 220)
        Me.SmartTreeView2.TabIndex = 5
        Me.SmartTreeView2.Text = "Roles and permissions"
        '
        'SmartTreeView1
        '
        Me.SmartTreeView1.BackColor = System.Drawing.Color.White
        Me.SmartTreeView1.CheckMode = JsToolBox.Controls.TreeView.Enums.SmartTreeViewCheckMode.RadioButton
        Me.SmartTreeView1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SmartTreeView1.ForeColor = System.Drawing.Color.Black
        Me.SmartTreeView1.GrandParentNodeBackColor = System.Drawing.Color.LightYellow
        Me.SmartTreeView1.Location = New System.Drawing.Point(182, 28)
        Me.SmartTreeView1.Name = "SmartTreeView1"
        Me.SmartTreeView1.NodeDividerColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SmartTreeView1.NodeHeight = 25
        SmartTreeViewNode8.Expanded = True
        SmartTreeViewNode10.Tag = Nothing
        SmartTreeViewNode10.Text = "View Users"
        SmartTreeViewNode10.Value = Nothing
        SmartTreeViewNode11.Tag = Nothing
        SmartTreeViewNode11.Text = "View accounts"
        SmartTreeViewNode11.Value = Nothing
        SmartTreeViewNode9.Nodes.Add(SmartTreeViewNode10)
        SmartTreeViewNode9.Nodes.Add(SmartTreeViewNode11)
        SmartTreeViewNode9.Tag = Nothing
        SmartTreeViewNode9.Text = "Admin"
        SmartTreeViewNode9.Value = Nothing
        SmartTreeViewNode13.Tag = Nothing
        SmartTreeViewNode13.Text = "View acounts"
        SmartTreeViewNode13.Value = Nothing
        SmartTreeViewNode14.Tag = Nothing
        SmartTreeViewNode14.Text = "Create Reports"
        SmartTreeViewNode14.Value = Nothing
        SmartTreeViewNode12.Nodes.Add(SmartTreeViewNode13)
        SmartTreeViewNode12.Nodes.Add(SmartTreeViewNode14)
        SmartTreeViewNode12.Tag = Nothing
        SmartTreeViewNode12.Text = "Accountant"
        SmartTreeViewNode12.Value = Nothing
        SmartTreeViewNode8.Nodes.Add(SmartTreeViewNode9)
        SmartTreeViewNode8.Nodes.Add(SmartTreeViewNode12)
        SmartTreeViewNode8.Tag = Nothing
        SmartTreeViewNode8.Text = "Roles and permissions"
        SmartTreeViewNode8.Value = Nothing
        Me.SmartTreeView1.Nodes.Add(SmartTreeViewNode8)
        Me.SmartTreeView1.ParentNodeBackColor = System.Drawing.Color.LightBlue
        Me.SmartTreeView1.ShowNodeDividers = True
        Me.SmartTreeView1.Size = New System.Drawing.Size(200, 220)
        Me.SmartTreeView1.TabIndex = 4
        Me.SmartTreeView1.Text = "Roles and permissions"
        '
        'SmartTextBox4
        '
        Me.SmartTextBox4.BorderColor = System.Drawing.Color.DarkGray
        Me.SmartTextBox4.BorderColorError = System.Drawing.Color.Red
        Me.SmartTextBox4.BorderErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox4.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SmartTextBox4.CornerRadius = 8
        Me.SmartTextBox4.ErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox4.ErrorMessage = ""
        Me.SmartTextBox4.FloatingLabelActiveColor = System.Drawing.Color.DodgerBlue
        Me.SmartTextBox4.FloatingLabelColor = System.Drawing.Color.Gray
        Me.SmartTextBox4.FloatingSpeed = 10.0!
        Me.SmartTextBox4.HasError = False
        Me.SmartTextBox4.LabelText = "Password"
        Me.SmartTextBox4.LeftIcon = Nothing
        Me.SmartTextBox4.Location = New System.Drawing.Point(12, 204)
        Me.SmartTextBox4.Name = "SmartTextBox4"
        Me.SmartTextBox4.PlaceholderText = ""
        Me.SmartTextBox4.Size = New System.Drawing.Size(150, 52)
        Me.SmartTextBox4.SmartType = JsToolBox.Controls.SmartTextBox.SmartInputType.Password
        Me.SmartTextBox4.TabIndex = 3
        Me.SmartTextBox4.TextColor = System.Drawing.Color.Black
        '
        'SmartTextBox3
        '
        Me.SmartTextBox3.BorderColor = System.Drawing.Color.DarkGray
        Me.SmartTextBox3.BorderColorError = System.Drawing.Color.Red
        Me.SmartTextBox3.BorderErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox3.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SmartTextBox3.CornerRadius = 8
        Me.SmartTextBox3.ErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox3.ErrorMessage = ""
        Me.SmartTextBox3.FloatingLabelActiveColor = System.Drawing.Color.DodgerBlue
        Me.SmartTextBox3.FloatingLabelColor = System.Drawing.Color.Gray
        Me.SmartTextBox3.FloatingSpeed = 10.0!
        Me.SmartTextBox3.HasError = False
        Me.SmartTextBox3.LabelText = "Phone"
        Me.SmartTextBox3.LeftIcon = Nothing
        Me.SmartTextBox3.Location = New System.Drawing.Point(12, 146)
        Me.SmartTextBox3.Name = "SmartTextBox3"
        Me.SmartTextBox3.PlaceholderText = ""
        Me.SmartTextBox3.Size = New System.Drawing.Size(150, 52)
        Me.SmartTextBox3.SmartType = JsToolBox.Controls.SmartTextBox.SmartInputType.Phone
        Me.SmartTextBox3.TabIndex = 2
        Me.SmartTextBox3.TextColor = System.Drawing.Color.Black
        '
        'SmartTextBox2
        '
        Me.SmartTextBox2.BorderColor = System.Drawing.Color.DarkGray
        Me.SmartTextBox2.BorderColorError = System.Drawing.Color.Red
        Me.SmartTextBox2.BorderErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox2.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SmartTextBox2.CornerRadius = 8
        Me.SmartTextBox2.ErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox2.ErrorMessage = ""
        Me.SmartTextBox2.FloatingLabelActiveColor = System.Drawing.Color.DodgerBlue
        Me.SmartTextBox2.FloatingLabelColor = System.Drawing.Color.Gray
        Me.SmartTextBox2.FloatingSpeed = 10.0!
        Me.SmartTextBox2.HasError = False
        Me.SmartTextBox2.LabelText = "Email"
        Me.SmartTextBox2.LeftIcon = Nothing
        Me.SmartTextBox2.Location = New System.Drawing.Point(12, 88)
        Me.SmartTextBox2.Name = "SmartTextBox2"
        Me.SmartTextBox2.PlaceholderText = ""
        Me.SmartTextBox2.Size = New System.Drawing.Size(150, 52)
        Me.SmartTextBox2.SmartType = JsToolBox.Controls.SmartTextBox.SmartInputType.Email
        Me.SmartTextBox2.TabIndex = 1
        Me.SmartTextBox2.TextColor = System.Drawing.Color.Black
        '
        'SmartTextBox1
        '
        Me.SmartTextBox1.BorderColor = System.Drawing.Color.DarkGray
        Me.SmartTextBox1.BorderColorError = System.Drawing.Color.Red
        Me.SmartTextBox1.BorderErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SmartTextBox1.CornerRadius = 8
        Me.SmartTextBox1.ErrorColor = System.Drawing.Color.Red
        Me.SmartTextBox1.ErrorMessage = ""
        Me.SmartTextBox1.FloatingLabelActiveColor = System.Drawing.Color.DodgerBlue
        Me.SmartTextBox1.FloatingLabelColor = System.Drawing.Color.Gray
        Me.SmartTextBox1.FloatingSpeed = 10.0!
        Me.SmartTextBox1.HasError = False
        Me.SmartTextBox1.LabelText = "Name"
        Me.SmartTextBox1.LeftIcon = Nothing
        Me.SmartTextBox1.Location = New System.Drawing.Point(12, 12)
        Me.SmartTextBox1.Name = "SmartTextBox1"
        Me.SmartTextBox1.PlaceholderText = ""
        Me.SmartTextBox1.Size = New System.Drawing.Size(150, 52)
        Me.SmartTextBox1.SmartType = JsToolBox.Controls.SmartTextBox.SmartInputType.Text
        Me.SmartTextBox1.TabIndex = 0
        Me.SmartTextBox1.TextColor = System.Drawing.Color.Black
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Designer added no checkboxes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Designer added with Radio button"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(476, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Programatically added with Check Boxes"
        '
        'ControlsDemoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 551)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SmartTreeView2)
        Me.Controls.Add(Me.SmartTreeView1)
        Me.Controls.Add(Me.SmartTextBox4)
        Me.Controls.Add(Me.SmartTextBox3)
        Me.Controls.Add(Me.SmartTextBox2)
        Me.Controls.Add(Me.SmartTextBox1)
        Me.Name = "ControlsDemoForm"
        Me.Text = "Controls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SmartTextBox1 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTextBox2 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTextBox3 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTextBox4 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTreeView1 As JsToolBox.Controls.TreeView.SmartTreeView
    Friend WithEvents SmartTreeView2 As JsToolBox.Controls.TreeView.SmartTreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
