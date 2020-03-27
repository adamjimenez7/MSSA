using System;
using System.Linq;
using System.Collections.Generic;

namespace Stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SwitchUpperLower("aAbB"));
        }

        static int AngleHands(int hour, int minute)
        {
            int angle = (Math.Abs(hour - (minute / 5)) > 6) ? (12 - Math.Abs(hour - (minute / 5))) * 30 : Math.Abs(hour - (minute / 5)) * 30;
            return angle;
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

            for (int i = 0; i < wordIn.Length / 2; i++)
            {
                if (wordIn[i] != wordIn[wordIn.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        static string SortRGBArray()
        {
            Console.WriteLine("Please input your array:");
            string inString = Console.ReadLine();
            inString = inString.ToLower();
            string rString = "";
            string gString = "";
            string bString = "";

            for (int i = 0; i < inString.Length; i++)
            {
                if (inString[i] == 'r')
                {
                    rString += inString[i];
                }
                else if (inString[i] == 'g')
                {
                    gString += inString[i];
                }
                else if (inString[i] == 'b')
                {
                    bString += inString[i];
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
            input = input.ToUpper();
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    if (i > 0 && Char.IsNumber(input[i - 1]))
                    {
                        input = input.Remove(i, 1).Insert(i, (Char.GetNumericValue(input[i - 1]) + 1).ToString());
                    }

                    else
                    {
                        input = input.Remove(i, 1).Insert(i, 2.ToString());
                    }
                }
            }

            for (int i = input.Length - 1; i > 0; i--)
            {
                if (Char.IsNumber(input[i]) && Char.IsNumber(input[i - 1]))
                {
                    input = input.Remove(i - 1, 1);
                }
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (!Char.IsNumber(input[i]) && !Char.IsNumber(input[i + 1]))
                {
                    input = input.Insert(i + 1, 1.ToString());
                }
            }
            return input;
        }

        static string RunLengthDecode(string input)
        {
            input = input.ToUpper();
            string temp = "";
            string output = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (Char.IsNumber(input[i]))
                {
                    temp += input[i];
                    input = input.Remove(i, 1);
                }
            }

            for (int i = temp.Length - 1; i >= 0; i--)
            {
                if (Char.GetNumericValue(temp[i]) > 1)
                {
                    for (int j = 0; j < Char.GetNumericValue(temp[i]); j++)
                    {
                        output += input[input.Length - i - 1];
                    }
                }

                else
                {
                    output += input[input.Length - i - 1];
                }
            } 
            return output;
        }

        static bool BalancedBrackets(string input)
        {
            if (input == "")
            {
                return true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ')' && input[i - 1] == '(' || input[i] == '}' && input[i - 1] == '{' || input[i] == ']' && input[i - 1] == '[')
                {
                    input = input.Remove(i - 1, 2);
                    return BalancedBrackets(input);
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        static string SwitchUpperLower(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= 'Z')
                {
                    input = input.Remove(i, 1).Insert(i, ((char)(input[i] + 32)).ToString());
                }
                else if (input[i] > 'Z')
                {
                    input = input.Remove(i, 1).Insert(i, ((char)(input[i] - 32)).ToString());
                }
            }

            return input;
        }
    }
}