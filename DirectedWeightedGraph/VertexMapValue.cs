using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class VertexMapValue<T>
    {
        public int distance { get; set; }
        public Vertex<T> founder { get; set; }
        public bool wasVisited { get; set; }
        public int finalDistance { get; set; }
        public VertexMapValue(int distance, Vertex<T> founder, bool wasVisited, int finalDistance)
        {
            this.distance = distance;
            this.founder = founder;
            this.wasVisited = wasVisited;
            this.finalDistance = finalDistance;
        }
    }
}
