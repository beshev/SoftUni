using System;

namespace _02.FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            int couter1 = 0;
            int counterX = 0;
            int counter2 = 0;
            for (int i = 0; i < 3; i++)
            {

                string result1 = Console.ReadLine();
                if (result1[0] > result1[2])
                {
                    couter1++;
                }
                else if (result1[0] == result1[2])
                {
                    counterX++;
                }
                else if (result1[0] < result1[2])
                {
                    counter2++;
                }
            }
            Console.WriteLine($"Team won {couter1} games.");
            Console.WriteLine($"Team lost {counter2} games.");
            Console.WriteLine($"Drawn games: {counterX}");
        }
    }
}
