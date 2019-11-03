using MongoDB.Driver;

namespace Data.Repositories.MongoDb
{
    public static class MongoClientExtensions
    {
        private const string DatabaseName = "BookstoreDb";

        public static IMongoCollection<T> GetCollection<T>(this MongoClient client, string collectionName)
        {
            return client.GetDatabase(DatabaseName).GetCollection<T>(collectionName);
        }
    }
}