using System;

namespace _12.SongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            int m = int.Parse(Console.ReadLine());
            int counter = 0;
            int counterHave = 0;
            string fourPass = "";

            // Find all combinatoins ho have same number like "m"

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            // First Point 
                            bool firstPoint = a < b;
                            // Second Point
                            bool secondPoint = c > d;
                            // Thirth Point 
                            bool sum = (a * b) + (c * d) == m;
                            if (firstPoint && secondPoint && sum)
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                counter++;
                            }
                            if (counter == 4)
                            {
                                fourPass = $"{a}{b}{c}{d}";
                                counter++;
                                counterHave++;
                            }

                        }
                    }

                }
            }
            Console.WriteLine();
            if (counterHave == 1)
            {
                Console.WriteLine($"Password: {fourPass}");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
