using System;
using System.Collections.Generic;
using System.Drawing;

namespace TrappedKnight
{
    class Simulation
    {
        private int gridWidth;
        private int gridHeight;
        private int[,] grid;
        private Point gridCentre;
        private List<Point> history = new List<Point>();
        private Point knight;
        private Point nextMove;
        private bool calculated = false;
        private int steps;
        private int[,] moves;// change to array of points

        public Point Knight { get { return knight; } }
        public int[,] Moves { get { return moves; } }
        public int GridWidth { get { return gridWidth; } }
        public int GridHeight { get { return gridHeight; } }
        public int[,] Grid { get { return grid; } }
        public Point NextMove { get { return nextMove; } }
        public List<Point> History { get { return history; } }
        public int Steps { get { return steps; } }

        public Simulation(int gridWidth, int gridHeight)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            this.grid = new int[gridWidth, gridHeight];

            steps = 0;

            initialiseGrid();
        }

        private void initialiseGrid()
        {
            gridCentre = new Point(gridWidth / 2, gridHeight / 2);
            
            knight.X = gridCentre.X;
            knight.Y = gridCentre.Y;

            Point location = new Point(gridCentre.X, gridCentre.Y);

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

                if (location.X >= gridWidth || location.Y >= gridHeight)
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


        }

        public void Calculate()
        {
            if (calculated)
            {
                return;
            }

            moves = new int[,]
            {
                { knight.X - 2, knight.Y - 1 },
                { knight.X - 2, knight.Y + 1 },
                { knight.X + 2, knight.Y - 1 },
                { knight.X + 2, knight.Y + 1 },
                { knight.X - 1, knight.Y - 2 },
                { knight.X + 1, knight.Y - 2 },
                { knight.X - 1, knight.Y + 2 },
                { knight.X + 1, knight.Y + 2 },
            };

            int lowest = int.MaxValue;
            nextMove = new Point(knight.X, knight.Y);

            for (int c = 0; c < moves.GetLength(0); c++)
            {
                if (moves[c, 0] < grid.GetLength(0) && moves[c, 1] < grid.GetLength(1) && moves[c, 0] > -1 && moves[c, 1] > -1 && grid[moves[c, 0], moves[c, 1]] < lowest && history.Contains(new Point(moves[c, 0], moves[c, 1])) == false)
                {
                    lowest = grid[moves[c, 0], moves[c, 1]];
                    nextMove.X = moves[c, 0];
                    nextMove.Y = moves[c, 1];
                }
            }

            calculated = true;
        }

        public bool Step()
        {
            if (knight.X != nextMove.X || knight.Y != nextMove.Y)
            {
                steps += 1;
                history.Add(knight);
                knight.X = nextMove.X;
                knight.Y = nextMove.Y;
                calculated = false;
            }

            return calculated;
        }
    }
}
