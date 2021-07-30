namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            this.links = new LinkedList<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear()
        {
            this.links.Clear();
        }

        public bool Contains(ILink link)
        {
            return this.GetByUrl(link.Url) != null;
        }

        public ILink DeleteFirst()
        {
            ValidateIfEmpty();

            var result = this.links.Last;

            this.links.RemoveLast();

            return result.Value;
        }

        public ILink DeleteLast()
        {
            ValidateIfEmpty();

            var result = this.links.First;

            this.links.RemoveFirst();

            return result.Value;
        }

        public ILink GetByUrl(string url)
        {
            var node = this.links.First;

            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value.Url.ToLower().Contains(url.ToLower()))
                {
                    return node.Value;
                }
                node = nextNode;
            }

            return null;
        }

        public ILink LastVisited()
        {
            this.ValidateIfEmpty();

            return this.links.First.Value;
        }

        public void Open(ILink link)
        {
            this.links.AddFirst(link);
        }

        public int RemoveLinks(string url)
        {
            ValidateIfEmpty();

            var node = this.links.First;
            int counter = 0;


            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value.Url.Contains(url))
                {
                    this.links.Remove(node);
                    counter++;
                }
                node = nextNode;
            }

            if (counter == 0)
            {
                throw new InvalidOperationException("No links with the given url!");
            }

            return counter;
        }

        public ILink[] ToArray()
        {
            return this.links.ToArray();
        }

        public List<ILink> ToList()
        {
            return this.links.ToList();
        }

        public string ViewHistory()
        {
            if (this.Size == 0)
            {
                return "Browser history is empty!";
            }

            StringBuilder result = new StringBuilder();
            foreach (var item in this.links)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString();
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
