using AuthorProblem.Attributes;
using AuthorProblem.Models;

namespace AuthorProblem
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        public static void Main(string[] args)
        {
            Tracker.PrintMethodsByAuthor();
        }
        [Author("Dimitar.Beshev(_- Me -_)")]
        private static void JustForTest() { }
    }
}
