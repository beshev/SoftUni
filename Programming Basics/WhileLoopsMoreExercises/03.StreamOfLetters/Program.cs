using System;

namespace _03.StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string letter = Console.ReadLine();
            string word = "";
            string final = "";
            int counterC = 0;
            int counterN = 0;
            int counterO = 0;
            int counterAll = 0;

            while (letter != "End")
            {
                char pass = char.Parse(letter);
                if (pass >= 65 && pass <= 90 ||pass >= 97 && pass <= 122 )
                {
                    if (letter == "c")
                    {
                        counterC++;
                        counterAll++;
                        if (counterC >= 2)
                        {
                            word += letter;
                            counterAll--;
                        }
                        letter = string.Empty;
                    }
                    else if (letter == "n")
                    {
                        counterN++;
                        counterAll++;
                        if (counterN >= 2)
                        {
                            word += letter;
                            counterAll--;
                        }
                        letter = string.Empty;
                    }
                    else if (letter == "o")
                    {
                        counterO++;
                        counterAll++;
                        if (counterO >= 2)
                        {
                            word += letter;                            
                            counterAll--;
                        }
                        letter = string.Empty;
                    }
                    if (counterAll == 3)
                    {
                        word += " ";
                        counterAll = 0;
                        counterC = 0;
                        counterN = 0;
                        counterO = 0;
                        final += word;
                        word = string.Empty;
                    }

                    word += letter;
                }
                letter = Console.ReadLine();
            }
            Console.WriteLine(final);

        }
    }
}
