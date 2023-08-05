using ChaosGame.Games;
using System.Diagnostics;

namespace ChaosGame
{
    public partial class Form1 : Form
    {

        private bool Drawing = false;
        private Random rand = new Random();
        private int NumDotsDrawn = 0;

        private Bitmap ChaosBitmap = null!;

        private IChaosGame? chaosGame = null!;
        private IChaosGame[] knownGames = new IChaosGame[]
        {
            new Original(),
            new None(),
            new Restriction1(),
        };

        private PointF[] Points = null!;
        private PointF CurrentPoint;

        public Form1()
        {
            InitializeComponent();

            foreach (IChaosGame game in knownGames)
                restrictionComboBox.Items.Add(game);

            restrictionComboBox.SelectedItem = knownGames.Last();
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
            chaosGame = restrictionComboBox.SelectedItem as IChaosGame;
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

            Points = chaosGame.GenerateControlPoints(center, halfSize);

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

            chaosPictureBox.Refresh();
        }

        private void DrawDot()
        {
            int index = rand.Next(0, Points.Length);
            PointF controlPoint = Points[index];
            SizeF delta = new SizeF((controlPoint.X - CurrentPoint.X) / 2f, (controlPoint.Y - CurrentPoint.Y) / 2f);
            var possiblePoint = PointF.Add(CurrentPoint, delta);

            if (chaosGame.ShouldDrawPoint(index, possiblePoint))
            {
                CurrentPoint = possiblePoint;
                ChaosBitmap.SetPixel((int)CurrentPoint.X, (int)CurrentPoint.Y, chaosGame.ForeColor);
                NumDotsDrawn++;
            }
        }
    }
}