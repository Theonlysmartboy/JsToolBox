<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoaderDemoForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ChartsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GaugeChart1 = New JsToolBox.Charts.GaugeChart()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChartsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ChartsToolStripMenuItem
        '
        Me.ChartsToolStripMenuItem.Name = "ChartsToolStripMenuItem"
        Me.ChartsToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ChartsToolStripMenuItem.Text = "Charts"
        '
        'GaugeChart1
        '
        Me.GaugeChart1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
        Me.GaugeChart1.GradientEnd = System.Drawing.Color.DimGray
        Me.GaugeChart1.GradientStart = System.Drawing.Color.LightGray
        Me.GaugeChart1.Location = New System.Drawing.Point(203, 38)
        Me.GaugeChart1.Maximum = 100
        Me.GaugeChart1.Minimum = 0
        Me.GaugeChart1.Name = "GaugeChart1"
        Me.GaugeChart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel
        Me.GaugeChart1.Size = New System.Drawing.Size(400, 200)
        Me.GaugeChart1.TabIndex = 1
        Me.GaugeChart1.Title = ""
        Me.GaugeChart1.Value = 50
        Me.GaugeChart1.ZoneGreen = 40
        Me.GaugeChart1.ZoneRed = 100
        Me.GaugeChart1.ZoneYellow = 70
        '
        'LoaderDemoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GaugeChart1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "LoaderDemoForm"
        Me.Text = "Loader Demo Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ChartsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GaugeChart1 As JsToolBox.Charts.GaugeChart
End Class
