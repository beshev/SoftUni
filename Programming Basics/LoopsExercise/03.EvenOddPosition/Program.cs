using System;

namespace _03.EvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {

            // Read Input  
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            // Find Sum , Min and Max of even/odd Nums
            for (int i = 1; i <= n; i++)
            {
                double nums = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += nums;
                    if (evenMax < nums)
                    {
                        evenMax = nums;
                    }
                    {

                    }
                    if (evenMin > nums)
                    {
                        evenMin = nums;
                    }
                }
                else
                {
                    oddSum += nums;
                    if (oddMax < nums)
                    {
                        oddMax = nums;
                    }
                    {

                    }
                    if (oddMin > nums)
                    {
                        oddMin = nums;
                    }
                }
            }
            // print Output
            if (n == 0)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");

            }
            else if (n <= 1)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }







        }
    }
}
