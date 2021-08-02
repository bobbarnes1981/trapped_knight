using System.Drawing;

namespace TrappedKnight
{
    class KnightMoveGenerator3 : IMoveGenerator
    {
        public Point[] GenerateMoves(Point start)
        {
            return new Point[]
            {
                new Point(start.X - 4, start.Y - 3),
                new Point(start.X - 4, start.Y + 3),
                new Point(start.X + 4, start.Y - 3),
                new Point(start.X + 4, start.Y + 3),
                new Point(start.X - 2, start.Y - 1),
                new Point(start.X + 2, start.Y - 1),
                new Point(start.X - 2, start.Y + 1),
                new Point(start.X + 2, start.Y + 1),
           };
        }
    }
}
