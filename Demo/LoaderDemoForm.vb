Imports JsToolBox.Base
Imports JsToolBox.Loaders

Public Class LoaderDemoForm
    Inherits Form

    Private flow As FlowLayoutPanel

    Public Sub New()
        Me.Text = "JsToolBox Loaders Demo"
        Me.Size = New Size(900, 700)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Scrollable FlowLayoutPanel
        flow = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .Padding = New Padding(10),
            .BackColor = Color.WhiteSmoke
        }
        Me.Controls.Add(flow)

        AddLoaderDemo("Circular Loader", New CircularLoader() With {.LoaderColor = Color.DodgerBlue, .Text = "Loading"})
        AddLoaderDemo("Trailing Dots Loader", New TrailingDotsLoader() With {.LoaderColor = Color.MediumSeaGreen})
        AddLoaderDemo("Pulse Loader", New PulseLoader() With {.LoaderColor = Color.OrangeRed})
        AddLoaderDemo("Wave Bars Loader", New WaveBarsLoader() With {.LoaderColor = Color.MediumPurple})
        AddLoaderDemo("Chasing Dots Loader", New ChasingDotsLoader() With {.LoaderColor = Color.Crimson})
        AddLoaderDemo("Spinning Square Loader", New SpinningSquareLoader() With {.LoaderColor = Color.Teal})
        AddLoaderDemo("Dual Ring Loader", New DualRingLoader() With {.OuterRingColor = Color.DodgerBlue, .InnerRingColor = Color.DeepSkyBlue})
        AddLoaderDemo("Equalizer Bars Loader", New EqualizerBarsLoader() With {.LoaderColor = Color.DarkOrange, .Style = EqualizerBarsLoader.EqualizerStyle.Wave})
        AddLoaderDemo("Ripple Loader", New RippleLoader() With {.LoaderColor = Color.MediumTurquoise})
        AddLoaderDemo("Facebook Shimmer Loader", New FacebookShimmerLoader() With {.LoaderColor = Color.Gray, .Size = New Size(250, 60)})

    End Sub

    Private Sub AddLoaderDemo(title As String, loader As LoaderBase)
        ' Ensure loader is visible
        If loader.Width < 40 Then loader.Width = 60
        If loader.Height < 40 Then loader.Height = 60
        ' Container panel
        Dim panel As New Panel() With {
        .Size = New Size(flow.ClientSize.Width - 40, Math.Max(120, loader.Height + 50)),
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
        ' Loader location
        loader.Location = New Point(10, lbl.Bottom + 5)
        panel.Controls.Add(loader)
        ' Start / Stop buttons
        Dim btnStart As New Button() With {.Text = "Start", .Location = New Point(panel.Width - 150, 40), .Width = 60}
        Dim btnStop As New Button() With {.Text = "Stop", .Location = New Point(panel.Width - 80, 40), .Width = 60}
        AddHandler btnStart.Click, Sub(s, e) loader.Start()
        AddHandler btnStop.Click, Sub(s, e) loader.Stop()
        panel.Controls.Add(btnStart)
        panel.Controls.Add(btnStop)
        flow.Controls.Add(panel)
    End Sub

    <STAThread>
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New LoaderDemoForm())
    End Sub
End Class
