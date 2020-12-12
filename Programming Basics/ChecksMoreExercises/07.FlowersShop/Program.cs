using System;

namespace _07.FlowersShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int hyacinths = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());
            double sumFlowers = magnolias * 3.25 + hyacinths * 4 + roses * 3.50 +  cactus * 8;
            double priceFlowers = sumFlowers - (0.05 * sumFlowers);
            if (priceFlowers >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(priceFlowers - giftPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice - priceFlowers)} leva.");
            }
        }
    }
}
