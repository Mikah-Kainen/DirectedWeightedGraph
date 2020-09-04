using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DirectedWeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<char> graph = new Graph<char>();

            graph.AddVertex('a');
            graph.AddVertex('b');
            graph.AddVertex('c');
            graph.AddVertex('d');
            graph.AddVertex('e');
            graph.AddVertex('f');
            graph.AddVertex('g');
            graph.AddVertex('h');
            graph.AddVertex('i');
            graph.AddVertex('j');
            graph.AddVertex('k');


            graph.Connect('a', 'b', 3);
            graph.Connect('a', 'd', 3);
            graph.Connect('b', 'c', 5);
            graph.Connect('b', 'e', 2);
            graph.Connect('c', 'd', 5);
            graph.Connect('c', 'f', 2);
            graph.Connect('d', 'g', 2);
            graph.Connect('e', 'f', 5);
            graph.Connect('e', 'h', 2);
            graph.Connect('f', 'g', 5);
            graph.Connect('f', 'i', 2);
            graph.Connect('g', 'j', 2);
            graph.Connect('h', 'i', 5);
            graph.Connect('h', 'k', 3);
            graph.Connect('i', 'j', 5);
            graph.Connect('i', 'k', 2);
            graph.Connect('j', 'k', 3);


            //Enumerable.SequenceEqual()

            //    graph.AddVertex(6);
            //    graph.AddVertex(57);
            //    graph.AddVertex(16);
            //    graph.AddVertex(27);
            //    graph.AddVertex(39);
            //    graph.AddVertex(100);

            //    graph.Connect(6, 57, 51);
            //    graph.Connect(6, 16, 10);
            //    graph.Connect(16, 27, 11);
            //    graph.Connect(6, 27, 21);
            //    graph.Connect(6, 39, 33);
            //    graph.Connect(39, 16, 23);
            //    graph.Connect(27, 57, 30);
            //    graph.Connect(27, 100, 73);

            //    graph.RemoveVertex(39);
            //    graph.RemoveConnection(16, 27);

            //    bool isfalse = graph.Connect(6, 16, 10);
            //    bool istrue = graph.AreConnected(39, 16);

                List<char> dfs = graph.DFS('a', 'k');
                List<char> bfs = graph.BFS('a', 'k');
                var thing = graph.FindShortestPath('a', 'k');
            //    List<int> isnull = graph.DFS(6, 39);

        }
    }
}
