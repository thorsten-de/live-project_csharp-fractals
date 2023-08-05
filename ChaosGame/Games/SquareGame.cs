namespace ChaosGame.Games
{
    internal abstract class SquareGame: IChaosGame
    {
        protected int _lastIndex = -1;
        public Color ForeColor => Color.Snow;

        public PointF[] GenerateControlPoints(PointF center, float halfSize) =>
            new PointF[]{
                new PointF(center.X - halfSize, center.Y - halfSize),
                new PointF(center.X + halfSize, center.Y - halfSize),
                new PointF(center.X + halfSize, center.Y + halfSize),
                new PointF(center.X - halfSize, center.Y + halfSize),
            };

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
}