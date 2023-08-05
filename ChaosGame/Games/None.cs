using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGame.Games
{
    internal class None : IChaosGame
    {
        public Color ForeColor => Color.Snow;

        public PointF[] GenerateControlPoints(PointF center, float halfSize) =>
            new PointF[]{
                new PointF(center.X - halfSize, center.Y - halfSize),
                new PointF(center.X + halfSize, center.Y - halfSize),
                new PointF(center.X - halfSize, center.Y + halfSize),
                new PointF(center.X + halfSize, center.Y + halfSize),
            };

        public override string ToString()
        {
            return "None";
        }
    }
}
