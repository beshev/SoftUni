using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string[] reversedText = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse()
                    .ToArray();
                string currentText = new string(string.Join(' ', reversedText));
                int counter = 0;
                while (currentText != null)
                {
                    currentText = currentText.Replace('-', '@');
                    currentText = currentText.Replace(',', '@');
                    currentText = currentText.Replace('.', '@');
                    currentText = currentText.Replace('?', '@');
                    currentText = currentText.Replace('!', '@');
                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(currentText);
                    }
                    counter++;
                    currentText = reader.ReadLine();
                }
            }
        }
    }
}
