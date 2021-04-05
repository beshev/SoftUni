using P01.Stream_Progress.Models;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music music = new Music("NickelBack", "The 9 song",100,2);
            StreamProgressInfo musicStream = new StreamProgressInfo(music);
            Console.WriteLine($"NickelBack stream: {musicStream.CalculateCurrentPercent()}%");

            File file = new File("TestFile",100,22);
            StreamProgressInfo fileStream = new StreamProgressInfo(file);
            Console.WriteLine($"TestFile stream: {fileStream.CalculateCurrentPercent()}%");

            Movie movie = new Movie("Happy Programmer",12,100,50);
            StreamProgressInfo movieStream = new StreamProgressInfo(movie);
            Console.WriteLine($"Happy Programmer stream: {movieStream.CalculateCurrentPercent()}%");
        }
    }
}
