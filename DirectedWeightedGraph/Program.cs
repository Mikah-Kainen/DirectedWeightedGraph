using System;

namespace DirectedWeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(6);
            graph.AddVertex(16);
            graph.AddVertex(27);
            graph.AddVertex(39);

            graph.Connect(6, 16, 10);
            graph.Connect(16, 27, 11);
            graph.Connect(6, 27, 21);
            graph.Connect(6, 39, 33);
            graph.Connect(39, 16, 23);

            bool isfalse = graph.Connect(6, 16, 10);
            bool istrue = graph.AreConnected(39, 16);
        }
    }
}
