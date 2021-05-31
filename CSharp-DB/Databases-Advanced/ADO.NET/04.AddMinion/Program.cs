using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            minionInfo = minionInfo.Skip(1).ToArray();
            string[] villainInfo = Console.ReadLine().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            villainInfo = villainInfo.Skip(1).ToArray();

            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                SqlTransaction transaction = null;

                try
                {
                    //eviless factor 4
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    var townQuery = $@"SELECT Name FROM Towns WHERE Name = '{minionInfo[2]}'";
                    var cmdArg = new SqlCommand(townQuery, connection, transaction);
                    var townName = cmdArg.ExecuteScalar();

                    if (townName == null)
                    {
                        townName = minionInfo[2];
                        cmdArg.CommandText = $@"INSERT INTO Towns(Name,CountryCode) VALUES ('{townName}',1)";
                        cmdArg.ExecuteNonQuery();
                        Console.WriteLine($"Town {townName} was added to the database.");
                    }

                    cmdArg.CommandText = $@"SELECT Name FROM Villains WHERE Name = '{villainInfo[0]}'";
                    if (cmdArg.ExecuteScalar() == null)
                    {
                        cmdArg.CommandText = $@"INSERT INTO Villains(Name,EvilnessFactorId) VALUES('{villainInfo[0]}',4)";
                        cmdArg.ExecuteNonQuery();
                        Console.WriteLine($"Villain {villainInfo[0]} was added to the database.");
                    }

                    int townId = (int)new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{townName}'", connection, transaction).ExecuteScalar(); 
                    cmdArg.CommandText = $@"INSERT INTO Minions(Name,Age,TownId) VALUES('{minionInfo[0]}',{minionInfo[1]},{townId})";
                    cmdArg.ExecuteNonQuery();

                    int miniondId = (int)new SqlCommand
                        ($"SELECT Id FROM Minions WHERE Name = '{minionInfo[0]}' AND Age = {minionInfo[1]} AND TownId = {townId}", 
                        connection, transaction).ExecuteScalar();

                    int villainId = (int)new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainInfo[0]}'",
                        connection, transaction).ExecuteScalar();

                    cmdArg.CommandText = $@"INSERT INTO MinionsVillains(MinionId,VillainId) VALUES ({miniondId},{villainId})";
                    cmdArg.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionInfo[0]} to be minion of {villainInfo[0]}.");

                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
