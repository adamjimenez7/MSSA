//More whiteboarding problems. Implemented in classes for more practice with OOP

using System;

namespace Whiteboarding
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] userArray = { 2, 8, 9, 6, 3, 1 };
            // ArrayWork newSortedArray = new ArrayWork();
            // newSortedArray.SortArray(userArray);
            // for(int i = 0; i < newSortedArray.InputArray.Length; i++)
            // {
            //     Console.Write(newSortedArray.InputArray[i]);
            // }

            //HIndex newH= new HIndex();
            //System.Console.WriteLine(newH.GetH(userArray));

            string inputString = "dabbacd";
            CheckDouble newCheck = new CheckDouble();
            Console.WriteLine(newCheck.ReturnFirstDouble(inputString));
        }
    }
}