namespace _01._BrowserHistory
{
    using _01._BrowserHistory.Interfaces;

    public class Link : ILink
    {
        public Link(string url, int loadingTime)
        {
            this.Url = url;
            this.LoadingTime = loadingTime;
        }

        public string Url { get; set; }
        public int LoadingTime { get; set; }


        public int CompareTo(ILink other)
        {
            if (this.Url.ToLower() == other.Url.ToLower())
            {
                return 0;
            }

            return -1;
        }

        public override string ToString()
        {
            return $"-- {this.Url} {this.LoadingTime}s";
        }
    }
}
