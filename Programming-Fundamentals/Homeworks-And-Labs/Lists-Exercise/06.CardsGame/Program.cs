using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            PrintSumAndNameOfWinner(firstDeck, secondDeck);
        }

        static void PrintSumAndNameOfWinner(List<int> firstDeck, List<int> secondDeck)
        {
            List<int> first = new List<int>(firstDeck);
            List<int> second = new List<int>(secondDeck);
            string winner = String.Empty;
            int sum = 0;
            while (true)
            {
                int result = first[0].CompareTo(second[0]);
                if (result == 0)
                {
                    first.RemoveAt(0);
                    second.RemoveAt(0);
                }
                else if (result > 0)
                {
                    first.Add(first[0]);
                    first.Add(second[0]);
                    first.RemoveAt(0);
                    second.RemoveAt(0);
                }
                else
                {
                    second.Add(second[0]);
                    second.Add(first[0]);
                    first.RemoveAt(0);
                    second.RemoveAt(0);
                }
                if (first.Count == 0)
                {
                    for (int i = 0; i < second.Count; i++)
                    {
                        sum += second[i];
                    }
                    winner = "Second";
                    break;
                }
                if (second.Count == 0)
                {
                    for (int i = 0; i < first.Count; i++)
                    {
                        sum += first[i];
                    }
                    winner = "First";
                    break;
                }
            }
            Console.WriteLine($"{winner} player wins! Sum: {sum}");
        }
    }
}
