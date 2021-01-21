using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string input = Console.ReadLine();
            while (input !="Decode")
            {
                string[] cmdArg = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                if (command == "Move")
                {
                    int numOfLetters = int.Parse(cmdArg[1]);
                    string temp = encryptedMessage.Substring(0,numOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0,numOfLetters);
                    encryptedMessage += temp;
                }
                else if (command == "ChangeAll")
                {
                    string oldString = cmdArg[1];
                    string newString = cmdArg[2];
                    encryptedMessage = encryptedMessage.Replace(oldString,newString);
                }
                else if (command == "Insert")
                {
                    int indexOf = int.Parse(cmdArg[1]);
                    string value = cmdArg[2];
                    encryptedMessage = encryptedMessage.Insert(indexOf,value);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
