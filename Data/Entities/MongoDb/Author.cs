using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Entities.MongoDb
{
    public class Author
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}