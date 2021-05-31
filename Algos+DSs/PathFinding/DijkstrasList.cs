using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    public static class DijkstrasList
    {
        // The graph argument is an undirected graph w/ or w/o edge weights.
        public static Tuple<int, float>[] FindShortestPaths(List<Tuple<int, float>>[] graph, int source)
        {
            int verticesCount = graph.Length;

            Tuple<int, float>[] sptSet = new Tuple<int, float>[verticesCount];
            bool[] isVisited = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                sptSet[i] = new Tuple<int, float>(-1, -1f);
                isVisited[i] = false;
            }

            sptSet[source] = new Tuple<int, float>(-1, 0f); // Shortest path to source vertex is always 0.

            // Main loop
            for (int i = 0; i < verticesCount; i++)
            {
                int currVisiting = getNextVertex(sptSet, isVisited, source);

                isVisited[currVisiting] = true;

                // Going through all the vertices adjacent to currVisiting.
                for (int j = 0; j < graph[currVisiting].Count; j++)
                {
                    Tuple<int, float> currComparing = new Tuple<int, float>
                        (graph[currVisiting][j].Item1, graph[currVisiting][j].Item2);

                    if (!isVisited[currComparing.Item1])
                    {
                        float totalDist = sptSet[currVisiting].Item2 + currComparing.Item2;

                        if (sptSet[currComparing.Item1].Item2 == -1 || totalDist < sptSet[currComparing.Item1].Item2)
                            sptSet[currComparing.Item1] = new Tuple<int, float>(currVisiting, totalDist);
                    }
                }
            }
            return sptSet;
        }

        // Finds unvisited vertex with shortest path from source.
        private static int getNextVertex(Tuple<int, float>[] sptSet, bool[] isVisited, int source)
        {
            if (!isVisited[source])
                return source;

            float currShortest = -1f;
            int vertex = -1;

            // This loop is the reason the runing time is quadratic.
            for (int i = 0; i < sptSet.Length; i++)
            {
                if (!isVisited[i] && (sptSet[i].Item2 < currShortest || currShortest == -1f))
                {
                    if (sptSet[i].Item2 != -1f)
                    {
                        currShortest = sptSet[i].Item2;
                        vertex = i;
                    }
                }
            }
            return vertex;
        }
    }
}
