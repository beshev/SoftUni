using System;

namespace _04._02.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int heightWall = int.Parse(Console.ReadLine());
            int widthWall = int.Parse(Console.ReadLine());
            int allWallSize = (heightWall * widthWall) * 4;
            int per = int.Parse(Console.ReadLine());
            double percentage = (double)per / 100;
            double allWall = Math.Ceiling(allWallSize - (allWallSize * percentage));

            string input = Console.ReadLine();
            while (input != "Tired!")
            {
                int litter = int.Parse(input);
                allWall -= litter;
                if (allWall < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(allWall)} l paint left!");
                    return;
                }
                else if (allWall == 0)
                {
                    Console.WriteLine($"All walls are painted! Great job, Pesho!");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{allWall} quadratic m left.");
        }
    }
}
