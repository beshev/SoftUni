using System;
using System.IO;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int currentNum = ReadNumber(start, end);
                    if (currentNum < start || currentNum > end)
                    {
                        throw new ArgumentException("Invalid number");
                    }
                }
                catch (FormatException)
                {
                    i = 0;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i = 0;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            return number;
        }
    }
}


