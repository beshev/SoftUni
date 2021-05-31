using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] minionIds = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;

                foreach (var Id in minionIds)
                {
                    cmd.CommandText = $"UPDATE Minions SET Age += 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)) WHERE Id = {Id}";
                    cmd.ExecuteScalar();
                }

                cmd.CommandText = $"SELECT Name,Age FROM Minions";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                }
            }
        }
    }
}
