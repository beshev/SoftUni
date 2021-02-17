using System;
using System.IO;

namespace _02.Bee
{
    class Program
    {
        public class Position
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public void Move(string command)
            {
                if (command == "up")
                {
                    Row--;
                }
                if (command == "down")
                {
                    Row++;
                }
                if (command == "left")
                {
                    Col--;
                }
                if (command == "right")
                {
                    Col++;
                }
            }

            public bool IsSafe(int n)
            {
                if (Row < 0 || Col < 0)
                {
                    return false;
                }
                if (Row >= n || Col >= n)
                {
                    return false;
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Position bee = new Position();
            for (int row = 0; row < n; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'B')
                    {
                        bee.Row = row;
                        bee.Col = col;
                    }
                }
            }
            matrix[bee.Row, bee.Col] = '.';
            int pollinate = 0;
            bool isLost = false;
            string command = Console.ReadLine();
            while (command != "End")
            {
                bee.Move(command);
                if (bee.IsSafe(n))
                {
                    if (matrix[bee.Row, bee.Col] == 'f')
                    {
                        pollinate++;
                        matrix[bee.Row, bee.Col] = '.';
                    }
                    if (matrix[bee.Row, bee.Col] == 'O')
                    {
                        matrix[bee.Row, bee.Col] = '.';
                        bee.Move(command);
                        if (matrix[bee.Row, bee.Col] == 'f') pollinate++;
                        matrix[bee.Row, bee.Col] = '.';
                    }
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    isLost = true;
                    break;
                }
                command = Console.ReadLine();
            }
            if (isLost == false)
            {
                matrix[bee.Row, bee.Col] = 'B';
            }
            if (pollinate < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinate} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinate} flowers!");
            }
            Print(matrix);

        }
        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
