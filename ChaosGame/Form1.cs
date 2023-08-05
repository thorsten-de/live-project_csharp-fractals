namespace ChaosGame
{
    public partial class Form1 : Form
    {

        private bool Drawing = false;
        private Random rand = new Random();
        private int NumDotsDrawn = 0;

        private Bitmap ChaosBitmap = null!;

        private PointF[] Points = null!;
        private PointF? CurrentPoint;

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
    }
}