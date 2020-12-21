using System;

namespace _05.AccountBalans
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            double totalSum = 0;
            string input = Console.ReadLine();
            while (input != "NoMoreMoney")
            {
                double sum = double.Parse(input);
                if (sum < 0)
                {
                    Console.WriteLine($"Invalid operation!");
                    Console.WriteLine($"Total: {totalSum:f2}");
                    break;
                }
                Console.WriteLine($"Increase: {sum:f2}");
                totalSum += sum;

                input = Console.ReadLine();
            }
            if (input == "NoMoreMoney")
            {
                Console.WriteLine($"Total: {totalSum:f2}");
            }
        }
    }
}
