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
    }
}