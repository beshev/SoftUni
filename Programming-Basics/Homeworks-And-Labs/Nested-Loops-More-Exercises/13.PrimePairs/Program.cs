using System;

namespace _13.PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int diffCople1 = int.Parse(Console.ReadLine());
            int diffCople2 = int.Parse(Console.ReadLine());

            // First cople + diffrend
            for (int firstCople = first; firstCople <= first + diffCople1; firstCople++)
            {
                // Second Cople + diffrend
                for (int secondCople = second; secondCople <= second + diffCople2; secondCople++)
                {
                    int counterFirst = 1;
                    int counterSecond = 1;
                    // check firstCople is prime 
                    for (int prime1 = 2; prime1 <= firstCople; prime1++)
                    {

                        if (firstCople % prime1 == 0)
                        {
                            counterFirst++;
                        }
                    }
                    // check  secondCople is prime
                    for (int prime2 = 2; prime2 <= secondCople; prime2++)
                    {
                        if (secondCople % prime2 == 0)
                        {
                            counterSecond++;
                        }
                    }
                    if (counterFirst == 2 && counterSecond == 2)
                    {
                        Console.WriteLine($"{firstCople}{secondCople}");
                    }

                }
            }


        }
    }
}
