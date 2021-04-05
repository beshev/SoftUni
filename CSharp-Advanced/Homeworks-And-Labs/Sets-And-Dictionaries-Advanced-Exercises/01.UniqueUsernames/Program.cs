using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }
            usernames.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
