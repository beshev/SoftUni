using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLenght = int.Parse(Console.ReadLine());
            int bestLenght = 0;
            int[] bestDna = new int[dnaLenght];
            int bestSum = 0;
            int bestSample = 0;
            int bestIdex = 0;
            int currentSample = 0;
            // 1 0 1 1 0
            string input = Console.ReadLine();
            while (input != "Clone them!")
            {
                currentSample++;
                int[] currnetDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentLenght = 1;
                int currentIndex = 0;
                int currentSum = 0;
                for (int i = 0; i < currnetDNA.Length - 1; i++)
                {
                    if (currnetDNA[i] == 1 && currnetDNA[i + 1] == 1)
                    {
                        currentLenght++;
                        if (currentIndex < i)
                        {
                            currentIndex = i;
                        }
                    }

                }
                for (int i = 0; i < currnetDNA.Length; i++)
                {
                    currentSum += currnetDNA[i];
                }
                if (currentLenght > bestLenght)
                {
                    bestLenght = currentLenght;
                    bestDna = currnetDNA.ToArray();
                    bestSum = currentSum;
                    bestIdex = currentIndex;
                    bestSample = currentSample;
                }
                else if (currentLenght == bestLenght)
                {
                    if (currentIndex < bestIdex)
                    {
                        bestLenght = currentLenght;
                        bestDna = currnetDNA.ToArray();
                        bestSum = currentSum;
                        bestIdex = currentIndex;
                        bestSample = currentSample;
                    }
                    else if (currentSum > bestSum)
                    {
                        bestLenght = currentLenght;
                        bestDna = currnetDNA.ToArray();
                        bestSum = currentSum;
                        bestIdex = currentIndex;
                        bestSample = currentSample;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}
