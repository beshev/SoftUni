using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string> appendSir = x => Console.WriteLine($"Sir {x}");
            names.ToList().ForEach(x => appendSir(x));
        }
    }
}
