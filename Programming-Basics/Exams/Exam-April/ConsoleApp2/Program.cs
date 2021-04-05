using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double moneyForBilds = double.Parse(Console.ReadLine());

            double moneySaved = budget - moneyForBilds;
            moneySaved -= budget * 0.3;
            moneySaved *= months;
            double percentage = budget * months;
            percentage = moneySaved / percentage * 100;
            Console.WriteLine($"She can save {percentage:f2}%");
            Console.WriteLine($"{moneySaved:F2}");
        }
    }
}
