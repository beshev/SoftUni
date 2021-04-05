using System;
using System.Linq;

namespace _5.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string biggersNum = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                bool flag = true;
                for (int j = 0; 1 < numbers.Length - j - i; j++)
                {
                    if (numbers[i] > numbers[i + 1 + j])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }
                if (flag)
                {
                    biggersNum += numbers[i] + " ";
                }
            }
            Console.WriteLine(biggersNum);
        }
    }
}
