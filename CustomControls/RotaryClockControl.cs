// ==============================================================================
// RotaryClockControl.cs
// ==============================================================================
// 
// Project:      CustomControls
// Description:  A customizable rotary clock-style control with 6 tick marks
// 
// Author:       Mike Trethowan
// Created:      2026-06-12
// Modified:     2026-06-12
// Version:      1.0.0
// 
// Copyright (c) 2026 Mike Trethowan. All rights reserved.
// 
// License:      MIT License (or your chosen license)
//               See LICENSE file in the project root for full license information.
// 
// Dependencies: .NET Framework 4.8.1+
//               System.Windows.Forms
//               System.Drawing
// 
// Notes:        This control supports mouse drag, click, and scroll wheel interaction.
//               Custom knob images can be provided with rotation offset and size adjustment.
//               Mouse wheel works on hover without requiring focus click.
//               120-degree rotation range with 6 customizable tick labels.
// 
// Change Log:
//   v1.0.0 - 2026-06-12 - Initial release
//            - 120-degree rotary clock control (9 o'clock to 5 o'clock)
//            - 6 tick marks with customizable text labels
//            - Custom image support
//            - Mouse wheel support
//            - Configurable value ranges
// ==============================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
    /// <summary>
    /// A rotary clock-style control with 6 tick marks and customizable labels.
    /// Supports mouse drag, click, and scroll wheel interaction.
    /// </summary>
    /// <remarks>
    /// This control provides a 120-degree clock-style dial interface with 6 tick marks 
    /// positioned from 9 o'clock (180°) to 5 o'clock (300°). The control supports custom 
    /// images and offers multiple interaction methods including mouse wheel support without 
    /// requiring focus.
    /// </remarks>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(RotaryClockControl))]
    [Description("A rotary clock-style control with 6 tick marks")]
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    public class RotaryClockControl : Control
    {
        private float _value = 0f;
        private float _minimum = 0f;
        private float _maximum = 5f;
        private float _startAngle = 180f; // Starting position (labeled as 0) - 9 o'clock
        private float _endAngle = 300f;   // Ending position (labeled as 5) - 5 o'clock
        private Image _knobImage = null;
        private float _knobImageRotationOffset = 0f;
        private float _knobImageSizeMultiplier = 1.0f;
        private bool _isDragging = false;
        private Point _lastMousePosition;
        private string[] _tickLabels = new string[] { "0", "1", "2", "3", "4", "5" };

        #region Properties

        /// <summary>
        /// Gets or sets the current value of the control.
        /// </summary>
        /// <value>The current value, automatically clamped between <see cref="Minimum"/> and <see cref="Maximum"/>.</value>
        /// <remarks>
        /// Setting this property will trigger the <see cref="ValueChanged"/> event if the value changes.
        /// Values outside the valid range are automatically clamped.
        /// </remarks>
        [Category("Behavior")]
        [Description("Gets or sets the current value of the control (0-5).")]
        public float Value
        {
            get { return _value; }
            set
            {
                if (value < _minimum) value = _minimum;
                if (value > _maximum) value = _maximum;
                if (_value != value)
                {
                    _value = value;
                    OnValueChanged(EventArgs.Empty);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum value allowed for the control.
        /// </summary>
        /// <value>The minimum value. Default is 0.</value>
        /// <remarks>
        /// If the current <see cref="Value"/> is less than the new minimum, 
        /// the value will be automatically adjusted to match the minimum.
        /// </remarks>
        [Category("Behavior")]
        [Description("Gets or sets the minimum value.")]
        public float Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                if (_value < _minimum) Value = _minimum;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value allowed for the control.
        /// </summary>
        /// <value>The maximum value. Default is 5.</value>
        /// <remarks>
        /// If the current <see cref="Value"/> is greater than the new maximum, 
        /// the value will be automatically adjusted to match the maximum.
        /// </remarks>
        [Category("Behavior")]
        [Description("Gets or sets the maximum value.")]
        public float Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                if (_value > _maximum) Value = _maximum;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the custom labels for the 6 tick marks.
        /// </summary>
        /// <value>An array of 6 strings for the tick labels. Default is { "0", "1", "2", "3", "4", "5" }.</value>
        /// <remarks>
        /// This array must contain exactly 6 elements corresponding to the 6 tick marks.
        /// If an invalid array is provided, the default labels will be used.
        /// </remarks>
        [Browsable(false)]
        public string[] TickLabels
        {
            get { return _tickLabels; }
            set
            {
                if (value != null && value.Length == 6)
                {
                    _tickLabels = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the label text for the first tick mark (9 o'clock/180°).
        /// </summary>
        [Category("Appearance")]
        [Description("Label text for tick mark 1 (9 o'clock)")]
        [DefaultValue("0")]
        public string TickLabel1
        {
            get { return _tickLabels[0]; }
            set { _tickLabels[0] = value ?? "0"; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the label text for the second tick mark.
        /// </summary>
        [Category("Appearance")]
        [Description("Label text for tick mark 2")]
        [DefaultValue("1")]
        public string TickLabel2
        {
            get { return _tickLabels[1]; }
            set { _tickLabels[1] = value ?? "1"; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the label text for the third tick mark.
        /// </summary>
        [Category("Appearance")]
        [Description("Label text for tick mark 3")]
        [DefaultValue("2")]
        public string TickLabel3
        {
            get { return _tickLabels[2]; }
            set { _tickLabels[2] = value ?? "2"; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the label text for the fourth tick mark.
        /// </summary>
        [Category("Appearance")]
        [Description("Label text for tick mark 4")]
        [DefaultValue("3")]
        public string TickLabel4
        {
            get { return _tickLabels[3]; }
            set { _tickLabels[3] = value ?? "3"; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the label text for the fifth tick mark.
        /// </summary>
        [Category("Appearance")]
        [Description("Label text for tick mark 5")]
        [DefaultValue("4")]
        public string TickLabel5
        {
            get { return _tickLabels[4]; }
            set { _tickLabels[4] = value ?? "4"; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the label text for the sixth tick mark (5 o'clock/300°).
        /// </summary>
        [Category("Appearance")]
        [Description("Label text for tick mark 6 (5 o'clock)")]
        [DefaultValue("5")]
        public string TickLabel6
        {
            get { return _tickLabels[5]; }
            set { _tickLabels[5] = value ?? "5"; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the custom image used for the rotating knob.
        /// </summary>
        /// <value>The custom knob image, or null to use the default rendered knob.</value>
        /// <remarks>
        /// When set to null, a default gradient knob with an indicator line will be rendered.
        /// Use <see cref="KnobImageRotationOffset"/> to align the image pointer correctly,
        /// and <see cref="KnobImageSizeMultiplier"/> to adjust the image size.
        /// </remarks>
        [Category("Appearance")]
        [Description("Gets or sets the image used for the rotating knob.")]
        public Image KnobImage
        {
            get { return _knobImage; }
            set
            {
                _knobImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotation offset in degrees applied to the knob image.
        /// </summary>
        /// <value>The rotation offset in degrees (0-360). Default is 0.</value>
        /// <remarks>
        /// Use this property to align your custom knob image if the pointer/indicator 
        /// is not at the top (12 o'clock position). For example, if your image's pointer 
        /// is at 90 degrees (3 o'clock), set this to -90 to rotate it to the top.
        /// Values are automatically normalized to the 0-360 range.
        /// </remarks>
        [Category("Appearance")]
        [Description("Gets or sets the rotation offset in degrees applied to the knob image (0-360).")]
        [DefaultValue(0f)]
        public float KnobImageRotationOffset
        {
            get { return _knobImageRotationOffset; }
            set
            {
                _knobImageRotationOffset = value % 360f;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size multiplier for the knob image.
        /// </summary>
        /// <value>The size multiplier (e.g., 1.0 = 100%, 1.5 = 150%, 0.8 = 80%). Default is 1.0.</value>
        /// <remarks>
        /// This property scales the custom knob image relative to the default knob size.
        /// Minimum value is 0.1 (10%) to prevent invisible knobs. Only applies when 
        /// <see cref="KnobImage"/> is not null.
        /// </remarks>
        [Category("Appearance")]
        [Description("Gets or sets the size multiplier for the knob image (e.g., 1.0 = 100%, 1.5 = 150%).")]
        [DefaultValue(1.0f)]
        public float KnobImageSizeMultiplier
        {
            get { return _knobImageSizeMultiplier; }
            set
            {
                _knobImageSizeMultiplier = Math.Max(0.1f, value); // Minimum 10% size
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the <see cref="Value"/> property changes.
        /// </summary>
        /// <remarks>
        /// This event is raised whenever the control value changes through user interaction 
        /// (mouse drag, click, or scroll wheel) or programmatic assignment.
        /// </remarks>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Raises the <see cref="ValueChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RotaryClockControl"/> class.
        /// </summary>
        /// <remarks>
        /// Sets up the control with optimized rendering styles, transparent background support,
        /// and enables mouse wheel interaction without requiring focus.
        /// Default size is 150x150 pixels with a value range of 0-5 and 120-degree rotation (9 o'clock to 5 o'clock).
        /// </remarks>
        public RotaryClockControl()
        {
            SetStyle(ControlStyles.UserPaint | 
                     ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.OptimizedDoubleBuffer | 
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor | 
                     ControlStyles.Selectable, true);

            BackColor = Color.Transparent;
            Size = new Size(150, 150);

            // Enable mouse wheel without requiring focus
            this.MouseWheel += RotaryClockControl_MouseWheel;
        }

        /// <summary>
        /// Handles mouse wheel input when the cursor is over the control.
        /// </summary>
        private void RotaryClockControl_MouseWheel(object sender, MouseEventArgs e)
        {
            // Handle mouse wheel when mouse is over control (even without focus)
            if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                float delta = e.Delta > 0 ? 0.5f : -0.5f;
                Value += delta;
            }
        }

        /// <summary>
        /// Raises the <see cref="Control.OnMouseEnter"/> event and sets focus to enable mouse wheel interaction.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Grab focus when mouse enters so mouse wheel works immediately
            this.Focus();
        }

        /// <summary>
        /// Raises the <see cref="Control.OnPaint"/> event and renders the control.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// This method draws the tick marks, numeric labels, and the knob (either custom image or default).
        /// All rendering uses anti-aliasing for smooth appearance.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Calculate center and radius
            int centerX = Width / 2;
            int centerY = Height / 2;
            int radius = Math.Min(Width, Height) / 2 - 20; // Leave margin for labels

            // Draw tick marks and labels
            DrawTickMarksAndLabels(g, centerX, centerY, radius);

            // Draw the knob
            DrawKnob(g, centerX, centerY, radius);
        }

        private void DrawTickMarksAndLabels(Graphics g, int centerX, int centerY, int radius)
        {
            int tickCount = 6; // 6 tick marks
            float totalAngleRange = NormalizeAngle(_endAngle - _startAngle);

            using (Pen tickPen = new Pen(ForeColor, 2f))
            using (Font labelFont = new Font(Font.FontFamily, Font.Size * 0.8f))
            using (Brush labelBrush = new SolidBrush(ForeColor))
            {
                for (int i = 0; i < tickCount; i++)
                {
                    float angle = _startAngle + (totalAngleRange * i / (tickCount - 1));
                    // Adjust angle so 0° is at top (subtract 90° to convert from standard angle to visual angle)
                    float angleRad = (angle - 90f) * (float)Math.PI / 180f;

                    // Draw tick mark
                    int tickOuterRadius = radius + 5;
                    int tickInnerRadius = radius - 5;

                    float x1 = centerX + (float)Math.Cos(angleRad) * tickInnerRadius;
                    float y1 = centerY + (float)Math.Sin(angleRad) * tickInnerRadius;
                    float x2 = centerX + (float)Math.Cos(angleRad) * tickOuterRadius;
                    float y2 = centerY + (float)Math.Sin(angleRad) * tickOuterRadius;

                    g.DrawLine(tickPen, x1, y1, x2, y2);

                    // Draw label for each tick
                    string label = _tickLabels[i];
                    SizeF labelSize = g.MeasureString(label, labelFont);

                    float labelRadius = tickOuterRadius + 10;
                    float labelX = centerX + (float)Math.Cos(angleRad) * labelRadius - labelSize.Width / 2;
                    float labelY = centerY + (float)Math.Sin(angleRad) * labelRadius - labelSize.Height / 2;

                    g.DrawString(label, labelFont, labelBrush, labelX, labelY);
                }
            }
        }

        private void DrawKnob(Graphics g, int centerX, int centerY, int radius)
        {
            int knobSize = (int)(radius * 1.2f);

            // Calculate current angle based on value
            float totalAngleRange = NormalizeAngle(_endAngle - _startAngle);
            float valuePercent = (_value - _minimum) / (_maximum - _minimum);
            float currentAngle = _startAngle + (totalAngleRange * valuePercent);

            // Save graphics state
            GraphicsState state = g.Save();

            // Translate to center and rotate
            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(currentAngle + _knobImageRotationOffset);

            if (_knobImage != null)
            {
                // Draw the custom knob image with size multiplier
                int imgSize = (int)(knobSize * _knobImageSizeMultiplier);
                g.DrawImage(_knobImage, -imgSize / 2, -imgSize / 2, imgSize, imgSize);
            }
            else
            {
                // Draw default knob
                DrawDefaultKnob(g, knobSize);
            }

            // Restore graphics state
            g.Restore(state);
        }

        private void DrawDefaultKnob(Graphics g, int knobSize)
        {
            int size = knobSize;
            Rectangle knobRect = new Rectangle(-size / 2, -size / 2, size, size);

            // Draw knob body with gradient
            using (LinearGradientBrush gradBrush = new LinearGradientBrush(
                knobRect, 
                Color.FromArgb(200, 200, 200), 
                Color.FromArgb(100, 100, 100), 
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillEllipse(gradBrush, knobRect);
            }

            // Draw border
            using (Pen borderPen = new Pen(Color.FromArgb(60, 60, 60), 2f))
            {
                g.DrawEllipse(borderPen, knobRect);
            }

            // Draw indicator line pointing up
            using (Pen indicatorPen = new Pen(Color.Red, 3f))
            {
                g.DrawLine(indicatorPen, 0, 0, 0, -size / 2 + 5);
            }

            // Draw center dot
            int dotSize = size / 8;
            Rectangle dotRect = new Rectangle(-dotSize / 2, -dotSize / 2, dotSize, dotSize);
            using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(40, 40, 40)))
            {
                g.FillEllipse(dotBrush, dotRect);
            }
        }

        private float NormalizeAngle(float angle)
        {
            // Handle wrapping around 360 degrees
            if (angle < 0)
                angle += 360;
            return angle;
        }

        #region Mouse Handling

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePosition = e.Location;
                UpdateValueFromMouse(e.Location);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_isDragging)
            {
                UpdateValueFromMouse(e.Location);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isDragging = false;
        }

        private void UpdateValueFromMouse(Point mousePos)
        {
            int centerX = Width / 2;
            int centerY = Height / 2;

            // Calculate angle from center to mouse position
            float dx = mousePos.X - centerX;
            float dy = mousePos.Y - centerY;
            float angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);

            // Add 90° to convert from standard angle (0° = right) to visual angle (0° = top)
            angle += 90f;

            // Normalize angle to 0-360
            if (angle < 0) angle += 360;
            if (angle >= 360) angle -= 360;

            // Map angle to value
            float totalAngleRange = NormalizeAngle(_endAngle - _startAngle);
            float normalizedStartAngle = _startAngle;

            // Calculate the relative position within the valid range
            float relativeAngle = NormalizeAngle(angle - normalizedStartAngle);

            // Clamp to valid range
            if (relativeAngle > totalAngleRange && relativeAngle < 180)
                relativeAngle = totalAngleRange;
            else if (relativeAngle > 180)
                relativeAngle = 0;

            // Convert to value
            float percent = relativeAngle / totalAngleRange;
            Value = _minimum + (_maximum - _minimum) * percent;
        }

        #endregion
    }
}
