using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace DockCheckWindows.Services
{
    public class LiteDbService
    {
        private readonly LiteDatabase _liteDb;

        private static LiteDbService _instance;
        private LiteDbService(string connectionString)
        {
            _liteDb = new LiteDatabase(connectionString);
            //delete all users from LiteDB
            DeleteAll<User>("User");
        }

        public static LiteDbService Instance
        {
            get
            {
                if (_instance == null)
                {
                    var connectionString = @"Filename=dockcheck.db;Connection=shared;";
                    _instance = new LiteDbService(connectionString);
                }
                return _instance;
            }
        }

        public T GetByIdentificacao<T>(string identificacao) where T : new()
        {
            var collection = _liteDb.GetCollection<T>();
            return collection.FindOne(Query.EQ("Identificacao", identificacao));

        }


        public List<User> GetAll<User>(string collectionName) where User : new()
        {
            var collection = _liteDb.GetCollection<User>("User");
            return collection.FindAll().ToList();
        }

        public void Insert<T>(T item, string collectionName)
        {
            var collection = _liteDb.GetCollection<T>(collectionName);
            collection.Insert(item);
        }

        public bool Update<T>(T item, string collectionName)
        {
            var collection = _liteDb.GetCollection<T>(collectionName);
            return collection.Update(item);
        }

        public bool Delete<T>(string id)
        {
            var collection = _liteDb.GetCollection<T>();
            return collection.Delete(new BsonValue(id));
        }

        //delete all users from LiteDB
        public void DeleteAll<T>(string collectionName)
        {
            var collection = _liteDb.GetCollection<T>(collectionName);
            collection.DeleteAll();
        }

        public bool Exists<T>(string id)
        {
            var collection = _liteDb.GetCollection<T>();
            return collection.Exists(Query.EQ("_id", id));
        }

        public bool UserExists(string userId)
        {
            var collection = _liteDb.GetCollection<User>("User");
            return collection.Exists(Query.EQ("_id", new BsonValue(userId)));
        }

        public void UpsertUser(User user)
        {
            var collection = _liteDb.GetCollection<User>("User");
            if (UserExists(user.Identificacao))
            {
                collection.Update(user);
            }
            else
            {
                collection.Insert(user);
            }
        }
    }
}
