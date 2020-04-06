using System;
using System.Dynamic;

namespace Exercise_2B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Euclidean Distance Calculator...");
            int numDimensions = 2;
            int numPoints = 100;

            try
            {
                Console.WriteLine("First, how many dimensions would you like to work with? (2 or 3)");
                numDimensions = int.Parse(Console.ReadLine());
                if (numDimensions != 2 && numDimensions != 3)
                {
                    throw new System.IndexOutOfRangeException("We will be working with 2 dimensions.");
                }
                Console.WriteLine($"Great! We are working with {numDimensions} dimensions.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Not an integer.");
                Console.WriteLine("We will be working with 2 dimensions.");
            }

            try
            {
                Console.WriteLine("Now, how many points would you like to generate? (at least 2)");
                numPoints = int.Parse(Console.ReadLine());
                if (numPoints < 2)
                {
                    throw new System.IndexOutOfRangeException("We will work with 100 points.");
                }
                Console.WriteLine($"Outstanding! We are creating {numPoints} points.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Not an integer.");
                Console.WriteLine("We will work with 100 points.");
            }
            
            EuclidDistance newDistance = new EuclidDistance();
            Console.WriteLine($"The two closest points are {(newDistance.ShortestDistance(numDimensions, numPoints))}");
        }
    }
}