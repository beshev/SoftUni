namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            // TODO: Create copy from root

            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => GetNodesCount(this.Root);

        public bool Contains(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (current.Value.Equals(element))
                {
                    return true;
                }

                if (element.CompareTo(current.Value) == -1)
                {
                    current = current.LeftChild;
                }
                else if (element.CompareTo(current.Value) == 1)
                {
                    current = current.RightChild;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            this.Root = BSTInsert(this.Root, element);
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            IAbstractBinarySearchTree<T> tree = null;

            var node = this.Root;
            while (node != null)
            {
                if (node.Value.Equals(element))
                {
                    tree =  new BinarySearchTree<T>(node);
                    break;
                }

                if (element.CompareTo(node.Value) == -1)
                {
                    node = node.LeftChild;
                }
                else if (element.CompareTo(node.Value) == 1)
                {
                    node = node.RightChild;
                }
            }

            return tree;
        }

        public void EachInOrder(Action<T> action)
        {
            InOrderForEach(this.Root, action);
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();

            InOrder(this.Root, lower, upper, result);

            return result;
        }

        public void DeleteMin()
        {
            ValidateIfEmpty();

            if (this.Root.LeftChild == null)
            {
                this.Root = this.Root.RightChild;
                return;
            }

            var node = this.Root;

            while (node.LeftChild.LeftChild != null)
            {
                node = node.LeftChild;
            }

            //I'm made this because I don't wanna lose values
            node.LeftChild = node.LeftChild.RightChild;
        }

        public void DeleteMax()
        {
            ValidateIfEmpty();

            if (this.Root.RightChild == null)
            {
                this.Root = this.Root.LeftChild;
                return;
            }

            var node = this.Root;

            while (node.RightChild.RightChild != null)
            {
                node = node.RightChild;
            }

            //I'm made this because I don't wanna lose values
            node.RightChild = node.RightChild.LeftChild;
        }

        public int GetRank(T element)
        {
            return GetRankCount(this.Root, element);
        }

        private int GetRankCount(Node<T> node, T element)
        {

            if (node == null)
            {
                return 0;
            }

            int count = 0;

            if (node.Value.CompareTo(element) < 0)
            {
                count++;
            }

            if (node.LeftChild != null)
            {
                count += GetRankCount(node.LeftChild, element);
            }
            if (node.RightChild != null)
            {
                count += GetRankCount(node.RightChild, element);
            }

            return count;
        }

        private Node<T> BSTInsert(Node<T> root, T element)
        {
            if (root == null)
            {
                return new Node<T>(element, null, null);
            }

            if (element.CompareTo(root.Value) == -1)
            {
                root.LeftChild = BSTInsert(root.LeftChild, element);
            }
            else if (element.CompareTo(root.Value) == 1)
            {
                root.RightChild = BSTInsert(root.RightChild, element);
            }

            return root;
        }

        private void ValidateIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void InOrder(Node<T> root, T lower, T upper, List<T> result)
        {
            if (root == null)
            {
                return;
            }

            if (root.Value.CompareTo(lower) >= 0 && root.Value.CompareTo(upper) <= 0)
            {
                result.Add(root.Value);
            }

            InOrder(root.LeftChild, lower, upper, result);
            InOrder(root.RightChild, lower, upper, result);


        }

        private void InOrderForEach(Node<T> root, Action<T> action)
        {
            if (root == null)
            {
                return;
            }

            InOrderForEach(root.LeftChild, action);

            action(root.Value);

            InOrderForEach(root.RightChild, action);


        }

        private int GetNodesCount(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            int count = 1;

            count += GetNodesCount(root.LeftChild);
            count += GetNodesCount(root.RightChild);

            return count;
        }
    }
}
