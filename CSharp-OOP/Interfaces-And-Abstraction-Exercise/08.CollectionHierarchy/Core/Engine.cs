using System;
using System.Collections.Generic;

using _08.CollectionHierarchy.Models;
using _08.CollectionHierarchy.Models.Contracts;

namespace _08.CollectionHierarchy.Core
{
    class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int removeCount = int.Parse(Console.ReadLine());
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            AddingAndPriting(input, addCollection);
            
            AddingAndPriting(input, addRemoveCollection);

            AddingAndPriting(input, myList);

            RemovingAndPrinting(removeCount,addRemoveCollection);
            Console.WriteLine();

            RemovingAndPrinting(removeCount,myList);
        }

        private static void AddingAndPriting(string[] input, IAddable someCollection)
        {
            foreach (var item in input)
            {
                Console.Write(someCollection.Add(item) + " ");
            }
            Console.WriteLine();
        }

        private static void AddingAndPriting(string[] input, IRemovable someCollection)
        {
            foreach (var item in input)
            {
                Console.Write(someCollection.Add(item) + " ");
            }
            Console.WriteLine();
        }

        private static void RemovingAndPrinting(int removeCount,IRemovable someCollection)
        {
            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(someCollection.Remove() + " ");
            }
        }
    }
}
