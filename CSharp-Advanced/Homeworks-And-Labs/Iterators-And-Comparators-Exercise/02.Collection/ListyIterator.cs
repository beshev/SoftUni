using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            if (this.collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            IEnumerator<T> currentElement = GetAllElements();
            while (currentElement.MoveNext())
            {
                Console.Write(currentElement.Current + " ");
            }
        }

        private IEnumerator<T> GetAllElements()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
            Console.WriteLine();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetAllElements();

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
