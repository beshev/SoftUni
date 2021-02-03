using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();
            while (type != "end")
            {
                if (type != "print")
                {
                    Func<int, int> mathOperations = MathOperations(type);
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = mathOperations(numbers[i]);
                    }
                }
                else
                {
                    Printer(numbers);
                }

                type = Console.ReadLine();
            }
        }


        static void Printer(int[] numbers)
        {
            Console.WriteLine(string.Join(' ',numbers));
        }

        static Func<int, int> MathOperations(string type)
        {
            if (type == "add") return Add();
            else if (type == "multiply") return Multiply();
            else if (type == "subtract") return Subtract();
            return null;
        }

        static Func<int, int> Add()
        {
            return x => x + 1;
        }

        static Func<int, int> Multiply()
        {
            return x => x * 2;
        }

        static Func<int, int> Subtract()
        {
            return x => x - 1;
        }
    }
}
