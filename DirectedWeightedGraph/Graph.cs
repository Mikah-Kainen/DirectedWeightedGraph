using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectedWeightedGraph
{
    class Graph<T>
    {
        private List<Vertex<T>> vertices;
        public IReadOnlyList<Vertex<T>> Vertices { get { return vertices; } }

        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                List<Edge<T>> edges = new List<Edge<T>>();

                foreach (Vertex<T> vertex in vertices)
                {
                    foreach (Edge<T> edge in vertex.Edges)
                    {
                        if (!edges.Contains(edge))
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
            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex.Value.Equals(value))
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

            if (startingVertex == null || endingVertex == null)
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
            if (AreConnected(startingValue, endingValue))
            {
                return false;
            }
            Vertex<T> startingVertex = Find(startingValue);
            Vertex<T> endingVertex = Find(endingValue);

            if (startingVertex == null || endingVertex == null)
            {
                return false;
            }

            startingVertex.Edges.Add(new Edge<T>(weight, startingVertex, endingVertex));
            return true;
        }

        public bool RemoveVertex(T value)
        {
            Vertex<T> temp = null;
            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex.Value.Equals(value))
                {
                    temp = vertex;
                }
            }
            if (temp != null)
            {

                IReadOnlyList<Edge<T>> edges = Edges;
                List<Edge<T>> deleteList = new List<Edge<T>>();
                foreach (Edge<T> edge in edges)
                {
                    if (edge.EndingVertex.Equals(temp))
                    {
                        deleteList.Add(edge);
                    }
                }
                foreach (Edge<T> edge in deleteList)
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
            if (!AreConnected(startingValue, endingValue))
            {
                return false;
            }
            Vertex<T> startingVertex = Find(startingValue);

            Edge<T> temp = null;
            foreach (Edge<T> edge in startingVertex.Edges)
            {
                if (edge.EndingVertex.Value.Equals(endingValue))
                {
                    temp = edge;
                }
            }
            if (temp != null)
            {
                startingVertex.Edges.Remove(temp);
                return true;
            }
            return false;
        }

        private int FindWeight(List<Vertex<T>> targetList)
        {
            int weight = 0;
            int currentIndex = 0;
            Vertex<T> currentVertex = targetList[currentIndex];

            while (!currentVertex.Equals(targetList[targetList.Count - 1]))
            {
                foreach (Edge<T> edge in currentVertex.Edges)
                {
                    if (edge.EndingVertex.Equals(targetList[currentIndex + 1]))
                    {
                        weight += edge.Weight;
                        currentIndex += 1;
                        break;
                    }
                }
                currentVertex = targetList[currentIndex];
            }
            return weight;
        }
        private int FindWeight(List<Edge<T>> list)
        {
            int weight = 0;
            foreach(Edge<T> edge in list)
            {
                weight += edge.Weight;
            }
            return weight;
        }

        public List<T> FindShortestPath(T startValue, T endValue)
        {
            Vertex<T> startingVertex = Find(startValue);
            Vertex<T> endingVertex = Find(endValue);
            List<T> returnList = new List<T>();

            if (startingVertex == null || endingVertex == null)
            {
                return returnList;
            }
            List<List<Edge<T>>> list = FindShortestPath(startingVertex, endingVertex);

            int leastWeight = int.MaxValue;
            int targetIndex = 0;
            int tempWeight;
            for (int i = 0; i < list.Count; i++)
            {
                tempWeight = FindWeight(list[i]);
                if (tempWeight < leastWeight)
                {
                    targetIndex = i;
                    leastWeight = tempWeight;
                }
            }

            returnList.Add(startValue);
            foreach (Edge<T> edge in list[targetIndex])
            {
                returnList.Add(edge.EndingVertex.Value);
            }
            return returnList;
        }
        private List<List<Edge<T>>> FindShortestPath(Vertex<T> startingVertex, Vertex<T> endingVertex)
        {
            List<List<Edge<T>>> returnList = new List<List<Edge<T>>>();

            Stack<int> numberStack = new Stack<int>();
            for (int i = 1000; i > 0; i--)
            {
                returnList.Add(new List<Edge<T>>());
                numberStack.Push(i);
            }
            List<Edge<T>> oldPath;
            foreach (Edge<T> edge in startingVertex.Edges)
            {
                oldPath = new List<Edge<T>>();
                oldPath.Add(edge);
                FindShortestPath(edge.EndingVertex, endingVertex, returnList, numberStack, oldPath);
            }

            Stack<List<Edge<T>>> deleteStack = new Stack<List<Edge<T>>>();
            foreach (List<Edge<T>> list in returnList)
            {
                if (list.Count == 0 || (list.Count != 0 && !list[list.Count - 1].EndingVertex.Equals(endingVertex)))
                {
                    deleteStack.Push(list);
                }
            }

            while (deleteStack.Count != 0)
            {
                returnList.Remove(deleteStack.Pop());
            }


            return returnList;
        }
        private void FindShortestPath(Vertex<T> startingVertex, Vertex<T> endingVertex, List<List<Edge<T>>> returnList, Stack<int> numbers, List<Edge<T>> oldPath)
        {
            if (startingVertex.Equals(endingVertex))
            {
                return;
            }

            List<Edge<T>> newPath;
            foreach (Edge<T> newEdge in startingVertex.Edges)
            {
                newPath = new List<Edge<T>>();
                newPath = oldPath.Concat(new List<Edge<T>> { newEdge }).ToList();
                returnList[numbers.Pop()] = newPath;
                FindShortestPath(newEdge.EndingVertex, endingVertex, returnList, numbers, newPath);
            }
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
            for (int i = 0; i < vertices.Count; i++)
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


        public List<T> Dijkstra(T startValue, T endValue)
        {
            Vertex<T> startingVertex = Find(startValue);
            Vertex<T> endingVertex = Find(endValue);

            List<T> returnList = new List<T>();
            if(startingVertex == null || endingVertex == null)
            {
                return returnList;
            }

            Dictionary<Vertex<T>, (int distance, Vertex<T> parentVertex, bool wasVisited)> VertexMap = new Dictionary<Vertex<T>, (int, Vertex<T>, bool)>();


            foreach(Vertex<T> vertex in Vertices)
            {
                VertexMap.Add(vertex, (int.MaxValue, null, false));
            }
            VertexMap[startingVertex] = (0, null, false);

            var PriorityQueue = new HeapTree<Vertex<T>>(Comparer<Vertex<T>>.Create((a, b) => VertexMap[a].distance.CompareTo(VertexMap[b].distance)));

            PriorityQueue.Add(startingVertex);
            Dijkstra(PriorityQueue, VertexMap, endingVertex);

            Vertex<T> currentVertex = endingVertex;
            while(VertexMap[currentVertex].Item2 != null)
            {
                returnList.Add(currentVertex.Value);
                currentVertex = VertexMap[currentVertex].Item2;
            }
            returnList.Add(startingVertex.Value) ;
            return returnList;
        }
        
        private void Dijkstra(HeapTree<Vertex<T>> PriorityQueue, Dictionary<Vertex<T>, (int, Vertex<T>, bool)> VertexMap, Vertex<T> endingVertex)
        {
            Vertex<T> currentVertex = PriorityQueue.Pop();
            int currentDistance = VertexMap[currentVertex].Item1;
            foreach(Edge<T> edge in currentVertex.Edges)
            {
                if(currentDistance + edge.Weight < VertexMap[edge.EndingVertex].Item1)
                {
                    ChangeMap(VertexMap, edge.EndingVertex, currentDistance + edge.Weight, currentVertex, false);
                    PriorityQueue.Add(edge.EndingVertex);
                }
                else if(VertexMap[edge.EndingVertex].Item3 == false && !PriorityQueue.Contains(edge.EndingVertex))
                {
                    PriorityQueue.Add(edge.EndingVertex);
                }
            }
            if(currentVertex.Equals(endingVertex))
            {
                return;
            }
            else
            {
                ChangeMap(VertexMap, currentVertex, true);
            }
            if(PriorityQueue.Count != 0)
            {
                Dijkstra(PriorityQueue, VertexMap, endingVertex);
            }
        }

        private void ChangeMap(Dictionary<Vertex<T>, (int, Vertex<T>, bool)> map, Vertex<T> index, int distance, Vertex<T> parent, bool wasVisited)
        {
            map[index] = (distance, parent, wasVisited);
        }

        private void ChangeMap(Dictionary<Vertex<T>, (int, Vertex<T>, bool)> map, Vertex<T> index, int distance)
        {
            map[index] = (distance, map[index].Item2, map[index].Item3);
        }

        private void ChangeMap(Dictionary<Vertex<T>, (int, Vertex<T>, bool)> map, Vertex<T> index, Vertex<T> parent)
        {
            map[index] = (map[index].Item1, parent, map[index].Item3);
        }

        private void ChangeMap(Dictionary<Vertex<T>, (int, Vertex<T>, bool)> map, Vertex<T> index, bool wasVisited)
        {
            map[index] = (map[index].Item1, map[index].Item2, wasVisited);
        }

        private void ChangeMap(Dictionary<Vertex<T>, (int, Vertex<T>, bool)> map, Vertex<T> index, int distance, bool wasVisited)
        {
            map[index] = (distance, map[index].Item2, wasVisited);
        }
    }
}
