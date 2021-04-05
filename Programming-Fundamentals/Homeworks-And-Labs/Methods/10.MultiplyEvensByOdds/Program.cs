using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            Console.WriteLine(GetSumOfOddOrEveneNumbers(number, 0) * GetSumOfOddOrEveneNumbers(number , 1));
        }

        static int GetSumOfOddOrEveneNumbers(int number,int evenOrOdd)
        {
            int sum = 0;
            string input = number.ToString();
            for (int i = 0; i < input.Length; i++)
            {
                if (int.Parse(input[i].ToString()) % 2 == evenOrOdd)
                {
                    sum += int.Parse(input[i].ToString());

                }
            }
            return sum;

        }
    }
}
