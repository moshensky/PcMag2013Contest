using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Engine
    {
        public const int MaxFieldDistance = 1000;
        public const int FieldDimension = 500;

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
                (this.gameField[row, col]).Figures.Add(figure);
            }
        }

        /// <summary>
        /// Move the current figure to a new free place on the field
        /// </summary>
        /// <param name="figure">The figure to be moved.</param>
        public void MoveFigure(Figure figure)
        {
            Position newPosition = FindNewPlace(figure);
            this.RemoveFigure(figure);
            figure.Pos = newPosition;
            this.AddFigure(figure);
        }

        private void RemoveFigure(Figure figure)
        {
            foreach (var position in figure)
            {
                gameField[position.x, position.y].Figures.Remove(figure);
            }
            //cells.First(x => x.Figures.Contains(figure)).Figures.Remove(figure);
        }

        /// <summary>
        /// Finding a new place for the figure using the flood fill algorithm
        /// </summary>
        /// <param name="figure">The current figure to be moved</param>
        private Position FindNewPlace(Figure figure)
        {
            Stack<Position> stack = new Stack<Position>();
            Position newFigurePosition = new Position();
            int maxDistance = MaxFieldDistance;
            int currentDistance = 0;

            stack.Push(figure.Pos);

            while (stack.Count > 0)
            {
                newFigurePosition = stack.Pop();

                if (IsFreePlace(figure, newFigurePosition))
                {
                    currentDistance = CalculateDistance(figure.Pos, newFigurePosition);
                    if (currentDistance < maxDistance)
                    {
                        maxDistance = currentDistance;
                    }
                }

                PushNodesToStack(ref stack, newFigurePosition, figure.Pos, maxDistance);
            }

            return newFigurePosition;
        }

        private static void PushNodesToStack(ref Stack<Position> stack, Position newFigurePosition,
            Position startingPosition, int maxDistance)
        {
            int newPositionsDistance;

            newPositionsDistance = CalculateDistance(startingPosition,
                new Position(newFigurePosition.x - 1, newFigurePosition.y));
            if (newFigurePosition.x - 2 > 0 && newPositionsDistance < maxDistance)
            {
                stack.Push(new Position(newFigurePosition.x - 1, newFigurePosition.y));
            }

            newPositionsDistance = CalculateDistance(startingPosition,
                new Position(newFigurePosition.x + 1, newFigurePosition.y));
            if (newFigurePosition.x + 2 <= FieldDimension && newPositionsDistance < maxDistance)
            {
                stack.Push(new Position(newFigurePosition.x + 1, newFigurePosition.y));
            }

            newPositionsDistance = CalculateDistance(startingPosition,
                new Position(newFigurePosition.x, newFigurePosition.y - 1));
            if (newFigurePosition.y - 2 > 0 && newPositionsDistance < maxDistance)
            {
                stack.Push(new Position(newFigurePosition.x, newFigurePosition.y - 1));
            }

            newPositionsDistance = CalculateDistance(startingPosition,
                new Position(newFigurePosition.x, newFigurePosition.y + 1));
            if (newFigurePosition.y + 2 <= FieldDimension && newPositionsDistance < maxDistance)
            {
                stack.Push(new Position(newFigurePosition.x, newFigurePosition.y + 1));
            }
        }

        private static int CalculateDistance(Position startingPosition, Position newPosition)
        {
            int distance = 0;
            distance += Math.Abs(startingPosition.x - newPosition.x);
            distance += Math.Abs(startingPosition.y - newPosition.y);
            return distance;
        }

        private bool IsFreePlace(Figure figureToMove, Position newFigurePosition)
        {
            bool isFree = true;
            Figure newFigure = (Figure)figureToMove.Clone();

            foreach (var position in figureToMove)
            {
                int row = newFigurePosition.x + (position.x - newFigurePosition.x);
                int col = newFigurePosition.y + (position.y - newFigurePosition.y);

                if (gameField[row, col] != null && gameField[row, col].HasFigures)
                {
                    isFree = false;
                    break;
                }
            }

            return isFree;
        }

        public virtual void Run()
        {
            // TODO: Implement the logic of the engine
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Figures.Count; j++)
                {
                    MoveFigure(cells[i].Figures[j]);
                }
            }
        }
    }
}
