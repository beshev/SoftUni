using System;

namespace _06.VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int i = 1; i <= days; i++)
            {
                double daySum = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        daySum += 2.50;
                        totalSum += 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        daySum += 1.25;
                        totalSum += 1.25;
                    }
                    else
                    {
                        daySum += 1;
                        totalSum += 1;
                    }
                }
                Console.WriteLine($"Day: {i} - {daySum:f2} leva");
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
