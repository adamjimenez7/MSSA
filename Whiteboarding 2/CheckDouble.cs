//Create a method that returns the first letter in a string that is a duplicate

using System;

namespace Whiteboarding
{
    class CheckDouble
    {
        public char ReturnFirstDouble(string inputString)
        {
            char outputChar = '\0'; //Can't be blank char, so null
            bool isDoop = true;
            for (int i = 0; i < inputString.Length; i++)
            {
                for(int j = 0; j < inputString.Length; j++)
                {
                    if(i != j && inputString[i] == inputString[j]) //Nested for loop, if an item matches and isn't the same item (by index), is duplicate
                    {
                        isDoop = true;
                        break;
                    }
                    else
                    {
                        isDoop = false;
                    }
                }
                if(!isDoop) //If there is no duplicate, return null
                {
                    return outputChar = inputString[i];
                }
            }
            return outputChar;
        }
    }
}