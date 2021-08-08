using System;
using System.Collections.Generic;
using FirstWebApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public class NoteService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteService(INotesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var dbList = client.ListDatabases().ToList();
            //foreach (var db in client.ListDatabases().ToList())
            //{
            //    Console.WriteLine($"{db}");
            //}
            
            var database = client.GetDatabase(settings.DatabaseName);
            //Console.WriteLine($"{database.ListCollections().ToJson()}");
            //var collections = database.ListCollections().ToList();

           // Console.WriteLine($"try get collection :  {settings.NotesCollectionName}");
            _notes = database.GetCollection<Note>(settings.NotesCollectionName);
            //Console.WriteLine($"number of documents:  {_notes.CountDocuments(_ => true)}");
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