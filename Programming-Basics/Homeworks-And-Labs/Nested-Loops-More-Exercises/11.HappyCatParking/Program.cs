using System;

namespace _11.HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalSum = 0;
            // Find price for day and hour 
            for (int day = 1; day <= days; day++)
            {
                // Find Price for day
                double priceForDay = 0;
                for (int hour = 1; hour <= hours; hour++)
                {
                    // Priec for every even day and odd hour
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        priceForDay += 2.50;
                        totalSum += 2.50;

                    }
                    // Price for every odd Day and even hour
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        priceForDay += 1.25;
                        totalSum += 1.25;
                    }
                    else
                    {
                        priceForDay += 1;
                        totalSum += 1;
                    }

                }
                Console.WriteLine($"Day: {day} - {priceForDay:F2} leva");
            }
            Console.WriteLine($"Total: {totalSum:F2} leva");

        }
    }
}
