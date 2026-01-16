Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base

Namespace Charts
    Public Class FastLineChart
        Inherits ChartBase
        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.FastLine
            _chart.Series(0).IsValueShownAsLabel = True
            _chart.AccessibleDescription = "Fast Line Chart"
            _chart.AccessibleName = "Fast Line Chart"
            _chart.Series(0).BorderWidth = 2
        End Sub
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional: Add subtle rotation animation if desired
        End Sub
    End Class
End Namespace