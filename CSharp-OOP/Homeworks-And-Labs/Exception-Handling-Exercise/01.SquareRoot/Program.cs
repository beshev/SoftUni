using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new FormatException();
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
