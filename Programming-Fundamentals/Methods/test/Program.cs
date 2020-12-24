using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int counterCarige = 0;
            int counter = 0;
            double totalVolume = 0;
            while (input != "End")
            {
                double volume = double.Parse(input);
                counter++;
                if (counter == 3)
                {
                    volume += volume * 0.1;
                    counter = 0;
                }
                totalVolume += volume;
                if (totalVolume > capacity)
                {
                    Console.WriteLine($"No more space!");
                    break;
                }
                counterCarige++;
                input = Console.ReadLine();
            }
            if (totalVolume <= capacity)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {counterCarige} suitcases loaded.");
        }
    }
}
