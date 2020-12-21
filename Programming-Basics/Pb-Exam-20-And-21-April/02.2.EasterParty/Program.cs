using System;

namespace _02._2.EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsNum = int.Parse(Console.ReadLine());
            double priceForOne = double.Parse(Console.ReadLine());
            double moneyHave = double.Parse(Console.ReadLine());
            double totalSum = 0;

            if (guestsNum >= 10 && guestsNum <= 15 )
            {
                priceForOne = priceForOne - (priceForOne * 0.15);
            }
            else if (guestsNum > 15 && guestsNum <= 20)
            {
                priceForOne = priceForOne - (priceForOne * 0.20);
            }
            else if (guestsNum > 20)
            {
                priceForOne = priceForOne - (priceForOne * 0.25);
            }
            totalSum = priceForOne * guestsNum;
            moneyHave = moneyHave - (moneyHave * 0.1);

            if (moneyHave >= totalSum)
            {
                Console.WriteLine($"It is party time! {moneyHave - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {totalSum - moneyHave:f2} leva needed.");
            }


        }
    }
}
