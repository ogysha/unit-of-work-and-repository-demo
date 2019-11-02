using Data.Entities.EF;

namespace Data.Mappers.EF
{
    public interface IAuthorMapper : IDomainToDbMapper<Author, App.Domain.Author>
    {
    }
}