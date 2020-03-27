using System;
using System.Linq;
using System.Collections.Generic;

namespace Stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What is the hour?");
            //int hour = int.Parse(Console.ReadLine());
            //Console.WriteLine("What is the minute?");
            //int minute = int.Parse(Console.ReadLine());
            //Console.WriteLine($"The angle is {AngleHands(hour, minute)} degrees.");

            //Console.WriteLine(StairMaster(6078));

            //Console.WriteLine(StairMaster(4));

            //Console.WriteLine(IsPalindrome());

            //Console.WriteLine(SortRGBArray());

            //Console.WriteLine(FibCounter(5));

            //FizzBuzz();

            //Console.WriteLine(AddTwo());

            Console.WriteLine(RunLengthEncode(aaa));

            //Console.WriteLine(BalancedBrackets());
        }

        static int AngleHands(int hour, int minute)
        {
            int angle = (Math.Abs(hour - (minute / 5)) > 6) ? (12 - Math.Abs(hour - (minute / 5))) * 30 : Math.Abs(hour - (minute / 5)) * 30;
            return angle;

            //hour *= 30;
            //minute *= 6;
            //int angle = Math.Abs(hour - minute);

            //return (angle > 180 ? 360 - angle : angle); 
        }

        static int StairMaster(int n)
        {
            int count = 0;
            if (n == 1)
            {
                count = 1;
            }
            else if (n == 2)
            {
                count = 2;
            }
            else
            {
                count = StairMaster(n - 1) + StairMaster(n - 2);
            }

            return count;
        }

        static bool IsPalindrome()
        {
            Console.WriteLine("Please input the string you would like evaluated: ");
            string wordIn = Console.ReadLine();
            //string wordOut = "";
            char[] wordArray = wordIn.ToCharArray();

            for (int i = 0; i < wordIn.Length; i++)
            {
                if (wordArray[i] != wordArray[wordIn.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
            //for (int i = wordIn.Length - 1; i >= 0; i--)
            //{
            //    wordOut += wordIn[i];
            //}

            //if (wordIn == wordOut)
            //{
            //    return true;
            //}

            //else
            //{
            //    return false;
            //}
        }

        static string SortRGBArray()
        {
            Console.WriteLine("Please input your array:");
            string inString = Console.ReadLine();
            char[] inArray = (inString.ToLower()).ToCharArray();
            string rString = "";
            string gString = "";
            string bString = "";

            for (int i = 0; i < inArray.Length; i++)
            {
                if (inArray[i] == 'r')
                {
                    rString += inArray[i];
                }
                else if (inArray[i] == 'g')
                {
                    gString += inArray[i];
                }
                else if (inArray[i] == 'b')
                {
                    bString += inArray[i];
                }
            }
            string outString = $"{rString + gString + bString}";
            return outString;
        }

        static int FibCounter(int n)
        {
            int fibN = 0;
            for (int i = 0; i <= n; i++)
            {
                if (n == 2)
                {
                    fibN = 1;
                }
                else
                {
                    fibN = FibCounter(n - 1) + FibCounter(n - 2);
                }
            }
            return fibN;
        }

        static void FizzBuzz()
        {
            Console.WriteLine("Please input a number: ");
            string n = Console.ReadLine();

            for (int i = 1; i <= int.Parse(n); i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }

                else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }

                else if (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }

                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool AddTwo()
        {
            Console.WriteLine("Please enter a series of integers, separated by a comma (no space).");
            string[] stringArr = Console.ReadLine().Split(",");
            int[] arr = new int[stringArr.Length];

            for (int i = 0; i < stringArr.Length; i++)
            {
                arr[i] = int.Parse(stringArr[i]);
            }

            Console.WriteLine("please enter the number to check if two numbers in your list can sum to.");
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == k)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static string RunLengthEncode(string input)
        {
            string output = "";
            int counter = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[i + 1])
                {
                    counter += 1;
                    output[i] = counter.ToString();
                }
            }

            return output;
        }

        static bool BalancedBrackets(string input)
        {
            return true;
        }
    }  
}