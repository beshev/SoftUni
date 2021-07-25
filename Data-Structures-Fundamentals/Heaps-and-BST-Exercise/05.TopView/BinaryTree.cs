namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            List<T> result = new List<T>();

           result.AddRange(GetTopLeftTrees());
           result.AddRange(GetTopRightTrees());

            return result;
        }

        private List<T> GetTopLeftTrees()
        {
            var list = new List<T>();

            var current = this;
            while (current != null)
            {
                list.Add(current.Value);
                current = current.LeftChild;
            }

            return list;
        }

        private List<T> GetTopRightTrees()
        {
            var list = new List<T>();
            var current = this.RightChild;

            while (current != null)
            {
                list.Add(current.Value);

                current = current.RightChild;
            }

            return list;
        }
    }
}
