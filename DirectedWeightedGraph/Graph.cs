using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class Graph<T>
    {
        private List<Vertex<T>> vertices;
        public IReadOnlyList<Vertex<T>> Vertices { get {return vertices; } }

        //private List<Edge<T>> edges;
        //public IReadOnlyList<Edge<T>> Edges { get { return edges; } }
        public int Count { get { return vertices.Count; } }

        public Graph()
        {
            vertices = new List<Vertex<T>>();
            //edges = new List<Edge<T>>();
        }

        public void AddVertex(T value)
        {
            vertices.Add(new Vertex<T>(value));
        }

        public bool Contains(T value)
        {
            foreach(Vertex<T> vertex in vertices)
            {
                if(vertex.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public Vertex<T> Find(T value)
        {
            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }

        public bool AreConnected(T startingValue, T endingValue)
        {

            Vertex<T> startingVertex = Find(startingValue);
            Vertex<T> endingVertex = Find(endingValue);

            if(startingValue == null || endingValue == null)
            {
                return false;
            }

                foreach (Edge<T> edge in startingVertex.Edges)
                {
                    if (edge.EndingVertex.Equals(endingVertex))
                    {
                        return true;
                    }
                }
            return false;
        }

        public bool Connect(T startingValue, T endingValue, int weight)
        {
            if(AreConnected(startingValue, endingValue))
            {
                return false;
            }
            Vertex<T> startingVertex = Find(startingValue);
            Vertex<T> endingVertex = Find(endingValue);

            if(startingVertex == null || endingVertex == null)
            {
                return false;
            }

            startingVertex.Edges.Add(new Edge<T>(weight, startingVertex, endingVertex));
            return true;
        }

        public bool RemoveVertex(T value)
        {
            Vertex<T> temp = null;
            foreach(Vertex<T> vertex in vertices)
            {
                if(vertex.Value.Equals(value))
                {
                    temp = vertex;
                }
            }
            if(temp != null)
            {
                vertices.Remove(temp);
                return true;
            }
            return false;
        }

        public bool RemoveConnection(T startingValue, T endingValue)
        {
            if(!AreConnected(startingValue, endingValue))
            {
                return false;
            }
            Vertex<T> startingVertex = Find(startingValue);

            Edge<T> temp = null;
            foreach(Edge<T> edge in startingVertex.Edges)
            {
                if(edge.EndingVertex.Value.Equals(endingValue))
                {
                    temp = edge;
                }
            }
            if(temp != null)
            {
                startingVertex.Edges.Remove(temp);
                return true;
            }
            return false;
        }
    }
}
