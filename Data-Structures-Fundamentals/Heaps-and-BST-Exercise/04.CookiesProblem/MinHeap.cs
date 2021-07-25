namespace _04.CookiesProblem
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public MinHeap(IEnumerable<T> elements)
            : this()
        {
            foreach (var item in elements)
            {
                this.Add(item);
            }
        }

        public int Size => _elements.Count;

        public T Dequeue()
        {
            ValidateIfEmpty();

            var result = _elements[0];
            _elements.RemoveAt(0);

            return result;
        }

        public void Add(T element)
        {
            _elements.Add(element);


            int startIndex = this.Size - 1;

            while (startIndex != 0 && _elements[startIndex].CompareTo(_elements[startIndex - 1]) == -1)
            {
                var temp = _elements[startIndex - 1];
                _elements[startIndex - 1] = _elements[startIndex];
                _elements[startIndex] = temp;

                startIndex--;
            }
        }

        public T Peek()
        {
            ValidateIfEmpty();

            return _elements[0];
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
