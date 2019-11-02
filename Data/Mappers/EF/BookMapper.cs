using App.Domain;
using Db = Data.Entities.EF;

namespace Data.Mappers.EF
{
    public class BookMapper : IBookMapper
    {
        private readonly IAuthorMapper _authorMapper;

        public BookMapper(IAuthorMapper authorMapper)
        {
            _authorMapper = authorMapper;
        }

        public Db.Book ToDbEntity(Book book)
        {
            return new Db.Book
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Publisher = book.Publisher,
                Title = book.Title,
                ReleaseDate = book.ReleaseDate,
                Author = _authorMapper.ToDbEntity(book.Author)
            };
        }
    }
}