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
        private List<Figure> allFigures;

        public Engine()
        {
            gameField = new Cell[500, 500];
            cells = new List<Cell>();
            allFigures = new List<Figure>();
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
            allFigures.Add(figure);
        }

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

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Figures.Contains(figure))
                {
                    cells[i].Figures.Remove(figure);
                }
            }

            allFigures.Remove(figure);
        }

        private Position FindNewPlace(Figure figure)
        {
            List<Position> visited = new List<Position>();
            Stack<Position> stack = new Stack<Position>();
            Position newFigurePosition = new Position();
            Position returnPosition = new Position();
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
                        returnPosition.x = newFigurePosition.x;
                        returnPosition.y = newFigurePosition.y;
                    }
                }

                PushNodesToStack(ref stack, newFigurePosition, figure.Pos, maxDistance, visited);
            }

            return returnPosition;
        }

        private static void PushNodesToStack(ref Stack<Position> stack, Position newFigurePosition,
            Position startingPosition, int maxDistance, List<Position> visited)
        {
            int newPositionsDistance;

            Position westNode = new Position(newFigurePosition.x - 1, newFigurePosition.y);
            newPositionsDistance = CalculateDistance(startingPosition, westNode);
            if ((westNode.x - 1 > 0) && (newPositionsDistance < maxDistance) &&
                (!visited.Contains(westNode)))
            {
                stack.Push(westNode);
                visited.Add(westNode);
            }

            Position eastNode = new Position(newFigurePosition.x + 1, newFigurePosition.y);
            newPositionsDistance = CalculateDistance(startingPosition, eastNode);
            if ((eastNode.x + 1 <= FieldDimension) && (newPositionsDistance < maxDistance) &&
                (!visited.Contains(eastNode)))
            {
                stack.Push(eastNode);
                visited.Add(eastNode);
            }

            Position northNode = new Position(newFigurePosition.x, newFigurePosition.y - 1);
            newPositionsDistance = CalculateDistance(startingPosition, northNode);
            if ((northNode.y - 1 > 0) && (newPositionsDistance < maxDistance) && 
                (!visited.Contains(northNode)))
            {
                stack.Push(new Position(newFigurePosition.x, newFigurePosition.y - 1));
                visited.Add(northNode);
            }

            Position southNode = new Position(newFigurePosition.x, newFigurePosition.y + 1);
            newPositionsDistance = CalculateDistance(startingPosition, southNode);
            if ((southNode.y + 1 <= FieldDimension) && (newPositionsDistance < maxDistance) &&
                (!visited.Contains(southNode)))
            {
                stack.Push(new Position(newFigurePosition.x, newFigurePosition.y + 1));
                visited.Add(southNode);
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
            newFigure.Pos = newFigurePosition;

            foreach (var position in newFigure)
            {
                int row = newFigure.PosX;
                int col = newFigure.PosY;

                if (gameField[row, col] != null && gameField[row, col].HasFigures)
                {
                    isFree = false;
                    break;
                }
            }

            return isFree;
        }

        public void SetFigureOverlapping(Figure figureToSet)
        {
            foreach (var figure in allFigures)
            {
                bool isOverlapped = CheckOverlapping(figureToSet, figure);
                if (isOverlapped)
                {
                    figureToSet.IsOverlapped = true;
                    break;
                }
            }
        }

        private bool CheckOverlapping(Figure firstFigure, Figure secondFigure)
        {
            bool isOverlapped = false;
            foreach (var firstFigurePsition in firstFigure)
            {
                foreach (var secondFigurePosition in secondFigure)
                {
                    if ((firstFigurePsition.x == secondFigurePosition.x) &&
                        (firstFigurePsition.y == secondFigurePosition.y))
                    {
                        isOverlapped = true;
                        break;
                    }
                }
            }

            return isOverlapped;
        }

        public virtual void Run()
        {
            // TODO: Implement the logic of the engine
            for (int i = 0; i < allFigures.Count; i++)
            {
                if (allFigures[i].IsOverlapped)
                {
                    this.MoveFigure(allFigures[i]);
                    allFigures[i].IsOverlapped = false;
                }
            }
        }
    }
}
