using System;

namespace _01.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int moneyForTax = int.Parse(Console.ReadLine());
            double sneakers = moneyForTax - (moneyForTax * 0.4);
            double team = sneakers - (sneakers * 0.2);
            double ball = 1.0 / 4 * team;
            double accessories = 1.0 / 5 * ball;
            double sum = moneyForTax + sneakers + team + ball + accessories;

            Console.WriteLine($"{sum:F2}");
        }
    }
}
