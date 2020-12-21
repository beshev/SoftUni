using System;

namespace _11.SmartLili
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Read Input
            int years = int.Parse(Console.ReadLine());
            double priceWashmachine = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            double money = 0;
            double gifts = 0;
            double moneysForEven = 0;

            // 2.Find Gift Or Money Lily got for his birthday 
            for (int i = 1; i <= years; i++)
            {
                if (i % 2 == 0)
                {
                    // 2.1. She take 10lv For every even year
                    moneysForEven += 10;
                    money += moneysForEven;
                    // 2.2. His Brother take 1 lv. for every time when she got money
                    money--;
                }
                else
                {
                    gifts += 1;
                }

            }
            // 2.3. She Sels Gifts for N money 
            double toysMonye = gifts * toysPrice;
            // 2.4 How much money save Lili
            double saveMoney = toysMonye + money;

            // 3. Print Output
            if (saveMoney >= priceWashmachine)
            {
                Console.WriteLine($"Yes! {saveMoney - priceWashmachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceWashmachine - saveMoney:f2}");
            }


        }
    }
}
