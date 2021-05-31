using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace _09._IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());
            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                var cmd = new SqlCommand($"EXEC usp_GetOlder {minionId}",connection);
                Console.WriteLine(cmd.ExecuteScalar());
            }
        }
    }
}
