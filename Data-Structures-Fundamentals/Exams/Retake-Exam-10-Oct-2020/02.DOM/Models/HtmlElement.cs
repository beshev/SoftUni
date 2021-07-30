namespace _02.DOM.Models
{
    using _02.DOM.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            this.Type = type;
            this.Children = children.ToList();
            this.Attributes = new Dictionary<string, string>();

            foreach (var child in this.Children)
            {
                child.Parent = this;
            }
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }
    }
}
