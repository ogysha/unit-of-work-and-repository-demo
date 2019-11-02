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
                Author = new Author
                {
                    AuthorId = domainEntity.Author.Id,
                    FirstName = domainEntity.Author.FirstName,
                    LastName = domainEntity.Author.LastName
                },
                Isbn = domainEntity.Isbn,
                Publisher = domainEntity.Publisher,
                Title = domainEntity.Title,
                ReleaseDate = domainEntity.ReleaseDate
            };
        }
    }
}