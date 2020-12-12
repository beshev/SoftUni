using System;

namespace _02.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numStatisticians = int.Parse(Console.ReadLine());
            double priceForCloths = double.Parse(Console.ReadLine());

            double priceDecor = budget * 0.1;
            if (numStatisticians > 150 )
            {
                priceForCloths -= priceForCloths * 0.1; 
            }
            double totalSum = (numStatisticians * priceForCloths) + priceDecor;
            if (budget >= totalSum)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {budget - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalSum - budget:f2} leva more.");
            }
        }
    }
}
