using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> startList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            RemuveValueFromListAndIncreaseAndDecreaseOtherValues(startList);
        }

        static void RemuveValueFromListAndIncreaseAndDecreaseOtherValues(List<int> list)
        {
            List<int> input = new List<int>(list);
            int sumOfAll = 0;
            int removeValue = 0;
            while (input.Count != 0)
            {
                int indexRemuve = int.Parse(Console.ReadLine());
                if (indexRemuve < 0)
                {
                    removeValue = input[0];
                    input.RemoveAt(0);
                    input.Insert(0, input[input.Count - 1]);
                }
                else if (indexRemuve > input.Count - 1)
                {
                    removeValue = input[input.Count - 1];
                    input.RemoveAt(input.Count - 1);
                    input.Add(input[0]);
                }
                else
                {
                    removeValue = input[indexRemuve];
                    input.RemoveAt(indexRemuve);
                }
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] <= removeValue)
                    {
                        input[i] += removeValue;
                    }
                    else
                    {
                        input[i] -= removeValue;
                    }
                }
                sumOfAll += removeValue;
            }
            Console.WriteLine(sumOfAll);
        }
    }
}
