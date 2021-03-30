using SimpleLogger.Files.Contracts;
using SimpleLogger.Layout.Contracts;
using System;
using System.IO;
using System.Linq;

namespace SimpleLogger.Files
{
    public class LogFile : IFile
    {
        public int FileSize => CalcFileSize();

        public void Write(string format)
        {
            File.AppendAllText("../../../log.txt",format + Environment.NewLine);
        }

        private int CalcFileSize()
        {
            return File.ReadAllText("../../../log.txt")
                 .ToCharArray()
                 .Where(x => char.IsDigit(x))
                 .Sum(x => x);
        }
    }
}
