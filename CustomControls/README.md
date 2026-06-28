# CustomControls

A comprehensive collection of custom Windows Forms controls for .NET Framework 4.8.1+

## Controls

### Rotary Controls
- **RotaryKnobControl** - Customizable rotary dial for audio mixing, synthesizers, and dial-style inputs (270° range, 0-6 default positions)
- **RotaryKnobControl15Pos** - 15-position rotary knob with discrete positions 0-14
- **RotaryClockControl** - Clock-style control with 6 tick marks (120° range, 9 o'clock to 5 o'clock)
- **RotaryDialControl** - Dial control with 8 tick marks (160° range)
- **RotaryHexControl** - Hex control with 6 tick marks (200° range)
- **RotaryPotControl** - Potentiometer-style control with 7 tick marks (180° range)

### Toggle & Display Controls
- **RockerSwitchControl** - Two-state toggle switch with custom image support and IEC standard symbols
- **RoundedPictureBox** - Picture box with custom rounded corners and border styling

---

## RotaryKnobControl

A highly customizable rotary knob control for Windows Forms applications, perfect for audio applications, mixing consoles, synthesizers, or any application requiring dial-style input controls.

### Features

- ✨ **Fully Customizable Appearance** - Use custom images or default rendered knobs
- 🎛️ **Flexible Value Range** - Set any minimum and maximum values
- 🖱️ **Multiple Input Methods** - Mouse drag, click, and scroll wheel support
- 🎨 **Image Customization** - Adjust rotation offset and size of custom knob images
- 📊 **Visual Feedback** - Tick marks and numeric labels
- 🔄 **Smooth Interaction** - Mouse wheel works on hover without requiring focus/click
- 🎯 **Event-Driven** - ValueChanged event for reactive programming
- ✨ **Transparent Background Support** - Blend seamlessly into your UI

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

### Technical Details

- **Namespace**: `CustomControls`
- **Assembly**: CustomControls.dll
- **Base Class**: `System.Windows.Forms.Control`
- **Rendering**: GDI+ with anti-aliasing
- **Control Styles**: Double-buffered, transparent background support

---

## RotaryKnobControl15Pos

A 15-position variant of the RotaryKnobControl, providing discrete positions (0-14) ideal for applications like synthesizer controls or chromatic scales.

### Features

- 🎹 **15 Discrete Positions** - Perfect for chromatic scales, tuners, or selector wheels
- 🎨 **Customizable Appearance** - Custom images or default rendered knobs
- 🖱️ **Mouse Interaction** - Drag, click, and scroll wheel support
- 🎯 **Snap-to-Position** - Values snap to the nearest position
- 📊 **Visual Feedback** - Clear position indicators

### Quick Start

```csharp
using CustomControls;

var knob15 = new RotaryKnobControl15Pos
{
	Minimum = 0,
	Maximum = 14,
	Value = 0,
	Location = new Point(50, 50),
	Size = new Size(150, 150)
};

knob15.ValueChanged += (sender, e) =>
{
	Console.WriteLine($"Position: {knob15.Value}");
};

this.Controls.Add(knob15);
```

### Properties

Inherits all properties from RotaryKnobControl with predefined constraints:
- **Minimum**: 0
- **Maximum**: 14
- Values snap to discrete integer positions

---

## RotaryClockControl

A clock-style rotary control with 6 tick marks spanning 120 degrees (9 o'clock to 5 o'clock position).

### Features

- 🕐 **Clock-Style Layout** - Familiar clock face interface
- 6️⃣ **6 Tick Marks** - Customizable labels for each position
- 🎚️ **Continuous or Discrete Values** - Supports both smooth and stepped values
- 🖱️ **Full Mouse Support** - Drag, click, and wheel interaction
- 🎨 **Custom Knob Images** - Use your own knob designs

### Quick Start

```csharp
using CustomControls;

var clockControl = new RotaryClockControl
{
	Minimum = 0f,
	Maximum = 6f,
	Value = 3f,
	Location = new Point(50, 50),
	Size = new Size(150, 150)
};

clockControl.ValueChanged += (sender, e) =>
{
	Console.WriteLine($"Clock Value: {clockControl.Value}");
};

this.Controls.Add(clockControl);
```

### Specifications

- **Rotation Range**: 120 degrees
- **Start Angle**: 180° (9 o'clock position)
- **End Angle**: 300° (5 o'clock position)
- **Default Tick Count**: 6
- **Customizable Tick Labels**: Yes

---

## RotaryDialControl

A rotary dial control with 8 tick marks spanning 160 degrees, ideal for detailed tuning applications.

### Features

- 8️⃣ **8 Tick Marks** - Precise control with 8 positions
- 📊 **160° Range** - Extended rotation range for fine tuning
- 🎯 **Precision Input** - Customizable value ranges
- 🎨 **Full Customization** - Colors, images, and styling
- 🖱️ **Smooth Interaction** - Mouse and wheel support

### Quick Start

```csharp
using CustomControls;

var dialControl = new RotaryDialControl
{
	Minimum = 0f,
	Maximum = 8f,
	Value = 4f,
	Location = new Point(50, 50),
	Size = new Size(150, 150)
};

dialControl.ValueChanged += (sender, e) =>
{
	Console.WriteLine($"Dial Value: {dialControl.Value}");
};

this.Controls.Add(dialControl);
```

### Specifications

- **Rotation Range**: 160 degrees
- **Start Angle**: 280° (bottom-left)
- **End Angle**: 80° (top-right)
- **Default Tick Count**: 8
- **Customizable Tick Labels**: Yes

---

## RotaryHexControl

A hexagonal-style rotary control with 6 tick marks spanning 200 degrees.

### Features

- 6️⃣ **Hexagonal Layout** - Symmetric 6-position design
- 📐 **200° Range** - Wide rotation for comfortable interaction
- 🎨 **Customizable Appearance** - Full styling support
- 🖱️ **Intuitive Controls** - Drag, click, and wheel support
- 🎯 **Value Mapping** - Flexible value ranges

### Quick Start

```csharp
using CustomControls;

var hexControl = new RotaryHexControl
{
	Minimum = 0f,
	Maximum = 6f,
	Value = 3f,
	Location = new Point(50, 50),
	Size = new Size(150, 150)
};

hexControl.ValueChanged += (sender, e) =>
{
	Console.WriteLine($"Hex Value: {hexControl.Value}");
};

this.Controls.Add(hexControl);
```

### Specifications

- **Rotation Range**: 200 degrees
- **Start Angle**: 280° (bottom-left)
- **End Angle**: 80° (top-right)
- **Default Tick Count**: 6
- **Customizable Tick Labels**: Yes

---

## RotaryPotControl

A potentiometer-style rotary control with 7 tick marks spanning 180 degrees (semi-circle).

### Features

- 🎚️ **Potentiometer Style** - Classic semi-circular dial interface
- 7️⃣ **7 Tick Marks** - Standard potentiometer layout with customizable labels
- 📊 **180° Range** - Perfect semi-circular rotation
- 🎨 **Custom Images** - Use custom knob images with rotation offsets
- 🖱️ **Full Mouse Support** - Click, drag, and scroll wheel interaction

### Quick Start

```csharp
using CustomControls;

var potControl = new RotaryPotControl
{
	Minimum = 0f,
	Maximum = 10f,
	Value = 5f,
	Location = new Point(50, 50),
	Size = new Size(150, 150)
};

potControl.ValueChanged += (sender, e) =>
{
	Console.WriteLine($"Pot Value: {potControl.Value}");
};

this.Controls.Add(potControl);
```

### Example: Audio Gain Control
```csharp
var gainControl = new RotaryPotControl
{
	Minimum = -60f,
	Maximum = 12f,
	Value = 0f,
	ForeColor = Color.White,
	BackColor = Color.Transparent
};
```

### Specifications

- **Rotation Range**: 180 degrees (semi-circle)
- **Start Angle**: 180° (left edge)
- **End Angle**: 0° (right edge)
- **Default Tick Count**: 7
- **Customizable Tick Labels**: Yes

---

## RockerSwitchControl

A customizable two-state rocker switch control for Windows Forms applications, perfect for on/off toggles, settings panels, or any application requiring a visual toggle switch.

### Features

- ✨ **Fully Customizable Appearance** - Use custom images or default two-tone rendering
- 🔘 **Two-State Toggle** - Checked/Unchecked states with visual feedback
- 🎨 **Custom Images** - Separate images for active and inactive states
- 🖌️ **Color Customization** - Configure colors when not using custom images
- 🔄 **Orientation Support** - Horizontal or vertical layout options
- ⚡ **IEC Standard Symbols** - Optional I (ON) and O (OFF) markings
- 📝 **Adjustable Text Position** - Control text placement with offset properties
- 🎯 **CheckBox-Based** - Familiar CheckBox behavior with custom rendering
- ✨ **Event-Driven** - CheckedChanged event for reactive programming

### Quick Start

```csharp
using CustomControls;

// Create a rocker switch programmatically
var rockerSwitch = new RockerSwitchControl
{
	Text = "Power",
	Checked = false,
	Location = new Point(50, 50),
	Size = new Size(100, 35)
};

// Subscribe to state changes
rockerSwitch.CheckedChanged += (sender, e) =>
{
	Console.WriteLine($"Switch is now: {(rockerSwitch.Checked ? "ON" : "OFF")}");
};

// Add to form
this.Controls.Add(rockerSwitch);
```

### Using Custom Images

```csharp
var rockerSwitch = new RockerSwitchControl
{
	ActiveImage = Image.FromFile("switch-on.png"),
	DeactiveImage = Image.FromFile("switch-off.png"),
	Text = "Enable Feature",
	TextOffsetY = 5  // Position text 5 pixels below switch
};
```

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Checked` | bool | false | Current state of the switch (true = active/on) |
| `ActiveColor` | Color | LightGray | Color for the active half when no custom image is set |
| `DeactiveColor` | Color | DarkGray | Color for the inactive half when no custom image is set |
| `ActiveImage` | Image | null | Image displayed when switch is checked |
| `DeactiveImage` | Image | null | Image displayed when switch is unchecked |
| `Orientation` | RockerSwitchOrientation | Horizontal | Orientation of the switch (Horizontal or Vertical) |
| `ShowStandardSymbols` | bool | **true** | Display IEC 60417 standard symbols (I = ON, O = OFF) |
| `TextOffsetX` | int | 0 | Horizontal text offset in pixels (positive = right, negative = left) |
| `TextOffsetY` | int | 5 | Vertical text offset in pixels (positive = down, negative = up) |
| `Text` | string | "" | Text label displayed next to the switch |

### Events

| Event | Description |
|-------|-------------|
| `CheckedChanged` | Fired when the switch state changes |

### User Interaction

- **Click** - Click anywhere on the control to toggle between states
- **Keyboard** - Space bar toggles state when control has focus

### Orientation Behavior

- **Horizontal** (default): 
  - Unchecked/OFF: Left side pressed
  - Checked/ON: Right side pressed

- **Vertical** (90° counterclockwise rotation):
  - Unchecked/OFF: Bottom pressed (down position)
  - Checked/ON: Top pressed (up position)

### Customization Examples

#### Basic Color Switch
```csharp
var colorSwitch = new RockerSwitchControl
{
	ActiveColor = Color.LimeGreen,
	DeactiveColor = Color.FromArgb(60, 60, 60),
	Text = "Active",
	ForeColor = Color.White
};
```

#### Image-Based Switch
```csharp
var imageSwitch = new RockerSwitchControl
{
	ActiveImage = Properties.Resources.SwitchOn,
	DeactiveImage = Properties.Resources.SwitchOff,
	Text = "Power",
	TextOffsetX = 0,   // Center horizontally
	TextOffsetY = 8    // 8 pixels below switch
};
```

#### Vertical Orientation Switch
```csharp
var verticalSwitch = new RockerSwitchControl
{
	Orientation = RockerSwitchOrientation.Vertical,
	Size = new Size(35, 100),  // Taller than wide for vertical
	ActiveColor = Color.OrangeRed,
	DeactiveColor = Color.Gray,
	Text = "Volume",
	TextOffsetY = 5    // Position text to the right
	// When unchecked: bottom is pressed (OFF/down position)
	// When checked: top is pressed (ON/up position)
};
```

#### Horizontal Panel Switch
```csharp
var panelSwitch = new RockerSwitchControl
{
	Orientation = RockerSwitchOrientation.Horizontal,
	Size = new Size(80, 30),
	ActiveColor = Color.DodgerBlue,
	DeactiveColor = Color.SlateGray,
	Text = "Enable",
	Checked = true
};
```

#### IEC Standard Symbols (Default)
```csharp
var standardSwitch = new RockerSwitchControl
{
	// ShowStandardSymbols = true by default - symbols appear automatically
	Size = new Size(60, 40),
	ActiveColor = Color.FromArgb(100, 200, 100),
	DeactiveColor = Color.FromArgb(80, 80, 80),
	Text = "Power"
	// Symbols automatically contrast with background colors
	// Works with both horizontal and vertical orientations
};

// To disable symbols:
// standardSwitch.ShowStandardSymbols = false;
```

### Technical Details

- **Namespace**: `CustomControls`
- **Assembly**: CustomControls.dll
- **Base Class**: `System.Windows.Forms.CheckBox`
- **Rendering**: GDI+ with custom painting
- **Control Styles**: Double-buffered, user-painted

---

## RoundedPictureBox

A customizable PictureBox with rounded corners and optional border styling.

### Features

- 🎨 **Rounded Corners** - Adjustable corner radius
- 🖼️ **Border Support** - Customizable border color and width
- 🌈 **Full Styling** - All standard PictureBox properties supported
- 📐 **Flexible Sizing** - Works with any image size and aspect ratio
- 💡 **Design-Time Support** - Easy to use in Visual Studio designer

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `CornerRadius` | int | 20 | Radius of the rounded corners in pixels |
| `BorderWidth` | int | 4 | Width of the optional border in pixels |
| `BorderColor` | Color | Blue | Color of the border when displayed |

### Quick Start

```csharp
using CustomControls;

var pictureBox = new RoundedPictureBox
{
	Image = Image.FromFile("my-image.png"),
	CornerRadius = 15,
	BorderWidth = 3,
	BorderColor = Color.White,
	Location = new Point(50, 50),
	Size = new Size(200, 200),
	SizeMode = PictureBoxSizeMode.StretchImage
};

this.Controls.Add(pictureBox);
```

### Customization Examples

#### Profile Picture Frame
```csharp
var profilePicture = new RoundedPictureBox
{
	Image = Properties.Resources.UserPhoto,
	CornerRadius = 10,
	BorderWidth = 2,
	BorderColor = Color.DodgerBlue,
	Size = new Size(100, 100),
	SizeMode = PictureBoxSizeMode.StretchImage
};
```

#### Thumbnail with Thick Border
```csharp
var thumbnail = new RoundedPictureBox
{
	Image = Properties.Resources.Thumbnail,
	CornerRadius = 8,
	BorderWidth = 5,
	BorderColor = Color.FromArgb(64, 64, 64),
	Size = new Size(150, 150),
	SizeMode = PictureBoxSizeMode.Zoom
};
```

#### Sharp Corners with Subtle Border
```csharp
var sharpImage = new RoundedPictureBox
{
	Image = Properties.Resources.Image,
	CornerRadius = 0,      // No rounding
	BorderWidth = 1,
	BorderColor = Color.Gray,
	Size = new Size(300, 200)
};
```

### Technical Details

- **Namespace**: `CustomControls`
- **Assembly**: CustomControls.dll
- **Base Class**: `System.Windows.Forms.PictureBox`
- **Rendering**: GDI+ with anti-aliasing for rounded corners
- **Control Styles**: Double-buffered, custom painted

---

## Requirements

- **.NET Framework**: 4.8.1 or higher
- **Windows Forms**: Supported
- **Visual Studio**: 2019 or later (for development)

## Design-Time Support

All controls fully support the Visual Studio designer:
- Drag and drop from the toolbox
- Edit all properties in the Properties window
- Live preview in the designer
- Full IntelliSense support

## Version History

- **v1.2** - IEC Standard Symbols & New Controls
  - Added RotaryClockControl with 6 tick marks
  - Added RotaryDialControl with 8 tick marks
  - Added RotaryHexControl with 6 tick marks
  - Added RotaryPotControl with 7 tick marks (180° semi-circle)
  - Added RotaryKnobControl15Pos for 15-position discrete control
  - Added RoundedPictureBox with customizable corners and borders
  - Added ShowStandardSymbols property to RockerSwitchControl
  - Displays I (ON) and O (OFF) per IEC 60417 standard
  - Automatic contrast color selection for symbol visibility
  - Symbols work with both horizontal and vertical orientations

- **v1.1** - Orientation support
  - Added Orientation property to RockerSwitchControl (Horizontal/Vertical)
  - Improved text positioning for both orientations
  - Enhanced painting logic for vertical layout

- **v1.0** - Initial release
  - RotaryKnobControl with mouse and wheel support
  - Custom image support with rotation and sizing
  - Configurable value ranges and appearance
  - RockerSwitchControl two-state toggle
  - Custom images for active/inactive states
  - Adjustable text positioning

## Contributing

Contributions are welcome! Please feel free to submit issues and pull requests.

## License

MIT License - See LICENSE file for details

## Author

Mike Trethowan

---

For more examples and documentation, see the demo project included in this solution.
