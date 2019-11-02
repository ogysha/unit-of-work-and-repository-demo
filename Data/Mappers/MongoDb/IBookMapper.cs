using Data.Entities.MongoDb;

namespace Data.Mappers.MongoDb
{
    public interface IBookMapper : IDomainToDbMapper<Book, App.Domain.Book>
    {
    }
}