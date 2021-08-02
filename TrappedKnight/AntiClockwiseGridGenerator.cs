using System.Drawing;

namespace TrappedKnight
{
    class AntiClockwiseGridGenerator : IGridGenerator
    {
        public int[,] GenerateGrid(int width, int height)
        {
            Point location = new Point(width / 2, height / 2);

            int[,] grid = new int[width, height];

            int counter = 1;

            grid[location.X, location.Y] = counter;
            //Console.WriteLine($"({location.X},{location.Y}) {counter}");
            counter++;

            location.X += 1;

            grid[location.X, location.Y] = counter;
            //Console.WriteLine($"({location.X},{location.Y}) {counter}");
            counter++;

            Direction dir = Direction.North;

            while (true)
            {
                // move next
                switch (dir)
                {
                    case Direction.North:
                        if (grid[location.X - 1, location.Y] == 0)
                        {
                            dir = Direction.West;
                            location.X -= 1;
                        }
                        else
                        {
                            location.Y -= 1;
                        }
                        break;

                    case Direction.West:
                        if (grid[location.X, location.Y + 1] == 0)
                        {
                            dir = Direction.South;
                            location.Y += 1;
                        }
                        else
                        {
                            location.X -= 1;
                        }
                        break;

                    case Direction.South:
                        if (grid[location.X + 1, location.Y] == 0)
                        {
                            dir = Direction.East;
                            location.X += 1;
                        }
                        else
                        {
                            location.Y += 1;
                        }
                        break;

                    case Direction.East:
                        if (grid[location.X, location.Y - 1] == 0)
                        {
                            dir = Direction.North;
                            location.Y -= 1;
                        }
                        else
                        {
                            location.X += 1;
                        }
                        break;
                }

                if (location.X >= width || location.Y >= height)
                {
                    break;
                }

                grid[location.X, location.Y] = counter;
                //                Console.WriteLine($"({location.X},{location.Y}) {counter}");
                counter++;
            }

            //            for (int y = 0; y < gridHeight; y++)
            //            {
            //                for (int x = 0; x < gridWidth; x++)
            //                {
            //                    Console.Write($"{grid[x, y]},");
            //                }
            //                Console.WriteLine();
            //            }

            return grid;
        }
    }
}
