using P01.Stream_Progress.Models.Interfaces;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStraemable file;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStraemable file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
