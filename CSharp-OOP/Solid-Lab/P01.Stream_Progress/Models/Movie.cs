using P01.Stream_Progress.Models.Interfaces;

namespace P01.Stream_Progress.Models
{
    class Movie : IStraemable
    {
        private string name;
        private int categorization;

        public Movie(string name, int categorization, int length, int bytesSent)
        {
            this.name = name;
            this.categorization = categorization;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int BytesSent { get; }

        public int Length { get; }
    }
}
