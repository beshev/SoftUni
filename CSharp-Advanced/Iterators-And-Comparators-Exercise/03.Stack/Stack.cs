using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 4;

        private T[] items = new T[INITIAL_CAPACITY];

        public int Count { get; private set; }

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        public void Push(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }

        public void Pop()
        {
            if (Count == items.Length / 4)
            {
                Shrink();
            }
            if (Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                items[Count - 1] = default;
                Count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[Count - 1 - i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
