using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.Threading.Tasks;

namespace escape_time_fractals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Define the colors we will use.
        private Color[] FractalColors =
        {
            Color.Black, Color.Red, Color.Orange, Color.Yellow,
            Color.Green, Color.Cyan, Color.Blue, Color.Fuchsia,
        };
        int NumColors = 0;

        private enum FractalTypes
        {
            Mandelbrot,
            Julia,
            Vortex,
        }
        private FractalTypes FractalType = FractalTypes.Mandelbrot;

        private enum SmoothingTypes
        {
            None,
            Smooth1,
            Smooth2,
        }
        private SmoothingTypes SmoothingType = SmoothingTypes.None;

        // Drawing parameters.
        private int MaxMagnitude;
        private int MaxIterations;
        private Complex Z0, C0;

        // For smooth colors.
        private double LogEscape;

        // The bounds of interest for the different fractals.
        private RectangleF MandelbrotBounds = RectangleF.FromLTRB(-2.20f, -1.2f, 1.0f, 1.2f);
        private RectangleF JuliaBounds = RectangleF.FromLTRB(-1.5f, -1.5f, 1.5f, 1.5f);
        private RectangleF VortexBounds = RectangleF.FromLTRB(-1.5f, -1.5f, 2f, 1.5f);

        // The largest interesting area for the current fractal.
        private RectangleF WorldMaxBounds;

        // The currently selected area.
        private RectangleF WorldBounds;

        // Set some initial values.
        private void Form1_Load(object sender, EventArgs e)
        {
            fractalPictureBox.Cursor = Cursors.Cross;

            // Set drawing parameters.
            NumColors = FractalColors.Length;
            MaxMagnitude = 2;
            MaxIterations = 64;
            Z0 = new Complex(0, 0);
            C0 = new Complex(0, -1);
            LogEscape = Math.Log(MaxMagnitude);

            // Start with the Mandelbrot set.
            WorldMaxBounds = MandelbrotBounds;
            SetWorldBounds(MandelbrotBounds);

            fractalPictureBox.Refresh();
        }

        #region Coordinate systems

        // Set the world coordinate bounds as indicated,
        // adjust the aspect, and redraw the fractal.
        private void SetWorldBounds(RectangleF bounds)
        {
            // Set the world coordinate bounds.
            WorldBounds = bounds;
            AdjustBounds();
            DrawFractal();
        }

        // Adjust the world bounds so they have
        // the same aspect ratio as the PictureBox.
        private void AdjustBounds()
        {
            // Get the current world and device aspect ratios.
            float worldWidth = WorldBounds.Width;
            float worldHeight = WorldBounds.Height;
            float worldAspect = worldWidth / worldHeight;
            float deviceAspect =
                (float)fractalPictureBox.ClientSize.Width /
                (float)fractalPictureBox.ClientSize.Height;

            // Adjust the world sizes.
            if (worldAspect > deviceAspect)
            {
                // Too short and wide. Make taller.
                worldHeight = worldWidth / deviceAspect;
            }
            else
            {
                // Too tall and thin. Make wider.
                worldWidth = worldHeight * deviceAspect;
            }

            // Set the new bounds.
            float cx = WorldBounds.X + WorldBounds.Width / 2f;
            float cy = WorldBounds.Y + WorldBounds.Height / 2f;
            WorldBounds = new RectangleF(
                cx - worldWidth / 2f,
                cy - worldHeight / 2f,
                worldWidth,
                worldHeight);
        }

        // Convert from world to device coordinates.
        private PointF WtoD(PointF point)
        {
            float xscale = (point.X - WorldBounds.X) / WorldBounds.Width;
            float yscale = (point.Y - WorldBounds.Y) / WorldBounds.Height;

            float x = 0 + xscale * fractalPictureBox.ClientSize.Width;
            float y = 0 + yscale * fractalPictureBox.ClientSize.Height;
            return new PointF(x, y);
        }

        // Convert from device to world coordinates.
        private PointF DtoW(PointF point)
        {
            float xscale = (point.X - 0) / fractalPictureBox.ClientSize.Width;
            float yscale = (point.Y - 0) / fractalPictureBox.ClientSize.Height;
            float x = WorldBounds.X + xscale * WorldBounds.Width;
            float y = WorldBounds.Y + yscale * WorldBounds.Height;
            return new PointF(x, y);
        }

        #endregion Coordinate systems

        // Save the current image.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (fractalPictureBox.Image == null) return;
            if (sfdFractal.ShowDialog() == DialogResult.OK)
            {
                fractalPictureBox.Image.SaveImage(sfdFractal.FileName);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuSettingsMandelbrotSet_Click(object sender, EventArgs e)
        {
            SelectFractal(sender, FractalTypes.Mandelbrot);
        }
        private void mnuSettingsJuliaSet_Click(object sender, EventArgs e)
        {
            SelectFractal(sender, FractalTypes.Julia);
        }
        private void mnuSettingsVortexFractal_Click(object sender, EventArgs e)
        {
            SelectFractal(sender, FractalTypes.Vortex);
        }
        private void SelectFractal(object sender, FractalTypes fractalType)
        {
            // Check the correct menu item.
            ToolStripMenuItem[] items =
            {
                mnuSettingsMandelbrotSet,
                mnuSettingsJuliaSet,
                mnuSettingsVortexFractal,
            };
            SelectMenuItem(sender, items);
            FractalType = fractalType;

            // Set the correct max bounds.
            switch (FractalType)
            {
                case FractalTypes.Mandelbrot:
                    WorldMaxBounds = MandelbrotBounds;
                    break;
                case FractalTypes.Julia:
                    WorldMaxBounds = JuliaBounds;
                    break;
                case FractalTypes.Vortex:
                    WorldMaxBounds = VortexBounds;
                    break;
            }

            // Draw the newly selected fractal.
            DrawFractal();
        }

        private void mnuSettingsNoSmoothing_Click(object sender, EventArgs e)
        {
            SelectSmoothing(sender, SmoothingTypes.None);
        }
        private void mnuSettingsSmooth1_Click(object sender, EventArgs e)
        {
            SelectSmoothing(sender, SmoothingTypes.Smooth1);
        }

        private void mnuSettingsSmooth2_Click(object sender, EventArgs e)
        {
            SelectSmoothing(sender, SmoothingTypes.Smooth2);
        }
        private void SelectSmoothing(object sender, SmoothingTypes smoothingType)
        {
            // Check the correct menu item.
            ToolStripMenuItem[] items =
            {
                mnuSettingsNoSmoothing,
                mnuSettingsSmooth1,
                mnuSettingsSmooth2,
            };
            SelectMenuItem(sender, items);
            SmoothingType = smoothingType;

            DrawFractal();
        }

        // Change the maximum number of iterations.
        private void mnuSettingsChangeMaxIterations_Click(object sender, EventArgs e)
        {
            InputForm dlg = new InputForm();
            dlg.Text = "Max Iterations:";
            dlg.captionLabel.Text = "Max Iterations:";
            dlg.valueTextBox.Text = MaxIterations.ToString();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MaxIterations = int.Parse(dlg.valueTextBox.Text);
                DrawFractal();
            }
        }

        private void mnuScaleRedraw_Click(object sender, EventArgs e)
        {
            DrawFractal();
        }

        private void mnuScaleX2_Click(object sender, EventArgs e)
        {
            ScaleOut(2);
        }

        private void mnuScaleX4_Click(object sender, EventArgs e)
        {
            ScaleOut(4);
        }

        private void mnuScaleX8_Click(object sender, EventArgs e)
        {
            ScaleOut(8);
        }

        private void ScaleOut(float scale)
        {
            // Get the world coordinate center.
            float cx = WorldBounds.X + WorldBounds.Width / 2f;
            float cy = WorldBounds.Y + WorldBounds.Height / 2f;

            // Calculate the new width and height.
            float width = WorldBounds.Width * scale;
            float height = WorldBounds.Height * scale;

            // Set the new world bounds.
            WorldBounds = new RectangleF(
                cx - width / 2,
                cy - height / 2,
                width, height);

            // Redraw.
            DrawFractal();
        }

        private void mnuScaleFullScale_Click(object sender, EventArgs e)
        {
            switch (FractalType)
            {
                case FractalTypes.Mandelbrot:
                    WorldBounds = MandelbrotBounds;
                    break;
                case FractalTypes.Julia:
                    WorldBounds = JuliaBounds;
                    break;
                case FractalTypes.Vortex:
                    WorldBounds = VortexBounds;
                    break;
            }
            DrawFractal();
        }

        private void mnuScaleEnterSelectedArea_Click(object sender, EventArgs e)
        {
            InputForm dlg = new InputForm();
            dlg.Text = "Area to Select";
            dlg.captionLabel.Text = "xmin, ymin, xmax, ymax:";
            dlg.valueTextBox.Text =
                string.Format("{0}, {1}, {2}, {3}",
                    WorldBounds.Left, WorldBounds.Top,
                    WorldBounds.Right, WorldBounds.Bottom);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] fields = dlg.valueTextBox.Text.Split(',');
                float xmin = float.Parse(fields[0]);
                float ymin = float.Parse(fields[1]);
                float xmax = float.Parse(fields[2]);
                float ymax = float.Parse(fields[3]);
                WorldBounds = new RectangleF(xmin, ymin, xmax - xmin, ymax - ymin);
                DrawFractal();
            }
        }

        // Check the selected menu item and uncheck the others.
        private void SelectMenuItem(object sender, ToolStripMenuItem[] items)
        {
            ToolStripMenuItem selected = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem item in items)
                item.Checked = (item == selected);
        }

        #region Mouse events

        private Point StartPoint, EndPoint;
        private bool SelectingArea = false;

        // Start selecting an area.
        private void fractalPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            EndPoint = e.Location;

            fractalPictureBox.MouseMove += fractalPictureBox_MouseMove;
            fractalPictureBox.MouseUp += fractalPictureBox_MouseUp;

            SelectingArea = true;
            fractalPictureBox.Refresh();
        }


        // Continue selecting an area.
        private void fractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            EndPoint = e.Location;
            fractalPictureBox.Refresh();
        }

        // Finish selecting an area.
        private void fractalPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            SelectingArea = false;
            fractalPictureBox.MouseMove -= fractalPictureBox_MouseMove;
            fractalPictureBox.MouseUp -= fractalPictureBox_MouseUp;

            // Set the new world coordinate bounds.
            PointF wStartPoint = DtoW(StartPoint);
            PointF wEndPoint = DtoW(EndPoint);
            SetWorldBounds(wStartPoint.ToRectangle(wEndPoint));
        }

        // Draw the selection rectangle on top of the fractal.
        private void fractalPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (SelectingArea)
            {
                e.Graphics.DrawDashedBox(Color.Red, Color.Yellow,
                    2, 5, StartPoint, EndPoint);
            }
        }

        #endregion Mouse events

        #region Fractal drawing

        // Draw the selected fractal.
        private void DrawFractal()
        {
            // Hide any previous result.
            fractalPictureBox.Image = null;
            fractalPictureBox.Refresh();
            Cursor = Cursors.WaitCursor;

            // Make sure the aspect ratios match.
            AdjustBounds();

            // Find the X and Y scale factors.
            float dx = WorldBounds.Width /
                fractalPictureBox.ClientRectangle.Width;
            float dy = WorldBounds.Height /
                fractalPictureBox.ClientRectangle.Height;

            // Make the bitmap.
            int width = fractalPictureBox.ClientSize.Width;
            int height = fractalPictureBox.ClientSize.Height;
            Bitmap bm = new Bitmap(width, height);

            // Make a Bitmap32 object to manipulate pixels quickly.
            Bitmap32 bm32 = new Bitmap32(bm);
            bm32.LockBitmap();

            var stopwatch = Stopwatch.StartNew();
            // Draw the fractal.
            // (x, y) will be the corresponding point in world coordinates.
            //float y = WorldBounds.Y;

            // Loop over the pixels.

            Parallel.For(0, height, iy =>
            //for (int iy = 0; iy < height; iy++)
            {
                float y = DtoW(new PointF(0, iy)).Y;
                float x = WorldBounds.X;
                for (int ix = 0; ix < width; ix++)
                {
                    // Device coordinate point (ix, iy) corresponds
                    // to world coordinate point (x, y).

                    // Calculate the color for this point.
                    Complex z = new Complex();
                    Complex c = new Complex();
                    int stepNum = 0;
                    switch (FractalType)
                    {
                        case FractalTypes.Mandelbrot:
                            OptimizedMandelbrotPoint(x, y, out z, out c, out stepNum);
                            break;
                        case FractalTypes.Julia:
                            JuliaPoint(x, y, out z, out c, out stepNum);
                            break;
                        case FractalTypes.Vortex:
                            VortexPoint(x, y, out z, out c, out stepNum);
                            break;
                    }

                    // Set the pixel's color.
                    ColorPixel(bm32, ix, iy, z, c, stepNum);

                    // Move to the next point in world coordinates.
                    x += dx;
                }

                // Move to the next row in world coordinates.
             //   y += dy;
            });


            stopwatch.Stop();
            Console.Write(string.Format("{0}, {1}, {2}, {3} - ",
                WorldBounds.Left, WorldBounds.Top,
                WorldBounds.Right, WorldBounds.Bottom));
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms to compute ({fractalPictureBox.ClientSize}, MaxIterations={MaxIterations}");

            // Unlock the Bitmap32.
            bm32.UnlockBitmap();

            // Display the result.
            fractalPictureBox.Image = bm;
            Cursor = Cursors.Default;
        }

        // Calculate the Mandelbrot set values for this point.
        private void MandelbrotPoint(double x, double y,
            out Complex z, out Complex c, out int stepNum)
        {
            // Replace the following with your code.
            z = Z0;
            c = new Complex(x, y);
            stepNum = 0;
             
            while (stepNum < MaxIterations && z.Magnitude < MaxMagnitude)
            {
                z = z * z + c;
                stepNum++;
            }
        }

        // Calculate the Mandelbrot set values for this point.
        private void OptimizedMandelbrotPoint(double x0, double y0,
            out Complex z, out Complex c, out int stepNum)
        {
            // Replace the following with your code.
            double x2 = 0, x = 0;
            double y2= 0, y = 0;
            stepNum = 0;

            while (stepNum < MaxIterations && x2 + y2 <= 4)
            {
                y = (x + x) * y + y0;
                x = x2 - y2 + x0;
                x2 = x * x;
                y2 = y * y;

                stepNum++;
            }

            z = new Complex(x, y);
            c = new Complex(x0, y0);
        }



        // Calculate the Julia set values for this point.
        private void JuliaPoint(double x, double y,
            out Complex z, out Complex c, out int stepNum)
        {
            // Replace the following with your code.
            z = new Complex();
            c = new Complex();
            stepNum = 0;
        }

        // Calculate the vortex fractal values for this point.
        private void VortexPoint(double x, double y,
            out Complex z, out Complex c, out int stepNum)
        {
            // Replace the following with your code.
            z = new Complex();
            c = new Complex();
            stepNum = 0;
        }

        // Set the pixel's color according to the
        // current smoothing model.
        private void ColorPixel(Bitmap32 bm32, int ix, int iy,
            Complex z, Complex c, int stepNum)
        {
            if (stepNum >= MaxIterations)
                stepNum = 0;

            Color color = SmoothingType == SmoothingTypes.None
                ? FractalColors[stepNum % NumColors]
                : SmoothColor(z, c, stepNum);

            bm32.SetPixel(ix, iy, color.R, color.G, color.B, 255);
        }

        // Return a smooth mandelbrot color.
        // See http://csharphelper.com/blog/2014/07/draw-a-mandelbrot-set-fractal-with-smoothly-shaded-colors-in-c/
        private Color SmoothColor(Complex z, Complex c, int stepNum)
        {
            // Replace the following with your code.
            return Color.Black;
        }

        private Color MuToColor(double mu)
        {
            // Replace the following with your code.
            return Color.Black;
        }

        #endregion Fractal drawing
    }
}
