using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removedWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine();
            int indexOf = text.IndexOf(removedWord);
            while (indexOf != -1)
            {
                text = text.Remove(indexOf, removedWord.Length);
                indexOf = text.IndexOf(removedWord);
            }
            Console.WriteLine(text);
        }
    }
}
