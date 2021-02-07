using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    class LinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddTail(Node newTail)
        {
            if (Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;

            }
        }

        public int RemoveHead()
        {
            if (Head == null)
            {
                throw new NullReferenceException("List is empty");
            }
            int result = Head.Value;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            return result;
        }

        public int RemoveTail()
        {
            if (Tail == null)
            {
                throw new NullReferenceException("List is empty");
            }
            int result = Tail.Value;
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
            return result;
        }

        public void ForEach(Action<Node> actions)
        {
            var node = Head;
            while (node != null)
            {
                actions(node);
                node = node.Next;
            }
        }

        public int[] ToArray()
        {
            List<int> listArr = new List<int>();
            ForEach(node => listArr.Add(node.Value));
            return listArr.ToArray();
        }

        public void Print()
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public void ReversePrint()
        {
            Node currentTail = Tail;
            while (currentTail != null)
            {
                Console.WriteLine(currentTail.Value);
                currentTail = currentTail.Next;
            }
        }
    }
}
