using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGame.Games
{
    internal class Original : IChaosGame
    {
        public PointF[] GenerateControlPoints(PointF center, float halfSize) =>
            new PointF[] {
                new PointF(center.X - halfSize, center.Y + halfSize),
                new PointF(center.X + halfSize, center.Y + halfSize),
                new PointF(center.X, center.Y - halfSize),
            };

        public override string ToString() => "Original";

        public bool ShouldDrawPoint(int index, PointF pos) => true;

        public Color ForeColor => Color.Red;
    }
}
