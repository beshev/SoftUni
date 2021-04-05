using System;

namespace _5.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            string text = "";

            for (int i = 0; i < start; i++)
            {
                string digit = Console.ReadLine();
                int numDigit = digit.Length;
                int mainDigit = int.Parse(Convert.ToString(digit[0]));
                if (mainDigit == 0)
                {
                    text += " ";
                    continue;
                }
                int offset = (mainDigit - 2 ) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int letterIdex = offset + digit.Length - 1;
                letterIdex += 'a';
                text += (char)letterIdex;
                
            }
            Console.WriteLine(text);

            
        }
    }
}
