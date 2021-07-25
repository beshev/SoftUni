namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return IndentedPreOrderDFS(this, indent);
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            return InOrderDFS(this);
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            return PostOrderDFS(this);
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            return PreOrderDFS(this);
        }

        public void ForEachInOrder(Action<T> action)
        {
            ForEachInOrderDFS(this, action);
        }




        private string IndentedPreOrderDFS(IAbstractBinaryTree<T> treel, int indent)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{new string(' ', indent)}{treel.Value.ToString()}");

            if (treel.LeftChild != null)
            {
                sb.AppendLine(IndentedPreOrderDFS(treel.LeftChild, indent + 2));
            }
            if (treel.RightChild != null)
            {
                sb.AppendLine(IndentedPreOrderDFS(treel.RightChild, indent + 2));
            }

            return sb.ToString().TrimEnd();
        }

        private List<IAbstractBinaryTree<T>> PreOrderDFS(IAbstractBinaryTree<T> treel)
        {
            var result = new List<IAbstractBinaryTree<T>>();

            result.Add(treel);

            if (treel.LeftChild != null)
            {
                result.AddRange(PreOrderDFS(treel.LeftChild));
            }
            if (treel.RightChild != null)
            {
                result.AddRange(PreOrderDFS(treel.RightChild));
            }

            return result;
        }

        private List<IAbstractBinaryTree<T>> InOrderDFS(IAbstractBinaryTree<T> treel)
        {
            var result = new List<IAbstractBinaryTree<T>>();


            if (treel.LeftChild != null)
            {
                result.AddRange(InOrderDFS(treel.LeftChild));
            }

            result.Add(treel);

            if (treel.RightChild != null)
            {
                result.AddRange(InOrderDFS(treel.RightChild));
            }


            return result;
        }

        private List<IAbstractBinaryTree<T>> PostOrderDFS(IAbstractBinaryTree<T> treel)
        {
            var result = new List<IAbstractBinaryTree<T>>();


            if (treel.LeftChild != null)
            {
                result.AddRange(PostOrderDFS(treel.LeftChild));
            }

            if (treel.RightChild != null)
            {
                result.AddRange(PostOrderDFS(treel.RightChild));
            }

            result.Add(treel);


            return result;
        }

        private void ForEachInOrderDFS(IAbstractBinaryTree<T> treel,Action<T> action)
        {
            if (treel.LeftChild != null)
            {
                ForEachInOrderDFS(treel.LeftChild,action);
            }

            action(treel.Value);

            if (treel.RightChild != null)
            {
                ForEachInOrderDFS(treel.RightChild,action);
            }

        }
    }
}
