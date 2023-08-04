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

namespace SierpinskyCurves
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
            if (depth < 1 || depth > 8)
            {
                ShowValidationError("Depth must be between 1 and 8");
                return;
            }

            int width = curvePictureBox.ClientSize.Width;
            int height = curvePictureBox.ClientSize.Height;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(curvePictureBox.BackColor);

            float size = Math.Min(width, height) - 20;
            float startLength = (float)(size / (Math.Pow(2, depth + 2) - 1));

            PointF origin = new PointF((width - size) / 2f + startLength, (height - size) / 2f);

            DrawSierpinskyCurve(g, depth, startLength, ref origin);

            curvePictureBox.Image = bitmap;
        }

        private T ConvertInput<T>(TextBox textBox, Func<string, T> converter) =>
            converter(textBox.Text);

        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Draw tree fractal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DrawSierpinskyCurve(Graphics g, int depth, float size, ref PointF pos)
        {
            SegmentTop(g, depth, size, ref pos);
            DrawRelative(g, new SizeF(size, size), ref pos, Pens.Red);
            SegmentRight(g, depth, size, ref pos);
            DrawRelative(g, new SizeF(-size, size), ref pos, Pens.Red);
            SegmentBottom(g, depth, size, ref pos);
            DrawRelative(g, new SizeF(-size, -size), ref pos, Pens.Red);
            SegmentLeft(g, depth, size, ref pos);
            DrawRelative(g, new SizeF(size, -size), ref pos, Pens.Red);
        }

        private void SegmentTop(Graphics g, int depth, float size, ref PointF pos)
        {
            if (depth > 0)
            {
                depth--;
                SegmentTop(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(size, size), ref pos);
                SegmentRight(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(2 * size, 0), ref pos);
                SegmentLeft(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(size, -size), ref pos);
                SegmentTop(g, depth, size, ref pos);
            }
        }
        private void SegmentRight(Graphics g, int depth, float size, ref PointF pos)
        {
            if (depth > 0)
            {
                depth--;
                SegmentRight(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(-size, size), ref pos);
                SegmentBottom(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(0, 2 * size), ref pos);
                SegmentTop(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(size, size), ref pos);
                SegmentRight(g, depth, size, ref pos);
            }
        }
        private void SegmentBottom(Graphics g, int depth, float size, ref PointF pos)
        {
            if (depth > 0)
            {
                depth--;
                SegmentBottom(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(-size, -size), ref pos);
                SegmentLeft(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(-2 * size, 0), ref pos);
                SegmentRight(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(-size, size), ref pos);
                SegmentBottom(g, depth, size, ref pos);
            }
        }

        private void SegmentLeft(Graphics g, int depth, float size, ref PointF pos)
        {
            if (depth > 0)
            {
                depth--;
                SegmentLeft(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(size, -size), ref pos);
                SegmentTop(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(0, -2 * size), ref pos);
                SegmentBottom(g, depth, size, ref pos);
                DrawRelative(g, new SizeF(-size, -size), ref pos);
                SegmentLeft(g, depth, size, ref pos);
            }
        }

        private void DrawRelative(Graphics g, SizeF delta, ref PointF pos, Pen pen = null)
        {
            PointF destination = PointF.Add(pos, delta);
            g.DrawLine(pen ?? Pen, pos, destination);
            pos = destination;
        }
    }
}
