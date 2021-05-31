using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathFinding;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class DijkstrasTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            float[,] graph = new float[,]
            {
                { 0, 1, 0, 1 },
                { 1, 0, 1, 1 },
                { 0, 1, 0, 1 },
                { 1, 1, 1, 0 }
            };

            int source = 1;

            // act
            float[,] sptSet = DijkstrasMatrix.FindShortestPaths(graph, source);

            // assert
            Assert.AreEqual(1, sptSet[3, 0]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // arrange
            float[,] graph = new float[,]
            {
                { 0, 1.1f, 0, 2.3f },
                { 1.1f, 0, 7.5f, 0 },
                { 0, 7.5f, 0, 3.2f },
                { 2.3f, 0, 3.2f, 0 }
            };

            int source = 0;

            // act
            float[,] sptSet = DijkstrasMatrix.FindShortestPaths(graph, source);

            // assert
            Assert.AreEqual(3, sptSet[2, 1]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // arrange
            float[,] graph = new float[,]
            {
                { 0, 4 },
                { 4, 0 }
            };

            int source = 1;

            // act
            float[,] sptSet = DijkstrasMatrix.FindShortestPaths(graph, source);

            // assert
            Assert.AreEqual(4, sptSet[0, 0]);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // arrange
            float[,] graph = new float[,]
            {
                { 0, 3, 0, 0, 0, 0, 0, 0, 0, 27 },
                { 3, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 2, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 2, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 0, 2, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 2, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 3, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 3, 0, 2, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 4 },
                { 27, 0, 0, 0, 0, 0, 0, 0, 4, 0 }
            };

            int source = 0;

            // act
            float[,] sptSet = DijkstrasMatrix.FindShortestPaths(graph, source);

            // assert
            Assert.AreEqual(20, sptSet[9, 0]);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // arrange
            List<Tuple<int, float>>[] graph = new List<Tuple<int, float>>[]
            {
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(1, 1f),
                    new Tuple<int, float>(3, 1f)
                },
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(0, 1f),
                    new Tuple<int, float>(2, 1f),
                    new Tuple<int, float>(3, 1f)
                },
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(1, 1f),
                    new Tuple<int, float>(3, 1f)
                },
                new List<Tuple<int, float>>
                {
                    new Tuple<int, float>(0, 1f),
                    new Tuple<int, float>(1, 1f),
                    new Tuple<int, float>(2, 1f)
                }
            };

            int source = 1;

            // act
            Tuple<int, float>[] sptSet = DijkstrasList.FindShortestPaths(graph, source);

            // assert
            Assert.AreEqual(1, sptSet[3].Item2);
        }

        [TestMethod]
        public void TestMethod6()
        {
            // arrange
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

            // assert
            Assert.AreEqual(3, sptSet[2].Item1);
        }
    }
}
