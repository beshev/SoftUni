﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Problem02.Stack
{
    public class Node<T>
    {

        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}