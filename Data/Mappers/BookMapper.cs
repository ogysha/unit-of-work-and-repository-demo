using App.Infrastructure.Mappers;
using Data.Entities;
using Data.Mappers.Abstractions;

namespace Data.Mappers
{
    public class BookMapper : IBookMapper
    {
        public Book ToDbEntity(App.Domain.Book book)
        {
            return new Book
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Publisher = book.Publisher,
                Title = book.Title,
                ReleaseDate = book.ReleaseDate
            };
        }
    }
}