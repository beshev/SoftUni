using System;
using System.IO;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int>[] boxes = new Box<int>[n];
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                boxes[i] = new Box<int>(input);
            }

            int[] indexes = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            Swap(indexes, boxes);
            foreach (var item in boxes)
            {
                Console.WriteLine(item);
            }
        }



        public static void Swap<T>(int[] indexes, Box<T>[] boxes)
        {
            int indexOne = indexes[0];
            int indexTwo = indexes[1];
            bool indexChecker = (indexOne >= 0 && indexOne < boxes.Length)
                && (indexTwo >= 0 && indexTwo < boxes.Length);
            if (indexChecker)
            {
                var temp = new Box<T>(boxes[indexOne].Value);
                boxes[indexOne] = boxes[indexTwo];
                boxes[indexTwo] = temp;
            }
        }
    }
}
