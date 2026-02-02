Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base
Namespace Charts
    Public Class PieChart
        Inherits ChartBase

        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.Pie
            ' Optionaly show labels outside the slices
            Dim s = EnsureDefaultSeries()
            s("PieLabelStyle") = "Outside"
            _chart.AccessibleDescription = "Pie Chart"
            _chart.AccessibleName = "Pie Chart"
            s.ToolTip = "#VALX: #PERCENT{P2}"
            s.IsValueShownAsLabel = True
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional: Add subtle rotation animation if desired
        End Sub
    End Class
End Namespace