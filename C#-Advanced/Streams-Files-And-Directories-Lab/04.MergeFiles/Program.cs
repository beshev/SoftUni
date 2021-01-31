using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader1 = new StreamReader("../../../input1.txt"))
            {
                using (StreamReader reader2 = new StreamReader("../../../input2.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                    {
                        string currentReader1 = reader1.ReadLine();
                        string currentReader2 = reader2.ReadLine();
                        while (currentReader1 != null && currentReader2 != null)
                        {
                            writer.WriteLine(currentReader1);
                            writer.WriteLine(currentReader2);

                            currentReader1 = reader1.ReadLine();
                            currentReader2 = reader2.ReadLine();
                        }
                    }
                }

            }
        }
    }
}
