using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;

        private int index;

        public ListyIterator(params T[] arr)
        {
            this.collection = arr.ToList();
        }

        public bool Move()
        {
            if (this.index + 1 < this.collection.Count)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.index + 1 == this.collection.Count)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.collection[this.index]);
            }
        }
    }
}
