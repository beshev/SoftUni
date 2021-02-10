using System;

namespace _01.GenericBoxOfString
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string>[] box = new Box<string>[n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box[i] = new Box<string>(input);
            }
            foreach (var item in box)
            {
                Console.WriteLine(item);
            }
        }
    }
}
