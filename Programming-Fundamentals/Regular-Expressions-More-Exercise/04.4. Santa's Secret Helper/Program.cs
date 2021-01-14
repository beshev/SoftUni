using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> goodChildrens = new List<string>();
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                string decryptedMessage = DecryptMessage(input, key);
                Match nameAndType = Regex.Match(decryptedMessage, @"@([A-Za-z]+)[^@\-!:>]*!G!");
                if (nameAndType.Success)
                {
                    goodChildrens.Add(nameAndType.Groups[1].Value);
                }

                input = Console.ReadLine();
            }
            foreach (var children in goodChildrens)
            {
                Console.WriteLine(children);
            }
        }

        static string DecryptMessage(string input, int key)
        {
            char[] symbolsToDecrypt = input.ToCharArray();
            for (int i = 0; i < symbolsToDecrypt.Length; i++)
            {
                symbolsToDecrypt[i] = (char)(symbolsToDecrypt[i] - key);
            }
            return new string(symbolsToDecrypt);
        }
    }
}
