using System;

namespace ImplementingStackAndList
{
    class CustomStack
    {
        private const int ININTIAL_CAPACITY = 4;

        private int[] items;

        public CustomStack()
        {
            items = new int[ININTIAL_CAPACITY];
        }

        public CustomStack(int[] arr)
        {
            items = arr;
            Count = arr.Length;
        }

        public int Count { get; set; }

        public void Resize()
        {
            int[] copy = new int[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        public void Push(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }

        public int Pop()
        {
            if (Count == items.Length / 4)
            {
                Shrink();
            }
            if (Count == 0)
            {
                throw new ArgumentNullException("Stack is empty");
            }
            int toReturn = items[Count - 1];
            items[Count - 1] = default;
            Count--;
            return toReturn;
        }

        public int Peek()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Stack is empty");
            }
            return items[Count - 1];
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            items = new int[ININTIAL_CAPACITY];
            Count = 0;
        }


    }
}
