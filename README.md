# CustomControls Library

A comprehensive collection of custom Windows Forms controls for .NET Framework 4.8.1+

## Overview

This repository contains a professional-grade collection of reusable Windows Forms controls designed for building modern desktop applications. The library includes rotary dial controls, toggle switches, and custom UI elements with full designer support in Visual Studio.

## Available Controls

### Rotary Controls
- **RotaryKnobControl** - Customizable rotary dial for audio mixing, synthesizers, and dial-style inputs (270° range)
- **RotaryKnobControl15Pos** - 15-position rotary knob for discrete selections
- **RotaryClockControl** - Clock-style control with 6 tick marks (120° range)
- **RotaryDialControl** - Dial control with 8 tick marks (160° range)
- **RotaryHexControl** - Hexagonal control with 6 tick marks (200° range)
- **RotaryPotControl** - Potentiometer-style control with 7 tick marks (180° semi-circle)

### Toggle & Display Controls
- **RockerSwitchControl** - Two-state toggle switch with IEC standard symbols
- **RoundedPictureBox** - Picture box with customizable rounded corners and borders

## Features

✨ **Full Designer Support** - Drag and drop controls in Visual Studio
🎨 **Highly Customizable** - Colors, images, sizing, and styling options
🖱️ **Rich Interaction** - Mouse drag, click, and scroll wheel support
📊 **Visual Feedback** - Tick marks, labels, and smooth animations
🔄 **Event-Driven** - Standard event patterns for reactive programming
💡 **Documentation** - Comprehensive examples and API documentation
⚙️ **Lightweight** - No external dependencies beyond .NET Framework

## Quick Start

1. Add the `CustomControls` project to your solution
2. Add a reference to CustomControls from your Windows Forms project
3. Build the solution - controls appear in the Visual Studio toolbox
4. Drag and drop controls onto your forms

```csharp
using CustomControls;

// Create a rotary knob
var knob = new RotaryKnobControl
{
    Minimum = 0f,
    Maximum = 100f,
    Value = 50f,
    Location = new Point(50, 50),
    Size = new Size(150, 150)
};

knob.ValueChanged += (sender, e) => 
    Console.WriteLine($"Value: {knob.Value}");

this.Controls.Add(knob);
```

## Documentation

For detailed documentation on each control, see:
- [CustomControls README](CustomControls/README.md) - Comprehensive documentation for all controls
- Property documentation in Visual Studio IntelliSense
- Demo project included in the solution

## Requirements

- **.NET Framework**: 4.8.1 or higher
- **Windows Forms**: Supported
- **Visual Studio**: 2019 or later (for development)

## Version History

### v1.2 - Major Expansion
- Added 4 new rotary controls:
  - RotaryClockControl (6 ticks, 120°)
  - RotaryDialControl (8 ticks, 160°)
  - RotaryHexControl (6 ticks, 200°)
  - RotaryPotControl (7 ticks, 180°)
- Added RotaryKnobControl15Pos for discrete 15-position selections
- Added RoundedPictureBox with corner radius and border styling
- Enhanced RockerSwitchControl with IEC 60417 standard symbols
- Improved all controls with better rendering and performance

### v1.1
- Added orientation support (Horizontal/Vertical) to RockerSwitchControl
- Enhanced text positioning and rendering

### v1.0 - Initial Release
- RotaryKnobControl with full customization
- RockerSwitchControl with image support
- Complete Visual Studio designer integration

## License

MIT License - See LICENSE file for details

## Contributing

Contributions are welcome! Please feel free to submit issues and pull requests.

## Author

Mike Trethowan

---

**Note**: This project was forked from or related to VB_net-MIDI-Mixer. The CustomControls library provides reusable UI components for any Windows Forms application.
