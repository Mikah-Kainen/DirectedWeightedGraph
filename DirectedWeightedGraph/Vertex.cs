using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class Vertex<T>
    {
        public T Value;
        public List<Edge<T>> Edges;
        public int Count { get { return Edges.Count; } }

        public Vertex(T value)
        {
            Value = value;
            Edges = new List<Edge<T>>();
        }
    }
}
