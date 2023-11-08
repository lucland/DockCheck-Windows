using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace DockCheckWindows.Services
{
    public class LiteDbService
    {
        private readonly LiteDatabase _liteDb;

        private static LiteDbService _instance;

        static LiteDbService()
        {
            // Set up the mapper before creating the LiteDatabase instance
            BsonMapper.Global.Entity<User>().Id(x => x.Id, false);
        }

        private LiteDbService(string connectionString)
        {
            _liteDb = new LiteDatabase(connectionString);
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

        public T GetById<T>(string id) where T : new()
        {
            var collection = _liteDb.GetCollection<T>();
            return collection.FindById(new BsonValue(id));
        }

        public List<T> GetAll<T>(string collectionName) where T : new()
        {
            var collection = _liteDb.GetCollection<T>(collectionName);
            return collection.FindAll().ToList();
        }

        public void Insert<T>(T item, string collectionName)
        {
            var collection = _liteDb.GetCollection<T>(collectionName);
            collection.Insert(item);
        }

        public bool Update<T>(T item)
        {
            var collection = _liteDb.GetCollection<T>();
            return collection.Update(item);
        }

        public bool Delete<T>(string id)
        {
            var collection = _liteDb.GetCollection<T>();
            return collection.Delete(new BsonValue(id));
        }
    }
}
