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
        Me.SmartTextBox4.Location = New System.Drawing.Point(89, 242)
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
        Me.SmartTextBox3.Location = New System.Drawing.Point(89, 184)
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
        Me.SmartTextBox2.Location = New System.Drawing.Point(89, 126)
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
        Me.SmartTextBox1.Location = New System.Drawing.Point(89, 50)
        Me.SmartTextBox1.Name = "SmartTextBox1"
        Me.SmartTextBox1.PlaceholderText = ""
        Me.SmartTextBox1.Size = New System.Drawing.Size(150, 52)
        Me.SmartTextBox1.SmartType = JsToolBox.Controls.SmartTextBox.SmartInputType.Text
        Me.SmartTextBox1.TabIndex = 0
        Me.SmartTextBox1.TextColor = System.Drawing.Color.Black
        '
        'ControlsDemoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SmartTextBox4)
        Me.Controls.Add(Me.SmartTextBox3)
        Me.Controls.Add(Me.SmartTextBox2)
        Me.Controls.Add(Me.SmartTextBox1)
        Me.Name = "ControlsDemoForm"
        Me.Text = "Controls"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SmartTextBox1 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTextBox2 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTextBox3 As JsToolBox.Controls.SmartTextBox
    Friend WithEvents SmartTextBox4 As JsToolBox.Controls.SmartTextBox
End Class
