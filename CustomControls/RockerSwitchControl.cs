// ==============================================================================
// RockerSwitchControl.cs
// ==============================================================================
// 
// Project:      CustomControls
// Description:  A customizable rocker switch control for Windows Forms
// 
// Author:       Mike Trethowan
// Created:      2025-01-13
// Modified:     2025-01-13
// Version:      1.2.0
// 
// Copyright (c) 2025 Mike Trethowan. All rights reserved.
// 
// License:      MIT License
//               See LICENSE file in the project root for full license information.
// 
// Dependencies: .NET Framework 4.8.1+
//               System.Windows.Forms
//               System.Drawing
// 
// Notes:        This control is a two-state rocker switch that can use custom images
//               or default procedural rendering with configurable colors.
//               Text position is adjustable via TextOffsetX and TextOffsetY properties.
//               Supports both horizontal and vertical orientations.
//               Optional IEC 60417 standard symbols (I = ON, O = OFF).
// 
// Change Log:
//   v1.2.0 - 2025-01-13 - Added IEC standard symbols
//            - New ShowStandardSymbols property for I/O display
//            - Automatic contrast color selection for symbol visibility
//            - Symbols properly positioned for both orientations
//   v1.1.0 - 2025-01-13 - Added orientation support
//            - New Orientation property (Horizontal/Vertical)
//            - Vertical text positioning for vertical orientation
//            - Improved painting logic for both orientations
//   v1.0.0 - 2025-01-13 - Initial release
//            - Basic rocker switch functionality
//            - Custom image support (Active/Deactive states)
//            - Two-tone color rendering
//            - Adjustable text positioning
//            - CheckBox-based implementation
// ==============================================================================
// ==============================================================================

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace CustomControls
{
    /// <summary>
    /// Specifies the orientation of the rocker switch control.
    /// </summary>
    public enum RockerSwitchOrientation
    {
        /// <summary>
        /// Horizontal orientation (default) - switch toggles left-to-right.
        /// </summary>
        Horizontal = 0,

        /// <summary>
        /// Vertical orientation - switch toggles top-to-bottom (90° counterclockwise rotation).
        /// When unchecked/off, the bottom position is pressed (down). When checked/on, the top position is pressed (up).
        /// </summary>
        Vertical = 90
    }

    /// <summary>
    /// A rocker switch control with customizable appearance and state colors.
    /// </summary>
    /// <remarks>
    /// This control provides a two-state switch similar to hardware rocker switches,
    /// perfect for on/off controls, audio routing, or any binary state control.
    /// The control supports custom images or default two-tone rendering.
    /// </remarks>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(RockerSwitchControl))]
    [Description("A Rocker Switch control with customizable appearance")]
    [DefaultEvent("CheckedChanged")]
    [DefaultProperty("Checked")]
    public class RockerSwitchControl : CheckBox
    {
        /// <summary>
        /// Gets or sets the color used for the active/on half of the switch when no image is set.
        /// </summary>
        /// <remarks>
        /// This color is used for the right half when Checked=true, or left half when Checked=false.
        /// Only applies when custom images are not provided.
        /// </remarks>
        [Category("Appearance")]
        [Description("The color used for the active/on half of the switch when no image is set.")]
        public Color ActiveColor { get; set; } = Color.LightGray;

        /// <summary>
        /// Gets or sets the color used for the inactive/off half of the switch when no image is set.
        /// </summary>
        /// <remarks>
        /// This color is used for the left half when Checked=true, or right half when Checked=false.
        /// Only applies when custom images are not provided.
        /// </remarks>
        [Category("Appearance")]
        [Description("The color used for the inactive/off half of the switch when no image is set.")]
        public Color DeactiveColor { get; set; } = Color.FromArgb(80, 80, 80); // Dark Gray

        /// <summary>
        /// Gets or sets the image displayed when the switch is in the active (Checked) state.
        /// </summary>
        /// <remarks>
        /// When set, this image overrides the default two-tone rendering for the checked state.
        /// Set to null to use the default rendering with ActiveColor and DeactiveColor.
        /// </remarks>
        [Category("Appearance")]
        [Description("The image displayed when the switch is in the active (Checked) state.")]
        public Image ActiveImage { get; set; } = null;

        /// <summary>
        /// Gets or sets the image displayed when the switch is in the inactive (Unchecked) state.
        /// </summary>
        /// <remarks>
        /// When set, this image overrides the default two-tone rendering for the unchecked state.
        /// Set to null to use the default rendering with ActiveColor and DeactiveColor.
        /// </remarks>
        [Category("Appearance")]
        [Description("The image displayed when the switch is in the inactive (Unchecked) state.")]
        public Image DeactiveImage { get; set; } = null;

        /// <summary>
        /// Gets or sets the orientation of the rocker switch.
        /// </summary>
        /// <remarks>
        /// Horizontal orientation (default) renders the switch left-to-right.
        /// Vertical orientation renders the switch top-to-bottom (90° counterclockwise).
        /// In vertical mode, OFF/unchecked is down (bottom), ON/checked is up (top).
        /// Changing orientation at runtime will trigger a repaint.
        /// </remarks>
        [Category("Appearance")]
        [Description("The orientation of the rocker switch (Horizontal or Vertical).")]
        [DefaultValue(RockerSwitchOrientation.Horizontal)]
        public RockerSwitchOrientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    this.Invalidate(); // Trigger repaint
                }
            }
        }
        private RockerSwitchOrientation _orientation = RockerSwitchOrientation.Horizontal;

        /// <summary>
        /// Gets or sets whether to display IEC 60417 standard symbols (I = ON, O = OFF) on the switch.
        /// </summary>
        /// <remarks>
        /// When enabled, displays "I" (line) for ON and "O" (circle) for OFF according to 
        /// international standards. Symbols automatically rotate for vertical orientation.
        /// Only applies when custom images are not used.
        /// </remarks>
        [Category("Appearance")]
        [Description("Display IEC standard symbols: I (ON) and O (OFF) on the switch.")]
        [DefaultValue(true)]
        public bool ShowStandardSymbols
        {
            get => _showStandardSymbols;
            set
            {
                if (_showStandardSymbols != value)
                {
                    _showStandardSymbols = value;
                    this.Invalidate();
                }
            }
        }
        private bool _showStandardSymbols = true;

        /// <summary>
        /// Gets or sets the horizontal offset for the text label.
        /// </summary>
        /// <remarks>
        /// Positive values move text to the right, negative values move it to the left.
        /// Default is 0 (centered horizontally).
        /// </remarks>
        [Category("Appearance")]
        [Description("Horizontal offset in pixels for the text label position (positive = right, negative = left).")]
        [DefaultValue(0)]
        public int TextOffsetX { get; set; } = 0;

        /// <summary>
        /// Gets or sets the vertical offset for the text label.
        /// </summary>
        /// <remarks>
        /// Positive values move text down, negative values move it up.
        /// Default is 5 pixels below the bottom of the control (provides padding).
        /// </remarks>
        [Category("Appearance")]
        [Description("Vertical offset in pixels for the text label position (positive = down, negative = up). Default is 5 pixels below control.")]
        [DefaultValue(5)]
        public int TextOffsetY { get; set; } = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="RockerSwitchControl"/> class.
        /// </summary>
        /// <remarks>
        /// Sets up double buffering, custom painting, and default styling for the control.
        /// By default, the control is unchecked (inactive state).
        /// </remarks>
        public RockerSwitchControl()
        {
            // Enable double buffering and custom paint rules
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            // Default horizontal layout button-like proportions
            this.Size = new Size(100, 35);
        }

        /// <summary>
        /// Raises the <see cref="Control.OnPaint"/> event and renders the rocker switch.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// Renders the switch using custom images if provided, otherwise uses a two-tone
        /// split rendering with ActiveColor and DeactiveColor. Text is drawn below the control
        /// with configurable offsets. Supports both horizontal and vertical orientations.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Clear background canvas safely
            OnPaintBackground(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle controlRect = new Rectangle(0, 0, this.Width, this.Height);

            // Check if we should use custom images or fallback to procedural rendering
            if (this.Checked && ActiveImage != null)
            {
                g.DrawImage(ActiveImage, controlRect);
            }
            else if (!this.Checked && DeactiveImage != null)
            {
                g.DrawImage(DeactiveImage, controlRect);
            }
            else
            {
                // Draw the default procedural Two-Tone Rocker Switch illusion
                Rectangle firstHalf, secondHalf;
                Color firstColor, secondColor;

                if (Orientation == RockerSwitchOrientation.Horizontal)
                {
                    // Horizontal orientation: split left/right
                    int halfWidth = this.Width / 2;
                    firstHalf = new Rectangle(0, 0, halfWidth, this.Height);
                    secondHalf = new Rectangle(halfWidth, 0, this.Width - halfWidth, this.Height);

                    if (this.Checked)
                    {
                        // Active State: Right side is active color
                        firstColor = DeactiveColor;
                        secondColor = ActiveColor;
                    }
                    else
                    {
                        // Inactive State: Left side is active color
                        firstColor = ActiveColor;
                        secondColor = DeactiveColor;
                    }
                }
                else // Vertical
                {
                    // Vertical orientation: split top/bottom
                    // Rotated 90° counterclockwise from horizontal, so inactive position is down (bottom)
                    int halfHeight = this.Height / 2;
                    firstHalf = new Rectangle(0, 0, this.Width, halfHeight);
                    secondHalf = new Rectangle(0, halfHeight, this.Width, this.Height - halfHeight);

                    if (this.Checked)
                    {
                        // Active/ON State: Top half is active (rocker pressed up)
                        firstColor = ActiveColor;
                        secondColor = DeactiveColor;
                    }
                    else
                    {
                        // Inactive/OFF State: Bottom half is active (rocker pressed down)
                        firstColor = DeactiveColor;
                        secondColor = ActiveColor;
                    }
                }

                // Fill the split halves
                using (SolidBrush firstBrush = new SolidBrush(firstColor))
                {
                    g.FillRectangle(firstBrush, firstHalf);
                }

                using (SolidBrush secondBrush = new SolidBrush(secondColor))
                {
                    g.FillRectangle(secondBrush, secondHalf);
                }

                // Draw a subtle dividing seam to enhance the rocker illusion
                using (Pen seamPen = new Pen(Color.FromArgb(40, 0, 0, 0), 1))
                {
                    if (Orientation == RockerSwitchOrientation.Horizontal)
                    {
                        int halfWidth = this.Width / 2;
                        g.DrawLine(seamPen, halfWidth, 0, halfWidth, this.Height);
                    }
                    else
                    {
                        int halfHeight = this.Height / 2;
                        g.DrawLine(seamPen, 0, halfHeight, this.Width, halfHeight);
                    }
                }

                // Draw IEC standard symbols (I = ON, O = OFF) if enabled
                if (ShowStandardSymbols)
                {
                    DrawStandardSymbols(g, firstHalf, secondHalf);
                }
            }

            // Draw text based on orientation
            if (!string.IsNullOrEmpty(this.Text))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;

                    RectangleF textRect;

                    if (Orientation == RockerSwitchOrientation.Horizontal)
                    {
                        // Horizontal: text below the switch with padding
                        textRect = new RectangleF(
                            TextOffsetX,                    // Horizontal offset
                            this.Height + TextOffsetY,      // Below control with padding
                            this.Width,
                            this.Font.Height + 10           // Extra space for text
                        );
                    }
                    else
                    {
                        // Vertical: text to the right of the switch
                        textRect = new RectangleF(
                            this.Width + TextOffsetY,       // To right with padding
                            TextOffsetX,                    // Vertical offset
                            this.Font.Height * 3,           // Allow space for text
                            this.Height
                        );
                        sf.LineAlignment = StringAlignment.Center;
                    }

                    // Draw text using parent's graphics context if possible
                    if (this.Parent != null)
                    {
                        using (Graphics parentGraphics = this.Parent.CreateGraphics())
                        {
                            // Calculate position in parent coordinates
                            Point parentPoint = this.Parent.PointToClient(this.PointToScreen(Point.Empty));
                            RectangleF parentTextRect = new RectangleF(
                                parentPoint.X + textRect.X,
                                parentPoint.Y + textRect.Y,
                                textRect.Width,
                                textRect.Height
                            );

                            parentGraphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), parentTextRect, sf);
                        }
                    }
                }
            }

            // Draw focus rectangle indicator for accessibility
            if (this.Focused)
            {
                ControlPaint.DrawFocusRectangle(g, controlRect);
            }
        }

        /// <summary>
        /// Draws the IEC 60417 standard symbols (I = ON, O = OFF) on the rocker switch.
        /// </summary>
        /// <param name="g">The graphics context for drawing.</param>
        /// <param name="firstHalf">The first half rectangle (left for horizontal, top for vertical).</param>
        /// <param name="secondHalf">The second half rectangle (right for horizontal, bottom for vertical).</param>
        private void DrawStandardSymbols(Graphics g, Rectangle firstHalf, Rectangle secondHalf)
        {
            // Use a font size proportional to the control size
            float fontSize = Math.Min(this.Width, this.Height) * 0.3f;
            fontSize = Math.Max(8f, Math.Min(fontSize, 24f)); // Clamp between 8 and 24

            using (Font symbolFont = new Font("Arial", fontSize, FontStyle.Bold))
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                // Determine which symbol goes where based on orientation and state
                string firstSymbol, secondSymbol;
                Color firstSymbolColor, secondSymbolColor;

                if (Orientation == RockerSwitchOrientation.Horizontal)
                {
                    // Horizontal: I on right (ON side), O on left (OFF side)
                    firstSymbol = "O";   // Left side
                    secondSymbol = "I";  // Right side

                    // Make symbols visible: draw in contrasting color
                    firstSymbolColor = GetContrastColor(this.Checked ? DeactiveColor : ActiveColor);
                    secondSymbolColor = GetContrastColor(this.Checked ? ActiveColor : DeactiveColor);
                }
                else
                {
                    // Vertical: I on top (ON side), O on bottom (OFF side)
                    firstSymbol = "I";   // Top side
                    secondSymbol = "O";  // Bottom side

                    // Make symbols visible: draw in contrasting color
                    firstSymbolColor = GetContrastColor(this.Checked ? ActiveColor : DeactiveColor);
                    secondSymbolColor = GetContrastColor(this.Checked ? DeactiveColor : ActiveColor);
                }

                // Draw the symbols
                using (SolidBrush brush1 = new SolidBrush(firstSymbolColor))
                {
                    g.DrawString(firstSymbol, symbolFont, brush1, (RectangleF)firstHalf, sf);
                }

                using (SolidBrush brush2 = new SolidBrush(secondSymbolColor))
                {
                    g.DrawString(secondSymbol, symbolFont, brush2, (RectangleF)secondHalf, sf);
                }
            }
        }

        /// <summary>
        /// Gets a contrasting color (black or white) based on the brightness of the background color.
        /// </summary>
        /// <param name="backgroundColor">The background color to contrast against.</param>
        /// <returns>Black for light backgrounds, white for dark backgrounds.</returns>
        private Color GetContrastColor(Color backgroundColor)
        {
            // Calculate perceived brightness using standard luminance formula
            double brightness = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            return brightness > 0.5 ? Color.Black : Color.White;
        }
    }
}
