using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> list = new List<string>();
            list.AddRange(input
                .Split(new string[] { "Create", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            ListyIterator<string> myList = new ListyIterator<string>(list.ToArray());
            input = Console.ReadLine();
            while (input != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(myList.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(myList.HasNext());
                        break;
                    case "Print":
                        myList.Print();
                        break;
                    case "PrintAll":
                        myList.PrintAll();
                            break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
