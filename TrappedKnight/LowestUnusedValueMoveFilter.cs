using System.Collections.Generic;
using System.Drawing;

namespace TrappedKnight
{
    class LowestUnusedValueMoveFilter : IMoveFilter
    {
        public Point FilterMoves(Point[] moves, int[,] grid, Point defaultMove, List<Point> history)
        {
            Point nextMove = new Point(defaultMove.X, defaultMove.Y);
            int lowest = int.MaxValue;
            for (int c = 0; c < moves.GetLength(0); c++)
            {
                if (moves[c].X < grid.GetLength(0) && moves[c].Y < grid.GetLength(1) && moves[c].X > -1 && moves[c].Y > -1 && grid[moves[c].X, moves[c].Y] < lowest && history.Contains(new Point(moves[c].X, moves[c].Y)) == false)
                {
                    lowest = grid[moves[c].X, moves[c].Y];
                    nextMove.X = moves[c].X;
                    nextMove.Y = moves[c].Y;
                }
            }

            return nextMove;
        }
    }
}
