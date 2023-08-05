namespace ChaosGame.Games
{
    internal abstract class SquareGame: IChaosGame
    {
        public Color ForeColor => Color.Snow;

        public PointF[] GenerateControlPoints(PointF center, float halfSize) =>
            new PointF[]{
                new PointF(center.X - halfSize, center.Y - halfSize),
                new PointF(center.X + halfSize, center.Y - halfSize),
                new PointF(center.X - halfSize, center.Y + halfSize),
                new PointF(center.X + halfSize, center.Y + halfSize),
            };

        public abstract bool ShouldDrawPoint(int index, PointF pos);
    }
}