using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace DirectedWeightedGraph
{
    class Program
    {

        static void Main(string[] args)
        {

            var points = new List<MPoint>() { new MPoint(1, 1), new MPoint(1, 2) };
            ;

            //Graph<char> graph = new Graph<char>();

            //graph.AddVertex('a');
            //graph.AddVertex('b');
            //graph.AddVertex('c');
            //graph.AddVertex('d');
            //graph.AddVertex('e');
            //graph.AddVertex('f');
            //graph.AddVertex('g');
            //graph.AddVertex('h');
            //graph.AddVertex('i');
            //graph.AddVertex('j');
            //graph.AddVertex('k');


            //graph.Connect('a', 'b', 3);
            //graph.Connect('a', 'd', 3);
            //graph.Connect('b', 'c', 5);
            //graph.Connect('b', 'e', 2);
            //graph.Connect('c', 'd', 5);
            //graph.Connect('c', 'f', 2);
            //graph.Connect('d', 'g', 2);
            //graph.Connect('e', 'f', 5);
            //graph.Connect('e', 'h', 2);
            //graph.Connect('f', 'g', 5);
            //graph.Connect('f', 'i', 2);
            //graph.Connect('g', 'j', 2);
            //graph.Connect('h', 'i', 5);
            //graph.Connect('h', 'k', 3);
            //graph.Connect('i', 'j', 5);
            //graph.Connect('i', 'k', 2);
            //graph.Connect('j', 'k', 3);

            //graph.AddVertex('l');
            //graph.AddVertex('m');
            //graph.AddVertex('n');
            //graph.AddVertex('o');
            //graph.AddVertex('p');
            //graph.AddVertex('q');
            //graph.AddVertex('r');

            //graph.Connect('l', 'm', 5);
            //graph.Connect('n', 'o', 2);
            //graph.Connect('m', 'o', 4);
            //graph.Connect('h', 'm', 3);
            //graph.Connect('i', 'n', 1);
            //graph.Connect('n', 'p', 1);
            //graph.Connect('l', 'p', 10);
            //graph.Connect('p', 'q', 2);
            //graph.Connect('p', 'r', 5);
            //graph.Connect('l', 'p', 7);
            //graph.Connect('e', 'n', 8);

            ////Enumerable.SequenceEqual()
            //graph.Connect('a', 'd', 1);

            //List<char> dfs = graph.DFS('a', 'k');
            //List<char> bfs = graph.BFS('a', 'k');
            //var thing = graph.FindShortestPath('a', 'r');
            //var thingy = graph.Dijkstra('a', 'r');

            //var result = graph.BellmanFord('a', 'r');

            Graph<MPoint> graph = new Graph<MPoint>();
            string[] mazeLines = File.ReadAllLines("MazeProblem.txt");

            string[] commands = mazeLines[0].Split('|');
            ;

            foreach (string command in commands)
            {
                graph.AddVertex(new MPoint(int.Parse(command[3].ToString()), int.Parse(command[7].ToString())));
                Console.WriteLine($"Added point ({command[3]},{command[7]})");
            }
            Console.WriteLine();

            for (int i = 1; i < mazeLines.Length; i++)
            {
                graph.Connect(new MPoint(int.Parse(mazeLines[i][3].ToString()), int.Parse(mazeLines[i][7].ToString())), new MPoint(int.Parse(mazeLines[i][13].ToString()), int.Parse(mazeLines[i][17].ToString())), int.Parse(mazeLines[i][20].ToString()));
                Console.WriteLine($"Connected Points ({mazeLines[i][3]},{mazeLines[i][7]}) and ({mazeLines[i][13]},{mazeLines[i][17]}) with weight {mazeLines[i][20]}");
            }
            Console.WriteLine();

            List<MPoint> result = graph.AStar(new MPoint(0, 2), new MPoint(1, 1));
            result.Reverse();
            foreach(MPoint point in result)
            {
                Console.WriteLine($"{point.X}, {point.Y}");
            }
            ;
        }
    }
}
