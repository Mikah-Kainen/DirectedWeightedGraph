using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class VertexMapValue<T>
    {
        public double distance { get; set; }
        public Vertex<T> founder { get; set; }
        public bool wasVisited { get; set; }
        public double finalDistance { get; set; }
        public VertexMapValue(double distance, Vertex<T> founder, bool wasVisited, double finalDistance)
        {
            this.distance = distance;
            this.founder = founder;
            this.wasVisited = wasVisited;
            this.finalDistance = finalDistance;
        }
    }
}
