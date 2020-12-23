using System;
using System.Linq;

namespace _01.EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[] allSums = new double[n];

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double vowelSum = 0;
                double cosonantSum = 0;
                for (int j = 0; j < name.Length; j++)
                {
                    bool isVowel = name[j] == 'a' || name[j] == 'e' || name[j] == 'i' || name[j] == 'o' || name[j] == 'u' ||
                        name[j] == 'A' || name[j] == 'E' || name[j] == 'I' || name[j] == 'O' || name[j] == 'U';
                    if (isVowel)
                    {
                        vowelSum += name[j] * name.Length;
                    }
                    else
                    {
                        cosonantSum += name[j] / name.Length;
                    }
                }
                allSums[i] = vowelSum + cosonantSum;
            }
            Array.Sort(allSums);
            foreach (var item in allSums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
