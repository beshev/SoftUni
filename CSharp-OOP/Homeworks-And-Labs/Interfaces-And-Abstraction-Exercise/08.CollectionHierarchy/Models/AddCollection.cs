using System.Collections.Generic;

using _08.CollectionHierarchy.Models.Contracts;

namespace _08.CollectionHierarchy.Models
{
    class AddCollection : IAddable
    {
        private Stack<string> stack;

        public AddCollection()
        {
            stack = new Stack<string>();
        }
        
        public int Add(string element)
        {
            stack.Push(element);
            return stack.Count - 1;
        }
    }
}
