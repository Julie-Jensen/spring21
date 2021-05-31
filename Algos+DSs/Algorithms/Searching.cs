using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Searching
    {
        public static int LinearSearch(int[] list, int target)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == target)
                    return i;
            }

            return -1;
        }

        public static int BinarySearch(int[] list, int target)
        {
            int lowerBound = 0;
            int upperBound = list.Length - 1;

            while (lowerBound <= upperBound)
            {
                int mid = lowerBound + (upperBound - lowerBound) / 2;

                if (list[mid] == target)
                    return mid;
                else if (list[mid] < target)
                    lowerBound = mid + 1;
                else if (list[mid] > target)
                    upperBound = mid - 1;
            }

            return -1;
        }
    }
}
