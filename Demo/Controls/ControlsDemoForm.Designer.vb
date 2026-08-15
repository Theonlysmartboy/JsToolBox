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
        Me.SmartTextBox4 = New JsToolBox.Controls.SmartTextBox()
        Me.SmartTextBox3 = New JsToolBox.Controls.SmartTextBox()
        Me.SmartTextBox2 = New JsToolBox.Controls.SmartTextBox()
        Me.SmartTextBox1 = New JsToolBox.Controls.SmartTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTestOutput = New System.Windows.Forms.TextBox()
        Me.btnTestLeaves = New System.Windows.Forms.Button()
        Me.btnTestLevels = New System.Windows.Forms.Button()
        Me.btnTestCheckedLeaves = New System.Windows.Forms.Button()
        Me.btnTestSelected = New System.Windows.Forms.Button()
        Me.btnTestDisabled = New System.Windows.Forms.Button()
        Me.btnTestEnabled = New System.Windows.Forms.Button()
        Me.btnTestUnchecked = New System.Windows.Forms.Button()
        Me.btnTestChecked = New System.Windows.Forms.Button()
        Me.btnTestFindByText = New System.Windows.Forms.Button()
        Me.btnTestFindById = New System.Windows.Forms.Button()
        Me.btnEnableChildren = New System.Windows.Forms.Button()
        Me.btnDisableChildren = New System.Windows.Forms.Button()
        Me.btnEnableRetail = New System.Windows.Forms.Button()
        Me.btnDisableRetail = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Programatically added with Check Boxes"
        '
        'txtTestOutput
        '
        Me.txtTestOutput.Location = New System.Drawing.Point(12, 262)
        Me.txtTestOutput.Multiline = True
        Me.txtTestOutput.Name = "txtTestOutput"
        Me.txtTestOutput.Size = New System.Drawing.Size(382, 287)
        Me.txtTestOutput.TabIndex = 9
        '
        'btnTestLeaves
        '
        Me.btnTestLeaves.Location = New System.Drawing.Point(284, 111)
        Me.btnTestLeaves.Name = "btnTestLeaves"
        Me.btnTestLeaves.Size = New System.Drawing.Size(110, 30)
        Me.btnTestLeaves.TabIndex = 11
        Me.btnTestLeaves.Text = "Leaves"
        Me.btnTestLeaves.UseVisualStyleBackColor = True
        '
        'btnTestLevels
        '
        Me.btnTestLevels.Location = New System.Drawing.Point(284, 147)
        Me.btnTestLevels.Name = "btnTestLevels"
        Me.btnTestLevels.Size = New System.Drawing.Size(110, 30)
        Me.btnTestLevels.TabIndex = 12
        Me.btnTestLevels.Text = "Levels"
        Me.btnTestLevels.UseVisualStyleBackColor = True
        '
        'btnTestCheckedLeaves
        '
        Me.btnTestCheckedLeaves.Location = New System.Drawing.Point(168, 146)
        Me.btnTestCheckedLeaves.Name = "btnTestCheckedLeaves"
        Me.btnTestCheckedLeaves.Size = New System.Drawing.Size(110, 30)
        Me.btnTestCheckedLeaves.TabIndex = 13
        Me.btnTestCheckedLeaves.Text = "Checked Leaves"
        Me.btnTestCheckedLeaves.UseVisualStyleBackColor = True
        '
        'btnTestSelected
        '
        Me.btnTestSelected.Location = New System.Drawing.Point(168, 111)
        Me.btnTestSelected.Name = "btnTestSelected"
        Me.btnTestSelected.Size = New System.Drawing.Size(110, 30)
        Me.btnTestSelected.TabIndex = 14
        Me.btnTestSelected.Text = "Selected"
        Me.btnTestSelected.UseVisualStyleBackColor = True
        '
        'btnTestDisabled
        '
        Me.btnTestDisabled.Location = New System.Drawing.Point(284, 75)
        Me.btnTestDisabled.Name = "btnTestDisabled"
        Me.btnTestDisabled.Size = New System.Drawing.Size(110, 30)
        Me.btnTestDisabled.TabIndex = 15
        Me.btnTestDisabled.Text = "Disabled"
        Me.btnTestDisabled.UseVisualStyleBackColor = True
        '
        'btnTestEnabled
        '
        Me.btnTestEnabled.Location = New System.Drawing.Point(168, 75)
        Me.btnTestEnabled.Name = "btnTestEnabled"
        Me.btnTestEnabled.Size = New System.Drawing.Size(110, 30)
        Me.btnTestEnabled.TabIndex = 16
        Me.btnTestEnabled.Text = "Enabled"
        Me.btnTestEnabled.UseVisualStyleBackColor = True
        '
        'btnTestUnchecked
        '
        Me.btnTestUnchecked.Location = New System.Drawing.Point(284, 39)
        Me.btnTestUnchecked.Name = "btnTestUnchecked"
        Me.btnTestUnchecked.Size = New System.Drawing.Size(110, 30)
        Me.btnTestUnchecked.TabIndex = 17
        Me.btnTestUnchecked.Text = "Unchecked"
        Me.btnTestUnchecked.UseVisualStyleBackColor = True
        '
        'btnTestChecked
        '
        Me.btnTestChecked.Location = New System.Drawing.Point(168, 39)
        Me.btnTestChecked.Name = "btnTestChecked"
        Me.btnTestChecked.Size = New System.Drawing.Size(110, 30)
        Me.btnTestChecked.TabIndex = 18
        Me.btnTestChecked.Text = "Checked"
        Me.btnTestChecked.UseVisualStyleBackColor = True
        '
        'btnTestFindByText
        '
        Me.btnTestFindByText.Location = New System.Drawing.Point(284, 3)
        Me.btnTestFindByText.Name = "btnTestFindByText"
        Me.btnTestFindByText.Size = New System.Drawing.Size(110, 30)
        Me.btnTestFindByText.TabIndex = 19
        Me.btnTestFindByText.Text = "Find By Text"
        Me.btnTestFindByText.UseVisualStyleBackColor = True
        '
        'btnTestFindById
        '
        Me.btnTestFindById.Location = New System.Drawing.Point(168, 3)
        Me.btnTestFindById.Name = "btnTestFindById"
        Me.btnTestFindById.Size = New System.Drawing.Size(110, 30)
        Me.btnTestFindById.TabIndex = 20
        Me.btnTestFindById.Text = "Find By Id"
        Me.btnTestFindById.UseVisualStyleBackColor = True
        '
        'btnEnableChildren
        '
        Me.btnEnableChildren.Location = New System.Drawing.Point(284, 219)
        Me.btnEnableChildren.Name = "btnEnableChildren"
        Me.btnEnableChildren.Size = New System.Drawing.Size(110, 30)
        Me.btnEnableChildren.TabIndex = 21
        Me.btnEnableChildren.Text = "Enable Children"
        Me.btnEnableChildren.UseVisualStyleBackColor = True
        '
        'btnDisableChildren
        '
        Me.btnDisableChildren.Location = New System.Drawing.Point(168, 218)
        Me.btnDisableChildren.Name = "btnDisableChildren"
        Me.btnDisableChildren.Size = New System.Drawing.Size(110, 30)
        Me.btnDisableChildren.TabIndex = 22
        Me.btnDisableChildren.Text = "Disable Children"
        Me.btnDisableChildren.UseVisualStyleBackColor = True
        '
        'btnEnableRetail
        '
        Me.btnEnableRetail.Location = New System.Drawing.Point(284, 183)
        Me.btnEnableRetail.Name = "btnEnableRetail"
        Me.btnEnableRetail.Size = New System.Drawing.Size(110, 30)
        Me.btnEnableRetail.TabIndex = 23
        Me.btnEnableRetail.Text = "Enable Retail"
        Me.btnEnableRetail.UseVisualStyleBackColor = True
        '
        'btnDisableRetail
        '
        Me.btnDisableRetail.Location = New System.Drawing.Point(168, 182)
        Me.btnDisableRetail.Name = "btnDisableRetail"
        Me.btnDisableRetail.Size = New System.Drawing.Size(110, 30)
        Me.btnDisableRetail.TabIndex = 24
        Me.btnDisableRetail.Text = "Disable Retail"
        Me.btnDisableRetail.UseVisualStyleBackColor = True
        '
        'ControlsDemoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 551)
        Me.Controls.Add(Me.btnDisableRetail)
        Me.Controls.Add(Me.btnEnableRetail)
        Me.Controls.Add(Me.btnDisableChildren)
        Me.Controls.Add(Me.btnEnableChildren)
        Me.Controls.Add(Me.btnTestFindById)
        Me.Controls.Add(Me.btnTestFindByText)
        Me.Controls.Add(Me.btnTestChecked)
        Me.Controls.Add(Me.btnTestUnchecked)
        Me.Controls.Add(Me.btnTestEnabled)
        Me.Controls.Add(Me.btnTestDisabled)
        Me.Controls.Add(Me.btnTestSelected)
        Me.Controls.Add(Me.btnTestCheckedLeaves)
        Me.Controls.Add(Me.btnTestLevels)
        Me.Controls.Add(Me.btnTestLeaves)
        Me.Controls.Add(Me.txtTestOutput)
        Me.Controls.Add(Me.Label3)
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
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTestOutput As TextBox
    Friend WithEvents btnTestLeaves As Button
    Friend WithEvents btnTestLevels As Button
    Friend WithEvents btnTestCheckedLeaves As Button
    Friend WithEvents btnTestSelected As Button
    Friend WithEvents btnTestDisabled As Button
    Friend WithEvents btnTestEnabled As Button
    Friend WithEvents btnTestUnchecked As Button
    Friend WithEvents btnTestChecked As Button
    Friend WithEvents btnTestFindByText As Button
    Friend WithEvents btnTestFindById As Button
    Friend WithEvents btnEnableChildren As Button
    Friend WithEvents btnDisableChildren As Button
    Friend WithEvents btnEnableRetail As Button
    Friend WithEvents btnDisableRetail As Button
End Class
