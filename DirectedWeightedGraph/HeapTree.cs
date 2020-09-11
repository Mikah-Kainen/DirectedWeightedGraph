using System;
using System.Collections.Generic;
using System.Text;

namespace DirectedWeightedGraph
{
    class HeapTree<T>
    {

        public List<T> Values;
        public T Root { get { return Values[0]; } }
        public int Count { get { return Values.Count; } }

        public HeapTree(Comparer<T> comparer)
        {
            Values = new List<T>();
        }
        
        public void Add(T value)
        {
            Values.Add(value);
            if(Root.Equals(default))
            {
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
            int leftIndex = (index * 2) + 1;
            int rightIndex = (index * 2) + 2;

            if (rightIndex >= Values.Count)
            {
                if (leftIndex < Values.Count && Values[leftIndex].CompareTo(Values[index]) < 0)
                {
                    SwapValues(index, leftIndex);
                }
                return;
            }

            int smallerIndex;
            if (Values[leftIndex].CompareTo(Values[rightIndex]) < 0)
            {
                smallerIndex = leftIndex;
            }
            else
            {
                smallerIndex = rightIndex;
            }

            if (Values[index].CompareTo(Values[smallerIndex]) > 0)
            {
                SwapValues(index, smallerIndex);
                HeapifyDown(smallerIndex);
            }
        }

        private void SwapValues(int index, int otherIndex)
        {
            T temp = Values[index];
            Values[index] = Values[otherIndex];
            Values[otherIndex] = temp;
        }

    }
}
