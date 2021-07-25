namespace _02.LowestCommonAncestor
{
    using System;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {

            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;

            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            T currentPaterntValue = default;

            T result = Search(this, currentPaterntValue, first, second);

            return result;
        }

        private T Search(BinaryTree<T> root, T parentValue, T first, T second)
        {
            if (Contains(root, first) && Contains(root, second))
            {
                parentValue = root.Value;
            }

            if (root.LeftChild != null)
            {
                parentValue = Search(root.LeftChild, parentValue, first, second);
            }

            if (root.RightChild != null)
            {
                parentValue = Search(root.RightChild, parentValue, first, second);
            }

            return parentValue;
        }

        private bool Contains(BinaryTree<T> root, T element)
        {
            if (root.Value.Equals(element))
            {
                return true;
            }

            bool isFind = false;
            if (root.LeftChild != null)
            {
                isFind = Contains(root.LeftChild, element);
            }

            if (isFind)
            {
                return isFind;
            }

            if (root.RightChild != null)
            {
                isFind = Contains(root.RightChild, element);
            }

            return isFind;

        }
    }
}
