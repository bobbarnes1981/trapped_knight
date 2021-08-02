using System.Drawing;

namespace TrappedKnight
{
    class KnightMoveGenerator : IMoveGenerator
    {
        public Point[] GenerateMoves(Point start)
        {
            return new Point[]
            {
                new Point(start.X - 2, start.Y - 1),
                new Point(start.X - 2, start.Y + 1),
                new Point(start.X + 2, start.Y - 1),
                new Point(start.X + 2, start.Y + 1),
                new Point(start.X - 1, start.Y - 2),
                new Point(start.X + 1, start.Y - 2),
                new Point(start.X - 1, start.Y + 2),
                new Point(start.X + 1, start.Y + 2),
           };
        }
    }
}
