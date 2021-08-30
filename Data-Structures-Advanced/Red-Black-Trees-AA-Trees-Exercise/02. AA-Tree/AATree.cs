namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private int count;
        private Node<T> root;

        public int CountNodes()
        {
            return this.count;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = Insert(this.root, element);
        }

        public bool Search(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (node.Element.Equals(element))
                {
                    return true;
                }

                if (element.CompareTo(node.Element) < 0)
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

        public void InOrder(Action<T> action)
        {
            InOrderDFS(this.root, action);
        }

        public void InOrder()
        {
            InOrderDFS(this.root, 0);
        }

        public void PreOrder(Action<T> action)
        {
            PreOrderDFS(this.root, action);
        }

        public void PostOrder(Action<T> action)
        {
            PostOrderDFS(this.root, action);
        }

        private void InOrderDFS(Node<T> node, int indend)
        {
            if (node == null)
            {
                return;
            }

            InOrderDFS(node.Left, indend + 3);
            Console.Write(new string(' ', indend));
            Console.WriteLine(node.Element);
            InOrderDFS(node.Right ,indend + 3);
        }

        private Node<T> Insert(Node<T> node, T element)
        {
            if (node == null)
            {
                count++;
                return new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = Insert(node.Left, element);
            }
            else if (element.CompareTo(node.Element) > 0)
            {
                node.Right = Insert(node.Right, element);
            }

            node = Skew(node);
            node = Split(node);

            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Level.Equals(node.Right.Right.Level))
            {
                Node<T> right = node.Right;
                node.Right = right.Left;
                right.Left = node;
                right.Level = right.Level + 1;

                return right;
            }
            else
            {
                return node;
            }
        }

        private Node<T> Skew(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node;
            }
            else if (node.Left.Level == node.Level)
            {
                Node<T> left = node.Left;
                node.Left = left.Right;
                left.Right = node;
                return left;
            }
            else
            {
                return node;
            }
        }

        private void PreOrderDFS(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Element);
            PreOrderDFS(node.Left, action);
            PreOrderDFS(node.Right, action);
        }

        private void PostOrderDFS(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            PostOrderDFS(node.Left, action);
            PostOrderDFS(node.Right, action);
            action(node.Element);
        }

        private void InOrderDFS(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            InOrderDFS(node.Left, action);
            action(node.Element);
            InOrderDFS(node.Right, action);
        }
    }
}