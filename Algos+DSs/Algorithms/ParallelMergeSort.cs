using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class ParallelMergeSort
    {
        public static List<int> Sort(int[] list)
        {
            List<int> result = new List<int>();

            int[] auxArray = new int[list.Length];

            int totalThreads = Environment.ProcessorCount; // must be power of two: 2^p

            Task[] threads = new Task[totalThreads - 1];

            int iterations = (int)Math.Log2(totalThreads);

            int partitionSize = list.Length / totalThreads;
            int remainder = list.Length % totalThreads;

            Barrier barrier = new Barrier(totalThreads, (b) =>
            {
                partitionSize <<= 1;

                var temp = auxArray;

                auxArray = list;

                list = temp;
            });

            Action<object> workAction = (obj) =>
            {
                int index = (int)obj;
                //calculate the partition boundary
                int low = index * partitionSize;
                if (index > 0)
                    low += remainder;
                else
                    partitionSize += remainder;
                int high = (index + 1) * partitionSize - 1 + remainder;

                int[] parallel = parallelSort(list, low, high, partitionSize);
                foreach (int i in parallel)
                {
                    result.Add(i);
                }
                //result = parallelSort(list, low, high, partitionSize);
                barrier.SignalAndWait();
            };

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = Task.Factory.StartNew(obj => workAction(obj), i + 1);
            }
            workAction(0);

            barrier.Dispose(); // good practice to dispose: releases ressources used by the barrier.

            return result;

            /// Fejler nogle gange, som koden er nu
            /// Fejler helt sikkert, hvis antal elementer % antal tråde != 0
        }

        private static int[] parallelSort(int[] list, int low, int high, int partitionSize)
        {
            if (list.Length == 1)
                return list;

            int[] left, right;
            int middle = partitionSize / 2;

            if (partitionSize % 2 != 0)
            {
                left = new int[middle + 1];
                right = new int[middle];

                for (int i = 0; i <= middle; i++)
                {
                    left[i] = list[i + low - 1]; // fjern -1 ?
                }
                for (int i = middle + 1; i < partitionSize; i++)
                {
                    right[i - (middle + 1)] = list[i + low - 1]; // fjern -1 ?
                }
            }
            else
            {
                left = new int[middle];
                right = new int[middle];

                for (int i = 0; i < middle; i++)
                {
                    left[i] = list[i + low];
                }
                for (int i = middle; i < partitionSize; i++)
                {
                    right[i - middle] = list[i + low];
                }
            }

            left = parallelSort(left, 0, left.Length - 1, left.Length);
            right = parallelSort(right, 0, left.Length - 1, right.Length);

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
    }
}
