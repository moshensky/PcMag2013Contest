using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Engine
    {
        private Cell[,] gameField;
        private List<Cell> cells;

        public Engine()
        {
            gameField = new Cell[500, 500];
            cells = new List<Cell>();
        }

        public void AddFigure(Figure figure)
        {
            foreach (var position in figure)
            {
                int row = position.x;
                int col = position.y;

                if (gameField[row, col] == null)
                {
                    Cell cell = new Cell(row, col);
                    gameField[row, col] = cell;
                    this.cells.Add(cell);
                }
                this.gameField[row, col].Figures.Add(figure);
            }
        }

        public void MoveFigure(Figure figure)
        {
            FindNewPlace(figure);
        }

        private void FindNewPlace(Figure figure)
        {
            // TODO: Flood Algorithm
            Stack<Position> stack = new Stack<Position>();
            Position newFigurePosition;
            int maxDistance = 1000;
            int currentDistance = 0;

            stack.Push(figure.Pos);

            while (stack.Count > 0)
            {
                newFigurePosition = stack.Pop();

                if (IsFreePlace(newFigurePosition))
                {
                    currentDistance = CalculateDistance(figure.Pos, newFigurePosition);
                    if (currentDistance < maxDistance)
                    {
                        maxDistance = currentDistance;
                    }
                }

                stack.Push(new Position(newFigurePosition.x - 1, newFigurePosition.y));
                stack.Push(new Position(newFigurePosition.x + 1, newFigurePosition.y));
                stack.Push(new Position(newFigurePosition.x, newFigurePosition.y - 1));
                stack.Push(new Position(newFigurePosition.x, newFigurePosition.y + 1));
            }
        }

        private int CalculateDistance(Position startingPosition, Position newPosition)
        {
            int distance = 0;
            distance += Math.Abs(startingPosition.x - newPosition.x);
            distance += Math.Abs(startingPosition.y - newPosition.y);
            return distance;
        }

        private bool IsFreePlace(Position newFigurePosition)
        {
            // TODO: implement check for free place on the game field
            return true;
        }

        public virtual void Run()
        {
            // TODO: Implement the logic of the engine
        }
    }
}
