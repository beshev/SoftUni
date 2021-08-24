namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public TwoThreeTree()
        {

        }

        public void Insert(T key)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(key);
                return;
            }

            this.root = Insert(this.root, key);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T newElement)
        {
            if (node.IsLeaf())
            {
                return this.MergeNewElement(node, new TreeNode<T>(newElement));
            }

            TreeNode<T> returNode;

            if (newElement.CompareTo(node.LeftKey) < 0)
            {
                returNode = Insert(node.LeftChild, newElement);

                if (returNode == node.LeftChild)
                {
                    return node;
                }
                else
                {
                    return this.MergeNewElement(node, returNode);
                }
            }
            else if (node.IsTwoNode() || newElement.CompareTo(node.RightKey) < 0)
            {
                returNode = Insert(node.MiddleChild, newElement);

                if (returNode == node.MiddleChild)
                {
                    return node;
                }
                else
                {
                    return this.MergeNewElement(node, returNode);
                }
            }
            else
            {
                returNode = Insert(node.RightChild, newElement);

                if (returNode == node.RightChild)
                {
                    return node;
                }
                else
                {
                    return this.MergeNewElement(node, returNode);
                }
            }
        }

        private TreeNode<T> MergeNewElement(TreeNode<T> currentNode, TreeNode<T> node)
        {
            if (currentNode.IsTwoNode())
            {
                if (currentNode.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    currentNode.RightKey = node.LeftKey;
                    currentNode.MiddleChild = node.LeftChild;
                    currentNode.RightChild = node.MiddleChild;
                }
                else
                {
                    currentNode.RightKey = currentNode.LeftKey;
                    currentNode.RightChild = currentNode.MiddleChild;

                    currentNode.LeftKey = node.LeftKey;
                    currentNode.MiddleChild = node.MiddleChild;
                    currentNode.LeftChild = node.LeftChild;
                }

                return currentNode;
            }
            else if (currentNode.LeftKey.CompareTo(node.LeftKey) >= 0)
            {
                var newNode = new TreeNode<T>(currentNode.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = currentNode,
                };

                node.LeftChild = currentNode.LeftChild;
                currentNode.LeftChild = currentNode.MiddleChild;
                currentNode.RightChild = null;
                currentNode.LeftKey = currentNode.RightKey;
                currentNode.RightKey = default;

                return newNode;
            }
            else if (currentNode.RightKey.CompareTo(node.LeftKey) >= 0)
            {
                node.MiddleChild = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = currentNode.RightChild,
                };

                node.LeftChild = currentNode;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return node;
            }
            else
            {
                var newNode = new TreeNode<T>(currentNode.RightKey)
                {
                    MiddleChild = node,
                    LeftChild = currentNode,
                };

                node.LeftChild = currentNode.RightChild;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newNode;
            }
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
