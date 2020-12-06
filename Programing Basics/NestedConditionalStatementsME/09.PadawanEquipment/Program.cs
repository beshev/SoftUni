using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyHave = double.Parse(Console.ReadLine());
            int numbStudents = int.Parse(Console.ReadLine());
            double priceLightsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double totalSum = priceRobes * numbStudents;
            double lightSaber = Math.Ceiling(numbStudents * 0.1);
            totalSum += (lightSaber + numbStudents) * priceLightsabers;
            int discountBelt = 0;
            for (int i = 1; i <= numbStudents; i++)
            {
                if (i % 6 == 0)
                {
                    discountBelt++;
                }
            }
            totalSum += priceBelts * (numbStudents - discountBelt);
            if (moneyHave >= totalSum)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalSum - moneyHave:f2}lv more.");
            }
        }
    }
}
