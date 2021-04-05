using System;

namespace _10.Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int five = int.Parse(Console.ReadLine());
            int totalSum = int.Parse(Console.ReadLine());

            for (int coins1 = 0; coins1 <= one; coins1++)
            {
                for (int coins2 = 0; coins2 <= two; coins2++)
                {
                    for (int coins5 = 0; coins5 <= five; coins5++)
                    {
                        int sum = (coins1 * 1) + (coins2 * 2) + (coins5 * 5);
                        if (sum == totalSum)
                        {
                            Console.WriteLine($"{coins1} * 1 lv. + {coins2} * 2 lv. + {coins5} * 5 lv. = {totalSum} lv.");
                        }


                    }
                }
            }
        }
    }
}
