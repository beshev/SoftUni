using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            DecryptedSomeText(GetAllGidigtsFromString(someText), RemoveAllDigitsFromSting(someText));
        }

        static List<int> GetAllGidigtsFromString(string input)
        {
            List<int> digits = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                bool isDigit = int.TryParse(input[i].ToString(), out _);
                if (isDigit)
                {
                    digits.Add(int.Parse(input[i].ToString()));
                }
            }
            return digits;
        }

        static List<string> RemoveAllDigitsFromSting(string input)
        {
            List<string> text = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                bool isDigit = int.TryParse(input[i].ToString(), out _);
                if (!isDigit)
                {
                    text.Add(input[i].ToString());
                }
            }
            return text;
        }

        static void DecryptedSomeText(List<int> digits, List<string> text)
        {
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(digits[i]);
                }
                else
                {
                    skipList.Add(digits[i]);
                }
            }
            List<string> decryptedText = new List<string>();
            int skipCounter = 0;
            int takeCounter = 0;
            bool flag = false;
            for (int i = 0; i <= text.Count; i++)
            {
                if (takeCounter > takeList.Count - 1 || skipCounter > skipList.Count - 1)
                {
                    break;
                }
                if (takeList[takeCounter] > text.Count)
                {
                    for (int j = 0; j < text.Count; j++)
                    {
                        decryptedText.Add(text[j]);
                        flag = true;
                    }
                }
                else if (takeCounter < takeList.Count)
                {
                    for (int j = 0; j < takeList[takeCounter]; j++)
                    {
                        decryptedText.Add(text[0]);
                        text.RemoveAt(0);
                    }
                }
                takeCounter++;
                if (skipCounter < skipList.Count - 1)
                {
                    for (int j = 0; j < skipList[skipCounter]; j++)
                    {
                        text.RemoveAt(0);
                    }
                    skipCounter++;
                }
                if (flag)
                {
                    break;
                }
                i = 0;

            }
            foreach (var item in decryptedText)
            {
                Console.Write(item);
            }
        }
    }
}
