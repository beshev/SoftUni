using System.Linq;
using MongoDB.Driver;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MongoDBDemo
{
    class Program
    {
        //"Steve Jobs", date "05-05-2005", name "The story of Apple",  rating "60".
        static void Main(string[] args)
        {
            var client = new MongoClient
                ("mongodb://127.0.0.1:27017");

            var database = client.GetDatabase("NoSQL");

            var collection = database.GetCollection<BsonDocument>("SoftUniArticles");


            var deleteFilter = Builders<BsonDocument>.Filter.Lt("rating", 171);
            collection.DeleteMany(deleteFilter);

            var articles = collection.Find(new BsonDocument()).ToList();
            foreach (var article in articles)
            {
                string name = article.GetElement("name").Value.AsString;

                int newRanting = article.GetElement("rating").Value.ToInt32() + 5;

                var filterQuery = Builders<BsonDocument>.Filter.Eq("_id", article.GetElement("_id").Value);
                //  var updateQuery = Builders<BsonDocument>.Update.Set("rating", newRanting);
                //
                //  collection.UpdateOne(filterQuery, updateQuery);

                var rating = article.GetElement("rating").Value;

                Console.WriteLine($"{name} <=> Rating: {rating}");

            }
        }
    }
}
