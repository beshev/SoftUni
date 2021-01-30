using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(number) == false)
                {
                    numbers.Add(number, 0);
                }
                numbers[number]++;
            }
            numbers.Where(x => x.Value % 2 == 0)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Key));
        }
    }
}
