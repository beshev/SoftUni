using System;

namespace _04.EvenPowersOf_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                     double sum = Math.Pow(2,i);
                    Console.WriteLine(sum);
                }   
            }
        }
    }
}
