namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
         private Node<T> _head;

        private Node<T> _last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (_last == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                newNode.Previous = _last;
                _last = newNode;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return _head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            return _last.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var removedHead = _head;

            _head = _head.Next;

            Count--;
            return removedHead.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var removedlast = _last;

            _last = _last.Previous;


            Count--;
            return removedlast.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = _head;

            while (currentHead != null)
            {

                yield return currentHead.Item;

                currentHead = currentHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();




        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("LinkedList is empty!");
            }
        }
    }
}