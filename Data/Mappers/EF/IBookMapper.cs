using Data.Entities.EF;

namespace Data.Mappers.EF
{
    public interface IBookMapper : IDomainToDbMapper<Book, App.Domain.Book>
    {
    }
}