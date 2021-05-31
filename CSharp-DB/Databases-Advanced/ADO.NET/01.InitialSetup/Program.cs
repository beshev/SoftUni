using Microsoft.Data.SqlClient;
using System;

namespace _01.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Database=master;Integrated Security=True"))
            {
                connection.Open();
                string query = "CREATE DATABASE MinionsDB";
                var sqlCommand = new SqlCommand(query, connection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Database was created successfully");
                }
                catch (SqlException sx)
                {

                    Console.WriteLine(sx.Message);
                }
            }

            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                string query = @"CREATE TABLE Countries
                    (
                        Id INT PRIMARY KEY IDENTITY,
                    
                        [Name] VARCHAR(50) NOT NULL
                    )
                    
                    CREATE TABLE Towns
                    (
                        Id INT PRIMARY KEY IDENTITY,
                    
                        [Name] VARCHAR(50) NOT NULL,
                        CountryCode INT REFERENCES Countries(Id) NOT NULL
                    )
                    
                    CREATE TABLE Minions
                    (
                        Id INT PRIMARY KEY IDENTITY,
                    
                        [Name] VARCHAR(50) NOT NULL,
                        Age INT NOT NULL,
                        TownId INT REFERENCES Towns(Id) NOT NULL
                    )
                    
                    CREATE TABLE EvilnessFactors
                    (
                        Id INT PRIMARY KEY IDENTITY,
                    
                        [Name] VARCHAR(50) NOT NULL,
                    )
                    
                    CREATE TABLE Villains
                    (
                        Id INT PRIMARY KEY IDENTITY,
                    
                        [Name] VARCHAR(50) NOT NULL,
                        EvilnessFactorId INT REFERENCES EvilnessFactors(Id) NOT NULL
                    )
                    
                    CREATE TABLE MinionsVillains
                    (
                        MinionId INT REFERENCES Minions(id) NOT NULL,
                        VillainId INT REFERENCES Villains(id) NOT NULL,
                        PRIMARY KEY(MinionId, VillainId)
                    )";

                var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
            }

            using (var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True"))
            {
                connection.Open();
                string query = @"INSERT INTO Countries([Name]) VALUES
                                ('Bulgaria'),
                                ('Serbia'),
                                ('Russia'),
                                ('North Macedonia'),
                                ('Greece')
                                
                                INSERT INTO Towns([Name],CountryCode) VALUES
                                ('Sofia',1),
                                ('Belgrade',2),
                                ('Moscow',3),
                                ('Skopje',4),
                                ('Athens',5)
                                
                                INSERT INTO Minions([Name],Age,TownId) VALUES
                                ('Victor',22,1),
                                ('Stan',15,2),
                                ('Nikola',32,3),
                                ('Vladko',27,4),
                                ('Nikolaos',46,5)
                                
                                INSERT INTO EvilnessFactors([Name]) VALUES
                                ('super good'),
                                ('good'),
                                ('bad'),
                                ('evil'),
                                ('super evil')
                                
                                INSERT INTO Villains([Name],EvilnessFactorId) VALUES
                                ('Invisible evil',1),
                                ('Inevitable End',2),
                                ('Stancho',3),
                                ('Mr Sugar',4),
                                ('Candyman',5)
                                
                                INSERT INTO MinionsVillains(MinionId,VillainId) VALUES
                                (1,5),
                                (2,4),
                                (3,3),
                                (4,2),
                                (5,1)";
                var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
