using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2B
{
    class PointField
    {
        Point newPoint { get; set; }
        Point[] pointArray { get; set; }

        public Point[] GenerateField(int numPoints)
        {
            Point[] pointArray = new Point[numPoints];
            for(int i = 0; i < pointArray.Length; i++)
            {
                Point newPoint = new Point();
                pointArray[i] = newPoint;
            }
            return pointArray;
        }
    }
}
