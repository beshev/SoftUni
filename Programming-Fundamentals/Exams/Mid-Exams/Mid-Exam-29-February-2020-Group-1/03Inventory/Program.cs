using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> inventory = new List<string>(items);
            string input = Console.ReadLine();
            while (input != "Craft!")
            {
                string[] commnad = input.Split(new string[] { " - ", ":" }
                , StringSplitOptions.RemoveEmptyEntries);
                if (commnad[0] == "Collect")
                {
                    CollectItems(inventory, commnad[1]);
                }
                else if (commnad[0] == "Drop")
                {
                    DropItem(inventory, commnad[1]);
                }
                else if (commnad[0] == "Combine Items")
                {
                    CombineItems(inventory, commnad[1], commnad[2]);
                }
                else if (commnad[0] == "Renew")
                {
                    RenewExistItem(inventory, commnad[1]);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", inventory));
        }

        static void CollectItems(List<string> invetory, string item)
        {
            if (!invetory.Contains(item))
            {
                invetory.Add(item);
            }
        }

        static void DropItem(List<string> invetory, string item)
        {
            if (invetory.Contains(item))
            {
                invetory.Remove(item);
            }
        }

        static void CombineItems(List<string> invetory, string oldItem, string newItem)
        {
            if (invetory.Contains(oldItem))
            {
                int indexOf = invetory.IndexOf(oldItem);
                if (indexOf + 1 > invetory.Count - 1)
                {
                    invetory.Add(newItem);
                }
                else
                {
                    invetory.Insert(indexOf + 1, newItem);
                }
            }
        }

        static void RenewExistItem(List<string> invetory, string item)
        {
            if (invetory.Contains(item))
            {
                int indexOf = invetory.IndexOf(item);
                if (!(indexOf == invetory.Count - 1))
                {
                    invetory.Remove(item);
                    invetory.Add(item);
                }
            }
        }

    }
}
