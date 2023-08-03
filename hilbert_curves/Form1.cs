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

namespace HilbertCurves
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
            float startLength = (float)(size / (Math.Pow(2, depth) - 1));

            PointF origin = new PointF((width - size) / 2f, (height - size) / 2f);

            DrawHilbertCurve(g, depth, new SizeF(startLength, 0), ref origin);

            curvePictureBox.Image = bitmap;
        }

        private T ConvertInput<T>(TextBox textBox, Func<string, T> converter) =>
            converter(textBox.Text);

        private static double DegreesToRadiants(double deg) => deg * Math.PI / 180;

        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Draw tree fractal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DrawHilbertCurve(Graphics g, int depth, SizeF delta, ref PointF pos)
        {
            if (depth > 1) DrawHilbertCurve(g, depth - 1, new SizeF(delta.Height, delta.Width), ref pos);
            DrawRelative(g, delta, ref pos);
            if (depth > 1) DrawHilbertCurve(g, depth - 1, delta, ref pos);
            DrawRelative(g, new SizeF(delta.Height, delta.Width), ref pos);
            if (depth > 1) DrawHilbertCurve(g, depth - 1, delta, ref pos);
            DrawRelative(g, new SizeF(-delta.Width, -delta.Height), ref pos);
            if (depth > 1) DrawHilbertCurve(g, depth - 1, new SizeF(-delta.Height, -delta.Width), ref pos);
        }

        private void DrawRelative(Graphics g, SizeF delta, ref PointF pos)
        {
            PointF destination = PointF.Add(pos, delta);
            g.DrawLine(Pen, pos, destination);
            pos = destination;
        }
    }
}
