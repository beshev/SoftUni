namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        private Node<T> _last;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currnetNode = _head;

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

        public T Dequeue()
        {
            EnsureNotEmpty();

            var removedHead = _head;

            _head = _head.Next;

            Count--;

            return removedHead.Value;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                _last = newNode;
            }


            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return _head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = _head;

            while (currentHead != null)
            {

                yield return currentHead.Value;

                currentHead = currentHead.Next;
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