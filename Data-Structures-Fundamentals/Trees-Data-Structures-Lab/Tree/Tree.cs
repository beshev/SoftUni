namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private static bool isRootDelete = false;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            children.ToList().ForEach(x => { x.Parent = this; _children.Add(x); });
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            if (isRootDelete)
            {
                return new List<T>();
            }

            List<T> result = new List<T>();
            Queue<Tree<T>> trees = new Queue<Tree<T>>();

            trees.Enqueue(this);

            while (trees.Count > 0)
            {
                var subTree = trees.Dequeue();
                result.Add(subTree.Value);
                foreach (var child in subTree.Children)
                {
                    trees.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            if (isRootDelete)
            {
                return new List<T>();
            }

            return DFS(this);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            if (this.Value.Equals(parentKey))
            {
                this._children.Add(child);
                child.Parent = this;
                return;
            }

            var tree = DfsSearch(parentKey);

            CheckEmptyNode(tree);
            tree.AddChild(parentKey, child);

        }

        public void RemoveNode(T nodeKey)
        {
            var subTree = BfsSearch(nodeKey);
            CheckEmptyNode(subTree);


            if (subTree.Parent == null)
            {
                subTree._children.Clear();
                isRootDelete = true;
                subTree.Value = default(T);
            }
            else
            {
                subTree.Parent.RemoveChild(subTree);
            }


        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = BfsSearch(firstKey);
            var secondNode = DfsSearch(secondKey);

            CheckEmptyNode(firstNode);
            CheckEmptyNode(secondNode);

            if (firstNode.Parent == null)
            {
                SwapRoot(secondNode);
            }
            else
            {
                firstNode.Parent = secondNode.Parent;
                secondNode.Parent = firstNode.Parent;

                SwapTrees(firstNode, secondNode);
            }

        }

        private void SwapRoot(Tree<T> secondNode)
        {
            this._children.Clear();
            this._children.AddRange(secondNode._children);
            secondNode.Parent = null;
            this.Value = secondNode.Value;
        }

        private static void SwapTrees(Tree<T> first, Tree<T> second)
        {
            int indexOfFirst = first.Parent._children.IndexOf(first);
            int indexOfSecond = second.Parent._children.IndexOf(second);

            first.Parent._children[indexOfFirst] = second;
            second.Parent._children[indexOfSecond] = first;
        }

        private Tree<T> BfsSearch(T parentKey)
        {
            Queue<Tree<T>> trees = new Queue<Tree<T>>();

            trees.Enqueue(this);

            while (trees.Count > 0)
            {
                var subTree = trees.Dequeue();

                if (subTree.Value.Equals(parentKey))
                {
                    return subTree;
                }

                foreach (var child in subTree.Children)
                {
                    trees.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> DfsSearch(T parentKey)
        {
            if (this.Value.Equals(parentKey))
            {
                return this;
            }

            Tree<T> result = null;
            foreach (var child in this.Children)
            {
                result = child.DfsSearch(parentKey);
                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        private ICollection<T> DFS(Tree<T> root)
        {
            List<T> result = new List<T>();

            foreach (var child in root.Children)
            {
                result.AddRange(DFS(child));
            }

            result.Add(root.Value);

            return result;
        }

        private bool RemoveChild(Tree<T> subTree)
        {
            subTree.Parent = null;
            foreach (var child in subTree.Children)
            {
                child.Parent = null;
            }
            return this._children.Remove(subTree);
        }

        private void CheckEmptyNode(Tree<T> tree)
        {
            if (tree == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
