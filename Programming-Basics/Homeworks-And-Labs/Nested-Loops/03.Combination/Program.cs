using System;

namespace _03.Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            double x1 = 0;
            double x2 = 0;
            double x3 = 0;

            for (x1 = 0; x1 <= n; x1++)
            {

                for (x2 = 0; x2 <= n; x2++)
                {

                    for (x3 = 0; x3 <= n; x3++)
                    {
                        double sum = x1 + x2 + x3;
                        if (sum == n)
                        {
                            counter++;
                        }


                    }

                }

            }
            Console.WriteLine(counter);
        }
    }
}
