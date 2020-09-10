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
            graph.Connect('a', 'd', 1);

            List<char> dfs = graph.DFS('a', 'k');
            List<char> bfs = graph.BFS('a', 'k');
            var thing = graph.FindShortestPath('a', 'k');
        }
    }
}
