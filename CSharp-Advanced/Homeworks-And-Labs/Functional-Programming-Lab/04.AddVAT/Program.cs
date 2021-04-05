using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVat = AddVAT;
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(addVat)
                .ToArray();
            Print(numbers);

        }
        static void Print(decimal[] someText)
        {
            foreach (var word in someText)
            {
                Console.WriteLine(word);
            }
        }

        static decimal AddVAT(decimal num)
        {
            return decimal.Parse($"{num * 1.20m:F2}");
        }
    }
}
