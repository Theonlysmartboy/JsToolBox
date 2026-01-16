Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base
Namespace Charts
    Public Class DoughNutChart
        Inherits ChartBase

        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.Doughnut
            ' Optionaly show labels outside the slices
            _chart.Series(0)("PieLabelStyle") = "Outside"
            _chart.Series(0).IsValueShownAsLabel = True
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional: Add subtle rotation animation if desired
        End Sub
    End Class
End Namespace