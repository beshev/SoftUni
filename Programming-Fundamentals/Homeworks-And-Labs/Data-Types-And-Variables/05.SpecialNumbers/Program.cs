using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int numberCheck = i;
                while (numberCheck > 0)
                {
                    sum += numberCheck % 10;
                    numberCheck /= 10;
                }
                bool isTrue = sum == 5 || sum == 7 || sum == 11;
                if (isTrue)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

            }
        }
    }
}
