using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Cell
    {
        private int posX;
        private int posY;
        private List<Figure> figures;

        public List<Figure> Figures
        {
            get
            {
                return this.figures;
            }
        }

        public Cell(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.figures = new List<Figure>();
        }
    }
}
