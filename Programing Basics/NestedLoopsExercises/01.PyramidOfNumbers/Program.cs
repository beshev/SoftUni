using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int x1 = 1;


            for (int i = 1; i <= n; i++)
            {
                for ( int y = 1; y <= counter; y++)
                {
                    Console.Write($"{x1} ");
                    if (x1 == n)
                    {
                        return;
                    }
                    x1++;
                   
                }
                counter++;
                Console.WriteLine();
            }

            
        }
    }
}
