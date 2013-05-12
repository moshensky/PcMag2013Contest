using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public struct Position : IComparable<Position>
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Position other)
        {
            if (this.x > other.x)
            {
                return 1;
            }
            else if (this.x < other.x)
            {
                return -1;
            }
            else
            {
                if (this.y > other.y)
                {
                    return 1;
                }
                else if (this.y < other.y)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
