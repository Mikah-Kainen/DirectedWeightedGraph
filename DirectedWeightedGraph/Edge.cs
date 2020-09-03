using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class Edge<T>
    {
        public int Weight { get; private set; }
        public Vertex<T> StartingVertex;
        public Vertex<T> EndingVertex;

        public Edge(int weight, Vertex<T> startingVertex, Vertex<T> endingVertex)
        {
            Weight = weight;
            StartingVertex = startingVertex;
            EndingVertex = endingVertex;
        }
    }
}
