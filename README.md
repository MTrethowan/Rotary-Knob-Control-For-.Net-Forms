# CustomControls

A collection of custom Windows Forms controls for .NET Framework 4.8.1+

## RotaryKnobControl

A highly customizable rotary knob control for Windows Forms applications, perfect for audio applications, mixing consoles, synthesizers, or any application requiring dial-style input controls.

![Rotary Knob Control](docs/rotary-knob-preview.png)

### Features

- ✨ **Fully Customizable Appearance** - Use custom images or default rendered knobs
- 🎛️ **Flexible Value Range** - Set any minimum and maximum values
- 🖱️ **Multiple Input Methods** - Mouse drag, click, and scroll wheel support
- 🎨 **Image Customization** - Adjust rotation offset and size of custom knob images
- 📊 **Visual Feedback** - Tick marks and numeric labels
- 🔄 **Smooth Interaction** - Mouse wheel works on hover without requiring focus/click
- 🎯 **Event-Driven** - ValueChanged event for reactive programming
- 🌟 **Transparent Background Support** - Blend seamlessly into your UI

### Installation

#### Option 1: Add Project Reference
1. Copy the `CustomControls` project to your solution directory
2. Right-click your solution → Add → Existing Project
3. Select `CustomControls.csproj`
4. Add a reference from your Windows Forms project to CustomControls

#### Option 2: Copy Source File
1. Copy `RotaryKnobControl.cs` to your project
2. The control will automatically appear in the toolbox after building

### Quick Start

```csharp
using CustomControls;

// Create a rotary knob programmatically
var knob = new RotaryKnobControl
{
	Minimum = 0f,
	Maximum = 10f,
	Value = 5f,
	Location = new Point(50, 50),
	Size = new Size(150, 150)
};

// Subscribe to value changes
knob.ValueChanged += (sender, e) =>
{
	Console.WriteLine($"New value: {knob.Value}");
};

// Add to form
this.Controls.Add(knob);
```

### Using Custom Images

```csharp
var knob = new RotaryKnobControl
{
	KnobImage = Image.FromFile("knob.png"),
	KnobImageRotationOffset = -90f,  // Adjust if image pointer is not at top
	KnobImageSizeMultiplier = 1.2f   // Make image 20% larger
};
```

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Value` | float | 0 | Current value of the knob |
| `Minimum` | float | 0 | Minimum allowed value |
| `Maximum` | float | 10 | Maximum allowed value |
| `KnobImage` | Image | null | Custom image for the knob (uses default if null) |
| `KnobImageRotationOffset` | float | 0 | Rotation offset in degrees for custom images (0-360) |
| `KnobImageSizeMultiplier` | float | 1.0 | Size multiplier for custom images (e.g., 1.5 = 150%) |

### Events

| Event | Description |
|-------|-------------|
| `ValueChanged` | Fired when the knob value changes |

### User Interaction

- **Click and Drag** - Click anywhere on the control and drag to adjust value
- **Direct Click** - Click at a position to jump to that value
- **Mouse Wheel** - Hover over the control and scroll to adjust (no click required)
  - Scroll up: increases value by 0.5
  - Scroll down: decreases value by 0.5

### Customization Examples

#### Audio Mixer Style
```csharp
var volumeKnob = new RotaryKnobControl
{
	Minimum = -60f,
	Maximum = 6f,
	Value = 0f,
	ForeColor = Color.White,
	BackColor = Color.Transparent
};
```

#### Percentage Control
```csharp
var percentKnob = new RotaryKnobControl
{
	Minimum = 0f,
	Maximum = 100f,
	Value = 50f
};
```

#### Custom Styled Knob
```csharp
var customKnob = new RotaryKnobControl
{
	KnobImage = Properties.Resources.MyKnobImage,
	KnobImageRotationOffset = 45f,      // Rotate image 45° to align pointer
	KnobImageSizeMultiplier = 0.8f,     // Make image 80% of default size
	ForeColor = Color.FromArgb(255, 100, 50)
};
```

### Design-Time Support

The control fully supports the Visual Studio designer:
- Drag and drop from the toolbox
- Edit all properties in the Properties window
- Live preview in the designer
- Full IntelliSense support

### Requirements

- .NET Framework 4.8.1 or higher
- Windows Forms

### Technical Details

- **Namespace**: `CustomControls`
- **Assembly**: CustomControls.dll
- **Base Class**: `System.Windows.Forms.Control`
- **Rendering**: GDI+ with anti-aliasing
- **Control Styles**: Double-buffered, transparent background support

### Contributing

Contributions are welcome! Please feel free to submit issues and pull requests.

### License

MIT

### Author

Mike Trethowan

### Version History

- **v1.0** - Initial release
  - Rotary knob control with mouse and wheel support
  - Custom image support with rotation and sizing
  - Configurable value ranges and appearance

---

For more examples and documentation, see the demo project included in this solution.
