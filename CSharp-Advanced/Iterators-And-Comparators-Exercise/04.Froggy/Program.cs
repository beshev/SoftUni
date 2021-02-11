using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            Lake lake = new Lake(array);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
