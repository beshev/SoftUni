using System;

namespace _01._01.SuppliesforSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int pen = int.Parse(Console.ReadLine());
            int marker = int.Parse(Console.ReadLine());
            double litter = double.Parse(Console.ReadLine());
            int reduction = int.Parse(Console.ReadLine());

            double pricePen = pen * 5.8;
            double priceMarker = marker * 7.20;
            double pricePreparation = litter * 1.20;

            double off = (reduction * 1.0) / 100;

            double totalSum = priceMarker + pricePen + pricePreparation;
            totalSum -= totalSum * off;
            Console.WriteLine($"{totalSum:f3}");




        }
    }
}
