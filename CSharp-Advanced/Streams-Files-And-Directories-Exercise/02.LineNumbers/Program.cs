using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../input.txt");
            List<string> output = new List<string>();
            int lineCounter = 1;
            foreach (var line in lines)
            {
                string currentLine = line;
                int punctuationCount = Regex.Matches(currentLine, @"[.,;:?!'-]").Count;
                int lettersCount = Regex.Matches(currentLine, @"[A-Za-z]").Count;
                output.Add($"Line {lineCounter}: {currentLine} ({lettersCount})({punctuationCount})");
                lineCounter++;
            }
            File.WriteAllLines("../../../output.txt", output);
        }
    }
}
