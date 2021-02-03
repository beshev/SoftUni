using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
            Func<string[], string> getFirstName = GetFirstName(CheckNameSum(GetSumOfName()),number);
            Console.WriteLine(getFirstName(names));
        }

        static Func<string[], string> GetFirstName(Func<string, int, bool> filter, int number)
        {
            return names =>
            {
                foreach (var name in names)
                {
                    if (filter(name, number))
                    {
                        return name;
                    }
                }
                return "No Name With That Arguments";
            };
        }

        static Func<string, int, bool> CheckNameSum(Func<string, int> getSum)
        {
            return (name, number) =>
            {
                return number <= getSum(name);
            };
        }

        static Func<string, int> GetSumOfName()
        {
            return name =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }
                return sum;
            };
        }

    }
}
