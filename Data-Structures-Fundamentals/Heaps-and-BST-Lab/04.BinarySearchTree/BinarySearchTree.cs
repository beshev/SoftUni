namespace _04.BinarySearchTree
{
    using System;

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

        public bool Contains(T element)
        {
            return BSTSearch(this.Root, element) != null;
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
                return;
            }
            else
            {
                BSTInsert(this.Root, element);
            }
        }

        private Node<T> BSTInsert(Node<T> tree, T element)
        {
            if (tree == null)
            {
                return new Node<T>(element, null, null);
            }

            if (element.CompareTo(tree.Value) == -1)
            {
                tree.LeftChild = BSTInsert(tree.LeftChild, element);
            }
            else if(element.CompareTo(tree.Value) == 1)
            {
                tree.RightChild = BSTInsert(tree.RightChild, element);
            }

            return tree;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return BSTSearch(this.Root, element);
        }

        private IAbstractBinarySearchTree<T> BSTSearch(Node<T> tree, T element)
        {
            if (tree == null)
            {
                return null;
            }

            if (tree.Value.Equals(element))
            {
                return new BinarySearchTree<T>(tree);
            }

            IAbstractBinarySearchTree<T> subTree = null;
            if (element.CompareTo(tree.Value) == -1)
            {
                subTree = BSTSearch(tree.LeftChild, element);
            }
            else
            {
                subTree = BSTSearch(tree.RightChild, element);
            }

            return subTree;
        }
    }
}
