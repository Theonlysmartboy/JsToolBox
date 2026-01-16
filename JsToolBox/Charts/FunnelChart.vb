Imports System.Windows.Forms.DataVisualization.Charting
Imports JsToolBox.Base

Namespace Charts
    Public Class FunnelChart
        Inherits ChartBase

        Public Sub New()
            MyBase.New()
            Me.ChartType = SeriesChartType.Funnel

            Dim s = _chart.Series(0)
            s("FunnelStyle") = "YIsValue"
            s("FunnelLabelStyle") = "Outside"
            s.IsValueShownAsLabel = True
        End Sub

        Protected Overrides Sub OnTick(sender As Object, e As EventArgs)
            ' Optional animation
        End Sub
    End Class
End Namespace
