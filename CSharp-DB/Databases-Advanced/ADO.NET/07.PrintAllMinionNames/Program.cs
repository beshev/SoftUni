using Microsoft.Data.SqlClient;
using System;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                int rowsCount = (int)new SqlCommand("SELECT COUNT(*) FROM Minions", connection).ExecuteScalar();

                int start = 1;
                int end = rowsCount;

                var fromFirts = new SqlCommand($"SELECT Name FROM Minions WHERE Id = {start}", connection);
                var fromLast = new SqlCommand($"SELECT Name FROM Minions WHERE Id = {end}", connection);

                while (start != end)
                {
                    Console.WriteLine(fromFirts.ExecuteScalar());
                    Console.WriteLine(fromLast.ExecuteScalar());

                    fromFirts.CommandText = $"SELECT Name FROM Minions WHERE Id = {++start}";
                    fromLast.CommandText = $"SELECT Name FROM Minions WHERE Id = {--end}";
                }
                if (rowsCount % 2 != 0)
                {
                    Console.WriteLine(fromFirts.ExecuteScalar());
                }
            }
        }
    }
}
