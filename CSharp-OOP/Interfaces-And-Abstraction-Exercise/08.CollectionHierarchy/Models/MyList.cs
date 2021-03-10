using System.Collections.Generic;

using _08.CollectionHierarchy.Models.Contracts;

namespace _08.CollectionHierarchy.Models
{
    class MyList : IRemovable
    {
        private LinkedList<string> list;

        public MyList()
        {
            list = new LinkedList<string>();
        }

        public int Used { get => list.Count; }

        public int Add(string element)
        {
            list.AddFirst(element);
            return 0;
        }

        public string Remove()
        {
            string firstElement = list.First.Value;
            list.RemoveFirst();
            return firstElement;
        }
    }
}
