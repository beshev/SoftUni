namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private T[] array;
        private const int InitialSize = 4;
        public MaxHeap()
        {
            this.array = new T[InitialSize];
        }

        public int Size { get; private set; }

        public void Add(T element)
        {
            if (this.Size == array.Length)
            {
                this.Grow();
            }

            this.array[this.Size] = element;

            this.HeapifyUp(this.Size);

            this.Size++;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return this.array[0];
        }


        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.array[parentIndex];
            this.array[parentIndex] = this.array[index];
            this.array[index] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.array[index].CompareTo(this.array[parentIndex]) == 1;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void Grow()
        {
            T[] newArray = new T[this.array.Length * 2];

            Array.Copy(this.array, newArray, this.array.Length);

            this.array = newArray;
        }
    }
}
