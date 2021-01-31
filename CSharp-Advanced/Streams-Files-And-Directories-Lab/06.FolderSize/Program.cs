using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allDirectories = Directory.GetFiles("../../../TestFolder");
            decimal sum = 0;
            foreach (var directory in allDirectories)
            {
                FileInfo fileInfo = new FileInfo(directory);
                Console.WriteLine(fileInfo.Name);
                sum += fileInfo.Length;
            }
            Console.WriteLine(sum / 1000000);
            
        }
    }
}
