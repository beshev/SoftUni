using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                string query = @"SELECT v.Name AS Name,COUNT(*) AS [Count]
                                	FROM MinionsVillains as mv
                                	JOIN Villains AS v ON v.Id = mv.VillainId
                                	JOIN Minions AS m ON m.Id = mv.MinionId
                                GROUP BY v.Name
                                HAVING COUNT(*) >= 3
                                ORDER BY COUNT(*) DESC";
                var sqlCommand = new SqlCommand(query, connection);

               SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"{sqlDataReader["Name"]} - {sqlDataReader["Count"]}");
                }
            }
        }
    }
}
