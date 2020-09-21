using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    interface IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    public struct MPoint : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
