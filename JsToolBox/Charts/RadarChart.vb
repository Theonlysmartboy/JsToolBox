Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base

Namespace Charts
    Public Class RadarChart
        Inherits ChartBase

        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.Radar

            ' Radar needs circular gridlines
            Dim area = _chart.ChartAreas(0)
            area.AxisX.MajorGrid.Enabled = False
            area.AxisY.MajorGrid.Enabled = False
            area.AxisY.Minimum = 0
            area.AxisY.Interval = 10

            _chart.Series(0).IsValueShownAsLabel = True
            _chart.Series(0).BorderWidth = 2
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' No animation needed, but hook is here
        End Sub
    End Class
End Namespace
