using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] firstsRows = new int[array.Length / 2];
            int counterForFirstRows = firstsRows.Length / 2;
            for (int i = 0; i < firstsRows.Length; i++)
            {
                firstsRows[i] = array[counterForFirstRows];
                counterForFirstRows++;
            }
            int[] secontRows = new int[array.Length / 2];
            int counterForSecondRows = firstsRows.Length / 2;
            for (int i = 0; i < counterForSecondRows; i++)
            {
                secontRows[i] = array[counterForSecondRows - i - 1];
            }
            int reverserCounter = 0;
            for (int i = counterForSecondRows; i < secontRows.Length; i++)
            {
                secontRows[counterForSecondRows] = array[array.Length - reverserCounter - 1];
                reverserCounter++;
                counterForSecondRows++;
            }
            for (int i = 0; i < array.Length / 2; i++)
            {
                Console.Write(firstsRows[i] + secontRows[i] + " ");
            }
        }
    }
}
