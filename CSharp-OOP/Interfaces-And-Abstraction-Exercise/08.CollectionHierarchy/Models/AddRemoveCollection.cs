using _08.CollectionHierarchy.Models.Contracts;
using System.Collections.Generic;

namespace _08.CollectionHierarchy.Models
{
    class AddRemoveCollection : IRemovable
    {
        private LinkedList<string> list;

        public AddRemoveCollection()
        {
            list = new LinkedList<string>();
        }

        public int Add(string element)
        {
            list.AddFirst(element);
            return 0;
        }

        public string Remove()
        {
            string lastElement = list.Last.Value;
            list.RemoveLast();
            return lastElement;
        }
    }
}
