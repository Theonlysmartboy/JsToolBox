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
        Dim SmartTreeViewNode15 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode16 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode17 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode18 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode19 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode20 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode21 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode22 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode23 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode24 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode25 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode26 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode27 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
        Dim SmartTreeViewNode28 As JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode = New JsToolBox.Controls.TreeView.Nodes.SmartTreeViewNode()
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
        Me.SmartTreeView2.IndicatorSize = 10
        Me.SmartTreeView2.Location = New System.Drawing.Point(182, 316)
        Me.SmartTreeView2.Name = "SmartTreeView2"
        Me.SmartTreeView2.NodeDividerColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SmartTreeView2.NodeHeight = 25
        SmartTreeViewNode15.Expanded = True
        SmartTreeViewNode17.Tag = Nothing
        SmartTreeViewNode17.Text = "View Users"
        SmartTreeViewNode17.Value = Nothing
        SmartTreeViewNode18.Tag = Nothing
        SmartTreeViewNode18.Text = "View accounts"
        SmartTreeViewNode18.Value = Nothing
        SmartTreeViewNode16.Nodes.Add(SmartTreeViewNode17)
        SmartTreeViewNode16.Nodes.Add(SmartTreeViewNode18)
        SmartTreeViewNode16.Tag = Nothing
        SmartTreeViewNode16.Text = "Admin"
        SmartTreeViewNode16.Value = Nothing
        SmartTreeViewNode20.Tag = Nothing
        SmartTreeViewNode20.Text = "View acounts"
        SmartTreeViewNode20.Value = Nothing
        SmartTreeViewNode21.Tag = Nothing
        SmartTreeViewNode21.Text = "Create Reports"
        SmartTreeViewNode21.Value = Nothing
        SmartTreeViewNode19.Nodes.Add(SmartTreeViewNode20)
        SmartTreeViewNode19.Nodes.Add(SmartTreeViewNode21)
        SmartTreeViewNode19.Tag = Nothing
        SmartTreeViewNode19.Text = "Accountant"
        SmartTreeViewNode19.Value = Nothing
        SmartTreeViewNode15.Nodes.Add(SmartTreeViewNode16)
        SmartTreeViewNode15.Nodes.Add(SmartTreeViewNode19)
        SmartTreeViewNode15.Tag = Nothing
        SmartTreeViewNode15.Text = "Roles and permissions"
        SmartTreeViewNode15.Value = Nothing
        Me.SmartTreeView2.Nodes.Add(SmartTreeViewNode15)
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
        Me.SmartTreeView1.GrandParentNodeBackColor = System.Drawing.Color.Yellow
        Me.SmartTreeView1.IndicatorSize = 10
        Me.SmartTreeView1.Location = New System.Drawing.Point(182, 28)
        Me.SmartTreeView1.Name = "SmartTreeView1"
        Me.SmartTreeView1.NodeDividerColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SmartTreeView1.NodeHeight = 25
        SmartTreeViewNode22.Expanded = True
        SmartTreeViewNode24.Tag = Nothing
        SmartTreeViewNode24.Text = "View Users"
        SmartTreeViewNode24.Value = Nothing
        SmartTreeViewNode25.Tag = Nothing
        SmartTreeViewNode25.Text = "View accounts"
        SmartTreeViewNode25.Value = Nothing
        SmartTreeViewNode23.Nodes.Add(SmartTreeViewNode24)
        SmartTreeViewNode23.Nodes.Add(SmartTreeViewNode25)
        SmartTreeViewNode23.Tag = Nothing
        SmartTreeViewNode23.Text = "Admin"
        SmartTreeViewNode23.Value = Nothing
        SmartTreeViewNode27.Tag = Nothing
        SmartTreeViewNode27.Text = "View acounts"
        SmartTreeViewNode27.Value = Nothing
        SmartTreeViewNode28.Tag = Nothing
        SmartTreeViewNode28.Text = "Create Reports"
        SmartTreeViewNode28.Value = Nothing
        SmartTreeViewNode26.Nodes.Add(SmartTreeViewNode27)
        SmartTreeViewNode26.Nodes.Add(SmartTreeViewNode28)
        SmartTreeViewNode26.Tag = Nothing
        SmartTreeViewNode26.Text = "Accountant"
        SmartTreeViewNode26.Value = Nothing
        SmartTreeViewNode22.Nodes.Add(SmartTreeViewNode23)
        SmartTreeViewNode22.Nodes.Add(SmartTreeViewNode26)
        SmartTreeViewNode22.Tag = Nothing
        SmartTreeViewNode22.Text = "Roles and permissions"
        SmartTreeViewNode22.Value = Nothing
        Me.SmartTreeView1.Nodes.Add(SmartTreeViewNode22)
        Me.SmartTreeView1.ParentNodeBackColor = System.Drawing.Color.Teal
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
