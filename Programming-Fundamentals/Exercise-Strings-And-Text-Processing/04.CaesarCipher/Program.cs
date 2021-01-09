using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string encryptedText = EncryptText(input);
            Console.WriteLine(encryptedText);
        }

        static string EncryptText(string text)
        {
            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                encryptedText.Append((char)(text[i] + 3));
            }
            return encryptedText.ToString();
        }
    }
}
