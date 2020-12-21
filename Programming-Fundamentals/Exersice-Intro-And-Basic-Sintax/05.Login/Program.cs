using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string reverse = "";
            int length = userName.Length - 1;
            while (length >= 0)
            {
                reverse += userName[length];
                length--;
            }
            int counter = 0;
            while (true)
            {
                string password = Console.ReadLine();
                counter++;
                if (password == reverse)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    return;
                }
                else
                {
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        return;
                    }

                }
                Console.WriteLine($"Incorrect password. Try again.");

            }
        }
    }
}
