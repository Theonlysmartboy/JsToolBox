Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Namespace Base

    Public MustInherit Class ChartBase
        Inherits UserControl

        Protected ReadOnly _chart As Chart
        Private _hoveredPoint As DataPoint = Nothing
        Private _originalColor As Color
        Private _targetMarkerSize As Integer = 0
        Private _animationTimer As Timer
        Private _glowIncrement As Integer = 1 ' How fast the grow/shrink happens
        Private _maxGlowSize As Integer = 12

        Public Sub New()
            Me.DoubleBuffered = True
            Me.Size = New Size(400, 300)

            ' Initialize chart
            _chart = New Chart() With {.Dock = DockStyle.Fill}
            Me.Controls.Add(_chart)

            Dim area As New ChartArea("MainArea")
            _chart.ChartAreas.Add(area)

            Dim series As New Series("Series1")
            _chart.Series.Add(series)

            Dim legend As New Legend("Legend1")
            _chart.Legends.Add(legend)

            ' Hover detection
            AddHandler _chart.MouseMove, AddressOf Chart_MouseMove
            AddHandler _chart.MouseLeave, AddressOf Chart_MouseLeave

            ' Timer for smooth animation
            _animationTimer = New Timer With {.Interval = 15} ' ~60 FPS
            AddHandler _animationTimer.Tick, AddressOf AnimateHoveredPoint
            _animationTimer.Start()
        End Sub

        ' Hover detection
        Private Sub Chart_MouseMove(sender As Object, e As MouseEventArgs)
            Dim result = _chart.HitTest(e.X, e.Y)
            Dim point As DataPoint = Nothing

            If result.ChartElementType = ChartElementType.DataPoint Then
                point = _chart.Series(result.Series.Name).Points(result.PointIndex)
            End If

            If point IsNot _hoveredPoint Then
                ResetPreviousPoint()
                _hoveredPoint = point
                If _hoveredPoint IsNot Nothing Then
                    _originalColor = _hoveredPoint.Color
                    _targetMarkerSize = _hoveredPoint.MarkerSize + _maxGlowSize
                    _hoveredPoint.MarkerStyle = MarkerStyle.Circle
                End If
            End If
        End Sub

        Private Sub Chart_MouseLeave(sender As Object, e As EventArgs)
            ResetPreviousPoint()
        End Sub

        ' Smooth animation per tick
        Private Sub AnimateHoveredPoint(sender As Object, e As EventArgs)
            If _hoveredPoint IsNot Nothing Then
                ' Grow towards target size
                If _hoveredPoint.MarkerSize < _targetMarkerSize Then
                    _hoveredPoint.MarkerSize += _glowIncrement
                    _hoveredPoint.Color = ControlPaint.Light(_originalColor, 0.5F)
                End If
            End If
        End Sub

        Private Sub ResetPreviousPoint()
            If _hoveredPoint IsNot Nothing Then
                ' Shrink back to original size
                _hoveredPoint.MarkerSize -= _glowIncrement
                If _hoveredPoint.MarkerSize <= 5 Then
                    _hoveredPoint.MarkerStyle = MarkerStyle.None
                    _hoveredPoint.Color = _originalColor
                    _hoveredPoint = Nothing
                End If
            End If
        End Sub

        ' Designer Properties
        <Browsable(True), Category("Appearance"), DefaultValue("Chart Title")>
        Public Property Title As String
            Get
                If _chart.Titles.Count = 0 Then Return ""
                Return _chart.Titles(0).Text
            End Get
            Set(value As String)
                _chart.Titles.Clear()
                _chart.Titles.Add(value)
            End Set
        End Property

        <Browsable(True), Category("Appearance"), DefaultValue(ChartColorPalette.Bright)>
        Public Property Palette As ChartColorPalette
            Get
                Return _chart.Palette
            End Get
            Set(value As ChartColorPalette)
                _chart.Palette = value
            End Set
        End Property

        <Browsable(True), Category("Appearance"), DefaultValue(True)>
        Public Property ShowLegend As Boolean
            Get
                Return _chart.Legends(0).Enabled
            End Get
            Set(value As Boolean)
                _chart.Legends(0).Enabled = value
            End Set
        End Property

        <Browsable(True), Category("Axes"), DefaultValue("")>
        Public Property AxisXTitle As String
            Get
                Return _chart.ChartAreas(0).AxisX.Title
            End Get
            Set(value As String)
                _chart.ChartAreas(0).AxisX.Title = value
            End Set
        End Property

        <Browsable(True), Category("Axes"), DefaultValue("")>
        Public Property AxisYTitle As String
            Get
                Return _chart.ChartAreas(0).AxisY.Title
            End Get
            Set(value As String)
                _chart.ChartAreas(0).AxisY.Title = value
            End Set
        End Property

        <Browsable(True), Category("Data"), DefaultValue("Series1")>
        Public Property SeriesName As String
            Get
                If _chart.Series.Count = 0 Then Return ""
                Return _chart.Series(0).Name
            End Get
            Set(value As String)
                If _chart.Series.Count = 0 Then
                    _chart.Series.Add(New Series(value))
                Else
                    _chart.Series(0).Name = value
                End If
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property ChartType As SeriesChartType
            Get
                If _chart.Series.Count = 0 Then Return SeriesChartType.Column
                Return _chart.Series(0).ChartType
            End Get
            Set(value As SeriesChartType)
                For Each s As Series In _chart.Series
                    s.ChartType = value
                Next
            End Set
        End Property

        <Browsable(False)>
        Public WriteOnly Property DataSource As DataTable
            Set(value As DataTable)
                _chart.Series.Clear()
                For Each col As DataColumn In value.Columns
                    Dim series As New Series(col.ColumnName) With {.ChartType = Me.ChartType}
                    For Each row As DataRow In value.Rows
                        series.Points.AddXY(row(0), row(col))
                    Next
                    _chart.Series.Add(series)
                Next
            End Set
        End Property

        <Browsable(False)>
        Public Sub SetData(xValues() As String, yValues() As Double)
            If xValues.Length <> yValues.Length Then Throw New ArgumentException("X and Y arrays must match length")
            _chart.Series.Clear()
            Dim series As New Series(SeriesName) With {.ChartType = Me.ChartType}
            For i As Integer = 0 To xValues.Length - 1
                series.Points.AddXY(xValues(i), yValues(i))
            Next
            _chart.Series.Add(series)
        End Sub

        Protected MustOverride Sub OnTick(sender As Object, e As EventArgs)

    End Class
End Namespace
