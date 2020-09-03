using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DirectedWeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(6);
            graph.AddVertex(57);
            graph.AddVertex(16);
            graph.AddVertex(27);
            graph.AddVertex(39);

            graph.Connect(6, 57, 51);
            graph.Connect(6, 16, 10);
            graph.Connect(16, 27, 11);
            graph.Connect(6, 27, 21);
            graph.Connect(6, 39, 33);
            graph.Connect(39, 16, 23);
            graph.Connect(27, 57, 30);

            graph.RemoveVertex(39);
            graph.RemoveConnection(16, 27);

            bool isfalse = graph.Connect(6, 16, 10);
            bool istrue = graph.AreConnected(39, 16);

            List<int> dfs = graph.DFS(6, 16);
            List<int> isnull = graph.DFS(6, 39);
        }
    }
}
