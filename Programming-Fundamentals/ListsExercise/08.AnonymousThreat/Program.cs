using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> result = new List<string>(firstList);
            string input = Console.ReadLine();
            while (input != "3:1")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "merge")
                {
                    result = MargeListFromGivenIdexes(result, int.Parse(command[1]), int.Parse(command[2]));
                }
                else if (command[0] == "divide")
                {
                    result = DivideListFromGivenIndexToSeveralSubstrings(result, int.Parse(command[1]), int.Parse(command[2]));
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", result));
        }

        static List<string> MargeListFromGivenIdexes(List<string> firstList, int startIdex, int endIndex)
        {
            if (startIdex > firstList.Count - 1)
            {
                return firstList;
            }
            else if (startIdex < 0)
            {
                if (endIndex > 0 && endIndex < firstList.Count)
                {
                    for (int i = 0; i < endIndex; i++)
                    {
                        firstList[0] += firstList[1];
                        firstList.RemoveAt(1);
                    }
                }
                else if (endIndex > firstList.Count - 1)
                {
                    for (int i = 1; i < firstList.Count;)
                    {
                        firstList[0] += firstList[1];
                        firstList.RemoveAt(1);
                    }
                }
            }
            else
            {
                if (endIndex > firstList.Count - 1)
                {
                    for (int i = startIdex; i < firstList.Count - 1;)
                    {
                        firstList[startIdex] += firstList[startIdex + 1];
                        firstList.RemoveAt(startIdex + 1);
                    }
                }
                else
                {
                    for (int i = startIdex; i < endIndex; i++)
                    {
                        firstList[startIdex] += firstList[startIdex + 1];
                        firstList.RemoveAt(startIdex + 1);
                    }
                }
            }
            return firstList;

        }

        static List<string> DivideListFromGivenIndexToSeveralSubstrings(List<string> result, int index, int divideOn)
        {
            List<string> temp = new List<string>();
            string toDivide = result[index];
            int partLength = toDivide.Length / divideOn;
            int additionalPartLength = toDivide.Length % divideOn;
            for (int i = 0; i < divideOn; i++)
            {
                if (i == divideOn - 1)
                {
                    partLength += additionalPartLength;
                }
                temp.Add(toDivide.Substring(0, partLength));
                toDivide = toDivide.Remove(0, partLength);
            }
            result.RemoveAt(index);
            result.InsertRange(index, temp);
            return result;
        }
    }
}