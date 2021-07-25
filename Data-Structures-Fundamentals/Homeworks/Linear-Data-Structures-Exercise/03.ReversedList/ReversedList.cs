namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public ReversedList()
            : this(DEFAULT_CAPACITY)
        {
        }

        public ReversedList(int capacity)
        {

            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidIndexChecker(index);

                return _items[Count - index - 1];
            }
            set
            {
                ValidIndexChecker(index);

                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (_items.Length == Count)
            {
                _items = ResizeArray();
            }

            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public int IndexOf(T item)
        {
            int index = _items.ToList().IndexOf(item);

            if (index == -1)
            {
                return -1;
            }

            index = Count - index - 1;

            return index;
        }

        public void Insert(int index, T item)
        {
            var newIndex = Count - index;

            ValidIndexChecker(index);
            LeftShift(newIndex);

            _items[newIndex] = item;

            Count++;
        }

        public bool Remove(T item)
        {
            int indexOf = IndexOf(item);

            if (indexOf == -1)
            {
                return false;
            }

            RemoveAt(indexOf);

            return true;

        }

        public void RemoveAt(int index)
        {
            var newIndex = Count - index;

            ValidIndexChecker(index);

            RightShift(newIndex);

            _items[Count - 1] = default;
            Count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();



        private void ValidIndexChecker(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void LeftShift(int index)
        {
            if (Count == _items.Length)
            {
                _items = ResizeArray();
            }

            for (int i = Count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
        }

        private void RightShift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
        }

        private T[] ResizeArray()
        {
            var newArray = new T[_items.Length * 2];

            Array.Copy(_items, newArray, Count);

            return newArray;
        }
    }
}