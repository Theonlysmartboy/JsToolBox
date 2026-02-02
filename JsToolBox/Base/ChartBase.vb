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
        Private _titleLabel As Label
        Private _container As Panel
        Private _emptyMessage As String = "No Data Available"
        Private _isEmpty As Boolean = False

        Public Sub New()
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            Me.BackColor = Color.Transparent
            Me.DoubleBuffered = True
            Me.Size = New Size(400, 300)
            _container = New Panel With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.Transparent
            }
            _titleLabel = New Label With {
                .Dock = DockStyle.Top,
                .Height = 35,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .ForeColor = Color.Black
            }
            _chart = New Chart() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.Transparent
            }
            Me.Controls.Add(_chart)
            Me.Controls.Add(_container)
            Me.Controls.Add(_titleLabel)
            Dim area As New ChartArea("MainArea")
            area.BackColor = Color.Transparent
            area.BorderColor = Color.Transparent
            area.Area3DStyle.Enable3D = False
            _chart.ChartAreas.Add(area)
            Dim legend As New Legend("Legend1")
            legend.BackColor = Color.Transparent
            legend.ForeColor = Color.Black
            _chart.Legends.Add(legend)
            ApplyDefaultStyling()
            AddHandler _chart.MouseMove, AddressOf Chart_MouseMove
            AddHandler _chart.MouseLeave, AddressOf Chart_MouseLeave
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            If String.IsNullOrWhiteSpace(Me.Title) Then
                Me.Title = Me.Name
            End If
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
                    _originalColor = If(_hoveredPoint.Color.IsEmpty, _hoveredPoint.BackSecondaryColor, _hoveredPoint.Color)
                End If
            End If
        End Sub

        Private Sub AnimateHoveredPoint(sender As Object, e As EventArgs)
            If _hoveredPoint IsNot Nothing Then
                ' Apply glow effect using a lightened color 
                _hoveredPoint.Color = ControlPaint.Light(_originalColor, 0.5F)
                ' Optionally, add border 
                _hoveredPoint.BorderColor = _originalColor
                _hoveredPoint.BorderWidth = 2
            End If
        End Sub

        Private Sub Chart_MouseLeave(sender As Object, e As EventArgs)
            ResetPreviousPoint()
        End Sub

        Private Sub ResetPreviousPoint()
            If _hoveredPoint IsNot Nothing Then
                ' Restore original color 
                _hoveredPoint.Color = _originalColor
                _hoveredPoint.BorderWidth = 1
                _hoveredPoint = Nothing
            End If
        End Sub

        ' Designer Properties 
        <Browsable(True), Category("Appearance"), DefaultValue("")>
        Public Property Title As String
            Get
                Return _titleLabel.Text
            End Get
            Set(value As String)
                _titleLabel.Text = value
                _titleLabel.Visible = Not String.IsNullOrWhiteSpace(value)
            End Set
        End Property

        <Browsable(True), Category("Appearance")>
        Public Property EmptyMessage As String
            Get
                Return _emptyMessage
            End Get
            Set(value As String)
                _emptyMessage = value
                If _isEmpty Then
                    ShowEmptyState()
                End If
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

        Private _chartType As SeriesChartType = SeriesChartType.Column
        <Browsable(True), Category("Appearance")>
        Public Property ChartType As SeriesChartType
            Get
                Return _chartType
            End Get
            Set(value As SeriesChartType)
                _chartType = value
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
            If xValues Is Nothing OrElse yValues Is Nothing OrElse xValues.Length = 0 OrElse yValues.All(Function(v) v = 0) Then
                ShowEmptyState()
                Return
            End If
            If xValues.Length <> yValues.Length Then
                Throw New ArgumentException("X and Y arrays must match length")
            End If
            _chart.Series.Clear()
            Dim series As New Series(SeriesName) With {
                .ChartType = Me.ChartType
            }
            _chart.Series.Add(series)
            For i As Integer = 0 To xValues.Length - 1
                Dim p = series.Points.AddXY(xValues(i), yValues(i))
                series.Points(p).Color = GetColor(i)
            Next
        End Sub

        Private Function GetColor(index As Integer) As Color
            Dim colors As Color() = {Color.FromArgb(255, 99, 132), Color.FromArgb(54, 162, 235), Color.FromArgb(255, 206, 86), Color.FromArgb(75, 192, 192), Color.FromArgb(153, 102, 255), Color.FromArgb(255, 159, 64)}
            Return colors(index Mod colors.Length)
        End Function

        Private Sub ShowEmptyState()
            _isEmpty = True
            _chart.Series.Clear()
            Dim area = _chart.ChartAreas(0)
            ' Remove previous annotations
            _chart.Annotations.Clear()
            If Me.ChartType = SeriesChartType.Pie OrElse Me.ChartType = SeriesChartType.Doughnut Then
                Dim s As New Series("Empty") With {
                    .ChartType = Me.ChartType,
                    .IsVisibleInLegend = False
                }
                s.Points.AddXY("Empty", 1)
                s.Points(0).Color = Color.FromArgb(160, Color.Gainsboro)
                If Me.ChartType = SeriesChartType.Doughnut Then
                    s("DoughnutRadius") = "65"
                End If
                _chart.Series.Add(s)
            Else
                ' Axis-based charts (Column, Bar, Line, etc)
                area.AxisX.Enabled = AxisEnabled.True
                area.AxisY.Enabled = AxisEnabled.True
                area.AxisY.Minimum = 0
                area.AxisY.Maximum = 10
                area.AxisY.Interval = 2
                area.AxisX.MajorGrid.Enabled = True
                area.AxisY.MajorGrid.Enabled = True
                Dim sEmpty As New Series("Empty") With {
                    .ChartType = Me.ChartType,
                    .IsVisibleInLegend = False,
                    .Color = Color.Transparent
                }
                sEmpty.Points.AddXY("", 0)
                _chart.Series.Add(sEmpty)
            End If
            AddWatermark()
        End Sub

        Private Sub AddWatermark()
            Dim annotation As New TextAnnotation()
            annotation.Text = _emptyMessage
            annotation.ForeColor = Color.Gray
            annotation.Font = New Font("Segoe UI", 11, FontStyle.Italic)
            annotation.Alignment = ContentAlignment.MiddleCenter
            annotation.AnchorAlignment = ContentAlignment.MiddleCenter
            annotation.X = 50
            annotation.Y = 50
            annotation.Width = 100
            annotation.Height = 100
            annotation.IsSizeAlwaysRelative = True
            _chart.Annotations.Add(annotation)
        End Sub

        Private Sub ApplyDefaultStyling()
            Dim area = _chart.ChartAreas(0)
            area.AxisX.MajorGrid.LineColor = Color.Gainsboro
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
            area.AxisX.MajorTickMark.Enabled = False
            area.AxisY.MajorTickMark.Enabled = False
            area.AxisX.LineColor = Color.DarkGray
            area.AxisY.LineColor = Color.DarkGray
            area.BackSecondaryColor = Color.Transparent
            area.BorderDashStyle = ChartDashStyle.NotSet
            area.ShadowColor = Color.Transparent
        End Sub

        Protected Function EnsureDefaultSeries() As Series
            If _chart.Series.Count = 0 Then
                Dim s As New Series("Series1") With {
                    .ChartType = Me.ChartType
                }
                _chart.Series.Add(s)
            End If
            Return _chart.Series(0)
        End Function

        Protected MustOverride Sub OnTick(sender As Object, e As EventArgs)
    End Class
End Namespace