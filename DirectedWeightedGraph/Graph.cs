using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class Graph<T>
    {
        private List<Vertex<T>> vertices;
        public IReadOnlyList<Vertex<T>> Vertices { get {return vertices; } }

        public IReadOnlyList<Edge<T>> Edges 
        { 
            get
            {
                List<Edge<T>> edges = new List<Edge<T>>();

                foreach(Vertex<T> vertex in vertices)
                {
                    foreach(Edge<T> edge in vertex.Edges)
                    {
                        if(!edges.Contains(edge))
                        {
                            edges.Add(edge);
                        }
                    }
                }
                return edges;
            } 
        }
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

            if(startingVertex == null || endingVertex == null)
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

                IReadOnlyList<Edge<T>> edges = Edges;
                List<Edge<T>> deleteList = new List<Edge<T>>();
                foreach(Edge<T> edge in edges)
                {
                    if(edge.EndingVertex.Equals(temp))
                    {
                        deleteList.Add(edge);
                    }
                }
                foreach(Edge<T> edge in deleteList)
                {
                    RemoveConnection(edge.StartingVertex.Value, edge.EndingVertex.Value);
                }

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

        public List<T> DFS(T startValue, T endValue)
        {
            Vertex<T> startingVertex = Find(startValue);
            Vertex<T> endingVertex = Find(endValue);
            if (startingVertex == null || endingVertex == null)
            {
                return null;
            }

            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            Vertex<T> currentVertex = null;
            stack.Push(startingVertex);

            List<Vertex<T>> visited = new List<Vertex<T>>();
            List<T> returnList = new List<T>();
            Vertex<T>[] parents = new Vertex<T>[vertices.Count];
            for(int i = 0; i < vertices.Count; i ++)
            {
                parents[i] = default;
            }

            do
            {
                currentVertex = stack.Pop();
                if (!visited.Contains(currentVertex))
                {
                    visited.Add(currentVertex);
                }

                foreach (Edge<T> edge in currentVertex.Edges)
                {
                    if (!visited.Contains(edge.EndingVertex))
                    {
                        stack.Push(edge.EndingVertex);
                        parents[vertices.IndexOf(edge.EndingVertex)] = currentVertex;
                    }
                }
            } while (!currentVertex.Equals(endingVertex) && stack.Count != 0 && currentVertex != null);

            while (currentVertex != null)
            {
                returnList.Add(currentVertex.Value);
                currentVertex = parents[vertices.IndexOf(currentVertex)];
            }
            return returnList;
        }

        public List<T> BFS(T startValue, T endValue)
        {
            Vertex<T> startingVertex = Find(startValue);
            Vertex<T> endingVertex = Find(endValue);
            if (startingVertex == null || endingVertex == null)
            {
                return null;
            }

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Vertex<T> currentVertex = null;
            queue.Enqueue(startingVertex);

            List<Vertex<T>> visited = new List<Vertex<T>>();
            List<T> returnList = new List<T>();
            Vertex<T>[] parents = new Vertex<T>[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                parents[i] = default;
            }

            do
            {
                currentVertex = queue.Dequeue();
                if (!visited.Contains(currentVertex))
                {
                    visited.Add(currentVertex);
                }

                foreach (Edge<T> edge in currentVertex.Edges)
                {
                    if (!visited.Contains(edge.EndingVertex))
                    {
                        queue.Enqueue(edge.EndingVertex);
                        parents[vertices.IndexOf(edge.EndingVertex)] = currentVertex;
                    }
                }
            } while (!currentVertex.Equals(endingVertex) && queue.Count != 0 && currentVertex != null);

            while (currentVertex != null)
            {
                returnList.Add(currentVertex.Value);
                currentVertex = parents[vertices.IndexOf(currentVertex)];
            }
            return returnList;
        }
    }
}
