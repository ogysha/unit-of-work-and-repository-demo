using App.Infrastructure.Mappers;
using Data.Entities;

namespace Data.Mappers.Abstractions
{
    public interface IBookMapper : IDomainToDbMapper<Book, App.Domain.Book>
    {
    }
}