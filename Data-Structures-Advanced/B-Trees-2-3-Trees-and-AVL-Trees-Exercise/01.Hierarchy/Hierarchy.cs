namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Dictionary<T, Node<T>> values;
        private T rootValue;

        public Hierarchy(T defautRootValue)
        {
            this.values = new Dictionary<T, Node<T>>();
            this.rootValue = defautRootValue;

            this.values.Add(defautRootValue, new Node<T>(defautRootValue));
        }

        public int Count => this.values.Count;

        public void Add(T element, T child)
        {
            if (!this.values.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            if (this.values.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var newNode = new Node<T>(child);
            var parentNode = this.values[element];
            newNode.Parent = parentNode;

            parentNode.Children.Add(newNode);
            this.values.Add(child, newNode);
        }

        public void Remove(T element)
        {
            if (rootValue.Equals(element))
            {
                throw new InvalidOperationException();
            }
            if (!this.values.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var nodeToRemove = this.values[element];
            var parentNode = this.values[nodeToRemove.Parent.Value];

            parentNode.Children.AddRange(nodeToRemove.Children);
            parentNode.Children.Remove(nodeToRemove);

            foreach (var child in nodeToRemove.Children)
            {
                child.Parent = parentNode;
            }
            this.values.Remove(nodeToRemove.Value);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            var parent = this.values[element];

            return parent.Children.Select(x => x.Value).ToArray();
        }

        public T GetParent(T element)
        {
            if (!this.values.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var node = this.values[element];

            if (node.Parent == null)
            {
                return default(T);
            }

            return node.Parent.Value;
        }

        public bool Contains(T element)
        {
            return this.values.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var currentValues = this.values.Values.Select(x => x.Value).ToList();
            var otherValues = other.values.Values.Select(x => x.Value).ToList();

            return currentValues.Intersect(otherValues);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var root = this.values.Values.First();

            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> GetNodeDFS(Node<T> root, T element)
        {
            if (root.Value.Equals(element))
            {
                return root;
            }

            Node<T> node = default;

            foreach (var child in root.Children)
            {
                if (node != null)
                {
                    break;
                }
                node = GetNodeDFS(child, element);
            }

            return node;
        }
    }
}