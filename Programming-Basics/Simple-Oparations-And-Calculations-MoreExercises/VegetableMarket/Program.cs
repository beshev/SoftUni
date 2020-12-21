using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyVegs = double.Parse(Console.ReadLine());
            double moneyFruts = double.Parse(Console.ReadLine());
            int vegsKg = int.Parse(Console.ReadLine());
            int frutsKg = int.Parse(Console.ReadLine());
            double sum1 = ((moneyVegs * vegsKg) + (moneyFruts * frutsKg));
            double sum2 = sum1 / 1.94;

            Console.WriteLine($"{sum2:f2}");



        }
    }
}
