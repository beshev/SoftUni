using System;
using System.IO;
using System.Linq;

namespace _02.ParkingFeud
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int rows = array[0];
            int cols = array[1];
            int[,] matrix = new int[rows + (rows - 1), cols + 2];
            int samNum = int.Parse(Console.ReadLine());
            string sectors = " ABCDEFGHIJ ";
            int totalDistance = 0;
            string sectorEnd = string.Empty;
            while (true)
            {
                string[] cmd = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string samsParkSpot = cmd[samNum - 1];
                sectorEnd = cmd[samNum - 1];
                cmd[samNum - 1] = null;

                int samStart = samNum * 2 - 1;
                int parkCol = sectors.IndexOf(samsParkSpot[0]);
                int parkRow = int.Parse(samsParkSpot[1].ToString()) * 2 - 2;

                if (cmd.Contains(samsParkSpot))
                {
                    int otherCarStart = (cmd.ToList().IndexOf(samsParkSpot) + 1) * 2 - 1;
                    string directionOther = GetDirection(otherCarStart, parkRow);
                    string directionSam = GetDirection(samNum, parkRow);
                    int samDistance = GetDistance(matrix, directionSam, samStart, parkRow, parkCol);
                    int otherCarDistance = GetDistance(matrix, directionOther, otherCarStart, parkRow, parkCol);
                    if (samDistance <= otherCarDistance)
                    {
                        totalDistance += samDistance;
                        break;
                    }
                    else
                    {
                        totalDistance += (samDistance * 2);
                    }

                }
                else
                {
                    string direction = GetDirection(samStart, parkRow);
                    totalDistance += GetDistance(matrix, direction, samStart, parkRow, parkCol);
                    break;
                }
            }
            Console.WriteLine($"Parked successfully at {sectorEnd}.");
            Console.WriteLine($"Total Distance Passed: {totalDistance}");
        }

        private static string GetDirection(int start, int parkRow)
        {
            if (start + 1 == parkRow || start - 1 == parkRow)
            {
                return null;
            }
            else if (start < parkRow)
            {
                return "down";
            }
            else if (start > parkRow)
            {
                return "up";
            }
            return null;
        }

        static int GetDistance(int[,] matrix, string command, int samNum, int parkRow, int parkCol)
        {
            int result = 0;
            if (command == "up")
            {
                while (true)
                {
                    int col = 0;
                    while (col < matrix.GetLength(1) - 1)
                    {
                        if ((samNum - 1 == parkRow || samNum + 1 == parkRow)
                            && col == parkCol)
                        {
                            return result;
                        }
                        col++;
                        result++;
                    }
                    samNum -= 2;
                    result += 2;
                    while (col > 0)
                    {
                        if ((samNum - 1 == parkRow || samNum + 1 == parkRow)
                            && col == parkCol)
                        {
                            return result;
                        }
                        col--;
                        result++;
                    }
                    samNum -= 2;
                    result += 2;
                }


            }
            else if (command == "down")
            {
                while (true)
                {


                    int col = 0;
                    while (col < matrix.GetLength(1) - 1)
                    {
                        if ((samNum - 1 == parkRow || samNum + 1 == parkRow)
                            && col == parkCol)
                        {
                            return result;
                        }
                        col++;
                        result++;
                    }
                    samNum += 2;
                    result += 2;
                    while (col > 0)
                    {
                        if ((samNum - 1 == parkRow || samNum + 1 == parkRow)
                            && col == parkCol)
                        {
                            return result;
                        }
                        col--;
                        result++;
                    }
                    samNum += 2;
                    result += 2;
                }
            }
            else
            {
                int col = 0;
                while (col != parkCol)
                {
                    col++;
                }
                result = col;
                return result;
            }
            return result;
        }
    }
}
