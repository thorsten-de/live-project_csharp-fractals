using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGame.Games
{
    internal class Restriction1 : SquareGame
    {
        private int lastIndex = -1;

        public override bool ShouldDrawPoint(int index, PointF pos)
        {
            if (index == lastIndex)
                return false;

            lastIndex = index;
            return true;
        }

        public override string ToString() => "1";
    }
}
