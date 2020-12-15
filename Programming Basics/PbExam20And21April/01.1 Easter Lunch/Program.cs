using System;

namespace _01._1_Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int breadnum = int.Parse(Console.ReadLine());
            int eggBark = int.Parse(Console.ReadLine());
            int cookieKg = int.Parse(Console.ReadLine());

            double breadPrice = breadnum * 3.20;
            double barkPrice = eggBark * 4.35;
            double cookiePrice = cookieKg * 5.40;
            double colorEgg = (eggBark * 12) * 0.15;

            double totalSum = breadPrice + barkPrice + cookiePrice + colorEgg;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
