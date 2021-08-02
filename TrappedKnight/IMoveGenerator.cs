using System.Drawing;

namespace TrappedKnight
{
    interface IMoveGenerator
    {
        Point[] GenerateMoves(Point start);
    }
}
