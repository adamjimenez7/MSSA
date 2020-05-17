using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2B
{
    class Point
    {
        int xCoord;
        int yCoord;
        int zCoord;

        Random r = new Random();

        public int XCoord()
        {
            xCoord = r.Next(1, 1001);
            return xCoord;
        }
        public int YCoord()
        {
            yCoord = r.Next(1, 1001);
            return yCoord;
        }
        public int ZCoord()
        {
            zCoord = r.Next(1, 1001);
            return zCoord;
        }
    }
}
