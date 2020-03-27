//Create a method that sorts an array

using System;

namespace Whiteboarding
{
    class ArrayWork
    {
        int temp;
        public int[] InputArray { get; set; }
        public int[] SortArray(int[] inputArray)
        {
            InputArray = inputArray;
            for(int i = 0; i < inputArray.Length - 1; i++)
            {
                for(int j = i + 1; j < inputArray.Length; j++)
                {
                    if(inputArray[i] > inputArray[j])
                    {
                        temp = inputArray[i];
                        inputArray[i] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }
    }
}