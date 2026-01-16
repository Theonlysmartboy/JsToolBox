Imports System.Reflection
Imports JsToolBox.Base

Public Class ChartDemoForm
    Inherits Form

    Private flow As FlowLayoutPanel
    Private ReadOnly rnd As New Random()

    Public Sub New()
        InitializeComponent()
        Me.Text = "JsToolBox Charts Demo"
        Me.Size = New Size(1000, 800)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Scrollable FlowLayoutPanel
        flow = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoScroll = True,
            .Padding = New Padding(10),
            .BackColor = Color.WhiteSmoke
        }
        Me.Controls.Add(flow)

        ' Discover and add all chart controls in JsToolBox.Charts namespace
        Dim asm = Assembly.GetAssembly(GetType(ChartBase))
        If asm IsNot Nothing Then
            For Each t In asm.GetTypes()
                If t.IsClass AndAlso Not t.IsAbstract AndAlso GetType(ChartBase).IsAssignableFrom(t) AndAlso t.Namespace = "JsToolBox.Charts" Then
                    Try
                        Dim chart As ChartBase = CType(Activator.CreateInstance(t), ChartBase)
                        ' Give a human-friendly title if none provided by the control
                        If String.IsNullOrWhiteSpace(chart.Title) Then
                            chart.Title = t.Name
                        End If
                        AddChartDemo(chart.Title, chart)
                    Catch ex As Exception
                        ' If a control fails to construct, skip it (keeps demo robust)
                    End Try
                End If
            Next
        End If

    End Sub

    Private Sub AddChartDemo(title As String, chart As ChartBase)
        ' Container panel
        Dim panel As New Panel() With {
            .Size = New Size(Math.Max(600, flow.ClientSize.Width - 40), 350),
            .BorderStyle = BorderStyle.FixedSingle,
            .Padding = New Padding(10)
        }

        ' Title label
        Dim lbl As New Label() With {
            .Text = title,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Dock = DockStyle.Top,
            .Height = 25
        }
        panel.Controls.Add(lbl)

        ' Chart control
        chart.Location = New Point(10, 35)
        chart.Size = New Size(panel.Width - 20, 250)
        panel.Controls.Add(chart)

        ' Sample Data Button
        Dim btnData As New Button() With {
            .Text = "Load Sample Data",
            .Location = New Point(panel.ClientSize.Width - 150, 40),
            .Width = 130
        }
        AddHandler btnData.Click, Sub()
                                      LoadSampleData(chart)
                                  End Sub
        panel.Controls.Add(btnData)

        flow.Controls.Add(panel)
        LoadSampleData(chart)
    End Sub

    Private Sub LoadSampleData(chart As ChartBase)
        Select Case chart.GetType().Name
            Case "PieChart"
                chart.SetData(New String() {"A", "B", "C", "D"}, New Double() {30, 25, 20, 25})
            Case "BarChart"
                chart.SetData(New String() {"Jan", "Feb", "Mar", "Apr"}, New Double() {12000, 15000, 10000, 18000})
            Case "LineChart"
                chart.SetData(New String() {"Q1", "Q2", "Q3", "Q4"}, New Double() {5000, 7000, 6500, 9000})
            Case Else
                ' Generic fallback for newly added charts: generate simple category data
                Dim categories = New String() {"Cat A", "Cat B", "Cat C", "Cat D", "Cat E", "Cat F"}
                Dim values(categories.Length - 1) As Double
                For i As Integer = 0 To values.Length - 1
                    values(i) = Math.Round(100 + rnd.NextDouble() * 900, 2)
                Next
                chart.SetData(categories, values)
        End Select
    End Sub

    <STAThread>
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New ChartDemoForm())
    End Sub

End Class