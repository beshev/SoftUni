using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                var countryId = new SqlCommand($"SELECT Id FROM Countries WHERE Name = '{countryName}'",connection).ExecuteScalar();
                if (countryId == null)
                {
                    NonAfectedRowsMsg();
                    return;
                        
                }
                var citiesCount = new SqlCommand($"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = {countryId}",connection).ExecuteNonQuery();

                if (citiesCount == 0)
                {
                    NonAfectedRowsMsg();
                    return;
                }

                Console.WriteLine($"{citiesCount} town names were affected.");
                var cities = new SqlCommand($"SELECT Name AS Name FROM Towns WHERE CountryCode = {countryId}", connection);
                Console.WriteLine($"[{string.Join(", ",GetAllCitiesNames(cities.ExecuteReader()))}]");

            }
        }

        private static void NonAfectedRowsMsg()
        {
            Console.WriteLine($"No town names were affected.");
        }

        private static string[] GetAllCitiesNames(SqlDataReader sqlDataReader)
        {
            List<string> result = new List<string>();

            while (sqlDataReader.Read())
            {
                result.Add(sqlDataReader["Name"].ToString());
            }

            return result.ToArray();
        }
    }
}
