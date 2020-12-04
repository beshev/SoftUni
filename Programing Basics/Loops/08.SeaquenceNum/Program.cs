    using System;

    namespace _08.SeaquenceNum
    {
        class Program
        {
            static void Main(string[] args)
            {
                int quantity = int.Parse(Console.ReadLine());

                int maxNumber = int.MinValue;
                int minNumber = int.MaxValue;

                for (int i = 0; i < quantity; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number > maxNumber)
                    {
                        maxNumber = number;
                    }
                    if (minNumber > number)
                    {
                        minNumber = number;
                    }

                }
                Console.WriteLine($"Max number: {maxNumber}");
                Console.WriteLine($"Min number: {minNumber}");
            }
        }
    }
