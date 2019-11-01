using MongoDB.Bson;
using MongoDb.Client.Entities;

namespace MongoDb.Client.Mappers
{
    public class BookMapper : IMapper<Book, Domain.Book>
    {
        public Book ToDocument(Domain.Book entity)
        {
            return new Book
            {
                Id = new ObjectId(entity.Id),
                Author = entity.Author,
                Category = entity.Category,
                Price = entity.Price,
                Title = entity.BookName
            };
        }

        public Domain.Book ToDomain(Book book)
        {
            return Domain.Book.Builder.CreateNew()
                .WithId(book.Id.ToString())
                .WithBookName(book.Title)
                .Build();
        }
    }
}