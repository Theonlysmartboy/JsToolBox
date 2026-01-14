Here's the improved `README.md` file, incorporating the new content while maintaining the existing structure and information:

# JsToolBox

JsToolBox is a collection of custom WinForms loader controls and utilities for VB.NET, intended as an advanced replacement and complement to the Visual Studio Toolbox. It provides reusable loader components (examples: trailing dots, circular loader) that are easy to drop into VB.NET WinForms projects.

This repository contains controls and base classes designed for extendability, performance, and design-time friendliness in Visual Studio 2022.

## Features

- Reusable WinForms loader controls (e.g., `TrailingDotsLoader`, `CircularLoader`)
- `LoaderBase` abstract base control with built-in timer/animation lifecycle
- Design-time properties for color, speed, and appearance
- Double-buffered painting to minimize flicker

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

## Example Usage

In the designer or at runtime, you can start and stop animations programmatically:

' Start a loader
myLoader.Start()

' Stop a loader
myLoader.Stop()

' Change loader color
myLoader.LoaderColor = Color.OrangeRed

' Adjust speed (interval in milliseconds; minimum 1)
myLoader.Speed = 75

The controls inherit from `LoaderBase`, which exposes the common properties and handles double-buffering and timer lifecycle. To create a new loader control, inherit from `JsToolBox.Base.LoaderBase` and implement the `OnTick` method to drive your animation.

## Project Structure

- `JsToolBox\Base` - base control classes and shared functionality
- `JsToolBox\Loaders` - concrete loader implementations (e.g., `TrailingDotsLoader`, `CircularLoader`)

## Development

- Follow the repository `.editorconfig` and `CONTRIBUTING.md` for coding and contribution standards.
- The project uses standard WinForms patterns: prefer double-buffered painting, invalidate on property changes, and keep timers per-control.
- When adding new controls, ensure design-time attributes (Browsable, Category) are used for properties that should appear in the Properties window.

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

This version maintains the original structure while ensuring clarity and coherence throughout the document. Each section is clearly defined, and the instructions are straightforward for users to follow.