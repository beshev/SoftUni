using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace _06.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                if (new SqlCommand($"SELECT Id FROM Villains WHERE Id = {villainId}", connection, transaction).ExecuteScalar() == null)
                {
                    Console.WriteLine($"No such villain was found.");
                    transaction.Rollback();
                    return;
                }

                var villainName = new SqlCommand($"SELECT Name FROM Villains WHERE Id = {villainId}",connection,transaction).ExecuteScalar();

                var deleteCommand = new SqlCommand($"DELETE FROM MinionsVillains WHERE VillainId = {villainId}", connection, transaction);
                int minionsReleased =deleteCommand.ExecuteNonQuery();
                deleteCommand.CommandText = $"DELETE FROM Villains WHERE Id = {villainId}";
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsReleased} minions were released.");

                transaction.Commit();

            }
        }
    }
}
