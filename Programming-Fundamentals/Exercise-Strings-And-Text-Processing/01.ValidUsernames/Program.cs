using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var name in userNames)
            {
                bool length = name.Length >= 3 && name.Length <= 16;
                if (length)
                {
                    bool isValid = true;
                    for (int i = 0; i < name.Length; i++)
                    {
                        if ((char.IsLetterOrDigit(name[i]) || (name[i] == '-' || name[i] == '_')) == false)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
