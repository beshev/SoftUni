﻿namespace CustomDoublyLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }
}
