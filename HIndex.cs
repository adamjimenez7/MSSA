//Determine h-index

using System;

namespace Whiteboarding
{
    class HIndex
    {
        public int GetH(int[] inputArray)
        {
            int h;
            for(h = inputArray.Length; h > 0; h--)
            {
                int numPubs = 0;
                for(int i = 0; i < inputArray.Length; i++)
                {
                    if(inputArray[i] >= h)
                    {
                        numPubs++;
                    }
                }
                if(numPubs >= h)
                {
                    break;
                }
                h--;
            }
            return h;
        }
    }
}

