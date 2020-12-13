using System;

namespace _05._01.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double trunk = double.Parse(Console.ReadLine());
            int counterSuitcase = 0;
            int allSuitcase = 0;

            string input = Console.ReadLine();
            while (input != "End")
            {
                double suitcase = double.Parse(input);
                counterSuitcase++;
                if (counterSuitcase == 3)
                {
                    suitcase += suitcase * 0.1;
                    counterSuitcase = 0;
                }
                if (trunk < suitcase)
                {
                    Console.WriteLine($"No more space!");
                    break;
                }
                allSuitcase++;
                trunk -= suitcase;
                input = Console.ReadLine();
            }
            if (input == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {allSuitcase} suitcases loaded.");

        }
    }
}
