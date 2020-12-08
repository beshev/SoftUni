using System;

namespace _03.LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input:
            int n = int.Parse(Console.ReadLine());

            // Find All Combinatoins Numbers:
            for (int firstNum = 1; firstNum <= 9; firstNum++)
            {
                for (int secondNum = 1; secondNum <= 9; secondNum++)
                {
                    for (int thirdNum = 1; thirdNum <= 9; thirdNum++)
                    {
                        for (int fourthNum = 1; fourthNum <= 9; fourthNum++)
                        {
                            int sum1And2 = firstNum + secondNum;
                            int sum3And4 = thirdNum + fourthNum;

                            // Find number is Lucky:
                            if (sum1And2 == sum3And4)
                            {
                                if (n % sum1And2 == 0)
                                {
                                    Console.Write($"{firstNum}{secondNum}{thirdNum}{fourthNum} ");
                                }
                            }

                        }
                    }
                }

            }
        }
    }
}
