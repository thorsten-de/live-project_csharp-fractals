using System.Runtime.InteropServices;

namespace ChaosGame.Games
{
    internal abstract class SquareGame : IChaosGame
    {
        protected int _lastIndex = -1;
        public Color ForeColor => Color.Snow;
        protected PointF _center;

        public PointF[] GenerateControlPoints(PointF center, float halfSize)
        {
            _center = center;
            return new PointF[]{
                new PointF(center.X - halfSize, center.Y - halfSize),
                new PointF(center.X + halfSize, center.Y - halfSize),
                new PointF(center.X + halfSize, center.Y + halfSize),
                new PointF(center.X - halfSize, center.Y + halfSize),
            };
        }

        public bool ShouldDrawPoint(int index, PointF pos)
        {
            if (IsRestricted(index, pos))
                return false;

            _lastIndex = index;
            return true;
        }

        public abstract bool IsRestricted(int index, PointF pos);
    }

    internal class Restriction1: SquareGame
    {
        public override bool IsRestricted(int index, PointF pos) => 
            _lastIndex == index;

        public override string ToString() => "1";
    }
    
    internal class Restriction2: SquareGame
    {
        public override bool IsRestricted(int index, PointF pos) =>
            index == (_lastIndex + 1) % 4;

        public override string ToString() => "2";
    }

    internal class Restriction3 : SquareGame
    {
        private float _distance;

        public Restriction3(float distance)
        {
            _distance = distance;
        }

        public override bool IsRestricted(int index, PointF pos) =>
            DistanceToCenter(pos) <= _distance;

        public override string ToString() => "3";

        private float DistanceToCenter(PointF pos)
        {
            float deltaX = pos.X - _center.X;
            float deltaY = pos.Y - _center.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }

    internal class Restriction4 : SquareGame
    {
        public override bool IsRestricted(int index, PointF pos) =>
            index == (_lastIndex + 2) % 4;

        public override string ToString() => "4";
    }

    internal class Restriction5 : SquareGame
    {
        private int _prevLastIndex = -2;

        public override bool IsRestricted(int index, PointF pos)
        {
            if (_lastIndex == _prevLastIndex &&
                (index == (_lastIndex + 1) % 4 || index == (_lastIndex + 3) % 4))
            {
                return true;
            }
            
            _prevLastIndex = _lastIndex;
            return false;
        }

        public override string ToString() => "5";
    }
}