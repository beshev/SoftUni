using System;
using System.Text;

namespace ImplementingStackAndList

{
    class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        private void Resize()
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

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default;
        }

        private void ShiftRight(int index)
        {

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        public void Add(int value)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = value;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int toReturn = items[index];
            items[index] = default;
            ShiftLeft(index);
            Count--;
            if (Count == items[items.Length / 4])
            {
                Shrink();
            }
            return toReturn;

        }

        public void Insert(int index, int item)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count == items.Length)
            {
                Resize();
            }
            ShiftRight(index);
            items[index] = item;
            Count++;
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

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= Count || secondIndex >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            items[firstIndex] = items[firstIndex] ^ items[secondIndex];
            items[secondIndex] = items[firstIndex] ^ items[secondIndex];
            items[firstIndex] = items[firstIndex] ^ items[secondIndex];
        }

        public int Find(Predicate<int> predicate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (predicate(items[i]))
                {
                    return items[i];
                }
            }
            return default;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                int temp = items[i];
                items[i] = items[Count - i - 1];
                items[Count - 1 - i] = temp;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (i == Count - 1)
                {
                    sb.Append($"{items[i]}");
                }
                else
                {
                    sb.Append($"{items[i]}, ");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
