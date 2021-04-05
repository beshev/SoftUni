using SimpleLogger.Layout.Contracts;

namespace SimpleLogger.Files.Contracts
{
    public interface IFile
    {
        public int FileSize { get; }

        public void Write(string format);
    }
}
