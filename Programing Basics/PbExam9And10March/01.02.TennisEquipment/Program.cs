using System;

namespace _01._02.TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tennisRocketPrice = double.Parse(Console.ReadLine());
            int numRockets = int.Parse(Console.ReadLine());
            int numSnaeckers = int.Parse(Console.ReadLine());
            
            double priceSnaeckers = 1.0 / 6 * tennisRocketPrice;
            priceSnaeckers *= numSnaeckers;
            double sum = priceSnaeckers + (tennisRocketPrice * numRockets);
            sum += sum * 0.2;

            double djokovic = Math.Floor(1.0 / 8 * sum);
            double sponsors = Math.Ceiling(7.0 / 8 * sum);
            Console.WriteLine($"Price to be paid by Djokovic {djokovic}");
            Console.WriteLine($"Price to be paid by sponsors {sponsors}");

        }
    }
}
