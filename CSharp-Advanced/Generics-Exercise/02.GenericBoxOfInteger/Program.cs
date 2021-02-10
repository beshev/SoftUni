using System;
using System.IO;

namespace _01.GenericBoxOfString
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int>[] box = new Box<int>[n];
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box[i] = new Box<int>(input);
            }
            foreach (var item in box)
            {
                Console.WriteLine(item);
            }
        }
    }
}
