using System;

namespace _06._1.EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numClient = int.Parse(Console.ReadLine());
            double totalSum = 0;
            double totalClient = 0;
            while (numClient != 0)
            {
                double sumForOne = 0;
                int counterBuy = 0;
                string buyName = Console.ReadLine();
                while (buyName != "Finish")
                {
                    switch (buyName)
                    {
                        case "basket":
                            sumForOne += 1.50;
                            counterBuy++;
                            break;
                        case "wreath":
                            sumForOne += 3.80;
                            counterBuy++;
                            break;
                        case "chocolate bunny":
                            sumForOne += 7;
                            counterBuy++;
                            break;
                    }
                    buyName = Console.ReadLine();


                }
                if (counterBuy % 2 == 0)
                {
                    sumForOne = sumForOne - (sumForOne * 0.2);
                Console.WriteLine($"You purchased {counterBuy} items for {sumForOne:f2} leva.");
                }
                else
                {
                    Console.WriteLine($"You purchased {counterBuy} items for {sumForOne:f2} leva.");
                }
                totalClient++;
                totalSum += sumForOne;
                numClient--;
            }
            Console.WriteLine($"Average bill per client is: {totalSum / totalClient:f2} leva.");
        }
    }
}
