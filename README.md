# JsToolBox

JsToolBox is a collection of custom WinForms loader controls and utilities for VB.NET, intended as an advanced replacement and complement to the Visual Studio Toolbox. It provides reusable loader components (examples: `TrailingDotsLoader`, `CircularLoader`, `BarLoader`, `SpinnerLoader`, `PulseEllipseLoader`) that are easy to drop into VB.NET WinForms projects.

This repository contains controls and base classes designed for extendability, performance, and design-time friendliness in Visual Studio 2022.

## Features

- Reusable WinForms loader controls
- `LoaderBase` abstract base control with built-in timer/animation lifecycle
- Design-time properties for color, speed, and appearance
- Double-buffered painting to minimize flicker
- Small, focused API per control for easy customization

## Included Loaders (brief descriptions)

- **`TrailingDotsLoader`**
  - Displays a sequence of moving dots (e.g., "Loading.", "Loading..", "Loading...") or a trailing-dot animation. Good for inline text status.
  - Key properties: `LoaderColor`, `Speed`, `DotCount` (number of dots), `Text` (optional label).

- **`CircularLoader`**
  - A circular spinner that rotates, with configurable thickness and sweep. Useful as a generic busy indicator.
  - Key properties: `LoaderColor`, `Speed`, `Thickness`, `SweepAngle`.

- **`BarLoader`**
  - Animated bar segments that move or pulse horizontally. Useful for progress-like indeterminate states.
  - Key properties: `LoaderColor`, `Speed`, `SegmentCount`, `SegmentWidth`.

- **`SpinnerLoader`**
  - Classic multi-segment spinner (like a gear of spokes) where segments fade in/out to give rotation impression.
  - Key properties: `LoaderColor`, `Speed`, `SpokeCount`, `InnerRadius`.

- **`PulseEllipseLoader`**
  - One or more ellipses that pulse in size/opacity, creating a breathing indicator effect.
  - Key properties: `LoaderColor`, `Speed`, `PulseCount`, `MaxScale`.

Each control inherits from `LoaderBase` and therefore shares common lifecycle methods and properties (`Start`, `Stop`, `LoaderColor`, `Speed`).

## Requirements

- Visual Studio 2022
- .NET Framework or .NET version compatible with the included projects (see individual project TFMs)

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/Theonlysmartboy/JsToolBox.git
    cd JsToolBox
    ```

2. Open the solution in Visual Studio 2022: open `JsToolBox.sln` (or the main solution file).

3. Build the solution.

4. Use the controls in your project:
   - Either add the compiled assembly (DLL) as a reference to your WinForms project, or add the project to your solution and reference it.
   - In the Visual Studio Toolbox, right-click and choose `Choose Items...`, then browse to the compiled DLL to add the controls to the toolbox.
   - Drag the control onto a WinForms designer surface like any other control.

## Basic Usage

All loaders share the same base API from `LoaderBase`.

```vb
' Start a loader
myLoader.Start()

' Stop a loader
myLoader.Stop()

' Change loader color
myLoader.LoaderColor = Color.OrangeRed

' Adjust speed (interval in milliseconds; minimum 1)
myLoader.Speed = 75
```

Control-specific examples (designer or runtime):

```vb
' TrailingDotsLoader: set dot count and text
Dim dots As New TrailingDotsLoader()
dots.DotCount = 3
dots.Text = "Loading"
dots.LoaderColor = Color.DodgerBlue
dots.Speed = 200
dots.Start()

' CircularLoader: set thickness and sweep
Dim spinner As New CircularLoader()
spinner.Thickness = 4
spinner.SweepAngle = 120
spinner.LoaderColor = Color.Green
spinner.Start()
```

When adding new controls, implement animation logic inside the `OnTick` override and call `Invalidate()` to trigger a repaint. Use `DoubleBuffered = True` to reduce flicker (already set in `LoaderBase`).

## Project Structure

- `JsToolBox\Base` - base control classes and shared functionality (e.g., `LoaderBase`)
- `JsToolBox\Loaders` - concrete loader implementations (e.g., `TrailingDotsLoader`, `CircularLoader`, `BarLoader`, `SpinnerLoader`, `PulseEllipseLoader`)

## Development

- Follow the repository `.editorconfig` and `CONTRIBUTING.md` for coding and contribution standards.
- The project uses standard WinForms patterns: prefer double-buffered painting, invalidate on property changes, and keep timers per-control.
- When adding new controls, ensure design-time attributes (`Browsable`, `Category`) are used for properties that should appear in the Properties window.

## Contributing

Contributions are welcome. Please follow these guidelines:

1. Fork the repository and create a descriptive branch for your changes.
2. Follow the coding standards in `.editorconfig` and project `CONTRIBUTING.md`.
3. Add or update unit tests where applicable.
4. Open a pull request with a clear description of the change.

See `CONTRIBUTING.md` for more details.

## License

This project does not include a license file in the repository by default. Add a license (for example MIT) if you intend to make the code open source.

## Contact

For questions or discussion, open an issue on the repository.

