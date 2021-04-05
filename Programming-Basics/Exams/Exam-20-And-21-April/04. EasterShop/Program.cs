using System;

namespace _04._EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggStart = int.Parse(Console.ReadLine());
            int eggSold = 0;

            string input = Console.ReadLine();
            while (input != "Close")
            {
                int numEgg = int.Parse(Console.ReadLine());
                if (input == "Fill")
                {
                    eggStart += numEgg;
                }
                else
                {
                    if (numEgg > eggStart)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggStart}.");
                        break;
                    }
                    eggStart -= numEgg;
                    eggSold += numEgg;

                }


                input = Console.ReadLine();
            }
            if (input == "Close")
            {
                Console.WriteLine($"Store is closed!");
                Console.WriteLine($"{eggSold} eggs sold.");
            }
        }
    }
}
