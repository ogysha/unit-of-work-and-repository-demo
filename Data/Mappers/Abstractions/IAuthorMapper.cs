using App.Domain;
using App.Infrastructure.Mappers;

namespace Data.Mappers.Abstractions
{
    public interface IAuthorMapper : IDbToDomainMapper<Author, Entities.Author>, IDomainToDbMapper<Entities.Author, Author>
    {
    }
}