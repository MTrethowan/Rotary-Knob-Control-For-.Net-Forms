using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class RoundedPictureBox : PictureBox
    {
        public RoundedPictureBox()
        {
            InitializeComponent();
        }

        public RoundedPictureBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private int _cornerRadius = 20;
        private int _borderWidth = 4;
        private Color _borderColor = Color.Blue;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Paint the image first
            base.OnPaint(pe);

            // Enhance drawing with AntiAliasing
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the bounds for the inner border
            Rectangle rect = new Rectangle(
                _borderWidth / 2,
                _borderWidth / 2,
                this.Width - _borderWidth,
                this.Height - _borderWidth);

            // Create the rounded rectangle path
            using (GraphicsPath path = GetRoundedRectangle(rect, _cornerRadius))
            {
                // Draw the border
                using (Pen pen = new Pen(_borderColor, _borderWidth))
                {
                    pe.Graphics.DrawPath(pen, path);
                }
            }

        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Top-left arc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);

            // Top-right arc
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);

            // Bottom-right arc
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);

            // Bottom-left arc
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
