using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SierpinskyTriangles
{
    public partial class Form1 : Form
    {
        public Pen Pen { get; } = Pens.Blue;

        public Form1()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            int depth = ConvertInput(depthTextBox, int.Parse);
            if (depth < 1 || depth > 6)
            {
                ShowValidationError("Depth must be between 1 and 6");
                return;
            }

            int width = curvePictureBox.ClientSize.Width;
            int height = curvePictureBox.ClientSize.Height;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(curvePictureBox.BackColor);

            DrawSiepinskyTriangle(g, depth, new PointF(width / 2f, 10), new PointF(10, height - 10), new PointF(width - 10, height - 10));

            curvePictureBox.Image = bitmap;
        }

        private void DrawSiepinskyTriangle(Graphics g, int depth, PointF p1, PointF p2, PointF p3)
        {
            if (depth < 1)
            {
                g.FillPolygon(Brushes.Red, new PointF[] { p1, p2, p3 });
                return;
            }

            PointF half12 = Interpolate(p1, p2);
            PointF half13 = Interpolate(p1, p3);
            PointF half23 = Interpolate(p2, p3);

            DrawSiepinskyTriangle(g, depth - 1, p1, half12, half13);
            DrawSiepinskyTriangle(g, depth - 1, half12, p2, half23);
            DrawSiepinskyTriangle(g, depth - 1, half13, half23, p3);
        }

        private PointF Interpolate(PointF p1, PointF p2, float ratio = 0.5f) =>
            new PointF(
                Interpolate(p1.X, p2.X, ratio),
                Interpolate(p1.Y, p2.Y, ratio));

        private float Interpolate(float f1, float f2, float ratio = 0.5f) => (f1 * ratio) + (f2 * (1 - ratio));

        private T ConvertInput<T>(TextBox textBox, Func<string, T> converter) =>
            converter(textBox.Text);

        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Draw tree fractal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
