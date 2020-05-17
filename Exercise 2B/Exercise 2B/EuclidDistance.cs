using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2B
{
    class EuclidDistance
    {
        public string ShortestDistance(int numDimensions, int numPoints)
        {
            double shortestDistance = 0;
            double distance;
            int x1;
            int y1;
            int z1;
            int x2;
            int y2;
            int z2;
            string closestPair = "";
            PointField pointField = new PointField();
            Point[] workingArray = pointField.GenerateField(numPoints);

            for (int i = 0; i < workingArray.Length; i++)
            {
                for (int j = i + 1; j < workingArray.Length; j++)
                {
                    x1 = workingArray[i].XCoord();
                    x2 = workingArray[j].XCoord();
                    y1 = workingArray[i].YCoord();
                    y2 = workingArray[j].YCoord();
                    z1 = workingArray[i].ZCoord();
                    z2 = workingArray[j].ZCoord();

                    if (numDimensions == 3)
                    {
                        distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
                        if (distance < shortestDistance || shortestDistance == 0)
                        {
                            shortestDistance = distance;
                            closestPair = $"({x1}, {y1}, {z1}) and ({x2}, {y2}, {z2}) with a distance of {shortestDistance}";
                        }
                    }
                    else
                    {
                        distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                        if (distance < shortestDistance || shortestDistance == 0)
                        {
                            shortestDistance = distance;
                            closestPair = $"({x1}, {y1}) and ({x2}, {y2}) with a distance of {shortestDistance}";
                        }
                    }
                }
            }
            return closestPair;
        }
    }
}
