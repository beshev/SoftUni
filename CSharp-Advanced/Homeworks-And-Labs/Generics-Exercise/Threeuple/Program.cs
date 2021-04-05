using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Threeuple<string, string, string> first =
                new Threeuple<string, string, string>($"{input[0]} {input[1]}", input[2], input[3]);

            input = Console.ReadLine().Split();
            Threeuple<string, int, bool> second =
                new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), input[2] == "drunk");

            input = Console.ReadLine().Split();
            Threeuple<string, double, string> third =
                new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
