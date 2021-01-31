using System;
using System.IO;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream sliceMe = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                for (int i = 0; i < 4; i++)
                {
                    using (FileStream writer = new FileStream($"../../../output{i + 1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[sliceMe.Length / 4];
                        sliceMe.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
