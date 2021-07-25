namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        private int currentLevel = 0;
        private Tree<T> leftDeepnestNode = null;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.Parent = null;
            _children = new List<Tree<T>>();
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            child.Parent = this;
            _children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            parent.AddChild(this);
        }

        public string GetAsString()
        {
            return DfsToString(this);
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            this.currentLevel = 0;
            this.leftDeepnestNode = null;

            DfsLeftDeepestNode(this);
            return this.leftDeepnestNode;
        }

        public List<T> GetLeafKeys()
        {
            List<T> leafs = new List<T>();

            Queue<Tree<T>> trees = new Queue<Tree<T>>();

            trees.Enqueue(this);

            while (trees.Count > 0)
            {
                var subTree = trees.Dequeue();
                if (subTree.Children.Count == 0)
                {
                    leafs.Add(subTree.Key);
                }

                foreach (var child in subTree.Children)
                {
                    trees.Enqueue(child);
                }
            }

            leafs.Sort();
            return leafs;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> leafs = new List<T>();

            Queue<Tree<T>> trees = new Queue<Tree<T>>();

            trees.Enqueue(this);

            while (trees.Count > 0)
            {
                var subTree = trees.Dequeue();
                if (subTree.Children.Count > 0 && subTree.Parent != null)
                {
                    leafs.Add(subTree.Key);
                }

                foreach (var child in subTree.Children)
                {
                    trees.Enqueue(child);
                }
            }

            leafs.Sort();
            return leafs;
        }

        public List<T> GetLongestPath()
        {
            this.currentLevel = 0;
            this.leftDeepnestNode = null;

            DfsLeftDeepestNode(this);

            List<T> result = new List<T>();

            while (this.leftDeepnestNode != null)
            {
                result.Add(this.leftDeepnestNode.Key);

                this.leftDeepnestNode = leftDeepnestNode.Parent;
            }

            result.Reverse();
            return result;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            Stack<T> result = new Stack<T>();
            List<List<T>> finnalResult = new List<List<T>>();

            AllPathsWithSum(this, finnalResult, result, 0, sum);

            return finnalResult;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> trees = new List<Tree<T>>();

            AllSubTreesWithSum(this, trees, sum);

            return trees;
        }


        public Tree<T> BfsSearch(T value)
        {
            Queue<Tree<T>> trees = new Queue<Tree<T>>();

            trees.Enqueue(this);

            while (trees.Count > 0)
            {
                var subTree = trees.Dequeue();

                if (subTree.Key.Equals(value))
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

        private string DfsToString(Tree<T> tree, int level = 0)
        {
            var sb = new StringBuilder();
            sb.Append(new string(' ', level));
            sb.AppendLine($"{tree.Key}");

            foreach (var child in tree.Children)
            {
                sb.AppendLine(DfsToString(child, level + 2));
            }
            return sb.ToString().TrimEnd();
        }

        private void DfsLeftDeepestNode(Tree<T> tree, int level = 0)
        {
            if (level > currentLevel)
            {
                currentLevel = level;
                this.leftDeepnestNode = tree;
            }

            foreach (var child in tree._children)
            {
                DfsLeftDeepestNode(child, level + 1);
            }
        }

        private void AllPathsWithSum(Tree<T> tree,
            List<List<T>> finnalResult,
            Stack<T> result,
            int currentSum, int expectedSum)
        {
            int treeValue = int.Parse(tree.Key.ToString());

            result.Push(tree.Key);

            foreach (var child in tree.Children)
            {
                AllPathsWithSum(child, finnalResult, result, currentSum + treeValue, expectedSum);
            }

            if (currentSum + treeValue == expectedSum)
            {
                finnalResult.Add(result.Reverse().ToList());
            }

            result.Pop();

        }

        private void AllSubTreesWithSum(Tree<T> tree, List<Tree<T>> result, int expectedSum)
        {
            int totalSum = SubTreesSum(tree,expectedSum);

            if (totalSum == expectedSum)
            {
                result.Add(tree);
            }

            foreach (var child in tree.Children)
            {
                AllSubTreesWithSum(child, result, expectedSum);
            }
        }

        private int SubTreesSum(Tree<T> tree,int expectedSum,int totalSum = 0)
        {
            int sum = int.Parse(tree.Key.ToString());

            foreach (var child in tree.Children)
            {
                sum += int.Parse(child.Key.ToString());
            }

            totalSum += sum;

            if (totalSum < expectedSum)
            {
                foreach (var child in tree.Children)
                {
                    totalSum += SubTreesSum(child,expectedSum, totalSum);
                }
            }
            else if (totalSum == expectedSum)
            {
                return expectedSum;
            }
            else
            {
                return -1;
            }

            return totalSum;
        }
    }
}
