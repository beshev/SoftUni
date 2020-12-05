using System;

namespace _02.ReadPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            string check = "";

            while (password != check)
            {
                 check= Console.ReadLine();
            }
            Console.WriteLine($"Welcome {userName}!");
        }
    }
}
