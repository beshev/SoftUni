using System;

namespace _08.SecretDoor_sLock
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int num100 = int.Parse(Console.ReadLine());
            int num10 = int.Parse(Console.ReadLine());
            int num1 = int.Parse(Console.ReadLine());

            // Find Hundreds = 1 to num100
            for (int hundreds = 1; hundreds <= num100; hundreds++)
            {
                // Find Dozens = 1 to num10
                for (int dozens = 1; dozens <= num10; dozens++)
                {
                    // Find Units = 1 to num1
                    for (int units = 1; units <= num1; units++)
                    {
                        // First Point - digits of Units and Hundreds = even;
                        bool firstPoint = units % 2 == 0 && hundreds % 2 == 0;
                        // Second Point - Digit of Dozens = Prime Number (From 2 to 7)
                        bool secondPoint = dozens == 2 || dozens == 3 || dozens == 5 || dozens == 7;
                        if (firstPoint && secondPoint)
                        {
                            Console.WriteLine($"{hundreds} {dozens} {units}");
                        }



                    }

                }
            }
        }
    }
}
