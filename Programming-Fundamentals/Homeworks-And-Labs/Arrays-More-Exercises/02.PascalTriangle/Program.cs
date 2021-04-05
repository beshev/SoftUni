using System;
namespace PascalTriangleDemo
{
    class Example
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int val = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0)
                    {
                        val = 1;
                    }
                    else
                    {
                        val = val * (i - j + 1) / j;
                    }
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}