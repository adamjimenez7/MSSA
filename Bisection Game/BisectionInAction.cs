using System;

namespace Exercise_8A
{
    class BisectionInAction
    {
        public void AutomaticBisection()
        {
            ArrayConfig newArray = new ArrayConfig();
            newArray.CreateArray(1, 10); //Creating an array from 1-10
            System.Console.WriteLine("The array is from 1 - 10. Please select a number in this range for the computer to get to: ");
            int val = int.Parse(Console.ReadLine());
            try
            {
                if(val < 0 || val > 10)
                {
                    throw new IndexOutOfRangeException("Invalid entry. Please input only an integer between 1 and 10, and press enter.");
                }
            }

            catch (FormatException e)
            {
                Console.WriteLine("Invalid entry. Please input only an integer between 1 and 10, and press enter.");
            }
            
            int numIterations = 1; //Initializing a counter
            
            while(val != newArray.Middle && newArray.WorkingArray.Length > 1) //While the computer is guessing...
            {
                newArray.FindCenter(newArray.WorkingArray); //Finding the middle of the array for the first iteration
                System.Console.WriteLine($"The array is currently: {newArray.WorkingArray[0]} - {newArray.WorkingArray[newArray.WorkingArray.Length - 1]}");
                
                if (val < newArray.Middle)
                {
                    System.Console.WriteLine($"The value {val} is lower than {newArray.Middle}");
                    newArray.BisectArrayDown(newArray.WorkingArray); //Bisect array and refactor to lower half
                    numIterations++;
                }
                else if (val > newArray.Middle)
                {
                    System.Console.WriteLine($"The value {val} is higher than {newArray.Middle}");
                    newArray.BisectArrayUp(newArray.WorkingArray); //Bisect array and refactor to lower half
                    numIterations++;
                }
            }
            if (val == newArray.Middle)
            {
                System.Console.WriteLine($"The value {val} is equal to {newArray.Middle}");
                System.Console.WriteLine($"The computer made {numIterations} iterations to get to the value {val}.");
                System.Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            else if (newArray.WorkingArray.Length == 1)
            {
                System.Console.WriteLine($"The value {val} was not found in array.");
                System.Console.WriteLine($"The computer made {numIterations} iterations to get to this point.");
                System.Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
}