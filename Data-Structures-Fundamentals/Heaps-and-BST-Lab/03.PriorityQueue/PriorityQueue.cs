namespace _03.PriorityQueue
{
    using System;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private T[] array;
        private const int InitialSize = 4;

        public PriorityQueue()
        {
            this.array = new T[InitialSize];
        }


        public int Size { get; private set; }

        public T Dequeue()
        {
            ValidIfEmpty();

            this.Swap(this.Size - 1, 0);

            var resul = this.array[this.Size - 1];
            this.array[--this.Size] = default;

            HeapifyDown(0);

            return resul;
        }

        public void Add(T element)
        {
            if (this.Size == this.array.Length)
            {
                Grow();
            }

            this.array[this.Size] = element;

            HeapifyUp(this.Size);

            this.Size++;
        }

        public T Peek()
        {
            ValidIfEmpty();

            return this.array[0];
        }

        private void ValidIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
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

        private void HeapifyDown(int index)
        {
            int childIndex = GetBiggestChildIndex(index);

            while (IsGreater(childIndex, index))
            {
                this.Swap(childIndex, index);
                index = childIndex;
                childIndex = GetBiggestChildIndex(index);
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

        private int GetBiggestChildIndex(int index)
        {
            var firstChildIndex = GetChildIndex(index, 1);
            var secondChildIndex = GetChildIndex(index, 2);

            if (IsGreater(firstChildIndex,secondChildIndex))
            {
                return firstChildIndex;
            }

            return secondChildIndex;
        }

        // ChildNumber can be Enum!
        private int GetChildIndex(int index, int childNumber)
        {
            var childIndex = 2 * index + childNumber;

            if (childIndex < 0 || childIndex >= this.Size)
            {
                return index;
            }

            return childIndex;
        }

        private void Grow()
        {
            T[] newArray = new T[this.array.Length * 2];

            Array.Copy(this.array, newArray, this.array.Length);

            this.array = newArray;
        }
    }
}
