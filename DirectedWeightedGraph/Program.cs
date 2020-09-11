using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace DirectedWeightedGraph
{
    class Program
    {

        static (int, bool, string) Foo()
        {
            return (5, false, "bananas");
        }

        static (int val, bool result) Bar()
        {
            return (5, true);
        }

        static void Main(string[] args)
        {

            var t = Bar();

            Console.WriteLine(t.val);
            Console.WriteLine(t.result);


            List<(int, bool)> tuples = new List<(int, bool)>();

            for (int i = 0; i < 10; i++)
            {
                tuples.Add(Bar());
            }

            ;


            (int, bool, string) mytuple = Foo();

            Console.WriteLine(mytuple.Item1);
            Console.WriteLine(mytuple.Item2);
            Console.WriteLine(mytuple.Item3);
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


            ////Enumerable.SequenceEqual()
            //graph.Connect('a', 'd', 1);

            //List<char> dfs = graph.DFS('a', 'k');
            //List<char> bfs = graph.BFS('a', 'k');
            //var thing = graph.FindShortestPath('a', 'k');

            HeapTree<int> tree = new HeapTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(4);
            tree.Add(8);
            tree.Add(1);
            tree.Add(22);
            for(int i = 15; i < 20; i ++)
            {
                tree.Add(i);
            }
            var thing = tree.Pop();
            var where = tree.Pop();
            var th = tree.Pop();
        }
    }
}
