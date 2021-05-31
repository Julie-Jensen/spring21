using System;

namespace Algorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            run();

            while (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine($"\n\n");
                run();
            }

            //Console.WriteLine($"Start\n...");
            //Sorting.MergeSort(list);
            //Console.WriteLine("Slut");
        }

        private static void run()
        {
            int[] list = createArray(16, 0, 10);
            foreach (int element in list)
            {
                Console.Write($"{element}; ");
            }

            Console.WriteLine("\n");

            ParallelQuicksort.Sort(list, 0, list.Length - 1, (int)Math.Log(Environment.ProcessorCount, 2));

            //Sorting.ParallelMergeSort(list);

            foreach (int element in list)
            {
                Console.Write($"{element}; ");
            }

            //List<int> result = Sorting.ParallelMergeSort(list);
            //foreach (int element in result)
            //{
            //    Console.Write($"{element}; ");
            //}
        }

        private static int[] createArray(int length, int min, int max)
        {
            int[] array = new int[length];

            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(min, max);
            }

            return array;
        }
    }
}
