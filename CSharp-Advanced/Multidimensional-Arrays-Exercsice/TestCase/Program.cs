using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        ReadFieldFromConsole(matrix);



        PrintField(matrix);
    }

    private static void PrintField(int[,] field)
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] < 10)
                {
                    Console.Write(" " + field[row, col] + " ");
                }
                else
                {
                    Console.Write(field[row, col] + " ");
                }

            }
            Console.WriteLine();
        }
    }

    private static void ReadFieldFromConsole(int[,] field)
    {
        int counter = 1;
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                field[row, col] = counter++;
            }
        }
    }
}