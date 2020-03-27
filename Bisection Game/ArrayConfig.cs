using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_8A
{
    class ArrayConfig
    {
        public int Middle { get; set; }
        public int[] WorkingArray {get; set; }

        public int[] CreateArray(int lowerParam, int upperParam) //Creates the array based on lower/upper parameters provided as input
        {
            int[] tempArray = new int[upperParam - lowerParam + 1];
            for(int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = lowerParam + i;
                }
            WorkingArray = tempArray;
            return WorkingArray;
        }
        public int FindCenter(int[] inputArray)
        {    
            int middle = inputArray[(inputArray.Length - 1) / 2]; //Middle is the vlaue in the center of the array, or center - 1 if the array has an even number of entries
            Middle = middle;
            return Middle;
        }
        public int[] BisectArrayUp(int[] inputArray)
        {   
            FindCenter(inputArray); //Determine middle value, which will be the array starting point
            if(inputArray.Length % 2 == 0) //If array is of even length, bisect the upper half (integer division would otherwise round down)
            {
                Middle += 1;
            }

            int[] tempArray;
            if(inputArray.Length % 2 != 0) //If array is of odd length, new temp array will have half + 1 the length of starting array (integer division would otherwise round down)
            {
                tempArray = new int[inputArray.Length / 2 + 1];
            }
            else
            {
                tempArray = new int[inputArray.Length / 2];
            }

            for(int i = 0; i < tempArray.Length; i ++)
            {
                tempArray[i] = Middle + i; //Populate temp array, with middle value being first entry
            }
            WorkingArray = tempArray;
            return WorkingArray;
        }
        public int[] BisectArrayDown(int[] inputArray)
        {
            FindCenter(inputArray); //Determine middle value, which will be the array ending point
            int[] tempArray;
            if(inputArray.Length % 2 != 0) //If array is of odd length, bisect the lower half (integer division would otherwise round down)
            {
                tempArray = new int[inputArray.Length / 2 + 1];
            }
            else
            {
                tempArray = new int[inputArray.Length / 2];
            }

            for(int i = 0; i < tempArray.Length; i ++)
            {
                tempArray[i] = Middle - tempArray.Length + i + 1; //Populate temp array, working backwards, with middle value being ending value
            }
            WorkingArray = tempArray;
            return WorkingArray;
        }
    }
}