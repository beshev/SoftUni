using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.RemoveNegativesAdReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            list.RemoveAll(n => n > 0);
            list.Reverse();
            if (list.Count == 0)
            {
                Console.WriteLine($"empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", list));
            }
        }

        static List<int> RemoveNegativesNumbersAdReverse(List<int> list)
        {
            List<int> result = new List<int>(list);
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] < 0)
                {
                    result.RemoveAt(i);
                    i--;
                }
            }
            result.Reverse();
            return result;
        }
    }
}
