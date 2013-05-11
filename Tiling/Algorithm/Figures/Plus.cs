using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Plus : Figure
    {
        public Plus(int posX, int posY) : base(posX, posY)
        {
            InitOffset();
        }

        public Plus(Position pos)
            : base(pos)
        {
            InitOffset();
        }

        private void InitOffset()
        {
            this.figureOffset = new Position[]{
                new Position(0, -1),  
                new Position(0, 1),
                new Position(-1, 0),
                new Position(1, 0)
            };
        }

        public override object Clone()
        {
            Plus clone = new Plus(base.PosX, base.PosY);
            clone.figureOffset = new Position[figureOffset.Length];
            for (int i = 0; i < figureOffset.Length; i++)
            {
                clone.figureOffset[i] = new Position(figureOffset[i].x, figureOffset[i].y);
            }
            return (Figure) clone;
        }
    }
}
