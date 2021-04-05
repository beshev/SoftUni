using System;

namespace _01._02.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int hourPay = int.Parse(Console.ReadLine());

            double priceNylon = (nylon + 2) * 1.50;
            double paintAdd = paint + paint * 0.10;
            double pricePaint = paintAdd * 14.50;
            double priceThinner = thinner * 5.00;
            double totalSum = priceNylon + pricePaint + priceThinner + 0.40;
            double priceForMaster = totalSum * 0.3;
            priceForMaster *= hourPay;

            totalSum += priceForMaster;

            Console.WriteLine($"Total expenses: {totalSum:f2} lv.");
            



        }
    }
}
