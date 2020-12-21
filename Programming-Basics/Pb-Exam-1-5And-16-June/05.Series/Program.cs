using System;

namespace _05.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numSerials = int.Parse(Console.ReadLine());
            double totalSum = 0;
            for (int i = 0; i < numSerials; i++)
            {
                string nameSerial = Console.ReadLine();
                double priceSerial = double.Parse(Console.ReadLine());
                switch (nameSerial)
                {
                    case "Thrones":
                        priceSerial /= 2;
                        break;
                    case "Lucifer":
                        priceSerial -= priceSerial * 0.4;
                        break;
                    case "Protector":
                        priceSerial -= priceSerial * 0.3;
                        break;
                    case "TotalDrama":
                        priceSerial -= priceSerial * 0.2;
                        break;
                    case "Area":
                        priceSerial -= priceSerial * 0.1;
                        break;
                }
                totalSum += priceSerial;

            }
            if (totalSum > budget)
            {
                Console.WriteLine($"You need {totalSum - budget:f2} lv. more to buy the series!");
            }
            else
            {
                Console.WriteLine($"You bought all the series and left with {budget - totalSum:f2} lv.");
            }
        }
    }
}
