using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Reveal")
            {
                string[] cmdArg = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArg[0];
                if (type == "InsertSpace")
                {
                    int index = int.Parse(cmdArg[1]);
                    result = result.Insert(index, " ");
                    PrintResult(result);
                }
                else if (type == "ChangeAll")
                {
                    string textToChange = cmdArg[1];
                    string newText = cmdArg[2];
                    result = result.Replace(textToChange, newText);
                    PrintResult(result);
                }
                else if (type == "Reverse")
                {
                    string subString = cmdArg[1];
                    if (result.Contains(subString))
                    {
                        ReverseString(ref result, subString);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {result}");
        }

        static void PrintResult(string result)
        {
            Console.WriteLine(result);
        }

        static void ReverseString(ref string result, string subString)
        {

            int index = result.IndexOf(subString);
            result = result.Remove(index, subString.Length);
            char[] charArr = subString.ToCharArray();
            Array.Reverse(charArr);
            subString = new string(charArr);
            result += subString;
            PrintResult(result);
        }
    }
}
