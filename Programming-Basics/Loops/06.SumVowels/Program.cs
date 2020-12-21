using System;

namespace _06.SumVowels
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            int sum = 0;
           

            for (int i = 0; i < text.Length; i++)
            {
                int sumChar = 0;
                switch (text[i])
                {
                    case 'a':
                        sumChar = 1;
                        break;
                    case 'e':
                        sumChar = 2;
                        break;
                    case 'i':
                        sumChar = 3;
                        break;
                    case 'o':
                        sumChar = 4;
                        break;
                    case 'u':
                        sumChar = 5;
                        break;
                }
                sum += sumChar;
            }
            Console.WriteLine($"{sum}");

        }
    }
}
