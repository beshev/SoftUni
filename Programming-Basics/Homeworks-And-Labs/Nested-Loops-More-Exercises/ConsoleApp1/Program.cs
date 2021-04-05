using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input:
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            // Find First and Third numbers are even , Find second number is prime:
            for ( int i1 = 1;  i1 <= num1;  i1++)
            {
                
                for (int y2 = 1; y2 <= num2; y2++)
                {
                    int primeCounter = 1;

                    // check num2 is prime:
                    for (int i = 2; i <= y2; i++)
                    {
                        if (y2 % i == 0)
                        {
                            primeCounter++;
                        }

                    }

                    // Print Output
                    for (int j3 = 1; j3 <= num3; j3++)
                    {
                        if (i1 % 2 == 0 && j3 % 2 == 0 && primeCounter == 2)
                        {
                            Console.WriteLine($"{i1} {y2} {j3}");
                            
                        }


                    }

                }

            }
        }
    }
}
