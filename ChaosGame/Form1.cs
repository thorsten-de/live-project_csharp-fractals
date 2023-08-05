using System.Diagnostics;

namespace ChaosGame
{
    public partial class Form1 : Form
    {

        private bool Drawing = false;
        private Random rand = new Random();
        private int NumDotsDrawn = 0;

        private Bitmap ChaosBitmap = null!;

        private PointF[] Points = null!;
        private PointF CurrentPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (Drawing)
                Stop();
            else
                Start();
        }

        private void Start()
        {
            Drawing = true;
            startButton.Text = "Stop";
            int width = chaosPictureBox.ClientSize.Width;
            int height = chaosPictureBox.ClientSize.Height;
            ChaosBitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(ChaosBitmap))
            {
                g.Clear(Color.Black);
            }
            chaosPictureBox.Image = ChaosBitmap;

            float halfSize = Math.Min(width, height) / 2f - 10;
            PointF center = new PointF(width / 2f, height / 2f);

            Points = new PointF[] {
                new PointF(center.X - halfSize, center.Y + halfSize),
                new PointF(center.X + halfSize, center.Y + halfSize),
                new PointF(center.X, center.Y - halfSize),
            };

            CurrentPoint = center;
            NumDotsDrawn = 0;
            dotsTimer.Start();
        }

        private void Stop()
        {
            Drawing = false;
            dotsTimer.Stop();
            startButton.Text = "Start";
        }

        private const int LoopCount = 100;

        private void dotsTimer_Tick(object sender, EventArgs e)
        {
            if (!Drawing)
            {
                dotsTimer.Stop();
                Debug.WriteLine("{0} dots drawn.", NumDotsDrawn);
                return;
            }

            for (int i = 0; i < LoopCount; i++)
                DrawDot();

            NumDotsDrawn += LoopCount;
            chaosPictureBox.Refresh();
        }

        private static readonly Color ForeColor = Color.Red;
        private void DrawDot()
        {
            PointF controlPoint = Points[rand.Next(0, Points.Length)];
            SizeF delta = new SizeF((controlPoint.X - CurrentPoint.X) / 2f, (controlPoint.Y - CurrentPoint.Y) / 2f);
            CurrentPoint = PointF.Add(CurrentPoint, delta);
            ChaosBitmap.SetPixel((int)CurrentPoint.X, (int)CurrentPoint.Y, ForeColor);
        }
    }
}