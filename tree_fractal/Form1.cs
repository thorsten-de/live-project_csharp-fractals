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

namespace tree_fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {


            double angle1 = ConvertInput(angle1TextBox, double.Parse);
            double angle2 = ConvertInput(angle2TextBox, double.Parse);

            float length = ConvertInput(lengthTextBox, float.Parse);
            float scale = ConvertInput(scaleTextBox, float.Parse);

            int depth = ConvertInput(depthTextBox, int.Parse);
            if (depth < 1 || depth > 20)
            {
                ShowValidationError("Depth must be between 1 and 20");
                return;
            }

            DrawTreeFractal(DegreesToRadiants(angle1), DegreesToRadiants(angle2), length, scale, depth);

        }

        private T ConvertInput<T>(TextBox textBox, Func<string, T> converter) => 
            converter(textBox.Text);

        private double DegreesToRadiants(double deg) => deg * Math.PI / 180;

        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Draw tree fractal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
        }
        
        private void DrawTreeFractal(double angle1, double angle2, float length, float scale, int depth)
        {
            int width = curvePictureBox.ClientSize.Width;
            int height = curvePictureBox.ClientSize.Height;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap); 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(curvePictureBox.BackColor);


            DrawBranch(g, depth, scale, angle1, angle2, DegreesToRadiants(-90), length, new PointF(width / 2, height - 10));

            curvePictureBox.Image = bitmap;        
        }

        private void DrawBranch(Graphics g, int depth, float scale, double angle1, double angle2, double currentAngle, float currentLength, PointF current)
        {
            if (depth == 0)
                return;
            
            SizeF delta = new SizeF(
                (float)(currentLength * Math.Cos(currentAngle)),
                (float)(currentLength * Math.Sin(currentAngle)));

            PointF destination = PointF.Add(current, delta);
            g.DrawLine(Pens.Green, current, destination);

            DrawBranch(g, depth - 1, scale, angle1, angle2, currentAngle + angle1, currentLength * scale, destination);
            DrawBranch(g, depth - 1, scale, angle1, angle2, currentAngle + angle2, currentLength * scale, destination);
        }
    }
}
