namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currnetNode = _top;

            while (currnetNode != null)
            {
                var value = currnetNode.Value;

                if (value.Equals(item))
                {
                    return true;
                }

                currnetNode = currnetNode.Next;
            }

            return false;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return _top.Value;
        }

        public T Pop()
        {
            EnsureNotEmpty();

            T removedValue = _top.Value;

            _top = _top.Next;
            Count--;

            return removedValue;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item);

            newNode.Next = _top;
            _top = newNode;

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _top;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empy!");
            }
        }
    }
}