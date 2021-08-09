using System.Collections.Generic;
using FirstWebApp.Models;
using MongoDB.Driver;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public class NoteServices : MongoDbService<Note> {

        public NoteServices(IDatabaseSettings settings) : base(settings)
        {
        }

        public Note Get(string id) =>
            _collection.Find<Note>(note => note.Id.ToString() == id).FirstOrDefault();

        public void Update(string id, Note noteIn) =>
            _collection.ReplaceOne(note => note.Id.ToString() == id, noteIn);

        public void Remove(Note noteIn) =>
            _collection.DeleteOne(note => note.Id == noteIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(note => note.Id.ToString() == id);
    }
}