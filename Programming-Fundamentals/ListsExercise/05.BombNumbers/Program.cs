using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] detonateNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(GetSumOfListAfterDetonate(list, detonateNumbers));

        }

        static int GetSumOfListAfterDetonate(List<int> list, int[] detonateNumbers)
        {
            List<int> detonateList = new List<int>(list);
            for (int i = 0; i < detonateList.Count; i++)
            {
                int temp = 0;
                if (detonateList[i] == detonateNumbers[0])
                {
                    if (i - detonateNumbers[1] < 0)
                    {
                        for (int j = 0; j <= i; j++)
                        {
                            detonateList.RemoveAt(0);
                        }
                    }
                    else
                    {
                        temp = i - detonateNumbers[1];
                        for (int j = 0; j < detonateNumbers[1] + 1; j++)
                        {
                            detonateList.RemoveAt(i - detonateNumbers[1]);
                        }
                    }
                    for (int j = 0; j < detonateNumbers[1]; j++)
                    {
                        if (temp == detonateList.Count)
                        {
                            break;
                        }
                        detonateList.RemoveAt(temp);
                    }
                    i = 0;
                }
            }
            int sum = 0;
            for (int i = 0; i < detonateList.Count; i++)
            {
                sum += detonateList[i];
            }
            return sum;
        }
    }
}
