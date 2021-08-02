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
        private List<Point> history = new List<Point>();
        private Point knight;
        private Point nextMove;
        private bool calculated = false;
        private int steps;
        private Point[] moves;

        public Point Knight { get { return knight; } }
        public Point[] Moves { get { return moves; } }
        public int GridWidth { get { return gridWidth; } }
        public int GridHeight { get { return gridHeight; } }
        public int[,] Grid { get { return grid; } }
        public Point NextMove { get { return nextMove; } }
        public List<Point> History { get { return history; } }
        public int Steps { get { return steps; } }

        private IMoveGenerator moveGenerator;
        private IGridGenerator gridGenerator;
        private IMoveFilter moveFilter;

        public Simulation(int gridWidth, int gridHeight, IGridGenerator gridGenerator, IMoveGenerator moveGenerator, IMoveFilter moveFilter)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;

            this.gridGenerator = gridGenerator;
            this.moveGenerator = moveGenerator;
            this.moveFilter = moveFilter;

            steps = 0;

            knight = new Point(gridWidth / 2, gridHeight / 2);

            grid = gridGenerator.GenerateGrid(gridWidth, gridHeight);
        }

        public void Calculate()
        {
            if (calculated)
            {
                return;
            }

            moves = moveGenerator.GenerateMoves(knight);

            nextMove = moveFilter.FilterMoves(moves, grid, new Point(knight.X, knight.Y), history);


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
