using System;

namespace _07.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counterOpenBrackets = 0;
            int counterCloseBrackets = 0; 
            string checks = "(";
            for (int i = 0; i < n; i++)
            {
                string bracketsOrNot = Console.ReadLine();
                if (bracketsOrNot == "(" && checks == "(")
                {
                    counterOpenBrackets++;
                    checks = ")";
                }
                else if (checks == ")" && bracketsOrNot == ")")
                {
                    counterCloseBrackets++;
                    checks = "(";
                }
                else if (bracketsOrNot == "(")
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                else if (bracketsOrNot == ")")
                {
                    counterCloseBrackets--;
                }
            }
            if (counterOpenBrackets == counterCloseBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
