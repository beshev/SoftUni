using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> getMinNum = GetMinNumber();
            Console.WriteLine(getMinNum(numbers));

        }

        static Func<int[],int> GetMinNumber()
        {
            int minNum = int.MaxValue;
            return x =>
            {
                x.ToList().ForEach(x =>
                {
                    if (x < minNum)
                    {
                        minNum = x;
                    }
                });
                return minNum;
            };
        }
    }
}
