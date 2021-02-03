using System;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = PrintName();
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            names.ToList().ForEach(x => printer(x));
        }

        static Action<string> PrintName()
        {
            return x => Console.WriteLine(x);
        }
    }
}
