using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2B
{
    public class PointPair
    {
        public string point1 { get; set; }
        public string point2 { get; set; }
        public PointPair(string point1, string point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
    }
}
