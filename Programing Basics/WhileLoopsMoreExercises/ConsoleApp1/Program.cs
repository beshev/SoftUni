using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int bottle = int.Parse(Console.ReadLine());
            bottle *= 750;
            int preparadNeed = 0;
            int vessles = 0;
            int counter = 0;
            int clearnPlate = 0;
            int clearnPot = 0;
            // Find vessels can wash
            string input = Console.ReadLine();
            while (input != "End")
            {
                counter++;
                vessles = int.Parse(input);
                // Find For every third time the pot washes
                // Find is preparad  not enough
                if (counter == 3)
                {
                    preparadNeed += vessles * 15;
                    clearnPot += vessles;
                    counter = 0;

                }
                else
                {
                    preparadNeed += vessles * 5;
                    clearnPlate += vessles;
                }
                if (preparadNeed > bottle)
                {
                    Console.WriteLine($"Not enough detergent, {preparadNeed - bottle} ml. more necessary!");
                    break;
                }
                input = Console.ReadLine();
            }
            // Find if we wash all vessles
            if (input == "End")
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{clearnPlate} dishes and {clearnPot} pots were washed.");
                Console.WriteLine($"Leftover detergent {bottle - preparadNeed} ml.");
            }

        }
    }
}
