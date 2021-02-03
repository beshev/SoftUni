using System;
using System.IO;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bound = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();
            Predicate<int> checkEvernOrOdd = EvenOrOdd(type);
            Action<int> printer = Printer();
            int star = bound[0];
            int end  = bound[1];
            for (int i = star; i <= end; i++)
            {
                if (checkEvernOrOdd(i))
                {
                    printer(i);
                }
            }

        }

        static Action<int> Printer()
        {
            return x => Console.Write(x + " ");
        }

        static Predicate<int> EvenOrOdd(string type)
        {
            if (type == "even")
            {
                return x => x % 2 == 0;
            }
            else if (type == "odd")
            {
                return x => x % 2 != 0;
            }
            return null;
        }
    }
}
