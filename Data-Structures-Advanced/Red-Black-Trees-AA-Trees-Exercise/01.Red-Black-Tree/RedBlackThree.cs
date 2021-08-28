namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private bool Red = true;
        private bool Black = false;

        private Node root;

        public RedBlackTree()
        {

        }

        public int Count => this.root?.Count ?? 0;

        public void Insert(T element)
        {
            this.root = Insert(this.root, element);
            this.root.Color = Black;
        }

        public T Select(int rank)
        {
            return Select(this.root, rank).Value;
        }

        public int Rank(T element)
        {
            return Rank(this.root, element);
        }

        public bool Contains(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (node.Value.Equals(element))
                {
                    return true;
                }

                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            return null;
        }

        public void DeleteMin()
        {
            this.root = DeleteMin(this.root);
            this.root.Color = Black;
        }

        public void DeleteMax()
        {
            this.root = DeleteMax(this.root);
            this.root.Color = Black;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return null;
        }

        public void Delete(T element)
        {
            this.root = Delete(this.root, element);
        }

        public T Ceiling(T element)
        {
            return Ceil(this.root, element);
        }

        public T Floor(T element)
        {
            return this.Floor(this.root, element);
        }

        public void EachInOrder(Action<T> action)
        {
            DFS(this.root, action);
        }

        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                node = new Node(value)
                {
                    Color = Red,
                };
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }

            node = ReBalance(node);
            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return node;
        }

        private Node ReBalance(Node node)
        {
            if (this.IsRed(node.Right) && !this.IsRed(node.Left))
            {
                node = LeftRoration(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = RightRotation(node);
            }
            if (this.IsRed(node.Right) && this.IsRed(node.Left))
            {
                this.FlipColors(node);
            }
            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return node;
        }

        private void FlipColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }

        private Node LeftRoration(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = node.Color;
            node.Color = Red;

            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return temp;
        }

        private Node RightRotation(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = node.Color;
            node.Color = Red;

            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return temp;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }

            return true;
        }

        private int CountNodes(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);
            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return node;
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);
            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return node;
        }

        private Node Delete(Node node, T element)
        {
            var comparer = element.CompareTo(node.Value);

            if (comparer < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (comparer > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                var replacement = Smallest(node.Left);

                node.Value = replacement.Value;
                node.Left = Delete(node.Left, replacement.Value);

                node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            }

            node = ReBalance(node);
            return node;
        }

        private Node Smallest(Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left != null)
            {
                return Smallest(node.Left);
            }
            else
            {
                return node;
            }
        }

        private void DFS(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            DFS(node.Left, action);
            action(node.Value);
            DFS(node.Right, action);
        }

        private T Floor(Node root, T key)
        {
            if (root == null)
                return default(T);

            /* If root->data is equal to key */
            if (root.Value.Equals(key))
                return root.Value;

            /* If root->data is greater than the key */
            if (root.Value.CompareTo(key) > 0)
                return Floor(root.Left, key);

            /* Else, the floor may lie in right subtree
        or may be equal to the root*/
            T floorValue = Floor(root.Right, key);
            bool isValid = floorValue != null && floorValue.CompareTo(key) <= 0;
            return isValid ? floorValue : root.Value;
        }

        private T Ceil(Node node, T input)
        {
            // Base case
            if (node == null)
            {
                return default(T);
            }

            // We found equal key
            if (node.Value.Equals(input))
            {
                return node.Value;
            }

            // If root's key is smaller, ceil must be in right subtree
            if (node.Value.CompareTo(input) < 0)
            {
                return Ceil(node.Right, input);
            }

            // Else, either left subtree or root has the ceil value
            T ceil = Ceil(node.Left, input);
            bool isValid = ceil != null && ceil.CompareTo(input) > 0;
            return isValid ? ceil : node.Value; // (ceil >= input)
        }

        private int Rank(Node tree, T val)
        {
            int rank = 0;
            while (tree != null)
            {
                if (val.CompareTo(tree.Value) < 0) // move to left subtree
                {
                    tree = tree.Left;
                }
                else if (val.CompareTo(tree.Value) > 0)
                {
                    rank += 1 + tree.Left.Count;
                    tree = tree.Right;
                }
                else
                {
                    return rank + tree.Left.Count;
                }
            }
            return rank; // not found
        }

        private Node Select(Node node, int key)
        {
            // Return Node containing key of rank k.
            if (node == null) return null;

            int t = node.Left.Count;

            if (t > key)
            {
                return Select(node.Left, key);
            }
            else if (t < key)
            {
                return Select(node.Right, key - t - 1);
            }
            else
            {
                return node;
            }
        }


        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }
            public bool Color { get; set; }
        }
    }
}