using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    public static class DijkstrasMatrix
    {
        // The graph argument is an undirected graph w/ or w/o edge weights.
        public static float[,] FindShortestPaths(float[,] graph, int source)
        {
            int verticesCount = graph.GetLength(0);

            // Multidimentional array to be returned - represents the shortest path tree set.
            // Will contain shortest path from source to all vertices in graph, as well as
            // the previous visited vertex.
            float[,] sptSet = new float[verticesCount, 2];

            // isVisited[i] holds true, if shortest distance from source has been found.
            bool[] isVisited = new bool[verticesCount];

            // Init above arrays.
            // All shortest paths is "infinite" at this point, represented with -1.
            // No previous visited vertices exist yet, therefore they are written as -1.
            // No vertices have been visited yet, hence only false values in the isVisited array.
            for (int i = 0; i < verticesCount; i++)
            {
                sptSet[i, 0] = -1;
                sptSet[i, 1] = -1;
                isVisited[i] = false;
            }

            // Shortest path to source vertex is always 0.
            sptSet[source, 0] = 0;

            // Main loop.
            // Goes through all vertices until none remains unvisited.
            // Starts from the vertex with the shortest path to the longest.
            for (int i = 0; i < verticesCount; i++)
            {
                int currVisiting = getNextVertex(sptSet, isVisited, source);

                isVisited[currVisiting] = true;

                for (int j = 0; j < verticesCount; j++)
                {
                    // If j is adjacent to currVertex, and j haven't been visited.
                    if (graph[currVisiting, j] != 0 && !isVisited[j])
                    {
                        // Total distance from source to j through currVertex.
                        float totalDist = sptSet[currVisiting, 0] + graph[currVisiting, j];

                        // If totalDistance is smaller than the current value of sptSet[j],
                        // the new value of sptSet[j] equals totalDist.
                        // The previous visited vertex is currVisiting.
                        if (sptSet[j, 0] == -1 || totalDist < sptSet[j, 0])
                        {
                            sptSet[j, 0] = totalDist;
                            sptSet[j, 1] = currVisiting;
                        }
                    }
                }
            }
            return sptSet;
        }

        // Finds unvisited vertex with shortest path from source.
        private static int getNextVertex(float[,] sptSet, bool[] isVisited, int source)
        {
            float currShortest = -1;
            int vertex = -1;

            for (int i = 0; i < sptSet.GetLength(0); i++)
            {
                if (!isVisited[i] && (sptSet[i, 0] <= currShortest || currShortest == -1))
                {
                    if (i == source)
                        return i;

                    if (sptSet[i, 0] != -1)
                    {
                        currShortest = sptSet[i, 0];
                        vertex = i;
                    }
                }
            }
            return vertex;
        }
    }
}
