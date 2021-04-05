using System;

namespace _05._1EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int bread = int.Parse(Console.ReadLine());
            int maxFlour = int.MinValue;
            int maxShugar = int.MinValue;
            double totalFlour = 0;
            double totalShugar = 0;

            for (int i = 0; i < bread; i++)
            {
                int shugarNeed = int.Parse(Console.ReadLine());
                int flourNeed = int.Parse(Console.ReadLine());
                totalFlour += flourNeed;
                totalShugar += shugarNeed;
                if (maxFlour < flourNeed)
                {
                    maxFlour = flourNeed;
                }
                if (maxShugar < shugarNeed)
                {
                    maxShugar = shugarNeed;
                }
            }
            Console.WriteLine($"Sugar: {Math.Ceiling(totalShugar / 950)}");
            Console.WriteLine($"Flour: {Math.Ceiling(totalFlour / 750)}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxShugar} grams.");
        }
    }
}
