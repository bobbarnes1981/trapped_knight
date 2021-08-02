using System.Collections.Generic;
using System.Drawing;

namespace TrappedKnight
{
    interface IMoveFilter
    {
        Point FilterMoves(Point[] moves, int[,] grid, Point defaultMove, List<Point> history);
    }
}
