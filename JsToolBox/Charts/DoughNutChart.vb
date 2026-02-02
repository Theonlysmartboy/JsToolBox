Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base
Namespace Charts
    Public Class DoughNutChart
        Inherits ChartBase

        Public Sub New()
            MyBase.New()

            Dim s As New Series("Series1") With {
        .ChartType = SeriesChartType.Doughnut
    }

            _chart.Series.Clear()
            _chart.Series.Add(s)

            s("DoughnutRadius") = "60"
            s("PieLabelStyle") = "Outside"
            s.IsValueShownAsLabel = True

            Me.ChartType = SeriesChartType.Doughnut
        End Sub


        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional: Add subtle rotation animation if desired
        End Sub
    End Class
End Namespace