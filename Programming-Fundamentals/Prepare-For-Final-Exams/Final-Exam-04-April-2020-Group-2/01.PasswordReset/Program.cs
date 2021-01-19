using System;
using System.Text;
using System.Linq;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] cmdArg = input.Split();
                if (cmdArg[0] == "TakeOdd")
                {
                    StringBuilder result = new StringBuilder();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        result.Append(password[i]);
                    }
                    password = result.ToString();
                    Console.WriteLine(password);
                }
                else if (cmdArg[0] == "Cut")
                {
                    int index = int.Parse(cmdArg[1].ToString());
                    int lenght = int.Parse(cmdArg[2].ToString());
                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (cmdArg[0] == "Substitute")
                {
                    string subString = cmdArg[1];
                    string subStitute = cmdArg[2];
                    if (password.Contains(subString))
                    {
                        password = password.Replace(subString, subStitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }

    }
}
