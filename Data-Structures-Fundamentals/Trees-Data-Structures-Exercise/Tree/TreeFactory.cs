namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            Tree<int> tree = null;

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int parentKey = int.Parse(tokens[0]);
                int childKey = int.Parse(tokens[1]);
                var child = new Tree<int>(childKey);

                if (tree == null)
                {
                    tree = new Tree<int>(parentKey);
                    tree.AddChild(child);
                }
                else
                {
                    var subTree = tree.BfsSearch(parentKey);
                    subTree.AddChild(child);
                }
            }

            return tree;
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(int parent, int child)
        {
            throw new NotImplementedException();
        }

        private Tree<int> GetRoot()
        {
            return this.nodesBykeys.Values.FirstOrDefault(x => x.Parent == null);
        }
    }
}
