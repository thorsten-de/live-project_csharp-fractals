using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGame.Games
{
    internal class None : SquareGame, IChaosGame
    {
        public override bool ShouldDrawPoint(int index, PointF pos) => true;

        public override string ToString()
        {
            return "None";
        }
    }
}
