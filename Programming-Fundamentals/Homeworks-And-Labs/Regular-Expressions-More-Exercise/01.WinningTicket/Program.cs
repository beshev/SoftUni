using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            var tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    CheckIfIsJackpodOrNotAndPrintResult(ticket);
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }

            static void CheckIfIsJackpodOrNotAndPrintResult(string ticket)
            {

                Match isJackpod = Regex.Match(ticket, @"[$]{20}|[@]{20}|[#]{20}|[\^]{20}");
                if (isJackpod.Success)
                {
                    string symbol = isJackpod.Value;
                    Console.WriteLine($"ticket \"{ticket}\" - {10}{symbol[0]} Jackpot!");
                }
                else
                {
                    string leftSide = GetLeftSide(ticket);
                    string rightSide = GetRightSide(ticket);
                    if ((leftSide.Length >= 6 && rightSide.Length >= 6)
                        && (leftSide[0] == rightSide[0]))
                    {
                        int num = Math.Min(leftSide.Length, rightSide.Length);
                        Console.WriteLine($"ticket \"{ticket}\" - {num}{leftSide[0]}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }

                }
            }

            static string GetLeftSide(string ticket)
            {
                string matchLeft = string.Empty;
                string leftSide = ticket.Substring(0, 10);
                Match left = Regex.Match(leftSide, @"[$]{6,10}|[@]{6,10}|[#]{6,10}|[\^]{6,10}");
                if (left.Success)
                {
                    matchLeft = left.Value;
                }
                return matchLeft;
            }

            static string GetRightSide(string ticket)
            {
                string matchRight = string.Empty;
                string rightSide = ticket.Substring(10, 10);
                Match right = Regex.Match(rightSide, @"[$]{6,10}|[@]{6,10}|[#]{6,10}|[\^]{6,10}");
                if (right.Success)
                {
                    matchRight = right.Value;
                }
                return matchRight;
            }
        }
    }
}
