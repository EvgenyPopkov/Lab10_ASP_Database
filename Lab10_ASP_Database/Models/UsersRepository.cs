using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Lab10_ASP_Database.Models
{
    public interface IUsersRepository
    {
        List<User> AllUsers();
        User GetUser(ObjectId id);
        void Add(User user);
        void Update(User user);
        void Remove(ObjectId id);
    }

    public class UsersRepository : IUsersRepository
    {
        static MongoClient client;
        static IMongoDatabase db;
        IMongoCollection <User> users;

        public UsersRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("UsersDB");
            users = db.GetCollection<User>("Users");
        }

        public List<User> AllUsers()
        {
            return users.Find(Builders<User>.Filter.Empty).ToList();
        }

        public User GetUser(ObjectId id)
        {
            return users.Find(Builders<User>.Filter.Eq(_ => _.Id, id)).FirstOrDefault();
        }

        public void Add(User user)
        {
            users.InsertOne(user);
        }

        public void Update(User user)
        {
            var filter = Builders<User>.Filter.Eq(_ => _.Id, user.Id);
            users.ReplaceOne(filter, user);
        }
        public void Remove(ObjectId id)
        {
            users.DeleteOne(Builders<User>.Filter.Eq(_ => _.Id, id));
        }
    }
}
