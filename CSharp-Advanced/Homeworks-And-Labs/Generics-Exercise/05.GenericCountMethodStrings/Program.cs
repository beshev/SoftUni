using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                boxes.Add(new Box<string>(input));
            }
            Console.WriteLine(GenericCpunter(boxes,Console.ReadLine()));
        }



        public static void Swap<T>(int[] indexes, List<Box<T>> boxes)
        {
            int indexOne = indexes[0];
            int indexTwo = indexes[1];
            bool indexChecker = (indexOne >= 0 && indexOne < boxes.Count)
                && (indexTwo >= 0 && indexTwo < boxes.Count);
            if (indexChecker)
            {
                var temp = new Box<T>(boxes[indexOne].Value);
                boxes[indexOne] = boxes[indexTwo];
                boxes[indexTwo] = temp;
            }
        }

        static int GenericCpunter<T>(List<Box<T>> boxes,T valueToCompare)
            where T : IComparable
        {
            int couter = 0;
            foreach (var box in boxes)
            {
                if (box.Value.CompareTo(valueToCompare) == 1)
                {
                    couter++;
                }
            }
            return couter;
        }
    }
}
