Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base

Namespace Charts
    Public Class BarChart
        Inherits ChartBase

        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.Bar
            _chart.Series(0).ToolTip = "#VALX: #PERCENT{P2}"
            _chart.AccessibleDescription = "Bar Chart"
            _chart.AccessibleName = "Bar Chart"
            _chart.Series(0).IsXValueIndexed = True
            _chart.Series(0).IsValueShownAsLabel = True
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional: Add subtle rotation animation if desired
        End Sub
    End Class
End Namespace