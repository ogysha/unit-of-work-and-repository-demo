using App.Domain;
using Db = Data.Entities.EF;

namespace Data.Mappers.EF
{
    public class BookMapper : IBookMapper
    {
        public Db.Book ToDbEntity(Book book)
        {
            return new Db.Book
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