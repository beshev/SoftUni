using System;

namespace _05._02.Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counterBack = 0;
            int counterChest = 0;
            int counterLegs = 0;
            int counterAbs = 0;
            int counteShake = 0;
            int counterBar = 0;

            for (int i = 0; i < num; i++)
            {
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Back":
                        counterBack++;
                        break;
                    case "Chest":
                        counterChest++;
                        break;
                    case "Legs":
                        counterLegs++;
                        break;
                    case "Abs":
                        counterAbs++;
                        break;
                    case "Protein shake":
                        counteShake++;
                        break;
                    case "Protein bar":
                        counterBar++;
                        break;
                }
            }
            double workOut = counterAbs + counterBack + counterChest + counterLegs;
            double protein = counterBar + counteShake;
            Console.WriteLine($"{counterBack} - back");
            Console.WriteLine($"{counterChest} - chest");
            Console.WriteLine($"{counterLegs} - legs");
            Console.WriteLine($"{counterAbs} - abs");
            Console.WriteLine($"{counteShake} - protein shake");
            Console.WriteLine($"{counterBar} - protein bar");
            Console.WriteLine($"{workOut / num * 100:F2}% - work out");
            Console.WriteLine($"{protein / num * 100:F2}% - protein");
        }
    }
}
