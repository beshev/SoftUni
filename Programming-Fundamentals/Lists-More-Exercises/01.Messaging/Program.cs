using System;
using System.Collections.Generic;
using System.Linq;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numebers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            foreach (var item in TakeAElemetAndAddToList(numebers, input))
            {
                Console.Write(item);
            }
        }
        static List<string> TakeAElemetAndAddToList(List<int> numbers, string input)
        {
            List<string> text = new List<string>();
            foreach (var item in input)
            {
                text.Add(item.ToString());
            }
            List<string> result = new List<string>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                string currentDigits = numbers[i].ToString();
                for (int j = 0; j < currentDigits.Length; j++)
                {
                    sum += int.Parse(currentDigits[j].ToString());
                }
                if (sum > text.Count)
                {
                    result.Add(text[sum - text.Count].ToString());
                    text.RemoveAt(sum - text.Count);
                }
                else
                {
                    result.Add(text[sum].ToString());
                    text.RemoveAt(sum);
                }

            }
            return result;
        }
    }
}
