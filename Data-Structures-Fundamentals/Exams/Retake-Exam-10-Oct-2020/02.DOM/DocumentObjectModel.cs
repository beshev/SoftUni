namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            var document = new HtmlElement(ElementType.Document,
                new HtmlElement(ElementType.Html,
                    new HtmlElement(ElementType.Head),
                    new HtmlElement(ElementType.Body)));

            this.Root = document;
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Type == type)
                {
                    return current;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            return DFSList(this.Root, type);
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == htmlElement)
                {
                    return true;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            if (this.Contains(parent))
            {
                child.Parent = parent;
                parent.Children.Insert(0, child);
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            //TODO : Chek if children is null!!

            if (this.Contains(parent))
            {
                child.Parent = parent;
                parent.Children.Add(child);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Remove(IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            var parent = htmlElement.Parent;

            parent.Children.Remove(htmlElement);

            htmlElement.Children.Clear();
            htmlElement.Parent = null;
        }

        public void RemoveAll(ElementType elementType)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Type == elementType)
                {
                    var parent = current.Parent;
                    parent.Children.Remove(current);
                    current.Children.Clear();
                    current.Parent = null;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (!htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Add(attrKey, attrValue);
                return true;
            }

            return false;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                htmlElement.Attributes.Remove(attrKey);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return DFSPrint(this.Root);
        }

        private string DFSPrint(IHtmlElement root,int level = 0)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{new string(' ', level)}{root.Type}");

            foreach (var child in root.Children)
            {
                sb.Append(DFSPrint(child, level + 2));
            }

            return sb.ToString();
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Attributes.ContainsKey("id"))
                {
                    if (current.Attributes["id"].Contains(idValue))
                    {
                        return current;
                    }
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private List<IHtmlElement> DFSList(IHtmlElement root, ElementType elementType)
        {
            var result = new List<IHtmlElement>();


            foreach (var child in root.Children)
            {
                result.AddRange(DFSList(child, elementType));
            }

            if (root.Type == elementType)
            {
                result.Add(root);
            }
            return result;
        }

    }
}
