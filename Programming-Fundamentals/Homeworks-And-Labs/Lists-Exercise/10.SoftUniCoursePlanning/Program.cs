using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> startList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> result = new List<string>(startList);
            string input = Console.ReadLine();
            while (input != "course start")
            {
                string[] command = input.Split(':');
                if (command[0] == "Add")
                {
                    AddTitleOfDoesNotExist(result, command[1]);
                }
                else if (command[0] == "Insert")
                {
                    InsertTitleInGivenIndexIfDoesNotExist(result, command[1], int.Parse(command[2]));
                }
                else if (command[0] == "Remove")
                {
                    RemoveExistTitleAndExercise(result, command[1]);
                }
                else if (command[0] == "Swap")
                {
                    SwapTitleIfTheyExist(result, command[1], command[2]);
                }
                else if (command[0] == "Exercise")
                {
                    AddExerciseAtTitleIfDontExists(result, command[1]);
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"{1 + i}.{result[i]}");
            }
        }

        static void AddTitleOfDoesNotExist(List<string> list, string lessonTitle)
        {
            bool dontExist = true;
            foreach (var item in list)
            {
                if (item == lessonTitle)
                {
                    dontExist = false;
                }
            }
            if (dontExist)
            {
                list.Add(lessonTitle);
            }
        }

        static void InsertTitleInGivenIndexIfDoesNotExist(List<string> list, string lessonTitle, int index)
        {
            bool dontExist = true;
            foreach (var item in list)
            {
                if (item == lessonTitle)
                {
                    dontExist = false;
                }
            }
            if (dontExist)
            {
                list.Insert(index, lessonTitle);
            }
        }

        static void RemoveExistTitleAndExercise(List<string> list, string lessonTitle)
        {
            bool exist = false;
            foreach (var item in list)
            {
                if (item == lessonTitle)
                {
                    exist = true;
                    break;
                }
            }
            if (exist)
            {
                list.Remove(lessonTitle);
                foreach (var item in list)
                {
                    if (item == lessonTitle + "-Exercise")
                    {
                        list.Remove(item);
                        break;
                    }
                }
            }
        }

        static void SwapTitleIfTheyExist(List<string> list, string lessonTitleOne, string lessonTitleTwo)
        {
            int indexFirst = -1;
            bool oneHaveExercise = false;
            int indexSecond = -1;
            bool twoHaveExercise = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (lessonTitleOne == list[i])
                {
                    indexFirst = i;
                    if (i + 1 < list.Count)
                    {
                        if (list[i + 1] == lessonTitleOne + "-Exercise")
                        {
                            oneHaveExercise = true;
                            indexFirst++;
                        }
                        break;
                    }

                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (lessonTitleTwo == list[i])
                {
                    indexSecond = i;
                    if (i + 1 < list.Count)
                    {
                        if (list[i + 1] == lessonTitleTwo + "-Exercise")
                        {
                            twoHaveExercise = true;
                            indexSecond++;
                        }
                        break;
                    }
                }
            }
            if (indexFirst >= 0 && indexSecond >= 0)
            {
                List<string> tempOne = new List<string>();
                if (oneHaveExercise)
                {
                    tempOne.Add(list[indexFirst - 1]);
                    tempOne.Add(list[indexFirst]);
                }
                else
                {
                    tempOne.Add(list[indexFirst]);
                }
                List<string> tempTwo = new List<string>();
                if (twoHaveExercise)
                {
                    tempTwo.Add(list[indexSecond - 1]);
                    tempTwo.Add(list[indexSecond]);
                }
                else
                {
                    tempTwo.Add(list[indexSecond]);
                }
                if (oneHaveExercise)
                {
                    list.RemoveAt(indexFirst);
                    list.RemoveAt(indexFirst);
                    if (twoHaveExercise)
                    {
                        list.Insert(indexFirst, tempTwo[1]);
                        list.Insert(indexFirst, tempTwo[0]);
                    }
                    else
                    {
                        list.Insert(indexFirst, tempTwo[0]);
                    }
                }
                else
                {
                    list.RemoveAt(indexFirst);
                    if (twoHaveExercise)
                    {
                        list.Insert(indexFirst, tempTwo[1]);
                        list.Insert(indexFirst, tempTwo[0]);
                    }
                    else
                    {
                        list.Insert(indexFirst, tempTwo[0]);
                    }
                }
                if (twoHaveExercise)
                {
                    list.RemoveAt(indexSecond);
                    list.RemoveAt(indexSecond);
                    if (oneHaveExercise)
                    {
                        list.Insert(indexSecond, tempOne[1]);
                        list.Insert(indexSecond, tempOne[0]);
                    }
                    else
                    {
                        list.Insert(indexSecond, tempOne[0]);
                    }
                }
                else
                {
                    list.RemoveAt(indexSecond);
                    if (oneHaveExercise)
                    {
                        list.Insert(indexSecond, tempOne[1]);
                        list.Insert(indexSecond, tempOne[0]);
                    }
                    else
                    {
                        list.Insert(indexSecond, tempOne[0]);
                    };
                }

            }
        }

        static void AddExerciseAtTitleIfDontExists(List<string> list, string lessonTitle)
        {
            bool haveTitle = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lessonTitle)
                {
                    haveTitle = true;
                    if (i + 1 < list.Count)
                    {
                        if (list[i + 1] != lessonTitle + "-Exercise")
                        {
                            list.Insert(i + 1, lessonTitle + "-Exercise");
                        }
                    }
                    else
                    {
                        list.Add(lessonTitle + "-Exercise");
                    }
                }
            }
            if (!haveTitle)
            {
                list.Add(lessonTitle);
                list.Add(lessonTitle + "-Exercise");
            }
        }
    }
}
