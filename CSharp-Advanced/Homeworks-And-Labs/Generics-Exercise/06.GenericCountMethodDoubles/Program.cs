using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDoubles
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                boxes.Add(new Box<double>(input));
            }
            Console.WriteLine(GenericCpunter(boxes,double.Parse(Console.ReadLine())));
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
