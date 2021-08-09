using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public class MongoDbService<T>
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoDbService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            bool databaseFind = false;
            foreach (var db in client.ListDatabases().ToList())
            {
                if (db.Values.Contains(settings.DatabaseName))
                {
                    databaseFind = true;
                }
            }
            if (databaseFind == false)
            {
                Console.WriteLine($"Error database don't exist: {settings.DatabaseName}");
            }

            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<T>(typeof(T).Name);

        }

        public List<T> Get() =>
            _collection.Find(x => true).ToList();
        public T Create(T x)
        {
            _collection.InsertOne(x);
            return x;
        }
    }
}