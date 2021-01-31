using System;
using System.IO;
using System.IO.Compression;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\Zip1", @"D:\Zip2\result.zip");
            ZipFile.ExtractToDirectory(@"D:\Zip2\result.zip", @"D:\Zip3\");

        }

    }
}
