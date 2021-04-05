using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(IntParse)
                .ToList();
            int divisor = int.Parse(Console.ReadLine());
            Func<List<int>, List<int>> reverse = Reverse();
            Func<int, bool> isNotDivided = RemoveDividerNumbers(divisor);
            Action<int> printer = Printer();
            numbers = reverse(numbers);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (isNotDivided(numbers[i]))
                {
                    printer(numbers[i]);
                }
            }
        }

        static Action<int> Printer()
        {
            return x => Console.Write(x.ToString() + ' ');
        }

        static Func<int, bool> RemoveDividerNumbers(int divisor)
        {
            return x => x % divisor != 0;
        }

        static Func<List<int>, List<int>> Reverse()
        {
            return x =>
            {
                Stack<int> result = new Stack<int>(x);
                return x = result.ToList();
            };
        }

        static int IntParse(string number)
        {
            return int.Parse(number.ToString());
        }
    }
}
