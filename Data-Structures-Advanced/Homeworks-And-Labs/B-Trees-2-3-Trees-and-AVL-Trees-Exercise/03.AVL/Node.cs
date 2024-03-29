﻿namespace _03.AVL
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public int Height;

        public Node(T value,Node<T> parent = null)
        {
            this.Value = value;
            this.Height = 1;
        }
    }
}
