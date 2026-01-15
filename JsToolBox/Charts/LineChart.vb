Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base

Namespace Charts
    Public Class LineChart
        Inherits ChartBase
        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.Line
            _chart.Series(0).IsValueShownAsLabel = True
            _chart.Series(0).BorderWidth = 2
        End Sub
        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional: Add subtle rotation animation if desired
        End Sub
    End Class
End Namespace