using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int nSongs = int.Parse(Console.ReadLine());
            List<Songs> songs = new List<Songs>();
            for (int i = 0; i < nSongs; i++)
            {
                string[] date = Console.ReadLine().Split("_");
                string type = date[0];
                string name = date[1];
                string time = date[2];
                Songs song = new Songs();
                song.TypeList = type;
                song.Name = name;
                song.Time = time;
                songs.Add(song);
            }
            string typeList = Console.ReadLine();
            List<Songs> result = songs.Where(s => s.TypeList == typeList).ToList();
            foreach (Songs item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        public class Songs
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
    }
}
