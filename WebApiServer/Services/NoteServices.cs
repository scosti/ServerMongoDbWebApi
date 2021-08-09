using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using FirstWebApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public class NoteService
    {
        private readonly IMongoCollection<Note> _notes;
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Product> _products;

        public NoteService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var dbList = client.ListDatabases().ToList();

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

            _notes = database.GetCollection<Note>(settings.NotesCollectionName);
            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }

        public List<Note> Get() =>
            _notes.Find(note => true).ToList();

        public Note Get(string id) =>
            _notes.Find<Note>(note => note.Id.ToString() == id).FirstOrDefault();

        public Note Create(Note note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public void Update(string id, Note noteIn) =>
            _notes.ReplaceOne(note => note.Id.ToString() == id, noteIn);

        public void Remove(Note noteIn) =>
            _notes.DeleteOne(note => note.Id == noteIn.Id);

        public void Remove(string id) => 
            _notes.DeleteOne(note => note.Id.ToString() == id);
    }
}