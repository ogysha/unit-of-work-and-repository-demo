using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Entities.MongoDb
{
    public class Book : IDbEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public Guid BookId { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Publisher { get; set; }

        public Author Author { get; set; }
    }
}