using System;

namespace _03.PrimeOrNonPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string num = Console.ReadLine();
            int sumPrimeNums = 0;
            int sumNonPrimeNums = 0;
            int counterPrime = 1;

            // Find Number is Prime , Non Prime or negative;
            while (num != "stop")
            {
                int numbers = int.Parse(num);
                for (int i = 2; i <= numbers; i++)
                {
                    if (numbers % i == 0)
                    {
                        counterPrime++;
                    }

                }
                
                // if number is negative;
                if (numbers < 0)
                {
                    Console.WriteLine("Number is negative.");

                }
                // if number is non prime;
                else if ( counterPrime > 2 )
                {
                    sumNonPrimeNums += numbers;

                }
                // if number is Prime;
                else
                {
                    sumPrimeNums += numbers;
                }
                counterPrime = 1;

                num = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNums}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNums}");
            

        }
    }
}
