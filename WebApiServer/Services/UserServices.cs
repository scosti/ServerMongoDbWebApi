using MongoDB.Driver;
using WebApiServer.Models;

namespace WebApiServer.Services
{
    public class UserServices :MongoDbService<User>
    {

        public User Get(string id) =>
            _collection.Find<User>(user => user.Id.ToString() == id).FirstOrDefault();

        public void Update(string id, User userIn) =>
            _collection.ReplaceOne(user => user.Id.ToString() == id, userIn);

        public void Remove(User userIn) =>
            _collection.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(user => user.Id.ToString() == id);

        public UserServices(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}