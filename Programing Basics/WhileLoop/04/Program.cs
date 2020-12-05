using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int sum = 1; sum <= num;)
            {
              Console.WriteLine(sum);
              sum = sum * 2 + 1;
            }
        }
    }
}
