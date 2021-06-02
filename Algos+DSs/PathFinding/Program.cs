using System;
using System.Collections.Generic;

namespace PathFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, float>>[] graph = new List<Tuple<int, float>>[]
            {
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(1, 1.1f),
                    new Tuple<int, float>(3, 2.3f)
                },
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(0, 1.1f),
                    new Tuple<int, float>(2, 7.5f)
                },
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(1, 7.5f),
                    new Tuple<int, float>(3, 3.2f)
                },
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(0, 2.3f),
                    new Tuple<int, float>(2, 3.2f)
                }
            };

            int source = 0;

            // act
            Tuple<int, float>[] sptSet = DijkstrasList.FindShortestPaths(graph, source);

            Console.WriteLine($"Source vertex: {source}\n");
            for (int i = 0; i < sptSet.Length; i++)
            {
                if (i != source)
                {
                    Console.WriteLine($"Dist. to vertex {i}:  {sptSet[i].Item2}");
                    Console.WriteLine($"    Prev. vertex:  {sptSet[i].Item1}");
                }
            }
        }
    }
}
