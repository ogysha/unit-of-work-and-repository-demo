using Data.Entities.MongoDb;

namespace Data.Mappers.MongoDb
{
    public class BookMapper : IBookMapper
    {
        public Book ToDbEntity(App.Domain.Book domainEntity)
        {
            return new Book
            {
                BookId = domainEntity.Id,
                Author = domainEntity.Author,
                Isbn = domainEntity.Isbn,
                Publisher = domainEntity.Publisher,
                Title = domainEntity.Title,
                ReleaseDate = domainEntity.ReleaseDate
            };
        }
    }
}