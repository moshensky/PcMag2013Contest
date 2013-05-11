using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Figure : IEnumerable<Position>, ICloneable
    {
        protected bool isOverlapped;
        protected Position[] figureOffset;
        private Position pos;

        public int PosX
        {
            get { return this.pos.x; }
            set { this.pos.x = value; }
        }

        public int PosY
        {
            get { return this.pos.y; }
            set { this.pos.y = value; }
        }

        public Position Pos
        {
            get { return this.pos; }
            set
            {
                this.pos = value;
                this.PosX = value.x;
                this.PosY = value.y;
            }
        }

        public bool IsOverlapped 
        {
            get { return this.isOverlapped; }
            set { this.isOverlapped = value; } 
        }

        protected Figure(int posX, int posY)
        {
            this.pos.x = posX;
            this.pos.y = posY;
        }

        protected Figure(Position pos)
        {
            this.pos = pos;
        }

        private class FigurePositions : IEnumerator<Position>
        {
            private int index;
            private Position[] positions;

            public FigurePositions(Position[] figurePositionOffset, Position figureCenterPosition)
            {
                int len = figurePositionOffset.Length;
                this.positions = new Position[len + 1];

                for (int i = 0; i < len; i++)
                {
                    int x = figurePositionOffset[i].x + figureCenterPosition.x;
                    int y = figurePositionOffset[i].y + figureCenterPosition.y;
                    this.positions[i] = new Position(x, y);
                }
                this.positions[len] = new Position(figureCenterPosition.x, figureCenterPosition.y);
                this.index = -1;
            }

            public Position Current
            {
                get
                {
                    return positions[index];
                }
            }

            public void Dispose()
            {
                // TODO: check what the is that

            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext()
            {
                bool b_return = false;
                this.index++;
                if (index < positions.Length)
                {
                    b_return = true;
                }

                return b_return;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<Position> GetEnumerator()
        {
            return new FigurePositions(figureOffset, pos);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
