using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class HeapTree<T> where T : IComparable<T>
    {

        public List<T> Values;
        public T Root;
        public int Count { get { return Values.Count; } }

        public HeapTree()
        {
            Values = new List<T>();
            Root = default;
        }
        
        public void Add(T value)
        {
            Values.Add(value);
            if(Root.Equals(default))
            {
                Root = value;
                return;
            }

            HeapifyUp(Values.Count - 1);
        }

        private int FindParent(int index)
        {
            return (index - 1) / 2;
        }

        private void HeapifyUp(int index)
        {
            if(index == 0)
            {
                Root = Values[0];
                return;
            }
            int parentIndex = FindParent(index);
            if(Values[index].CompareTo(Values[parentIndex]) < 0)
            {
                T tempHolder = Values[parentIndex];
                Values[parentIndex] = Values[index];
                Values[index] = tempHolder;
                HeapifyUp(parentIndex);
            }
        }

        public T Pop()
        {
            T returnValue = Root;
            Values[0] = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            HeapifyDown(0);
            return returnValue;
        }

        private void HeapifyDown(int index)
        {

        }

    }
}
