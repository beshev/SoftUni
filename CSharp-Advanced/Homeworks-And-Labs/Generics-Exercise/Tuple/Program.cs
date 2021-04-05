using System;
using System.Collections.Generic;
using System.IO;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split();
            Tuple<string, string> firstTuple =
                new Tuple<string, string>($"{line1[0]} {line1[1]}", line1[2]);

            string[] line2 = Console.ReadLine().Split();
            Tuple<string, int> secondTuple =
                new Tuple<string, int>(line2[0], int.Parse(line2[1]));

            string[] line3 = Console.ReadLine().Split();
            Tuple<int, double> thirdTuple =
                new Tuple<int, double>(int.Parse(line3[0]), double.Parse(line3[1]));

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
