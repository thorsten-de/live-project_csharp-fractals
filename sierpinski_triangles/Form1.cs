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
            g.FillPolygon(Brushes.Red, new PointF[] { p1, p2, p3 });
        }

        private T ConvertInput<T>(TextBox textBox, Func<string, T> converter) =>
            converter(textBox.Text);


        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Draw tree fractal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DrawRelative(Graphics g, SizeF delta, ref PointF pos)
        {
            PointF destination = PointF.Add(pos, delta);
            g.DrawLine(Pen, pos, destination);
            pos = destination;
        }
    }
}
