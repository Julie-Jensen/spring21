﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class ParallelQuicksort
    {
        public static void Sort(int[] array, int from, int to, int depthRemaining)
        {
            if (to - from <= 4)
            {
                _ = Sorting.InsertionSort(array);
            }
            else
            {
                int pivot = from + (to - from) / 2;
                if (depthRemaining > 0)
                {
                    Parallel.Invoke(
                      () => Sort(array, from, pivot, depthRemaining - 1),
                      () => Sort(array, pivot + 1, to, depthRemaining - 1));
                }
                else
                {
                    Sort(array, from, pivot, 0);
                    Sort(array, pivot + 1, to, 0);
                }
            }
        }
    }
}
