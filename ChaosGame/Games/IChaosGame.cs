using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGame.Games
{
    internal interface IChaosGame
    {
        PointF[] GenerateControlPoints(PointF center, float halfSize);
        Color ForeColor { get; }
    }
}
