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
        public Pen Pen { get; } = Pens.Red;

        public Form1()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            int depth = ConvertInput(depthTextBox, int.Parse);
            if (depth < 0 || depth > 8)
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
            
            PointF origin = new PointF(10, 2 * height / 3);

            DrawKochCurve(g, depth, 0, width - 20, ref origin);
            
            curvePictureBox.Image = bitmap;        
        }

        private T ConvertInput<T>(TextBox textBox, Func<string, T> converter) => 
            converter(textBox.Text);

        private static double DegreesToRadiants(double deg) => deg * Math.PI / 180;

        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Draw tree fractal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
        }

        private static readonly double[] _turns = new double[] {0, DegreesToRadiants(-60), DegreesToRadiants(60), 0 };

        private void DrawKochCurve(Graphics g, int depth, double angle, float length, ref PointF pos)
        { 
            if (depth < 1)
            {

                PointF destination = CalculateDestination(pos, angle, length);
                g.DrawLine(Pen, pos, destination);
                pos = destination;
                return;
            }

            float newLength = length / 3.0f;            
            foreach (var turnAngle in _turns)
                DrawKochCurve(g, depth - 1, angle + turnAngle, newLength, ref pos);
        }


        private static PointF CalculateDestination(PointF pos, double angle, float length)
        {
            var delta=  new SizeF(
                (float)(length * Math.Cos(angle)),
                (float)(length * Math.Sin(angle)));
            return PointF.Add(pos, delta);
        }
    }
}
