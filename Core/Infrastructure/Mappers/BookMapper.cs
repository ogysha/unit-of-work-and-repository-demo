using Core.Abstractions;
using Core.Infrastructure.Entities;

namespace Core.Infrastructure.Mappers
{
    public class BookMapper : IMapper<Book, global::Core.Entities.Book>
    {
        public Book ToDocument(global::Core.Entities.Book entity)
        {
            return new Book
            {
                Id = new ObjectId(entity.Id),
                Author = entity.Author,
                Category = entity.Category,
                Price = entity.Price,
                BookName = entity.BookName
            };
        }

        public global::Core.Entities.Book ToDomain(Book book)
        {
            return global::Core.Entities.Book.Builder.CreateNew()
                .WithId(book.Id.ToString())
                .WithBookName(book.BookName)
                .Build();
        }
    }
}