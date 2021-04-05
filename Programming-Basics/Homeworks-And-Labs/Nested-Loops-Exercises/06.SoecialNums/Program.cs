using System;

namespace _06.SoecialNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counterDigit = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                string currnetNums = i.ToString();
                counterDigit = 0;

                for (int y = 0; y < currnetNums.Length; y++)
                {
                    int currentDigit = int.Parse(currnetNums[y].ToString());
                    if (currentDigit == 0)
                    {
                        break;
                    }
                    if (num % currentDigit == 0)
                    {
                        counterDigit++;
                    }
                    else
                    {
                        break;
                    }
                    if (counterDigit == currnetNums.Length)
                    {
                        Console.Write($"{i} ");
                    }

                }
            }
        }
    }
}
