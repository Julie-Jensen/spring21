using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Sorting
    {
        public static int[] InsertionSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int key = list[i];
                int prev = i - 1;

                while (prev >= 0 && list[prev] > key)
                {
                    list[prev + 1] = list[prev];
                    prev -= 1;
                }
                list[prev + 1] = key;
            }

            return list;
        }

        public static int[] MergeSort(int[] list)
        {
            if (list.Length == 1)
                return list;

            int[] left, right;
            int middle = list.Length / 2;

            if (list.Length % 2 != 0)
            {
                left = new int[middle + 1];
                right = new int[middle];

                for (int i = 0; i <= middle; i++)
                {
                    left[i] = list[i];
                }
                for (int i = middle + 1; i < list.Length; i++)
                {
                    right[i - (middle + 1)] = list[i];
                }
            }
            else
            {
                left = new int[middle];
                right = new int[middle];

                for (int i = 0; i < middle; i++)
                {
                    left[i] = list[i];
                }
                for (int i = middle; i < list.Length; i++)
                {
                    right[i - middle] = list[i];
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return merge(left, right);
        }

        private static int[] merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int i = 0;
            int lCounter = 0;
            int rCounter = 0;
            while (lCounter < left.Length && rCounter < right.Length)
            {
                if (left[lCounter] <= right[rCounter])
                {
                    result[i] = left[lCounter];
                    lCounter++;
                }
                else
                {
                    result[i] = right[rCounter];
                    rCounter++;
                }

                i++;
            }

            while (i < result.Length)
            {
                if (rCounter == right.Length)
                {
                    result[i] = left[lCounter];
                    lCounter++;
                }
                else
                {
                    result[i] = right[rCounter];
                    rCounter++;
                }

                i++;
            }

            return result;
        }

        public static void QuickSort(int[] array, int from, int to)
        {
            if (to - from <= 4)
            {
                _ = InsertionSort(array);
            }
            else
            {
                int pivot = from + (to - from) / 2;
                QuickSort(array, from, pivot);
                QuickSort(array, pivot + 1, to);
            }
        }
    }
}
