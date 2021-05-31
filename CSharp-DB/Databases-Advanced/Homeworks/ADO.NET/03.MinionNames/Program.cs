using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (var connectio = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connectio.Open();
                string queryForVillain = @$"SELECT COUNT(*) FROM Villains WHERE Id = {villainId}";
                SqlCommand villainCount = new SqlCommand(queryForVillain, connectio);
                if ((int)villainCount.ExecuteScalar() == 0)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                string getVillain = $@"SELECT Name FROM Villains WHERE Id = {villainId}";
                var nameCommand = new SqlCommand(getVillain,connectio);
                Console.WriteLine($"Villain: {nameCommand.ExecuteScalar()}");


                string queryForMinions = @$"SELECT m.Name AS Minion,
                                                   m.Age AS Age
	                                        FROM Minions AS m
	                                        JOIN MinionsVillains AS ms ON ms.MinionId = m.Id
	                                        JOIN Villains AS v ON v.Id = ms.VillainId
	                                        WHERE ms.VillainId = {villainId}
                                            ORDER BY m.Name";
                var command = new SqlCommand(queryForMinions, connectio);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }
                int counter = 1;
                while (reader.Read())
                {
                    Console.WriteLine($"{counter++}. {reader["Minion"]} {reader["Age"]}");
                }
            }
        }
    }
}
